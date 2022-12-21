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
    public partial class CategoryForm : Form
    {
        private bool _isAdd = true;
        private Category _categoryInfo = new Category();

        public CategoryForm(Guid categoryID = new Guid())
        {
            InitializeComponent();

            if(categoryID != Guid.Empty)
                _isAdd = false;

            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_CATEGORY) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_CATEGORY);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_CATEGORY) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_CATEGORY);

            PopulateCategory(categoryID);
        }

        private async void PopulateCategory(Guid categoryID)
        {
            //Check if Add or Edit
            if(!_isAdd)
            {
                //Get Category based on the given ID
                var response = await HttpController.GetCategoryByID(categoryID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show(response.Data.ToString(),
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_CATEGORY), 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                    return;
                }
                _categoryInfo = response.Data as Category;
            }

            PopulateFields(_categoryInfo);
            EnableFields(_categoryInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private void EnableFields(bool isEnabled)
        {
            txtName.Enabled = isEnabled;
            txtDescription.Enabled = isEnabled;
            tglStatus.Enabled = isEnabled;
        }

        private void PopulateFields(Category category)
        {
            txtName.Text = category.Name;
            txtDescription.Text = category.Description;
            tglStatus.Checked = Utility.ConvertStatusToBoolean(category.Status);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Check if Category Name Field is Empty
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show(string.Format(Constants.ERROR_NAME_REQUIRED, Constants.OBJECT_CATEGORY),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_CATEGORY),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            //Disable Fields
            EnableFields(false);

            //Store new values in corresponding attribute
            _categoryInfo.Name = txtName.Text;
            _categoryInfo.Description = txtDescription.Text;
            _categoryInfo.Status = Utility.ConvertBooleanToStatus(tglStatus.Checked);


            //Prepare Request for SaveCategory
            var request = new SaveCategoryRequest
            {
                UserID = Guid.NewGuid(),
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_CATEGORY_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_CATEGORY_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                inputCategory = _categoryInfo,
            };

            //Send Request for SaveCategory
            var response = await HttpController.PostSaveCategory(request);

            //Enable Fields
            EnableFields(true);

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

        private void tglStatus_CheckedChanged(object sender, EventArgs e)
        {
            EnableFields(tglStatus.Checked);
            lblStatus.Text = (tglStatus.Checked ? Constants.STATUS_ENABLED_STRING : Constants.STATUS_DISABLED_STRING).ToUpper();
            lblStatus.ForeColor = tglStatus.Checked ? Color.FromArgb(39, 174, 96) : Color.FromArgb(64, 64, 64);
        }
    }
}
