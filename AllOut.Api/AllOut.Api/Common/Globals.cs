﻿namespace AllOut.Api.Common
{
    public class Globals
    {
        public static DateTime EXEC_DATETIME = DateTime.Now;
        public static string EXEC_DATE = DateTime.Now.ToString("yyyy/MM/dd");
        public static string REQUEST_ID_PREFFIX = DateTime.Now.ToString("yyyyMMdd");
    }
}