using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Astroentity.Migrations
{
    /// <inheritdoc />
    public partial class dbv001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StarSystem",
                table: "Stars",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarSystem",
                table: "Stars");
        }
    }
}
