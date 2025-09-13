using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models;

public class Hall
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
    public int Capacity { get; set; }
    
    [StringLength(200)]
    public string? Location { get; set; }
    
    // Navigation property
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
