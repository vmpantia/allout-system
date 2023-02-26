using System;

namespace AllOut.Web.Blazor.Models
{
    public class InventoryFullInformation
    {
        public string InventoryID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid BrandID { get; set; }
        public string BrandName { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
