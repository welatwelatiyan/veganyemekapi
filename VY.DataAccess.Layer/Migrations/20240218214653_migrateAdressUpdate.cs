using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VY.DataAccess.Layer.Migrations
{
    /// <inheritdoc />
    public partial class migrateAdressUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "vyUserAdressTables",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Closedtime",
                table: "vyStoreTables",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "ExceptionalClosed",
                table: "vyStoreTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "vyStoreTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpenEndOfWeek",
                table: "vyStoreTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Opentime",
                table: "vyStoreTables",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "vyUserAdressTables");

            migrationBuilder.DropColumn(
                name: "Closedtime",
                table: "vyStoreTables");

            migrationBuilder.DropColumn(
                name: "ExceptionalClosed",
                table: "vyStoreTables");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "vyStoreTables");

            migrationBuilder.DropColumn(
                name: "IsOpenEndOfWeek",
                table: "vyStoreTables");

            migrationBuilder.DropColumn(
                name: "Opentime",
                table: "vyStoreTables");
        }
    }
}
