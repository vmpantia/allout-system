using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.BrandForms
{
    public partial class BrandForm : Form
    {
        private bool _isAdd = true;
        private Brand _brandInfo;
        public BrandForm(Guid brandID = new Guid())
        {
            InitializeComponent();

            if(brandID != Guid.Empty)
                _isAdd = false;

            lblBrandFormTitle.Text = _isAdd ? Constants.TITLE_ADD_BRAND : Constants.TITLE_EDIT_BRAND;
            lblBrandFormDescription.Text = _isAdd ? Constants.DESCRIPTION_ADD_BRAND : Constants.DESCRIPTION_EDIT_BRAND;

            _brandInfo = _isAdd ? new Brand() : HTTPController.GetBrandByID(brandID);
            PopulateBrand(_brandInfo);
        }

        private void PopulateBrand(Brand brandInfo)
        {
            txtBrandName.Text = brandInfo.Name;
            txtBrandDescription.Text = brandInfo.Description;
            tglStatus.Checked = Utility.ConvertStatusToBoolean(_brandInfo.Status);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _brandInfo.Name = txtBrandName.Text;
            _brandInfo.Description = txtBrandDescription.Text;
            _brandInfo.Status = Utility.ConvertBooleanToStatus(tglStatus.Checked);
            _brandInfo.CreatedDate = _isAdd ? DateTime.Now : _brandInfo.CreatedDate;
            _brandInfo.ModifiedDate = _isAdd ? _brandInfo.ModifiedDate : DateTime.Now;

            var request = new BrandRequest
            {
                UserID = Guid.NewGuid(),
                FunctionID = "02A00",
                RequestStatus = "A2",
                inputBrand = _brandInfo,
            };

            var result = HTTPController.SaveBrand(request);
            MessageBox.Show(result);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _brandInfo = null;
            this.Close();
        }

        private void tglStatus_CheckedChanged(object sender, EventArgs e)
        {
            lblStatus.Text = (tglStatus.Checked ? Constants.STRING_STATUS_ENABLED : Constants.STRING_STATUS_DISABLED).ToUpper();
            lblStatus.ForeColor = tglStatus.Checked ? Constants.COLOR_STATUS_ENABLED : Constants.COLOR_STATUS_DISABLED;
        }
    }
}
