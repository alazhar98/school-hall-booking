using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Models;

namespace SchoolHallBooking.Data;

public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
    {
    }

    public DbSet<Hall> Halls { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<StaffStatistic> StaffStatistics { get; set; }
    public DbSet<RegularStudentStatistic> RegularStudentStatistics { get; set; }
    public DbSet<HearingImpairedStudentStatistic> HearingImpairedStudentStatistics { get; set; }
    public DbSet<DutyScheduleItem> DutyScheduleItems { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivitySupervisor> ActivitySupervisors { get; set; }
        public DbSet<DailyPlan> DailyPlans { get; set; }
        public DbSet<ClassLeader> ClassLeaders { get; set; }
        public DbSet<PlanArea> PlanAreas { get; set; }
        public DbSet<PlanObjective> PlanObjectives { get; set; }
        public DbSet<PlanSubObjective> PlanSubObjectives { get; set; }
        public DbSet<PlanAction> PlanActions { get; set; }
        public DbSet<SupervisoryVisit> SupervisoryVisits { get; set; }
        public DbSet<SchoolHallBooking.Models.SupervisoryVisitAnalysis> SupervisoryVisitAnalyses { get; set; }
        public DbSet<SchoolHallBooking.Models.StudentWorkAnalysis> StudentWorkAnalyses { get; set; }
        
        // Professional Development
        public DbSet<ProfessionalDevelopmentProgram> ProfessionalDevelopmentPrograms { get; set; }
        public DbSet<TrainingProgramDesign> TrainingProgramDesigns { get; set; }
        public DbSet<FinalEvaluation> FinalEvaluations { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ImprovementTeam> ImprovementTeams { get; set; }
        public DbSet<FollowUpMeeting> FollowUpMeetings { get; set; }
        
        // Academic Achievement
        public DbSet<AcademicAchievementPlan> AcademicAchievementPlans { get; set; }
        public DbSet<AcademicAchievementInitiative> AcademicAchievementInitiatives { get; set; }
        public DbSet<AcademicAchievementSchoolEffort> AcademicAchievementSchoolEfforts { get; set; }
        public DbSet<AcademicAchievementImprovementTeam> AcademicAchievementImprovementTeams { get; set; }
        public DbSet<AcademicAchievementFollowupMeeting> AcademicAchievementFollowupMeetings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Hall entity
        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Capacity).IsRequired();
            entity.Property(e => e.Location).HasMaxLength(200);
        });

        // Configure Booking entity
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.BookingDate).HasColumnType("date");
            entity.Property(e => e.TeacherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CreatedAt).IsRequired();

            // Configure foreign key relationship
            entity.HasOne(e => e.Hall)
                  .WithMany(e => e.Bookings)
                  .HasForeignKey(e => e.HallId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Create unique index to prevent double booking for same hall, date, and period
            entity.HasIndex(e => new { e.HallId, e.BookingDate, e.Period })
                  .IsUnique();
        });

        // Configure Stats entities (stored in same DB)
        modelBuilder.Entity<StaffStatistic>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            // Enforce one row per role
            entity.HasIndex(e => e.Role).IsUnique();
        });

        modelBuilder.Entity<RegularStudentStatistic>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Division).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<HearingImpairedStudentStatistic>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Grade).IsRequired().HasMaxLength(100);
        });

        // Configure DutyScheduleItem entity
        modelBuilder.Entity<DutyScheduleItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Day).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Column).IsRequired().HasMaxLength(100);
            entity.Property(e => e.TeacherNames).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Configure Employee entity
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.EmployeeId).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CreatedAt).IsRequired();
            
            // Make EmployeeId unique
            entity.HasIndex(e => e.EmployeeId).IsUnique();
        });

        // Seed data
        modelBuilder.Entity<Hall>().HasData(
            new Hall { Id = 1, Name = "قاعة التوجيه المهني", Capacity = 30, Location = "الطابق الأول" },
            new Hall { Id = 2, Name = "قاعة الفضل", Capacity = 50, Location = "الطابق الأول" },
            new Hall { Id = 3, Name = "مركز مصادر التعلم", Capacity = 200, Location = "الطابق الأرضي" },
            new Hall { Id = 4, Name = "قاعة اللغة الإنجليزية", Capacity = 500, Location = "الطابق الثاني" },
            new Hall { Id = 5, Name = "قاعة اللغة العربية", Capacity = 20, Location = "الطابق الأرضي" },
            new Hall { Id = 6, Name = "قاعة المهارات الموسيقية", Capacity = 40, Location = "الطابق الثاني" }
        );

        // Configure Activity entity
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.CreatedAt).IsRequired();
            
            // Configure relationship with ActivitySupervisor
            entity.HasMany(e => e.Supervisors)
                  .WithOne(s => s.Activity)
                  .HasForeignKey(s => s.ActivityId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure ActivitySupervisor entity
        modelBuilder.Entity<ActivitySupervisor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.TeacherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.TeacherId).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Configure DailyPlan entity
        modelBuilder.Entity<DailyPlan>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Month).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Day).IsRequired();
            entity.Property(e => e.Action).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Executor).IsRequired().HasMaxLength(100);
            entity.Property(e => e.ReasonForNonExecution).HasMaxLength(500);
            entity.Property(e => e.ActionTaken).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
        });

        // Configure ClassLeader entity
        modelBuilder.Entity<ClassLeader>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ClassName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.TeacherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
        });

        // Configure PlanArea entity
        modelBuilder.Entity<PlanArea>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Configure PlanObjective entity
        modelBuilder.Entity<PlanObjective>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Objective).IsRequired().HasMaxLength(500);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Configure PlanSubObjective entity
        modelBuilder.Entity<PlanSubObjective>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PlanObjectiveId).IsRequired();
            entity.Property(e => e.Area).IsRequired().HasMaxLength(100);
            entity.Property(e => e.SubObjective).IsRequired().HasMaxLength(500);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();

            entity.HasOne(e => e.PlanObjective)
                  .WithMany(e => e.SubObjectives)
                  .HasForeignKey(e => e.PlanObjectiveId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configure PlanAction entity
        modelBuilder.Entity<PlanAction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PlanSubObjectiveId).IsRequired();
            entity.Property(e => e.Action).IsRequired().HasMaxLength(500);
            entity.Property(e => e.TimePeriod).HasMaxLength(100);
            entity.Property(e => e.Executor).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();

            entity.HasOne(e => e.PlanSubObjective)
                  .WithMany(e => e.Actions)
                  .HasForeignKey(e => e.PlanSubObjectiveId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Seed employee data
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, EmployeeId = "EMP001", Name = "أحمد محمد", Password = "123456", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Employee { Id = 2, EmployeeId = "EMP002", Name = "فاطمة علي", Password = "123456", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Employee { Id = 3, EmployeeId = "EMP003", Name = "محمد حسن", Password = "123456", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Employee { Id = 4, EmployeeId = "EMP004", Name = "سارة أحمد", Password = "123456", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Employee { Id = 5, EmployeeId = "EMP005", Name = "عبدالله سالم", Password = "123456", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) }
        );

        // Seed activity data
        modelBuilder.Entity<Activity>().HasData(
            new Activity { Id = 1, Name = "الإذاعة المدرسية", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 2, Name = "النادي العلمي", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 3, Name = "الصحة المدرسية", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 4, Name = "التراث والسياحة", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 5, Name = "الجمعية التعاونية", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 6, Name = "الفنون التشكيلية والصناعات الحرفية", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 7, Name = "المسرح", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 8, Name = "الأمن والسلامة", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 9, Name = "جماعة الكشافة", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 10, Name = "جماعة العمل التطوعي", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 11, Name = "جماعة الموسيقى والفنون الشعبية", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 12, Name = "جماعة الفنون الأدبية", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 13, Name = "جماعة النشاط الرياضي", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 14, Name = "جماعة الحاسوب", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new Activity { Id = 15, Name = "جماعة حفظ القرآن الكريم", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) }
        );

        // Seed plan areas data
        modelBuilder.Entity<PlanArea>().HasData(
            new PlanArea { Id = 1, Name = "القيادة والإدارة والحوكمة", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new PlanArea { Id = 2, Name = "النمو الشخصي للطلبة ورعايتهم", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new PlanArea { Id = 3, Name = "التدريس والتقويم", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) },
            new PlanArea { Id = 4, Name = "إنجاز الطلبة", IsActive = true, CreatedAt = new DateTime(2024, 1, 1) }
        );

        // Configure SupervisoryVisit entity
        modelBuilder.Entity<SupervisoryVisit>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.VisitorTeacherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.VisitedTeacherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Day).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.LessonTitle).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(50);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Professional Development Program
        modelBuilder.Entity<ProfessionalDevelopmentProgram>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ProgramType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.ProgramName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Executor).IsRequired().HasMaxLength(100);
            entity.Property(e => e.ExecutionLocation).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ProgramJustifications).HasMaxLength(500);
            entity.Property(e => e.NumberOfAttendees).IsRequired();
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Training Program Design
        modelBuilder.Entity<TrainingProgramDesign>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ProgramName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Field).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Classification).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ExecutionPeriod).IsRequired().HasMaxLength(100);
            entity.Property(e => e.TargetAudience).IsRequired().HasMaxLength(200);
            entity.Property(e => e.NumberOfParticipants).IsRequired();
            entity.Property(e => e.Objectives).HasMaxLength(1000);
            entity.Property(e => e.WorksheetName).HasMaxLength(200);
            entity.Property(e => e.Executor).HasMaxLength(100);
            entity.Property(e => e.JobTitle).HasMaxLength(100);
            entity.Property(e => e.Duration).HasMaxLength(100);
            entity.Property(e => e.ExecutionLocation).HasMaxLength(200);
            entity.Property(e => e.ProgramEvaluation).HasMaxLength(500);
            entity.Property(e => e.FollowUp).HasMaxLength(50);
            entity.Property(e => e.ProposedFollowUpPlan).HasMaxLength(500);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Final Evaluation
        modelBuilder.Entity<FinalEvaluation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ProgramTitle).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Attendance
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.Property(e => e.ProgramTitle).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Executor).IsRequired().HasMaxLength(100);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Improvement Team
        modelBuilder.Entity<ImprovementTeam>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.JobTitle).IsRequired().HasMaxLength(100);
            entity.Property(e => e.TaskOrRole).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Follow Up Meeting
        modelBuilder.Entity<FollowUpMeeting>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MeetingNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Day).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Agenda).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.IsActive).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });
    }
}
