﻿using AllOut.Api.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AllOut.Api.DataAccess
{
    public class AllOutDbContext : DbContext
    {
        public AllOutDbContext(): base() { }
        public AllOutDbContext(DbContextOptions<AllOutDbContext> options) : base(options) { }

        #region MASTER TABLES
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesItem> SalesItems { get; set; }
        public virtual DbSet<OtherCharge> OtherCharges { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        #endregion

        #region TRANSACTION TABLES
        public virtual DbSet<User_TRN> User_TRN { get; set; }
        public virtual DbSet<Role_TRN> Role_TRN { get; set; }
        public virtual DbSet<Product_TRN> Product_TRN { get; set; }
        public virtual DbSet<Category_TRN> Category_TRN { get; set; }
        public virtual DbSet<Brand_TRN> Brand_TRN { get; set; }
        public virtual DbSet<Sales_TRN> Sales_TRN { get; set; }
        public virtual DbSet<SalesItem_TRN> SalesItem_TRN { get; set; }
        public virtual DbSet<OtherCharge_TRN> OtherCharge_TRN { get; set; }
        public virtual DbSet<Inventory_TRN> Inventory_TRN { get; set; }
        #endregion
    }
}
