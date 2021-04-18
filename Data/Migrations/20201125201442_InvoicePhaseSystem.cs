using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class InvoicePhaseSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastSMS",
                table: "Invoices",
                newName: "NextNotification");

            migrationBuilder.RenameColumn(
                name: "LastEmail",
                table: "Invoices",
                newName: "LastNotification");

            migrationBuilder.AddColumn<int>(
                name: "Delay",
                table: "Increments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoicePhase",
                table: "Increments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delay",
                table: "Increments");

            migrationBuilder.DropColumn(
                name: "InvoicePhase",
                table: "Increments");

            migrationBuilder.RenameColumn(
                name: "NextNotification",
                table: "Invoices",
                newName: "LastSMS");

            migrationBuilder.RenameColumn(
                name: "LastNotification",
                table: "Invoices",
                newName: "LastEmail");
        }
    }
}
