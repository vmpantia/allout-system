using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AllOut.Desktop.Views
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            PopulateData();
            PopulateReportsData();
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

            response = HttpController.GetCountRolesAsync(Globals.ClientInformation.ClientID);
            lblCountRole.Text = response.Result == ResponseResult.SUCCESS ? (string)response.Data : Constants.NA;
        }

        private void PopulateReportsData()
        {
            int year, month;

            //Reset
            chartSales.Series[Constants.SERIES_TOTAL].Points.Clear();
            tblProduts.DataSource = null;

            var type = Utility.GetReportType(out year, out month, cmbYear, cmbMonth);
            var sales = Utility.GetSalesReportByType(year, month, type);
            var products = Utility.GetProductsReportByType(year, month, type);

            if (sales.Any() && type == ReportType.ALL)
            {
                //Initialize ComboBox
                Utility.PopulateMonth(cmbMonth);
                Utility.PopulateYear(sales.First().Year, sales.Last().Year, cmbYear);
            }

            //Display Sales Chart
            DisplayChartByType(sales, type);

            //Display Product Sales
            lblTableDescription.Visible = products.Count == 0;
            tblProduts.DataSource = products.Take(15).Select(data => new
            {
                Product = data.ProductName,
                Brand = data.BrandName,
                Category = data.CategoryName,
                data.Quantity,
                data.Total
            }).ToList();
        }

        private void DisplayChartByType(List<SalesReportInformation> salesReports, ReportType type)
        {
            foreach (var salesReport in salesReports)
            {
                switch (type)
                {
                    case ReportType.BY_YEAR:
                        chartSales.Series[Constants.SERIES_TOTAL].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(salesReport.Month), salesReport.Total);
                        break;
                    case ReportType.BY_MONTH:
                        chartSales.Series[Constants.SERIES_TOTAL].Points.AddXY(salesReport.Day, salesReport.Total);
                        break;
                    default:
                        chartSales.Series[Constants.SERIES_TOTAL].Points.AddXY(salesReport.Year, salesReport.Total);
                        break;
                }
            }
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateReportsData();
        }

        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateReportsData();
        }

    }
}
