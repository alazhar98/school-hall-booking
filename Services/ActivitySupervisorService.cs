using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class ActivitySupervisorService : IActivitySupervisorService
    {
        private readonly BookingDbContext _context;

        public ActivitySupervisorService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _context.Activities
                .Include(a => a.Supervisors)
                .Where(a => a.IsActive)
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public async Task<List<ActivitySupervisor>> GetSupervisorsByActivityIdAsync(int activityId)
        {
            return await _context.ActivitySupervisors
                .Where(s => s.ActivityId == activityId && s.IsActive)
                .OrderBy(s => s.TeacherName)
                .ToListAsync();
        }

        public async Task<ActivitySupervisor?> AddSupervisorAsync(ActivitySupervisor supervisor)
        {
            try
            {
                supervisor.CreatedAt = DateTime.Now;
                _context.ActivitySupervisors.Add(supervisor);
                await _context.SaveChangesAsync();
                return supervisor;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ActivitySupervisor?> UpdateSupervisorAsync(ActivitySupervisor supervisor)
        {
            try
            {
                var existingSupervisor = await _context.ActivitySupervisors.FindAsync(supervisor.Id);
                if (existingSupervisor == null)
                    return null;

                existingSupervisor.TeacherName = supervisor.TeacherName;
                existingSupervisor.TeacherId = supervisor.TeacherId;
                existingSupervisor.IsActive = supervisor.IsActive;

                await _context.SaveChangesAsync();
                return existingSupervisor;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteSupervisorAsync(int supervisorId)
        {
            try
            {
                var supervisor = await _context.ActivitySupervisors.FindAsync(supervisorId);
                if (supervisor == null)
                    return false;

                _context.ActivitySupervisors.Remove(supervisor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Activity?> GetActivityByIdAsync(int activityId)
        {
            return await _context.Activities
                .Include(a => a.Supervisors)
                .FirstOrDefaultAsync(a => a.Id == activityId);
        }

        public async Task<Activity?> AddActivityAsync(Activity activity)
        {
            try
            {
                activity.CreatedAt = DateTime.Now;
                activity.IsActive = true;
                _context.Activities.Add(activity);
                await _context.SaveChangesAsync();
                return activity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Activity?> UpdateActivityAsync(Activity activity)
        {
            try
            {
                var existingActivity = await _context.Activities.FindAsync(activity.Id);
                if (existingActivity == null)
                    return null;

                existingActivity.Name = activity.Name;
                existingActivity.IsActive = activity.IsActive;

                await _context.SaveChangesAsync();
                return existingActivity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteActivityAsync(int activityId)
        {
            try
            {
                var activity = await _context.Activities
                    .Include(a => a.Supervisors)
                    .FirstOrDefaultAsync(a => a.Id == activityId);
                    
                if (activity == null)
                    return false;

                // حذف جميع المشرفين المرتبطين بالنشاط
                _context.ActivitySupervisors.RemoveRange(activity.Supervisors);
                
                // حذف النشاط
                _context.Activities.Remove(activity);
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
