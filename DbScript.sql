USE [LogisticsBackOffice]
GO
ALTER TABLE [dbo].[WorkOrder] DROP CONSTRAINT [FK_WorkOrder_Worker_WorkerId]
GO
ALTER TABLE [dbo].[WorkOrder] DROP CONSTRAINT [FK_WorkOrder_Status_OrderStatusId]
GO
ALTER TABLE [dbo].[WorkOrder] DROP CONSTRAINT [FK_WorkOrder_Service_ServiceId]
GO
ALTER TABLE [dbo].[WorkOrder] DROP CONSTRAINT [FK_WorkOrder_ProjectDetail_ProjectDetailId]
GO
ALTER TABLE [dbo].[WorkOrder] DROP CONSTRAINT [FK_WorkOrder_Project_ProjectId]
GO
ALTER TABLE [dbo].[Worker] DROP CONSTRAINT [FK_Worker_GeographicalInfo_GeographicalInfoId]
GO
ALTER TABLE [dbo].[State] DROP CONSTRAINT [FK_State_CountryRegion_CountryRegionId]
GO
ALTER TABLE [dbo].[ProjectGeographicalInfo] DROP CONSTRAINT [FK_ProjectGeographicalInfo_Project_ProjectId]
GO
ALTER TABLE [dbo].[ProjectDetail] DROP CONSTRAINT [FK_ProjectDetail_Service_ServiceId]
GO
ALTER TABLE [dbo].[ProjectDetail] DROP CONSTRAINT [FK_ProjectDetail_Project_ProjectId]
GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Status_StatusId]
GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_GeographicalInfo_GeographicalInfoId]
GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_CourierCompany_CourierCompanyId]
GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Contact_ContactId]
GO
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_Client_ClientId]
GO
ALTER TABLE [dbo].[GeographicalInfo] DROP CONSTRAINT [FK_GeographicalInfo_State_StateId]
GO
ALTER TABLE [dbo].[GeographicalInfo] DROP CONSTRAINT [FK_GeographicalInfo_ProjectGeographicalInfo_ProjectId]
GO
ALTER TABLE [dbo].[ClientContact] DROP CONSTRAINT [FK_ClientContact_Contact_ContactId]
GO
ALTER TABLE [dbo].[ClientContact] DROP CONSTRAINT [FK_ClientContact_Client_ClientId]
GO
ALTER TABLE [dbo].[Client] DROP CONSTRAINT [FK_Client_GeographicalInfo_GeographicalInfoId]
GO
ALTER TABLE [dbo].[WorkOrder] DROP CONSTRAINT [DF__WorkOrder__Done__6B79F03D]
GO
ALTER TABLE [dbo].[State] DROP CONSTRAINT [DF__State__LastModif__5B78929E]
GO
ALTER TABLE [dbo].[Service] DROP CONSTRAINT [DF__Service__Rate__2D7CBDC4]
GO
ALTER TABLE [dbo].[CountryRegion] DROP CONSTRAINT [DF__CountryRe__LastM__5D60DB10]
GO
ALTER TABLE [dbo].[ClientContact] DROP CONSTRAINT [DF__ClientCon__LastM__5E54FF49]
GO
ALTER TABLE [dbo].[Client] DROP CONSTRAINT [DF__Client__Done__3F115E1A]
GO
/****** Object:  Table [dbo].[WorkOrder]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WorkOrder]') AND type in (N'U'))
DROP TABLE [dbo].[WorkOrder]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Worker]') AND type in (N'U'))
DROP TABLE [dbo].[Worker]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status]') AND type in (N'U'))
DROP TABLE [dbo].[Status]
GO
/****** Object:  Table [dbo].[State]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Service]') AND type in (N'U'))
DROP TABLE [dbo].[Service]
GO
/****** Object:  Table [dbo].[ProjectGeographicalInfo]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectGeographicalInfo]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectGeographicalInfo]
GO
/****** Object:  Table [dbo].[ProjectDetail]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectDetail]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectDetail]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project]') AND type in (N'U'))
DROP TABLE [dbo].[Project]
GO
/****** Object:  Table [dbo].[GeographicalInfo]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GeographicalInfo]') AND type in (N'U'))
DROP TABLE [dbo].[GeographicalInfo]
GO
/****** Object:  Table [dbo].[CourierCompany]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CourierCompany]') AND type in (N'U'))
DROP TABLE [dbo].[CourierCompany]
GO
/****** Object:  Table [dbo].[CountryRegion]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CountryRegion]') AND type in (N'U'))
DROP TABLE [dbo].[CountryRegion]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
DROP TABLE [dbo].[Contact]
GO
/****** Object:  Table [dbo].[ClientContact]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientContact]') AND type in (N'U'))
DROP TABLE [dbo].[ClientContact]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 4/7/2024 11:53:17 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
DROP TABLE [dbo].[Client]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](3) NULL,
	[FullName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Suffix] [nvarchar](4) NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Cellphone] [nvarchar](50) NOT NULL,
	[AdditionalInfo] [nvarchar](150) NOT NULL,
	[GeographicalInfoId] [int] NOT NULL,
	[Done] [bit] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientContact]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ClientContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Suffix] [nvarchar](4) NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Cellphone] [nvarchar](50) NOT NULL,
	[AdditionalInfo] [nvarchar](150) NULL,
	[Role] [nvarchar](50) NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CountryRegion]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryRegion](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryRegionCode] [nvarchar](2) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CountryRegion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourierCompany]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourierCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_CourierCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeographicalInfo]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeographicalInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [nvarchar](100) NOT NULL,
	[AddressLine2] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[PostalCode] [nvarchar](10) NOT NULL,
	[Latitude] [nvarchar](20) NULL,
	[Longitude] [nvarchar](20) NULL,
	[LocationName] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](30) NOT NULL,
	[ProjectId] [int] NULL,
	[ProjectGeographicalInfoId] [int] NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NULL,
 CONSTRAINT [PK_GeographicalInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[ReceivingDate] [datetime2](7) NULL,
	[ProcessingDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[TotalReceivedPackages] [int] NULL,
	[TotalWorkers] [int] NULL,
	[Sidemark] [nvarchar](max) NULL,
	[ContactId] [int] NOT NULL,
	[DeclaredValueInsurace] [bit] NULL,
	[Amount] [decimal](18, 2) NULL,
	[InspectionNotes] [nvarchar](max) NULL,
	[ReplaytoEmail] [bit] NULL,
	[EmailSent] [nvarchar](80) NULL,
	[GeographicalInfoId] [int] NOT NULL,
	[CourierCompanyId] [int] NULL,
	[DriverName] [nvarchar](80) NULL,
	[ShippingNumber] [nvarchar](80) NULL,
	[ShipperOrigin] [nvarchar](80) NULL,
	[ProjectQRGenerated] [nvarchar](max) NULL,
	[Done] [bit] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[StatusId] [int] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectDetail]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[Duration] [decimal](18, 2) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NULL,
 CONSTRAINT [PK_ProjectDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectGeographicalInfo]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectGeographicalInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[GeographicalInfoId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProjectGeographicalInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsReceivingService] [bit] NULL,
	[IsProcessingService] [bit] NULL,
	[IsWarehouseService] [bit] NULL,
	[IsCleaningService] [bit] NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NULL,
	[Rate] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[StateCode] [nvarchar](3) NOT NULL,
	[CountryRegionId] [int] NOT NULL,
	[TerritoryId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Entity] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Order] [int] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](4) NULL,
	[FullName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Cellphone] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[AdditionalInfo] [nvarchar](100) NULL,
	[GeographicalInfoId] [int] NOT NULL,
	[UserId] [int] NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkOrder]    Script Date: 4/7/2024 11:53:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectDetailId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[WorkerId] [int] NOT NULL,
	[HoursAmount] [decimal](18, 2) NOT NULL,
	[ScheduledStartDate] [datetime2](7) NULL,
	[ScheduledEndDate] [datetime2](7) NULL,
	[ModifiedEndDate] [datetime2](7) NULL,
	[ProjectId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[LastModified] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](100) NULL,
	[StatusId] [int] NULL,
	[OrderStatusId] [int] NULL,
	[Done] [bit] NOT NULL,
 CONSTRAINT [PK_WorkOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Done]
GO
ALTER TABLE [dbo].[ClientContact] ADD  DEFAULT (N'') FOR [LastModifiedBy]
GO
ALTER TABLE [dbo].[CountryRegion] ADD  DEFAULT (N'') FOR [LastModifiedBy]
GO
ALTER TABLE [dbo].[Service] ADD  DEFAULT ((0.0)) FOR [Rate]
GO
ALTER TABLE [dbo].[State] ADD  DEFAULT (N'') FOR [LastModifiedBy]
GO
ALTER TABLE [dbo].[WorkOrder] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Done]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_GeographicalInfo_GeographicalInfoId] FOREIGN KEY([GeographicalInfoId])
REFERENCES [dbo].[GeographicalInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_GeographicalInfo_GeographicalInfoId]
GO
ALTER TABLE [dbo].[ClientContact]  WITH CHECK ADD  CONSTRAINT [FK_ClientContact_Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientContact] CHECK CONSTRAINT [FK_ClientContact_Client_ClientId]
GO
ALTER TABLE [dbo].[ClientContact]  WITH CHECK ADD  CONSTRAINT [FK_ClientContact_Contact_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClientContact] CHECK CONSTRAINT [FK_ClientContact_Contact_ContactId]
GO
ALTER TABLE [dbo].[GeographicalInfo]  WITH CHECK ADD  CONSTRAINT [FK_GeographicalInfo_ProjectGeographicalInfo_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ProjectGeographicalInfo] ([Id])
GO
ALTER TABLE [dbo].[GeographicalInfo] CHECK CONSTRAINT [FK_GeographicalInfo_ProjectGeographicalInfo_ProjectId]
GO
ALTER TABLE [dbo].[GeographicalInfo]  WITH CHECK ADD  CONSTRAINT [FK_GeographicalInfo_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[GeographicalInfo] CHECK CONSTRAINT [FK_GeographicalInfo_State_StateId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Client_ClientId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Contact_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Contact_ContactId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_CourierCompany_CourierCompanyId] FOREIGN KEY([CourierCompanyId])
REFERENCES [dbo].[CourierCompany] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_CourierCompany_CourierCompanyId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_GeographicalInfo_GeographicalInfoId] FOREIGN KEY([GeographicalInfoId])
REFERENCES [dbo].[GeographicalInfo] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_GeographicalInfo_GeographicalInfoId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Status_StatusId]
GO
ALTER TABLE [dbo].[ProjectDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDetail_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectDetail] CHECK CONSTRAINT [FK_ProjectDetail_Project_ProjectId]
GO
ALTER TABLE [dbo].[ProjectDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProjectDetail_Service_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectDetail] CHECK CONSTRAINT [FK_ProjectDetail_Service_ServiceId]
GO
ALTER TABLE [dbo].[ProjectGeographicalInfo]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeographicalInfo_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectGeographicalInfo] CHECK CONSTRAINT [FK_ProjectGeographicalInfo_Project_ProjectId]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_CountryRegion_CountryRegionId] FOREIGN KEY([CountryRegionId])
REFERENCES [dbo].[CountryRegion] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_CountryRegion_CountryRegionId]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_GeographicalInfo_GeographicalInfoId] FOREIGN KEY([GeographicalInfoId])
REFERENCES [dbo].[GeographicalInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_GeographicalInfo_GeographicalInfoId]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Project_ProjectId]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_ProjectDetail_ProjectDetailId] FOREIGN KEY([ProjectDetailId])
REFERENCES [dbo].[ProjectDetail] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_ProjectDetail_ProjectDetailId]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Service_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Service] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Service_ServiceId]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Status_OrderStatusId] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Status_OrderStatusId]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Worker_WorkerId] FOREIGN KEY([WorkerId])
REFERENCES [dbo].[Worker] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Worker_WorkerId]
GO
