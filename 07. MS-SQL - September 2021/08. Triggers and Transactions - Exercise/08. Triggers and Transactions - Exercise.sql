--01. Create Table Logs
USE [Bank]

CREATE TABLE Logs
(
	[LogId] INT PRIMARY KEY IDENTITY NOT NULL,
	[AccountId] INT REFERENCES [dbo].[Accounts](Id) NOT NULL,
	[OldSum] DECIMAL(12,2) NOT NULL,
	[NewSum] DECIMAL(12,2) NOT NULL
)

GO

CREATE OR ALTER TRIGGER [tr_AccountsChanges] ON [dbo].[Accounts] 
FOR UPDATE
AS
	DECLARE @AccountId INT = (SELECT [Id] FROM [inserted])
	DECLARE @NewSum DECIMAL(12,2) = (SELECT [Balance] FROM [inserted])
	DECLARE @OldSum DECIMAL(12,2) = (SELECT [Balance] FROM [deleted])

	INSERT INTO [dbo].[Logs]([AccountId], [NewSum], [OldSum]) VALUES
		(@AccountId, @NewSum, @OldSum)
GO

--02. Create Table Emails
USE [Bank]

CREATE TABLE [NotificationEmails]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Recipient] INT REFERENCES [Accounts](Id) NOT NULL,
	[Subject] NVARCHAR(MAX) NOT NULL,
	[Body] NVARCHAR(MAX) NOT NULL
)

GO

CREATE OR ALTER TRIGGER [tr_NotificationForNewEmail] ON [dbo].[Logs]
FOR INSERT
AS
	DECLARE @recipient INT = (SELECT [AccountId] FROM [inserted])
	DECLARE @balance NVARCHAR(MAX) = (SELECT 'Balance change for account:' + CAST([AccountId] AS nvarchar) FROM [inserted])
	DECLARE @body NVARCHAR(MAX) = (SELECT 'On ' + CAST(GETDATE() as nvarchar)+ ' your balance was changed from ' + CAST([OldSum] as nvarchar) + ' to ' + CAST([NewSum] AS nvarchar) FROM [inserted])

	INSERT INTO [dbo].[NotificationEmails] ([Recipient], [Subject], [Body]) VALUES
		(@recipient, @balance, @body)
GO

UPDATE [dbo].[Accounts]
SET [Balance] += 30
WHERE [Id] = 1

SELECT * FROM [dbo].[Logs]
SELECT * FROM [dbo].[NotificationEmails]

--03. Deposit Money
USE [Bank]

GO

CREATE OR ALTER PROC [usp_DepositMoney] (@AccountId INT, @MoneyAmount DECIMAL(12,4))
AS
BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
	THROW 50001, 'Can`t make transaction with negative number!', 1
	IF @AccountId = 0
	THROW 50002, 'There is no customer with that id!', 1
	
	UPDATE [dbo].[Accounts] 
	SET [Balance] += @MoneyAmount
	WHERE [Id] = @AccountId
COMMIT
GO

SELECT * FROM [dbo].[Accounts]
WHERE [Id] = 1

EXEC [dbo].[usp_DepositMoney] 1,100

--04. Withdraw Money Procedure
USE [Bank]

GO

CREATE OR ALTER PROC [usp_WithdrawMoney] (@AccountId INT, @MoneyAmount DECIMAL(12,4))
AS
	BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
	THROW 50001, 'Can`t make transaction with negative number!', 1
	IF @AccountId = 0
	THROW 50002, 'There is no customer with that id!', 1
	UPDATE [Accounts] 
	SET [Balance] -= @MoneyAmount
	WHERE [Id] = @AccountId
COMMIT
GO

EXEC [usp_WithdrawMoney] 5, 25

--05. Money Transfer
USE [Bank]

GO

CREATE OR ALTER PROC [usp_TransferMoney] (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(12,4))
AS
BEGIN TRANSACTION
	EXEC [usp_DepositMoney] @SenderId, @Amount
	EXEC [usp_WithdrawMoney] @ReceiverId, @Amount
COMMIT
GO

EXEC [dbo].[usp_TransferMoney] 5, 1, 5000

--06. *Massive Shopping
--07. Employees with Three Projects
USE [SoftUni]

GO

CREATE OR ALTER PROC [usp_AssignProject] (@EmployeeId INT, @ProjectId INT)
AS
BEGIN
	DECLARE @maxEmployeeProjectsCount INT = 3
	DECLARE @employeeProjectsCount INT = (SELECT COUNT(*) FROM [dbo].[EmployeesProjects] WHERE [EmployeeID] = @EmployeeID)

	IF (@employeeProjectsCount >= @maxEmployeeProjectsCount)
		THROW 50001, 'The employee has too many projects!', 1

	INSERT INTO [dbo].[EmployeesProjects] ([EmployeeID], [ProjectID])
		VALUES (@EmployeeId, @ProjectId)
END
GO

--08. Delete Employees
USE [SoftUni]

GO

CREATE TABLE [Deleted_Employees]
(
	[EmployeeId] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(50),
	[MiddleName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[JobTitle] NVARCHAR(50),
	[DepartmentId] INT FOREIGN KEY REFERENCES [dbo].[Departments](DepartmentId),
	[Salary] MONEY
)

GO

CREATE OR ALTER TRIGGER [tr_DeleteEmployees] ON [dbo].[Employees] 
FOR DELETE
AS
	INSERT INTO [dbo].[Deleted_Employees]
		([FirstName],[LastName],[MiddleName],[JobTitle],[DepartmentId],[Salary])
	SELECT
		[FirstName],[LastName],[MiddleName],[JobTitle],[DepartmentId],[Salary]
	FROM deleted