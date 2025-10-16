using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class AcademicAchievementPlan
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "الإجراء/الفعالية مطلوب")]
        public string Activity { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "فترة التنفيذ مطلوبة")]
        public string ImplementationPeriod { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "الفئة المستهدفة مطلوبة")]
        public string TargetGroup { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "جهة التنفيذ مطلوبة")]
        public string ImplementingBody { get; set; } = string.Empty;
        
        public bool IsImplemented { get; set; } = false;
        
        public string? Notes { get; set; }
        
        public string Subject { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class AcademicAchievementInitiative
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "اسم المشروع/المبادرة مطلوب")]
        public string ProjectName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "المادة مطلوبة")]
        public string Subject { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "الفئة المستهدفة مطلوبة")]
        public string TargetGroup { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "فكرة المشروع مطلوبة")]
        public string ProjectIdea { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "أهداف المشروع مطلوبة")]
        public string ProjectObjectives { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "الخطة الزمنية مطلوبة")]
        public string Timeline { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "آلية التنفيذ مطلوبة")]
        public string ImplementationMechanism { get; set; } = string.Empty;
        
        public string? TechnicalOpinion { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class AcademicAchievementSchoolEffort
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "المادة مطلوبة")]
        public string Subject { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "البرنامج أو الفعالية مطلوب")]
        public string ProgramOrActivity { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "النوع مطلوب")]
        public string Type { get; set; } = string.Empty; // إثرائي، علاجي، تطويري
        
        [Required(ErrorMessage = "الفئة المستهدفة مطلوبة")]
        public string TargetGroup { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "المنفذون مطلوبون")]
        public string Implementers { get; set; } = string.Empty;
        
        public DateTime? Date { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class AcademicAchievementImprovementTeam
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "الوظيفة مطلوبة")]
        public string JobTitle { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "المهمة/الدور مطلوب")]
        public string TaskOrRole { get; set; } = string.Empty;
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class AcademicAchievementFollowupMeeting
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "رقم الاجتماع مطلوب")]
        public string MeetingNumber { get; set; } = string.Empty;
        
        public DateTime? Date { get; set; }
        
        [Required(ErrorMessage = "اليوم مطلوب")]
        public string Day { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "جدول الأعمال مطلوب")]
        public string Agenda { get; set; } = string.Empty;
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
