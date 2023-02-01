using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllOut.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AddRole",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteRole",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditRole",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AddRole",
                table: "Role_TRN",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteRole",
                table: "Role_TRN",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EditRole",
                table: "Role_TRN",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddRole",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeleteRole",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EditRole",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AddRole",
                table: "Role_TRN");

            migrationBuilder.DropColumn(
                name: "DeleteRole",
                table: "Role_TRN");

            migrationBuilder.DropColumn(
                name: "EditRole",
                table: "Role_TRN");
        }
    }
}
