using AllOut.Web.Blazor.Models;
using AllOut.Web.Blazor.Models.enums;
using System.Text;

namespace AllOut.Web.Blazor.Commons
{
    public class Utility
    {
        public static string PermittedObjects(Role role, PermissionType type)
        {
            string allowed = string.Empty;

            var properties = role.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.Name.Contains(Constants.OBJECT_PERMISSION))
                {
                    var permission = (int)property.GetValue(role);

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
            if(status == Constants.STATUS_ENABLED_INT)
                return Constants.STATUS_ENABLED_STRING;

            else if(status == Constants.STATUS_DISABLED_INT)
                return Constants.STATUS_DISABLED_STRING;

            else
                return Constants.STATUS_DELETION_STRING;
        }

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

        public static Guid GetGuidByCellValue(object value)
        {
            return value == null ? Guid.Empty : Guid.Parse(value.ToString());
        }

        public static string GetStringByCellValue(object value)
        {
            return value == null ? string.Empty : value.ToString();
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
            for(int i = firstYear; i <= lastYear; i++)
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
                case "Guid":
                    return string.Format(url, clientID, (Guid)param);
                case "int":
                    return string.Format(url, clientID, (int)param);
                default:
                    return string.Format(url, clientID, (string)param);
            }
        }
    }
}
