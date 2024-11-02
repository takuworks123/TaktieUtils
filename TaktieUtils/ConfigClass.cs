using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaktieUtils
{
    internal class ConfigClass
    {
        public bool enableMuteKeyBind { get; set; }
        public string audioDevice { get; set; }
        public int keyBind1 { get; set; }
        public int keyBind2 { get; set; }
        public bool enableAfkPowerSaving { get; set; }
        public string idleThreshold { get; set; }
        public string afkDisableTaskProcess { get; set; }
    }
}
