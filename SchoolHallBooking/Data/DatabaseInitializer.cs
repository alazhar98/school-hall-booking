using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SchoolHallBooking.Data
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeDatabaseAsync(BookingDbContext context)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Fix the unique constraint if it exists
            try
            {
                // Drop the old unique index if it exists
                await context.Database.ExecuteSqlRawAsync("DROP INDEX IF EXISTS \"IX_Bookings_HallId_BookingDate\"");
                
                // Create the new unique index that includes Period
                await context.Database.ExecuteSqlRawAsync(
                    "CREATE UNIQUE INDEX IF NOT EXISTS \"IX_Bookings_HallId_BookingDate_Period\" ON \"Bookings\" (\"HallId\", \"BookingDate\", \"Period\")");
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the application startup
                Console.WriteLine($"Warning: Could not fix database constraints: {ex.Message}");
            }

            // Apply pending migrations if any (with error handling)
            try
            {
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                // Log the error but don't fail the application startup
                Console.WriteLine($"Warning: Could not apply migrations: {ex.Message}");
            }

            // Seed initial data for halls if they don't exist or update their names
            if (!context.Halls.Any())
            {
                context.Halls.AddRange(
                    new Hall { Id = 1, Name = "قاعة التوجيه المهني", Capacity = 30, Location = "الطابق الأول" },
                    new Hall { Id = 2, Name = "قاعة الفضل", Capacity = 50, Location = "الطابق الأول" },
                    new Hall { Id = 3, Name = "مركز مصادر التعلم", Capacity = 200, Location = "الطابق الأرضي" },
                    new Hall { Id = 4, Name = "قاعة اللغة الإنجليزية", Capacity = 500, Location = "الطابق الثاني" },
                    new Hall { Id = 5, Name = "قاعة اللغة العربية", Capacity = 20, Location = "الطابق الأرضي" },
                    new Hall { Id = 6, Name = "قاعة المهارات الموسيقية", Capacity = 40, Location = "الطابق الثاني" }
                );
                await context.SaveChangesAsync();
            }
            else
            {
                // Update hall names to ensure they match the swapped configuration
                var hallsToUpdate = new Dictionary<int, (string Name, int Capacity, string Location)>
                {
                    { 1, ("قاعة التوجيه المهني", 30, "الطابق الأول") },
                    { 2, ("قاعة الفضل", 50, "الطابق الأول") },
                    { 3, ("مركز مصادر التعلم", 200, "الطابق الأرضي") },
                    { 4, ("قاعة اللغة الإنجليزية", 500, "الطابق الثاني") },
                    { 5, ("قاعة اللغة العربية", 20, "الطابق الأرضي") },
                    { 6, ("قاعة المهارات الموسيقية", 40, "الطابق الثاني") }
                };

                bool changesMade = false;
                foreach (var entry in hallsToUpdate)
                {
                    var hall = await context.Halls.FindAsync(entry.Key);
                    if (hall != null && (hall.Name != entry.Value.Name || hall.Capacity != entry.Value.Capacity || hall.Location != entry.Value.Location))
                    {
                        hall.Name = entry.Value.Name;
                        hall.Capacity = entry.Value.Capacity;
                        hall.Location = entry.Value.Location;
                        changesMade = true;
                    }
                    else if (hall == null)
                    {
                        // Add missing hall if it doesn't exist
                        context.Halls.Add(new Hall { Id = entry.Key, Name = entry.Value.Name, Capacity = entry.Value.Capacity, Location = entry.Value.Location });
                        changesMade = true;
                    }
                }

                if (changesMade)
                {
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
