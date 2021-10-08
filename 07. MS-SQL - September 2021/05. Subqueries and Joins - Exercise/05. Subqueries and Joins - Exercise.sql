--01. Employee Address
USE [SoftUni]

SELECT TOP (5) e.[EmployeeID], e.[JobTitle], e.[AddressID], a.[AddressText] FROM [dbo].[Employees] AS e
	LEFT JOIN [dbo].[Addresses] AS a ON a.[AddressID] = e.[AddressID]
ORDER BY e.[AddressID]

--02. Addresses with Towns
USE [SoftUni]

SELECT TOP (50) e.[FirstName], e.[LastName], t.[Name] AS [Town], a.[AddressText] FROM [dbo].[Employees] AS e
	LEFT JOIN [dbo].[Addresses] AS a ON a.[AddressID] = e.[AddressID]
	LEFT JOIN [dbo].[Towns] AS t ON t.[TownID] = a.[TownID]
ORDER BY e.[FirstName], e.[LastName]

--03. Sales Employees
USE [SoftUni]

SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name] AS [DepartmentName] FROM [dbo].[Employees] AS e
	JOIN [dbo].[Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID] 

--04. Employee Departments
USE [SoftUni]

SELECT TOP (5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name] AS [DepartmentName] FROM [dbo].[Employees] AS e
	JOIN [dbo].[Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
WHERE e.[Salary] > 15000
ORDER BY e.[DepartmentID]

--05. Employees Without Projects
USE [SoftUni]

SELECT TOP (3) e.[EmployeeID], e.[FirstName] FROM [dbo].[Employees] AS e
	LEFT JOIN [dbo].[EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
WHERE ep.[ProjectID] IS NULL
ORDER BY e.[EmployeeID]

--06. Employees Hired After
USE [SoftUni]

SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS [DeptName] FROM [dbo].[Employees] AS e
	JOIN [dbo].[Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
WHERE e.[HireDate] > '1999-01-01' AND [Name] = 'Sales' OR [Name] = 'Finance'
ORDER BY e.[HireDate]

--07. Employees With Project
USE [SoftUni]

SELECT TOP (5) e.[EmployeeID], e.[FirstName], p.[Name] AS [ProjectName] FROM [dbo].[Employees] AS e
	JOIN [dbo].[EmployeesProjects] ep ON ep.[EmployeeID] = e.[EmployeeID]
	JOIN [dbo].[Projects] AS p ON p.[ProjectID] = ep.[ProjectID]
WHERE p.[StartDate] > '2002-08-13' AND p.[StartDate] IS NOT NULL
ORDER BY e.[EmployeeID]

--08. Employee 24
USE [SoftUni]

SELECT TOP (5) e.[EmployeeID], e.[FirstName], CASE 
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.[Name] 
	END AS [ProjectName] 
FROM [dbo].[Employees] AS e
	JOIN [dbo].[EmployeesProjects] ep ON ep.[EmployeeID] = e.[EmployeeID]
	JOIN [dbo].[Projects] AS p ON p.[ProjectID] = ep.[ProjectID]
WHERE e.[EmployeeID] = 24 

--09. Employee Manager
USE [SoftUni]

SELECT e.[EmployeeID], e.[FirstName], e.[ManagerID], m.[FirstName] AS [ManagerName] FROM [dbo].[Employees] AS e
	LEFT JOIN [dbo].[Employees] AS m ON m.[EmployeeID] = e.[ManagerID]
WHERE e.[ManagerID] = 3 OR e.[ManagerID] = 7
ORDER BY e.[EmployeeID]

--10. Employees Summary
USE [SoftUni]

SELECT TOP (50) e.[EmployeeID], CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName], CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName], d.[Name] AS [DepartmentName] FROM [dbo].[Employees] AS e
	LEFT JOIN [dbo].[Employees] AS m ON m.[EmployeeID] = e.[ManagerID]
	JOIN [dbo].[Departments] AS d ON d.[DepartmentID] = e.[DepartmentID]
ORDER BY e.[EmployeeID]

--11. Min Average Salary
USE [SoftUni]
   
SELECT MIN(a.[AverageSalary]) AS [MinAverageSalary] FROM 
	(SELECT AVG(e.[Salary]) AS [AverageSalary] FROM [dbo].[Employees] AS e 
	GROUP BY e.[DepartmentID]) AS a

--12. Highest Peaks in Bulgaria
USE [Geography]

SELECT mc.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation] FROM [dbo].[Peaks] AS p
	JOIN [dbo].[MountainsCountries] AS mc ON mc.[MountainId] = p.[MountainId]
	JOIN [dbo].[Mountains] AS m ON m.[Id] = mc.[MountainId]
WHERE mc.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

--13. Count Mountain Ranges
USE [Geography]

SELECT mc.[CountryCode], COUNT (*) AS [MountainRanges] FROM [dbo].[Mountains] AS m
	JOIN [dbo].[MountainsCountries] AS mc ON mc.[MountainId] = m.[Id]
WHERE mc.[CountryCode] = 'BG' OR mc.[CountryCode] = 'RU' OR mc.[CountryCode] = 'US'
GROUP BY mc.[CountryCode] 

--14. Countries With or Without Rivers
USE [Geography]

SELECT TOP (5) c.[CountryName], r.[RiverName] FROM [dbo].[Rivers] AS r
	RIGHT JOIN [dbo].[CountriesRivers] AS cr ON cr.[RiverId] = r.[Id]
	RIGHT JOIN [dbo].[Countries] AS c ON c.[CountryCode] = cr.[CountryCode]
WHERE c.[ContinentCode] = 'AF'
ORDER BY c.[CountryName] 

--15. *Continents and Currencies
USE [Geography]

SELECT [ContinentCode], [CurrencyCode], [CurrencyCount] AS [CurrencyUsage] FROM
	(SELECT *, DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) AS [CurrencyRank] FROM
		(SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyCount] FROM [dbo].[Countries]
		GROUP BY [ContinentCode], [CurrencyCode]) AS [CurrencyCountSubQuery]
	WHERE [CurrencyCount] > 1) AS [CurrencyRankingSubQuery]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]

--16. Countries Without any Mountains
USE [Geography]

SELECT COUNT(*) FROM [dbo].[Countries] AS c
	LEFT JOIN [dbo].[MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
WHERE mc.[MountainId] IS NULL

--17. Highest Peak and Longest River by Country
USE [Geography]

SELECT TOP (3) c.[CountryName], MAX(p.[Elevation]) AS [HighestPeakElevation], MAX(r.[Length]) AS [LongestRiverLength] FROM [dbo].[Countries] AS c
	LEFT JOIN [dbo].[MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
	LEFT JOIN [dbo].[Mountains] AS m ON m.[Id] = mc.[MountainId]
	LEFT JOIN [dbo].[Peaks] AS p ON p.[MountainId] = m.[Id]
	LEFT JOIN [dbo].[CountriesRivers] AS cr ON cr.[CountryCode] = c.[CountryCode]
	LEFT JOIN [dbo].[Rivers] AS r ON r.[Id] = cr.[RiverId]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]

--18. *Highest Peak Name and Elevation by Country
USE [Geography]

SELECT TOP (5)
	[CountryName] AS [Country],
	ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
	ISNULL([Elevation], 0) AS [Highest Peak Elevation],
	ISNULL([MountainRange], '(no mountain)') AS [Highest Peak Elevation]
	FROM (SELECT c.[CountryName], p.[PeakName], p.[Elevation], m.[MountainRange], DENSE_RANK() OVER (PARTITION BY [CountryName] ORDER BY [Elevation] DESC) AS [ElevationRank]
		FROM [dbo].[Countries] AS c
		LEFT JOIN [dbo].[MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
		LEFT JOIN [dbo].[Mountains] AS m ON m.[Id] = mc.[MountainId]
		LEFT JOIN [dbo].[Peaks] AS p ON p.[MountainId] = m.[Id]
	GROUP BY c.[CountryName], p.[PeakName], p.[Elevation], m.[MountainRange]) AS [ElevationRanking]
WHERE [ElevationRank] = 1
ORDER BY [CountryName], [Highest Peak Name]
