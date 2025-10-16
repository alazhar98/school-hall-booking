using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IDailyPlanService
    {
        Task<List<DailyPlan>> GetDailyPlansAsync(string month, int day);
        Task<List<DailyPlan>> GetAllDailyPlansAsync();
        Task<DailyPlan?> GetDailyPlanByIdAsync(int id);
        Task AddDailyPlanAsync(DailyPlan dailyPlan);
        Task UpdateDailyPlanAsync(DailyPlan dailyPlan);
        Task DeleteDailyPlanAsync(int id);
        Task<List<string>> GetAvailableMonthsAsync();
        Task<List<int>> GetAvailableDaysAsync(string month);
    }
}
