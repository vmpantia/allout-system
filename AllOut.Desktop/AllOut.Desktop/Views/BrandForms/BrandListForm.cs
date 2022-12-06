using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using System;
using System.Collections;
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
    public partial class BrandListForm : Form
    {
        public BrandListForm()
        {
            InitializeComponent();
            PopulateBrands();
        }

        private void PopulateBrands()
        {
            var response = HTTPController.GetBrands();

            if (response.Result == ResponseResult.SYSTEM_ERROR ||
                response.Result == ResponseResult.API_ERROR)
            {
                tblBrandList.Visible = false;
                return;
            }
            var brandList = response.Data as List<Brand>;
            tblBrandList.DataSource = brandList;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            var form = new BrandForm();
            form.ShowDialog();
        }
    }
}
