using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VY.DataAccess.Layer.Migrations
{
    /// <inheritdoc />
    public partial class deliveryTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isMenu",
                table: "vyDeliveryTables");

            migrationBuilder.RenameColumn(
                name: "totalAmaunt",
                table: "vyDeliveryTables",
                newName: "totalAmount");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "vyDeliveryTables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "vyDeliveryTables");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "vyDeliveryTables",
                newName: "totalAmaunt");

            migrationBuilder.AddColumn<bool>(
                name: "isMenu",
                table: "vyDeliveryTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
