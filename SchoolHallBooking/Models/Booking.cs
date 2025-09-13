using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolHallBooking.Models;

public class Booking
{
    public int Id { get; set; }
    
    [Required]
    public int HallId { get; set; }
    
    [Required]
    [Column(TypeName = "date")]
    public DateTime BookingDate { get; set; }
    
    [Required]
    [StringLength(100)]
    public string TeacherName { get; set; } = string.Empty;
    
    [Required]
    [Range(1, 8)]
    public int Period { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation property
    public virtual Hall Hall { get; set; } = null!;
}
