using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.RoleForms
{
    public partial class RoleForm : Form
    {
        private bool _isAdd = true;
        private Role _roleInfo = new Role();

        public RoleForm(Guid roleID = new Guid())
        {
            InitializeComponent();

            _isAdd = roleID == Guid.Empty;
            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_ROLE) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_ROLE);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_ROLE) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_ROLE);

            PopulateRole(roleID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Disable Controls
            EnableControls(false);

            //Populate Text Fields in Data
            _roleInfo.Name = txtName.Text;
            _roleInfo.Status = Constants.STATUS_ENABLED_INT;
            GetPermissionsValue(_roleInfo);

            //Prepare Request for Save
            var request = new SaveRoleRequest
            {
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_ROLE_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_ROLE_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                client = Globals.ClientInformation,
                inputRole = _roleInfo
            };

            //Send Request for Save
            var response = HttpController.PostSaveRoleAsync(request);

            //Enable Controls
            EnableControls(true);

            //Check Response Result
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_ROLE),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_SAVED, Constants.OBJECT_ROLE, response.Data),
                            string.Format(Constants.TITLE_SAVE, Constants.OBJECT_ROLE),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _roleInfo = null;
            Close();
        }

        private void PopulateRole(Guid roleID)
        {
            //Check if Add or Edit
            if (!_isAdd)
            {
                //Get Category based on the given ID
                var response = HttpController.GetRoleByIDAsync(Globals.ClientInformation.ClientID, roleID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show((string)response.Data,
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_ROLE),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                _roleInfo = response.Data as Role;
            }
            
            //Populate Data in Text Fields
            txtName.Text = _roleInfo.Name;
            PopulatePermissions(_roleInfo);

            EnableControls(_roleInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private void PopulatePermissions(Role role)
        {
            tblObjectList.Rows.Clear();

            var properties = role.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.Name.Contains(Constants.OBJECT_PERMISSION))
                {
                    var name = property.Name.Replace(Constants.OBJECT_PERMISSION, string.Empty);
                    var permission = (int)property.GetValue(role);

                    tblObjectList.Rows.Add(name, Utility.IsPermitted(permission, PermissionType.ADD),
                                                 Utility.IsPermitted(permission, PermissionType.EDIT),
                                                 Utility.IsPermitted(permission, PermissionType.DELETE));
                }
            }
        }

        private void GetPermissionsValue(Role role)
        {
            var properties = role.GetType().GetProperties();

            for (var idx = 0; idx < tblObjectList.Rows.Count; idx++)
            {
                var name = string.Concat(tblObjectList.Rows[idx].Cells[0].Value.ToString(), Constants.OBJECT_PERMISSION);
                var add = (bool)tblObjectList.Rows[idx].Cells[1].Value;
                var edit = (bool)tblObjectList.Rows[idx].Cells[2].Value;
                var delete = (bool)tblObjectList.Rows[idx].Cells[3].Value;

                int permission = 0, index = 0;
                if (add)
                    permission |= 1 << index; //1

                index++;

                if (edit)
                    permission |= 1 << index; //2

                index++;

                if (delete)
                    permission |= 1 << index; //4

                var props = properties.Where(data => data.Name == name).ToList();
                if (props == null || props.Count == 0)
                    continue;

                var property = props.First();
                property.SetValue(role, permission);
            }
        }

        private void EnableControls(bool isEnabled)
        {
            txtName.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
    }
}
