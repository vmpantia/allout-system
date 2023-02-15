using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AllOut.Desktop.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ResetError();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ResetError();
            EnableButtonsAndFields(false);

            var loginUerRequest = new LoginUserRequest
            {
                LogonName = txtLogonName.Text,
                Password = Utility.ParsePassword(txtPassword.Text, true),
                Browser = Constants.NA,
                IPAddress = Constants.NA,
                WindowsVersion = Constants.NA
            };

            var response = HttpController.PostLoginUserAsync(loginUerRequest);

            EnableButtonsAndFields(true);

            if (response.Result != ResponseResult.SUCCESS)
            {
                lblLoginError.Text = (string)response.Data;
                return;
            }

            Globals.ClientInformation = (Client)response.Data;
            var mainForm = new MainForm();

            //Hide Login Form
            this.Hide();

            //Show Main Form
            mainForm.ShowDialog();
            
            //Reset Fields & Show Login Form
            txtPassword.Text = string.Empty;
            txtLogonName.Text = string.Empty;
            this.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regForm = new RegisterForm();
            regForm.ShowDialog();
        }

        private void ResetError()
        {
            lblLoginError.Text = string.Empty;
        }

        private void EnableButtonsAndFields(bool enable)
        {
            btnLogin.Enabled = enable;
            btnRegister.Enabled = enable;
            txtLogonName.Enabled = enable;
            txtPassword.Enabled = enable;
        }
    }
}
