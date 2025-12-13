using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherClassVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherClassVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherProfileId = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstTeacherProfileId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeacherName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ClassName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Section = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    VisitDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Standard = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    VisitType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EvaluationType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NumericRating = table.Column<int>(type: "INTEGER", nullable: true),
                    Recommendations = table.Column<string>(type: "TEXT", maxLength: 3000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClassVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherClassVisits_FirstTeacherProfiles_FirstTeacherProfileId",
                        column: x => x.FirstTeacherProfileId,
                        principalTable: "FirstTeacherProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherClassVisits_TeacherProfiles_TeacherProfileId",
                        column: x => x.TeacherProfileId,
                        principalTable: "TeacherProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassVisits_FirstTeacherProfileId",
                table: "TeacherClassVisits",
                column: "FirstTeacherProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClassVisits_TeacherProfileId",
                table: "TeacherClassVisits",
                column: "TeacherProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherClassVisits");
        }
    }
}
