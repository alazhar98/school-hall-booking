using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddAcademicAchievementTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicAchievementFollowupMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Day = table.Column<string>(type: "TEXT", nullable: false),
                    Agenda = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicAchievementFollowupMeetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicAchievementImprovementTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    TaskOrRole = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicAchievementImprovementTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicAchievementInitiatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    TargetGroup = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectIdea = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectObjectives = table.Column<string>(type: "TEXT", nullable: false),
                    Timeline = table.Column<string>(type: "TEXT", nullable: false),
                    ImplementationMechanism = table.Column<string>(type: "TEXT", nullable: false),
                    TechnicalOpinion = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicAchievementInitiatives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicAchievementPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Activity = table.Column<string>(type: "TEXT", nullable: false),
                    ImplementationPeriod = table.Column<string>(type: "TEXT", nullable: false),
                    TargetGroup = table.Column<string>(type: "TEXT", nullable: false),
                    ImplementingBody = table.Column<string>(type: "TEXT", nullable: false),
                    IsImplemented = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicAchievementPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicAchievementSchoolEfforts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    ProgramOrActivity = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    TargetGroup = table.Column<string>(type: "TEXT", nullable: false),
                    Implementers = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicAchievementSchoolEfforts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicAchievementFollowupMeetings");

            migrationBuilder.DropTable(
                name: "AcademicAchievementImprovementTeams");

            migrationBuilder.DropTable(
                name: "AcademicAchievementInitiatives");

            migrationBuilder.DropTable(
                name: "AcademicAchievementPlans");

            migrationBuilder.DropTable(
                name: "AcademicAchievementSchoolEfforts");
        }
    }
}
