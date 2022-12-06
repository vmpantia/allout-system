using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using System;
using System.Collections.Generic;
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

        private async void PopulateBrands()
        {
            var response = await HttpController.GetBrands();

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
            PopulateBrands();
        }
    }
}
