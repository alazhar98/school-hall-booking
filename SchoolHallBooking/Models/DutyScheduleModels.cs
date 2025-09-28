using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class DutyScheduleItem
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Day { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Column { get; set; } = string.Empty;
        
        public int Row { get; set; }
        
        [MaxLength(500)]
        public string TeacherNames { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}

