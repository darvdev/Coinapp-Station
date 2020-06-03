using MaterialSkin.Controls;

namespace CoinappStation
{
    partial class Form_login : MaterialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_login));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_login = new MaterialSkin.Controls.MaterialRaisedButton();
            this.button_station = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textbox_email = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textbox_password = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(104, 375);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Forgot your password?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(73, 354);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Don\'t have an account? Sign up";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.White;
            this.button_login.Depth = 0;
            this.button_login.Location = new System.Drawing.Point(79, 228);
            this.button_login.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_login.Name = "button_login";
            this.button_login.Primary = true;
            this.button_login.Size = new System.Drawing.Size(200, 36);
            this.button_login.TabIndex = 7;
            this.button_login.Text = "LOGIN";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_station
            // 
            this.button_station.BackColor = System.Drawing.Color.White;
            this.button_station.Depth = 0;
            this.button_station.Location = new System.Drawing.Point(79, 286);
            this.button_station.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_station.Name = "button_station";
            this.button_station.Primary = true;
            this.button_station.Size = new System.Drawing.Size(200, 36);
            this.button_station.TabIndex = 7;
            this.button_station.Text = "STATION";
            this.button_station.UseVisualStyleBackColor = false;
            this.button_station.Click += new System.EventHandler(this.button_station_Click);
            // 
            // textbox_email
            // 
            this.textbox_email.Depth = 0;
            this.textbox_email.Hint = "Email";
            this.textbox_email.Location = new System.Drawing.Point(65, 123);
            this.textbox_email.MouseState = MaterialSkin.MouseState.HOVER;
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.PasswordChar = '\0';
            this.textbox_email.SelectedText = "";
            this.textbox_email.SelectionLength = 0;
            this.textbox_email.SelectionStart = 0;
            this.textbox_email.Size = new System.Drawing.Size(233, 23);
            this.textbox_email.TabIndex = 8;
            this.textbox_email.UseSystemPasswordChar = false;
            // 
            // textbox_password
            // 
            this.textbox_password.Depth = 0;
            this.textbox_password.Hint = "Password";
            this.textbox_password.Location = new System.Drawing.Point(65, 171);
            this.textbox_password.MouseState = MaterialSkin.MouseState.HOVER;
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '\0';
            this.textbox_password.SelectedText = "";
            this.textbox_password.SelectionLength = 0;
            this.textbox_password.SelectionStart = 0;
            this.textbox_password.Size = new System.Drawing.Size(233, 23);
            this.textbox_password.TabIndex = 8;
            this.textbox_password.UseSystemPasswordChar = true;
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(368, 441);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.textbox_email);
            this.Controls.Add(this.button_station);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coinapp Login";
            this.Load += new System.EventHandler(this.Form_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialRaisedButton button_login;
        private MaterialRaisedButton button_station;
        private MaterialSingleLineTextField textbox_email;
        private MaterialSingleLineTextField textbox_password;
    }
}