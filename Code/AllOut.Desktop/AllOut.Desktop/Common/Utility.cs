using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Common
{
    internal class Utility
    {
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

        public static Guid GetIDByCellValue(object value)
        {
            return value == null ? Guid.Empty : Guid.Parse(value.ToString());
        }
    }
}
