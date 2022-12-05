using AllOut.Desktop.Common;
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
        public BrandForm(Brand editBrand = null)
        {
            InitializeComponent();

            if(editBrand != null)
                _isAdd = false;

            lblBrandFormTitle.Text = _isAdd ? Constants.TITLE_ADD_BRAND : Constants.TITLE_EDIT_BRAND;
            lblBrandFormDescription.Text = _isAdd ? Constants.DESCRIPTION_ADD_BRAND : Constants.DESCRIPTION_EDIT_BRAND;

            _brandInfo = _isAdd ? new Brand() : editBrand;
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
