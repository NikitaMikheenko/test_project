USE [master]
GO
/****** Object:  Database [TestTaskDB]    Script Date: 14.02.2019 15:21:57 ******/
CREATE DATABASE [TestTaskDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestTaskDB', FILENAME = N'D:\Qulix\TestTaskDB\TestTaskDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestTaskDB_log', FILENAME = N'D:\Qulix\TestTaskDB\TestTaskDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestTaskDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestTaskDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestTaskDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestTaskDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestTaskDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestTaskDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestTaskDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestTaskDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestTaskDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestTaskDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestTaskDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestTaskDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestTaskDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestTaskDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestTaskDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestTaskDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestTaskDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestTaskDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestTaskDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestTaskDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestTaskDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestTaskDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestTaskDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TestTaskDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TestTaskDB]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Size] [int] NULL,
	[OrganizationLegalForm] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Workers]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[DateOfEmployment] [nvarchar](10) NULL,
	[Position] [nvarchar](16) NULL,
	[CompanyId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE SET NULL
GO
/****** Object:  StoredProcedure [dbo].[CreateCompany]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateCompany]
AS
INSERT Companies OUTPUT inserted.Id DEFAULT VALUES
GO
/****** Object:  StoredProcedure [dbo].[CreateWorker]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateWorker]
AS
INSERT Workers OUTPUT inserted.Id DEFAULT VALUES
GO
/****** Object:  StoredProcedure [dbo].[DeleteCompany]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCompany]
@id INT
AS
DELETE Companies WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[DeleteWorker]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteWorker]
@id INT
AS
DELETE Workers WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetCompaniesList]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCompaniesList]
AS
SELECT * FROM Companies
GO
/****** Object:  StoredProcedure [dbo].[GetCompanyById]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCompanyById]
@id INT
AS
SELECT * FROM Companies WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetWorkerById]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetWorkerById]
@id INT
AS
SELECT Workers.Id, Workers.Surname, Workers.Name, Workers.MiddleName, Workers.DateOfEmployment,
	Workers.Position, Companies.Id AS CompanyId, Companies.Name AS CompanyName,
	Companies.Size AS CompanySize, Companies.OrganizationLegalForm AS CompanyOrganizationLegalForm
FROM Workers
JOIN Companies ON Companies.Id = Workers.CompanyId
WHERE Workers.Id = @id
GO
/****** Object:  StoredProcedure [dbo].[GetWorkersList]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetWorkersList]
AS
SELECT Workers.Id, Workers.Surname, Workers.Name, Workers.MiddleName, Workers.DateOfEmployment,
	Workers.Position, Companies.Id AS CompanyId, Companies.Name AS CompanyName,
	Companies.Size AS CompanySize, Companies.OrganizationLegalForm AS CompanyOrganizationLegalForm
FROM Workers
JOIN Companies ON Companies.Id = Workers.CompanyId
GO
/****** Object:  StoredProcedure [dbo].[SaveCompany]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveCompany]
@id INT,
@name NVARCHAR(100),
@size INT,
@organizationLegalForm NVARCHAR(100)
AS
UPDATE Companies SET 
Name = @name, 
Size = @size, 
OrganizationLegalForm = @organizationLegalForm
WHERE Id = @id
GO
/****** Object:  StoredProcedure [dbo].[SaveWorker]    Script Date: 14.02.2019 15:21:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SaveWorker]
@id INT,
@surname NVARCHAR(100),
@name NVARCHAR(100),
@middleName NVARCHAR(100),
@dateOfEmployment NVARCHAR(10),
@position NVARCHAR(16),
@companyId INT
AS
UPDATE Workers SET
Surname = @surname,
Name = @name,
MiddleName = @middleName,
DateOfEmployment = @dateOfEmployment,
Position = @position,
CompanyId = @companyId
WHERE Id = @id
GO
USE [master]
GO
ALTER DATABASE [TestTaskDB] SET  READ_WRITE 
GO
