using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string EmployeeId { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
        
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
