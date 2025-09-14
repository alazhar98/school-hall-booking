using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing unique index if it exists
            migrationBuilder.Sql("DROP INDEX IF EXISTS \"IX_Bookings_HallId_BookingDate\"");

            // Create a new unique index that includes Period if it doesn't exist
            migrationBuilder.Sql("CREATE UNIQUE INDEX IF NOT EXISTS \"IX_Bookings_HallId_BookingDate_Period\" ON \"Bookings\" (\"HallId\", \"BookingDate\", \"Period\")");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the new unique index
            migrationBuilder.DropIndex(
                name: "IX_Bookings_HallId_BookingDate_Period",
                table: "Bookings");

            // Recreate the original unique index
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HallId_BookingDate",
                table: "Bookings",
                columns: new[] { "HallId", "BookingDate" },
                unique: true);
        }
    }
}
