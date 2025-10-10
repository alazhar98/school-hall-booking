using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IClassLeaderService
    {
        Task<List<ClassLeader>> GetAllClassLeadersAsync();
        Task<ClassLeader?> GetClassLeaderByIdAsync(int id);
        Task AddClassLeaderAsync(ClassLeader classLeader);
        Task UpdateClassLeaderAsync(ClassLeader classLeader);
        Task DeleteClassLeaderAsync(int id);
        Task<bool> ClassLeaderExistsAsync(string className, int? excludeId = null);
        Task<bool> TeacherExistsAsync(string teacherName, int? excludeId = null);
    }
}
