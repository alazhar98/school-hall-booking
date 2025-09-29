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
    }
}


