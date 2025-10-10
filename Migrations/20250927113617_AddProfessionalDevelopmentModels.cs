using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessionalDevelopmentModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProgramTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Executor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalEvaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeetingNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Day = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Agenda = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpMeetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImprovementTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TaskOrRole = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImprovementTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalDevelopmentPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProgramName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Executor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ExecutionLocation = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProgramJustifications = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    NumberOfAttendees = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDevelopmentPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgramDesigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Field = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Classification = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ExecutionPeriod = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TargetAudience = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    NumberOfParticipants = table.Column<int>(type: "INTEGER", nullable: false),
                    Objectives = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    WorksheetName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Executor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Duration = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ExecutionLocation = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DuringExecution = table.Column<bool>(type: "INTEGER", nullable: false),
                    AfterExecution = table.Column<bool>(type: "INTEGER", nullable: false),
                    EvaluationMethod = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    WillBeFollowedUp = table.Column<bool>(type: "INTEGER", nullable: false),
                    FollowUpPlan = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgramDesigns", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "FinalEvaluations");

            migrationBuilder.DropTable(
                name: "FollowUpMeetings");

            migrationBuilder.DropTable(
                name: "ImprovementTeams");

            migrationBuilder.DropTable(
                name: "ProfessionalDevelopmentPrograms");

            migrationBuilder.DropTable(
                name: "TrainingProgramDesigns");
        }
    }
}
