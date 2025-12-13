using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstTeacherProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstTeacherProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EmployeeNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Qualification = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Specialization = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    PreviousPerformanceEvaluation = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    TeachingStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SchoolStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PhotoPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    JobGrade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Class = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Division = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    NumberOfLessons = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessionalGoals = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstTeacherProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstTeacherProfiles_EmployeeNumber",
                table: "FirstTeacherProfiles",
                column: "EmployeeNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstTeacherProfiles");
        }
    }
}
