using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    EmployeeNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Qualification = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Specialization = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    YearsOfTeaching = table.Column<int>(type: "INTEGER", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    JobGrade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    SubjectTaught = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Class = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Division = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    NumberOfLessons = table.Column<int>(type: "INTEGER", nullable: true),
                    SchedulePhotoPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DevelopmentPrograms = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Workshops = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    PreviousEvaluation = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherProfiles_EmployeeNumber",
                table: "TeacherProfiles",
                column: "EmployeeNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherProfiles");
        }
    }
}
