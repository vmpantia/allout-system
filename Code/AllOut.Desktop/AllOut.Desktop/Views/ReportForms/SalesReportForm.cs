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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.ReportForms
{
    public partial class SalesReportForm : Form
    {
        public SalesReportForm()
        {
            InitializeComponent();
            PopulateSalesReport();
            btnSearchToolTip.SetToolTip(btnSearch, string.Format(Constants.TOOLTIP_SEARCH, Constants.OBJECT_BRAND));
        }

        private void PopulateSalesReport()
        {
            int year = 0, month = 0;

            //Reset
            tblObjectList.DataSource = null;

            var type = ReportType.ALL;

            var sales = GetSalesReportByType(year, month, type);

            //Populate Sales Report
            lblTableDescription.Visible = sales.Count == 0;
            switch (type)
            {
                case ReportType.BY_YEAR:
                    tblObjectList.DataSource = sales.Select(data => new
                    {
                        data.Month,
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

        private List<SalesReportInformation> GetSalesReportByType(int year, int month, ReportType type)
        {
            Response response;

            var salesReports = new List<SalesReportInformation>();
            var clientID = Globals.ClientInformation.ClientID;

            switch (type)
            {
                case ReportType.BY_YEAR:
                    response = HttpController.GetSalesReportByYearAsync(clientID, year);
                    break;

                case ReportType.BY_MONTH:
                    response = HttpController.GetSalesReportByYearAndMonthAsync(clientID, string.Format(Constants.YEAR_MONTH_FORMAT, year, month));
                    break;

                default:
                    response = HttpController.GetSalesReportAsync(clientID);
                    break;
            }

            if (response.Result == ResponseResult.SUCCESS)
            {
                salesReports = (List<SalesReportInformation>)response.Data;
            }

            return salesReports;
        }
    }
}
