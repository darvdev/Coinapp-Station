using System;
using System.Windows.Forms;

namespace CoinappStation
{
    public partial class Form_dialog : Form
    {
        private bool clicked = false;
        public Form_dialog()
        {
            InitializeComponent();
        }
        const int WM_CONTEXTMENU = 0x007B;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CONTEXTMENU)
                m.Result = IntPtr.Zero;
            else
                base.WndProc(ref m);
        }
        public string ShowDialog(string pcName = "Client PC")
        {
            this.Text = pcName + " password";
            //System.Media.SystemSounds.Beep.Play();
            base.ShowDialog();
            return textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clicked = true;
            this.Close();
        }

        private void Dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!clicked)
            {
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)) button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && button1.Enabled == true)
            {
                clicked = true;
                this.Close();
            }
        }
    }
}
