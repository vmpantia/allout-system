using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AllOut.Desktop.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            EnableButtonsAndFields(false);

            if(txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(Constants.ERROR_PASSWORD_NOT_MATCH,
                                string.Format(Constants.TITLE_REGISTER, Constants.OBJECT_USER),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                EnableButtonsAndFields(true);
                return;
            }


            var request = new SaveUserRequest
            {
                FunctionID = Constants.FUNCTION_ID_ADD_USER,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                client = new Client
                {
                    ClientID = Guid.Empty,
                    UserID = Guid.Empty,
                    Name = string.Empty,
                    Browser = string.Empty,
                    IPAddress = string.Empty,
                    WindowsVersion = string.Empty,
                    Status = Constants.STATUS_ENABLED_INT
                },
                inputUser = new User
                {
                    UserID = Guid.Empty,
                    Email = txtEmail.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    MiddleName = txtMiddleName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Password = Utility.EncodePassword(txtPassword.Text.Trim()),
                    IsEmailConfirmed = false,
                    RoleID = Guid.Empty,
                    Status = Constants.STATUS_ENABLED_INT,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                }
            };

            var response = HttpController.PostSaveUserAsync(request);
            EnableButtonsAndFields(true);

            if (response.Result == ResponseResult.API_ERROR)
            {
                MessageBox.Show((string)response.Data, 
                                string.Format(Constants.TITLE_REGISTER, Constants.OBJECT_USER), 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_SAVED, Constants.OBJECT_USER, (string)response.Data),
                            string.Format(Constants.TITLE_REGISTER, Constants.OBJECT_USER),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = string.Format(Constants.USERNAME_FORMAT, txtLastName.Text.Trim(), txtFirstName.Text.Trim()).ToLower();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            txtUsername.Text = string.Format(Constants.USERNAME_FORMAT, txtLastName.Text.Trim(), txtFirstName.Text.Trim()).ToLower();
        }

        private void EnableButtonsAndFields(bool enable)
        {
            btnRegister.Enabled = enable;
            btnCancel.Enabled = enable;
            txtEmail.Enabled = enable;
            txtFirstName.Enabled = enable;
            txtMiddleName.Enabled = enable;
            txtLastName.Enabled = enable;
            txtPassword.Enabled = enable;
            txtConfirmPassword.Enabled = enable;
        }
    }
}
