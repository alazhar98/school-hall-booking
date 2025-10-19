using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToProfessionalDevelopmentProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ProfessionalDevelopmentPrograms",
                type: "TEXT",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ProfessionalDevelopmentPrograms");
        }
    }
}
