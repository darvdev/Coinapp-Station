using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoinappStation.Authentication;
using Firebase.Auth;

namespace CoinappStation
{
    public partial class Form_signup : Form
    {
        private bool working = false;
        public Form_signup()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (working == true)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.Dispose();
            base.OnFormClosing(e);
        }

        private void Form_signup_Load(object sender, EventArgs e)
        {
            Task.Run((Action)(async () =>
            {
                bool connection = Brain.InternetAvailable;

                this.BeginInvoke((Action)(() => {

                    if (!connection)
                    {
                        MessageBox.Show("No internet connection", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    button_signup.Enabled = true;
                }));

                try
                {
                    Auth.AuthProvider = new FirebaseAuthProvider(new FirebaseConfig(API.key));
                    FirebaseAuthLink auth = await Auth.AuthProvider.CreateUserWithEmailAndPasswordAsync(textBox_email.Text, textBox_password.Text);

                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                    return;
                }
                
            }));

        }
    }
}
