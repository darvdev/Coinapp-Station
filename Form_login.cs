using System;
using System.Windows.Forms;
using CoinappStation.constant;
using Firebase.Auth;
using Newtonsoft.Json;

namespace CoinappStation
{
    public partial class Form_login : Form
    {
        bool start = false;
        FirebaseAuthProvider authProvider;
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

        private async void button_login_Click(object sender, EventArgs e)
        {
            button_login.Enabled = false;
            button_login.Text = "LOGGING IN...";

            try
            {
                authProvider = new FirebaseAuthProvider(new FirebaseConfig(API.key));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(textBox_email.Text, textBox_password.Text);
                auth.FirebaseAuthRefreshed += Auth_FirebaseAuthRefreshed;
                Program.FirebaseToken = auth.FirebaseToken;
                MessageBox.Show(auth.User.LocalId);
                
                //MessageBox.Show(auth.FirebaseToken);
                //var user = auth.User;

                
            }
            catch (Exception ex)
            {
                dynamic result = JsonConvert.SerializeObject(ex.Message);
                dynamic abc = JsonConvert.DeserializeObject(result);
                MessageBox.Show(abc, "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                button_login.Enabled = true;
                button_login.Text = "LOGIN";
                return;
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
    }
}
