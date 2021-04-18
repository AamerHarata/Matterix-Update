using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class InvoiceUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Invoices",
                newName: "OriginalDueDate");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "Invoices",
                newName: "OriginalDeadline");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentAmount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDeadline",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDueDate",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEmail",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSMS",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentAmount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CurrentDeadline",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CurrentDueDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LastEmail",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "LastSMS",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "OriginalDueDate",
                table: "Invoices",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "OriginalDeadline",
                table: "Invoices",
                newName: "Deadline");
        }
    }
}
