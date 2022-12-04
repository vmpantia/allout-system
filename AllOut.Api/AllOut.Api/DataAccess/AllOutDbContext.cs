using AllOut.Api.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AllOut.Api.DataAccess
{
    public class AllOutDbContext : DbContext
    {
        public AllOutDbContext(): base() { }
        public AllOutDbContext(DbContextOptions<AllOutDbContext> options) : base(options) { }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Inventory_TRN> Inventory_TRN { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_TRN> Product_TRN { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Category_TRN> Category_TRN { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
    }
}
