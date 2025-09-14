using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Data;

public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    {
    }

    public DbSet<Hall> Halls { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Hall entity
        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Capacity).IsRequired();
            entity.Property(e => e.Location).HasMaxLength(200);
        });

        // Configure Booking entity
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.BookingDate).HasColumnType("date");
            entity.Property(e => e.TeacherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CreatedAt).IsRequired();

            // Configure foreign key relationship
            entity.HasOne(e => e.Hall)
                  .WithMany(e => e.Bookings)
                  .HasForeignKey(e => e.HallId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Create unique index to prevent double booking for same hall, date, and period
            entity.HasIndex(e => new { e.HallId, e.BookingDate, e.Period })
                  .IsUnique();
        });

        // Seed data
        modelBuilder.Entity<Hall>().HasData(
            new Hall { Id = 1, Name = "قاعة التوجيه المهني", Capacity = 30, Location = "الطابق الأول" },
            new Hall { Id = 2, Name = "قاعة الفضل", Capacity = 50, Location = "الطابق الأول" },
            new Hall { Id = 3, Name = "مركز مصادر التعلم", Capacity = 200, Location = "الطابق الأرضي" },
            new Hall { Id = 4, Name = "قاعة اللغة الإنجليزية", Capacity = 500, Location = "الطابق الثاني" },
            new Hall { Id = 5, Name = "قاعة اللغة العربية", Capacity = 20, Location = "الطابق الأرضي" },
            new Hall { Id = 6, Name = "قاعة المهارات الموسيقية", Capacity = 40, Location = "الطابق الثاني" }
        );
    }
}
