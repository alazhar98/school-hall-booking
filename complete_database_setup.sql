-- ========================================
-- إنشاء جميع الجداول المطلوبة
-- ========================================

-- 1. جدول EF Migrations History
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT IGNORE INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20241018000000_InitialCreate', '9.0.0');

-- 2. جدول برامج الإنماء المهني
CREATE TABLE IF NOT EXISTS `ProfessionalDevelopmentPrograms` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ProgramType` varchar(100) NOT NULL,
    `ProgramName` varchar(200) NOT NULL,
    `Subject` varchar(100) NOT NULL,
    `Date` date NOT NULL,
    `Executor` varchar(100) NOT NULL,
    `ExecutionLocation` varchar(200) NOT NULL,
    `NumberOfAttendees` int NOT NULL,
    `ProgramJustifications` text,
    `TrainingProgramSummary` text,
    `ImagePath` varchar(500),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 3. جدول الإنجازات الأكاديمية
CREATE TABLE IF NOT EXISTS `AcademicAchievements` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(200) NOT NULL,
    `Description` text,
    `Date` date NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 4. جدول التقييمات النهائية
CREATE TABLE IF NOT EXISTS `FinalEvaluations` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ProgramId` int NOT NULL,
    `EvaluationDate` date NOT NULL,
    `Evaluator` varchar(100) NOT NULL,
    `Score` int NOT NULL,
    `Comments` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 5. جدول الأنشطة
CREATE TABLE IF NOT EXISTS `Activities` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(200) NOT NULL,
    `Description` text,
    `Date` date NOT NULL,
    `Location` varchar(200),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 6. جدول مشرفي الأنشطة
CREATE TABLE IF NOT EXISTS `ActivitySupervisors` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ActivityId` int NOT NULL,
    `SupervisorName` varchar(100) NOT NULL,
    `SupervisorRole` varchar(100),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 7. جدول قادة الصف
CREATE TABLE IF NOT EXISTS `ClassLeaders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `StudentName` varchar(100) NOT NULL,
    `Class` varchar(50) NOT NULL,
    `AcademicYear` varchar(20) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 8. جدول الخطط اليومية
CREATE TABLE IF NOT EXISTS `DailyPlans` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` date NOT NULL,
    `PlanTitle` varchar(200) NOT NULL,
    `Description` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 9. جدول جدول المناوبات
CREATE TABLE IF NOT EXISTS `DutyScheduleItems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` date NOT NULL,
    `Time` time NOT NULL,
    `Location` varchar(200) NOT NULL,
    `AssignedPerson` varchar(100) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 10. جدول اجتماعات المتابعة
CREATE TABLE IF NOT EXISTS `FollowupMeetings` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MeetingDate` date NOT NULL,
    `MeetingTitle` varchar(200) NOT NULL,
    `Participants` text,
    `Agenda` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 11. جدول فرق التحسين
CREATE TABLE IF NOT EXISTS `ImprovementTeams` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TeamName` varchar(200) NOT NULL,
    `TeamLeader` varchar(100) NOT NULL,
    `Members` text,
    `Objective` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 12. جدول إجراءات الخطة
CREATE TABLE IF NOT EXISTS `PlanActions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ActionTitle` varchar(200) NOT NULL,
    `Description` text,
    `ResponsiblePerson` varchar(100) NOT NULL,
    `Deadline` date,
    `Status` varchar(50) DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 13. جدول مجالات الخطة
CREATE TABLE IF NOT EXISTS `PlanAreas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AreaName` varchar(200) NOT NULL,
    `Description` text,
    `Priority` varchar(50),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 14. جدول أهداف الخطة
CREATE TABLE IF NOT EXISTS `PlanObjectives` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ObjectiveTitle` varchar(200) NOT NULL,
    `Description` text,
    `TargetDate` date,
    `Status` varchar(50) DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 15. جدول الأهداف الفرعية
CREATE TABLE IF NOT EXISTS `PlanSubObjectives` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ObjectiveId` int NOT NULL,
    `SubObjectiveTitle` varchar(200) NOT NULL,
    `Description` text,
    `TargetDate` date,
    `Status` varchar(50) DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 16. جدول سجلات الحضور
CREATE TABLE IF NOT EXISTS `AttendanceRecords` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `StudentName` varchar(100) NOT NULL,
    `Class` varchar(50) NOT NULL,
    `Date` date NOT NULL,
    `Status` varchar(50) NOT NULL,
    `Notes` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 17. جدول حضور الموظفين
CREATE TABLE IF NOT EXISTS `Attendances` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `EmployeeId` varchar(50) NOT NULL,
    `Date` date NOT NULL,
    `CheckInTime` time,
    `CheckOutTime` time,
    `Status` varchar(50) NOT NULL,
    `Notes` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 18. جدول تحليل الزيارات الإدارية
CREATE TABLE IF NOT EXISTS `AdminJobVisitAnalyses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `VisitDate` date NOT NULL,
    `VisitorName` varchar(100) NOT NULL,
    `VisitPurpose` varchar(200) NOT NULL,
    `Findings` text,
    `Recommendations` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 19. جدول تحليل آراء أولياء الأمور
CREATE TABLE IF NOT EXISTS `ParentsOpinionAnalyses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SurveyDate` date NOT NULL,
    `SurveyTitle` varchar(200) NOT NULL,
    `TotalResponses` int NOT NULL,
    `PositiveResponses` int NOT NULL,
    `NegativeResponses` int NOT NULL,
    `Summary` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 20. جدول إحصائيات الطلاب ضعاف السمع
CREATE TABLE IF NOT EXISTS `HearingImpairedStudentStatistics` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AcademicYear` varchar(20) NOT NULL,
    `TotalStudents` int NOT NULL,
    `MaleStudents` int NOT NULL,
    `FemaleStudents` int NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 21. جدول اجتماعات متابعة الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementFollowupMeetings` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MeetingDate` date NOT NULL,
    `MeetingTitle` varchar(200) NOT NULL,
    `Participants` text,
    `Agenda` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 22. جدول فرق تحسين الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementImprovementTeams` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TeamName` varchar(200) NOT NULL,
    `TeamLeader` varchar(100) NOT NULL,
    `Members` text,
    `Objective` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 23. جدول مبادرات الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementInitiatives` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `InitiativeTitle` varchar(200) NOT NULL,
    `Description` text,
    `StartDate` date NOT NULL,
    `EndDate` date,
    `Status` varchar(50) DEFAULT 'Active',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 24. جدول خطط الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementPlans` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PlanTitle` varchar(200) NOT NULL,
    `Description` text,
    `TargetDate` date,
    `Status` varchar(50) DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- 25. جدول جهود المدرسة في الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementSchoolEfforts` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `EffortTitle` varchar(200) NOT NULL,
    `Description` text,
    `ImplementationDate` date NOT NULL,
    `Results` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

