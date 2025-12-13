using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstTeacherReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstTeacherReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstTeacherProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    FromDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ToDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlanProgress = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    PlanAchievements = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    PlanChallenges = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    VisitNotes = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    PerformanceSummary = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    PerformanceActions = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    DutyCommitment = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    DutyNotes = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    DutyActions = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    MeetingsCount = table.Column<int>(type: "INTEGER", nullable: true),
                    MeetingDecisions = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    MeetingFollowup = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    TrainingPrograms = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    TrainingImpact = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    TrainingFutureNeeds = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    AttendancePercentage = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    RecommendationImplementation = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    PlanCompletion = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Recommendations = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Suggestions = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstTeacherReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstTeacherReports_FirstTeacherProfiles_FirstTeacherProfileId",
                        column: x => x.FirstTeacherProfileId,
                        principalTable: "FirstTeacherProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstTeacherReports_FirstTeacherProfileId",
                table: "FirstTeacherReports",
                column: "FirstTeacherProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstTeacherReports");
        }
    }
}
