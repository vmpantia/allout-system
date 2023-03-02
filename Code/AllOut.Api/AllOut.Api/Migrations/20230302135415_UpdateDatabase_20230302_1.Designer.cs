﻿// <auto-generated />
using System;
using AllOut.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllOut.Api.Migrations
{
    [DbContext(typeof(AllOutDbContext))]
    [Migration("20230302135415_UpdateDatabase_20230302_1")]
    partial class UpdateDatabase202303021
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Brand", b =>
                {
                    b.Property<Guid>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Client", b =>
                {
                    b.Property<Guid>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Browser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WindowsVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Inventory", b =>
                {
                    b.Property<string>("InventoryID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("InventoryID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.OtherCharge", b =>
                {
                    b.Property<string>("SalesID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ChargeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesID", "ChargeName");

                    b.ToTable("OtherCharges");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReorderPoint")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Request", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid?>("ApprovedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FunctionID")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("RequestID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Role", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrandPermission")
                        .HasColumnType("int");

                    b.Property<int>("CategoryPermission")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventoryPermission")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductPermission")
                        .HasColumnType("int");

                    b.Property<int>("RolePermission")
                        .HasColumnType("int");

                    b.Property<int>("SalesPermission")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserPermission")
                        .HasColumnType("int");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Sales", b =>
                {
                    b.Property<string>("SalesID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("AmountPaid")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Change")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SalesID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.SalesItem", b =>
                {
                    b.Property<string>("SalesID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesID", "ProductID");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.Brand_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("BrandID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Number", "BrandID");

                    b.ToTable("Brand_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.Category_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Number", "CategoryID");

                    b.ToTable("Category_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.Inventory_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("InventoryID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Number", "InventoryID");

                    b.ToTable("Inventory_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.OtherCharge_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("SalesID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ChargeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RequestID", "Number", "SalesID");

                    b.ToTable("OtherCharge_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.Product_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReorderPoint")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Number", "ProductID");

                    b.ToTable("Product_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.Role_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BrandPermission")
                        .HasColumnType("int");

                    b.Property<int>("CategoryPermission")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventoryPermission")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductPermission")
                        .HasColumnType("int");

                    b.Property<int>("RolePermission")
                        .HasColumnType("int");

                    b.Property<int>("SalesPermission")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserPermission")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Number", "RoleID");

                    b.ToTable("Role_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.SalesItem_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SalesID")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RequestID", "Number");

                    b.ToTable("SalesItem_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.Sales_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("SalesID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RequestID", "Number", "SalesID");

                    b.ToTable("Sales_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.Transactions.User_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("RequestID", "Number", "UserID");

                    b.ToTable("User_TRN");
                });

            modelBuilder.Entity("AllOut.Api.DataAccess.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
