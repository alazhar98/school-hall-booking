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

        // Define available periods based on hall
        List<int> allPeriods;
        if (hallId == 3) // مركز مصادر التعلم - only sessions 2-7
        {
            allPeriods = Enumerable.Range(2, 6).ToList(); // 2, 3, 4, 5, 6, 7
        }
        else // All other halls - sessions 1-8
        {
            allPeriods = Enumerable.Range(1, 8).ToList();
        }
        
        var availablePeriods = allPeriods.Except(bookedPeriods).ToList();

        return availablePeriods;
    }

    public async Task<Booking> CreateBookingAsync(int hallId, DateTime date, string teacherName, string section, int period)
    {
        var normalizedDate = date.Date; // Normalize to midnight
        
        // Check if hall exists
        var hall = await _context.Halls.FindAsync(hallId);
        if (hall == null)
        {
            throw new ArgumentException($"Hall with ID {hallId} not found.");
        }

        // Validate weekend restriction (Friday = 5, Saturday = 6)
        if (normalizedDate.DayOfWeek == DayOfWeek.Friday || normalizedDate.DayOfWeek == DayOfWeek.Saturday)
        {
            throw new InvalidOperationException("لا يمكن الحجز في عطلة نهاية الأسبوع (الجمعة والسبت).");
        }

        // Validate weekly booking restriction
        if (!IsWithinCurrentWeek(normalizedDate))
        {
            var currentWeekStart = GetCurrentWeekStart();
            var currentWeekEnd = GetCurrentWeekEnd();
            throw new InvalidOperationException($"يمكن الحجز فقط خلال الأسبوع الحالي من {currentWeekStart:yyyy/MM/dd} إلى {currentWeekEnd:yyyy/MM/dd}.");
        }

        // Validate period for specific halls
        if (hallId == 3 && (period < 2 || period > 7))
        {
            throw new InvalidOperationException($"مركز مصادر التعلم متاح فقط للحصص من 2 إلى 7. الحصة المحددة: {period}");
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
            Section = section,
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

    /// <summary>
    /// Checks if the given date is within the current week (Saturday to Thursday)
    /// </summary>
    private bool IsWithinCurrentWeek(DateTime date)
    {
        var currentWeekStart = GetCurrentWeekStart();
        var currentWeekEnd = GetCurrentWeekEnd();
        
        return date >= currentWeekStart && date <= currentWeekEnd;
    }

    /// <summary>
    /// Gets the start of the current week (Saturday)
    /// </summary>
    private DateTime GetCurrentWeekStart()
    {
        var today = DateTime.Today;
        var daysSinceSaturday = ((int)today.DayOfWeek + 1) % 7; // Saturday = 0, Sunday = 1, ..., Friday = 6
        return today.AddDays(-daysSinceSaturday);
    }

    /// <summary>
    /// Gets the end of the current week (Thursday)
    /// </summary>
    private DateTime GetCurrentWeekEnd()
    {
        var weekStart = GetCurrentWeekStart();
        return weekStart.AddDays(5); // Saturday + 5 days = Thursday
    }

    /// <summary>
    /// Gets the start of the current week (Saturday) - public method for UI
    /// </summary>
    public DateTime GetCurrentWeekStartPublic()
    {
        return GetCurrentWeekStart();
    }

    /// <summary>
    /// Gets the end of the current week (Thursday) - public method for UI
    /// </summary>
    public DateTime GetCurrentWeekEndPublic()
    {
        return GetCurrentWeekEnd();
    }

    /// <summary>
    /// Checks if a date is a weekend (Friday or Saturday)
    /// </summary>
    public bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
    }

    public async Task<bool> IsHallAvailableAsync(int hallId, DateTime date, int period)
    {
        var normalizedDate = date.Date;
        
        var existingBooking = await _context.Bookings
            .FirstOrDefaultAsync(b => b.HallId == hallId && b.BookingDate == normalizedDate && b.Period == period);

        return existingBooking == null;
    }

    public async Task<List<Booking>> GetHallBookingsAsync(int hallId, DateTime date)
    {
        var normalizedDate = date.Date;
        
        var bookings = await _context.Bookings
            .Include(b => b.Hall)
            .Where(b => b.HallId == hallId && b.BookingDate == normalizedDate)
            .OrderBy(b => b.Period)
            .ToListAsync();

        return bookings;
    }

    public async Task<Dictionary<string, int>> GetHallBookingStatisticsAsync()
    {
        var stats = await _context.Bookings
            .Include(b => b.Hall)
            .GroupBy(b => b.Hall.Name)
            .Select(g => new { HallName = g.Key, BookingCount = g.Count() })
            .ToDictionaryAsync(x => x.HallName, x => x.BookingCount);

        return stats;
    }

    public async Task<Dictionary<string, int>> GetSectionBookingStatisticsAsync()
    {
        var stats = await _context.Bookings
            .GroupBy(b => b.Section)
            .Select(g => new { Section = g.Key, BookingCount = g.Count() })
            .ToDictionaryAsync(x => x.Section, x => x.BookingCount);

        return stats;
    }

    public async Task<List<Booking>> GetFilteredBookingsAsync(int? hallId, DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Bookings.Include(b => b.Hall).AsQueryable();

        if (hallId.HasValue)
        {
            query = query.Where(b => b.HallId == hallId.Value);
        }

        if (fromDate.HasValue)
        {
            query = query.Where(b => b.BookingDate >= fromDate.Value.Date);
        }

        if (toDate.HasValue)
        {
            query = query.Where(b => b.BookingDate <= toDate.Value.Date);
        }

        return await query
            .OrderBy(b => b.BookingDate)
            .ThenBy(b => b.Hall.Name)
            .ThenBy(b => b.Period)
            .ToListAsync();
    }

    private static bool IsUniqueConstraintViolation(DbUpdateException ex)
    {
        return ex.InnerException?.Message.Contains("UNIQUE constraint") == true ||
               ex.InnerException?.Message.Contains("duplicate key") == true;
    }
}
