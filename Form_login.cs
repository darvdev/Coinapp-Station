using System;
using System.Windows.Forms;

namespace CoinappStation
{
    public partial class Form_login : Form
    {
        bool start = false;
        public Form_login()
        {
            InitializeComponent();
            //Text = ProductName + " " + ProductVersion;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!start)
            {
                Environment.Exit(0);
            }
            else
            {
                Program.form_station.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start = true;
            Close();
        }
    }
}
