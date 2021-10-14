--01. DDL
CREATE DATABASE [Bakery]

USE [Bakery]

CREATE TABLE [Countries]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(25),
	[LastName] NVARCHAR(25),
	[Gender] CHAR(1),
		CHECK([Gender] IN ('M', 'F')),
	[Age] INT,
	[PhoneNumber] CHAR(10),
	[CountryId] INT FOREIGN KEY REFERENCES [dbo].[Countries]([Id])
)

CREATE TABLE [Products]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	[Description] NVARCHAR(250),
	[Recipe] NVARCHAR(MAX),
	[Price] DECIMAL(18,2),
		CHECK([Price] >= 0)
)

CREATE TABLE [Feedbacks]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(255),
	[Rate] DECIMAL(18,2),
		CHECK([Rate] BETWEEN 0 AND 10),
	[ProductId] INT FOREIGN KEY REFERENCES [dbo].[Products]([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES [dbo].[Customers]([Id])
)

CREATE TABLE [Distributors]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) UNIQUE,
	[AddressText] NVARCHAR(30),
	[Summary] NVARCHAR(200),
	[CountryId] INT FOREIGN KEY REFERENCES [dbo].[Countries]([Id])
)

CREATE TABLE [Ingredients]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30),
	[Description] NVARCHAR(200),
	[OriginCountryId] INT FOREIGN KEY REFERENCES [dbo].[Countries]([Id]),
	[DistributorId] INT FOREIGN KEY REFERENCES [dbo].[Distributors]([Id])
)

CREATE TABLE [ProductsIngredients]
(
	[ProductId] INT FOREIGN KEY REFERENCES [dbo].[Products]([Id]),
	[IngredientId] INT FOREIGN KEY REFERENCES [dbo].[Ingredients]([Id]),
	PRIMARY KEY ([ProductId], [IngredientId])
)

--02. Insert
USE [Bakery]

INSERT INTO [dbo].[Distributors]([Name], [CountryId], [AddressText], [Summary]) VALUES
	('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
	('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
	('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
	('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
	('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO [dbo].[Customers]([FirstName], [LastName], [Age], [Gender], [PhoneNumber], [CountryId]) VALUES
	('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
	('Kendra', 'Loud', 22, 'F', '0063631526', 11),
	('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
	('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
	('Tom', 'Loeza', 31, 'M', '0144876096', 23),
	('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
	('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
	('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--03. Update
USE [Bakery]

UPDATE [dbo].[Ingredients]
SET [DistributorId] = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE [dbo].[Ingredients]
SET [OriginCountryId] = 14
WHERE [OriginCountryId] = 8

--04. Delete
USE [Bakery]

DELETE FROM [dbo].[Feedbacks]
WHERE [CustomerId] = 14 OR [ProductId] = 5

--05. Products By Price
USE [Bakery]

SELECT [Name], [Price], [Description] FROM [dbo].[Products]
ORDER BY [Price] DESC, [Name]

--06. Negative Feedback
USE [Bakery]

SELECT f.[ProductId], f.[Rate], f.[Description], f.[CustomerId], c.[Age], c.[Gender] FROM [dbo].[Feedbacks] AS f
	LEFT JOIN [dbo].[Customers] AS c ON c.[Id] = f.[CustomerId]
WHERE f.[Rate] < 5
ORDER BY f.[ProductId] DESC, f.[Rate]

--07. Customers without Feedback
USE [Bakery]

SELECT CONCAT(c.[FirstName], ' ', c.[LastName]) AS [CustomerName], c.[PhoneNumber], c.[Gender] FROM [dbo].[Customers] AS c
	LEFT JOIN [dbo].[Feedbacks] AS f ON f.[CustomerId] = c.[Id]
WHERE f.[Id] IS NULL
ORDER BY c.[Id]

--08. Customers by Criteria
USE [Bakery]

SELECT cm.[FirstName], cm.[Age], cm.[PhoneNumber] FROM [dbo].[Customers] AS cm
	JOIN [dbo].[Countries] AS cn ON cn.[Id] = cm.[CountryId]
WHERE (cm.[Age] >= 21 AND cm.[FirstName] LIKE '%an%') OR (cm.[PhoneNumber] LIKE '%38' AND cn.[Name] != 'Greece')
ORDER BY cm.[FirstName], cm.[Age]

--09. Middle Range Distributors
USE [Bakery]

SELECT 
	d.[Name] AS [DistributorName], 
	i.[Name] AS [IngredientName], 
	p.[Name] AS [ProductName], 
	AVG(f.[Rate]) AS [AverageRate] 
FROM [dbo].[Distributors] AS d
	JOIN [dbo].[Ingredients] AS i ON i.[DistributorId] = d.[Id]
	JOIN [dbo].[ProductsIngredients] AS pdi ON pdi.[IngredientId] = i.[Id]
	JOIN [dbo].[Products] AS p ON p.[Id] = pdi.[ProductId]
	JOIN [dbo].[Feedbacks] AS f ON f.[ProductId] = p.[Id]
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(f.[Rate]) >= 5 AND AVG(f.[Rate]) <= 8

--10. Country Representative
USE [Bakery]

SELECT [CountryName], [DistributorName] FROM
	(SELECT 
		c.[Name] AS [CountryName], 
		d.[Name] AS [DistributorName],
		DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.[Name]) DESC) AS [CountRank]
	FROM [dbo].[Countries] AS c
		JOIN [dbo].[Distributors] AS d ON d.[CountryId] = c.[Id]
		LEFT JOIN [dbo].[Ingredients] AS i ON i.[DistributorId] = d.[Id]
	GROUP BY c.[Name], d.[Name]) AS [DistributorsRanking]
WHERE [CountRank] = 1
ORDER BY [CountryName], [DistributorName]

--11. Customers With Countries
USE [Bakery]

GO

CREATE OR ALTER VIEW [v_UserWithCountries] AS
SELECT 
	CONCAT(cm.[FirstName], ' ', cm.[LastName]) AS [CustomerName], 
	cm.[Age], 
	cm.[Gender],
	cn.[Name] AS [CountryName]
FROM [dbo].[Customers] AS cm
	LEFT JOIN [dbo].[Countries] AS cn ON cn.[Id] = cm.[CountryId]
GO

SELECT TOP(5) * FROM [dbo].[v_UserWithCountries]
ORDER BY [Age]

--12. Delete Products
USE [Bakery]

GO

CREATE OR ALTER TRIGGER [tr_DeleteProducts] ON [dbo].[Products]
INSTEAD OF DELETE
AS BEGIN
	DECLARE @productId INT = (SELECT p.[Id] FROM [dbo].[Products] AS p JOIN [deleted] AS d ON d.[Id] = p.[Id])

	DELETE FROM [dbo].[ProductsIngredients] WHERE [ProductId] = @productId

	DELETE FROM [dbo].[Feedbacks] WHERE [ProductId] = @productId

	DELETE FROM [dbo].[Products] WHERE [Id] = @productId
END
GO

DELETE FROM [dbo].[Products] WHERE [Id] = 7