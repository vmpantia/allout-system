using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.BrandForms
{
    public partial class BrandForm : Form
    {
        private bool _isAdd = true;
        private Brand _brandInfo = new Brand();

        public BrandForm(Guid brandID = new Guid())
        {
            InitializeComponent();

            if(brandID != Guid.Empty)
                _isAdd = false;

            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_BRAND) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_BRAND);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_BRAND) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_BRAND);

            PopulateBrand(brandID);
        }

        private async void PopulateBrand(Guid brandID)
        {
            //Check if Add or Edit
            if(!_isAdd)
            {
                //Get Brand based on the given ID
                var response = await HttpController.GetBrandByID(brandID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show(response.Data.ToString(),
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_BRAND), 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                    return;
                }
                _brandInfo = response.Data as Brand;
            }

            PopulateFields(_brandInfo);
            EnableFieldsAndButtons(_brandInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private void EnableFieldsAndButtons(bool isEnabled)
        {
            txtName.Enabled = isEnabled;
            txtDescription.Enabled = isEnabled;
            btnSave.Enabled= isEnabled;
        }

        private void PopulateFields(Brand brand)
        {
            txtName.Text = brand.Name;
            txtDescription.Text = brand.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Check if Brand Name Field is Empty
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show(string.Format(Constants.ERROR_NAME_REQUIRED, Constants.OBJECT_BRAND),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_BRAND),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            //Disable Fields and Buttons
            EnableFieldsAndButtons(false);

            //Store new values in corresponding attribute
            _brandInfo.Name = txtName.Text;
            _brandInfo.Description = txtDescription.Text;
            _brandInfo.Status = Constants.STATUS_ENABLED_INT;


            //Prepare Request for SaveBrand
            var request = new SaveBrandRequest
            {
                UserID = Guid.NewGuid(),
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_BRAND_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_BRAND_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                inputBrand = _brandInfo,
            };

            //Send Request for SaveBrand
            var response = await HttpController.PostSaveBrand(request);

            //Enable Fields and Buttons
            EnableFieldsAndButtons(true);

            //Check Response Result
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_BRAND),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_SAVED, Constants.OBJECT_BRAND, response.Data),
                            string.Format(Constants.TITLE_SAVE, Constants.OBJECT_BRAND),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _brandInfo = null;
            Close();
        }
    }
}
