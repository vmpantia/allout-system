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

            _isAdd = brandID == Guid.Empty;
            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_BRAND) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_BRAND);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_BRAND) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_BRAND);

            PopulateBrand(brandID);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Disable Controls
            EnableControls(false);

            //Populate Text Fields in Data
            _brandInfo.Name = txtName.Text;
            _brandInfo.Description = txtDescription.Text;
            _brandInfo.Status = Constants.STATUS_ENABLED_INT;

            //Prepare Request for Save
            var request = new SaveBrandRequest
            {
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_BRAND_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_BRAND_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                client = Globals.ClientInformation,
                inputBrand = _brandInfo
            };

            //Send Request for Save
            var response = await HttpController.PostSaveBrandAsync(request);

            //Enable Controls
            EnableControls(true);

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

        private async void PopulateBrand(Guid brandID)
        {
            //Check if Add or Edit
            if (!_isAdd)
            {
                //Get Brand based on the given ID
                var response = await HttpController.GetBrandByIDAsync(Globals.ClientInformation.ClientID, brandID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show((string)response.Data,
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_BRAND),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                _brandInfo = response.Data as Brand;
            }
            
            //Populate Data in Text Fields
            txtName.Text = _brandInfo.Name;
            txtDescription.Text = _brandInfo.Description;

            EnableControls(_brandInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private void EnableControls(bool isEnabled)
        {
            txtName.Enabled = isEnabled;
            txtDescription.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
    }
}
