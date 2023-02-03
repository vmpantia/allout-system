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
            PopulateChart();
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

        private void PopulateChart(int year = 0, int month = 0)
        {
            SalesChart.Series["Total"].Points.Clear();
            SalesChart.Series["Additional"].Points.Clear();
            SalesChart.Series["Deduction"].Points.Clear();

            var salesReports = new List<SalesReportInformation>();
            bool isAllYear = false;
            bool isByYear = false;
            bool isByMonth = false;
            if (year == 0 && month == 0)
            {
                isAllYear = true;
                var res = HttpController.GetSalesReportAsync(Globals.ClientInformation.ClientID);
                if (res.Result == ResponseResult.SUCCESS)
                {
                    salesReports = (List<SalesReportInformation>)res.Data;
                    if (!salesReports.Any())
                        return;

                    var firstYear = salesReports.OrderBy(data => data.Year).First().Year;
                    var lastYear = salesReports.OrderBy(data => data.Year).Last().Year;
                    var years = Utility.GetYears(firstYear, lastYear);
                    var months = Utility.GetMonths();

                    cmbYear.DataSource = years;
                    cmbYear.DisplayMember = "YearString";
                    cmbYear.ValueMember = "YearInt";

                    cmbMonth.DataSource = months;
                    cmbMonth.DisplayMember = "MonthName";
                    cmbMonth.ValueMember = "MonthNumber";
                }
            }
            else if (year != 0 && month == 0)
            {
                isByYear = true;
                var res = HttpController.GetSalesReportByYearAsync(Globals.ClientInformation.ClientID, year);
                if (res.Result == ResponseResult.SUCCESS)
                {
                    salesReports = (List<SalesReportInformation>)res.Data;
                }
            }
            else
            {
                isByMonth = true;
                var res = HttpController.GetSalesReportByYearAndMonthAsync(Globals.ClientInformation.ClientID,
                                                                           string.Format("{0}-{1}", year,
                                                                                                    month));
                if (res.Result == ResponseResult.SUCCESS)
                {
                    salesReports = (List<SalesReportInformation>)res.Data;
                }
            }

            foreach (var salesReport in salesReports)
            {
                if (isAllYear)
                {
                    SalesChart.Series["Total"].Points.AddXY(salesReport.Year, salesReport.Total);
                    SalesChart.Series["Additional"].Points.AddXY(salesReport.Year, salesReport.Additional);
                    SalesChart.Series["Deduction"].Points.AddXY(salesReport.Year, salesReport.Deductions);
                    return;
                }
                if (isByYear)
                {
                    SalesChart.Series["Total"].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(salesReport.Month), salesReport.Total);
                    SalesChart.Series["Additional"].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(salesReport.Month), salesReport.Additional);
                    SalesChart.Series["Deduction"].Points.AddXY(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(salesReport.Month), salesReport.Deductions);
                    return;
                }
                if (isByMonth)
                {
                    SalesChart.Series["Total"].Points.AddXY(salesReport.Day, salesReport.Total);
                    SalesChart.Series["Additional"].Points.AddXY(salesReport.Day, salesReport.Additional);
                    SalesChart.Series["Deduction"].Points.AddXY(salesReport.Day, salesReport.Deductions);
                    return;
                }
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulateChart(false);
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulateChart(false);
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            int year = cmbYear.SelectedItem == null ? 0 : ((Year)cmbYear.SelectedItem).YearInt;
            int month = cmbMonth.SelectedItem == null ? 0 : ((Month)cmbMonth.SelectedItem).MonthNumber;
            PopulateChart(year, month);
        }

        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            int year = cmbYear.SelectedItem == null ? 0 : ((Year)cmbYear.SelectedItem).YearInt;
            int month = cmbMonth.SelectedItem == null ? 0 : ((Month)cmbMonth.SelectedItem).MonthNumber;
            PopulateChart(year, month);
        }
    }
}
