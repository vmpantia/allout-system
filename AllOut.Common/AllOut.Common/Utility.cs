using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Common
{
    public class Utility
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
            if (status == Constants.STATUS_ENABLED_INT)
                return Constants.STATUS_ENABLED_STRING;

            else if (status == Constants.STATUS_DISABLED_INT)
                return Constants.STATUS_DISABLED_STRING;

            else
                return Constants.STATUS_DELETION_STRING;
        }
    }
}
