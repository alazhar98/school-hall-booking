using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherMeeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MeetingTime = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Goals = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Recommendations = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Attendance = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherMeetings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherMeetings");
        }
    }
}
