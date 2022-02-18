--01. DDL
CREATE DATABASE [WMS]

USE [WMS]

CREATE TABLE [Clients]
(
	[ClientId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Phone] CHAR(12) NOT NULL
)

CREATE TABLE [Mechanics]
(
	[MechanicId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Models]
(
	[ModelId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Jobs]
(
	[JobId] INT PRIMARY KEY IDENTITY,
	[ModelId] INT FOREIGN KEY REFERENCES [dbo].[Models]([ModelId]) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending',
		CHECK([Status] IN ('Pending', 'In Progress', 'Finished')),
	[ClientId] INT FOREIGN KEY REFERENCES [dbo].[Clients]([ClientId]) NOT NULL,
	[MechanicId] INT FOREIGN KEY REFERENCES [dbo].[Mechanics]([MechanicId]),
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE
)

CREATE TABLE [Orders]
(
	[OrderId] INT PRIMARY KEY IDENTITY,
	[JobId] INT FOREIGN KEY REFERENCES [dbo].[Jobs]([JobId]) NOT NULL,
	[IssueDate] DATE,
	[Delivered] BIT DEFAULT 0
)

CREATE TABLE [Vendors]
(
	[VendorId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Parts]
(
	[PartId] INT PRIMARY KEY IDENTITY,
	[SerialNumber] VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	[Price] DECIMAL(6,2) NOT NULL,
		CHECK([Price] > 0),
	[VendorId] INT FOREIGN KEY REFERENCES [dbo].[Vendors]([VendorId]) NOT NULL,
	[StockQty] INT DEFAULT 0,
		CHECK([StockQty] >= 0)
)

CREATE TABLE [OrderParts]
(
	[OrderId] INT FOREIGN KEY REFERENCES [dbo].[Orders]([OrderId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [dbo].[Parts]([PartId]) NOT NULL,
	PRIMARY KEY([OrderId], [PartId]),
	[Quantity] INT DEFAULT 1,
		CHECK([Quantity] >= 0) 
)

CREATE TABLE [PartsNeeded]
(
	[JobId] INT FOREIGN KEY REFERENCES [dbo].[Jobs]([JobId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [dbo].[Parts]([PartId]) NOT NULL,
	PRIMARY KEY([JobId], [PartId]),
	[Quantity] INT DEFAULT 1,
		CHECK([Quantity] >= 0) 
)

--02. Insert
USE [WMS]

INSERT INTO [dbo].[Clients]([FirstName], [LastName], [Phone]) VALUES
	('Teri', 'Ennaco', '570-889-5187'),
	('Merlyn', 'Lawler', '201-588-7810'),
	('Georgene', 'Montezuma', '925-615-5185'),
	('Jettie', 'Mconnell', '908-802-3564'),
	('Lemuel', 'Latzke', '631-748-6479'),
	('Melodie', 'Knipp', '805-690-1682'),
	('Candida', 'Corbley', '908-275-8357')

INSERT INTO [dbo].[Parts]([SerialNumber], [Description], [Price], [VendorId]) VALUES
	('WP8182119', 'Door Boot Seal', 117.86, 2),
	('W10780048', 'Suspension Rod', 42.81, 1),
	('W10841140', 'Silicone Adhesive', 6.77, 4),
	('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--03. Update
USE [WMS]

UPDATE [dbo].[Jobs]
SET [MechanicId] = 3, [Status] = 'In Progress'
WHERE [Status] = 'Pending'

--04. Delete
USE [WMS]

DELETE FROM [dbo].[OrderParts] WHERE [OrderId] = 19

DELETE FROM [dbo].[Orders] WHERE [OrderId] = 19

--05. Mechanic Assignments
USE [WMS]

SELECT 
	CONCAT(m.[FirstName], ' ', m.[LastName]) AS [Mechanic], 
	j.[Status], 
	j.[IssueDate] 
FROM [dbo].[Mechanics] AS m
	LEFT JOIN [dbo].[Jobs] AS j ON j.[MechanicId] = m.[MechanicId]
ORDER BY m.[MechanicId], j.[IssueDate], j.[JobId]

--06. Current Clients
USE [WMS]

SELECT 
	CONCAT(c.[FirstName], ' ', c.[LastName]) AS [Client], 
	DATEDIFF(DAY, j.[IssueDate], '2017-04-24') AS [Days going], 
	j.[Status] 
FROM [dbo].[Clients] AS c
	LEFT JOIN [dbo].[Jobs] AS j ON j.[ClientId] = c.[ClientId]
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.[ClientId]

--07. Mechanic Performance
USE [WMS]

SELECT 
	CONCAT(m.[FirstName], ' ', m.[LastName]) AS [Mechanic], 
	AVG(DATEDIFF(DAY, j.[IssueDate], j.[FinishDate])) AS [Average Days]
FROM [dbo].[Mechanics] AS m
	LEFT JOIN [dbo].[Jobs] AS j ON j.[MechanicId] = m.[MechanicId]
GROUP BY m.[MechanicId], m.[FirstName], m.[LastName]
ORDER BY m.[MechanicId]

--08. Available Mechanics
USE [WMS]

SELECT CONCAT([FirstName], ' ' + [LastName]) AS [Available] FROM [dbo].[Mechanics]
WHERE [MechanicId] NOT IN
	(SELECT DISTINCT m.[MechanicId] FROM [dbo].[Mechanics] AS m
			JOIN [dbo].[Jobs] AS j ON j.[MechanicId] = m.[MechanicId]
	WHERE j.[Status] != 'Finished')
ORDER BY [MechanicId]

--09. Past Expenses
USE [WMS]

SELECT j.[JobId], ISNULL(SUM(p.[Price] * op.[Quantity]), 0.00) AS [Total] FROM [dbo].[Jobs] AS j
	LEFT JOIN [dbo].[Orders] AS o ON o.[JobId] = j.[JobId]
	LEFT JOIN [dbo].[OrderParts] AS op ON op.[OrderId] = o.[OrderId]
	LEFT JOIN [dbo].[Parts] AS p ON p.[PartId] = op.[PartId]
WHERE j.[Status] = 'Finished'
GROUP BY j.[JobId]
ORDER BY [Total] DESC, j.[JobId]

--10. Missing Parts
USE [WMS]

SELECT * FROM
	(SELECT 
		p.[PartId], 
		p.[Description], 
		SUM(pn.[Quantity]) AS [Required], 
		SUM(p.[StockQty]) AS [In Stock],
		IIF(o.[Delivered] = 0, SUM(op.[Quantity]), 0) AS [Ordered]
		--CASE 
		--	WHEN o.[Delivered] = 0 THEN SUM(op.[Quantity])
		--	ELSE 0
		--END AS [Ordered]
	FROM [dbo].[Parts] AS p
		LEFT JOIN [dbo].[PartsNeeded] AS pn ON pn.[PartId] = p.[PartId]
		LEFT JOIN [dbo].[Jobs] AS j ON pn.[JobId] = j.[JobId]
		LEFT JOIN [dbo].[OrderParts] AS op ON op.[PartId] = p.[PartId]
		LEFT JOIN [dbo].[Orders] AS o ON o.[OrderId] = op.[OrderId]
	WHERE j.[Status] != 'Finished' 
	GROUP BY p.[PartId], p.[Description], o.[Delivered]) AS [Parts Query]
GROUP BY [PartId], [Description], [Required], [In Stock], [Ordered]
HAVING SUM([In Stock] + [Ordered]) < [Required]  
--I am led to believe that there is a problem with the problem description as there the value for PartId [11, Water Inlet Valve, 3, 0, 0] is missing when it meets the given conditions (I checked manually)

--11. Place Order
USE [WMS]

GO

CREATE OR ALTER PROC [usp_PlaceOrder] (@JobId INT, @PartSerialNumber VARCHAR(11), @Quantity INT)
AS BEGIN
	IF (@Quantity <= 0)
	THROW 50012, 'Part quantity must be more than zero!', 1

	IF (@JobId IN ((SELECT [JobId] FROM [dbo].[Jobs] WHERE [Status] = 'Finished')))
	THROW 50011 ,'This job is not active!', 1

	IF (@JobId NOT IN (SELECT [JobId] FROM [dbo].[Jobs]))
	THROW 50013, 'Job not found!', 1

	IF (@PartSerialNumber NOT IN (SELECT [SerialNumber] FROM [dbo].[Parts]))
	THROW 50014, 'Part not found!', 1

	IF (@JobId IN (SELECT [JobId] FROM [dbo].[Jobs]) AND 
		(SELECT [IssueDate] FROM [dbo].[Orders] WHERE [JobId] = @JobId) IS NULL)
	BEGIN
		DECLARE @OrderId INT = (SELECT [OrderId] FROM [dbo].[Orders] WHERE [JobId] = @JobID AND [IssueDate] IS NULL)
		DECLARE @PartId INT = (SELECT [PartId] FROM [dbo].[Parts] WHERE [SerialNumber] = @PartSerialNumber)
		IF (@OrderId IN (SELECT [OrderId] FROM Orders) AND @PartId IN (SELECT [PartId] FROM [dbo].[OrderParts]))
			BEGIN
				UPDATE [dbo].[OrderParts]
				SET [Quantity] += @Quantity
				WHERE [OrderId] = @OrderId AND [PartId] = @PartId
			END
		ELSE
		BEGIN 
			INSERT INTO [dbo].[OrderParts]([OrderId], [PartId], [Quantity]) VALUES 
				(@OrderId, @PartId, @Quantity)
		END
	END
END
GO

EXEC [dbo].[usp_PlaceOrder] 1, 'ZeroQuantity', 0

--12. Cost of Order
USE [WMS]

GO

CREATE OR ALTER FUNCTION [udf_GetCost](@JobId INT)
RETURNS DECIMAL(18,2)
AS BEGIN
	RETURN (SELECT ISNULL(SUM(p.[Price] * op.[Quantity]), 0) FROM [dbo].[Jobs] AS j 
		LEFT JOIN [dbo].[Orders] AS o ON o.[JobId] = j.[JobId]
		LEFT JOIN [dbo].[OrderParts] AS op ON op.[OrderId] = o.[OrderId]
		LEFT JOIN [dbo].[Parts] AS p ON p.[PartId] = op.[PartId]
	WHERE j.[JobId] = @JobId
	GROUP BY j.[JobId])
END
GO

SELECT [dbo].[udf_GetCost](1)
SELECT [dbo].[udf_GetCost](3)