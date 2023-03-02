using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models.Transactions
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(RoleID))]
    public class Role_TRN
    {
        [MaxLength(15)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid RoleID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        //Permissions
        public int ProductPermission { get; set; }
        public int CategoryPermission { get; set; }
        public int BrandPermission { get; set; }
        public int InventoryPermission { get; set; }
        public int SalesPermission { get; set; }
        public int UserPermission { get; set; }
        public int RolePermission { get; set; }

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
