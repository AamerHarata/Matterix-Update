using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class StripeInitiatedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "InitiatedOrders",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Registrations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "InitiatedOrders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "InitiatedOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InitiatedOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "InitiatedOrders");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "InitiatedOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InitiatedOrders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InitiatedOrders",
                newName: "OrderId");
        }
    }
}
