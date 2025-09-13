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
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Capacity).IsRequired();
            entity.Property(e => e.Location).HasMaxLength(200);
        });

        // Configure Booking entity
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BookingDate).HasColumnType("date");
            entity.Property(e => e.TeacherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CreatedAt).IsRequired();

            // Configure foreign key relationship
            entity.HasOne(e => e.Hall)
                  .WithMany(e => e.Bookings)
                  .HasForeignKey(e => e.HallId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Create unique index to prevent double booking
            entity.HasIndex(e => new { e.HallId, e.BookingDate })
                  .IsUnique();
        });

        // Seed data
        modelBuilder.Entity<Hall>().HasData(
            new Hall { Id = 1, Name = "Room 1", Capacity = 200, Location = "Ground Floor" },
            new Hall { Id = 2, Name = "Room 2", Capacity = 50, Location = "First Floor" },
            new Hall { Id = 3, Name = "Room 3", Capacity = 30, Location = "First Floor" },
            new Hall { Id = 4, Name = "Room 4", Capacity = 500, Location = "Second Floor" },
            new Hall { Id = 5, Name = "Room 5", Capacity = 20, Location = "Ground Floor" },
            new Hall { Id = 6, Name = "Room 6", Capacity = 40, Location = "Second Floor" }
        );
    }
}
