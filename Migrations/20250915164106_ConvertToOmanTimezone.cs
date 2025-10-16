using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class ConvertToOmanTimezone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Note: This migration is for documentation purposes only.
            // The timezone conversion is handled in the application layer.
            // Existing bookings are assumed to be in UTC and will be converted
            // to Oman timezone (GMT+4) when displayed to users.
            
            // No database schema changes are needed for timezone conversion.
            // The conversion is handled by the TimeZoneService in the application.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
