using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IDutyScheduleService
    {
        Task<List<DutyScheduleItem>> GetScheduleAsync();
        Task SaveScheduleAsync(List<DutyScheduleItem> scheduleItems);
        Task<DutyScheduleItem?> GetScheduleItemAsync(int id);
        Task DeleteScheduleItemAsync(int id);
    }
}


