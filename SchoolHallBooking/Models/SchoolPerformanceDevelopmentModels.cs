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
}


