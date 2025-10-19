using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainingProgramSummaryField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrainingProgramSummary",
                table: "ProfessionalDevelopmentPrograms",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainingProgramSummary",
                table: "ProfessionalDevelopmentPrograms");
        }
    }
}
