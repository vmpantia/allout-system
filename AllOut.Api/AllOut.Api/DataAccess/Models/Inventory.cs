using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class Inventory
    {
        [Key]
        public Guid InventoryID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
