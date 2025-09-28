using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IStatsService
    {
        // Staff
        Task<List<StaffStatistic>> GetStaffAsync();
        Task<StaffStatistic?> GetStaffByIdAsync(int id);
        Task<StaffStatistic> AddStaffAsync(StaffStatistic item);
        Task UpdateStaffAsync(StaffStatistic item);
        Task DeleteStaffAsync(int id);
        Task UpsertStaffBulkAsync(List<StaffStatistic> items);

        // Regular students
        Task<List<RegularStudentStatistic>> GetRegularStudentsAsync();
        Task<RegularStudentStatistic?> GetRegularStudentByIdAsync(int id);
        Task<RegularStudentStatistic> AddRegularStudentAsync(RegularStudentStatistic item);
        Task UpdateRegularStudentAsync(RegularStudentStatistic item);
        Task DeleteRegularStudentAsync(int id);

        // Hearing impaired students
        Task<List<HearingImpairedStudentStatistic>> GetHearingImpairedAsync();
        Task<HearingImpairedStudentStatistic?> GetHearingImpairedByIdAsync(int id);
        Task<HearingImpairedStudentStatistic> AddHearingImpairedAsync(HearingImpairedStudentStatistic item);
        Task UpdateHearingImpairedAsync(HearingImpairedStudentStatistic item);
        Task DeleteHearingImpairedAsync(int id);
    }
}


