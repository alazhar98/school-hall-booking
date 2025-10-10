using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlanObjectiveToSupportMultipleAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanObjectives_PlanAreas_PlanAreaId",
                table: "PlanObjectives");

            migrationBuilder.AlterColumn<int>(
                name: "PlanAreaId",
                table: "PlanObjectives",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Areas",
                table: "PlanObjectives",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanObjectives_PlanAreas_PlanAreaId",
                table: "PlanObjectives",
                column: "PlanAreaId",
                principalTable: "PlanAreas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanObjectives_PlanAreas_PlanAreaId",
                table: "PlanObjectives");

            migrationBuilder.DropColumn(
                name: "Areas",
                table: "PlanObjectives");

            migrationBuilder.AlterColumn<int>(
                name: "PlanAreaId",
                table: "PlanObjectives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanObjectives_PlanAreas_PlanAreaId",
                table: "PlanObjectives",
                column: "PlanAreaId",
                principalTable: "PlanAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
