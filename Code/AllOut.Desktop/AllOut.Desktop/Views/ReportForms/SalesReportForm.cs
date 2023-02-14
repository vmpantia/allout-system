using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using AllOut.Desktop.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.ReportForms
{
    public partial class SalesReportForm : Form
    {
        private List<SalesReportInformation> _sales;
        public SalesReportForm()
        {
            InitializeComponent();
            PopulateSalesReport();
        }

        private void PopulateSalesReport()
        {
            int year, month;

            //Reset
            tblObjectList.DataSource = null;

            var type = Utility.GetReportType(out year, out month, cmbYear, cmbMonth);
            var sales = Utility.GetSalesReportByType(year, month, type);

            if(sales.Any() && type == ReportType.ALL)
            {
                //Initialize ComboBox
                Utility.PopulateMonth(cmbMonth);
                Utility.PopulateYear(sales.First().Year, sales.Last().Year, cmbYear);
            }

            //Populate Sales Report
            lblTableDescription.Visible = sales.Count == 0;
            DisplaySalesReportByType(sales, type);

            _sales = sales;
        }

        private void DisplaySalesReportByType(List<SalesReportInformation> sales, ReportType type)
        {
            switch (type)
            {
                case ReportType.BY_YEAR:
                    tblObjectList.DataSource = sales.Select(data => new
                    {
                        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(data.Month),
                        data.Quantity,
                        ItemTotal = data.ItemTotal.ToString(Constants.N0_FORMAT),
                        Additional = data.Additional.ToString(Constants.N0_FORMAT),
                        Deductions = data.Deductions.ToString(Constants.N0_FORMAT),
                        Total = data.Total.ToString(Constants.N0_FORMAT),
                    }).ToList();
                    break;

                case ReportType.BY_MONTH:
                    tblObjectList.DataSource = sales.Select(data => new
                    {
                        data.Day,
                        data.Quantity,
                        ItemTotal = data.ItemTotal.ToString(Constants.N0_FORMAT),
                        Additional = data.Additional.ToString(Constants.N0_FORMAT),
                        Deductions = data.Deductions.ToString(Constants.N0_FORMAT),
                        Total = data.Total.ToString(Constants.N0_FORMAT),
                    }).ToList();
                    break;

                default:
                    tblObjectList.DataSource = sales.Select(data => new
                    {
                        data.Year,
                        data.Quantity,
                        ItemTotal = data.ItemTotal.ToString(Constants.N0_FORMAT),
                        Additional = data.Additional.ToString(Constants.N0_FORMAT),
                        Deductions = data.Deductions.ToString(Constants.N0_FORMAT),
                        Total = data.Total.ToString(Constants.N0_FORMAT),
                    }).ToList();
                    break;
            }
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateSalesReport();
        }

        private void cmbMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateSalesReport();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            int year, month;
            var type = Utility.GetReportType(out year, out month, cmbYear, cmbMonth);

            var excel = new ExcelService();

            var result = excel.ExportToExcel(_sales);
            MessageBox.Show(result);
        }
    }
}
