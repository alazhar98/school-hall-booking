using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services;

public class BookingService : IBookingService
{
    private readonly BookingDbContext _context;
    private readonly ILogger<BookingService> _logger;

    public BookingService(BookingDbContext context, ILogger<BookingService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Hall>> GetAvailableHallsAsync(DateTime date)
    {
        // Return all halls - availability will be checked per period
        var availableHalls = await _context.Halls
            .OrderBy(h => h.Name)
            .ToListAsync();

        return availableHalls;
    }

    public async Task<List<int>> GetAvailablePeriodsAsync(int hallId, DateTime date)
    {
        var normalizedDate = date.Date;
        
        var bookedPeriods = await _context.Bookings
            .Where(b => b.HallId == hallId && b.BookingDate == normalizedDate)
            .Select(b => b.Period)
            .ToListAsync();

        var allPeriods = Enumerable.Range(1, 8).ToList();
        var availablePeriods = allPeriods.Except(bookedPeriods).ToList();

        return availablePeriods;
    }

    public async Task<Booking> CreateBookingAsync(int hallId, DateTime date, string teacherName, int period)
    {
        var normalizedDate = date.Date; // Normalize to midnight
        
        // Check if hall exists
        var hall = await _context.Halls.FindAsync(hallId);
        if (hall == null)
        {
            throw new ArgumentException($"Hall with ID {hallId} not found.");
        }

        // Check if hall is already booked on this date and period
        var existingBooking = await _context.Bookings
            .FirstOrDefaultAsync(b => b.HallId == hallId && b.BookingDate == normalizedDate && b.Period == period);

        if (existingBooking != null)
        {
            throw new InvalidOperationException($"Hall '{hall.Name}' is already booked on {normalizedDate:yyyy-MM-dd} for Period {period}.");
        }

        var booking = new Booking
        {
            HallId = hallId,
            BookingDate = normalizedDate,
            TeacherName = teacherName,
            Period = period,
            CreatedAt = DateTime.UtcNow
        };

        try
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Booking created successfully. Hall: {HallName}, Date: {Date}, Period: {Period}, Teacher: {Teacher}", 
                hall.Name, normalizedDate, period, teacherName);
            
            return booking;
        }
        catch (DbUpdateException ex) when (IsUniqueConstraintViolation(ex))
        {
            _logger.LogWarning("Concurrency conflict: Hall {HallId} already booked on {Date}", hallId, normalizedDate);
            throw new InvalidOperationException($"Hall '{hall.Name}' is already booked on {normalizedDate:yyyy-MM-dd} for Period {period}. Please try again.");
        }
    }

    public async Task<List<Booking>> GetBookingsAsync(DateTime date)
    {
        var normalizedDate = date.Date;
        
        var bookings = await _context.Bookings
            .Include(b => b.Hall)
            .Where(b => b.BookingDate == normalizedDate)
            .OrderBy(b => b.Hall.Name)
            .ToListAsync();

        return bookings;
    }

    public async Task<List<Booking>> GetAllBookingsAsync()
    {
        var bookings = await _context.Bookings
            .Include(b => b.Hall)
            .OrderBy(b => b.BookingDate)
            .ThenBy(b => b.Hall.Name)
            .ToListAsync();

        return bookings;
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
        var booking = await _context.Bookings.FindAsync(bookingId);
        if (booking == null)
        {
            throw new ArgumentException($"Booking with ID {bookingId} not found.");
        }

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        
        _logger.LogInformation("Booking deleted successfully. ID: {BookingId}, Hall: {HallId}, Date: {Date}", 
            bookingId, booking.HallId, booking.BookingDate);
    }

    public async Task<Hall?> GetHallByIdAsync(int hallId)
    {
        return await _context.Halls.FindAsync(hallId);
    }

    public async Task<bool> IsHallAvailableAsync(int hallId, DateTime date, int period)
    {
        var normalizedDate = date.Date;
        
        var existingBooking = await _context.Bookings
            .FirstOrDefaultAsync(b => b.HallId == hallId && b.BookingDate == normalizedDate && b.Period == period);

        return existingBooking == null;
    }

    private static bool IsUniqueConstraintViolation(DbUpdateException ex)
    {
        return ex.InnerException?.Message.Contains("UNIQUE constraint") == true ||
               ex.InnerException?.Message.Contains("duplicate key") == true;
    }
}
