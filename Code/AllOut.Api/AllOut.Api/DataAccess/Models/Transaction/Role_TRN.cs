using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AllOut.Api.DataAccess.Models
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
        #region Product
        public bool AddProduct { get; set; }
        public bool EditProduct { get; set; }
        public bool DeleteProduct { get; set; }
        #endregion

        #region Category
        public bool AddCategory { get; set; }
        public bool EditCategory { get; set; }
        public bool DeleteCategory { get; set; }
        #endregion

        #region Brand
        public bool AddBrand { get; set; }
        public bool EditBrand { get; set; }
        public bool DeleteBrand { get; set; }
        #endregion

        #region Inventory
        public bool AddInventory { get; set; }
        public bool EditInventory { get; set; }
        public bool DeleteInventory { get; set; }
        #endregion

        #region Sales
        public bool AddSales { get; set; }
        public bool EditSales { get; set; }
        public bool DeleteSales { get; set; }
        #endregion

        #region User
        public bool AddUser { get; set; }
        public bool EditUser { get; set; }
        public bool DeleteUser { get; set; }
        #endregion

        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
