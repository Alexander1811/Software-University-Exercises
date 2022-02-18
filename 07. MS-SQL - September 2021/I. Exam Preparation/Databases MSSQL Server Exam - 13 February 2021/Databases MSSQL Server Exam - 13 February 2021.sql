--01. DDL
CREATE DATABASE [Bitbucket]

USE [Bitbucket]

CREATE TABLE [Users]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE [Repositories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [RepositoriesContributors]
(
	[RepositoryId] INT FOREIGN KEY REFERENCES [dbo].[Repositories]([Id]),
	[ContributorId] INT FOREIGN KEY REFERENCES [dbo].[Users]([Id]),
	PRIMARY KEY ([RepositoryId], [ContributorId])
)

CREATE TABLE [Issues]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(255) NOT NULL,
	[IssueStatus] CHAR(6) NOT NULL,
	[RepositoryId] INT FOREIGN KEY REFERENCES [dbo].[Repositories]([Id]) NOT NULL,
	[AssigneeId] INT FOREIGN KEY REFERENCES [dbo].[Users]([Id]) NOT NULL
)

CREATE TABLE [Commits]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	[IssueId] INT FOREIGN KEY REFERENCES [dbo].[Issues]([Id]),
	[RepositoryId] INT FOREIGN KEY REFERENCES [dbo].[Repositories]([Id]) NOT NULL,
	[ContributorId] INT FOREIGN KEY REFERENCES [dbo].[Users]([Id]) NOT NULL
)

CREATE TABLE [Files]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Size] DECIMAL(18,2) NOT NULL,
	[ParentId] INT FOREIGN KEY REFERENCES [dbo].[Files]([Id]),
	[CommitId] INT FOREIGN KEY REFERENCES [dbo].[Commits]([Id]) NOT NULL
)

--02. Insert
USE [Bitbucket]

INSERT INTO [dbo].[Files]([Name], [Size], [ParentId], [CommitId]) VAlUES
	('Trade.idk', 2598.0, 1, 1),
	('menu.net', 9238.31, 2, 2),
	('Administrate.soshy', 1246.93, 3, 3),
	('Controller.php', 7353.15, 4, 4),
	('Find.java', 9957.86, 5, 5),
	('Controller.json', 14034.87, 3, 6),
	('Operate.xix', 7662.92, 7, 7)

INSERT INTO [dbo].[Issues]([Title], [IssueStatus], [RepositoryId], [AssigneeId]) VALUES
	('Critical Problem with HomeController.cs file', 'open', 1, 4),
	('Typo fix in Judge.html', 'open', 4, 3),
	('Implement documentation for UsersService.cs', 'closed', 8, 2),
	('Unreachable code in Index.cs', 'open', 9, 8)

--03. Update
USE [Bitbucket]

UPDATE [dbo].[Issues]
SET [IssueStatus] = 'closed'
WHERE [AssigneeId] = 6

--04. Delete
USE [Bitbucket]

DELETE FROM [dbo].[RepositoriesContributors]
WHERE [RepositoryId] = (SELECT [Id] FROM [dbo].[Repositories] WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM [dbo].[Issues]
WHERE [RepositoryId] = (SELECT [Id] FROM [dbo].[Repositories] WHERE [Name] = 'Softuni-Teamwork')

--05. Commit
USE [Bitbucket]

SELECT [Id], [Message], [RepositoryId], [ContributorId] FROM [dbo].[Commits]
ORDER BY [Id], [Message], [RepositoryId], [ContributorId]

--06. Front-end
USE [Bitbucket]

SELECT [Id], [Name], [Size] FROM [dbo].[Files]
WHERE [Size] > 1000 AND [Name] LIKE '%html'
ORDER BY [Size] DESC, [Id], [Name]

--07. Issue Assignment
USE [Bitbucket]

SELECT i.[Id], CONCAT(u.[Username], ' : ', i.[Title]) AS [IssueAssignee] FROM [dbo].[Issues] AS i
	JOIN [dbo].[Users] AS u ON u.[Id] = i.[AssigneeId]
ORDER BY i.[Id] DESC, [IssueAssignee]

--08. Single Files
USE [Bitbucket]

SELECT pf.[Id], pf.[Name], CONCAT(pf.[Size], 'KB') AS [Size] FROM [dbo].[Files] AS pf
	LEFT JOIN [dbo].[Files] AS cf ON cf.[ParentId] = pf.[Id]
WHERE cf.[Id] IS NULL
ORDER BY pf.[Id], pf.[Name], pf.[Size] DESC

--09. Commits in Repositories
USE [Bitbucket]

SELECT TOP(5) r.[Id], r.[Name], COUNT(rc.[ContributorId]) AS [Commits] FROM [dbo].[Repositories] AS r
	LEFT JOIN [dbo].[Commits] AS c ON c.[RepositoryId] = r.Id
	LEFT JOIN [dbo].[RepositoriesContributors] AS rc ON rc.[RepositoryId] = r.[Id]
GROUP BY r.[Id], r.[Name]
ORDER BY [Commits] DESC, r.[Id], r.[Name]

--10. Average Size
USE [Bitbucket]

SELECT u.[Username], AVG(f.[Size]) AS [Size] FROM [dbo].[Users] AS u
	JOIN [dbo].[Commits] AS c ON c.[ContributorId] = u.[Id]
	JOIN [dbo].[Files] AS f ON f.[CommitId] = c.[Id]
GROUP BY u.[Id], u.[Username]
ORDER BY AVG(f.[Size]) DESC, u.[Username]

--11. All User Commits
USE [Bitbucket]

GO

CREATE OR ALTER FUNCTION [udf_AllUserCommits](@username VARCHAR(MAX))
RETURNS INT
AS BEGIN
	RETURN (SELECT COUNT(*) FROM [dbo].[Commits] AS c
		JOIN [dbo].[Users] AS u ON u.[Id] = c.[ContributorId]
	WHERE u.[Username] = @username) 
END
GO

SELECT [dbo].[udf_AllUserCommits]('UnderSinduxrein') AS [Output]

--12. Search for Files
USE [Bitbucket]

GO

CREATE OR ALTER PROC [usp_SearchForFiles] (@fileExtension VARCHAR(20))
AS BEGIN
	SELECT [Id], [Name], CONCAT([Size], 'KB') AS [Size] FROM [dbo].[Files]
	WHERE [Name] LIKE CONCAT('%', @fileExtension)
END
GO

EXEC [dbo].[usp_SearchForFiles] 'txt'