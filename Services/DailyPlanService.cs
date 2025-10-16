using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolHallBooking.Services
{
    public class DailyPlanService : IDailyPlanService
    {
        private readonly BookingDbContext _context;

        public DailyPlanService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<DailyPlan>> GetDailyPlansAsync(string month, int day)
        {
            return await _context.DailyPlans
                                 .Where(dp => dp.Month == month && dp.Day == day)
                                 .OrderBy(dp => dp.CreatedAt)
                                 .ToListAsync();
        }

        public async Task<List<DailyPlan>> GetAllDailyPlansAsync()
        {
            return await _context.DailyPlans.ToListAsync();
        }

        public async Task<DailyPlan?> GetDailyPlanByIdAsync(int id)
        {
            return await _context.DailyPlans.FindAsync(id);
        }

        public async Task AddDailyPlanAsync(DailyPlan dailyPlan)
        {
            dailyPlan.CreatedAt = DateTime.Now;
            dailyPlan.UpdatedAt = DateTime.Now;
            _context.DailyPlans.Add(dailyPlan);
            await _context.SaveChangesAsync();
        }

    public async Task UpdateDailyPlanAsync(DailyPlan dailyPlan)
    {
        var existingPlan = await _context.DailyPlans.FindAsync(dailyPlan.Id);
        if (existingPlan != null)
        {
            existingPlan.Month = dailyPlan.Month;
            existingPlan.Day = dailyPlan.Day;
            existingPlan.Action = dailyPlan.Action;
            existingPlan.Executor = dailyPlan.Executor;
            existingPlan.IsExecuted = dailyPlan.IsExecuted;
            existingPlan.ReasonForNonExecution = dailyPlan.ReasonForNonExecution;
            existingPlan.ActionTaken = dailyPlan.ActionTaken;
            existingPlan.UpdatedAt = DateTime.Now;
            
            await _context.SaveChangesAsync();
        }
    }

        public async Task DeleteDailyPlanAsync(int id)
        {
            var dailyPlan = await _context.DailyPlans.FindAsync(id);
            if (dailyPlan != null)
            {
                _context.DailyPlans.Remove(dailyPlan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<string>> GetAvailableMonthsAsync()
        {
            return await _context.DailyPlans
                .Select(dp => dp.Month)
                .Distinct()
                .OrderBy(month => month)
                .ToListAsync();
        }

        public async Task<List<int>> GetAvailableDaysAsync(string month)
        {
            return await _context.DailyPlans
                .Where(dp => dp.Month == month)
                .Select(dp => dp.Day)
                .Distinct()
                .OrderBy(day => day)
                .ToListAsync();
        }
    }
}