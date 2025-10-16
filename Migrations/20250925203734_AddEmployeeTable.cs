using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "IsActive", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 26, 0, 37, 34, 271, DateTimeKind.Local).AddTicks(5270), "EMP001", true, "أحمد محمد", "123456", "مدير" },
                    { 2, new DateTime(2025, 9, 26, 0, 37, 34, 271, DateTimeKind.Local).AddTicks(5410), "EMP002", true, "فاطمة علي", "123456", "نائب مدير" },
                    { 3, new DateTime(2025, 9, 26, 0, 37, 34, 271, DateTimeKind.Local).AddTicks(5420), "EMP003", true, "محمد حسن", "123456", "معلم" },
                    { 4, new DateTime(2025, 9, 26, 0, 37, 34, 271, DateTimeKind.Local).AddTicks(5420), "EMP004", true, "سارة أحمد", "123456", "معلمة" },
                    { 5, new DateTime(2025, 9, 26, 0, 37, 34, 271, DateTimeKind.Local).AddTicks(5420), "EMP005", true, "عبدالله سالم", "123456", "موظف إداري" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffStatistics_Role",
                table: "StaffStatistics",
                column: "Role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_StaffStatistics_Role",
                table: "StaffStatistics");
        }
    }
}
