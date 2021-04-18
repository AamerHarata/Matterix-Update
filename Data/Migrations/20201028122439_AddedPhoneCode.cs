using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class AddedPhoneCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneCode",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneCode",
                table: "AspNetUsers");
        }
    }
}
