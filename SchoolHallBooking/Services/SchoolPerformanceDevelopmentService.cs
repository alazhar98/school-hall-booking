using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class SchoolPerformanceDevelopmentService : ISchoolPerformanceDevelopmentService
    {
        private readonly BookingDbContext _context;

        public SchoolPerformanceDevelopmentService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<List<SupervisoryVisitAnalysis>> GetVisitAnalysesBySubjectAsync(string subject)
        {
            return await _context.Set<SupervisoryVisitAnalysis>()
                .Where(x => x.Subject == subject)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public Task<SupervisoryVisitAnalysis?> GetVisitAnalysisAsync(int id)
        {
            return _context.Set<SupervisoryVisitAnalysis>().FindAsync(id).AsTask();
        }

        public async Task<SupervisoryVisitAnalysis> AddVisitAnalysisAsync(SupervisoryVisitAnalysis item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateVisitAnalysisAsync(SupervisoryVisitAnalysis item)
        {
            var existing = await _context.Set<SupervisoryVisitAnalysis>().FindAsync(item.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteVisitAnalysisAsync(int id)
        {
            var existing = await _context.Set<SupervisoryVisitAnalysis>().FindAsync(id);
            if (existing != null)
            {
                _context.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<StudentWorkAnalysis>> GetStudentWorkAnalysesBySubjectAsync(string subject)
        {
            return await _context.Set<StudentWorkAnalysis>()
                .Where(x => x.Subject == subject)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public Task<StudentWorkAnalysis?> GetStudentWorkAnalysisAsync(int id)
        {
            return _context.Set<StudentWorkAnalysis>().FindAsync(id).AsTask();
        }

        public async Task<StudentWorkAnalysis> AddStudentWorkAnalysisAsync(StudentWorkAnalysis item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateStudentWorkAnalysisAsync(StudentWorkAnalysis item)
        {
            var existing = await _context.Set<StudentWorkAnalysis>().FindAsync(item.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteStudentWorkAnalysisAsync(int id)
        {
            var existing = await _context.Set<StudentWorkAnalysis>().FindAsync(id);
            if (existing != null)
            {
                _context.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }
    }
}


