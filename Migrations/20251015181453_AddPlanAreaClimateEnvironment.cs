using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddPlanAreaClimateEnvironment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlanAreas",
                columns: new[] { "Id", "Name", "IsActive", "CreatedAt" },
                values: new object[] { 5, "مناخ المدرسة و بيئة التعلم", true, new DateTime(2024, 1, 1) }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanAreas",
                keyColumn: "Id",
                keyValue: 5
            );
        }
    }
}
