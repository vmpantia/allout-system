using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
{
    public class Role
    {
        [Key]
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
