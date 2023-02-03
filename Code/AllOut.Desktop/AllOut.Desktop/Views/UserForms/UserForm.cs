using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

            PopulateRoles();
            PopulateUser(userID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Disable Controls
            EnableControls(false);

            //Populate Text Fields in Data
            _userInfo.Email = txtEmail.Text;
            _userInfo.Username = string.Format(Constants.USERNAME_FORMAT, txtLastName.Text.Trim(), txtFirstName.Text.Trim()).ToLower();
            _userInfo.FirstName = txtFirstName.Text;
            _userInfo.MiddleName = txtMiddleName.Text;
            _userInfo.LastName = txtLastName.Text;
            _userInfo.IsEmailConfirmed = false;
            _userInfo.RoleID = (Guid)cmdRole.SelectedValue;
            _userInfo.Status = Constants.STATUS_ENABLED_INT;

            //Prepare Request for Save
            var request = new SaveUserRequest
            {
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_USER_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_USER_BY_ADMIN,
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
            txtUsername.Text = _userInfo.Username;
            txtFirstName.Text = _userInfo.FirstName;
            txtMiddleName.Text = _userInfo.MiddleName;
            txtLastName.Text = _userInfo.LastName;
            cmdRole.SelectedValue = _userInfo.RoleID;

            EnableControls(_userInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private void PopulateRoles()
        {
            var categories = new List<Role>();
            var response = HttpController.GetRolesByStatusAsync(Globals.ClientInformation.ClientID, Constants.STATUS_ENABLED_INT);

            if (response.Result == ResponseResult.SUCCESS)
                categories = ((List<Role>)response.Data).OrderBy(data => data.Name).ToList();

            categories.Insert(0, new Role
            {
                RoleID = Guid.Empty,
                Name = string.Format(Constants.CMB_PLACEHOLDER, Constants.OBJECT_ROLE),
            });

            cmdRole.DataSource = categories;
            cmdRole.DisplayMember = Constants.CMB_DISPLAY_NAME;
            cmdRole.ValueMember = Constants.CMB_VALUE_ROLE_ID;
        }

        private void EnableControls(bool isEnabled)
        {
            txtEmail.Enabled = isEnabled;
            txtFirstName.Enabled = isEnabled;
            txtMiddleName.Enabled = isEnabled;
            txtLastName.Enabled = isEnabled;
            cmdRole.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
    }
}
