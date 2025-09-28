using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class SupervisoryVisitService : ISupervisoryVisitService
    {
        private readonly BookingDbContext _context;

        public SupervisoryVisitService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupervisoryVisit>> GetAllVisitsAsync()
        {
            return await _context.SupervisoryVisits
                                .Where(v => v.IsActive)
                                .OrderByDescending(v => v.Date)
                                .ThenBy(v => v.VisitorTeacherName)
                                .ToListAsync();
        }

        public async Task<SupervisoryVisit?> GetVisitByIdAsync(int id)
        {
            return await _context.SupervisoryVisits
                                .FirstOrDefaultAsync(v => v.Id == id && v.IsActive);
        }

        public async Task AddVisitAsync(SupervisoryVisit visit)
        {
            visit.CreatedAt = DateTime.Now;
            _context.SupervisoryVisits.Add(visit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVisitAsync(SupervisoryVisit visit)
        {
            var existingVisit = await _context.SupervisoryVisits.FindAsync(visit.Id);
            if (existingVisit != null)
            {
                existingVisit.VisitorTeacherName = visit.VisitorTeacherName;
                existingVisit.VisitedTeacherName = visit.VisitedTeacherName;
                existingVisit.Day = visit.Day;
                existingVisit.Date = visit.Date;
                existingVisit.LessonTitle = visit.LessonTitle;
                existingVisit.Notes = visit.Notes;
                existingVisit.Subject = visit.Subject;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteVisitAsync(int id)
        {
            var visit = await _context.SupervisoryVisits.FindAsync(id);
            if (visit != null)
            {
                visit.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> VisitExistsAsync(string visitorTeacher, string visitedTeacher, DateTime date, int? excludeId = null)
        {
            return await _context.SupervisoryVisits
                                .AnyAsync(v => v.VisitorTeacherName == visitorTeacher &&
                                             v.VisitedTeacherName == visitedTeacher &&
                                             v.Date.Date == date.Date &&
                                             v.IsActive &&
                                             (excludeId == null || v.Id != excludeId));
        }
    }
}
