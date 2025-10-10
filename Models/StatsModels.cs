using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public enum StaffRole
    {
        Administrative = 1,
        Support = 2,
        Teaching = 3,
        DailyWageTeachers = 4,
        Workers = 5,
        Guards = 6,
        SchoolBusDrivers = 7
    }

    public class StaffStatistic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public StaffRole Role { get; set; }

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class RegularStudentStatistic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Division { get; set; } = string.Empty; // الشعبة

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class HearingImpairedStudentStatistic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Grade { get; set; } = string.Empty; // الصف

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}



