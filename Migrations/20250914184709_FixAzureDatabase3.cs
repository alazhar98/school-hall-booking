using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class FixAzureDatabase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ensure Hall 1 is "قاعة التوجيه المهني"
            migrationBuilder.Sql("UPDATE \"Halls\" SET \"Name\" = 'قاعة التوجيه المهني', \"Capacity\" = 30, \"Location\" = 'الطابق الأول' WHERE \"Id\" = 1");
            
            // Ensure Hall 3 is "مركز مصادر التعلم"
            migrationBuilder.Sql("UPDATE \"Halls\" SET \"Name\" = 'مركز مصادر التعلم', \"Capacity\" = 200, \"Location\" = 'الطابق الأرضي' WHERE \"Id\" = 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert Hall 1 to "مركز مصادر التعلم"
            migrationBuilder.Sql("UPDATE \"Halls\" SET \"Name\" = 'مركز مصادر التعلم', \"Capacity\" = 200, \"Location\" = 'الطابق الأرضي' WHERE \"Id\" = 1");
            
            // Revert Hall 3 to "قاعة التوجيه المهني"
            migrationBuilder.Sql("UPDATE \"Halls\" SET \"Name\" = 'قاعة التوجيه المهني', \"Capacity\" = 30, \"Location\" = 'الطابق الأول' WHERE \"Id\" = 3");
        }
    }
}
