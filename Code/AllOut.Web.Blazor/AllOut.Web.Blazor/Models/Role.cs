using System;

namespace AllOut.Web.Blazor.Models
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string Name { get; set; }
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
