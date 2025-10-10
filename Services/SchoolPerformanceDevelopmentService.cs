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

        public Task<List<AdminJobVisitAnalysis>> GetAdminJobVisitsAsync()
        {
            return _context.Set<AdminJobVisitAnalysis>()
                .OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public Task<AdminJobVisitAnalysis?> GetAdminJobVisitAsync(int id)
        {
            return _context.Set<AdminJobVisitAnalysis>().FindAsync(id).AsTask();
        }

        public async Task<AdminJobVisitAnalysis> AddAdminJobVisitAsync(AdminJobVisitAnalysis item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAdminJobVisitAsync(AdminJobVisitAnalysis item)
        {
            var existing = await _context.Set<AdminJobVisitAnalysis>().FindAsync(item.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAdminJobVisitAsync(int id)
        {
            var existing = await _context.Set<AdminJobVisitAnalysis>().FindAsync(id);
            if (existing != null)
            {
                _context.Remove(existing);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<StudentOpinionAnalysis>> GetStudentOpinionsAsync()
            => _context.Set<StudentOpinionAnalysis>().OrderByDescending(x => x.CreatedAt).ToListAsync();
        public async Task<StudentOpinionAnalysis> AddStudentOpinionAsync(StudentOpinionAnalysis item)
        { _context.Add(item); await _context.SaveChangesAsync(); return item; }
        public async Task UpdateStudentOpinionAsync(StudentOpinionAnalysis item)
        { var e = await _context.Set<StudentOpinionAnalysis>().FindAsync(item.Id); if (e!=null){ _context.Entry(e).CurrentValues.SetValues(item); await _context.SaveChangesAsync(); } }
        public async Task DeleteStudentOpinionAsync(int id)
        { var e = await _context.Set<StudentOpinionAnalysis>().FindAsync(id); if (e!=null){ _context.Remove(e); await _context.SaveChangesAsync(); } }

        public Task<List<StaffOpinionAnalysis>> GetStaffOpinionsAsync()
            => _context.Set<StaffOpinionAnalysis>().OrderByDescending(x => x.CreatedAt).ToListAsync();
        public async Task<StaffOpinionAnalysis> AddStaffOpinionAsync(StaffOpinionAnalysis item)
        { _context.Add(item); await _context.SaveChangesAsync(); return item; }
        public async Task UpdateStaffOpinionAsync(StaffOpinionAnalysis item)
        { var e = await _context.Set<StaffOpinionAnalysis>().FindAsync(item.Id); if (e!=null){ _context.Entry(e).CurrentValues.SetValues(item); await _context.SaveChangesAsync(); } }
        public async Task DeleteStaffOpinionAsync(int id)
        { var e = await _context.Set<StaffOpinionAnalysis>().FindAsync(id); if (e!=null){ _context.Remove(e); await _context.SaveChangesAsync(); } }

        public Task<List<ParentsOpinionAnalysis>> GetParentsOpinionsAsync()
            => _context.Set<ParentsOpinionAnalysis>().OrderByDescending(x => x.CreatedAt).ToListAsync();
        public async Task<ParentsOpinionAnalysis> AddParentsOpinionAsync(ParentsOpinionAnalysis item)
        { _context.Add(item); await _context.SaveChangesAsync(); return item; }
        public async Task UpdateParentsOpinionAsync(ParentsOpinionAnalysis item)
        { var e = await _context.Set<ParentsOpinionAnalysis>().FindAsync(item.Id); if (e!=null){ _context.Entry(e).CurrentValues.SetValues(item); await _context.SaveChangesAsync(); } }
        public async Task DeleteParentsOpinionAsync(int id)
        { var e = await _context.Set<ParentsOpinionAnalysis>().FindAsync(id); if (e!=null){ _context.Remove(e); await _context.SaveChangesAsync(); } }

        public Task<List<SPDImprovementTeamMember>> GetImprovementTeamAsync(string subject)
            => _context.Set<SPDImprovementTeamMember>().Where(x=>x.Subject==subject).OrderByDescending(x=>x.CreatedAt).ToListAsync();
        public async Task<SPDImprovementTeamMember> AddImprovementTeamMemberAsync(SPDImprovementTeamMember item)
        { _context.Add(item); await _context.SaveChangesAsync(); return item; }
        public async Task UpdateImprovementTeamMemberAsync(SPDImprovementTeamMember item)
        { var e = await _context.Set<SPDImprovementTeamMember>().FindAsync(item.Id); if (e!=null){ _context.Entry(e).CurrentValues.SetValues(item); await _context.SaveChangesAsync(); } }
        public async Task DeleteImprovementTeamMemberAsync(int id)
        { var e = await _context.Set<SPDImprovementTeamMember>().FindAsync(id); if (e!=null){ _context.Remove(e); await _context.SaveChangesAsync(); } }

        public Task<List<SPDFollowupMeeting>> GetFollowupMeetingsAsync(string subject)
            => _context.Set<SPDFollowupMeeting>().Where(x=>x.Subject==subject).OrderByDescending(x=>x.MeetingDate).ToListAsync();
        public async Task<SPDFollowupMeeting> AddFollowupMeetingAsync(SPDFollowupMeeting item)
        { _context.Add(item); await _context.SaveChangesAsync(); return item; }
        public async Task UpdateFollowupMeetingAsync(SPDFollowupMeeting item)
        { var e = await _context.Set<SPDFollowupMeeting>().FindAsync(item.Id); if (e!=null){ _context.Entry(e).CurrentValues.SetValues(item); await _context.SaveChangesAsync(); } }
        public async Task DeleteFollowupMeetingAsync(int id)
        { var e = await _context.Set<SPDFollowupMeeting>().FindAsync(id); if (e!=null){ _context.Remove(e); await _context.SaveChangesAsync(); } }

        public Task<List<SPDDirectiveRecord>> GetDirectiveRecordsAsync(string subject)
            => _context.Set<SPDDirectiveRecord>().Where(x=>x.Subject==subject).OrderByDescending(x=>x.DirectiveDate).ToListAsync();
        public async Task<SPDDirectiveRecord> AddDirectiveRecordAsync(SPDDirectiveRecord item)
        { _context.Add(item); await _context.SaveChangesAsync(); return item; }
        public async Task UpdateDirectiveRecordAsync(SPDDirectiveRecord item)
        { var e = await _context.Set<SPDDirectiveRecord>().FindAsync(item.Id); if (e!=null){ _context.Entry(e).CurrentValues.SetValues(item); await _context.SaveChangesAsync(); } }
        public async Task DeleteDirectiveRecordAsync(int id)
        { var e = await _context.Set<SPDDirectiveRecord>().FindAsync(id); if (e!=null){ _context.Remove(e); await _context.SaveChangesAsync(); } }

        public Task<List<SPDVisitRecord>> GetSPDVisitRecordsAsync(string subject)
            => _context.Set<SPDVisitRecord>().Where(x=>x.Subject==subject).OrderByDescending(x=>x.VisitDate).ToListAsync();
        public async Task<SPDVisitRecord> AddSPDVisitRecordAsync(SPDVisitRecord item)
        { _context.Add(item); await _context.SaveChangesAsync(); return item; }
        public async Task UpdateSPDVisitRecordAsync(SPDVisitRecord item)
        { var e = await _context.Set<SPDVisitRecord>().FindAsync(item.Id); if (e!=null){ _context.Entry(e).CurrentValues.SetValues(item); await _context.SaveChangesAsync(); } }
        public async Task DeleteSPDVisitRecordAsync(int id)
        { var e = await _context.Set<SPDVisitRecord>().FindAsync(id); if (e!=null){ _context.Remove(e); await _context.SaveChangesAsync(); } }
    }
}


