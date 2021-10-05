--01. Examine the Databases
--02. Find All Information About Departments
USE [SoftUni]

SELECT * FROM [dbo].[Departments]

--03. Find All Department Names
USE [SoftUni]

SELECT [Name] FROM [dbo].[Departments]

--04. Find Salary of Each Employee
USE [SoftUni]

SELECT [FirstName], [LastName], [Salary] FROM [dbo].[Employees]

--05. Find Full Name of Each Employee
USE [SoftUni]

SELECT [FirstName], [MiddleName], [LastName] FROM [dbo].[Employees]

--06. Find Email Address of Each Employee
USE [SoftUni]

SELECT CONCAT([FirstName], '.', [LastName], '@softuni.bg') AS [Full Email Address] FROM [dbo].[Employees]

--07. Find All Different Employee's Salaries
USE [SoftUni]

SELECT DISTINCT [Salary] FROM [dbo].[Employees]

--08. Find All Information About Employees
USE [SoftUni]

SELECT * FROM [dbo].[Employees]
WHERE [JobTitle] = 'Sales Representative'

--09. Find Names of All Employees by Salary in Range
USE [SoftUni]

SELECT [FirstName], [LastName], [JobTitle] FROM [dbo].[Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

--10. Find Names of All Employees 
USE [SoftUni]

SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name] FROM [dbo].[Employees]
WHERE [Salary] = 12500 OR [Salary] = 14000 OR [Salary] = 23600 OR [Salary] = 25000
 
--11. Find All Employees Without Manager
USE [SoftUni]

SELECT [FirstName], [LastName] FROM [dbo].[Employees]
WHERE [ManagerID] IS NULL

--12. Find All Employees with Salary More Than 50000
USE [SoftUni]

SELECT [FirstName], [LastName], [Salary] FROM [dbo].[Employees]
WHERE [Salary] > 50000 
ORDER BY [Salary] DESC

--13. Find 5 Best Paid Employees.
USE [SoftUni]

SELECT TOP (5) [FirstName], [LastName] FROM [dbo].[Employees]
ORDER BY [Salary] DESC

--14. Find All Employees Except Marketing
USE [SoftUni]

SELECT [FirstName], [LastName] FROM [dbo].[Employees]
WHERE NOT [DepartmentID] = 4

--15. Sort Employees Table
USE [SoftUni]

SELECT * FROM [dbo].[Employees]
ORDER BY [Salary] DESC, [FirstName], [LastName] DESC, [MiddleName]

--16. Create View Employees with Salaries
USE [SoftUni]

CREATE VIEW [v_EmployeesSalaries] AS
SELECT [FirstName], [LastName], [Salary] FROM [dbo].[Employees]

--17. Create View Employees with Job Titles
USE [SoftUni]

CREATE VIEW [v_EmployeeNameJobTitle] AS
SELECT CONCAT([FirstName], ' ', ISNULL([MiddleName], NULL), ' ', [LastName]) AS [Full Name], [JobTitle] AS [Job Title] FROM [dbo].[Employees]

--18. Distinct Job Titles
USE [SoftUni]

SELECT DISTINCT [JobTitle] FROM [dbo].[Employees]

--19. Find First 10 Started Projects
USE [SoftUni]

SELECT TOP (10) * FROM [dbo].[Projects]
ORDER BY [StartDate], [Name]

--20. Last 7 Hired Employees
USE [SoftUni]

SELECT TOP (7) [FirstName], [LastName], [HireDate] FROM [dbo].[Employees]
ORDER BY [HireDate] DESC

--21. Increase Salaries
USE [SoftUni]

UPDATE [dbo].[Employees]
SET [Salary] *= 1.12
WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary] FROM [dbo].[Employees]

UPDATE [dbo].[Employees]
SET [Salary] /= 1.12
WHERE [DepartmentID] IN (1, 2, 4, 11)

--22. All Mountain Peaks
USE [Geography]

SELECT [PeakName] FROM [dbo].[Peaks]
ORDER BY [PeakName]

--23. Biggest Countries by Population
USE [Geography]

SELECT TOP (30) [CountryName], [Population] FROM [dbo].[Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC

--24. *Countries and Currency (Euro / Not Euro)
USE [Geography]

SELECT [CountryName], [CountryCode], CASE
	WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
END AS [Currency]
FROM [dbo].[Countries]
ORDER BY [CountryName]

--25. All Diablo Characters
USE [Diablo]

SELECT [Name] FROM [dbo].[Characters]
ORDER BY [Name] 