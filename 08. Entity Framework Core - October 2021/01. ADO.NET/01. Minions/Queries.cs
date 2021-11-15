namespace Minions
{
    public static class Queries
    {
        //Problem 01 Queries
        public const string CheckIfDatabaseExists = "SELECT * FROM master.dbo.sysdatabases WHERE name = '{0}'";
        public const string CreateDatabase = "CREATE DATABASE [{0}]";
        public static readonly string[] MinionsDbCreateTables =
            {
                "CREATE TABLE [Countries] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50))",
                "CREATE TABLE [Towns] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50), [CountryCode] INT FOREIGN KEY REFERENCES [Countries]([Id]))",
                "CREATE TABLE [Minions] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(30), [Age] INT, [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]))",
                "CREATE TABLE [EvilnessFactors] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50))",
                "CREATE TABLE [Villains] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50), [EvilnessFactorId] INT FOREIGN KEY REFERENCES [EvilnessFactors]([Id]))",
                "CREATE TABLE [MinionsVillains] ([MinionId] INT FOREIGN KEY REFERENCES [Minions]([Id]), [VillainId] INT FOREIGN KEY REFERENCES [Villains]([Id]), CONSTRAINT PK_MinionsVillains PRIMARY KEY ([MinionId], [VillainId]))"
            };
        public static readonly string[] MinionsDbInsertValues =
            {
            "INSERT INTO [Countries] ([Name]) VALUES ('Bulgaria'), ('England'), ('Cyprus'), ('Germany'), ('Norway')",
            "INSERT INTO [Towns] ([Name], [CountryCode]) VALUES ('Plovdiv', 1), ('Varna', 1), ('Burgas', 1), ('Sofia', 1), ('London', 2), ('Southampton', 2), ('Bath', 2), ('Liverpool', 2), ('Berlin', 3), ('Frankfurt', 3), ('Oslo', 4)",
            "INSERT INTO [Minions] ([Name], [Age], [TownId]) VALUES ('Bob', 14, 3), ('Kevin', 13, 1), ('Billy', 19, 2), ('Simon', 45, 3), ('Cathleen', 11, 2), ('Carry ', 50, 10), ('Becky', 125, 5), ('Mars', 21, 1), ('Misho', 5, 10), ('Zoe', 125, 5), ('Jason', 21, 1)",
            "INSERT INTO [EvilnessFactors] ([Name]) VALUES ('Super good'), ('Good'), ('Bad'), ('Evil'), ('Super evil')",
            "INSERT INTO [Villains] ([Name], [EvilnessFactorId]) VALUES ('Gru', 2), ('Victor', 1), ('Jilly', 3), ('Miro', 4), ('Rosen', 5), ('Dimityr', 1), ('Dobromir', 2), ('Victor Jr.', 3)",
            "INSERT INTO [MinionsVillains] ([MinionId], [VillainId]) VALUES (4,2), (1,1), (5,7), (3,5), (2,6), (11,5), (8,4), (9,7), (7,1), (1,3), (7,3), (5,3), (4,3), (1,2), (2,1), (2,7)"
        };

        //Problem 02 Queries
        public const string VillainsGetWithMoreThan3Minions = "SELECT v.[Name], COUNT(mv.[VillainId]) AS [MinionsCount] FROM [Villains] AS v JOIN [MinionsVillains] AS mv ON v.[Id] = mv.[VillainId] GROUP BY v.[Id], v.[Name] HAVING COUNT(mv.[VillainId]) > 3 ORDER BY COUNT(mv.[VillainId])";

        //Problem 03 Queries
        public const string VillainGetNameById = "SELECT [Name] FROM [Villains] WHERE [Id] = @id";
        public const string MinionsGetInfoByVillainsId = "SELECT ROW_NUMBER() OVER (ORDER BY m.[Name]) as [RowNum], m.[Name], m.[Age] FROM [MinionsVillains] AS mv JOIN [Minions] As m ON mv.[MinionId] = m.[Id] WHERE mv.[VillainId] = @id ORDER BY m.[Name]";

        //Problem 04 Queries
        public const string VillainsGetIdByName = "SELECT [Id] FROM [Villains] WHERE [Name] = @name";
        public const string MinionsGetIdByName = "SELECT [Id] FROM [Minions] WHERE [Name] = @name";
        public const string TownsGetIdByName = "SELECT [Id] FROM [Towns] WHERE[Name] = @townName";
        public const string VillainsInsertWithName = "INSERT INTO [Villains] ([Name], [EvilnessFactorId])  VALUES (@villainName, 4)";
        public const string MinionsInsertWithNameAgeTownId = "INSERT INTO [Minions] ([Name], [Age], [TownId]) VALUES (@name, @age, @townId)";
        public const string TownsInsertWithName = "INSERT INTO [Towns] ([Name]) VALUES (@townName)";
        public const string MinionsVilliansInsertPair = "INSERT INTO [MinionsVillains] ([MinionId], [VillainId]) VALUES (@minionId, @villainId)";

        //Problem 05 Queries
        public const string TownsUpdateNamesToUpperByCountryName = "UPDATE [Towns] SET [Name] = UPPER([Name]) WHERE [CountryCode] = (SELECT c.[Id] FROM [Countries] AS c WHERE c.[Name] = @countryName)";
        public const string TownsGetNamesByCountryName= "SELECT t.[Name] FROM [Towns] as t JOIN [Countries] AS c ON c.[Id] = t.[CountryCode] WHERE c.[Name] = @countryName";

        //Problem 06 Queries
        public const string VillainsGetNameById = "SELECT [Name] FROM [Villains] WHERE [Id] = @villainId";
        public const string MinionsVillainsDeletePairByVillianId = "DELETE FROM [MinionsVillains] WHERE [VillainId] = @villainId";
        public const string VillainsDeleteById = "DELETE FROM [Villains] WHERE [Id] = @villainId";

        //Problem 07 Queries
        public const string MinionsGetNames = "SELECT [Name] FROM [Minions]";

        //Problem 08 Queries
        public const string MinionsUpdateNameToUpperAndIncreaseAgeById = "UPDATE [Minions] SET [Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name])), [Age] += 1 WHERE [Id] = @id";
        public const string MinionsGetNamesAges = "SELECT [Name], [Age] FROM [Minions]";

        //Problem 09 Queries
        public const string CreateProcedureGetOlder = "CREATE OR ALTER PROC [usp_GetOlder] @id INT AS UPDATE [Minions] SET [Age] += 1 WHERE [Id] = @id";
        public const string ExecuteProcedureUspGetOlder = "EXEC [usp_GetOlder] @id";
        public const string MinionsGetNameAgeById = "SELECT [Name], [Age] FROM [Minions] WHERE [Id] = @id";
    }
}
