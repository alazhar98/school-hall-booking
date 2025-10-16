using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IAcademicAchievementService
    {
        // Plans
        Task<List<AcademicAchievementPlan>> GetPlansBySubjectAsync(string subject);
        Task AddPlanAsync(AcademicAchievementPlan plan);
        Task UpdatePlanAsync(AcademicAchievementPlan plan);
        Task DeletePlanAsync(int id);

        // Initiatives
        Task<List<AcademicAchievementInitiative>> GetInitiativesBySubjectAsync(string subject);
        Task AddInitiativeAsync(AcademicAchievementInitiative initiative);
        Task UpdateInitiativeAsync(AcademicAchievementInitiative initiative);
        Task DeleteInitiativeAsync(int id);

        // School Efforts
        Task<List<AcademicAchievementSchoolEffort>> GetSchoolEffortsBySubjectAsync(string subject);
        Task AddSchoolEffortAsync(AcademicAchievementSchoolEffort effort);
        Task UpdateSchoolEffortAsync(AcademicAchievementSchoolEffort effort);
        Task DeleteSchoolEffortAsync(int id);

        // Improvement Team
        Task<List<AcademicAchievementImprovementTeam>> GetImprovementTeamMembersAsync();
        Task AddImprovementTeamMemberAsync(AcademicAchievementImprovementTeam member);
        Task UpdateImprovementTeamMemberAsync(AcademicAchievementImprovementTeam member);
        Task DeleteImprovementTeamMemberAsync(int id);

        // Follow-up Meetings
        Task<List<AcademicAchievementFollowupMeeting>> GetFollowupMeetingsAsync();
        Task AddFollowupMeetingAsync(AcademicAchievementFollowupMeeting meeting);
        Task UpdateFollowupMeetingAsync(AcademicAchievementFollowupMeeting meeting);
        Task DeleteFollowupMeetingAsync(int id);
    }
}
