--01. DDL
CREATE DATABASE [TripService]

USE [TripService]

CREATE TABLE [Cities]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	[CountryCode] VARCHAR(2) NOT NULL
)

CREATE TABLE [Hotels]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[CityId] INT FOREIGN KEY REFERENCES [dbo].[Cities]([Id]) NOT NULL,
	[EmployeeCount] INT NOT NULL,
	[BaseRate] DECIMAL(18,2)
)

CREATE TABLE [Rooms]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Price] DECIMAL(18,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL, 
	[Beds] INT NOT NULL,
	[HotelId] INT FOREIGN KEY REFERENCES [dbo].[Hotels]([Id]) NOT NULL
)

CREATE TABLE [Trips]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[RoomId] INT FOREIGN KEY REFERENCES [dbo].[Rooms]([Id]) NOT NULL,
	[BookDate] DATE NOT NULL,
		CHECK([BookDate] < [ArrivalDate]),
	[ArrivalDate] DATE NOT NULL,
		CHECK([ArrivalDate] < [ReturnDate]),
	[ReturnDate] DATE NOT NULL,
	[CancelDate] DATE
)

CREATE TABLE [Accounts]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(20),
	[LastName] NVARCHAR(50) NOT NULL,
	[CityId] INT FOREIGN KEY REFERENCES [dbo].[Cities]([Id]) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[Email] VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE [AccountsTrips]
(
	[AccountId] INT FOREIGN KEY REFERENCES [dbo].[Accounts]([Id]) NOT NULL,
	[TripId] INT FOREIGN KEY REFERENCES [dbo].[Trips]([Id]) NOT NULL,
	[Luggage] INT NOT NULL,
		CHECK([Luggage] >= 0),
	PRIMARY KEY ([AccountId], [TripId])
)
	 
--02. Insert
USE [TripService]

INSERT INTO [dbo].[Accounts]([FirstName], [MiddleName], [LastName], [CityId], [BirthDate], [Email]) VALUES
	('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'), 
	('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'), 
	('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'), 
	('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO [dbo].[Trips]([RoomId], [BookDate], [ArrivalDate], [ReturnDate], [CancelDate]) VALUES
	(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
	(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
	(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
	(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--03. Update
USE [TripService]

UPDATE [dbo].[Rooms]
SET [Price] *= 1.14
WHERE [HotelId] IN (5,7,9)

--04. Delete
USE [TripService]

DELETE FROM [dbo].[AccountsTrips]
WHERE [AccountId] = 47

--05. EEE-Mails
USE [TripService]

SELECT a.[FirstName], a.[LastName], FORMAT(a.[BirthDate], 'MM-dd-yyyy') AS [BirthDate], c.[Name] AS [Hometown], a.[Email] FROM [dbo].[Accounts] AS a
	LEFT JOIN [dbo].[Cities] AS c ON c.[Id] = a.[CityId]
WHERE [Email] LIKE 'e%'
ORDER BY c.[Name]

--06. City Statistics
USE [TripService]

SELECT c.[Name], COUNT(*) AS [Hotels] FROM [dbo].[Cities] AS c
	JOIN [dbo].[Hotels] AS h ON h.[CityId] = c.[Id]
GROUP BY c.[Id], c.[Name]
ORDER BY [Hotels] DESC, c.[Name]

--07. Longest and Shortest Trips
USE [TripService]

SELECT 
	a.[Id] AS [AccountId],
	CONCAT(a.[FirstName], ' ', a.[LastName]) AS [FullName],
	MAX(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [LongestTrip],
	MIN(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [ShortestTrip]
FROM [dbo].[Accounts] AS a
	JOIN [dbo].[AccountsTrips] AS atr ON atr.[AccountId] = a.[Id]
	JOIN [dbo].[Trips] AS t ON t.[Id] = atr.[TripId]
WHERE a.[MiddleName] IS NULL AND t.[CancelDate] IS NULL
GROUP BY a.[Id], a.[FirstName], a.[LastName]
ORDER BY [LongestTrip] DESC, [ShortestTrip]

--08. Metropolis
USE [TripService]

SELECT TOP(10) c.[Id], c.[Name] AS [City], c.[CountryCode] AS [Country], COUNT(*) AS [Accounts] FROM [dbo].[Cities] AS c
	JOIN [dbo].[Accounts] AS a ON a.[CityId] = c.[Id]
GROUP BY c.[Id], c.[Name], c.[CountryCode]
ORDER BY [Accounts] DESC

--09. Romantic Getaways
USE [TripService]

SELECT a.[Id], a.[Email], c.[Name] AS [City], COUNT(*) AS [Trips] FROM [dbo].[Accounts] AS a
	JOIN [dbo].[AccountsTrips] AS atr ON atr.[AccountId] = a.[Id]
	JOIN [dbo].[Trips] AS t ON t.[Id] = atr.[TripId]
	JOIN [dbo].[Rooms] AS r ON r.[Id] = t.[RoomId]
	JOIN [dbo].[Hotels] AS h ON h.[Id] = r.[HotelId]
	JOIN [dbo].[Cities] AS c ON c.[Id] = a.[CityId]
WHERE a.[CityId] = h.[CityId]
GROUP BY a.[Id], a.[Email], c.[Name]
ORDER BY [Trips] DESC, a.[Id]

--10. GDPR Violation
USE [TripService]

SELECT 
	t.[Id], 
	--CONCAT_WS(' ', a.[FirstName], ISNULL(a.[MiddleName], NULL), a.[LastName]) AS [Full Name],
	CASE 
		WHEN a.[MiddleName] IS NULL THEN CONCAT(a.[FirstName], ' ', a.[LastName])
		ELSE CONCAT(a.[FirstName], ' ', a.[MiddleName], ' ', a.[LastName])
	END AS [Full Name],
	c1.[Name] AS [From],
	c2.[Name] AS [To],
	CASE 
		WHEN t.[CancelDate] IS NULL THEN CONCAT(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate]), ' days')
		ELSE 'Canceled'
	END AS [Duration]
FROM [dbo].[Trips] AS t
	JOIN [dbo].[AccountsTrips] AS atr ON atr.[TripId] = t.[Id]
	JOIN [dbo].[Accounts] AS a ON a.[Id] = atr.[AccountId]
	JOIN [dbo].[Cities] AS c1 ON c1.[Id] = a.[CityId]
	JOIN [dbo].[Rooms] AS r ON r.[Id] = t.[RoomId]
	JOIN [dbo].[Hotels] AS h ON h.[Id] = r.[HotelId]
	JOIN [dbo].[Cities] AS c2 ON c2.[Id] = h.[CityId]
ORDER BY [Full Name], t.[Id]

--11. Available Room
USE [TripService]

GO

CREATE OR ALTER FUNCTION [udf_GetAvailableRoom](@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS BEGIN
	DECLARE @RoomId INT = 
		(SELECT TOP(1) r.[Id] FROM [dbo].[Rooms] AS r 
			JOIN [dbo].[Trips] AS t ON t.[RoomId] = r.[Id]
		WHERE r.[HotelId] = @HotelId 
			AND (@Date NOT BETWEEN t.[ArrivalDate] AND t.[ReturnDate]) 
			AND YEAR(@Date) = YEAR(t.[ArrivalDate]) 
			AND	t.[CancelDate] IS NULL 
			AND	r.[Beds] >= @People
		ORDER BY r.[Price] DESC)

	IF @RoomId IS NULL
		RETURN 'No rooms available'

	DECLARE @RoomType NVARCHAR(20) = (SELECT [Type] FROM [dbo].[Rooms] WHERE [Id] = @RoomId)
	
	DECLARE @Beds INT = (SELECT [Beds] FROM [dbo].[Rooms] WHERE [Id] = @RoomId)

	DECLARE @RoomPrice DECIMAL(18,2) = (SELECT [Price] FROM [dbo].[Rooms] WHERE [Id] = @RoomId)
	
	DECLARE @HotelBaseRate DECIMAL(15,2) = (SELECT [BaseRate] FROM [dbo].[Hotels] WHERE [Id] = @HotelId)
	
	DECLARE @TotalPrice DECIMAL(18,2) = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room ', @RoomId, ': ', @RoomType, ' (', @Beds, ' beds',') - $', @TotalPrice)
END
GO

SELECT [dbo].[udf_GetAvailableRoom](112, '2011-12-17', 2) AS [Output]
SELECT [dbo].[udf_GetAvailableRoom](94, '2015-07-26', 3) AS [Output]
			
--12. Switch Room
USE [TripService]

GO

CREATE OR ALTER PROC [usp_SwitchRoom] (@TripId INT, @TargetRoomId INT)
AS BEGIN
	DECLARE @OldHotelId INT = 
		(SELECT r.[HotelId] FROM [dbo].[Trips] AS t
			JOIN [dbo].[Rooms] AS r ON r.[Id] = t.[RoomId]
		WHERE t.[Id] = @TripId)
	
	DECLARE @NewHotelId INT = 
		(SELECT DISTINCT r.[HotelId] FROM [dbo].[Trips] AS t
			JOIN [dbo].[Rooms] AS r ON r.[Id] = t.[RoomId]
		WHERE t.[RoomId] = @TargetRoomId)

	IF @OldHotelId != @NewHotelId
		THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @TargetRoomBeds INT = (SELECT [Beds] FROM [dbo].[Rooms] WHERE [Id] = @TargetRoomId)

	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM 
			(SELECT DISTINCT atr.[AccountId] FROM [dbo].[Trips] AS t 
				JOIN [dbo].[AccountsTrips] AS atr ON atr.[TripId] = @TripId
			GROUP BY atr.[AccountId]) AS [AccountIDs])

	IF @TripAccounts > @TargetRoomBeds
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE [dbo].[Trips]
	SET [RoomId] = @TargetRoomId
	WHERE [Id] = @TripId
END
GO

EXEC [dbo].[usp_SwitchRoom] 10, 11
SELECT [RoomId] FROM [dbo].[Trips] WHERE [Id] = 10
EXEC [dbo].[usp_SwitchRoom] 10, 7
EXEC [dbo].[usp_SwitchRoom] 10, 8