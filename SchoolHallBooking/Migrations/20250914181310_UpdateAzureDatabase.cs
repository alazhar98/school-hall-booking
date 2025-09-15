using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAzureDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update Hall 1 to "قاعة التوجيه المهني"
            migrationBuilder.Sql("UPDATE \"Halls\" SET \"Name\" = 'قاعة التوجيه المهني', \"Capacity\" = 30, \"Location\" = 'الطابق الأول' WHERE \"Id\" = 1");
            
            // Update Hall 3 to "مركز مصادر التعلم"
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
