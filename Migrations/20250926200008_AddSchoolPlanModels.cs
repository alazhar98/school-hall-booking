using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolPlanModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Objective = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanObjectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanObjectives_PlanAreas_PlanAreaId",
                        column: x => x.PlanAreaId,
                        principalTable: "PlanAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanObjectiveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    TimePeriod = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Executor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsExecuted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanActions_PlanObjectives_PlanObjectiveId",
                        column: x => x.PlanObjectiveId,
                        principalTable: "PlanObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlanAreas",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "القيادة والإدارة والحوكمة" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "النمو الشخصي للطلبة ورعايتهم" },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "التدريس والتقويم" },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "إنجاز الطلبة" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanActions_PlanObjectiveId",
                table: "PlanActions",
                column: "PlanObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanObjectives_PlanAreaId",
                table: "PlanObjectives",
                column: "PlanAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanActions");

            migrationBuilder.DropTable(
                name: "PlanObjectives");

            migrationBuilder.DropTable(
                name: "PlanAreas");
        }
    }
}
