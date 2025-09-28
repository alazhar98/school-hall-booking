using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class ClassLeader
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الصف مطلوب")]
        [StringLength(50, ErrorMessage = "يجب أن يكون اسم الصف أقل من 50 حرف")]
        public string ClassName { get; set; } = string.Empty;

        [Required(ErrorMessage = "اسم المعلم مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون اسم المعلم أقل من 100 حرف")]
        public string TeacherName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
