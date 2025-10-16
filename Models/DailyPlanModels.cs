using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class DailyPlan
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "الشهر مطلوب")]
        public string Month { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "اليوم مطلوب")]
        public int Day { get; set; }
        
        [Required(ErrorMessage = "الإجراء مطلوب")]
        [StringLength(500, ErrorMessage = "يجب أن يكون الإجراء أقل من 500 حرف")]
        public string Action { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "المنفذ مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون اسم المنفذ أقل من 100 حرف")]
        public string Executor { get; set; } = string.Empty;
        
        public bool IsExecuted { get; set; } = false;
        
        [StringLength(500, ErrorMessage = "يجب أن يكون السبب أقل من 500 حرف")]
        public string? ReasonForNonExecution { get; set; }
        
        [StringLength(500, ErrorMessage = "يجب أن يكون الإجراء المتبع أقل من 500 حرف")]
        public string? ActionTaken { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
