--01. Create Database
CREATE DATABASE [Minions]

--02. Create Tables
USE [Minions]

CREATE TABLE [Minions] 
(
    [ID] INT PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(256) NOT NULL,
    [Age] INT
)

CREATE TABLE [Towns] 
(
    [ID] INT PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(256) NOT NULL
)

--03. Alter Minions Table
USE [Minions]

ALTER TABLE [Minions]
ADD [TownID] INT NOT NULL

ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsTownID] FOREIGN KEY (TownID) REFERENCES [Towns]([ID])

--04. Insert Records in Both Tables
USE [Minions]

INSERT INTO [Towns] ([ID], [Name]) VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')
	
INSERT INTO [Minions] ([ID], [Name], [Age], [TownID]) VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

--05. Truncate Table Minions
TRUNCATE TABLE [Minions]

--06. Drop All Tables
DROP TABLE dbo.Minions
DROP TABLE dbo.Towns

--07. Create Table People
USE [Minions]

CREATE TABLE [People] 
(
	[ID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(256) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Heigth] DECIMAL(5, 2),
	[Weigth] DECIMAL(5, 2),
	[Gender] CHAR NOT NULL,
	CHECK ([Gender] IN ('M','F')),
	[Birthdate] CHAR(10) NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Heigth], [Weigth], [Gender], [Birthdate]) VALUES
	('A', 1.75, 810, 'm', '16.03.2000'),
	('B', 1.93, 900, 'm', '21.07.1993'),
	('C', 1.65, 550, 'f', '15.05.1988'),
	('D', 1.82, 101, 'm', '11.10.1989'),
	('E', 1.63, 577, 'f', '14.02.1980')

--08. Create Table Users
USE [Minions]

CREATE TABLE [Users] 
(
	[ID] BIGINT PRIMARY KEY IDENTITY(1,1),
	[Username] VARCHAR(32) UNIQUE NOT NULL,
	[Password] VARCHAR(32),
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) VALUES
	('A', 'A123', 980, '12:00:00', 0),
	('B', 'B123', 724, '12:00:00', 0),
	('C', 'C123', 865, '12:00:00', 0),
	('D', 'D123', 456, '12:00:00', 0),
	('E', 'E123', 572, '12:00:00', 0)

--09. Change Primary Key
USE [Minions]

ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC27BCDB21A3]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIDUsername] PRIMARY KEY ([ID], [Username])

--10. Add Check Constraint
USE [Minions]

ALTER TABLE [Users]
ADD CONSTRAINT [PasswordMinLength] CHECK (COL_LENGTH('Users', 'Password') >= 5)

--11. Set Default Value of a Field
USE [Minions]

ALTER TABLE [Users] 
ADD CONSTRAINT [DefaultTime] DEFAULT GETDATE() FOR [LastLoginTime]

--12. Set Unique Field
USE [Minions]

ALTER TABLE [Users]
DROP CONSTRAINT [PK_UsersCompositeIDUsername]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersID] PRIMARY KEY ([ID])

ALTER TABLE [Users]
ADD CONSTRAINT [UsernameMinLength] CHECK (COL_LENGTH('Users', 'Username') >= 3)

--13. Movies Database
CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] 
(
	[ID] INT PRIMARY KEY NOT NULL,
	[DirectorName] VARCHAR(256) NOT NULL, 
	[Notes] VARCHAR(256)
)

CREATE TABLE [Genres] 
(
	[ID] INT PRIMARY KEY NOT NULL,
	[GenreName] VARCHAR(256) NOT NULL, 
	[Notes] VARCHAR(256)
)

CREATE TABLE [Categories] 
(
	[ID] INT PRIMARY KEY NOT NULL,
	[CategoryName] VARCHAR(256) NOT NULL, 
	[Notes] VARCHAR(256)  
)

CREATE TABLE [Movies]
(
	[ID] INT PRIMARY KEY NOT NULL,
	[Title] VARCHAR(256) NOT NULL, 
	[DirectorID] INT NOT NULL, 
	[CopyrightYear] INT NOT NULL, 
	[Length] DECIMAL(3, 2) NOT NULL, 
	[GenreID] INT NOT NULL, 
	[CategoryID] INT NOT NULL, 
	[Rating] INT, 
	[Notes] VARCHAR(256)
)

ALTER TABLE [Movies]
ADD CONSTRAINT [FK_DirectorID] FOREIGN KEY (DirectorID) REFERENCES [Directors]([ID])

ALTER TABLE [Movies]
ADD CONSTRAINT [FK_GenreID] FOREIGN KEY (GenreID) REFERENCES [Genres]([ID])

ALTER TABLE [Movies]
ADD CONSTRAINT [FK_CategoryID] FOREIGN KEY (CategoryID) REFERENCES [Categories]([ID])

INSERT INTO [Directors] ([ID], [DirectorName], [Notes]) VALUES
	(1, 'Peter', NULL),
	(2, 'John', NULL),
	(3, 'Paul', 'More extras needed'),
	(4, 'Stefan', 'Better animations'),
	(5, 'Luke', NULL)

INSERT INTO [Genres] ([ID], [GenreName], [Notes]) VALUES
	(1, 'Drama', 'Crisis and redemption'),
	(2, 'Horror', 'Teenagers go into the woods'),
	(3, 'Romcom', 'They get caught by her parents'),
	(4, 'Comedy', 'Clowns smashing pies in peoples faces'),
	(5, 'Action', 'Lots of blood and explosions')

INSERT INTO [Categories] ([ID], [CategoryName], [Notes]) VALUES
	(1, 'TV Series', NULL),
	(2, 'Film', NULL),
	(3, 'Educational', 'Some weird octopuses'),
	(4, 'Historical', 'Vikings'),
	(5, 'Documentary', 'WW2')

INSERT INTO [Movies] ([ID], [Title], [DirectorID], [CopyrightYear], [Length], [GenreID], [CategoryID], [Rating], [Notes]) VALUES
	(1, 'Fight Club', 1, 1999, 2.33, 1, 2, 8.8, 'Danger is fun'),
	(2, 'How I met your mother', 3, 2005, 0.35, 4, 1, 8.3, '...'),
	(3, 'Joker', 4, 2019, 2, 1, 2, 8.4, 'Nihilism is fun'),
	(4, '300', 5, 2006, 2, 5, 2, 7.6, 'THIS IS SPARTA'),
	(5, 'The Matrix', 5, 1999, 2.25, 5, 2, 8.7, 'Old but good')

--14. Car Rental Database
CREATE DATABASE [Car Rental]

USE [Car Rental]

CREATE TABLE [Categories] 
(
	[ID] INT PRIMARY KEY NOT NULL,
	[CategoryName] VARCHAR(256) NOT NULL, 
	[DailyRate] INT NOT NULL,
	[WeeklyRate] INT NOT NULL,
	[MonthlyRate] INT NOT NULL,
	[WeekendRate] INT NOT NULL
)

CREATE TABLE [Employees]
(
	[ID] INT PRIMARY KEY NOT NULL, 
	[FirstName] VARCHAR(32) NOT NULL, 
	[LastName] VARCHAR(32) NOT NULL, 
	[Title] VARCHAR(32) NOT NULL,
	[Notes] VARCHAR(256)
)

CREATE TABLE [Customers]
(
	[ID] INT PRIMARY KEY NOT NULL, 
	[DriverLicenseNumber] INT NOT NULL, 
	[FullName] VARCHAR(64) NOT NULL,
	[Address] VARCHAR(64),
	[City] VARCHAR(32),
	[ZIPCode] VARCHAR(5),
	[Notes] VARCHAR(256)
)

CREATE TABLE [Cars] 
(
	[ID] INT PRIMARY KEY NOT NULL,
	[PlateNumber] VARCHAR(16) NOT NULL, 
	[Manufacturer] VARCHAR(32) NOT NULL, 
	[Model] VARCHAR(32) NOT NULL, 
	[CarYear] INT NOT NULL,
	[CategoryID] INT NOT NULL,
	[Doors] INT NOT NULL, 
	[Picture] VARBINARY(MAX),
	[Condition] VARCHAR(64),
	[Available] BIT NOT NULL
)

CREATE TABLE [RentalOrders]
(
	[ID] INT PRIMARY KEY NOT NULL, 
	[EmployeeID] INT NOT NULL, 
	[CustomerID] INT NOT NULL, 
	[CarID] INT NOT NULL, 
	[TankLevel] INT NOT NULL, 
	[KilometrageStart] INT NOT NULL, 
	[KilometrageEnd] INT NOT NULL, 
	[TotalKilometrage] INT NOT NULL, 
	[StartDate] CHAR(10) NOT NULL, 
	[EndDate] CHAR(10)  NOT NULL, 
	[TotalDays] CHAR(10)  NOT NULL, 
	[RateApplied] INT NOT NULL, 
	[TaxRate] DECIMAL, 
	[OrderStatus] VARCHAR(64), 
	[Notes] VARCHAR(256) 
)

ALTER TABLE [Cars]
ADD CONSTRAINT [FK_CategoryID] FOREIGN KEY (CategoryID) REFERENCES [Categories]([ID])

ALTER TABLE [RentalOrders]
ADD CONSTRAINT [FK_EmployeeID] FOREIGN KEY (EmployeeID) REFERENCES [Employees]([ID])

ALTER TABLE [RentalOrders]
ADD CONSTRAINT [FK_CustomerID] FOREIGN KEY (CustomerID) REFERENCES [Customers]([ID])

ALTER TABLE [RentalOrders]
ADD CONSTRAINT [FK_CarID] FOREIGN KEY (CarID) REFERENCES [Cars]([ID])

INSERT INTO [Categories] ([ID], [CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate]) VALUES
	(1, 'Business', 150, 1050, 4500, 300),
	(2, 'Off-Road', 200, 1400, 6000, 400),
	(3, 'Sport', 170, 1190, 5100, 340)

INSERT INTO [Employees] ([ID], [FirstName], [LastName], [Title], [Notes]) VALUES
	(1, 'Peter', 'Peterson', 'Manager', NULL),
	(2, 'John', 'Johnson', 'Security', NULL),
	(3, 'Andrew', 'Anderson', 'HR', NULL)

INSERT INTO [Customers] ([ID], [DriverLicenseNumber], [FullName], [Address], [City], [ZIPCode], [Notes]) VALUES
	(1, '534555974', 'Carl Carlson', '4817 Steve Hunt Road', 'Miami', '33176', NULL),
	(2, '684561719', 'Erik Erikson', '4899 Hickory Ridge Drive', 'Las Vegas', '89030', NULL),
	(3, '879452138', 'George Washington',  '1040 Edgewood Road', 'Memphis', '38116', NULL)

INSERT INTO [Cars] ([ID], [PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryID], [Doors], [Picture], [Condition], [Available]) VALUES
	(1, 'CA0330KM', 'BMW', 'X5', 2014, 1, 4, NULL, 'good', 1),
	(2, 'CB5871CK', 'Mistubishi', 'ASX', 2011, 2, 4, NULL, 'good', 1),
	(3, 'PA1574BK', 'Mercedes', 'S63 AMG', 2018, 3, 4, NULL, 'excellent', 1)

INSERT INTO [RentalOrders] ([ID], [EmployeeID], [CustomerID], [CarID], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes]) VALUES
	(1, 2, 3, 1, 58000, 152423, 156423, 4000, '12/10/2021', '19/10/2021', 7, 875, 15.00, 'paid', NULL),
	(2, 1, 2, 3, 78000, 254879, 259879, 5000, '06/12/2021', '09/12/2021', 3, 495, 15.00, 'paid', NULL),
	(3, 3, 1, 2, 67500,  0, 0, 0, '11/09/2021', '15/09/2021', 4, 340, 15.00, 'paid', NULL)

--15. Car Rental Database
CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees]
(
	[ID] INT PRIMARY KEY NOT NULL,
	[FirstName] VARCHAR(32) NOT NULL,
	[LastName] VARCHAR(32) NOT NULL, 
	[Title] VARCHAR(64) NOT NULL, 
	[Notes] VARCHAR(256)
)

CREATE TABLE [Customers]
(
	[AccountNumber] INT PRIMARY KEY NOT NULL, 
	[FirstName] VARCHAR(32) NOT NULL, 
	[LastName] VARCHAR(32) NOT NULL, 
	[PhoneNumber] VARCHAR(16) NOT NULL, 
	[EmergencyName] VARCHAR(64), 
	[EmergencyNumber] VARCHAR(32),
	[Notes] VARCHAR(256)
)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] VARCHAR(16) NOT NULL,
	[Notes] VARCHAR(256)
)

CREATE TABLE [RoomTypes]
(
	[RoomType] VARCHAR(64) NOT NULL,
	[Notes] VARCHAR(256)
)

CREATE TABLE [BedTypes]
(
	[BedType] VARCHAR(64) NOT NULL,
	[Notes] VARCHAR(256)
)

CREATE TABLE [Rooms]
(
	[RoomNumber] INT NOT NULL,
	[RoomType] VARCHAR(32) NOT NULL,
	[BedType] VARCHAR(32) NOT NULL,
	[Rate] INT NOT NULL,
	[RoomStatus] VARCHAR(32) NOT NULL,
	[Notes] VARCHAR(256)
)

CREATE TABLE [Payments]
(
	[ID] INT PRIMARY KEY NOT NULL, 
	[EmployeeID] INT FOREIGN KEY REFERENCES [Employees]([ID]), 
	[PaymentDate] CHAR(10) NOT NULL, 
	[AccountNumber] INT NOT NULL, 
	[FirstDateOccupied] CHAR(10) NOT NULL, 
	[LastDateOccupied] CHAR(10) NOT NULL, 
	[TotalDays] INT NOT NULL, 
	[AmountCharged] DECIMAL(10,2) NOT NULL, 
	[TaxRate] DECIMAL(5,2) NOT NULL, 
	[TaxAmount] DECIMAL(5,2) NOT NULL, 
	[PaymentTotal] DECIMAL(10,2) NOT NULL, 
	[Notes] VARCHAR(256)
)

CREATE TABLE [Occupancies]
(
	[ID] INT PRIMARY KEY NOT NULL, 
	[EmployeeID] INT FOREIGN KEY REFERENCES [Employees]([ID]), 
	[DateOccupied] VARCHAR(10) NOT NULL, 
	[AccountNumber] INT NOT NULL,
	[RoomNumber] INT NOT NULL, 
	[RateApplied] DECIMAL(5,2) NOT NULL, 
	[PhoneCharge] DECIMAL(10,2) NOT NULL, 
	[Notes] VARCHAR(256)
)

INSERT INTO [Employees] VALUES
	(1, 'Peter', 'Peterson', 'Manager', NULL),
	(2, 'John', 'Johnson', 'Security', NULL),
	(3, 'Andrew', 'Anderson', 'HR', NULL)

INSERT INTO [Customers] VALUES
	(1, 'Carl', 'Carlson', '+185619987', 'Ben', '+564897751', NULL),
	(2, 'Erik', 'Erikson', '+798451231', 'Bill', '+445792587', NULL),
	(3, 'George', 'Washington', '+456213454', 'Sam', '+157792587', NULL)

INSERT INTO [RoomStatus] VALUES
	('Occupied', NULL),
	('Occupied', NULL),
	('Vacant', NULL)

INSERT INTO [RoomTypes] VALUES
	('One bedroom', NULL),
	('Two bedrooms', NULL),
	('President room', NULL)

INSERT INTO [BedTypes] VALUES
	('One single bed', NULL),
	('Two single beds', NULL),
	('Two double beds', NULL)

INSERT INTO [Rooms] VALUES
	(1, 'One bedroom', 'One single bed', 145, 'Occupied', NULL),
	(2, 'Two bedrooms', 'Two single beds', 160, 'Occupied', NULL),
	(3, 'President room', 'Two double beds', 240, 'Vacant', NULL)

INSERT INTO [Payments] VALUES
	(1, 3, '09/10/2021', 789546532, '02/10/2021', '09/10/2021', 7, 800.00, 15.00, 120.00, 920.00, NULL),
	(2, 2, '11/10/2021', 218465186, '08/10/2021', '11/10/2021', 3, 1200.00, 15.00, 180.00, 1380.00, NULL),
	(3, 1, '05/10/2021', 789541237, '01/10/2021', '05/10/2021', 4, 2100.00, 15.00, 315.00, 2415.00, NULL)

INSERT INTO [Occupancies] VALUES
	(1, 2, '22/10/2021', 789546532, 1, 125.00, 0.00, NULL),
	(2, 1, '18/10/2021', 218465186, 3, 165.00, 0.00, NULL),
	(3, 3, '20/10/2021', 789541237, 5, 85.00, 0.00, NULL)

--16. SoftUni Database
CREATE DATABASE [SoftUni]

USE [SoftUni]

CREATE TABLE [Towns]
(
	[ID] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR(31) NOT NULL
)

CREATE TABLE [Addresses]
(
	[ID] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[AddressText] VARCHAR(256) NOT NULL,
	[TownID] INT FOREIGN KEY (TownID) REFERENCES [Towns]([ID])
)

CREATE TABLE [Departments]
(
	[ID] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR(32) NOT NULL
)

CREATE TABLE [Employees]
(
	[ID] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[FirstName] VARCHAR(32) NOT NULL,
	[MiddleName] VARCHAR(32), 
	[LastName] VARCHAR(32) NOT NULL, 
	[JobTitle] VARCHAR(64) NOT NULL, 
	[DepartmentID] INT FOREIGN KEY (DepartmentID) REFERENCES [Departments]([ID]), 
	[HireDate] CHAR(10) NOT NULL, 
	[Salary] DECIMAL(6, 2), 
	[AddressID] INT FOREIGN KEY (AddressID) REFERENCES [Addresses]([ID])
)

--17. Backup Database

--18. Basic Insert
USE [SoftUni]

INSERT INTO [Towns] VALUES
	('Sofia'), 
	('Plovdiv'), 
	('Varna'), 
	('Burgas')

INSERT INTO [Departments] VALUES
	('Engineering'), 
	('Sales'), 
	('Marketing'), 
	('Software Development'), 
	('Quality Assurance')

INSERT INTO [Employees] VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00, NULL),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00, NULL),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '28/08/2016', 525.25, NULL),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '09/12/2007', 3000.00, NULL),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '28/08/2016', 599.88, NULL)

--19. Basic Select All Fields
USE [SoftUni]

SELECT * FROM [dbo].[Towns]
SELECT * FROM [dbo].[Departments]
SELECT * FROM [dbo].[Employees]

--20. Basic Select All Fields and Order Them
USE [SoftUni]

SELECT * FROM [dbo].[Towns]
ORDER BY [Name]
SELECT * FROM [dbo].[Departments]
ORDER BY [Name]
SELECT * FROM [dbo].[Employees]
ORDER BY [Salary] DESC

--21. Basic Select Some Fields
USE [SoftUni]

SELECT [Name] FROM [dbo].[Towns]
ORDER BY [Name]
SELECT [Name] FROM [dbo].[Departments]
ORDER BY [Name]
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [dbo].[Employees]
ORDER BY [Salary] DESC

--22. Increase Employees Salary
USE [SoftUni]

UPDATE [dbo].[Employees]
SET [Salary] *= 1.1
SELECT [Salary] FROM [dbo].[Employees]

--23. Decrease Tax Rate
USE [Hotel]

UPDATE [dbo].[Payments]
SET [TaxRate] *= 0.97
SELECT [TaxRate] FROM [dbo].[Payments]

--24. Delete All Records
USE [Hotel]

DELETE [Occupancies]