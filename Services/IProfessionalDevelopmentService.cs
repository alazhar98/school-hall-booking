using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IProfessionalDevelopmentService
    {
        // Professional Development Programs
        Task<List<ProfessionalDevelopmentProgram>> GetAllProgramsAsync();
        Task<ProfessionalDevelopmentProgram?> GetProgramByIdAsync(int id);
        Task AddProgramAsync(ProfessionalDevelopmentProgram program);
        Task UpdateProgramAsync(ProfessionalDevelopmentProgram program);
        Task DeleteProgramAsync(int id);

        // Training Program Designs
        Task<List<TrainingProgramDesign>> GetAllDesignsAsync();
        Task<TrainingProgramDesign?> GetDesignByIdAsync(int id);
        Task AddDesignAsync(TrainingProgramDesign design);
        Task UpdateDesignAsync(TrainingProgramDesign design);
        Task DeleteDesignAsync(int id);

        // Final Evaluations
        Task<List<FinalEvaluation>> GetAllEvaluationsAsync();
        Task<FinalEvaluation?> GetEvaluationByIdAsync(int id);
        Task AddEvaluationAsync(FinalEvaluation evaluation);
        Task UpdateEvaluationAsync(FinalEvaluation evaluation);
        Task DeleteEvaluationAsync(int id);

        // Attendances
        Task<List<Attendance>> GetAllAttendancesAsync();
        Task<Attendance?> GetAttendanceByIdAsync(int id);
        Task AddAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);

        // Attendance Records
        Task<List<AttendanceRecord>> GetAttendanceRecordsByAttendanceIdAsync(int attendanceId);
        Task<AttendanceRecord?> GetAttendanceRecordByIdAsync(int id);
        Task AddAttendanceRecordAsync(AttendanceRecord attendanceRecord);
        Task UpdateAttendanceRecordAsync(AttendanceRecord attendanceRecord);
        Task DeleteAttendanceRecordAsync(int id);

        // Improvement Teams
        Task<List<ImprovementTeam>> GetAllTeamMembersAsync();
        Task<ImprovementTeam?> GetTeamMemberByIdAsync(int id);
        Task AddTeamMemberAsync(ImprovementTeam teamMember);
        Task UpdateTeamMemberAsync(ImprovementTeam teamMember);
        Task DeleteTeamMemberAsync(int id);

        // Follow Up Meetings
        Task<List<FollowUpMeeting>> GetAllMeetingsAsync();
        Task<FollowUpMeeting?> GetMeetingByIdAsync(int id);
        Task AddMeetingAsync(FollowUpMeeting meeting);
        Task UpdateMeetingAsync(FollowUpMeeting meeting);
        Task DeleteMeetingAsync(int id);

        // Validation
        Task<bool> ProgramExistsAsync(string programName, string subject, DateTime date, int? excludeId = null);
        Task<bool> DesignExistsAsync(string programName, string field, int? excludeId = null);
        Task<bool> EvaluationExistsAsync(string programTitle, string subject, int? excludeId = null);
        Task<bool> AttendanceExistsAsync(string subject, string programTitle, DateTime date, int? excludeId = null);
        Task<bool> TeamMemberExistsAsync(string name, string jobTitle, int? excludeId = null);
        Task<bool> MeetingExistsAsync(string meetingNumber, DateTime date, int? excludeId = null);
    }
}
