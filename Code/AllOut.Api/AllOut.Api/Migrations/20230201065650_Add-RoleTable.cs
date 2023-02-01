using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllOut.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role_TRN",
                columns: table => new
                {
                    RequestID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddProduct = table.Column<bool>(type: "bit", nullable: false),
                    EditProduct = table.Column<bool>(type: "bit", nullable: false),
                    DeleteProduct = table.Column<bool>(type: "bit", nullable: false),
                    AddCategory = table.Column<bool>(type: "bit", nullable: false),
                    EditCategory = table.Column<bool>(type: "bit", nullable: false),
                    DeleteCategory = table.Column<bool>(type: "bit", nullable: false),
                    AddBrand = table.Column<bool>(type: "bit", nullable: false),
                    EditBrand = table.Column<bool>(type: "bit", nullable: false),
                    DeleteBrand = table.Column<bool>(type: "bit", nullable: false),
                    AddInventory = table.Column<bool>(type: "bit", nullable: false),
                    EditInventory = table.Column<bool>(type: "bit", nullable: false),
                    DeleteInventory = table.Column<bool>(type: "bit", nullable: false),
                    AddSales = table.Column<bool>(type: "bit", nullable: false),
                    EditSales = table.Column<bool>(type: "bit", nullable: false),
                    DeleteSales = table.Column<bool>(type: "bit", nullable: false),
                    AddUser = table.Column<bool>(type: "bit", nullable: false),
                    EditUser = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_TRN", x => new { x.RequestID, x.Number, x.RoleID });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddProduct = table.Column<bool>(type: "bit", nullable: false),
                    EditProduct = table.Column<bool>(type: "bit", nullable: false),
                    DeleteProduct = table.Column<bool>(type: "bit", nullable: false),
                    AddCategory = table.Column<bool>(type: "bit", nullable: false),
                    EditCategory = table.Column<bool>(type: "bit", nullable: false),
                    DeleteCategory = table.Column<bool>(type: "bit", nullable: false),
                    AddBrand = table.Column<bool>(type: "bit", nullable: false),
                    EditBrand = table.Column<bool>(type: "bit", nullable: false),
                    DeleteBrand = table.Column<bool>(type: "bit", nullable: false),
                    AddInventory = table.Column<bool>(type: "bit", nullable: false),
                    EditInventory = table.Column<bool>(type: "bit", nullable: false),
                    DeleteInventory = table.Column<bool>(type: "bit", nullable: false),
                    AddSales = table.Column<bool>(type: "bit", nullable: false),
                    EditSales = table.Column<bool>(type: "bit", nullable: false),
                    DeleteSales = table.Column<bool>(type: "bit", nullable: false),
                    AddUser = table.Column<bool>(type: "bit", nullable: false),
                    EditUser = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role_TRN");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
