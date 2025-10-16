using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class PlanArea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المجال مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون اسم المجال أقل من 100 حرف")]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<PlanObjective> Objectives { get; set; } = new List<PlanObjective>();
    }

    public class PlanObjective
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الهدف مطلوب")]
        [StringLength(500, ErrorMessage = "يجب أن يكون الهدف أقل من 500 حرف")]
        public string Objective { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<PlanSubObjective> SubObjectives { get; set; } = new List<PlanSubObjective>();
    }

    public class PlanSubObjective
    {
        public int Id { get; set; }
        public int? PlanObjectiveId { get; set; }

        [Required(ErrorMessage = "المجال مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون اسم المجال أقل من 100 حرف")]
        public string Area { get; set; } = string.Empty;

        [Required(ErrorMessage = "الهدف الإجرائي مطلوب")]
        [StringLength(500, ErrorMessage = "يجب أن يكون الهدف الإجرائي أقل من 500 حرف")]
        public string SubObjective { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PlanObjective? PlanObjective { get; set; }
        public ICollection<PlanAction> Actions { get; set; } = new List<PlanAction>();
    }

    public class PlanAction
    {
        public int Id { get; set; }
        public int PlanSubObjectiveId { get; set; }

        [Required(ErrorMessage = "الإجراء مطلوب")]
        [StringLength(500, ErrorMessage = "يجب أن يكون الإجراء أقل من 500 حرف")]
        public string Action { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "يجب أن تكون الفترة الزمنية أقل من 100 حرف")]
        public string? TimePeriod { get; set; }

        [StringLength(100, ErrorMessage = "يجب أن يكون المنفذ أقل من 100 حرف")]
        public string? Executor { get; set; }

        public bool IsExecuted { get; set; } = false;

        [StringLength(500, ErrorMessage = "يجب أن تكون الملاحظات أقل من 500 حرف")]
        public string? Notes { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PlanSubObjective? PlanSubObjective { get; set; }
    }
}
