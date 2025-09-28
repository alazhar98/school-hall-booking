using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddSupervisoryVisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupervisoryVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VisitorTeacherName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    VisitedTeacherName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Day = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LessonTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisoryVisits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupervisoryVisits");
        }
    }
}
