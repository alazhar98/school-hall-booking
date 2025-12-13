-- إنشاء الجداول الأساسية للتطبيق
CREATE TABLE IF NOT EXISTS `Halls` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(100) NOT NULL,
    `Capacity` int NOT NULL,
    `Location` varchar(200) DEFAULT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE IF NOT EXISTS `Employees` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `EmployeeId` varchar(50) NOT NULL,
    `Name` varchar(100) NOT NULL,
    `Password` varchar(255) DEFAULT NULL,
    `IsActive` tinyint(1) NOT NULL DEFAULT 1,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`),
    UNIQUE KEY `IX_Employees_EmployeeId` (`EmployeeId`)
);

CREATE TABLE IF NOT EXISTS `Bookings` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `HallId` int NOT NULL,
    `EmployeeId` varchar(50) NOT NULL,
    `BookingDate` date NOT NULL,
    `StartTime` time(6) NOT NULL,
    `EndTime` time(6) NOT NULL,
    `Purpose` varchar(500) DEFAULT NULL,
    `Status` varchar(20) NOT NULL DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`),
    KEY `IX_Bookings_HallId` (`HallId`),
    KEY `IX_Bookings_EmployeeId` (`EmployeeId`),
    CONSTRAINT `FK_Bookings_Halls_HallId` FOREIGN KEY (`HallId`) REFERENCES `Halls` (`Id`) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS `StaffStatistics` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Role` varchar(50) NOT NULL,
    `Count` int NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

-- إدراج سجل الهجرة الأولية
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20241018000000_InitialCreate', '8.0.0');

-- جدول برامج الإنماء المهني
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
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول الإنجازات الأكاديمية
CREATE TABLE IF NOT EXISTS `AcademicAchievements` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(200) NOT NULL,
    `Description` text,
    `Date` date NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول التقييمات النهائية
CREATE TABLE IF NOT EXISTS `FinalEvaluations` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ProgramId` int NOT NULL,
    `EvaluationDate` date NOT NULL,
    `Evaluator` varchar(100) NOT NULL,
    `OverallRating` int NOT NULL,
    `Comments` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`),
    KEY `IX_FinalEvaluations_ProgramId` (`ProgramId`)
);

-- جدول الأنشطة
CREATE TABLE IF NOT EXISTS `Activities` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(200) NOT NULL,
    `Description` text,
    `Date` date NOT NULL,
    `Location` varchar(200),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول مشرفي الأنشطة
CREATE TABLE IF NOT EXISTS `ActivitySupervisors` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ActivityId` int NOT NULL,
    `SupervisorName` varchar(100) NOT NULL,
    `SupervisorRole` varchar(100),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`),
    KEY `IX_ActivitySupervisors_ActivityId` (`ActivityId`)
);

-- جدول قادة الفصول
CREATE TABLE IF NOT EXISTS `ClassLeaders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ClassName` varchar(50) NOT NULL,
    `LeaderName` varchar(100) NOT NULL,
    `Grade` varchar(20),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول الخطط اليومية
CREATE TABLE IF NOT EXISTS `DailyPlans` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` date NOT NULL,
    `PlanTitle` varchar(200) NOT NULL,
    `Description` text,
    `CreatedBy` varchar(100) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول جدولة المناوبات
CREATE TABLE IF NOT EXISTS `DutyScheduleItems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Date` date NOT NULL,
    `EmployeeName` varchar(100) NOT NULL,
    `DutyType` varchar(100) NOT NULL,
    `Location` varchar(200),
    `Notes` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول اجتماعات المتابعة
CREATE TABLE IF NOT EXISTS `FollowupMeetings` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MeetingDate` date NOT NULL,
    `MeetingTitle` varchar(200) NOT NULL,
    `Participants` text,
    `Agenda` text,
    `Decisions` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول فرق التحسين
CREATE TABLE IF NOT EXISTS `ImprovementTeams` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TeamName` varchar(200) NOT NULL,
    `TeamLeader` varchar(100) NOT NULL,
    `Members` text,
    `Objectives` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول خطط العمل
CREATE TABLE IF NOT EXISTS `PlanActions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ActionTitle` varchar(200) NOT NULL,
    `Description` text,
    `ResponsiblePerson` varchar(100) NOT NULL,
    `Deadline` date,
    `Status` varchar(50) DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول مجالات الخطة
CREATE TABLE IF NOT EXISTS `PlanAreas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AreaName` varchar(200) NOT NULL,
    `Description` text,
    `Priority` varchar(50),
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول أهداف الخطة
CREATE TABLE IF NOT EXISTS `PlanObjectives` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ObjectiveTitle` varchar(200) NOT NULL,
    `Description` text,
    `TargetDate` date,
    `Status` varchar(50) DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول الأهداف الفرعية
CREATE TABLE IF NOT EXISTS `PlanSubObjectives` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ObjectiveId` int NOT NULL,
    `SubObjectiveTitle` varchar(200) NOT NULL,
    `Description` text,
    `TargetDate` date,
    `Status` varchar(50) DEFAULT 'Pending',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`),
    KEY `IX_PlanSubObjectives_ObjectiveId` (`ObjectiveId`)
);

-- جدول سجلات الحضور
CREATE TABLE IF NOT EXISTS `AttendanceRecords` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `EmployeeId` varchar(50) NOT NULL,
    `Date` date NOT NULL,
    `CheckInTime` time(6),
    `CheckOutTime` time(6),
    `Status` varchar(50) DEFAULT 'Present',
    `Notes` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`),
    KEY `IX_AttendanceRecords_EmployeeId` (`EmployeeId`)
);

-- جدول الحضور
CREATE TABLE IF NOT EXISTS `Attendances` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ProgramId` int NOT NULL,
    `AttendeeName` varchar(100) NOT NULL,
    `AttendeeRole` varchar(100),
    `AttendanceStatus` varchar(50) DEFAULT 'Present',
    `Notes` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`),
    KEY `IX_Attendances_ProgramId` (`ProgramId`)
);

-- جدول تحليل زيارات الوظائف الإدارية
CREATE TABLE IF NOT EXISTS `AdminJobVisitAnalyses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `VisitDate` date NOT NULL,
    `VisitorName` varchar(100) NOT NULL,
    `VisitPurpose` varchar(200) NOT NULL,
    `Findings` text,
    `Recommendations` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول تحليل آراء أولياء الأمور
CREATE TABLE IF NOT EXISTS `ParentsOpinionAnalyses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `AnalysisDate` date NOT NULL,
    `SurveyTitle` varchar(200) NOT NULL,
    `TotalResponses` int NOT NULL,
    `PositiveResponses` int NOT NULL,
    `NegativeResponses` int NOT NULL,
    `NeutralResponses` int NOT NULL,
    `Summary` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول إحصائيات طلبة الدمج السمعي
CREATE TABLE IF NOT EXISTS `HearingImpairedStudentStatistics` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Grade` varchar(20) NOT NULL,
    `StudentCount` int NOT NULL,
    `MaleCount` int NOT NULL,
    `FemaleCount` int NOT NULL,
    `AcademicYear` varchar(20) NOT NULL,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول اجتماعات متابعة الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementFollowupMeetings` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MeetingDate` date NOT NULL,
    `MeetingTitle` varchar(200) NOT NULL,
    `Participants` text,
    `Agenda` text,
    `Decisions` text,
    `NextMeetingDate` date,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول فرق تحسين الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementImprovementTeams` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `TeamName` varchar(200) NOT NULL,
    `TeamLeader` varchar(100) NOT NULL,
    `Members` text,
    `Objectives` text,
    `ActionPlan` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول مبادرات الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementInitiatives` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `InitiativeTitle` varchar(200) NOT NULL,
    `Description` text,
    `StartDate` date NOT NULL,
    `EndDate` date,
    `ResponsiblePerson` varchar(100) NOT NULL,
    `Status` varchar(50) DEFAULT 'Active',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول خطط الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementPlans` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `PlanTitle` varchar(200) NOT NULL,
    `Description` text,
    `AcademicYear` varchar(20) NOT NULL,
    `StartDate` date NOT NULL,
    `EndDate` date,
    `Status` varchar(50) DEFAULT 'Active',
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);

-- جدول جهود المدرسة في الإنجاز الأكاديمي
CREATE TABLE IF NOT EXISTS `AcademicAchievementSchoolEfforts` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `EffortTitle` varchar(200) NOT NULL,
    `Description` text,
    `ImplementationDate` date NOT NULL,
    `ResponsibleDepartment` varchar(100) NOT NULL,
    `Results` text,
    `CreatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    `UpdatedAt` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
    PRIMARY KEY (`Id`)
);
