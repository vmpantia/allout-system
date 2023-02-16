using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.enums;
using AllOut.Web.Blazor.UserControls;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace AllOut.Web.Blazor.Commons
{
    public class Utility
    {
        #region User Controls
        public static List<Button> Buttons
        {
            get
            {
                return new List<Button>
                {
                    new Button { Icon = "oi oi-dashboard", Text = "Dashboard", Page = "" },
                    new Button { Icon = "oi oi-bar-chart", Text = "Sales", Page = "Sales" },
                    new Button { Icon = "oi oi-spreadsheet", Text = "Inventory", Page = "Inventory" },
                    new Button { Icon = "oi oi-cart", Text = "Product", Page = "Product" },
                    new Button { Icon = "oi oi-tag", Text = "Brand", Page = "Brand" },
                    new Button { Icon = "oi oi-target", Text = "Category", Page = "Category" },
                    new Button { Icon = "oi oi-person", Text = "User", Page = "User" },
                    new Button { Icon = "oi oi-project", Text = "Role", Page = "Role" },
                };
            }
        }
        #endregion

        public static string PermittedObjects(Role role, PermissionType type)
        {
            string allowed = string.Empty;

            var properties = role.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.Name.Contains(Constants.OBJECT_PERMISSION))
                {
                    var permission = (int)property.GetValue(role)!;

                    if (Utility.IsPermitted(permission, type))
                    {
                        var name = property.Name.Replace(Constants.OBJECT_PERMISSION, string.Empty);
                        allowed += string.Concat(name.ToUpper(), Constants.NEWLINE);
                    }
                }
            }
            return string.IsNullOrEmpty(allowed) ? Constants.NA : allowed;
        }

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

        public static string ParsePassword(string password, bool isEncrypt)
        {
            if (string.IsNullOrEmpty(password))
                return password;

            byte[] data = isEncrypt ? UTF32Encoding.UTF8.GetBytes(password) : Convert.FromBase64String(password);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constants.HASH));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    if (isEncrypt)
                    {
                        ICryptoTransform encrypt = tripDes.CreateEncryptor();
                        byte[] resultsEncrypt = encrypt.TransformFinalBlock(data, 0, data.Length);
                        return Convert.ToBase64String(resultsEncrypt, 0, resultsEncrypt.Length);
                    }
                    ICryptoTransform decrypt = tripDes.CreateDecryptor();
                    byte[] resultsDecrypt = decrypt.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(resultsDecrypt);
                }
            }
        }

        public static Guid GetGuidByCellValue(object value)
        {
            return value == null ? Guid.Empty : Guid.Parse(value.ToString());
        }

        public static string GetStringByCellValue(object value)
        {
            return value.ToString() ?? string.Empty;
        }

        public static List<Year> GetYears(int firstYear, int lastYear)
        {
            var years = new List<Year>
            {
                //Add Default Year
                new Year
                {
                    YearString = "All",
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
                new Month {  MonthName = "All", MonthNumber = 0, },
                new Month {  MonthName = "JANUARY", MonthNumber = 1, },
                new Month {  MonthName = "FEBRUARY", MonthNumber = 2, },
                new Month {  MonthName = "MARCH", MonthNumber = 3, },
                new Month {  MonthName = "APRIL", MonthNumber = 4, },
                new Month {  MonthName = "MAY", MonthNumber = 5, },
                new Month {  MonthName = "JUNE", MonthNumber = 6, },
                new Month {  MonthName = "JULY", MonthNumber = 7, },
                new Month {  MonthName = "AUGUST", MonthNumber = 8, },
                new Month {  MonthName = "SEPTEMBER", MonthNumber = 9, },
                new Month {  MonthName = "OCTOBER", MonthNumber = 10, },
                new Month {  MonthName = "NOVEMBER", MonthNumber = 11, },
                new Month {  MonthName = "DECEMBER", MonthNumber = 12, }
            };
        }

        public static bool IsPermitted(int permission, PermissionType type)
        {
            return ((permission & (int)type) > 0);
        }

        public static string ParseURL(string url, Guid clientID, object? param)
        {
            if (param == null)
            {
                return string.Format(url, clientID);
            }
            switch (param.GetType().Name)
            {
                case Constants.DT_GUID:
                    return string.Format(url, clientID, (Guid)param);
                case Constants.DT_INT:
                    return string.Format(url, clientID, (int)param);
                default:
                    return string.Format(url, clientID, (string)param);
            }
        }
    }
}
