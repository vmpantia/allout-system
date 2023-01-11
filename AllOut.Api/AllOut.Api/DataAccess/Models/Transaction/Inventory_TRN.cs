using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    [PrimaryKey(nameof(RequestID), nameof(Number))]
    public class Inventory_TRN
    {
        [MaxLength(12)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid InventoryID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
