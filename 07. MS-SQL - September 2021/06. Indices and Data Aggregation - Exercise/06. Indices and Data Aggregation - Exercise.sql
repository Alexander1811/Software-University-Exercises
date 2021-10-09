--01. Records’ Count
USE [Gringotts]

SELECT COUNT(*) AS [Count] FROM [dbo].[WizzardDeposits]

--02. Longest Magic Wand
USE [Gringotts]

SELECT MAX([MagicWandSize]) AS [LongestMagicWand] FROM [dbo].[WizzardDeposits]

--03. Longest Magic Wand per Deposit Groups
USE [Gringotts]

SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand] FROM [dbo].[WizzardDeposits]
GROUP BY [DepositGroup]

--04. *Smallest Deposit Group per Magic Wand Size
USE [Gringotts]

SELECT TOP (2) [DepositGroup] FROM [dbo].[WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize])

--05. Deposits Sum
USE [Gringotts]

SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [dbo].[WizzardDeposits]
GROUP BY [DepositGroup]

--06. Deposits Sum for Ollivander Family
USE [Gringotts]

SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [dbo].[WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--07. Deposits Filter
USE [Gringotts]

SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum] FROM [dbo].[WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

--08. Deposit Charge
USE [Gringotts]

SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS [MinDepositCharge] FROM [dbo].[WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

--09. Age Groups
USE [Gringotts]

SELECT [AgeGroup], COUNT(*) AS [WizardCount] FROM 
	(SELECT CASE
		WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
		END AS [AgeGroup] 
	FROM [dbo].[WizzardDeposits]) AS [AgeGroupsSubQuery]
GROUP BY [AgeGroup]

--10. First Letter
USE [Gringotts]

SELECT DISTINCT SUBSTRING([FirstName], 1, 1) AS [FirstLetter] FROM [dbo].[WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY [DepositGroup], [FirstName]

--11. Average Interest
USE [Gringotts]

SELECT [DepositGroup], [IsDepositExpired], AVG([DepositInterest]) AS [AveargeInterest] FROM [dbo].[WizzardDeposits]
WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--12. *Rich Wizard, Poor Wizard
USE [Gringotts]

SELECT SUM(b.[DepositAmount] - a.[DepositAmount]) AS [SumDifference] FROM [dbo].[WizzardDeposits] AS a
	JOIN [dbo].[WizzardDeposits] AS b ON b.[Id] = a.[Id] - 1

--13. Departments Total Salaries
USE [SoftUni]

SELECT [DepartmentID], SUM([Salary]) AS [TotalSalary] FROM [dbo].[Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14. Employees Minimum Salaries
USE [SoftUni]

SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary] FROM [dbo].[Employees]
WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '2000-01-01'
GROUP BY [DepartmentID]

--15. Employees Average Salaries
USE [SoftUni]

SELECT * INTO [dbo].[EmployeesWithSalaryHigherThan30000] FROM [dbo].[Employees]
WHERE [Salary] > 30000

DELETE FROM [dbo].[EmployeesWithSalaryHigherThan30000]
WHERE [ManagerID] = 42

UPDATE [dbo].[EmployeesWithSalaryHigherThan30000]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary] FROM [dbo].[EmployeesWithSalaryHigherThan30000]
GROUP BY [DepartmentID]

--16. Employees Maximum Salaries
USE [SoftUni]

SELECT [DepartmentID], MAX([Salary]) AS [MaxSalary] FROM [dbo].[Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries
USE [SoftUni]

SELECT COUNT([Salary]) AS [Count] FROM [dbo].[Employees]
WHERE [ManagerID] IS NULL

--18. *3rd Highest Salary
USE [SoftUni]

SELECT [DepartmentID], [Salary] AS [ThirdHighestSalary] FROM 
	(SELECT [DepartmentID], [Salary], DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [SalaryRank] FROM [dbo].[Employees]
	GROUP BY [DepartmentID], [Salary]) AS [SalaryRanking]
WHERE [SalaryRank] = 3

--19. **Salary Challenge
USE [SoftUni]

SELECT TOP (10) e.[FirstName], e.[LastName], e.[DepartmentID] FROM [dbo].[Employees] AS e
WHERE [Salary] > (SELECT AVG([Salary]) 
		FROM [dbo].[Employees] AS edept
		WHERE edept.[DepartmentID] = e.[DepartmentID]
		GROUP BY [DepartmentID])
ORDER BY [DepartmentID]