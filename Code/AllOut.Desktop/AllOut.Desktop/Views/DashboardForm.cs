using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AllOut.Desktop.Views
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            PopulateData();
        }
        private async void PopulateData()
        {
            var response = await HttpController.GetCountProductsAsync(Globals.ClientInformation.ClientID);
            lblCountProduct.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = await HttpController.GetCountBrandsAsync(Globals.ClientInformation.ClientID);
            lblCountBrand.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = await HttpController.GetCountCategoriesAsync(Globals.ClientInformation.ClientID);
            lblCountCategory.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = await HttpController.GetCountUsersAsync(Globals.ClientInformation.ClientID);
            lblCountUser.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;
        }
    }
}
