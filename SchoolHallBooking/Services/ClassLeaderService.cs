using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class ClassLeaderService : IClassLeaderService
    {
        private readonly BookingDbContext _context;

        public ClassLeaderService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassLeader>> GetAllClassLeadersAsync()
        {
            return await _context.ClassLeaders
                                 .Where(cl => cl.IsActive)
                                 .OrderBy(cl => cl.ClassName)
                                 .ToListAsync();
        }

        public async Task<ClassLeader?> GetClassLeaderByIdAsync(int id)
        {
            return await _context.ClassLeaders.FindAsync(id);
        }

        public async Task AddClassLeaderAsync(ClassLeader classLeader)
        {
            classLeader.CreatedAt = DateTime.Now;
            classLeader.UpdatedAt = DateTime.Now;
            _context.ClassLeaders.Add(classLeader);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClassLeaderAsync(ClassLeader classLeader)
        {
            var existingClassLeader = await _context.ClassLeaders.FindAsync(classLeader.Id);
            if (existingClassLeader != null)
            {
                existingClassLeader.ClassName = classLeader.ClassName;
                existingClassLeader.TeacherName = classLeader.TeacherName;
                existingClassLeader.IsActive = classLeader.IsActive;
                existingClassLeader.UpdatedAt = DateTime.Now;
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClassLeaderAsync(int id)
        {
            var classLeader = await _context.ClassLeaders.FindAsync(id);
            if (classLeader != null)
            {
                _context.ClassLeaders.Remove(classLeader);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ClassLeaderExistsAsync(string className, int? excludeId = null)
        {
            return await _context.ClassLeaders
                                 .AnyAsync(cl => cl.ClassName == className && 
                                                cl.Id != excludeId);
        }

        public async Task<bool> TeacherExistsAsync(string teacherName, int? excludeId = null)
        {
            return await _context.ClassLeaders
                                 .AnyAsync(cl => cl.TeacherName == teacherName && 
                                                cl.Id != excludeId);
        }
    }
}
