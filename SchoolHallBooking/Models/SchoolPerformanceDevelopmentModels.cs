using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolHallBooking.Models
{
    public class SupervisoryVisitAnalysis
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string Subject { get; set; } = string.Empty;
        public string Strengths { get; set; } = string.Empty;           // جوانب القوة
        public string Enhancements { get; set; } = string.Empty;        // جوانب التعزيز
        public string FollowUpActions { get; set; } = string.Empty;     // إجراءات المتابعة

        public string DevelopmentPriorities { get; set; } = string.Empty; // أولويات التطوير
        public string DevelopmentActions { get; set; } = string.Empty;     // إجراءات التطوير
        public string DevelopmentFollowUp { get; set; } = string.Empty;    // إجراءات المتابعة للتطوير
    }

    public class StudentWorkAnalysis
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string Subject { get; set; } = string.Empty;
        public string Strengths { get; set; } = string.Empty;           // جوانب القوة
        public string Enhancements { get; set; } = string.Empty;        // جوانب التعزيز
        public string FollowUpActions { get; set; } = string.Empty;     // إجراءات المتابعة

        public string DevelopmentPriorities { get; set; } = string.Empty; // أولويات التطوير
        public string DevelopmentActions { get; set; } = string.Empty;     // إجراءات التطوير
        public string DevelopmentFollowUp { get; set; } = string.Empty;    // إجراءات المتابعة للتطوير
    }

    // Slide 6: الوظائف الإدارية والمساندة - تحليل زيارة
    public class AdminJobVisitAnalysis
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public string JobTitle { get; set; } = string.Empty;            // الوظيفة
        public string Strengths { get; set; } = string.Empty;
        public string Enhancements { get; set; } = string.Empty;
        public string FollowUpActions { get; set; } = string.Empty;
        public string DevelopmentPriorities { get; set; } = string.Empty;
        public string DevelopmentActions { get; set; } = string.Empty;
        public string DevelopmentFollowUp { get; set; } = string.Empty;
    }

    // Slide 7/8/9: آراء الطلبة/الهيئة/أولياء الأمور
    public class StudentOpinionAnalysis
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Strengths { get; set; } = string.Empty;
        public string Enhancements { get; set; } = string.Empty;
        public string FollowUpActions { get; set; } = string.Empty;
        public string SummarySuggestions { get; set; } = string.Empty;   // أهم المقترحات
        public string SummaryFollowUp { get; set; } = string.Empty;      // جوانب المتابعة
    }

    public class StaffOpinionAnalysis
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Strengths { get; set; } = string.Empty;
        public string Enhancements { get; set; } = string.Empty;
        public string FollowUpActions { get; set; } = string.Empty;
        public string SummarySuggestions { get; set; } = string.Empty;
        public string SummaryFollowUp { get; set; } = string.Empty;
    }

    public class ParentsOpinionAnalysis
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Strengths { get; set; } = string.Empty;
        public string Enhancements { get; set; } = string.Empty;
        public string FollowUpActions { get; set; } = string.Empty;
        public string SummarySuggestions { get; set; } = string.Empty;
        public string SummaryFollowUp { get; set; } = string.Empty;
    }

    // Slide 10: فريق التحسين والتطوير (ضمن الشريحة 1)
    public class SPDImprovementTeamMember
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Subject { get; set; } = string.Empty; // للمادة المختارة من الشريحة 1
        [Required]
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }

    // Slide 11: اجتماعات فريق المتابعة
    public class SPDFollowupMeeting
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Subject { get; set; } = string.Empty;
        public string MeetingNumber { get; set; } = string.Empty;
        public DateTime? MeetingDate { get; set; }
        public string Day { get; set; } = string.Empty;
        public string Agenda { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }

    // Slide 12: التعاميم
    public class SPDDirectiveRecord
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Subject { get; set; } = string.Empty;
        public string DirectiveNumber { get; set; } = string.Empty;
        public DateTime? DirectiveDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty; // الجهة الصادرة
    }

    // Slide 13: الزيارات الخاصة بالنظام
    public class SPDVisitRecord
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Subject { get; set; } = string.Empty;
        public string VisitorName { get; set; } = string.Empty;
        public string VisitorJob { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public DateTime? VisitDate { get; set; }
        public string Target { get; set; } = string.Empty;
    }
}


