using System;
using System.Windows.Forms;
using CoinappStation.Authentication;
using Firebase.Auth;
using Newtonsoft.Json;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Drawing;

namespace CoinappStation
{
    public partial class Form_login : MaterialForm
    {
        bool start = false;
        FirebaseAuthProvider authProvider;
        public Form_login()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!start)
            {
                Environment.Exit(0);
            }
            else
            {
                Brain.form_station.Show();
            }
        }

        private async void button_login_Click(object sender, EventArgs e)
        {
            button_login.Enabled = false;
            button_login.Text = "LOGGING IN...";

            try
            {
                authProvider = new FirebaseAuthProvider(new FirebaseConfig(API.key));
                FirebaseAuthLink auth = await authProvider.SignInWithEmailAndPasswordAsync(textbox_email.Text, textbox_password.Text);
                //auth.FirebaseAuthRefreshed += Auth_FirebaseAuthRefreshed;
                Auth.FirebaseToken = auth.FirebaseToken;
                MessageBox.Show(auth.User.LocalId);
                
                //MessageBox.Show(auth.FirebaseToken);
                //var user = auth.User;

                
            }
            catch (Exception ex)
            {
                this.BeginInvoke((Action)(() => MessageBox.Show(ex.Message.Substring(ex.Message.IndexOf("Reason: ") + 8), "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
            }

            button_login.Enabled = true;
            button_login.Text = "LOGIN";

        }

        private void Auth_FirebaseAuthRefreshed(object sender, FirebaseAuthEventArgs e)
        {
            MessageBox.Show("Firebase auto refreshed");
            MessageBox.Show(sender.ToString());
            MessageBox.Show(e.FirebaseAuth.FirebaseToken);
            MessageBox.Show(e.FirebaseAuth.RefreshToken);
        }

        private void Form_login_Load(object sender, EventArgs e)
        {
            //Product product = new Product();
            //product.Name = "Apple";
            //product.Expiry = new DateTime(2008, 12, 28);
            //product.Price = 3.99M;
            //product.Sizes = new string[] { "Small", "Medium", "Large" };

            //string json = JsonConvert.SerializeObject(product);
            ////{
            ////  "Name": "Apple",
            ////  "Expiry": "2008-12-28T00:00:00",
            ////  "Price": 3.99,
            ////  "Sizes": [
            ////    "Small",
            ////    "Medium",
            ////    "Large"
            ////  ]
            ////}

            //Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
        }

        private void button_station_Click(object sender, EventArgs e)
        {
            start = true;
            Close();
        }
    }
}
