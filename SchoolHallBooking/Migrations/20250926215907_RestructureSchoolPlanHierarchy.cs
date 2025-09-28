using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class RestructureSchoolPlanHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanActions_PlanObjectives_PlanObjectiveId",
                table: "PlanActions");

            migrationBuilder.DropColumn(
                name: "Areas",
                table: "PlanObjectives");

            migrationBuilder.RenameColumn(
                name: "PlanObjectiveId",
                table: "PlanActions",
                newName: "PlanSubObjectiveId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanActions_PlanObjectiveId",
                table: "PlanActions",
                newName: "IX_PlanActions_PlanSubObjectiveId");

            migrationBuilder.CreateTable(
                name: "PlanSubObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanObjectiveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Area = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SubObjective = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSubObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanSubObjectives_PlanObjectives_PlanObjectiveId",
                        column: x => x.PlanObjectiveId,
                        principalTable: "PlanObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanSubObjectives_PlanObjectiveId",
                table: "PlanSubObjectives",
                column: "PlanObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActions_PlanSubObjectives_PlanSubObjectiveId",
                table: "PlanActions",
                column: "PlanSubObjectiveId",
                principalTable: "PlanSubObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanActions_PlanSubObjectives_PlanSubObjectiveId",
                table: "PlanActions");

            migrationBuilder.DropTable(
                name: "PlanSubObjectives");

            migrationBuilder.RenameColumn(
                name: "PlanSubObjectiveId",
                table: "PlanActions",
                newName: "PlanObjectiveId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanActions_PlanSubObjectiveId",
                table: "PlanActions",
                newName: "IX_PlanActions_PlanObjectiveId");

            migrationBuilder.AddColumn<string>(
                name: "Areas",
                table: "PlanObjectives",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanActions_PlanObjectives_PlanObjectiveId",
                table: "PlanActions",
                column: "PlanObjectiveId",
                principalTable: "PlanObjectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
