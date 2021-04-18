using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class InitiatedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InitiatedOrders",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: true),
                    PayAllNow = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Reason = table.Column<int>(nullable: false),
                    InvoiceNumber = table.Column<int>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    AuthCookies = table.Column<string>(nullable: true),
                    OperatingSystem = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiatedOrders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_InitiatedOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InitiatedOrders_UserId",
                table: "InitiatedOrders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitiatedOrders");
        }
    }
}
