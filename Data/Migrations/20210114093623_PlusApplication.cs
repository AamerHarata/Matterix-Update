using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class PlusApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserDevices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Connection",
                table: "UserDevices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "UserDevices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "Registrations",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Live",
                table: "Registrations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Book",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatterixFiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    WebPath = table.Column<string>(nullable: true),
                    RootPath = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    MbSize = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterixFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlusApplications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplyDate = table.Column<DateTime>(nullable: false),
                    Applier = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true),
                    ContactPersonEmail = table.Column<string>(nullable: true),
                    ContactPersonPhoneCode = table.Column<string>(nullable: true),
                    ContactPersonPhone = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    Program = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CoursesIds = table.Column<string>(nullable: true),
                    Reference = table.Column<int>(nullable: false),
                    PassCode = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Replay = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusApplications_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlusApplicationFiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FileId = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlusApplicationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlusApplicationFiles_PlusApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "PlusApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlusApplicationFiles_MatterixFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "MatterixFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ApplicationId",
                table: "Registrations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApplicationId",
                table: "Invoices",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusApplicationFiles_ApplicationId",
                table: "PlusApplicationFiles",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusApplicationFiles_FileId",
                table: "PlusApplicationFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_PlusApplications_StudentId",
                table: "PlusApplications",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_PlusApplications_ApplicationId",
                table: "Invoices",
                column: "ApplicationId",
                principalTable: "PlusApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_PlusApplications_ApplicationId",
                table: "Registrations",
                column: "ApplicationId",
                principalTable: "PlusApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PlusApplications_ApplicationId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_PlusApplications_ApplicationId",
                table: "Registrations");

            migrationBuilder.DropTable(
                name: "PlusApplicationFiles");

            migrationBuilder.DropTable(
                name: "PlusApplications");

            migrationBuilder.DropTable(
                name: "MatterixFiles");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_ApplicationId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ApplicationId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserDevices");

            migrationBuilder.DropColumn(
                name: "Connection",
                table: "UserDevices");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "UserDevices");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Live",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Book",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Goal",
                table: "Courses");
        }
    }
}
