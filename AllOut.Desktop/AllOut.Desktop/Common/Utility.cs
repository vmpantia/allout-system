﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Desktop.Common
{
    internal class Utility
    {
        public static bool ConvertStatusToBoolean(int status)
        {
            return status == Constants.INT_STATUS_ENABLED;
        }

        public static int ConvertBooleanToStatus(bool status)
        {
            return status ? Constants.INT_STATUS_ENABLED : Constants.INT_STATUS_DISABLED;
        }
    }
}