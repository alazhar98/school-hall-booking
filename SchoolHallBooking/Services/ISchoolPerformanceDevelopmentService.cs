using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface ISchoolPerformanceDevelopmentService
    {
        // SupervisoryVisitAnalysis
        Task<List<SupervisoryVisitAnalysis>> GetVisitAnalysesBySubjectAsync(string subject);
        Task<SupervisoryVisitAnalysis?> GetVisitAnalysisAsync(int id);
        Task<SupervisoryVisitAnalysis> AddVisitAnalysisAsync(SupervisoryVisitAnalysis item);
        Task UpdateVisitAnalysisAsync(SupervisoryVisitAnalysis item);
        Task DeleteVisitAnalysisAsync(int id);

        // StudentWorkAnalysis
        Task<List<StudentWorkAnalysis>> GetStudentWorkAnalysesBySubjectAsync(string subject);
        Task<StudentWorkAnalysis?> GetStudentWorkAnalysisAsync(int id);
        Task<StudentWorkAnalysis> AddStudentWorkAnalysisAsync(StudentWorkAnalysis item);
        Task UpdateStudentWorkAnalysisAsync(StudentWorkAnalysis item);
        Task DeleteStudentWorkAnalysisAsync(int id);

        // Admin jobs visit analyses (slide 6)
        Task<List<AdminJobVisitAnalysis>> GetAdminJobVisitsAsync();
        Task<AdminJobVisitAnalysis?> GetAdminJobVisitAsync(int id);
        Task<AdminJobVisitAnalysis> AddAdminJobVisitAsync(AdminJobVisitAnalysis item);
        Task UpdateAdminJobVisitAsync(AdminJobVisitAnalysis item);
        Task DeleteAdminJobVisitAsync(int id);

        // Opinions slides (7/8/9)
        Task<List<StudentOpinionAnalysis>> GetStudentOpinionsAsync();
        Task<StudentOpinionAnalysis> AddStudentOpinionAsync(StudentOpinionAnalysis item);
        Task UpdateStudentOpinionAsync(StudentOpinionAnalysis item);
        Task DeleteStudentOpinionAsync(int id);

        Task<List<StaffOpinionAnalysis>> GetStaffOpinionsAsync();
        Task<StaffOpinionAnalysis> AddStaffOpinionAsync(StaffOpinionAnalysis item);
        Task UpdateStaffOpinionAsync(StaffOpinionAnalysis item);
        Task DeleteStaffOpinionAsync(int id);

        Task<List<ParentsOpinionAnalysis>> GetParentsOpinionsAsync();
        Task<ParentsOpinionAnalysis> AddParentsOpinionAsync(ParentsOpinionAnalysis item);
        Task UpdateParentsOpinionAsync(ParentsOpinionAnalysis item);
        Task DeleteParentsOpinionAsync(int id);

        // Slide 10-13 (under slide 1)
        Task<List<SPDImprovementTeamMember>> GetImprovementTeamAsync(string subject);
        Task<SPDImprovementTeamMember> AddImprovementTeamMemberAsync(SPDImprovementTeamMember item);
        Task UpdateImprovementTeamMemberAsync(SPDImprovementTeamMember item);
        Task DeleteImprovementTeamMemberAsync(int id);

        Task<List<SPDFollowupMeeting>> GetFollowupMeetingsAsync(string subject);
        Task<SPDFollowupMeeting> AddFollowupMeetingAsync(SPDFollowupMeeting item);
        Task UpdateFollowupMeetingAsync(SPDFollowupMeeting item);
        Task DeleteFollowupMeetingAsync(int id);

        Task<List<SPDDirectiveRecord>> GetDirectiveRecordsAsync(string subject);
        Task<SPDDirectiveRecord> AddDirectiveRecordAsync(SPDDirectiveRecord item);
        Task UpdateDirectiveRecordAsync(SPDDirectiveRecord item);
        Task DeleteDirectiveRecordAsync(int id);

        Task<List<SPDVisitRecord>> GetSPDVisitRecordsAsync(string subject);
        Task<SPDVisitRecord> AddSPDVisitRecordAsync(SPDVisitRecord item);
        Task UpdateSPDVisitRecordAsync(SPDVisitRecord item);
        Task DeleteSPDVisitRecordAsync(int id);
    }
}


