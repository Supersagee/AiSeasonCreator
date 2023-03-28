using Aydsko.iRacingData;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRacingSeasonCreator
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            if (ErrorLoginText != null)
            {
                loginErrorLabel.Text = ErrorLoginText;
                loginErrorLabel.Visible = true;
            }

            userNameBox.KeyPress += loginButton_KeyPress;
            userPasswordBox.KeyPress += loginButton_KeyPress;
            userPasswordBox.PasswordChar = '*';

        }

        private async void loginButton_Click(object sender, EventArgs e)
        {

            bool validUser = await IRacingService.LoginWindow(userNameBox.Text, userPasswordBox.Text);

            if (validUser)
            {
                userPasswordBox.Text = "";
                Close();
            }
            else
            {
                loginErrorLabel.Text = "Username or Password incorrect. Please try again.";
                loginErrorLabel.Visible = true;

            }
        }

        private void loginButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }

        public static string? ErrorLoginText { get; set; }
    }
}
