-- SQL Script لإنشاء الجداول الأساسية في MySQL
-- استخدم هذا السكريبت في phpMyAdmin أو MySQL Workbench

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

-- إدراج بيانات أولية
INSERT INTO `Halls` (`Name`, `Capacity`, `Location`) VALUES
('القاعة الرئيسية', 100, 'الطابق الأرضي'),
('قاعة الاجتماعات', 30, 'الطابق الأول'),
('المختبر', 25, 'الطابق الثاني');

INSERT INTO `Employees` (`EmployeeId`, `Name`, `Password`, `IsActive`) VALUES
('admin', 'مدير النظام', 'admin123', 1),
('teacher1', 'أحمد محمد', 'teacher123', 1),
('teacher2', 'فاطمة علي', 'teacher123', 1);

INSERT INTO `StaffStatistics` (`Role`, `Count`) VALUES
('معلم', 25),
('إداري', 5),
('عامل', 3);
