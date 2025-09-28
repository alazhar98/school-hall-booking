using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface ISupervisoryVisitService
    {
        Task<List<SupervisoryVisit>> GetAllVisitsAsync();
        Task<SupervisoryVisit?> GetVisitByIdAsync(int id);
        Task AddVisitAsync(SupervisoryVisit visit);
        Task UpdateVisitAsync(SupervisoryVisit visit);
        Task DeleteVisitAsync(int id);
        Task<bool> VisitExistsAsync(string visitorTeacher, string visitedTeacher, DateTime date, int? excludeId = null);
    }
}
