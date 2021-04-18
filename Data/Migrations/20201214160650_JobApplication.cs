using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matterix.Data.Migrations
{
    public partial class JobApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReplayMessage",
                table: "ContactMessages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplyDate = table.Column<DateTime>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    VideoLink = table.Column<string>(nullable: true),
                    ExtraMessage = table.Column<string>(nullable: true),
                    Replay = table.Column<string>(nullable: true),
                    CvRootPath = table.Column<string>(nullable: true),
                    CvWebPath = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: false),
                    InterviewDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ReplayMessage",
                table: "ContactMessages");
        }
    }
}
