namespace TaktieUtils
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_AudioDevices = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AfkTimer = new System.Windows.Forms.Timer(this.components);
            this.KeyCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox_KeyBind1 = new System.Windows.Forms.ComboBox();
            this.comboBox_KeyBind2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_MuteKeyBind = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_AfkDisableTaskProcess = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_idleThreshold = new System.Windows.Forms.TextBox();
            this.checkBox_AfkPowerSaving = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_AudioDevices
            // 
            this.comboBox_AudioDevices.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox_AudioDevices.FormattingEnabled = true;
            this.comboBox_AudioDevices.Location = new System.Drawing.Point(16, 21);
            this.comboBox_AudioDevices.Name = "comboBox_AudioDevices";
            this.comboBox_AudioDevices.Size = new System.Drawing.Size(325, 23);
            this.comboBox_AudioDevices.TabIndex = 0;
            this.comboBox_AudioDevices.SelectedIndexChanged += new System.EventHandler(this.comboBox_AudioDevices_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(103, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "ミュート切り替え";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AfkTimer
            // 
            this.AfkTimer.Tick += new System.EventHandler(this.AfkTimer_Tick);
            // 
            // KeyCheckTimer
            // 
            this.KeyCheckTimer.Tick += new System.EventHandler(this.KeyCheckTimer_Tick);
            // 
            // comboBox_KeyBind1
            // 
            this.comboBox_KeyBind1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox_KeyBind1.FormattingEnabled = true;
            this.comboBox_KeyBind1.Location = new System.Drawing.Point(16, 21);
            this.comboBox_KeyBind1.Name = "comboBox_KeyBind1";
            this.comboBox_KeyBind1.Size = new System.Drawing.Size(152, 23);
            this.comboBox_KeyBind1.TabIndex = 3;
            this.comboBox_KeyBind1.SelectedIndexChanged += new System.EventHandler(this.comboBox_KeyBind1_SelectedIndexChanged);
            // 
            // comboBox_KeyBind2
            // 
            this.comboBox_KeyBind2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox_KeyBind2.FormattingEnabled = true;
            this.comboBox_KeyBind2.Location = new System.Drawing.Point(189, 21);
            this.comboBox_KeyBind2.Name = "comboBox_KeyBind2";
            this.comboBox_KeyBind2.Size = new System.Drawing.Size(152, 23);
            this.comboBox_KeyBind2.TabIndex = 4;
            this.comboBox_KeyBind2.SelectedIndexChanged += new System.EventHandler(this.comboBox_KeyBind2_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_MuteKeyBind);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 321);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "マイクミュート";
            // 
            // checkBox_MuteKeyBind
            // 
            this.checkBox_MuteKeyBind.AutoSize = true;
            this.checkBox_MuteKeyBind.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox_MuteKeyBind.Location = new System.Drawing.Point(15, 39);
            this.checkBox_MuteKeyBind.Name = "checkBox_MuteKeyBind";
            this.checkBox_MuteKeyBind.Size = new System.Drawing.Size(121, 19);
            this.checkBox_MuteKeyBind.TabIndex = 7;
            this.checkBox_MuteKeyBind.Text = "キー操作を有効";
            this.checkBox_MuteKeyBind.UseVisualStyleBackColor = true;
            this.checkBox_MuteKeyBind.CheckedChanged += new System.EventHandler(this.checkBox_MicMute_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_AudioDevices);
            this.groupBox3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(15, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 65);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "対象デバイス";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_KeyBind1);
            this.groupBox2.Controls.Add(this.comboBox_KeyBind2);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(15, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 61);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "キーバインド";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.checkBox_AfkPowerSaving);
            this.groupBox4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox4.Location = new System.Drawing.Point(12, 356);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 159);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AFK省電力";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox_AfkDisableTaskProcess);
            this.groupBox6.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox6.Location = new System.Drawing.Point(204, 39);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(167, 106);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "このプロセスが起動していたら、AFK省電力を無効にする";
            // 
            // textBox_AfkDisableTaskProcess
            // 
            this.textBox_AfkDisableTaskProcess.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_AfkDisableTaskProcess.Location = new System.Drawing.Point(16, 64);
            this.textBox_AfkDisableTaskProcess.Name = "textBox_AfkDisableTaskProcess";
            this.textBox_AfkDisableTaskProcess.Size = new System.Drawing.Size(136, 22);
            this.textBox_AfkDisableTaskProcess.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_idleThreshold);
            this.groupBox5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox5.Location = new System.Drawing.Point(15, 73);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(168, 72);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "放置時間";
            // 
            // textBox_idleThreshold
            // 
            this.textBox_idleThreshold.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_idleThreshold.Location = new System.Drawing.Point(16, 30);
            this.textBox_idleThreshold.Name = "textBox_idleThreshold";
            this.textBox_idleThreshold.Size = new System.Drawing.Size(134, 22);
            this.textBox_idleThreshold.TabIndex = 0;
            this.textBox_idleThreshold.TextChanged += new System.EventHandler(this.textBox_idleThreshold_TextChanged);
            // 
            // checkBox_AfkPowerSaving
            // 
            this.checkBox_AfkPowerSaving.AutoSize = true;
            this.checkBox_AfkPowerSaving.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox_AfkPowerSaving.Location = new System.Drawing.Point(15, 39);
            this.checkBox_AfkPowerSaving.Name = "checkBox_AfkPowerSaving";
            this.checkBox_AfkPowerSaving.Size = new System.Drawing.Size(56, 19);
            this.checkBox_AfkPowerSaving.TabIndex = 8;
            this.checkBox_AfkPowerSaving.Text = "有効";
            this.checkBox_AfkPowerSaving.UseVisualStyleBackColor = true;
            this.checkBox_AfkPowerSaving.CheckedChanged += new System.EventHandler(this.checkBox_AfkPowerSaving_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 526);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "TaktieUtils - r1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_AudioDevices;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer AfkTimer;
        private System.Windows.Forms.Timer KeyCheckTimer;
        private System.Windows.Forms.ComboBox comboBox_KeyBind1;
        private System.Windows.Forms.ComboBox comboBox_KeyBind2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_idleThreshold;
        private System.Windows.Forms.CheckBox checkBox_MuteKeyBind;
        private System.Windows.Forms.CheckBox checkBox_AfkPowerSaving;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox_AfkDisableTaskProcess;
    }
}

