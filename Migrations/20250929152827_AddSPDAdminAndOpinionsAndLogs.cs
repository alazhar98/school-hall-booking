using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddSPDAdminAndOpinionsAndLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminJobVisitAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Strengths = table.Column<string>(type: "TEXT", nullable: false),
                    Enhancements = table.Column<string>(type: "TEXT", nullable: false),
                    FollowUpActions = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentPriorities = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentActions = table.Column<string>(type: "TEXT", nullable: false),
                    DevelopmentFollowUp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminJobVisitAnalyses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentsOpinionAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Strengths = table.Column<string>(type: "TEXT", nullable: false),
                    Enhancements = table.Column<string>(type: "TEXT", nullable: false),
                    FollowUpActions = table.Column<string>(type: "TEXT", nullable: false),
                    SummarySuggestions = table.Column<string>(type: "TEXT", nullable: false),
                    SummaryFollowUp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentsOpinionAnalyses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPDDirectiveRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    DirectiveNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DirectiveDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Issuer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPDDirectiveRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPDFollowupMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    MeetingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Day = table.Column<string>(type: "TEXT", nullable: false),
                    Agenda = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPDFollowupMeetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPDImprovementTeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPDImprovementTeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPDVisitRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    VisitorName = table.Column<string>(type: "TEXT", nullable: false),
                    VisitorJob = table.Column<string>(type: "TEXT", nullable: false),
                    Organization = table.Column<string>(type: "TEXT", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Target = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPDVisitRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffOpinionAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Strengths = table.Column<string>(type: "TEXT", nullable: false),
                    Enhancements = table.Column<string>(type: "TEXT", nullable: false),
                    FollowUpActions = table.Column<string>(type: "TEXT", nullable: false),
                    SummarySuggestions = table.Column<string>(type: "TEXT", nullable: false),
                    SummaryFollowUp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffOpinionAnalyses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentOpinionAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Strengths = table.Column<string>(type: "TEXT", nullable: false),
                    Enhancements = table.Column<string>(type: "TEXT", nullable: false),
                    FollowUpActions = table.Column<string>(type: "TEXT", nullable: false),
                    SummarySuggestions = table.Column<string>(type: "TEXT", nullable: false),
                    SummaryFollowUp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOpinionAnalyses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminJobVisitAnalyses");

            migrationBuilder.DropTable(
                name: "ParentsOpinionAnalyses");

            migrationBuilder.DropTable(
                name: "SPDDirectiveRecords");

            migrationBuilder.DropTable(
                name: "SPDFollowupMeetings");

            migrationBuilder.DropTable(
                name: "SPDImprovementTeamMembers");

            migrationBuilder.DropTable(
                name: "SPDVisitRecords");

            migrationBuilder.DropTable(
                name: "StaffOpinionAnalyses");

            migrationBuilder.DropTable(
                name: "StudentOpinionAnalyses");
        }
    }
}
