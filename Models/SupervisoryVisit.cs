using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class SupervisoryVisit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المعلم الزائر مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون اسم المعلم الزائر أقل من 100 حرف")]
        public string VisitorTeacherName { get; set; } = string.Empty;

        [Required(ErrorMessage = "اسم المعلم المزار مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون اسم المعلم المزار أقل من 100 حرف")]
        public string VisitedTeacherName { get; set; } = string.Empty;

        [Required(ErrorMessage = "اليوم مطلوب")]
        [StringLength(20, ErrorMessage = "يجب أن يكون اليوم أقل من 20 حرف")]
        public string Day { get; set; } = string.Empty;

        [Required(ErrorMessage = "التاريخ مطلوب")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "عنوان الدرس مطلوب")]
        [StringLength(200, ErrorMessage = "يجب أن يكون عنوان الدرس أقل من 200 حرف")]
        public string LessonTitle { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "يجب أن تكون الملاحظات أقل من 500 حرف")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة")]
        [StringLength(50, ErrorMessage = "يجب أن تكون المادة أقل من 50 حرف")]
        public string Subject { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
