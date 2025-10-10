using System;

namespace SchoolHallBooking.Models
{
    public class TeacherWorkshopRecordEntity
    {
        public int Id { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string TrainingProgram { get; set; } = string.Empty;
        public string TimePeriod { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class TeacherLeaveRequestEntity
    {
        public int Id { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public DateTime LeaveDate { get; set; } = DateTime.UtcNow.Date;
        public string Reason { get; set; } = string.Empty;
        // مصفوفة التوزيع بشكل JSON (5 أيام × 8 حصص)
        public string DistributionJson { get; set; } = "";
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}


