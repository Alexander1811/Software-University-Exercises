--01. DDL
CREATE DATABASE [ColonialJourney]

USE [ColonialJourney]

CREATE TABLE [Planets]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Spaceports]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PlanetId] INT FOREIGN KEY REFERENCES [dbo].[Planets]([Id]) NOT NULL
)

CREATE TABLE [Spaceships]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Manufacturer] VARCHAR(30) NOT NULL,
	[LightSpeedRate] INT DEFAULT 0
)

CREATE TABLE [Colonists]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[Ucn] VARCHAR(10) UNIQUE NOT NULL,
	[BirthDate] DATE NOT NULL
)

CREATE TABLE [Journeys]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[JourneyStart] DATETIME2 NOT NULL,
	[JourneyEnd] DATETIME2 NOT NULL,
	[Purpose] VARCHAR(11) NOT NULL,
		CHECK([Purpose] IN ('Medical', 'Technical', 'Educational', 'Military')),
	[DestinationSpaceportId] INT FOREIGN KEY REFERENCES [dbo].[Spaceports]([Id]) NOT NULL,
	[SpaceshipId] INT FOREIGN KEY REFERENCES [dbo].[Spaceships]([Id]) NOT NULL
)

CREATE TABLE [TravelCards]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CardNumber] VARCHAR(10) UNIQUE NOT NULL,
		CHECK(LEN([CardNumber]) = 10),
	[JobDuringJourney] VARCHAR(8),
		CHECK([JobDuringJourney] IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	[ColonistId] INT FOREIGN KEY REFERENCES [dbo].[Colonists]([Id]) NOT NULL,
	[JourneyId] INT FOREIGN KEY REFERENCES [dbo].[Journeys]([Id]) NOT NULL
)

--02. Insert
USE [ColonialJourney]

INSERT INTO [dbo].[Planets]([Name]) VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO [dbo].[Spaceships]([Name], [Manufacturer], [LightSpeedRate]) VALUES
	('Golf', 'VW', 3),
	('WakaWaka', 'Wakanda', 4),
	('Falcon9', 'SpaceX', 1),
	('Bed', 'Vidolov', 6)

--03. Update
USE [ColonialJourney]

UPDATE [dbo].[Spaceships]
SET [LightSpeedRate] += 1
WHERE [Id] BETWEEN 8 AND 12

--04. Delete
USE [ColonialJourney]

DELETE FROM [dbo].[TravelCards]
WHERE [JourneyId] IN (SELECT TOP(3) [Id] FROM [dbo].[Journeys] ORDER BY [Id])

DELETE FROM [dbo].[Journeys]
WHERE [Id] IN (SELECT TOP(3) [Id] FROM [dbo].[Journeys] ORDER BY [Id])

--05. Select All Military Journeys
USE [ColonialJourney]

SELECT [Id], FORMAT([JourneyStart], 'dd/MM/yyyy') AS [JourneyStart], FORMAT([JourneyEnd], 'dd/MM/yyyy') AS [JourneyEnd] FROM [dbo].[Journeys]
WHERE [Purpose] = 'Military'
ORDER BY [JourneyStart]

--06. Select All Pilots
USE [ColonialJourney]

SELECT c.[Id] AS [id], CONCAT(c.[FirstName], ' ', c.[LastName]) AS [full_name] FROM [dbo].[Colonists] AS c
	JOIN [dbo].[TravelCards] AS tc ON tc.[ColonistId] = c.[Id]
WHERE tc.[JobDuringJourney] = 'Pilot'
ORDER BY c.[Id]

--07. Count Colonists
USE [ColonialJourney]

SELECT COUNT(*) AS [count] FROM [dbo].[Colonists] AS c
	JOIN [dbo].[TravelCards] AS tc ON tc.[ColonistId] = c.[Id]
	JOIN [dbo].[Journeys] AS j ON j.[Id] = tc.[JourneyId]
WHERE j.[Purpose] = 'Technical'

--08. Select Spaceships With Pilots
USE [ColonialJourney]

SELECT ss.[Name], ss.[Manufacturer] AS [Years] FROM [dbo].[Colonists] AS c
	JOIN [dbo].[TravelCards] AS tc ON tc.[ColonistId] = c.[Id]
	JOIN [dbo].[Journeys] AS j ON j.[Id] = tc.[JourneyId]
	JOIN [dbo].[Spaceships] AS ss ON ss.[Id] = j.[SpaceshipId]
WHERE tc.[JobDuringJourney] = 'Pilot' AND DATEDIFF(YEAR, c.[BirthDate], '01/01/2019') < 30
ORDER BY ss.[Name]

--09. Planets And Journeys
USE [ColonialJourney]

SELECT p.[Name] AS [PlanetName], COUNT(j.[Id]) AS [JourneyCount] FROM [dbo].[Planets] AS p
	JOIN [dbo].[Spaceports] AS sp ON sp.[PlanetId] = p.[Id]
	JOIN [dbo].[Journeys] AS j ON j.[DestinationSpaceportId] = sp.[Id]
GROUP BY p.[Name]
ORDER BY [JourneyCount] DESC, [PlanetName]

--10. Select Special Colonists
USE [ColonialJourney]

SELECT * FROM 
	(SELECT 
		tc.[JobDuringJourney],
		CONCAT(c.[FirstName], ' ', c.[LastName]) AS [FullName],
		DENSE_RANK() OVER (PARTITION BY tc.[JobDuringJourney] ORDER BY c.[BirthDate]) AS [JobRank] 
	FROM [dbo].[Colonists] AS c
		JOIN [dbo].[TravelCards] AS tc ON tc.[ColonistId] = c.[Id]) AS [JobAgeRanking]
WHERE [JobRank] = 2


--11. Get Colonists Count
USE [ColonialJourney]

GO

CREATE OR ALTER FUNCTION [udf_GetColonistsCount](@PlanetName VARCHAR(30))
RETURNS INT
AS BEGIN
	RETURN (SELECT COUNT(*) FROM [dbo].[Planets] AS p
		LEFT JOIN [dbo].[Spaceports] AS sp ON sp.[PlanetId] = p.[Id]
		LEFT JOIN [dbo].[Journeys] AS j ON j.[DestinationSpaceportId] = sp.[Id]
		LEFT JOIN [dbo].[TravelCards] AS tc ON tc.[JourneyId] = j.[Id]
		LEFT JOIN [dbo].[Colonists] AS c ON c.[Id] = tc.[ColonistId]
	WHERE p.[Name] = @PlanetName)
END
GO

SELECT [dbo].[udf_GetColonistsCount]('Otroyphus') AS [Count]

--12. Change Journey Purpose
USE [ColonialJourney]

GO

CREATE OR ALTER PROC [usp_ChangeJourneyPurpose](@JourneyId INT, @NewPurpose VARCHAR(11))
AS BEGIN
	DECLARE @ExistingJourneyId INT = (SELECT [Id] FROM [dbo].[Journeys] WHERE [Id] = @JourneyId)

	IF @ExistingJourneyId IS NULL
		THROW 50001, 'The journey does not exist!', 1

	DECLARE @OldPurpose VARCHAR(11) = (SELECT [Purpose] FROM [dbo].[Journeys] WHERE [Id] = @JourneyId)

	IF @OldPurpose = @NewPurpose
		THROW 50002, 'You cannot change the purpose!', 1

	UPDATE [dbo].[Journeys]
	SET [Purpose] = @NewPurpose
	WHERE [Id] = @JourneyId
END
GO

EXEC [dbo].[usp_ChangeJourneyPurpose] 4, 'Technical'
EXEC [dbo].[usp_ChangeJourneyPurpose] 2, 'Educational'
EXEC [dbo].[usp_ChangeJourneyPurpose] 196, 'Technical'