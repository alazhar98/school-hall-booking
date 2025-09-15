using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services;

public interface IBookingService
{
    Task<List<Hall>> GetAvailableHallsAsync(DateTime date);
    Task<List<int>> GetAvailablePeriodsAsync(int hallId, DateTime date);
    Task<Booking> CreateBookingAsync(int hallId, DateTime date, string teacherName, string section, int period);
    Task<List<Booking>> GetBookingsAsync(DateTime date);
    Task<List<Booking>> GetAllBookingsAsync();
    Task DeleteBookingAsync(int bookingId);
    Task<Hall?> GetHallByIdAsync(int hallId);
    Task<bool> IsHallAvailableAsync(int hallId, DateTime date, int period);
    Task<List<Booking>> GetHallBookingsAsync(int hallId, DateTime date);
    Task<Dictionary<string, int>> GetHallBookingStatisticsAsync();
    Task<Dictionary<string, int>> GetSectionBookingStatisticsAsync();
    Task<List<Booking>> GetFilteredBookingsAsync(int? hallId, DateTime? fromDate, DateTime? toDate);
    DateTime GetCurrentWeekStartPublic();
    DateTime GetCurrentWeekEndPublic();
    bool IsWeekend(DateTime date);
}
