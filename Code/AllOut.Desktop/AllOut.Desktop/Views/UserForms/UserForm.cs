using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.UserForms
{
    public partial class UserForm : Form
    {
        private bool _isAdd = true;
        private User _userInfo = new User();

        public UserForm(Guid userID = new Guid())
        {
            InitializeComponent();

            _isAdd = userID == Guid.Empty;
            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_USER) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_USER);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_USER) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_USER);

            PopulateUser(userID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Disable Controls
            EnableControls(false);

            //Populate Text Fields in Data
            _userInfo.Email = txtEmail.Text;
            _userInfo.Username = string.Format(Constants.USERNAME_FORMAT, txtLastName.Text.Trim(), txtFirstName.Text.Trim()).ToLower();
            _userInfo.Password = string.Empty;
            _userInfo.FirstName = txtFirstName.Text;
            _userInfo.MiddleName = txtMiddleName.Text;
            _userInfo.LastName = txtLastName.Text;
            _userInfo.IsEmailConfirmed = false;
            _userInfo.Permission = int.Parse(cmbPermission.SelectedValue.ToString());
            _userInfo.Status = Constants.STATUS_ENABLED_INT;

            //Prepare Request for Save
            var request = new SaveUserRequest
            {
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_PRODUCT_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                client = Globals.ClientInformation,
                inputUser = _userInfo
            };

            //Send Request for Save
            var response = HttpController.PostSaveUserAsync(request);

            //Enable Controls
            EnableControls(true);

            //Check Response Result
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_USER),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_SAVED, Constants.OBJECT_USER, response.Data),
                            string.Format(Constants.TITLE_SAVE, Constants.OBJECT_USER),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _userInfo = null;
            Close();
        }

        private void PopulateUser(Guid userID)
        {
            //Check if Add or Edit
            if (!_isAdd)
            {
                //Get User based on the given ID
                var response = HttpController.GetUserByIDAsync(Globals.ClientInformation.ClientID, userID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show((string)response.Data,
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_USER),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                _userInfo = response.Data as User;
            }

            //Populate Data in Text Fields
            txtEmail.Text = _userInfo.Email;
            txtFirstName.Text = _userInfo.FirstName;
            txtMiddleName.Text = _userInfo.MiddleName;
            txtLastName.Text = _userInfo.LastName.ToString();
            cmbPermission.SelectedValue = _userInfo.Permission.ToString();

            EnableControls(_userInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private void EnableControls(bool isEnabled)
        {
            txtEmail.Enabled = isEnabled;
            txtFirstName.Enabled = isEnabled;
            txtMiddleName.Enabled = isEnabled;
            txtLastName.Enabled = isEnabled;
            cmbPermission.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
    }
}
