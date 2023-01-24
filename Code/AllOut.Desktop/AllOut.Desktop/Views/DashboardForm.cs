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
        private void PopulateData()
        {
            var response = HttpController.GetCountProductsAsync(Globals.ClientInformation.ClientID);
            lblCountProduct.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = HttpController.GetCountBrandsAsync(Globals.ClientInformation.ClientID);
            lblCountBrand.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = HttpController.GetCountCategoriesAsync(Globals.ClientInformation.ClientID);
            lblCountCategory.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = HttpController.GetCountUsersAsync(Globals.ClientInformation.ClientID);
            lblCountUser.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = HttpController.GetCountInventoriesAsync(Globals.ClientInformation.ClientID);
            lblCountInventory.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            response = HttpController.GetCountSalesAsync(Globals.ClientInformation.ClientID);
            lblCountSales.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;

            var res = HttpController.GetSalesReportAsync(Globals.ClientInformation.ClientID);
            if(res.Result == ResponseResult.SUCCESS)
            {
                var salesReports = (List<SalesReportInformation>)res.Data;
                foreach(var salesReport in salesReports)
                {
                    SalesChart.Series["Total"].Points.AddXY(salesReport.Year, salesReport.Total);
                }
            }
        }
    }
}
