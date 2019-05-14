using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzLearn_Game_Configuration
{
    public partial class UserForm : Form
    {
        IUserManager userManager;
        ISharedManager sharedManager;
        bool login;

        public UserForm(IUserManager um, ISharedManager sm)
        {
            userManager = um;
            sharedManager = sm;
            login = true;

            InitializeComponent();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            sharedManager.SqlPressCheck(e);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            sharedManager.SqlDownCheck(sender, e);
        }

        public void SetLogin()
        {
            Text = "PuzzLearn - Login";
            TitleLabel.Text = "Login";
            SwitchModeButton.Text = "Create New Account";
            ConfirmPasswordPanel.Visible = false;
            login = true;

            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        public void SetCreateAccount()
        {
            Text = "PuzzLearn - Account";
            TitleLabel.Text = "Create Account";
            ConfirmPasswordPanel.Visible = true;
            login = false;
            SwitchModeButton.Text = "Back to Login";

            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";
            ConfirmPasswordTextBox.Text = "";
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (login)
                userManager.ConfirmLogin(this, UsernameTextBox.Text, PasswordTextBox.Text);
            else
                userManager.ConfirmAccount(this, UsernameTextBox.Text, PasswordTextBox.Text, ConfirmPasswordTextBox.Text);
        }

        private void SwitchModeButton_Click(object sender, EventArgs e)
        {
            if (login)
                userManager.CreateNewAccount(this);
            else
                userManager.Login(this);
        }
    }
}
