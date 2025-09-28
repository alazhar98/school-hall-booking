using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public class AcademicAchievementService : IAcademicAchievementService
    {
        private readonly BookingDbContext _context;

        public AcademicAchievementService(BookingDbContext context)
        {
            _context = context;
        }

        // Plans
        public async Task<List<AcademicAchievementPlan>> GetPlansBySubjectAsync(string subject)
        {
            return await _context.AcademicAchievementPlans
                .Where(p => p.Subject == subject)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task AddPlanAsync(AcademicAchievementPlan plan)
        {
            _context.AcademicAchievementPlans.Add(plan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlanAsync(AcademicAchievementPlan plan)
        {
            var existingPlan = await _context.AcademicAchievementPlans.FindAsync(plan.Id);
            if (existingPlan != null)
            {
                _context.Entry(existingPlan).CurrentValues.SetValues(plan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlanAsync(int id)
        {
            var plan = await _context.AcademicAchievementPlans.FindAsync(id);
            if (plan != null)
            {
                _context.AcademicAchievementPlans.Remove(plan);
                await _context.SaveChangesAsync();
            }
        }

        // Initiatives
        public async Task<List<AcademicAchievementInitiative>> GetInitiativesBySubjectAsync(string subject)
        {
            return await _context.AcademicAchievementInitiatives
                .Where(i => i.Subject == subject)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }

        public async Task AddInitiativeAsync(AcademicAchievementInitiative initiative)
        {
            _context.AcademicAchievementInitiatives.Add(initiative);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInitiativeAsync(AcademicAchievementInitiative initiative)
        {
            var existingInitiative = await _context.AcademicAchievementInitiatives.FindAsync(initiative.Id);
            if (existingInitiative != null)
            {
                _context.Entry(existingInitiative).CurrentValues.SetValues(initiative);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteInitiativeAsync(int id)
        {
            var initiative = await _context.AcademicAchievementInitiatives.FindAsync(id);
            if (initiative != null)
            {
                _context.AcademicAchievementInitiatives.Remove(initiative);
                await _context.SaveChangesAsync();
            }
        }

        // School Efforts
        public async Task<List<AcademicAchievementSchoolEffort>> GetSchoolEffortsBySubjectAsync(string subject)
        {
            return await _context.AcademicAchievementSchoolEfforts
                .Where(e => e.Subject == subject)
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();
        }

        public async Task AddSchoolEffortAsync(AcademicAchievementSchoolEffort effort)
        {
            _context.AcademicAchievementSchoolEfforts.Add(effort);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSchoolEffortAsync(AcademicAchievementSchoolEffort effort)
        {
            var existingEffort = await _context.AcademicAchievementSchoolEfforts.FindAsync(effort.Id);
            if (existingEffort != null)
            {
                _context.Entry(existingEffort).CurrentValues.SetValues(effort);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSchoolEffortAsync(int id)
        {
            var effort = await _context.AcademicAchievementSchoolEfforts.FindAsync(id);
            if (effort != null)
            {
                _context.AcademicAchievementSchoolEfforts.Remove(effort);
                await _context.SaveChangesAsync();
            }
        }

        // Improvement Team
        public async Task<List<AcademicAchievementImprovementTeam>> GetImprovementTeamMembersAsync()
        {
            return await _context.AcademicAchievementImprovementTeams
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task AddImprovementTeamMemberAsync(AcademicAchievementImprovementTeam member)
        {
            _context.AcademicAchievementImprovementTeams.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateImprovementTeamMemberAsync(AcademicAchievementImprovementTeam member)
        {
            var existingMember = await _context.AcademicAchievementImprovementTeams.FindAsync(member.Id);
            if (existingMember != null)
            {
                _context.Entry(existingMember).CurrentValues.SetValues(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteImprovementTeamMemberAsync(int id)
        {
            var member = await _context.AcademicAchievementImprovementTeams.FindAsync(id);
            if (member != null)
            {
                _context.AcademicAchievementImprovementTeams.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        // Follow-up Meetings
        public async Task<List<AcademicAchievementFollowupMeeting>> GetFollowupMeetingsAsync()
        {
            return await _context.AcademicAchievementFollowupMeetings
                .OrderByDescending(m => m.Date)
                .ThenBy(m => m.MeetingNumber)
                .ToListAsync();
        }

        public async Task AddFollowupMeetingAsync(AcademicAchievementFollowupMeeting meeting)
        {
            _context.AcademicAchievementFollowupMeetings.Add(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFollowupMeetingAsync(AcademicAchievementFollowupMeeting meeting)
        {
            var existingMeeting = await _context.AcademicAchievementFollowupMeetings.FindAsync(meeting.Id);
            if (existingMeeting != null)
            {
                _context.Entry(existingMeeting).CurrentValues.SetValues(meeting);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteFollowupMeetingAsync(int id)
        {
            var meeting = await _context.AcademicAchievementFollowupMeetings.FindAsync(id);
            if (meeting != null)
            {
                _context.AcademicAchievementFollowupMeetings.Remove(meeting);
                await _context.SaveChangesAsync();
            }
        }
    }
}
