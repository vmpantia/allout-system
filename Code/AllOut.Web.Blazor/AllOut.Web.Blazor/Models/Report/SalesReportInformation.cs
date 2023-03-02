using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllOut.Web.Blazor.Models.Report
{
    public class SalesReportInformation
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
        public decimal Additional { get; set; }
        public decimal Deductions { get; set; }
        public decimal Total { get; set; }
    }
}
