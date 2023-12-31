USE [master]
GO
/****** Object:  Database [LogisticsBackOffice]    Script Date: 9/1/2023 8:31:14 PM ******/
CREATE DATABASE [LogisticsBackOffice]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LogisticsBackOffice', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLDEVELOPMENT\MSSQL\DATA\LogisticsBackOffice.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LogisticsBackOffice_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLDEVELOPMENT\MSSQL\DATA\LogisticsBackOffice_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LogisticsBackOffice] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LogisticsBackOffice].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LogisticsBackOffice] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET ARITHABORT OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LogisticsBackOffice] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LogisticsBackOffice] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LogisticsBackOffice] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LogisticsBackOffice] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LogisticsBackOffice] SET  MULTI_USER 
GO
ALTER DATABASE [LogisticsBackOffice] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LogisticsBackOffice] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LogisticsBackOffice] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LogisticsBackOffice] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LogisticsBackOffice] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LogisticsBackOffice] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LogisticsBackOffice] SET QUERY_STORE = ON
GO
ALTER DATABASE [LogisticsBackOffice] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LogisticsBackOffice]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](2) NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Suffix] [nchar](4) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Cellphone] [nvarchar](50) NULL,
	[AdditionalInfo] [nvarchar](50) NULL,
	[GeographicalInfoId] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientContact]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
 CONSTRAINT [PK_ClientContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](4) NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Suffix] [nchar](4) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Cellphone] [nvarchar](50) NULL,
	[Role] [nchar](30) NULL,
	[AdditionalInfo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountryRegion]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryRegion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryRegionCode] [nchar](2) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CountryRegion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeographicalInfo]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeographicalInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [varchar](50) NOT NULL,
	[AddressLine2] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[PostalCode] [varchar](10) NOT NULL,
	[Latitude] [nchar](12) NOT NULL,
	[Longitude] [nchar](12) NOT NULL,
	[LocationName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
 CONSTRAINT [PK_GeographicalInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operator]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](4) NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CellPhone] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[AdditionalInfo] [nvarchar](50) NULL,
	[GeographicalInfoId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ReceivingStartDate] [datetime] NULL,
	[ProcessingDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[TotalReceivedPackages] [int] NULL,
	[TotalOperators] [decimal](18, 0) NULL,
	[Sidemark] [int] NULL,
	[ContactId] [int] NOT NULL,
	[DeclaredValueInsurance] [bit] NULL,
	[Amount] [numeric](18, 2) NULL,
	[InspectionNotes] [nvarchar](max) NULL,
	[ReplaytoEmail] [bit] NULL,
	[EmailSent] [varchar](80) NULL,
	[GeographicalInfoId] [int] NOT NULL,
	[OperatorIdReceiving] [int] NOT NULL,
	[DeliveryCompanyId] [int] NULL,
	[DriverName] [nvarchar](80) NULL,
	[ShippingNumber] [nvarchar](80) NULL,
	[ShipperOrigin] [nvarchar](80) NULL,
	[ProjectQRGenerated] [varbinary](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectDetail]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Duration] [numeric](18, 2) NOT NULL,
	[Rate] [numeric](18, 2) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_ProjectDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectGeographicalInfo]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectGeographicalInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[GeographicalInfoId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectGeographicalInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsReceivingService] [bit] NOT NULL,
	[IsProcessingService] [bit] NOT NULL,
	[IsWarehouseService] [bit] NOT NULL,
	[IsCleaningService] [bit] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StateCode] [varchar](2) NOT NULL,
	[CountryRegionId] [int] NOT NULL,
	[TerritoryId] [int] NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkOrder]    Script Date: 9/1/2023 8:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectDetailId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[OperatorId] [int] NOT NULL,
	[HoursAmount] [decimal](18, 0) NULL,
	[ScheduledStartDate] [datetime] NULL,
	[ScheduledEndDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_OperatorTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_GeographicalInfo] FOREIGN KEY([GeographicalInfoId])
REFERENCES [dbo].[GeographicalInfo] ([Id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_GeographicalInfo]
GO
ALTER TABLE [dbo].[ClientContact]  WITH CHECK ADD  CONSTRAINT [FK_ClientContact_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ClientContact] CHECK CONSTRAINT [FK_ClientContact_Client]
GO
ALTER TABLE [dbo].[ClientContact]  WITH CHECK ADD  CONSTRAINT [FK_ClientContact_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[ClientContact] CHECK CONSTRAINT [FK_ClientContact_Contact]
GO
ALTER TABLE [dbo].[GeographicalInfo]  WITH CHECK ADD  CONSTRAINT [FK_GeographicalInfo_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[GeographicalInfo] CHECK CONSTRAINT [FK_GeographicalInfo_State]
GO
ALTER TABLE [dbo].[Operator]  WITH CHECK ADD  CONSTRAINT [FK_Operator_GeographicalInfo] FOREIGN KEY([GeographicalInfoId])
REFERENCES [dbo].[GeographicalInfo] ([Id])
GO
ALTER TABLE [dbo].[Operator] CHECK CONSTRAINT [FK_Operator_GeographicalInfo]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_GeographicalInfo] FOREIGN KEY([GeographicalInfoId])
REFERENCES [dbo].[GeographicalInfo] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_GeographicalInfo]
GO
ALTER TABLE [dbo].[ProjectDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDetail_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectDetail] CHECK CONSTRAINT [FK_ProjectDetail_Project]
GO
ALTER TABLE [dbo].[ProjectDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDetail_Task] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ProjectDetail] CHECK CONSTRAINT [FK_ProjectDetail_Task]
GO
ALTER TABLE [dbo].[ProjectGeographicalInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeographicalInfo_GeographicalInfo] FOREIGN KEY([GeographicalInfoId])
REFERENCES [dbo].[GeographicalInfo] ([Id])
GO
ALTER TABLE [dbo].[ProjectGeographicalInfo] CHECK CONSTRAINT [FK_ProjectGeographicalInfo_GeographicalInfo]
GO
ALTER TABLE [dbo].[ProjectGeographicalInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeographicalInfo_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectGeographicalInfo] CHECK CONSTRAINT [FK_ProjectGeographicalInfo_Project]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_CountryRegion] FOREIGN KEY([CountryRegionId])
REFERENCES [dbo].[CountryRegion] ([Id])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_CountryRegion]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDetailTask_Operator] FOREIGN KEY([OperatorId])
REFERENCES [dbo].[Operator] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_ProjectDetailTask_Operator]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDetailTask_ProjectDetail] FOREIGN KEY([ProjectDetailId])
REFERENCES [dbo].[ProjectDetail] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_ProjectDetailTask_ProjectDetail]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDetailTask_Task] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_ProjectDetailTask_Task]
GO
USE [master]
GO
ALTER DATABASE [LogisticsBackOffice] SET  READ_WRITE 
GO
