using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class ProfessionalDevelopmentService : IProfessionalDevelopmentService
    {
        private readonly BookingDbContext _context;

        public ProfessionalDevelopmentService(BookingDbContext context)
        {
            _context = context;
        }

        // Professional Development Programs
        public async Task<List<ProfessionalDevelopmentProgram>> GetAllProgramsAsync()
        {
            return await _context.ProfessionalDevelopmentPrograms
                                .Where(p => p.IsActive)
                                .OrderByDescending(p => p.Date)
                                .ThenBy(p => p.ProgramName)
                                .ToListAsync();
        }

        public async Task<ProfessionalDevelopmentProgram?> GetProgramByIdAsync(int id)
        {
            return await _context.ProfessionalDevelopmentPrograms.FindAsync(id);
        }

        public async Task AddProgramAsync(ProfessionalDevelopmentProgram program)
        {
            program.CreatedAt = DateTime.Now;
            program.IsActive = true;
            _context.ProfessionalDevelopmentPrograms.Add(program);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgramAsync(ProfessionalDevelopmentProgram program)
        {
            var existingProgram = await _context.ProfessionalDevelopmentPrograms.FindAsync(program.Id);
            if (existingProgram != null)
            {
                _context.Entry(existingProgram).CurrentValues.SetValues(program);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProgramAsync(int id)
        {
            var program = await _context.ProfessionalDevelopmentPrograms.FindAsync(id);
            if (program != null)
            {
                program.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        // Training Program Designs
        public async Task<List<TrainingProgramDesign>> GetAllDesignsAsync()
        {
            return await _context.TrainingProgramDesigns
                                .Where(d => d.IsActive)
                                .OrderByDescending(d => d.CreatedAt)
                                .ThenBy(d => d.ProgramName)
                                .ToListAsync();
        }

        public async Task<TrainingProgramDesign?> GetDesignByIdAsync(int id)
        {
            return await _context.TrainingProgramDesigns.FindAsync(id);
        }

        public async Task AddDesignAsync(TrainingProgramDesign design)
        {
            design.CreatedAt = DateTime.Now;
            design.IsActive = true;
            _context.TrainingProgramDesigns.Add(design);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDesignAsync(TrainingProgramDesign design)
        {
            var existingDesign = await _context.TrainingProgramDesigns.FindAsync(design.Id);
            if (existingDesign != null)
            {
                _context.Entry(existingDesign).CurrentValues.SetValues(design);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDesignAsync(int id)
        {
            var design = await _context.TrainingProgramDesigns.FindAsync(id);
            if (design != null)
            {
                design.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        // Final Evaluations
        public async Task<List<FinalEvaluation>> GetAllEvaluationsAsync()
        {
            return await _context.FinalEvaluations
                                .Where(e => e.IsActive)
                                .OrderByDescending(e => e.CreatedAt)
                                .ThenBy(e => e.ProgramTitle)
                                .ToListAsync();
        }

        public async Task<FinalEvaluation?> GetEvaluationByIdAsync(int id)
        {
            return await _context.FinalEvaluations.FindAsync(id);
        }

        public async Task AddEvaluationAsync(FinalEvaluation evaluation)
        {
            evaluation.CreatedAt = DateTime.Now;
            evaluation.IsActive = true;
            _context.FinalEvaluations.Add(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEvaluationAsync(FinalEvaluation evaluation)
        {
            var existingEvaluation = await _context.FinalEvaluations.FindAsync(evaluation.Id);
            if (existingEvaluation != null)
            {
                _context.Entry(existingEvaluation).CurrentValues.SetValues(evaluation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteEvaluationAsync(int id)
        {
            var evaluation = await _context.FinalEvaluations.FindAsync(id);
            if (evaluation != null)
            {
                evaluation.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        // Attendances
        public async Task<List<Attendance>> GetAllAttendancesAsync()
        {
            return await _context.Attendances
                                .Where(a => a.IsActive)
                                .OrderByDescending(a => a.Date)
                                .ThenBy(a => a.ProgramTitle)
                                .ToListAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            attendance.CreatedAt = DateTime.Now;
            attendance.IsActive = true;
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            var existingAttendance = await _context.Attendances.FindAsync(attendance.Id);
            if (existingAttendance != null)
            {
                _context.Entry(existingAttendance).CurrentValues.SetValues(attendance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                attendance.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        // Improvement Teams
        public async Task<List<ImprovementTeam>> GetAllTeamMembersAsync()
        {
            return await _context.ImprovementTeams
                                .Where(t => t.IsActive)
                                .OrderBy(t => t.Name)
                                .ToListAsync();
        }

        public async Task<ImprovementTeam?> GetTeamMemberByIdAsync(int id)
        {
            return await _context.ImprovementTeams.FindAsync(id);
        }

        public async Task AddTeamMemberAsync(ImprovementTeam teamMember)
        {
            teamMember.CreatedAt = DateTime.Now;
            teamMember.IsActive = true;
            _context.ImprovementTeams.Add(teamMember);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeamMemberAsync(ImprovementTeam teamMember)
        {
            var existingTeamMember = await _context.ImprovementTeams.FindAsync(teamMember.Id);
            if (existingTeamMember != null)
            {
                _context.Entry(existingTeamMember).CurrentValues.SetValues(teamMember);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTeamMemberAsync(int id)
        {
            var teamMember = await _context.ImprovementTeams.FindAsync(id);
            if (teamMember != null)
            {
                teamMember.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        // Follow Up Meetings
        public async Task<List<FollowUpMeeting>> GetAllMeetingsAsync()
        {
            return await _context.FollowUpMeetings
                                .Where(m => m.IsActive)
                                .OrderByDescending(m => m.Date)
                                .ThenBy(m => m.MeetingNumber)
                                .ToListAsync();
        }

        public async Task<FollowUpMeeting?> GetMeetingByIdAsync(int id)
        {
            return await _context.FollowUpMeetings.FindAsync(id);
        }

        public async Task AddMeetingAsync(FollowUpMeeting meeting)
        {
            meeting.CreatedAt = DateTime.Now;
            meeting.IsActive = true;
            _context.FollowUpMeetings.Add(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMeetingAsync(FollowUpMeeting meeting)
        {
            var existingMeeting = await _context.FollowUpMeetings.FindAsync(meeting.Id);
            if (existingMeeting != null)
            {
                _context.Entry(existingMeeting).CurrentValues.SetValues(meeting);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMeetingAsync(int id)
        {
            var meeting = await _context.FollowUpMeetings.FindAsync(id);
            if (meeting != null)
            {
                meeting.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();
            }
        }

        // Validation
        public async Task<bool> ProgramExistsAsync(string programName, string subject, DateTime date, int? excludeId = null)
        {
            return await _context.ProfessionalDevelopmentPrograms
                                .AnyAsync(p => p.ProgramName == programName &&
                                               p.Subject == subject &&
                                               p.Date.Date == date.Date &&
                                               p.IsActive &&
                                               p.Id != excludeId);
        }

        public async Task<bool> DesignExistsAsync(string programName, string field, int? excludeId = null)
        {
            return await _context.TrainingProgramDesigns
                                .AnyAsync(d => d.ProgramName == programName &&
                                               d.Field == field &&
                                               d.IsActive &&
                                               d.Id != excludeId);
        }

        public async Task<bool> EvaluationExistsAsync(string programTitle, string subject, int? excludeId = null)
        {
            return await _context.FinalEvaluations
                                .AnyAsync(e => e.ProgramTitle == programTitle &&
                                               e.Subject == subject &&
                                               e.IsActive &&
                                               e.Id != excludeId);
        }

        public async Task<bool> AttendanceExistsAsync(string subject, string programTitle, DateTime date, int? excludeId = null)
        {
            return await _context.Attendances
                                .AnyAsync(a => a.Subject == subject &&
                                               a.ProgramTitle == programTitle &&
                                               a.Date.Date == date.Date &&
                                               a.IsActive &&
                                               a.Id != excludeId);
        }

        public async Task<bool> TeamMemberExistsAsync(string name, string jobTitle, int? excludeId = null)
        {
            return await _context.ImprovementTeams
                                .AnyAsync(t => t.Name == name &&
                                               t.JobTitle == jobTitle &&
                                               t.IsActive &&
                                               t.Id != excludeId);
        }

        public async Task<bool> MeetingExistsAsync(string meetingNumber, DateTime date, int? excludeId = null)
        {
            return await _context.FollowUpMeetings
                                .AnyAsync(m => m.MeetingNumber == meetingNumber &&
                                               m.Date.Date == date.Date &&
                                               m.IsActive &&
                                               m.Id != excludeId);
        }
    }
}
