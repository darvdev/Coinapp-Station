using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoinappStation.Authentication;
using Firebase.Auth;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace CoinappStation
{
    public partial class Form_signup : Form
    {
        private bool working = false;
        FirebaseAuthLink auth;
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

                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "", icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
                    return;
                }
                
            }));

        }

        private  void button_signup_Click(object sender, EventArgs e)
        {
            Task.Run((Action)(async () => {
                try
                {
                    auth = await Auth.AuthProvider.CreateUserWithEmailAndPasswordAsync(textBox_email.Text, textBox_password.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Substring(ex.Message.IndexOf("reason: "), 3), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //ShowErrorJson(ex.Message);
                    return;
                }

                MessageBox.Show(auth.User.LocalId);
            }));
            
        }

        private void ShowErrorJson(string data)
        {
            try
            {
                dynamic result = JsonConvert.DeserializeObject("{"+ data + "}");
                MessageBox.Show(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
