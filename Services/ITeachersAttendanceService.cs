using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface ITeachersAttendanceService
    {
        Task<List<TeacherWorkshopRecordEntity>> GetWorkshopsAsync();
        Task<TeacherWorkshopRecordEntity> AddWorkshopAsync(TeacherWorkshopRecordEntity entity);
        Task<TeacherWorkshopRecordEntity?> UpdateWorkshopAsync(TeacherWorkshopRecordEntity entity);
        Task<bool> DeleteWorkshopAsync(int id);

        Task<List<TeacherLeaveRequestEntity>> GetLeavesAsync();
        Task<TeacherLeaveRequestEntity> AddLeaveAsync(TeacherLeaveRequestEntity entity);
        Task<TeacherLeaveRequestEntity?> UpdateLeaveAsync(TeacherLeaveRequestEntity entity);
        Task<bool> DeleteLeaveAsync(int id);
    }
}


