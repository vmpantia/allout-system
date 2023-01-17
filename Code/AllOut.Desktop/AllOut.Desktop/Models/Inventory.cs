using System;

namespace AllOut.Desktop.Models
{
    public class Inventory
    {
        public string InventoryID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
