using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            ResetError();
            EnableButtonsAndFields(false);

            var loginUerRequest = new LoginUserRequest
            {
                LogonName = txtLogonName.Text,
                Password = Utility.EncryptPassowrd(txtPassword.Text),
                Browser = Constants.NA,
                IPAddress = Constants.NA,
                WindowsVersion = Constants.NA
            };

            var response = await HttpController.PostLoginUserAsync(loginUerRequest);

            EnableButtonsAndFields(true);

            if (response.Result == ResponseResult.API_ERROR)
            {
                lblLoginError.Text = (string)response.Data;
                return;
            }

            var mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
            btnClose.Enabled = enable;
            txtLogonName.Enabled = enable;
            txtPassword.Enabled = enable;
        }
    }
}
