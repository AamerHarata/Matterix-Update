using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class AddNewLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAllowed",
                table: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllowed",
                table: "Country",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
