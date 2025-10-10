using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolPerformanceDevelopment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentWorkAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Strengths = table.Column<string>(type: "TEXT", nullable: false),
                    Enhancements = table.Column<string>(type: "TEXT", nullable: false),
                    FollowUpActions = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentPriorities = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentActions = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentFollowUp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentWorkAnalyses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupervisoryVisitAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Strengths = table.Column<string>(type: "TEXT", nullable: false),
                    Enhancements = table.Column<string>(type: "TEXT", nullable: false),
                    FollowUpActions = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentPriorities = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentActions = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentFollowUp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisoryVisitAnalyses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentWorkAnalyses");

            migrationBuilder.DropTable(
                name: "SupervisoryVisitAnalyses");
        }
    }
}
