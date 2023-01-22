using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllOut.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangePKSalesItemAndOtherCharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesItems",
                table: "SalesItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OtherCharges",
                table: "OtherCharges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesItems",
                table: "SalesItems",
                columns: new[] { "SalesID", "ProductID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtherCharges",
                table: "OtherCharges",
                columns: new[] { "SalesID", "ChargeName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesItems",
                table: "SalesItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OtherCharges",
                table: "OtherCharges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesItems",
                table: "SalesItems",
                column: "SalesID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtherCharges",
                table: "OtherCharges",
                column: "SalesID");
        }
    }
}
