using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Common
{
    public class Utility
    {
        #region Status Functionalities
        public static bool ConvertStatusToBoolean(int status)
        {
            return status == Constants.STATUS_ENABLED_INT;
        }
        public static int ConvertBooleanToStatus(bool status)
        {
            return status ? Constants.STATUS_ENABLED_INT : Constants.STATUS_DISABLED_INT;
        }
        public static string ConvertStatusToString(int status)
        {
            if (status == Constants.STATUS_ENABLED_INT)
                return Constants.STATUS_ENABLED_STRING;

            else if (status == Constants.STATUS_DISABLED_INT)
                return Constants.STATUS_DISABLED_STRING;

            else
                return Constants.STATUS_DELETION_STRING;
        }
        #endregion

        #region Password Functionalities
        public static string EncodePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return password;

            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }
        public static string DecodePassword(string password)
        {
            var bytes = Convert.FromBase64String(password);
            return Encoding.UTF8.GetString(bytes);
        }
        #endregion

        #region DataGridView Functionalities
        public static Guid GetGuidByCellValue(object value)
        {
            return value == null ? Guid.Empty : Guid.Parse(value.ToString());
        }

        public static string GetStringByCellValue(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }
        #endregion

        #region Reports Functionalities
        public static List<Year> GetYears(int firstYear, int lastYear)
        {
            var years = new List<Year>
            {
                //Add Default Year
                new Year
                {
                    YearString = Constants.ALL,
                    YearInt = 0,
                }
            };
            for (int i = firstYear; i <= lastYear; i++)
            {
                years.Add(new Year
                {
                    YearString = i.ToString(),
                    YearInt = i,
                });
            };

            return years.ToList();
        }
        public static List<Month> GetMonths()
        {
            return new List<Month>
            {
                //Add Default Month
                new Month {  MonthString = Constants.ALL, MonthInt = 0, },
                new Month {  MonthString = Constants.MONTH_JAN, MonthInt = 1, },
                new Month {  MonthString = Constants.MONTH_FEB, MonthInt = 2, },
                new Month {  MonthString = Constants.MONTH_MAR, MonthInt = 3, },
                new Month {  MonthString = Constants.MONTH_APR, MonthInt = 4, },
                new Month {  MonthString = Constants.MONTH_MAY, MonthInt = 5, },
                new Month {  MonthString = Constants.MONTH_JUN, MonthInt = 6, },
                new Month {  MonthString = Constants.MONTH_JUL, MonthInt = 7, },
                new Month {  MonthString = Constants.MONTH_AUG, MonthInt = 8, },
                new Month {  MonthString = Constants.MONTH_SEP, MonthInt = 9, },
                new Month {  MonthString = Constants.MONTH_OCT, MonthInt = 10, },
                new Month {  MonthString = Constants.MONTH_NOV, MonthInt = 11, },
                new Month {  MonthString = Constants.MONTH_DEC, MonthInt = 12, }
            };
        }
        public static ReportType GetReportType(out int year, out int month, Guna2ComboBox cmbYear, Guna2ComboBox cmbMonth)
        {
            year = cmbYear.SelectedItem == null ? 0 : ((Year)cmbYear.SelectedItem).YearInt;
            month = cmbMonth.SelectedItem == null ? 0 : ((Month)cmbMonth.SelectedItem).MonthInt;

            if (year == 0 && month == 0)
                return ReportType.ALL;

            if (year != 0 && month == 0)
                return ReportType.BY_YEAR;

            return ReportType.BY_MONTH;
        }
        public static List<SalesReportInformation> GetSalesReportByType(int year, int month, ReportType type)
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
                //Get Data from Response
                salesReports = (List<SalesReportInformation>)response.Data;

            return salesReports;
        }
        public static List<ProductReportInformation> GetProductsReportByType(int year, int month, ReportType type)
        {
            Response response;

            var productsReport = new List<ProductReportInformation>();
            var clientID = Globals.ClientInformation.ClientID;

            switch (type)
            {
                case ReportType.BY_YEAR:
                    response = HttpController.GetProductsReportByYearAsync(clientID, year);
                    break;

                case ReportType.BY_MONTH:
                    response = HttpController.GetProductsReportByYearAndMonthAsync(clientID, string.Format(Constants.YEAR_MONTH_FORMAT, year, month));
                    break;

                default:
                    response = HttpController.GetProductsReportAsync(clientID);
                    break;
            }

            if (response.Result == ResponseResult.SUCCESS)
                //Get Data from Response
                productsReport = (List<ProductReportInformation>)response.Data;

            return productsReport;
        }
        public static void PopulateMonth(Guna2ComboBox cmbMonth)
        {
            cmbMonth.DataSource = null;
            cmbMonth.DataSource = GetMonths();
            cmbMonth.DisplayMember = Constants.CMB_DISPLAY_MONTH_STRING;
            cmbMonth.ValueMember = Constants.CMB_VALUE_MONTH_INT;
        }
        public static void PopulateYear(int firstYear, int lastYear, Guna2ComboBox cmbYear)
        {
            cmbYear.DataSource = null;
            cmbYear.DataSource = GetYears(firstYear, lastYear);
            cmbYear.DisplayMember = Constants.CMB_DISPLAY_YEAR_STRING;
            cmbYear.ValueMember = Constants.CMB_VALUE_YEAR_INT;

        }
        #endregion

        #region Permissions Functionalities
        public static string PermittedObjects(Role role, PermissionType type)
        {
            string allowed = string.Empty;

            var properties = role.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.Name.Contains(Constants.OBJECT_PERMISSION))
                {
                    var permission = (int)property.GetValue(role);

                    if (IsPermitted(permission, type))
                    {
                        var name = property.Name.Replace(Constants.OBJECT_PERMISSION, string.Empty);
                        allowed += string.Concat(name.ToUpper(), Constants.NEWLINE);
                    }
                }
            }
            return string.IsNullOrEmpty(allowed) ? Constants.NA : allowed;
        }
        public static bool IsPermitted(int permission, PermissionType type)
        {
            return ((permission & (int)type) > 0);
        }
        #endregion
    }
}
