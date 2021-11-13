--01. Employees with Salary Above 35000
USE [SoftUni]

GO

CREATE OR ALTER PROC [usp_GetEmployeesSalaryAbove35000]
AS BEGIN
	SELECT [FirstName], [LastName] FROM [dbo].[Employees]
	WHERE [Salary] > 35000
END
GO

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

--02. Employees with Salary Above Number
USE [SoftUni]

GO

CREATE OR ALTER PROC [usp_GetEmployeesSalaryAboveNumber] (@minSalary DECIMAL(18,4))
AS BEGIN
	SELECT [FirstName], [LastName] FROM [dbo].[Employees]
	WHERE [Salary] >= @minSalary
END
GO

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100

--03. Town Names Starting With
USE [SoftUni]

GO

CREATE OR ALTER PROC [usp_GetTownsStartingWith] (@string VARCHAR(50))
AS BEGIN
SELECT [Name] AS [Town] FROM [dbo].[Towns]
	WHERE SUBSTRING(LOWER([Name]), 1, LEN(@string)) = LOWER(@string)
END
GO

EXEC [dbo].[usp_GetTownsStartingWith] 'b'

--04. Employees from Town
USE [SoftUni]

GO

CREATE OR ALTER PROC [usp_GetEmployeesFromTown] (@townName VARCHAR(50))
AS BEGIN
	SELECT e.[FirstName], e.[LastName] FROM [dbo].[Employees] AS e
		JOIN [dbo].[Addresses] AS a ON a.[AddressID] = e.[AddressID]
		JOIN [dbo].[Towns] AS t ON t.[TownID] = a.[TownID]
	WHERE t.[Name] = @townName
END
GO

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia'

--05. Salary Level Function
USE [SoftUni]

GO

CREATE OR ALTER FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS BEGIN
	IF @salary IS NULL
		RETURN NULL
	IF @salary < 30000
		RETURN 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000
		RETURN 'Average'
	RETURN 'High'
END
GO

SELECT [Salary], [dbo].[ufn_GetSalaryLevel]([Salary]) AS [SalaryLevel] FROM [dbo].[Employees]

--06. Employees by Salary Level
USE [SoftUni]

GO

CREATE OR ALTER PROC [usp_EmployeesBySalaryLevel] (@salaryLevel VARCHAR(7))
AS BEGIN
	SELECT [FirstName], [LastName] FROM 
		(SELECT [FirstName], [LastName], [dbo].[ufn_GetSalaryLevel]([Salary]) AS [SalaryLevel] FROM [dbo].[Employees]) AS [SalaryLevelSubQuery]
	WHERE [SalaryLevel] = @salaryLevel
END
GO

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'high'

--07. Define Function
USE [SoftUni]

GO

CREATE OR ALTER FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS BEGIN
	DECLARE @countOfLetters INT = LEN(@word)
	DECLARE @index INT = 1

	WHILE @index <= @countOfLetters
		BEGIN
		IF(CHARINDEX(SUBSTRING(@word, @index, 1), @setOfLetters) = 0)
			BEGIN
				RETURN 0
			END
			SET @index += 1
		END
		RETURN 1
END
GO

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia') AS [Result]
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'halves') AS [Result]

--08. *Delete Employees and Departments
USE [SoftUni]

GO

CREATE OR ALTER PROC [usp_DeleteEmployeesFromDepartment] (@departmentId INT) 
AS BEGIN
	--Remove or set to NULL all foreign keys to other tables from [dbo].[Employees] so as to remove all employees from the given department
	DELETE FROM [dbo].[EmployeesProjects]
	WHERE [EmployeeID] IN
		(SELECT [EmployeeID] FROM [dbo].[Employees] 
		WHERE [DepartmentId] = @departmentId)

	UPDATE [dbo].[Employees]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN
		(SELECT [EmployeeID] FROM [dbo].[Employees]
		WHERE [DepartmentId] = @departmentId)

	ALTER TABLE [dbo].[Departments]
	ALTER COLUMN [ManagerID] INT NULL

	UPDATE [dbo].[Departments]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN
		(SELECT [EmployeeID] FROM [dbo].[Employees]
		WHERE [DepartmentId] = @departmentId)

	--Then, remove all employees from said department
	DELETE FROM [dbo].[Employees]
	WHERE [DepartmentID] = @departmentId

	--Thereafter, remove the department
	DELETE FROM [dbo].[Departments]
	WHERE [DepartmentID] = @departmentId

	--Finally, visualize the number of remaining employees in the department (should be 0)
	SELECT COUNT(*) AS [Remaining Employees] FROM [dbo].[Employees]
	WHERE [DepartmentID] = @departmentId 
END
GO

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 4

--09. Find Full Name
USE [Bank]

GO

CREATE OR ALTER PROC [usp_GetHoldersFullName]
AS BEGIN
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [Full Name] FROM [dbo].[AccountHolders]
END
GO

EXEC [dbo].[usp_GetHoldersFullName]

--10. People with Balance Higher Than
USE [Bank]

GO

CREATE OR ALTER PROC [usp_GetHoldersWithBalanceHigherThan] (@minMoney DECIMAL(18,4))
AS BEGIN
	SELECT ah.[FirstName], ah.[LastName] FROM [dbo].[AccountHolders] AS ah
		JOIN [dbo].[Accounts] AS a ON a.[AccountHolderId] = ah.[Id]
	GROUP BY ah.[FirstName], ah.[LastName]
	HAVING SUM(a.[Balance]) > @minMoney
	ORDER BY ah.[FirstName], ah.[LastName]
END
GO

EXEC [dbo].[usp_GetHoldersWithBalanceHigherThan] 10000

--11. Future Value Function
USE [Bank]

GO

CREATE OR ALTER FUNCTION [ufn_CalculateFutureValue](@sum DECIMAL(18,4), @interestRate FLOAT, @years INT) 
RETURNS DECIMAL(18,4)
AS BEGIN
	RETURN @sum * POWER(1 + @interestRate, @years)
END
GO

SELECT [dbo].[ufn_CalculateFutureValue] (1000, 0.1, 5) AS [Output]

--12. Calculating Interest
USE [Bank]

GO

CREATE OR ALTER PROC [usp_CalculateFutureValueForAccount] (@accountId INT, @interestRate FLOAT)  
AS BEGIN
	SELECT 
		ah.[Id] AS [Account Id], 
		ah.[FirstName] AS [First Name], 
		ah.[LastName] AS [Last Name], 
		a.[Balance] AS [Current Balance], 
		[dbo].[ufn_CalculateFutureValue](a.[Balance], @interestRate, 5) AS [Balance in 5 years] 
	FROM [dbo].[AccountHolders] AS ah
		JOIN [dbo].[Accounts] AS a ON a.[AccountHolderId] = ah.[Id]
	WHERE a.[AccountHolderId] = @accountId
END
GO

EXEC [usp_CalculateFutureValueForAccount] 1, 0.1

--13. *Cash in User Games Odd Rows
USE [Diablo]

GO
   
CREATE OR ALTER FUNCTION [ufn_CashInUsersGames](@gameName NVARCHAR(50))
RETURNS TABLE
AS RETURN 
		(SELECT SUM([Row Ranking].[Cash]) AS [SumCash] FROM 
			(SELECT ug.[Cash] AS [Cash], ROW_NUMBER() OVER (ORDER BY ug.[Cash] DESC) AS [Row Number]
			FROM [dbo].[UsersGames] AS ug
				JOIN [dbo].[Games] AS g ON g.[Id] = ug.[GameId]
			WHERE g.[Name] = @gameName) AS [Row Ranking]
		WHERE [Row Ranking].[Row Number] % 2 = 1) 
GO

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist') AS [Result]