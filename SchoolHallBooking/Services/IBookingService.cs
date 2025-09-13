using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services;

public interface IBookingService
{
    Task<List<Hall>> GetAvailableHallsAsync(DateTime date);
    Task<List<int>> GetAvailablePeriodsAsync(int hallId, DateTime date);
    Task<Booking> CreateBookingAsync(int hallId, DateTime date, string teacherName, int period);
    Task<List<Booking>> GetBookingsAsync(DateTime date);
    Task<List<Booking>> GetAllBookingsAsync();
    Task DeleteBookingAsync(int bookingId);
    Task<Hall?> GetHallByIdAsync(int hallId);
    Task<bool> IsHallAvailableAsync(int hallId, DateTime date, int period);
}
