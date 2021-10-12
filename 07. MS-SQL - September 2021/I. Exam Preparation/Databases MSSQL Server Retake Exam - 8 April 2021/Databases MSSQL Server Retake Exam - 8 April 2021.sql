--01. DDL
CREATE DATABASE [Service]

USE [Service]

CREATE TABLE [Users]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	[Birthdate] DATETIME2,
	[Age] INT,
		CHECK([Age] >= 14 AND [Age] <= 110),
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE [Departments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(25),
	[LastName] VARCHAR(25),
	[Birthdate] DATETIME2,
	[Age] INT,
		CHECK([Age] >= 18 AND [Age] <= 110),
	[DepartmentId] INT FOREIGN KEY REFERENCES [dbo].[Departments]([Id])
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [dbo].[Departments]([Id])
)

CREATE TABLE [Status]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE [Reports]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryId] INT FOREIGN KEY REFERENCES [dbo].[Categories]([Id]) NOT NULL,
	[StatusId] INT FOREIGN KEY REFERENCES [dbo].[Status]([Id]) NOT NULL,
	[OpenDate] DATETIME2 NOT NULL,
	[CloseDate] DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	[UserId] INT FOREIGN KEY REFERENCES [dbo].[Users]([Id]) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [dbo].[Employees]([Id])
)

--02. Insert
USE [Service]

INSERT [dbo].[Employees]([FirstName], [LastName], [Birthdate], [DepartmentId]) VALUES
	('Marlo', 'O''Malley', '1958-09-21', 1),
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-14', 9),
	('Giovanna', 'Amati', '1959-07-20', 5)

INSERT [dbo].[Reports]([CategoryId], [StatusId], [OpenDate], [CloseDate], [Description], [UserId], [EmployeeId]) VALUES
	(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--03. Update
USE [Service]

UPDATE [dbo].[Reports]
SET [CloseDate] = GETDATE()
WHERE [CloseDate] IS NULL

--04. Delete
USE [Service]

DELETE [dbo].[Reports]
WHERE [StatusId] = 4

--05. Unassigned Reports
USE [Service]

SELECT r.[Description], FORMAT(r.[OpenDate], 'dd-MM-yyyy') AS [OpenDate] FROM [dbo].[Reports] AS r
WHERE r.[EmployeeId] IS NULL
ORDER BY r.[OpenDate] ASC, r.[Description]

--06. Reports & Categories
USE [Service]

SELECT r.[Description], c.[Name] AS [CategoryName] FROM [dbo].[Reports] AS r
	JOIN [dbo].[Categories] AS c ON c.[Id] = r.[CategoryId]
ORDER BY r.[Description], c.[Name]

--07. Most Reported Category
USE [Service]

SELECT TOP (5) c.[Name] AS [CategoryName], COUNT(*) AS [ReportsNumber] FROM [dbo].[Reports] AS r
	JOIN [dbo].[Categories] AS c ON c.[Id] = r.[CategoryId]
GROUP BY c.[Name]
ORDER BY [ReportsNumber] DESC, [CategoryName]

--08. Birthday Report
USE [Service]

SELECT u.[Username], c.[Name] AS [CategoryName] FROM [dbo].[Reports] AS r
	JOIN [dbo].[Users] AS u ON u.[Id] = r.[UserId]
	JOIN [dbo].[Categories] AS c ON c.[Id] = r.[CategoryId]
WHERE MONTH(u.[Birthdate]) = MONTH(r.[OpenDate]) AND DAY(u.[Birthdate]) = DAY(r.[OpenDate])
ORDER BY u.[Username] asc, c.[Name] 

--09. User per Employee
USE [Service]

SELECT DISTINCT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName], COUNT(u.[Id]) AS [UsersCount] FROM [dbo].[Employees] AS e
	LEFT JOIN [dbo].[Reports] AS r ON r.[EmployeeId] = e.[Id]
	LEFT JOIN [dbo].[Users] AS u ON u.[Id] = r.[UserId]
GROUP BY e.[Id], e.[FirstName], e.[LastName]
ORDER BY COUNT(u.[Id]) DESC, [FullName]

--10. Full Info
USE [Service]

SELECT 
	ISNULL(e.[FirstName] + ' ' + e.[LastName], 'None') AS [Employee],
	ISNULL(d.[Name], 'None') AS [Department],
	ISNULL(c.[Name], 'None') AS [Category],
	ISNULL(r.[Description], 'None') AS [Description],
	FORMAT(r.[OpenDate],'dd.MM.yyyy') AS [OpenDate],
	ISNULL(s.[Label], 'None') AS [Status],
	ISNULL(u.[Name], 'None') AS [User]
FROM [dbo].[Reports] AS r 
	LEFT JOIN [dbo].[Employees] AS e ON e.[Id] = r.[EmployeeId]
	LEFT JOIN [dbo].[Categories] AS c ON c.[Id] = r.[CategoryId]
	LEFT JOIN [dbo].[Status] AS s ON s.[Id] = r.[StatusId]
	LEFT JOIN [dbo].[Users] AS u ON u.[Id] = r.[UserId]
	LEFT JOIN [dbo].[Departments] AS d ON d.[Id] = e.[DepartmentId]
ORDER BY e.[FirstName] DESC, e.[LastName] DESC, d.[Name], c.[Name], r.[Description], r.[OpenDate], s.[Label], u.[Name]

--11. Hours to Complete
USE [Service]

GO

CREATE OR ALTER FUNCTION [udf_HoursToComplete](@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS BEGIN
	IF (@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END
GO

SELECT [dbo].[udf_HoursToComplete](OpenDate, CloseDate) AS [TotalHours] FROM [dbo].[Reports]

--12. Assign Employee
USE [Service]

GO

CREATE OR ALTER PROC [usp_AssignEmployeeToReport] (@EmployeeId INT, @ReportId INT)
AS BEGIN
	DECLARE @EmployeeDepartmentId INT = (SELECT [DepartmentId] FROM [dbo].[Employees] WHERE [Id] = @EmployeeId)
	DECLARE @ReportDepartmentId INT = (SELECT c.[DepartmentId] FROM [dbo].[Reports] AS r JOIN [dbo].[Categories] AS c ON c.[Id] = r.[CategoryId] WHERE r.[Id] = @ReportId)

	IF (@EmployeeDepartmentId != @ReportDepartmentId)
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
	ELSE
		UPDATE [dbo].[Reports]
		SET [EmployeeId] = @EmployeeId
		WHERE [Id] = @ReportId
END
GO

EXEC [dbo].[usp_AssignEmployeeToReport] 30, 1
GO
EXEC [dbo].[usp_AssignEmployeeToReport] 17, 2
