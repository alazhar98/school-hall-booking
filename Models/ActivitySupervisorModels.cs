using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class Activity
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public List<ActivitySupervisor> Supervisors { get; set; } = new();
    }

    public class ActivitySupervisor
    {
        public int Id { get; set; }
        
        public int ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;
        
        [Required]
        [StringLength(100)]
        public string TeacherName { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string? TeacherId { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
