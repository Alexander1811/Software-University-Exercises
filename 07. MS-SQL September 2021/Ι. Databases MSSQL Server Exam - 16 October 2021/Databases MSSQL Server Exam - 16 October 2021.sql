--01. DDL
CREATE DATABASE [CigarShop]

USE [CigarShop]

CREATE TABLE [Sizes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL,
		CHECK([Length] BETWEEN 10 AND 25),
	[RingRange] DECIMAL(3,2) NOT NULL,
		CHECK([RingRange] BETWEEN 1.5 AND 7.5)
)

CREATE TABLE [Tastes]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[TasteType] VARCHAR(20) NOT NULL,
	[TasteStrength] VARCHAR(15) NOT NULL,
	[ImageURL] NVARCHAR(100) NOT NULL	
)

CREATE TABLE [Brands]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[BrandName] VARCHAR(30) UNIQUE NOT NULL,
	[BrandDescription] VARCHAR(MAX)	
)

CREATE TABLE [Cigars]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CigarName] VARCHAR(80) NOT NULL,
	[BrandId] INT FOREIGN KEY REFERENCES [dbo].[Brands]([Id]) NOT NULL,
	[TastId] INT FOREIGN KEY REFERENCES [dbo].[Tastes]([Id]) NOT NULL,
	[SizeId] INT FOREIGN KEY REFERENCES [dbo].[Sizes]([Id]) NOT NULL,
	[PriceForSingleCigar] DECIMAL(18,2) NOT NULL,
	[ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Town] VARCHAR(30) NOT NULL,
	[Country] NVARCHAR(30) NOT NULL,
	[Streat] NVARCHAR(100) NOT NULL,
	[ZIP] VARCHAR(20) NOT NULL
)

CREATE TABLE [Clients]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [dbo].[Addresses]([Id]) NOT NULL
)

CREATE TABLE [ClientsCigars]
(
	[ClientId] INT FOREIGN KEY REFERENCES [dbo].[Clients]([Id]) NOT NULL,
	[CigarId] INT FOREIGN KEY REFERENCES [dbo].[Cigars]([Id]) NOT NULL,
	PRIMARY KEY([ClientId], [CigarId])
)

--02. Insert
USE [CigarShop]

INSERT INTO [dbo].[Cigars]([CigarName], [BrandId], [TastId], [SizeId], [PriceForSingleCigar], [ImageURL]) VALUES
	('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
	('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
	('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
	('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
	('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO [dbo].[Addresses]([Town], [Country], [Streat], [ZIP]) VALUES
	('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
	('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
	('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--03. Update
USE [CigarShop]

UPDATE [dbo].[Cigars] 
SET [PriceForSingleCigar] *= 1.2
FROM [dbo].[Cigars] AS c
	JOIN [dbo].[Tastes] AS t ON t.[Id] = c.[TastId]
WHERE t.[TasteType] = 'Spicy'

UPDATE [dbo].[Brands] 
SET [BrandDescription] = 'New description'
WHERE [BrandDescription] IS NULL

--04. Delete
USE [CigarShop]

DELETE [dbo].[Clients] FROM [dbo].[Clients] AS c 
	JOIN [dbo].[Addresses] AS a ON a.[Id] = c.[AddressId]
WHERE a.[Country] LIKE 'C%'

DELETE FROM [dbo].[Addresses]
WHERE [Country] LIKE 'C%'

--05. Cigars by Price
USE [CigarShop]

SELECT [CigarName], [PriceForSingleCigar], [ImageURL] FROM [dbo].[Cigars]
ORDER BY [PriceForSingleCigar], [CigarName] DESC

--06. Cigars by Taste
USE [CigarShop]

SELECT c.[Id], c.[CigarName], c.[PriceForSingleCigar], t.[TasteType], t.[TasteStrength] FROM [dbo].[Cigars] AS c
	JOIN [dbo].[Tastes] AS t ON t.[Id] = c.[TastId]
WHERE t.[TasteType] IN ('Earthy', 'Woody')
ORDER BY c.[PriceForSingleCigar] DESC

--07. Clients without Cigars
USE [CigarShop]

SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [ClientName], [Email] FROM [dbo].[Clients] AS c
WHERE [Id] NOT IN (SELECT [ClientId] FROM [dbo].[ClientsCigars])
ORDER BY [ClientName]

--08. First 5 Cigars
USE [CigarShop]

SELECT TOP(5) c.[CigarName], c.[PriceForSingleCigar], c.[ImageURL] FROM [dbo].[Cigars] AS c
	JOIN [dbo].[Sizes] AS s ON s.[Id] = c.[SizeId]
WHERE s.[Length] > 12 AND (c.[CigarName] LIKE '%ci%' OR c.[PriceForSingleCigar] > 50 AND s.[RingRange] > 2.55)
ORDER BY c.[CigarName], c.[PriceForSingleCigar] DESC

--09. Clients with ZIP Codes
USE [CigarShop]

SELECT 
	CONCAT(cl.[FirstName], ' ', cl.[LastName]) AS [FullName], 
	a.[Country], 
	a.[ZIP], 
	CONCAT('$', MAX(cig.[PriceForSingleCigar])) AS [CigarPrice]
FROM [dbo].[Clients] AS cl
	JOIN [dbo].[Addresses] AS a ON a.[Id] = cl.[AddressId]
	JOIN [dbo].[ClientsCigars] AS cc ON cc.[ClientId] = cl.[Id]
	JOIN [dbo].[Cigars] AS cig ON cig.[Id] = cc.[CigarId]
WHERE a.[ZIP] NOT LIKE '%[^0-9.]%'
GROUP BY cl.[FirstName], cl.[LastName], a.[Country], a.[ZIP]
ORDER BY [FullName]

--10. Cigars by Size
USE [CigarShop]

SELECT 
	cl.[LastName], 
	AVG(s.[Length]) AS [CigarLength], 
	CEILING(AVG(s.[RingRange])) AS [CigarRingRange]
FROM [dbo].[Clients] AS cl
	JOIN [dbo].[ClientsCigars] AS cc ON cc.[ClientId] = cl.[Id]
	JOIN [dbo].[Cigars] AS cig ON cig.[Id] = cc.[CigarId]
	JOIN [dbo].[Sizes] AS s ON s.[Id] = cig.[SizeId]
GROUP BY cl.[LastName]
ORDER BY AVG(s.[Length]) DESC

SELECT * FROM [dbo].[Clients] AS cl
	FULL JOIN [dbo].[ClientsCigars] AS cc ON cc.[ClientId] = cl.[Id]
	FULL JOIN [dbo].[Cigars] AS cig ON cig.[Id] = cc.[CigarId]
	FULL JOIN [dbo].[Sizes] AS s ON s.[Id] = cig.[SizeId]
WHERE cl.[Id] = 3

--11. Client with Cigars
USE [CigarShop]

GO

CREATE OR ALTER FUNCTION [udf_ClientWithCigars](@name NVARCHAR(30))
RETURNS INT
AS BEGIN 
	RETURN 
		(SELECT COUNT(*) FROM [dbo].[Clients] AS c 
			JOIN [dbo].[ClientsCigars] AS cc ON cc.[ClientId] = c.[Id]
		WHERE c.[FirstName] = @name)
END 
GO

SELECT [dbo].[udf_ClientWithCigars]('Betty') AS [Output]

--12. Search for Cigar with Specific Taste
USE [CigarShop]

GO

CREATE OR ALTER PROC [usp_SearchByTaste] (@taste VARCHAR(20))
AS BEGIN
	SELECT 
		c.[CigarName], 
		CONCAT('$', c.[PriceForSingleCigar]) AS [Price],
		t.[TasteType],
		b.[BrandName],
		CONCAT(s.[Length], ' cm') AS [CigarLength],
		CONCAT(s.[RingRange], ' cm') AS [CigarRingRange]
	FROM [dbo].[Cigars] AS c
		JOIN [dbo].[Tastes] AS t ON t.[Id] = c.[TastId]
		JOIN [dbo].[Sizes] AS s ON s.[Id] = c.[SizeId]
		JOIN [dbo].[Brands] AS b ON b.[Id] = c.[BrandId]
	WHERE t.[TasteType] = @taste
	ORDER BY [CigarLength], [CigarRingRange] DESC
END
GO

EXEC [dbo].[usp_SearchByTaste] 'Woody'
