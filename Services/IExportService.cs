using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IExportService
    {
        Task<byte[]> ExportToExcelAsync(List<Booking> bookings);
        string GenerateFileName();
    }
}
