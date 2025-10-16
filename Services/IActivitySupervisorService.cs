using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IActivitySupervisorService
    {
        Task<List<Activity>> GetAllActivitiesAsync();
        Task<List<ActivitySupervisor>> GetSupervisorsByActivityIdAsync(int activityId);
        Task<ActivitySupervisor?> AddSupervisorAsync(ActivitySupervisor supervisor);
        Task<ActivitySupervisor?> UpdateSupervisorAsync(ActivitySupervisor supervisor);
        Task<bool> DeleteSupervisorAsync(int supervisorId);
        Task<Activity?> GetActivityByIdAsync(int activityId);
        Task<Activity?> AddActivityAsync(Activity activity);
        Task<Activity?> UpdateActivityAsync(Activity activity);
        Task<bool> DeleteActivityAsync(int activityId);
    }
}
