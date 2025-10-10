using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class SwapHall1AndHall3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "Location", "Name" },
                values: new object[] { 30, "الطابق الأول", "قاعة التوجيه المهني" });

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "Location", "Name" },
                values: new object[] { 200, "الطابق الأرضي", "مركز مصادر التعلم" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "Location", "Name" },
                values: new object[] { 200, "الطابق الأرضي", "مركز مصادر التعلم" });

            migrationBuilder.UpdateData(
                table: "Halls",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capacity", "Location", "Name" },
                values: new object[] { 30, "الطابق الأول", "قاعة التوجيه المهني" });
        }
    }
}
