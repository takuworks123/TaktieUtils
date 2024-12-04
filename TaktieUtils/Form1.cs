using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TaktieUtils
{
    public partial class Form1 : Form
    {
        // キー監視用のため、WindowsAPIのインポート
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern short GetKeyState(int nVirtKey);

        // nAudio用の変数
        private MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();
        private MMDevice selectedDevice;

        // ミュート用の変数
        KeyClass keyBind1;
        KeyClass keyBind2;
        private System.Media.SoundPlayer sound = null;

        // KeyCheckTimer用の変数
        private bool keyDownCooldown = false;

        // AfkTimer用の変数
        private int idleCounter = 0;
        private int mousePosX = 0;
        private const string POWERPLAN_SAVING = "a1841308-3541-4fab-bc81-f71556f20b4a";
        private const string POWERPLAN_BALANCE = "381b4222-f694-41f0-9685-ff5bb260df2e";

        // タスクトレイに入れる変数
        NotifyIcon notifyIcon = new NotifyIcon();


        public Form1()
        {
            InitializeComponent();

            InitializeAudioDeviceCombobox();
            InitializeKeyBindCombobox();
            LoadConfig();
            InitializeKeyCheckTimer();
            InitializeAfkTimer();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            // アイコンを表示する
            notifyIcon.Visible = true;
            // アイコンにマウスポインタを合わせたときのテキスト
            notifyIcon.Text = "TaktieUtils - ダブルクリックで表示";

            notifyIcon.Icon = new Icon(@"data/unmute.ico");
            UpdateIcon();

            // コンテキストメニュー
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem TSMItoggleMute = new ToolStripMenuItem();
            ToolStripMenuItem TSMIexit = new ToolStripMenuItem();

            TSMItoggleMute.Text = "ミュート切り替え";
            TSMItoggleMute.Click += TSMItoggleMute_Click;
            contextMenuStrip.Items.Add(TSMItoggleMute);

            TSMIexit.Text = "終了";
            TSMIexit.Click += TSMIexit_Click;
            contextMenuStrip.Items.Add(TSMIexit);

            notifyIcon.ContextMenuStrip = contextMenuStrip;

            // NotifyIconのクリックイベント
            notifyIcon.DoubleClick += NotifyIcon_Click;
        }
        private void TSMItoggleMute_Click(object sender, EventArgs e)
        {
            ToggleMute();
        }
        private void TSMIexit_Click(object sender, EventArgs e)
        {
            // アイコンを非表示にする
            notifyIcon.Visible = false;
            // アプリケーションの終了
            Application.Exit();
        }
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            // Formの表示/非表示を反転
            this.Visible = !this.Visible;
            this.WindowState = FormWindowState.Normal;
        }
        private void UpdateIcon()
        {
            if (selectedDevice == null) return;

            if (selectedDevice.AudioEndpointVolume.Mute) {
                notifyIcon.Icon = new Icon(@"data/mute.ico");
            } else {
                notifyIcon.Icon = new Icon(@"data/unmute.ico");
            }
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    this.Visible = true;
                    break;
                case FormWindowState.Minimized:
                    this.Visible = false;
                    break;
                default:
                    break;
            }
        }



        private void InitializeAudioDeviceCombobox()
        {
            comboBox_AudioDevices.Items.Clear();
            comboBox_AudioDevices.Items.Add("");

            // コンボボックスにデバイスを追加
            var inputDevices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            foreach (var device in inputDevices) {
                comboBox_AudioDevices.Items.Add(device);
            }
        }
        private void ToggleMute()
        {
            if (selectedDevice == null) return;

            if (selectedDevice.AudioEndpointVolume.Mute) {
                selectedDevice.AudioEndpointVolume.Mute = false;
                PlaySound("data/unmute.wav");
            } else {
                selectedDevice.AudioEndpointVolume.Mute = true;
                PlaySound("data/mute.wav");
            }
            UpdateIcon();
        }
        private void comboBox_AudioDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AudioDevices.SelectedItem.ToString() == "") {
                selectedDevice = null;
            } else {
                selectedDevice = comboBox_AudioDevices.SelectedItem as MMDevice;
            }
            UpdateIcon();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ToggleMute();
        }
        // デバイス変更メッセージを処理するためのメソッド
        protected override void WndProc(ref Message m)
        {
            // オーディオデバイスの変更を検出用の変数
            const int WM_DEVICECHANGE = 0x0219;
            const int DBT_DEVNODES_CHANGED = 0x0007;

            base.WndProc(ref m);
            if (m.Msg == WM_DEVICECHANGE && (int)m.WParam == DBT_DEVNODES_CHANGED) {
                // オーディオデバイスの変更を検出
                InitializeAudioDeviceCombobox();
            }
        }
        private void PlaySound(string waveFile)
        {
            //再生されているときは止める
            if (sound != null) StopSound();

            //読み込む
            sound = new System.Media.SoundPlayer(waveFile);
            //非同期再生する
            sound.Play();
        }
        private void StopSound()
        {
            if (sound != null) {
                sound.Stop();
                sound.Dispose();
                sound = null;
            }
        }



        private void InitializeKeyCheckTimer()
        {
            KeyCheckTimer.Interval = 50; // 0.05秒ごとにチェック
            if (checkBox_MuteKeyBind.Checked) KeyCheckTimer.Start();
        }
        private void InitializeKeyBindCombobox()
        {
            var keyClassList = new List<KeyClass>();
            keyClassList.Add(new KeyClass { key = System.Windows.Forms.Keys.None, name = "" });
            keyClassList.Add(new KeyClass { key = System.Windows.Forms.Keys.LControlKey, name = "L Ctrl" });
            keyClassList.Add(new KeyClass { key = System.Windows.Forms.Keys.RControlKey, name = "R Ctrl" });
            keyClassList.Add(new KeyClass { key = System.Windows.Forms.Keys.LMenu, name = "L Alt" });
            keyClassList.Add(new KeyClass { key = System.Windows.Forms.Keys.IMENonconvert, name = "無変換" });

            comboBox_KeyBind1.DisplayMember = "name";
            comboBox_KeyBind2.DisplayMember = "name";

            foreach (var key in keyClassList) {
                comboBox_KeyBind1.Items.Add(key);
                comboBox_KeyBind2.Items.Add(key);
            }
        }
        private bool IsKeyPushing(System.Windows.Forms.Keys keyValue)
        {
            // WindowsAPIで押下判定
            bool keyState = (GetKeyState((int)keyValue) & 0x80) != 0;
            return keyState;
        }
        private void comboBox_KeyBind1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyBind1 = comboBox_KeyBind1.SelectedItem as KeyClass;
        }

        private void comboBox_KeyBind2_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyBind2 = comboBox_KeyBind2.SelectedItem as KeyClass;
        }
        private void KeyCheckTimer_Tick(object sender, EventArgs e)
        {
            if (keyBind1 == null) keyBind1 = new KeyClass { key = System.Windows.Forms.Keys.None, name = "" };
            if (keyBind2 == null) keyBind2 = new KeyClass { key = System.Windows.Forms.Keys.None, name = "" };

            bool flag = false;

            if (keyBind1.key != System.Windows.Forms.Keys.None && keyBind2.key != System.Windows.Forms.Keys.None) {
                if (IsKeyPushing(keyBind1.key) && IsKeyPushing(keyBind2.key)) flag = true;
            } else {
                if (keyBind1.key != System.Windows.Forms.Keys.None && IsKeyPushing(keyBind1.key)) flag = true;
                else if(keyBind2.key != System.Windows.Forms.Keys.None && IsKeyPushing(keyBind2.key)) flag = true;
            }

            if (flag) {
                // 押した瞬間だけToggleMuteが発動するように
                if (keyDownCooldown == false) {
                    keyDownCooldown = true;
                    ToggleMute();
                }
            } else {
                keyDownCooldown = false;
            }
        }



        private void InitializeAfkTimer()
        {
            AfkTimer.Interval = 500; // 0.5秒ごとにチェック
            if (checkBox_AfkPowerSaving.Checked) AfkTimer.Start();
        }
        private void textBox_idleThreshold_TextChanged(object sender, EventArgs e)
        {
            int time;
            if (textBox_idleThreshold.Text == "") {
                time = 2000000000;
            } else if (int.TryParse(textBox_idleThreshold.Text, out time) == false) {
                time = 1;
            } else {
                if (time <= 0) time = 1;
            }

            textBox_idleThreshold.Text = time.ToString();
        }
        private void AfkTimer_Tick(object sender, EventArgs e)
        {
            // textBox_AfkDisableTaskProcessが起動していたらタイマーを止める
            if (Process.GetProcessesByName(textBox_AfkDisableTaskProcess.Text).Any() == true) {
                if (idleCounter <= -1) {
                    SetPowercfg(POWERPLAN_BALANCE);
                }
                idleCounter = 0;
                return;
            }

            int tempMousePos = Control.MousePosition.X;

            if (mousePosX != tempMousePos) {
                mousePosX = tempMousePos;

                if (idleCounter <= -1) { // AFK解除処理
                    SetPowercfg(POWERPLAN_BALANCE);
                }
                idleCounter = 0;
                return;
            }
            if (idleCounter <= -1) return; // AFK状態の場合はreturn

            idleCounter++;
            int time;
            if (int.TryParse(textBox_idleThreshold.Text, out time)) {
                if (idleCounter >= time * 2) { // 閾値を超えた場合、省電力モードに移行
                    SetPowercfg(POWERPLAN_SAVING);
                    idleCounter = -1; // カウンターをロック→ AFK状態
                }
            }
        }
        private void SetPowercfg(string guid)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "powercfg",
                    Arguments = $"/setactive {guid}",
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"電源プラン変更時にエラー: {ex.Message}");
            }
        }




        private void LoadConfig()
        {
            var config = YamlClass.LoadYaml("config.yml");
            if (config == null) {
                comboBox_AudioDevices.SelectedIndex = 0;
                return;
            }

            checkBox_MuteKeyBind.Checked = config.enableMuteKeyBind;

            // comboBox_AudioDevicesを設定
            bool flag = false;
            int i = 0;
            foreach (var device in comboBox_AudioDevices.Items) {
                if (device is MMDevice == false) continue;

                if (device.ToString() == config.audioDevice) {
                    comboBox_AudioDevices.SelectedIndex = i + 1; // +1 は、「選択なし」を飛ばすため
                    selectedDevice = (MMDevice)device;
                    flag = true;
                }
                i++;
            }
            // config.ymlに書いてあるデバイスが有効になっていない場合、初期化
            if (!flag) {
                comboBox_AudioDevices.SelectedIndex = 0;
            }

            // comboBox_KeyBindを設定
            comboBox_KeyBind1.SelectedIndex = config.keyBind1;
            comboBox_KeyBind2.SelectedIndex = config.keyBind2;

            // AFK設定
            checkBox_AfkPowerSaving.Checked = config.enableAfkPowerSaving;
            textBox_idleThreshold.Text = config.idleThreshold;
            textBox_AfkDisableTaskProcess.Text = config.afkDisableTaskProcess;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string deviceName = "";
            if (selectedDevice != null) {
                deviceName = selectedDevice.ToString();
            }
            ConfigClass config = new ConfigClass
            {
                enableMuteKeyBind = checkBox_MuteKeyBind.Checked,
                audioDevice = deviceName,
                keyBind1 = comboBox_KeyBind1.SelectedIndex,
                keyBind2 = comboBox_KeyBind2.SelectedIndex,
                enableAfkPowerSaving = checkBox_AfkPowerSaving.Checked,
                idleThreshold = textBox_idleThreshold.Text,
                afkDisableTaskProcess = textBox_AfkDisableTaskProcess.Text
            };
            YamlClass.SaveYaml("config.yml", config);

            KeyCheckTimer.Stop();
            AfkTimer.Stop();
        }

        private void checkBox_MicMute_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_MuteKeyBind.Checked) {
                KeyCheckTimer.Start();
            } else {
                KeyCheckTimer.Stop();
            }
        }

        private void checkBox_AfkPowerSaving_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AfkPowerSaving.Checked) {
                AfkTimer.Start();
            } else {
                AfkTimer.Stop();
            }
        }
    }
}
