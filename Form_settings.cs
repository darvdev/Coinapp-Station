using System;
using System.Windows.Forms;

namespace CoinappStation
{
    public partial class Form_settings : Form
    {
        private Config _config;
        public Form_settings(Config config)
        {
            InitializeComponent();
            _config = config;
            Text = config.PCNAME + " configurations";
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBoxPass.Text = _config.PASSWORD;
            textBoxEmail.Text = _config.EMAIL;
            numericShutdown.Text =_config.SHUTDOWN;
            numericHotkey.Text = _config.HOTKEYCODE;
            numericAttempt.Text = _config.LOGINATTEMPT;
            numericTimer.Text = _config.TIMER;
            numericSound.Text = _config.SOUND;
            textBoxLockimage.Text = _config.LOCKIMAGE;
            textBoxSavedata.Text = _config.SAVEDATA;
            textBoxLogs.Text = _config.LOG;
            numericStartup.Text = _config.STARTUP;
            numericTaskmgr.Text = _config.TASKMGR;

            numericPortnumber.Text = _config.PORTNUMBER;
            comboBoxBaudrate.Text = _config.BAUDRATE;
            comboBoxCoinslot.Text = _config.COINSLOT;
            numericInterval.Text = _config.INTERVAL;
            numericCoin1.Text = _config.COIN1;
            numericCoin2.Text = _config.COIN2;
            numericCoin3.Text = _config.COIN3;
            numericPulse1.Text = _config.PULSE1;
            numericPulse2.Text = _config.PULSE2;
            numericPulse3.Text = _config.PULSE3;
            
        }
    }
}

