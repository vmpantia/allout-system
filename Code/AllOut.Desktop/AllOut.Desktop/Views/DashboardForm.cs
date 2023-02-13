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
using System.Windows.Forms;

namespace AllOut.Desktop.Views
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            PopulateData();
            PopulateSalesData();
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

        private void PopulateSalesData()
        {
            List<SalesReportInformation> salesReports;
            List<ProductReportInformation> productReports;
            int year, month;

            //Reset
            chartSales.Series[Constants.SERIES_TOTAL].Points.Clear();
            tblProduts.DataSource = null;

            var type = GetReportType(out year, out month);
            GetReportsByType(out salesReports, out productReports, year, month, type);


            //Populate Sales Chart
            PopulateChart(type, salesReports);

            //Populate Product Sales
            tblProduts.DataSource = productReports;
            lblTableDescription.Visible = productReports.Count == 0;
        }

        private void PopulateChart(ReportType type,  List<SalesReportInformation> salesReports)
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

        private void GetReportsByType(out List<SalesReportInformation> salesReports, 
                                      out List<ProductReportInformation> productReports,
                                      int year,
                                      int month,
                                      ReportType type)
        {
            Response responseSales, responseProducts;
            salesReports = new List<SalesReportInformation>();
            productReports = new List<ProductReportInformation>();

            var clientID = Globals.ClientInformation.ClientID;

            switch (type)
            {
                case ReportType.BY_YEAR:
                    responseSales = HttpController.GetSalesReportByYearAsync(clientID, year);
                    if (responseSales.Result == ResponseResult.SUCCESS)
                        salesReports = (List<SalesReportInformation>)responseSales.Data;

                    responseProducts = HttpController.GetProductsReportByYearAsync(clientID, year);
                    if (responseProducts.Result == ResponseResult.SUCCESS)
                        productReports = (List<ProductReportInformation>)responseProducts.Data;
                    break;

                case ReportType.BY_MONTH:
                    responseSales = HttpController.GetSalesReportByYearAndMonthAsync(clientID, string.Format(Constants.YEAR_MONTH_FORMAT, year, month));
                    if (responseSales.Result == ResponseResult.SUCCESS)
                        salesReports = (List<SalesReportInformation>)responseSales.Data;

                    responseProducts = HttpController.GetProductsReportByYearAndMonthAsync(clientID, string.Format(Constants.YEAR_MONTH_FORMAT, year, month));
                    if (responseSales.Result == ResponseResult.SUCCESS)
                        productReports = (List<ProductReportInformation>)responseProducts.Data;
                    break;

                default:
                    responseSales = HttpController.GetSalesReportAsync(clientID);
                    if (responseSales.Result == ResponseResult.SUCCESS)
                    {
                        salesReports = (List<SalesReportInformation>)responseSales.Data;
                        //Initialize ComoboBox
                        if (salesReports.Any())
                        {
                            PopulateMonth();
                            PopulateYear(salesReports.First().Year, salesReports.Last().Year);
                        }
                    }

                    responseProducts = HttpController.GetProductsReportAsync(clientID);
                    if (responseProducts.Result == ResponseResult.SUCCESS)
                        productReports = (List<ProductReportInformation>)responseProducts.Data;
                    break;
            }
        }

        private ReportType GetReportType(out int year, out int month)
        {
            year = cmbYear.SelectedItem == null ? 0 : ((Year)cmbYear.SelectedItem).YearInt;
            month = cmbMonth.SelectedItem == null ? 0 : ((Month)cmbMonth.SelectedItem).MonthInt;

            if(year == 0 && month == 0)
                return ReportType.ALL;

            if (year != 0 && month == 0)
                return ReportType.BY_YEAR;

            return ReportType.BY_MONTH;
        }

        private void PopulateYear(int firstYear, int lastYear)
        {
            cmbYear.DataSource = null;

            var years = Utility.GetYears(firstYear, lastYear);

            cmbYear.DataSource = years;
            cmbYear.DisplayMember = Constants.CMB_DISPLAY_YEAR_STRING;
            cmbYear.ValueMember = Constants.CMB_VALUE_YEAR_INT;

        }

        private void PopulateMonth()
        {
            cmbMonth.DataSource = null;

            var months = Utility.GetMonths();

            cmbMonth.DataSource = months;
            cmbMonth.DisplayMember = Constants.CMB_DISPLAY_MONTH_STRING;
            cmbMonth.ValueMember = Constants.CMB_VALUE_MONTH_INT;
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateSalesData();
        }

        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateSalesData();
        }

    }
}
