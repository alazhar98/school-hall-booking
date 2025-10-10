using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    // نموذج برنامج الانماء المهني
    public class ProfessionalDevelopmentProgram
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نوع البرنامج مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون نوع البرنامج أقل من 100 حرف")]
        public string ProgramType { get; set; } = string.Empty;

        [Required(ErrorMessage = "اسم البرنامج مطلوب")]
        [StringLength(200, ErrorMessage = "يجب أن يكون اسم البرنامج أقل من 200 حرف")]
        public string ProgramName { get; set; } = string.Empty;

        [Required(ErrorMessage = "المادة مطلوبة")]
        [StringLength(100, ErrorMessage = "يجب أن تكون المادة أقل من 100 حرف")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "التاريخ مطلوب")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "المنفذ مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون المنفذ أقل من 100 حرف")]
        public string Executor { get; set; } = string.Empty;

        [Required(ErrorMessage = "مكان التنفيذ مطلوب")]
        [StringLength(200, ErrorMessage = "يجب أن يكون مكان التنفيذ أقل من 200 حرف")]
        public string ExecutionLocation { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "يجب أن تكون مبررات البرنامج أقل من 500 حرف")]
        public string? ProgramJustifications { get; set; }

        public int NumberOfAttendees { get; set; } = 0;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // نموذج تصميم البرنامج التدريبي
    public class TrainingProgramDesign
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم البرنامج التدريبي مطلوب")]
        [StringLength(200, ErrorMessage = "يجب أن يكون اسم البرنامج أقل من 200 حرف")]
        public string ProgramName { get; set; } = string.Empty;

        [Required(ErrorMessage = "المجال مطلوب")]
        [StringLength(50, ErrorMessage = "يجب أن يكون المجال أقل من 50 حرف")]
        public string Field { get; set; } = string.Empty;

        [Required(ErrorMessage = "التصنيف مطلوب")]
        [StringLength(50, ErrorMessage = "يجب أن يكون التصنيف أقل من 50 حرف")]
        public string Classification { get; set; } = string.Empty;

        [Required(ErrorMessage = "فترة التنفيذ مطلوبة")]
        [StringLength(100, ErrorMessage = "يجب أن تكون فترة التنفيذ أقل من 100 حرف")]
        public string ExecutionPeriod { get; set; } = string.Empty;

        [Required(ErrorMessage = "الفئة المستهدفة مطلوبة")]
        [StringLength(200, ErrorMessage = "يجب أن تكون الفئة المستهدفة أقل من 200 حرف")]
        public string TargetAudience { get; set; } = string.Empty;

        public int NumberOfParticipants { get; set; } = 0;

        // محتوى البرنامج
        public string Objectives { get; set; } = string.Empty;
        public string WorksheetName { get; set; } = string.Empty;
        public string Executor { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string ExecutionLocation { get; set; } = string.Empty;

        // التقييم
        public string ProgramEvaluation { get; set; } = string.Empty;
        public string FollowUp { get; set; } = string.Empty;
        public string? ProposedFollowUpPlan { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // نموذج التقييم الختامي
    public class FinalEvaluation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان البرنامج مطلوب")]
        [StringLength(200, ErrorMessage = "يجب أن يكون عنوان البرنامج أقل من 200 حرف")]
        public string ProgramTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "المادة مطلوبة")]
        [StringLength(100, ErrorMessage = "يجب أن تكون المادة أقل من 100 حرف")]
        public string Subject { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // نموذج الحضور
    public class Attendance
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "المادة مطلوبة")]
        [StringLength(100, ErrorMessage = "يجب أن تكون المادة أقل من 100 حرف")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "عنوان البرنامج مطلوب")]
        [StringLength(200, ErrorMessage = "يجب أن يكون عنوان البرنامج أقل من 200 حرف")]
        public string ProgramTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "التاريخ مطلوب")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "المنفذ مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون المنفذ أقل من 100 حرف")]
        public string Executor { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // نموذج فريق التحسين والتطوير
    public class ImprovementTeam
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(100, ErrorMessage = "يجب أن يكون الاسم أقل من 100 حرف")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "الوظيفة مطلوبة")]
        [StringLength(100, ErrorMessage = "يجب أن تكون الوظيفة أقل من 100 حرف")]
        public string JobTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "المهمة/الدور مطلوب")]
        [StringLength(200, ErrorMessage = "يجب أن تكون المهمة/الدور أقل من 200 حرف")]
        public string TaskOrRole { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "يجب أن تكون الملاحظات أقل من 500 حرف")]
        public string? Notes { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // نموذج اجتماعات فريق المتابعة
    public class FollowUpMeeting
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "رقم الاجتماع مطلوب")]
        [StringLength(50, ErrorMessage = "يجب أن يكون رقم الاجتماع أقل من 50 حرف")]
        public string MeetingNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "التاريخ مطلوب")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "اليوم مطلوب")]
        [StringLength(20, ErrorMessage = "يجب أن يكون اليوم أقل من 20 حرف")]
        public string Day { get; set; } = string.Empty;

        [Required(ErrorMessage = "جدول الأعمال مطلوب")]
        [StringLength(500, ErrorMessage = "يجب أن يكون جدول الأعمال أقل من 500 حرف")]
        public string Agenda { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "يجب أن تكون الملاحظات أقل من 500 حرف")]
        public string? Notes { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
