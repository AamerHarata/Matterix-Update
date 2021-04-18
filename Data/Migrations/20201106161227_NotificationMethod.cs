using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class NotificationMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NoNotifications",
                table: "NoNotifications");

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "NoNotifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoNotifications",
                table: "NoNotifications",
                columns: new[] { "UserId", "NotificationType", "Method" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NoNotifications",
                table: "NoNotifications");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "NoNotifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoNotifications",
                table: "NoNotifications",
                columns: new[] { "UserId", "NotificationType" });
        }
    }
}
