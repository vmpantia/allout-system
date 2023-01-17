using System;

namespace AllOut.Desktop.Models
{
    public class Sales
    {
        public string SalesID { get; set; }
        public Guid UserID { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
