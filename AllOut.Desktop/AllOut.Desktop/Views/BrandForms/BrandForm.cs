using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
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

            lblBrandFormTitle.Text = _isAdd ? Constants.TITLE_ADD_BRAND : Constants.TITLE_EDIT_BRAND;
            lblBrandFormDescription.Text = _isAdd ? Constants.DESCRIPTION_ADD_BRAND : Constants.DESCRIPTION_EDIT_BRAND;

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
                                    Constants.TITLE_EDIT_BRAND, 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                    return;
                }
                _brandInfo = response.Data as Brand;
            }

            PopulateFields(_brandInfo);
            EnableFields(_brandInfo.Status == Constants.INT_STATUS_ENABLED);
        }

        private void EnableFields(bool isEnabled)
        {
            txtBrandName.Enabled = isEnabled;
            txtBrandDescription.Enabled = isEnabled;
        }

        private void PopulateFields(Brand brand)
        {
            txtBrandName.Text = brand.Name;
            txtBrandDescription.Text = brand.Description;
            tglStatus.Checked = Utility.ConvertStatusToBoolean(brand.Status);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Check if Brand Name Field is Empty
            if (string.IsNullOrEmpty(txtBrandName.Text))
            {
                MessageBox.Show(string.Format(Constants.MESSAGE_OBJECT_NAME_REQUIRED, Constants.OBJECT_BRAND),
                                Constants.TITLE_SAVE_BRAND,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            //Disable Fields
            EnableFields(false);

            //Store new values in corresponding attribute
            _brandInfo.Name = txtBrandName.Text;
            _brandInfo.Description = txtBrandDescription.Text;
            _brandInfo.Status = Utility.ConvertBooleanToStatus(tglStatus.Checked);


            //Prepare Request for SaveBrand
            var request = new BrandRequest
            {
                UserID = Guid.NewGuid(),
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_BRAND_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_BRAND_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                inputBrand = _brandInfo,
            };

            //Send Request for SaveBrand
            var response = await HttpController.PostSaveBrand(request);

            //Enable Fields
            EnableFields(true);

            //Check Response Result
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                Constants.TITLE_SAVE_BRAND,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.MESSAGE_OBJECT_SAVED, Constants.OBJECT_BRAND) + response.Data,
                            Constants.TITLE_SAVE_BRAND,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _brandInfo = null;
            Close();
        }

        private void tglStatus_CheckedChanged(object sender, EventArgs e)
        {
            EnableFields(tglStatus.Checked);
            lblStatus.Text = (tglStatus.Checked ? Constants.STRING_STATUS_ENABLED : Constants.STRING_STATUS_DISABLED).ToUpper();
            lblStatus.ForeColor = tglStatus.Checked ? Constants.COLOR_STATUS_ENABLED : Constants.COLOR_STATUS_DISABLED;
        }
    }
}
