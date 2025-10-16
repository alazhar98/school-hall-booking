using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class TeachersAttendanceService : ITeachersAttendanceService
    {
        private readonly BookingDbContext _context;
        public TeachersAttendanceService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherWorkshopRecordEntity>> GetWorkshopsAsync()
        {
            return await _context.Set<TeacherWorkshopRecordEntity>()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<TeacherWorkshopRecordEntity> AddWorkshopAsync(TeacherWorkshopRecordEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TeacherWorkshopRecordEntity?> UpdateWorkshopAsync(TeacherWorkshopRecordEntity entity)
        {
            var existing = await _context.Set<TeacherWorkshopRecordEntity>().FindAsync(entity.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteWorkshopAsync(int id)
        {
            var existing = await _context.Set<TeacherWorkshopRecordEntity>().FindAsync(id);
            if (existing == null) return false;
            _context.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TeacherLeaveRequestEntity>> GetLeavesAsync()
        {
            return await _context.Set<TeacherLeaveRequestEntity>()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<TeacherLeaveRequestEntity> AddLeaveAsync(TeacherLeaveRequestEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TeacherLeaveRequestEntity?> UpdateLeaveAsync(TeacherLeaveRequestEntity entity)
        {
            var existing = await _context.Set<TeacherLeaveRequestEntity>().FindAsync(entity.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteLeaveAsync(int id)
        {
            var existing = await _context.Set<TeacherLeaveRequestEntity>().FindAsync(id);
            if (existing == null) return false;
            _context.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


