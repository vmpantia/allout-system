using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.CategoryForms
{
    public partial class RoleForm : Form
    {
        private bool _isAdd = true;
        private Category _categoryInfo = new Category();

        public RoleForm(Guid brandID = new Guid())
        {
            InitializeComponent();

            _isAdd = brandID == Guid.Empty;
            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_CATEGORY) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_CATEGORY);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_CATEGORY) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_CATEGORY);

            PopulateCategory(brandID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Disable Controls
            EnableControls(false);

            //Populate Text Fields in Data
            _categoryInfo.Name = txtName.Text;
            _categoryInfo.Description = txtDescription.Text;
            _categoryInfo.Status = Constants.STATUS_ENABLED_INT;

            //Prepare Request for Save
            var request = new SaveCategoryRequest
            {
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_CATEGORY_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_CATEGORY_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                client = Globals.ClientInformation,
                inputCategory = _categoryInfo
            };

            //Send Request for Save
            var response = HttpController.PostSaveCategoryAsync(request);

            //Enable Controls
            EnableControls(true);

            //Check Response Result
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_CATEGORY),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_SAVED, Constants.OBJECT_CATEGORY, response.Data),
                            string.Format(Constants.TITLE_SAVE, Constants.OBJECT_CATEGORY),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _categoryInfo = null;
            Close();
        }

        private void PopulateCategory(Guid brandID)
        {
            //Check if Add or Edit
            if (!_isAdd)
            {
                //Get Category based on the given ID
                var response = HttpController.GetCategoryByIDAsync(Globals.ClientInformation.ClientID, brandID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show((string)response.Data,
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_CATEGORY),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                _categoryInfo = response.Data as Category;
            }
            
            //Populate Data in Text Fields
            txtName.Text = _categoryInfo.Name;
            txtDescription.Text = _categoryInfo.Description;

            EnableControls(_categoryInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private void EnableControls(bool isEnabled)
        {
            txtName.Enabled = isEnabled;
            txtDescription.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
    }
}
