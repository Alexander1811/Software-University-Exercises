--01. Find Names of All Employees by First Name
USE [SoftUni]

SELECT [FirstName], [LastName] FROM [dbo].[Employees]
WHERE [FirstName] LIKE 'Sa%' 
--WHERE LEFT([FirstName], 2) = 'Sa'
--WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

--02. Find Names of All employees by Last Name 
USE [SoftUni]

SELECT [FirstName], [LastName] FROM [dbo].[Employees]
WHERE [LastName] LIKE '%ei%' 

--03. Find First Names of All Employees
USE [SoftUni]

SELECT [FirstName] FROM [dbo].[Employees]
WHERE [DepartmentID] = 3 OR [DepartmentID] = 10 AND YEAR([HireDate]) BETWEEN 1995 AND 2005

--04. Find All Employees Except Engineers
USE [SoftUni]

SELECT [FirstName], [LastName] FROM [dbo].[Employees]
WHERE [JobTitle] NOT LIKE '%engineer%' 

--05. Find Towns with Name Length
USE [SoftUni]

SELECT [Name] FROM [dbo].[Towns]
WHERE LEN ([Name]) = 5 OR LEN ([Name]) = 6
ORDER BY [Name] ASC

--06. Find Towns Starting With
USE [SoftUni]

SELECT [TownID], [Name] FROM [dbo].[Towns]
WHERE [Name] LIKE '[BEKM]%'
ORDER BY [Name] ASC

--07. Find Towns Not Starting With
USE [SoftUni]

SELECT [TownID], [Name] FROM [dbo].[Towns]
WHERE [Name] NOT LIKE '[RBD]%' 
ORDER BY [Name] ASC

--08. Create View Employees Hired After 2000 Year
USE [SoftUni]

CREATE VIEW [v_EmployeesHiredAfter2000] AS
SELECT * FROM [dbo].[Employees]
WHERE YEAR([HireDate]) > 2000

--09. Length of Last Name
USE [SoftUni]

SELECT [FirstName], [LastName] FROM [dbo].[Employees]
WHERE LEN([LastName]) = 5

--10. Rank Employees by Salary
USE [SoftUni]

SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank] 
FROM [dbo].[Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--11. Find All Employees with Rank 2
USE [SoftUni]

SELECT * FROM 
	(SELECT [EmployeeID], [FirstName], [LastName], [Salary], DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [dbo].[Employees]
WHERE [Salary] BETWEEN 10000 AND 50000) AS [Ranking Table]
WHERE [Rank] = 2
ORDER BY [Salary] DESC

--12. Countries Holding ‘A’ 3 or More Times
USE [Geography]

SELECT [CountryName] AS [Country Name], [IsoCode] AS [ISO Code] FROM [dbo].[Countries]
WHERE [CountryName] LIKE '%A%A%A%'
ORDER BY [IsoCode] ASC

--13. Mix of Peak and River Names
USE [Geography]

SELECT [PeakName], [RiverName], CONCAT(LOWER([PeakName]), SUBSTRING(LOWER([RiverName]), 2, LEN([RiverName]))) AS [Mix] FROM [Peaks], [Rivers]
WHERE RIGHT([PeakName], 1) = LEFT([RiverName], 1)
ORDER BY [Mix]

--14. Games from 2011 and 2012 Year
USE [Diablo]

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM [dbo].[Games]
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--15. User Email Providers
USE [Diablo]

SELECT [Username], SUBSTRING([Email], CHARINDEX('@', [Email], 1)+1, LEN([Email])) AS [Email Provider] FROM [dbo].[Users]
ORDER BY [Email Provider], [Username]

--16. Get Users with IP Address Like Pattern
USE [Diablo]

SELECT [Username], [IpAddress] AS [IP Address] FROM [dbo].[Users]
WHERE [IpAddress] LIKE '[0-9][0-9][0-9].1%.%[0-9][0-9][0-9]' --'___.1%.%.___' 
ORDER BY [Username]

--17. Show All Games with Duration and Part of the Day
USE [Diablo] 

SELECT [Name] AS [Game],
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon' 
		WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening' 
	END AS [Part of the Day],
	CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		WHEN [Duration] IS NULL THEN 'Extra Long'
	END AS [Duration]
FROM [dbo].[Games]
ORDER BY [Game], [Duration], [Part of the Day]

--18. Orders Table
CREATE DATABASE [Orders]

USE [Orders]

CREATE TABLE [Orders]
(
	[Id] INT NOT NULL,
	[ProductName] VARCHAR(50) NOT NULL,
	[OrderDate] DATETIME NOT NULL
	CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
)

INSERT INTO [dbo].[Orders] ([Id], [ProductName], [OrderDate]) VALUES 
	(1, 'Butter', '2016-09-19'),
	(2, 'Milk', '2016-09-30'),
	(3, 'Cheese', '2016-09-04'),
	(4, 'Bread', '2015-12-20'),
	(5, 'Tomatoes', '2015-01-01')

SELECT 
	[ProductName], 
	[OrderDate],
	DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
	DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM [dbo].[Orders]

--19. People Table
CREATE DATABASE [People]

USE [People]

CREATE TABLE [People]
(	
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL
)

INSERT INTO [People] ([Name], [Birthdate]) VALUES
	('Victor', '2000-12-07 00:00:00.000'),
	('Steven', '1992-09-10 00:00:00.000'),
	('Stephen', '1910-09-19 00:00:00.000'),
	('John', '2010-01-06 00:00:00.000')

SELECT 
	[Name],
	DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM [dbo].[People]