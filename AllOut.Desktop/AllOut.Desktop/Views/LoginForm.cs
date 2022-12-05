using AllOut.Desktop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ResetError()
        {
            lblLoginError.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ResetError();

            if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblLoginError.Text = Constants.ERROR_EMPTY_CREDENTIAL;
                return;
            }

            if(txtUsername.Text.ToUpper() != "ADMIN" &&
                txtPassword.Text.ToUpper() != "ADMIN")
            {
                lblLoginError.Text = Constants.ERROR_INCORRECT_CREDENTIAL;
                return;
            }

            var mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
