namespace AllOut.Web.Blazor.Models.Reports
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
