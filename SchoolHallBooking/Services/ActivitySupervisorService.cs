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
    }
}
