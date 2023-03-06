using AllOut.Web.Blazor.Models.Commons;

namespace AllOut.Web.Blazor.Models.DataAccess
{
    public class Inventory : Selection
    {
        public string InventoryID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
