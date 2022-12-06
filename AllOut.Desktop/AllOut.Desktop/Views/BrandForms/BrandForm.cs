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
            if(!_isAdd)
            {
                var response = await HttpController.GetBrandByID(brandID);
                if (response.Result == ResponseResult.SYSTEM_ERROR ||
                    response.Result == ResponseResult.API_ERROR)
                {
                    MessageBox.Show(response.Data.ToString(),
                                    "Edit Brand",
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
            if (string.IsNullOrEmpty(txtBrandName.Text))
            {
                MessageBox.Show("Brand Name field is Required.",
                                "Save Brand",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            _brandInfo.Name = txtBrandName.Text;
            _brandInfo.Description = txtBrandDescription.Text;
            _brandInfo.Status = Utility.ConvertBooleanToStatus(tglStatus.Checked);

            var request = new BrandRequest
            {
                UserID = Guid.NewGuid(),
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_BRAND_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_BRAND_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                inputBrand = _brandInfo,
            };

            var response = await HttpController.PostSaveBrand(request);

            if (response.Result == ResponseResult.SUCCESS)
            {
                MessageBox.Show("Brand has been Saved Successfully! \n" +
                                 response.Data,
                                 "Save Brand",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Data.ToString(),
                                "Save Brand",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
