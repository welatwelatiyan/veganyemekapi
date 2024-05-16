using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VY.DataAccess.Layer.Migrations
{
    /// <inheritdoc />
    public partial class prducttablesstoreids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "vyMenuProductTables",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "vyMenuKategoris",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "vyMenuProductTables");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "vyMenuKategoris");
        }
    }
}
