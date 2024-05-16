using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VY.DataAccess.Layer.Migrations
{
    /// <inheritdoc />
    public partial class menukategoritableupdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequireChoice",
                table: "vyMenuProductTables");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequireChoice",
                table: "vyMenuKategoris",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequireChoice",
                table: "vyMenuKategoris");

            migrationBuilder.AddColumn<bool>(
                name: "IsRequireChoice",
                table: "vyMenuProductTables",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
