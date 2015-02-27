/****** Object:  Role [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Membership_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Membership_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Membership_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Membership_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Membership_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Membership_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Personalization_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Personalization_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Personalization_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Personalization_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Personalization_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Personalization_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Profile_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Profile_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Profile_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Profile_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Profile_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Profile_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Roles_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Roles_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Roles_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Roles_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_Roles_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_Roles_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Role [aspnet_WebEvent_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE ROLE [aspnet_WebEvent_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_WebEvent_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_WebEvent_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Roles_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Roles_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Roles_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Roles_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Roles_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Roles_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Profile_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Profile_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Profile_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Profile_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Profile_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Profile_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Personalization_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Personalization_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Personalization_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Personalization_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Personalization_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Personalization_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Membership_ReportingAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Membership_ReportingAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Membership_FullAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Membership_FullAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_Membership_BasicAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_Membership_BasicAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess]    Script Date: 12/29/2014 16:38:47 ******/
CREATE SCHEMA [aspnet_ChangeNotification_ReceiveNotificationsOnlyAccess] AUTHORIZATION [dbo]
GO
/****** Object:  Table [dbo].[ModuleMessage]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleMessage](
	[ModuleMessageID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NULL,
	[Message] [ntext] NULL,
	[Culture] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[MessageType] [int] NULL,
	[MessageMode] [int] NULL,
	[MessagePosition] [int] NULL,
 CONSTRAINT [PK_ModuleMessage] PRIMARY KEY CLUSTERED 
(
	[ModuleMessageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MessageTemplate]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplate](
	[MessageTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[MessageTemplateTypeID] [int] NOT NULL,
	[Subject] [nvarchar](200) NOT NULL,
	[Body] [ntext] NOT NULL,
	[MailFrom] [nvarchar](100) NOT NULL,
	[Culture] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MessageTemplate] PRIMARY KEY CLUSTERED 
(
	[MessageTemplateID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MenuPermission]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuPermission](
	[MenuPermissionID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NULL,
	[PermissionID] [int] NULL,
	[AllowAccess] [bit] NULL,
	[RoleID] [uniqueidentifier] NULL,
	[Username] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MenuPermission] PRIMARY KEY CLUSTERED 
(
	[MenuPermissionID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[BgBanner]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BgBanner](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](250) NULL,
	[Culture] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[ImageOrder] [int] NULL,
	[ImageLink] [nvarchar](250) NULL,
	[PortalID] [int] NULL,
 CONSTRAINT [PK_BgBanner] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[BannerImage]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BannerImage](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[BannerID] [int] NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[ImagePath] [nvarchar](256) NULL,
	[Caption] [nvarchar](max) NULL,
	[LinkToImage] [nvarchar](256) NULL,
	[HTMLBodyText] [nvarchar](max) NULL,
	[NavigationImage] [nvarchar](256) NULL,
	[ReadButtonText] [nvarchar](256) NULL,
	[ReadMorePage] [nvarchar](256) NULL,
	[Description] [nvarchar](max) NULL,
	[PortalID] [int] NULL,
	[DisplayOrder] [int] NULL,
	[CultureCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_BannerImage] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SessionTracker]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionTracker](
	[SessionTrackerID] [int] IDENTITY(1,1) NOT NULL,
	[SessionUserHostAddress] [nvarchar](500) NULL,
	[SessionUserAgent] [nvarchar](500) NULL,
	[SessionBrowser] [nvarchar](500) NULL,
	[SessionCrawler] [nvarchar](500) NULL,
	[SessionURL] [nvarchar](500) NULL,
	[SessionVisitCount] [int] NULL,
	[SessionOriginalReferrer] [nvarchar](500) NULL,
	[SessionOriginalURL] [nvarchar](500) NULL,
	[Start] [datetime] NULL,
	[End] [datetime] NULL,
	[Username] [nvarchar](256) NULL,
	[PortalID] [int] NULL,
 CONSTRAINT [PK_SessionTracker] PRIMARY KEY CLUSTERED 
(
	[SessionTrackerID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Email] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[UserModules_History]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModules_History](
	[OperationDate] [datetime] NOT NULL,
	[OperationType] [char](1) NOT NULL,
	[OperationId] [nvarchar](256) NOT NULL,
	[UserModuleID] [int] NULL,
	[ModuleDefID] [int] NULL,
	[UserModuleTitle] [nvarchar](256) NULL,
	[AllPages] [bit] NULL,
	[InheritViewPermissions] [bit] NULL,
	[Header] [ntext] NULL,
	[Footer] [ntext] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[SEOName] [nvarchar](100) NULL,
	[ShowInPages] [nvarchar](256) NULL,
	[IsHandheld] [bit] NULL,
	[SuffixClass] [nvarchar](max) NULL,
	[HeaderText] [nvarchar](500) NULL,
	[ShowHeaderText] [bit] NULL,
	[IsInAdmin] [bit] NULL,
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_UserModules_History] PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageFrameSearchProcedure]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageFrameSearchProcedure](
	[SageFrameSearchProcedureID] [int] IDENTITY(1,1) NOT NULL,
	[SageFrameSearchTitle] [nvarchar](100) NULL,
	[SageFrameSearchProcedureName] [nvarchar](256) NULL,
	[SageFrameSearchProcedureExecuteAs] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_SageFrameSearchProcedure] PRIMARY KEY CLUSTERED 
(
	[SageFrameSearchProcedureID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageBannerSettingValue]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageBannerSettingValue](
	[SageBannerSettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[CultureCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_SageBannerSettingValue] PRIMARY KEY CLUSTERED 
(
	[SageBannerSettingValueID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageBannerSettingKey]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageBannerSettingKey](
	[SageBannerSettingKeyID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_SageBannerSettingKey] PRIMARY KEY CLUSTERED 
(
	[SettingKey] ASC,
	[PortalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageBanner]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageBanner](
	[BannerID] [int] IDENTITY(1,1) NOT NULL,
	[BannerName] [nvarchar](max) NULL,
	[BannerDescription] [nvarchar](max) NULL,
	[UserModuleID] [int] NULL,
	[PortalID] [int] NULL,
	[CultureCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_SageBanner] PRIMARY KEY CLUSTERED 
(
	[BannerID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[robots]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[robots](
	[PortalID] [int] NULL,
	[UserAgent] [nvarchar](50) NULL,
	[PagePath] [nvarchar](max) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_robots] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PropertyType]    Script Date: 12/29/2014 16:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyType](
	[PropertyTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PropertyType] PRIMARY KEY CLUSTERED 
(
	[PropertyTypeID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_AvailableModulesUpdate]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AvailableModulesUpdate]
 @FileName NVARCHAR(256)
AS
BEGIN

 SET NOCOUNT ON;
UPDATE [dbo].[AvailableModules]
SET [IsDeleted]=1 ,[DeletedOn]=GETDATE()
WHERE FolderName=@FileName

END
GO
/****** Object:  StoredProcedure [dbo].[usp_AvailableModulesGet]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AvailableModulesGet]

 @PortalID INT
AS 
BEGIN

 SET NOCOUNT ON;
SELECT AvailableModuleID 
 ,[ModuleName] AS [Name]
 ,[ModuleName]
 ,[FriendlyName]
 ,[Description]
 ,[Version]
 ,[IsPremium]
 ,[IsAdmin]
 ,[BusinessControllerClass]
 ,[FolderName] 
 ,[SupportedFeatures]
 ,[CompatibleVersions]
 ,[Dependencies]
 ,[Permissions]
 ,[PackageID]
 ,[IsActive]
 ,[IsDeleted]
 ,[IsModified]
 ,[AddedOn]
 ,[PortalID]
 ,[AddedBy]
 ,[UpdatedBy]
 ,[DeletedBy]
FROM [dbo].[AvailableModules]
WHERE [IsActive]=1 AND [IsDeleted] =0 AND PortalID=@PortalID
  
END
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[usp_AvailableModulesAdd]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AvailableModulesAdd]
 -- Add the parameters for the stored procedure here
  @FriendlyName NVARCHAR(256)
 ,@Description NVARCHAR(256)
 ,@Version NVARCHAR(256) 
 ,@BusinessControllerClass NVARCHAR(256)
 ,@FolderName NVARCHAR(256)
 ,@ModuleName NVARCHAR(256) 
 ,@IsActive BIT
 ,@IsDeleted BIT
 ,@IsModified BIT 
 ,@PortalID INT
 ,@AddedBy NVARCHAR(256)
 


AS
BEGIN
 
 SET NOCOUNT ON;
IF not exists(SELECT [FolderName] FROM [dbo].[AvailableModules] WHERE [FolderName]=@FolderName and [ModuleName]=@ModuleName and [Version]=@Version and [IsDeleted]=0)
BEGIN
INSERT INTO [dbo].[AvailableModules]
(
 [FriendlyName]
 ,[Description]
 ,[Version] 
 ,[BusinessControllerClass]
 ,[FolderName]
 ,[ModuleName] 
 ,[IsActive]
 ,[IsDeleted]
 ,[IsModified]
 ,[AddedOn]
 ,[PortalID]
 ,[AddedBy]
 
)
VALUES
(
 @FriendlyName 
 ,@Description
 ,@Version  
 ,@BusinessControllerClass 
 ,@FolderName
 ,@ModuleName  
 ,@IsActive 
 ,@IsDeleted 
 ,@IsModified 
 ,GETDATE()  
 ,@PortalID 
 ,@AddedBy 
)
End
END
GO
/****** Object:  Table [dbo].[GoogleAnalytics]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoogleAnalytics](
	[GoogleAnalyticsID] [int] IDENTITY(1,1) NOT NULL,
	[GoogleJSCode] [nvarchar](1500) NULL,
	[IsActive] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_GoogleAnalytics] PRIMARY KEY CLUSTERED 
(
	[GoogleAnalyticsID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PaymentGateWaySetting]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentGateWaySetting](
	[UserModuleID] [int] NOT NULL,
	[PortalID] [int] NOT NULL,
	[Culture] [nvarchar](100) NULL,
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[SettingValue] [nvarchar](max) NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_PaymentGateWaySetting] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Pages_History]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages_History](
	[OperationDate] [datetime] NOT NULL,
	[OperationType] [char](1) NOT NULL,
	[OperationId] [char](24) NOT NULL,
	[PageID] [int] NOT NULL,
	[PageOrder] [int] NULL,
	[PageName] [nvarchar](100) NULL,
	[IsVisible] [bit] NULL,
	[ParentID] [int] NULL,
	[Level] [int] NULL,
	[IconFile] [nvarchar](100) NULL,
	[DisableLink] [bit] NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[KeyWords] [nvarchar](500) NULL,
	[Url] [nvarchar](255) NULL,
	[TabPath] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[RefreshInterval] [decimal](16, 2) NULL,
	[PageHeadText] [nvarchar](500) NULL,
	[IsSecure] [bit] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[SEOName] [nvarchar](100) NULL,
	[IsShowInFooter] [bit] NULL,
	[IsRequiredPage] [bit] NULL,
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Pages_History] PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MenuMgrSettingValue]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuMgrSettingValue](
	[MenuMgrSettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MenuMgrSettingValue] PRIMARY KEY CLUSTERED 
(
	[MenuMgrSettingValueID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MenuMgrSettingKey]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuMgrSettingKey](
	[MenuMgrSettingKey] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModiified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MenuMgrSettingKey] PRIMARY KEY CLUSTERED 
(
	[MenuMgrSettingKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PagePreview]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagePreview](
	[PreviewID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NULL,
	[PreviewCode] [nvarchar](256) NULL,
 CONSTRAINT [PK_PagePreview] PRIMARY KEY CLUSTERED 
(
	[PreviewID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PagePermission_History]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagePermission_History](
	[OperationDate] [datetime] NOT NULL,
	[OperationType] [char](1) NOT NULL,
	[OperationId] [nvarchar](256) NOT NULL,
	[PagePermissionID] [int] NULL,
	[PageID] [int] NULL,
	[PermissionID] [int] NULL,
	[AllowAccess] [bit] NULL,
	[RoleID] [uniqueidentifier] NULL,
	[Username] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PagePermission_History] PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[UDFsplit]    Script Date: 12/29/2014 16:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION [dbo].[UDFsplit]  
(  
    @ListString nvarchar(max),  
    @Delimiter  char(1)  
   )   
RETURNS @ListTable TABLE (SplittedValue NVARCHAR(4000))  WITH EXECUTE AS CALLER    
AS  
BEGIN      
    DECLARE @CurrentPosition INT, @NextPosition INT, @Item NVARCHAR(MAX), @ID INT, @len INT  
     
    SELECT @len = len(replace(@Delimiter,' ','^'))  
   , @ListString = @ListString + @Delimiter  
            , @CurrentPosition = 1   
    SELECT @NextPosition = Charindex(@Delimiter, @ListString, @CurrentPosition)  
 WHILE @NextPosition > 0 Begin  
   SET  @Item = ltrim(rtrim(substring(@ListString, @CurrentPosition, @NextPosition-@CurrentPosition)))  
   INSERT Into @ListTable (SplittedValue) Values (@Item)    
    SET  @CurrentPosition = @NextPosition+@len  
    SET  @NextPosition = Charindex(@Delimiter, @ListString, @CurrentPosition)  
  END  
    RETURN  
END  

------------------------------------------------------------------------------------------------------------------------------------
--GO
GO
/****** Object:  UserDefinedFunction [dbo].[udf_StripHTML]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[udf_StripHTML] (@HTMLText VARCHAR(MAX))  
RETURNS VARCHAR(MAX) AS  
BEGIN  
    DECLARE @Start INT  
    DECLARE @End INT  
    DECLARE @Length INT  
    SET @Start = CHARINDEX('<',@HTMLText)  
    SET @End = CHARINDEX('>',@HTMLText,CHARINDEX('<',@HTMLText))  
    SET @Length = (@End - @Start) + 1  
    WHILE @Start > 0 AND @End > 0 AND @Length > 0  
    BEGIN  
        SET @HTMLText = STUFF(@HTMLText,@Start,@Length,'')  
        SET @Start = CHARINDEX('<',@HTMLText)  
        SET @End = CHARINDEX('>',@HTMLText,CHARINDEX('<',@HTMLText))  
        SET @Length = (@End - @Start) + 1  
    END  
    
 -- SET @HTMLText = REPLACE (@HTMLText,'&nbsp;',' ')
    -- SET @HTMLText = REPLACE (@HTMLText,'&copy;','&#169;')
    RETURN LTRIM(RTRIM(@HTMLText))  
END
GO
/****** Object:  Table [dbo].[TutorialRssContent]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TutorialRssContent](
	[TutorialContent] [text] NULL,
	[UpdatedDate] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TutorialRssContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[TrackSettingValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackSettingValue](
	[TrackSettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_TrackSettingValue] PRIMARY KEY CLUSTERED 
(
	[UserModuleID] ASC,
	[SettingKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[TrackSettingKey]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrackSettingKey](
	[TrackSettingID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_TrackSettingKey] PRIMARY KEY CLUSTERED 
(
	[SettingKey] ASC,
	[PortalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[TemplateTypeToken]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemplateTypeToken](
	[MessageTemplateTypeTokenID] [int] NOT NULL,
	[MessageTemplateTypeID] [int] NOT NULL,
	[MessageTokenID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TemplateTypeToken] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Template]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Template](
	[TemplateID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateTitle] [nvarchar](256) NOT NULL,
	[PortalID] [int] NULL,
	[Author] [nvarchar](256) NULL,
	[Description] [nvarchar](500) NULL,
	[AuthorURL] [nvarchar](256) NULL,
	[AddedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Template] PRIMARY KEY CLUSTERED 
(
	[TemplateID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Template] ON [dbo].[Template] 
(
	[TemplateTitle] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[TaskToDo]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskToDo](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[Note] [ntext] NULL,
	[Date] [date] NULL,
	[PortalId] [int] NULL,
	[ModuleId] [int] NULL,
	[CultureField] [nvarchar](100) NULL,
	[AddedOn] [date] NULL,
	[AddedBy] [nvarchar](100) NULL,
	[UpdateOn] [date] NULL,
	[UpdateBy] [nvarchar](100) NULL,
	[DeletedOn] [date] NULL,
	[Deletedby] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_TaskToDo] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SystemEventLocation]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemEventLocation](
	[EventLocationID] [int] IDENTITY(1,1) NOT NULL,
	[EventLocationName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[AddedOn] [datetime] NULL,
 CONSTRAINT [PK_SystemEventLocation] PRIMARY KEY CLUSTERED 
(
	[EventLocationID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SystemConstrains]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConstrains](
	[SuperuserModuleID] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SystemConstrains] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[NL_SettingValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NL_SettingValue](
	[NL_SettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_NL_SettingValue] PRIMARY KEY CLUSTERED 
(
	[NL_SettingValueID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[NL_SettingKey]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NL_SettingKey](
	[NL_SettingKeyID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_NL_SettingKey] PRIMARY KEY CLUSTERED 
(
	[NL_SettingKeyID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[NL_NewsLetter]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NL_NewsLetter](
	[NewsLetterID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](128) NULL,
	[Body] [nvarchar](max) NULL,
	[IsSubscribed] [bit] NULL,
	[UserModuleID] [int] NULL,
	[PortalID] [int] NULL,
	[AddedOn] [datetime] NULL,
	[AddedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_NL_NewsLetter] PRIMARY KEY CLUSTERED 
(
	[NewsLetterID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[NL_MobileSubsciber]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NL_MobileSubsciber](
	[MobSubscriberID] [int] IDENTITY(1,1) NOT NULL,
	[MobileNumber] [bigint] NULL,
	[IsSubscribed] [bit] NULL,
	[ClientIP] [nvarchar](128) NULL,
	[UserModuleID] [int] NULL,
	[PortalID] [int] NULL,
	[AddedOn] [datetime] NULL,
	[Addedby] [nvarchar](128) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_NL_MobileSubsciber] PRIMARY KEY CLUSTERED 
(
	[MobSubscriberID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[NL_EmailSubscriber]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NL_EmailSubscriber](
	[SubscriberID] [int] IDENTITY(1,1) NOT NULL,
	[SubscriberEmail] [nvarchar](128) NULL,
	[IsSubscribed] [bit] NULL,
	[ClientIP] [nvarchar](128) NULL,
	[AddedOn] [datetime] NULL,
	[AddedBy] [nvarchar](128) NULL,
	[UserModuleID] [int] NULL,
	[PortalID] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_NL_Subscriber] PRIMARY KEY CLUSTERED 
(
	[SubscriberID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[NewsSetting]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsSetting](
	[NewsSettingID] [int] IDENTITY(1,1) NOT NULL,
	[DateFormat] [nvarchar](50) NULL,
	[NewsWordsToShow] [int] NULL,
	[NewsDetailsPage] [nvarchar](250) NULL,
	[ViewAllNewsPage] [nvarchar](250) NULL,
	[UserModuleID] [int] NULL,
	[PortalID] [int] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[CultureCode] [nvarchar](100) NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_NewsSetting_1] PRIMARY KEY CLUSTERED 
(
	[NewsSettingID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RestorePermissions]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RestorePermissions]
    @name   sysname
AS
BEGIN
    DECLARE @object sysname
    DECLARE @protectType char(10)
    DECLARE @action varchar(60)
    DECLARE @grantee sysname
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT Object, ProtectType, [Action], Grantee FROM #aspnet_Permissions where Object = @name

    OPEN c1

    FETCH c1 INTO @object, @protectType, @action, @grantee
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = @protectType + ' ' + @action + ' on ' + @object + ' TO [' + @grantee + ']'
        EXEC (@cmd)
        FETCH c1 INTO @object, @protectType, @action, @grantee
    END

    CLOSE c1
    DEALLOCATE c1
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RemoveAllRoleMembers]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RemoveAllRoleMembers]
    @name   sysname
AS
BEGIN
    CREATE TABLE #aspnet_RoleMembers
    (
        Group_name      sysname,
        Group_id        smallint,
        Users_in_group  sysname,
        User_id         smallint
    )

    INSERT INTO #aspnet_RoleMembers
    EXEC sp_helpuser @name

    DECLARE @user_id smallint
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT User_id FROM #aspnet_RoleMembers

    OPEN c1

    FETCH c1 INTO @user_id
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = 'EXEC sp_droprolemember ' + '''' + @name + ''', ''' + USER_NAME(@user_id) + ''''
        EXEC (@cmd)
        FETCH c1 INTO @user_id
    END

    CLOSE c1
    DEALLOCATE c1
END
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL,
 CONSTRAINT [PK__aspnet_SchemaVer__2BB470E3] PRIMARY KEY CLUSTERED 
(
	[Feature] ASC,
	[CompatibleSchemaVersion] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchForm]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchForm] 
@CultureCode NVARCHAR(250),
@UserModuleID INT,
@SearchText NVARCHAR(100),
@PortalID INT
AS
BEGIN
 SELECT FormID,LTRIM(Title) AS Title,AddedOn FROM Form 
 WHERE [PortalID] =@PortalID AND CultureCode=@CultureCode AND UserModuleID=@UserModuleID  AND (ISDELETED= 0 OR ISDELETED is NULL) 
 AND LTRIM(Title) LIKE @SearchText+'%'
 ORDER BY Title ASC
END
GO
/****** Object:  Table [dbo].[Codes]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Codes](
	[Code] [uniqueidentifier] NULL,
	[ActiveFrom] [datetime] NULL,
	[ActiveTo] [datetime] NULL,
	[CodeForPurpose] [nvarchar](256) NULL,
	[CodeForUsername] [nchar](256) NULL,
	[IsAlreadyUsed] [bit] NULL,
	[PortalID] [int] NULL,
	[CodeID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Codes] PRIMARY KEY CLUSTERED 
(
	[CodeID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[CDN]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CDN](
	[URLID] [int] IDENTITY(1,1) NOT NULL,
	[URL] [nvarchar](500) NULL,
	[IsJS] [bit] NULL,
	[URLOrder] [int] NULL,
	[PortalID] [int] NULL,
 CONSTRAINT [PK_CDN] PRIMARY KEY CLUSTERED 
(
	[URLID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[CacheSearch]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CacheSearch](
	[CacheID] [int] IDENTITY(1,1) NOT NULL,
	[SearchWord] [nvarchar](max) NULL,
	[PageName] [nvarchar](200) NULL,
	[UserModuleTitle] [nvarchar](200) NULL,
	[HTMLContent] [ntext] NULL,
	[URL] [nvarchar](200) NULL,
	[CultureName] [nvarchar](50) NULL,
	[UpdatedContentOn] [datetime] NULL,
	[UserModuleID] [int] NULL,
	[Counter] [int] NULL,
	[RowTotal] [int] NULL,
	[RowNumber] [int] NULL,
	[SearchedDate] [datetime] NULL,
	[PortalID] [int] NULL,
 CONSTRAINT [PK_CacheSearch_1] PRIMARY KEY CLUSTERED 
(
	[CacheID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[BreadCrumbMenuItem]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BreadCrumbMenuItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pageName] [nvarchar](256) NULL,
 CONSTRAINT [PK_BreadCrumbMenuItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[BlogRssContent]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogRssContent](
	[BlogContent] [text] NULL,
	[UpdatedDate] [datetime] NULL,
	[BlogContentID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_BlogRssContent] PRIMARY KEY CLUSTERED 
(
	[BlogContentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[CoreJs]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoreJs](
	[ResourceID] [int] IDENTITY(1,1) NOT NULL,
	[LoadingMode] [int] NULL,
	[IsHandheld] [bit] NULL,
	[PathMode] [bit] NULL,
	[Path] [nvarchar](500) NULL,
	[IsCompress] [bit] NULL,
	[Position] [bit] NULL,
 CONSTRAINT [PK_CoreJs] PRIMARY KEY CLUSTERED 
(
	[ResourceID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PortalModulePermission]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalModulePermission](
	[PortalModulePermissionID] [int] IDENTITY(1,1) NOT NULL,
	[PortalModuleID] [int] NOT NULL,
	[ModuleDefPermissionID] [int] NOT NULL,
	[AllowAccess] [bit] NOT NULL,
	[RoleID] [uniqueidentifier] NULL,
	[Username] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_PortalModulePermission] PRIMARY KEY CLUSTERED 
(
	[PortalModulePermissionID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LogActivity]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogActivity](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](max) NULL,
	[ActivityUserName] [nvarchar](150) NULL,
	[LogDateTime] [datetime] NULL,
	[PortalID] [int] NULL,
	[UserModuleID] [int] NULL,
	[ID] [int] NULL,
 CONSTRAINT [PK_LogActivity] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[AspNet_SqlCacheTablesForChangeNotification]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification](
	[tableName] [nvarchar](450) NOT NULL,
	[notificationCreated] [datetime] NOT NULL,
	[changeId] [int] NOT NULL,
 CONSTRAINT [PK__AspNet_SqlCacheT__6E2152BE] PRIMARY KEY CLUSTERED 
(
	[tableName] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK__aspnet_Applicati__2136E270] PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF),
 CONSTRAINT [UQ__aspnet_Applicati__222B06A9] UNIQUE NONCLUSTERED 
(
	[LoweredApplicationName] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF),
 CONSTRAINT [UQ__aspnet_Applicati__231F2AE2] UNIQUE NONCLUSTERED 
(
	[ApplicationName] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE CLUSTERED INDEX [aspnet_Applications_Index] ON [dbo].[aspnet_Applications] 
(
	[LoweredApplicationName] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[LocalPage]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalPage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NULL,
	[PageName] [nvarchar](250) NULL,
	[LocalPageName] [nvarchar](250) NULL,
	[LocalPageCaption] [nvarchar](500) NULL,
	[CultureCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_LocalPage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LocalModuleTitle]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalModuleTitle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserModule] [nvarchar](500) NULL,
	[UserModuleID] [int] NULL,
	[LocalModuleTitle] [nvarchar](500) NULL,
	[CultureCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_LocalModuleTitle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Lists]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lists](
	[EntryID] [int] IDENTITY(1,1) NOT NULL,
	[ListName] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
	[Text] [nvarchar](150) NOT NULL,
	[ParentID] [int] NOT NULL,
	[Level] [int] NOT NULL,
	[CurrencyCode] [nvarchar](50) NULL,
	[DisplayLocale] [nvarchar](50) NULL,
	[DisplayOrder] [int] NOT NULL,
	[DefinitionID] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[PortalID] [int] NOT NULL,
	[SystemList] [bit] NOT NULL,
	[IsActive] [bit] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[UpdatedOn] [datetime] NULL,
	[Culture] [nvarchar](256) NULL,
 CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED 
(
	[ListName] ASC,
	[Value] ASC,
	[Text] ASC,
	[ParentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LayoutMgr]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LayoutMgr](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleOrder] [nvarchar](100) NOT NULL,
	[PortelID] [int] NULL,
	[ModuleID] [nvarchar](100) NULL,
	[ModuleName] [nvarchar](100) NULL,
	[PaneName] [nvarchar](100) NULL,
 CONSTRAINT [PK_LayoutMgr] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LanguageSettingValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageSettingValue](
	[LanguageSettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_LanguageSettingValue] PRIMARY KEY CLUSTERED 
(
	[UserModuleID] ASC,
	[SettingKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LanguageSettingKey]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageSettingKey](
	[LanguageSettingID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_LanguageSettingKey] PRIMARY KEY CLUSTERED 
(
	[SettingKey] ASC,
	[PortalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[CultureCode] [nvarchar](50) NOT NULL,
	[CultureName] [nvarchar](200) NOT NULL,
	[FallbackCulture] [nvarchar](50) NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedByUserID] [int] NULL,
	[LastModifiedOnDate] [datetime] NULL,
	[FallbackCultureCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LanguageMessageTemplateType]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageMessageTemplateType](
	[LanguageMessageTemplateTypeID] [int] IDENTITY(1,1) NOT NULL,
	[MessageTemplateTypeID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Culture] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_LanguageMessageTemplateType] PRIMARY KEY CLUSTERED 
(
	[LanguageMessageTemplateTypeID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_FormValueDelete]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FormValueDelete] 
 @FormID int,
 @FormSubmittedID int,
 @UserModuleID int,
 @PortalID int 
AS
BEGIN
 DELETE  FormFieldValue WHERE FormSubmittedID IN
  (SELECT FFV.FormSubmittedID 
  FROM Form F inner join FormFields FF ON F.FormID=FF.FormID inner join FormFieldValue FFV ON FF.FieldID=FFV.FieldID
  WHERE F.FormID=@FormID and F.UserModuleID=@UserModuleID and F.PortalID=@PortalID and FFV.FormSubmittedID=@FormSubmittedID)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerUpdateFile]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FileManagerUpdateFile]
(
@FileID INT,
@FileName NVARCHAR(100)
)
AS
BEGIN
SET NOCOUNT ON;
UPDATE [File] 
SET FileName=@FileName
WHERE FileId=@FileID
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerSettingGetAll]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerSettingGetAll]
 @UserModuleID INT,
 @PortalID INT

WITH EXECUTE AS CALLER
AS
BEGIN
 SELECT ISNULL([dbo].[FileManagerSettingValue].[FileManagerSettingValueID],0) AS FileManagerSettingValueID
      ,0 AS [UserModuleID]
      ,[dbo].[FileManagerSettingKey].[SettingKey] AS SettingKey
      ,COALESCE([dbo].[FileManagerSettingValue].SettingValue,[dbo].[FileManagerSettingKey].SettingValue) AS SettingValue
      ,[dbo].[FileManagerSettingValue].[IsActive]
      ,[dbo].[FileManagerSettingValue].[IsDeleted]
      ,[dbo].[FileManagerSettingValue].[IsModified]
      ,[dbo].[FileManagerSettingValue].[AddedOn]
      ,[dbo].[FileManagerSettingValue].[UpdatedOn]
      ,[dbo].[FileManagerSettingValue].[DeletedOn]
      ,[dbo].[FileManagerSettingValue].[PortalID]
      ,[dbo].[FileManagerSettingValue].[AddedBy]
      ,[dbo].[FileManagerSettingValue].[UpdatedBy]
      ,[dbo].[FileManagerSettingValue].[DeletedBy]
 FROM [dbo].[FileManagerSettingValue]
 RIGHT JOIN [dbo].[FileManagerSettingKey] 
        ON [dbo].[FileManagerSettingValue].SettingKey = [dbo].[FileManagerSettingKey].SettingKey 
        AND [dbo].[FileManagerSettingValue].UserModuleID = @UserModuleID 
        AND [dbo].[FileManagerSettingValue].PortalID=@PortalID 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerSettingAddUpdate]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerSettingAddUpdate] 
 @UserModuleID INT,
 @SettingKey NVARCHAR(256),
 @SettingValue NVARCHAR(256),
 @IsActive BIT,
 @PortalID INT,
 @UpdatedBy NVARCHAR(256),
 @AddedBy NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN
IF(EXISTS(SELECT * FROM dbo.FileManagerSettingValue WHERE  
 [UserModuleID] = @UserModuleID
 AND [SettingKey] = @SettingKey
 AND PortalID = @PortalID))
BEGIN
UPDATE dbo.FileManagerSettingValue SET 
 [SettingValue] = @SettingValue,
 [IsActive] = @IsActive,
 [IsModified] = 1,
 [UpdatedOn] = GETDATE(),
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE  
 [UserModuleID] = @UserModuleID
 AND [SettingKey] = @SettingKey
 AND PortalID = @PortalID
END
ELSE
BEGIN
 INSERT INTO dbo.FileManagerSettingValue ( 
 [UserModuleID],
 [SettingKey],
 [SettingValue],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @UserModuleID,
 @SettingKey,
 @SettingValue,
 @IsActive,
 GETDATE(),
 @PortalID,
 @AddedBy
)
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerCopyFile]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerCopyFile]
(
 @FileID INT,
 @FolderID INT,
 @Folder NVARCHAR(200),
 @UniqueId UNIQUEIDENTIFIER,
 @VersionGuid UNIQUEIDENTIFIER
) 
AS
BEGIN
 SET NOCOUNT ON;
 INSERT INTO [File]
 (
  PortalId,[FileName],
  Extension,Size,
  Width,Height,
  ContentType,Folder,
  FolderID,Content,
  UniqueId,VersionGuid,
  IsActive,IsDeleted,
  IsModified,AddedOn,
  UpdatedOn,DeletedOn,
  AddedBy,UpdatedBy,
  DeletedBy
  )
  select 
  PortalId,[FileName],
  Extension, [Size],
  Width, Height,
  ContentType,@Folder,
  @FolderID,Content,
  @UniqueId,@VersionGuid,
  IsActive,IsDeleted,
  IsModified,AddedOn,
  UpdatedOn,DeletedOn,
  AddedBy,UpdatedBy,
  DeletedBy FROM [File]
  WHERE FileId=@FileID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerAddFile]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerAddFile]
 (
    @PortalId INT,
    @UniqueId UNIQUEIDENTIFIER,
    @VersionGuid UNIQUEIDENTIFIER,
    @FileName NVARCHAR(100),
    @Extension NVARCHAR(100),
    @Size INT,  
    @ContentType NVARCHAR(200),
    @Folder NVARCHAR(200),
    @FolderID INT,
 @IsActive BIT,
 @AddedBy NVARCHAR(256)
) 
AS  
        BEGIN
          INSERT INTO dbo.[File](
            PortalId,
            UniqueId,
            VersionGuid,
            FileName,
            Extension,
            Size,           
            ContentType,
            Folder,
            FolderID,
   IsActive,
   AddedBy,
   AddedOn
          )
          VALUES (
            @PortalId,
            @UniqueId,
            @VersionGuid,
            @FileName,
            @Extension,
            @Size,           
            @ContentType,
            @Folder,
            @FolderID,
   @IsActive,
   @AddedBy,
   GETDATE()
          )
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerAddDatabaseFile]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerAddDatabaseFile]
  (
    @PortalId INT,
    @UniqueId UNIQUEIDENTIFIER,
    @VersionGuid UNIQUEIDENTIFIER,
    @FileName NVARCHAR(100),
    @Extension NVARCHAR(100),
    @Size INT,  
    @ContentType NVARCHAR(200),
    @Folder NVARCHAR(200),
    @FolderID INT,
 @Content IMAGE,
 @IsActive INT,
 @AddedBy NVARCHAR(256)
) 
AS  
        BEGIN
          INSERT INTO dbo.[File](
            PortalId,
            UniqueId,
            VersionGuid,
            FileName,
            Extension,
            Size,           
            ContentType,
            Folder,
            FolderID,
   [Content],
   IsActive,
   AddedBy,
   AddedOn
          )
          VALUES (
            @PortalId,
            @UniqueId,
            @VersionGuid,
            @FileName,
            @Extension,
            @Size,           
            @ContentType,
            @Folder,
            @FolderID,
   @Content,
   @IsActive,
   @AddedBy,
   GETDATE()
          )
END
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserID] [int] NULL,
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[image] [nvarchar](250) NULL,
	[UserName] [nvarchar](250) NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[FullName] [nvarchar](250) NULL,
	[BirthDate] [datetime] NULL,
	[Location] [nvarchar](50) NULL,
	[AboutYou] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[ResPhone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Others] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[Gender] [varchar](10) NULL,
 CONSTRAINT [PK_NewUserProfile] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[UserAgent]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAgent](
	[AgentMode] [nvarchar](50) NULL,
	[PortalID] [int] NULL,
	[ChangedBy] [nvarchar](250) NULL,
	[ChangedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[AgentID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_UserAgent] PRIMARY KEY CLUSTERED 
(
	[AgentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Pages]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[PageOrder] [int] NULL,
	[PageName] [nvarchar](100) NULL,
	[IsVisible] [bit] NULL,
	[ParentID] [int] NULL,
	[Level] [int] NULL,
	[IconFile] [nvarchar](100) NULL,
	[DisableLink] [bit] NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[KeyWords] [nvarchar](500) NULL,
	[Url] [nvarchar](255) NULL,
	[TabPath] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[RefreshInterval] [decimal](16, 2) NULL,
	[PageHeadText] [nvarchar](500) NULL,
	[IsSecure] [bit] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[SEOName] [nvarchar](100) NULL,
	[IsShowInFooter] [bit] NULL,
	[IsRequiredPage] [bit] NULL,
 CONSTRAINT [PK_Tabs] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PageMenu]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageMenu](
	[PageMenuID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NULL,
	[PortalID] [int] NULL,
	[IsAdmin] [bit] NULL,
	[IsFooter] [bit] NULL,
	[ShowInMenu] [bit] NULL,
 CONSTRAINT [PK_PageMenu] PRIMARY KEY CLUSTERED 
(
	[PageMenuID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetRootFolders]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FileManagerGetRootFolders]
AS
BEGIN
SELECT [FolderID]
      ,[PortalID]
      ,[FolderPath]
      ,[StorageLocation]
      ,[IsProtected]
      ,[IsCached]
      ,[UniqueId]
      ,[VersionGuid]
      ,[IsRoot]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
  FROM [dbo].[Folder]
  WHERE IsRoot=1
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetFolders]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerGetFolders]
AS
BEGIN
SELECT [FolderID]
      ,[PortalID]
      ,[FolderPath]
      ,[StorageLocation]
      ,[IsProtected]
      ,[IsCached]
      ,[UniqueId]
      ,[VersionGuid]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
  FROM [dbo].[Folder]
  WHERE IsRoot=0
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerAddRootFolder]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerAddRootFolder]
 (
    @PortalID INT,
    @FolderPath VARCHAR(300),
 @StorageLocation INT,
    @UniqueId UNIQUEIDENTIFIER,
    @VersionGuid UNIQUEIDENTIFIER,
 @IsActive BIT,
 @AddedBy NVARCHAR(256)
) 
   
AS
BEGIN
    INSERT INTO dbo.Folder (
        PortalID,
  ParentFolderID, 
  FolderPath, 
        StorageLocation, 
        UniqueId,
        VersionGuid,        
        IsActive,
  IsRoot,
  AddedBy,
  AddedOn
    )
    VALUES (
        @PortalID,
  0,
  @FolderPath, 
        @StorageLocation,  
        @UniqueId,
        @VersionGuid,        
        @IsActive,
  1,
  @AddedBy,
  GETDATE()
    )
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerAddFolderRetFolderID]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerAddFolderRetFolderID]
 (
    @PortalID INT,
 @ParentFolderID INT,
    @FolderPath VARCHAR(300),
 @StorageLocation INT,
    @UniqueId UNIQUEIDENTIFIER,
    @VersionGuid UNIQUEIDENTIFIER,
 @IsActive BIT,
 @AddedBy NVARCHAR(256),
 @FolderID INT OUTPUT
  ) 
AS
BEGIN
    INSERT INTO dbo.Folder (
        PortalID,
  ParentFolderID, 
  FolderPath, 
        StorageLocation, 
        UniqueId,
        VersionGuid,        
        IsActive,
  IsRoot,
  AddedBy,
  AddedOn
    )
    VALUES (
        @PortalID,
  @ParentFolderID,
  @FolderPath, 
        @StorageLocation,  
        @UniqueId,
        @VersionGuid,        
        @IsActive,
  0,
  @AddedBy,
  GETDATE()
    )    
 SET @FolderID=SCOPE_IDENTITY();
 SELECT @FolderID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerAddFolder]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerAddFolder]
 (
    @PortalID    INT,
 @ParentFolderID  INT,
    @FolderPath   varchar(300),
 @StorageLocation  INT,
    @UniqueId    UNIQUEIDENTIFIER,
    @VersionGuid   UNIQUEIDENTIFIER,
 @IsActive   BIT,
 @AddedBy   NVARCHAR(256)
) 
   
AS
BEGIN
    INSERT INTO dbo.Folder (
        PortalID,
  ParentFolderID ,
  FolderPath, 
        StorageLocation, 
        UniqueId,
        VersionGuid,        
        IsActive,
  IsRoot,
  AddedBy,
  AddedOn
    )
    VALUES (
        @PortalID,
  @ParentFolderID,
  @FolderPath, 
        @StorageLocation,  
        @UniqueId,
        @VersionGuid,        
        @IsActive,
  0,
  @AddedBy,
  GETDATE()
    )
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_LevelPrefix]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Dinesh Hona
-- Create date: <Create Date, ,>
-- Description: <Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fn_LevelPrefix]
(
 @Level int,
 @Prefix nvarchar(10)
)
RETURNS nvarchar(500)
AS
BEGIN
 DECLARE @ReturnValue nvarchar(255),@Counter int
 SET @ReturnValue=''
 SET @Counter=1
 WHILE(@Counter<=@Level)
 BEGIN
  SET @ReturnValue=@ReturnValue+@Prefix;
  SET @Counter=@Counter+1
 END
 RETURN @ReturnValue

END
GO
/****** Object:  Table [dbo].[MenuItem]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[MenuItemID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[LinkType] [nvarchar](50) NULL,
	[PageID] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[LinkURL] [nvarchar](200) NULL,
	[ImageIcon] [nvarchar](100) NULL,
	[Caption] [nvarchar](200) NULL,
	[HtmlContent] [nvarchar](2000) NULL,
	[ParentID] [int] NULL,
	[MenuLevel] [nvarchar](50) NULL,
	[MenuOrder] [int] NULL,
	[SubText] [nvarchar](254) NULL,
	[IsVisible] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MenuItem] PRIMARY KEY CLUSTERED 
(
	[MenuItemID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](100) NULL,
	[MenuType] [nvarchar](50) NULL,
	[IsDefault] [bit] NULL,
	[PortalID] [int] NULL,
 CONSTRAINT [PK_dbo.Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MembershipSettings]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembershipSettings](
	[MembershipSettingID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NULL,
	[SettingValue] [nvarchar](50) NULL,
 CONSTRAINT [PK_MembershipSettings] PRIMARY KEY CLUSTERED 
(
	[MembershipSettingID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LogType]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogType](
	[LogTypeID] [int] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_LogType] PRIMARY KEY CLUSTERED 
(
	[LogTypeID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Logo]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logo](
	[LogoID] [int] IDENTITY(1,1) NOT NULL,
	[LogoText] [nvarchar](100) NULL,
	[LogoPath] [nvarchar](200) NULL,
	[UserModuleID] [int] NULL,
	[PortalID] [int] NULL,
	[Slogan] [nvarchar](500) NULL,
	[url] [nvarchar](200) NULL,
	[CultureCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_Logo] PRIMARY KEY CLUSTERED 
(
	[LogoID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[LoginLog]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginLog](
	[LoginLogID] [int] IDENTITY(1,1) NOT NULL,
	[ClientIPAddress] [nvarchar](30) NULL,
	[ConnectionStart] [datetime] NULL,
	[ConnectionEnd] [datetime] NULL,
	[Username] [nvarchar](256) NULL,
 CONSTRAINT [PK_LoginLog] PRIMARY KEY CLUSTERED 
(
	[LoginLogID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PageMenu_History]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageMenu_History](
	[OperationDate] [datetime] NOT NULL,
	[OperationType] [char](1) NOT NULL,
	[OperationId] [char](24) NOT NULL,
	[PageMenuID] [int] NULL,
	[PageID] [int] NULL,
	[PortalID] [int] NULL,
	[IsAdmin] [bit] NULL,
	[IsFooter] [bit] NULL,
	[ShowInMenu] [bit] NULL,
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PageMenu_History] PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PageModules_History]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageModules_History](
	[OperationDate] [datetime] NOT NULL,
	[OperationType] [char](1) NOT NULL,
	[OperationId] [char](24) NOT NULL,
	[PageModuleID] [int] NULL,
	[PageID] [int] NULL,
	[UserModuleID] [int] NULL,
	[PaneName] [nvarchar](50) NULL,
	[ModuleOrder] [int] NULL,
	[CacheTime] [int] NULL,
	[Alignment] [nvarchar](50) NULL,
	[Color] [nvarchar](20) NULL,
	[Border] [nvarchar](1) NULL,
	[IconFile] [nvarchar](100) NULL,
	[Visibility] [int] NULL,
	[DisplayTitle] [bit] NULL,
	[DisplayPrint] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PageModules_History] PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingPortalUpdate]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingPortalUpdate]
 @SettingID INT, 
 @Value NVARCHAR(2000), 
 @PortalID INT 
AS
BEGIN
 IF(EXISTS(
   SELECT * 
   FROM 
    [dbo].[SettingPortal] 
   WHERE 
     [PortalID]=@PortalID 
    AND [SettingID] = @SettingID
  ))
  BEGIN 
    UPDATE 
     [dbo].[SettingPortal] 
    SET
     [SettingID] = @SettingID,
     [Value] = @Value,
     [PortalID] = @PortalID
    WHERE 
      [PortalID]=@PortalID 
     AND [SettingID] = @SettingID
  END
 ELSE
  BEGIN
   INSERT INTO [dbo].[SettingPortal]
     (
      [SettingID],
      [Value],
      [PortalID]
     ) 
    VALUES 
     (
      @SettingID,
      @Value,
      @PortalID
     )
  END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingPortalList]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingPortalList]
AS
SELECT
 [SettingPortalID],
 [SettingID],
 [Value],
 [PortalID]
FROM 
 [dbo].[SettingPortal]
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingPortalDelete]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingPortalDelete]
 @SettingID INT,
 @PortalID INT
AS

DELETE FROM 
 [dbo].[SettingPortal]
WHERE
  [SettingID]=@SettingID 
 AND [PortalID] = @PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingPortalAdd]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingPortalAdd]
 @SettingPortal INT=null OUTPUT,
 @SettingID INT,
 @Value NVARCHAR(2000),
 @PortalID INT
AS

INSERT INTO [dbo].[SettingPortal]
(
 [SettingID],
 [Value],
 [PortalID]
) VALUES (
 @SettingID,
 @Value,
 @PortalID
)

SET @SettingPortal= SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[SettingKey]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SettingKey](
	[SettingKeyID] [int] IDENTITY(1,1) NOT NULL,
	[SettingType] [nvarchar](100) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[IsCacheable] [bit] NULL,
 CONSTRAINT [PK_SettingKey] PRIMARY KEY CLUSTERED 
(
	[SettingType] ASC,
	[SettingKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingUpdate]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingUpdate]
 @SettingID INT, 
 @Name NVARCHAR(200), 
 @Value NVARCHAR(2000), 
 @Description NTEXT
AS

UPDATE 
 [dbo].[Setting] 
SET
 [Name] = @Name,
 [Value] = @Value,
 [Description] = @Description
WHERE 
 [SettingID] = @SettingID
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingPortalBySettingID]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingPortalBySettingID]
 @SettingID INT,
 @PortalID INT
AS
SELECT
 [SettingPortalID],
 [SettingID],
 [Value],
 [PortalID],
 (
  SELECT 
   [dbo].[Setting].[Name] 
  FROM
   [dbo].[Setting] 
  WHERE 
   [dbo].[Setting].[SettingID]=@SettingID
 ) AS [Name],
 (
  SELECT 
   [dbo].[Setting].[Value]  
  FROM 
   [dbo].[Setting] 
  WHERE 
   [dbo].[Setting].[SettingID]=@SettingID
 ) as [DefaultValue]
FROM 
 [dbo].[SettingPortal]
WHERE 
  PortalID=@PortalID 
 AND [SettingID]=@SettingID
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingPortalByPortalID]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingPortalByPortalID]
 @PortalID INT
AS
SELECT
 [dbo].[SettingPortal].[SettingPortalID], 
 [dbo].[SettingPortal].[SettingID],
 [dbo].[SettingPortal].[Value],
 [dbo].[SettingPortal].[PortalID],
 [dbo].[Setting].[Name],
 [dbo].[Setting].[Value] AS DefaultValue
FROM 
 [dbo].[SettingPortal]
RIGHT OUTER JOIN 
 [dbo].[Setting] 
ON 
 [dbo].[SettingPortal].SettingID = [dbo].[Setting].SettingID
WHERE 
 [PortalID]=@PortalID
ORDER BY 
 [dbo].[Setting].[Name]
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingList]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingList]
AS
SELECT
 [SettingID],
 [Name],
 [Value],
 [Description]
FROM 
 [dbo].[Setting]
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingDelete]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingDelete]
 @SettingID INT, 
 @PortalID INT 
AS
DELETE FROM 
 [dbo].[Setting] 
WHERE 
 [SettingID] = @SettingID
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingBySettingID]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[sp_SettingBySettingID]
 @SettingID INT
AS
SELECT
 [SettingID],
 [Name],
 [Value],
 [Description]
FROM 
 [dbo].[Setting]
WHERE
 [SettingID] = @SettingID
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingAdd]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SettingAdd]
 @SettingID INT = NULL OUTPUT,
 @Name NVARCHAR(200),
 @Value NVARCHAR(2000),
 @Description NTEXT
AS

INSERT INTO [dbo].[Setting] (
 [Name],
 [Value],
 [Description]
) VALUES (
 @Name,
 @Value,
 @Description
)

SET @SettingID= SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[SessionTrackerPages]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionTrackerPages](
	[SessionTrackerPageID] [int] IDENTITY(1,1) NOT NULL,
	[SessionTrackerID] [int] NULL,
	[SessionTrackerPage] [nvarchar](500) NULL,
	[SessionTrackerTime] [varchar](8) NULL,
 CONSTRAINT [PK_SessionTrackerPages] PRIMARY KEY CLUSTERED 
(
	[SessionTrackerPageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Split](@String [nvarchar](4000), @Delimiter [char](1))
RETURNS @temptable TABLE (
 [items] [nvarchar](4000) NULL
) WITH EXECUTE AS CALLER
AS 
begin       
     declare @idx int       
     declare @slice nvarchar(4000)       
       
     select @idx = 1       
     if len(@String)<1 or @String is null  
  return       
       
     while @idx!= 0       
     begin       
         set @idx = charindex(@Delimiter,@String)       
         if @idx!=0       
             set @slice = left(@String,@idx - 1)       
         else       
             set @slice = @String       
           
         if(len(@slice)>0)  
             insert into @temptable(Items) values(@slice)       
  else
   Insert Into @temptable(Items) values(null)
         set @String = right(@String,len(@String) - @idx)       
         if len(@String) = 0 
         break       
     end   
 return       
 end
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleName] [varchar](200) NULL,
	[FullNamespace] [varchar](200) NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[StartHour] [smallint] NULL,
	[StartMin] [smallint] NULL,
	[RepeatWeeks] [smallint] NULL,
	[RepeatDays] [int] NULL,
	[WeekOfMonth] [int] NULL,
	[EveryHours] [int] NULL,
	[EveryMin] [smallint] NULL,
	[ObjectDependencies] [varchar](300) NULL,
	[RetryTimeLapse] [int] NULL,
	[RetryFrequencyUnit] [int] NULL,
	[AttachToEvent] [varchar](50) NULL,
	[CatchUpEnabled] [bit] NULL,
	[Servers] [varchar](250) NULL,
	[CreatedByUserID] [varchar](250) NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedbyUserID] [int] NULL,
	[LastModifiedDate] [datetime] NULL,
	[IsEnable] [bit] NOT NULL,
	[RunningMode] [int] NOT NULL,
	[AssemblyFileName] [varchar](150) NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageMenuSettingValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageMenuSettingValue](
	[SageMenuSettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_SageMenuSettingValue] PRIMARY KEY CLUSTERED 
(
	[UserModuleID] ASC,
	[SettingKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageMenuSettingkey]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageMenuSettingkey](
	[SageMenuSettingKeyID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_SageMenuSettingkey] PRIMARY KEY CLUSTERED 
(
	[SettingKey] ASC,
	[PortalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageFrameSearchSettingValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageFrameSearchSettingValue](
	[SageFrameSearchSettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[CultureName] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_SageFrameSearchSettingValue_1] PRIMARY KEY CLUSTERED 
(
	[SageFrameSearchSettingValueID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SageFrameSearchSetting]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SageFrameSearchSetting](
	[SageFrameSearchSettingID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_SageFrameSearchSetting_1] PRIMARY KEY CLUSTERED 
(
	[SageFrameSearchSettingID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PortalUser]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalUser](
	[PortalUserID] [int] IDENTITY(1,1) NOT NULL,
	[PortalID] [int] NOT NULL,
	[Username] [nvarchar](256) NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[FirstName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_PortalUser] PRIMARY KEY CLUSTERED 
(
	[PortalID] ASC,
	[Username] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PortalStartUp]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalStartUp](
	[PortalStartUpID] [int] IDENTITY(1,1) NOT NULL,
	[PortalID] [int] NULL,
	[EventLocationName] [nvarchar](50) NULL,
	[ControlUrl] [nvarchar](500) NULL,
	[IsAdmin] [bit] NULL,
	[IsControlUrl] [bit] NULL,
	[IsSystem] [bit] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_PortalStartUp] PRIMARY KEY CLUSTERED 
(
	[PortalStartUpID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[PortalRole]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalRole](
	[PortalRoleID] [int] IDENTITY(1,1) NOT NULL,
	[PortalID] [int] NOT NULL,
	[RoleID] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_PortalRole] PRIMARY KEY CLUSTERED 
(
	[PortalID] ASC,
	[RoleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[NewsRssContent]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsRssContent](
	[NewsContent] [text] NULL,
	[UpdatedDate] [datetime] NULL,
	[NewsContentID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_NewsRssContent] PRIMARY KEY CLUSTERED 
(
	[NewsContentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[ModuleWebInfo]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleWebInfo](
	[ModuleID] [int] NOT NULL,
	[ModuleName] [nvarchar](128) NULL,
	[ReleaseDate] [datetime] NULL,
	[Version] [nvarchar](8) NULL,
	[DownloadUrl] [nvarchar](200) NULL,
	[Description] [nvarchar](2000) NULL,
	[AddedOn] [datetime] NULL,
 CONSTRAINT [PK_ModuleWebInfo] PRIMARY KEY CLUSTERED 
(
	[ModuleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateFormField]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateFormField]
( @FormID INT,
 @FieldID INT,
 @PortalID INT,
 @AddedBy NVARCHAR (256))
  AS
BEGIN
 UPDATE FormFields
SET IsActive = 0,
 IsModified = 1,
 UpdatedBy =@AddedBy,
 UpdatedOn = GETDATE()
WHERE
 [FormID] = @FormID
AND FieldID = @FieldID
AND PortalID =@PortalID
END
GO
/****** Object:  Table [dbo].[MessageTemplateTypeMap]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplateTypeMap](
	[MessageTemplateTypeID] [int] NULL,
	[PortalSpecID] [int] NULL,
	[PortalID] [int] NULL,
	[MessageTemplateTypeMapID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_MessageTemplateTypeMap] PRIMARY KEY CLUSTERED 
(
	[MessageTemplateTypeMapID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MessageTemplateType]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplateType](
	[MessageTemplateTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MessageTemplateType] PRIMARY KEY CLUSTERED 
(
	[MessageTemplateTypeID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetFiles]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerGetFiles]
(
@FolderID INT
)
AS
BEGIN
SELECT fi.FileId
      ,fi.PortalId
      ,fi.FileName
      ,fi.Extension
      ,fi.Size
      ,fi.Width
      ,fi.Height
      ,fi.ContentType
      ,fi.Folder
      ,fi.FolderID
      ,fi.Content
      ,fi.UniqueId
      ,fi.VersionGuid,
  fo.StorageLocation
      ,fi.IsActive
      ,fi.IsDeleted
      ,fi.IsModified
      ,fi.AddedOn
      ,fi.UpdatedOn
      ,fi.DeletedOn
      ,fi.AddedBy
      ,fi.UpdatedBy
      ,fi.DeletedBy
  FROM [dbo].[File] fi
LEFT JOIN Folder fo
ON fi.FolderID=fo.FolderID
  WHERE fi.FolderID=@FolderID
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetFileDetails]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerGetFileDetails]
 @FileID INT
AS
BEGIN
SELECT fi.FileId
      ,fi.PortalId
      ,fi.FileName
      ,fi.Extension
      ,fi.Size
      ,fi.Width
      ,fi.Height
      ,fi.ContentType
      ,fi.Folder
      ,fi.FolderID
      ,fi.Content
      ,fi.UniqueId
      ,fi.VersionGuid
   ,fo.StorageLocation
      ,fi.IsActive
      ,fi.IsDeleted
      ,fi.IsModified
      ,fi.AddedOn
      ,fi.UpdatedOn
      ,fi.DeletedOn
      ,fi.AddedBy
      ,fi.UpdatedBy
      ,fi.DeletedBy
  FROM [dbo].[File] fi
 LEFT JOIN Folder fo
 ON fi.FolderID=fo.FolderID
 WHERE fi.FileId=@FileID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetAllFolders]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerGetAllFolders]
AS
BEGIN
 SELECT [FolderID]
    ,[PortalID]
    ,[FolderPath]
    ,[StorageLocation]
    ,[IsProtected]
    ,[IsCached]
    ,[UniqueId]
    ,[VersionGuid]
    ,[IsActive]
    ,[IsDeleted]
    ,[IsModified]
    ,[AddedOn]
    ,[UpdatedOn]
    ,[DeletedOn]
    ,[AddedBy]
    ,[UpdatedBy]
    ,[DeletedBy]
   FROM [dbo].[Folder] 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetActiveRootFolders]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerGetActiveRootFolders]
AS
BEGIN
 SELECT [FolderID]
    ,[PortalID]
    ,[FolderPath]
    ,[StorageLocation]
    ,[IsProtected]
    ,[IsCached]
    ,[UniqueId]
    ,[VersionGuid]
    ,[IsRoot]
    ,[IsActive]
    ,[IsDeleted]
    ,[IsModified]
    ,[AddedOn]
    ,[UpdatedOn]
    ,[DeletedOn]
    ,[AddedBy]
    ,[UpdatedBy]
    ,[DeletedBy]
   FROM [dbo].[Folder]
   WHERE IsRoot=1
   AND IsActive=1
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerEnableRootFolder]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerEnableRootFolder]
 @FolderID INT
AS
  BEGIN
      SET NOCOUNT ON;
      UPDATE folder
      SET    isactive = 1
      WHERE  folderid = @FolderID
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerDisableRootFolder]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerDisableRootFolder]
 @FolderID INT 
AS
  BEGIN
      SET NOCOUNT ON;
      UPDATE folder
      SET    isactive = 0
      WHERE  folderid = @FolderID
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerDeleteRootFolder]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerDeleteRootFolder]
 @FolderID INT
AS
BEGIN
 DELETE FROM [File]
 WHERE FolderID=@FolderID
 DELETE FROM Folder
 WHERE FolderID=@FolderID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerDeleteFileFolder]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerDeleteFileFolder]
(
 @FolderID INT,
 @FileID INT
)
AS
BEGIN
    IF @FolderID = 0
      BEGIN
          DELETE FROM [file]
          WHERE  fileid = @FileId
      END
    ELSE
      BEGIN
          DELETE FROM [file]
          WHERE  folderid = @FolderID

          DELETE FROM folder
          WHERE  folderid = @FolderID
      END 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerDeleteExistingPermissions]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerDeleteExistingPermissions]
@FolderID INT
AS
BEGIN
 DECLARE @Count INT 

      SELECT @Count = COUNT(*) 
      FROM   folderpermission 
      WHERE  folderid = @FolderID 

      IF @Count <> 0 
        BEGIN 
            DELETE FROM folderpermission 
            WHERE  folderid = @FolderID 
        END 
END
GO
/****** Object:  Table [dbo].[DashboardSidebar]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashboardSidebar](
	[DisplayName] [nvarchar](250) NULL,
	[Depth] [int] NULL,
	[ImagePath] [nvarchar](250) NULL,
	[URL] [nvarchar](250) NULL,
	[ParentID] [int] NULL,
	[IsActive] [bit] NULL,
	[SidebarItemID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayOrder] [int] NULL,
	[PageID] [int] NULL,
 CONSTRAINT [PK_DashboardSidebar] PRIMARY KEY CLUSTERED 
(
	[SidebarItemID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[DashBoardSettingValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashBoardSettingValue](
	[DashBoardSettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_DashBoardSettingValue] PRIMARY KEY CLUSTERED 
(
	[UserModuleID] ASC,
	[SettingKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[DashboardSettingsKeyValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashboardSettingsKeyValue](
	[DashboardSettingKeyID] [int] IDENTITY(1,1) NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[UserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_DashboardSettingsKeyValue] PRIMARY KEY CLUSTERED 
(
	[DashboardSettingKeyID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[DashBoardSettingKey]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashBoardSettingKey](
	[DashBoardSettingID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NOT NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_DashBoardSettingKey] PRIMARY KEY CLUSTERED 
(
	[SettingKey] ASC,
	[PortalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[DashboardQuickLinks]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DashboardQuickLinks](
	[DisplayName] [nvarchar](200) NULL,
	[URL] [nvarchar](250) NULL,
	[ImagePath] [nvarchar](250) NULL,
	[QuickLinkID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NULL,
	[PageID] [int] NULL,
 CONSTRAINT [PK_DashboardQuickLinks] PRIMARY KEY CLUSTERED 
(
	[QuickLinkID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Portal]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portal](
	[PortalID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[SEOName] [nvarchar](100) NULL,
	[IsParent] [bit] NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_Portal] PRIMARY KEY CLUSTERED 
(
	[PortalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerSearchFiles]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FileManagerSearchFiles] 
(
@SearchQuery VARCHAR(200)
)
AS
BEGIN
SELECT fi.FileId
      ,fi.PortalId
      ,fi.FileName
      ,fi.Extension
      ,fi.Size
      ,fi.Width
      ,fi.Height
      ,fi.ContentType
      ,fi.Folder
      ,fi.FolderID
      ,fi.Content
      ,fi.UniqueId
      ,fi.VersionGuid,
  fo.StorageLocation
      ,fi.IsActive
      ,fi.IsDeleted
      ,fi.IsModified
      ,fi.AddedOn
      ,fi.UpdatedOn
      ,fi.DeletedOn
      ,fi.AddedBy
      ,fi.UpdatedBy
      ,fi.DeletedBy
  FROM [dbo].[File] fi
LEFT JOIN Folder fo
ON fi.FolderID=fo.FolderID
   WHERE fi.FileName LIKE @SearchQuery + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerMoveFile]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FileManagerMoveFile]
(
@FileID INT,
@FolderID INT,
@Folder NVARCHAR(200),
@UniqueId UNIQUEIDENTIFIER,
@VersionGuid UNIQUEIDENTIFIER
)
AS
BEGIN
SET NOCOUNT ON;

INSERT INTO [File]
(
PortalId,
[FileName],
Extension,
Size,
Width,
Height,
ContentType,
Folder,
FolderID,
Content,
UniqueId,
VersionGuid,
IsActive,
IsDeleted,
IsModified,
AddedOn,
UpdatedOn,
DeletedOn,
AddedBy,
UpdatedBy,
DeletedBy
)
SELECT PortalId,
[FileName],
Extension,
[Size],
Width,
Height,
ContentType,
@Folder,
@FolderID,
Content,
@UniqueId,
@VersionGuid,
IsActive,
IsDeleted,
IsModified,
AddedOn,
UpdatedOn,
DeletedOn,
AddedBy,
UpdatedBy,
DeletedBy
FROM [File]
WHERE FileId=@FileID
DELETE FROM [File] WHERE FileId=@FileID
END;
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [ntext] NULL,
 CONSTRAINT [PK__aspnet_WebEvent___027D5126] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MessageToken]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageToken](
	[MessageTokenID] [int] IDENTITY(1,1) NOT NULL,
	[MessageTokenKey] [nvarchar](100) NULL,
	[MessageTokenName] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MessageToken] PRIMARY KEY CLUSTERED 
(
	[MessageTokenID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MessageToken] ON [dbo].[MessageToken] 
(
	[MessageTokenName] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MessageToken_Key] ON [dbo].[MessageToken] 
(
	[MessageTokenKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[ShortUrl]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShortUrl](
	[ShortUrlID] [uniqueidentifier] NOT NULL,
	[ShortUrlKey] [nvarchar](10) NULL,
	[ShortUrlValue] [nvarchar](1000) NULL,
	[AddedOn] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ShortUrl] PRIMARY KEY CLUSTERED 
(
	[ShortUrlID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[sftemplate]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sftemplate](
	[TemplateID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[PortalID] [int] NULL,
 CONSTRAINT [PK_sftemplate] PRIMARY KEY CLUSTERED 
(
	[TemplateID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[SettingValue]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SettingValue](
	[SettingValueID] [int] IDENTITY(1,1) NOT NULL,
	[SettingType] [nvarchar](100) NOT NULL,
	[SettingTypeID] [int] NOT NULL,
	[SettingKey] [nvarchar](256) NOT NULL,
	[SettingValue] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[IsCacheable] [bit] NULL,
 CONSTRAINT [PK_SettingValue] PRIMARY KEY CLUSTERED 
(
	[SettingType] ASC,
	[SettingTypeID] ASC,
	[SettingKey] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IX_SettingValue_NN] ON [dbo].[SettingValue] 
(
	[SettingTypeID] ASC,
	[SettingKey] ASC,
	[SettingType] ASC
)
INCLUDE ( [SettingValue]) WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[ScheduleDate]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleDate](
	[ScheduleID] [int] NOT NULL,
	[Schedule_Date] [smalldatetime] NOT NULL,
	[IsExecuted] [bit] NOT NULL,
 CONSTRAINT [PK_ScheduleDate] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC,
	[Schedule_Date] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[MessageTemplateTypeToken]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageTemplateTypeToken](
	[MessageTemplateTypeTokenID] [int] IDENTITY(1,1) NOT NULL,
	[MessageTemplateTypeID] [int] NOT NULL,
	[MessageTokenID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MessageTemplateTypeToken] PRIMARY KEY CLUSTERED 
(
	[MessageTemplateTypeID] ASC,
	[MessageTokenID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_PortalRoleAdd]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PortalRoleAdd] 
 @PortalID INT,
 @RoleID  UNIQUEIDENTIFIER,
 @IsActive BIT,
 @AddedOn DATETIME,
 @AddedBy NVARCHAR(256)
AS
INSERT INTO [dbo].PortalRole (
 [PortalID],
 [RoleID],
 [IsActive],
 [AddedOn],
 [AddedBy]
)
VALUES( 
 @PortalID,
 @RoleId,
 @IsActive,
 @AddedOn,
 @AddedBy
)
GO
/****** Object:  StoredProcedure [dbo].[usp_PortalIsParent]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_PortalIsParent]
@PortalID int
AS
BEGIN
SELECT IsParent From [dbo].[Portal] WHERE PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Template_MenuUpdate]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Template_MenuUpdate] (
 @caption NVARCHAR(MAX)
 ,@htmlContent NVARCHAR(MAX)
 ,@imageIcon NVARCHAR(MAX)
 ,@ismenuActive NVARCHAR(MAX)
 ,@isVisible NVARCHAR(MAX)
 ,@linkType NVARCHAR(MAX)
 ,@linkUrl NVARCHAR(MAX)
 ,@menuLevel NVARCHAR(MAX)
 ,@menuOrder NVARCHAR(MAX)
 ,@pageID NVARCHAR(MAX)
 ,@title NVARCHAR(MAX)
 ,@menuName NVARCHAR(MAX)
 ,@SettingKey NVARCHAR(MAX)
 ,@SettingValue NVARCHAR(MAX)
 ,@portalID INT
 ,@userModuleID INT
 )
AS
BEGIN
 DECLARE @MenuID INT

 INSERT INTO Menu (
  MenuName
  ,MenuType
  ,IsDefault
  ,PortalID
  )
 VALUES (
  @menuName
  ,'1'
  ,0
  ,@portalID
  )

 SET @MenuID = SCOPE_IDENTITY()

 CREATE TABLE #TblMenuItemID (
  RowNum INT IDENTITY(1, 1)
  ,MenuItemID NVARCHAR(100)
  )

 CREATE TABLE #TblCaption (
  RowNum INT IDENTITY(1, 1)
  ,Caption NVARCHAR(100)
  )

 INSERT INTO #TblCaption
 SELECT *
 FROM dbo.Split(@caption, ',')

 CREATE TABLE #TblHtmlContent (
  RowNum INT IDENTITY(1, 1)
  ,HtmlContent NVARCHAR(100)
  )

 INSERT INTO #TblHtmlContent
 SELECT *
 FROM dbo.Split(@htmlContent, ',')

 CREATE TABLE #TblImageIcon (
  RowNum INT IDENTITY(1, 1)
  ,ImageIcon NVARCHAR(100)
  )

 INSERT INTO #TblImageIcon
 SELECT *
 FROM dbo.Split(@imageIcon, ',')

 CREATE TABLE #TblisActive (
  RowNum INT IDENTITY(1, 1)
  ,Active BIT
  )

 INSERT INTO #TblisActive
 SELECT *
 FROM dbo.Split(@ismenuActive, ',')

 CREATE TABLE #TblIsVisible (
  RowNum INT IDENTITY(1, 1)
  ,Visible BIT
  )

 INSERT INTO #TblIsVisible
 SELECT *
 FROM dbo.Split(@isVisible, ',')

 CREATE TABLE #TblLinkType (
  RowNum INT IDENTITY(1, 1)
  ,LinkType NVARCHAR(50)
  )

 INSERT INTO #TblLinkType
 SELECT *
 FROM dbo.Split(@linkType, ',')

 CREATE TABLE #TblLinkUrl (
  RowNum INT IDENTITY(1, 1)
  ,LinkUrl NVARCHAR(200)
  )

 INSERT INTO #TblLinkUrl
 SELECT *
 FROM dbo.Split(@linkUrl, ',')

 CREATE TABLE #TblMenuLevel (
  RowNum INT IDENTITY(1, 1)
  ,MenuLevel NVARCHAR(50)
  )

 INSERT INTO #TblMenuLevel
 SELECT *
 FROM dbo.Split(@menuLevel, ',')

 CREATE TABLE #TblMenuOrder (
  RowNum INT IDENTITY(1, 1)
  ,MenuOrder INT
  )

 INSERT INTO #TblMenuOrder
 SELECT *
 FROM dbo.Split(@menuOrder, ',')

 CREATE TABLE #TblPageID (
  RowNum INT IDENTITY(1, 1)
  ,PageID NVARCHAR(100)
  )

 INSERT INTO #TblPageID
 SELECT *
 FROM dbo.Split(@pageID, ',')

 CREATE TABLE #TblTitle (
  RowNum INT IDENTITY(1, 1)
  ,Title NVARCHAR(100)
  )

 INSERT INTO #TblTitle
 SELECT *
 FROM dbo.Split(@title, ',')

 DECLARE @COUNT INT
  ,@Counter INT

 SET @Counter = (
   SELECT COUNT(*)
   FROM #TblCaption
   )
 SET @COUNT = 1

 WHILE (@COUNT <= @Counter)
 BEGIN
  DECLARE @Caption_ NVARCHAR(200)
  DECLARE @HtmlContent_ NVARCHAR(2000)
  DECLARE @ImageIcon_ NVARCHAR(100)
  DECLARE @IsMenuActive_ BIT
  DECLARE @IsVisible_ BIT
  DECLARE @LinkType_ NVARCHAR(50)
  DECLARE @LinkUrl_ NVARCHAR(200)
  DECLARE @MenuLevel_ NVARCHAR(50)
  DECLARE @MenuOrder_ INT
  DECLARE @PageID_ NVARCHAR(50)
  DECLARE @Title_ NVARCHAR(100)
  DECLARE @MenuITemID_ INT

  SET @Caption_ = (
    SELECT Caption
    FROM #TblCaption
    WHERE RowNum = @COUNT
    )
  SET @HtmlContent_ = (
    SELECT HtmlContent
    FROM #TblHtmlContent
    WHERE RowNum = @COUNT
    )
  SET @ImageIcon_ = (
    SELECT ImageIcon
    FROM #TblImageIcon
    WHERE RowNum = @COUNT
    )
  SET @IsMenuActive_ = (
    SELECT Active
    FROM #TblisActive
    WHERE RowNum = @COUNT
    )
  SET @IsVisible_ = (
    SELECT Visible
    FROM #TblIsVisible
    WHERE RowNum = @COUNT
    )
  SET @LinkType_ = (
    SELECT LinkType
    FROM #TblLinkType
    WHERE RowNum = @COUNT
    )
  SET @LinkUrl_ = (
    SELECT LinkUrl
    FROM #TblLinkUrl
    WHERE RowNum = @COUNT
    )
  SET @MenuLevel_ = (
    SELECT MenuLevel
    FROM #TblMenuLevel
    WHERE RowNum = @COUNT
    )
  SET @MenuOrder_ = (
    SELECT MenuOrder
    FROM #TblMenuOrder
    WHERE RowNum = @COUNT
    )
  SET @PageID_ = (
    SELECT PageID
    FROM #TblPageID
    WHERE RowNum = @COUNT
    )
  SET @Title_ = (
    SELECT Title
    FROM #TblTitle
    WHERE RowNum = @COUNT
    )

  INSERT INTO MenuItem (
   MenuID
   ,Caption
   ,HtmlContent
   ,ImageIcon
   ,IsActive
   ,IsVisible
   ,LinkType
   ,LinkURL
   ,MenuLevel
   ,MenuOrder
   ,PageID
   ,Title
   ,PortalID
   )
  VALUES (
   @MenuID
   ,@Caption_
   ,@HtmlContent_
   ,@ImageIcon_
   ,@IsMenuActive_
   ,@IsVisible_
   ,@LinkType_
   ,@LinkUrl_
   ,@MenuLevel_
   ,@MenuOrder_
   ,@PageID_
   ,@Title_
   ,@portalID
   )

  SET @MenuITemID_ = SCOPE_IDENTITY()

  INSERT INTO #TblMenuItemID
  VALUES (@MenuITemID_)

  SET @COUNT = @COUNT + 1
 END

 CREATE TABLE #TblSettingKey (
  RowNum INT IDENTITY(1, 1)
  ,SettingKey NVARCHAR(256)
  )

 INSERT INTO #TblSettingKey
 SELECT *
 FROM dbo.Split(@SettingKey, ',')

 CREATE TABLE #TblSettingValue (
  RowNum INT IDENTITY(1, 1)
  ,SettingValue NVARCHAR(256)
  )

 INSERT INTO #TblSettingValue
 SELECT *
 FROM dbo.Split(@SettingValue, ',')

 DECLARE @Count2 INT
  ,@Counter2 INT

 SET @Counter2 = (
   SELECT COUNT(*)
   FROM #TblSettingKey
   )
 SET @Count2 = 1

 WHILE (@Count2 <= @Counter2)
 BEGIN
  DECLARE @SettingKey_ NVARCHAR(256)
  DECLARE @SettingValue_ NVARCHAR(256)

  SET @SettingKey_ = (
    SELECT SettingKey
    FROM #TblSettingKey
    WHERE RowNum = @Count2
    )
  SET @SettingValue_ = (
    SELECT SettingValue
    FROM #TblSettingValue
    WHERE RowNum = @Count2
    )

  INSERT INTO MenuMgrSettingValue (
   MenuID
   ,SettingKey
   ,SettingValue
   ,PortalID
   )
  VALUES (
   @MenuID
   ,@SettingKey_
   ,@SettingValue_
   ,@portalID
   )

  SET @Count2 = @Count2 + 1
 END

 INSERT INTO SageMenuSettingValue (
  UserModuleID
  ,SettingKey
  ,SettingValue
  ,PortalID
  )
 VALUES (
  @userModuleID
  ,'MenuID'
  ,@MenuID
  ,@portalID
  )

 SELECT MenuItemID
 FROM #TblMenuItemID

 DROP TABLE #TblMenuItemID

 DROP TABLE #TblCaption

 DROP TABLE #TblHtmlContent

 DROP TABLE #TblImageIcon

 DROP TABLE #TblisActive

 DROP TABLE #TblIsVisible

 DROP TABLE #TblLinkType

 DROP TABLE #TblLinkUrl

 DROP TABLE #TblMenuLevel

 DROP TABLE #TblMenuOrder

 DROP TABLE #TblTitle

 DROP TABLE #TblPageID

 DROP TABLE #TblSettingKey

 DROP TABLE #TblSettingValue
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUnquiePageName]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Milson Munakami
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- Modified By: Dinesh Hona
-- Modified Date: 2010-08-04
-- =============================================

CREATE PROCEDURE [dbo].[sp_CheckUnquiePageName] 
 @PageID int,
 @PortalID int,
 @PageName nvarchar(50), 
 @isEdit bit,
 @pageCount int output
AS
Begin
 --Initilization of output parameter
 Set @pageCount = 0

 --Conditional check
 IF @isEdit = 1
  Begin
   Select @pageCount = IsNull(Count(PageID),0) From dbo.Pages Where PageName = @PageName and PageID <> @PageID AND PortalID = @PortalID AND (IsDeleted=0 OR IsDeleted IS NULL)
  End
 Else
  Begin
   Select @pageCount = IsNull(Count(PageID),0) From dbo.Pages where PageName = @PageName AND PortalID = @PortalID AND (IsDeleted=0 OR IsDeleted IS NULL)
  End
End
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetUsersWithPermissions]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FileManagerGetUsersWithPermissions]
(
@FolderID INT
)
AS
BEGIN
SELECT DISTINCT fp.UserID,u.UserName FROM FolderPermission fp 
INNER JOIN Users u 
ON fp.UserID=u.UserID WHERE fp.FolderID=@FolderID
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetUserID]    Script Date: 12/29/2014 16:38:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FileManagerGetUserID]
(
@UserName NVARCHAR(256)
)
AS
BEGIN
DECLARE @UserID INT
SELECT @UserID=UserID FROM Users WHERE Username=@UserName
IF @UserID IS NULL
SET @UserID=0
SELECT @UserID
END;
GO
/****** Object:  View [dbo].[Country]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Country]
AS
SELECT     EntryID, ListName, Value, Text, ParentID, [Level], CurrencyCode, DisplayLocale, DisplayOrder, DefinitionID, Description, PortalID, SystemList, IsActive, 
                      AddedBy, AddedOn, UpdatedBy, UpdatedOn, Culture
FROM         dbo.Lists
WHERE     (ListName = 'Country')
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateSystemEventStartUp]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateSystemEventStartUp]
 @PortalStartUpID INT,
 @PortalID INT,
 @ControlUrl NVARCHAR(500), 
 @EventLocation NVARCHAR(50),
 @IsAdmin BIT,
 @IsControlUrl BIT,
 @IsActive BIT,
 @UserName NVARCHAR(256)
AS

BEGIN 
 SET NOCOUNT ON;
IF(@PortalStartUpID>0)
BEGIN
UPDATE dbo.PortalStartUp SET PortalID=@PortalID,
       ControlUrl=@ControlUrl,       
       EventLocationName=@EventLocation,
       IsAdmin=@IsAdmin,
       IsControlUrl=@IsControlUrl,
       IsActive=@IsActive,
       IsModified=1,
       UpdatedOn=GETDATE(),
       UpdatedBy=@UserName
       WHERE PortalStartUpID=@PortalStartUpID
       
END
ELSE
BEGIN
INSERT INTO dbo.PortalStartUp(PortalID,ControlUrl,EventLocationName,IsAdmin,IsControlUrl,IsActive,AddedOn,AddedBy)
VALUES(@PortalID,@ControlUrl,@EventLocation,@IsAdmin,@IsControlUrl,@IsActive,GETDATE(),@UserName)
END   
END
GO
/****** Object:  StoredProcedure [dbo].[usp_TutorialRssContentUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TutorialRssContentUpdate]
(@TutorialContent TEXT)
AS
BEGIN

 SET NOCOUNT ON;

  BEGIN TRAN
     DELETE FROM dbo.TutorialRssContent
     IF(@@error<>0) goto ErrorHandler
    
     INSERT INTO dbo.TutorialRssContent(TutorialContent,UpdatedDate) VALUES(@TutorialContent,GETDATE());
     if(@@error<>0) goto ErrorHandler

    COMMIT TRAN
RETURN 0
ERRORHANDLER:
 ROLLBACK TRAN 
RETURN 1
    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_TutorialRssContentGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TutorialRssContentGet]
 AS
BEGIN
SET NOCOUNT ON ; SELECT
 TutorialContent
FROM
 dbo.TutorialRssContent
END
GO
/****** Object:  StoredProcedure [dbo].[usp_TrackSettingsGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TrackSettingsGet] (
 @PortalID INT
 ,@UserModuleID INT
 )
AS
BEGIN
 CREATE TABLE #TbltempTrackUser (
  settingkey NVARCHAR(500)
  ,settingvalue NVARCHAR(500)
  )

 INSERT INTO #TbltempTrackUser
 SELECT [dbo].[TrackSettingKey].[SettingKey] AS settingkey
  ,Coalesce([dbo].[TrackSettingValue].settingvalue, [dbo].[TrackSettingKey].settingvalue) AS settingvalue
 FROM [dbo].[TrackSettingValue]
 RIGHT JOIN [dbo].[TrackSettingKey] ON [dbo].[TrackSettingValue].settingkey = [dbo].[TrackSettingKey].settingkey
  AND [dbo].[TrackSettingValue].usermoduleid = @UserModuleID
  AND [dbo].[TrackSettingValue].portalid = @PortalID;

 WITH tracksetting
 AS (
  SELECT *
  FROM (
   SELECT settingvalue
    ,CASE [SettingKey]
     WHEN 'START_DATE'
      THEN 'START_DATE'
     WHEN 'END_DATE'
      THEN 'END_DATE'
     WHEN 'MAP_TYPE'
      THEN 'MAP_TYPE'
     WHEN 'GAEmailAddress'
      THEN 'GAEmailAddress'
     WHEN 'GAPassword'
      THEN 'GAPassword'
     WHEN 'GAProfileID'
      THEN 'GAProfileID'
     END AS skey
   FROM #TbltempTrackUser
   ) datatable
  PIVOT(MAX(settingvalue) FOR skey IN (
     start_date
     ,end_date
     ,map_type
     ,GAEmailAddress
     ,GAPassword
     ,GAProfileID
     )) pivottable
  )
 SELECT *
 FROM tracksetting

 DROP TABLE #TbltempTrackUser
END
GO
/****** Object:  StoredProcedure [dbo].[usp_TrackSettingGetAll]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TrackSettingGetAll] 
(@UserModuleID INT,
 @PortalID INT)
  WITH EXECUTE AS CALLER AS
BEGIN
 SELECT
  ISNULL(
   [dbo].[TrackSettingValue].[TrackSettingValueID],
   0
  ) AS TrackSettingValueID ,@UserModuleID AS [UserModuleID],
  [dbo].[TrackSettingKey].[SettingKey] AS SettingKey,
  COALESCE (
   [dbo].[TrackSettingValue].SettingValue,
   [dbo].[TrackSettingKey].SettingValue
  ) AS SettingValue,
  [dbo].[TrackSettingValue].[IsActive],
  [dbo].[TrackSettingValue].[IsDeleted],
  [dbo].[TrackSettingValue].[IsModified],
  [dbo].[TrackSettingValue].[AddedOn],
  [dbo].[TrackSettingValue].[UpdatedOn],
  [dbo].[TrackSettingValue].[DeletedOn],
  [dbo].[TrackSettingValue].[PortalID],
  [dbo].[TrackSettingValue].[AddedBy],
  [dbo].[TrackSettingValue].[UpdatedBy],
  [dbo].[TrackSettingValue].[DeletedBy]
 FROM
  [dbo].[TrackSettingValue]
 RIGHT JOIN [dbo].[TrackSettingKey] ON [dbo].[TrackSettingValue].SettingKey = [dbo].[TrackSettingKey].SettingKey
 AND [dbo].[TrackSettingValue].UserModuleID = @UserModuleID
 AND [dbo].[TrackSettingValue].PortalID =@PortalID
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_TrackSettingAddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TrackSettingAddUpdate]
( @UserModuleID INT,
 @SettingKey NVARCHAR (256),
 @SettingValue NVARCHAR (256),
 @IsActive BIT,
 @PortalID INT,
 @UpdatedBy NVARCHAR (256),
 @AddedBy NVARCHAR (256))
  WITH EXECUTE AS CALLER 
 AS
BEGIN

IF (
 EXISTS (
  SELECT
   *
  FROM
   dbo.TrackSettingValue
  WHERE
   [UserModuleID] = @UserModuleID
  AND [SettingKey] = @SettingKey
  AND PortalID = @PortalID
 )
)
BEGIN
 UPDATE dbo.TrackSettingValue
SET [SettingValue] = @SettingValue,
 [IsActive] = @IsActive,
 [IsModified] = 1,
 [UpdatedOn] = getdate(),
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE
 [UserModuleID] = @UserModuleID
AND [SettingKey] = @SettingKey
AND PortalID = @PortalID
END
ELSE

BEGIN
 INSERT INTO dbo.TrackSettingValue (
  [UserModuleID],
  [SettingKey],
  [SettingValue],
  [IsActive],
  [AddedOn],
  [PortalID],
  [AddedBy]
 )
VALUES
 (
  @UserModuleID,
  @SettingKey,
  @SettingValue,
  @IsActive,
  getdate(),
  @PortalID,
  @AddedBy
 )
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_TemplateGetPortalTemplate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TemplateGetPortalTemplate] 
AS
BEGIN
 SELECT
  TemplateName,
  PortalID
 FROM
  sftemplate
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_Template_ParentIDUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Template_ParentIDUpdate] (
 @newMenuItemIDstring NVARCHAR(MAX)
 ,@newMenuParentIDstring NVARCHAR(MAX)
 )
AS
BEGIN
 CREATE TABLE #TblMenuItemID (
  RowNum INT IDENTITY(1, 1)
  ,MenuItemID NVARCHAR(100)
  )

 INSERT INTO #TblMenuItemID
 SELECT *
 FROM dbo.Split(@newMenuItemIDstring, ',')

 DECLARE @TblMenuItemParentID TABLE (
  RowNum INT IDENTITY(1, 1)
  ,ParentID NVARCHAR(100)
  )

 INSERT INTO @TblMenuItemParentID
 SELECT *
 FROM dbo.Split(@newMenuParentIDstring, ',')

 DECLARE @Count INT
  ,@Counter INT

 SET @Counter = (
   SELECT COUNT(1)
   FROM #TblMenuItemID
   )
 SET @Count = 1

 WHILE (@Count <= @Counter)
 BEGIN
  DECLARE @MenuItemID_ INT
  DECLARE @ParentID_ INT

  SET @MenuItemID_ = (
    SELECT MenuItemID
    FROM #TblMenuItemID
    WHERE RowNum = @Count
    )
  SET @ParentID_ = (
    SELECT ParentID
    FROM @TblMenuItemParentID
    WHERE RowNum = @Count
    )

  UPDATE MenuItem
  SET ParentID = @ParentID_
  WHERE MenuItemID = @MenuItemID_

  SET @Count = @Count + 1
 END

 DROP TABLE #TblMenuItemID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SortAdminPages]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SortAdminPages]
( @PageID INT,
 @PageOrder INT,
 @PortalID INT) AS
BEGIN
 UPDATE PAGES
SET PageOrder =@PageOrder
WHERE
 PageID =@PageID  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SiteAnalyticsSettingAddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SiteAnalyticsSettingAddUpdate] (
 @UserModuleID INT,
 @SettingKey NVARCHAR (256),
 @SettingValue NVARCHAR (256),
 @IsActive BIT,
 @PortalID INT,
 @UpdatedBy NVARCHAR (50),
 @AddedBy NVARCHAR (50)
) AS
BEGIN

SET nocount ON ;
IF (
 EXISTS (
  SELECT
   DashboardSettingValueID
  FROM
   DashboardSettingValue
  WHERE
   @SettingKey = SettingKey
  AND PortalID =@PortalID
  AND UserModuleID =@UserModuleID
 )
)
BEGIN
 UPDATE DashboardSettingValue
SET SettingValue =@SettingValue
WHERE
 PortalID =@PortalID
AND SettingKey =@SettingKey
AND UserModuleID =@UserModuleID
END
ELSE

BEGIN
 INSERT INTO DashboardSettingValue (
  SettingKey,
  SettingValue,
  IsActive,
  AddedOn,
  PortalID,
  AddedBy,
  UserModuleID
 )
VALUES
 (
  @SettingKey ,@SettingValue,
  1,
  getdate() ,@PortalID ,@AddedBy ,@UserModuleID
 )
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerGetImageInformationByID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerGetImageInformationByID]
 @ImageID INT
AS
BEGIN
 SELECT ImagePath,Caption,LinkToImage,HTMLBodyText,ReadMorePage,ReadButtonText,Description FROM BannerImage
 WHERE ImageID=@ImageID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerGetHTMLContentForEditByID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerGetHTMLContentForEditByID]
@ImageID INT 
AS
BEGIN
 SELECT ImageID,HTMLBodyText,NavigationImage FROM BannerImage WHERE ImageID=@ImageID AND DATALENGTH(HTMLBodyText)>0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerGetFileName]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerGetFileName]
@ImageId INT
AS
BEGIN
 SELECT ImagePath FROM BannerImage WHERE ImageID=@ImageId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerGetBannerSetting]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[usp_SageBannerGetBannerSetting]1,47,'en-US'
CREATE PROCEDURE [dbo].[usp_SageBannerGetBannerSetting]
(
 @PortalID INT,
 @UserModuleID INT,
 @CultureCode NVARCHAR(100)
)
AS
SELECT *
 FROM (SELECT bk.SettingKey,
   COALESCE(bv.settingvalue, bk.settingvalue) AS settingvalue
   FROM  SageBannerSettingValue bv RIGHT JOIN SageBannerSettingKey bk
   ON bv.SettingKey = bk.SettingKey AND bv.PortalID=@PortalID AND bv.CultureCode=@CultureCode AND bv.UserModuleID=@UserModuleID )p PIVOT(MAX(SettingValue)
     FOR
     SettingKey IN
     (
    [Auto_Direction],
    [Auto_Hover],
    [Auto_Slide],
    [Caption],
    [DisplaySlideQty],
    [Easing],
    [InfiniteLoop],
    [MoveSlideQty],
    [NavigationImagePager],
    [NumericPager],
    [Pause_Time],
    [RandomStart],
    [Speed],
    [Starting_Slide],
    [EnableControl],
    [TransitionMode],
    [BannerToUse]
   )
 ) AS pivottable
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerGetBannerImages]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[usp_SageBannerGetBannerImages]1,47,1,'ne-NP'
CREATE PROCEDURE [dbo].[usp_SageBannerGetBannerImages]
(
 @BannerID INT,
 @UserModuleID INT,
 @PortalID INT,
 @CultureCode NVARCHAR(100)
) 
AS
BEGIN
 SELECT ImagePath,Caption,LinkToImage,HTMLBodyText,NavigationImage,ReadButtonText,ReadMorePage,[Description]
 FROM BannerImage WHERE BannerID=@BannerID 
 AND UserModuleID=@UserModuleID AND CultureCode=@CultureCode
 AND PortalID=@PortalID ORDER BY DisplayOrder 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerGetAllPagesOfSageFrame]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerGetAllPagesOfSageFrame] 
@PortalID INT 
AS
BEGIN
 SELECT p.TabPath,p.SEOName AS PageName FROM Pages p INNER JOIN 
 PageMenu pm ON p.PageID=pm.PageID WHERE IsDeleted=0 AND (pm.IsAdmin=0 OR pm.IsAdmin IS NULL OR p.ParentID>0 )
 AND p.PortalID=@PortalID AND pm.IsAdmin=0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerGetAllBanner]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerGetAllBanner]
(
 @UserModuleID INT,
 @PortalID INT,
 @CultureCode NVARCHAR(10)
)
AS
BEGIN
 SELECT BannerID,BannerName FROM SageBanner WHERE UserModuleID=@UserModuleID AND PortalID=@PortalID AND CultureCode=@CultureCode
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerDeleteHTMLContentByID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerDeleteHTMLContentByID] 
 @ImageId INT
AS
BEGIN
 DELETE FROM BannerImage WHERE ImageID=@ImageId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerDeleteBannerContentByID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerDeleteBannerContentByID] 
 @ImageId INT
AS
BEGIN
 DELETE FROM BannerImage WHERE ImageID=@ImageId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerDeleteBannerAndItsContentByBannerID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerDeleteBannerAndItsContentByBannerID]
@BannerID INT
AS
BEGIN
 DELETE FROM SageBanner WHERE BannerID=@BannerID
 DELETE FROM BannerImage WHERE BannerID=@BannerID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerBannerSortOrderUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerBannerSortOrderUpdate]
(
 @ImageId INT, 
 @MoveUp BIT
)
AS
BEGIN
 DECLARE @CurrentOrder INT,@BannerUsedID INT,@NewOrder INT
 SELECT @BannerUsedID=BannerID FROM BannerImage WHERE ImageID=@ImageId

 IF @MoveUp=1
 BEGIN
  DECLARE @UpEntryOrder INT,@UpID INT 
  SELECT @CurrentOrder=DisplayOrder FROM BannerImage WHERE ImageID=@ImageId and BannerID=@BannerUsedID
  Select @UpEntryOrder=MAX(DisplayOrder) FROM BannerImage WHERE BannerID=@BannerUsedID AND DisplayOrder<@CurrentOrder
  SELECT @UpID=ImageID FROM BannerImage WHERE DisplayOrder=@UpEntryOrder and BannerID=@BannerUsedID
  SELECT @NewOrder=DisplayOrder FROM BannerImage WHERE ImageID=@UpID 
  UPDATE BannerImage SET DisplayOrder=@CurrentOrder WHERE ImageID=@UpID 
  UPDATE BannerImage SET DisplayOrder=@NewOrder WHERE ImageID=@ImageId
 END
 ELSE
 BEGIN
 DECLARE @DownEntryOrder INT,@DownID INT
  SELECT @CurrentOrder=DisplayOrder FROM BannerImage WHERE ImageID=@ImageId and BannerID=@BannerUsedID
  SELECT @DownEntryOrder=MIN(DisplayOrder) FROM BannerImage WHERE BannerID=@BannerUsedID AND DisplayOrder>@CurrentOrder
  SELECT @DownID=ImageID FROM BannerImage WHERE DisplayOrder=@DownEntryOrder and BannerID=@BannerUsedID
  SELECT @NewOrder=DisplayOrder FROM BannerImage WHERE ImageID=@DownID 
  UPDATE BannerImage SET DisplayOrder=@CurrentOrder WHERE ImageID=@DownID
  UPDATE BannerImage SET DisplayOrder=@NewOrder WHERE ImageID=@ImageId
 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerAddHtmlContentToBanner]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerAddHtmlContentToBanner]
(
 @Content NVARCHAR(MAX),
 @Bannerid INT,
 @UserModuleId INT,
 @ImageID INT,
 @NavigationImage NVARCHAR(256),
 @PortalID INT,
 @CultureCode NVARCHAR(256)
) 
AS
IF @ImageID=0
BEGIN
 INSERT INTO BannerImage
 (
  HTMLBodyText,
  BannerID,
  UserModuleID,
  NavigationImage,
  PortalID,
  CultureCode
 )
 VALUES
 (
  @Content,
  @Bannerid,
  @UserModuleId,
  @NavigationImage,
  @PortalID,
  @CultureCode
 ) 
 END
ELSE
 UPDATE BannerImage
 SET
 HTMLBodyText=@Content,
 BannerID=@Bannerid,
 UserModuleID=@UserModuleId,
 NavigationImage=@NavigationImage,
 PortalID=@PortalID
 WHERE ImageID=@ImageID
GO
/****** Object:  StoredProcedure [dbo].[usp_PortalUsersAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PortalUsersAdd]
 @UserID UNIQUEIDENTIFIER,
 @UserName NVARCHAR(256),
 @FirstName NVARCHAR(100),
 @LastName NVARCHAR(100),
 @Email NVARCHAR(256),
 @IsActive BIT,
 @AddedOn DATETIME,
 @PortalID INT,
 @AddedBy NVARCHAR(256)
AS

INSERT INTO [dbo].[PortalUser] (
 [UserID],
 [Username],
 [FirstName],
 [LastName],
 [Email],
 [IsActive],
 [AddedOn],
 [PortalID],
 [IsDeleted],
 [AddedBy]
) VALUES (
 @UserID,
 @UserName,
 @FirstName,
 @LastName,
 @Email,
 @IsActive,
 GETDATE(),
 @PortalID,
 0,
 @AddedBy
)
GO
/****** Object:  StoredProcedure [dbo].[usp_TaskToDo_InsertTask]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TaskToDo_InsertTask] 
 -- Add the parameters for the stored procedure here
 @Note ntext,
 @date datetime,
 @PortalID int,
 @ModuleId int,
 @CultureField nvarchar(200),
 @UserName nvarchar(200),
 @Id int
AS
BEGIN

 SET NOCOUNT ON;
 IF(@Id=0)
 BEGIN
 
 INSERT INTO TaskToDo(Note,Date, CultureField,portalID,ModuleId,AddedBy,AddedOn,IsDeleted)
 VALUES(@Note,@date,@CultureField,@PortalID,@ModuleId,@UserName,GETDATE(),0)
 END
 ELSE
 BEGIN
 UPDATE TaskToDo SET Note=@Note,Date=@date,UpdateBy=@UserName,updateOn=GETDATE()
 WHERE TaskID=@Id
    END 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_TaskToDo_GetTaskContent]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TaskToDo_GetTaskContent]
@CultureCode nvarchar(50),
@PortalID int,
@UserModuleId  int,
@Id int
AS
SELECT TaskId,Note,Date FROM TaskToDo WHERE
 TaskId=@Id and CultureField=@CultureCode and ModuleID=@UserModuleId And portalId=@PortalID
GO
/****** Object:  StoredProcedure [dbo].[usp_TaskToDo_GetTask]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TaskToDo_GetTask] @offset INT
 ,@STR NVARCHAR(50)
 ,@PortalID INT
 ,@ModuleId INT
 ,@Date DATE
 ,@UserName NVARCHAR(200)
 ,@CultureField NVARCHAR(200)
AS
BEGIN
 IF @UserName <> 'anonymoususer'
 BEGIN
  DECLARE @RowTotal INT

  CREATE TABLE #Temptbl (
   RowNum INT identity(1, 1)
   ,TaskId INT
   ,Note NVARCHAR(max)
   ,DATE DATE
   )

  IF @Date = ''
  BEGIN
   IF (@STR = 'PREVIOUS')
   BEGIN
    INSERT INTO #Temptbl
    SELECT TaskId
     ,Note
     ,DATE
    FROM dbo.TaskToDo
    WHERE PortalID = @PortalID
     AND ModuleID = @ModuleId
     AND CultureField = @CultureField
     AND IsDeleted = 0
     AND AddedBy = @UserName
     AND DATE < CONVERT(DATE, GETDATE())
    ORDER BY DATE DESC

    SELECT @RowTotal = COUNT(TaskId)
    FROM #Temptbl

    SELECT TaskID
     ,Note
     ,DATE
     ,@RowTotal AS total
    FROM #Temptbl
    WHERE RowNum > @offset
     AND RowNum <= (@offset + 5)
   END
   ELSE
    IF (@STR = 'TODAY')
    BEGIN
     INSERT INTO #Temptbl
     SELECT TaskId
      ,Note
      ,DATE
     FROM dbo.TaskToDo
     WHERE ModuleID = @ModuleId
      AND CultureField = @CultureField
      AND IsDeleted = 0
      AND AddedBy = @UserName
      AND DATE = CONVERT(DATE, GETDATE())

     SELECT @RowTotal = COUNT(TaskId)
     FROM #Temptbl

     SELECT TaskID
      ,Note
      ,DATE
      ,@RowTotal AS total
     FROM #Temptbl
    END
    ELSE
     IF (@STR = 'UPCOMING')
     BEGIN
      INSERT INTO #Temptbl
      SELECT TaskId
       ,Note
       ,[Date]
      FROM dbo.TaskToDo
      WHERE PortalID = @PortalID
       AND ModuleID = @ModuleId
       AND CultureField = @CultureField
       AND IsDeleted = 0
       AND AddedBy = @UserName
       AND [Date] > CONVERT(DATE, GETDATE())
      ORDER BY DATE

      SELECT @RowTotal = COUNT(TaskId)
      FROM #Temptbl

      SELECT TaskID
       ,Note
       ,DATE
       ,@RowTotal AS total
      FROM #Temptbl
      WHERE RowNum > @offset
       AND RowNum <= (@offset + 5)
     END
     ELSE
     BEGIN
      INSERT INTO #Temptbl
      SELECT TaskId
       ,Note
       ,DATE
      FROM dbo.TaskToDo
      WHERE PortalID = @PortalID
       AND ModuleID = @ModuleId
       AND CultureField = @CultureField
       AND IsDeleted = 0
       AND AddedBy = @UserName
      ORDER BY DATE

      SELECT @RowTotal = COUNT(TaskId)
      FROM #Temptbl

      SELECT TaskID
       ,Note
       ,DATE
       ,@RowTotal AS total
      FROM #Temptbl
      WHERE RowNum > @offset
       AND RowNum <= (@offset + 5)
     END
  END
  ELSE
  BEGIN
   INSERT INTO #Temptbl
   SELECT TaskId
    ,Note
    ,DATE
   FROM dbo.TaskToDo
   WHERE PortalID = @PortalID
    AND ModuleID = @ModuleId
    AND CultureField = @CultureField
    AND IsDeleted = 0
    AND AddedBy = @UserName
    AND DATE = @Date
   ORDER BY DATE DESC

   SELECT @RowTotal = COUNT(TaskId)
   FROM #Temptbl

   SELECT TaskID
    ,Note
    ,DATE
    ,@RowTotal AS total
   FROM #Temptbl
  END

  DROP TABLE #Temptbl
 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_TaskToDo_DeleteTask]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TaskToDo_DeleteTask] 
 -- Add the parameters for the stored procedure here
 @CultureCode nvarchar(50),
    @PortalID int,
    @UserModuleId  int,
 @Id INT,
 @UserName nvarchar(200)
AS
BEGIN

 SET NOCOUNT ON;
 UPDATE TaskToDo  SET IsDeleted='TRUE',DeletedBy=@UserName,DeletedOn=GETDATE() WHERE TaskID=@Id
  and CultureField=@CultureCode and ModuleID=@UserModuleId And portalId=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardGetSettingByKey]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardGetSettingByKey]
(
 @SettingKey NVARCHAR(256),
 @UserName NVARCHAR(256),
 @PortalID INT
) 
AS
BEGIN
 SELECT SettingValue FROM DashboardSettingsKeyValue
 WHERE SettingKey=@SettingKey
 AND PortalID=@PortalID
 AND UserName=@UserName
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashBoardGetAll]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashBoardGetAll] 
(
 @UserModuleID INT,
 @PortalID INT
)
WITH EXECUTE AS CALLER
AS
BEGIN
 SELECT ISNULL([dbo].[DashBoardSettingValue].[DashBoardSettingValueID],0) AS DashBoardSettingValueID
      ,@UserModuleID AS [UserModuleID]
      ,[dbo].[DashBoardSettingKey].[SettingKey] AS SettingKey
      ,COALESCE([dbo].[DashBoardSettingValue].SettingValue,[dbo].[DashBoardSettingKey].SettingValue) AS SettingValue
      ,[dbo].[DashBoardSettingValue].[IsActive]
      ,[dbo].[DashBoardSettingValue].[IsDeleted]
      ,[dbo].[DashBoardSettingValue].[IsModified]
      ,[dbo].[DashBoardSettingValue].[AddedOn]
      ,[dbo].[DashBoardSettingValue].[UpdatedOn]
      ,[dbo].[DashBoardSettingValue].[DeletedOn]
      ,[dbo].[DashBoardSettingValue].[PortalID]
      ,[dbo].[DashBoardSettingValue].[AddedBy]
      ,[dbo].[DashBoardSettingValue].[UpdatedBy]
      ,[dbo].[DashBoardSettingValue].[DeletedBy]
 FROM [dbo].[DashBoardSettingValue]
  RIGHT JOIN [dbo].[DashBoardSettingKey] ON [dbo].[DashBoardSettingValue].SettingKey = [dbo].[DashBoardSettingKey].SettingKey
  AND [dbo].[DashBoardSettingValue].UserModuleID = @UserModuleID 
  AND [dbo].[DashBoardSettingValue].PortalID=@PortalID 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardGetAdminPages]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardGetAdminPages]
(
@PortalID INT
)
AS
BEGIN
 SELECT distinct p.PageID,p.PageName,p.TabPath FROM PageMenu pm
 INNER JOIN Pages p ON pm.PageID=p.PageID WHERE IsAdmin=1
 AND p.PortalID=@PortalID OR p.PortalID=-1 AND (IsDeleted=0 OR IsDeleted IS NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardQuickLinkDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardQuickLinkDelete]
 @QuickLinkID INT 
AS
BEGIN
 SET NOCOUNT ON;
 DELETE FROM [dbo].[DashboardQuickLinks] WHERE QuickLinkID=@QuickLinkID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardQuickLinkAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_DashboardQuickLinkAdd]
(
 @DisplayName NVARCHAR(200),
 @URL NVARCHAR(250),
 @ImagePath NVARCHAR(250),
 @DisplayOrder INT,
 @PageID INT,
 @IsActive BIT
)
AS
BEGIN
 SET NOCOUNT ON;
 INSERT INTO [dbo].[DashboardQuickLinks]
 (
  DisplayName,URL,ImagePath,DisplayOrder,PageID,IsActive
 )
 VALUES
 (
  @DisplayName,@URL,@ImagePath,@DisplayOrder,@PageID,@IsActive
 )
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TemplateAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-06-28
CREATE PROCEDURE [dbo].[sp_TemplateAdd]
 @TemplateTitle NVARCHAR(256),
 @Author NVARCHAR(256),
 @Description NVARCHAR(500),
 @AuthorURL NVARCHAR(256),
 @PortalID INT,
 @UserName NVARCHAR(256)
AS
INSERT INTO 
  [dbo].[Template]
   (
    [TemplateTitle],
    [Author],
    [Description],
    [AuthorURL],
    [PortalID],
    [AddedOn],
    [AddedBy]
   ) 
  VALUES 
   (
    @TemplateTitle,
    @Author,
    @Description,
    @AuthorURL,
    @PortalID,
    GETDATE(),
    @UserName
   )
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePageAsContextMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- earlier the @IsVisible BIT=NULL, @IsPublish bit=NULL this is updated if not published 0-- swantina 20131128


CREATE PROCEDURE [dbo].[sp_UpdatePageAsContextMenu]
@PageID INT,
@IsVisible BIT=0,
@IsPublish BIT=0,
@PortalID INT,
@AddedBy NVARCHAR(256),
@updateFor NVARCHAR(1)
AS
BEGIN
 IF @updateFor ='M'
  BEGIN    
   UPDATE 
    [dbo].[Pages]  
   SET   
     [IsVisible] = @IsVisible
    ,[IsModified] = 1
    ,[UpdatedOn] = GETDATE()
    ,[PortalID] = @PortalID
    ,[UpdatedBy] = @AddedBy    
   WHERE 
     PortalID=@PortalID 
    AND PageID=@PageID  
  END 
 ELSE IF @updateFor ='P'
  BEGIN
   UPDATE [dbo].[Pages]  SET 
   
      [IsActive]=@IsPublish
     ,[IsModified] = 1
     ,[UpdatedOn] = GETDATE()
     ,[PortalID] = @PortalID
     ,[UpdatedBy] = @AddedBy    
   WHERE PortalID=@PortalID AND PageID=@PageID  
  END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateChildLevelTabPath]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-07-21
CREATE PROCEDURE [dbo].[sp_UpdateChildLevelTabPath]
@ParentID INT,
@NewParentLevel INT,
@NewParentTabPath nvarchar(4000),
@UpdatedBy nvarchar(256),
@PortalID INT
AS

BEGIN
 DECLARE @TblChildPages TABLE 
  ( 
   RowNum INT IDENTITY(1,1), 
   ChildPageID INT,
   ChildPageSEOName NVARCHAR(1000)
  )

 INSERT INTO @TblChildPages
  (
   ChildPageID,
   ChildPageSEOName
  ) 
 SELECT 
  PageID,
  SEOName 
 FROM 
  [dbo].Pages 
 WHERE 
   ParentID=@ParentID 
  AND (IsDeleted=0 OR IsDeleted IS NULL)

 DECLARE @Counter INT, @Count INT, @NewPageLevel INT, @NewTabPath NVARCHAR(4000)
 SET @Counter=1
 SELECT @Count=COUNT(*) FROM @TblChildPages
 WHILE @Counter<=@Count
 BEGIN
  DECLARE @ChildPageID INT,@SEOName NVARCHAR(1000)
  SELECT 
   @ChildPageID=ChildPageID,
   @SEOName=ChildPageSEOName 
  FROM 
   @TblChildPages 
  WHERE 
   RowNum=@Counter

  SET @NewPageLevel=@NewParentLevel+1
  SET @NewTabPath=@NewParentTabPath+'/'+@SEOName

  EXECUTE [dbo].[sp_UpdateChildLevelTabPath] @ChildPageID,@NewPageLevel,@NewTabPath,@UpdatedBy,@PortalID

  UPDATE 
   [dbo].Pages 
  SET 
   [Level]=@NewPageLevel,
   TabPath= @NewTabPath 
  WHERE 
   PageID=@ChildPageID

  SET @Counter=@Counter+1
 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ChangePortal]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[usp_ChangePortal] 1
CREATE PROCEDURE [dbo].[usp_ChangePortal]
@PortalID INT
AS
BEGIN
 DECLARE @TableNames TABLE
 (
  RowNo INT IDENTITY(1,1),
  table_name NVARCHAR(256)
 )
 DECLARE @HasTemplate INT
  
 IF EXISTS(SELECT TemplateID FROM Template WHERE PortalID=@PortalID)
  BEGIN
   SET @HasTemplate=1 
  END
 ELSE  
  BEGIN
   SET @HasTemplate=0 
  END
 
 INSERT INTO @TableNames  
 SELECT DISTINCT t.name AS table_name
 FROM sys.tables AS t 
 INNER JOIN sys.columns c ON t.object_id=c.object_id
     WHERE c.name ='PortalID' AND t.name!='Portal' AND t.name !='SettingValue'
     AND t.name!='Modules' AND t.name!='Template' AND t.name!='SettingKey'
  AND t.name!= 'ModuleDefPermission' AND t.name!= 'ModuleControls' 
  AND t.name!= 'ModuleDefinitions' AND t.name!= 'ModuleMessage' 
  AND t.name!= 'MenuMgrSettingKey' AND t.name!= 'Permission' 
  AND t.name!='Packages' 
     DECLARE @TotalTable INT,@Counter INT
  SET @TotalTable=(SELECT COUNT(RowNo) FROM @TableNames)
     SET @Counter=1
     DECLARE @NextPortal INT
     declare @name nvarchar(100)
     declare @seoname nvarchar(100)
     set @name =  (SELECT name from Portal WHERE PortalID=1)
     set @seoname = (SELECT SEOName from Portal WHERE PortalID=1)
     SET @NextPortal=(SELECT MAX(PortalID) FROM Portal)+1
     INSERT INTO Portal 
     (
  Name,
  SEOName,
  IsParent
 )
 
      values (
  @name,
   @seoname,
    0
      )
 DECLARE @currentTable NVARCHAR(256),@UpdateSql NVARCHAR(256),@UpdateSql1 NVARCHAR(256)
 WHILE (@Counter<@TotalTable)
 BEGIN
  SET @currentTable=(SELECT table_name from @TableNames WHERE RowNo=@Counter)
  SET @UpdateSql ='UPDATE [dbo].['+@currentTable+'] '+'SET PortalID='+Cast(@NextPortal as NVARCHAR(100))+'  WHERE PortalID=1'
  SET @UpdateSql1='UPDATE [dbo].['+@currentTable+'] SET PortalID=1 WHERE PortalID='+CAST(@PortalID AS NVARCHAR(100) )+''
  EXEC(@UpdateSql)
  EXEC(@UpdateSql1)
  SET @Counter=@Counter+1
 END 
 DECLARE @SettingValuecounter INT
 SET @SettingValuecounter=1
  UPDATE SettingValue SET SettingTypeID=@NextPortal ,PortalID=@NextPortal WHERE SettingTypeID=1 AND SettingType='SiteAdmin'
  UPDATE SettingValue SET SettingTypeID=1 ,PortalID=1 WHERE SettingTypeID=@PortalID;
  DECLARE @chengedName NVARCHAR(256),@ChangedSeoName NVARCHAR(256)
  SET @ChangedSeoName =(SELECT Name from Portal WHERE PortalID=@PortalID)
  SET @ChangedSeoName=(SELECT SEOName from Portal WHERE PortalID=@PortalID)
  DELETE Portal WHERE PortalID=@PortalID
  UPDATE Portal SET Name=@ChangedSeoName,SEOName=@ChangedSeoName WHERE PortalID=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CDNSaveOrder]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[usp_CDNSaveOrder] 
@URLID INT,
@URLOrder INT,
@PortalID INT
AS
BEGIN

 UPDATE [dbo].[CDN]
 SET 
 URLOrder = @URLOrder
 WHERE URLID = @URLID AND PortalID = @PortalID
END


--1 http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js True 0 1
--10 http://code.jquery.com/ui/1.9.2/jquery-ui.min.js True 1 1
GO
/****** Object:  StoredProcedure [dbo].[usp_CDNSaveLink]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_CDNSaveLink]
@URL NVARCHAR(500),
@IsJs BIT,
@URLOrder INT,
@PortalID INT,
@Mode NVARCHAR(5)
AS

IF(@Mode = 'A')
    BEGIN
  DECLARE @UOD INT
  IF( EXISTS (SELECT 1 FROM CDN))
   SET @UOD=(SELECT MAX(URLOrder)  FROM CDN) + 1
  ELSE
   SET  @UOD=@URLOrder

  INSERT INTO CDN(URL,IsJS,URLOrder,PortalID) VALUES(@URL,@IsJS,@UOD,@PortalID)

 END
ELSE
  BEGIN
   UPDATE CDN SET URL=@URL WHERE URLID=@Mode
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_CDNGetLink]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_CDNGetLink] --1
@PortalID INT
AS
BEGIN
SELECT * FROM CDN WHERE PortalID = @PortalID ORDER BY URLOrder asc
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CDNDeleteLink]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_CDNDeleteLink]
@UrlID int,
@PortalID int
AS
BEGIN
DELETE FROM CDN WHERE URLID=@UrlID AND PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_BreadCrumbMenuItemPath]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_BreadCrumbMenuItemPath] 
AS
BEGIN
 DECLARE @Temp TABLE
 (
  RowNum INT IDENTITY(1,1),
  PageName NVARCHAR(256)
 )
 INSERT INTO @Temp
 SELECT PageName FROM dbo.BreadCrumbMenuItem
  DECLARE @Count INT,@Final NVARCHAR(500),@Counter INT
 SET @Final=''
 SELECT @Count=count(RowNum) FROM @Temp
 SET @Counter=1
  WHILE(@Counter<=@Count or @Count=0)
   BEGIN
    DECLARE @Name nvarchar(100)
    SELECT @Name=PageName FROM @Temp WHERE RowNum = @Counter
    SET @Final=@Final+@Name+'/'
 SET @Counter=@Counter+1
   END
  SET @Final=substring(@Final,0,len(@Final))
 IF((substring(@Final,1,1))='-')
  BEGIN
   SET @Final=replace(@Final,'-','')
  END
SELECT +'/'+@Final as TabPath
END
GO
/****** Object:  StoredProcedure [dbo].[usp_BreadCrumbGetFromPageName]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [usp_BreadCrumbGetFromPageName]'About-EEC',1,'en-US'
CREATE PROCEDURE [dbo].[usp_BreadCrumbGetFromPageName] @SEOName NVARCHAR(100)
 ,@PortalID INT
 ,@CultureCode NVARCHAR(100)
AS
BEGIN
 DECLARE @PageID INT
 DECLARE @DefaultPage NVARCHAR(200)

 SET @DefaultPage = (
   SELECT SettingValue
   FROM SettingValue
   WHERE SettingKey = 'PortalDefaultPage'
    AND settingTypeID = @portalID
   )

 DECLARE @TabPath NVARCHAR(max)

 SET @TabPath = (
   SELECT TabPath
   FROM [dbo].[Pages]
   WHERE SEOName = @SEOName
    AND (
     PortalID = @PortalID
     OR PortalID = - 1
     )
    AND IsDeleted = 0
   ) + '/'
 SET @TabPath = '/' + @DefaultPage + @TabPath

 DECLARE @tblFinal TABLE (
  RowNum INT identity(1, 1)
  ,TabPath NVARCHAR(500)
  ,LocalPage NVARCHAR(500)
  )
 DECLARE @Count INT

 SET @Count = CHARINDEX('/', @TabPath)

 DECLARE @EIND INT

 SET @EIND = 0

 DECLARE @PageName NVARCHAR(500)

 WHILE (@Count != LEN(@TabPath))
 BEGIN
  SET @EIND = ISNULL(((CHARINDEX('/', @TabPath, @Count + 1)) - @Count - 1), 0)
  SET @PageName = (
    SELECT (SUBSTRING(@TabPath, (@Count + 1), @EIND))
    )
  SET @PageID = (
    SELECT PageID
    FROM Pages
    WHERE SEOName = @PageName
     AND PortalID = @PortalID
     AND IsDeleted = 0
    )

  INSERT INTO @tblFinal
  SELECT (SUBSTRING(@TabPath, (@Count + 1), @EIND))
   ,(
    SELECT LocalPageName
    FROM [dbo].[LocalPage]
    WHERE PageID = @PageID
     AND CultureCode = @CultureCode
    )

  SELECT @Count = ISNULL(CHARINDEX('/', @TabPath, @Count + 1), 0)
 END

 SELECT *
 FROM @tblFinal
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardQuickLinkReorder]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardQuickLinkReorder]
(
 @QuickLinkID INT,
 @DisplayOrder INT
) 
AS
BEGIN
 SET NOCOUNT ON;
 UPDATE [dbo].[DashboardQuickLinks]
 SET DisplayOrder=@DisplayOrder 
 WHERE QuickLinkID=@QuickLinkID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardQuickLinkGetDetails]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardQuickLinkGetDetails]
 @QuickLinkItemID INT
AS
BEGIN
 select * FROM DashboardQuickLinks WHERE QuickLinkID=@QuickLinkItemID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SessionTrackerUpdateUsername]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-07-06
CREATE PROCEDURE [dbo].[sp_SessionTrackerUpdateUsername]
 @SessionTrackerID INT,
 @UserName NVARCHAR(256),
 @PortalID INT
AS 
UPDATE 
 [dbo].[SessionTracker] 
SET 
 [Username]=@UserName,
 PortalID=@PortalID 
WHERE 
 SessionTrackerID=@SessionTrackerID
GO
/****** Object:  StoredProcedure [dbo].[sp_SessionTrackerUpdateEND]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-07-06
CREATE PROCEDURE [dbo].[sp_SessionTrackerUpdateEND]
@SessionTrackerID INT,
@PortalID INT
AS 
UPDATE 
 [dbo].[SessionTracker] 
SET 
 [END]=GETDATE(),
 PortalID=@PortalID 
WHERE 
 SessionTrackerID=@SessionTrackerID
GO
/****** Object:  StoredProcedure [dbo].[sp_SessionTrackerPageAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-07-06
CREATE PROCEDURE [dbo].[sp_SessionTrackerPageAdd]
@SessionTrackerID INT,
@SessionTrackerPage NVARCHAR(500),
@SessionTrackerTime VARCHAR(8),
@InsertedID INT OUTPUT
AS
INSERT INTO [dbo].[SessionTrackerPages]
   (
    [SessionTrackerID]
      ,[SessionTrackerPage]
      ,[SessionTrackerTime]
   )
  VALUES
   (
    @SessionTrackerID
      ,@SessionTrackerPage
      ,@SessionTrackerTime
   )

SET @InsertedID=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_SessionTrackerAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-07-06
CREATE PROCEDURE [dbo].[sp_SessionTrackerAdd]
@SessionUserHostAddress NVARCHAR(500),
@SessionUserAgent NVARCHAR(500),
@SessionBrowser NVARCHAR(500),
@SessionCrawler NVARCHAR(500),
@SessionURL NVARCHAR(500),
@SessionVisitCount INT,
@SessionOriginalReferrer NVARCHAR(500),
@SessionOriginalURL NVARCHAR(500),
@UserName NVARCHAR(256),
@PortalID INT,
@InsertedID INT OUTPUT

AS
INSERT INTO [dbo].[SessionTracker]
   (
    [SessionUserHostAddress]
      ,[SessionUserAgent]
      ,[SessionBrowser]
      ,[SessionCrawler]
      ,[SessionURL]
      ,[SessionVisitCount]
      ,[SessionOriginalReferrer]
      ,[SessionOriginalURL]
      ,[Start]
      ,[Username]
      ,[PortalID]
   )
     VALUES
   (
    @SessionUserHostAddress,
    @SessionUserAgent,
    @SessionBrowser,
    @SessionCrawler,
    @SessionURL,
    @SessionVisitCount,
    @SessionOriginalReferrer,
    @SessionOriginalURL,
    GETDATE(),
    @UserName,
    @PortalID
   )

SET @InsertedID=SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_SageSearchBySearchKey]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- truncate table cachesearch
--  [dbo].[sp_SageSearchBySearchKey] 'lorem','superuser',1,'en-US',1,1,10
CREATE Procedure [dbo].[sp_SageSearchBySearchKey]
 @Searchword nvarchar(500),
 @SearchBy nvarchar(256),
 @IsUseFriendlyUrls bit,
 @CultureName nvarchar(256),
 @PortalID INT,
 @offset INT,
 @limit INT
As
Begin

  IF( EXISTS(SELECT SearchWord FROM CacheSearch WHERE SearchWord=@Searchword and CultureName=@CultureName and RowNumber>=@offset and RowNumber<=(@offset+@limit-1) and PortalID=@PortalID))
  BEGIN
   SELECT SearchWord, PageName,UserModuleID,UserModuleTitle,HTMLContent,URL,convert(nvarchar,UpdatedContentOn,106) AS UpdatedContentOn,RowTotal 
   FROM CacheSearch WHERE SearchWord=@Searchword AND RowNumber>=@offset AND RowNumber<=(@offset+@limit-1) and PortalID=@PortalID
   UPDATE CacheSearch SET Counter=Counter+1 WHERE SearchWord=@Searchword and PortalID=@PortalID
  END
    ELSE
Begin
 /* Time Calculation Initilization */

 SET STATISTICS TIME OFF
 Declare @CurrentExecuitionTime float
 SET @CurrentExecuitionTime = 0
 DECLARE @start_time DATETIME, @end_time DATETIME, @dif int
 SET @start_time = CURRENT_TIMESTAMP 

 /* Time Calculation Initilization End */

 --Initilization for Table to hold resut
  Declare @RowTotal INT
  Declare @tblSageSearchResult table
  ( 
   RowNum int identity(1,1),
   CultureName nvarchar(200),   
   PageName nvarchar(256),
   UserModuleID int,
   UserModuleTitle nvarchar(256),
   HTMLContent nvarchar(max),
   URL nvarchar(1000),
   UpdatedContentOn datetime
  )
 --End of Initilization for Table to hold resut

 --Get All Search Extensions from SageSearch Extenson
  Declare @tblSageExtensions table
  (
   RowNum int identity(1,1),
   ProcedureID int,
   SearchTitle nvarchar(100),
   ProcedureName nvarchar(256),
   ExecuteAs nvarchar(50)
  )
  Insert into @tblSageExtensions
  Select
   SageFrameSearchProcedureID,SageFrameSearchTitle,
   SageFrameSearchProcedureName,
   SageFrameSearchProcedureExecuteAs
  From
   dbo.SageFrameSearchProcedure
  Where
   IsActive = 1 And IsDeleted = 0 And PortalID = @PortalID

 --End of Get All Search Extensions from SageSearch Extenson
  --Select * From @tblSageExtensions
  Declare @Counter int
  Declare @RowCounter int
  Set @Counter = 1
  Set @RowCounter = 0
  Select @RowCounter=Count(RowNum) From @tblSageExtensions
  
  --Now Execute one bye one and Filll in Search Result Table
  While (@RowCounter >= @Counter)
  Begin
   Declare @SearchTitle nvarchar(100)
   Declare @ProcedureName nvarchar(256)
   Declare @ExecuteAs nvarchar(50)
   Select @SearchTitle=SearchTitle, @ProcedureName=ProcedureName, @ExecuteAs=ExecuteAs 
   From @tblSageExtensions Where RowNum=@counter
   Declare @ReadyProcedureName nvarchar(500)
   Set @ReadyProcedureName = ''
   Set @ReadyProcedureName = @ExecuteAs + '.' + @ProcedureName + ' ' + 'N''' + @Searchword + ''',' + '''' + @SearchBy + '''' + ',' + Cast(@IsUseFriendlyUrls as nvarchar(10)) + ',' + '''' + @CultureName + '''' + ',' + Cast(@PortalID as nvarchar(10))
   
   
   Insert into @tblSageSearchResult
   Exec(@ReadyProcedureName)
      
   --Incrising Counter
   SET @counter = @counter + 1
  End
 

 --End of Execution
 --Select * from @tblSageSearchResult Order by UpdatedContentOn desc

 --Select distinct PageName from @tblSageSearchResult

 /* Time Calculation End Start */
 --SET @end_time = CURRENT_TIMESTAMP
 --SELECT @CurrentExecuitionTime = DATEDIFF(millisecond, @start_time, @end_time)
 --Select  @CurrentExecuitionTime as CurrentExecuitionTime
 /* Time Calculation End */

 SELECT @RowTotal=COUNT(*) FROM @tblSageSearchResult
    
    SELECT 
     @SearchWord as SearchWord, 
     @RowTotal as RowTotal,
     s.RowNum,
     s.CultureName,
     s.PageName,
     s.UserModuleID,
     s.UserModuleTitle,
     s.HTMLContent,
     s.URL,
     convert(nvarchar,s.UpdatedContentOn,106) AS UpdatedContentOn
     from @tblSageSearchResult as s  
     WHERE  RowNum>=@offset AND RowNum<=(@offset+@limit-1) ORDER BY UpdatedContentOn  DESC

    DECLARE @TotalList int 
  SET @TotalList= (SELECT ISNULL(max(RowTotal),0) FROM CacheSearch WHERE SearchWord=@Searchword and PortalID=@PortalID)
   IF (@TotalList!='')
     BEGIN 
     INSERT into CacheSearch(SearchWord,PageName,UserModuleID,UserModuleTitle,HTMLContent,URL,CultureName,UpdatedContentOn,RowTotal,RowNumber,counter,SearchedDate,PortalID)
      SELECT @Searchword, tb.PageName,tb.UserModuleID,tb.UserModuleTitle ,tb.HTMLContent ,tb.URL,tb.CultureName , convert(nvarchar, UpdatedContentOn , 106) AS UpdatedContentOn, @TotalList AS RowTotal ,RowNum,1,getdate(),@PortalID FROM @tblSageSearchResult AS tb 
       WHERE  RowNum>=@offset AND RowNum<=(@offset+@limit-1) ORDER BY UpdatedContentOn  DESC

     -- DELETE FROM CacheSearch WHERE DATEDIFF(day,getdate(),SearchedDate) < -1
     END
   ELSE

     BEGIN 
      INSERT into CacheSearch(SearchWord,PageName,UserModuleID,UserModuleTitle,HTMLContent,URL,CultureName,UpdatedContentOn,RowTotal,RowNumber,counter,SearchedDate,PortalID)
      SELECT @Searchword, tb.PageName,tb.UserModuleID,tb.UserModuleTitle ,tb.HTMLContent ,tb.URL,tb.CultureName , convert(nvarchar, UpdatedContentOn , 106) AS UpdatedContentOn, @RowTotal AS RowTotal ,RowNum,1,getdate(),@PortalID FROM @tblSageSearchResult AS tb 
       WHERE  RowNum>=@offset AND RowNum<=(@offset+@limit-1) ORDER BY UpdatedContentOn  DESC
       --DELETE FROM CacheSearch WHERE DATEDIFF(day,getdate(),SearchedDate) < -1
     END
  
ENd

End
GO
/****** Object:  StoredProcedure [dbo].[sp_SageFrameSearchSettingValueGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_SageFrameSearchSettingValueGet]
 @PortalID INT,
 @CultureName NVARCHAR(256)
AS

 IF(EXISTS(
    SELECT * FROM dbo.SageFrameSearchSettingValue 
    WHERE 
     [PortalID] = @PortalID 
    AND [CultureName] = @CultureName
   ))
  BEGIN
   SELECT * FROM dbo.SageFrameSearchSettingValue 
   WHERE 
    [PortalID] = @PortalID 
   AND [CultureName] = @CultureName
  END
 Else
  BEGIN
   IF(EXISTS(
      SELECT * FROM dbo.SageFrameSearchSettingValue 
      WHERE PortalID = @PortalID
     ))
    BEGIN
     INSERT INTO dbo.SageFrameSearchSettingValue
      SELECT 
       [SettingKey],
       [SettingValue],
       @CultureName,
       [IsActive],
       [IsDeleted],
       [IsModified],
       [AddedOn],
       [UpdatedOn],
       [DeletedOn],
       [PortalID],
       [AddedBy],
       [UpdatedBy],
       [DeletedBy]
       FROM 
       dbo.[SageFrameSearchSettingValue] 
       WHERE
       [PortalID] = @PortalID

     SELECT * FROM dbo.SageFrameSearchSettingValue 
     WHERE 
      [PortalID] = @PortalID 
     AND [CultureName] = @CultureName
    END
   ELSE
    BEGIN     
     INSERT INTO dbo.SageFrameSearchSettingValue
      SELECT 
       [SettingKey],
       [SettingValue],
       @CultureName,
       [IsActive],
       [IsDeleted],
       [IsModified],
       [AddedOn],
       [UpdatedOn],
       [DeletedOn],
       @PortalID,
       [AddedBy],
       [UpdatedBy],
       [DeletedBy]
       FROM
       dbo.[SageFrameSearchSettingValue] 
      WHERE
       [PortalID] = 1

     SELECT * FROM dbo.SageFrameSearchSettingValue 
     WHERE 
       [PortalID] = @PortalID 
      AND [CultureName] = @CultureName
    END
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_SageFrameSearchSettingValueAddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_SageFrameSearchSettingValueAddUpdate]
 @SettingKeys NVARCHAR(4000),
 @SettingValues NVARCHAR(4000),
 @AddedBy NVARCHAR(256),
 @PortalID INT,
 @CultureName NVARCHAR(256)

AS
BEGIN
 TRUNCATE TABLE CacheSearch 
 DECLARE @TblSettingKeys TABLE
 (
  RowNum INT IDENTITY(1,1),
  SettingKey NVARCHAR(100)
 )
 DECLARE @TblSettingValues TABLE
 (
  RowNum INT IDENTITY(1,1),
  SettingValue NVARCHAR(256)
 )

 INSERT INTO @TblSettingKeys(SettingKey)
 SELECT RTRIM(LTRIM(items)) FROM split(@SettingKeys,'#')
 INSERT INTO @tblSettingValues(SettingValue)
 SELECT RTRIM(LTRIM(items)) FROM split(@SettingValues,'#')

 DECLARE @KeyCount INT
 DECLARE @ValueCount INT
 DECLARE @Counter INT
 SELECT @KeyCount=COUNT(RowNum) from @TblSettingKeys
 SELECT @ValueCount=COUNT(RowNum) from @TblSettingValues
 
 SET @Counter=1
 WHILE(@Counter<=@KeyCount or @Counter=1)
  BEGIN
   DECLARE @Key NVARCHAR(256),@Value NVARCHAR(256)
   SELECT @Key=[SettingKey] FROM @TblSettingKeys WHERE RowNum=@Counter
   SELECT @Value=[SettingValue] FROM @TblSettingValues WHERE RowNum=@Counter
   IF(EXISTS(
     SELECT * FROM [dbo].[SageFrameSearchSettingValue] 
     WHERE 
      [dbo].[SageFrameSearchSettingValue].[SettingKey]=@Key 
     AND [dbo].[SageFrameSearchSettingValue].[PortalID]=@PortalID 
     AND [dbo].[SageFrameSearchSettingValue].[CultureName] = @CultureName
    ))
    BEGIN
     UPDATE [dbo].[SageFrameSearchSettingValue] SET
      [SettingValue] = @Value,
      [UpdatedOn] = GETDATE(),
      [UpdatedBy] = @AddedBy
     WHERE
       [dbo].[SageFrameSearchSettingValue].[SettingKey]=@Key 
      AND [dbo].[SageFrameSearchSettingValue].[PortalID]=@PortalID 
      AND [dbo].[SageFrameSearchSettingValue].[CultureName] = @CultureName
    END
   ELSE
    BEGIN
     INSERT INTO [dbo].[SageFrameSearchSettingValue]
      (
       [SettingKey],
       [SettingValue],
       [CultureName],
       [PortalID],
       [AddedBy]
      )
     VALUES
      (
       @Key,
       @Value,
       @CultureName,
       @PortalID,
       @AddedBy
      )
    END
   SET @counter=@counter+1
  END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SageFrameSearchProcedureList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SageFrameSearchProcedureList]
(
 @PortalID INT
)

AS
BEGIN
 SELECT
 [SageFrameSearchProcedureID],
 [SageFrameSearchTitle],
 [SageFrameSearchProcedureName],
 [SageFrameSearchProcedureExecuteAs],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM 
 [dbo].[SageFrameSearchProcedure]
WHERE 
  [IsDeleted] = 0 
 AND [IsActive] = 1 
 AND [PortalID] = @PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SageFrameSearchProcedureGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SageFrameSearchProcedureGet]
 @SageFrameSearchProcedureID INT
 
AS
BEGIN
 SELECT
 [SageFrameSearchProcedureID],
 [SageFrameSearchTitle],
 [SageFrameSearchProcedureName],
 [SageFrameSearchProcedureExecuteAs],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM 
 [dbo].[SageFrameSearchProcedure]
WHERE
 [SageFrameSearchProcedureID] = @SageFrameSearchProcedureID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SageFrameSearchProcedureDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SageFrameSearchProcedureDelete]
 @SageFrameSearchProcedureID INT,   
 @DeletedBy NVARCHAR(256) 
AS

BEGIN
 UPDATE [dbo].[SageFrameSearchProcedure] SET 
  [IsDeleted] = 1, 
  [DeletedOn] = GETDATE(),  
  [DeletedBy] = @DeletedBy
 WHERE
  [SageFrameSearchProcedureID] = @SageFrameSearchProcedureID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SageFrameSearchProcedureAddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SageFrameSearchProcedureAddUpdate]
 @SageFrameSearchProcedureID INT,
 @SageFrameSearchTitle NVARCHAR(100),
 @SageFrameSearchProcedureName NVARCHAR(256),
 @SageFrameSearchProcedureExecuteAs NVARCHAR(50),
 @IsActive BIT, 
 @AddedOn DATETIME, 
 @PortalID INT,
 @AddedBy NVARCHAR(256) 
AS
BEGIN
 IF @SageFrameSearchProcedureID = 0
  BEGIN
   INSERT INTO [dbo].[SageFrameSearchProcedure] (
    [SageFrameSearchTitle],
    [SageFrameSearchProcedureName],
    [SageFrameSearchProcedureExecuteAs],
    [IsActive],
    [IsDeleted],
    [IsModified],
    [AddedOn],
    [UpdatedOn],   
    [PortalID],
    [AddedBy]   
   ) VALUES (
    @SageFrameSearchTitle,
    @SageFrameSearchProcedureName,
    @SageFrameSearchProcedureExecuteAs,
    @IsActive,
    0,
    0,
    GETDATE(),
    GETDATE(),   
    @PortalID,
    @AddedBy   
   )
  END
 ELSE
  BEGIN
   UPDATE [dbo].[SageFrameSearchProcedure] SET
    [SageFrameSearchTitle] = @SageFrameSearchTitle,
    [SageFrameSearchProcedureName] = @SageFrameSearchProcedureName,
    [SageFrameSearchProcedureExecuteAs] = @SageFrameSearchProcedureExecuteAs,
    [IsActive] = @IsActive,  
    [IsModified] = 1,  
    [UpdatedOn] = GETDATE(),  
    [PortalID] = @PortalID,  
    [UpdatedBy] = @AddedBy  
   WHERE
    [SageFrameSearchProcedureID] = @SageFrameSearchProcedureID
  END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PagesGetByPageID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PagesGetByPageID] 
  @PageID int 
AS


DECLARE @str VARCHAR(100)
DECLARE @MenuPages nvarchar(250)
DECLARE @caption nvarchar(250)
set @caption = (select top 1 caption from MenuItem where PageID=@PageID)
select @str=COALESCE(@str+'/', '') + cast(MenuID as varchar(20))  from MenuItem where PageID=@PageID
select @MenuPages=ISNULL(@str,0)


SELECT
 [PageID],
 [PageOrder],
 [PageName],
 [IsVisible],
 [ParentID],
 [Level],
 [IconFile],
 [DisableLink],
 [Title],
 [Description],
 [KeyWords],
 [Url],
 [TabPath],
 [StartDate],
 [EndDate],
 [RefreshInterval],
 [PageHeadText],
 [IsSecure],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy],
 [SEOName],
 [IsShowInFooter],
 [IsRequiredPage],
 @MenuPages AS MenuPages,
 @caption AS caption
 
FROM dbo.Pages
WHERE
 [PageID] = @PageID
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalUpdate]
 @PortalID INT,
 @PortalName NVARCHAR(200),
 @IsParent BIT,
 @UserName NVARCHAR(256),
 @PortalURL NVARCHAR(256),
 @ParentID INT
AS
BEGIN
 DECLARE @PortalSEOName NVARCHAR(100)
 --SET @PortalSEOName=LOWER(LTRIM(RTRIM(REPLACE(@PortalName,' ','-'))))
 SET @PortalSEOName=@PortalURL
 IF(NOT(EXISTS(SELECT * FROM dbo.Portal WHERE PortalID=@PortalID)))
 BEGIN
  RAISERROR('Portal does not Exist!', 16, 1)
 END
 ELSE
 BEGIN
  UPDATE [dbo].[Portal] SET  [Name]=@PortalName,[SEOName]=@PortalSEOName,ParentID=@ParentID,IsParent =@IsParent 
  WHERE PortalID=@PortalID
 END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalGetList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[sp_PortalGetList]
 AS
 BEGIN
  SELECT Por.PortalID,[Name],LOWER(LTRIM(RTRIM(SEOName))) AS SEOName, IsParent ,Por.ParentID,
    (Select SEOName FROM Portal as port WHERE Por.ParentID = port.PortalID  ) AS ParentPortalName,
    [dbo].[SettingValue].SettingValue AS DefaultPage
  FROM dbo.Portal AS Por
     INNER JOIN [dbo].[SettingValue] ON  Por.PortalID = [dbo].[SettingValue].settingtypeid 
  WHERE SettingType='SiteAdmin' and SettingKey='PortalDefaultPage'
 END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalGetByPortalID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalGetByPortalID] 
 @PortalID INT,
 @UserName NVARCHAR(256)
AS
BEGIN
                SELECT POR.*,
    (Select SEOName FROM Portal as Port WHERE Por.ParentID = Port.PortalID  ) AS ParentPortalName
     FROM dbo.Portal POR WHERE PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PagePortalGetByCustomPrefix]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: Dinesh Hona
--CREATED DATE: 2010-07-29
CREATE PROCEDURE [dbo].[sp_PagePortalGetByCustomPrefix] --'---',true,false,1,'superuser',null,null
 @prefix [nvarchar](10),
 @IsActive [bit],
 @IsDeleted [bit],
 @PortalID [int],
 @UserName [nvarchar](256),
 @IsVisible [bit],
 @IsRequiredPage bit
WITH EXECUTE AS CALLER
AS
BEGIN
select * from pages where portalid=@PortalID or portalid=-1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_MessageTemplateUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: 
--CREATED DATE: 2010-04-09
--Modified DATE: 2010-04-25
CREATE PROCEDURE [dbo].[sp_MessageTemplateUpdate]
 @MessageTemplateID INT,
 @MessageTemplateTypeID INT,
 @Subject NVARCHAR(200),
 @Body ntext,
 @MailFrom nvarchar(100),
 @IsActive BIT,
 @UpdatedOn DATETIME,
 @PortalID INT,
 @UpdatedBy NVARCHAR(256),
 @CurrentCulture NVARCHAR(256)
AS
UPDATE [dbo].[MessageTemplate] SET
 [MessageTemplateTypeID] = @MessageTemplateTypeID,
 [Subject] = @Subject,
 [Body] = @Body,
 [MailFrom] = @MailFrom,
 [IsActive] = @IsActive,
 [IsModified] = 1,
 [UpdatedOn] = @UpdatedOn,
 [UpdatedBy] = @UpdatedBy
WHERE PortalID=@PortalID AND [MessageTemplateID] = @MessageTemplateID AND Culture=@CurrentCulture
GO
/****** Object:  StoredProcedure [dbo].[sp_MessageTemplateTypeAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_MessageTemplateTypeAdd]
 @MessageTemplateTypeID [int] OUTPUT,
 @Name [nvarchar](200),
 @IsActive [bit],
 @AddedOn [datetime],
 @PortalID [int],
 @AddedBy nvarchar(256)
WITH EXECUTE AS CALLER
AS
INSERT INTO [dbo].[MessageTemplateType] (
 [Name],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @Name,
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)

SET @MessageTemplateTypeID = @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_MessageTemplateDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_MessageTemplateDelete]
 @MessageTemplateID INT,
 @PortalID INT,
 @DeletedOn DATETIME,
 @DeletedBy NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
UPDATE [dbo].[MessageTemplate] SET
 [IsDeleted] = 1,
 [DeletedOn] = @DeletedOn,
 DeletedBy = @DeletedBy
WHERE PortalID=@PortalID AND
 [MessageTemplateID] = @MessageTemplateID
GO
/****** Object:  StoredProcedure [dbo].[sp_MessageTemplateByMessageTemplateTypeID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: 
--CREATED DATE: 2010-04-09
--Modified DATE: 2011-04-25
--[dbo].[sp_MessageTemplateByMessageTemplateTypeID]10,48
CREATE PROCEDURE [dbo].[sp_MessageTemplateByMessageTemplateTypeID]
 @MessageTemplateTypeID INT,
 @PortalID INT
AS
SELECT TOP 1 mt.[MessageTemplateID], 
       mt.[MessageTemplateTypeID], 
       mt.[Subject], 
       mt.[Body], 
       mt.[MailFrom], 
       mt.[IsActive], 
       mt.[IsDeleted], 
       mt.[IsModified], 
       mt.[AddedOn], 
       mt.[UpdatedOn], 
       mt.[DeletedOn], 
       mt.[PortalID], 
       mt.[AddedBy], 
       mt.[UpdatedBy], 
       mt.[DeletedBy] 
FROM   MessageTemplateTypeMap mttm 
       INNER JOIN MessageTemplateType mtt 
         ON mttm.PortalSpecID = mtt.MessageTemplateTypeID 
       INNER JOIN MessageTemplate mt 
         ON mt.MessageTemplateTypeID = mtt.MessageTemplateTypeID 
WHERE  mttm.PortalID =@PortalID
       AND mttm.MessageTemplateTypeID = @MessageTemplateTypeID
    AND mt.IsActive=1 AND (mt.IsDeleted=0 OR mt.IsDeleted IS NULL)
GO
/****** Object:  StoredProcedure [dbo].[sp_MessageTemplateAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Created By: 
--Modified DATE: 2010-04-25,2010-08-01
CREATE PROCEDURE [dbo].[sp_MessageTemplateAdd]
 @MessageTemplateID [int] OUTPUT,
 @MessageTemplateTypeID [int],
 @Subject [nvarchar](200),
 @Body [ntext],
 @MailFrom NVARCHAR(100),
 @IsActive [bit],
 @AddedOn [datetime],
 @PortalID [int],
 @AddedBy [nvarchar](256),
 @CurrentCulture NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
INSERT INTO [dbo].[MessageTemplate] (
 [MessageTemplateTypeID],
 [Subject],
 [Body],
 [MailFrom], Culture,
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @MessageTemplateTypeID,
 @Subject,
 @Body,
 @MailFrom,@CurrentCulture,
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)

SET @MessageTemplateID = @@IDENTITY

INSERT INTO [dbo].[MessageTemplateTypeMap]
(
 MessageTemplateTypeID,PortalSpecID,PortalID
)
VALUES
(
 @MessageTemplateTypeID,@MessageTemplateID,@PortalID
)
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_DashboardSidebarDelete]
@SidebarItemID INT
AS
BEGIN
 DELETE FROM [dbo].[DashboardSidebar] WHERE ParentID=@SidebarItemID
 DELETE FROM [dbo].[DashboardSidebar] WHERE SidebarItemID=@SidebarItemID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_DashboardSidebarAdd] (
 @DisplayName NVARCHAR(200)
 ,@Depth INT
 ,@ImagePath NVARCHAR(250)
 ,@URL NVARCHAR(250)
 ,@ParentID INT
 ,@IsActive BIT
 ,@DisplayOrder INT
 ,@PageID INT
 )
AS
BEGIN
 SET NOCOUNT ON;

 DECLARE @PDepth INT

 IF (@Depth = 0)
  SET @PDepth = @Depth
 ELSE
  SELECT @PDepth = [DashboardSidebar].Depth + 1
  FROM [dbo].[DashboardSidebar]
  WHERE @ParentID = SidebarItemID

 INSERT INTO [dbo].[DashboardSidebar] (
  DisplayName
  ,Depth
  ,ImagePath
  ,URL
  ,ParentID
  ,IsActive
  ,DisplayOrder
  ,PageID
  )
 VALUES (
  @DisplayName
  ,@PDepth
  ,@ImagePath
  ,@URL
  ,@ParentID
  ,@IsActive
  ,@DisplayOrder
  ,@PageID
  )
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashBoardSettingsSelect]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashBoardSettingsSelect] 
(
 @PortalID INT, 
 @UserModuleID INT 
) 
AS 
  BEGIN 
      DECLARE @TbltempDashBoardControl TABLE
      ( 
        settingkey   NVARCHAR(500), 
        settingvalue NVARCHAR(500)
        ) 

      INSERT INTO @TbltempDashBoardControl 
      SELECT [dbo].[DashBoardSettingKey].[SettingKey]  AS settingkey, 
             COALESCE([dbo].[DashBoardSettingValue].settingvalue, 
             [dbo].[DashBoardSettingKey].settingvalue) AS settingvalue 
      FROM   [dbo].[DashBoardSettingValue] 
             RIGHT JOIN [dbo].[DashBoardSettingKey] 
               ON [dbo].[DashBoardSettingValue].settingkey = [dbo].[DashBoardSettingKey].settingkey 
                  AND [dbo].[DashBoardSettingValue].usermoduleid = @UserModuleID 
                  AND [dbo].[DashBoardSettingValue].portalid = @PortalID; 

      WITH tracksetting 
           AS (SELECT * 
               FROM (SELECT settingvalue, 
                              CASE [SettingKey] 
                                WHEN 'START_DATE' THEN 'START_DATE' 
                                WHEN 'END_DATE' THEN 'END_DATE' 
                                WHEN 'SELECT_TYPE' THEN 'SELECT_TYPE'
        
                              END AS skey 
                       FROM   @TbltempDashBoardControl)datatable PIVOT ( MAX(settingvalue) 
                      FOR skey 
                      IN ( 
                      start_date, end_date, select_type ))pivottable) 
      SELECT * FROM tracksetting 
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashBoardSettingAddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashBoardSettingAddUpdate]
(
 @SettingKey NVARCHAR(256),
 @SettingValue NVARCHAR(256),
 @UserName NVARCHAR(50),
 @PortalID INT
) 
AS
BEGIN
 SET NOCOUNT ON;
 IF(EXISTS(SELECT DashboardSettingKeyID FROM DashboardSettingsKeyValue
     WHERE @SettingKey=SettingKey AND PortalID=@PortalID 
     AND UserName=@UserName))
  BEGIN
   UPDATE DashboardSettingsKeyValue
   SET SettingValue=@SettingValue
   WHERE UserName=@UserName AND PortalID=@PortalID AND SettingKey=@SettingKey
  END
 ELSE
  BEGIN
   INSERT INTO DashboardSettingsKeyValue
   (
    SettingKey,SettingValue,IsActive,AddedOn,PortalID,UserName
   )
   VALUES
   (
    @SettingKey,@SettingValue,1,GETDATE(),@PortalID,@UserName
   )
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardQuickLinkUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_DashboardQuickLinkUpdate]
(
 @DisplayName NVARCHAR(200),
 @URL NVARCHAR(250),
 @ImagePath NVARCHAR(250),
 @QuickLinkID INT,
 @PageID INT,
 @IsActive BIT
) 
AS
BEGIN
 SET NOCOUNT ON;
 UPDATE [dbo].[DashboardQuickLinks]
 SET DisplayName=@DisplayName,URL=@URL,ImagePath=@ImagePath,IsActive=@IsActive,PageID=@PageID
 WHERE QuickLinkID=@QuickLinkID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SettingPortalAddUpdateList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[sp_SettingPortalAddUpdateList]
 @strKeyes NVARCHAR(4000),
 @strValues nvarchar(4000),
 @PortalID INT,
 @Return INT OUTPUT 
As
BEGIN
 
 DECLARE @TblKeyes TABLE (SettingID INT)
 DECLARE @TblValues TABLE (SettingValues NVARCHAR(2000))
 DECLARE @Pos INT
 SET @Pos = 0
 DECLARE @KeyCount INT
 SET @KeyCount = 0
 DECLARE @ValueCount INT
 SET @ValueCount = 0
 
 WHILE CHARINDEX('#', @strKeyes, 1) > 0 
  BEGIN
   SET @Pos = CHARINDEX('#', @strKeyes, 1)
   INSERT @TblKeyes VALUES (CAST(SUBSTRING(@strKeyes, 1, @Pos-1) AS INT))
   SET @strKeyes = SUBSTRING(@strKeyes, @Pos+1, DATALENGTH(@strKeyes)-@Pos)
  END
 INSERT @TblKeyes VALUES (CAST(@strKeyes AS INT))
 
 
 SET @Pos = 0
 WHILE CHARINDEX('#', @strValues, 1) > 0 
  BEGIN
   SET @Pos = CHARINDEX('#', @strValues, 1)
   INSERT @TblValues VALUES (CAST(SUBSTRING(@strValues, 1, @Pos-1) AS NVARCHAR(2000)))
   SET @strValues = SUBSTRING(@strValues, @Pos+1, DATALENGTH(@strValues)-@Pos)
  END
 INSERT @TblValues VALUES (CAST(@strValues AS NVARCHAR(2000)))
 
 SELECT @KeyCount = COUNT(SettingID) FROM @TblKeyes
 SELECT @ValueCount = COUNT(SettingValues) FROM @TblValues
 
 IF @KeyCount = @ValueCount
  BEGIN
   WHILE @KeyCount <> 0
    BEGIN

     DECLARE @SettingID INT
     DECLARE @SettingValue NVARCHAR(2000)

     SELECT TOP 1 @SettingID = SettingID FROM @TblKeyes
     SELECT TOP 1 @SettingValue = SettingValues FROM @TblValues
     
     EXEC [dbo].[sp_SettingPortalUpdate] @SettingID,@SettingValue,@PortalID

     
     DELETE TOP(1) FROM @TblKeyes
     DELETE TOP(1) FROM @TblValues

     
     SELECT @KeyCount = COUNT(SettingID) FROM @TblKeyes
    End
   SET @Return = 0
  END
 ELSE
  BEGIN
   SET @Return = 1
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteSystemEventStartUp]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteSystemEventStartUp]
@PortalStartUpID int,
@UserName nvarchar(256)
AS
BEGIN
 SET NOCOUNT ON;
   UPDATE dbo.PortalStartUp SET
     IsDeleted=1,
     DeletedOn=GETDATE(),
     DeletedBy=@UserName
    WHERE PortalStartUpID=@PortalStartUpID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardSidebarUpdate]
(
 @DisplayName NVARCHAR(200),
 @Depth INT,
 @ImagePath NVARCHAR(250),
 @URL NVARCHAR(250),
 @ParentID INT,
 @IsActive BIT,
 @SidebarItemID INT,
 @PageID INT
) 
AS
BEGIN
SET NOCOUNT ON;
 UPDATE [dbo].[DashboardSidebar]
 SET DisplayName=@DisplayName,URL=@URL,ImagePath=@ImagePath,
 ParentID=@ParentID,IsActive=@IsActive,PageID=@PageID
 WHERE SidebarItemID=@SidebarItemID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarReorder]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardSidebarReorder]
(
 @SidebarItemID INT,
 @DisplayOrder  INT
) 
AS
BEGIN
SET NOCOUNT ON;
 UPDATE [dbo].[DashboardSidebar]
  SET DisplayOrder=@DisplayOrder 
  WHERE SidebarItemID=@SidebarItemID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarGetParents]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardSidebarGetParents]

(

@SidebarItemID INT

)

AS

BEGIN

 SELECT * FROM  DashboardSidebar WHERE( Depth=0 OR Depth=1) AND SidebarItemID!=@SidebarItemID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarGetDetails]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardSidebarGetDetails]
@SidebarItemID INT
AS 
BEGIN
 SELECT * from DashboardSidebar WHERE SidebarItemID=@SidebarItemID
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UnRegisterSchemaVersion]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UnRegisterSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    DELETE FROM dbo.aspnet_SchemaVersions
        WHERE   Feature = LOWER(@Feature) AND @CompatibleSchemaVersion = CompatibleSchemaVersion
END
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheUpdateChangeIdStoredProcedure]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheUpdateChangeIdStoredProcedure] 
             @tableName NVARCHAR(450) 
         AS

         BEGIN 
             UPDATE dbo.AspNet_SqlCacheTablesForChangeNotification WITH (ROWLOCK) SET changeId = changeId + 1 
             WHERE tableName = @tableName
         END
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheUnRegisterTableStoredProcedure]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheUnRegisterTableStoredProcedure] 
             @tableName NVARCHAR(450) 
         AS
         BEGIN

         BEGIN TRAN
         DECLARE @triggerName AS NVARCHAR(3000) 
         DECLARE @fullTriggerName AS NVARCHAR(3000)
         SET @triggerName = REPLACE(@tableName, '[', '__o__') 
         SET @triggerName = REPLACE(@triggerName, ']', '__c__') 
         SET @triggerName = @triggerName + '_AspNet_SqlCacheNotification_Trigger' 
         SET @fullTriggerName = 'dbo.[' + @triggerName + ']' 

         /* Remove the table-row from the notification table */ 
         IF EXISTS (SELECT name FROM sysobjects WITH (NOLOCK) WHERE name = 'AspNet_SqlCacheTablesForChangeNotification' AND type = 'U') 
             IF EXISTS (SELECT name FROM sysobjects WITH (TABLOCKX) WHERE name = 'AspNet_SqlCacheTablesForChangeNotification' AND type = 'U') 
             DELETE FROM dbo.AspNet_SqlCacheTablesForChangeNotification WHERE tableName = @tableName 

         /* Remove the trigger */ 
         IF EXISTS (SELECT name FROM sysobjects WITH (NOLOCK) WHERE name = @triggerName AND type = 'TR') 
             IF EXISTS (SELECT name FROM sysobjects WITH (TABLOCKX) WHERE name = @triggerName AND type = 'TR') 
             EXEC('DROP TRIGGER ' + @fullTriggerName) 

         COMMIT TRAN
         END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMessageTemplateTypeList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-04-09
--Modified By: Dinesh Hona
--Modified Date: 2010-08-01
CREATE PROCEDURE [dbo].[sp_GetMessageTemplateTypeList]
 @IsActive [BIT],
 @IsDeleted [BIT],
 @PortalID [INT],
 @UserName NVARCHAR(256),
 @CurrentCulture NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
SELECT
 MTT.[MessageTemplateTypeID],
 MTT.[Name],
 COALESCE(LMTT.[Name],MTT.[Name]) AS CultureName 
FROM [dbo].[MessageTemplateType] AS MTT
LEFT JOIN [dbo].[LanguageMessageTemplateType] AS LMTT ON LMTT.[MessageTemplateTypeID]=MTT.[MessageTemplateTypeID]
WHERE MTT.IsActive=@IsActive AND MTT.IsDeleted=@IsDeleted AND (MTT.PortalID=@PortalID OR MTT.PortalID IS NULL) AND (LMTT.PortalID=@PortalID OR LMTT.PortalID IS NULL) AND (LMTT.Culture=@CurrentCulture OR LMTT.Culture IS NULL)
ORDER BY MTT.[Name]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMessageTemplateList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-04-09
--Modified DATE: 2010-04-25
CREATE PROCEDURE [dbo].[sp_GetMessageTemplateList]
 @IsActive [BIT],
 @IsDeleted [BIT],
 @PortalID [INT],
 @UserName NVARCHAR(256),
 @CurrentCulture NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
SELECT
 [MessageTemplateID],
 [MessageTemplateTypeID],
 [Subject],
 [Body],
 [MailFrom],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[MessageTemplate]
WHERE (IsDeleted=0 OR IsDeleted IS NULL) AND PortalID=@PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMessageTemplate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: DINESH HONA
--CREATED DATE: 2010-04-09
--Modified DATE: 2010-04-25
CREATE PROCEDURE [dbo].[sp_GetMessageTemplate]
 @MessageTemplateID int,
 @PortalID int
AS
SELECT
 [MessageTemplateID],
 [MessageTemplateTypeID],
 [Subject],
 [Body],
 [MailFrom],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM
 [dbo].[MessageTemplate]
WHERE PortalID = @PortalID AND
 [MessageTemplateID] = @MessageTemplateID
GO
/****** Object:  StoredProcedure [dbo].[sp_GoogleAnalyticsListByPortalID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GoogleAnalyticsListByPortalID]
 @PortalID INT
AS
SELECT
 [GoogleAnalyticsID],
 [GoogleJSCode],
 [IsActive],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy]
FROM [dbo].[GoogleAnalytics]
WHERE
 PortalID = @PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_GoogleAnalyticsListActiveOnlyByPortalID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GoogleAnalyticsListActiveOnlyByPortalID]
 @PortalID INT
AS
SELECT
 [GoogleAnalyticsID],
 [GoogleJSCode],
 [IsActive],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy]
FROM [dbo].[GoogleAnalytics]
WHERE
 [IsActive] = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_GoogleAnalyticsAddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GoogleAnalyticsAddUpdate]
 @GoogleJSCode NVARCHAR(1500),
 @IsActive BIT, 
 @PortalID INT,
 @AddedBy NVARCHAR(256)
AS
IF NOT EXISTS
(
 SELECT * FROM [dbo].[GoogleAnalytics] WHERE
 PortalID = @PortalID
)
 BEGIN
  INSERT INTO [dbo].[GoogleAnalytics] (
   [GoogleJSCode],
   [IsActive],
   [IsModified],
   [AddedOn],
   [UpdatedOn],
   [PortalID],
   [AddedBy]
  ) VALUES (
   @GoogleJSCode,
   @IsActive,
   0,
   GETDATE(),
   GETDATE(),
   @PortalID,
   @AddedBy
  )
 END
ELSE
 BEGIN
  UPDATE [dbo].[GoogleAnalytics] SET
   [GoogleJSCode] = @GoogleJSCode,
   [IsActive] = @IsActive,
   [IsModified] = 1,   
   [UpdatedOn] = GETDATE(),  
   [UpdatedBy] = @AddedBy
  WHERE
   @PortalID = @PortalID
 END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsernameByActivationOrRecoveryCode]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: 2010-08-03
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUsernameByActivationOrRecoveryCode]--'2e1bfd29-b83f-4c08-86de-59e399b68141',29
 @Code NVARCHAR(256),
 @PortalID INT
AS
BEGIN
 SELECT * FROM [dbo].[Codes] WHERE Code=@Code AND GETDATE() BETWEEN ActiveFrom AND ActiveTo
AND  PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserLastName]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: 2010-04-15
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserLastName]
@UserName NVARCHAR(256),
@PortalID INT
AS
BEGIN
SELECT LastName FROM
dbo.Users
WHERE PortalID=@PortalId AND Username=@UserName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserFirstName]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: 2010-04-15
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserFirstName]
@UserName NVARCHAR(256),
@PortalID INT
AS
BEGIN
SELECT FirstName FROM
dbo.Users
WHERE PortalID=@PortalId AND Username=@UserName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserEmail]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: 2010-04-15
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUserEmail]
@UserName NVARCHAR(256),
@PortalID INT
AS
BEGIN
SELECT Email FROM
dbo.Users
WHERE PortalID=@PortalId AND Username=@UserName
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListSortOrderUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--author: Sushil Sapkota 
--Date:s/4/2013 
CREATE PROCEDURE [dbo].[sp_ListSortOrderUpdate] (@EntryID INT, 
                                                @MoveUp  BIT, 
                                                @Culture NVARCHAR(256)) 
AS 
  BEGIN 
      DECLARE @CurrentOrder INT, 
              @ListName     NVARCHAR(250), 
              @NewOrder     INT, 
              @parentId     int 

      SELECT @ListName = ListName 
      FROM   Lists 
      WHERE  EntryID = @EntryID 

      set @parentId=(select ParentID 
                     from   Lists 
                     where  EntryID = @EntryID) 

      SELECT @CurrentOrder = DisplayOrder 
      FROM   Lists 
      WHERE  EntryID = @EntryID 
             AND ListName = @ListName 

      IF @MoveUp = 1 
        BEGIN 
            DECLARE @UpEntryOrder INT, 
                    @UpID         INT 

            if( @CurrentOrder - 1 != 0 ) 
              begin 
                  set @UpID=(select EntryID 
                             from   Lists 
                             where  ListName = @ListName 
                                    and ParentID = @parentId 
                                    and DisplayOrder = ( @CurrentOrder - 1 )) 

                  print @upId 

                  print @CurrentOrder 

                  print @CurrentOrder - 1 

                  Update Lists 
                  SET    DisplayOrder = ( @CurrentOrder - 1 ) 
                  where  EntryID = @EntryID 

                  UPDATE Lists 
                  SET    DisplayOrder = ( @CurrentOrder ) 
                  where  EntryID = @UpID 
              end 
        END 
      ELSE 
        BEGIN 
            DECLARE @DownEntryOrder INT, 
                    @DownID         INT 

            set @DownEntryOrder=(SELECT MAX(DisplayOrder) 
                                 from   Lists 
                                 where  ListName = @ListName 
                                        and ParentID = @parentId) 

            if( @CurrentOrder < @DownEntryOrder ) 
              begin 
                  set @DownID=(select EntryID 
                               from   Lists 
                               where  ListName = @ListName 
                                      and ParentID = @parentId 
                                      and DisplayOrder = ( @CurrentOrder + 1 )) 

                  Update Lists 
                  SET    DisplayOrder = ( @CurrentOrder + 1 ) 
                  where  EntryID = @EntryID 

                  UPDATE Lists 
                  SET    DisplayOrder = ( @CurrentOrder ) 
                  where  EntryID = @DownID 
              end 
        END 
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_ListEntryUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListEntryUpdate]
 
 @EntryID INT, 
 @Value NVARCHAR(100), 
 @Text NVARCHAR(150), 
 @CurrencyCode NVARCHAR(50),
 @DisplayLocale NVARCHAR(50),
 @Description NVARCHAR(500),
 @IsActive BIT,
 @UpdatedBy NVARCHAR(256),
 @Culture NVARCHAR(256)

AS
 UPDATE dbo.Lists
  SET 
   [Value] = @Value,
   [Text] = @Text,   
   [CurrencyCode]=@CurrencyCode,
   [DisplayLocale]=@DisplayLocale,
   [Description] = @Description,
   [IsActive]=@IsActive,
   [UpdatedBy] = @UpdatedBy, 
   [UpdatedOn] = GETDATE()
  WHERE  [EntryID] = @EntryID AND Culture=@Culture
GO
/****** Object:  StoredProcedure [dbo].[sp_ListEntryDeleteByID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ListEntryDeleteByID]

@EntryId   INT,
@DeleteChild BIT,
@Culture nvarchar(256),
@IsExist BIT OUTPUT

AS

DECLARE @ListName NVARCHAR(256)
SELECT @ListName=ListName FROM dbo.Lists WHERE EntryID=@EntryID 

DELETE
FROM dbo.Lists
WHERE  [EntryID] = @EntryID AND Culture=@Culture

IF(EXISTS(SELECT * FROM dbo.Lists WHERE ListName=@ListName))SET @IsExist=1

ELSE SET @IsExist=0
 

IF @DeleteChild = 1
BEGIN
 DELETE 
 FROM dbo.Lists
 WHERE [ParentID] = @EntryID AND Culture=@Culture
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LanguageGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LanguageGet]
AS
BEGIN
SELECT LanguageID,CultureCode,CultureName,FallbackCulture  FROM dbo.Languages ORDER BY CultureName ASC ;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LanguageDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LanguageDelete]
 @code  NVARCHAR(200)
AS
    DELETE
     FROM dbo.Languages
     WHERE   CultureCode = @code
GO
/****** Object:  StoredProcedure [dbo].[sp_LanguageAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LanguageAdd]

 @CultureCode      NVARCHAR(50),
 @CultureName            NVARCHAR(200),
 @FallbackCulture        NVARCHAR(50),
 @FallbackCultureCode NVARCHAR(50),
 @CreatedByUserID INT

AS
IF NOT EXISTS(SELECT CultureCode FROM dbo.Languages WHERE CultureCode=@CultureCode)
BEGIN
 INSERT INTO dbo.Languages (
  CultureCode,
  CultureName,
  FallbackCulture,
  FallbackCultureCode,
  [CreatedByUserID],
  [CreatedOnDate],
  [LastModifiedByUserID],
  [LastModifiedOnDate]
 )
 VALUES (
  @CultureCode,
  @CultureName,
  @FallbackCulture,
  @FallbackCultureCode,
  @CreatedByUserID,
    GETDATE(),
    @CreatedByUserID,
    GETDATE()
 )
 SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateSettings]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertUpdateSettings]
 @SettingTypes NVARCHAR(4000),
 @SettingKeys NVARCHAR(4000),
 @SettingValues NVARCHAR(4000),
 @UserName NVARCHAR(256),
 @PortalID INT
WITH EXECUTE AS CALLER
AS
BEGIN
  DECLARE @TypeCount INT,@KeyCount INT, @ValueCount INT,@Counter INT
  DECLARE @TblSettingType TABLE ( RowNum INT IDENTITY(1,1),SettingType NVARCHAR(100))
  DECLARE @TblSettingKey TABLE( RowNum INT IDENTITY(1,1), SettingKey NVARCHAR(256))
  DECLARE @TblSettingValue TABLE(  RowNum INT IDENTITY(1,1),SettingValue NVARCHAR(256))
  
  INSERT INTO @TblSettingType(SettingType)
  SELECT RTRIM(LTRIM(items)) FROM split(@SettingTypes,',')
  
  INSERT INTO @TblSettingKey(SettingKey)
  SELECT RTRIM(LTRIM(items)) FROM split(@SettingKeys,',')
  
  INSERT INTO @TblSettingValue(SettingValue)
  SELECT RTRIM(LTRIM(items)) FROM split(@SettingValues,',')
  
  
  SELECT @TypeCount = COUNT(RowNum) FROM @TblSettingType
  SELECT @KeyCount = COUNT(RowNum) FROM @TblSettingKey
  SELECT @ValueCount = COUNT(RowNum) FROM @TblSettingValue
  
  IF(@TypeCount<>@KeyCount OR @KeyCount<>@ValueCount)
   BEGIN
    RAISERROR ('Invalid number of key,value or keytype', 16, 1);  
   END
  ELSE
  BEGIN
   SET @Counter=1
   WHILE(@Counter<=@KeyCount OR @Counter=1)
   BEGIN
    DECLARE @key NVARCHAR(256),@value NVARCHAR(256),@type NVARCHAR(100)
    
    SELECT @type=SettingType FROM @TblSettingType WHERE RowNum=@Counter
    SELECT @Key=SettingKey FROM @TblSettingKey WHERE RowNum=@Counter
    SELECT @value=SettingValue FROM @TblSettingValue WHERE RowNum=@Counter
    
    IF(EXISTS(SELECT 1 FROM [dbo].[SettingValue] WHERE [dbo].[SettingValue].SettingType=@type AND [dbo].[SettingValue].SettingKey=@key AND [dbo].[SettingValue].SettingTypeID=@PortalID))
    BEGIN
     UPDATE [dbo].[SettingValue] SET [SettingValue]=@value, IsModified=1, UpdatedOn=GETDATE(),UpdatedBy=@UserName 
     WHERE [dbo].[SettingValue].SettingType=@type 
       AND [dbo].[SettingValue].SettingKey=@key 
       AND [dbo].[SettingValue].SettingTypeID=@PortalID
    END
    ELSE
     BEGIN
      INSERT INTO [dbo].[SettingValue]([SettingType]
              ,[SettingTypeID]
              ,[SettingKey]
              ,[SettingValue]
              ,[IsActive]
              ,[AddedOn]
              ,[PortalID]
              ,[AddedBy])
        VALUES(@type,@PortalID,@key,@value,1,GETDATE(),@PortalID,@UserName)
     END
    
    SET @Counter=@Counter+1
  END
 END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUpdateSetting]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: 
--CREATED DATE: 2010-04-04
CREATE PROCEDURE [dbo].[sp_InsertUpdateSetting]
 @SettingType NVARCHAR(500),
 @SettingKey NVARCHAR(500),
 @SettingValue NVARCHAR(500),
 @UserName NVARCHAR(256),
 @PortalID INT
WITH EXECUTE AS CALLER
AS
BEGIN
 IF(EXISTS(SELECT * FROM [dbo].[SettingValue] WHERE [dbo].[SettingValue].SettingType=@SettingType AND [dbo].[SettingValue].SettingKey=@SettingKey AND [dbo].[SettingValue].SettingTypeID=@PortalID))
 BEGIN
  UPDATE [dbo].[SettingValue] SET [SettingValue]=@SettingValue, IsModified=1, UpdatedOn=GETDATE(),UpdatedBy=@UserName 
  WHERE [dbo].[SettingValue].SettingType=@SettingType 
  AND [dbo].[SettingValue].SettingKey=@SettingKey 
  AND [dbo].[SettingValue].SettingTypeID=@PortalID
 END
 ELSE
 BEGIN
  INSERT INTO [dbo].[SettingValue]([SettingType]
          ,[SettingTypeID]
          ,[SettingKey]
          ,[SettingValue]
          ,[IsActive]
          ,[AddedOn]
          ,[PortalID]
          ,[AddedBy])
    VALUES(@SettingType,@PortalID,@SettingKey,@SettingValue,1,GETDATE(),@PortalID,@UserName)
 END 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ImagesGetbyPageID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Indira Sapkota>
-- Create date: <16 May 2010>
-- Description: <DashBoardModule>
-- =============================================
Create PROCEDURE [dbo].[sp_ImagesGetbyPageID] 
  @PageID int
 
AS

SELECT

 [IconFile]
 
FROM dbo.Pages
WHERE
 [PageID] = @PageID
GO
/****** Object:  StoredProcedure [dbo].[sp_LogType]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: 2010-04-12
-- Description: HLog Viewer module
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_LogType]
AS
SELECT * FROM dbo.LogType
GO
/****** Object:  Table [dbo].[Log]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[LogTypeID] [int] NOT NULL,
	[Severity] [int] NOT NULL,
	[Message] [nvarchar](1000) NOT NULL,
	[Exception] [nvarchar](4000) NOT NULL,
	[ClientIPAddress] [nvarchar](100) NOT NULL,
	[PageURL] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSettings]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllSettings] @PortalID    INT,  
                                          @SettingType NVARCHAR(100)  
AS  
    IF( @SettingType = 'SuperUser' )  
      BEGIN  
          SELECT [dbo].[settingvalue].settingtype,  
                 LOWER(Ltrim(Rtrim(dbo.portal.seoname))) + '.'  
                 + [dbo].[settingkey].settingkey  
                 AS [SettingKey],  
                 COALESCE([dbo].[settingvalue].settingvalue,  
                 [dbo].[settingkey].settingvalue) AS  
                 [SettingValue]  
          FROM   [dbo].[settingvalue]  
                 INNER JOIN [dbo].[settingkey]  
                         ON [dbo].[settingvalue].settingkey =  
                            [dbo].[settingkey].settingkey  
                            AND [dbo].[settingvalue].settingtype =  
                                [dbo].[settingkey].settingtype,  
                 dbo.portal  
          WHERE  ( [dbo].[settingvalue].settingtype = 'SuperUser' )  
      END  
    ELSE IF ( @SettingType = 'SiteAdmin' )  
    BEGIN  
     SELECT [dbo].[settingvalue].settingtype,  
      LOWER(Ltrim(Rtrim(dbo.portal.seoname))) + '.'  
      + [dbo].[settingkey].settingkey  
      AS [SettingKey],  
      COALESCE([dbo].[settingvalue].settingvalue,  
      [dbo].[settingkey].settingvalue) AS  
      [SettingValue]  
     FROM   [dbo].[settingvalue]  
      INNER JOIN [dbo].[settingkey]  
        ON [dbo].[settingvalue].settingkey =  
        [dbo].[settingkey].settingkey  
        AND [dbo].[settingvalue].settingtype =  
         [dbo].[settingkey].settingtype  
      INNER JOIN dbo.portal  
        ON dbo.portal.portalid =  
        [dbo].[settingvalue].settingtypeid  
     WHERE  ( [dbo].[settingvalue].settingtype = 'SiteAdmin' )  
    END  
    ELSE  
      BEGIN  
          SELECT settingtype, LOWER(Ltrim(Rtrim(dbo.portal.seoname))) + '.'   + settingkey AS [SettingKey],      settingvalue  
       
          FROM   (SELECT [dbo].[settingvalue].settingtype,  
                         [dbo].[settingkey].settingkey,  
                         COALESCE([dbo].[settingvalue].settingvalue,  
                         [dbo].[settingkey].settingvalue) AS  
                         [SettingValue]  
                  FROM   [dbo].[settingvalue]  
                         INNER JOIN [dbo].[settingkey]  
                                 ON [dbo].[settingvalue].settingkey =  
                                    [dbo].[settingkey].settingkey  
                                    AND [dbo].[settingvalue].settingtype =  
                                        [dbo].[settingkey].settingtype  
                  WHERE  ( [dbo].[settingvalue].settingtype = 'SuperUser' )) x  
                 CROSS JOIN dbo.portal  
              
          UNION ALL                 
       
          SELECT [dbo].[settingvalue].settingtype,  
                 LOWER(Ltrim(Rtrim(dbo.portal.seoname))) + '.'  
                 + [dbo].[settingkey].settingkey  
                 AS [SettingKey],  
                 COALESCE([dbo].[settingvalue].settingvalue,  
                 [dbo].[settingkey].settingvalue) AS  
                 [SettingValue]  
          FROM   [dbo].[settingvalue]  
                 INNER JOIN [dbo].[settingkey]  
                         ON [dbo].[settingvalue].settingkey =  
                            [dbo].[settingkey].settingkey  
                            AND [dbo].[settingvalue].settingtype =  
                                [dbo].[settingkey].settingtype  
                 INNER JOIN dbo.portal  
                         ON dbo.portal.portalid =  
                            [dbo].[settingvalue].settingtypeid  
          WHERE  ( [dbo].[settingvalue].settingtype = 'SiteAdmin' )  
  

      END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPortals]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllPortals]
AS
    SELECT *
    FROM   dbo.portal
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListForUniqueness]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetListForUniqueness] 
 -- Add the parameters for the stored procedure here
 @ListName Nvarchar(500),
 @Culture NVARCHAR(256),
 @ParentId int
AS
BEGIN
SELECT * FROM dbo.Lists WHERE ListName=@ListName AND Culture=@Culture AND ParentID = @ParentId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PagePublish]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Sushil Sapkota
-- Create date: 22/09/2013
-- Description: Publishing the page
-- =============================================
CREATE PROCEDURE [dbo].[usp_PagePublish] @PageId INT
 ,@IsPublished BIT
AS
BEGIN
 SET NOCOUNT ON;

 UPDATE Pages
 SET IsVisible = @IsPublished
 WHERE PageID = @PageId
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PagePortalGetByCustomPrefix]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-07-29
CREATE PROCEDURE [dbo].[usp_PagePortalGetByCustomPrefix] 
 @prefix NVARCHAR(10),
 @IsActive BIT,
 @IsDeleted BIT,
 @PortalID INT,
 @UserName NVARCHAR(256),
 @IsVisible BIT,
 @IsRequiredPage BIT
WITH EXECUTE AS CALLER
AS
BEGIN
SELECT * FROM Pages WHERE (PortalID=@PortalID OR PortalID=-1) AND IsDeleted=0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleWebInfoGetAll]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleWebInfoGetAll] 
AS
BEGIN
 SELECT 
  *,
  ROW_NUMBER() OVER
      (
       ORDER BY AddedOn DESC
      ) AS rowNum
 FROM 
  (
   SELECT 
     * 
   FROM 
    [dbo].[ModuleWebInfo]
  ) DataTable
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleWebInfoDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleWebInfoDelete] 
AS
BEGIN
 DELETE FROM 
  [dbo].[ModuleWebInfo]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerSaveBannerSetting]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[usp_SageBannerSaveBannerSetting]'BannerToUse','4','superuser','superuser',47,1,'ne-NP'
CREATE PROCEDURE [dbo].[usp_SageBannerSaveBannerSetting]
(
 @SettingKey NVARCHAR(256),
    @SettingValue NVARCHAR(256),
    @Updatedby NVARCHAR(256),
    @AddedBy NVARCHAR(256),
    @usermoduleid INT,
    @PortalID INT,
    @CultureCode NVARCHAR(100)
 )
WITH EXECUTE AS CALLER
AS
DECLARE @IsActive AS BIT
SET @IsActive='true'
BEGIN
 IF(EXISTS(SELECT * FROM dbo.SageBannerSettingValue WHERE  
  [UserModuleID] = @usermoduleid
  AND [SettingKey] = @SettingKey
  AND PortalID = @PortalID
  AND CultureCode=@CultureCode
  ))
 BEGIN
 print 'update'
  UPDATE dbo.SageBannerSettingValue SET 
   [SettingValue] = @SettingValue,
   [IsActive] = @IsActive,
   [IsModified] = 1,
   [UpdatedOn] = GETDATE(),
   [PortalID] = @PortalID,
   [UpdatedBy] = @Updatedby
  WHERE  
   [UserModuleID] = @usermoduleid
   AND [SettingKey] = @SettingKey
   AND PortalID = @PortalID
   AND CultureCode=@CultureCode
   
 END
 ELSE
 BEGIN
 print 'insert'
   INSERT INTO dbo.SageBannerSettingValue 
   ( 
   [UserModuleID],
   [SettingKey],
   [SettingValue],
   [IsActive],
   [AddedOn],
   [PortalID],
   [AddedBy],
   [CultureCode]
   ) 
  VALUES 
   (
   @usermoduleid,
   @SettingKey,
   @SettingValue,
   @IsActive,
   GETDATE(),
   @PortalID,
   @AddedBy,
   @CultureCode
  )
 END;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerSaveBannerInformation]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerSaveBannerInformation]
(
 @BannerName NVARCHAR(256),
 @BannerDescription NVARCHAR(MAX),
 @UserModuleID INT,
 @PortalID INT,
 @CultureCode NVARCHAR(100)
)
AS
BEGIN
 INSERT INTO SageBanner
 (
  BannerName,
  BannerDescription,
  UserModuleID,
  PortalID,
  CultureCode
 )
 VALUES
 (
  @BannerName,
  @BannerDescription,
  @UserModuleID,
  @PortalID,
  @CultureCode
 )
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerSaveBannerContent]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerSaveBannerContent]
( 
 @Caption NVARCHAR(256),
 @ImagePath NVARCHAR(256),
 @LinkToImage NVARCHAR(256),
 @UserModuleID INT,
 @BannerID INT,
 @ImageID INT,
 @NavigationImage NVARCHAR(256),
 @ReadButtonText NVARCHAR(256),
 @Description NVARCHAR(MAX),
 @ReadMorePage NVARCHAR(256),
 @PortalID INT,
 @CultureCode NVARCHAR(100)
)
AS
DECLARE @DisplayOrder INT
 SET @DisplayOrder = ISNULL((SELECT MAX([DisplayOrder]) FROM dbo.BannerImage WHERE BannerID = @BannerID ), 0) + 1
IF @ImageID=0
 BEGIN
  INSERT INTO BannerImage
  (
  Caption,
  ImagePath,
  LinkToImage,
  UserModuleID,
  BannerID,
  NavigationImage,
  ReadButtonText,
  Description,
  ReadMorePage,
  PortalID,
  DisplayOrder,
  CultureCode
  )
  VALUES
  (
  @Caption ,
  @ImagePath,
  @LinkToImage,
  @UserModuleID,
  @BannerID,
  @NavigationImage,
  @ReadButtonText,
  @Description,
  @ReadMorePage,
  @PortalID,
  @DisplayOrder,
  @CultureCode
  )  
 END
ELSE
 BEGIN
  UPDATE BannerImage SET 
  Caption=@Caption,
  ImagePath=@ImagePath,
  LinkToImage=@LinkToImage,
  UserModuleID=@UserModuleID,
  BannerID=@BannerID,
  NavigationImage=@NavigationImage,
  ReadButtonText=@ReadButtonText,
  Description=@Description,
  ReadMorePage=@ReadMorePage,
  PortalID=@PortalID,
  CultureCode=@CultureCode
  WHERE ImageID=@ImageID
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerLoadBannerListOnGrid]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerLoadBannerListOnGrid]
(
 @PortalID INT,
    @UserModuleID INT,
    @CultureCode NVARCHAR(100)
)
AS
BEGIN
 SELECT BannerID,BannerName,BannerDescription FROM SageBanner 
 WHERE PortalID=@PortalID 
 AND UserModuleID=@UserModuleID 
 AND CultureCode=@CultureCode
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerLoadBannerImagesOnGrid]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerLoadBannerImagesOnGrid]
( 
 @BannerID INT,
 @UserModuleID INT,
 @PortalID INT,
 @CultureCode NVARCHAR(100)
) 
AS
BEGIN
 SELECT [ImageID],[ImagePath],[Caption],DisplayOrder
 FROM BannerImage 
 WHERE BannerID=@BannerID 
 AND  UserModuleID=@UserModuleID 
 AND PortalID=@PortalID  
 AND CultureCode=@CultureCode
 AND DATALENGTH(ImagePath)>0 ORDER BY DisplayOrder
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageBannerLoadBannerHTMLContentOnGrid]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageBannerLoadBannerHTMLContentOnGrid] 
(
 @BannerID INT,
 @UserModuleID INT,
 @PortalID INT,
 @CultureCode NVARCHAR(100)
)
AS
BEGIN
 SELECT [ImageID],[HTMLBodyText] 
 FROM BannerImage 
 WHERE DATALENGTH(HTMLBodyText)>0 
 AND BannerID=@BannerID
 AND UserModuleID=@UserModuleID
 AND PortalID=@PortalID
 AND CultureCode=@CultureCode
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PortalGetParentURL]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_PortalGetParentURL] @PortalID INT
AS
  BEGIN
      DECLARE @IsParent BIT =(SELECT isparent
        FROM   Portal
        WHERE  PortalID = @PortalID)

      IF ( @IsParent = 1 )
        BEGIN
            SELECT seoname
            FROM   Portal
            WHERE  PortalID = @PortalID
        END
      ELSE
        BEGIN
            SELECT SEOName
            FROM   Portal
            WHERE  PortalID = (SELECT ParentID
                               FROM   Portal
                               WHERE  PortalID = @PortalID)
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_PortalGetParent]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PortalGetParent]
AS
BEGIN
 
 SET NOCOUNT ON;
 SELECT PortalID,SEOName From [dbo].[Portal]
 WHERE parentID=0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PageMgr_UpdSettingKeyValue]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageMgr_UpdSettingKeyValue] 
@Page NVARCHAR(200),
@PortalID INT
AS
BEGIN
 --UPDATE dbo.SettingKey SET SettingValue=@Page WHERE SettingKey='PortalDefaultPage' 
 UPDATE dbo.SettingValue SET SettingValue=@Page WHERE SettingKey='PortalDefaultPage' and SettingTypeID = @PortalID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_PageMenuUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageMenuUpdate]
@PageID INT,
@PortalID INT,
@IsAdmin BIT,
@IsFooter BIT
AS
BEGIN
SET NOCOUNT ON;
 UPDATE [dbo].[PageMenu]
 SET IsAdmin=@IsAdmin,IsFooter=@IsFooter
 WHERE
 PageID=@PageID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PageMenuDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageMenuDelete]
@PageID INT,
@DeletedBy nvarchar(256)
AS
BEGIN
SET NOCOUNT ON;
 IF(EXISTS(SELECT PageID FROM [dbo].[PageMenu] WHERE PageID=@PageID))
 BEGIN
  
   
  INSERT INTO [PageMenu_History]
  SELECT  Getdate(),'D', @DeletedBy,* FROM [PageMenu]  WHERE PageID=@PageID;
  
  DELETE FROM [dbo].[PageMenu]
  WHERE PageID=@PageID
 



 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PageMenuAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageMenuAdd]
 @PageID INT,
 @PortalID INT,
 @IsAdmin BIT,
 @IsFooter BIT
AS
BEGIN
SET NOCOUNT ON;
 IF(NOT EXISTS
   (
    SELECT 
     PageID 
    FROM 
     [dbo].[PageMenu] 
    WHERE 
     PageID=@PageID
   )
  )
  BEGIN
   INSERT INTO 
    [dbo].[PageMenu]
       (
        [PageID],
        [PortalID],
        [IsAdmin],
        [IsFooter]
       )
      VALUES
       (
        @PageID,
        @PortalID,
        @IsAdmin,
        @IsFooter
       )
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PageManagerMenuPageUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageManagerMenuPageUpdate]
(
 @MenuIDs NVARCHAR(250),
 @PageID INT
)
AS
BEGIN
SET NOCOUNT ON;
 DELETE FROM 
  MenuItem
 WHERE 
   PageID=@PageID
  AND MenuID IN
      (
       SELECT 
        RTRIM(LTRIM(items)) 
       FROM 
        Split(@MenuIDs, ',')
      )
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PageManagerAddPageToMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageManagerAddPageToMenu] 
(
@Mode VARCHAR(5), 
@MenuID INT, 
@MenuIDs NVARCHAR(50), 
@PageID NVARCHAR(50), 
@ParentID INT, 
@caption NVARCHAR(250),
@UpdateLabel VARCHAR(5) 
) 
AS 
  BEGIN 
 DECLARE @PageName NVARCHAR(250) 
 DECLARE @PortalID INT
 SET @PortalID= (
      SELECT 
       ISNULL(MAX(PortalID),0) 
      FROM 
       Menu 
      WHERE 
       MenuID=@MenuID
     )
      
      SELECT 
  @PageName = SEOName 
      FROM 
  Pages 
      WHERE 
  PageID = @PageID  
      
      DECLARE @NewParentID INT,@NewOrder INT,@MenuLevel INT 

   IF EXISTS (
     SELECT 
      MenuItemID 
     FROM 
      MenuItem 
     WHERE  
       pageid = @ParentID 
      AND menuid = @MenuID 
      AND linktype = 0 
    )
    BEGIN
     SELECT 
    @NewParentID = MenuItemID,
    @MenuLevel = MenuLevel 
     FROM  
    MenuItem 
     WHERE  
     PageID = @ParentID 
    AND menuid = @MenuID 
    AND linktype = 0 
    END
   ELSE
    BEGIN
   SET @NewParentID=0
   SET @MenuLevel=0
    END
    
  SELECT 
   @NewOrder = MAX(menuorder) 
  FROM 
   MenuItem 
  WHERE
    ParentID = @ParentID 
   AND MenuID = @MenuID 
   AND LinkType = 0 

      SET @NewOrder=ISNULL(@NewOrder, 0) + 1

   IF @ParentID <> 0 
  BEGIN 
   SET @MenuLevel=ISNULL(@MenuLevel, 0) + 1 
  END 
   ELSE 
  BEGIN 
   SET @MenuLevel=ISNULL(@MenuLevel, 0) 
  END 
      SET @NewParentID=ISNULL(@NewParentID, 0)
      IF @Mode = 'A' 
        BEGIN 
            INSERT INTO [dbo].[MenuItem] 
         (
            MenuID, 
            LinkType, 
            PageID, 
            Title, 
            LinkURL, 
            ImageIcon, 
            Caption, 
            HtmlContent, 
            ParentID, 
            MenuLevel, 
            MenuOrder, 
            AddedOn, 
            IsActive, 
            IsVisible,
            PortalID
          ) 
        VALUES      
         ( 
           @MenuID, 
           0, 
           @PageID, 
           @PageName, 
           '', 
           '', 
           @caption, 
           '', 
           ISNULL(@NewParentID, 0) , 
           @MenuLevel, 
           @NewOrder, 
           GETDATE(), 
           1, 
           1,
           @PortalID 
         ) 
        END 
      ELSE 
        IF @Mode = 'E' 
          BEGIN
   IF @UpdateLabel='NA'
    BEGIN
     SET @MenuLevel = 0
    END 
     IF @MenuIDs<>'0'
      BEGIN 
       DELETE FROM 
      [dbo].[MenuItem] 
       WHERE  
       pageid = @PageID
      AND menuid NOT IN
           (
            SELECT 
             RTRIM(LTRIM(items)) 
            FROM   
             Split(@MenuIDs, ',')
           )
      END
     ELSE IF @MenuIDs='0'
    BEGIN
         DELETE FROM 
      [dbo].[MenuItem] 
      WHERE  
      pageid = @PageID 
    END

              DECLARE @TblTemp TABLE
      ( 
       num    INT IDENTITY(1, 1), 
       menuid INT
      ) 
              DECLARE @RowTotal INT 

              INSERT INTO @TblTemp 
              SELECT 
    RTRIM(LTRIM(items)) 
              FROM   
    dbo.Split(@MenuIDs, ',') 

              SELECT 
    @RowTotal = COUNT(*) 
              FROM   
    @TblTemp 

              WHILE( @RowTotal > 0 ) 
                BEGIN 
                    DECLARE @MenuID1 INT 

                    SELECT 
      @MenuID1 = menuid 
                    FROM  
      @TblTemp 
                    WHERE  
      num = @RowTotal       
     set @NewParentID = (SELECT MenuItemID FROM   menuitem WHERE  pageid = @ParentID AND menuid = @MenuID1)      
                    IF( 
      EXISTS(
        SELECT 
         * 
        FROM   
         menuitem 
                               WHERE  
         pageid = @pageid 
                                AND menuid = @MenuID1) ) 
                      BEGIN 
                        UPDATE                                                 
       [dbo].[MenuItem] 
      SET    
        linktype = 0, 
        title = @PageName, 
        linkurl = '', 
        imageicon = '', 
        caption = @caption, 
        htmlcontent = '', 
        parentid = ISNULL(@NewParentID,0), 
        menulevel = @MenuLevel, 
        addedon = GETDATE(), 
        isactive = 1, 
        isvisible = 1 
                         WHERE  
        menuid = @MenuID1 
       AND pageid = @PageID 
                      END 
                    ELSE 
                      BEGIN 
                          INSERT INTO [dbo].[MenuItem] 
          (
           menuid, 
           linktype, 
           pageid, 
           title, 
           linkurl, 
           imageicon, 
           caption, 
           htmlcontent, 
           parentid, 
           menulevel, 
           menuorder, 
           addedon, 
           isactive, 
           isvisible,
           PortalID
          ) 
         VALUES      
          ( 
           @MenuID1, 
           0, 
           @PageID, 
           @PageName, 
           '', 
           '', 
           @caption, 
           '', 
           ISNULL(@NewParentID,0), 
           @MenuLevel, 
           @NewOrder, 
           GETDATE(), 
           1, 
           1,
           @PortalID 
          ) 
                      END 

                    SET @RowTotal=@RowTotal - 1 
                END 
          END 
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_PageGettingBySEOName]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageGettingBySEOName]
@PortalID INT,
@SEOName NVARCHAR(256)
AS

BEGIN
 SELECT 
  PageName,
  IconFile 
 FROM 
  [dbo].[Pages] 
 WHERE  
   PortalID=@PortalID  
  AND SEOName=@SEOName 
  AND 
   (
     IsDeleted = 0 
     OR IsDeleted IS NULL
   ) 
  AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_OnlineUserCountGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_OnlineUserCountGet]
AS
BEGIN
 DECLARE @TblTemp TABLE ( 
  [Users] NVARCHAR(256), 
  Cnt INT 
    ) 
 INSERT INTO @TblTemp 
  SELECT 
   'AnonymousUser',
   COUNT(*)
  FROM 
   SessionTracker 
  WHERE 
    Username = 'anonymoususer' 
   AND [End] IS NULL 
  UNION ALL 
  SELECT 
    'LoginUser', 
     COUNT(*) 
  FROM 
   SessionTracker 
  WHERE  
    Username NOT IN ( 'anonymoususer' ) 
   AND [End] IS NULL
  SELECT 
   * 
  FROM 
   (
    SELECT 
     Cnt,
     [Users] 
    FROM @TblTemp
   )p 
   PIVOT 
    ( 
     MAX(Cnt) 
     FOR [Users] IN 
         (
          [AnonymousUser],
          [LoginUser]) 
         ) 
     AS PivotTable 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NLGetSetting]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NLGetSetting]
@UserModuleID INT,
@PortalID INT
AS
SELECT *
FROM   (SELECT nk.SettingKey,
               Coalesce(nv.SettingValue, nk.SettingValue) AS settingvalue
        FROM  NL_SettingValue nv
              RIGHT JOIN NL_SettingKey nk
                 ON nv.SettingKey = nk.SettingKey AND nv.PortalID=@PortalID AND nv.UserModuleID=@UserModuleID )p PIVOT ( MAX(settingvalue)
       FOR
       settingkey  IN([ModuleHeader],[ModuleDescription],[UnSubscribePageName],[IsMobileSubscription])) AS pivottable
       
--       SELECT *
--FROM   (SELECT ak.settingkey,
--               Coalesce(av.settingvalue, ak.settingvalue) AS settingvalue
--        FROM   AdvertisementSettingvalue av
--              RIGHT JOIN AdvertisementSettingkey ak
--                 ON av.settingkey = ak.settingkey AND av.PortalID=@PortalID AND av.UserModuleID=@UserModuleID )p PIVOT ( MAX(settingvalue)
--       FOR
--       settingkey  IN([AdsHeight],[AdsWidth],[AdsType],[ViewType],[NumberOfAds],[IsDimension],[ListType],[AdsNextLineAfter])) AS pivottable
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_UpdateNewsLetter]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_UpdateNewsLetter]
@NewsLetterID INT
AS
BEGIN
 UPDATE DBO.NL_NewsLetter SET IsSubscribed=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_UnSubscribeUserByPhone]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_UnSubscribeUserByPhone]
@Phone bigint
AS
BEGIN
 UPDATE DBO.NL_MobileSubsciber 
 SET IsSubscribed=0 WHERE MobileNumber=@Phone
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_UnSubscribeUserByEmail]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_UnSubscribeUserByEmail]
@Email NVARCHAR(128)
AS
BEGIN
 UPDATE DBO.NL_EmailSubscriber 
 SET IsSubscribed=0 WHERE SubscriberEmail=@Email
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_UnSubscribeByEmailLink]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_UnSubscribeByEmailLink]
@subscriberID INT
AS
BEGIN
 UPDATE DBO.NL_EmailSubscriber 
 SET IsSubscribed=0
 WHERE SubscriberID=@subscriberID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_SaveNLSetting]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_SaveNLSetting]
@SettingKeys NVARCHAR(128),
@SettingValues NVARCHAR(128),
@UserModuleID INT,
@PortalID INT
AS
DECLARE @IsActive AS BIT
SET @IsActive='true'
BEGIN
  DECLARE @tblKey TABLE
  (
  RowNum INT IDENTITY(1,1),
  SettingKey NVARCHAR(500)
  )
  DECLARE @tblValue TABLE
  (
  RowNum INT IDENTITY(1,1),
  SettingValue NVARCHAR(500)
  )
  INSERT INTO @tblKey 
  SELECT RTRIM(LTRIM(items)) FROM split(@SettingKeys,',')
  INSERT into @tblValue 
  SELECT RTRIM(LTRIM(items)) FROM split(@SettingValues,',')
  DECLARE @counter INT,@RowCount INT
  SELECT @RowCount=COUNT(RowNum) FROM @tblKey
  SET @counter=1
  WHILE(@counter<=@RowCount or @counter=1)
   BEGIN 
    DECLARE @key NVARCHAR(500),@value NVARCHAR(500)
  SELECT @key=SettingKey FROM @tblKey WHERE RowNum=@counter
  SELECT @value=SettingValue FROM @tblValue WHERE RowNum=@counter

IF(EXISTS(SELECT * FROM dbo.NL_SettingValue WHERE  
 [UserModuleID] = @UserModuleID
 AND [SettingKey] = @key))
      BEGIN
      UPDATE  dbo.NL_SettingValue SET 
   [SettingValue] = @value,
 [IsActive] = @IsActive,
 [IsModified] = 1,
 [UpdatedOn] = GETDATE()

 
      WHERE  
  [UserModuleID] = @UserModuleID
 AND [SettingKey] = @key
 
     END
  ELSE
  BEGIN
 INSERT INTO dbo.NL_SettingValue ( 
 [UserModuleID],
 [PortalID],
 [SettingKey],
 [SettingValue],
 [IsActive],
 [AddedOn]
 

) VALUES (
 @UserModuleID, 
 @PortalID,
 @key,
 @value,
 @IsActive,
 GETDATE()
 
 
)
END
SET @counter=@counter+1
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_SaveNewsLetter]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_SaveNewsLetter]
@Subject nvarchar(128),
@BodyMsg nvarchar(max),
@UserModuleID int,
@PortalID int
AS
BEGIN
 INSERT INTO DBO.NL_NewsLetter 
 ([Subject],Body,UserModuleID,PortalID,IsSubscribed,AddedOn)
 VALUES(@Subject,@BodyMsg,@UserModuleID,@PortalID,0,GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_SaveMobileSubscriber]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_SaveMobileSubscriber]
@SubscriberPhone bigint,
@UserModuleID INT,
@PortalID INT,
@UserName NVARCHAR(128),
@ClientIP NVARCHAR(128)
AS
BEGIN
INSERT INTO DBO.NL_MobileSubsciber 
(
MobileNumber,
IsSubscribed,
UserModuleID,
PortalID,
AddedOn,
AddedBy,
ClientIP

)
VALUES
(
@SubscriberPhone,
1,
@UserModuleID,
@PortalID,
GETDATE(),
@UserName,
@ClientIP
)
 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_SaveEmailSubscriber]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_SaveEmailSubscriber]
@SubscriberEmail NVARCHAR(128),
@UserModuleID INT,
@PortalID INT,
@UserName NVARCHAR(128),
@ClientIP NVARCHAR(128)
AS
BEGIN
IF EXISTS (
        SELECT * FROM NL_EmailSubscriber WHERE SubscriberEmail = @SubscriberEmail
)
BEGIN
       UPDATE DBO.NL_EmailSubscriber 
       SET IsSubscribed=1 WHERE SubscriberEmail=@SubscriberEmail
END
ELSE
BEGIN
   INSERT INTO DBO.NL_EmailSubscriber 
(
SubscriberEmail,
IsSubscribed,
UserModuleID,
PortalID,
AddedOn,
AddedBy,
ClientIP

)
VALUES
(
@SubscriberEmail,
1,
@UserModuleID,
@PortalID,
GETDATE(),
@UserName,
@ClientIP
)     
END


 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetSubscriberList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_NL_GetSubscriberList]
@Offset INT
AS
BEGIN
DECLARE @lower INT
DECLARE @upper INT
DECLARE @SubscribeNo INT
DECLARE @active TABLE
(
RowNo INT IDENTITY(1,1),
SubscriberId INT
)
SET NOCOUNT ON;
INSERT INTO @active
SELECT SubscriberID FROM NL_EmailSubscriber WHERE IsSubscribed=1 
SET @SubscribeNo=(SELECT MAX(RowNo) FROM @active  )
SET @upper=@SubscribeNo-(@Offset*5)
IF(@upper >5)
SET @lower=@upper-4
ELSE
SET @lower=0
SELECT DISTINCT SubscriberID,(SELECT COUNT(*) FROM DBO.NL_EmailSubscriber WHERE IsSubscribed=1) AS EmailCount,SubscriberEmail FROM DBO.NL_EmailSubscriber WHERE 
IsSubscribed=1 AND SubscriberID  in(SELECT SubscriberId FROM  @active WHERE RowNo between @Lower and  @upper  )  ORDER BY SubscriberID DESC

END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetSubscriberEmailList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_GetSubscriberEmailList] 
 @PortalID INT
AS
BEGIN
 SELECT *FROM DBO.NL_EmailSubscriber WHERE IsSubscribed=1 AND PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetNLSettingForUnSubscribe]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_GetNLSettingForUnSubscribe]

AS
SELECT *
FROM   (SELECT nk.SettingKey,
               Coalesce(nv.SettingValue, nk.SettingValue) AS settingvalue
        FROM  NL_SettingValue nv
              RIGHT JOIN NL_SettingKey nk
                 ON nv.SettingKey = nk.SettingKey )p PIVOT ( MAX(settingvalue)
       FOR
       settingkey  IN([ModuleHeader],[ModuleDescription],[UnSubscribePageName],[IsMobileSubscription])) AS pivottable
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetNewsLetter]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_GetNewsLetter]
@PortalID int
AS
BEGIN
 SELECT * FROM DBO.NL_NewsLetter WHERE PortalID=@PortalID and IsSubscribed=0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetMessageTemplateList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: DINESH HONA
--CREATED DATE: 2010-04-09
--Modified DATE: 2010-04-25
CREATE PROCEDURE [dbo].[usp_NL_GetMessageTemplateList]
    @Current INT,
    @Pagesize INT,
 @IsActive [bit],
 @IsDeleted [bit],
 @PortalID [int],
 @UserName NVARCHAR(256),
 @CurrentCulture NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
DECLARE @RowTotal INT
SELECT @RowTotal=COUNT(*)
FROM dbo.MessageTemplate WHERE (IsDeleted=0 OR IsDeleted IS NULL)  AND PortalID=@PortalID AND IsActive=@IsActive;
 WITH MessageTemplateList AS
 (SELECT @RowTotal as MessageTokenID,*,ROW_NUMBER() OVER(ORDER BY (MessageTemplateID)) AS RowNumber
 FROM
 ( 
SELECT
 [MessageTemplateID],
 [MessageTemplateTypeID],
 [Subject],
 [Body],
 [MailFrom],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[MessageTemplate]
WHERE (IsDeleted=0 OR IsDeleted IS NULL) AND PortalID=@PortalID AND IsActive=@IsActive

 )DataTable
  )

  SELECT * FROM MessageTemplateList WHERE RowNumber>=(@Current-1)*@PageSize+1
       AND RowNumber<=(@pageSize*@Current)
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetMessageTemplateByTypeID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_GetMessageTemplateByTypeID]--1,'EN-US',1
@MessageTemplateTypeID INT,
@Culture NVARCHAR(50),
@PortalID INT
AS
BEGIN
SELECT MessageTemplateID,[Subject],Body FROM DBO.MessageTemplate
WHERE MessageTemplateTypeID=@MessageTemplateTypeID AND Culture=@Culture and PortalID=@PortalID 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetMessageInfoByID]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_GetMessageInfoByID]
@messageTemplateID INT
AS
BEGIN
 SELECT * FROM DBO.MessageTemplate WHERE MessageTemplateID=@messageTemplateID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NL_GetDataByEmail]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_NL_GetDataByEmail]
@Email NVARCHAR(128)
AS
BEGIN
 SELECT * FROM dbo.NL_EmailSubscriber WHERE SubscriberEmail=@Email AND IsSubscribed=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NewsRssContentUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_NewsRssContentUpdate]
@NewsContent TEXT
AS
BEGIN
 SET NOCOUNT ON;
  BEGIN TRAN
   DELETE FROM 
    dbo.NewsRssContent
   IF(@@ERROR<>0) 
    GOTO ErrorHandler     
   INSERT INTO 
    dbo.NewsRssContent
         (
          NewsContent,
          UpdatedDate
         ) 
        VALUES
         (
          @NewsContent,
          GETDATE()
         )
   IF(@@ERROR<>0) 
    GOTO ErrorHandler
  COMMIT TRAN
  RETURN 0

  ERRORHANDLER:
   ROLLBACK TRAN
  RETURN 1    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_NewsRssContentGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_NewsRssContentGet]

AS
BEGIN
 SET NOCOUNT ON;
  SELECT 
  NewsContent 
 FROM 
  dbo.NewsRssContent    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MsgTempTypeUniquenessCheck]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
--[usp_MsgTempTypeUniquenessCheck] 'account Activation - Email',1,0
CREATE PROCEDURE [dbo].[usp_MsgTempTypeUniquenessCheck]
 @MsgTemplateTypeName nvarchar(256),
 @PortalID int,
 @IsUnique bit output
 
AS
BEGIN
IF(EXISTS(SELECT * FROM [dbo].[MessageTemplateType] WHERE (IsDeleted=0 OR IsDeleted IS NULL) AND 
 PortalID = @PortalID AND Name = @MsgTemplateTypeName ))
  BEGIN
   SET @IsUnique = CAST(0 as bit) 
  END
  ELSE
  BEGIN
   SET @IsUnique = CAST(1 as bit)
  END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuGetAdminView]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuGetAdminView] 
     @prefix [nvarchar](10), 
  @IsDeleted [BIT],
  @PortalID [int],
  @UserName [nvarchar](256),
     @CultureCode NVARCHAR(20)
 
AS
BEGIN
 DECLARE @IsActive BIT,@IsVisible BIT,@IsRequiredPage BIT
 SET @IsActive=NULL
 SET @IsVisible=NULL
 SET @IsRequiredPage=NULL

select *,PageName AS LevelPageName FROM dbo.Pages p INNER JOIN dbo.PageMenu pm ON p.PageID=pm.PageID
WHERE (p.IsDeleted=0 OR p.IsDeleted IS NULL) AND (P.PortalID=@PortalID OR p.PortalID=-1)
AND pm.IsAdmin=1
AND pm.PortalID = @PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PaymentGatewaySetting_Save]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--  [usp_PaymentGatewaySetting_Save]
CREATE PROCEDURE [dbo].[usp_PaymentGatewaySetting_Save]
@SettingValue nvarchar(max),
@PortalID int,
@UserModuleID int,
@UserName nvarchar(256),
@CultureCode nvarchar(100)
AS
BEGIN
IF(EXISTS(select 1 from [PaymentGateWaySetting] where PortalID = @PortalID and  UserModuleID = @UserModuleID))
	BEGIN
		UPDATE [PaymentGateWaySetting]
		SET [SettingValue] = @SettingValue
		where PortalID = @PortalID and
		[UserModuleID] = @UserModuleID	
	END
ELSE
	BEGIN
	INSERT INTO [dbo].[PaymentGateWaySetting]
			   ([UserModuleID]
			   ,[PortalID]
			   ,[Culture]
			   ,[SettingValue]
			   ,[AddedBy]
			   ,[ModifiedOn])
		 VALUES
			   ( @UserModuleID, @PortalID , @CultureCode , @SettingValue , @UserName , GETDATE())
	END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_PaymentGatewaySetting_GetSettingValue]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_PaymentGatewaySetting_GetSettingValue]
--@UserModuleID int,
@PortalID int
AS
select UserModuleID , PortalID , PaymentID , SettingValue ,PaymentID
FROM PaymentGateWaySetting 
where PortalID  = @PortalID 
--and UserModuleID = @UserModuleID
GO
/****** Object:  StoredProcedure [dbo].[usp_PasswordRecoveryDeactivateCode]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PasswordRecoveryDeactivateCode]
(
 @UserName NVARCHAR(256),
 @PortalID INT
)
AS
BEGIN
UPDATE Codes 
 SET IsAlreadyUsed=1
 WHERE CodeForUsername=@UserName
 AND PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SaveSettings]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SaveSettings]
(
@SettingKey NVARCHAR(256),
@SettingValue NVARCHAR(50)
)
AS
BEGIN
SET NOCOUNT ON;
UPDATE MembershipSettings
SET SettingValue=@SettingValue
WHERE SettingKey=@SettingKey
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuUpdateSelectedMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_SageMenuUpdateSelectedMenu]
(
@UserModuleID INT,
@PortalID INT,
@SettingKey NVARCHAR(250),
@SettingValue NVARCHAR(250)
)
AS
BEGIN
IF EXISTS(SELECT * FROM SageMenuSettingValue WHERE UserModuleID=@UserModuleID AND PortalID=@PortalID)
BEGIN
UPDATE SageMenuSettingValue
SET SettingValue=@SettingValue
WHERE UserModuleID=@UserModuleID
AND PortalID=@PortalID
END
ELSE
BEGIN
INSERT INTO SageMenuSettingValue
(
SettingKey,SettingValue,PortalID,UserModuleID
)
VALUES
(
@SettingKey,@SettingValue,@PortalID,@UserModuleID
)
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuSettingGetAll]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuSettingGetAll] 
 @UserModuleID [INT],
 @PortalID [INT]

WITH EXECUTE AS CALLER
AS
BEGIN

DECLARE @MenuID INT

IF EXISTS(SELECT SettingValue FROM SageMenuSettingValue WHERE SettingKey='MenuID' AND UserModuleID=@UserModuleID)
BEGIN
SELECT @MenuID=SettingValue FROM SageMenuSettingValue WHERE SettingKey='MenuID' AND UserModuleID=@UserModuleID
END
ELSE
BEGIN
SELECT @MenuID=MenuID FROM Menu WHERE IsDefault=1
END


SELECT *
FROM (

SELECT [dbo].[MenuMgrSettingKey].[SettingKey] AS SettingKey,@MenuID AS MenuID
      ,COALESCE([dbo].[MenuMgrSettingValue].SettingValue,[dbo].[MenuMgrSettingKey].SettingValue) AS SettingValue
    
 FROM [dbo].[MenuMgrSettingValue]
  RIGHT JOIN [dbo].MenuMgrSettingKey ON [dbo].[MenuMgrSettingValue].SettingKey = [dbo].MenuMgrSettingKey.SettingKey AND 
  [dbo].[MenuMgrSettingValue].MenuID = @MenuID AND [dbo].[MenuMgrSettingValue].PortalID=@PortalID

 )p PIVOT ( MAX(settingvalue)
FOR
settingkey IN([MenuType],[DisplayMode],[TopMenuSubType],[Caption],[SubTitleLevel],[SideMenuType])) AS pivottable
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuSettingAddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuSettingAddUpdate] 
 @UserModuleID [INT],
 @SettingKey [NVARCHAR](256),
 @SettingValue [NVARCHAR](256),
 @IsActive [BIT],
 @PortalID [INT],
 @UpdatedBy [NVARCHAR](256),
 @AddedBy NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN
IF(EXISTS(SELECT * FROM dbo.SageMenuSettingValue WHERE  
 [UserModuleID] = @UserModuleID
 AND [SettingKey] = @SettingKey
 AND PortalID = @PortalID))
BEGIN
UPDATE dbo.SageMenuSettingValue SET 
 [SettingValue] = @SettingValue,
 [IsActive] = @IsActive,
 [IsModified] = 1,
 [UpdatedOn] = GETDATE(),
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE  
 [UserModuleID] = @UserModuleID
 AND [SettingKey] = @SettingKey
 AND PortalID = @PortalID
END
ELSE
BEGIN
 INSERT INTO dbo.SageMenuSettingValue ( 
 [UserModuleID],
 [SettingKey],
 [SettingValue],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @UserModuleID,
 @SettingKey,
 @SettingValue,
 @IsActive,
 GETDATE(),
 @PortalID,
 @AddedBy
)
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuGetClientView]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuGetClientView] 
 
  --   @prefix [nvarchar](10), 
 -- @IsDeleted [bit],
  @PortalID [int]
  --,
 -- @UserName [nvarchar](256),
  --   @CultureCode nVARCHAR(20)
 
AS
BEGIN
 SELECT p.PageID,PageOrder,ParentID,
  [Level],SEOName,TabPath,IsVisible
  ,ShowInMenu,IconFile,
  PageName as LevelPageName,
  ISNULL((SELECT MAX([PageOrder]) FROM [dbo].[Pages]  WHERE [Level]=p.[Level] AND ParentID=p.ParentID AND PortalID=@PortalID )
  ,p.PageOrder) AS [MaxPageOrder]
 FROM dbo.Pages p 
   INNER JOIN dbo.PageMenu pm ON p.PageID=pm.PageID 
 WHERE pm.PortalID=@PortalID AND pm.IsAdmin=0 ORDER BY p.PageID,p.PageOrder
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SchedulerAddJob]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SchedulerAddJob] (@ScheduleName       VARCHAR(200), 
                                      @FullNamespace      VARCHAR(200), 
                                      @StartDate          SMALLDATETIME, 
                                      @EndDate            SMALLDATETIME, 
                                      @StartHour          SMALLINT, 
                                      @StartMin           SMALLINT, 
                                      @RepeatWeeks        SMALLINT, 
                                      @RepeatDays         INT, 
                                      @WeekOfMonth        INT, 
                                      @EveryHour         INT, 
                                      @EveryMin           SMALLINT, 
                                      @ObjectDependencies VARCHAR(300), 
                                      @RetryTimeLapse     INT, 
                                      @RetryFrequencyUnit VARCHAR(10), 
                                      @AttachToEvent      VARCHAR(50), 
                                      @CatchUpEnabled     BIT, 
                                      @Servers            VARCHAR(250),                                     
                                      @IsEnable bit,
                                      @ScheduleID int output,
                                      @RunningMode int,
                                      @AssemblyFileName varchar(150)
                                      ) 
AS 
  BEGIN 
      SET NOCOUNT ON; 
      INSERT INTO [dbo].[Schedule] 
                  ([ScheduleName], 
                   [FullNamespace], 
                   [StartDate], 
                   [EndDate], 
                   [StartHour], 
                   [StartMin], 
                   [RepeatWeeks], 
                   [RepeatDays], 
                   [WeekOfMonth], 
                   [EveryHours], 
                   [EveryMin], 
                   [ObjectDependencies], 
                   [RetryTimeLapse], 
                   [RetryFrequencyUnit], 
                   [AttachToEvent], 
                   [CatchUpEnabled], 
                   [Servers], 
                  
                   [IsEnable], 
                   [CreatedOnDate],
                   [RunningMode],
                   [AssemblyFileName]) 
      VALUES      ( @ScheduleName, 
                    @FullNamespace, 
                    @StartDate, 
                    @EndDate, 
                    @StartHour, 
                    @StartMin, 
                    @RepeatWeeks, 
                    @RepeatDays, 
                    @WeekOfMonth, 
                    @EveryHour, 
                    @EveryMin, 
                    @ObjectDependencies, 
                    @RetryTimeLapse, 
                    @RetryFrequencyUnit, 
                    @AttachToEvent, 
                    @CatchUpEnabled, 
                    @Servers,                    
                    @IsEnable, 
                    GETDATE(),
                    @RunningMode,
                     @AssemblyFileName) 
      SET @ScheduleID=@@IDENTITY
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleGet]
@ScheduleID INT
AS
BEGIN
SELECT s.[ScheduleID],s.[ScheduleName],s.[FullNamespace],s.[StartDate],s.[EndDate],s.[StartHour],s.[StartMin],s.[RepeatWeeks]
      ,s.[RepeatDays],s.[WeekOfMonth],s.[EveryHours],s.[EveryMin] ,s.[ObjectDependencies],s.[RetryTimeLapse],s.[RetryFrequencyUnit]
      ,s.[AttachToEvent] ,s.[CatchUpEnabled],s.[Servers],s.[CreatedByUserID],s.[CreatedOnDate],s.[LastModifiedbyUserID],s.[LastModifiedDate]
   ,s.[IsEnable],s.[AssemblyFileName],RunningMode FROM [dbo].[Schedule] s 
WHERE s.ScheduleID=@ScheduleID
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleGetAllCount]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleGetAllCount]
AS
BEGIN
 SELECT COUNT(*) AS RowTotal  FROM [dbo].[Schedule] 
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleUpdate]
(
           @ScheduleName       VARCHAR(200),                                      
                                      @StartDate          SMALLDATETIME, 
                                      @EndDate            SMALLDATETIME, 
                                      @StartHour          SMALLINT, 
                                      @StartMin           SMALLINT, 
                                      @RepeatWeeks        SMALLINT, 
                                      @RepeatDays         INT, 
                                      @WeekOfMonth        INT, 
                                      @EveryHour         INT, 
                                      @EveryMin           SMALLINT, 
                                      @ObjectDependencies VARCHAR(300), 
                                      @RetryTimeLapse     INT, 
                                      @RetryFrequencyUnit VARCHAR(10), 
                                      @AttachToEvent      VARCHAR(50), 
                                      @CatchUpEnabled     BIT, 
                                      @IsEnable BIT,
                                      @Servers            VARCHAR(250),
           @ScheduleID    INT,
                                       @RunningMode INT
)
AS 
BEGIN
SET NOCOUNT ON;
UPDATE [dbo].[Schedule]
   SET [ScheduleName] = @ScheduleName,
      [StartDate] = @StartDate, 
      [EndDate] = @EndDate,
       RunningMode=@RunningMode,
IsEnable=@IsEnable,
      [StartHour] = @StartHour,
      [StartMin] = @StartMin,
      [RepeatWeeks] = @RepeatWeeks,
      [RepeatDays] = @RepeatDays,
      [WeekOfMonth] = @WeekOfMonth,
      [EveryHours] = @EveryHour,
      [EveryMin] = @EveryMin,
      [ObjectDependencies] = @ObjectDependencies,
      [RetryTimeLapse] = @RetryTimeLapse,
      [RetryFrequencyUnit] = @RetryFrequencyUnit,
      [AttachToEvent] = @AttachToEvent,
      [CatchUpEnabled] = @CatchUpEnabled,
      [Servers] = @Servers
     
 WHERE [ScheduleID]=@ScheduleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMembershipSettings]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetMembershipSettings]
AS
BEGIN
SELECT * FROM MembershipSettings
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEventLocationList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Rajkumar Gupta
-- Create date: 11/5/2012
-- Description: To get Event List
-- =============================================
--[dbo].[sp_GetEventTypeList] 
CREATE PROCEDURE [dbo].[usp_GetEventLocationList] 
AS
BEGIN
 SET NOCOUNT ON;  
SELECT EventLocationName FROM dbo.SystemEventLocation WHERE IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetDailyVisit]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetDailyVisit] 
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME
AS
BEGIN
SELECT   DATENAME(YEAR,[start]) +  '-' + CAST(DATEPART(MONTH,[start])
AS NVARCHAR(4))+  '-' + CAST(DATEPART(DAY,[start]) 
         AS VARCHAR(4)) AS VisitedDate,
        COUNT(*) AS [VisitTime]
        FROM    SessionTracker  
        WHERE [start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
        GROUP BY  DATENAME(YEAR,[start]) +  '-' +CAST(DATEPART(MONTH,[start])
AS NVARCHAR(4)) + '-' + CAST(DATEPART(DAY,[start]) AS VARCHAR(4))
ORDER BY [VisitTime]
DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCountry_Report]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetCountry_Report]
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME 
AS
BEGIN
SELECT DISTINCT SessionUserHostAddress, COUNT(*) AS [VisitTime] 
  FROM SessionTracker
  WHERE [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
 GROUP BY SessionUserHostAddress 
ORDER BY [VisitTime] DESC
END


/****** Object:  StoredProcedure [dbo].[usp_GetBrowser_Report]    Script Date: 12/17/2012 16:10:33 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBrowser_Report]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetBrowser_Report]
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME 
AS
BEGIN
SELECT DISTINCT  SessionBrowser AS Browser, COUNT(*) AS [VisitTime] 
FROM SessionTracker WHERE [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
 GROUP BY SessionBrowser
ORDER BY [VisitTime] DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetBlogRssContent]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetBlogRssContent]
AS
BEGIN
 SET NOCOUNT ON;
 SELECT BlogContent FROM dbo.BlogRssContent    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetApplicationInfo]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[usp_GetApplicationInfo]
@ApplicationName nvarchar(256)
AS
BEGIN
SELECT [ApplicationName]
      ,[ApplicationId]
      ,[Description]
  FROM [dbo].[aspnet_Applications] where [LoweredApplicationName] =  @ApplicationName
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllSettings]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAllSettings] @PortalID    INT,
                                          @SettingType NVARCHAR(100)
AS
    IF( @SettingType = 'SuperUser' )
      BEGIN
          SELECT [dbo].[settingkey].settingkey
                 AS [SettingKey],
                 COALESCE([dbo].[settingvalue].settingvalue,
                 [dbo].[settingkey].settingvalue) AS
                 [SettingValue]
          FROM   [dbo].[settingvalue]
                 INNER JOIN [dbo].[settingkey]
                         ON [dbo].[settingvalue].settingkey =
                            [dbo].[settingkey].settingkey
                            AND [dbo].[settingvalue].settingtype =
                                [dbo].[settingkey].settingtype,
                 dbo.portal
          WHERE  ( [dbo].[settingvalue].settingtype = 'SuperUser'  )
      END
    ELSE IF ( @SettingType = 'SiteAdmin' )
      BEGIN
          SELECT [dbo].[settingkey].settingkey
                 AS [SettingKey],
                 COALESCE([dbo].[settingvalue].settingvalue,
                 [dbo].[settingkey].settingvalue) AS
                 [SettingValue]
          FROM   [dbo].[settingvalue]
                 INNER JOIN [dbo].[settingkey]
                         ON [dbo].[settingvalue].settingkey =
                            [dbo].[settingkey].settingkey
                            AND [dbo].[settingvalue].settingtype =
                                [dbo].[settingkey].settingtype
                 INNER JOIN dbo.portal
                         ON dbo.portal.portalid =
                            [dbo].[settingvalue].settingtypeid
          WHERE  ( [dbo].[settingvalue].settingtype = 'SiteAdmin' )
      END
    ELSE
      BEGIN
	  CREATE TABLE  #tmp
	  (
	  [SettingKey] NVARCHAR(MAX),
	  settingvalue NVARCHAR(MAX)
	  )
          --SELECT settingkey AS [SettingKey],
          --       settingvalue
         INSERT INTO   #tmp
             SELECT 
                         [dbo].[settingkey].settingkey,
                         COALESCE([dbo].[settingvalue].settingvalue,
                         [dbo].[settingkey].settingvalue) AS
                         [SettingValue]
                  FROM   [dbo].[settingvalue]
                         INNER JOIN [dbo].[settingkey]
                                 ON [dbo].[settingvalue].settingkey =
                                    [dbo].[settingkey].settingkey
                                    AND [dbo].[settingvalue].settingtype =
                                        [dbo].[settingkey].settingtype
                  WHERE  ( [dbo].[settingvalue].settingtype = 'SuperUser' and 
                  [dbo].[settingvalue].settingtypeid= 1 ) 
                 --CROSS JOIN dbo.portal


          INSERT INTO #tmp
                    
          SELECT [dbo].[settingkey].settingkey
                 AS [SettingKey],
                 COALESCE([dbo].[settingvalue].settingvalue,
                 [dbo].[settingkey].settingvalue) AS
                 [SettingValue]
          FROM   [dbo].[settingvalue]
                 INNER JOIN [dbo].[settingkey]
                         ON [dbo].[settingvalue].settingkey =
                            [dbo].[settingkey].settingkey
                            AND [dbo].[settingvalue].settingtype =
                                [dbo].[settingkey].settingtype
                 INNER JOIN dbo.portal
                         ON dbo.portal.portalid =
                            [dbo].[settingvalue].settingtypeid
          WHERE  ( [dbo].[settingvalue].settingtype = 'SiteAdmin' and [dbo].[settingvalue].settingtypeid=@PortalID )

          SELECT *
          FROM   #tmp
		       
          DROP TABLE #tmp
      END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllSecurePages]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAllSecurePages] 
 @PortalID INT,
 @CultureName NVARCHAR(256)
AS
BEGIN
 SELECT SEOName AS SecurePageName, IsSecure FROM dbo.Pages
        WHERE  PortalID = @PortalID AND (IsDeleted =0 OR IsDeleted IS NULL)
 AND IsActive =1 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAdminPages]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAdminPages]
 @prefix NVARCHAR(10), 
  @IsDeleted BIT,
  @PortalID INT,
  @UserName NVARCHAR(256),
     @CultureCode NVARCHAR(20)
AS
BEGIN
SELECT * FROM PageMenu pm INNER JOIN Pages p
ON pm.PageID=p.PageID WHERE pm.IsAdmin=1 AND pm.PortalID=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetRefPage_Report]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetRefPage_Report] --'2009/01/01' , '2015/01/01' 
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME 
AS
BEGIN
DECLARE @Temp1 TABLE(RefPage NVARCHAR(200))

INSERT INTO @Temp1
SELECT
    CASE WHEN CHARINDEX('/',SessionOriginalReferrer,9) = 0 
  THEN SessionOriginalReferrer
  ELSE LEFT(SessionOriginalReferrer, CHARINDEX('/',SessionOriginalReferrer,9)-1)
  END AS RefPage FROM SessionTracker 
 WHERE [Start] BETWEEN @DashBoardStartDate and @DashBoardEndDate 
 AND  SessionOriginalReferrer <> ''


 SELECT DISTINCT RefPage, COUNT(*) AS [VisitTime]  FROM @Temp1
  GROUP BY RefPage
ORDER BY [VisitTime] DESC 
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetRefPage]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[usp_GetRefPage] '2010/01/01','2015/01/01', 5,1
CREATE PROCEDURE [dbo].[usp_GetRefPage] 
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME,
@range INT,
@pageNo INT
AS
BEGIN
DECLARE @Temp1 TABLE(RefPage NVARCHAR(200))

INSERT INTO @Temp1
SELECT
    CASE WHEN CHARINDEX('/',SessionOriginalReferrer,9) = 0 
  THEN SessionOriginalReferrer
  ELSE LEFT(SessionOriginalReferrer, CHARINDEX('/',SessionOriginalReferrer,9)-1)
  END AS RefPage FROM SessionTracker 
 WHERE [Start] BETWEEN @DashBoardStartDate and @DashBoardEndDate 
 AND  SessionOriginalReferrer <> ''

DECLARE @Temp2 TABLE(RowNum INT IDENTITY(1,1), RefPage NVARCHAR(200), VisitTime INT)
INSERT INTO @Temp2
 SELECT DISTINCT RefPage, COUNT(*) AS [VisitTime]  FROM @Temp1
  GROUP BY RefPage
ORDER BY [VisitTime] DESC 

DECLARE @Count INT
SET @Count =(SELECT COUNT(*) FROM @Temp2)
SELECT @Count AS [Count], * FROM  @Temp2
  WHERE RowNum BETWEEN (@PageNo - 1) * @Range + 1 
       AND @PageNo * @Range
  ORDER BY RowNum ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPortalStartUpList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[usp_GetPortalStartUpList]0 
CREATE Procedure [dbo].[usp_GetPortalStartUpList]
@IsAdmin BIT
AS
BEGIN
SET NOCOUNT ON;
 SELECT 
  [PortalStartUpID],
  [PortalID],
  [EventLocationName],      
  [ControlUrl] 
      FROM 
  dbo.PortalStartUp 
      WHERE IsActive=1 AND IsAdmin=@IsAdmin AND (IsDeleted=0 OR IsDeleted=NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PropertyTypeList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PropertyTypeList]
AS

SELECT
 [PropertyTypeID],
 [Name]
FROM [dbo].[PropertyType]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetMonthlyVisit]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetMonthlyVisit]
AS
BEGIN
SELECT COUNT(*) AS [VisitTime] 
FROM SessionTracker
WHERE DATENAME(MONTH,[start] ) = DATENAME(mm,GETDATE()) 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_loc_AddLanguageSwitchSettings]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_loc_AddLanguageSwitchSettings] 
 @UserModuleID [INT],
 @SettingKey [NVARCHAR](256),
 @SettingValue [NVARCHAR](256),
 @IsActive [BIT],
 @PortalID [INT],
 @UpdatedBy [NVARCHAR](256),
 @AddedBy NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN
IF(EXISTS(SELECT * FROM dbo.LanguageSettingValue WHERE  
 [UserModuleID] = @UserModuleID
 AND [SettingKey] = @SettingKey
 AND PortalID = @PortalID))
BEGIN
UPDATE dbo.LanguageSettingValue SET 
 [SettingValue] = @SettingValue,
 [IsActive] = @IsActive,
 [IsModified] = 1,
 [UpdatedOn] = GETDATE(),
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE  
 [UserModuleID] = @UserModuleID
 AND [SettingKey] = @SettingKey
 AND PortalID = @PortalID
END
ELSE
BEGIN
 INSERT INTO dbo.LanguageSettingValue ( 
 [UserModuleID],
 [SettingKey],
 [SettingValue],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @UserModuleID,
 @SettingKey,
 @SettingValue,
 @IsActive,
 GETDATE(),
 @PortalID,
 @AddedBy
)
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ListEntryAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListEntryAdd]

 @ListName NVARCHAR(50), 
 @Value NVARCHAR(100), 
 @Text NVARCHAR(150),
 @ParentID INT,
 @Level INT,
 @CurrencyCode NVARCHAR(50),
 @DisplayLocale NVARCHAR(50), 
 @EnableDisplayOrder BIT,
 @DefinitionID INT, 
 @Description NVARCHAR(500),
 @PortalID INT,  
 @IsActive BIT,
 @AddedBy NVARCHAR(256),
 @Culture NVARCHAR(256),
 @ListID INT OUTPUT
 

AS
 DECLARE @DisplayOrder INT

 IF @EnableDisplayOrder = 1
  SET @DisplayOrder = ISNULL((SELECT MAX ([DisplayOrder]) FROM dbo.Lists 
     WHERE [ListName] = @ListName AND Culture=@Culture ), 0) + 1
 ELSE
  SET @DisplayOrder = 0
 -- Check if this entry exists
 If EXISTS (SELECT [EntryID] FROM dbo.Lists WHERE [ListName] = @ListName 
    AND [Value] = @Value AND [Text] = @Text 
 AND [ParentID] = @ParentID AND Culture=@Culture)
 BEGIN
  SELECT @ListID=0
  RETURN 
 END
 ELSE
 BEGIN
 INSERT INTO dbo.Lists 
  (
    [ListName],
  [Value],
  [Text],
  [ParentID],
  [Level],
  [CurrencyCode],
  [DisplayLocale],
  [DisplayOrder],
  [DefinitionID],  
  [Description],
  [PortalID],  
  [IsActive],
  [AddedBy],
  [AddedOn],
  [Culture]
  
  )
 VALUES (
  @ListName,
  @Value,
  @Text,
  @ParentID,
  @Level,
  @CurrencyCode,
  @DisplayLocale, 
  @DisplayOrder,  
  @DefinitionID,  
  @Description,
  @PortalID,  
  @IsActive,
    @AddedBy,
    GETDATE(),
    @Culture 
  )

 SELECT @ListID=SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetVisitedPage_Report]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetVisitedPage_Report]
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME 

AS
BEGIN
SELECT
DISTINCT
   CASE CHARINDEX( '?', SessionURL)
       WHEN 0 THEN SessionURL 
       ELSE LEFT(SessionURL, CHARINDEX( '?', SessionURL) - 1) END AS VisitPage , COUNT(*) AS [VisitTime] 
FROM SessionTracker  WHERE SessionURL NOT LIKE '%Admin%' AND SessionURL NOT LIKE '%Super-User%' 
AND  [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate 
GROUP BY SessionURL 
ORDER BY [VisitTime] DESC
END

/****** Object:  StoredProcedure [dbo].[usp_GetRefPage_Report]    Script Date: 12/17/2012 16:10:47 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPages]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec [dbo].[usp_GetPages] 1,0
CREATE PROC [dbo].[usp_GetPages] @PortalID INT
 ,@IsAdmin BIT = NULL
AS
--BEGIN 
IF (@IsAdmin = 0)
BEGIN
 SELECT *
  ,pp.PreviewCode
  ,Isnull((
    SELECT MAX([PageOrder])
    FROM [dbo].[Pages]
    WHERE [Level] = p.[Level]
     AND parentid = p.parentid
     AND portalid = @PortalID
    ), p.pageorder) AS [MaxPageOrder]
 FROM pages p
 INNER JOIN pagemenu pm ON p.pageid = pm.pageid
 INNER JOIN PagePreview pp ON pp.PageID = p.PageID
 WHERE pm.portalid = @PortalID
  AND pm.isadmin = @IsAdmin
 ORDER BY --p.pageid, 
  p.pageorder
END
ELSE
BEGIN
 BEGIN
  SELECT *
   ,Isnull((
     SELECT MAX([PageOrder])
     FROM [dbo].[Pages]
     WHERE [Level] = p.[Level]
      AND parentid = p.parentid
      AND portalid = @PortalID
     ), p.pageorder) AS [MaxPageOrder]
  FROM pages p
  INNER JOIN pagemenu pm ON p.pageid = pm.pageid
  WHERE pm.portalid = @PortalID
   AND pm.isadmin = @IsAdmin
  ORDER BY --p.pageid, 
   p.pageorder
 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSageFrameUserList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetSageFrameUserList]
AS
BEGIN
SELECT UserName From dbo.PortalUser
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTopvisitedPageSearch]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTopvisitedPageSearch] 
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME

AS
BEGIN
DECLARE @TempTable TABLE
(VisitPage NVARCHAR(250),VisitTime  INT )

INSERT INTO @TempTable 
SELECT
DISTINCT
   CASE CHARINDEX( '?', SessionURL)
       WHEN 0 THEN SessionURL 
       ELSE LEFT(SessionURL, CHARINDEX( '?', SessionURL) - 1) END AS VisitPage , COUNT(*) AS [VisitTime] 
FROM SessionTracker  WHERE SessionURL NOT LIKE '%Admin%' AND SessionURL NOT LIKE '%Super-User%' 
AND  [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
GROUP BY SessionURL 
ORDER BY [VisitTime] DESC
DECLARE @Count INT
SET @Count =(SELECT COUNT(*) FROM @TempTable)
SELECT @Count AS [Count], * FROM  @TempTable
  ORDER BY [Count] ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTopvisitedPage]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTopvisitedPage] 
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME ,
@PageNo INT,
@Range INT
AS
BEGIN
DECLARE @TempTable TABLE
(RowNum INT IDENTITY(1,1) ,VisitPage NVARCHAR(250),VisitTime  INT )

INSERT INTO @TempTable 
SELECT
DISTINCT
   CASE CHARINDEX( '?', SessionURL)
       WHEN 0 THEN SessionURL 
       ELSE LEFT(SessionURL, CHARINDEX( '?', SessionURL) - 1) END AS VisitPage , COUNT(*) AS [VisitTime] 
FROM SessionTracker  WHERE SessionURL NOT LIKE '%Admin%' AND SessionURL NOT LIKE '%Super-User%' 
AND  [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
GROUP BY SessionURL 
ORDER BY [VisitTime] DESC
DECLARE @Count INT
SET @Count =(SELECT COUNT(*) FROM @TempTable)
SELECT @Count AS [Count], * FROM  @TempTable
  WHERE RowNum BETWEEN (@PageNo - 1) * @Range + 1 
       AND @PageNo * @Range
  ORDER BY RowNum ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTopvisitCountry]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTopvisitCountry]
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME ,
@Range INT,
@PageNo INT
AS
BEGIN 

DECLARE @TempTable TABLE
(RowNum INT IDENTITY(1,1) ,SessionUserHostAddress NVARCHAR(250),VisitTime  INT )

INSERT INTO @TempTable 
SELECT DISTINCT SessionUserHostAddress, COUNT(*) AS [VisitTime] 
  FROM SessionTracker
  WHERE [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
 GROUP BY SessionUserHostAddress 
ORDER BY [VisitTime] DESC
DECLARE @Count INT
SET @Count =(SELECT COUNT(*) FROM @TempTable)
SELECT @Count AS [Count], * FROM  @TempTable
  WHERE RowNum BETWEEN (@PageNo - 1) * @Range + 1 
       AND @PageNo * @Range
  ORDER BY RowNum ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTopFivevisitedPage]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTopFivevisitedPage]
@DashBoardStartDate DATETIME,
@DashBoardEndDate DATETIME 
AS
BEGIN 


SELECT TOP(5) SessionUserHostAddress AS Country , COUNT(*) AS [VisitTime] 
  FROM SessionTracker
WHERE [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
 GROUP BY SessionUserHostAddress 
ORDER BY [VisitTime] DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTopFivevisitCountry]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTopFivevisitCountry]
@DashBoardStartDate NVARCHAR(50),
@DashBoardEndDate NVARCHAR(50) 
AS
BEGIN 


SELECT TOP(5) SessionUserHostAddress AS Country , COUNT(*) AS [VisitTime] 
  FROM SessionTracker
WHERE [Start] BETWEEN GETDATE()-20 AND GETDATE()
 GROUP BY SessionUserHostAddress 
ORDER BY [VisitTime] DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTopFiveBrowser]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTopFiveBrowser]
@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME
AS
BEGIN
SELECT DISTINCT TOP(5)  SessionBrowser AS Browser , COUNT(*) AS [VisitTime] 
  FROM SessionTracker  WHERE [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
 GROUP BY SessionBrowser
ORDER BY [VisitTime] DESC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetTopBrowser]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetTopBrowser]

@DashBoardStartDate DATETIME ,
@DashBoardEndDate DATETIME,
@PageNo INT,
@Range INT
AS
BEGIN
DECLARE @TempTable TABLE
(RowNum INT IDENTITY(1,1) ,Browser NVARCHAR(250),VisitTime  INT )

INSERT INTO @TempTable 
SELECT DISTINCT  SessionBrowser AS Browser, COUNT(*) AS [VisitTime] 
  FROM SessionTracker WHERE [Start] BETWEEN @DashBoardStartDate AND @DashBoardEndDate
 GROUP BY SessionBrowser
ORDER BY [VisitTime] DESC

DECLARE @Count INT
SET @Count =(SELECT COUNT(*) FROM @TempTable)
SELECT @Count AS [Count], * FROM  @TempTable
  WHERE RowNum BETWEEN (@PageNo - 1) * @Range + 1 
       AND @PageNo * @Range
  ORDER BY RowNum ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSystemEventStartUpList]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Rajkumar Gupta
-- Create date: 11/5/2012
-- Description: To get PortalStartUpList
-- =============================================
--[dbo].[usp_GetSystemEventStartUpList]1
CREATE PROCEDURE [dbo].[usp_GetSystemEventStartUpList]
 @PortalID INT
AS
BEGIN 
 SET NOCOUNT ON;   
 SELECT * FROM dbo.PortalStartUp WHERE PortalID=@PortalID AND (IsDeleted=0 OR IsDeleted=NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSystemEventStartUpDetails]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetSystemEventStartUpDetails]
@PortalStartUpID INT
AS
BEGIN
 SET NOCOUNT ON;
   SELECT ControlUrl,EventLocationName,IsAdmin,IsControlUrl,IsActive FROM dbo.PortalStartUp WHERE PortalStartUpID=@PortalStartUpID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSettingValueByIndividualKey]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetSettingValueByIndividualKey] @PortalID INT
 ,@SettingKey NVARCHAR(256)
AS
BEGIN
 IF (
   EXISTS (
    SELECT *
    FROM SettingValue
    WHERE settingKey = @SettingKey
     AND SettingTypeID = @PortalID
    )
   )
 BEGIN
  SELECT SettingValue as Value
  FROM SettingValue
  WHERE settingKey = @SettingKey
   AND SettingTypeID = @PortalID
 END
 ELSE
 BEGIN
  SELECT SettingValue as Value
  FROM SettingKey
  WHERE settingKey = @SettingKey
   AND PortalID = 1
 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrLoadMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrLoadMenu] 
(
 @UserModuleID INT,
 @PortalID INT
)
AS
BEGIN
 DECLARE @MenuID INT
  IF EXISTS(
     SELECT 
      SettingValue 
     FROM 
      SageMenuSettingValue 
     WHERE 
       SettingKey='MenuID' 
      AND UserModuleID=@UserModuleID
    )
   BEGIN
    SELECT 
     @MenuID=SettingValue 
    FROM 
     SageMenuSettingValue 
    WHERE 
      SettingKey='MenuID' 
     AND UserModuleID=@UserModuleID
   END
  ELSE
   BEGIN
    SELECT 
     @MenuID=MenuID 
    FROM 
     Menu 
    WHERE 
     IsDefault=1
   END
 SELECT 
  *,
  mi.PageID,
  (
   SELECT 
    COUNT(*) 
   FROM 
    MenuItem m 
   WHERE 
    m.ParentID=mi.MenuItemID
  ) AS ChildCount 
 FROM 
  [dbo].[MenuItem] mi 
 WHERE 
  mi.MenuID =@MenuID
 ORDER BY
  MenuLevel,MenuOrder
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrGetSetting]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrGetSetting] 
 @PortalID INT,
 @MenuID INT

AS
BEGIN
 SELECT 
  *
 FROM
  (
   SELECT 
    [dbo].[MenuMgrSettingKey].[SettingKey] AS SettingKey
    ,COALESCE
      (
       [dbo].[MenuMgrSettingValue].SettingValue,
       [dbo].[MenuMgrSettingKey].SettingValue
      ) AS SettingValue     
   FROM 
    [dbo].[MenuMgrSettingValue]
   RIGHT JOIN 
    [dbo].MenuMgrSettingKey 
   ON 
     [dbo].[MenuMgrSettingValue].SettingKey = [dbo].MenuMgrSettingKey.SettingKey 
    AND [dbo].[MenuMgrSettingValue].MenuID = @MenuID 
    AND [dbo].[MenuMgrSettingValue].PortalID=@PortalID
  )p 
 PIVOT 
  (
   MAX(settingvalue)
    FOR
     settingkey IN
         (
          [MenuType],
          [DisplayMode],
          [TopMenuSubType],
          [Caption],
          [SubTitleLevel],
          [SideMenuType]
         )
  ) AS pivottable
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrGetPermission]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrGetPermission] 
 @MenuID INT,
 @PortalID INT

AS
BEGIN
 SELECT 
  PermissionID,
  CAST(RoleID AS NVARCHAR(250)) AS RoleID,
  Username 
 FROM 
  MenuPermission 
 WHERE 
   MenuID=@MenuID 
  AND PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrGetMenuItemDetails]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrGetMenuItemDetails]
(
 @MenuItemID INT
)
AS
BEGIN
 SELECT [MenuItemID]
    ,[MenuID]
    ,[LinkType]
    ,[PageID]
    ,[Title]
    ,[LinkURL]
    ,[ImageIcon]
    ,[Caption]
    ,[HtmlContent]
    ,[ParentID]
    ,[MenuLevel]
    ,[MenuOrder]
    ,[SubText]
    ,[IsActive]
    ,[IsVisible]
    ,[IsDeleted]
    ,[IsModified]
    ,[AddedOn]
    ,[UpdatedOn]
    ,[DeletedOn]
    ,[PortalID]
    ,[AddedBy]
    ,[UpdatedBy]
    ,[DeletedBy]
   FROM 
  [dbo].[MenuItem]
   WHERE 
  [MenuItemID]=@MenuItemID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrGetMenuItem]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrGetMenuItem] 
@MenuID INT

AS
BEGIN
 SELECT 
    [mi].[MenuItemID]
    ,[mi].[MenuID]
    ,[mi].[LinkType]
    ,[mi].[PageID]
    ,[mi].[Title]
    ,[mi].[LinkURL]
    ,[mi].[ImageIcon]
    ,[mi].[Caption]
    ,[mi].[HtmlContent]
    ,[mi].[ParentID]
    ,[mi].[MenuLevel]
    ,[mi].[MenuOrder]
    ,[mi].[SubText]
    ,[mi].[IsVisible]
    ,[mi].[IsActive]
    ,[p].[PageID]
    ,[p].[PageOrder]
    ,[p].[PageName]
    ,[p].[IsVisible]
    ,[p].[ParentID]
    ,[p].[Level]
    ,[p].[IconFile]
    ,[p].[DisableLink]
    ,[p].[Title]
    ,[p].[Description]
    ,[p].[KeyWords]
    ,(
     SELECT COUNT(1) 
     FROM   MenuItem m 
     WHERE   m.ParentID=mi.MenuItemID
    ) AS ChildCount 
  
 FROM    [dbo].[MenuItem] mi 
    LEFT JOIN  Pages p ON mi.PageID=p.PageID
 WHERE    mi.MenuID =@MenuID
 ORDER BY   MenuLevel,MenuOrder
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrDeleteMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrDeleteMenu]
@MenuID INT

AS
BEGIN
 DECLARE @CheckDefault BIT
 SET @CheckDefault = (SELECT IsDefault FROM Menu  WHERE MenuID =  @MenuID)
  IF(@CheckDefault <> 1)
   BEGIN
    DELETE FROM 
     MenuItem 
    WHERE 
     MenuID = @MenuID
    DELETE FROM 
     MenuPermission 
    WHERE 
     MenuID = @MenuID
    DELETE FROM 
     Menu 
    WHERE 
     MenuID = @MenuID
    DELETE FROM 
     MenuMgrSettingValue 
    WHERE 
     MenuID=@MenuID
    DELETE FROM 
     SageMenuSettingValue 
    WHERE 
      SettingKey='MenuID' 
     AND CAST(SettingValue AS INT)=@MenuID
   END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrDeleteLink]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrDeleteLink]
@MenuItemID INT

AS 
BEGIN
 DELETE FROM 
  [dbo].[MenuItem] 
 WHERE 
  ParentID=@MenuItemID
 DELETE FROM 
  [dbo].[MenuItem] 
 WHERE 
  MenuItemID=@MenuItemID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddUpdSetting]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddUpdSetting]   
@MenuID INT,
@SettingKey NVARCHAR(256),
@SettingValue NVARCHAR(256),
@PortalID INT,
@Updatedby NVARCHAR(256),
@AddedBy NVARCHAR(256) 

WITH EXECUTE AS CALLER
AS
 DECLARE @IsActive AS BIT
 SET @IsActive='True'
BEGIN
 IF(EXISTS(
    SELECT 
      * 
    FROM 
     dbo.MenuMgrSettingValue 
    WHERE 
      [MenuID] = @MenuID 
     AND [SettingKey] = @SettingKey 
     AND PortalID = @PortalID
   ))
  BEGIN
      UPDATE 
    dbo.MenuMgrSettingValue 
   SET 
    [SettingValue] = @SettingValue,
    [IsActive] = @IsActive,
    [IsModified] = 1,
    [UpdatedOn] = GETDATE(),
    [PortalID] = @PortalID,
    [UpdatedBy] = @UpdatedBy
      WHERE 
     [MenuID] = @MenuID 
    AND [SettingKey] = @SettingKey 
    AND PortalID = @PortalID
  END
 ELSE
  BEGIN
   INSERT INTO MenuMgrSettingValue 
           ( 
            [MenuID],
            [SettingKey],
            [SettingValue], 
            [AddedOn],
            [PortalID],
            [AddedBy]
           ) 
          VALUES 
           (
            @MenuID,
            @SettingKey,
            @SettingValue, 
            GETDATE(),
            @PortalID,
            @AddedBy
           )
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddUpdateMenuPermission]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddUpdateMenuPermission] 
@MenuID INT,
@PermissionID INT,
@RoleID UNIQUEIDENTIFIER,
@UserName NVARCHAR(256),
@AllowAccess BIT,
@PortalID INT
                                                  
AS
  BEGIN
      IF( (@UserName IS NOT NULL ) OR @UserName<>'' )
  BEGIN
   DELETE FROM
    [dbo].[MenuPermission] 
   WHERE  
     [PortalID] = @PortalID 
    AND [MenuID] = @MenuID 
    AND username=@username
   INSERT INTO [dbo].[MenuPermission]
           (
             MenuID,
             PermissionID,
             RoleID,
             Username,
             AllowAccess,
             PortalID,
             AddedOn
            )            
          VALUES      
           (
             @MenuID,
             @permissionid,
             NULL,
             @UserName,
             @AllowAccess,
             @PortalID,
             GETDATE()
           )
  END
 ELSE IF((@RoleID IS NOT NULL) OR @RoleID <> '' )
  BEGIN
   IF(NOT EXISTS(SELECT * FROM  [MenuPermission] WHERE PortalID=@PortalID AND MenuID=@MenuID AND PermissionID=@PermissionID AND RoleID=@RoleID))
    BEGIN
     DELETE FROM 
      [MenuPermission] 
     WHERE  
       PortalID=@PortalID 
      AND MenuID=@MenuID  
      AND RoleID=@RoleID
     INSERT INTO [dbo].[MenuPermission]
              (
               MenuID,
               PermissionID,
               RoleID,
               Username,
               AllowAccess,
               PortalID,
               AddedOn
              )
             VALUES
              (
               @MenuID,
               @PermissionID,
               CAST(@RoleID AS UNIQUEIDENTIFIER ),
               @RoleID,
               @AllowAccess,
               @PortalID,
               GETDATE()
              )
    END   
  END      
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddSubText]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddSubText]
 @PageID INT,
 @SubText NVARCHAR(254),
 @IsActive BIT,
 @IsVisible BIT
AS
BEGIN
 UPDATE  
  [dbo].[MenuItem] 
 SET 
  SubText = @SubText,
  IsActive = @IsActive,
  IsVisible = @IsVisible 
 WHERE 
  PageID =@PageID
END
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddNewMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddNewMenu] 
@MenuName VARCHAR(100),
@MenuType VARCHAR(50),
@IsDefault BIT,
@PortalID INT,
@MenuID INT OUTPUT
AS
BEGIN
 IF(@IsDefault = 1)
   BEGIN
    UPDATE  
     [dbo].[MENU] 
    SET 
     IsDefault = 0 
    WHERE 
     IsDefault= 1 
    AND 
     PortalID=@PortalID
    INSERT INTO [dbo].[MENU]
          (
           MenuName,
           MenuType,
           IsDefault,
           PortalID
          ) 
         VALUES 
          (
           @MenuName,
           @MenuType,
           @IsDefault,
           @PortalID
          )
   END
 ELSE
   BEGIN
    DECLARE @PortalDefault BIT
     IF EXISTS(SELECT MenuID FROM Menu WHERE IsDefault=1 AND PortalID=@PortalID)
      BEGIN
       SET @PortalDefault=0
      END
     ELSE
      BEGIN
       SET @PortalDefault=1
      END
    INSERT INTO [dbo].[MENU]
          (
           MenuName,
           MenuType,
           IsDefault,
           PortalID
          ) 
         VALUES 
          (
           @MenuName,
           @MenuType,
           @PortalDefault,
           @PortalID
          )
   END
 SET @MenuID = CAST(SCOPE_IDENTITY() AS INT)
END
 SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddMenuPermission]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddMenuPermission] 
 @MenuID INT,
 @PermissionID INT,
 @RoleID UNIQUEIDENTIFIER,
 @UserName NVARCHAR(256),
 @AllowAccess BIT,
 @PortalID INT
                                                  
AS
  BEGIN
 INSERT INTO MenuPermission
        ( 
         MenuID
         ,PermissionID
         ,RoleID
         ,Username
         ,AllowAccess
         ,PortalID
         ,AddedOn
         )
        VALUES      
        (
          @MenuID
         ,@permissionid
         ,CAST(@RoleID AS UNIQUEIDENTIFIER)
         ,@UserName
         ,@AllowAccess
         ,@PortalID
         ,GETDATE()
        )
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddMenuItem]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddMenuItem]
 @MenuID INT,
 @MenuItemID INT,
 @LinkType NVARCHAR(50),
 @PageID NVARCHAR(50),
 @Title NVARCHAR(50),
 @LinkURL NVARCHAR(50),
 @ImageIcon NVARCHAR(100),
 @Caption NVARCHAR(2000),
 @HtmlContent NVARCHAR(4000),
 @ParentID INT,
 @MenuLevel NVARCHAR(50),
 @MenuOrder NVARCHAR(50),
 @Mode NVARCHAR(50),
 @PreservePageOrder BIT,
 @MainParent INT,
 @IsActive BIT,
 @IsVisible BIT
AS
BEGIN
 DECLARE @NewParentID INT,@NewLevel INT,@NewOrder INT,@ParentLevel INT,@PortalID INT
 SET @PortalID= (
      SELECT 
       ISNULL(MAX(PortalID),0) 
      FROM 
       Menu 
      WHERE 
       MenuID=@MenuID
     )
  IF @Mode='A'
   BEGIN
    
    IF @PreservePageOrder=1
     BEGIN
      IF (EXISTS(SELECT * FROM MenuItem  WHERE PageID=@ParentID AND MenuID=@MenuID))
       BEGIN
        SELECT 
         @NewParentID=MenuItemID 
        FROM 
         MenuItem 
        WHERE 
          PageID=@ParentID 
         AND MenuID=@MenuID
        SET @NewLevel=@MenuLevel
        SELECT 
         @NewOrder=MAX(MenuOrder) 
        FROM 
         MenuItem 
        WHERE 
          ParentID=@ParentID 
         AND MenuID=@MenuID
        SET @NewOrder=@NewOrder+1
       END
      ELSE
       BEGIN
        SET @NewParentID=0   
         IF @NewParentID=0
          BEGIN
           SET @NewLevel=0
           SELECT 
            @NewOrder=MAX(MenuOrder) 
           FROM 
            MenuItem 
           WHERE 
             ParentID=@ParentID 
            AND MenuLevel=@NewLevel 
            AND MenuID=@MenuID
           SET @NewOrder= ISNULL(@NewOrder,0)+1
          END
         ELSE
          BEGIN
           SELECT 
            @ParentLevel=MenuLevel 
            FROM 
             MenuItem 
            WHERE 
             MenuItemID=@NewParentID   
            AND MenuID=@MenuID
           SET @NewLevel=@ParentLevel+1
           SELECT 
            @NewOrder=MAX(MenuOrder) 
           FROM 
            MenuItem 
           WHERE 
             ParentID=@ParentID   
            AND MenuID=@MenuID
           SET @NewOrder=ISNULL(@NewOrder,0)+1
          END
       END
     END
    ELSE
     BEGIN
      SET @NewParentID=@MainParent
       IF @NewParentID=0
        BEGIN
         SET @NewLevel=0
         SELECT 
          @NewOrder=MAX(MenuOrder) 
         FROM 
          MenuItem 
         WHERE 
           ParentID=0 
          AND MenuLevel=@NewLevel 
          AND MenuID=@MenuID
         SET @NewOrder=ISNULL(@NewOrder,0)+1
        END
       ELSE
        BEGIN
         SELECT 
          @ParentLevel=MenuLevel 
         FROM 
          MenuItem 
         WHERE 
           MenuItemID=@NewParentID 
          AND MenuID=@MenuID
         SET @NewLevel=@ParentLevel+1
         SELECT 
          @NewOrder=MAX(MenuOrder) 
         FROM 
          MenuItem 
         WHERE 
           ParentID=@ParentID 
          AND MenuID=@MenuID
         SET @NewOrder=ISNULL(@NewOrder,0)+1
        END
     END
    INSERT INTO MenuItem
          (
            MenuID
           ,LinkType
           ,PageID
           ,Title
           ,LinkURL 
           ,ImageIcon 
           ,Caption 
           ,HtmlContent
           ,ParentID 
           ,MenuLevel 
           ,MenuOrder 
           ,AddedOn
           ,IsActive
           ,IsVisible
           ,PortalID
          )
         VALUES
          (
            @MenuID
           ,@LinkType
           ,@PageID
           ,@Title
           ,@LinkURL 
           ,@ImageIcon 
           ,@Caption 
           ,@HtmlContent
           ,@NewParentID 
           ,@NewLevel
           ,@NewOrder
           ,GETDATE()
           ,@IsActive
           ,@IsVisible
           ,@PortalID
          )
   END
  ELSE
   BEGIN
    IF @ParentID<>0
     BEGIN
      SELECT 
       @NewLevel=MenuLevel 
      FROM 
       MenuItem 
      WHERE 
        MenuItemID=@ParentID 
       AND MenuID=@MenuID
      SET @NewLevel=ISNULL(@NewLevel,0)+1
     END
    ELSE
     BEGIN
      SET @NewLevel=0
     END
    UPDATE 
     [dbo].[MenuItem]
    SET 
     Caption=@Caption,
     MenuLevel=@NewLevel,
     IsActive=@IsActive,
     IsVisible=@IsVisible,
     PortalID=@PortalID,
     IsModified=1,
     ParentID=@ParentID,
     UpdatedOn=GETDATE()
    WHERE 
      MenuItemID=@MenuItemID 
     AND MenuID=@MenuID 
   END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddHtmlContent]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddHtmlContent]
 @MenuID INT,
 @MenuItemID INT,
 @LinkType NVARCHAR(50),
 @Title NVARCHAR(50),
 @HtmlContent ntext,
 @ImageIcon NVARCHAR(100),
 @Caption NVARCHAR(2000),
 @ParentID NVARCHAR(50),
 @MenuLevel NVARCHAR(50),
 @IsVisible BIT,
 @Mode NVARCHAR(50),
 @IsActive BIT
AS
BEGIN
 DECLARE @GetMenuOrder INT,@PortalID INT;
 SET @PortalID = (
       SELECT 
        ISNULL(MAX(PortalID),0) 
       FROM 
        Menu 
       WHERE 
        MenuID=@MenuID
      )
 SET @GetMenuOrder = (
       SELECT 
        ISNULL(MAX(MenuOrder),0) 
       FROM 
        MenuItem 
       WHERE 
         MenuID=@MenuID 
        AND MenuLevel=@MenuLevel 
       AND ParentID=@ParentID 
      )
 SET @GetMenuOrder = @GetMenuOrder + 1
  IF (@Mode='A')
   BEGIN
    INSERT INTO MenuItem
         (
           MenuID
          ,LinkType
          ,Title
          ,HtmlContent 
          ,ImageIcon 
          ,Caption 
          ,ParentID 
          ,MenuLevel 
          ,MenuOrder 
          ,IsVisible
          ,AddedOn
          ,IsActive
          ,PortalID
         )
        VALUES
         (
           @MenuID
          ,@LinkType
          ,@Title
          ,@HtmlContent 
          ,@ImageIcon 
          ,@Caption 
          ,@ParentID
          ,@MenuLevel 
          ,@GetMenuOrder 
          ,@IsVisible
          ,GETDATE()
          ,@IsActive
          ,@PortalID
         )
   END
  ELSE
   BEGIN
    UPDATE 
     MenuItem
    SET 
     Title=@Title,
     HtmlContent=@HtmlContent,
     ImageIcon=@ImageIcon,
     Caption=@Caption,
     ParentID=@ParentID,
     MenuLevel=@MenuLevel,
     --MenuOrder=@GetMenuOrder,
     IsVisible=@IsVisible,
     IsActive=@IsActive,
     PortalID=@PortalID
    WHERE 
     MenuItemID=@MenuItemID
   END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrAddExternalLink]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrAddExternalLink]
 @MenuID INT,
 @MenuItemID INT,
 @LinkType NVARCHAR(50),
 @Title NVARCHAR(50),
 @LinkURL NVARCHAR(200),
 @ImageIcon NVARCHAR(100),
 @Caption NVARCHAR(2000),
 @ParentID NVARCHAR(50),
 @MenuLevel NVARCHAR(50),
 @MenuOrder NVARCHAR(50),
 @IsVisible BIT,
 @IsActive BIT,
 @Mode NVARCHAR(50)
AS
BEGIN
 DECLARE @GetMenuOrder INT, @PortalID INT;
 SET @PortalID = (
       SELECT 
         ISNULL( MAX(PortalID),0) 
       FROM 
        Menu 
       WHERE 
        MenuID=@MenuID
      )
 SET @GetMenuOrder = (
       SELECT 
        ISNULL(MAX(MenuOrder),0) 
       FROM 
        MenuItem 
       WHERE 
         MenuID=@MenuID 
        AND MenuLevel=@MenuLevel 
        AND ParentID=@ParentID 
      )
 SET @GetMenuOrder = @GetMenuOrder + 1
  IF @Mode='A'
   BEGIN
    INSERT INTO MenuItem
         (
           MenuID
          ,LinkType
          ,Title
          ,LinkURL 
          ,ImageIcon 
          ,Caption 
          ,ParentID 
          ,MenuLevel 
          ,MenuOrder
          ,IsActive
          ,IsVisible 
          ,AddedOn
          ,PortalID
         )
        VALUES
         (
           @MenuID
          ,@LinkType
          ,@Title
          ,@LinkURL 
          ,@ImageIcon 
          ,@Caption 
          ,@ParentID
          ,@MenuLevel 
          ,@GetMenuOrder
          ,@IsActive 
          ,@IsVisible
          ,GETDATE()
          ,@PortalID
         )
   END
  ELSE
   BEGIN
       UPDATE 
     MenuItem
       SET 
     Title=@Title,
     LinkURL=@LinkURL,
     ImageIcon=@ImageIcon,
     Caption=@Caption,
     ParentID=@ParentID,
     MenuLevel=@MenuLevel,
     --MenuOrder=@GetMenuOrder,
     IsVisible = @IsVisible, 
     IsActive=@IsActive,
     AddedOn=GETDATE(),
     PortalID=@PortalID
       WHERE 
     MenuItemID=@MenuItemID
   END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuManagerGetSageMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuManagerGetSageMenu]  
(  
 @UserName NVARCHAR(50),  
 @UserModuleID INT,  
 @PortalID INT  
)  
AS  
 BEGIN    
 DECLARE @MenuID NVARCHAR(50)   
    IF EXISTS  
      (  
      SELECT   1
      FROM      SageMenuSettingValue   
      WHERE     UserModuleID=@UserModuleID  
      )  
       BEGIN  
          SELECT     @MenuID=SettingValue   
          FROM       SageMenuSettingValue  
          WHERE       UserModuleID=@UserModuleID  
       END  
    ELSE  
       BEGIN  
        SET @MenuID=0  
       END   
        
      SELECT  DISTINCT MenuID,    MenuName,  
        MenuType,   IsDefault,  
        PortalID,   @MenuID AS SelectedMenu   
      FROM    Menu   
      WHERE   PortalID=@PortalID    
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuManagerGetMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuManagerGetMenu]
(
 @UserName NVARCHAR(50),
 @PortalID INT
)
AS
 BEGIN 
    SELECT  
  DISTINCT MenuID,
     MenuName,
     MenuType,
     IsDefault,
     PortalID
    FROM 
  Menu  
 WHERE 
  PortalID=@PortalID
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuLocalizeGetPages]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[usp_MenuLocalizeGetPages]1,'en-US'
CREATE PROCEDURE [dbo].[usp_MenuLocalizeGetPages]
@PortalID INT,
@CultureCode NVARCHAR(20)
AS
BEGIN
DECLARE @MenuID INT
SET @MenuID=(SELECT MenuID FROM Menu WHERE IsDefault=1 and PortalID = @PortalID)
 SELECT 
  p.PageID,
  p.PageName, 
  (
   CASE WHEN 
      (
      SELECT 
       COUNT(PageID) 
      FROM 
       LocalPage 
      WHERE 
        PageID=p.PageID 
       AND CultureCode=@CultureCode
     )>0
    THEN 
     (
      SELECT 
       LocalPageName 
      FROM 
       LocalPage 
      WHERE 
        PageID=p.PageID 
       AND CultureCode=@CultureCode
     )
    ELSE 
     (
      SELECT 
       PageName 
      FROM 
       Pages 
      WHERE 
       PageID=p.PageID
      ) 
    END
  ) AS LocalPageName ,
  (
   CASE WHEN 
      (
      SELECT 
       COUNT(PageID) 
      FROM 
       LocalPage 
      WHERE 
        PageID=p.PageID 
       AND CultureCode=@CultureCode
     )>0
    THEN 
     (
      SELECT 
       LocalPageCaption 
      FROM 
       LocalPage 
      WHERE 
        PageID=p.PageID 
       AND CultureCode=@CultureCode
     )
    ELSE 
     (     
      SELECT 
       Caption 
      FROM 
       MenuItem 
      WHERE 
       PageID=p.PageID AND MenuID=@MenuID
      ) 
    END
  ) AS LocalPageCaption 
 FROM 
  Pages p 
 WHERE 
  (
    p.PortalID=@PortalID 
   OR p.PortalID=-1
   
  )
  AND (p.IsDeleted=0 OR p.IsDeleted IS NULL)
END

  
  
  
  
  
  
  
  
  
  
  
  
--  select * from Pages where PageName Like '%Upgrade%'

--Update Pages
--SET portalID = -1
--WHERE PageID = 18

--select * from PageModules where pageID = 28

--Update Pages
--SET portalID = -1
--WHERE PageID = 18

--Update PageModules
--SET PortalID = -1
--WHERE PageID = 18
--OR PageID = 28
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleMessageGet]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleMessageGet]
(
 @ModuleID INT,
 @Culture NVARCHAR(50)
)
AS
BEGIN
 SELECT 
  * 
 FROM 
  ModuleMessage 
 WHERE 
   ModuleID=@ModuleID 
  AND Culture=@Culture
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleMessageAdd]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleMessageAdd]
(
 @ModuleID INT,
 @Message NTEXT,
 @Culture NVARCHAR(50),
 @IsActive BIT,
 @MessageType INT,
 @MessageMode INT,
 @MessagePosition INT
)
AS
BEGIN
 IF(EXISTS
   (
    SELECT 
     * 
    FROM 
     ModuleMessage 
    WHERE 
      ModuleID=@ModuleID 
     AND Culture=@Culture
   )
  )
  BEGIN
   UPDATE 
    ModuleMessage 
   SET 
    [Message]=@Message,
    MessageType=@MessageType,
    MessageMode=@MessageMode,
    MessagePosition=@MessagePosition,
    IsActive=@IsActive
   WHERE 
     ModuleID=@ModuleID 
    AND Culture=@Culture
  END
 ELSE
  BEGIN
   INSERT INTO ModuleMessage
    (
     ModuleID,
     [Message],
     Culture,
     IsActive,
     MessageType,
     MessageMode,
     MessagePosition
    )
   VALUES
    (
     @ModuleID,
     @Message,
     @Culture,
     @IsActive,
     @MessageType,
     @MessageMode,
     @MessagePosition
    )
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrUpdateMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrUpdateMenu] 
 @MenuName VARCHAR(100),
 @MenuType VARCHAR(50),
 @IsDefault BIT,
 @PortalID INT,
 @MenuID INT 
AS
BEGIN
 IF(@IsDefault = 1)
   BEGIN
    UPDATE  
     [dbo].[MENU] 
    SET 
     IsDefault = 0 
    WHERE 
      IsDefault= 1 
     AND PortalID=@PortalID     
 
    UPDATE  
     [dbo].[MENU] 
    SET 
     MenuName =@MenuName,
     IsDefault=@IsDefault,
     MenuType = @MenuType 
    WHERE 
     MenuID=@MenuID    
   END
 ELSE
   BEGIN
    UPDATE  
     [dbo].[MENU] 
    SET 
     MenuName =@MenuName,
     MenuType = @MenuType 
    WHERE MenuID=@MenuID
   END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrSortMenuItems]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrSortMenuItems]
(
 @MenuID INT,
 @MenuItemID INT,
 @ParentID INT,
 @BeforeID INT,
 @AfterID INT,
 @PortalID INT
)

AS
BEGIN
 DECLARE @MenuLevel INT
 DECLARE @MenuOrder INT
 
  IF @ParentID>0
   BEGIN
    SELECT 
     @MenuLevel=MenuLevel 
    FROM 
     MenuItem 
    WHERE 
     MenuID=@MenuID 
    AND 
     MenuItemID=@ParentID 

    SET @MenuLevel=@MenuLevel+1
    SELECT 
     @MenuOrder=MenuOrder 
    FROM 
     MenuItem 
    WHERE 
      MenuID=@MenuID 
     AND MenuItemID=@ParentID 
     AND MenuLevel=@MenuLevel 
   END
  ELSE IF @ParentID=0
   BEGIN
    SET @MenuLevel=0
    SELECT 
     @MenuOrder=MenuOrder 
    FROM 
     MenuItem 
    WHERE 
      MenuID=@MenuID 
     AND MenuLevel=@MenuLevel 
   END
   
 UPDATE 
  MenuItem 
 SET 
  ParentID=@ParentID,
  MenuLevel=@MenuLevel,
  MenuOrder=@MenuOrder
 WHERE 
  MenuItemID=@MenuItemID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrSortMenu]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrSortMenu]
 @MenuItemID INT,
 @ParentID INT,
 @BeforeID INT,
 @AfterID INT,
 @PortalID INT
AS
BEGIN
 IF(
  EXISTS
   (
    SELECT 
     *  
    FROM 
     [dbo].[MenuItem] 
    WHERE 
     MenuItemID=@MenuItemID
   )
  )
   BEGIN 
   DECLARE @ParentLevel INT, @MenuOrder INT,@oldParentID INT,@oldMenuOrder INT
   SELECT 
    @ParentLevel=MenuLevel 
   FROM 
    MenuItem 
   WHERE 
    MenuItemID=@ParentID  
   SELECT 
    @oldParentID=ParentID,
    @oldMenuOrder=MenuOrder 
   FROM 
    [dbo].[MenuItem] 
   WHERE 
    MenuItemID=@MenuItemID  
    
    IF @oldParentID <> @ParentID
     BEGIN     
      UPDATE 
       MenuItem 
      SET 
       MenuOrder=MenuOrder-1 
      WHERE 
        MenuOrder>@oldMenuOrder 
       AND ParentID=@oldParentID  
     END
     DECLARE @CurrentSortValue INT
     SELECT 
      @CurrentSortValue=MenuOrder 
     FROM 
      dbo.MenuItem 
     WHERE 
       [MenuItemID]=@MenuItemID  
      AND ParentID=@ParentID     
    IF(@BeforeID>0)
     BEGIN
      UPDATE 
       MenuItem 
      SET 
       MenuOrder=MenuOrder-1 
      WHERE 
        MenuOrder>@CurrentSortValue  
       AND ParentID=@ParentID
      SELECT 
       @MenuOrder=[MenuOrder] 
      FROM 
       MenuItem 
      WHERE 
       MenuItemID=@BeforeID 
      UPDATE 
       MenuItem 
      SET 
       MenuOrder=MenuOrder+1 
      WHERE 
        MenuOrder>=@MenuOrder  
       AND ParentID=@ParentID
     END     
    ELSE IF(@AfterID>0)
     BEGIN
      UPDATE 
       MenuItem 
      SET 
       MenuOrder=MenuOrder-1 
      WHERE 
        MenuOrder>@CurrentSortValue  
       AND ParentID=@ParentID 
      SELECT 
       @MenuOrder=[MenuOrder] 
      FROM 
       MenuItem 
      WHERE 
       MenuItemID=@AfterID
      UPDATE 
       MenuItem 
      SET 
       MenuOrder=MenuOrder+1 
      WHERE 
        MenuOrder>@MenuOrder 
       AND ParentID=@ParentID
      SET @MenuOrder=@MenuOrder+1
     END
    ELSE
     BEGIN
      SET @MenuOrder=@CurrentSortValue
     END
   
      UPDATE 
       [dbo].[MenuItem]  
      SET 
        [MenuOrder] = ISNULL(@MenuOrder,1)   
       ,[ParentID] = @ParentID
       ,MenuLevel = ISNULL(@ParentLevel,-1)+1        
      WHERE  
       MenuItemID=@MenuItemID
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrSelectIsDefault]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrSelectIsDefault]
@MenuID INT

AS
BEGIN
 SELECT 1
 FROM   [dbo].[Menu] 
 WHERE  IsDefault = 1 AND MenuID = @MenuID         
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrMenuPermissionDelete]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrMenuPermissionDelete]
 @MenuID INT,                                                  
 @PortalID INT
                                                  
AS
  BEGIN 
    DELETE FROM 
   [MenuPermission] 
  WHERE  
    PortalID=@PortalID 
   AND MenuID=@MenuID
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_loc_GetLanguageSwitchSettings]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_loc_GetLanguageSwitchSettings]
(
@PortalID INT,
@UserModuleID INT
)
AS
BEGIN
 SELECT ISNULL([dbo].[LanguageSettingValue].[LanguageSettingValueID],0) AS LanguageSettingValueID
      ,0 AS [UserModuleID]
      ,[dbo].[LanguageSettingKey].[SettingKey] AS SettingKey
      ,COALESCE([dbo].[LanguageSettingValue].SettingValue,[dbo].[LanguageSettingKey].SettingValue) AS SettingValue
      ,[dbo].[LanguageSettingValue].[IsActive]
      ,[dbo].[LanguageSettingValue].[IsDeleted]
      ,[dbo].[LanguageSettingValue].[IsModified]
      ,[dbo].[LanguageSettingValue].[AddedOn]
      ,[dbo].[LanguageSettingValue].[UpdatedOn]
      ,[dbo].[LanguageSettingValue].[DeletedOn]
      ,[dbo].[LanguageSettingValue].[PortalID]
      ,[dbo].[LanguageSettingValue].[AddedBy]
      ,[dbo].[LanguageSettingValue].[UpdatedBy]
      ,[dbo].[LanguageSettingValue].[DeletedBy]
 FROM [dbo].[LanguageSettingValue]
 RIGHT JOIN [dbo].[LanguageSettingKey] ON [dbo].[LanguageSettingValue].SettingKey = [dbo].[LanguageSettingKey].SettingKey 
    AND [dbo].[LanguageSettingValue].UserModuleID = @UserModuleID AND [dbo].[LanguageSettingValue].PortalID=@PortalID
 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Logo_GetData]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Logo_GetData] 
 @UserModuleID INT,
 @PortalID INT,
 @CultureCode NVARCHAR(100)
AS
BEGIN
 SELECT LogoText,LogoPath,Slogan,url FROM dbo.[Logo] 
 WHERE UserModuleID=@UserModuleID AND PortalID=@PortalID AND CultureCode=@CultureCode
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Logo_AddUpdate]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Logo_AddUpdate] 
 @LogoText NVARCHAR(100),
 @LogoPath NVARCHAR(200),
 @UserModuleID INT,
 @PortalID INT,
 @Slogan NVARCHAR(500),
 @url NVARCHAR(250),
 @CultureCode NVARCHAR(100)
AS
BEGIN
 IF(EXISTS(SELECT * FROM dbo.[Logo] WHERE UserModuleID=@UserModuleID AND PortalID=@PortalID AND CultureCode=@CultureCode))
  BEGIN
   UPDATE dbo.Logo SET LogoText=@LogoText,LogoPath=@LogoPath,Slogan=@Slogan,url=@url 
   WHERE UserModuleID=@UserModuleID AND PortalID=@PortalID AND CultureCode=@CultureCode 
  END
 ELSE
  BEGIN
   INSERT INTO dbo.[Logo]
   (
   LogoText,
   LogoPath,
   UserModuleID,
   PortalID,
   Slogan,
   url,
   CultureCode
   )
   VALUES
   (
   @LogoText,
   @LogoPath,
   @UserModuleID,
   @PortalID,
   @Slogan,
   @url,
   @CultureCode
   )
   
  END
END
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[ContactUsID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[Message] [nvarchar](4000) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[ContactUsID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Paths](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NOT NULL,
	[Path] [nvarchar](256) NOT NULL,
	[LoweredPath] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK__aspnet_Paths__67C95AEA] PRIMARY KEY NONCLUSTERED 
(
	[PathId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_Paths_index] ON [dbo].[aspnet_Paths] 
(
	[ApplicationId] ASC,
	[LoweredPath] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  View [dbo].[vw_aspnet_Applications]    Script Date: 12/29/2014 16:38:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Applications]
  AS SELECT [dbo].[aspnet_Applications].[ApplicationName], [dbo].[aspnet_Applications].[LoweredApplicationName], [dbo].[aspnet_Applications].[ApplicationId], [dbo].[aspnet_Applications].[Description]
  FROM [dbo].[aspnet_Applications]
GO
/****** Object:  StoredProcedure [dbo].[usp_UserAgentSaveType]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserAgentSaveType]
( @AgentMode NVARCHAR (50),
 @PortalID INT,
 @ChangedBy NVARCHAR (250),
 @ChangedDate DATETIME,
 @IsActive BIT) AS
BEGIN

IF EXISTS (
 SELECT
  *
 FROM
  [UserAgent]
 WHERE
  PortalID =@PortalID
) UPDATE [dbo].[UserAgent]
SET AgentMode =@AgentMode,
 PortalID =@PortalID,
 ChangedBy =@ChangedBy,
 ChangedDate =@ChangedDate,
 IsActive =@IsActive
 WHERE PortalID = @PortalID
ELSE

BEGIN
 INSERT INTO [dbo].[UserAgent] (
  AgentMode,
  PortalID,
  ChangedBy,
  ChangedDate,
  IsActive
 )
VALUES
 (
  @AgentMode,
  @PortalID,
  @ChangedBy,
  @ChangedDate,
  @IsActive
 )
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserAgentGetType]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserAgentGetType] 
@PortalID INT,
 @IsActive BIT AS
BEGIN
 SELECT
  [AgentMode]
 FROM
  [DBO].[UserAgent]
 WHERE
  PortalID =@PortalID
 AND IsActive = @IsActive
 END
GO
/****** Object:  StoredProcedure [dbo].[USP_SHORTURL_ENCODE]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_SHORTURL_ENCODE]
 -- Add the parameters for the stored procedure here
 @Url NVARCHAR(1000)
 ,@Code NVARCHAR(8)
AS
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON;

 IF (
   EXISTS (
    SELECT ShortUrlKey
    FROM ShortUrl
    WHERE ShortUrlValue = @Url
    )
   )
 BEGIN
  SELECT @Code = ShortUrlKey
  FROM ShortUrl
  WHERE ShortUrlValue = @Url

  SELECT @Code
 END
 ELSE
 BEGIN
  IF (
    EXISTS (
     SELECT ShortUrlKey
     FROM ShortUrl
     WHERE ShortUrlKey = @Code
     )
    )
  BEGIN
   SELECT @Code = '-1'
    --SELECT @Code = coalesce(@Code, '') + n
    --FROM (
    -- SELECT TOP 8 CHAR(number) n
    -- FROM master..spt_values
    -- WHERE type = 'P'
    --  AND (
    --   number BETWEEN ascii(0)
    --    AND ascii(9)
    --   OR number BETWEEN ascii('A')
    --    AND ascii('Z')
    --   OR number BETWEEN ascii('a')
    --    AND ascii('z')
    --   )
    -- ORDER BY newid()
    -- ) a
  END
  ELSE
  BEGIN
   INSERT INTO dbo.ShortUrl (
    ShortUrlKey
    ,ShortUrlValue
    )
   VALUES (
    @Code
    ,@Url
    )
  END

  SELECT @Code
 END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SHORTURL_DECODE]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[USP_SHORTURL_DECODE]
 -- Add the parameters for the stored procedure here
 @Key NVARCHAR(8)
AS
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON;

 IF (
   EXISTS (
    SELECT ShortUrlKey
    FROM ShortUrl
    WHERE ShortUrlKey = @Key
    )
   )
 BEGIN  
  SELECT ShortUrlValue
  FROM ShortUrl
  WHERE ShortUrlKey = @Key
 END
 ELSE
  SELECT 'code does not exist'
END
GO
/****** Object:  StoredProcedure [dbo].[usp_sftemplate_updactive]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_sftemplate_updactive] 
@TemplateName NVARCHAR (50) AS
BEGIN

IF (
 (
  SELECT
   COUNT (*)
  FROM
   sftemplate
 ) > 0
)
BEGIN
 UPDATE sftemplate
SET TemplateName =@TemplateName
END
ELSE

BEGIN
 INSERT INTO sftemplate (TemplateName, IsActive)
VALUES
 (@TemplateName, 1)
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_sftemplate_GetActiveTemplate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_sftemplate_GetActiveTemplate] (@PortalID INT) AS
 BEGIN
   SELECT TemplateName
   FROM sftemplate       
   WHERE PortalID =@PortalID 
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_sftemplate_activate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec usp_sftemplate_activate 'default',1,1  
CREATE PROCEDURE [dbo].[usp_sftemplate_activate]  
 (  
 @TemplateName NVARCHAR (50),  
 @IsActive BIT,  
 @PortalID INT  
) AS  
BEGIN  
  
IF (EXISTS(  SELECT   1  
   FROM  sftemplate  
   WHERE  PortalID =@PortalID  
  ))  
   
   BEGIN  
      UPDATE  sftemplate  
      SET   TemplateName =@TemplateName, IsActive =@IsActive  
      WHERE  PortalID =@PortalID  
   END  
     
ELSE  
  
BEGIN  
   INSERT INTO sftemplate (  
  TemplateName,  
  IsActive,  
  PortalID  
    )  
   VALUES  
    (  
  @TemplateName ,@IsActive ,@PortalID  
    )  
   END  
  
    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UsersAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UsersAdd] 
(@UserID INT OUTPUT,
 @UserName NVARCHAR (256),
 @FirstName NVARCHAR (100),
 @LastName NVARCHAR (100),
 @Email NVARCHAR (256),
 @IsActive BIT,
 @AddedOn DATETIME,
 @PortalID INT,
 @AddedBy NVARCHAR (256))
 AS
BEGIN
 INSERT INTO [dbo].Users (
 [Username],
 [FirstName],
 [LastName],
 [Email],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
)
VALUES
 (
  @UserName,
  @FirstName,
  @LastName,
  @Email,
  @IsActive,
  @AddedOn,
  @PortalID,
  @AddedBy
 )
SET @UserID = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserProfilePicDelete]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserProfilePicDelete]
(
@UserName NVARCHAR(250),
@PortalID INT
)
AS
BEGIN
UPDATE [dbo].[UserDetails]
SET [image]=''
WHERE UserName=@UserName and PortalID=@PortalID   
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SEOSaveRobotsPage]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SEOSaveRobotsPage]
@PortalID INT,
@UserAgent NVARCHAR(50),
@PagePath NVARCHAR(MAX)
AS
BEGIN

INSERT INTO [dbo].[robots] 
(
PortalID,
UserAgent,
PagePAth
)
VALUES
(
@PortalID,
@UserAgent,
@PagePath
)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SEOGetRobots]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SEOGetRobots] 
@PortalID INT
AS
BEGIN   
SELECT PageName,TabPath,SEOName,Description FROM [dbo].[Pages] WHERE PortalID =  @PortalID and Isdeleted =0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SEOGetPages]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SEOGetPages]
AS 
BEGIN
SELECT p.SEOName AS PageName,p.TabPath,pr.SEOName AS PortalName,p.PortalID,p.UpdatedOn,p.AddedOn FROM Pages p 
INNER JOIN PageMenu pm ON p.pageid=pm.pageid
INNER JOIN Portal pr ON pm.PortalID=pr.PortalID AND pm.isadmin=0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SEOGenerateRobots]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SEOGenerateRobots]
@UserAgent NVARCHAR(50)
AS
BEGIN
SELECT PortalID,UserAgent,PagePAth FROM [dbo].[robots] WHERE UserAgent=@UserAgent
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SEODeleteExistingRobots]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SEODeleteExistingRobots]
@PortalID INT
AS
BEGIN
 DELETE FROM [dbo].[robots] WHERE PortalID NOT IN(SELECT PortalID FROM Portal)
 DELETE FROM  [dbo].[robots] WHERE PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchResultPageExists]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchResultPageExists] 
(
@PortalID INT,
@PageName NVARCHAR(250)
)
AS
BEGIN
SELECT COUNT(PageName) FROM Pages p INNER JOIN PageMenu pm ON p.PageID=pm.PageID WHERE p.PortalID=@PortalID AND p.SEOName=@PageName
AND pm.IsAdmin=0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchFormValue]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchFormValue] 
 @FormID INT,
 @FIDs NVARCHAR(250)=null, 
 @FieldIDs NVARCHAR(250), 
 @SearchText varchar(100)=null,
 @CultureCode NVARCHAR(250), 
 @UserModuleID INT,
 @PortalID INT
AS
BEGIN
 DECLARE @FieldValue NVARCHAR(MAX)
SET NOCOUNT ON;
 IF @SearchText IS NOT NULL AND CAST(@FIDs AS INT) = 0 
  BEGIN 
   SELECT F.FormID,F.FormHtml,F.UserModuleID,FF.FieldID,FF.FieldName,FF.ControlType,FF.ControlOrder, FFV.FormSubmittedID,FFV.FormFieldValueID
   ,FFV.FieldSubName,FFV.FieldSubValues 
   FROM Form F RIGHT JOIN FormFields FF ON F.FormID=FF.FormID INNER JOIN FormFieldValue FFV ON FF.FieldID=FFV.FieldID
   WHERE F.FormID=@FormID AND FF.FieldID IN(SELECT items FROM dbo.split(@FieldIDs,',')) AND F.CultureCode=@CultureCode AND F.UserModuleID=@UserModuleID 
   AND FFV.FormSubmittedID=CAST(@SearchText AS INT) AND FFV.PortalID=@PortalID 
   ORDER BY FormSubmittedID,FieldID 
  END
 ELSE IF @SearchText IS NOT NULL AND @FIDs IS NOT NULL
  BEGIN    
   SELECT F.FormID,F.FormHtml,F.UserModuleID,FF.FieldID,FF.FieldName,FF.ControlType,FF.ControlOrder, FFV.FormSubmittedID,FFV.FormFieldValueID,
   FFV.FieldSubName,FFV.FieldSubValues 
   FROM Form F RIGHT JOIN FormFields FF ON F.FormID=FF.FormID INNER JOIN FormFieldValue FFV ON FF.FieldID=FFV.FieldID
   WHERE F.FormID=@FormID AND FF.FieldID IN(SELECT items FROM dbo.split(@FieldIDs,','))  AND F.CultureCode=@CultureCode AND F.UserModuleID=@UserModuleID 
   AND FFV.PortalID=@PortalID AND
   FFV.FormSubmittedID  IN(SELECT DISTINCT(FormSubmittedID) from formfieldvalue WHERE fieldID IN (SELECT items FROM dbo.split(@FIDs,',')) 
   AND LTRIM(FieldSubValues) like '%'+@SearchText+'%')
   ORDER BY FormSubmittedID,FieldID 
  END
 ELSE IF @FIDs IS NULL AND @SearchText IS NOT NULL
  BEGIN 
   SELECT F.FormID,F.FormHtml,F.UserModuleID,FF.FieldID,FF.FieldName,FF.ControlType,FF.ControlOrder, FFV.FormSubmittedID,FFV.FormFieldValueID
   ,FFV.FieldSubName,FFV.FieldSubValues 
   FROM Form F RIGHT JOIN FormFields FF ON F.FormID=FF.FormID INNER JOIN FormFieldValue FFV ON FF.FieldID=FFV.FieldID
   WHERE F.FormID=@FormID AND FF.FieldID IN(SELECT items FROM dbo.split(@FieldIDs,',')) AND F.CultureCode=@CultureCode AND F.UserModuleID=@UserModuleID 
   AND FFV.PortalID=@PortalID AND
   FFV.FormSubmittedID IN (SELECT DISTINCT(FormSubmittedID) from formfieldvalue WHERE FieldSubValues like '%'+@SearchText+'%') 
   ORDER BY FormSubmittedID,FieldID
  END 
 ELSE 
  BEGIN
   SELECT F.FormID,F.FormHtml,F.UserModuleID,FF.FieldID,FF.FieldName,FF.ControlType,FF.ControlOrder, FFV.FormSubmittedID,FFV.FormFieldValueID,
   FFV.FieldSubName,FFV.FieldSubValues 
   FROM Form F RIGHT JOIN FormFields FF ON F.FormID=FF.FormID INNER JOIN FormFieldValue FFV ON FF.FieldID=FFV.FieldID
   WHERE F.FormID=@FormID AND FF.FieldID IN(SELECT items FROM dbo.split(@FieldIDs,',')) AND F.CultureCode=@CultureCode AND F.UserModuleID=@UserModuleID
    AND FFV.PortalID=@PortalID
   ORDER BY FormSubmittedID,FieldID
  END 
END
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheRegisterTableStoredProcedure]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheRegisterTableStoredProcedure] 
             @tableName NVARCHAR(450) 
         AS
         BEGIN

         DECLARE @triggerName AS NVARCHAR(3000) 
         DECLARE @fullTriggerName AS NVARCHAR(3000)
         DECLARE @canonTableName NVARCHAR(3000) 
         DECLARE @quotedTableName NVARCHAR(3000) 

         /* Create the trigger name */ 
         SET @triggerName = REPLACE(@tableName, '[', '__o__') 
         SET @triggerName = REPLACE(@triggerName, ']', '__c__') 
         SET @triggerName = @triggerName + '_AspNet_SqlCacheNotification_Trigger' 
         SET @fullTriggerName = 'dbo.[' + @triggerName + ']' 

         /* Create the cannonicalized table name for trigger creation */ 
         /* Do not touch it if the name contains other delimiters */ 
         IF (CHARINDEX('.', @tableName) <> 0 OR 
             CHARINDEX('[', @tableName) <> 0 OR 
             CHARINDEX(']', @tableName) <> 0) 
             SET @canonTableName = @tableName 
         ELSE 
             SET @canonTableName = '[' + @tableName + ']' 

         /* First make sure the table exists */ 
         IF (SELECT OBJECT_ID(@tableName, 'U')) IS NULL 
         BEGIN 
             RAISERROR ('00000001', 16, 1) 
             RETURN 
         END 

         BEGIN TRAN
         /* Insert the value into the notification table */ 
         IF NOT EXISTS (SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification WITH (NOLOCK) WHERE tableName = @tableName) 
             IF NOT EXISTS (SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification WITH (TABLOCKX) WHERE tableName = @tableName) 
                 INSERT  dbo.AspNet_SqlCacheTablesForChangeNotification 
                 VALUES (@tableName, GETDATE(), 0)

         /* Create the trigger */ 
         SET @quotedTableName = QUOTENAME(@tableName, '''') 
         IF NOT EXISTS (SELECT name FROM sysobjects WITH (NOLOCK) WHERE name = @triggerName AND type = 'TR') 
             IF NOT EXISTS (SELECT name FROM sysobjects WITH (TABLOCKX) WHERE name = @triggerName AND type = 'TR') 
                 EXEC('CREATE TRIGGER ' + @fullTriggerName + ' ON ' + @canonTableName +'
                       FOR INSERT, UPDATE, DELETE AS BEGIN
                       SET NOCOUNT ON
                       EXEC dbo.AspNet_SqlCacheUpdateChangeIdStoredProcedure N' + @quotedTableName + '
                       END
                       ')
         COMMIT TRAN
         END
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCacheQueryRegisteredTablesStoredProcedure]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCacheQueryRegisteredTablesStoredProcedure] 
         AS
         SELECT tableName FROM dbo.AspNet_SqlCacheTablesForChangeNotification
GO
/****** Object:  StoredProcedure [dbo].[AspNet_SqlCachePollingStoredProcedure]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AspNet_SqlCachePollingStoredProcedure] AS
         SELECT tableName, changeId FROM dbo.AspNet_SqlCacheTablesForChangeNotification
         RETURN 0
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionCode] [varchar](50) NOT NULL,
	[PermissionKey] [varchar](50) NOT NULL,
	[PermissionName] [varchar](50) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_BreadCrumbGetFromMenuItem]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[usp_BreadCrumbGetFromMenuItem]'Services',1,0,'ne-NP'
CREATE PROCEDURE [dbo].[usp_BreadCrumbGetFromMenuItem] 
@SEOName NVARCHAR(100),
@PortalID INT,
@MenuID INT,
@CultureCode NVARCHAR(100)
AS
BEGIN
 TRUNCATE TABLE BreadCrumbMenuItem
  DECLARE @ParentId INT,@SubChild NVARCHAR(100),@Final NVARCHAR(256)

 SET @ParentId=(SELECT DISTINCT mi.parentid FROM  dbo.MenuItem mi 
 WHERE (REPLACE(Title,'-','')=REPLACE(@SEOName,'-',' ') or @SEOName=Title)
 AND mi.PortalID=@PortalID  AND (mi.IsDeleted=0 OR mi.IsDeleted is NULL)
 AND mi.IsVisible=1 AND mi.IsActive=1 AND mi.MenuID=@MenuID)

  SELECT @SubChild=Title FROM MenuItem WHERE 
 MenuItemID=@ParentId and PortalID=@PortalID AND(IsDeleted=0 OR IsDeleted is NULL) 
 AND IsVisible=1 AND IsActive=1

 IF((SUBSTRING(@SubChild,1,1))='-')
  BEGIN
   SET @SubChild=REPLACE(@SubChild,'-','')
  END
 SET @SubChild=REPLACE(@SubChild,' ','-')
 IF(@SubChild is not null)
 BEGIN
  EXEC [dbo].[usp_BreadCrumbGetFromMenuItem] @SubChild,@PortalID,@MenuID
 END
  INSERT INTO BreadCrumbMenuItem
  SELECT @SEOName
END
GO
/****** Object:  StoredProcedure [dbo].[usp_BlogRssContentAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_BlogRssContentAdd]
@BlogContent TEXT
AS
BEGIN

 SET NOCOUNT ON;

  BEGIN TRAN
     DELETE FROM dbo.BlogRssContent
     IF(@@error<>0) GOTO ErrorHandler
    
     INSERT INTO dbo.BlogRssContent(BlogContent,UpdatedDate) VALUES(@BlogContent,GETDATE());
     IF(@@error<>0) GOTO ErrorHandler

    COMMIT TRAN
RETURN 0
ERRORHANDLER:
 ROLLBACK TRAN
RETURN 1
    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddUpdatePageMenu]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [usp_AddUpdatePageMenu] 4,1,1,1

CREATE PROC [dbo].[usp_AddUpdatePageMenu] 
 @PageID INT,
 @PortalID INT,
 @IsAdmin BIT,
 @IsFooter BIT
AS
BEGIN

 IF @IsAdmin= 0
  BEGIN
   IF(EXISTS(SELECT 1 FROM [dbo].[PageMenu] WHERE PageID=@PageID))
    UPDATE [dbo].[PageMenu] SET IsAdmin=@IsAdmin,IsFooter=@IsFooter WHERE PageID=@PageID
   ELSE
    INSERT INTO [dbo].[PageMenu]([PageID],[PortalID],[IsAdmin],[IsFooter]) VALUES (@PageID,@PortalID,@IsAdmin,@IsFooter)
  END  
 ELSE
  BEGIN
   DECLARE @totalPortal int 
   DECLARE @count int
   DECLARE @newPortalID int
   DECLARE @portalTable Table(Row int identity(1,1), PId int )
   
   INSERT INTO @portalTable SELECT PortalId FROM Portal     
   SET @totalPortal = @@ROWCOUNT
   
   SET @count = 1
   
   WHILE(@count<=@totalPortal)
    BEGIN
     SELECT  @newPortalID = Pid FROM @portalTable WHERE Row = @Count
     
     IF( EXISTS(SELECT PageID FROM [dbo].[PageMenu] WHERE PageID=@PageID and PortalID = @newPortalID))
      UPDATE [dbo].[PageMenu] SET IsAdmin=@IsAdmin,IsFooter=@IsFooter WHERE PageID=@PageID   
     ELSE
      INSERT INTO [dbo].[PageMenu]([PageID],[PortalID],[IsAdmin],[IsFooter]) VALUES (@PageID,@newPortalID,@IsAdmin,@IsFooter)
     
     SET @count = @count + 1
    END
  END  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddUpdateLocalPage]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_AddUpdateLocalPage]
@PageID INT,
@LocalPageName NVARCHAR(250),
@CultureCode NVARCHAR(50) ,
@LocalPageCaption NVARCHAR(256)
AS
BEGIN
DECLARE @PageName NVARCHAR(250)
SET @PageName=(SELECT PageName FROM Pages WHERE PageID=@PageID)
 IF(EXISTS(SELECT PageID FROM [dbo].[LocalPage] WHERE PageID=@PageID AND CultureCode=@CultureCode))
BEGIN
  UPDATE LocalPage
  SET LocalPageName=@LocalPageName,LocalPageCaption=@LocalPageCaption,PageName=@PageName
  WHERE PageID=@PageID
  AND CultureCode=@CultureCode
 END
ELSE
  BEGIN
   INSERT INTO LocalPage(PageID,LocalPageName,CultureCode,LocalPageCaption,PageName)
   VALUES(@PageID,@LocalPageName,@CultureCode,@LocalPageCaption,@PageName)
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddModulesOrder]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AddModulesOrder]
@ModuleOrder NVARCHAR(100),
@PortelID INT,
@ModuleID NVARCHAR(100),
@ModuleName NVARCHAR(100),
@PaneName NVARCHAR(100),
@UserModuleID int,
@NewModuleID INT OUTPUT
AS
BEGIN
IF @UserModuleID=0
BEGIN
INSERT INTO [dbo].[LayOutMgr](ModuleOrder,PortelID,ModuleID,ModuleName,PaneName)VALUES(@ModuleOrder,@PortelID,@ModuleID,@ModuleName,@PaneName)
SELECT @NewModuleID = SCOPE_IDENTITY()
END
ELSE
BEGIN
UPDATE LayoutMgr
set ModuleOrder=@ModuleOrder,PortelID=@PortelID,PaneName=@PaneName,ModuleName=@ModuleName
where ID=@UserModuleID
SELECT @NewModuleID = @UserModuleID
END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ActivityLogAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_ActivityLogAdd] --'Page Delete', 'superuser', 641, '12/12/2012', 1, 0
 @Action NVARCHAR(MAX),
 @ActivityUserName NVARCHAR(150),
 @ID INT,
 @LogDateTime DATETIME,
 @PortalID INT,
 @UserModuleID INT
AS
BEGIN
 INSERT INTO [dbo].[LogActivity]([Action],ActivityUserName,ID,LogDateTime,PortalID,UserModuleID)
 VALUES(@Action,@ActivityUserName,@ID,@LogDateTime,@PortalID,@UserModuleID ) 
 
 
END
GO
/****** Object:  Table [dbo].[HtmlComment]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HtmlComment](
	[HTMLCommentID] [int] IDENTITY(1,1) NOT NULL,
	[HTMLTextID] [int] NOT NULL,
	[Comment] [ntext] NOT NULL,
	[IsApproved] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[ApprovedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[ApprovedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_HTMLComment] PRIMARY KEY CLUSTERED 
(
	[HTMLCommentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetListParentKey]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetListParentKey]
(
 @ParentID AS int,
 @ListName as nvarchar(50),
 @Type as nvarchar(50),
 @Count as int 
)
RETURNS nvarchar(2000)

AS
 BEGIN
  DECLARE @KeyValue nvarchar(2000)
  DECLARE @ListValue nvarchar(2000)
  DECLARE @TextValue nvarchar(2000)
  DECLARE @ReturnValue nvarchar(2000)
  DECLARE @Key nvarchar(2000)
  
  IF @ParentID = 0
   IF @Count = 0
    SET @ReturnValue = ''
   ELSE
    SET @ReturnValue = @ListName
  ELSE
   BEGIN
    SELECT @KeyValue = ListName + '.' + [Value],
      @TextValue = ListName + '.' + [Text], 
      @ListValue = ListName, 
      @ParentID = ParentID  
     FROM dbo.Lists 
     WHERE EntryID = @ParentID
    If @Type = 'ParentKey' Or (@Type = 'ParentList' AND @Count > 0)
     SET @ReturnValue = @KeyValue
    ELSE 
     IF @Type = 'ParentList'
      SET @ReturnValue = @ListValue
     ELSE
      SET @ReturnValue = @TextValue
    IF @Count > 0
     If @Count = 1 AND @Type = 'ParentList'
      SET @ReturnValue = @ReturnValue + ':' + @ListName
     ELSE
      SET @ReturnValue = @ReturnValue + '.' + @ListName
    SET @ReturnValue = dbo.GetListParentKey(@ParentID, @ReturnValue, @Type, @Count+1)
   END

  RETURN    @ReturnValue
 END
GO
/****** Object:  Table [dbo].[UserPortals]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPortals](
	[UserPortalsID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](256) NULL,
	[PortalID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_UserPortals] PRIMARY KEY CLUSTERED 
(
	[UserPortalsID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetSettingValueBySettingKey]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  DINESH HONA
-- Create date: <Create Date, ,>
-- Description: <Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fn_GetSettingValueBySettingKey]
(
@SettingType nvarchar(100),
@SettingTypeID int,
@SettingKey nvarchar(256)
)
RETURNS nvarchar(256)
AS
BEGIN
 -- Declare the return variable here
 DECLARE @SettingValue nvarchar(256)
 SELECT @SettingValue=Coalesce([dbo].[SettingValue].SettingValue,[dbo].[SettingKey].SettingValue)
 FROM [dbo].[SettingValue]
  INNER JOIN [dbo].[SettingKey] ON [dbo].[SettingValue].SettingKey = [dbo].[SettingKey].SettingKey AND [dbo].[SettingValue].SettingType = [dbo].[SettingKey].SettingType
 WHERE [dbo].[SettingValue].SettingType=@SettingType AND [dbo].[SettingValue].SettingTypeID = @SettingTypeID AND [dbo].[SettingValue].SettingKey=@SettingKey

 RETURN @SettingValue
END
GO
/****** Object:  Table [dbo].[PortalLanguages]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalLanguages](
	[PortalLanguageID] [int] IDENTITY(1,1) NOT NULL,
	[PortalID] [int] NOT NULL,
	[LanguageID] [int] NOT NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[IsPublished] [bit] NOT NULL,
 CONSTRAINT [PK_PortalLanguages] PRIMARY KEY CLUSTERED 
(
	[PortalLanguageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[aspnet_WebEvent_LogEvent]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_WebEvent_LogEvent]
        @EventId         char(32),
        @EventTimeUtc    datetime,
        @EventTime       datetime,
        @EventType       nvarchar(256),
        @EventSequence   decimal(19,0),
        @EventOccurrence decimal(19,0),
        @EventCode       int,
        @EventDetailCode int,
        @Message         nvarchar(1024),
        @ApplicationPath nvarchar(256),
        @ApplicationVirtualPath nvarchar(256),
        @MachineName    nvarchar(256),
        @RequestUrl      nvarchar(1024),
        @ExceptionType   nvarchar(256),
        @Details         ntext
AS
BEGIN
    INSERT
        dbo.aspnet_WebEvent_Events
        (
            EventId,
            EventTimeUtc,
            EventTime,
            EventType,
            EventSequence,
            EventOccurrence,
            EventCode,
            EventDetailCode,
            Message,
            ApplicationPath,
            ApplicationVirtualPath,
            MachineName,
            RequestUrl,
            ExceptionType,
            Details
        )
    VALUES
    (
        @EventId,
        @EventTimeUtc,
        @EventTime,
        @EventType,
        @EventSequence,
        @EventOccurrence,
        @EventCode,
        @EventDetailCode,
        @Message,
        @ApplicationPath,
        @ApplicationVirtualPath,
        @MachineName,
        @RequestUrl,
        @ExceptionType,
        @Details
    )
END
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[LoweredRoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__aspnet_Roles__54B68676] PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE CLUSTERED INDEX [aspnet_Roles_index] ON [dbo].[aspnet_Roles] 
(
	[ApplicationId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PropertyTypeID] [int] NOT NULL,
	[DataType] [nvarchar](15) NULL,
	[IsRequired] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Image]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageExtension] [nvarchar](10) NULL,
	[LargeImagePath] [nvarchar](300) NULL,
	[MediumImagePath] [nvarchar](300) NULL,
	[SmallImagePath] [nvarchar](300) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[aspnet_CheckSchemaVersion]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_CheckSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    IF (EXISTS( SELECT  *
                FROM    dbo.aspnet_SchemaVersions
                WHERE   Feature = LOWER( @Feature ) AND
                        CompatibleSchemaVersion = @CompatibleSchemaVersion ))
        RETURN 0

    RETURN 1
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Applications_CreateApplication]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Applications_CreateApplication]
    @ApplicationName      nvarchar(256),
    @ApplicationId        uniqueidentifier OUTPUT
AS
BEGIN
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName

    IF(@ApplicationId IS NULL)
    BEGIN
        DECLARE @TranStarted   bit
        SET @TranStarted = 0

        IF( @@TRANCOUNT = 0 )
        BEGIN
         BEGIN TRANSACTION
         SET @TranStarted = 1
        END
        ELSE
         SET @TranStarted = 0

        SELECT  @ApplicationId = ApplicationId
        FROM dbo.aspnet_Applications WITH (UPDLOCK, HOLDLOCK)
        WHERE LOWER(@ApplicationName) = LoweredApplicationName

        IF(@ApplicationId IS NULL)
        BEGIN
            SELECT  @ApplicationId = NEWID()
            INSERT  dbo.aspnet_Applications (ApplicationId, ApplicationName, LoweredApplicationName)
            VALUES  (@ApplicationId, @ApplicationName, LOWER(@ApplicationName))
        END


        IF( @TranStarted = 1 )
        BEGIN
            IF(@@ERROR = 0)
            BEGIN
         SET @TranStarted = 0
         COMMIT TRANSACTION
            END
            ELSE
            BEGIN
                SET @TranStarted = 0
                ROLLBACK TRANSACTION
            END
        END
    END
END
GO
/****** Object:  Table [dbo].[ScheduleWeek]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleWeek](
	[ScheduleID] [int] NOT NULL,
	[WeekDayID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ScheduleWeek] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[ScheduleMonth]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleMonth](
	[ScheduleID] [int] NOT NULL,
	[MonthID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ScheduleMonth] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[ScheduleHistory]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleHistory](
	[ScheduleHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[Status] [bit] NULL,
	[ReturnText] [ntext] NULL,
	[NextStart] [datetime] NULL,
	[Server] [varchar](150) NULL,
 CONSTRAINT [PK_ScheduleHistory] PRIMARY KEY CLUSTERED 
(
	[ScheduleHistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[ScheduleDay]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleDay](
	[ScheduleID] [int] NOT NULL,
	[DayID] [int] NOT NULL,
 CONSTRAINT [PK_ScheduleDay] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC,
	[DayID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_Users__25FB978D] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE CLUSTERED INDEX [aspnet_Users] ON [dbo].[aspnet_Users] 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [aspnet_Users_Index2] ON [dbo].[aspnet_Users] 
(
	[ApplicationId] ASC,
	[LastActivityDate] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[Modules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modules](
	[ModuleID] [int] IDENTITY(1,1) NOT NULL,
	[FriendlyName] [nvarchar](128) NULL,
	[Description] [nvarchar](2000) NULL,
	[Version] [nvarchar](8) NULL,
	[IsPremium] [bit] NULL,
	[IsAdmin] [bit] NULL,
	[IsRequired] [bit] NULL,
	[BusinessControllerClass] [nvarchar](200) NULL,
	[FolderName] [nvarchar](128) NULL,
	[ModuleName] [nvarchar](128) NULL,
	[SupportedFeatures] [int] NULL,
	[CompatibleVersions] [nvarchar](500) NULL,
	[Dependencies] [nvarchar](400) NULL,
	[Permissions] [nvarchar](400) NULL,
	[PackageID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_DesktopModule] PRIMARY KEY CLUSTERED 
(
	[ModuleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_CreateUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[aspnet_Users_CreateUser]
    @ApplicationId    uniqueidentifier,
    @UserName         nvarchar(256),
    @IsUserAnonymous  bit,
    @LastActivityDate DATETIME,
    @UserId           uniqueidentifier OUTPUT
AS
BEGIN
    IF( @UserId IS NULL )
        SELECT @UserId = NEWID()
    ELSE
    BEGIN
        IF( EXISTS( SELECT UserId FROM dbo.aspnet_Users
                    WHERE @UserId = UserId ) )
            RETURN -1
    END

    INSERT dbo.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
    VALUES (@ApplicationId, @UserId, @UserName, LOWER(@UserName), @IsUserAnonymous, @LastActivityDate)

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ContactUsGetAll]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-06-03
-- Description:  ContactUs Module
-- =============================================  
CREATE PROCEDURE [dbo].[sp_ContactUsGetAll] @PortalID INT
AS
  BEGIN
      SELECT [contactusid],
             [name],
             [email],
             [message],
             [isactive],
             [isdeleted],
             [ismodified],
             [addedon],
             [updatedon],
             [deletedon],
             [portalid],
             [addedby],
             [updatedby],
             [deletedby]
      FROM   dbo.[contactus]
      WHERE  [portalid] = @PortalID
             AND ( [isdeleted] = 0
                    OR [isdeleted] IS NULL )
             AND [isactive] = 1
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_ContactUsDeletebyID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-06-03
-- Description:  ContactUs Module
-- =============================================    
CREATE PROCEDURE [dbo].[sp_ContactUsDeletebyID] @ContactUsID INT,
                                               @PortalID    INT,
                                               @DeletedBy   NVARCHAR(256)
AS
  BEGIN
      UPDATE [dbo].contactus
      SET    [isdeleted] = 1,
             [deletedon] = GETDATE(),
             [deletedby] = @DeletedBy
      WHERE  [contactusid] = @ContactUsID
             AND portalid = @PortalID
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_ContactUsAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-06-02
-- Description:  ContactUs Module
-- =============================================  
CREATE PROCEDURE [dbo].[sp_ContactUsAdd] 
                                        @Name        NVARCHAR(256),
                                        @Email       NVARCHAR(256),
                                        @Message     NVARCHAR(4000),
                                        @IsActive    BIT,
                                        @PortalID    INT,
                                        @AddedBy     NVARCHAR(256)
AS
  BEGIN
      INSERT INTO dbo.contactus
                  ([name],
                   [email],
                   [message],
                   [isactive],
                   [addedon],
                   [portalid],
                   [addedby])
      VALUES      ( @Name,
                    @Email,
                    @Message,
                    @IsActive,
                    GETDATE(),
                    @PortalID,
                    @AddedBy )
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetFolderPermission]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerGetFolderPermission]
(
@FolderID INT
)
AS
BEGIN
SELECT fp.FolderPermissionID,
       fp.FolderID,
       fp.PermissionID,
       (SELECT Username FROM Users WHERE UserID=fp.UserID) AS UserName,
  fp.UserID,
       fp.RoleID,
    p.PermissionKey,
       fp.IsActive,
       fp.IsDeleted,
       fp.IsModified,
       fp.AddedOn,
       fp.UpdatedOn,
       fp.DeletedOn,
       fp.AddedBy,
       fp.UpdatedBy,
       fp.DeletedBy
  FROM [dbo].[FolderPermission] fp
  INNER JOIN Permission p
   ON fp.PermissionID = p.PermissionID
 WHERE FolderID=@FolderID
END;
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserProfileID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](256) NOT NULL,
	[ProfileID] [int] NOT NULL,
	[Value] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[UserProfileID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[ProfileValue]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileValue](
	[ProfileValueID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileID] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_ProfileValue] PRIMARY KEY CLUSTERED 
(
	[ProfileValueID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Membership](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
	[Comment] [ntext] NULL,
 CONSTRAINT [PK__aspnet_Membershi__3631FF56] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE CLUSTERED INDEX [aspnet_Membership_index] ON [dbo].[aspnet_Membership] 
(
	[ApplicationId] ASC,
	[LoweredEmail] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [ntext] NOT NULL,
	[PropertyValuesString] [ntext] NOT NULL,
	[PropertyValuesBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_Profile__4B2D1C3C] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser](
	[Id] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_Personali__705EA0EB] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE UNIQUE CLUSTERED INDEX [aspnet_PersonalizationPerUser_index1] ON [dbo].[aspnet_PersonalizationPerUser] 
(
	[PathId] ASC,
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE UNIQUE NONCLUSTERED INDEX [aspnet_PersonalizationPerUser_ncindex2] ON [dbo].[aspnet_PersonalizationPerUser] 
(
	[UserId] ASC,
	[PathId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers](
	[PathId] [uniqueidentifier] NOT NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_Personali__6D823440] PRIMARY KEY CLUSTERED 
(
	[PathId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Paths_CreatePath]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Paths_CreatePath]
    @ApplicationId UNIQUEIDENTIFIER,
    @Path           NVARCHAR(256),
    @PathId         UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    BEGIN TRANSACTION
    IF (NOT EXISTS(SELECT * FROM dbo.aspnet_Paths WHERE LoweredPath = LOWER(@Path) AND ApplicationId = @ApplicationId))
    BEGIN
        INSERT dbo.aspnet_Paths (ApplicationId, Path, LoweredPath) VALUES (@ApplicationId, @Path, LOWER(@Path))
    END
    COMMIT TRANSACTION
    SELECT @PathId = PathId FROM dbo.aspnet_Paths WHERE LOWER(@Path) = LoweredPath AND ApplicationId = @ApplicationId
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_CreateRole]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_CreateRole]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF (EXISTS(SELECT RoleId FROM dbo.aspnet_Roles WHERE LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId))
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    INSERT INTO dbo.aspnet_Roles
                (ApplicationId, RoleName, LoweredRoleName)
         VALUES (@ApplicationId, @RoleName, LOWER(@RoleName))

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END

    RETURN(0)

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_RoleExists]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_RoleExists]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(0)
    IF (EXISTS (SELECT RoleName FROM dbo.aspnet_Roles WHERE LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId ))
        RETURN(1)
    ELSE
        RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_GetAllRoles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_GetAllRoles] (
    @ApplicationName           nvarchar(256))
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN
    SELECT RoleName
    FROM   dbo.aspnet_Roles WHERE ApplicationId = @ApplicationId
    ORDER BY RoleName
END
GO
/****** Object:  StoredProcedure [dbo].[usp_sf_CreateRole]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_sf_CreateRole]
    @ApplicationName  NVARCHAR(256),
    @RoleName         NVARCHAR(256) ,
 @PortalID    INT, 
 @IsActive    BIT,
 @AddedOn    DATETIME,
 @AddedBy          NVARCHAR(256),
 @ErrorCode    INT OUTPUT
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    SELECT  @ApplicationId = NULL   

    DECLARE @TranStarted   BIT
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END
 DECLARE @DUP_ROLE_KEY NVARCHAR(100)
 SET @DUP_ROLE_KEY='DUPLICATE_ROLES_ACROSS_PORTALS'
 
 DECLARE @AllowDuplicateRoles INT
 SELECT @AllowDuplicateRoles=CAST(SettingValue AS INT) FROM MembershipSettings 
 WHERE SettingKey=@DUP_ROLE_KEY

 IF @AllowDuplicateRoles=0
 BEGIN
    IF (EXISTS(SELECT RoleId FROM dbo.aspnet_Roles WHERE LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId))
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END
 END
 ELSE IF @AllowDuplicateRoles=1
 BEGIN
 IF(EXISTS(SELECT ar.RoleID FROM dbo.PortalRole pr INNER JOIN dbo.aspnet_Roles ar ON pr.RoleID=ar.RoleID WHERE ar.LoweredRoleName=LOWER(@RoleName) 
 AND pr.PortalID=@PortalID))
 BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END
 END
    INSERT INTO dbo.aspnet_Roles
                (ApplicationId, RoleName, LoweredRoleName)
         VALUES (@ApplicationId, @RoleName, LOWER(@RoleName))

 DECLARE @NewRoleID INT
 SET @NewRoleID=@@IDENTITY
    DECLARE @NewRoleGUID UNIQUEIDENTIFIER
 SELECT @NewRoleGUID=RoleID FROM dbo.aspnet_Roles WHERE ID=@NewRoleID
 --add the role to PortalRole table
 EXEC usp_PortalRoleAdd @PortalID,@NewRoleGUID,@IsActive,@AddedOn,@AddedBy

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END

    RETURN(0)

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
set ANSI_NULLS ON
set QUOTED_IDENTIFIER OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_MessageTemplateTokenAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MessageTemplateTokenAdd]
 @MessageTokenID [int]  OUTPUT,
 @MessageTemplateTypeID [int],
 @Name [nvarchar](200),
 @IsActive [bit],
 @AddedOn [datetime],
 @PortalID [int],
 @AddedBy nvarchar(256)
WITH EXECUTE AS CALLER
AS
IF(Not Exists(SELECT MessageTokenID from [dbo].[MessageToken] where MessageTokenKey=@Name))
BEGIN
 INSERT INTO [dbo].[MessageToken] (
  [MessageTokenKey],
  [MessageTokenName],
  [IsActive],
  [AddedOn],
  [PortalID],
  [AddedBy]
 ) VALUES (
  @Name,
  @Name,
  @IsActive,
  @AddedOn,
  @PortalID,
  @AddedBy
 )
 SET @MessageTokenID = @@IDENTITY
END
ELSE
 BEGIN
  SET @MessageTokenID=(SELECT MessageTokenID from [dbo].[MessageToken] where MessageTokenKey=@Name)
 END 
INSERT INTO [dbo].[MessageTemplateTypeToken]
(
 MessageTemplateTypeID,MessageTokenID,IsActive,AddedOn,PortalID,AddedBy
)
VALUES
(
 @MessageTemplateTypeID,@MessageTokenID,@IsActive,@AddedOn,@PortalID,@AddedBy
)
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleWeekGetNextWeek]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleWeekGetNextWeek]
@ScheduleId INT,
@CurrentWeeknum INT

AS 
BEGIN
DECLARE @LargeWeeknum INT
SELECT  @LargeWeeknum =MAX(WeekDayID) FROM ScheduleWeek WHERE ScheduleID=@ScheduleId

IF @LargeWeeknum >0
BEGIN
   if @CurrentWeeknum>=@LargeWeeknum
  BEGIN   
   SELECT MIN(WeekDayID) AS weekDay FROM ScheduleWeek WHERE ScheduleID=@ScheduleId
   END
   ELSE IF @CurrentWeeknum<@LargeWeeknum
   BEGIN
          SELECT MIN(WeekDayID) AS weekDay FROM ScheduleWeek WHERE  WeekDayID>@CurrentWeeknum AND 
                ScheduleID=@ScheduleId
   END
END 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleWeekAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleWeekAdd]
@ScheduleID INT,
@Weeks NVARCHAR(50)
AS
BEGIN
 INSERT INTO dbo.ScheduleWeek(ScheduleID, WeekDayID)          
 SELECT @ScheduleID, items FROM dbo.split(@Weeks,',')
END
GO
/****** Object:  StoredProcedure [dbo].[usp_loc_PortalLanguagesGet]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_loc_PortalLanguagesGet]
(
@PortalID INT
)
AS
BEGIN
SELECT pl.PortalID,pl.LanguageID,l.CultureCode,l.CultureName,l.LanguageID 
FROM portallanguages pl
INNER JOIN Languages l ON pl.LanguageID=l.LanguageID
WHERE pl.PortalID=@PortalID OR l.CultureCode='en-US'
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_loc_EnableLanguage]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_loc_EnableLanguage]
(
 @PortalID INT,
 @LanguageID INT,
 @AddedBy VARCHAR(256),
 @IsEnabled BIT,
 @IsPublished BIT
)
AS
BEGIN
DECLARE @EXISTS INT
SELECT @EXISTS=COUNT(*) FROM PortalLanguages 
WHERE PortalID=@PortalID AND LanguageID=@LanguageID
IF @EXISTS>0
  DELETE FROM PortalLanguages
  WHERE PortalID=@PortalID AND LanguageID=@LanguageID;
ELSE 
 INSERT INTO PortalLanguages
 (
  PortalID,LanguageID,AddedOn,AddedBy 
 )
 VALUES
 (
  @PortalID,@LanguageID,GETDATE(),@AddedBy
 )
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_GetScheduleDates]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetScheduleDates]
 @ScheduleID INT
AS
BEGIN

SET NOCOUNT ON;
  SELECT * FROM dbo.ScheduleDate WHERE ScheduleID=@ScheduleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSageFramePortalList]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetSageFramePortalList]
AS
BEGIN
SELECT pr.PortalID, ar.RoleName
FROM dbo.PortalRole pr
INNER JOIN dbo.aspnet_roles ar
ON pr.RoleID=ar.RoleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetModuleInformation]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetModuleInformation]
@FriendlyName NVARCHAR(128) 
AS
BEGIN
SELECT ModuleName,[Description],[Version],* FROM Modules WHERE FriendlyName = @FriendlyName 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SchedulesGetCurrent]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SchedulesGetCurrent]
AS
BEGIN
SELECT 
s.[ScheduleID]
      ,s.[ScheduleName]
      ,s.[FullNamespace]
      ,s.[StartDate]
      ,s.[EndDate]
      ,s.[StartHour]
      ,s.[StartMin]
      ,s.[RepeatWeeks]
      ,s.[RepeatDAYs]
      ,s.[WeekOfMonth]
      ,s.[EveryHours]
      ,s.[EveryMin]
      ,s.[ObjectDependencies]
      ,s.[RetryTimeLapse]
      ,s.[RetryFrequencyUnit]
      ,s.[AttachToEvent]
      ,s.[CatchUpEnabled]
      ,s.[Servers]
      ,s.[CreatedByUserID]
      ,s.[CreatedOnDate]
      ,s.[LAStModifiedbyUserID]
      ,s.[LAStModifiedDate]
,s.RunningMode
,s.[IsEnable]
,
  MAX(v.ScheduleHistoryID)AS ScheduleHistoryID
      ,MAX(v.NextStart) AS NextStart
,MAX(v.StartDate) AS HistoryStartDate,
MAX(v.EndDate) AS HistoryEndDate
  FROM [dbo].[Schedule] s LEFT JOIN  [dbo].[ScheduleHistory] v ON s.ScheduleID=v.ScheduleID
 WHERE  s.[ScheduleID] IN(
 SELECT ss.[ScheduleID]
 FROM Schedule ss 
  INNER JOIN ScheduleHistory h ON ss.ScheduleId = h.ScheduleId
 WHERE ss.RunningMode = 0
  AND GETDATE() BETWEEN DATEADD(Hour, ss.StartHour, DATEADD(minute, ss.StartMin, ss.StartDate)) AND COALESCE(ss.EndDate,'12/12/2090') 
  AND (h.NextStart IS NULL OR DATEDIFF(minute, h.NextStart, GETDATE()) >= (EveryHours*60) + EveryMin)

UNION ALL
 
 SELECT ss.[ScheduleID]
 FROM Schedule ss 
  INNER JOIN ScheduleHistory h ON ss.ScheduleId = h.ScheduleId
 WHERE ss.RunningMode  = 1
  AND GETDATE() BETWEEN ss.StartDate AND COALESCE(ss.EndDate,'12/12/2078') 
  AND (h.EndDate IS NULL OR   ss.RepeatDAYs<DATEDIFF(DAY, h.EndDate, GETDATE()))
  AND (ss.StartHour*60) + ss.StartMin = (DATEPART(hour,GETDATE())*60) + DATEPART(minute,GETDATE())
 
 UNION ALL
 
 SELECT ss.[ScheduleID]
 FROM Schedule ss 
  INNER JOIN ScheduleHistory h ON ss.ScheduleId = h.ScheduleId
  INNER JOIN ScheduleWeek w ON w.ScheduleId = h.ScheduleId
 WHERE ss.RunningMode=2
  AND GETDATE() BETWEEN ss.StartDate AND COALESCE(ss.EndDate,'12/12/2078') 
  AND DATEPART (weekDAY , GETDATE()) = w.WeekDAYId
  AND ((ss.StartHour*60) + ss.StartMin) <= (DATEPART(hour,GETDATE())*60) + DATEPART(minute,GETDATE()) 
  AND (h.NextStart IS NULL OR DATEDIFF(DAY,h.NextStart, GETDATE()) > 0) --weekly
 
 UNION ALL
 
 
 SELECT ss.[ScheduleID]
 FROM Schedule ss 
  INNER JOIN ScheduleHistory h ON ss.ScheduleId = h.ScheduleId
  INNER JOIN ScheduleWeek w ON w.ScheduleId = h.ScheduleId
  INNER JOIN ScheduleMonth m ON m.ScheduleId = h.ScheduleId
 WHERE ss.RunningMode =3
  AND GETDATE() BETWEEN s.StartDate AND COALESCE(s.EndDate,'12/12/2078') 
  AND w.WeekDAYId = DATEPART (weekDAY , GETDATE())
  AND m.MonthId = DATEPART (month , GETDATE())
  AND ss.WeekOfMonth = (DATEPART(ww,GETDATE())) + 1 - DATEPART(ww,DATEADD(dd,-(DATEPART(dd,GETDATE())-1),GETDATE()))
  AND ((ss.StartHour*60) + ss.StartMin) <= (DATEPART(hour,GETDATE())*60) + DATEPART(minute,GETDATE()) 
  AND (h.NextStart IS NULL OR DATEDIFF(DAY, h.NextStart, GETDATE()) > 0) -- weeknumber
 UNION ALL
 
 SELECT ss.[ScheduleID]
 FROM Schedule ss 
  INNER JOIN ScheduleHistory h ON ss.ScheduleId = h.ScheduleId
  INNER JOIN ScheduleDate m ON m.ScheduleId = h.ScheduleId
  
 WHERE ss.RunningMode =4
  AND GETDATE() BETWEEN ss.StartDate AND COALESCE(ss.EndDate,'12/12/2078') 
  AND DATEADD(hh, 12, DATEDIFF(D, 0, GETDATE())) = m.Schedule_Date
        AND m.IsExecuted=0
     AND ((ss.StartHour*60) + ss.StartMin) <= (DATEPART(hour,GETDATE())*60) + DATEPART(minute,GETDATE()) 
  AND (h.NextStart IS NULL OR DATEDIFF(DAY,h.NextStart, GETDATE()) > 0) -- calendar
 
 UNION
 
 SELECT ss.[ScheduleID]
 FROM Schedule ss 
  INNER JOIN ScheduleHistory h ON ss.ScheduleId = h.ScheduleId
 WHERE ss.RunningMode= 5
  AND GETDATE() >=ss.StartDate  
  AND ((ss.StartHour*60) + ss.StartMin) <= (DATEPART(hour,GETDATE())*60) + DATEPART(minute,GETDATE()) 
  AND (h.NextStart IS NULL)  -- run once

)
GROUP BY s.[ScheduleID]
      ,s.[ScheduleName]
      ,s.[FullNamespace]
      ,s.[StartDate]
      ,s.[EndDate]
      ,s.[StartHour]
      ,s.[StartMin]
      ,s.[RepeatWeeks]
      ,s.[RepeatDAYs]
      ,s.[WeekOfMonth]
      ,s.[EveryHours]
      ,s.[EveryMin]
      ,s.[ObjectDependencies]
      ,s.[RetryTimeLapse]
      ,s.[RetryFrequencyUnit]
      ,s.[AttachToEvent]
      ,s.[CatchUpEnabled]
      ,s.[Servers]
      ,s.[CreatedByUserID]
      ,s.[CreatedOnDate]
      ,s.[LAStModifiedbyUserID]
      ,s.[LAStModifiedDate]
,s.[IsEnable]
,s.RunningMode

END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleRepeatOptionsDelete]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleRepeatOptionsDelete]
@ScheduleID INT
AS
BEGIN
DELETE FROM dbo.ScheduleDate WHERE ScheduleID=@ScheduleID
DELETE FROM dbo.ScheduleDay  WHERE ScheduleID=@ScheduleID
DELETE FROM dbo.ScheduleMonth  WHERE ScheduleID=@ScheduleID  
DELETE FROM dbo.ScheduleWeek  WHERE ScheduleID=@ScheduleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleGetAllActive]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[usp_ScheduleGetAll] 1,10
CREATE PROCEDURE [dbo].[usp_ScheduleGetAllActive]
@offset INT,
@limit INT
AS
BEGIN
DECLARE @RowTotal INT
SELECT @RowTotal= COUNT(*) 
  FROM [dbo].[Schedule] 
DECLARE @tbltemp TABLE
(
RowNumber INT IDENTITY(1,1),
ScheduleID INT,
ScheduleName NVARCHAR(200),
FullNameSpace NVARCHAR(200),
StartDate SMALLDATETIME,
EndDate SMALLDATETIME,
StartHour SMALLINT,
StartMin SMALLINT,
RepeatWeeks SMALLINT,
RepeatDays INT,
WeekOfMonth INT,
EveryHours INT,
EveryMin SMALLINT,
ObjectDependencies NVARCHAR(300),
RetryTimeLapse INT,
RetryFrequencyUnit INT,
AttachToEvent NVARCHAR(50),
CatchUpEnabled bit,
Servers NVARCHAR(250),
CreatedByUserID NVARCHAR(50),
CreatedOnDate datetime,
LAStModifiedbyUserID INT,
LAStModifiedDate datetime,
IsEnable BIT,
ScheduleHistoryID INT,
NextStart datetime,
HistoryStartDate SMALLDATETIME,
HistoryEndDate SMALLDATETIME,
RunningMode INT,
RowTotal INT
)
INSERT INTO @tbltemp
SELECT 
s.[ScheduleID]
      ,s.[ScheduleName]
      ,s.[FullNamespace]
      ,s.[StartDate]
      ,s.[EndDate]
      ,s.[StartHour]
      ,s.[StartMin]
      ,s.[RepeatWeeks]
      ,s.[RepeatDays]
      ,s.[WeekOfMonth]
      ,s.[EveryHours]
      ,s.[EveryMin]
      ,s.[ObjectDependencies]
      ,s.[RetryTimeLapse]
      ,s.[RetryFrequencyUnit]
      ,s.[AttachToEvent]
      ,s.[CatchUpEnabled]
      ,s.[Servers]
      ,s.[CreatedByUserID]
      ,s.[CreatedOnDate]
      ,s.[LAStModifiedbyUserID]
      ,s.[LAStModifiedDate]
,s.[IsEnable]
,
  MAX(v.ScheduleHistoryID)AS ScheduleHistoryID
      ,MAX(v.NextStart) AS NextStart
,MAX(v.StartDate) AS HistoryStartDate,
MAX(v.EndDate) AS HistoryEndDate,
s.[RunningMode],
@RowTotal
  FROM [dbo].[Schedule] s LEFT JOIN  [dbo].[ScheduleHistory] v ON s.ScheduleID=v.ScheduleID
WHERE s.IsEnable=1
 
GROUP BY s.[ScheduleID]
      ,s.[ScheduleName]
      ,s.[FullNamespace]
      ,s.[StartDate]
      ,s.[EndDate]
      ,s.[StartHour]
      ,s.[StartMin]
      ,s.[RepeatWeeks]
      ,s.[RepeatDays]
      ,s.[WeekOfMonth]
      ,s.[EveryHours]
      ,s.[EveryMin]
      ,s.[ObjectDependencies]
      ,s.[RetryTimeLapse]
      ,s.[RetryFrequencyUnit]
      ,s.[AttachToEvent]
      ,s.[CatchUpEnabled]
      ,s.[Servers]
      ,s.[CreatedByUserID]
      ,s.[CreatedOnDate]
      ,s.[LAStModifiedbyUserID]
      ,s.[LAStModifiedDate]
,s.[IsEnable]
,s.[RunningMode]

ORDER BY s.ScheduleID DESC
SELECT
RowTotal ,
ScheduleID ,
ScheduleName ,
FullNameSpace ,
StartDate ,
EndDate ,
StartHour ,
StartMin ,
RepeatWeeks ,
RepeatDays ,
WeekOfMonth ,
EveryHours ,
EveryMin ,
ObjectDependencies ,
RetryTimeLapse ,
RetryFrequencyUnit ,
AttachToEvent ,
CatchUpEnabled ,
Servers ,
CreatedByUserID ,
CreatedOnDate ,
LAStModifiedbyUserID ,
LAStModifiedDate,
IsEnable ,
ScheduleHistoryID ,
NextStart ,
HistoryStartDate ,
HistoryEndDate ,
RunningMode,
 RowNumber
FROM @tbltemp WHERE RowNumber >= @offset
AND RowNumber <= (@offset + @limit - 1)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleGetAll]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleGetAll]
@offset INT,
@limit INT
AS
BEGIN
DECLARE @RowTotal INT
SELECT @RowTotal= count(*)   FROM [dbo].[Schedule] ;
WITH scheduleTmp AS
(
SELECT  @RowTotal AS RowTotal,*,ROW_NUMBER() OVER(ORDER BY ScheduleID DESC) AS RowNum
FROM
(SELECT s.[ScheduleID] AS ScheduleID
      ,s.[ScheduleName]
      ,s.[FullNamespace]
      ,s.[StartDate]
      ,s.[EndDate]
      ,s.[StartHour]
      ,s.[StartMin]
      ,s.[RepeatWeeks]
      ,s.[RepeatDays]
      ,s.[WeekOfMonth]
      ,s.[EveryHours]
      ,s.[EveryMin]
      ,s.[ObjectDependencies]
      ,s.[RetryTimeLapse]
      ,s.[RetryFrequencyUnit]
      ,s.[AttachToEvent]
      ,s.[CatchUpEnabled]
      ,s.[Servers]
 ,s.[ASsemblyFileName]
      ,s.[CreatedByUserID]
      ,s.[CreatedOnDate]
      ,s.[LAStModifiedbyUserID]
      ,s.[LAStModifiedDate]
,s.[IsEnable]
, MAX(v.ScheduleHistoryID) AS ScheduleHistoryID
 , (SELECT NextStart FROM [dbo].[ScheduleHistory]
          WHERE ScheduleHistoryID=MAX(v.ScheduleHistoryID))
         AS NextStart
,MAX(v.StartDate) AS HistoryStartDate,
MAX(v.EndDate) AS HistoryEndDate,
s.[RunningMode]
  FROM [dbo].[Schedule] s LEFT JOIN  [dbo].[ScheduleHistory] v ON s.ScheduleID=v.ScheduleID 

GROUP BY s.[ScheduleID]
      ,s.[ScheduleName]
      ,s.[FullNamespace]
      ,s.[StartDate]
      ,s.[EndDate]
      ,s.[StartHour]
      ,s.[StartMin]
      ,s.[RepeatWeeks]
      ,s.[RepeatDays]
      ,s.[WeekOfMonth]
      ,s.[EveryHours]
      ,s.[EveryMin]
      ,s.[ObjectDependencies]
      ,s.[RetryTimeLapse]
      ,s.[RetryFrequencyUnit]
      ,s.[AttachToEvent]
      ,s.[CatchUpEnabled]
      ,s.[Servers]
      ,s.[CreatedByUserID]
      ,s.[CreatedOnDate]
  ,s.[ASsemblyFileName]
      ,s.[LAStModifiedbyUserID]
      ,s.[LAStModifiedDate]
 ,s.[IsEnable],s.[RunningMode] )DataTable

)

SELECT * from scheduleTmp WHERE RowNum>= @offset
AND RowNum <= (@offset + @limit - 1)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleDeleteTask]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleDeleteTask]
(
@ScheduleID INT
)
AS
BEGIN
SET NOCOUNT ON;
DELETE FROM ScheduleWeek WHERE  ScheduleID=@ScheduleID
DELETE FROM ScheduleDay WHERE  ScheduleID=@ScheduleID
DELETE FROM ScheduleDate WHERE  ScheduleID=@ScheduleID
DELETE FROM ScheduleMonth WHERE  ScheduleID=@ScheduleID
DELETE FROM ScheduleHistory WHERE  ScheduleID=@ScheduleID
DELETE FROM Schedule WHERE ScheduleID=@ScheduleID
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleDayAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleDayAdd]
@ScheduleID INT,
@DayIds  NVARCHAR(50)
AS
BEGIN
 INSERT INTO ScheduleDay(ScheduleID,DayID)
 SELECT @ScheduleID, items FROM dbo.split(@DayIds,',')
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleDateGetNextMonth]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleDateGetNextMonth] 
@ScheduleID INT,
@NextMonth NVARCHAR(10)
AS 
BEGIN
 SELECT MIN(MonthID) AS NextMonth FROM ScheduleMonth WHERE MonthID>DATEPART(M,CAST(@NextMonth AS DATETIME )) AND ScheduleID=@ScheduleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleDateGetNextCalendarDate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleDateGetNextCalendarDate] 
@ScheduleID INT,
@CurrentCalendarDate NVARCHAR(10)
AS 
BEGIN
SELECT Min(Schedule_Date) AS ScheduleDate FROM ScheduleDate WHERE Schedule_Date>CONVERT(DATETIME,@CurrentCalendarDate,101) AND ScheduleID=@ScheduleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleDateAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleDateAdd]
@ScheduleID INT,
@Dates NVARCHAR(50)
AS
BEGIN
INSERT INTO dbo.ScheduleDate(ScheduleID, Schedule_Date)
SELECT @ScheduleID, items FROM dbo.split(@Dates,',') 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleMonthAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ScheduleMonthAdd]
@ScheduleID INT,
@Months NVARCHAR(50)
AS
BEGIN
 INSERT INTO dbo.ScheduleMonth(ScheduleID, MonthID)     
 SELECT @ScheduleID, items FROM dbo.split(@Months ,',')
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleHistoryUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleHistoryUpdate]
(
 @ScheduleID INT,
 @ScheduleHistoryID INT,
 @StartDate DATETIME,
 @EndDate DATETIME,
 @Status BIT,
 @ReturnText NTEXT,
 @NextStart DATETIME,
 @Server NVARCHAR(150)
)
AS
BEGIN
SET NOCOUNT ON;
UPDATE ScheduleHistory
SET ScheduleID=@ScheduleID,
  StartDate=@StartDate,
  EndDate=@EndDate,
  Status=@Status,
  ReturnText=@ReturnText,
  NextStart=@NextStart
WHERE ScheduleHistoryID=@ScheduleHistoryID
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleHistoryRetrieve]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleHistoryRetrieve]
(
 @ScheduleID INT 
)
AS
BEGIN

DECLARE @ScheduleHistoryID INT
SELECT @ScheduleHistoryID=MAX(ScheduleHistoryID) FROM dbo.ScheduleHistory WHERE ScheduleID=@ScheduleID
  
IF(@ScheduleHistoryID IS NOT NULL)
BEGIN
 SELECT 
    h.[ScheduleHistoryID]
    ,h.[ScheduleID]      
    ,h.[StartDate]
    ,h.[EndDate]
    ,h.[Status]
    ,h.[ReturnText]
    ,h.[NextStart]
    ,h.[Server]
    ,s.RunningMode
   ,s.EveryHours
   ,s.EveryMin 
   ,s.StartMin
   ,s.StartHour
  ,s.StartDate
  ,s.RepeatWeeks
  ,s.RepeatDays
   FROM [dbo].[ScheduleHistory] h INNER JOIN dbo.Schedule s
  on s.ScheduleID=h.ScheduleID
 WHERE ScheduleHistoryID=@ScheduleHistoryID
END
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleHistoryNextStartUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <ROSHAN GHIMIRE>
-- Create date: <2011/08/26>
-- Description: <Description,,>

CREATE PROCEDURE [dbo].[usp_ScheduleHistoryNextStartUpdate] 
(
@ScheduleID INT ,
@ResultNextStart DATETIME OUTPUT
)
AS
BEGIN
 SET NOCOUNT ON;
 DECLARE @ScheduleHistoryID INT
 DECLARE @WeekDAY INT,@CurrentWeeknum INT, @LargeWeeknum INT,@NextDAY INT, @CurrentStartDAY INT
 SELECT @ScheduleHistoryID=MAX(ScheduleHistoryID) FROM dbo.ScheduleHistory WHERE ScheduleID=@ScheduleID
   
 DECLARE @RunningMode INT,@StartDate DATETIME,@NextStart DATETIME,@HistoryStartDate DATETIME,
    @StartHour INT,@StartMIN INT,@EveryHours INT,@EveryMIN INT,@RepeatDAYs INT, @RepeatWeek INT


 IF(@ScheduleHistoryID IS NOT NULL)
  BEGIN
   SELECT   
    @NextStart=h.[NextStart]   
    ,@RunningMode=s.RunningMode
    ,@EveryHours=s.EveryHours
    ,@EveryMIN=s.EveryMIN 
    ,@StartMIN=s.StartMIN
    ,@StartHour=s.StartHour
    ,@StartDate=s.StartDate
    ,@HistoryStartDate=h.StartDate
    ,@RepeatWeek=s.RepeatWeeks
    ,@RepeatDAYs=s.RepeatDAYs
     FROM [dbo].[ScheduleHistory] h INNER JOIN dbo.Schedule s
    ON s.ScheduleID=h.ScheduleID
    WHERE ScheduleHistoryID=@ScheduleHistoryID

   IF((@NextStart IS NULL OR @NextStart='') AND @RunningMode<>0)
    BEGIN
     SET @NextStart=DATEADD(MINute,@StartMIN,(DATEADD(hour,@StartHour,@StartDate)))
    END 
   
   SET @StartDate=DATEADD(MINute,@StartMIN,(DATEADD(hour,@StartHour,@StartDate)))
   IF(@StartDate>GETDATE())
    BEGIN
     SET @NextStart=@StartDate
    END
   
   ELSE
   BEGIN
   IF (@HistoryStartDate>@StartDate)
   SET @StartDate=DATEADD(MINute,@StartMIN,(DATEADD(hour,@StartHour,(DATEADD(dd, 0, DATEDIFF(dd, 0, @HistoryStartDate))))))
   --Hourly
   IF(@RunningMode=0)
    BEGIN
     SET @NextStart=DATEADD(MINute,@EveryMIN,(DATEADD(hour,@EveryHours,@StartDate)))
    END

   --Daily
   ELSE IF(@RunningMode=1)
    BEGIN
     SET @NextStart=DATEADD(DAY,@RepeatDAYs,@StartDate)
    END

   --Weekly
   ELSE IF(@RunningMode=2)
    BEGIN

     SET @CurrentWeeknum=DATEPART(weekDAY,@StartDate)+1
     SELECT  @LargeWeeknum =MAX(WeekDAYID) FROM ScheduleWeek WHERE ScheduleID=@ScheduleId

     IF @LargeWeeknum >0
      BEGIN
         IF @CurrentWeeknum>=@LargeWeeknum
        BEGIN   
           SELECT @WeekDAY=MIN(WeekDAYID) FROM ScheduleWeek WHERE ScheduleID=@ScheduleId
        END
       ELSE IF @CurrentWeeknum<@LargeWeeknum
        BEGIN
           SELECT @WeekDAY=MIN(WeekDAYID) FROM ScheduleWeek WHERE  
          WeekDAYID>@CurrentWeeknum AND ScheduleID=@ScheduleId
        END   
      END 

     SET @NextDAY=0
     SET @CurrentStartDAY=DATEPART(weekDAY,GETDATE())
      
     IF (@WeekDAY>@CurrentStartDAY)
      SET @NextDAY=@WeekDAY-@CurrentStartDAY
     ELSE 
      SET @NextDAY=7+@WeekDAY-@CurrentStartDAY

     SET @NextStart=DATEADD(DAY,@NextDAY,(DATEADD(MINute,@StartMIN,(DATEADD(hour,@StartHour,(DATEADD(dd, 0, 

     DATEDIFF(dd, 0, GETDATE()))))))))

    END

   --WeekNumber
   ELSE IF(@RunningMode=3)
    BEGIN
     SET @CurrentWeeknum=DATEPART(weekDAY,@StartDate)+1
     SELECT  @LargeWeeknum =MAX(WeekDAYID) FROM ScheduleWeek WHERE ScheduleID=@ScheduleId
     IF @LargeWeeknum >0
      BEGIN
       IF @CurrentWeeknum>=@LargeWeeknum
        BEGIN   
           SELECT @WeekDAY=MIN(WeekDAYID) FROM ScheduleWeek WHERE ScheduleID=@ScheduleId
        END
       ELSE IF @CurrentWeeknum<@LargeWeeknum
        BEGIN
           SELECT @WeekDAY=MIN(WeekDAYID) FROM ScheduleWeek WHERE  
          WeekDAYID>@CurrentWeeknum AND ScheduleID=@ScheduleId
        END 
      END 

     DECLARE @NextMonth INT
     SET @NextDAY=0
     SET @CurrentStartDAY=DATEPART(weekDAY,GETDATE())
     SET @NextMonth=DATEPART(month,GETDATE())+1

     IF(@WeekDAY>@CurrentStartDAY)
      SET @NextDAY=DATEPART(DAY,GETDATE())+@WeekDAY-@CurrentStartDAY
     ELSE
      BEGIN   
       SELECT @NextMonth=MIN(MonthID)  FROM ScheduleMonth WHERE MonthID>DATEPART(Month,@StartDate) AND ScheduleID=@ScheduleID                    
       SET @NextDAY=@RepeatWeek*7-7+@WeekDAY
      END

     SET @NextStart=CAST(CAST(YEAR(GETDATE()) AS VARCHAR(4)) + '/' + @NextMonth + '/' + @NextDAY AS DATETIME)
    END

   --CalENDar
   ELSE IF(@RunningMode=4)
    BEGIN
     SELECT @NextStart=MIN(Schedule_Date)  FROM ScheduleDate WHERE Schedule_Date>convert(DATETIME,@StartDate,101) AND ScheduleID=@ScheduleID
    END
   --Once
   ELSE IF(@RunningMode=5)
    BEGIN
     SELECT @NextStart=NULL
    END
  END
  END

 UPDATE ScheduleHistory
  SET NextStart=@NextStart  
  WHERE ScheduleHistoryID=@ScheduleHistoryID

SET @ResultNextStart=@NextStart
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleHistoryGetMax]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleHistoryGetMax]
(
 @ScheduleID INT
)
AS
BEGIN
SELECT MAX(ScheduleHistoryID) AS  ScheduleHistoryID FROM dbo.ScheduleHistory
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleHistoryGet]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleHistoryGet]
(
 @ScheduleID INT,
    @offset INT,
    @limit INT 
)
AS
BEGIN
DECLARE @RowTotal INT
SELECT @RowTotal=COUNT(*) FROM [dbo].[ScheduleHistory]
WHERE ScheduleID=@ScheduleID ;

WITH scheduleHistoryTmp AS
(
   SELECT @RowTotal AS RowTotal ,*, row_number() OVER(ORDER BY ScheduleHistoryID DESC) AS rowNum
  FROM
  (
   SELECT
      [ScheduleHistoryID]
   ,[ScheduleID]      
   ,[StartDate]
      ,[EndDate]
      ,[Status]
      ,[ReturnText]
      ,[NextStart]
      ,[Server]
         
     FROM [dbo].[ScheduleHistory]
   WHERE ScheduleID=@ScheduleID
   ) DataTable
)
SELECT * FROM  scheduleHistoryTmp WHERE
rowNum>= @offset
AND rowNum<= (@offset + @limit - 1)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleHistoryAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleHistoryAdd]
(
 @ScheduleID INT,
 @StartDate DATETIME,
 @EndDate DATETIME=NULL,
 @Status bit,
 @ReturnText NTEXT=NULL,
 @NextStart DATETIME=NULL,
 @Server NVARCHAR(150)=NULL,
    @id INT OUTPUT
)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO ScheduleHistory
(
 ScheduleID,StartDate,EndDate,Status,ReturnText,NextStart,[Server]
)
VALUES
(
 @ScheduleID,@StartDate,@EndDate,@Status,@ReturnText,@NextStart,@Server
);

SET @id=@@identity
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ScheduleGetHistory]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ScheduleGetHistory] 
@ScheduleID INT,
@offset INT,
@limit INT
AS
BEGIN
SELECT * FROM(
SELECT row_number() OVER(ORDER BY s.[ScheduleID] DESC) AS rowNum, 
s.[ScheduleID]
      ,s.[ScheduleName]
      ,s.[FullNamespace]
      ,s.[StartDate]
      ,s.[EndDate]
      ,s.[StartHour]
      ,s.[StartMin]
      ,s.[RepeatWeeks]
      ,s.[RepeatDays]
      ,s.[WeekOfMonth]
      ,s.[EveryHours]
      ,s.[EveryMin]
      ,s.[ObjectDependencies]
      ,s.[RetryTimeLapse]
      ,s.[RetryFrequencyUnit]
      ,s.[AttachToEvent]
      ,s.[CatchUpEnabled]
      ,s.[Servers]
      ,s.[CreatedByUserID]
      ,s.[CreatedOnDate]
      ,s.[LastModifiedbyUserID]
      ,s.[LastModifiedDate]
,s.[IsEnable]
,v.Status,v.[Server],
  v.ScheduleHistoryID AS ScheduleHistoryID
      ,v.NextStart AS NextStart
,v.StartDate AS HistoryStartDate,
v.EndDate AS HistoryEndDate
, v.ReturnText,DATEDIFF(millisecond,v.StartDate,v.EndDate) AS Duration

  FROM [dbo].[Schedule] s LEFT JOIN [dbo].[ScheduleHistory] v ON s.ScheduleID=v.ScheduleID
 WHERE v.ScheduleID=@ScheduleID
) AS t
WHERE
 rowNum>= @offset
AND rowNum <= (@offset + @limit - 1)
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleMessageGetModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleMessageGetModules]
AS
BEGIN
  SELECT 
  [ModuleID],
  [FriendlyName]     
  FROM 
  [dbo].[Modules]
  WHERE 
   ( 
     IsDeleted=0 
    OR IsDeleted IS NULL 
   )
  AND 
   IsAdmin=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MsgTempTokenUniquenessCheck]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_MsgTempTokenUniquenessCheck]
 @MsgTemplateTokenName nvarchar(256),
 @MsgTemplateTypeID nvarchar(256),
 @PortalID int,
 @IsUnique bit output
 
AS
BEGIN
DECLARE @MessageTokenID int
SELECT @MessageTokenID=(SELECT MessageTokenID FROM [dbo].[MessageToken] where MessageTokenKey=@MsgTemplateTokenName)
IF(EXISTS(SELECT * FROM [dbo].[MessageTemplateTypeToken] WHERE (IsDeleted=0 OR IsDeleted IS NULL) AND 
 PortalID = @PortalID AND MessageTemplateTypeID = @MsgTemplateTypeID AND MessageTokenID= @MessageTokenID ))
  BEGIN
   SET @IsUnique = CAST(0 as bit) 
  END
  ELSE
  BEGIN
   SET @IsUnique = CAST(1 as bit)
  END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_PollInstalled]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PollInstalled]
AS
BEGIN 
 SELECT ModuleName FROM Modules WHERE FolderName='Polling'  
END
GO
/****** Object:  Table [dbo].[PortalModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalModules](
	[PortalModuleID] [int] IDENTITY(1,1) NOT NULL,
	[PortalID] [int] NOT NULL,
	[ModuleID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_PortalModules] PRIMARY KEY CLUSTERED 
(
	[PortalModuleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[sp_LogInsert]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LogInsert]
 @LogID INT = NULL OUTPUT,
 @LogTypeID INT,
 @Severity INT,
 @Message NVARCHAR(1000),
 @Exception NVARCHAR(4000),
 @ClientIPAddress NVARCHAR(100),
 @PageURL NVARCHAR(100),
 @IsActive BIT,
 @PortalID INT,
 @AddedBy NVARCHAR(256)
AS
BEGIN
 INSERT
 INTO [dbo].[Log]
 (
  LogTypeID,
  Severity,
  [Message],
  Exception,
  ClientIPAddress,
  PageURL,
  [IsActive],
  [AddedOn],
  [PortalID],
  [AddedBy]
 )
 VALUES
 (
  @LogTypeID,
  @Severity,
  @Message,
  @Exception,
  @ClientIPAddress,
  @PageURL,
  @IsActive,
  GETDATE(),
  @PortalID,
  @AddedBy
 )

 SET @LogID=@@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LogDeleteByLogID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: 2010-04-19
-- Description: Log Viewer Module
-- =============================================

CREATE PROCEDURE [dbo].[sp_LogDeleteByLogID]
 @LogID INT,
 @PortalID INT,
 @DeletedBy NVARCHAR(256)
AS

UPDATE [dbo].[Log] SET
[IsDeleted] = 1,
[DeletedOn] = GETDATE(),
[DeletedBy] = @DeletedBy
WHERE
 [LogID] = @LogID AND PortalID=@PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_LogClear]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LogClear]
@PortalID INT
AS
BEGIN
 SET NOCOUNT ON
 DELETE
 FROM [dbo].[Log]
 WHERE PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: 2010-03-30
-- Description: HTML/Text Module -- Comment section
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_HtmlCommentUpdate]
 -- Add the parameters for the stored procedure here
   @HTMLCommentID INT
   ,@Comment NTEXT
   ,@IsApproved BIT
   ,@IsActive BIT
   ,@IsModified BIT
   ,@UpdatedOn DATETIME
   ,@PortalID INT
   ,@UpdatedBy NVARCHAR(256)
AS
BEGIN
 UPDATE [dbo].[HtmlComment] SET
 [Comment] = @Comment,
 [IsApproved]=@IsApproved,
 [IsActive] = @IsActive,
 [IsModified] = @IsModified,
 [UpdatedOn] = @UpdatedOn,
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE
 [HTMLCommentID] = @HTMLCommentID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentGetByHTMLTextID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Milson Munakami
-- Create date: 2010-03-30
-- Description: HTML/Text Module -- Comment section
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_HtmlCommentGetByHTMLTextID] 
 -- Add the parameters for the stored procedure here
 @PortalID int,
 @HTMLTextID int
AS
BEGIN
 SELECT
 [HTMLTextID],
 [Comment],
 [IsApproved],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [ApprovedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy],
 [ApprovedBy]
FROM dbo.[HtmlComment]
WHERE
 [PortalID]=@PortalID AND [HTMLTextID]=@HTMLTextID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentGetByHTMLCommentID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: 2010-03-31
-- Description: HTML/Text Module -- Comment section
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_HtmlCommentGetByHTMLCommentID] 
 @PortalID INT,
 @HTMLCommentID INT
AS
BEGIN
 SELECT
 [HTMLCommentID],
 [HTMLTextID],
 [Comment],
 [IsApproved],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [ApprovedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy],
 [ApprovedBy]
FROM dbo.[HtmlComment]
WHERE
 [PortalID]=@PortalID AND [HTMLCommentID]=@HTMLCommentID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentGetAllByHTMLTextID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HtmlCommentGetAllByHTMLTextID]
 @PortalID INT,
 @HTMLTextID INT
 
WITH EXECUTE AS CALLER
AS
BEGIN


 SELECT
 [HTMLCommentID],
 [HTMLTextID],
 [Comment],
 [IsApproved],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [ApprovedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy],
 [ApprovedBy]
FROM dbo.[HtmlComment]
WHERE
 [PortalID]=@PortalID AND [HTMLTextID]=@HTMLTextID AND (IsDeleted=0 OR IsDeleted IS NULL)
END
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentGetByHTMLCommentID]    Script Date: 12/02/2012 13:49:51 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentDeleteByCommentID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: 2010-03-31
-- Description: HTML/Text Module -- Comment section
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_HtmlCommentDeleteByCommentID] 
 -- Add the parameters for the stored procedure here
 @HTMLCommentID INT,
 @PortalID INT,
 @DeletedBy NVARCHAR(256)
AS
BEGIN
UPDATE [dbo].[HtmlComment] SET 
 [IsDeleted] = 1, 
 [DeletedOn] = GETDATE(), 
 [DeletedBy] = @DeletedBy
WHERE
 [HTMLCommentID] = @HTMLCommentID AND [PortalID] = @PortalID
END
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentGetAllByHTMLTextID]    Script Date: 12/02/2012 13:48:19 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: 2010-03-30
-- Description: HTML/Text Module -- Comment section
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_HtmlCommentAdd]
 -- Add the parameters for the stored procedure here
   @HTMLCommentID INT OUTPUT
     ,@HTMLTextID INT
           ,@Comment NTEXT
           ,@IsApproved BIT
           ,@IsActive BIT
           ,@AddedOn DATETIME
           ,@PortalID INT
           ,@AddedBy NVARCHAR(256)
AS
BEGIN
 INSERT INTO [dbo].[HtmlComment]
           ([HTMLTextID]
           ,[Comment]
           ,[IsApproved]
           ,[IsActive]           
           ,[AddedOn]
           ,[PortalID]
           ,[AddedBy])
     VALUES
     (@HTMLTextID
           ,@Comment
           ,@IsApproved
           ,@IsActive
           ,@AddedOn
           ,@PortalID
           ,@AddedBy)

SELECT @HTMLCommentID=SCOPE_IDENTITY()

END
/****** Object:  StoredProcedure [dbo].[sp_HtmlCommentDeleteByCommentID]    Script Date: 12/02/2012 13:47:13 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserActivationCode]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserActivationCode]
 @UserName NVARCHAR(256),
 @PortalID INT
AS
BEGIN
SELECT UserId FROM
dbo.aspnet_users
WHERE Username=@UserName
END
/****** Object:  StoredProcedure [dbo].[sp_GetUserEmail]    Script Date: 12/02/2012 13:13:10 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoleIDByRoleName]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRoleIDByRoleName]   
 -- Add the parameters for the stored procedure here  
 @RoleName VARCHAR(256)  
AS  
BEGIN  
 SET NOCOUNT ON; 
 

  SELECT  [ApplicationId], [RoleId] , [RoleName],[LoweredRoleName] ,[Description]
  FROM  [dbo].[aspnet_Roles]   WITH (NOLOCK)  
  WHERE     (LoweredRoleName = @RoleName OR RoleName = @RoleName)  
END  
/****** Object:  StoredProcedure [dbo].[sp_GetUserActivationCode]    Script Date: 12/02/2012 13:10:50 ******/  
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPermissionByCodeAndKey]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: <Create Date,,>
-- Description: <Description,,>
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_GetPermissionByCodeAndKey] 
 -- Add the parameters for the stored procedure here
 @PermissionCode VARCHAR(50),
 @PermissionKey VARCHAR(50)
AS
BEGIN
 SELECT *
  FROM dbo.Permission
  WHERE
   (PermissionCode = @PermissionCode OR @PermissionCode IS NULL)
   AND
   (PermissionKey = @PermissionKey OR @PermissionKey IS NULL)
END
/****** Object:  StoredProcedure [dbo].[sp_GetRoleIDByRoleName]    Script Date: 12/02/2012 13:01:34 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerSetFolderPermission]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerSetFolderPermission] 
(
@FolderID      INT, 
@PermissionKey VARCHAR(50), 
@UserID        INT, 
@RoleID        UNIQUEIDENTIFIER, 
@IsActive      BIT, 
@AddedBy       NVARCHAR(256)) 
AS 
  BEGIN 
      SET NOCOUNT ON; 
      DECLARE @PermissionID INT
      SELECT @PermissionID = PermissionID 
      FROM   Permission 
      WHERE  PermissionKey = @PermissionKey 

      INSERT INTO FolderPermission 
                  (FolderID, 
                   PermissionID, 
                   UserID, 
                   RoleID, 
                   IsActive, 
                   AddedOn, 
                   AddedBy) 
      VALUES      ( @FolderID, 
                    @PermissionID, 
                    @UserID, 
                    @RoleID, 
                    @IsActive, 
                    GETDATE(), 
                    @AddedBy ) 
  END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileUpdateDisplayOrderAndIsActiveOnly]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileUpdateDisplayOrderAndIsActiveOnly]
 @ProfileID INT, 
 @DisplayOrder INT, 
 @IsActive BIT, 
 @UpdatedOn DATETIME, 
 @PortalID INT, 
 @UpdatedBy NVARCHAR(256) 
AS
UPDATE [dbo].[Profile] SET
 [DisplayOrder] = @DisplayOrder,
 [IsActive] = @IsActive,
 [IsModified] = 1, 
 [UpdatedOn] = @UpdatedOn,  
 [UpdatedBy] = @UpdatedBy 
WHERE
 [ProfileID] = @ProfileID and [PortalID] = @PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileUpdate]
 @ProfileID INT, 
 @Name NVARCHAR(100), 
 @PropertyTypeID INT,
 @DataType NVARCHAR(15), 
 @IsRequired BIT,
 @IsActive BIT, 
 @IsModified BIT, 
 @UpdatedOn DATETIME, 
 @PortalID INT, 
 @UpdatedBy NVARCHAR(256) 
AS
UPDATE [dbo].[Profile] SET
 [Name] = @Name,
 [PropertyTypeID] = @PropertyTypeID,
 [DataType] = @DataType,
 [IsRequired] = @IsRequired,
 [IsActive] = @IsActive, 
 [IsModified] = @IsModified, 
 [UpdatedOn] = @UpdatedOn, 
 [PortalID] = @PortalID, 
 [UpdatedBy] = @UpdatedBy 
WHERE
 [ProfileID] = @ProfileID
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileListActive]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileListActive]
 @PortalID INT
AS
BEGIN
SELECT     
dbo.[Profile].ProfileID, 
dbo.[Profile].[Name], 
dbo.[Profile].PropertyTypeID,
dbo.[Profile].[DataType],
dbo.[Profile].[IsRequired], 
dbo.[Profile].DisplayOrder, 
dbo.[Profile].IsActive, 
dbo.[Profile].IsDeleted, 
dbo.[Profile].IsModified, 
dbo.[Profile].AddedOn, 
dbo.[Profile].UpdatedOn, 
dbo.[Profile].DeletedOn, 
dbo.[Profile].PortalID, 
dbo.[Profile].AddedBy, 
dbo.[Profile].UpdatedBy, 
dbo.[Profile].DeletedBy, 
dbo.[PropertyType].[Name] AS PropertyTypeName
FROM         
dbo.[Profile] INNER JOIN
dbo.[PropertyType] ON dbo.[Profile].PropertyTypeID = dbo.PropertyType.PropertyTypeID
WHERE
dbo.[Profile].PortalID = @PortalID AND 
dbo.[Profile].[IsActive] = 1 AND
dbo.[Profile].[IsDeleted] = 0
ORDER BY dbo.[Profile].DisplayOrder ASC

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileList]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileList]
 @PortalID INT
AS
BEGIN
SELECT 
dbo.[Profile].ProfileID, 
dbo.[Profile].[Name], 
dbo.[Profile].PropertyTypeID,
dbo.[Profile].[DataType],
dbo.[Profile].[IsRequired], 
CAST((ROW_NUMBER() OVER (ORDER BY dbo.[Profile].DisplayOrder)) AS INT) AS [DisplayOrder], 
dbo.[Profile].IsActive, 
dbo.[Profile].IsDeleted, 
dbo.[Profile].IsModified, 
dbo.[Profile].AddedOn, 
dbo.[Profile].UpdatedOn, 
dbo.[Profile].DeletedOn, 
dbo.[Profile].PortalID, 
dbo.[Profile].AddedBy, 
dbo.[Profile].UpdatedBy, 
dbo.[Profile].DeletedBy, 
dbo.[PropertyType].[Name] AS PropertyTypeName
FROM         
dbo.[Profile] INNER JOIN
dbo.[PropertyType] ON dbo.[Profile].PropertyTypeID = dbo.PropertyType.PropertyTypeID
Where
dbo.[Profile].PortalID = @PortalID AND 
dbo.[Profile].[IsDeleted] = 0 ORDER BY dbo.[Profile].DisplayOrder ASC

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesGetByModuleName]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ModulesGetByModuleName]
 @ModuleName nvarchar(128),
 @PortalID int
 
 
AS
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON;

    -- Insert statements for procedure here
 SELECT 
 [ModuleID],
 [FriendlyName],
 [Description],
 [Version],
 [IsPremium],
 [IsAdmin],
 [BusinessControllerClass],
 [FolderName],
 [ModuleName],
 [SupportedFeatures],
 [CompatibleVersions],
 [Dependencies],
 [Permissions],
 [PackageID],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[Modules]
WHERE
 [ModuleName] = @ModuleName --AND PortalID = @PortalID

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesGetByModuleID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[sp_ModulesGetByModuleID]
 @ModuleID int,
 @PortalID int
AS

SELECT
 [ModuleID],
 [FriendlyName],
 [Description],
 [Version],
 [IsPremium],
 [IsAdmin],
 [BusinessControllerClass],
 [FolderName],
 [ModuleName],
 [SupportedFeatures],
 [CompatibleVersions],
 [Dependencies],
 [Permissions],
 [PackageID],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[Modules]
WHERE
 [ModuleID] = @ModuleID
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesDelete]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModulesDelete]
 @ModuleID int,
 @DeletedBy nvarchar(256),
 @PortalID int
AS
UPDATE [dbo].[Modules] SET
 [IsDeleted] = 1, 
 [DeletedOn] = getdate(), 
 [DeletedBy] = @DeletedBy
WHERE
 [ModuleID] = @ModuleID --And PortalID = @PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_LogView]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: 2010-04-10
-- Description: HLog Viewer module
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_LogView] 
   @PortalID INT,
   @LogType NVARCHAR(256)   
AS
BEGIN
IF(@LogType='')
 BEGIN
  SELECT     dbo.LogType.[LogTypeID],dbo.LogType.[Name] AS LogTypeName, dbo.[Log].LogID, dbo.[Log].ClientIPAddress, dbo.[Log].AddedOn, dbo.[Log].Exception, dbo.[log].PageURL, dbo.Portal.[Name] AS PortalName 
   FROM         dbo.Portal INNER JOIN
        dbo.[Log] ON dbo.Portal.PortalID = dbo.[Log].PortalID INNER JOIN
        dbo.LogType ON dbo.[Log].LogTypeID = dbo.LogType.LogTypeID
        Where dbo.Portal.PortalID = @PortalID AND ([IsDeleted]=0 OR [IsDeleted] IS NULL) AND IsActive = 1 ORDER BY [dbo].[Log].AddedOn DESC
   END
  ELSE
   BEGIN
    SELECT     dbo.LogType.[LogTypeID],dbo.LogType.[Name] AS LogTypeName, dbo.[Log].LogID, dbo.[Log].ClientIPAddress, dbo.[Log].AddedOn, dbo.[Log].Exception, dbo.[log].PageURL, dbo.Portal.[Name] AS PortalName 
   FROM         dbo.Portal INNER JOIN
        dbo.[Log] ON dbo.Portal.PortalID = dbo.[Log].PortalID INNER JOIN
        dbo.LogType ON dbo.[Log].LogTypeID = dbo.LogType.LogTypeID
        Where dbo.Portal.PortalID = @PortalID AND dbo.LogType.[Name]=@LogType AND ([IsDeleted]=0 OR [IsDeleted] IS NULL) AND IsActive = 1 ORDER BY [dbo].[Log].AddedOn DESC 
   END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_MessageTemplateTypeTokenListByMessageTemplateType]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Created By:   
-- Date Created: 2010-04-25

CREATE PROCEDURE [dbo].[sp_MessageTemplateTypeTokenListByMessageTemplateType]
@MessageTemplateTypeID INT,
@PortalID INT
AS
SELECT
 MTTT.[MessageTemplateTypeTokenID],
 MTTT.[MessageTemplateTypeID],
 MTTT.[MessageTokenID],
 MT.[MessageTokenKey],
 MT.[MessageTokenName],
 MTTT.[IsActive],
 MTTT.[IsDeleted],
 MTTT.[IsModified],
 MTTT.[AddedOn],
 MTTT.[UpdatedOn],
 MTTT.[DeletedOn],
 MTTT.[PortalID],
 MTTT.[AddedBy],
 MTTT.[UpdatedBy],
 MTTT.[DeletedBy]
FROM
 [dbo].[MessageTemplateTypeToken] AS MTTT
 INNER JOIN [dbo].[MessageToken] AS MT ON MTTT.MessageTokenID=MT.MessageTokenID
WHERE MTTT.IsActive=1 AND (MTTT.IsDeleted IS NULL OR MTTT.IsDeleted=0) 
   AND [MessageTemplateTypeID]=@MessageTemplateTypeID
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModulesUpdate]
 @ModuleID int, 
 @FriendlyName nvarchar(128), 
 @Description nvarchar(2000), 
 @Version nvarchar(8), 
 @IsPremium bit, 
 @IsAdmin bit, 
 @BusinessControllerClass nvarchar(200), 
 @FolderName nvarchar(128), 
 @ModuleName nvarchar(128), 
 @SupportedFeatures int, 
 @CompatibleVersions nvarchar(500), 
 @Dependencies nvarchar(400), 
 @Permissions nvarchar(400), 
 @PackageID int, 
 @IsActive bit, 
 @IsModified bit,  
 @UpdatedOn datetime,  
 @PortalID int, 
 @UpdatedBy nvarchar(256) 
AS
SET @PortalID = 1

UPDATE [dbo].[Modules] SET
 [FriendlyName] = @FriendlyName,
 [Description] = @Description,
 [Version] = @Version,
 [IsPremium] = @IsPremium,
 [IsAdmin] = @IsAdmin,
 [BusinessControllerClass] = @BusinessControllerClass,
 [FolderName] = @FolderName,
 [ModuleName] = @ModuleName,
 [SupportedFeatures] = @SupportedFeatures,
 [CompatibleVersions] = @CompatibleVersions,
 [Dependencies] = @Dependencies,
 [Permissions] = @Permissions,
 [PackageID] = @PackageID,
 [IsActive] = @IsActive,
 [IsModified] = @IsModified,
 [UpdatedOn] = @UpdatedOn,
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE
 [ModuleID] = @ModuleID
GO
/****** Object:  StoredProcedure [dbo].[sp_ModuleGetByModuleID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModuleGetByModuleID]
 @ModuleID INT
AS

SELECT
 [ModuleID],
 [FriendlyName],
 [Description],
 [Version],
 [IsPremium],
 [IsAdmin],
 [BusinessControllerClass],
 [FolderName],
 [ModuleName],
 [SupportedFeatures],
 [CompatibleVersions],
 [Dependencies],
 [Permissions],
 [PackageID],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[Modules]
WHERE
 [ModuleID] = @ModuleID
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileGetByProfileID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileGetByProfileID]
 @ProfileID INT
AS
SELECT
 [ProfileID],
 [Name],
 [PropertyTypeID],
 [DataType],
 [IsRequired],
 [DisplayOrder],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[Profile]
WHERE
 [ProfileID] = @ProfileID
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileDeleteByProfileID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileDeleteByProfileID]
 @ProfileID INT,
 @DeletedBy NVARCHAR(256)
AS
UPDATE [dbo].[Profile] SET
 [IsDeleted] = 1,
 [DeletedOn] = GETDATE(),
 [DeletedBy] = @DeletedBy
WHERE
 [ProfileID] = @ProfileID
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileAdd]
 @ProfileID INT OUTPUT,
 @Name NVARCHAR(100),
 @PropertyTypeID INT,
 @DataType NVARCHAR(15),
 @IsRequired BIT,
 @IsActive BIT, 
 @AddedOn DATETIME, 
 @PortalID INT,
 @AddedBy NVARCHAR(256)
AS
DECLARE @DisplayOrder INT
SET @DisplayOrder = 0
SELECT @DisplayOrder = (ISNULL(MAX(DisplayOrder),0) + 1) 
FROM [dbo].[Profile]
INSERT INTO [dbo].[Profile] (
 [Name],
 [PropertyTypeID],
 [DataType],
 [IsRequired],
 [DisplayOrder], 
 [IsActive], 
 [AddedOn], 
 [PortalID],
 [AddedBy]
) VALUES (
 @Name,
 @PropertyTypeID,
 @DataType,
 @IsRequired,
 @DisplayOrder,
 @IsActive, 
 @AddedOn, 
 @PortalID,
 @AddedBy
)
SET @ProfileID = SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK__aspnet_UsersInRo__5887175A] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [aspnet_UsersInRoles_index] ON [dbo].[aspnet_UsersInRoles] 
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[PagePermission]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PagePermission](
	[PagePermissionID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NULL,
	[PermissionID] [int] NULL,
	[AllowAccess] [bit] NULL,
	[RoleID] [uniqueidentifier] NULL,
	[Username] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_TabPermission] PRIMARY KEY CLUSTERED 
(
	[PagePermissionID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[PackageID] [int] IDENTITY(1,1) NOT NULL,
	[PortalID] [int] NULL,
	[ModuleID] [int] NULL,
	[Name] [nvarchar](128) NOT NULL,
	[FriendlyName] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[PackageType] [nvarchar](100) NOT NULL,
	[Version] [nvarchar](50) NOT NULL,
	[License] [ntext] NULL,
	[Manifest] [ntext] NULL,
	[Owner] [nvarchar](100) NULL,
	[Organization] [nvarchar](100) NULL,
	[Url] [nvarchar](250) NULL,
	[Email] [nvarchar](100) NULL,
	[ReleaseNotes] [ntext] NULL,
	[IsSystemPackage] [bit] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[PackageID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_SortPages]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_SortPages] 
(@PageID INT,
 @ParentID INT,
 @PageName NVARCHAR (200),
 @BeforeID INT,
 @AfterID INT,
 @PortalID INT,
 @AddedBy NVARCHAR (100)) AS
BEGIN

IF (
 EXISTS (
  SELECT
   *
  FROM
   [dbo].[Pages]
  WHERE
   PageID =@PageID
 )
)
BEGIN
 DECLARE
  @ParentLevel INT,
  @ParentTabPath NVARCHAR (4000) ,@PageOrder INT ,@PageSEOName NVARCHAR (1000) ,@OldParentID INT ,@OldPageOrder INT DECLARE
   @NewTabPath NVARCHAR (4000),
   @NewParentLevel INT SELECT
    @ParentLevel = [Level] ,@ParentTabPath = ISNULL(TabPath, '')
   FROM
    Pages
   WHERE
    PageID =@ParentID SELECT
     @NewTabPath = TabPath
    FROM
     Pages
    WHERE
     PageID =@PageID
    SET @PageSEOName = REPLACE(@PageName, ' ', '-') SELECT
     @OldParentID = ParentID ,@OldPageOrder = PageOrder
    FROM
     [dbo].[Pages]
    WHERE
     PageID =@PageID
    IF @OldParentID <> @ParentID
    BEGIN

    SET @NewParentLevel = ISNULL(@ParentLevel ,- 1) + 1
    SET @NewTabPath = ISNULL(@ParentTabPath, '') + '/' +@PageSEOName EXECUTE [dbo].[sp_UpdateChildLevelTabPath] @PageID ,@NewParentLevel ,@NewTabPath ,@AddedBy ,@PortalID UPDATE Pages
    SET PageOrder = PageOrder - 1
    WHERE
     PageOrder >@OldPageOrder
    AND PortalID =@PortalID
    AND ParentID =@OldParentID
    AND (
     IsDeleted = 0
     OR IsDeleted IS NULL
    )
    END DECLARE
     @CurrentSortValue INT SELECT
      @CurrentSortValue = [PageOrder]
     FROM
      dbo.Pages
     WHERE
      [PageID] =@PageID
     AND ParentID =@ParentID
     AND (
      PortalID =@PortalID
      OR PortalID =- 1
     )
     AND (
      IsDeleted = 0
      OR IsDeleted IS NULL
     )
     IF (@BeforeID > 0)
     BEGIN
      UPDATE Pages
     SET PageOrder = PageOrder - 1
     WHERE
      PageOrder >@CurrentSortValue
     AND PortalID =@PortalID
     AND (
      PortalID =@PortalID
      OR PortalID =- 1
     )
     AND (
      IsDeleted = 0
      OR IsDeleted IS NULL
     ) SELECT
      @PageOrder = [PageOrder]
     FROM
      Pages
     WHERE
      PageID =@BeforeID
     AND ParentID =@ParentID
     AND (
      PortalID =@PortalID
      OR PortalID =- 1
     )
     AND (
      IsDeleted = 0
      OR IsDeleted IS NULL
     ) UPDATE Pages
     SET PageOrder = PageOrder + 1
     WHERE
      PageOrder >=@PageOrder
     AND PortalID =@PortalID
     AND (
      PortalID =@PortalID
      OR PortalID =- 1
     )
     AND (
      IsDeleted = 0
      OR IsDeleted IS NULL
     )
     END
     ELSE

     IF (@AfterID > 0)
     BEGIN
      UPDATE Pages
     SET PageOrder = PageOrder - 1
     WHERE
      PageOrder >@CurrentSortValue
     AND PortalID =@PortalID
     AND ParentID =@ParentID
     AND (
      IsDeleted = 0
      OR IsDeleted IS NULL
     ) SELECT
      @PageOrder = [PageOrder]
     FROM
      Pages
     WHERE
      PageID =@AfterID
     AND ParentID =@ParentID
     AND PortalID =@PortalID
     AND (
      IsDeleted = 0
      OR IsDeleted IS NULL
     ) UPDATE Pages
     SET PageOrder = PageOrder + 1
     WHERE
      PageOrder >@PageOrder
     AND PortalID =@PortalID
     AND ParentID =@ParentID
     AND (
      IsDeleted = 0
      OR IsDeleted IS NULL
     )
     SET @PageOrder =@PageOrder + 1
     END
     ELSE

     BEGIN

     SET @PageOrder =@CurrentSortValue
     END UPDATE [dbo].[Pages]
     SET [PageOrder] = ISNULL(@PageOrder, 1),
     [ParentID] = @ParentID,
     [Level] = ISNULL(@ParentLevel ,- 1) + 1,
     [TabPath] = @NewTabPath,
     [IsModified] = 1,
     [UpdatedOn] = GetDate(),
     [PortalID] = @PortalID,
     [UpdatedBy] = @AddedBy
    WHERE
     PortalID =@PortalID
    AND PageID =@PageID
    END
    END
GO
/****** Object:  Table [dbo].[ModuleDefinitions]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleDefinitions](
	[ModuleDefID] [int] IDENTITY(1,1) NOT NULL,
	[FriendlyName] [nvarchar](128) NULL,
	[ModuleID] [int] NULL,
	[DefaultCacheTime] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_ModuleDefinitions] PRIMARY KEY CLUSTERED 
(
	[ModuleDefID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[CoreModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoreModules](
	[CoreModuleID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NULL,
 CONSTRAINT [PK_CoreModules] PRIMARY KEY CLUSTERED 
(
	[CoreModuleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  View [dbo].[vw_Lists]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_Lists]
AS
SELECT     EntryID, ListName, Value, Text, LEVEL, CurrencyCode, DisplayLocale, DisplayOrder, DefinitionID, ParentID, Description, PortalID, SystemList, Culture, 
                      dbo.GetListParentKey(ParentID, ListName, N'ParentKey', 0) AS ParentKey, dbo.GetListParentKey(ParentID, ListName, N'Parent', 0) AS Parent, 
                      dbo.GetListParentKey(ParentID, ListName, N'ParentList', 0) AS ParentList,
                          (SELECT     MAX(DisplayOrder) AS Expr1
                            FROM          dbo.Lists
                            WHERE      (ListName = L.ListName) AND (ParentID = L.ParentID)) AS MaxSortOrder,
                          (SELECT     COUNT(EntryID) AS Expr1
                            FROM          dbo.Lists AS Lists_1
                            WHERE      (ListName = L.ListName) AND (ParentID = L.ParentID)) AS EntryCount,
                          (SELECT     COUNT(DISTINCT ParentID) AS Expr1
                            FROM          dbo.Lists AS Lists_2
                            WHERE      (ParentID = L.EntryID)) AS HasChildren, IsActive, AddedBy, AddedOn, UpdatedBy, UpdatedOn
FROM         dbo.Lists AS L
GO
/****** Object:  View [dbo].[vw_aspnet_Users]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Users]
  AS SELECT [dbo].[aspnet_Users].[ApplicationId], [dbo].[aspnet_Users].[UserId], [dbo].[aspnet_Users].[UserName], [dbo].[aspnet_Users].[LoweredUserName], [dbo].[aspnet_Users].[MobileAlias], [dbo].[aspnet_Users].[IsAnonymous], [dbo].[aspnet_Users].[LastActivityDate]
  FROM [dbo].[aspnet_Users]
GO
/****** Object:  View [dbo].[vw_aspnet_Roles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Roles]
  AS SELECT [dbo].[aspnet_Roles].[ApplicationId], [dbo].[aspnet_Roles].[RoleId], [dbo].[aspnet_Roles].[RoleName], [dbo].[aspnet_Roles].[LoweredRoleName], [dbo].[aspnet_Roles].[Description]
  FROM [dbo].[aspnet_Roles]
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Paths]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Paths]
  AS SELECT [dbo].[aspnet_Paths].[ApplicationId], [dbo].[aspnet_Paths].[PathId], [dbo].[aspnet_Paths].[Path], [dbo].[aspnet_Paths].[LoweredPath]
  FROM [dbo].[aspnet_Paths]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddUpdatePage]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddUpdatePage] @PageID INT
 ,@PageOrder INT
 ,@PageName NVARCHAR(1000)
 ,@IsVisible BIT
 ,@ParentID INT
 ,@IconFile NVARCHAR(500)
 ,@DisableLink BIT
 ,@Title NVARCHAR(200)
 ,@Description NVARCHAR(500)
 ,@KeyWords NVARCHAR(500)
 ,@Url NVARCHAR(255)
 ,@StartDate NVARCHAR(50)
 ,@EndDate NVARCHAR(50)
 ,@RefreshInterval DECIMAL(16, 2)
 ,@PageHeadText NVARCHAR(500)
 ,@IsSecure BIT
 ,@IsActive BIT
 ,@IsShowInFooter BIT
 ,@IsRequiredPage BIT
 ,@BeforeID INT
 ,@AfterID INT
 ,@PortalID INT
 ,@AddedBy NVARCHAR(256)
 ,@IsAdmin BIT
 ,@InsertedPageID INT OUTPUT
AS
BEGIN
 DECLARE @ParentLevel INT
  ,@ParentTabPath NVARCHAR(4000)
  ,@PageSEOName NVARCHAR(1000)
SELECT @StartDate = CONVERT(DATETIME, @StartDate ,103) ,@EndDate= CONVERT(DATETIME, @EndDate ,103)
 IF @Title = ''
  SET @Title = CONVERT(NVARCHAR(200), [dbo].[Fn_getsettingvaluebysettingkey]('SiteAdmin', @PortalID, 'PageTitle'))

 IF @Description = ''
  SET @Description = CONVERT(NVARCHAR(500), [dbo].[Fn_getsettingvaluebysettingkey]('SiteAdmin', @PortalID, 'MetaDescription'))

 DECLARE @newPortalID INT

 SET @newPortalID = @portalID

 IF @IsAdmin = 1
 BEGIN
  SET @newPortalID = - 1
 END

 IF @KeyWords = ''
  SET @KeyWords = CONVERT(NVARCHAR(500), [dbo].[Fn_getsettingvaluebysettingkey]('SiteAdmin', @PortalID, 'MetaKeywords'))

 SELECT @ParentLevel = [level]
  ,@ParentTabPath = ISNULL(tabpath, '')
 FROM pages
 WHERE pageid = @ParentID

 SELECT @PageOrder = Max(pageorder) + 1
 FROM pages p
 INNER JOIN pagemenu pm ON p.pageid = pm.pageid
 WHERE pm.isadmin = @isadmin

 SET @PageSEOName = Replace(@PageName, ' ', '-')

 IF @PageID = 0
 BEGIN
  INSERT INTO [dbo].[pages] (
   [pageorder]
   ,[pagename]
   ,[isvisible]
   ,[parentid]
   ,[level]
   ,[iconfile]
   ,[disablelink]
   ,[title]
   ,[description]
   ,[keywords]
   ,[url]
   ,[tabpath]
   ,[startdate]
   ,[enddate]
   ,[refreshinterval]
   ,[pageheadtext]
   ,[issecure]
   ,[isactive]
   ,[addedon]
   ,[portalid]
   ,[addedby]
   ,[seoname]
   ,[isshowinfooter]
   ,[isrequiredpage]
   )
  VALUES (
   ISNULL(@PageOrder, 1)
   ,@PageName
   ,@IsVisible
   ,@ParentID
   ,ISNULL(@ParentLevel, - 1) + 1
   ,@IconFile
   ,@DisableLink
   ,@Title
   ,@Description
   ,@KeyWords
   ,@Url
   ,ISNULL(@ParentTabPath, '') + '/' + @PageSEOName
   ,@StartDate
   ,@EndDate
   ,@RefreshInterval
   ,@PageHeadText
   ,@IsSecure
   ,@IsActive
   ,GETDATE()
   ,@newPortalID
   ,@AddedBy
   ,@PageSEOName
   ,@IsShowInFooter
   ,@IsRequiredPage
   )

  SET @InsertedPageID = @@IDENTITY

  EXECUTE [dbo].[Usp_addupdatepagemenu] @InsertedPageID
   ,@PortalID
   ,@IsAdmin
   ,@IsShowInFooter

  SET @PageID = Scope_identity()

  DECLARE @Date DATETIME

  SET @Date = GETDATE()

  INSERT INTO PagePreview (
   PageID
   ,PreviewCode
   )
  VALUES (
   @PageID
   ,convert(NVARCHAR(256), NEWID())
   )
 END
 ELSE
 BEGIN
  IF (
    EXISTS (
     SELECT *
     FROM [dbo].[pages]
     WHERE pageid = @PageID
     )
    )
  BEGIN
   EXECUTE [dbo].[Usp_addupdatepagemenu] @PageID
    ,@PortalID
    ,@IsAdmin
    ,@IsShowInFooter

   DECLARE @oldParentID INT
    ,@oldPageOrder INT

   SELECT @oldParentID = parentid
    ,@oldPageOrder = pageorder
   FROM [dbo].[pages]
   WHERE pageid = @PageID

   IF @oldParentID <> @ParentID
   BEGIN
    DECLARE @NewTabPath NVARCHAR(4000)
     ,@NewParentLevel INT

    SET @NewParentLevel = ISNULL(@ParentLevel, - 1) + 1
    SET @NewTabPath = ISNULL(@ParentTabPath, '') + '/' + @PageSEOName

    EXECUTE [dbo].[Sp_updatechildleveltabpath] @PageID
     ,@NewParentLevel
     ,@NewTabPath
     ,@AddedBy
     ,@PortalID

    UPDATE pages
    SET pageorder = pageorder - 1
    WHERE pageorder > @oldPageOrder
     AND portalid = @PortalID
     AND parentid = @oldParentID
     AND (
      isdeleted = 0
      OR isdeleted IS NULL
      )
   END

   DECLARE @CurrentSortValue INT

   SELECT @CurrentSortValue = [pageorder]
   FROM dbo.pages
   WHERE [pageid] = @PageID
    AND parentid = @ParentID
    AND portalid = @PortalID
    AND (
     isdeleted = 0
     OR isdeleted IS NULL
     )

   IF (@BeforeID > 0)
   BEGIN
    UPDATE pages
    SET pageorder = pageorder - 1
    WHERE pageorder > @CurrentSortValue
     AND portalid = @PortalID
     AND parentid = @ParentID
     AND (
      isdeleted = 0
      OR isdeleted IS NULL
      )

    SELECT @PageOrder = [pageorder]
    FROM pages
    WHERE pageid = @BeforeID
     AND parentid = @ParentID
     AND portalid = @PortalID
     AND (
      isdeleted = 0
      OR isdeleted IS NULL
      )

    UPDATE pages
    SET pageorder = pageorder + 1
    WHERE pageorder >= @PageOrder
     AND portalid = @PortalID
     AND parentid = @ParentID
     AND (
      isdeleted = 0
      OR isdeleted IS NULL
      )
   END
   ELSE
    IF (@AfterID > 0)
    BEGIN
     UPDATE pages
     SET pageorder = pageorder - 1
     WHERE pageorder > @CurrentSortValue
      AND portalid = @PortalID
      AND parentid = @ParentID
      AND (
       isdeleted = 0
       OR isdeleted IS NULL
       )

     SELECT @PageOrder = [pageorder]
     FROM pages
     WHERE pageid = @AfterID
      AND parentid = @ParentID
      AND portalid = @PortalID
      AND (
       isdeleted = 0
       OR isdeleted IS NULL
       )

     UPDATE pages
     SET pageorder = pageorder + 1
     WHERE pageorder > @PageOrder
      AND portalid = @PortalID
      AND parentid = @ParentID
      AND (
       isdeleted = 0
       OR isdeleted IS NULL
       )

     SET @PageOrder = @PageOrder + 1
    END
    ELSE
    BEGIN
     SET @PageOrder = @CurrentSortValue
    END

   BEGIN
    DECLARE @OldPortalID INT

    SELECT @OldPortalID = portalid
    FROM [dbo].[pages]
    WHERE (
      portalid = @PortalID
      OR portalid = - 1
      )
     AND pageid = @PageID

    IF (@OldPortalID = - 1)
    BEGIN
     SET @PortalID = @OldPortalID
    END
    ELSE
    BEGIN
     SET @PortalID = @PortalID
    END

    UPDATE [dbo].[pages]
    SET [pageorder] = ISNULL(@PageOrder, 1)
     ,[pagename] = @PageName
     ,[isvisible] = @IsVisible
     ,[parentid] = @ParentID
     ,[level] = ISNULL(@ParentLevel, - 1) + 1
     ,[iconfile] = @IconFile
     ,[disablelink] = @DisableLink
     ,[title] = @Title
     ,[description] = @Description
     ,[keywords] = @KeyWords
     ,[url] = @Url
     ,[tabpath] = ISNULL(@ParentTabPath, '') + '/' + @PageSEOName
     ,[startdate] = @StartDate
     ,[enddate] = @EndDate
     ,[refreshinterval] = @RefreshInterval
     ,[pageheadtext] = @PageHeadText
     ,[issecure] = @IsSecure
     ,[isactive] = @IsActive
     ,[ismodified] = 1
     ,[updatedon] = GETDATE()
     ,[portalid] = @PortalID
     ,[updatedby] = @AddedBy
     ,[seoname] = @PageSEOName
     ,[isshowinfooter] = @IsShowInFooter
    WHERE (
      portalid = @PortalID
      OR portalid = - 1
      )
     AND pageid = @PageID

    SET @InsertedPageID = @PageID

    UPDATE [dbo].[localpage]
    SET localpagename = @PageName
    WHERE pageid = @PageID
     AND culturecode = 'en-US'

    DECLARE @UpdatedOn DATETIME

    SET @UpdatedOn = GETDATE()
   END
  END
 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Template_InsertPage]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Template_InsertPage] (
 @pageName VARCHAR(50)
 ,@pageOrder INT
 ,@isVisible BIT
 ,@LEVEL INT
 ,@portalID INT
 ,@disableLink BIT
 ,@isSecure BIT
 ,@isActive BIT
 ,@isShowInFooter BIT
 ,@isRequiredPage BIT
 ,@iconfile VARCHAR(100)
 ,@pageHeadText VARCHAR(100)
 ,@description VARCHAR(100)
 ,@keyWords VARCHAR(100)
 ,@url VARCHAR(100)
 ,@tabPath VARCHAR(100)
 ,@seoName VARCHAR(100)
 ,@refreshInterval DECIMAL(6, 2)
 ,@title VARCHAR(100)
 ,@allowAcess NVARCHAR(MAX)
 ,@roleName NVARCHAR(MAX)
 ,@permissionID NVARCHAR(MAX)
 ,@isPermisssionActive NVARCHAR(MAX)
 )
AS
BEGIN
 DECLARE @PageID AS INT

 IF (
   EXISTS (
    SELECT PageID
    FROM Pages
    WHERE PageName = @pageName
     AND IsDeleted = 0
    )
   )
 BEGIN
  SET @PageID = (
    SELECT PageID
    FROM Pages
    WHERE PageName = @pageName
     AND IsDeleted = 0
    )
 END
 ELSE
 BEGIN
  INSERT INTO Pages (
   [PageOrder]
   ,[PageName]
   ,[IsVisible]
   ,[ParentID]
   ,[Level]
   ,[IconFile]
   ,[DisableLink]
   ,[Title]
   ,[Description]
   ,[KeyWords]
   ,[Url]
   ,[TabPath]
   ,[RefreshInterval]
   ,[PageHeadText]
   ,[IsSecure]
   ,[IsActive]
   ,[PortalID]
   ,[SEOName]
   ,[IsShowInFooter]
   ,[IsRequiredPage]
   )
  VALUES (
   @pageOrder
   ,@pageName
   ,@isVisible
   ,0
   ,@LEVEL
   ,@iconfile
   ,@disableLink
   ,@title
   ,@description
   ,@keyWords
   ,@url
   ,@tabPath
   ,@refreshInterval
   ,@pageHeadText
   ,@isSecure
   ,@isActive
   ,@portalID
   ,@seoName
   ,@isShowInFooter
   ,@isRequiredPage
   )

  SET @PageID = Scope_Identity()

  INSERT INTO PageMenu (
   PageID
   ,IsAdmin
   ,ShowInMenu
   ,PortalID
   )
  VALUES (
   @PageID
   ,0
   ,1
   ,@portalID
   )
 END

 CREATE TABLE #TableAllowAcess (
  ROWNO INT IDENTITY(1, 1)
  ,AllowAcess NVARCHAR(50)
  )

 INSERT INTO #TableAllowAcess
 SELECT *
 FROM dbo.Split(@allowAcess, ',')

 CREATE TABLE #TableRoleName (
  ROWNO INT IDENTITY(1, 1)
  ,RoleName NVARCHAR(50)
  )

 INSERT INTO #TableRoleName
 SELECT *
 FROM dbo.Split(@roleName, ',')

 CREATE TABLE #TablePermissionID (
  ROWNO INT IDENTITY(1, 1)
  ,PermissionID NVARCHAR(50)
  )

 INSERT INTO #TablePermissionID
 SELECT *
 FROM dbo.Split(@permissionID, ',')

 CREATE TABLE #TablePermissionIsActive (
  ROWNO INT IDENTITY(1, 1)
  ,IsPermissionActive NVARCHAR(50)
  )

 INSERT INTO #TablePermissionIsActive
 SELECT *
 FROM dbo.Split(@isPermisssionActive, ',')

 DECLARE @Counter INT
 DECLARE @COUNT INT

 SET @Counter = (
   SELECT MAX(ROWNO)
   FROM #TableAllowAcess
   )
 SET @COUNT = 1

 WHILE (@COUNT <= @Counter)
 BEGIN
  DECLARE @RoleName_ NVARCHAR(256)
  DECLARE @AllowAcess_ BIT
  DECLARE @PermissionID_ INT
  DECLARE @IsPermisssionActive_ BIT

  SET @RoleName_ = (
    SELECT roleName
    FROM #TableRoleName
    WHERE ROWNO = @COUNT
    )
  SET @AllowAcess_ = (
    SELECT AllowAcess
    FROM #TableAllowAcess
    WHERE ROWNO = @COUNT
    )
  SET @PermissionID_ = (
    SELECT PermissionID
    FROM #TablePermissionID
    WHERE ROWNO = @COUNT
    )
  SET @IsPermisssionActive_ = (
    SELECT IsPermissionActive
    FROM #TablePermissionIsActive
    WHERE ROWNO = @COUNT
    )

  DECLARE @RoleId VARCHAR(64)

  SET @RoleId = (
    SELECT a.RoleId
    FROM aspnet_Roles AS a
    WHERE a.RoleName = @RoleName_
    )

  INSERT INTO PagePermission (
   PageID
   ,PermissionID
   ,AllowAccess
   ,IsActive
   ,RoleID
   )
  VALUES (
   @PageID
   ,@PermissionID_
   ,@AllowAcess_
   ,@IsPermisssionActive_
   ,@RoleId
   )

  SET @COUNT = @COUNT + 1
 END

 SELECT @PageID AS PageID

 DROP TABLE #TableAllowAcess

 DROP TABLE #TableRoleName

 DROP TABLE #TablePermissionIsActive

 DROP TABLE #TablePermissionID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddPagePermission]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddPagePermission] (@PageID       INT,
                                              @RoleID       NVARCHAR(100)=NULL,
                                              @PermissionID INT,
                                              @AllowAccess  BIT,
                                              @Username     NVARCHAR(256)=NULL,
                                              @IsActive     BIT,
                                              @PortalID     INT,
                                              @AddedBy      NVARCHAR(256),
                                              @IsAdmin  BIT)
AS
  BEGIN
--  IF(@Username <>'')
--  BEGIN
--SET @RoleID = (SELECT  [dbo].[aspnet_UsersInRoles].roleid
--FROM         [dbo].[aspnet_UsersInRoles] INNER JOIN
--       [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].userid = [dbo].[aspnet_UsersInRoles].userid
--       WHERE UserName=@Username)
--       END
  IF @IsAdmin = 0
   BEGIN
    INSERT INTO dbo.pagepermission
       (pageid,
        permissionid,
        allowaccess,
        roleid,
        username,
        isactive,
        addedon,
        portalid,
        addedby)
    VALUES      (@PageID,
        @PermissionID,
        @AllowAccess,
        @RoleID,
        @Username,
        @IsActive,
        GETDATE(),
        @PortalID,
        @AddedBy )
   END
  ELSE
   BEGIN   
   declare @totalPortal int 
   declare @count int
   declare @portalTable Table(Row int identity(1,1), PId int )
   Insert Into @portalTable
   select PortalId from Portal 
   Set @totalPortal = (select Count(*) from @portalTable)
   Set @count = 1
   While(@count<=@totalPortal)
    BEGIN  
       DECLARE @newPortalID INT
       SET @newPortalID =(SELECT PId FROM @portalTable WHERE Row = @Count)
       INSERT INTO dbo.pagepermission
          (pageid,
           permissionid,
           allowaccess,
           roleid,
           username,
           isactive,
           addedon,
           portalid,
           addedby)
       VALUES      (@PageID,
           @PermissionID,
           @AllowAccess,
           @RoleID,
           @Username,
           @IsActive,
           GETDATE(),
           @newPortalID,
           @AddedBy )
     Set @count = @count + 1
    END  
   
   END
  END
GO
/****** Object:  View [dbo].[vw_aspnet_UsersInRoles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_UsersInRoles]
  AS SELECT [dbo].[aspnet_UsersInRoles].[UserId], [dbo].[aspnet_UsersInRoles].[RoleId]
  FROM [dbo].[aspnet_UsersInRoles]
GO
/****** Object:  View [dbo].[vw_aspnet_Profiles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Profiles]
  AS SELECT [dbo].[aspnet_Profile].[UserId], [dbo].[aspnet_Profile].[LastUpdatedDate],
      [DataSize]=  DATALENGTH([dbo].[aspnet_Profile].[PropertyNames])
                 + DATALENGTH([dbo].[aspnet_Profile].[PropertyValuesString])
                 + DATALENGTH([dbo].[aspnet_Profile].[PropertyValuesBinary])
  FROM [dbo].[aspnet_Profile]
GO
/****** Object:  View [dbo].[vw_aspnet_MembershipUsers]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_MembershipUsers]
  AS SELECT [dbo].[aspnet_Membership].[UserId],
            [dbo].[aspnet_Membership].[PasswordFormat],
            [dbo].[aspnet_Membership].[MobilePIN],
            [dbo].[aspnet_Membership].[Email],
            [dbo].[aspnet_Membership].[LoweredEmail],
            [dbo].[aspnet_Membership].[PasswordQuestion],
            [dbo].[aspnet_Membership].[PasswordAnswer],
            [dbo].[aspnet_Membership].[IsApproved],
            [dbo].[aspnet_Membership].[IsLockedOut],
            [dbo].[aspnet_Membership].[CreateDate],
            [dbo].[aspnet_Membership].[LastLoginDate],
            [dbo].[aspnet_Membership].[LastPasswordChangedDate],
            [dbo].[aspnet_Membership].[LastLockoutDate],
            [dbo].[aspnet_Membership].[FailedPasswordAttemptCount],
            [dbo].[aspnet_Membership].[FailedPasswordAttemptWindowStart],
            [dbo].[aspnet_Membership].[FailedPasswordAnswerAttemptCount],
            [dbo].[aspnet_Membership].[FailedPasswordAnswerAttemptWindowStart],
            [dbo].[aspnet_Membership].[Comment],
            [dbo].[aspnet_Users].[ApplicationId],
            [dbo].[aspnet_Users].[UserName],
            [dbo].[aspnet_Users].[MobileAlias],
            [dbo].[aspnet_Users].[IsAnonymous],
            [dbo].[aspnet_Users].[LastActivityDate]
  FROM [dbo].[aspnet_Membership] INNER JOIN [dbo].[aspnet_Users]
      ON [dbo].[aspnet_Membership].[UserId] = [dbo].[aspnet_Users].[UserId]
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_User]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_User]
  AS SELECT [dbo].[aspnet_PersonalizationPerUser].[PathId], [dbo].[aspnet_PersonalizationPerUser].[UserId], [DataSize]=DATALENGTH([dbo].[aspnet_PersonalizationPerUser].[PageSettings]), [dbo].[aspnet_PersonalizationPerUser].[LastUpdatedDate]
  FROM [dbo].[aspnet_PersonalizationPerUser]
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Shared]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Shared]
  AS SELECT [dbo].[aspnet_PersonalizationAllUsers].[PathId], [DataSize]=DATALENGTH([dbo].[aspnet_PersonalizationAllUsers].[PageSettings]), [dbo].[aspnet_PersonalizationAllUsers].[LastUpdatedDate]
  FROM [dbo].[aspnet_PersonalizationAllUsers]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUnquieModuleDefName]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Milson Munakami
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[sp_CheckUnquieModuleDefName] 
 @ModuleDefID int,
 @ModuleDefName nvarchar(50), 
 @Count int output
AS
Begin
 --Initilization of output parameter
 Set @Count = 0
  Begin
   Select @Count = IsNull(Count(ModuleDefID),0) From dbo.ModuleDefinitions Where FriendlyName = @ModuleDefName and ModuleDefID <> @ModuleDefID
  End
Print @Count
End
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]
 @ApplicationName  nvarchar(256),
 @UserNames    nvarchar(4000),
 @RoleNames    nvarchar(4000)
AS
BEGIN
 DECLARE @AppId uniqueidentifier
 SELECT  @AppId = NULL
 SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
 IF (@AppId IS NULL)
  RETURN(2)


 DECLARE @TranStarted   bit
 SET @TranStarted = 0

 IF( @@TRANCOUNT = 0 )
 BEGIN
  BEGIN TRANSACTION
  SET @TranStarted = 1
 END

 DECLARE @tbNames  table(Name nvarchar(256) NOT NULL PRIMARY KEY)
 DECLARE @tbRoles  table(RoleId uniqueidentifier NOT NULL PRIMARY KEY)
 DECLARE @tbUsers  table(UserId uniqueidentifier NOT NULL PRIMARY KEY)
 DECLARE @Num   int
 DECLARE @Pos   int
 DECLARE @NextPos  int
 DECLARE @Name   nvarchar(256)
 DECLARE @CountAll int
 DECLARE @CountU   int
 DECLARE @CountR   int


 SET @Num = 0
 SET @Pos = 1
 WHILE(@Pos <= LEN(@RoleNames))
 BEGIN
  SELECT @NextPos = CHARINDEX(N',', @RoleNames,  @Pos)
  IF (@NextPos = 0 OR @NextPos IS NULL)
   SELECT @NextPos = LEN(@RoleNames) + 1
  SELECT @Name = RTRIM(LTRIM(SUBSTRING(@RoleNames, @Pos, @NextPos - @Pos)))
  SELECT @Pos = @NextPos+1

  INSERT INTO @tbNames VALUES (@Name)
  SET @Num = @Num + 1
 END

 INSERT INTO @tbRoles
   SELECT RoleId
   FROM   dbo.aspnet_Roles ar, @tbNames t
   WHERE  LOWER(t.Name) = ar.LoweredRoleName AND ar.ApplicationId = @AppId
 SELECT @CountR = @@ROWCOUNT

 IF (@CountR <> @Num)
 BEGIN
  SELECT TOP 1 N'', Name
  FROM   @tbNames
  WHERE  LOWER(Name) NOT IN (SELECT ar.LoweredRoleName FROM dbo.aspnet_Roles ar,  @tbRoles r WHERE r.RoleId = ar.RoleId)
  IF( @TranStarted = 1 )
   ROLLBACK TRANSACTION
  RETURN(2)
 END


 DELETE FROM @tbNames WHERE 1=1
 SET @Num = 0
 SET @Pos = 1


 WHILE(@Pos <= LEN(@UserNames))
 BEGIN
  SELECT @NextPos = CHARINDEX(N',', @UserNames,  @Pos)
  IF (@NextPos = 0 OR @NextPos IS NULL)
   SELECT @NextPos = LEN(@UserNames) + 1
  SELECT @Name = RTRIM(LTRIM(SUBSTRING(@UserNames, @Pos, @NextPos - @Pos)))
  SELECT @Pos = @NextPos+1

  INSERT INTO @tbNames VALUES (@Name)
  SET @Num = @Num + 1
 END

 INSERT INTO @tbUsers
   SELECT UserId
   FROM   dbo.aspnet_Users ar, @tbNames t
   WHERE  LOWER(t.Name) = ar.LoweredUserName AND ar.ApplicationId = @AppId

 SELECT @CountU = @@ROWCOUNT
 IF (@CountU <> @Num)
 BEGIN
  SELECT TOP 1 Name, N''
  FROM   @tbNames
  WHERE  LOWER(Name) NOT IN (SELECT au.LoweredUserName FROM dbo.aspnet_Users au,  @tbUsers u WHERE u.UserId = au.UserId)

  IF( @TranStarted = 1 )
   ROLLBACK TRANSACTION
  RETURN(1)
 END

 SELECT  @CountAll = COUNT(*)
 FROM dbo.aspnet_UsersInRoles ur, @tbUsers u, @tbRoles r
 WHERE   ur.UserId = u.UserId AND ur.RoleId = r.RoleId

 IF (@CountAll <> @CountU * @CountR)
 BEGIN
  SELECT TOP 1 UserName, RoleName
  FROM   @tbUsers tu, @tbRoles tr, dbo.aspnet_Users u, dbo.aspnet_Roles r
  WHERE   u.UserId = tu.UserId AND r.RoleId = tr.RoleId AND
      tu.UserId NOT IN (SELECT ur.UserId FROM dbo.aspnet_UsersInRoles ur WHERE ur.RoleId = tr.RoleId) AND
      tr.RoleId NOT IN (SELECT ur.RoleId FROM dbo.aspnet_UsersInRoles ur WHERE ur.UserId = tu.UserId)
  IF( @TranStarted = 1 )
   ROLLBACK TRANSACTION
  RETURN(3)
 END

 DELETE FROM dbo.aspnet_UsersInRoles
 WHERE UserId IN (SELECT UserId FROM @tbUsers)
   AND RoleId IN (SELECT RoleId FROM @tbRoles)
 IF( @TranStarted = 1 )
  COMMIT TRANSACTION
 RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_IsUserInRole]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_IsUserInRole]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(2)
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId

    IF (@UserId IS NULL)
        RETURN(2)

    SELECT  @RoleId = RoleId
    FROM    dbo.aspnet_Roles
    WHERE   LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId

    IF (@RoleId IS NULL)
        RETURN(3)

    IF (EXISTS( SELECT * FROM dbo.aspnet_UsersInRoles WHERE  UserId = @UserId AND RoleId = @RoleId))
        RETURN(1)
    ELSE
        RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetUsersInRoles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_GetUsersInRoles]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
     DECLARE @RoleId uniqueidentifier
     SELECT  @RoleId = NULL

     SELECT  @RoleId = RoleId
     FROM    dbo.aspnet_Roles
     WHERE   LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId

     IF (@RoleId IS NULL)
         RETURN(1)

    SELECT u.UserName
    FROM   dbo.aspnet_Users u, dbo.aspnet_UsersInRoles ur
    WHERE  u.UserId = ur.UserId AND @RoleId = ur.RoleId AND u.ApplicationId = @ApplicationId
    ORDER BY u.UserName
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetRolesForUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_GetRolesForUser]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId

    IF (@UserId IS NULL)
        RETURN(1)

    SELECT r.RoleName
    FROM   dbo.aspnet_Roles r, dbo.aspnet_UsersInRoles ur
    WHERE  r.RoleId = ur.RoleId AND r.ApplicationId = @ApplicationId AND ur.UserId = @UserId
    ORDER BY r.RoleName
    RETURN (0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_FindUsersInRole]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_FindUsersInRole]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256),
    @UserNameToMatch  nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
     DECLARE @RoleId uniqueidentifier
     SELECT  @RoleId = NULL

     SELECT  @RoleId = RoleId
     FROM    dbo.aspnet_Roles
     WHERE   LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId

     IF (@RoleId IS NULL)
         RETURN(1)

    SELECT u.UserName
    FROM   dbo.aspnet_Users u, dbo.aspnet_UsersInRoles ur
    WHERE  u.UserId = ur.UserId AND @RoleId = ur.RoleId AND u.ApplicationId = @ApplicationId AND LoweredUserName LIKE LOWER(@UserNameToMatch)
    ORDER BY u.UserName
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_AddUsersToRoles]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_AddUsersToRoles]
 @ApplicationName  nvarchar(256),
 @UserNames    nvarchar(4000),
 @RoleNames    nvarchar(4000),
 @CurrentTimeUtc   datetime
AS
BEGIN
 DECLARE @AppId uniqueidentifier
 SELECT  @AppId = NULL
 SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
 IF (@AppId IS NULL)
  RETURN(2)
 DECLARE @TranStarted   bit
 SET @TranStarted = 0

 IF( @@TRANCOUNT = 0 )
 BEGIN
  BEGIN TRANSACTION
  SET @TranStarted = 1
 END

 DECLARE @tbNames table(Name nvarchar(256) NOT NULL PRIMARY KEY)
 DECLARE @tbRoles table(RoleId uniqueidentifier NOT NULL PRIMARY KEY)
 DECLARE @tbUsers table(UserId uniqueidentifier NOT NULL PRIMARY KEY)
 DECLARE @Num  int
 DECLARE @Pos  int
 DECLARE @NextPos int
 DECLARE @Name  nvarchar(256)

 SET @Num = 0
 SET @Pos = 1
 WHILE(@Pos <= LEN(@RoleNames))
 BEGIN
  SELECT @NextPos = CHARINDEX(N',', @RoleNames,  @Pos)
  IF (@NextPos = 0 OR @NextPos IS NULL)
   SELECT @NextPos = LEN(@RoleNames) + 1
  SELECT @Name = RTRIM(LTRIM(SUBSTRING(@RoleNames, @Pos, @NextPos - @Pos)))
  SELECT @Pos = @NextPos+1

  INSERT INTO @tbNames VALUES (@Name)
  SET @Num = @Num + 1
 END

 INSERT INTO @tbRoles
   SELECT RoleId
   FROM   dbo.aspnet_Roles ar, @tbNames t
   WHERE  LOWER(t.Name) = ar.LoweredRoleName AND ar.ApplicationId = @AppId

 IF (@@ROWCOUNT <> @Num)
 BEGIN
  SELECT TOP 1 Name
  FROM   @tbNames
  WHERE  LOWER(Name) NOT IN (SELECT ar.LoweredRoleName FROM dbo.aspnet_Roles ar,  @tbRoles r WHERE r.RoleId = ar.RoleId)
  IF( @TranStarted = 1 )
   ROLLBACK TRANSACTION
  RETURN(2)
 END

 DELETE FROM @tbNames WHERE 1=1
 SET @Num = 0
 SET @Pos = 1

 WHILE(@Pos <= LEN(@UserNames))
 BEGIN
  SELECT @NextPos = CHARINDEX(N',', @UserNames,  @Pos)
  IF (@NextPos = 0 OR @NextPos IS NULL)
   SELECT @NextPos = LEN(@UserNames) + 1
  SELECT @Name = RTRIM(LTRIM(SUBSTRING(@UserNames, @Pos, @NextPos - @Pos)))
  SELECT @Pos = @NextPos+1

  INSERT INTO @tbNames VALUES (@Name)
  SET @Num = @Num + 1
 END

 INSERT INTO @tbUsers
   SELECT UserId
   FROM   dbo.aspnet_Users ar, @tbNames t
   WHERE  LOWER(t.Name) = ar.LoweredUserName AND ar.ApplicationId = @AppId

 IF (@@ROWCOUNT <> @Num)
 BEGIN
  DELETE FROM @tbNames
  WHERE LOWER(Name) IN (SELECT LoweredUserName FROM dbo.aspnet_Users au,  @tbUsers u WHERE au.UserId = u.UserId)

  INSERT dbo.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
    SELECT @AppId, NEWID(), Name, LOWER(Name), 0, @CurrentTimeUtc
    FROM   @tbNames

  INSERT INTO @tbUsers
    SELECT  UserId
    FROM dbo.aspnet_Users au, @tbNames t
    WHERE   LOWER(t.Name) = au.LoweredUserName AND au.ApplicationId = @AppId
 END

 IF (EXISTS (SELECT * FROM dbo.aspnet_UsersInRoles ur, @tbUsers tu, @tbRoles tr WHERE tu.UserId = ur.UserId AND tr.RoleId = ur.RoleId))
 BEGIN
  SELECT TOP 1 UserName, RoleName
  FROM   dbo.aspnet_UsersInRoles ur, @tbUsers tu, @tbRoles tr, aspnet_Users u, aspnet_Roles r
  WHERE  u.UserId = tu.UserId AND r.RoleId = tr.RoleId AND tu.UserId = ur.UserId AND tr.RoleId = ur.RoleId

  IF( @TranStarted = 1 )
   ROLLBACK TRANSACTION
  RETURN(3)
 END

 INSERT INTO dbo.aspnet_UsersInRoles (UserId, RoleId)
 SELECT UserId, RoleId
 FROM @tbUsers, @tbRoles

 IF( @TranStarted = 1 )
  COMMIT TRANSACTION
 RETURN(0)
END
GO
/****** Object:  Table [dbo].[ModuleControls]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleControls](
	[ModuleControlID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleDefID] [int] NULL,
	[ControlKey] [nvarchar](50) NULL,
	[ControlTitle] [nvarchar](50) NULL,
	[ControlSrc] [nvarchar](256) NULL,
	[IconFile] [nvarchar](100) NULL,
	[ControlType] [int] NULL,
	[DisplayOrder] [int] NULL,
	[HelpUrl] [nvarchar](200) NULL,
	[SupportsPartialRendering] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_ModuleControls] PRIMARY KEY CLUSTERED 
(
	[ModuleControlID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  View [dbo].[vw_SageFrameUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_SageFrameUser]
AS
SELECT     dbo.aspnet_Users.UserId, dbo.aspnet_Users.UserName, dbo.Users.FirstName, dbo.Users.LastName, dbo.aspnet_Users.LoweredUserName, 
                      dbo.aspnet_Users.LastActivityDate, dbo.aspnet_Membership.Email, dbo.aspnet_Membership.LastLoginDate, 
                      dbo.aspnet_Membership.LastPasswordChangedDate, dbo.aspnet_Membership.LastLockoutDate, dbo.PortalUser.PortalID, 
                      dbo.Portal.SEOName AS PortalSEOName, dbo.Users.IsActive, dbo.Users.IsModified, dbo.Users.AddedOn, dbo.Users.UpdatedOn, dbo.Users.DeletedOn,
                       dbo.Users.AddedBy, dbo.Users.UpdatedBy, dbo.Users.DeletedBy, dbo.Users.IsDeleted
FROM         dbo.Users INNER JOIN
                      dbo.aspnet_Users ON dbo.Users.Username = dbo.aspnet_Users.UserName INNER JOIN
                      dbo.aspnet_Membership ON dbo.aspnet_Membership.UserId = dbo.aspnet_Users.UserId INNER JOIN
                      dbo.PortalUser ON dbo.Users.Username = dbo.PortalUser.Username INNER JOIN
                      dbo.Portal ON dbo.PortalUser.PortalID = dbo.Portal.PortalID
WHERE     (dbo.Users.IsDeleted = 0) OR
                      (dbo.Users.IsDeleted IS NULL)
GO
/****** Object:  View [dbo].[vw_PortalUsers]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_PortalUsers] 
as
SELECT     dbo.aspnet_Users.UserId, dbo.aspnet_Users.UserName, dbo.aspnet_Users.LoweredUserName
   , dbo.aspnet_Users.LastActivityDate, dbo.aspnet_Membership.Email
   , dbo.aspnet_Membership.LastLoginDate, dbo.aspnet_Membership.LastPasswordChangedDate
            , dbo.aspnet_Membership.LastLockoutDate, dbo.PortalUser.PortalID 
          ,dbo.Portal.SEOName AS PortalSEOName, dbo.PortalUser.LastName, dbo.PortalUser.FirstName
          , dbo.PortalUser.IsActive, dbo.PortalUser.IsModified, 
          dbo.PortalUser.AddedOn, dbo.PortalUser.UpdatedOn, dbo.PortalUser.DeletedOn, dbo.PortalUser.AddedBy
          , dbo.PortalUser.UpdatedBy, dbo.PortalUser.DeletedBy, 
          dbo.PortalUser.IsDeleted
FROM         dbo.aspnet_Users 
    INNER JOIN   dbo.aspnet_Membership ON dbo.aspnet_Membership.UserId = dbo.aspnet_Users.UserId 
    INNER JOIN   dbo.PortalUser ON dbo.aspnet_Users.UserId = dbo.PortalUser.UserID
    INNER JOIN   dbo.Portal ON dbo.PortalUser.PortalID = dbo.Portal.PortalID
WHERE     (dbo.PortalUser.IsDeleted = 0) OR
                      (dbo.PortalUser.IsDeleted IS NULL) AND (dbo.PortalUser.IsActive = 1)
GO
/****** Object:  StoredProcedure [dbo].[usp_PortalUserListGet]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PortalUserListGet] 
(
 @PortalID INT
)
AS
SELECT
 [PortalUserID],
 [PortalID],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn], 
 [AddedBy],
 [UpdatedBy],
 [DeletedBy],
 [dbo].[aspnet_users].*
FROM [dbo].PortalUser
INNER JOIN dbo.aspnet_Users ON dbo.PortalUser.UserID =dbo.aspnet_Users.UserId
WHERE [dbo].[PortalUser].[PortalID]=@PortalID  or [dbo].[PortalUser].Username in
(select p.UserName from PortalUser p
INNER JOIN aspnet_usersinroles AU
ON P.UserID=AU.UserId INNER JOIN aspnet_roles AR ON AR.RoleId=AU.RoleId AND AR.RoleName='Super User')
GO
/****** Object:  StoredProcedure [dbo].[usp_PortalRoleDelete]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PortalRoleDelete]
(
 @RoleID UNIQUEIDENTIFIER,
 @PortalID INT 
)
WITH EXECUTE AS CALLER
AS
 BEGIN     
  DECLARE @MultipleRole INT
  DECLARE @UserTable TABLE(UserId NVARCHAR(MAX),RoleId NVARCHAR(MAX))
   
  
  INSERT INTO @UserTable SELECT UserId,RoleId FROM dbo.aspnet_UsersInRoles WHERE RoleId=@RoleID
  
    SELECT @MultipleRole = count(roleID) from  aspnet_usersinroles where UserID in (select UserId from @UserTable)  
      IF(@MultipleRole > 1 )
   BEGIN
     DELETE FROM dbo.PortalRole WHERE @RoleId = RoleId AND PortalID=@PortalID   
     DELETE FROM dbo.aspnet_UsersInRoles  WHERE @RoleId = RoleId
     DELETE FROM dbo.aspnet_Roles WHERE @RoleId = RoleId
   END
  ELSE
   BEGIN
     DELETE FROM dbo.aspnet_UsersInRoles WHERE UserId IN(select UserId from @UserTable )
     DELETE FROM dbo.aspnet_membership WHERE UserId IN(select UserId from @UserTable )
     DELETE FROM dbo.aspnet_users WHERE UserId IN(select UserId from @UserTable )
     DELETE FROM dbo.PortalUser WHERE UserId IN(select UserId from @UserTable )  
     
     
     DELETE FROM dbo.PortalRole WHERE @RoleId = RoleId AND PortalID=@PortalID 
     DELETE FROM dbo.aspnet_Roles WHERE @RoleId = RoleId
     
   END
   
  
  
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_IsUserInRole]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_IsUserInRole]
(
 @UserName nvarchar(250),
 @RoleName nvarchar(250),
 @PortalID int
)
RETURNS int
AS
BEGIN
 DECLARE @ReturnValue int
 
 if(@RoleName='Super User')
 BEGIN
 
  
 select @ReturnValue=count(ar.RoleName) from PortalUser pu inner join aspnet_usersinroles au
 on pu.UserID=au.UserID
 inner join aspnet_roles ar
 on au.RoleID=ar.RoleID
 where pu.Username=@UserName
 and ar.RoleName=@RoleName
 END
 ELSE 
  BEGIN
 
 SELECT @ReturnValue=count(ar.RoleName) from PortalUser pu inner join aspnet_usersinroles au
 on pu.UserID=au.UserID
 inner join aspnet_roles ar
 on au.RoleID=ar.RoleID
 where pu.Username=@UserName
 and (pu.PortalID=@PortalID )
 and ar.RoleName=@RoleName
  END
 
 IF @ReturnValue>0
  SET @ReturnValue=1
 ELSE
  SET @ReturnValue=0

 RETURN @ReturnValue

END
GO
/****** Object:  StoredProcedure [dbo].[sp_UsersUpdateChanges]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UsersUpdateChanges]
 @Usernames NVARCHAR(4000),
 @IsActives NVARCHAR(4000),
 @PortalID INT,
 @UpdatedBy NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN
 DECLARE @tblUsername AS TABLE (
        RowNo int identity(1,1), 
        UserName nvarchar(256)
        )
        
 DECLARE @tblIsActive AS TABLE(
        RowNo int identity(1,1), 
        IsActive bit
       )
 DECLARE @Counter INT
 DECLARE @Count INT
 
 INSERT INTO @tblUsername(UserName)
 SELECT rtrim(ltrim(items)) FROM split(@Usernames,',')
 
 INSERT INTO @tblIsActive(IsActive)
   SELECT rtrim(ltrim(items)) FROM split(@IsActives,',')
 
 SELECT @Count=count(RowNo) FROM @tblUsername
 SET @Counter=1
 WHILE(@Counter<=@Count or @Counter=1)
 BEGIN  
  UPDATE dbo.Users SET 
       IsActive=(SELECT IsActive FROM @tblIsActive where RowNo=@Counter)
       ,UpdatedOn=getdate()
       ,UpdatedBy=@UpdatedBy
  WHERE PortalID=@PortalID AND [Username] = (SELECT UserName FROM @tblUsername where RowNo=@Counter )

  UPDATE dbo.PortalUser SET 
       IsActive=(SELECT IsActive FROM @tblIsActive where RowNo=@Counter)
       ,UpdatedOn=getdate()
       ,UpdatedBy=@UpdatedBy
  WHERE PortalID=@PortalID AND [Username] = (SELECT UserName FROM @tblUsername where RowNo=@Counter )

  UPDATE [dbo].[aspnet_Membership] SET IsApproved=(SELECT IsActive FROM @tblIsActive where RowNo=@Counter) 
  WHERE UserId=(SELECT UserId FROM [dbo].[PortalUser] WHERE ([Username] = (SELECT UserName FROM @tblUsername where RowNo=@Counter) AND PortalID=@PortalID))
  SET @Counter=@Counter+1
 END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UsersDeleteSeleted]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UsersDeleteSeleted] @Usernames NVARCHAR(4000), 
                                               @PortalID  INT, 
                                               @DeletedBy NVARCHAR(256) 
WITH EXECUTE AS caller 
AS 
  BEGIN 
      DECLARE @TblUsername AS TABLE( 
        RowNum   INT, 
        UserName NVARCHAR(256)) 
      DECLARE @UsernameCount INT, 
              @Counter       INT, 
              @tmpUsername   NVARCHAR(256),
     @UserID UNIQUEIDENTIFIER

      INSERT INTO @TblUsername 
                  (RowNum, 
                   UserName) 
      SELECT Row_number()OVER(ORDER BY items), 
             Rtrim(Ltrim(items)) 
      FROM   Split(@Usernames, ',') 

      SELECT @UsernameCount = COUNT(RowNum) 
      FROM   @TblUsername 

      SET @Counter=1 

      WHILE( @Counter <= @UsernameCount ) 
        BEGIN 
            SELECT @tmpUsername = UserName 
            FROM   @TblUsername 
            WHERE  RowNum = @Counter 
            
   SELECT @UserID=UserID FROM PortalUser
   WHERE  UserName=@tmpUsername and (PortalID=@PortalID  or UserId in (SELECT au.UserId  FROM PortalUser P1 INNER JOIN aspnet_usersinroles au
ON P1.UserID=AU.UserId INNER JOIN aspnet_roles AR ON AR.RoleId=AU.RoleId AND AR.RoleName='Super User' AND p1.IsActive=1 AND (p1.IsDeleted =0 OR p1.ISDeleted IS NULL )))

   DELETE             
            FROM   dbo.aspnet_UsersInRoles
   WHERE  dbo.aspnet_UsersInRoles.UserId = @UserID 

            DELETE             
            FROM   dbo.aspnet_membership
   WHERE  dbo.aspnet_membership.UserId = @UserID
            
   DELETE             
            FROM   dbo.aspnet_users
   WHERE  dbo.aspnet_users.UserId = @UserID
            

            DELETE FROM dbo.portaluser 
            WHERE  dbo.portaluser.UserId = @UserID        

            SET @Counter=@Counter + 1 
        END 
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_UserProfileUpdateByProfileID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserProfileUpdateByProfileID] 
 @UserName  nvarchar(256), 
 @ProfileID int, 
 @Value nvarchar(255), 
 @IsActive bit,  
 @IsModified bit, 
 @UpdatedOn datetime, 
 @PortalID int,  
 @UpdatedBy nvarchar(256)  
AS

UPDATE [dbo].[UserProfile] SET 
 [Value] = @Value,
 [IsActive] = @IsActive, 
 [IsModified] = @IsModified, 
 [UpdatedOn] = @UpdatedOn, 
 [UpdatedBy] = @UpdatedBy 
WHERE
 [ProfileID] = @ProfileID and [Username] = @UserName and [PortalID] = @PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_UserProfileUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserProfileUpdate]
 @UserProfileID int, 
 @UserName  nvarchar(256), 
 @ProfileID int, 
 @Value nvarchar(255), 
 @IsActive bit,  
 @IsModified bit, 
 @UpdatedOn datetime, 
 @PortalID int,  
 @UpdatedBy nvarchar(256) 
 
AS

UPDATE [dbo].[UserProfile] SET
 [Username] = @UserName,
 [ProfileID] = @ProfileID,
 [Value] = @Value,
 [IsActive] = @IsActive, 
 [IsModified] = @IsModified, 
 [UpdatedOn] = @UpdatedOn, 
 [PortalID] = @PortalID, 
 [UpdatedBy] = @UpdatedBy
 
WHERE
 [UserProfileID] = @UserProfileID
GO
/****** Object:  StoredProcedure [dbo].[sp_UserProfileListByPortalID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserProfileListByPortalID]
 @PortalID int
AS

SELECT
 [UserProfileID],
 [Username],
 [ProfileID],
 [Value],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[UserProfile]
Where [PortalID]=@PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_UserProfileDeleteByUserProfileID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserProfileDeleteByUserProfileID]
 @UserProfileID int,
 @DeletedBy nvarchar(256)
AS

UPDATE [dbo].[UserProfile] SET 
 [IsDeleted] = 1,
 [DeletedOn] = getdate(), 
 [DeletedBy] = @DeletedBy 
WHERE
 UserProfileID = @UserProfileID
GO
/****** Object:  StoredProcedure [dbo].[sp_UserProfileAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserProfileAdd]
 @UserProfileID INT OUTPUT,
 @UserName  NVARCHAR(256),
 @ProfileID INT,
 @Value NVARCHAR(255),
 @IsActive BIT, 
 @AddedOn DATETIME, 
 @PortalID INT,
 @AddedBy NVARCHAR(256) 
AS
IF(NOT EXISTS(SELECT * FROM [dbo].[UserProfile] WHERE [ProfileID] = @ProfileID and [Username] = @UserName and [PortalID] = @PortalID))
 BEGIN
  INSERT INTO [dbo].[UserProfile] (
   [Username],
   [ProfileID],
   [Value],
   [IsActive], 
   [AddedOn], 
   [PortalID],
   [AddedBy]
  ) VALUES (
   @UserName,
   @ProfileID,
   @Value,
   @IsActive, 
   @AddedOn, 
   @PortalID,
   @AddedBy
  )

  SET @UserProfileID = SCOPE_IDENTITY()
 End
ElSE
 BEGIN
  UPDATE [dbo].[UserProfile] SET 
   [Value] = @Value,
   [IsActive] = @IsActive, 
   [IsModified] = 1, 
   [UpdatedOn] = @AddedOn, 
   [UpdatedBy] = @AddedBy 
  WHERE
   [ProfileID] = @ProfileID and [Username] = @UserName and [PortalID] = @PortalID

  SET @UserProfileID = 0
 End
GO
/****** Object:  StoredProcedure [dbo].[sp_UserExportList]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserExportList] 
 
AS
BEGIN
SELECT PU.[UserID],
	PU.[Username],
	PU.[FirstName],
	PU.[LastName],
	PU.[Email],
	am.[Password],
	am.[PasswordFormat],
	RoleName = 
        STUFF((SELECT ', ' + RoleName
           FROM aspnet_UsersInRoles  aum1
	INNER JOIN aspnet_Roles  as ar1
	ON aum1.RoleId = ar1.RoleId 
	where 
          aum1.UserId=am.UserId
          FOR XML PATH('')), 1, 2, ''),
	PU.[PortalID],
	am.[IsApproved],
	am.[PasswordSalt]
	FROM
	dbo.aspnet_Membership as am 
	INNER JOIN PortalUser as PU
	ON pu.UserID = am.UserId
	
	WHERE (PU.[IsDeleted]=0 OR PU.[IsDeleted] IS NULL) 
	 AND PU.[Username] NOT IN ('superuser','admin')
	ORDER BY PU.AddedOn DESC 
END
GO
/****** Object:  Table [dbo].[ModuleDefPermission]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleDefPermission](
	[ModuleDefPermissionID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleDefID] [int] NULL,
	[PermissionID] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_MainModulePermission] PRIMARY KEY CLUSTERED 
(
	[ModuleDefPermissionID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardQuickLinkGetAll]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardQuickLinkGetAll]
(
 @UserName NVARCHAR(50),
 @PortalID INT
) 
AS

 BEGIN 
      SELECT DISTINCT p.pageid, p.pagename, p.tabpath AS URL, 
                      p.iconfile, ds.imagepath, p.title, 
                      p.seoname, ds.DisplayName, ds.DisplayOrder,
      ds.QuickLinkID
      FROM   dbo.pagepermission pp 
             INNER JOIN dashboardquicklinks ds ON pp.pageid = ds.pageid 
             INNER JOIN pages p ON ds.pageid = p.pageid 
      WHERE  pp.roleid IN (SELECT roleid FROM   dbo.aspnet_usersinroles 
                          INNER JOIN dbo.aspnet_users ON dbo.aspnet_usersinroles.userid = dbo.aspnet_users.userid 
                           WHERE  dbo.aspnet_users.username = @UserName)
   AND (p.PortalID=@PortalID OR p.PortalID=-1)   
   ORDER BY ds.DisplayOrder ASC

  END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardQuickLinkGet]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardQuickLinkGet]  --'superuser',1
(
 @UserName NVARCHAR(50),
 @PortalID INT
)
AS

 BEGIN 
      SELECT DISTINCT p.pageid, p.pagename, p.tabpath AS URL, 
                      p.iconfile, ds.imagepath, p.title, 
                      p.seoname, ds.DisplayName, ds.DisplayOrder,
      ds.QuickLinkID
      FROM   dbo.pagepermission pp 
             INNER JOIN dashboardquicklinks ds ON pp.pageid = ds.pageid 
             INNER JOIN pages p ON ds.pageid = p.pageid 
      WHERE  pp.roleid IN (SELECT roleid FROM   dbo.aspnet_usersinroles 
                               INNER JOIN dbo.aspnet_users ON dbo.aspnet_usersinroles.userid = dbo.aspnet_users.userid 
                           WHERE  dbo.aspnet_users.username = @UserName)
   AND (p.PortalID=@PortalID OR p.PortalID=-1) AND ds.IsActive=1
   ORDER BY ds.DisplayOrder ASC
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalRoleList]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalRoleList]
 @PortalID INT,
 @IsAll BIT,
 @UserName NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN 
SET NOCOUNT ON ;

DECLARE @UserHasHostRole BIT, @HostRoleId UNIQUEIDENTIFIER
 
 SELECT @HostRoleId=RoleId FROM dbo.aspnet_roles WHERE RoleName='Super User'
 
 IF(EXISTS(SELECT 1 FROM dbo.Aspnet_usersinroles uir 
    INNER JOIN dbo.Aspnet_users u ON uir.UserId=u.UserId 
    INNER JOIN dbo.Aspnet_roles r ON uir.RoleId = r.RoleId 
    WHERE u.Username=@UserName AND r.RoleName='Super User'))
  BEGIN
   SET @UserHasHostRole=1
  END
 ELSE
  BEGIN
   SET @UserHasHostRole=0
  END
  
 IF(@IsAll=1 OR @UserHasHostRole=1)
 SELECT
  [dbo].[PortalRole].[PortalRoleID],
  [dbo].[PortalRole].[RoleID],
  [dbo].[aspnet_roles].RoleName
 -- [dbo].[PortalRole].[PortalID],   
  --,
  --[dbo].[PortalRole].[IsActive],
  --[dbo].[PortalRole].[IsDeleted],
  --[dbo].[PortalRole].[IsModified],
  --[dbo].[PortalRole].[AddedOn],
  --[dbo].[PortalRole].[UpdatedOn],
  --[dbo].[PortalRole].[DeletedOn],
  --[dbo].[PortalRole].[AddedBy],
  --[dbo].[PortalRole].[UpdatedBy],
  --[dbo].[PortalRole].[DeletedBy]
 FROM [dbo].[PortalRole]
  LEFT JOIN [dbo].[Aspnet_roles] ON [dbo].[Aspnet_roles].RoleId = [dbo].[PortalRole].RoleID
 WHERE ([dbo].[PortalRole].[PortalID]=@PortalID OR [dbo].[PortalRole].[PortalID]=-1) AND 
   ([dbo].[Aspnet_roles].RoleName<>'Anonymous User' OR @IsAll=1)
 ELSE
  SELECT
  [dbo].[PortalRole].[PortalRoleID], 
  [dbo].[PortalRole].[RoleID],
  [dbo].[aspnet_roles].RoleName
    --[dbo].[PortalRole].[PortalID],   --,
  --[dbo].[PortalRole].[IsActive],
  --[dbo].[PortalRole].[IsDeleted],
  --[dbo].[PortalRole].[IsModified],
  --[dbo].[PortalRole].[AddedOn],
  --[dbo].[PortalRole].[UpdatedOn],
  --[dbo].[PortalRole].[DeletedOn],
  --[dbo].[PortalRole].[AddedBy],
  --[dbo].[PortalRole].[UpdatedBy],
  --[dbo].[PortalRole].[DeletedBy]
 FROM [dbo].[PortalRole]
  LEFT JOIN [dbo].[Aspnet_roles] ON [dbo].[Aspnet_roles].RoleId = [dbo].[PortalRole].RoleID
 WHERE ([dbo].[PortalRole].[PortalID]=@PortalID OR [dbo].[PortalRole].[PortalID]=-1) AND 
 [dbo].[Aspnet_roles].RoleId<>@HostRoleId  AND ([dbo].[Aspnet_roles].RoleName<>'Anonymous User' OR @IsAll=1)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalModulesUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalModulesUpdate] 
 @ModuleIDs NVARCHAR (4000),
 @IsActives NVARCHAR(4000),
 @PortalID INT,
 @UpdatedBy NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN 
 DECLARE @TblModuleIDs AS TABLE (
        RowNo INT IDENTITY(1,1), 
        ModuleID INT
        )
        
 DECLARE @TblIsActive AS TABLE(
        RowNo INT IDENTITY(1,1), 
        IsActive BIT
       )
 DECLARE @Counter INT
 DECLARE @Count INT

 INSERT INTO @TblModuleIDs(ModuleID)
   SELECT RTRIM(LTRIM(items)) FROM split(@ModuleIDs,',')
 
 INSERT INTO @TblIsActive(IsActive)
   SELECT RTRIM(LTRIM(items)) FROM split(@IsActives,',')
 
 SELECT @Count=COUNT(RowNo) FROM @TblModuleIDs
 SET @Counter=1
 WHILE(@Counter<=@Count or @Counter=1)
 BEGIN
IF(EXISTS(SELECT * FROM dbo.PortalModules WHERE PortalID=@PortalID AND 
[ModuleID] = (SELECT [ModuleID] FROM @TblModuleIDs WHERE RowNo=@Counter )))
 BEGIN
   UPDATE dbo.PortalModules SET 
        IsActive=(SELECT IsActive FROM @TblIsActive WHERE RowNo=@Counter)
        ,UpdatedOn=GETDATE()
        ,UpdatedBy=@UpdatedBy
   WHERE PortalID=@PortalID AND [ModuleID] = (SELECT [ModuleID] FROM @TblModuleIDs WHERE RowNo=@Counter )
 END
ELSE
 BEGIN
  DECLARE @ModuleID INT, @IsActive BIT
  SELECT @ModuleID=[ModuleID] FROM @TblModuleIDs WHERE RowNo=@Counter
  SELECT @IsActive=IsActive FROM @TblIsActive WHERE RowNo=@Counter
  INSERT INTO dbo.PortalModules (
  [PortalID],
  [ModuleID],
  [IsActive],
  [AddedOn],
  [AddedBy]
 ) VALUES (
  @PortalID,
  @ModuleID,
  @IsActive,
  GETDATE(),
  @UpdatedBy
 )
 END
  SET @Counter=@Counter+1
 END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalModulesGetByPortalID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalModulesGetByPortalID]
 @PortalID INT,
 @UserName NVARCHAR(256)
AS
BEGIN
 SELECT
 dbo.Modules.*, CAST(ISNULL((SELECT IsActive FROM dbo.PortalModules 
 WHERE dbo.PortalModules.IsActive=1 AND (dbo.PortalModules.IsDeleted=0 OR 
 dbo.PortalModules.IsDeleted Is Null) AND (dbo.PortalModules.[PortalID] = @PortalID) AND 
 ModuleID=dbo.Modules.ModuleID),0) AS BIT) AS IsPortalModuleActive
FROM dbo.Modules 
WHERE dbo.Modules.IsActive=1 AND (dbo.Modules.IsDeleted=0 or dbo.Modules.IsDeleted Is Null)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalModulesAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalModulesAdd]
 -- Add the parameters for the stored procedure here
 @PortalModuleID INT=NULL OUTPUT,
 @PortalID INT,
 @ModuleID INT,
 @IsActive BIT,
 @AddedOn DATETIME,
 @AddedBy NVARCHAR(256)
AS
BEGIN
IF (@PortalID !=1)
 BEGIN
 INSERT INTO dbo.PortalModules (
 [PortalID],
 [ModuleID],
 [IsActive],
 [AddedOn],
 [AddedBy]
) VALUES (
 @PortalID,
 @ModuleID,
 @IsActive,
 @AddedOn,
 @AddedBy
)
SET @PortalModuleID = SCOPE_IDENTITY()
 END
SET @PortalID=1
 INSERT INTO dbo.PortalModules (
 [PortalID],
 [ModuleID],
 [IsActive],
 [AddedOn],
 [AddedBy]
) VALUES (
 @PortalID,
 @ModuleID,
 @IsActive,
 @AddedOn,
 @AddedBy
)
SET @PortalModuleID = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesGetByModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PackagesGetByModules]
 @ModuleID int
AS

SELECT
 [PackageID],
 [PortalID],
 [ModuleID],
 [Name],
 [FriendlyName],
 [Description],
 [PackageType],
 [Version],
 [License],
 [Manifest],
 [Owner],
 [Organization],
 [Url],
 [Email],
 [ReleaseNotes],
 [IsSystemPackage],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[Packages]
WHERE
 [ModuleID]=@ModuleID
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesGetByModuleIDAndPortalID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[sp_PackagesGetByModuleIDAndPortalID]
 @PackageID int,
 @ModuleID int,
 @PortalID int  
AS

SELECT
 [PackageID],
 [PortalID],
 [ModuleID],
 [Name],
 [FriendlyName],
 [Description],
 [PackageType],
 [Version],
 [License],
 [Manifest],
 [Owner],
 [Organization],
 [Url],
 [Email],
 [ReleaseNotes],
 [IsSystemPackage],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[Packages]
WHERE
 [PackageID] = @PackageID
 AND ModuleID = @ModuleID
 --AND PortalID = @PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesDeleteByModuleID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PackagesDeleteByModuleID]
 @PortalID int,
 @ModuleID int,
 @DeletedBy nvarchar(256)
 AS
 BEGIN
 UPDATE [dbo].[Packages] SET
 [IsDeleted]=1,
 [DeletedOn]=getdate(),
 [DeletedBy]=@DeletedBy
 WHERE ModuleID=@ModuleID --AND PortalID=@PortalID
 
 UPDATE [dbo].[ModuleDefinitions] SET 
 [IsDeleted]=1,
 [DeletedOn]=getdate(),
 [DeletedBy]=@DeletedBy
 WHERE ModuleID=@ModuleID 

 UPDATE [dbo].[Modules] SET
 [IsDeleted]=1,
 [DeletedOn]=getdate(),
 [DeletedBy]=@DeletedBy
 WHERE ModuleID=@ModuleID --AND PortalID=@PortalID

 UPDATE [dbo].[PortalModules] SET
 [IsDeleted]=1,
 [DeletedOn]=getdate(),
 [DeletedBy]=@DeletedBy
 WHERE ModuleID=@ModuleID 

 END
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesDeleteByModuleDefID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PackagesDeleteByModuleDefID]
 @PortalID int,
 @ModuleDefID int,
 @DeletedBy nvarchar(256)
 AS
 BEGIN
 UPDATE [dbo].[ModuleDefinitions] SET
 [IsDeleted]=1,
 [DeletedOn]=getdate(),
 [DeletedBy]=@DeletedBy
 WHERE ModuleDefID=@ModuleDefID --AND PortalID=@PortalID
 END
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesDelete]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PackagesDelete]
 @PackageID int,
 @DeletedBy nvarchar(256),
 @PortalID int
AS

UPDATE [dbo].[Packages] SET
 [IsDeleted] = 1, 
 [DeletedOn] = getdate(), 
 [DeletedBy] = @DeletedBy
WHERE
 [PackageID] = @PackageID
 --AND [PortalID]=@PortalID
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PackagesAdd]
 @PackageID int output,
 @PortalID int,
 @ModuleID int,
 @Name nvarchar(128),
 @FriendlyName nvarchar(250),
 @Description nvarchar(2000),
 @PackageType nvarchar(100),
 @Version nvarchar(50),
 @License ntext,
 @Manifest ntext,
 @Owner nvarchar(100),
 @Organization nvarchar(100),
 @Url nvarchar(250),
 @Email nvarchar(100),
 @ReleaseNotes ntext,
 @IsSystemPackage bit,
 @IsActive bit,
 @AddedOn datetime,
 @AddedBy nvarchar(256)
AS

SET @PortalID = 1
INSERT INTO [dbo].[Packages] (
 [PortalID],
 [ModuleID],
 [Name],
 [FriendlyName],
 [Description],
 [PackageType],
 [Version],
 [License],
 [Manifest],
 [Owner],
 [Organization],
 [Url],
 [Email],
 [ReleaseNotes],
 [IsSystemPackage],
 [IsActive],
 [AddedOn],
 [AddedBy]
) VALUES (
 @PortalID,
 @ModuleID,
 @Name,
 @FriendlyName,
 @Description,
 @PackageType,
 @Version,
 @License,
 @Manifest,
 @Owner,
 @Organization,
 @Url,
 @Email,
 @ReleaseNotes,
 @IsSystemPackage,
 @IsActive,
 @AddedOn,
 @AddedBy
)

select @PackageID=SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPagePermissionByPageID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: <05 sep 2011>

-- ============================================= 
CREATE PROCEDURE [dbo].[sp_GetPagePermissionByPageID]
 @PageID    INT,
 @portalID INT
AS
BEGIN
 SELECT  * FROM dbo.PagePermission WHERE  PageID = @PageID  AND portalID = @PortalID
END
/****** Object:  StoredProcedure [dbo].[sp_GetPageSetting]    Script Date: 12/02/2012 12:43:32 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesGetByPortalIDAdmin]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModulesGetByPortalIDAdmin]
 @PortalID int
AS
SELECT
 [dbo].[Modules].[ModuleID],
 [dbo].[Modules].[FriendlyName],
 [dbo].[Modules].[Description],
 [dbo].[Modules].[Version],
 [dbo].[Modules].[IsPremium],
 [dbo].[Modules].[IsAdmin],
 [dbo].[Modules].[BusinessControllerClass],
 [dbo].[Modules].[FolderName],
 [dbo].[Modules].[ModuleName],
 [dbo].[Modules].[SupportedFeatures],
 [dbo].[Modules].[CompatibleVersions],
 [dbo].[Modules].[Dependencies],
 [dbo].[Modules].[Permissions],
 [dbo].[Modules].[PackageID],
 [dbo].[Modules].[IsActive],
 [dbo].[Modules].[IsDeleted],
 [dbo].[Modules].[IsModified],
 [dbo].[Modules].[AddedOn],
 [dbo].[Modules].[UpdatedOn],
 [dbo].[Modules].[DeletedOn],
 [dbo].[Modules].[PortalID],
 [dbo].[Modules].[AddedBy],
 [dbo].[Modules].[UpdatedBy],
 [dbo].[Modules].[DeletedBy]
FROM [dbo].[Modules]
INNER JOIN dbo.PortalModules ON [dbo].[Modules].[ModuleID] = dbo.PortalModules.[ModuleID]
WHERE
 dbo.PortalModules.[PortalID]=@PortalID AND (dbo.PortalModules.IsDeleted=0 or dbo.PortalModules.IsDeleted IS NULL) AND dbo.PortalModules.IsActive =1
ORDER BY [dbo].[Modules].[FriendlyName]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesGetByPortalID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModulesGetByPortalID]
 @PortalID int
AS
SELECT
 [dbo].[Modules].[ModuleID],
 [dbo].[Modules].[FriendlyName],
 [dbo].[Modules].[Description],
 [dbo].[Modules].[Version],
 [dbo].[Modules].[IsPremium],
 [dbo].[Modules].[IsAdmin],
 [dbo].[Modules].[BusinessControllerClass],
 [dbo].[Modules].[FolderName],
 [dbo].[Modules].[ModuleName],
 [dbo].[Modules].[SupportedFeatures],
 [dbo].[Modules].[CompatibleVersions],
 [dbo].[Modules].[Dependencies],
 [dbo].[Modules].[Permissions],
 [dbo].[Modules].[PackageID],
 [dbo].[Modules].[IsActive],
 [dbo].[Modules].[IsDeleted],
 [dbo].[Modules].[IsModified],
 [dbo].[Modules].[AddedOn],
 [dbo].[Modules].[UpdatedOn],
 [dbo].[Modules].[DeletedOn],
 [dbo].[Modules].[PortalID],
 [dbo].[Modules].[AddedBy],
 [dbo].[Modules].[UpdatedBy],
 [dbo].[Modules].[DeletedBy]
FROM [dbo].[Modules]
INNER JOIN dbo.PortalModules ON [dbo].[Modules].[ModuleID] = dbo.PortalModules.[ModuleID]
WHERE
 dbo.PortalModules.[PortalID]=@PortalID AND (dbo.PortalModules.IsDeleted=0 or dbo.PortalModules.IsDeleted IS NULL) AND dbo.PortalModules.IsActive =1 AND [Modules].[ModuleID] NOT IN (SELECT SuperuserModuleID FROm [dbo].SystemConstrains)
ORDER BY [dbo].[Modules].[FriendlyName]
GO
/****** Object:  StoredProcedure [dbo].[sp_PagePermissionDeleteByPageID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Created By Milson Munakami

CREATE PROCEDURE [dbo].[sp_PagePermissionDeleteByPageID]
 @PageID int, 
 @PortalID int,
 @IsAdmin bit
AS
BEGIN
 IF @IsAdmin = 0
 BEGIN
  DELETE [dbo].[PagePermission]
  WHERE [PortalID] = @PortalID AND
   [PageID] = @PageID
 END 
 ELSE
 BEGIN
  DELETE [dbo].[PagePermission]
  WHERE [PageID] = @PageID
 END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PagePermissionByuserNamePermissionInsert]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Milson Munakami
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PagePermissionByuserNamePermissionInsert]
(
 @PageID int,
 @RoleID uniqueidentifier,
 @PermissionID int,
 @AllowAccess bit,
 @UserName nvarchar(800),
 @IsActive bit,
 @AddedOn datetime,
 @PortalID int,
 @AddedBy nvarchar(256)
)
AS
DECLARE @count int
DECLARE @str nvarchar(800)
DECLARE @spot SMALLINT
WHILE @UserName <> ''

BEGIN
 SET @spot = CHARINDEX(',', @UserName)
 IF @spot>0
 BEGIN
  SET @str = LEFT(@UserName, @spot-1)
  SET @UserName = RIGHT(@UserName, LEN(@UserName)-@spot)
 END
 ELSE
 BEGIN
  SET @str = @UserName 
  SET @UserName = ''
 END
-- SELECT @count=count(1) FROM dbo.PagePermission
-- WHERE RoleID=@str AND PageID=@PageID
--IF @count =0
BEGIN
INSERT INTO dbo.PagePermission
 (PageID,
 PermissionID,
 AllowAccess,
 RoleID,
 Username,
 IsActive,
 AddedOn,
 PortalID,
 AddedBy
)
VALUES
 (@PageID,
 @PermissionID,
 @AllowAccess,
 @RoleID,
 @str,
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)
END
END
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_PagePermissionByRolePermissionInsert]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Milson Munakami
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_PagePermissionByRolePermissionInsert]
(
 @PageID int,
 @RoleID nvarchar(800),
 @PermissionID int,
 @AllowAccess bit,
 @UserName nvarchar(256),
 @IsActive bit,
 @AddedOn datetime,
 @PortalID int,
 @AddedBy nvarchar(256)
)
AS
DECLARE @count int
DECLARE @str nvarchar(800)
DECLARE @spot SMALLINT
WHILE @RoleID <> ''

BEGIN
 SET @spot = CHARINDEX(',', @RoleID)
 IF @spot>0
 BEGIN
  SET @str = CAST(LEFT(@RoleID, @spot-1) AS uniqueidentifier)
  SET @RoleID = RIGHT(@RoleID, LEN(@RoleID)-@spot)
 END
 ELSE
 BEGIN
  SET @str = CAST(@RoleID AS uniqueidentifier)
  SET @RoleID = ''
 END
-- SELECT @count=count(1) FROM dbo.PagePermission
-- WHERE RoleID=@str AND PageID=@PageID
--IF @count =0
BEGIN
INSERT INTO dbo.PagePermission
 (PageID,
 PermissionID,
 AllowAccess,
 RoleID,
 Username,
 IsActive,
 AddedOn,
 PortalID,
 AddedBy
)
VALUES
 (@PageID,
 @PermissionID,
 @AllowAccess,
 @str,
 @UserName,
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)
END
END
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_PageGetByParentID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- CREATED BY: Dinesh Hona
-- CREATED DATE: 2010-03-24
-- MODIFIED BY: Dinesh Hona 
-- MODIFIED DATE: 2010-07-18
CREATE PROCEDURE [dbo].[sp_PageGetByParentID]
 @ParentID int,
 @IsActive [bit]=null,
 @IsVisible [bit]=null,
 @IsRequiredPage bit=null,
 @UserName nvarchar(256),
 @PortalID int
AS
BEGIN
SELECT DISTINCT [dbo].[Pages].* 
FROM   [dbo].[Pages] 
    INNER JOIN  [dbo].[PagePermission]  ON [dbo].[PagePermission].PageID = [dbo].[Pages].PageID
WHERE ([dbo].[PagePermission].[RoleID] IN (SELECT [dbo].[aspnet_UsersInRoles].RoleId
           FROM [dbo].[aspnet_UsersInRoles]
           INNER JOIN [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].UserId = [dbo].[aspnet_UsersInRoles].UserId
           WHERE [dbo].[aspnet_Users].UserName = @UserName)
  OR [dbo].[PagePermission].Username=@UserName ) AND [dbo].[Pages].ParentID=@ParentID
 AND ([dbo].[Pages].IsDeleted=0 OR [dbo].[Pages].IsDeleted IS NULL)
 AND ([dbo].[Pages].IsActive=@IsActive OR @IsActive IS NULL)
 AND ([dbo].[Pages].IsVisible=@IsVisible OR @IsVisible IS NULL) AND ([dbo].[Pages].IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL)
 AND [dbo].[Pages].PortalID=@PortalID
ORDER BY [dbo].[Pages].PageOrder Asc
END



SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_PageGetByCustomPrefix]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: Dinesh Hona
--Modified BY: Dinesh Hona
--Modified DAte: 2010-04-13,2010-05-7,2010-07-19
CREATE PROCEDURE [dbo].[sp_PageGetByCustomPrefix]
 @prefix [nvarchar](10),
 @IsActive [bit],
 @IsDeleted [bit],
 @PortalID [int],
 @UserName [nvarchar](256),
 @IsVisible [bit],
 @IsRequiredPage bit
WITH EXECUTE AS CALLER
AS
BEGIN
select distinct dbo.pagepermission.PageID INTO #tblPages from dbo.pagepermission 
WHERE RoleID in (Select RoleId from dbo.aspnet_usersinroles INNER JOIN dbo.aspnet_users ON dbo.aspnet_usersinroles.UserId=dbo.aspnet_users.UserId WHERE dbo.aspnet_users.Username=@UserName) ;
with PageOrders([PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshInterval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,[newOrder]) 
AS
(
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(convert(int,ISnull(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshInterval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST(P1.[PageOrder] as varchar(100)) as [newOrder]
 FROM [dbo].[Pages] AS P1 
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
 where (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) AND P1.ParentID=0 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) AND P1.DisableLink=0
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(convert(int,ISnull(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshInterval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] as varchar(10))+'.'+ CAST(Right('00'+CAST(P1.[PageOrder] as varchar(2)),2) as varchar(89))  as [newOrder]
 FROM [dbo].[Pages] AS P1
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID]
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) AND P1.[Level]=1 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) AND P1.DisableLink=0
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(convert(int,ISnull(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshInterval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] as varchar(10))+CAST(Right('00'+CAST(P1.[PageOrder] as varchar(2)),2) as varchar(90))  as [newOrder]
 FROM [dbo].[Pages] AS P1
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID]
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) AND P1.[Level]>1 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL)  AND P1.DisableLink=0
)
select [PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshInterval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,Cast([newOrder] as DECIMAL(38,10)) as [newOrder] INTO #TEMP from PageOrders
ORDER BY [newOrder]

SELECT P1.[PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshInterval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,(SELECT MAX([PageOrder]) FROM [dbo].[Pages] as m WHERE m.PageOrder<5000 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) as [MaxPageOrder]
      ,(SELECT MIN([PageOrder]) FROM [dbo].[Pages] as m WHERE m.PageOrder<5000 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) as [MinPageOrder] 
FROM #TEMP AS P1 ORDER BY [newOrder]
DROP TABLE #TEMP
DROP TABLE #tblPages
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesUpdateChanges]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  Milson Munakami
-- Create date: 2010-06-27
-- Description: Package IsActive Management
-- =============================================
CREATE PROCEDURE [dbo].[sp_PackagesUpdateChanges]
 @ModuleIDs [nvarchar](4000),
 @IsActives [nvarchar](4000),
 @UpdatedBy [nvarchar](256)
WITH EXECUTE AS CALLER
AS
BEGIN
 DECLARE @tblModuleIDs AS TABLE (
        rowno int identity(1,1), 
        ModuleID nvarchar(256)
        )
        
 DECLARE @tblIsActive AS TABLE(
        rowno int identity(1,1), 
        IsActive bit
       )
 DECLARE @Counter int
 DECLARE @Count int
 
 INSERT INTO @tblModuleIDs(ModuleID)
 SELECT rtrim(ltrim(items)) FROM split(@ModuleIDs,',')
 
 INSERT INTO @tblIsActive(IsActive)
   SELECT rtrim(ltrim(items)) FROM split(@IsActives,',')
 
 SELECT @Count=count(rowno) FROM @tblModuleIDs
 SET @counter=1
 WHILE(@counter<=@Count or @counter=1)
 BEGIN  

 UPDATE [dbo].[Packages] SET
 IsActive=(SELECT IsActive FROM @tblIsActive where rowno=@counter)
       ,UpdatedOn=getdate()
       ,UpdatedBy=@UpdatedBy
  WHERE [ModuleID] = (SELECT ModuleID FROM @tblModuleIDs where rowno=@counter ) 

 UPDATE [dbo].[ModuleDefinitions] SET 
 IsActive=(SELECT IsActive FROM @tblIsActive where rowno=@counter)
       ,UpdatedOn=getdate()
       ,UpdatedBy=@UpdatedBy
  WHERE [ModuleID] = (SELECT ModuleID FROM @tblModuleIDs where rowno=@counter )

 UPDATE [dbo].[Modules] SET
 IsActive=(SELECT IsActive FROM @tblIsActive where rowno=@counter)
       ,UpdatedOn=getdate()
       ,UpdatedBy=@UpdatedBy
  WHERE [ModuleID] = (SELECT ModuleID FROM @tblModuleIDs where rowno=@counter )

 UPDATE [dbo].[PortalModules] SET
 IsActive=(SELECT IsActive FROM @tblIsActive where rowno=@counter)
       ,UpdatedOn=getdate()
       ,UpdatedBy=@UpdatedBy
  WHERE [ModuleID] = (SELECT ModuleID FROM @tblModuleIDs where rowno=@counter )
SET @counter=@counter+1
 END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesList]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PackagesList]
AS

SELECT
 [PackageID],
 [PortalID],
 [ModuleID],
 [Name],
 [FriendlyName],
 [Description],
 [PackageType],
 [Version],
 [License],
 [Manifest],
 [Owner],
 [Organization],
 [Url],
 [Email],
 [ReleaseNotes],
 [IsSystemPackage],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[Packages]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDefaultList]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetDefaultList] @PortalID INT,
                                          @Culture  NVARCHAR(256)
AS
  BEGIN
      SELECT DISTINCT TOP 1 listname,
                            parentkey
      FROM   dbo.vw_lists
      WHERE  portalid = @PortalID
             AND parentkey = ''
             AND culture = @Culture
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_ExtensionUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-03-20
CREATE PROCEDURE [dbo].[sp_ExtensionUpdate] @ModuleID                INT,
                                           @FolderName              NVARCHAR(128),
                                           @BusinessControllerClass NVARCHAR(200),
                                           @Dependencies            NVARCHAR(400),
                                           @Permissions             NVARCHAR(400),
                                           @IsPortable              BIT,
                                           @IsSearchable            BIT,
                                           @IsUpgradable            BIT,
                                           @IsPremium               BIT,
                                           @PackageName             NVARCHAR(128),
                                           @PackageDescription      NVARCHAR(2000),
                                           @Version                 NVARCHAR(50),
                                           @License                 NTEXT,
                                           @ReleaseNotes            NTEXT,
                                           @Owner                   NVARCHAR(100),
                                           @Organization            NVARCHAR(100),
                                           @Url                     NVARCHAR(250),
                                           @Email                   NVARCHAR(100),
                                           @PortalID                INT,
                                           @UserName                NVARCHAR(256)
AS
  BEGIN
      UPDATE [dbo].[modules]
      SET    description = @PackageDescription,
             version = @Version,
             foldername = @FolderName,
             businesscontrollerclass = @BusinessControllerClass,
             dependencies = @Dependencies,
             [permissions] = @Permissions,
             ispremium = @IsPremium,
             ismodified = 1,
             updatedon = GETDATE(),
             updatedby = @UserName
      WHERE  moduleid = @ModuleID

      UPDATE [dbo].[packages]
      SET    name = @PackageName,
             [description] = @PackageDescription,
             [version] = @Version,
             license = @License,
             releasenotes = @ReleaseNotes,
             [owner] = @Owner,
             organization = @Organization,
             url = @Url,
             email = @Email,
             ismodified = 1,
             updatedon = GETDATE(),
             updatedby = @UserName
      WHERE  [dbo].[packages].moduleid = @ModuleID
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModulesAdd]
 @ModuleID int output,
 @ModuleDefID int output,
 @Name nvarchar(128),
 @PackageType nvarchar(100), 
 @License ntext,
    @Owner nvarchar(100),
    @Organization nvarchar(100),
    @Url nvarchar(250),
    @Email nvarchar(100),
 @ReleaseNotes ntext,
 @FriendlyName nvarchar(128),
 @Description nvarchar(2000),
 @Version nvarchar(8),
 @IsPremium bit,
 @IsAdmin bit,
 @BusinessControllerClass nvarchar(200),
 @FolderName nvarchar(128),
 @ModuleName nvarchar(128),
 @SupportedFeatures int,
 @CompatibleVersions nvarchar(500),
 @Dependencies nvarchar(400),
 @Permissions nvarchar(400),
 @PackageID int,
 @IsActive bit,
 @AddedOn datetime,
 @PortalID int,
 @AddedBy nvarchar(256) 
AS

SET @PortalID=1

BEGIN TRANSACTION

INSERT INTO [dbo].[Modules] (
 [FriendlyName],
 [Description],
 [Version],
 [IsPremium],
 [IsAdmin],
 [BusinessControllerClass],
 [FolderName],
 [ModuleName],
 [SupportedFeatures],
 [CompatibleVersions],
 [Dependencies],
 [Permissions],
 [PackageID],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @FriendlyName,
 @Description,
 @Version,
 @IsPremium,
 @IsAdmin,
 @BusinessControllerClass,
 @FolderName,
 @ModuleName,
 @SupportedFeatures,
 @CompatibleVersions,
 @Dependencies,
 @Permissions,
 @PackageID,
 @IsActive, 
 @AddedOn,
 @PortalID,
 @AddedBy
)

SET @ModuleID = IDENT_CURRENT('Modules')
--INSERT INTO [dbo].[Packages] VALUES (@ObjectID, @DataID)
INSERT INTO [dbo].[ModuleDefinitions] (
 [FriendlyName],
 [ModuleID],
 [DefaultCacheTime],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
)
VALUES (
 @FriendlyName,
 @ModuleID,
 0, 
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)
SET @ModuleDefID = IDENT_CURRENT('ModuleDefinitions')

INSERT INTO [dbo].[Packages]
           ([PortalID]
           ,[ModuleID]
           ,[Name]
           ,[FriendlyName]
           ,[Description]
           ,[PackageType]
           ,[Version]
           ,[License]
           ,[Manifest]
           ,[Owner]
           ,[Organization]
           ,[Url]
           ,[Email]
           ,[ReleaseNotes]
           ,[IsSystemPackage]
           ,[IsActive]
           ,[AddedOn]
           ,[AddedBy])
     VALUES
           (@PortalID
           ,@ModuleID
           ,@Name
           ,@FriendlyName
           ,@Description
           ,@PackageType
           ,@Version
           ,@License
           ,null
           ,@Owner
           ,@Organization
           ,@Url
           ,@Email
           ,@ReleaseNotes
           ,0
           ,1
           ,@AddedOn
           ,@AddedBy)

SET @PackageID = IDENT_CURRENT('Packages')

 UPDATE [dbo].[Modules] SET 
  PackageID = @PackageID
 WHERE
  ModuleID = @ModuleID

COMMIT
--END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModuleDefinitionsUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[sp_ModuleDefinitionsUpdate]
 @ModuleDefID INT, 
 @FriendlyName NVARCHAR(128), 
 @DefaultCacheTime INT, 
 @IsActive BIT,  
 @IsModified BIT, 
 @UpdatedOn DATETIME, 
 @PortalID INT,
 @UpdatedBy NVARCHAR(256)
AS
SET @PortalID = 1
BEGIN
 UPDATE dbo.ModuleDefinitions SET
 [FriendlyName] = @FriendlyName,
 [DefaultCacheTime] = @DefaultCacheTime,
 [IsActive] = @IsActive,
 [IsModified] = @IsModified,
 [UpdatedOn] = @UpdatedOn,
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE
 [ModuleDefID] = @ModuleDefID 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileImageFoldersGet]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_ProfileImageFoldersGet]
 @EditUserName NVARCHAR(256),
 @ProfileID INT,
 @PortalID INT 
AS
BEGIN
 SELECT * FROM dbo.[UserProfile] WHERE [Username]=@EditUserName AND 
 [ProfileID] = @ProfileID AND PortalID=@PortalID
 AND (IsDeleted IS NULL OR IsDeleted=0) AND IsActive = 1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarGetAll]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[usp_DashboardSidebarGetAll] 'superuser', 1
CREATE PROCEDURE [dbo].[usp_DashboardSidebarGetAll] (
 @UserName NVARCHAR(50)
 ,@PortalID INT
 )
AS
BEGIN
 SELECT DISTINCT pp.pageid
  ,p.pagename
  ,p.tabpath AS URL
  ,p.iconfile
  ,ds.imagepath
  ,p.title
  ,p.seoname
  ,ds.DisplayName
  ,ds.Depth
  ,ds.ParentID
  ,(
   SELECT COUNT(*)
   FROM dashboardsidebar d
   WHERE d.ParentID = ds.SidebarItemID
   ) AS ChildCount
  ,ds.DisplayOrder
  ,ds.SidebarItemID
 FROM dbo.pagepermission pp
 INNER JOIN dashboardsidebar ds ON pp.pageid = ds.pageid
 INNER JOIN pages p ON ds.pageid = p.pageid
 WHERE pp.roleid IN (
   SELECT roleid
   FROM dbo.aspnet_usersinroles
   INNER JOIN dbo.aspnet_users ON dbo.aspnet_usersinroles.userid = dbo.aspnet_users.userid
   WHERE dbo.aspnet_users.username = @UserName
   )
  AND (
   p.PortalID = @PortalID
   OR p.PortalID = - 1
   )
  --AND ds.IsActive = 1
 ORDER BY ds.DisplayOrder
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashboardSidebarGet]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashboardSidebarGet]
(
 @UserName NVARCHAR(50),
 @PortalID INT
) 
AS 
  BEGIN 
      SELECT DISTINCT pp.pageid, p.pagename, p.tabpath AS URL, 
                      p.iconfile, ds.imagepath, p.title, 
                      p.seoname, ds.DisplayName, ds.Depth,         
   ds.ParentID,
   (SELECT COUNT(*) FROM dashboardsidebar d WHERE d.ParentID=ds.SidebarItemID) AS ChildCount,
      ds.DisplayOrder, ds.SidebarItemID
      FROM   dbo.pagepermission pp 
             INNER JOIN dashboardsidebar ds ON pp.pageid = ds.pageid 
             INNER JOIN pages p ON ds.pageid = p.pageid 
      WHERE  pp.roleid IN (SELECT roleid FROM   dbo.aspnet_usersinroles 
                          INNER JOIN dbo.aspnet_users ON dbo.aspnet_usersinroles.userid = dbo.aspnet_users.userid 
                           WHERE  dbo.aspnet_users.username = @UserName)
 AND (p.PortalID=@PortalID OR p.PortalID=-1) AND ds.IsActive=1
 ORDER BY ds.DisplayOrder
  END
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_CheckMultiRoleForUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <bhuvan>
-- Create date: <2012-03-22>
-- Description: <Description, ,>
-- =============================================
--select [dbo].[ufn_CheckMultiRoleForUser]('027361E9-9DED-41CE-BA12-411F237D7277')
CREATE FUNCTION [dbo].[ufn_CheckMultiRoleForUser]
(
@UserID uniqueidentifier
)
RETURNS int
AS
BEGIN
 -- Declare the return variable here
 DECLARE @IsMultiRole int
 select @IsMultiRole=count(roleID) from  aspnet_usersinroles where UserID=@UserID
 IF @IsMultiRole>1
  SET @IsMultiRole=1
 ELSE
  SET @IsMultiRole=0

 RETURN @IsMultiRole 

END
GO
/****** Object:  Table [dbo].[UserModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModules](
	[UserModuleID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleDefID] [int] NULL,
	[UserModuleTitle] [nvarchar](256) NULL,
	[AllPages] [bit] NULL,
	[InheritViewPermissions] [bit] NULL,
	[Header] [ntext] NULL,
	[Footer] [ntext] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
	[SEOName] [nvarchar](100) NULL,
	[ShowInPages] [nvarchar](256) NULL,
	[IsHandheld] [bit] NULL,
	[SuffixClass] [nvarchar](max) NULL,
	[HeaderText] [nvarchar](500) NULL,
	[ShowHeaderText] [bit] NULL,
	[IsInAdmin] [bit] NULL,
 CONSTRAINT [PK_Modules] PRIMARY KEY CLUSTERED 
(
	[UserModuleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [ix_UserModules_ModuleDefID_NN] ON [dbo].[UserModules] 
(
	[ModuleDefID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  StoredProcedure [dbo].[aspnet_AnyDataInTables]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_AnyDataInTables]
    @TablesToCheck int
AS
BEGIN
    -- Check Membership table if (@TablesToCheck & 1) is set
    IF ((@TablesToCheck & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Membership))
        BEGIN
            SELECT N'aspnet_Membership'
            RETURN
        END
    END

    -- Check aspnet_Roles table if (@TablesToCheck & 2) is set
    IF ((@TablesToCheck & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Roles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 RoleId FROM dbo.aspnet_Roles))
        BEGIN
            SELECT N'aspnet_Roles'
            RETURN
        END
    END

    -- Check aspnet_Profile table if (@TablesToCheck & 4) is set
    IF ((@TablesToCheck & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Profile))
        BEGIN
            SELECT N'aspnet_Profile'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 8) is set
    IF ((@TablesToCheck & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_PersonalizationPerUser))
        BEGIN
            SELECT N'aspnet_PersonalizationPerUser'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 16) is set
    IF ((@TablesToCheck & 16) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'aspnet_WebEvent_LogEvent') AND (type = 'P'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 * FROM dbo.aspnet_WebEvent_Events))
        BEGIN
            SELECT N'aspnet_WebEvent_Events'
            RETURN
        END
    END

    -- Check aspnet_Users table if (@TablesToCheck & 1,2,4 & 8) are all set
    IF ((@TablesToCheck & 1) <> 0 AND
        (@TablesToCheck & 2) <> 0 AND
        (@TablesToCheck & 4) <> 0 AND
        (@TablesToCheck & 8) <> 0 AND
        (@TablesToCheck & 32) <> 0 AND
        (@TablesToCheck & 128) <> 0 AND
        (@TablesToCheck & 256) <> 0 AND
        (@TablesToCheck & 512) <> 0 AND
        (@TablesToCheck & 1024) <> 0)
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Users))
        BEGIN
            SELECT N'aspnet_Users'
            RETURN
        END
        IF (EXISTS(SELECT TOP 1 ApplicationId FROM dbo.aspnet_Applications))
        BEGIN
            SELECT N'aspnet_Applications'
            RETURN
        END
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsernameByPortalIDAuto]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-03-25
CREATE PROCEDURE [dbo].[sp_GetUsernameByPortalIDAuto]
 @Prefix NVARCHAR(50),
 @Count INT,
 @PortalID INT,
 @UserName NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
DECLARE @DynSQL NVARCHAR(1000),@HostRoleId UNIQUEIDENTIFIER,@UserHasHostRole BIT
SELECT @HostRoleId=RoleId FROM dbo.aspnet_roles WHERE RoleName='Super User'
IF(EXISTS(SELECT * FROM dbo.aspnet_usersinroles uir INNER JOIN dbo.aspnet_users u ON uir.UserId=u.UserId INNER JOIN dbo.aspnet_roles r ON uir.RoleId = r.RoleId WHERE u.Username=@UserName AND r.RoleName='Super User'))
BEGIN
 SET @UserHasHostRole=1
END
ELSE
BEGIN
 SET @UserHasHostRole=0
END
IF @UserHasHostRole=1
BEGIN
 SET @DynSQL='SELECT Top '+CAST(ISNULL(@Count,'1000') AS VARCHAR)+' FirstName+'' ''+LastName as UserName FROM vw_SageFrameUser WHERE (((FirstName like '''+ISNULL(@Prefix,'')+'%'') OR (LastName like '''+ISNULL(@Prefix,'')+'%'')OR (username like '''+ISNULL(@Prefix,'')+'%'') OR (email like '''+ISNULL(@Prefix,'')+'%'') )) AND UserName<>''anonymoususer'' ORDER By FirstName,LastName'
END
ELSE
BEGIN
 SET @DynSQL='SELECT Top '+CAST(ISNULL(@Count,'1000') AS VARCHAR)+' FirstName+'' ''+LastName as UserName FROM vw_SageFrameUser WHERE (((FirstName like '''+ISNULL(@Prefix,'')+'%'') OR (LastName like '''+ISNULL(@Prefix,'')+'%'')OR (username like '''+ISNULL(@Prefix,'')+'%'') OR (email like '''+ISNULL(@Prefix,'')+'%'') ) AND (PortalID='+CONVERT(VARCHAR(100),ISNULL(@PortalID,''))+')) AND UserName<>''anonymoususer'' ORDER By FirstName,LastName'
END
EXECUTE(@DynSQL)
/****** Object:  StoredProcedure [dbo].[sp_GoogleAnalyticsAddUpdate]    Script Date: 12/02/2012 13:30:37 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListsByPortalID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetListsByPortalID]
 
 @PortalID INT,
 @Culture NVARCHAR(256)

AS
 SELECT DISTINCT 
  
  ListName,
  [Level],
  DefinitionID,
  PortalID,
  SystemList,
  EntryCount,
  ParentID,
  ParentKey,
  Parent,
  ParentList,
  MaxSortOrder
 FROM dbo.vw_Lists
 WHERE PortalID = @PortalID
 ORDER BY [Level], ListName
/****** Object:  StoredProcedure [dbo].[sp_GetMessageTemplate]    Script Date: 12/02/2012 12:28:41 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListEntrybyParentId]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetListEntrybyParentId]
  
 @EntryID INT,
 @Culture NVARCHAR(256)
AS
BEGIN

 SELECT *
 FROM dbo.vw_Lists
 WHERE 
  ([ParentID]=@EntryID AND Culture=@Culture)
END 
/****** Object:  StoredProcedure [dbo].[sp_GetListsByPortalID]    Script Date: 12/02/2012 12:26:22 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListEntrybyNameValueAndEntryID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetListEntrybyNameValueAndEntryID]

 @ListName NVARCHAR(50),
 @Value NVARCHAR(200),
 @EntryID INT,
 @Culture NVARCHAR(256)

AS
 SELECT *
 FROM dbo.vw_Lists
 WHERE ([ListName] = @ListName OR @ListName='')
  AND ([EntryID]=@EntryID OR @EntryID = -1)
  AND ([Value]=@Value OR @Value = '') AND Culture=@Culture
  
/****** Object:  StoredProcedure [dbo].[sp_GetListEntrybyParentId]    Script Date: 12/02/2012 12:25:24 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListEntriesByNameParentKeyAndPortalID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetListEntriesByNameParentKeyAndPortalID] 
@ListName nvarchar(50), 
@ParentKey nvarchar(150), 
@PortalID int, 
@Culture nvarchar(256) 
AS BEGIN
SELECT EntryID,ListName,Value,[Text],[LEVEL] as [Level],CurrencyCode,DisplayLocale,DisplayOrder,DefinitionID,ParentID,[Description],PortalID,SystemList,Culture, ParentKey,Parent,ParentList,MaxSortOrder,EntryCount,HasChildren,IsActive,AddedBy,AddedOn,UpdatedBy,UpdatedOn 
FROM dbo.vw_Lists 
WHERE (ListName = @ListName ) AND (ParentKey = @ParentKey ) AND (PortalID = @PortalID OR @PortalID IS NULL or SystemList=1) AND Culture=@Culture 
ORDER BY DisplayOrder
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleMgrSortModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleMgrSortModules]
 @flag INT,
 @isAdmin BIT,
 @PortalID INT,
 @IncludePortalModules int
AS 

--IF @IncludePortalModules=0
 BEGIN
   SELECT 
    m.FriendlyName,
    md.ModuleDefID 
   FROM 
    Modules m 
       INNER JOIN  ModuleDefinitions md  ON  m.ModuleID=md.ModuleID
       INNER JOIN  PortalModules pm ON  md.ModuleID=pm.ModuleID
   WHERE 
     (isnull(m.IsAdmin,0)=@isAdmin)
    AND (
       m.IsDeleted IS NULL 
      OR m.IsDeleted=0
     )
    AND pm.PortalID=@PortalID
    AND pm.IsActive=1
   
   ORDER BY
    CASE 
     WHEN @flag = 0 
      THEN m.FriendlyName 
     END ASC,
    CASE 
     WHEN @flag = 1 
      THEN m.FriendlyName 
     END DESC
     
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_PagesGetPossibleParents]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PagesGetPossibleParents]
 @prefix NVARCHAR(10),
 @IsActive BIT,
 @IsDeleted BIT,
 @PortalID INT,
 @UserName NVARCHAR(256),
 @IsVisible BIT,
 @IsRequiredPage BIT,
 @PageID INT
WITH EXECUTE AS CALLER
AS
BEGIN
--create temp table #TblPages
CREATE TABLE #TblPages
(
 PageID INT
)
CREATE TABLE #Temp
(
 [PageID] INT,
 [PageOrder] INT NULL,
 [PageName] NVARCHAR(100),
 [LevelPageName] NVARCHAR(100),
 [IsVisible] BIT NULL,
 [ParentID] INT NULL,
 [Level] INT NULL,
 [IconFile] NVARCHAR(100),
 [DisableLink] BIT NULL,
 [Title] NVARCHAR(200) NULL,
 [Description] NVARCHAR(500) NULL,
 [KeyWords] NVARCHAR(500)  NULL,
 [Url] NVARCHAR(255) ,
 [TabPath] NVARCHAR(255) NULL,
 [StartDate] DATETIME NULL,
 [EndDate] [datetime] NULL,
 [RefreshInterval] DECIMAL(16, 2) NULL,
 [PageHeadText] NVARCHAR(500) NULL,
 [IsSecure] BIT NOT NULL,
 [IsActive] BIT NULL,
 [IsDeleted] BIT NULL,
 [IsModified] BIT NULL,
 [AddedOn] DATETIME NULL,
 [UpdatedOn] DATETIME NULL,
 [DeletedOn] DATETIME NULL,
 [PortalID] INT NULL,
 [AddedBy] NVARCHAR(256) NULL,
 [UpdatedBy] NVARCHAR(256) NULL,
 [DeletedBy] NVARCHAR(256) NULL,
 [SEOName] NVARCHAR(100) NULL,
 [newOrder] DECIMAL(38,10)
)
INSERT INTO #TblPages
SELECT DISTINCT dbo.PagePermission.PageID FROM dbo.PagePermission 
WHERE RoleID IN (SELECT RoleId FROM dbo.aspnet_UsersInRoles INNER JOIN dbo.aspnet_Users 
ON dbo.aspnet_UsersInRoles.UserId=dbo.aspnet_Users.UserId 
WHERE dbo.aspnet_Users.Username=@UserName  AND dbo.PagePermission.PageID<>@PageID);

WITH PageOrders([PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshInterval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,[newOrder]) 
AS
(
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshInterval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST(P1.[PageOrder] AS VARCHAR(100)) as [newOrder]
 FROM [dbo].[Pages] AS P1 
 INNER JOIN #TblPages ON #TblPages.pageid=P1.PageID
 where (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID 
 AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
 AND P1.ParentID=0 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) 
 AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) AND P1.DisableLink=0
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshInterval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] AS VARCHAR(10))+'.'+ CAST(Right('00'+CAST(P1.[PageOrder] AS VARCHAR(2)),2) AS VARCHAR(89))  AS [newOrder]
 FROM [dbo].[Pages] AS P1
 INNER JOIN #TblPages ON #TblPages.pageid=P1.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID]
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID 
 AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) AND P1.[Level]=1 
 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) 
 AND P1.DisableLink=0
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshInterval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] AS VARCHAR(10))+CAST(Right('00'+CAST(P1.[PageOrder] AS VARCHAR(2)),2) AS VARCHAR(90))  AS [newOrder]
 FROM [dbo].[Pages] AS P1
 INNER JOIN #TblPages ON #TblPages.pageid=P1.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID]
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID
  AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
  AND P1.[Level]>1 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) 
  AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL)  AND P1.DisableLink=0
)


INSERT INTO #Temp
SELECT [PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshInterval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,CAST([newOrder] AS DECIMAL(38,10)) AS [newOrder] FROM PageOrders
ORDER BY [newOrder]


SELECT P1.[PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshInterval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,(SELECT MAX([PageOrder]) FROM [dbo].[Pages] AS m WHERE m.PageOrder<5000 
 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted 
 AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
 AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) AS [MaxPageOrder]
      ,(SELECT MIN([PageOrder]) FROM [dbo].[Pages] AS m WHERE m.PageOrder<5000 
 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted 
 AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
 AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) AS [MinPageOrder] 
FROM #Temp AS P1 ORDER BY [newOrder]
DROP TABLE #Temp
DROP TABLE #TblPages
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuGetSideMenu]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuGetSideMenu] @PortalID    [INT], 
                                                @UserName    [NVARCHAR](256), 
                                                @MenuID      [INT], 
                                                @CultureCode NVARCHAR(10) 
AS 
  BEGIN 
      DECLARE @prefix [NVARCHAR](10) 
      DECLARE @IsActive [BIT] 
      DECLARE @IsDeleted [BIT] 
      DECLARE @IsVisible [BIT] 
      DECLARE @IsRequiredPage BIT 

      --DECLARE @PageID INT   
      SET @prefix='---' 
      SET @IsActive=NULL 
      SET @IsDeleted=0 
      SET @IsVisible=1 
      SET @IsRequiredPage=NULL 

      --Get Highest Parent Page 
      select * 
      Into   #tblTemp 
      from   MenuItem 
      Where  PortalID = @PortalID
             and MenuID = @MenuID 

      ----------------------------- 
      DECLARE @roleid NVARCHAR(100) 

      IF @UserName = 'anonymoususer' 
        BEGIN 
            SET @roleid = (SELECT [RoleId] 
                           FROM   dbo.aspnet_roles 
                           WHERE  loweredrolename = 'anonymous user') 
        END 
      ELSE 
        BEGIN 
            SET @roleid = (SELECT TOP(1) RoleId 
                           FROM   dbo.ASpnet_usersinroles 
                                  INNER JOIN dbo.ASpnet_users 
                                          ON 
                                  dbo.ASpnet_usersinroles.UserId = 
                                  dbo.ASpnet_users.UserId 
                           WHERE  dbo.ASpnet_users.Username = @userName) 
        END 

      SELECT distinct dbo.pagepermission.PageID 
      Into   #tblPages 
      FROM   dbo.pagepermission 
      WHERE  RoleID = @roleid 
             and ( dbo.pagepermission.userName = @userName 
                    or dbo.pagepermission.userName = '' ); 

      with t(menuitemid, PageID, ParentID,MenuOrder) 
           as (select menuitemid, 
                      pageid, 
                      parentid ,MenuOrder
               from   #tblTemp) select t1.PageID, t.MenuOrder AS [newOrder] ,
             case t1.ParentID 
               when 0 then t1.ParentID 
               else t.PageID 
             end                                 as ParentID, 
             t1.menulevel                        as [Level], 
             t1.Title, 
             p.[PageOrder],
             --p.[PageName], 
             ISNULL
        (
         (
          SELECT 
           lp.LocalPageName 
          FROM 
           LocalPage lp 
          WHERE 
            lp.PageID=p.PageID 
           AND lp.CultureCode=@CultureCode
         )
         ,p.PageName
        ) AS PageName,
             ( dbo.fn_LevelPrefix(convert(INT, ISNULL(p.[Level], 0)), @prefix) 
               + p.[PageName] )                  AS [LevelPageName], 
             p.[IsVisible], 
             p.[IconFile], 
             p.[DisableLink], 
             p.[Title], 
             p.[Description], 
             p.[KeyWords], 
             p.[Url], 
             p.[TabPath], 
             p.[StartDate], 
             p.[EndDate], 
             p.[RefreshINTerval], 
             p.[PageHeadText], 
             p.[IsSecure], 
             p.[IsActive], 
             p.[IsDeleted], 
             p.[IsModified], 
             p.[AddedOn], 
             p.[UpdatedOn], 
             p.[DeletedOn], 
             p.[PortalID], 
             p.[AddedBy], 
             p.[UpdatedBy], 
             p.[DeletedBy], 
             p.[SEOName]
      from   t 
             inner join #tblTemp t1 
                     on t1.parentid = t.menuitemid 
             inner join pages p 
                     on p.pageid = t1.pageid 
      union all 
      select t2.PageID, MenuOrder AS [newOrder] ,
             t2.ParentID, 
             t2.menulevel                         as [Level], 
             t2.Title, 
             p1.[PageOrder]
              , ISNULL
        (
         (
          SELECT 
           lp.LocalPageName 
          FROM 
           LocalPage lp 
          WHERE 
            lp.PageID=p1.PageID 
           AND lp.CultureCode=@CultureCode
         )
         ,p1.PageName
        ) AS PageName,
             ( dbo.fn_LevelPrefix(convert(INT, ISNULL(p1.[Level], 0)), @prefix) 
               + p1.[PageName] )                  AS [LevelPageName], 
             p1.[IsVisible], 
             p1.[IconFile], 
             p1.[DisableLink], 
             p1.[Title], 
             p1.[Description], 
             p1.[KeyWords], 
             p1.[Url], 
             p1.[TabPath], 
             p1.[StartDate], 
             p1.[EndDate], 
             p1.[RefreshINTerval], 
             p1.[PageHeadText], 
             p1.[IsSecure], 
             p1.[IsActive], 
             p1.[IsDeleted], 
             p1.[IsModified], 
             p1.[AddedOn], 
             p1.[UpdatedOn], 
             p1.[DeletedOn], 
             p1.[PortalID], 
             p1.[AddedBy], 
             p1.[UpdatedBy], 
             p1.[DeletedBy], 
             p1.[SEOName]
      from   #tblTemp t2 
             inner join pages p1 
                     on p1.pageid = t2.pageid 
      where  t2.parentid = 0 
             AND ( p1.IsDeleted = @IsDeleted 
                    OR @IsDeleted IS NULL ) 
             AND P1.PortalID = @PortalID 
             AND ( p1.IsRequiredPage = @IsRequiredPage 
                    OR @IsRequiredPage IS NULL ) 
             AND p1.ParentID >= 0 
             AND ( p1.IsActive = @IsActive 
                    OR @IsActive IS NULL ) 
             AND ( p1.IsVisible = @IsVisible 
                    OR @IsVisible IS NULL ) 
             AND p1.DisableLink = 0 
      ORDER  BY [newOrder]
      DROP TABLE #tblTemp 
      DROP TABLE #tblPages 
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuGetFooter]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuGetFooter]
 @PortalID [INT],
 @UserName [NVARCHAR](256),
 @CultureCode [NVARCHAR](20)  
AS
BEGIN

    DECLARE @prefix [NVARCHAR](10)
 DECLARE @IsActive [BIT]
 DECLARE @IsDeleted [BIT] 
 DECLARE @IsVisible [BIT]
 DECLARE @IsRequiredPage BIT
 SET @prefix='---'
 SET @IsActive=NULL
 SET @IsDeleted=0 
 SET @IsVisible=NULL
 SET @IsRequiredPage=NULL
CREATE TABLE #tblPages
(
PageID INT
)
create table #TEMP
(
 [PageID] [INT],
 [PageOrder] [INT] NULL,
 [PageName] [NVARCHAR](100),
 [LevelPageName] [NVARCHAR](100),
 [IsVisible] [BIT] NULL,
 [ParentID] [INT] NULL,
 [Level] [INT] NULL,
 [IconFile] [NVARCHAR](100),
 [DisableLink] [BIT] NULL,
 [Title] [NVARCHAR](200) NULL,
 [Description] [NVARCHAR](500) NULL,
 [KeyWords] [NVARCHAR](500)  NULL,
 [Url] [NVARCHAR](255) ,
 [TabPath] [NVARCHAR](255) NULL,
 [StartDate] [DATETIME] NULL,
 [EndDate] [DATETIME] NULL,
 [RefreshINTerval] [decimal](16, 2) NULL,
 [PageHeadText] [NVARCHAR](500) NULL,
 [IsSecure] [BIT] NOT NULL,
 [IsActive] [BIT] NULL,
 [IsDeleted] [BIT] NULL,
 [IsModified] [BIT] NULL,
 [AddedOn] [DATETIME] NULL,
 [UpdatedOn] [DATETIME] NULL,
 [DeletedOn] [DATETIME] NULL,
 [PortalID] [INT] NULL,
 [AddedBy] [NVARCHAR](256) NULL,
 [UpdatedBy] [NVARCHAR](256) NULL,
 [DeletedBy] [NVARCHAR](256) NULL,
 [SEOName] [NVARCHAR](100) NULL,
 [newOrder] DECIMAL(38,10),
 [ShowInMenu] [BIT] NULL
)
INSERT INTO #tblPages
SELECT DISTINCT dbo.pagepermission.PageID FROM dbo.pagepermission 
WHERE RoleID IN (SELECT RoleId FROM dbo.ASpnet_usersinroles INNER JOIN dbo.ASpnet_users ON dbo.ASpnet_usersinroles.UserId=dbo.ASpnet_users.UserId 
     WHERE dbo.ASpnet_users.Username=@UserName) ;
WITH PageOrders([PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshINTerval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,[newOrder]
   ,[ShowInMenu]) 
AS
(
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshINTerval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST(P1.[PageOrder] AS VARCHAR(100)) AS [newOrder]
   ,pm.[ShowInMenu]
 FROM [dbo].[Pages] AS P1 
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
 INNER JOIN [dbo].[PageMenu] pm on P1.PageID=pm.PageID 
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
  AND P1.ParentID=0 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) AND P1.DisableLink=0 
  AND pm.IsFooter=1
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshINTerval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] AS VARCHAR(10))+'.'+ CAST(Right('00'+CAST(P1.[PageOrder] AS VARCHAR(2)),2) AS VARCHAR(89))  AS [newOrder]
 ,PM.[ShowInMenu]
 FROM [dbo].[Pages] AS P1
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
 INNER JOIN [dbo].[PageMenu] pm ON P1.PageID=pm.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID] 
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
  AND P1.[Level]=1 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) AND P1.DisableLink=0 and pm.IsFooter=1
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshINTerval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] AS VARCHAR(10))+CAST(Right('00'+CAST(P1.[PageOrder] AS VARCHAR(2)),2) AS VARCHAR(90))  AS [newOrder]
 ,pm.[ShowInMenu]
 FROM [dbo].[Pages] AS P1
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
 INNER JOIN [dbo].[PageMenu] pm on P1.PageID=pm.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID] 
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
  AND P1.[Level]>1 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL)  AND P1.DisableLink=0 and pm.IsFooter=1
)
INSERT INTO #TEMP
SELECT [PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshINTerval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,CASt([newOrder] AS DECIMAL(38,10)) AS [newOrder],[ShowInMenu] FROM PageOrders
ORDER BY [newOrder]

SELECT P1.[PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshINTerval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,( CASE 
                 WHEN (SELECT COUNT(pageid) 
                       FROM   localpage 
                       WHERE  pageid = p1.pageid 
                              AND culturecode = @Culturecode) > 0 THEN (SELECT 
                 localpagename 
                                                                        FROM 
                 localpage 
                                                                        WHERE 
                 pageid = p1.pageid 
                 AND culturecode = @CultureCode) 
                 ELSE (SELECT pagename 
                       FROM   pages 
                       WHERE  pageid = p1.pageid) 
               END )                               AS seoname 
   ,(SELECT MAX([PageOrder]) FROM [dbo].[Pages] AS m WHERE m.PageOrder<5000 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted 
  AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
  AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) AS [MaxPageOrder]
      ,(SELECT MIN([PageOrder]) FROM [dbo].[Pages] AS m WHERE m.PageOrder<5000 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted 
  AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
  AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) AS [MinPageOrder] 
 ,[ShowInMenu]
FROM #TEMP AS P1
WHERE [ShowInMenu]=1
ORDER BY [newOrder]
DROP TABLE #TEMP
DROP TABLE #tblPages
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuGetClientEdit]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuGetClientEdit] 
AS
BEGIN
    DECLARE @prefix [NVARCHAR](10)
 DECLARE @IsActive [BIT]
 DECLARE @IsDeleted [BIT]
 DECLARE @PortalID [INT]
 DECLARE @UserName [NVARCHAR](256)
 DECLARE @IsVisible [BIT]
 DECLARE @IsRequiredPage BIT
 SET @prefix='---'
 SET @IsActive=null
 SET @IsDeleted=0
 SET @PortalID=1
 SET @UserName='superuser'
 SET @IsVisible=1
 SET @IsRequiredPage=NULL
SELECT DISTINCT dbo.pagepermission.PageID INTO #tblPages FROM dbo.pagepermission 
WHERE RoleID IN (SELECT RoleId FROM dbo.aspnet_usersinroles INNER JOIN dbo.aspnet_users ON dbo.aspnet_usersinroles.UserId=dbo.aspnet_users.UserId
     WHERE dbo.aspnet_users.Username=@UserName) ;
WITH PageOrders([PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshINTerval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,[newOrder]
   ,[ShowInMenu]) 
AS
(
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshINTerval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST(P1.[PageOrder] AS VARCHAR(100)) AS [newOrder]
   ,pm.[ShowInMenu]
 FROM [dbo].[Pages] AS P1 
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
 INNER JOIN PageMenu pm on P1.PageID=pm.PageID
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
   AND P1.ParentID=0 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) AND P1.DisableLink=0
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshINTerval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] AS VARCHAR(10))+'.'+ CAST(RIGHT('00'+CAST(P1.[PageOrder] AS VARCHAR(2)),2) AS VARCHAR(89))  AS [newOrder]
  ,pm.ShowInMenu
 FROM [dbo].[Pages] AS P1
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID]
 INNER JOIN PageMenu pm on P1.PageID=pm.PageID
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
  AND P1.[Level]=1 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL) AND P1.DisableLink=0
 UNION ALL
 SELECT P1.[PageID]
      ,P1.[PageOrder]
   ,P1.[PageName]
      ,(dbo.fn_LevelPrefix(CONVERT(INT,ISNULL(P1.[Level],0)),@prefix) + P1.[PageName]) AS [LevelPageName]
      ,P1.[IsVisible]
      ,P1.[ParentID]
      ,P1.[Level]
      ,P1.[IconFile]
      ,P1.[DisableLink]
      ,P1.[Title]
      ,P1.[Description]
      ,P1.[KeyWords]
      ,P1.[Url]
      ,P1.[TabPath]
      ,P1.[StartDate]
      ,P1.[EndDate]
      ,P1.[RefreshINTerval]
      ,P1.[PageHeadText]
      ,P1.[IsSecure]
      ,P1.[IsActive]
      ,P1.[IsDeleted]
      ,P1.[IsModified]
      ,P1.[AddedOn]
      ,P1.[UpdatedOn]
      ,P1.[DeletedOn]
      ,P1.[PortalID]
      ,P1.[AddedBy]
      ,P1.[UpdatedBy]
      ,P1.[DeletedBy]
      ,P1.[SEOName]
   ,CAST([newOrder] AS VARCHAR(10))+CAST(Right('00'+CAST(P1.[PageOrder] AS VARCHAR(2)),2) AS VARCHAR(90))  AS [newOrder]
  ,pm.ShowInMenu
 FROM [dbo].[Pages] AS P1
 INNER JOIN #tblPages ON #tblPages.pageid=P1.PageID
  INNER JOIN PageOrders AS po
        ON po.[PageID] = p1.[ParentID]
INNER JOIN PageMenu pm ON P1.PageID=pm.PageID
 WHERE (P1.IsDeleted=@IsDeleted OR @IsDeleted IS NULL) AND P1.PortalID=@PortalID AND (P1.IsRequiredPage=@IsRequiredPage OR @IsRequiredPage IS NULL) 
  AND P1.[Level]>1 AND (P1.IsActive=@IsActive OR @IsActive IS NULL) AND (P1.IsVisible=@IsVisible OR @IsVisible IS NULL)  AND P1.DisableLink=0
)
SELECT [PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshINTerval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
   ,Cast([newOrder] AS DECIMAL(38,10)) AS [newOrder],[ShowInMenu] INTO #TEMP FROM PageOrders
 
ORDER BY [newOrder]

SELECT P1.[PageID]
      ,[PageOrder]
   ,[PageName]
      ,[LevelPageName]
      ,[IsVisible]
      ,[ParentID]
      ,[Level]
      ,[IconFile]
      ,[DisableLink]
      ,[Title]
      ,[Description]
      ,[KeyWords]
      ,[Url]
      ,[TabPath]
      ,[StartDate]
      ,[EndDate]
      ,[RefreshINTerval]
      ,[PageHeadText]
      ,[IsSecure]
      ,[IsActive]
      ,[IsDeleted]
      ,[IsModified]
      ,[AddedOn]
      ,[UpdatedOn]
      ,[DeletedOn]
      ,[PortalID]
      ,[AddedBy]
      ,[UpdatedBy]
      ,[DeletedBy]
      ,[SEOName]
  ,[ShowInMenu]
   ,(SELECT MAX([PageOrder]) FROM [dbo].[Pages] AS m WHERE m.PageOrder<5000 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted 
  AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
  AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) as [MaxPageOrder]
      ,(SELECT MIN([PageOrder]) FROM [dbo].[Pages] AS m WHERE m.PageOrder<5000 AND (m.IsActive=@IsActive OR @IsActive IS NULL) AND m.IsDeleted=@IsDeleted 
  AND m.PortalID=@PortalID AND ((@IsVisible=0 OR @IsVisible IS NULL) OR (m.[DisableLink]=0 AND m.IsVisible=@IsVisible)) 
  AND m.[Level]=P1.[Level] and  m.ParentID=P1.ParentID) as [MinPageOrder] 

  FROM #TEMP AS P1 ORDER BY [newOrder]
DROP TABLE #TEMP
DROP TABLE #tblPages
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileValueGetActiveByProfileID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileValueGetActiveByProfileID]
 @ProfileID INT,
 @PortalID INT
AS
BEGIN
SELECT
 [ProfileValueID],
 [ProfileID],
 [Name],
 [DisplayOrder],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM [dbo].[ProfileValue]
WHERE
 [ProfileID]=@ProfileID And PortalID = @PortalID And [IsActive] = 1 And [IsDeleted] = 0
 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ProfileValueDeleteByProfileID]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ProfileValueDeleteByProfileID]
 @ProfileID INT,
 @PortalID INT,
 @DeletedBy NVARCHAR(256)
AS
UPDATE [dbo].[ProfileValue] SET 
 [IsDeleted] = 1, 
 [DeletedOn] = GETDATE(), 
 [DeletedBy] = @DeletedBy
WHERE
 [ProfileID] = @ProfileID And [PortalID] = @PortalID
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserProfile]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetUserProfile]
@UserName NVARCHAR(250),
@PortalID INT
AS
BEGIN

if exists(select * from PortalUser where  PortalID=@PortalID and Username=@UserName)
begin

SELECT ISNULL(ud.UserName,pu.UserName) AS UserName,ISNULL(ud.FirstName,pu.Firstname) AS FirstName,
ISNULL(ud.LastName,pu.LastName) AS LastName,ISNULL(ud.Email,pu.Email) AS Email,
ud.* FROM UserDetails ud RIGHT JOIN PortalUser pu
ON ud.UserName=pu.UserName AND ud.PortalID=pu.PortalID
WHERE pu.UserName = @UserName AND pu.PortalID=@PortalID
END
ELSE
BEGIN
SELECT ISNULL(ud.UserName,pu.UserName) AS UserName,ISNULL(ud.FirstName,pu.Firstname) AS FirstName,
ISNULL(ud.LastName,pu.LastName) AS LastName,ISNULL(ud.Email,pu.Email) AS Email,
ud.* FROM UserDetails ud RIGHT JOIN PortalUser pu
ON ud.UserName=pu.UserName AND ud.PortalID=pu.PortalID
INNER JOIN aspnet_usersinroles AU
ON PU.UserID=AU.UserId INNER JOIN aspnet_roles AR ON AR.RoleId=AU.RoleId AND RoleName='Super User'

WHERE pu.UserName = @UserName 
END 

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserDetails]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_GetUserDetails] 
    ( @UserName NVARCHAR(256), 
               @PortalID INT) 
AS 
  BEGIN 

    
     --DECLARE @TblRole TABLE(RoleID NVARCHAR(256))
     --INSERT INTO @TblRole 
     --SELECT DISTINCT roleid FROM aspnet_usersinroles ur 
     --    INNER JOIN portaluser pu ON pu.userid=ur.userid WHERE username=@UserName
     
     
     
     
     --DECLARE @Counter INT,@rowCount INT,@isRoleSuperuser BIT 
     --SELECT @RowCount = COUNT(RowNum) FROM @TblRole
     
     --SET @Counter=1
     --WHILE(@Counter<=@RowCount or @Counter=1)
     --BEGIN
     -- DECLARE @key UNIQUEIDENTIFIER 
     -- SELECT @key=RoleID FROM @TblRole WHERE RowNum=@Counter
     
     
     --  IF(@key=(SELECT roleid FROM aspnet_roles WHERE RoleName='Super User'))
     --   BEGIN 
     --    SET @isRoleSuperuser=1
     --    BREAK;
     --   END
     --  ELSE
     --   BEGIN
     --    SET @isRoleSuperuser=0
     --   END
     -- SET @Counter=@Counter+1
     --END

   
    DECLARE @isRoleSuperuser BIT     
    DECLARE  @TblRole  TABLE (UserID UNIQUEIDENTIFIER)

     IF(EXISTS(SELECT 1 FROM aspnet_usersinroles ur 
           INNER JOIN portaluser pu ON pu.userid=ur.userid 
           WHERE username=@UserName  AND  
           ur.RoleId IN (SELECT roleid FROM aspnet_roles WHERE RoleName='Super User')
      )
      )
    SET @isRoleSuperuser = 1
    ELSE
    SET @isRoleSuperuser = 0
    
    

 
    INSERT INTO @TblRole 
    SELECT pu.UserID   
          FROM   aspnet_membership am 
           INNER JOIN portaluser pu   ON am.userid = pu.userid  
           INNER JOIN aspnet_Users au ON  au.UserId=am.UserId
          WHERE  pu.portalid = @PortalID and 
           pu.username = @UserName
    
    
           
     IF(@isRoleSuperuser=0)                            
      BEGIN
          SELECT am.userid, 
           am.password, 
           am.passwordformat, 
           am.passwordsalt, 
           am.email, 
           am.isapproved, 
           am.islockedout,
           am.LastLoginDate,
           am.LastPasswordChangedDate,
           am.LastLockoutDate,
           pu.username,
           pu.FirstName,
           pu.LastName,
           am.IsApproved,
          am.CreateDate,
           au.LastActivityDate 
          FROM   aspnet_membership am 
           INNER JOIN portaluser pu   ON am.userid = pu.userid  
           INNER JOIN aspnet_Users au ON  au.UserId=am.UserId
          WHERE  pu.portalid = @PortalID and pu.UserID in (select UserID from @TblRole)
           --AND LOWER(pu.username) = LOWER(@UserName) 
       END  
     ELSE 
      BEGIN
         SELECT am.userid, 
          am.password, 
          am.passwordformat, 
          am.passwordsalt, 
          am.email, 
          am.isapproved, 
          am.islockedout,
          am.LastLoginDate,
          am.LastPasswordChangedDate,
          am.LastLockoutDate,
          pu.username,
          pu.FirstName,
          pu.LastName,
          am.IsApproved,
         am.CreateDate,
          au.LastActivityDate 
         FROM   aspnet_membership am  
          INNER JOIN portaluser pu   ON am.userid = pu.userid  
          INNER JOIN aspnet_Users au ON au.UserId=am.UserId
         WHERE  au.LoweredUserName = LOWER(@UserName)
      END
   END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserByEmail]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[usp_GetUserByEmail] 'mt_bij@yahoo.com', 1
CREATE PROCEDURE [dbo].[usp_GetUserByEmail] 
@email NVARCHAR(100),
@portalID INT
AS
BEGIN

 DECLARE @DUP_EMAIL NVARCHAR(50)
 SET @DUP_EMAIL='DUPLICATE_EMAIL_ALLOWED';
 DECLARE @AllowDuplicateRegistration INT
 DECLARE @DuplicateEmail INT
 SELECT @DuplicateEmail=CAST(SettingValue AS INT) FROM MembershipSettings  where SettingKey = @DUP_EMAIL
 IF( @DuplicateEmail=0)
   BEGIN
   IF(EXISTS(SELECT UserId FROM  PortalUser WHERE Email = @email))
   BEGIN
   DECLARE @UserID NVARCHAR(100)
   SET @UserID = (SELECT UserId FROM  PortalUser WHERE Email = @email )
   SELECT am.userid, 
     am.password, 
     am.passwordformat, 
     am.passwordsalt, 
     am.email, 
     am.isapproved, 
     am.islockedout,
     am.LastLoginDate,
     am.LastPasswordChangedDate,
     am.LastLockoutDate,
     pu.username,
     pu.FirstName,
     pu.LastName,
     am.IsApproved,
    am.CreateDate,
     au.LastActivityDate 
    FROM   aspnet_membership am 
     INNER JOIN portaluser pu 
       ON am.userid = pu.userid  
     INNER JOIN aspnet_Users au ON 
     au.UserId=am.UserId
    WHERE  pu.portalid = 1 
     AND pu.UserID = @UserID 
   END
   ELSE 
   BEGIN
    SELECT   0 AS IsApproved
   END
 END
 ELSE
 BEGIN  
   IF(EXISTS(SELECT UserId FROM  PortalUser WHERE Email = @email and UserName= @email))
   BEGIN
   DECLARE @singleUserID NVARCHAR(100)
   SET @singleUserID = (SELECT UserId FROM  PortalUser WHERE Email = @email and UserName= @email )
   SELECT am.userid, 
     am.password, 
     am.passwordformat, 
     am.passwordsalt, 
     am.email, 
     am.isapproved, 
     am.islockedout,
     am.LastLoginDate,
     am.LastPasswordChangedDate,
     am.LastLockoutDate,
     pu.username,
     pu.FirstName,
     pu.LastName,
     am.IsApproved,
    am.CreateDate,
     au.LastActivityDate 
    FROM   aspnet_membership am 
     INNER JOIN portaluser pu 
       ON am.userid = pu.userid  
     INNER JOIN aspnet_Users au ON 
     au.UserId=am.UserId
    WHERE  pu.portalid = 1 
     AND pu.UserID = @singleUserID 
   END
   ELSE 
   BEGIN
    SELECT   0 AS IsApproved
   END
 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrLoadSageMenuItems_Localized]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrLoadSageMenuItems_Localized] (@UserModuleID INT, @PortalID INT, @UserName NVARCHAR(200), @Culture NVARCHAR(50))
AS
BEGIN
 DECLARE @temprole TABLE (roleid NVARCHAR(250), username NVARCHAR(Max))

 INSERT INTO @temprole
 SELECT [dbo].[aspnet_UsersInRoles].roleid, [dbo].[aspnet_Users].username
 FROM [dbo].[aspnet_UsersInRoles]
 INNER JOIN [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].userid = [dbo].[aspnet_UsersInRoles].userid
 
 UNION ALL
 
 SELECT [RoleId], 'anonymous user' AS username
 FROM dbo.aspnet_roles
 WHERE loweredrolename = 'anonymous user'

 DECLARE @MenuID INT

 IF EXISTS (
    SELECT SettingValue
    FROM SageMenuSettingValue
    WHERE  SettingKey = 'MenuID'
     AND UserModuleID = @UserModuleID
    )
     BEGIN
      SELECT @MenuID = SettingValue
      FROM SageMenuSettingValue
      WHERE SettingKey = 'MenuID'
       AND UserModuleID = @UserModuleID
     END
    ELSE
     BEGIN
      SELECT @MenuID = MenuID
      FROM Menu
      WHERE IsDefault = 1
     END

 SELECT DISTINCT mi.MenuID, mi.PageID, ISNULL((
    SELECT lp.LocalPageName
    FROM LocalPage lp
    WHERE lp.PageID = mi.PageID
         AND lp.CultureCode = @Culture
    ),   p.PageName) AS PageName
    ,    PageName AS Title, 
    (SELECT COUNT(1)FROM MenuItem m WHERE m.ParentID = mi.MenuItemID)  AS ChildCount
    , p.IconFile AS ImageIcon
    , p.TabPath AS URL
    , ISNULL((SELECT lp.LocalPageCaption FROM LocalPage lp WHERE lp.PageID = mi.PageID AND lp.CultureCode = @Culture), mi.Caption) AS Caption
    , mi.HtmlContent, mi.ParentID, mi.MenuLevel as menulevel, mi.MenuOrder as menuOrder , mi.SubText, mi.IsVisible
    , mi.IsActive, mi.MenuItemID as MenuItemID, mi.LinkType, mi.LinkURL
 FROM MenuItem mi
   LEFT JOIN Pages p ON mi.PageID = p.PageID
   INNER JOIN [dbo].[PagePermission] ON [dbo].[PagePermission].pageid = p.pageid
   INNER JOIN @temprole mv ON (
     [dbo].[PagePermission].RoleID = mv.roleid
     AND [dbo].[PagePermission].UserName = mv.UserName
     )
    OR (
     [dbo].[PagePermission].RoleID = mv.roleid
     AND [dbo].[PagePermission].UserName = ''
     )
   WHERE (
     mv.username = @UserName
     OR [dbo].[PagePermission].username = @UserName
     )
    AND p.pageid = mi.PageID
    AND (
     p.[IsDeleted] = 0
     OR p.[IsDeleted] IS NULL
     )
    AND (
     p.portalid = @PortalID
     OR p.portalid = - 1
     )
    AND (
     [dbo].[PagePermission].[IsDeleted] = 0
     OR [dbo].[PagePermission].[IsDeleted] IS NULL
     )
    AND mi.MenuID = @MenuID
    AND mi.LinkType = 0
    AND mi.IsVisible = 1
    AND mi.PortalID = @PortalID

   UNION ALL

 SELECT DISTINCT mi.MenuID, mi.PageID, p.PageName, mi.Title, 
      (SELECT COUNT(1)
      FROM MenuItem m
      WHERE m.ParentID = mi.MenuItemID ) AS ChildCount
     , mi.ImageIcon, p.TabPath AS URL, mi.Caption, mi.HtmlContent, mi.ParentID, mi.MenuLevel as menulevel
     , mi.MenuOrder as menuOrder, mi.SubText, mi.IsVisible, mi.IsActive, mi.MenuItemID as MenuItemID , mi.LinkType, mi.LinkURL
     
 FROM   MenuItem mi
     LEFT JOIN Pages p ON mi.PageID = p.PageID
     LEFT JOIN PagePermission pp ON p.PageID = pp.PageID
 WHERE    mi.MenuID = @MenuID
     AND (
      mi.LinkType = 1
      OR mi.LinkType = 2
      )
     AND mi.IsVisible = 1
     AND mi.PortalID = @PortalID
  
 ORDER BY menuOrder ,MenuItemID desc 

 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuMgrLoadSageMenuItems]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MenuMgrLoadSageMenuItems]
(
@UserModuleID INT,
@PortalID INT,
@UserName NVARCHAR(200)
)

AS
BEGIN

      ----------------------------------------------------------
        -- Declare and select Role and Username 
      -----------------------------------------------------------
   declare @temprole table
   (
   roleid nvarchar(250),
   username nvarchar(50)
   )
   INSERT INTO @temprole

   SELECT  [dbo].[aspnet_UsersInRoles].roleid, [dbo].[aspnet_Users].username
   FROM         [dbo].[aspnet_UsersInRoles] INNER JOIN
          [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].userid = [dbo].[aspnet_UsersInRoles].userid
   UNION ALL
   SELECT     [RoleId], 'anonymous user' AS username
   FROM         dbo.aspnet_roles
   WHERE     loweredrolename = 'anonymous user'

 DECLARE @MenuID INT
  IF EXISTS
    (
     SELECT 
      SettingValue 
     FROM 
      SageMenuSettingValue 
     WHERE 
       SettingKey='MenuID' 
      AND UserModuleID=@UserModuleID
    )
   BEGIN
    SELECT 
     @MenuID=SettingValue 
    FROM 
     SageMenuSettingValue 
    WHERE 
      SettingKey='MenuID' 
     AND UserModuleID=@UserModuleID
   END
  ELSE
   BEGIN
    SELECT 
     @MenuID=MenuID 
    FROM 
     Menu 
    WHERE IsDefault=1
   END

 DECLARE  @Temp TABLE
  (
   MenuID INT,
   PageID INT,
   PageName NVARCHAR(250),
   Title NVARCHAR(250),
   ChildCount INT,
   ImageIcon NVARCHAR(250),
   URL NVARCHAR(250),
   Caption NVARCHAR(250),
   HtmlContent NVARCHAR(2000),
   ParentID INT,
   MenuLevel INT,
   MenuOrder INT,
   SubText NVARCHAR(250),
   IsVisible BIT,
   IsActive BIT,
   MenuItemID INT,
   LinkType INT,
   LinkURL NVARCHAR(256)
  )
 
 INSERT INTO @Temp
 SELECT 
  DISTINCT mi.MenuID,
     mi.PageID,
     p.PageName,
     mi.Title,
     (
      SELECT 
       COUNT(*) 
      FROM 
       MenuItem m 
      WHERE 
       m.ParentID=mi.MenuItemID
     ) AS ChildCount,
     p.IconFile AS ImageIcon,
     p.TabPath AS URL,
     mi.Caption,
     mi.HtmlContent,
     mi.ParentID,
     mi.MenuLevel,
     mi.MenuOrder,
     mi.SubText,
     mi.IsVisible,
     mi.IsActive,
     mi.MenuItemID,
     mi.LinkType,
     mi.LinkURL
 FROM 
  MenuItem mi 
 LEFT JOIN 
  Pages p 
 ON 
  mi.PageID=p.PageID  
 INNER JOIN 
  PageMenu pm 
 ON 
  pm.PageID=p.PageID  
 INNER JOIN 
  [dbo].[PagePermission] 
 ON 
  [dbo].[PagePermission].pageid = p.pageid
  
  INNER JOIN @temprole mv on [dbo].[PagePermission].RoleID = mv.roleid
    WHERE  
 (mv.username = @UserName or[dbo].[PagePermission].username = @UserName) 
 
  AND 
   p.pageid = mi.PageID 
  AND 
   (  p.[IsDeleted] = 0 
    OR 
     p.[IsDeleted] IS NULL 
   ) 
  AND 
   ( 
     p.portalid = @PortalID 
    OR p.portalid = -1 
   ) 
  AND 
   ( 
     [dbo].[PagePermission].[IsDeleted] = 0 
    OR [dbo].[PagePermission].[IsDeleted] IS NULL 
   )
  AND 
   mi.MenuID=@MenuID
  AND 
   mi.LinkType=0 
  AND 
   mi.IsVisible=1 
  AND 
   mi.PortalID=@PortalID
  ORDER BY 
   MenuLevel,MenuOrder
  
 
 INSERT INTO @Temp
  SELECT  
   DISTINCT mi.MenuID,
      mi.PageID,
      p.PageName,
      mi.Title,
      (
       SELECT 
        COUNT(*) 
       FROM 
        MenuItem m 
       WHERE 
        m.ParentID=mi.MenuItemID
      ) AS ChildCount,
      mi.ImageIcon,
      p.TabPath AS URL,
      mi.Caption,
      mi.HtmlContent,
      mi.ParentID,
      mi.MenuLevel,
      mi.MenuOrder,
      mi.SubText,
      mi.IsVisible,
      mi.IsActive,
      mi.MenuItemID,
      mi.LinkType,
      mi.LinkURL
  FROM 
   MenuItem mi 
  LEFT JOIN 
   Pages p 
  ON 
   mi.PageID=p.PageID
  LEFT JOIN
   PagePermission pp 
  ON 
   p.PageID=pp.PageID      
  WHERE 
   mi.MenuID=@MenuID 
  AND 
   (
     mi.LinkType=1 
    OR mi.LinkType=2
   )
  AND 
   mi.IsVisible=1 
  AND 
   mi.PortalID=@PortalID
  ORDER BY 
   MenuLevel,MenuOrder
  
 SELECT 
  * 
 FROM 
  @Temp 
 ORDER BY 
  MenuOrder
 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_loc_CoreModulesGet]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_loc_CoreModulesGet]
AS
BEGIN
SELECT cm.CoreModuleID,cm.ModuleID,m.ModuleName,m.FolderName FROM CoreModules cm 
INNER JOIN Modules m ON cm.ModuleId=m.ModuleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleManagerGetSearchModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleManagerGetSearchModules]
 @SearchText VARCHAR(20),
 @PortalID INT,
 @IsAdmin BIT
AS
BEGIN
 SELECT 
  m.FriendlyName,
  m.ModuleID,
  md.ModuleDefID 
 FROM 
  Modules m 
 INNER JOIN 
  ModuleDefinitions md 
 ON 
  m.ModuleID=md.ModuleID
 INNER JOIN 
  PortalModules pm 
 ON 
  md.ModuleID=pm.ModuleID
 WHERE 
   (m.IsAdmin=@IsAdmin)
  AND (
     m.IsDeleted IS NULL 
    OR m.IsDeleted=0
   )
  AND 
   pm.PortalID=@PortalID
  AND 
  pm.IsActive=1
  AND 
   m.FriendlyName LIKE @SearchText +  '%'
 ORDER BY 
  m.FriendlyName ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleManagerGetPortalModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleManagerGetPortalModules]
(
@PortalID INT
)
AS
BEGIN
 SELECT 
  m.FriendlyName,
  md.ModuleDefID 
 FROM 
  Modules m 
 INNER JOIN 
  ModuleDefinitions md 
 ON 
  m.ModuleID=md.ModuleID
 INNER JOIN 
  PortalModules pm 
 ON 
  md.ModuleID=pm.ModuleID
 WHERE 
   (
     m.IsAdmin=0 
    OR m.IsAdmin IS NULL
   )
  AND 
   (
     m.IsDeleted IS NULL 
    OR m.IsDeleted=0
   )
 AND 
  pm.PortalID=@PortalID
 AND 
  pm.IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleManagerGetAdminModules]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleManagerGetAdminModules]
(
 @PortalID INT
)
AS
BEGIN
 SELECT 
  m.FriendlyName,
  md.ModuleDefID 
 FROM 
  Modules m 
 INNER JOIN 
  ModuleDefinitions md 
 ON 
  m.ModuleID=md.ModuleID
 INNER JOIN 
  PortalModules pm 
 ON 
  md.ModuleID=pm.ModuleID
 WHERE 
  m.IsAdmin=1
 AND (
    m.IsDeleted IS NULL 
   OR m.IsDeleted=0
  )
 AND pm.PortalID=@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleGetAllExisting]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleGetAllExisting] 
AS
SELECT
 [dbo].[Modules].[ModuleID],
 [dbo].[Modules].[FriendlyName],
 [dbo].[Modules].[Description],
 [dbo].[Modules].[Version],
 [dbo].[Modules].[IsPremium],
 [dbo].[Modules].[IsAdmin],
 [dbo].[Modules].[BusinessControllerClass],
 [dbo].[Modules].[FolderName],
 [dbo].[Modules].[ModuleName],
 [dbo].[Modules].[SupportedFeatures],
 [dbo].[Modules].[CompatibleVersions],
 [dbo].[Modules].[Dependencies],
 [dbo].[Modules].[Permissions],
 [dbo].[Modules].[PackageID],
 [dbo].[Modules].[IsActive],
 [dbo].[Modules].[IsDeleted],
 [dbo].[Modules].[IsModified],
 [dbo].[Modules].[AddedOn],
 [dbo].[Modules].[UpdatedOn],
 [dbo].[Modules].[DeletedOn],
 [dbo].[Modules].[PortalID],
 [dbo].[Modules].[AddedBy],
 [dbo].[Modules].[UpdatedBy],
 [dbo].[Modules].[DeletedBy]
FROM 
 [dbo].[Modules]
INNER JOIN 
 dbo.PortalModules 
ON 
 [dbo].[Modules].[ModuleID] = dbo.PortalModules.[ModuleID]
WHERE 
  (
    dbo.PortalModules.IsDeleted=0 
   OR dbo.PortalModules.IsDeleted IS NULL
  ) 
 AND dbo.PortalModules.IsActive =1 
 AND [Modules].[ModuleID] 
       NOT IN 
        (
         SELECT 
          SuperuserModuleID 
         FROM 
          [dbo].SystemConstrains
        )
ORDER BY 
 [dbo].[Modules].[FriendlyName]
GO
/****** Object:  StoredProcedure [dbo].[usp_UsersGetAll]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UsersGetAll] 
AS
BEGIN
 SELECT
  pu.PortalId,
  au.UserName,
  au.UserId,
  pu.FirstName,
  pu.LastName,
  am.Email,
  am.PasswordFormat
 FROM
  [dbo].[PortalUser] pu
 INNER JOIN [dbo].[aspnet_Users] au ON pu.userid = au.userid
 INNER JOIN [dbo].[aspnet_Membership] am ON au.userid = am.userid
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_UsersDelete]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UsersDelete] 
 (@ApplicationName NVARCHAR (256),
 @UserName NVARCHAR (256),
 @PortalID INT,
 @StoreID INT,
 @DeletedBy NVARCHAR (256))
  WITH EXECUTE AS CALLER AS
BEGIN
-- DECLARE
--  @UserID UNIQUEIDENTIFIER SELECT
--   @UserID = UserID
--  FROM
--   PortalUser
--  WHERE
--   PortalID =@PortalID or UserId in (SELECT au.UserId  FROM PortalUser P1 INNER JOIN aspnet_usersinroles au
--ON P1.UserID=AU.UserId INNER JOIN aspnet_roles AR ON AR.RoleId=AU.RoleId AND AR.RoleName='Super User' AND p1.IsActive=1 AND (p1.IsDeleted =0 OR p1.ISDeleted IS NULL ))
--  AND Username =@UserName

 DECLARE
  @UserID UNIQUEIDENTIFIER SELECT
   @UserID = UserID
  FROM
   PortalUser
  WHERE
  PortalID=@PortalID and Username=@UserName
  
   DELETE
  FROM
   dbo.aspnet_UsersInRoles
  WHERE
   dbo.aspnet_UsersInRoles.UserId = @UserID DELETE
  FROM
   dbo.aspnet_membership
  WHERE
   dbo.aspnet_membership.UserId = @UserID DELETE
  FROM
   dbo.aspnet_users
  WHERE
   dbo.aspnet_users.UserId = @UserID DELETE
  FROM
   dbo.portaluser
  WHERE
   dbo.portaluser.UserId = @UserID DELETE
  FROM
   dbo.Users
  WHERE
   dbo.Users.UserName = @UserName --------For DELETETING CUSTOMER--------------
  IF EXISTS (
   SELECT
    *
   FROM
    sys.objects
   WHERE
    object_id = OBJECT_ID(N'[dbo].[Aspx_Customer]')
   AND type IN (N'U')
  )
  BEGIN
   DECLARE
    @CustomerID INT SELECT
     @CustomerID = CustomerID
    FROM
     dbo.Aspx_Customer
    WHERE
     StoreID =@StoreID
    AND PortalID =@PortalID
    AND UserName =@UserName
    IF (@CustomerID IS NOT NULL)
    BEGIN
     UPDATE [dbo].[Aspx_Customer]
    SET IsDeleted = 1,
    DeletedOn = getdate(),
    DeletedBy = @UserName
   WHERE
    [CustomerID] = @CustomerID
   AND StoreID = @StoreID
   AND PortalID = @PortalID --     DELETE [dbo].[Aspx_Customer] 
   --     WHERE
   --       [CustomerID] = @CustomerID AND StoreID = @StoreID AND PortalID = @PortalID
   END UPDATE dbo.Aspx_Address
   SET IsDeleted = 1,
   DeletedOn = getdate(),
   DeletedBy = @UserName
  WHERE
   StoreID =@StoreID
  AND PortalID =@PortalID
  AND AddedBy =@UserName DELETE dbo.Aspx_Cart
  WHERE
   StoreID =@StoreID
  AND PortalID =@PortalID
  AND CustomerID =@CustomerID UPDATE dbo.Aspx_CartItems
  SET IsDeleted = 1,
  DeletedOn = getdate(),
  DeletedBy = @UserName
 WHERE
  CartID IN (
   SELECT
    cartID
   FROM
    Aspx_Cart
   WHERE
    StoreID =@StoreID
   AND PortalID =@PortalID
   AND CustomerID =@CustomerID
  ) UPDATE dbo.Aspx_CompareItemDetails
 SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND UserName =@userName DELETE dbo.Aspx_CompareItems
WHERE
 CompareItemID IN (
  SELECT
   CompareItemID
  FROM
   Aspx_CompareItemDetails
  WHERE
   StoreID =@StoreID
  AND PortalID =@PortalID
  AND UserName =@UserName
 ) UPDATE dbo.Aspx_EmailAFriend
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND SenderName =@UserName UPDATE dbo.Aspx_EmailShareWishList
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND SenderName =@UserName UPDATE dbo.Aspx_ItemRating
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND UserName =@UserName UPDATE dbo.Aspx_ItemReview
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND UserName =@UserName UPDATE dbo.Aspx_ItemTags
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND AddedBy =@UserName UPDATE dbo.Aspx_RecentlyComparedItems
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND AddedBy =@UserName UPDATE dbo.Aspx_RecentlyViewedItems
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND UserName =@UserName UPDATE dbo.Aspx_UserBillingAddress
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND AddedBy =@UserName UPDATE dbo.Aspx_UserShippingAddress
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND AddedBy =@UserName UPDATE dbo.Aspx_WishItemDetails
SET IsDeleted = 1,
 DeletedOn = getdate(),
 DeletedBy = @UserName
WHERE
 StoreID =@StoreID
AND PortalID =@PortalID
AND UserName =@UserName DELETE dbo.Aspx_WishItems
WHERE
 WishItemID IN (
  SELECT
   WishItemID
  FROM
   Aspx_WishItemDetails
  WHERE
   StoreID =@StoreID
  AND PortalID =@PortalID
  AND UserName =@UserName
 )
END
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUserInfo]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UpdateUserInfo]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @IsPasswordCorrect              bit,
    @UpdateLastLoginActivityDate    bit,
    @MaxInvalidPasswordAttempts     int,
    @PasswordAttemptWindow          int,
    @CurrentTimeUtc                 datetime,
    @LastLoginDate                  datetime,
    @LastActivityDate               datetime
AS
BEGIN
    DECLARE @UserId                                 uniqueidentifier
    DECLARE @IsApproved                             bit
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
     BEGIN TRANSACTION
     SET @TranStarted = 1
    END
    ELSE
     SET @TranStarted = 0

    SELECT  @UserId = u.UserId,
            @IsApproved = m.IsApproved,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m WITH ( UPDLOCK )
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF ( @@rowcount = 0 )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    IF( @IsLockedOut = 1 )
    BEGIN
        GOTO Cleanup
    END

    IF( @IsPasswordCorrect = 0 )
    BEGIN
        IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAttemptWindowStart ) )
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = 1
        END
        ELSE
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = @FailedPasswordAttemptCount + 1
        END

        BEGIN
            IF( @FailedPasswordAttemptCount >= @MaxInvalidPasswordAttempts )
            BEGIN
                SET @IsLockedOut = 1
                SET @LastLockoutDate = @CurrentTimeUtc
            END
        END
    END
    ELSE
    BEGIN
        IF( @FailedPasswordAttemptCount > 0 OR @FailedPasswordAnswerAttemptCount > 0 )
        BEGIN
            SET @FailedPasswordAttemptCount = 0
            SET @FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            SET @FailedPasswordAnswerAttemptCount = 0
            SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            SET @LastLockoutDate = CONVERT( datetime, '17540101', 112 )
        END
    END

    IF( @UpdateLastLoginActivityDate = 1 )
    BEGIN
        UPDATE  dbo.aspnet_Users
        SET     LastActivityDate = @LastActivityDate
        WHERE   @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END

        UPDATE  dbo.aspnet_Membership
        SET     LastLoginDate = @LastLoginDate
        WHERE   UserId = @UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END


    UPDATE dbo.aspnet_Membership
    SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
        FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
        FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
        FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
        FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
    WHERE @UserId = UserId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
 SET @TranStarted = 0
 COMMIT TRANSACTION
    END

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
     ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UpdateUser]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @Email                nvarchar(256),
    @Comment              ntext,
    @IsApproved           bit,
    @LastLoginDate        datetime,
    @LastActivityDate     datetime,
    @UniqueEmail          int,
    @CurrentTimeUtc       datetime
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId, @ApplicationId = a.ApplicationId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF (@UserId IS NULL)
        RETURN(1)

    IF (@UniqueEmail = 1)
    BEGIN
        IF (EXISTS (SELECT *
                    FROM  dbo.aspnet_Membership WITH (UPDLOCK, HOLDLOCK)
                    WHERE ApplicationId = @ApplicationId  AND @UserId <> UserId AND LoweredEmail = LOWER(@Email)))
        BEGIN
            RETURN(7)
        END
    END

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
     BEGIN TRANSACTION
     SET @TranStarted = 1
    END
    ELSE
 SET @TranStarted = 0

    UPDATE dbo.aspnet_Users WITH (ROWLOCK)
    SET
         LastActivityDate = @LastActivityDate
    WHERE
       @UserId = UserId

    IF( @@ERROR <> 0 )
        GOTO Cleanup

    UPDATE dbo.aspnet_Membership WITH (ROWLOCK)
    SET
         Email            = @Email,
         LoweredEmail     = LOWER(@Email),
         Comment          = @Comment,
         IsApproved       = @IsApproved,
         LastLoginDate    = @LastLoginDate
    WHERE
       @UserId = UserId

    IF( @@ERROR <> 0 )
        GOTO Cleanup

    IF( @TranStarted = 1 )
    BEGIN
 SET @TranStarted = 0
 COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
     ROLLBACK TRANSACTION
    END

    RETURN -1
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UnlockUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UnlockUser]
    @ApplicationName                         nvarchar(256),
    @UserName                                nvarchar(256)
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF ( @UserId IS NULL )
        RETURN 1

    UPDATE dbo.aspnet_Membership
    SET IsLockedOut = 0,
        FailedPasswordAttemptCount = 0,
        FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 ),
        FailedPasswordAnswerAttemptCount = 0,
        FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 ),
        LastLockoutDate = CONVERT( datetime, '17540101', 112 )
    WHERE @UserId = UserId

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[usp_sf_UsersUpdate]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_sf_UsersUpdate]
(
 @ApplicationName NVARCHAR(256),
 @UserName NVARCHAR(256),
 @UserID UNIQUEIDENTIFIER,
 @FirstName NVARCHAR(256),
 @LastName NVARCHAR(256),
 @Email NVARCHAR(256), 
 @PortalID INT,
 @IsApproved BIT,
 @UpdatedBy NVARCHAR(256),
 @ErrorCode INT OUTPUT,
--For AspsxCommerce 
 @StoreID INT
)
AS
BEGIN
 SET NOCOUNT ON
    DECLARE @AppId UNIQUEIDENTIFIER
 SELECT  @AppId = NULL
 SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName

    DECLARE @TranStarted   BIT
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0


    DECLARE @DUP_EMAIL NVARCHAR(50)
 SET @DUP_EMAIL='DUPLICATE_EMAIL_ALLOWED';
    DECLARE @DuplicateEmail INT
    SELECT @DuplicateEmail=CAST(SettingValue as INT) FROM MembershipSettings 
 WHERE SettingKey=@DUP_EMAIL
    DECLARE @IsEmailExists BIT
 SET @IsEmailExists=0

 IF (EXISTS(SELECT Email FROM aspnet_Membership WHERE Email=@Email AND UserId<>@UserID))
  BEGIN
  SET @IsEmailExists=1
  END

    IF @DuplicateEmail=0 AND @IsEmailExists=1
  BEGIN
   SET @ErrorCode = 1
   GOTO Cleanup 
  END

    UPDATE dbo.aspnet_Membership SET Email=@Email,
        LoweredEmail=LOWER(@Email),
        IsApproved=@IsApproved
       WHERE
                 ApplicationId=@AppId
       AND 
        UserId=@UserId

    UPDATE dbo.PortalUser SET FirstName=@FirstName,
       LastName=@LastName,
       Email=@Email,
       IsActive=@IsApproved,
       UpdatedOn=getdate(),
       UpdatedBy=@UpdatedBy
      WHERE
                   UserID=@UserID

 UPDATE dbo.Users SET FirstName=@FirstName,
      LastName=@LastName,
      Email=@Email,
      IsActive=@IsApproved,
      UpdatedOn=getdate(),
      UpdatedBy=@UpdatedBy
      WHERE
                  Username=@UserName
      AND PortalID=@PortalID
      
      
  UPDATE [dbo].[UserDetails] SET
        
  FirstName = @FirstName,
  LastName = @LastName,
  Email = @Email
  WHERE
   Username = @UserName and PortalID = @PortalID
      

--For Customer table AspxCommerce
IF EXISTS (SELECT * FROM sys.objects 
   WHERE object_id = OBJECT_ID(N'[dbo].[Aspx_Customer]') AND type in (N'U'))
BEGIN
 UPDATE dbo.[Aspx_Customer] SET 
      IsActive=@IsApproved,
      UpdatedOn=getdate(),
      UpdatedBy=@UpdatedBy
      WHERE
                  Username=@UserName AND PortalID=@PortalID AND [StoreID] = @StoreID
END

  IF( @@ERROR <> 0 )
  BEGIN
   SET @ErrorCode = -1
   GOTO Cleanup
  END
  
  IF( @TranStarted = 1 )
  BEGIN
   SET @TranStarted = 0
   COMMIT TRANSACTION
  END

  RETURN 0

 Cleanup:

  IF( @TranStarted = 1 )
  BEGIN
   SET @TranStarted = 0
      ROLLBACK TRANSACTION
  END

  RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[usp_sf_UserInRolesDelete]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_sf_UserInRolesDelete] (
 @ApplicationName NVARCHAR (120),
 @UserID UNIQUEIDENTIFIER,
 @RoleNames NVARCHAR (4000),
 @PortalID INT,
 @ErrorCode INT OUTPUT
) AS
BEGIN
 DELETE
FROM
 dbo.aspnet_UsersInRoles
WHERE
 UserID =@UserID ;
SET @ErrorCode = 0 ; RETURN @ErrorCode
END
GO
/****** Object:  StoredProcedure [dbo].[usp_sf_UserInRolesAdd]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_sf_UserInRolesAdd] 
(
@ApplicationName NVARCHAR(120),
@UserID UNIQUEIDENTIFIER,
@RoleNames NVARCHAR(4000),
@PortalID INT
)
as
BEGIN
  DECLARE @TranStarted   BIT
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

 DECLARE @AppId UNIQUEIDENTIFIER
 SELECT  @AppId = NULL
 SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName



 DECLARE @TableNames TABLE(Name NVARCHAR(256) NOT NULL PRIMARY KEY)
 DECLARE @TableUserInRoles table(RoleId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,UserID UNIQUEIDENTIFIER) 
 DECLARE @Num  INT
 DECLARE @Pos  INT
 DECLARE @NextPos INT
 DECLARE @Name  NVARCHAR(256)

 SET @Num = 0
 SET @Pos = 1
 WHILE(@Pos <= LEN(@RoleNames))
 BEGIN
  SELECT @NextPos = CHARINDEX(N',', @RoleNames,  @Pos)
  IF (@NextPos = 0 OR @NextPos IS NULL)
   SELECT @NextPos = LEN(@RoleNames) + 1
  SELECT @Name = RTRIM(LTRIM(SUBSTRING(@RoleNames, @Pos, @NextPos - @Pos)))
  SELECT @Pos = @NextPos+1

  INSERT INTO @TableNames VALUES (@Name)
  SET @Num = @Num + 1
 END

 INSERT INTO @TableUserInRoles
   SELECT ar.RoleId,@UserID
   FROM   dbo.PortalRole pr INNER JOIN aspnet_Roles ar on pr.RoleID=ar.RoleId
     INNER JOIN  @TableNames t on LOWER(t.Name) = ar.LoweredRoleName   
   WHERE  ar.ApplicationId = @AppId
   AND pr.PortalID=@PortalID OR pr.PortalID=-1

IF (EXISTS (SELECT * FROM dbo.aspnet_UsersInRoles ur, @TableUserInRoles tr WHERE tr.UserID = ur.UserId AND tr.RoleId = ur.RoleId))
 BEGIN
  IF( @TranStarted = 1 )
   ROLLBACK TRANSACTION  
 END

 INSERT INTO dbo.aspnet_UsersInRoles (UserId, RoleId)
  SELECT UserID, RoleId
  FROM  @TableUserInRoles  

 IF( @@ERROR <> 0 )
    BEGIN        
        GOTO Cleanup
    END

IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END


Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END   

END
GO
/****** Object:  StoredProcedure [dbo].[usp_sf_ResetPassword]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_sf_ResetPassword] 
 @UserID UNIQUEIDENTIFIER ,
 @NewPassword NVARCHAR (128),
 @PasswordSalt NVARCHAR (128),
 @PasswordFormat INT AS
BEGIN

SET NOCOUNT ON UPDATE [dbo].[aspnet_Membership]
SET Password =@NewPassword,
 PasswordSalt =@PasswordSalt,
 PasswordFormat =@PasswordFormat,
 LastPasswordChangedDate = getdate()
WHERE
 UserId =@UserID
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_DeleteRole]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_DeleteRole]
    @ApplicationName            nvarchar(256),
    @RoleName                   nvarchar(256),
    @DeleteOnlyIfRoleIsEmpty    bit
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

    DECLARE @RoleId   uniqueidentifier
    SELECT  @RoleId = NULL
    SELECT  @RoleId = RoleId FROM dbo.aspnet_Roles WHERE LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId

    IF (@RoleId IS NULL)
    BEGIN
        SELECT @ErrorCode = 1
        GOTO Cleanup
    END
    IF (@DeleteOnlyIfRoleIsEmpty <> 0)
    BEGIN
        IF (EXISTS (SELECT RoleId FROM dbo.aspnet_UsersInRoles  WHERE @RoleId = RoleId))
        BEGIN
            SELECT @ErrorCode = 2
            GOTO Cleanup
        END
    END


    DELETE FROM dbo.aspnet_UsersInRoles  WHERE @RoleId = RoleId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    DELETE FROM dbo.aspnet_Roles WHERE @RoleId = RoleId  AND ApplicationId = @ApplicationId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END

    RETURN(0)

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_DeleteUser]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Users_DeleteUser]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @TablesToDeleteFrom int,
    @NumTablesDeletedFrom int OUTPUT
AS
BEGIN
    DECLARE @UserId               uniqueidentifier
    SELECT  @UserId               = NULL
    SELECT  @NumTablesDeletedFrom = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
     BEGIN TRANSACTION
     SET @TranStarted = 1
    END
    ELSE
 SET @TranStarted = 0

    DECLARE @ErrorCode   int
    DECLARE @RowCount    int

    SET @ErrorCode = 0
    SET @RowCount  = 0

    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a
    WHERE   u.LoweredUserName       = LOWER(@UserName)
        AND u.ApplicationId         = a.ApplicationId
        AND LOWER(@ApplicationName) = a.LoweredApplicationName

    IF (@UserId IS NULL)
    BEGIN
        GOTO Cleanup
    END

    -- Delete from Membership table if (@TablesToDeleteFrom & 1) is set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        DELETE FROM dbo.aspnet_Membership WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
               @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_UsersInRoles table if (@TablesToDeleteFrom & 2) is set
    IF ((@TablesToDeleteFrom & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_UsersInRoles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_UsersInRoles WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Profile table if (@TablesToDeleteFrom & 4) is set
    IF ((@TablesToDeleteFrom & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_Profile WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_PersonalizationPerUser table if (@TablesToDeleteFrom & 8) is set
    IF ((@TablesToDeleteFrom & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationPerUser WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Users table if (@TablesToDeleteFrom & 1,2,4 & 8) are all set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (@TablesToDeleteFrom & 2) <> 0 AND
        (@TablesToDeleteFrom & 4) <> 0 AND
        (@TablesToDeleteFrom & 8) <> 0 AND
        (EXISTS (SELECT UserId FROM dbo.aspnet_Users WHERE @UserId = UserId)))
    BEGIN
        DELETE FROM dbo.aspnet_Users WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    IF( @TranStarted = 1 )
    BEGIN
     SET @TranStarted = 0
     COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:
    SET @NumTablesDeletedFrom = 0

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
     ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddUpdateUserProfile]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AddUpdateUserProfile]
 @image NVARCHAR(250),
 @UserName NVARCHAR(256), 
 @FirstName NVARCHAR(100), 
 @LastName NVARCHAR(100),
 @FullName NVARCHAR(250), 
 @Location NVARCHAR(50),
 @AboutYou NVARCHAR(MAX),
 @Email NVARCHAR(MAX), 
 @ResPhone NVARCHAR(50),
 @Mobile NVARCHAR(50),
 @Others NVARCHAR(max),
 @AddedOn DATETIME,
 @AddedBy NVARCHAR,
 @UpdatedOn DATETIME, 
 @PortalID INT, 
 @UpdatedBy NVARCHAR(256),
 @BirthDate DATETIME,
 @Gender INT
AS
BEGIN
UPDATE [dbo].[PortalUser] SET
 FirstName = @FirstName,
 LastName = @LastName,
 Email=@Email,
 UpdatedOn=getdate(),
 UpdatedBy=@UpdatedBy
 WHERE 
 Username=@UserName and PortalID=@PortalID

 DECLARE @UserProfileID INT
 DECLARE @UserId UNIQUEIDENTIFIER
 SELECT @UserId=UserId FROM PortalUser 
 WHERE 
 Username=@UserName and PortalID=@PortalID
 
 
   UPDATE dbo.aspnet_Membership SET Email=@Email,
        LoweredEmail=LOWER(@Email)
       WHERE                 
        UserId=@UserId
        
        UPDATE dbo.Users SET FirstName=@FirstName,
      LastName=@LastName,
      Email=@Email,      
      UpdatedOn=getdate(),
      UpdatedBy=@UpdatedBy
      WHERE
                  Username=@UserName
      AND PortalID=@PortalID

END
IF(Not Exists(SELECT * FROM [dbo].[UserDetails] WHERE  [UserName] = @UserName and [PortalID] = @PortalID))
BEGIN

  INSERT INTO [dbo].[UserDetails] (
  [image],
  Username,
  FirstName,
  LastName,
  FullName,
  BirthDate,
  Gender,
  Location,
  AboutYou,
  Email,
  ResPhone,
  Mobile,
  Others,
  AddedOn,
  AddedBy,
  PortalID
        )
  VALUES
  (
  @image,
  @UserName,
  @FirstName,
  @LastName,
  @FullName,
  @BirthDate,
  @Gender,
  @Location,
  @AboutYou,
  @Email,
  @ResPhone,
  @Mobile,
  @Others,
  @AddedOn,
  @AddedBy,
  @PortalID
  )
   SET @UserProfileID=SCOPE_IDENTITY()
  UPDATE [dbo].[UserDetails] SET UserId=@UserProfileID WHERE ProfileID=@UserProfileID
 End
Else
    BEGIN

 UPDATE [dbo].[UserDetails] SET
  [image] = @image,
  FirstName = @FirstName,
  LastName = @LastName,
  FullName = @FullName,
  BirthDate = @BirthDate,
  Gender = @Gender,
  Location = @Location,
  AboutYou = @AboutYou,
  Email = @Email,
  ResPhone = @ResPhone,
  Mobile = @Mobile,
  Others = @Others,
  UpdatedOn = @UpdatedOn,
  UpdatedBy = @UpdatedBy
 WHERE Username = @UserName and PortalID = @PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ActivateUserByUserId]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActivateUserByUserId]
 @ActivationCode NVARCHAR(256),
 @PortalID INT,
 @UserName NVARCHAR(256) OUTPUT   
WITH EXECUTE AS CALLER
AS
BEGIN 
 DECLARE @UserID UNIQUEIDENTIFIER 
 IF(EXISTS(SELECT * FROM [dbo].[Codes] WHERE Code=@ActivationCode AND GETDATE() BETWEEN ActiveFrom AND ActiveTo AND IsAlreadyUsed=0)) 
 BEGIN  
  SELECT @UserName=UserName,@UserID=UserID FROM [dbo].[PortalUser] pu INNER JOIN [dbo].[Codes] dc ON pu.UserName=dc.CodeForUsername AND pu.PortalID=dc.PortalID
  WHERE dc.Code=CAST(@ActivationCode AS UNIQUEIDENTIFIER)
  
  UPDATE [dbo].[Codes] SET IsAlreadyUsed=1 WHERE Code=@ActivationCode

  UPDATE [dbo].[aspnet_Membership] SET IsApproved=1 
  WHERE UserId=@UserID

  UPDATE [dbo].PortalUser SET IsActive=1
  WHERE username=@UserName AND PortalID=@PortalID

  UPDATE [dbo].Users SET IsActive=1
  WHERE username=@UserName
   
 END
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPageRolesNUsername]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  DINESH HONA
-- Create date: 2010-03-15
-- Description: <Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[fn_GetPageRolesNUsername]
(
@PageID int
)
RETURNS nvarchar(1000)
AS
BEGIN
DECLARE @ROLEs nvarchar(1000)
SET @ROLEs=''
SELECT @ROLEs=@ROLEs+','+Coalesce(convert(nvarchar(1000),RoleID),Username) from dbo.PagePermission  where pageID=@PageID
GROUP BY RoleID,Username
SET @ROLEs= substring(@ROLEs,2,len(@ROLEs))
return @ROLEs
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_SetPassword]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_SetPassword]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @NewPassword      nvarchar(128),
    @PasswordSalt     nvarchar(128),
    @CurrentTimeUtc   datetime,
    @PasswordFormat   int = 0
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF (@UserId IS NULL)
        RETURN(1)

    UPDATE dbo.aspnet_Membership
    SET Password = @NewPassword, PasswordFormat = @PasswordFormat, PasswordSalt = @PasswordSalt,
        LastPasswordChangedDate = @CurrentTimeUtc
    WHERE @UserId = UserId
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ResetPassword]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_ResetPassword]
    @ApplicationName             nvarchar(256),
    @UserName                    nvarchar(256),
    @NewPassword                 nvarchar(128),
    @MaxInvalidPasswordAttempts  int,
    @PasswordAttemptWindow       int,
    @PasswordSalt                nvarchar(128),
    @CurrentTimeUtc              datetime,
    @PasswordFormat              int = 0,
    @PasswordAnswer              nvarchar(128) = NULL
AS
BEGIN
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @UserId                                 uniqueidentifier
    SET     @UserId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
     BEGIN TRANSACTION
     SET @TranStarted = 1
    END
    ELSE
     SET @TranStarted = 0

    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF ( @UserId IS NULL )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    SELECT @IsLockedOut = IsLockedOut,
           @LastLockoutDate = LastLockoutDate,
           @FailedPasswordAttemptCount = FailedPasswordAttemptCount,
           @FailedPasswordAttemptWindowStart = FailedPasswordAttemptWindowStart,
           @FailedPasswordAnswerAttemptCount = FailedPasswordAnswerAttemptCount,
           @FailedPasswordAnswerAttemptWindowStart = FailedPasswordAnswerAttemptWindowStart
    FROM dbo.aspnet_Membership WITH ( UPDLOCK )
    WHERE @UserId = UserId

    IF( @IsLockedOut = 1 )
    BEGIN
        SET @ErrorCode = 99
        GOTO Cleanup
    END

    UPDATE dbo.aspnet_Membership
    SET    Password = @NewPassword,
           LastPasswordChangedDate = @CurrentTimeUtc,
           PasswordFormat = @PasswordFormat,
           PasswordSalt = @PasswordSalt
    WHERE  @UserId = UserId AND
           ( ( @PasswordAnswer IS NULL ) OR ( LOWER( PasswordAnswer ) = LOWER( @PasswordAnswer ) ) )

    IF ( @@ROWCOUNT = 0 )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount + 1
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END

            SET @ErrorCode = 3
        END
    ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            END
        END

    IF( NOT ( @PasswordAnswer IS NULL ) )
    BEGIN
        UPDATE dbo.aspnet_Membership
        SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
            FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
        WHERE @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    IF( @TranStarted = 1 )
    BEGIN
 SET @TranStarted = 0
 COMMIT TRANSACTION
    END

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
     ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByUserId]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByUserId]
    @UserId               uniqueidentifier,
    @CurrentTimeUtc       datetime,
    @UpdateLastActivity   bit = 0
AS
BEGIN
    IF ( @UpdateLastActivity = 1 )
    BEGIN
        UPDATE   dbo.aspnet_Users
        SET      LastActivityDate = @CurrentTimeUtc
        FROM     dbo.aspnet_Users
        WHERE    @UserId = UserId

        IF ( @@ROWCOUNT = 0 ) -- User ID not found
            RETURN -1
    END

    SELECT  m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate, m.LastLoginDate, u.LastActivityDate,
            m.LastPasswordChangedDate, u.UserName, m.IsLockedOut,
            m.LastLockoutDate
    FROM    dbo.aspnet_Users u, dbo.aspnet_Membership m
    WHERE   @UserId = u.UserId AND u.UserId = m.UserId

    IF ( @@ROWCOUNT = 0 ) -- User ID not found
       RETURN -1

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByName]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByName]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @CurrentTimeUtc       datetime,
    @UpdateLastActivity   bit = 0
AS
BEGIN
    DECLARE @UserId uniqueidentifier

    IF (@UpdateLastActivity = 1)
    BEGIN
        -- select user ID from aspnet_users table
        SELECT TOP 1 @UserId = u.UserId
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE    LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                LOWER(@UserName) = u.LoweredUserName AND u.UserId = m.UserId

        IF (@@ROWCOUNT = 0) -- Username not found
            RETURN -1

        UPDATE   dbo.aspnet_Users
        SET      LastActivityDate = @CurrentTimeUtc
        WHERE    @UserId = UserId

        SELECT m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
                m.CreateDate, m.LastLoginDate, u.LastActivityDate, m.LastPasswordChangedDate,
                u.UserId, m.IsLockedOut, m.LastLockoutDate
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE  @UserId = u.UserId AND u.UserId = m.UserId 
    END
    ELSE
    BEGIN
        SELECT TOP 1 m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
                m.CreateDate, m.LastLoginDate, u.LastActivityDate, m.LastPasswordChangedDate,
                u.UserId, m.IsLockedOut,m.LastLockoutDate
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE    LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                LOWER(@UserName) = u.LoweredUserName AND u.UserId = m.UserId

        IF (@@ROWCOUNT = 0) -- Username not found
            RETURN -1
    END

    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByEmail]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByEmail]
    @ApplicationName  nvarchar(256),
    @Email            nvarchar(256)
AS
BEGIN
    IF( @Email IS NULL )
        SELECT  u.UserName
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                u.UserId = m.UserId AND
                m.LoweredEmail IS NULL
    ELSE
        SELECT  u.UserName
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                u.UserId = m.UserId AND
                LOWER(@Email) = m.LoweredEmail

    IF (@@rowcount = 0)
        RETURN(1)
    RETURN(0)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPasswordWithFormat]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetPasswordWithFormat]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @UpdateLastLoginActivityDate    bit,
    @CurrentTimeUtc                 datetime
AS
BEGIN
    DECLARE @IsLockedOut                        bit
    DECLARE @UserId                             uniqueidentifier
    DECLARE @Password                           nvarchar(128)
    DECLARE @PasswordSalt                       nvarchar(128)
    DECLARE @PasswordFormat                     int
    DECLARE @FailedPasswordAttemptCount         int
    DECLARE @FailedPasswordAnswerAttemptCount   int
    DECLARE @IsApproved                         bit
    DECLARE @LastActivityDate                   datetime
    DECLARE @LastLoginDate                      datetime

    SELECT  @UserId          = NULL

    SELECT  @UserId = u.UserId, @IsLockedOut = m.IsLockedOut, @Password=Password, @PasswordFormat=PasswordFormat,
            @PasswordSalt=PasswordSalt, @FailedPasswordAttemptCount=FailedPasswordAttemptCount,
      @FailedPasswordAnswerAttemptCount=FailedPasswordAnswerAttemptCount, @IsApproved=IsApproved,
            @LastActivityDate = LastActivityDate, @LastLoginDate = LastLoginDate
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF (@UserId IS NULL)
        RETURN 1

    IF (@IsLockedOut = 1)
        RETURN 99

    SELECT   @Password, @PasswordFormat, @PasswordSalt, @FailedPasswordAttemptCount,
             @FailedPasswordAnswerAttemptCount, @IsApproved, @LastLoginDate, @LastActivityDate

    IF (@UpdateLastLoginActivityDate = 1 AND @IsApproved = 1)
    BEGIN
        UPDATE  dbo.aspnet_Membership
        SET     LastLoginDate = @CurrentTimeUtc
        WHERE   UserId = @UserId

        UPDATE  dbo.aspnet_Users
        SET     LastActivityDate = @CurrentTimeUtc
        WHERE   @UserId = UserId
    END


    RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPassword]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetPassword]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @MaxInvalidPasswordAttempts     int,
    @PasswordAttemptWindow          int,
    @CurrentTimeUtc                 datetime,
    @PasswordAnswer                 nvarchar(128) = NULL
AS
BEGIN
    DECLARE @UserId                                 uniqueidentifier
    DECLARE @PasswordFormat                         int
    DECLARE @Password                               nvarchar(128)
    DECLARE @passAns                                nvarchar(128)
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
     BEGIN TRANSACTION
     SET @TranStarted = 1
    END
    ELSE
     SET @TranStarted = 0

    SELECT  @UserId = u.UserId,
            @Password = m.Password,
            @passAns = m.PasswordAnswer,
            @PasswordFormat = m.PasswordFormat,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m WITH ( UPDLOCK )
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF ( @@rowcount = 0 )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    IF( @IsLockedOut = 1 )
    BEGIN
        SET @ErrorCode = 99
        GOTO Cleanup
    END

    IF ( NOT( @PasswordAnswer IS NULL ) )
    BEGIN
        IF( ( @passAns IS NULL ) OR ( LOWER( @passAns ) <> LOWER( @PasswordAnswer ) ) )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount + 1
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END

            SET @ErrorCode = 3
        END
        ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            END
        END

        UPDATE dbo.aspnet_Membership
        SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
            FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
        WHERE @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    IF( @TranStarted = 1 )
    BEGIN
 SET @TranStarted = 0
 COMMIT TRANSACTION
    END

    IF( @ErrorCode = 0 )
        SELECT @Password, @PasswordFormat

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
     ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetNumberOfUsersOnline]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetNumberOfUsersOnline]
    @ApplicationName            nvarchar(256),
    @MinutesSinceLastInActive   int,
    @CurrentTimeUtc             datetime
AS
BEGIN
    DECLARE @DateActive datetime
    SELECT  @DateActive = DATEADD(minute,  -(@MinutesSinceLastInActive), @CurrentTimeUtc)

    DECLARE @NumOnline int
    SELECT  @NumOnline = COUNT(*)
    FROM    dbo.aspnet_Users u WITH(NOLOCK),
            dbo.aspnet_Applications a WITH(NOLOCK),
            dbo.aspnet_Membership m WITH(NOLOCK)
    WHERE   u.ApplicationId = a.ApplicationId                  AND
            LastActivityDate > @DateActive                     AND
            a.LoweredApplicationName = LOWER(@ApplicationName) AND
            u.UserId = m.UserId
    RETURN(@NumOnline)
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetAllUsers]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetAllUsers]
    @ApplicationName       nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0


    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
    SELECT u.UserId
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u
    WHERE  u.ApplicationId = @ApplicationId AND u.UserId = m.UserId
    ORDER BY u.UserName

    SELECT @TotalRecords = @@ROWCOUNT

    SELECT u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY u.UserName
    RETURN @TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByName]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_FindUsersByName]
    @ApplicationName       nvarchar(256),
    @UserNameToMatch       nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
        SELECT u.UserId
        FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND u.LoweredUserName LIKE LOWER(@UserNameToMatch)
        ORDER BY u.UserName


    SELECT  u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY u.UserName

    SELECT  @TotalRecords = COUNT(*)
    FROM    #PageIndexForUsers
    RETURN @TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByEmail]    Script Date: 12/29/2014 16:38:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_FindUsersByEmail]
    @ApplicationName       nvarchar(256),
    @EmailToMatch          nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    IF( @EmailToMatch IS NULL )
        INSERT INTO #PageIndexForUsers (UserId)
            SELECT u.UserId
            FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
            WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND m.Email IS NULL
            ORDER BY m.LoweredEmail
    ELSE
        INSERT INTO #PageIndexForUsers (UserId)
            SELECT u.UserId
            FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
            WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND m.LoweredEmail LIKE LOWER(@EmailToMatch)
            ORDER BY m.LoweredEmail

    SELECT  u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY m.LoweredEmail

    SELECT  @TotalRecords = COUNT(*)
    FROM    #PageIndexForUsers
    RETURN @TotalRecords
END
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]
    @ApplicationName       nvarchar(256),
    @UserName              nvarchar(256),
    @NewPasswordQuestion   nvarchar(256),
    @NewPasswordAnswer     nvarchar(128)
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Membership m, dbo.aspnet_Users u, dbo.aspnet_Applications a
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId
    IF (@UserId IS NULL)
    BEGIN
        RETURN(1)
    END

    UPDATE dbo.aspnet_Membership
    SET    PasswordQuestion = @NewPasswordQuestion, PasswordAnswer = @NewPasswordAnswer
    WHERE  UserId=@UserId
    RETURN(0)
END
GO
/****** Object:  Table [dbo].[HtmlText]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HtmlText](
	[HTMLTextID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[CultureName] [nvarchar](256) NULL,
	[IsAllowedToComment] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_HtmlText] PRIMARY KEY CLUSTERED 
(
	[HTMLTextID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  View [dbo].[vw_PagePermissions]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_PagePermissions]
AS
SELECT DISTINCT 
                      PP.PagePermissionID, PP.PageID, P.PermissionID, PP.RoleID, PP.AllowAccess, P.PermissionCode, MDP.ModuleDefID, P.PermissionKey, 
                      P.PermissionName, Pg.PortalID, PP.IsActive, PP.IsDeleted, PP.IsModified, PP.AddedOn, PP.UpdatedOn, PP.DeletedOn, PP.AddedBy, PP.UpdatedBy, 
                      PP.DeletedBy, R.RoleName, U.UserName
FROM         dbo.PagePermission AS PP INNER JOIN
                      dbo.Pages AS Pg ON PP.PageID = Pg.PageID AND PP.PortalID = Pg.PortalID LEFT OUTER JOIN
                      dbo.Permission AS P ON PP.PermissionID = P.PermissionID LEFT OUTER JOIN
                      dbo.ModuleDefPermission AS MDP ON P.PermissionID = MDP.PermissionID LEFT OUTER JOIN
                      dbo.aspnet_Roles AS R ON PP.RoleID = R.RoleId LEFT OUTER JOIN
                      dbo.aspnet_UsersInRoles AS UR ON R.RoleId = UR.RoleId LEFT OUTER JOIN
                      dbo.aspnet_Users AS U ON UR.UserId = U.UserId
GO
/****** Object:  Table [dbo].[UserModuleSettings]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModuleSettings](
	[UserModuleID] [int] NOT NULL,
	[SettingName] [nvarchar](50) NOT NULL,
	[SettingValue] [nvarchar](2000) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_ModuleSettings] PRIMARY KEY CLUSTERED 
(
	[UserModuleID] ASC,
	[SettingName] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_AddUpdateLocalModuleTitle]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_AddUpdateLocalModuleTitle]
@UserModuleID INT,
@LocalModuleTitle NVARCHAR(max),
@CultureCode NVARCHAR(50)
AS
BEGIN
DECLARE @UserModuleTitle NVARCHAR(250)
SET @UserModuleTitle=(SELECT UserModuleTitle FROM UserModules WHERE  UserModuleID=@UserModuleID)
 IF(EXISTS(SELECT UserModuleID FROM [dbo].[LocalModuleTitle] WHERE UserModuleID=@UserModuleID AND CultureCode=@CultureCode))
 BEGIN
  UPDATE [LocalModuleTitle]
  SET LocalModuleTitle=@LocalModuleTitle,UserModule=@UserModuleTitle
  WHERE UserModuleID=@UserModuleID
  AND CultureCode=@CultureCode
 END
ELSE
  BEGIN
   INSERT INTO [LocalModuleTitle](UserModuleID,LocalModuleTitle,CultureCode,UserModule)
   VALUES(@UserModuleID,@LocalModuleTitle,@CultureCode,@UserModuleTitle)
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModulesAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UserModulesAdd] 
(@ModuleDefID INT,
 @UserModuleTitle NVARCHAR (256),
 @AllPages BIT,
 @ShowInPages NVARCHAR (256),
 @InheritViewPermissions BIT,
 @IsActive BIT,
 @AddedOn DATETIME,
 @PortalID INT,
 @AddedBy NVARCHAR (256),
 @SEOName NVARCHAR (100),
 @IsHandheld BIT,
 @SuffixClass NVARCHAR (200),
 @HeaderText NVARCHAR (500),
 @ShowHeaderText BIT,
 @IsInAdmin BIT,
 @UserModuleID INT = NULL OUTPUT,
 @ControlCount INT = NULL OUTPUT )
 AS
 BEGIN

  INSERT INTO dbo.UserModules (
 [ModuleDefID],
 [UserModuleTitle],
 [AllPages],
 [ShowInPages],
 [InheritViewPermissions],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy],
 [SEOName],
 [IsHandheld],
 [SuffixClass],
 [HeaderText],
 [ShowHeaderText],
 [IsInAdmin]
)
VALUES
 (
  @ModuleDefID,
  @UserModuleTitle,
  @AllPages,
  @ShowInPages,
  @InheritViewPermissions,
  @IsActive,
  getdate(),
  @PortalID,
  @AddedBy,
  @SEOName,
  @IsHandheld,
  @SuffixClass,
  @HeaderText,
  @ShowHeaderText,
  @IsInAdmin
 )
SET @UserModuleID = SCOPE_IDENTITY() SELECT
 @ControlCount = COUNT (*)
FROM
 ModuleControls mc
WHERE
 mc.ModuleDefID =@ModuleDefID ; 
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_sf_CreateUser]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[usp_sf_CreateUser]
    @ApplicationName                        NVARCHAR(256),
    @UserName                               NVARCHAR(256),
 @FirstName        NVARCHAR(256),
 @LastName        NVARCHAR(256),
    @Password                               NVARCHAR(128),
    @PasswordSalt                           NVARCHAR(128),
    @Email                                  NVARCHAR(256),
    @PasswordQuestion                       NVARCHAR(256),
    @PasswordAnswer                         NVARCHAR(128),
    @IsApproved                             BIT,
    @CurrentTimeUtc                         DATETIME,
    @CreateDate                             DATETIME = NULL,
    @UniqueEmail                            INT      = 0,
    @PasswordFormat                         INT      = 0,
 @PortalID        INT, 
 @AddedOn        DATETIME, 
 @AddedBy        NVARCHAR(256),
 @RoleNames        NVARCHAR(4000),   
    @ErrorCode        INT output,
 @StoreID        INT,
    @CustomerID                             INT output,
    @UserId                                 UNIQUEIDENTIFIER OUTPUT
 
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    SELECT  @ApplicationId = NULL
    DECLARE @NewUserId UNIQUEIDENTIFIER
    SELECT @NewUserId = NULL
    DECLARE @IsLockedOut BIT
    SET @IsLockedOut = 0
    DECLARE @LastLockoutDate DATETIME
    SET @LastLockoutDate = CONVERT(DATETIME,'17540101',112)
    DECLARE @FailedPasswordAttemptCount INT
    SET @FailedPasswordAttemptCount = 0
    DECLARE @FailedPasswordAttemptWindowStart DATETIME
    SET @FailedPasswordAttemptWindowStart = CONVERT( DATETIME, '17540101', 112 )
    DECLARE @FailedPasswordAnswerAttemptCount INT
    SET @FailedPasswordAnswerAttemptCount = 0
    DECLARE @FailedPasswordAnswerAttemptWindowStart DATETIME
    SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( DATETIME, '17540101', 112 )
    DECLARE @NewUserCreated BIT
    DECLARE @ReturnValue   INT
    SET @ReturnValue = 0
 DECLARE @NewID INT
    DECLARE @TranStarted BIT
    SET @TranStarted = 0
 DECLARE @DUP_REG_KEY NVARCHAR(50)
 SET @DUP_REG_KEY='DUPLICATE_USERS_ACROSS_PORTALS';
 DECLARE @DUP_EMAIL NVARCHAR(50)
 SET @DUP_EMAIL='DUPLICATE_EMAIL_ALLOWED';
    DECLARE @AllowDuplicateRegistration INT
 DECLARE @DuplicateEmail INT
 SELECT @DuplicateEmail=CAST(SettingValue AS INT) FROM MembershipSettings 
 WHERE SettingKey=@DUP_EMAIL
 SELECT @AllowDuplicateRegistration=CAST(SettingValue AS INT) FROM MembershipSettings 
 WHERE SettingKey=@DUP_REG_KEY
 DECLARE @IsEmailExists BIT
 SET @IsEmailExists=0

 IF (EXISTS(SELECT Email FROM aspnet_Membership WHERE Email=@Email))
  BEGIN
  SET @IsEmailExists=1
  END

 DECLARE @PortalUserID INT
 SET @PortalUserID=0
 
 IF @DuplicateEmail=0 AND @IsEmailExists=1
  BEGIN
   SET @ErrorCode = 3
   GOTO Cleanup 
  END

    IF( @@TRANCOUNT = 0 )
    BEGIN
     BEGIN TRANSACTION
     SET @TranStarted = 1
    END
    ELSE
     SET @TranStarted = 0
    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END
    SET @CreateDate = @CurrentTimeUtc
    IF @AllowDuplicateRegistration=0 
 BEGIN  
  IF (NOT EXISTS(SELECT UserId 
                 FROM dbo.aspnet_Users 
                 WHERE LOWER(@UserName) = LoweredUserName AND @ApplicationId = ApplicationId))
  BEGIN
   IF @DuplicateEmail=0   
   SET @NewUserId = @UserId
   EXEC @ReturnValue = dbo.aspnet_Users_CreateUser @ApplicationId, 
                       @UserName, 0, @CreateDate, @NewUserId OUTPUT;
   EXEC dbo.usp_PortalUsersAdd @NewUserId,@UserName,@FirstName,
        @LastName,@Email,@IsApproved,@AddedOn,@PortalID,@AddedBy;
   EXEC dbo.usp_sf_UserInRolesAdd @ApplicationName,@NewUserId,@RoleNames,@PortalID;
   EXEC dbo.usp_UsersAdd @NewID output,@UserName,@FirstName,@LastName,
        @Email,@IsApproved,@AddedOn,@PortalID,@AddedBy;
          
   
   SET @NewUserCreated = 1
  END
  ELSE
  BEGIN
   SET @NewUserCreated = 0   
    SET @ErrorCode = 6
    GOTO Cleanup   
  END
    END
 ELSE
 BEGIN
  IF (NOT EXISTS(SELECT * FROM dbo.PortalUser 
                 WHERE  LOWER(Username)=LOWER(@UserName) 
                 AND PortalID=@PortalID))
  BEGIN  
   SET @NewUserId = @UserId 
   EXEC @ReturnValue = dbo.aspnet_Users_CreateUser @ApplicationId,
            @UserName, 0, @CreateDate, @NewUserId OUTPUT;
   EXEC dbo.usp_PortalUsersAdd @NewUserId,@UserName,@FirstName,
            @LastName,@Email,@IsApproved,@AddedOn,@PortalID,@AddedBy;
   EXEC dbo.usp_sf_UserInRolesAdd @ApplicationName,@NewUserId,
            @RoleNames,@PortalID;
   EXEC dbo.usp_UsersAdd @NewID output,@UserName,@FirstName,@LastName,
            @Email,@IsApproved,@AddedOn,@PortalID,@AddedBy
     
   
   SET @NewUserCreated = 1
  END
  ELSE
  BEGIN
   SET @NewUserCreated = 0   
   BEGIN
    SET @ErrorCode = 6
    GOTO Cleanup
   END
  END
    END

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @ReturnValue = -1 )
    BEGIN
        SET @ErrorCode = 10
        GOTO Cleanup
    END

    IF ( EXISTS ( SELECT UserId
                  FROM   dbo.aspnet_Membership
                  WHERE  @NewUserId = UserId ) )
    BEGIN
        SET @ErrorCode = 6
        GOTO Cleanup
    END

    SET @UserId = @NewUserId

    IF (@UniqueEmail = 1)
    BEGIN
        IF (EXISTS (SELECT *
                    FROM  dbo.aspnet_Membership m WITH ( UPDLOCK, HOLDLOCK )
                    WHERE ApplicationId = @ApplicationId AND LoweredEmail = LOWER(@Email)))
        BEGIN
            SET @ErrorCode = 7
            GOTO Cleanup
        END
    END

    IF (@NewUserCreated = 0)
    BEGIN
        UPDATE dbo.aspnet_Users
        SET    LastActivityDate = @CreateDate
        WHERE  @UserId = UserId
        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    INSERT INTO dbo.aspnet_Membership
                ( ApplicationId,
                  UserId,
                  Password,
                  PasswordSalt,
                  Email,
                  LoweredEmail,
                  PasswordQuestion,
                  PasswordAnswer,
                  PasswordFormat,
                  IsApproved,
                  IsLockedOut,
                  CreateDate,
                  LastLoginDate,
                  LastPasswordChangedDate,
                  LastLockoutDate,
                  FailedPasswordAttemptCount,
                  FailedPasswordAttemptWindowStart,
                  FailedPasswordAnswerAttemptCount,
                  FailedPasswordAnswerAttemptWindowStart )
         VALUES ( @ApplicationId,
                  @UserId,
                  @Password,
                  @PasswordSalt,
                  @Email,
                  LOWER(@Email),
                  @PasswordQuestion,
                  @PasswordAnswer,
                  @PasswordFormat,
                  @IsApproved,
                  @IsLockedOut,
                  @CreateDate,
                  @CreateDate,
                  @CreateDate,
                  @LastLockoutDate,
                  @FailedPasswordAttemptCount,
                  @FailedPasswordAttemptWindowStart,
                  @FailedPasswordAnswerAttemptCount,
                  @FailedPasswordAnswerAttemptWindowStart )

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
     SET @TranStarted = 0
     COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
     ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModulesUpdate]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UserModulesUpdate] 
(@UserModuleID INT,
 @ModuleDefID INT,
 @UserModuleTitle NVARCHAR (256),
 @AllPages BIT,
 @ShowInPages NVARCHAR (256),
 @InheritViewPermissions BIT,
 @IsActive BIT,
 @AddedOn DATETIME,
 @PortalID INT,
 @AddedBy NVARCHAR (256),
 @SEOName NVARCHAR (100),
 @IsHandheld BIT,
 @SuffixClass NVARCHAR (200),
 @HeaderText NVARCHAR (500),
 @ShowHeaderText BIT )AS
BEGIN

SET NOCOUNT ON ; 
UPDATE dbo.UserModules
SET AllPages =@AllPages,
 ShowInPages =@ShowInPages,
 InheritViewPermissions =@InheritViewPermissions,
 IsActive =@IsActive,
 IsHandheld =@IsHandheld,
 UserModuleTitle =@UserModuleTitle,
 SuffixClass =@SuffixClass,
 HeaderText =@HeaderText,
 ShowHeaderText =@ShowHeaderText
WHERE
 UserModuleID =@UserModuleID
AND PortalID =@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModuleHistory]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UserModuleHistory]
 @PageID varchar(1000),
 @DeletedBy nvarchar(256),
 @PortalID int
       
 AS 
 BEGIN 
 SET NOCOUNT ON;
  --- update SHowinpages in History table -- added swantina 20140108
  
   DECLARE @PageIdPstnFirstOrMiddle varchar(100) 
   DECLARE @PageIdPstnEnd varchar(100) 

   SET @PageIdPstnFirstOrMiddle = @PageId + ','   
   SET @PageIdPstnEnd =  ',' +@PageId 
   

   IF EXISTS(SELECT CHARINDEX(@PageId,ShowInPages) 
   FROM   UserModules
   WHERE  ShowInPages = @PageID AND PortalID = @PortalID) 
    BEGIN

     INSERT INTO [UserModules_History] 
     SELECT Getdate(),'U', @DeletedBy, * FROM [UserModules] WHERE ShowInPages = @PageID;

     UPDATE [UserModules] SET ShowInPages = NULL, [IsActive] =0 ,[IsDeleted] = 1  WHERE   ShowInPages = @PageID AND PortalID = @PortalID;     
    END   

   ELSE IF EXISTS(SELECT CHARINDEX(@PageIdPstnFirstOrMiddle,ShowInPages) 
   FROM   UserModules
   WHERE  ShowInPages like '%'+@PageIdPstnFirstOrMiddle +'%' AND PortalID = @PortalID ) 
    BEGIN

       INSERT INTO [UserModules_History] 
       SELECT Getdate(),'U', @DeletedBy, * FROM [UserModules] WHERE ShowInPages like '%'+@PageIdPstnFirstOrMiddle +'%' AND PortalID = @PortalID;

       UPDATE UserModules
       SET  ShowInPages =   SUBSTRING(ShowInPages,0,CHARINDEX(@PageIdPstnFirstOrMiddle,ShowInPages))+ SUBSTRING(ShowInPages,CHARINDEX(@PageIdPstnFirstOrMiddle,ShowInPages)+LEN(@PageIdPstnFirstOrMiddle),LEN(ShowInPages))
        ,[IsActive] =0 ,[IsDeleted] = 1 WHERE  ShowInPages like '%'+@PageIdPstnFirstOrMiddle +'%' AND PortalID = @PortalID  

    END

   ELSE IF EXISTS(SELECT CHARINDEX(@PageIdPstnEnd,ShowInPages) 
     FROM   UserModules
     WHERE ShowInPages like '%'+@PageIdPstnEnd +'%' AND PortalID = @PortalID ) 
    BEGIN
     

      INSERT INTO [UserModules_History] 
      SELECT Getdate(),'U', @DeletedBy, * FROM [UserModules] WHERE ShowInPages like '%'+@PageIdPstnEnd +'%' AND PortalID = @PortalID;

      --SUBSTRING(ShowInPages,0,CHARINDEX(@PageIdPstnEnd,ShowInPages)+1)+ SUBSTRING(ShowInPages,CHARINDEX(@PageIdPstnEnd,ShowInPages)+ LEN(@PageIdPstnEnd),LEN(ShowInPages))  

      UPDATE UserModules 
      SET     ShowInPages = SUBSTRING(ShowInPages,0,CHARINDEX(@PageIdPstnEnd,ShowInPages))--+ SUBSTRING(ShowInPages,CHARINDEX(@PageIdPstnEnd,ShowInPages)+ LEN(@PageIdPstnEnd),LEN(ShowInPages))  
        ,[IsActive] =0 ,[IsDeleted] = 1
      WHERE   ShowInPages like '%'+@PageIdPstnEnd +'%'   AND PortalID = @PortalID
    END 

 END
GO
/****** Object:  StoredProcedure [dbo].[usp_MenuLocalizeGetModuleTitle]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [dbo].[usp_MenuLocalizeGetModuleTitle]1,'ne-NP'
CREATE PROCEDURE [dbo].[usp_MenuLocalizeGetModuleTitle]
@PortalID INT,
@CultureCode NVARCHAR(20)
AS
BEGIN

 SELECT 
  m.UserModuleID,
  m.UserModuleTitle, 
  (
   CASE WHEN 
      (
      SELECT 
       COUNT(UserModuleID) 
      FROM 
       LocalModuleTitle
      WHERE 
        UserModuleID=m.UserModuleID 
       AND CultureCode=@CultureCode
     )>0
    THEN 
     (
      SELECT 
       LocalModuleTitle 
      FROM 
       LocalModuleTitle 
      WHERE 
        UserModuleID=m.UserModuleID 
       AND CultureCode=@CultureCode
     )
    ELSE 
     (
      SELECT 
        HeaderText
      FROM 
       UserModules 
      WHERE 
       UserModuleID=m.UserModuleID
      ) 
    END
  ) AS LocalModuleTitle 
  
 FROM 
  UserModules m 
 WHERE 
  (
    m.PortalID=@PortalID 
   OR m.PortalID=-1
   
  )
  AND (m.IsDeleted=0 OR m.IsDeleted IS NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleControlGetModuleNameFromUserModuleId]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleControlGetModuleNameFromUserModuleId]
 @UserModuleID INT

AS
BEGIN
 SELECT 
  UserModuleTitle 
 FROM 
  [dbo].[UserModules] 
 WHERE 
  UserModuleID = @UserModuleID 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleControlGetModuleIdFromUserModuleId]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleControlGetModuleIdFromUserModuleId]
 @UserModuleID INT

AS

BEGIN
 SELECT 
  ModuleDefID 
 FROM 
  [dbo].[UserModules] 
 WHERE 
  UserModuleID = @UserModuleID 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleControlGetControlTypeFromModuleID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleControlGetControlTypeFromModuleID]
 @ModuleDefID INT

AS
BEGIN
 SELECT 
  ControlTitle,
  ControlType,
  ControlSrc 
 FROM 
  [dbo].[ModuleControls] 
 WHERE 
  ModuleDefID = @ModuleDefID 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleMessageGetByUserModuleID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleMessageGetByUserModuleID]
(
@UserModuleID INT,
@Culture NVARCHAR(50)
)
AS
BEGIN
 DECLARE @ModuleID INT
 SELECT 
  @ModuleID=md.ModuleID 
 FROM 
  UserModules um 
 INNER JOIN 
  ModuleDefinitions md 
 ON 
  um.ModuleDefID=md.ModuleDefID 
 WHERE 
  um.UserModuleID=@UserModuleID

 SELECT 
  * 
 FROM 
  ModuleMessage 
 WHERE 
   ModuleID=@ModuleID 
  AND Culture=@Culture
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageMenuAdminGet]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageMenuAdminGet]
 @ParentNodeID [int],
 @UserName [NVARCHAR](256),
 @PortalID [int],
 @CultureCode NVARCHAR(20)
WITH EXECUTE AS CALLER
AS
BEGIN 
 DECLARE @PortalSEOName NVARCHAR(200), @IsParentPortal BIT, @UseFriendlyUrls NVARCHAR(256), @PortalPrefix NVARCHAR(200)
 SELECT @PortalSEOName=LTRIM(RTRIM(SEOName)),@IsParentPortal=IsParent FROM dbo.Portal WHERE PortalID=@PortalID
 SET @PortalPrefix=''
 IF(NOT(@IsParentPortal=1))
 BEGIN
  SET @PortalPrefix='/portal/'+@PortalSEOName
 END
 SELECT DISTINCT [dbo].[Pages].PageID INTO #tmppage FROM [dbo].[Pages] 
 INNER JOIN [dbo].[PagePermission] ON [dbo].[PagePermission].PageID  = [dbo].[Pages].PageID
 WHERE IsVisible=1 AND [dbo].[Pages].IsActive=1 AND ([dbo].[Pages].IsDeleted=0 OR [dbo].[Pages].IsDeleted IS NULL) 
 AND [dbo].[PagePermission].[RoleID] IN ( SELECT [dbo].[aspnet_Roles].RoleId
    FROM [dbo].[aspnet_Roles]
    WHERE [dbo].[aspnet_Roles].RoleName IN ('Site Admin','Super User')
 )
 AND (([dbo].[Pages].PortalID=-1 AND @ParentNodeID=0) OR @ParentNodeID>0)  AND [dbo].[Pages].ParentID=@ParentNodeID 
 AND ([dbo].[Pages].IsDeleted=0 OR [dbo].[Pages].IsDeleted IS NULL)
 SELECT @UseFriendlyUrls= dbo.fn_GetSettingValueBySettingKey('SuperUser',1,'UseFriendlyUrls')
 IF UPPER(@UseFriendlyUrls)='TRUE'
 BEGIN
  SELECT [dbo].[Pages].PageID, 
  [dbo].[Pages].PageOrder, 
   ( CASE 
                 WHEN (SELECT COUNT(pageid) 
                       FROM   localpage 
                       WHERE  pageid = [dbo].[Pages].pageid 
                              AND culturecode = @Culturecode) > 0 THEN (SELECT 
                 localpagename 
                                                                        FROM 
                 localpage 
                                                                        WHERE 
                 pageid = [dbo].[Pages].pageid  
                 AND culturecode = @CultureCode) 
                 ELSE (SELECT pagename 
                       FROM   pages 
                       WHERE  pageid = [dbo].[Pages].pageid ) 
               END )                               AS PageName,
  [dbo].[Pages].IsVisible, 
  [dbo].[Pages].ParentID, 
  [dbo].[Pages].[Level], 
  [dbo].[Pages].IconFile, 
  [dbo].[Pages].DisableLink, 
  [dbo].[Pages].Title, 
  [dbo].[Pages].[Description], 
  [dbo].[Pages].KeyWords, 
  (CASE WHEN ([dbo].[Pages].Url IS NULL) OR (LEN(RTRIM(LTRIM([dbo].[Pages].Url)))<1) THEN @PortalPrefix+[dbo].[Pages].TabPath+'.aspx' 
   ELSE [dbo].[Pages].Url END) AS TabPath, 
  [dbo].[Pages].Url, 
  [dbo].[Pages].StartDate, 
  [dbo].[Pages].EndDate, 
  [dbo].[Pages].RefreshInterval, 
  [dbo].[Pages].PageHeadText, 
  [dbo].[Pages].IsSecure, 
  [dbo].[Pages].IsActive,
  [dbo].[fn_GetPageRolesNUsername]([dbo].[Pages].PageID) AS PageRoles
 FROM   [dbo].[Pages] 
 INNER JOIN #tmppage ON #tmppage.PageID = [dbo].[Pages].PageID
 ORDER BY [dbo].[Pages].PageOrder ASC
 END
 ELSE
 BEGIN
 SELECT [dbo].[Pages].PageID, 
  [dbo].[Pages].PageOrder, 
  ( CASE 
                 WHEN (SELECT COUNT(pageid) 
                       FROM   localpage 
                       WHERE  pageid = [dbo].[Pages].pageid 
                              AND culturecode = @Culturecode) > 0 THEN (SELECT 
                 localpagename 
                                                                        FROM 
                 localpage 
                                                                        WHERE 
                 pageid = [dbo].[Pages].pageid  
                 AND culturecode = @CultureCode) 
                 ELSE (SELECT pagename 
                       FROM   pages 
                       WHERE  pageid = [dbo].[Pages].pageid ) 
               END )                               AS PageName,
  [dbo].[Pages].IsVisible, 
  [dbo].[Pages].ParentID, 
  [dbo].[Pages].[Level], 
  [dbo].[Pages].IconFile, 
  [dbo].[Pages].DisableLink, 
  [dbo].[Pages].Title, 
  [dbo].[Pages].[Description], 
  [dbo].[Pages].KeyWords, 
  (CASE WHEN ([dbo].[Pages].Url IS NULL) OR (len(RTRIM(LTRIM([dbo].[Pages].Url)))<1) 
   THEN '/Default.aspx?ptlid='+convert(VARCHAR(18),@PortalID)+'&ptSEO='+ISNULL(@PortalSEOName,'')+'&pgnm='+ISNULL([dbo].[Pages].[SEOName],'') 
   ELSE [dbo].[Pages].Url END ) AS TabPath, 
  [dbo].[Pages].Url, 
  [dbo].[Pages].StartDate, 
  [dbo].[Pages].EndDate, 
  [dbo].[Pages].RefreshInterval, 
  [dbo].[Pages].PageHeadText, 
  [dbo].[Pages].IsSecure, 
  [dbo].[Pages].IsActive,
  [dbo].[fn_GetPageRolesNUsername]([dbo].[Pages].PageID) AS PageRoles
 FROM   [dbo].[Pages] 
 INNER JOIN #tmppage ON #tmppage.PageID = [dbo].[Pages].PageID
 ORDER BY [dbo].[Pages].PageOrder ASC
 END 
 DROP TABLE #tmpPage
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageFrameUserListSearch]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageFrameUserListSearch]
 @RoleID [NVARCHAR](36),
 @SearchText [NVARCHAR](4000),
 @PortalID [INT],
 @UserName NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN
 DECLARE @SearchResult AS TABLE
        (
        UserId UNIQUEIDENTIFIER
        ,UserName NVARCHAR(256)
        ,FirstName NVARCHAR(100)
        ,LastName NVARCHAR(100)
        ,LoweredUserName NVARCHAR(256)
        ,LastActivityDate DATETIME
        ,Email NVARCHAR(256)
        ,LastLoginDate DATETIME
        ,LastPasswordChangedDate DATETIME
        ,LastLockoutDate DATETIME
        ,PortalID INT
        ,PortalSEOName NCHAR(100)
        ,IsActive BIT
        ,IsModified BIT
        ,AddedOn DATETIME 
        ,UpdatedOn DATETIME
        ,DeletedOn DATETIME
        ,AddedBy NVARCHAR(256)
        ,UpdatedBy NVARCHAR(256)
        ,DeletedBy NVARCHAR(256)
        )
        
 DECLARE @TblSearchText as Table
        (
         RowNum INT,
         SearchText NVARCHAR(100)
        )
 DECLARE @SearchCount INT, @Counter INT, @UserHasHostRole BIT, @HostRoleId UNIQUEIDENTIFIER
 SELECT @HostRoleId=RoleId FROM dbo.aspnet_roles WHERE RoleName='Super User' OR RoleName='Site Admin'
 if(EXISTS(SELECT * FROM dbo.aspnet_usersinroles uir INNER JOIN dbo.aspnet_users u ON uir.UserId=u.UserId 
 INNER JOIN dbo.aspnet_roles r on uir.RoleId = r.RoleId WHERE u.Username=@UserName AND r.RoleName='Super User' OR r.RoleName='Site Admin' ))
 BEGIN
  SET @UserHasHostRole=1
 END
 ELSE
 BEGIN
  SET @UserHasHostRole=0
 END
 DECLARE @tmpSearchText NVARCHAR(100)
 IF(@RoleID<>'')
 BEGIN
  IF(@SearchText<>'')
  BEGIN
   INSERT INTO @TblSearchText(RowNum,SearchText)
   SELECT row_number()OVER(ORDER BY items),rtrim(ltrim(items)) FROM split(@SearchText,' ')
   SELECT @SearchCount=count(RowNum) FROM @TblSearchText
   SET @counter=1
   WHILE(@counter<=@SearchCount or @counter=1)
   BEGIN
    SELECT @tmpSearchText=SearchText FROM   @TblSearchText WHERE RowNum = @counter;
    IF @UserHasHostRole=1
    BEGIN
     INSERT INTO @SearchResult
     (
     UserId
     ,UserName
     ,[FirstName]
     ,LastName
     ,LoweredUserName
     ,LastActivityDate
     ,Email
     ,LastLoginDate
     ,LastPasswordChangedDate
     ,LastLockoutDate
     ,PortalID
     ,PortalSEOName
     ,IsActive
     ,IsModified
     ,AddedOn
     ,UpdatedOn
     ,DeletedOn
     ,AddedBy
     ,UpdatedBy
     ,DeletedBy
     )
     SELECT DISTINCT 
      sfu.UserId
      ,sfu.UserName
      ,sfu.[FirstName]
      ,sfu.LastName
      ,sfu.LoweredUserName
      ,sfu.LastActivityDate
      ,sfu.Email
      ,sfu.LastLoginDate
      ,sfu.LastPasswordChangedDate
      ,sfu.LastLockoutDate
      ,sfu.PortalID
      ,sfu.PortalSEOName
      ,sfu.IsActive
      ,sfu.IsModified
      ,sfu.AddedOn
      ,sfu.UpdatedOn
      ,sfu.DeletedOn
      ,sfu.AddedBy
      ,sfu.UpdatedBy
      ,sfu.DeletedBy 
     FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir ON sfu.UserId = uir.UserId
     WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User'))       
     AND ( sfu.UserName like @tmpSearchText+'%'
       )
     AND (uir.RoleId = Convert(UNIQUEIDENTIFIER,@RoleId)) 
     AND sfu.UserName<>'anonymoususer'
    END
    ELSE
    BEGIN
     INSERT INTO @SearchResult
     (
     UserId
     ,UserName
     ,[FirstName]
     ,LastName
     ,LoweredUserName
     ,LastActivityDate
     ,Email
     ,LastLoginDate
     ,LastPasswordChangedDate
     ,LastLockoutDate
     ,PortalID
     ,PortalSEOName
     ,IsActive
     ,IsModified
     ,AddedOn
     ,UpdatedOn
     ,DeletedOn
     ,AddedBy
     ,UpdatedBy
     ,DeletedBy
     )
     SELECT DISTINCT sfu.UserId
      ,sfu.UserName
      ,sfu.[FirstName]
      ,sfu.LastName
      ,sfu.LoweredUserName
      ,sfu.LastActivityDate
      ,sfu.Email
      ,sfu.LastLoginDate
      ,sfu.LastPasswordChangedDate
      ,sfu.LastLockoutDate
      ,sfu.PortalID
      ,sfu.PortalSEOName
      ,sfu.IsActive
      ,sfu.IsModified
      ,sfu.AddedOn
      ,sfu.UpdatedOn
      ,sfu.DeletedOn
      ,sfu.AddedBy
      ,sfu.UpdatedBy
      ,sfu.DeletedBy 
     FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir ON sfu.UserId = uir.UserId
    WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User'))        
     AND ( sfu.UserName like @tmpSearchText+'%'
)
     AND (uir.RoleId = Convert(UNIQUEIDENTIFIER,@RoleId)) 
     AND sfu.UserName<>'anonymoususer'
    END
    SET @counter=@counter+1
   END
  END
  ELSE
  BEGIN
   IF(@SearchText<>'')
   BEGIN
    INSERT INTO @SearchResult
    SELECT sfu.UserId
    ,sfu.UserName
    ,sfu.[FirstName]
    ,sfu.LastName
    ,sfu.LoweredUserName
    ,sfu.LastActivityDate
    ,sfu.Email
    ,sfu.LastLoginDate
    ,sfu.LastPasswordChangedDate
    ,sfu.LastLockoutDate
    ,sfu.PortalID
    ,sfu.PortalSEOName
    ,sfu.IsActive
    ,sfu.IsModified
    ,sfu.AddedOn
    ,sfu.UpdatedOn
    ,sfu.DeletedOn
    ,sfu.AddedBy
    ,sfu.UpdatedBy
    ,sfu.DeletedBy
    FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir on sfu.UserId = uir.UserId
    WHERE (PortalID=@PortalID)    
    AND (uir.RoleId = Convert(UNIQUEIDENTIFIER,@RoleId))
    AND sfu.UserName<>'anonymoususer'
   END
   ELSE
   BEGIN
    INSERT INTO @SearchResult
    SELECT sfu.UserId
    ,sfu.UserName
    ,sfu.[FirstName]
    ,sfu.LastName
    ,sfu.LoweredUserName
    ,sfu.LastActivityDate
    ,sfu.Email
    ,sfu.LastLoginDate
    ,sfu.LastPasswordChangedDate
    ,sfu.LastLockoutDate
    ,sfu.PortalID
    ,sfu.PortalSEOName
    ,sfu.IsActive
    ,sfu.IsModified
    ,sfu.AddedOn
    ,sfu.UpdatedOn
    ,sfu.DeletedOn
    ,sfu.AddedBy
    ,sfu.UpdatedBy
    ,sfu.DeletedBy
    FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir ON sfu.UserId = uir.UserId
    WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User'))       
    AND (uir.RoleId = Convert(UNIQUEIDENTIFIER,@RoleId))
    AND sfu.UserName<>'anonymoususer'
   END
  END
 END
 ELSE
 BEGIN
  IF(@SearchText<>'')
  BEGIN  
   INSERT INTO @TblSearchText(RowNum,SearchText)
   SELECT row_number()OVER(ORDER BY items),rtrim(ltrim(items)) FROM split(@SearchText,' ')
   SELECT @SearchCount=count(RowNum) FROM @TblSearchText
   SET @counter=1
   WHILE(@counter<=@SearchCount or @counter=1)
   BEGIN
    SELECT @tmpSearchText=SearchText
    FROM   @TblSearchText
    WHERE RowNum = @counter;
    IF @UserHasHostRole=1 
    BEGIN
     INSERT INTO @SearchResult
     (
     UserId
     ,UserName
     ,[FirstName]
     ,LastName
     ,LoweredUserName
     ,LastActivityDate
     ,Email
     ,LastLoginDate
     ,LastPasswordChangedDate
     ,LastLockoutDate
     ,PortalID
     ,PortalSEOName
     ,IsActive
     ,IsModified
     ,AddedOn
     ,UpdatedOn
     ,DeletedOn
     ,AddedBy
     ,UpdatedBy
     ,DeletedBy
     )
     SELECT DISTINCT sfu.UserId
      ,sfu.UserName
      ,sfu.[FirstName]
      ,sfu.LastName
      ,sfu.LoweredUserName
      ,sfu.LastActivityDate
      ,sfu.Email
      ,sfu.LastLoginDate
      ,sfu.LastPasswordChangedDate
      ,sfu.LastLockoutDate
      ,sfu.PortalID
      ,sfu.PortalSEOName
      ,sfu.IsActive
      ,sfu.IsModified
      ,sfu.AddedOn
      ,sfu.UpdatedOn
      ,sfu.DeletedOn
      ,sfu.AddedBy
      ,sfu.UpdatedBy
      ,sfu.DeletedBy 
     FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir ON sfu.UserId = uir.UserId
     WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User'))       
     AND ( sfu.UserName like @tmpSearchText+'%')
     AND sfu.UserName<>'anonymoususer'
    END
    ELSE
    BEGIN
     INSERT INTO @SearchResult
     (
     UserId
     ,UserName
     ,[FirstName]
     ,LastName
     ,LoweredUserName
     ,LastActivityDate
     ,Email
     ,LastLoginDate
     ,LastPasswordChangedDate
     ,LastLockoutDate
     ,PortalID
     ,PortalSEOName
     ,IsActive
     ,IsModified
     ,AddedOn
     ,UpdatedOn
     ,DeletedOn
     ,AddedBy
     ,UpdatedBy
     ,DeletedBy
     )
     SELECT DISTINCT sfu.UserId
      ,sfu.UserName
      ,sfu.[FirstName]
      ,sfu.LastName
      ,sfu.LoweredUserName
      ,sfu.LastActivityDate
      ,sfu.Email
      ,sfu.LastLoginDate
      ,sfu.LastPasswordChangedDate
      ,sfu.LastLockoutDate
      ,sfu.PortalID
      ,sfu.PortalSEOName
      ,sfu.IsActive
      ,sfu.IsModified
      ,sfu.AddedOn
      ,sfu.UpdatedOn
      ,sfu.DeletedOn
      ,sfu.AddedBy
      ,sfu.UpdatedBy
      ,sfu.DeletedBy 
     FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir ON sfu.UserId = uir.UserId
     WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User'))    
    AND (PortalID=@PortalID)      
     AND (sfu.UserName like @tmpSearchText+'%' )
     AND sfu.UserName<>'anonymoususer'
     AND (uir.RoleId <> @HostRoleId)
    END
    SET @counter=@counter+1
   END
  END
  ELSE
  BEGIN
   IF @UserHasHostRole=1 
   BEGIN
    INSERT INTO @SearchResult
    SELECT sfu.UserId
    ,sfu.UserName
    ,sfu.[FirstName]
    ,sfu.LastName
    ,sfu.LoweredUserName
    ,sfu.LastActivityDate
    ,sfu.Email
    ,sfu.LastLoginDate
    ,sfu.LastPasswordChangedDate
    ,sfu.LastLockoutDate
    ,sfu.PortalID
    ,sfu.PortalSEOName
    ,sfu.IsActive
    ,sfu.IsModified
    ,sfu.AddedOn
    ,sfu.UpdatedOn
    ,sfu.DeletedOn
    ,sfu.AddedBy
    ,sfu.UpdatedBy
    ,sfu.DeletedBy
    FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir ON sfu.UserId = uir.UserId
    WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User'))    
    AND sfu.UserName<>'anonymoususer'
   END
   ELSE
   BEGIN
    INSERT INTO @SearchResult
    SELECT sfu.UserId
    ,sfu.UserName
    ,sfu.[FirstName]
    ,sfu.LastName
    ,sfu.LoweredUserName
    ,sfu.LastActivityDate
    ,sfu.Email
    ,sfu.LastLoginDate
    ,sfu.LastPasswordChangedDate
    ,sfu.LastLockoutDate
    ,sfu.PortalID
    ,sfu.PortalSEOName
    ,sfu.IsActive
    ,sfu.IsModified
    ,sfu.AddedOn
    ,sfu.UpdatedOn
    ,sfu.DeletedOn
    ,sfu.AddedBy
    ,sfu.UpdatedBy
    ,sfu.DeletedBy
    FROM vw_PortalUsers sfu
     INNER JOIN aspnet_usersinroles  uir ON sfu.UserId = uir.UserId
   WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User'))       
    AND (uir.RoleId <> @HostRoleId)
    AND sfu.UserName<>'anonymoususer'
   END
  END
 END
 SELECT DISTINCT 
UserId
     ,UserName
     ,[FirstName]
     ,LastName
     ,LoweredUserName
     ,LastActivityDate
     ,Email
     ,LastLoginDate
     ,LastPasswordChangedDate
     ,LastLockoutDate
     ,PortalID
     ,PortalSEOName
     ,IsActive
     ,IsModified
     ,ISNULL(AddedOn,getdate()) AS AddedOn
     ,UpdatedOn
     ,DeletedOn
     ,AddedBy
     ,UpdatedBy
     ,DeletedBy
 FROM @SearchResult
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SageFramePortalUserSearch]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SageFramePortalUserSearch] 
(
 @RoleID  NVARCHAR(36) , 
    @SearchText NVARCHAR(4000), 
    @PortalID  INT, 
    @UserName NVARCHAR(256) 
  )
WITH EXECUTE AS CALLER 
AS 
  BEGIN 
      DECLARE @SearchMode INT 
      DECLARE @Counter INT 
      DECLARE @Num INT 
      DECLARE @RowCount INT 
      DECLARE @TempSearchText NVARCHAR(100) 
      DECLARE @HostRoleId UNIQUEIDENTIFIER 
      DECLARE @UserHasHostRole INT 
      DECLARE @SearchResult AS TABLE 
      ( 
        UserId                  UNIQUEIDENTIFIER, 
        UserName                NVARCHAR(256), 
        FirstName               NVARCHAR(100), 
        LastName                NVARCHAR(100), 
        LoweredUserName         NVARCHAR(256), 
        LastActivityDate        DATETIME, 
        Email                   NVARCHAR(256), 
        LastLoginDate           DATETIME, 
        LastPasswordChangedDate DATETIME, 
        LastLockOutDate         DATETIME, 
        PortalId                INT, 
        PortalSeoName           NCHAR(100), 
        IsActive                BIT, 
        IsModified              BIT, 
        AddedOn                 DATETIME, 
        UpdatedOn               DATETIME, 
        DeletedOn               DATETIME, 
        AddedBy                 NVARCHAR(256), 
        UpdatedBy               NVARCHAR(256), 
        DeletedBy               NVARCHAR(256)
       ) 
       
      DECLARE @TblSearchText AS TABLE 
      ( 
        RowNum INT, 
        SearchText NVARCHAR(100)
      ) 

      IF( @SearchText <> '' ) 
        BEGIN 
            INSERT INTO @TblSearchText 
                        (RowNum, 
                         SearchText) 
            SELECT ROW_NUMBER()OVER(ORDER BY items), 
                   RTRIM(LTRIM(items)) 
            FROM   Split(@SearchText, ' ') 
        END 
      ELSE 
        BEGIN 
            INSERT INTO @TblSearchText 
                        (RowNum, 
                         SearchText) 
            SELECT 1, 
                   @SearchText 
        END 

      SET @RowCount=@@ROWCOUNT 

      SELECT @HostRoleId = RoleId 
      FROM   dbo.aspnet_Roles 
      WHERE RoleName='Super User' OR RoleName='Site Admin'

      IF( EXISTS(SELECT * 
                 FROM   dbo.aspnet_UsersInRoles uir 
                        INNER JOIN dbo.aspnet_Users u 
                          ON uir.UserId = u.UserId 
                        INNER JOIN dbo.aspnet_Roles r 
                          ON uir.RoleId = r.RoleId 
                 WHERE  u.UserName = @UserName 
                        AND r.RoleName = 'Super User')) 
        BEGIN 
            SET @UserHasHostRole=1 
        END   
      ELSE 
        BEGIN 
            SET @UserHasHostRole=0 
        END 

      SET @SearchMode= CASE 
                         WHEN ( @RoleID = '' 
                                AND @SearchText = '' ) THEN 0 
                         WHEN ( @RoleID = '' 
                                AND @SearchText <> '' ) THEN 1 
                         WHEN ( @RoleID <> '' 
                                AND @SearchText = '' ) THEN 2 
                         WHEN ( @RoleID <> '' 
                                AND @SearchText <> '' ) THEN 3 
                         ELSE 0 
                       END 

      IF @SearchMode = 0 
        BEGIN 
            SET @Counter=1 

            WHILE( @Counter <= @RowCount 
                    OR @Counter = 1 ) 
              BEGIN 
                  SELECT @TempSearchText = SearchText 
                  FROM   @TblSearchText 
                  WHERE  RowNum = @Counter; 

                  IF @UserHasHostRole = 1 
                    BEGIN 
                        INSERT INTO @SearchResult 
                                    (
          UserId, 
          UserName, 
          FirstName, 
          LastName, 
          LoweredUserName, 
          LastActivityDate, 
          Email, 
          LastLoginDate, 
          LastPasswordChangedDate, 
          LastLockOutDate, 
          PortalId, 
          PortalSeoName, 
          IsActive 
         ) 
                        SELECT sfu.UserId, 
                               sfu.UserName, 
                               sfu.FirstName, 
                               sfu.LastName, 
                               sfu.LoweredUserName, 
                               sfu.LastActivityDate, 
                               sfu.Email, 
                               sfu.LastLoginDate, 
                               sfu.LastPasswordChangedDate, 
                               sfu.LastLockoutDate, 
                               sfu.PortalID, 
                               sfu.PortalSEOName, 
                               sfu.IsActive 
                        FROM vw_PortalUsers sfu 
                               INNER JOIN aspnet_UsersInRoles uir 
                                 ON sfu.UserId = uir.UserId 
                  WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User')) 
                    END 

                  SET @Counter=@Counter + 1 
              END 
        END 

      IF @SearchMode = 1 
        BEGIN 
            SET @Counter=1 
            WHILE( @Counter <= @RowCount 
                    OR @Counter = 1 ) 
              BEGIN 
                  SELECT @TempSearchText = SearchText 
                  FROM   @TblSearchText 
                  WHERE  RowNum = @Counter; 

                  IF @UserHasHostRole = 1 
                    BEGIN 
                        INSERT INTO @SearchResult 
                                    (
          UserId, 
          UserName, 
          FirstName, 
          LastName, 
          LoweredUserName, 
          LastActivityDate, 
          Email, 
          LastLoginDate, 
          LastPasswordChangedDate, 
          LastLockOutDate, 
          PortalId, 
          PortalSeoName, 
          IsActive 
                                     ) 
                        SELECT sfu.UserId, 
                               sfu.UserName, 
                               sfu.FirstName, 
                               sfu.LastName, 
                               sfu.LoweredUserName, 
                               sfu.LastActivityDate, 
                               sfu.Email, 
                               sfu.LastLoginDate, 
                               sfu.LastPasswordChangedDate, 
                               sfu.LastLockoutDate, 
                               sfu.PortalID, 
                               sfu.PortalSEOName, 
                               sfu.IsActive 
                        FROM  vw_PortalUsers sfu 
                              INNER JOIN aspnet_UsersInRoles uir 
         ON sfu.UserId = uir.UserId 
                          WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User')) 
                               AND ( sfu.FirstName LIKE @TempSearchText + '%' 
                                      OR sfu.LastName LIKE @TempSearchText + '%' 
                                      OR sfu.Email LIKE @TempSearchText + '%' 
                                      OR sfu.UserName LIKE @TempSearchText + '%' 
                                   ) 
                               AND sfu.UserName <> 'anonymoususer' 
                    END 

                  SET @Counter=@Counter + 1 
              END 
        END 

      IF @SearchMode = 2 
        BEGIN 
            SET @Counter=1 

            WHILE( @Counter <= @RowCount 
                    OR @Counter = 1 ) 
              BEGIN 
                  SELECT @TempSearchText = SearchText 
                  FROM   @TblSearchText 
                  WHERE  RowNum = @Counter; 

                  IF @UserHasHostRole = 1 
                    BEGIN 
                        INSERT INTO @SearchResult 
                                    (
          UserId, 
          UserName, 
          FirstName, 
          LastName, 
          LoweredUserName, 
          LastActivityDate, 
          Email, 
          LastLoginDate, 
          LastPasswordChangedDate, 
          LastLockOutDate, 
          PortalId, 
          PortalSeoName, 
          IsActive
                                     ) 
                        SELECT sfu.UserId, 
                               sfu.UserName, 
                               sfu.FirstName, 
                               sfu.LastName, 
                               sfu.LoweredUserName, 
                               sfu.LastActivityDate, 
                               sfu.Email, 
                               sfu.LastLoginDate, 
                               sfu.LastPasswordChangedDate, 
                               sfu.LastLockoutDate, 
                               sfu.PortalID, 
                               sfu.PortalSEOName, 
                               sfu.IsActive 
                        FROM  vw_PortalUsers sfu 
                               INNER JOIN aspnet_UsersInRoles uir 
                                 ON sfu.UserId = uir.UserId 
                       WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User')) 
                               AND ( uir.RoleId = CONVERT(UNIQUEIDENTIFIER, 
                                                  @RoleId) ) 
                               AND sfu.UserName <> 'anonymoususer' 
                    END 

                  SET @Counter=@Counter + 1 
              END 
        END 

      IF @SearchMode = 3 
        BEGIN 
            SET @Counter=1 

            WHILE( @Counter <= @RowCount 
                    OR @Counter = 1 ) 
              BEGIN 
                  SELECT @TempSearchText = SearchText 
                  FROM   @TblSearchText 
                  WHERE  RowNum = @Counter; 

                  IF @UserHasHostRole = 1 
                    BEGIN 
                        INSERT INTO @SearchResult 
                                    (
          UserId, 
          UserName, 
          FirstName, 
          LastName, 
          LoweredUserName, 
          LastActivityDate, 
          Email, 
          LastLoginDate, 
          LastPasswordChangedDate, 
          LastLockOutDate, 
          PortalId, 
          PortalSeoName, 
          IsActive
                                     ) 
                        SELECT sfu.UserId, 
                               sfu.UserName, 
                               sfu.FirstName, 
                               sfu.LastName, 
                               sfu.LoweredUserName, 
                               sfu.LastActivityDate, 
                               sfu.Email, 
                               sfu.LastLoginDate, 
                               sfu.LastPasswordChangedDate, 
                               sfu.LastLockoutDate, 
                               sfu.PortalID, 
                               sfu.PortalSEOName, 
                               sfu.IsActive 
                        FROM  vw_PortalUsers sfu 
                               INNER JOIN aspnet_UsersInRoles uir 
                                 ON sfu.UserId = uir.UserId 
                      WHERE (PortalID=@PortalID or uir.RoleId in (select RoleId from aspnet_Roles where RoleName='Super User')) 
                               AND ( sfu.FirstName LIKE @TempSearchText + '%' 
                                      OR sfu.LastName LIKE @TempSearchText + '%' 
                                      OR sfu.Email LIKE @TempSearchText + '%' 
                                      OR sfu.UserName LIKE @TempSearchText + '%' 
                                   ) 
                               AND ( uir.RoleId = CONVERT(UNIQUEIDENTIFIER, 
                                                  @RoleId) ) 
                               AND sfu.UserName <> 'anonymoususer' 
                    END 

                  SET @Counter=@Counter + 1 
              END 
        END 

      SELECT DISTINCT * 
      FROM   @SearchResult 
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleMessageUpdateStatus]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ModuleMessageUpdateStatus]
(
 @ModuleID INT,
 @IsActive BIT
)
AS
BEGIN
 DECLARE @MID INT
 SELECT 
  @MID=md.ModuleID 
 FROM 
  UserModules um 
 INNER JOIN 
  ModuleDefinitions md
 ON 
  um.ModuleDefID=md.ModuleDefID 
 WHERE 
  um.UserModuleID=@ModuleID

 
 UPDATE 
  ModuleMessage
 SET 
  IsActive=@IsActive
 WHERE 
  ModuleID=@MID 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetExtensionSetting]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-03-17
CREATE PROCEDURE [dbo].[sp_GetExtensionSetting]
@ModuleID INT,
@PortalID INT
AS
BEGIN
SELECT * FROM [dbo].Modules WHERE ModuleID=@ModuleID
SELECT * FROM [dbo].ModuleDefinitions WHERE ModuleID=@ModuleID
SELECT * FROM  [dbo].ModuleControls 
    INNER JOIN [dbo].ModuleDefinitions ON [dbo].ModuleDefinitions.ModuleDefID = [dbo].ModuleControls.ModuleDefID
    WHERE [dbo].ModuleDefinitions.ModuleID=@ModuleID AND [dbo].ModuleControls.IsDeleted=0 
SELECT * FROM [dbo].Packages WHERE ModuleID=@ModuleID
END
/****** Object:  StoredProcedure [dbo].[sp_GetListEntriesByNameParentKeyAndPortalID]    Script Date: 12/02/2012 12:19:42 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActivationTokenValue]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-04-26
-- Modified DATe: 2010-07-30
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetActivationTokenValue] @UserName NVARCHAR(256),
                                                   @PortalID INT
AS
  BEGIN
      DECLARE @code UNIQUEIDENTIFIER

      --SELECT @code = Newid()
       select @code=(select UserID  FROM   vw_sageframeuser
      WHERE  username = @UserName
             AND portalid = @PortalID)

      INSERT INTO [dbo].[codes]
                  ([code],
                   isalreadyused,
                   [activefrom],
                   [activeto],
                   [codeforpurpose],
                   [codeforusername],
                   [portalid])
      VALUES      (@code,
                   0,
                   GETDATE(),
                   Dateadd(d, 7, GETDATE()),
                   'UserActivation',
                   @UserName,
                   @PortalID)

      SELECT @code     AS [%UserActivationCode%],
             username  AS [%Username%],
             firstname AS [%UserFirstName%],
             lastname  AS [%UserLastName%],
             email     AS [%UserEmail%]
      FROM   vw_sageframeuser
      WHERE  username = @UserName
             AND portalid = @PortalID
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetActivationSuccessfulTokenValue]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- Created Date: 2010-04-27
CREATE PROCEDURE [dbo].[sp_GetActivationSuccessfulTokenValue] @UserName NVARCHAR(
256),
                                                             @PortalID INT
WITH EXECUTE AS caller
AS
  BEGIN
      SELECT userid    AS [%UserActivationCode%],
             username  AS [%Username%],
             firstname AS [%UserFirstName%],
             lastname  AS [%UserLastName%],
             email     AS [%UserEmail%]
      FROM   vw_sageframeuser
      WHERE  username = @UserName
             AND portalid = @PortalID
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPasswordRecoveryTokenValue]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
  
-- Create date: 2010-04-26
-- Description: 
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetPasswordRecoveryTokenValue] 
 @UserName NVARCHAR(256),
 @PortalID NVARCHAR
AS
BEGIN
DECLARE @Code UNIQUEIDENTIFIER
 SELECT @Code=NEWID()
 INSERT INTO [dbo].[Codes]([Code],[ActiveFrom],[ActiveTo],[CodeForPurpose],[CodeForUsername],[PortalID]) VALUES (@code,GETDATE(),DATEADD(d,7,GETDATE()),'PasswordRecovery',@UserName,@PortalID)
SELECT @Code AS [%UserActivationCode%],Username AS [%Username%], FirstName AS [%UserFirstName%], LastName AS [%UserLastName%], Email AS [%UserEmail%]
FROM vw_PortalUsers
WHERE Username=@UserName AND PortalID=@PortalID

END
/****** Object:  StoredProcedure [dbo].[sp_GetPermissionByCodeAndKey]    Script Date: 12/02/2012 12:55:59 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPasswordRecoverySuccessfulTokenValue]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- Created Date: 2010-04-27
CREATE PROCEDURE [dbo].[sp_GetPasswordRecoverySuccessfulTokenValue]
 @UserName [NVARCHAR](256),
 @PortalID [INT]
WITH EXECUTE AS CALLER
AS
BEGIN
SELECT UserId AS [%UserActivationCode%],Username AS [%Username%], FirstName AS [%UserFirstName%], LastName AS [%UserLastName%], Email AS [%UserEmail%]
FROM vw_sageframeuser
WHERE Username=@UserName AND PortalID=@PortalID
END
/****** Object:  StoredProcedure [dbo].[sp_GetPasswordRecoveryTokenValue]    Script Date: 12/02/2012 12:52:57 ******/
SET ANSI_NULLS ON
GO
/****** Object:  Table [dbo].[UserModulePermission]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModulePermission](
	[UserModulePermissionID] [int] IDENTITY(1,1) NOT NULL,
	[UserModuleID] [int] NULL,
	[ModuleDefPermissionID] [int] NULL,
	[AllowAccess] [bit] NULL,
	[RoleID] [uniqueidentifier] NULL,
	[Username] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_ModulePermission] PRIMARY KEY CLUSTERED 
(
	[UserModulePermissionID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[sp_ModuleControlsUpdate]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[sp_ModuleControlsUpdate]
 @ModuleControlID INT,  
 @ControlKey NVARCHAR(50), 
 @ControlTitle NVARCHAR(50), 
 @ControlSrc NVARCHAR(256), 
 @IconFile NVARCHAR(100), 
 @ControlType INT, 
 @DisplayOrder INT, 
 @HelpUrl NVARCHAR(200), 
 @SupportsPartialRendering BIT, 
 @IsActive BIT,  
 @IsModified BIT,  
 @UpdatedOn DATETIME,
 @PortalID INT,  
 @UpdatedBy NVARCHAR(256) 
AS
SET @PortalID = 1

BEGIN
 UPDATE dbo.ModuleControls SET
 [ControlKey] = @ControlKey,
 [ControlTitle] = @ControlTitle,
 [ControlSrc] = @ControlSrc,
 [IconFile] = @IconFile,
 [ControlType] = @ControlType,
 [DisplayOrder] = @DisplayOrder,
 [HelpUrl] = @HelpUrl,
 [SupportsPartialRendering] = @SupportsPartialRendering,
 [IsActive] = @IsActive,
 [IsModified] = @IsModified,
 [UpdatedOn] = @UpdatedOn,
 [PortalID] = @PortalID,
 [UpdatedBy] = @UpdatedBy
WHERE
 [ModuleControlID] = @ModuleControlID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModuleControlsGetByModuleControlID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModuleControlsGetByModuleControlID]
 @ModuleControlID INT
AS
BEGIN
 SELECT
 [ModuleControlID],
 [ModuleDefID],
 [ControlKey],
 [ControlTitle],
 [ControlSrc],
 [IconFile],
 [ControlType],
 [DisplayOrder],
 [HelpUrl],
 [SupportsPartialRendering],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM dbo.ModuleControls
WHERE
 [ModuleControlID] = @ModuleControlID 

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModuleControlsDeleteByModuleControlID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_ModuleControlsDeleteByModuleControlID]
 @ModuleControlID INT,
 @DeletedBy NVARCHAR(256)
AS
BEGIN
 UPDATE dbo.ModuleControls SET
 IsDeleted=1,
 DeletedOn=GETDATE(),
 DeletedBy=@DeletedBy
WHERE
 [ModuleControlID] = @ModuleControlID 

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModuleControlsAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ModuleControlsAdd]
 @ModuleControlID INT OUTPUT,
 @ModuleDefID INT,
 @ControlKey NVARCHAR(50),
 @ControlTitle NVARCHAR(50),
 @ControlSrc NVARCHAR(256),
 @IconFile NVARCHAR(100),
 @ControlType INT,
 @DisplayOrder INT,
 @HelpUrl NVARCHAR(200),
 @SupportsPartialRendering BIT,
 @IsActive BIT,
 @AddedOn DATETIME,
 @PortalID INT,
 @AddedBy NVARCHAR(256)
AS
SET @PortalID = 1

INSERT INTO [dbo].[ModuleControls] (
 [ModuleDefID],
 [ControlKey],
 [ControlTitle],
 [ControlSrc],
 [IconFile],
 [ControlType],
 [DisplayOrder],
 [HelpUrl],
 [SupportsPartialRendering],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @ModuleDefID,
 @ControlKey,
 @ControlTitle,
 @ControlSrc,
 @IconFile,
 @ControlType,
 @DisplayOrder,
 @HelpUrl,
 @SupportsPartialRendering,
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)

SET @ModuleControlID=SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[sp_PackagesGetByPortalID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED BY: DINESH HONA
--CREATED DATE: 2010-03-12
--Modified BY: Dinesh Hona, Milson Munakami
--Modified DAte: 2010-06-27, 2011-01-09
-- [dbo].[sp_PackagesGetByPortalID] 1, ''

CREATE PROCEDURE [dbo].[sp_PackagesGetByPortalID] --1,''
 @PortalID [int],
 @SearchText [nvarchar](4000)
WITH EXECUTE AS CALLER
AS

--Added by shree
declare @tmpResult table
(
    [PackageID] [int] ,
 [PortalID] [int] ,
 [ModuleID] [int] ,
 [Name] [nvarchar](128),
 [FriendlyName] [nvarchar](250),
 [Description] [nvarchar](2000),
 [PackageType] [nvarchar](100) ,
 [Version] [nvarchar](50) ,
 [License] [ntext] ,
 [Manifest] [ntext],
 [Owner] [nvarchar](100),
 [Organization] [nvarchar](100),
 [Url] [nvarchar](250) ,
 [Email] [nvarchar](100),
 [ReleaseNotes] [ntext] ,
 [IsSystemPackage] [bit],
 [IsActive] [bit] ,
 [IsDeleted] [bit],
 [IsModified] [bit],
 [AddedOn] [datetime],
 [UpdatedOn] [datetime],
 [DeletedOn] [datetime],
 [AddedBy] [nvarchar](256),
 [UpdatedBy] [nvarchar](256),
 [DeletedBy] [nvarchar](256),
 [InUse] [int],
 [IsAdmin] [int]
)
--end by shree
INSERT INTO @tmpResult
SELECT 
 [dbo].[Packages].[PackageID],
 [dbo].[Packages].[PortalID],
 [dbo].[Packages].[ModuleID],
 [dbo].[Packages].[Name],
 [dbo].[Packages].[FriendlyName],
 [dbo].[Packages].[Description],
 [dbo].[Packages].[PackageType],
 [dbo].[Packages].[Version],
 [dbo].[Packages].[License],
 [dbo].[Packages].[Manifest],
 [dbo].[Packages].[Owner],
 [dbo].[Packages].[Organization],
 [dbo].[Packages].[Url],
 [dbo].[Packages].[Email],
 [dbo].[Packages].[ReleaseNotes],
 [dbo].[Packages].[IsSystemPackage],
 [dbo].[Packages].[IsActive],
 [dbo].[Packages].[IsDeleted],
 [dbo].[Packages].[IsModified],
 [dbo].[Packages].[AddedOn],
 [dbo].[Packages].[UpdatedOn],
 [dbo].[Packages].[DeletedOn],
 [dbo].[Packages].[AddedBy],
 [dbo].[Packages].[UpdatedBy],
 [dbo].[Packages].[DeletedBy],
 0 AS [InUse],
 [dbo].Modules.IsAdmin --INTO #tmpResult
FROM [dbo].[Packages]
INNER JOIN [dbo].PortalModules ON [dbo].[Packages].ModuleID=[dbo].PortalModules.ModuleID
INNER JOIN [dbo].Modules ON [dbo].Modules.ModuleID=[dbo].[Packages].ModuleID
WHERE 1=2

IF(len(@SearchText)>0)
BEGIN
declare @tbltemp table
(
RowNum int identity(1,1),
SearchText nvarchar(500)
)
insert into @tbltemp(SearchText)
SELECT rtrim(ltrim(items)) FROM split(@SearchText,' ')
DECLARE @KeyCount int, @ValueCount int,@counter int
SELECT @KeyCount=count(RowNum) from @tbltemp


set @counter=1
WHILE(@counter<=@KeyCount or @counter=1)
  BEGIN
 declare @key nvarchar(500)
select @key=SearchText from @tbltemp where RowNum=@counter
print @key
INSERT INTO @tmpResult
SELECT 
 [dbo].[Packages].[PackageID],
 [dbo].[Packages].[PortalID],
 [dbo].[Packages].[ModuleID],
 [dbo].[Packages].[Name],
 [dbo].[Packages].[FriendlyName],
 [dbo].[Packages].[Description],
 [dbo].[Packages].[PackageType],
 [dbo].[Packages].[Version],
 [dbo].[Packages].[License],
 [dbo].[Packages].[Manifest],
 [dbo].[Packages].[Owner],
 [dbo].[Packages].[Organization],
 [dbo].[Packages].[Url],
 [dbo].[Packages].[Email],
 [dbo].[Packages].[ReleaseNotes],
 [dbo].[Packages].[IsSystemPackage],
 [dbo].[Packages].[IsActive],
 [dbo].[Packages].[IsDeleted],
 [dbo].[Packages].[IsModified],
 [dbo].[Packages].[AddedOn],
 [dbo].[Packages].[UpdatedOn],
 [dbo].[Packages].[DeletedOn],
 [dbo].[Packages].[AddedBy],
 [dbo].[Packages].[UpdatedBy],
 [dbo].[Packages].[DeletedBy],
 (SELECT
  CASE 
  WHEN [dbo].[UserModules].ModuleDefID IS NULL THEN 0 ELSE 1
  END
  FROM [dbo].[ModuleDefinitions] 
  LEFT JOIN [dbo].[UserModules] ON [dbo].[UserModules].ModuleDefID = [dbo].ModuleDefinitions.ModuleDefID
  WHERE [dbo].ModuleDefinitions.ModuleID = [dbo].[Packages].ModuleID
  GROUP BY [dbo].[UserModules].ModuleDefID
 )
  AS [InUse],
 [dbo].Modules.IsAdmin
FROM [dbo].[Packages]
INNER JOIN [dbo].PortalModules ON [dbo].[Packages].ModuleID=[dbo].PortalModules.ModuleID
INNER JOIN [dbo].Modules ON [dbo].Modules.ModuleID=[dbo].[Packages].ModuleID
WHERE
 --([dbo].[Packages].PortalID = @PortalID OR @PortalID IS NULL OR [dbo].[Packages].PortalID IS NULL) AND 
([dbo].PortalModules.PortalID = @PortalID )AND
([dbo].[Packages].IsDeleted=0 OR [dbo].[Packages].IsDeleted IS NULL) AND 
[dbo].[Packages].[FriendlyName] LIKE @key+'%'
ORDER BY PackageType ASC, [FriendlyName] ASC
set @counter=@counter+1
  END

END
ELSE
BEGIN

INSERT INTO @tmpResult
SELECT 
 [dbo].[Packages].[PackageID],
 [dbo].[Packages].[PortalID],
 [dbo].[Packages].[ModuleID],
 [dbo].[Packages].[Name],
 [dbo].[Packages].[FriendlyName],
 [dbo].[Packages].[Description],
 [dbo].[Packages].[PackageType],
 [dbo].[Packages].[Version],
 [dbo].[Packages].[License],
 [dbo].[Packages].[Manifest],
 [dbo].[Packages].[Owner],
 [dbo].[Packages].[Organization],
 [dbo].[Packages].[Url],
 [dbo].[Packages].[Email],
 [dbo].[Packages].[ReleaseNotes],
 [dbo].[Packages].[IsSystemPackage],
 [dbo].[Packages].[IsActive],
 [dbo].[Packages].[IsDeleted],
 [dbo].[Packages].[IsModified],
 [dbo].[Packages].[AddedOn],
 [dbo].[Packages].[UpdatedOn],
 [dbo].[Packages].[DeletedOn],
 [dbo].[Packages].[AddedBy],
 [dbo].[Packages].[UpdatedBy],
 [dbo].[Packages].[DeletedBy],
 (SELECT
  CASE 
  WHEN [dbo].[UserModules].ModuleDefID IS NULL THEN 0 ELSE 1
  END
  FROM [dbo].[ModuleDefinitions] 
  LEFT JOIN [dbo].[UserModules] ON [dbo].[UserModules].ModuleDefID = [dbo].ModuleDefinitions.ModuleDefID
  WHERE [dbo].ModuleDefinitions.ModuleID = [dbo].[Packages].ModuleID
  GROUP BY [dbo].[UserModules].ModuleDefID
 )
  AS [InUse],
 [dbo].Modules.IsAdmin
FROM [dbo].[Packages]
INNER JOIN [dbo].PortalModules ON [dbo].[Packages].ModuleID=[dbo].PortalModules.ModuleID
INNER JOIN [dbo].Modules ON [dbo].Modules.ModuleID=[dbo].[Packages].ModuleID
WHERE
 --([dbo].[Packages].PortalID = @PortalID OR @PortalID IS NULL OR [dbo].[Packages].PortalID IS NULL) AND 
([dbo].PortalModules.PortalID = @PortalID )AND
([dbo].[Packages].IsDeleted=0 OR [dbo].[Packages].IsDeleted IS NULL) AND 
[dbo].[Packages].[FriendlyName] LIKE @SearchText+'%'
ORDER BY PackageType ASC, [FriendlyName] ASC
END

SELECT * FROM @tmpResult
GO
/****** Object:  StoredProcedure [dbo].[sp_ModuleDefPermissionAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_ModuleDefPermissionAdd] @ModuleDefPermissionID INT = NULL OUTPUT
 ,@ModuleDefID INT
 ,@PortalModuleID INT
 ,@PermissionID INT
 ,@IsActive BIT
 ,@AddedOn DATETIME
 ,@PortalID INT
 ,@AddedBy NVARCHAR(256)
AS
BEGIN
 INSERT INTO dbo.ModuleDefPermission (
  [ModuleDefID]
  ,[PermissionID]
  ,[IsActive]
  ,[AddedOn]
  ,[PortalID]
  ,[AddedBy]
  )
 VALUES (
  @ModuleDefID
  ,@PermissionID
  ,@IsActive
  ,@AddedOn
  ,@PortalID
  ,@AddedBy
  )

 SET @ModuleDefPermissionID = SCOPE_IDENTITY()

 DECLARE @tblRoleIDs TABLE (tRoleID UNIQUEIDENTIFIER)

 INSERT INTO @tblRoleIDs (tRoleID)
 SELECT RoleId
 FROM dbo.aspnet_Roles
 WHERE RoleName = 'site admin'
  OR RoleName = 'super user'

 INSERT INTO dbo.PortalModulePermission (
  [PortalModuleID]
  ,[ModuleDefPermissionID]
  ,[AllowAccess]
  ,[RoleID]
  ,[Username]
  ,[IsActive]
  ,[AddedOn]
  ,[AddedBy]
  )
 SELECT @PortalModuleID
  ,@ModuleDefPermissionID
  ,1
  ,tRoleID
  ,@AddedBy
  ,@IsActive
  ,@AddedOn
  ,@AddedBy
 FROM @tblRoleIDs
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesPermissionAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_ModulesPermissionAdd]
 @ModuleDefPermissionID int=NULL output,
 @PortalModulePermissionID int output,
 @ModuleDefID int,
 @PermissionID int,
 @PortalID int, 
 @PortalModuleID int,
 @AllowAccess bit,
 @UserName nvarchar(256),
 @IsActive bit,
 @AddedOn datetime,
 @AddedBy nvarchar(256)
 
AS

SET @PortalID=1

BEGIN
 INSERT INTO dbo.ModuleDefPermission (
 [ModuleDefID],
 [PermissionID],
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @ModuleDefID,
 @PermissionID,
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)
SET @ModuleDefPermissionID = SCOPE_IDENTITY()

DECLARE @tblRoleIDs table (tRoleID uniqueidentifier)
INSERT INTO @tblRoleIDs (tRoleID)
SELECT RoleId
FROM dbo.aspnet_Roles 
WHERE RoleName='site admin' or RoleName = 'super user' 


INSERT INTO dbo.PortalModulePermission(
 [PortalModuleID],
 [ModuleDefPermissionID],
 [AllowAccess],
 [RoleID],
 [Username],
 [IsActive],
 [AddedOn],
 [AddedBy]) 
SELECT 
 @PortalModuleID,
 @ModuleDefPermissionID,
 @AllowAccess,
 tRoleID,
 @UserName,
 @IsActive,
 @AddedOn,
 @AddedBy
FROM @tblRoleIDs
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RoleGetByUsername]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-03-24
CREATE PROCEDURE [dbo].[sp_RoleGetByUsername]
 @UserName NVARCHAR(256),
 @PortalID INT
AS

BEGIN
 IF(EXISTS(
    SELECT * FROM dbo.vw_SageFrameUser sfu 
    INNER JOIN  
     aspnet_UsersInRoles AS uir ON uir.UserId=sfu.UserId
    INNER JOIN 
     aspnet_Roles AS r ON r.RoleId = uir.RoleId 
    WHERE 
     (r.RoleName='Super User' OR PortalID=@PortalID) 
     AND Username = @UserName 
     AND IsActive=1 
     AND (IsDeleted=0 OR IsDeleted IS NULL)
   ))
  BEGIN
   SELECT DISTINCT r.RoleId FROM dbo.aspnet_Roles r
   INNER JOIN
    dbo.aspnet_UsersInRoles ur on r.roleid=ur.roleid
   INNER JOIN
    dbo.aspnet_Users u ON u.UserId=ur.UserId
   WHERE 
    u.Username = @UserName
  END
 ELSE
  BEGIN
   SELECT DISTINCT r.RoleId FROM dbo.aspnet_Roles r  
   WHERE 
    1=2
  END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalAdd]
 @PortalName NVARCHAR(200),
 @IsParent BIT,
 @TemplateName NVARCHAR(250),
 @UserName NVARCHAR(256),
 
 @PortalParentID INT,
 @PSEOName NVARCHAR(256)
AS
BEGIN
 DECLARE @PortalSEOName NVARCHAR(100), @PortalID INT,@SuperUserID UNIQUEIDENTIFIER
 SELECT @SuperUserID=UserId FROM [dbo].[Aspnet_Users] 
 WHERE LoweredUserName='superuser'
 
 IF(@PSEOName ='')
 SET @PortalSEOName=LOWER(LTRIM(RTRIM(REPLACE(@PortalName,' ','_'))))
 ELSE
 SET @PortalSEOName=@PSEOName
 
 IF(EXISTS(SELECT * FROM dbo.Portal WHERE [SEOName]=@PortalSEOName and IsParent=0))
 BEGIN
  RAISERROR('Portal Already Exist!', 16, 1)
 END
 ELSE
 BEGIN
  INSERT INTO [dbo].[Portal]
      ([Name]
      ,[SEOName]
      ,[IsParent]
      ,[ParentID])
   VALUES
      (@PortalName
      ,@PortalSEOName
      ,@IsParent
      ,@PortalParentID)
  
  SET @PortalID=@@IDENTITY;
  INSERT INTO PageMenu ( PageID, PortalID, IsAdmin, IsFooter,ShowInMenu )
       ( SELECT  PageID, @PortalID ,IsAdmin,IsFooter,ShowInMenu FROM    PageMenu WHERE   PageMenu.PortalID = 1 AND IsAdmin=1)
  --EXEC dbo.usp_PortalUsersAdd @SuperUserID,'superuser','superuser','superuser','info@sageframe.com',1,null,@PortalID,'superuser'
  ----Search Table Update
  INSERT INTO [SageFrameSearchProcedure]
           ([SageFrameSearchTitle]
           ,[SageFrameSearchProcedureName]
           ,[SageFrameSearchProcedureExecuteAs]
           ,[IsActive]
           ,[IsDeleted]
           ,[IsModified]
           ,[AddedOn]
           ,[UpdatedOn]
           ,[DeletedOn]
           ,[PortalID]
           ,[AddedBy]
           ,[UpdatedBy]
           ,[DeletedBy])
     (SELECT[SageFrameSearchTitle]
           ,[SageFrameSearchProcedureName]
           ,[SageFrameSearchProcedureExecuteAs]
           ,[IsActive]
           ,[IsDeleted]
           ,[IsModified]
           ,[AddedOn]
           ,[UpdatedOn]
           ,[DeletedOn]
           ,@PortalID
           ,[AddedBy]
           ,[UpdatedBy]
           ,[DeletedBy] from [SageFrameSearchProcedure]
           WHERE   [SageFrameSearchProcedure].[PortalID] = 1)
           
  EXEC [dbo].[usp_sftemplate_activate] @TemplateName,1,@PortalID
    
  INSERT INTO dbo.SettingValue(SettingType,SettingKey,SettingValue,
  SettingTypeID,IsActive,AddedOn,AddedBy,IsCacheable)
  Select SettingType,SettingKey,SettingValue,@PortalID,1,GetDATE(),
  @UserName,IsCacheable FROM dbo.SettingKey WHERE SettingType='SiteAdmin'
  
  DECLARE @ModuleID INT,@PortalModuleID INT,@ModuleIsActive BIT
  DECLARE CurModule CURSOR FOR
  SELECT ModuleID,IsActive FROM [dbo].[Modules] WHERE IsRequired=1 
  AND (IsDeleted=0 OR IsDeleted IS NULL)
  OPEN CurModule   
  FETCH NEXT FROM CurModule INTO @ModuleID,@ModuleIsActive
  WHILE @@FETCH_STATUS=0
  BEGIN
   INSERT INTO [dbo].[PortalModules]
      ([PortalID]
      ,[ModuleID]
      ,[IsActive]
      ,[AddedOn]
      ,[AddedBy])
   VALUES(@PortalID,@ModuleID,@ModuleIsActive,GETDATE(),@UserName)
   SET @PortalModuleID=@@IDENTITY 
   
   DECLARE @RoleID UNIQUEIDENTIFIER
   SELECT @RoleID=RoleId FROM [dbo].Aspnet_roles WHERE RoleName='super user'
   INSERT INTO [dbo].[PortalModulePermission]
         ([PortalModuleID]
         ,[ModuleDefPermissionID]
         ,[AllowAccess]
         ,[RoleID]
         ,[Username]
         ,[IsActive]
         ,[AddedOn]
         ,[AddedBy])
   SELECT @PortalModuleID,ModuleDefPermissionID,1,@RoleID,NULL,1,GETDATE(),@UserName 
   FROM ModuleDefinitions MD INNER JOIN ModuleDefPermission MDP 
   ON MD.ModuleDefID=MDP.ModuleDefID WHERE MD.ModuleID=@ModuleID AND
   (MDP.IsDeleted=0 OR MDP.IsDeleted IS NULL)
   
   SELECT @RoleID=RoleId FROM [dbo].aspnet_roles WHERE RoleName='site admin'
   INSERT INTO [dbo].[PortalModulePermission]
         ([PortalModuleID]
         ,[ModuleDefPermissionID]
         ,[AllowAccess]
         ,[RoleID]
         ,[Username]
         ,[IsActive]
         ,[AddedOn]
         ,[AddedBy])
   SELECT @PortalModuleID,ModuleDefPermissionID,1,@RoleID,NULL,1,GETDATE(),@UserName 
   FROM ModuleDefinitions MD INNER JOIN ModuleDefPermission MDP 
   ON MD.ModuleDefID=MDP.ModuleDefID WHERE MD.ModuleID=@ModuleID AND 
   (MDP.IsDeleted=0 OR MDP.IsDeleted IS NULL)
   FETCH NEXT FROM CurModule INTO @ModuleID,@ModuleIsActive
  END
  CLOSE CurModule
  DEALLOCATE CurModule

  DECLARE @Name VARCHAR(40),@PageID INT,@NewPageID INT, @PageOrder INT
      ,@PageName NVARCHAR(100)
      ,@IsVisible BIT
      ,@ParentID INT
      ,@Level INT
      ,@IconFile NVARCHAR(100)
      ,@DisableLink BIT
      ,@Title NVARCHAR(200)
      ,@Description NVARCHAR(500)
      ,@KeyWords NVARCHAR(500)
      ,@Url NVARCHAR(255)
      ,@TabPath NVARCHAR(255)
      ,@StartDate DATETIME
      ,@EndDate DATETIME
      ,@RefreshInterval DECIMAL(16,2)
      ,@PageHeadText NVARCHAR(500)
      ,@IsSecure BIT
      ,@IsActive BIT
      ,@SEOName NVARCHAR(100)
      ,@IsShowInFooter BIT
      ,@IsRequiredPage BIT
      
  SELECT PageID,PageOrder,PageName,IsVisible,ParentID,[Level],IconFile,DisableLink,
  Title,Description,KeyWords,Url,TabPath ,StartDate,EndDate ,RefreshInterval,
  PageHeadText,IsSecure,IsActive,SEOName,IsShowInFooter,IsRequiredPage 
  
  INTO #tblReqPages FROM dbo.Pages WHERE IsRequiredPage=1 AND 
  (IsDeleted=0 OR IsDeleted IS NULL) AND PortalID=1
  
  DECLARE CurReqPages CURSOR FOR 
  SELECT PageID,PageOrder,PageName,IsVisible,ParentID,[Level],IconFile,DisableLink,Title,
  Description,KeyWords,Url,TabPath ,StartDate,EndDate ,RefreshInterval,PageHeadText,
  IsSecure,IsActive,SEOName,IsShowInFooter,IsRequiredPage FROM #tblReqPages
  
  OPEN CurReqPages
  
  FETCH NEXT FROM CurReqPages INTO @PageID,@PageOrder,@PageName,@IsVisible,@ParentID,
  @Level,@IconFile,@DisableLink,@Title,@Description,@KeyWords,@Url,@TabPath ,
  @StartDate,@EndDate ,@RefreshInterval,@PageHeadText,@IsSecure,@IsActive,@SEOName,
  @IsShowInFooter,@IsRequiredPage
  
  WHILE @@FETCH_STATUS = 0  
  BEGIN
    INSERT INTO [dbo].[Pages](PageOrder,PageName,IsVisible,ParentID,[Level],IconFile,
    DisableLink,Title,Description,KeyWords,Url,TabPath ,StartDate,EndDate ,
    RefreshInterval,PageHeadText,IsSecure,IsActive,SEOName,IsShowInFooter,
    IsRequiredPage,PortalID,AddedOn,AddedBy)
        VALUES(@PageOrder,@PageName,@IsVisible,@ParentID,@Level,@IconFile,
        @DisableLink,@Title,@Description,@KeyWords,@Url,@TabPath ,@StartDate,
        @EndDate ,@RefreshInterval,@PageHeadText,@IsSecure,@IsActive,
        @SEOName,@IsShowInFooter,1,@PortalID,GETDATE(),@UserName)
    SET @NewPageID=@@IDENTITY

   INSERT INTO PagePreview (
   PageID
   ,PreviewCode
   )
   VALUES (
   @NewPageID
   ,convert(NVARCHAR(256), NEWID())
   )



    --add to pagemenu
    --IF @PageID=1
    --BEGIN
    --EXECUTE [dbo].[usp_PageMenuAdd] @NewPageID,@PortalID,0,@IsShowInFooter
    --END
    --ELSE
    --BEGIN
    EXECUTE [dbo].[usp_PageMenuAdd] @NewPageID,@PortalID,0,@IsShowInFooter
    --END
    INSERT INTO [dbo].[PagePermission]
          ([PageID]
          ,[PermissionID]
          ,[AllowAccess]
          ,[RoleID]
          ,[Username]
          ,[IsActive]
          ,[AddedOn]
          ,[PortalID]
          ,[AddedBy])
    SELECT @NewPageID,[PermissionID]
          ,[AllowAccess]
          ,[RoleID]
          ,[Username],[IsActive],GETDATE(),@PortalID,@UserName 
          FROM PagePermission WHERE PageID=@PageID
   
  FETCH NEXT FROM CurReqPages INTO 
    @PageID,@PageOrder,@PageName,@IsVisible,@ParentID,@Level,@IconFile,
    @DisableLink,@Title,@Description,@KeyWords,@Url,@TabPath ,@StartDate,@EndDate ,
    @RefreshInterval,@PageHeadText,@IsSecure,@IsActive,@SEOName,@IsShowInFooter,
    @IsRequiredPage
  END
  CLOSE CurReqPages
  DEALLOCATE CurReqPages
 
  --INSERT INTO PageMenu Values(select PageID From PageMenu where PortalID=1 and IsAdmin = 1 , @PortalID, 1, 0,1)
 


  DECLARE @MessageTemplateTypeID INT, @NewMessageTemplateTypeID INT 
  DECLARE @MessageTemplateTypeName NVARCHAR(200), @MessageTemplateTypeIsActive BIT
  DECLARE CurMessageTemplateType CURSOR FOR 
  SELECT MessageTemplateTypeID,[Name],[IsActive] FROM [MessageTemplateType] 
  WHERE PortalID=1 AND (IsDeleted=0 OR IsDeleted IS NULL)
  OPEN CurMessageTemplateType
  FETCH NEXT FROM CurMessageTemplateType INTO @MessageTemplateTypeID,@MessageTemplateTypeName,
  @MessageTemplateTypeIsActive 
  WHILE @@FETCH_STATUS = 0  
  BEGIN
   INSERT INTO [dbo].[MessageTemplateType]([Name] ,[IsActive] ,[AddedOn],[PortalID] ,
   [AddedBy])
   VALUES( @MessageTemplateTypeName,@MessageTemplateTypeIsActive,GETDATE() ,@PortalID ,@UserName)
   SET @NewMessageTemplateTypeID=@@IDENTITY   
   INSERT INTO [dbo].[MessageTemplateTypeToken]([MessageTemplateTypeID],[MessageTokenID],[IsActive],[AddedOn],[PortalID],[AddedBy])
   SELECT @NewMessageTemplateTypeID ,[MessageTokenID] ,[IsActive] ,GETDATE() ,@PortalID ,@UserName FROM [dbo].[MessageTemplateTypeToken] 
   WHERE MessageTemplateTypeID=@MessageTemplateTypeID AND (IsDeleted=0 OR IsDeleted IS NULL)

   INSERT INTO [dbo].[MessageTemplate]([MessageTemplateTypeID],[Subject] ,[Body] ,[MailFrom], Culture, [IsActive] ,[AddedOn],[PortalID],[AddedBy])
   SELECT @NewMessageTemplateTypeID,[Subject],[Body],[MailFrom], 'en-US', [IsActive],GETDATE(),@PortalID,@UserName FROM [dbo].[MessageTemplate] 
   WHERE MessageTemplateTypeID=@MessageTemplateTypeID AND (IsDeleted=0 OR IsDeleted IS NULL)

   INSERT INTO [dbo].[MessageTemplateTypeMap]([MessageTemplateTypeID],[PortalSpecID],[PortalID])
   SELECT @MessageTemplateTypeID,@NewMessageTemplateTypeID,@PortalID 
   FETCH NEXT FROM CurMessageTemplateType INTO @MessageTemplateTypeID,@MessageTemplateTypeName,@MessageTemplateTypeIsActive    
  END
  CLOSE CurMessageTemplateType
  DEALLOCATE CurMessageTemplateType
 END
 ---User Agent
 INSERT INTO UserAgent(AgentMode,PortalID,ChangedBy,ChangedDate,IsActive) VALUES('3',@PortalID,@UserName,GETDATE(),1)

END
GO
/****** Object:  Table [dbo].[PageModules]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PageModules](
	[PageModuleID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NULL,
	[UserModuleID] [int] NULL,
	[PaneName] [nvarchar](50) NULL,
	[ModuleOrder] [int] NULL,
	[CacheTime] [int] NULL,
	[Alignment] [nvarchar](50) NULL,
	[Color] [nvarchar](20) NULL,
	[Border] [nvarchar](1) NULL,
	[IconFile] [nvarchar](100) NULL,
	[Visibility] [int] NULL,
	[DisplayTitle] [bit] NULL,
	[DisplayPrint] [bit] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[IsModified] [bit] NULL,
	[AddedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[DeletedOn] [datetime] NULL,
	[PortalID] [int] NULL,
	[AddedBy] [nvarchar](256) NULL,
	[UpdatedBy] [nvarchar](256) NULL,
	[DeletedBy] [nvarchar](256) NULL,
 CONSTRAINT [PK_TabModule] PRIMARY KEY CLUSTERED 
(
	[PageModuleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[usp_Template_PageIDUpdates]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Template_PageIDUpdates] (
 @pageID NVARCHAR(MAX)
 ,@parentID NVARCHAR(MAX)
 ,@userModuleID NVARCHAR(MAX)
 ,@ShowInAllPages NVARCHAR(MAX)
 )
AS
BEGIN
 CREATE TABLE #TblPageID (
  RowNum INT IDENTITY(1, 1)
  ,PageID INT
  )

 INSERT INTO #TblPageID
 SELECT *
 FROM dbo.Split(@pageID, ',')

 CREATE TABLE #TblParentID (
  RowNum INT IDENTITY(1, 1)
  ,ParentID INT
  )

 INSERT INTO #TblParentID
 SELECT *
 FROM dbo.Split(@parentID, ',')

 DECLARE @COUNT INT
  ,@Counter INT

 SET @Counter = (
   SELECT COUNT(*)
   FROM #TblPageID
   )
 SET @COUNT = 1

 WHILE (@COUNT <= @Counter)
 BEGIN
  DECLARE @PageID_ INT
  DECLARE @ParentID_ INT

  SET @PageID_ = (
    SELECT PageID
    FROM #TblPageID
    WHERE RowNum = @COUNT
    )
  SET @ParentID_ = (
    SELECT ParentID
    FROM #TblParentID
    WHERE RowNum = @COUNT
    )

  UPDATE Pages
  SET ParentID = @ParentID_
  WHERE PageID = @PageID_

  SET @COUNT = @COUNT + 1
 END

 CREATE TABLE #TbluserModeleID (
  RowNum INT IDENTITY(1, 1)
  ,UserModuleID INT
  )

 INSERT INTO #TbluserModeleID
 SELECT *
 FROM dbo.Split(@userModuleID, ':')

 CREATE TABLE #TblshowInAllPages (
  RowNum INT IDENTITY(1, 1)
  ,ShowInAllPages VARCHAR(100)
  )

 INSERT INTO #TblshowInAllPages
 SELECT *
 FROM dbo.Split(@ShowInAllPages, ':')

 DECLARE @Count2 INT
  ,@Counter2 INT

 SET @Counter2 = (
   SELECT COUNT(*)
   FROM #TbluserModeleID
   )
 SET @Count2 = 1

 WHILE (@Count2 <= @Counter2)
 BEGIN
  DECLARE @UserModuleID_ INT
  DECLARE @ShowInAllPages_ VARCHAR(100)

  SET @UserModuleID_ = (
    SELECT UserModuleID
    FROM #TbluserModeleID
    WHERE RowNum = @Count2
    )
  SET @ShowInAllPages_ = (
    SELECT ShowInAllPages
    FROM #TblshowInAllPages
    WHERE RowNum = @Count2
    )

  UPDATE UserModules
  SET ShowInPages = @ShowInAllPages_
  WHERE UserModuleID = @UserModuleID_

  SET @Count2 = @Count2 + 1
 END

 DROP TABLE #TblPageID

 DROP TABLE #TblParentID

 DROP TABLE #TbluserModeleID

 DROP TABLE #TblshowInAllPages
END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoleNamesGetByUserName]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RoleNamesGetByUserName]
(
 @UserName NVARCHAR(256), 
 @PortalID INT
) 
AS 
  BEGIN 
   DECLARE @RoleName NVARCHAR(4000)
      SELECT @RoleName = COALESCE(@RoleName + ',', '') + rolename 
      FROM  dbo.vw_PortalUsers sfu 
           INNER JOIN aspnet_UsersInRoles AS uir 
           ON uir.UserId = sfu.UserId 
           INNER JOIN aspnet_Roles AS r 
           ON r.RoleId = uir.RoleId 
      WHERE  ( r.RoleName = 'Super User' 
                OR PortalID = @PortalID ) 
             AND UserName = @UserName 
   SELECT @RoleName AS RoleName
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_TemplateGetList]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-06-28

CREATE PROCEDURE [dbo].[sp_TemplateGetList]
 @PortalID INT,
 @UserName NVARCHAR(256)
AS
DECLARE @HasHostRole BIT
SET @HasHostRole=0
IF(EXISTS(
  SELECT * 
  FROM aspnet_usersinroles AS uir 
  INNER JOIN aspnet_Roles as r ON r.RoleId = uir.RoleId 
  WHERE r.RoleName='Super User' 
  AND userid IN (
      SELECT userid 
      FROM dbo.vw_SageFrameUser 
      WHERE 
       Username=@UserName 
      AND IsActive=1 
      AND (IsDeleted=0 OR IsDeleted IS NULL)
     )
  ))
 BEGIN
  SET @HasHostRole=1
 END
IF @HasHostRole=1
 BEGIN
  SELECT 
    [TemplateID]
   ,[TemplateTitle]
   ,[PortalID]
   ,[Author]
   ,[Description]
   ,[AuthorURL]   
   ,[AddedOn]
   ,[AddedBy]
    FROM 
   [dbo].[Template]
 END
ELSE
 BEGIN
  SELECT 
    [TemplateID]
   ,[TemplateTitle]
   ,[PortalID]
   ,[Author]
   ,[Description] 
   ,[AuthorURL]
   ,[AddedOn]
   ,[AddedBy]
  FROM 
   [dbo].[Template] 
  WHERE 
    PortalID=@PortalID 
   OR (LOWER([TemplateTitle])='default')
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_ChangeUserInRoles]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ChangeUserInRoles]
(
 @ApplicationName NVARCHAR(120),
 @UserID UNIQUEIDENTIFIER, 
 @RoleNamesUnselected NVARCHAR(4000),
 @RoleNamesSelected NVARCHAR(4000),
 @PortalID INT
)
AS
 BEGIN
 DECLARE @ErrorCode INT
 SET @ErrorCode=0
  EXEC [dbo].[usp_sf_UserInRolesDelete] @ApplicationName,@UserID,@RoleNamesUnselected,@PortalID,@ErrorCode output;
  EXEC [dbo].[usp_sf_UserInRolesAdd] @ApplicationName,@UserID,@RoleNamesSelected,@PortalID; 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DashBoardPageModuleStatistics]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DashBoardPageModuleStatistics] --1,0
(
 @PortalID INT,
 @IsAdmin BIT=NULL
)
AS
BEGIN
 DECLARE @Tbltemp TABLE ( 
    [Users] NVARCHAR(256), 
    cnt     INT 
   ) 

 INSERT INTO @Tbltemp 
 SELECT 'AnonymousUser', 
     COUNT(*) 
   FROM   SessionTracker 
   WHERE  username = 'anonymoususer' 
   AND [end] IS NULL 
 UNION ALL 
 SELECT 'LoginUser', 
     COUNT(*) 
   FROM   SessionTracker 
   WHERE  username NOT IN ( 'anonymoususer' ) 
   AND [end] IS NULL
 UNION ALL 
 SELECT 'PageCount', 
    count(*)
    FROM   Pages p 
        INNER JOIN pagemenu pm 
       ON p.pageid = pm.pageid 
    WHERE  pm.portalid = @PortalID 
        AND pm.isadmin = 0   
 AND (p.IsDeleted=0 OR p.IsDeleted IS NULL)
      and p.IsVisible=1        
 UNION ALL 
 SELECT 'UserCount', 
   Count(*) from [dbo].[vw_portalusers]
    WHERE portalid=@portalid or UserId in (SELECT au.UserId  FROM PortalUser P1 INNER JOIN aspnet_usersinroles au
ON P1.UserID=AU.UserId INNER JOIN aspnet_roles AR ON AR.RoleId=AU.RoleId AND AR.RoleName='Super User' AND p1.IsActive=1 AND (p1.IsDeleted =0 OR p1.ISDeleted IS NULL ))
     
 SELECT * 
 FROM  (SELECT cnt, [Users]     
   FROM   @Tbltemp)p PIVOT ( MAX(cnt) FOR [Users]
    IN ([AnonymousUser],[LoginUser],[PageCount],[UserCount]) ) AS pivottable 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DashBoardView]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DashBoardView] @PageSEOName NVARCHAR(256),
                                         @UserName    [NVARCHAR](256),
                                         @PortalID    INT
AS
  BEGIN
      DECLARE @RoleId UNIQUEIDENTIFIER
SET @RoleId=(
      --changed by sushil
      select Top 1 ar.RoleId from aspnet_Roles ar inner join
   aspnet_UsersInRoles ur on ar.RoleId=ur.RoleId
   inner join PortalUser pu on pu.UserID=ur.UserId
     where Username=@UserName and PortalID=@PortalID and (ar.RoleName='Super User' or ar.RoleName='site admin')
      )

      DECLARE @roleName NVARCHAR(256)

      SET @roleName=(SELECT rolename
                     FROM   aspnet_roles
                     WHERE  roleid = @RoleId)

      DECLARE @PortalSEOName   NVARCHAR(200),
              @IsParentPortal  BIT,
              @UseFriendlyUrls NVARCHAR(256),
              @PortalPrefix    NVARCHAR(200)

      SELECT @PortalSEOName = Ltrim(Rtrim(seoname)),
             @IsParentPortal = isparent
      FROM   dbo.portal
      WHERE  portalid = @PortalID

      SET @PortalPrefix=''

      IF( NOT( @IsParentPortal = 1 ) )
        BEGIN
            SET @PortalPrefix='/portal/' + @PortalSEOName
        END

      DECLARE @IsInRole INT

      SELECT @IsInRole = dbo.Fn_isuserinrole(@UserName, 'Super User', @PortalID)

      IF @IsInRole = 1
          OR @roleName = 'Super User'
        BEGIN
            SELECT P1.pageid,
                   P1.pageorder,
                   P1.pagename,
                   P1.isvisible,
                   P1.parentid,
                   P1.[level],
                   P1.iconfile,
                   P1.title,
                   P1.[description],
                   P1.keywords,
                   '~' + @PortalPrefix + P1.tabpath AS Url,
                   P1.tabpath
            FROM   [dbo].[pages] AS P1
                   INNER JOIN [dbo].[pages] AS P2
                           ON P1.parentid = P2.pageid
            WHERE  P2.seoname = @PageSEOName
                   AND ( ( P1.[isdeleted] = 0
                            OR P1.[isdeleted] IS NULL )
                         AND ( P1.portalid = @PortalID
                                OR P1.portalid = -1 )
                         AND P1.isvisible = 1 )
            UNION
            SELECT P1.pageid,
                   P1.pageorder,
                   P1.pagename,
                   P1.isvisible,
                   P1.parentid,
                   P1.[level],
                   P1.iconfile,
                   P1.title,
                   P1.[description],
                   P1.keywords,
                   '~' + @PortalPrefix + P1.tabpath AS Url,
                   P1.tabpath
            FROM   [dbo].[pages] AS P1
                   INNER JOIN [dbo].[pages] AS P2
                           ON P1.parentid = P2.pageid
            WHERE  P2.seoname = 'super-user'
                   AND ( ( P1.[isdeleted] = 0
                            OR P1.[isdeleted] IS NULL )
                         AND ( P1.portalid = @PortalID
                                OR P1.portalid = -1 )
                         AND P1.isvisible = 1 )
            ORDER  BY p1.pageorder
        END
      ELSE
        BEGIN
            SELECT DISTINCT P1.pageid,
                   P1.pageorder,
                   P1.pagename,
                   P1.isvisible,
                   P1.parentid,
                   P1.[level],
                   P1.iconfile,
                   P1.title,
                   P1.[description],
                   P1.keywords,
                   '~' + @PortalPrefix + P1.tabpath AS Url,
                   P1.tabpath
            FROM   [dbo].[pages] AS P1
                   INNER JOIN [dbo].[pages] AS P2
                           ON P1.parentid = P2.pageid
                   INNER JOIN dbo.pagepermission pp
                           ON P1.pageid = pp.pageid
                              AND pp.roleid = @RoleId
                              AND permissionid = 1
            WHERE  P2.seoname = @PageSEOName
                   AND ( ( P1.[isdeleted] = 0
                            OR P1.[isdeleted] IS NULL )
                         AND ( P1.portalid = @PortalID
                                OR P1.portalid = -1 )
                         AND P1.isvisible = 1 )
            ORDER  BY P1.pageorder
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUnquieModuleControlsControlType]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2011-1-17
-- Description:  Check Unique ControlType -- only one type of control can EXISTS for one module
-- =============================================
CREATE PROCEDURE [dbo].[sp_CheckUnquieModuleControlsControlType] 
  @ModuleControlID INT,
        @ModuleDefID INT,                                  
  @ControlType INT,
  @PortalID     INT,                                                         
    @isEdit BIT,   
    @COUNT INT output
AS
  BEGIN
      SET @COUNT = 0

      IF @isEdit = 1
        BEGIN
            SELECT @ModuleDefID = moduledefid
            FROM   dbo.modulecontrols
            WHERE  modulecontrolid = @ModuleControlID
                   AND portalid = @PortalID
                   AND ( isdeleted = 0
                          OR isdeleted IS NULL )

            SELECT @COUNT = ISNULL(COUNT(modulecontrolid), 0)
            FROM   dbo.modulecontrols
            WHERE  controltype = @ControlType
                   AND modulecontrolid <> @ModuleControlID
                   AND moduledefid = @ModuleDefID
                   AND portalid = @PortalID
                   AND ( isdeleted = 0
                          OR isdeleted IS NULL )
        END
      ELSE
        BEGIN
            SELECT @COUNT = ISNULL(COUNT(modulecontrolid), 0)
            FROM   dbo.modulecontrols
            WHERE  controltype = @ControlType
                   AND moduledefid = @ModuleDefID
                   AND portalid = @PortalID
                   AND ( isdeleted = 0
                          OR isdeleted IS NULL )
        END

      PRINT @COUNT
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_AdSenseSettingsGetByUserModuleID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-04-18
-- Description:  Adsense Settings
-- =============================================  
CREATE PROCEDURE [dbo].[sp_AdSenseSettingsGetByUserModuleID] 
 @UserModuleID INT,
    @PortalID     INT
AS
  BEGIN
      SELECT *
      FROM   dbo.usermodulesettings
      WHERE  usermoduleid = @UserModuleID
             AND portalid = @PortalID
             AND ( isdeleted IS NULL
                    OR isdeleted = 0 )
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_AdSenseSettingsCount]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-04-18
-- Description:  GoogleAdsense Settings
-- =============================================  
CREATE PROCEDURE [dbo].[sp_AdSenseSettingsCount] @UserModuleID    INT,
                                                @PortalID        INT,
                                                @UserModuleCount INT output
AS
  BEGIN
      SELECT @UserModuleCount = COUNT(usermoduleid)
      FROM   dbo.usermodulesettings
      WHERE  usermoduleid = @UserModuleID
             AND portalid = @PortalID
             AND ( isdeleted IS NULL
                    OR isdeleted = 0 )
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_AdSenseDelete]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-04-19
-- Description:  GoogleAdsense Settings
-- Modified date: 2010-05-25
-- =============================================  
CREATE PROCEDURE [dbo].[sp_AdSenseDelete] @UserModuleID INT,
                                         @PortalID     INT
AS
  BEGIN
      DELETE dbo.usermodulesettings
      WHERE  portalid = @PortalID
             AND usermoduleid = @UserModuleID
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_AdSenseCount]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AdSenseCount] @UserModuleID    INT,
                                        @PortalID        INT,
                                        @UserModuleCount [INT] output
WITH EXECUTE AS caller
AS
  BEGIN
      DECLARE @AdsenseShow NVARCHAR(256)

      SELECT @AdsenseShow = settingvalue
      FROM   usermodulesettings
      WHERE  settingname = 'AdsenseShow'
             AND portalid = @PortalID
             AND usermoduleid = @UserModuleID
             AND ( isdeleted IS NULL
                    OR isdeleted = 0 )
             AND isactive = 1

      IF( UPPER(@AdsenseShow) = 'TRUE' )
        BEGIN
            SELECT @UserModuleCount = COUNT(usermoduleid)
            FROM   dbo.usermodulesettings
            WHERE  usermoduleid = @UserModuleID
                   AND portalid = @PortalID
                   AND ( isdeleted IS NULL
                          OR isdeleted = 0 )
                   AND isactive = 1
        END
      ELSE
        BEGIN
            SET @UserModuleCount=0
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_AdSenseAddUpdate]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTER date: 2010-04-18
-- Description:  Adsense Settings
-- =============================================  
CREATE PROCEDURE [dbo].[sp_AdSenseAddUpdate] @UserModuleID INT,
                                            @SettingName  NVARCHAR(256),
                                            @SettingValue NVARCHAR(256),
                                            @IsActive     BIT,
                                            @PortalID     INT,
                                            @UpdatedBy    NVARCHAR(256),
                                            @UpdateFlag   BIT
AS
  BEGIN
      IF( @UpdateFlag = 1 )
        BEGIN
            UPDATE dbo.usermodulesettings
            SET    [settingvalue] = @SettingValue,
                   [updatedby] = @UpdatedBy,
                   [isactive] = @IsActive,
                   [ismodified] = 1,
                   [updatedon] = GETDATE()
            WHERE  settingname = @SettingName
                   AND usermoduleid = @UserModuleID
                   AND portalid = @PortalID
        END
      ELSE
        BEGIN
            INSERT INTO dbo.usermodulesettings
                        ([usermoduleid],
                         [settingname],
                         [settingvalue],
                         [isactive],
                         [addedon],
                         [portalid],
                         [addedby])
            VALUES      ( @UserModuleID,
                          @SettingName,
                          @SettingValue,
                          @IsActive,
                          GETDATE(),
                          @PortalID,
                          @UpdatedBy )
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_Template_InsertModule]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Template_InsertModule] (
 @pageID INT
 ,@ModuleName VARCHAR(100)
 ,@FriendlyName VARCHAR(100)
 ,@userModuleTitle VARCHAR(100)
 ,@paneName NVARCHAR(100)
 ,@allowAcess NVARCHAR(MAX)
 ,@roleName NVARCHAR(MAX)
 ,@permissionID NVARCHAR(MAX)
 ,@portalID INT
 ,@allPages BIT
 ,@inheritViewPermissions BIT
 ,@header NVARCHAR(MAX)
 ,@footer NVARCHAR(MAX)
 ,@isActive BIT
 ,@seoName NVARCHAR(100)
 ,@ShowInPages NVARCHAR(256)
 ,@IsHandheld BIT
 ,@suffixClass NVARCHAR(MAX)
 ,@headerText NVARCHAR(500)
 ,@showHeaderText BIT
 ,@isInAdmin BIT
 ,@Query NVARCHAR(MAX)
 ,@LEVEL INT
 )
AS
BEGIN
 DECLARE @Test VARCHAR(MAX)
 DECLARE @ModuleID INT
 DECLARE @ModuleDefID INT
 DECLARE @UserModuleID INT

 SET @UserModuleID = 0

 DECLARE @PageModuleID INT
 DECLARE @UmId NCHAR(10)

 CREATE TABLE #TableAccessName (
  ROWNO INT IDENTITY(1, 1)
  ,AllowAcess NVARCHAR(50)
  )

 INSERT INTO #TableAccessName
 SELECT *
 FROM dbo.Split(@allowAcess, ',')

 CREATE TABLE #TableRoleName (
  ROWNO INT IDENTITY(1, 1)
  ,RoleName NVARCHAR(50)
  )

 INSERT INTO #TableRoleName
 SELECT *
 FROM dbo.Split(@roleName, ',')

 CREATE TABLE #tblpermissionID (
  ROWNO INT IDENTITY(1, 1)
  ,PermissionID NVARCHAR(50)
  )

 INSERT INTO #tblpermissionID
 SELECT *
 FROM dbo.Split(@permissionID, ',')

 IF (
   EXISTS (
    SELECT m.ModuleID
    FROM Modules m
    INNER JOIN ModuleDefinitions md ON m.ModuleID = md.ModuleID
    INNER JOIN PortalModules pm ON md.ModuleID = pm.ModuleID
    WHERE (
      m.IsAdmin = 0
      OR m.IsAdmin IS NULL
      )
     AND (
      m.IsDeleted IS NULL
      OR m.IsDeleted = 0
      )
     AND pm.PortalID = @PortalID
     AND pm.IsActive = 1
     AND m.FriendlyName = @FriendlyName
    )
   )
 BEGIN
  SET @ModuleID = (
    SELECT m.ModuleID
    FROM Modules m
    INNER JOIN ModuleDefinitions md ON m.ModuleID = md.ModuleID
    INNER JOIN PortalModules pm ON md.ModuleID = pm.ModuleID
    WHERE (
      m.IsAdmin = 0
      OR m.IsAdmin IS NULL
      )
     AND (
      m.IsDeleted IS NULL
      OR m.IsDeleted = 0
      )
     AND pm.PortalID = @PortalID
     AND pm.IsActive = 1
     AND m.FriendlyName = @FriendlyName
    )
  SET @ModuleDefID = (
    SELECT ModuleDefID
    FROM ModuleDefinitions
    WHERE ModuleID = @ModuleID
    )

  INSERT INTO UserModules (
   [ModuleDefID]
   ,[UserModuleTitle]
   ,[AllPages]
   ,[InheritViewPermissions]
   ,[Header]
   ,[Footer]
   ,[IsActive]
   ,[PortalID]
   ,[SEOName]
   ,[ShowInPages]
   ,[IsHandheld]
   ,[SuffixClass]
   ,[HeaderText]
   ,[ShowHeaderText]
   ,[IsInAdmin]
   )
  VALUES (
   @ModuleDefID
   ,@userModuleTitle
   ,@allPages
   ,@inheritViewPermissions
   ,@header
   ,@footer
   ,@isActive
   ,@portalID
   ,@seoName
   ,@ShowInPages
   ,@IsHandheld
   ,@suffixClass
   ,@headerText
   ,@showHeaderText
   ,@isInAdmin
   )

  SET @UserModuleID = SCOPE_IDENTITY()

  INSERT INTO PageModules (
   PageID
   ,UserModuleID
   ,PaneName
   )
  VALUES (
   @pageID
   ,@UserModuleID
   ,@paneName
   )

  SET @PageModuleID = SCOPE_IDENTITY()

  DECLARE @Counter INT
  DECLARE @COUNT INT

  SET @Counter = (
    SELECT MAX(ROWNO)
    FROM #TableAccessName
    )
  SET @COUNT = 1

  WHILE (@COUNT <= @Counter)
  BEGIN
   DECLARE @AllowAcess_ INT
   DECLARE @RoleName_ VARCHAR(100)
   DECLARE @PermissionID_ INT

   SET @AllowAcess_ = (
     SELECT AllowAcess
     FROM #TableAccessName
     WHERE ROWNO = @COUNT
     )
   SET @RoleName_ = (
     SELECT RoleName
     FROM #TableRoleName
     WHERE ROWNO = @COUNT
     )
   SET @PermissionID_ = (
     SELECT PermissionID
     FROM #tblpermissionID
     WHERE ROWNO = @COUNT
     )

   DECLARE @ModuleDefPermissionID INT
   DECLARE @RoleID VARCHAR(100)

   IF (
     EXISTS (
      SELECT ModuleDefPermissionID
      FROM ModuleDefPermission
      WHERE ModuleDefID = @ModuleDefID
       AND PermissionID = @PermissionID_
      )
     )
   BEGIN
    SET @ModuleDefPermissionID = (
      SELECT ModuleDefPermissionID
      FROM ModuleDefPermission
      WHERE ModuleDefID = @ModuleDefID
       AND PermissionID = @PermissionID_
      )
   END
   ELSE
   BEGIN
    INSERT INTO ModuleDefPermission (
     ModuleDefID
     ,PermissionID
     )
    VALUES (
     @ModuleDefID
     ,@PermissionID_
     )

    SET @ModuleDefPermissionID = SCOPE_IDENTITY()
   END

   SET @RoleID = (
     SELECT RoleId
     FROM aspnet_Roles
     WHERE RoleName = @RoleName_
     )

   INSERT INTO UserModulePermission (
    UserModuleID
    ,ModuleDefPermissionID
    ,RoleID
    ,AllowAccess
    ,PortalID
    )
   VALUES (
    @UserModuleID
    ,@ModuleDefPermissionID
    ,@RoleID
    ,@AllowAcess_
    ,@portalID
    )

   SET @COUNT = @COUNT + 1
  END

  IF (@LEVEL = 1)
  BEGIN
   SET @Query = (
     SELECT Replace(@Query, '##usermoduleID', @UserModuleID)
     )

   EXEC (@Query)
  END
  ELSE
  BEGIN
   SET @Query = (
     SELECT Replace(@Query, '##UserModuleID', @UserModuleID)
     )

   CREATE TABLE #TableQuery (
    RowNum INT IDENTITY(1, 1)
    ,Query NVARCHAR(MAX)
    )

   INSERT INTO #TableQuery
   SELECT *
   FROM dbo.Split(@Query, '^')

   DECLARE @Count1 INT
    ,@Counter1 INT

   SET @Counter1 = (
     SELECT COUNT(*)
     FROM #TableQuery
     )
   SET @Count1 = 1

   DECLARE @Count2 INT
    ,@Counter2 INT

   SET @Count2 = 1

   WHILE (@Count1 <= @Counter1)
   BEGIN
    DECLARE @SingleQuery NVARCHAR(MAX)

    SET @SingleQuery = (
      SELECT Query
      FROM #TableQuery
      WHERE RowNum = @Count1
      )

    IF (@SingleQuery IS NOT NULL)
    BEGIN
     CREATE TABLE #TableSmallQuery (
      Row INT IDENTITY(1, 1)
      ,SmallQuery NVARCHAR(MAX)
      )

     INSERT INTO #TableSmallQuery
     SELECT *
     FROM dbo.Split(@SingleQuery, '!')

     DECLARE @BannerID INT

     SET @Counter2 = (
       SELECT COUNT(*)
       FROM #TableSmallQuery
       ) + @Count2 - 1

     DECLARE @FIRST INT

     SET @FIRST = 1

     WHILE (@Count2 <= @Counter2)
     BEGIN
      DECLARE @SmallQuery NVARCHAR(MAX)

      SET @SmallQuery = (
        SELECT SmallQuery
        FROM #TableSmallQuery
        WHERE Row = @Count2
        )

      IF (@FIRST = 1)
      BEGIN
       CREATE TABLE #TableTemp (i INT)

       INSERT #TableTemp
       EXEC (N' SET NOCOUNT ON ' + @SmallQuery)

       IF (
         (
          SELECT TOP (1) *
          FROM #TableTemp
          ) <> 0
         )
        SET @BannerID = (
          SELECT TOP (1) *
          FROM #TableTemp
          )

       DELETE
       FROM #TableTemp

       DROP TABLE #TableTemp
      END
      ELSE
      BEGIN
       SET @SmallQuery = (
         SELECT Replace(@SmallQuery, '@tempID', @BannerID)
         )

       EXEC (N' SET NOCOUNT ON ' + @SmallQuery)
      END

      SET @Count2 = @Count2 + 1
      SET @FIRST = @FIRST + 1
     END

     DELETE
     FROM #TableSmallQuery
    END

    DROP TABLE #TableSmallQuery

    SET @Count1 = @Count1 + 1
   END

   DROP TABLE #TableQuery
  END
 END

 DROP TABLE #TableAccessName

 DROP TABLE #TableRoleName

 DROP TABLE #tblpermissionID

 SELECT @UserModuleID AS UserModuleId
END
GO
/****** Object:  View [dbo].[vw_PageUserModules]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_PageUserModules] as  
SELECT distinct  p.PageID, p.SEOName, p.PortalID, pm.UserModuleID, um.UserModuleTitle, pm.PaneName, pm.ModuleOrder, um.IsHandheld, um.SuffixClass, um.ShowHeaderText,         
                      um.HeaderText, um.IsInAdmin, mc.ControlSrc, mc.SupportsPartialRendering, ump.RoleID, ump.Username, um.AllPages, um.ShowInPages, mc.ControlType,         
                      um.IsDeleted, um.IsActive ,(SELECT COUNT(1) AS Expr1  FROM  dbo.ModuleControls AS mc1  WHERE (ModuleDefID = um.ModuleDefID AND IsDeleted <> 1)) AS ControlsCount              
     
FROM   dbo.Pages p       
  LEFT JOIN dbo.PageModules pm ON p.PageID = pm.PageID AND p.PortalID = pm.PortalID       
  LEFT JOIN dbo.UserModules AS um ON pm.UserModuleID = um.UserModuleID --and ISNULL(um.ShowInPages,'')<>''        
  LEFT JOIN dbo.ModuleControls AS mc ON mc.ModuleDefID = um.ModuleDefID AND p.IsDeleted <> 1 and mc.ControlType = 1            
  LEFT JOIN dbo.UserModulePermission AS ump ON  ump.UserModuleID = um.UserModuleID 
  ----------------------------------------------------------------------------------------
 ---- ** use this following join if the COUNT(ump.UserModulePermissionID) is used in [usp_MasterPageGetPageModules] ** swantina, 2013 nov 21**----
  -- left join dbo.moduledefpermissiON   mdp    ON ump.moduledefpermissiONid = mdp.moduledefpermissiONid 
   --- AND SELECT --,ump.ModuleDefPermissionID
       --, mdp.permissiONid  
  ----------------------------------------------------------------------------------------    
WHERE ISNULL(p.IsDeleted,0)=0 AND ISNULL(um.IsDeleted,0)=0  AND um.IsActive = 1

--------------------------------------------------------------------------------------------------------------------------------------------------
GO
/****** Object:  StoredProcedure [dbo].[usp_CheckModulePermissionView]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CheckModulePermissionView] @UserModuleID INT
  ,@UserName NVARCHAR(256)
 ,@PortalID INT
AS
BEGIN
	 IF (
	   EXISTS (
		SELECT UserModulePermissionID
		FROM userModulepermission ump
		 ,aspnet_UsersInRoles aur
		 ,aspnet_Users au
		 ,ModuleDefPermission mdf
		WHERE ump.userModuleID = @userModuleID
		 AND ump.portalID = @portalID
		 AND ump.RoleID = aur.RoleID
		 AND aur.UserID = au.UserID
		 AND au.UserName = @UserName
		 AND mdf.ModuleDefPermissionID = ump.ModuleDefPermissionID
		 AND mdf.PermissionID =1
		)
	   )
		 BEGIN
		  SELECT 1
		 END
	 ELSE
		 BEGIN
			
		  --SELECT 0
		  DECLARE @IVP BIT
		
		  
		  SET @IVP = (SELECT InheritViewPermissions FROM UserModules WHERE UserModuleID = @UserModuleID) 
		  IF(@IVP=1)
				BEGIN
				  DECLARE @PID INT
				  DECLARE @PER BIT
				  DECLARE @MPER BIT
				  DECLARE @RID uniqueidentifier
		 
		  SET @RID = (SELECT RoleID FROM aspnet_UsersInRoles AUI LEFT JOIN aspnet_Users AU ON AUI.UserId=AU.UserId WHERE  AU.UserName=@UserName)

				SET @PID = (SELECT PageID FROM PageModules  WHERE UserModuleID = @UserModuleID )
				SET @PER = (SELECT AllowAccess FROM PagePermission 
				WHERE PageID=@PID 
				AND (Username=@UserName OR @RID=RoleID)
				--AND PortalID=@PortalID 
				AND PermissionID=1
				)
					IF(@PER=1)
						SELECT 1
					ELSE 
						SELECT 0
				END
			ELSE
				SELECT 0


		 END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_CheckModulePermissionEdit]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CheckModulePermissionEdit] @UserModuleID INT
 ,@UserName NVARCHAR(256)
 ,@PortalID INT
AS
BEGIN
 IF (
 
   EXISTS (
    SELECT UserModulePermissionID
    FROM userModulepermission ump
     ,aspnet_UsersInRoles aur
     ,aspnet_Users au
     ,ModuleDefPermission mdf
    WHERE ump.userModuleID = @userModuleID
     AND ump.portalID = @portalID
     AND ump.RoleID = aur.RoleID
     AND aur.UserID = au.UserID
     AND au.UserName = @UserName
     AND mdf.ModuleDefPermissionID = ump.ModuleDefPermissionID
     AND mdf.PermissionID = 2
    )
   )
 BEGIN
  SELECT 1
 END
 ELSE
 BEGIN
  SELECT 0
 END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PortalDelete]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PortalDelete]
 @PortalID INT,
 @UserName NVARCHAR(256)
AS
BEGIN
 DELETE FROM [dbo].PagePermission WHERE PageID IN (SELECT PageID FROM dbo.Pages 
 WHERE PortalID=@PortalID)
 DELETE FROM [dbo].PageModules WHERE PortalID=@PortalID
 DELETE FROM [dbo].[UserModulePermission] 
 WHERE UserModuleID in (SELECT UserModuleID FROM [dbo].UserModules WHERE PortalID=@PortalID)

 DELETE FROM [dbo].HtmlComment WHERE HTMLTextID IN (SELECT HTMLTextID FROM [dbo].HtmlText  
 WHERE UserModuleID in (SELECT UserModuleID FROM [dbo].UserModules WHERE PortalID=@PortalID))
 DELETE FROM [dbo].HtmlText  WHERE UserModuleID in (SELECT UserModuleID FROM [dbo].UserModules 
 WHERE PortalID=@PortalID)
 DELETE FROM [dbo].[Image] WHERE PortalID=@PortalID 

 DELETE FROM dbo.MessageTemplateTypeToken 
 WHERE MessageTemplateTypeID IN (SELECT MessageTemplateTypeID 
 FROM dbo.MessageTemplateType  WHERE PortalID=@PortalID)
 
 DELETE FROM dbo.MessageTemplate  WHERE PortalID=@PortalID
 DELETE FROM dbo.MessageTemplateType  WHERE PortalID=@PortalID
    DELETE FROM dbo.MessageTemplateTypeMap WHERE PortalID=@PortalID

 DELETE FROM [dbo].PageModules WHERE PageID IN (SELECT PageID FROM [dbo].Pages 
 WHERE PortalID=@PortalID)
 -- SELECT * FROM dbo.Permission
 DELETE FROM [dbo].PortalRole WHERE PortalID=@PortalID
 DELETE FROM [dbo].PortalUser  WHERE PortalID=@PortalID
 DELETE FROM [dbo].ProfileValue WHERE ProfileID IN (SELECT ProfileID FROM dbo.[Profile] 
 WHERE PortalID=@PortalID)
 DELETE FROM [dbo].[Profile] WHERE PortalID=@PortalID
 DELETE FROM [dbo].UserModulePermission WHERE UserModuleID in (SELECT UserModuleID 
 
 FROM [dbo].UserModules WHERE PortalID=@PortalID)
 DELETE FROM [dbo].UserModuleSettings WHERE UserModuleID in (SELECT UserModuleID 
 FROM [dbo].UserModules WHERE PortalID=@PortalID)
 DELETE FROM [dbo].Users  WHERE PortalID=@PortalID
 DELETE FROM [dbo].UserModules WHERE PortalID=@PortalID
 DELETE FROM [dbo].[PagePermission] WHERE PageID IN (SELECT PageID FROM [dbo].Pages 
 WHERE PortalID=@PortalID)
 DELETE FROM [dbo].Pages WHERE PortalID=@PortalID
 DELETE FROM [dbo].[PortalModulePermission] WHERE PortalModuleID IN (SELECT PortalModuleID 
 FROM [dbo].PortalMOdules WHERE PortalID=@PortalID)
 DELETE FROM [dbo].PortalModules WHERE PortalID=@PortalID
 DELETE FROM [dbo].SettingValue WHERE SettingTypeID=@PortalID
 DELETE FROM [dbo].[Profile] WHERE PortalID=@PortalID
 DELETE FROM [dbo].PortalUser WHERE PortalID=@PortalID
 DELETE FROM [dbo].Portal WHERE PortalID=@PortalID
 DELETE FROM [dbo].PageMenu WHERE PortalID=@PortalID
 DELETE FROM [dbo].sftemplate WHERE PortalID=@PortalID
 DELETE FROM [dbo].UserAgent WHERE PortalID =@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PagesDelete]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PagesDelete]
  @PageID int,
  @DeletedBy nvarchar(256),
  @PortalID int
AS
BEGIN

  DECLARE @PageOrder INT,@ParentID INT
  SELECT @PageOrder=PageOrder,@ParentID=ParentID FROM [dbo].[Pages] WHERE PageID=@PageID
  DECLARE @tblChildPages TABLE (RowNum INT Identity(1,1), ChildPageID INT)
  
  ----- Delete from pagepermission and update history table ---
  INSERT INTO [PagePermission_History]
  SELECT  Getdate(),'D',@DeletedBy,* FROM [dbo].[PagePermission] WHERE [dbo].[PagePermission].[PageID] = @PageID And [dbo].[PagePermission].[PortalID] = @PortalID; 
 
  --UPDATE [PagePermission_History] SET [IsActive] =0 ,[IsDeleted] = 1  WHERE [dbo].[PagePermission_History].[PageID] = @PageID And [dbo].[PagePermission_History].[PortalID] = @PortalID  
  
     
  DELETE FROM  [PagePermission] WHERE [dbo].[PagePermission].[PageID] = @PageID --And [dbo].[PagePermission].[PortalID] = @PortalID;
  
   ----- Delete from pageModules and update history table ---
   
   INSERT INTO [PageModules_History]
  SELECT  Getdate(),'D',@DeletedBy,* FROM [dbo].[PageModules] WHERE [dbo].[PageModules].[PageID] = @PageID And [dbo].[PageModules].[PortalID] = @PortalID; 
 
  --UPDATE [PageModules_History] SET [IsActive] =0 ,[IsDeleted] = 1  WHERE [dbo]. [PageModules_History].[PageID] = @PageID And [dbo]. [PageModules_History].[PortalID] = @PortalID  
  
     
  DELETE FROM  [PageModules] WHERE [dbo].[PageModules].[PageID] = @PageID And [dbo].[PageModules].[PortalID] = @PortalID;
    
    
  ----- Delete from  usermodules and update history table ---   
  
  EXECUTE [dbo].[usp_UserModuleHistory] @PageID ,@DeletedBy ,@PortalID
  ----------
  ----- Delete from  PagePreviee ---  

  DELETE FROM  [PagePreview] WHERE [dbo].[PagePreview].[PageID] = @PageID --And [dbo].[PagePreview].[PortalID] = @PortalID;
  ---------- 
  
  INSERT INTO [Pages_History]
  SELECT  Getdate(),'D',@DeletedBy,* FROM [dbo].[Pages] WHERE [dbo].[Pages].[PageID] = @PageID And [dbo].[Pages].[PortalID] = @PortalID;
 
  --UPDATE [Pages_History] SET [IsActive] =0 ,[IsDeleted] = 1  WHERE [dbo].[Pages_History].[PageID] = @PageID And [dbo].[Pages_History].[PortalID] = @PortalID  
  
  DELETE FROM  [Pages] WHERE [dbo].[Pages].[PageID] = @PageID And [dbo].[Pages].[PortalID] = @PortalID;
  

   EXECUTE [dbo].[usp_PageMenuDelete] @PageID,@DeletedBy
   
   
   UPDATE [dbo].[Pages]
   SET  PageOrder = PageOrder - 1 
   WHERE PageOrder > @PageOrder AND PortalID = @PortalID 
     AND ParentID=@ParentID AND (IsDeleted = 0 OR IsDeleted IS NULL)
   
   DECLARE @Counter INT, @Count INT
   SET @Counter=1
    
   INSERT INTO @tblChildPages(ChildPageID) SELECT PageID FROM [dbo].Pages WHERE ParentID=@PageID AND (IsDeleted=0 OR IsDeleted IS NULL) 
   SET @Count = @@ROWCOUNT
  
  

 WHILE @Counter<=@Count
  BEGIN
   DECLARE @ChildPageID INT
   SELECT @ChildPageID=ChildPageID FROM @tblChildPages WHERE RowNum=@Counter
   EXECUTE [dbo].[sp_PagesDelete] @ChildPageID,@DeletedBy,@PortalID
   EXECUTE [dbo].[usp_PageMenuDelete] @ChildPageID ,@DeletedBy 
   DELETE FROM [dbo].[MenuItem] WHERE PageID=@ChildPageID 
   SET @Counter=@Counter+1
  END
  
  DELETE FROM [dbo].[MenuItem] WHERE PageID=@PageID 
  DELETE FROM [dbo].[MenuItem] WHERE ParentID=@PageID 

END
GO
/****** Object:  StoredProcedure [dbo].[sp_NewsSearch]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[sp_NewsSearch] N'Acharya','anonymoususer',1,'en-US',1
-- =============================================
CREATE PROCEDURE [dbo].[sp_NewsSearch] 
 @Searchword nvarchar(500),
 @SearchBy nvarchar(256),
 @IsUseFriendlyUrls bit,
 @CultureName nvarchar(256),
 @PortalID INT
 
AS
BEGIN
 Declare @MaxResultCharacter int
set @MaxResultCharacter = (select top(1) SettingValue from [dbo].[SageFrameSearchSettingValue] where SettingKey ='MaxResultChracterAllowedWithSpace' and PortalID=@PortalID and CultureName=@CultureName)

declare @length int

Declare @code nvarchar(20)
if(@CultureName='ne-NP') 
 begin
set @length=3
set @code=N' ?'
 end
 
else
begin
set @length=1
set @code='.'
end
--select @code
 DECLARE @TblSearchText AS TABLE
 (
  RowNum INT IDENTITY(1,1),
  SearchText NVARCHAR(100)
 )

 DECLARE @TblPage AS TABLE
 (
  RowNum INT IDENTITY(1,1),
  PageID INT
 )

 DECLARE @TblUserModule AS TABLE
 (
  RowNum INT IDENTITY(1,1),
  SearchPageID INT,
  SearchUserModuleID INT,
  SearchHTMLTextID INT,
  HTMLContent nvarchar(max) ,
  UpdatedContentOn datetime,
  UserModuleTitle nvarchar(500)
 )

  DECLARE @SearchKey NVARCHAR(256),@SearchCount INT, @Counter INT
  declare @textSQL nvarchar(2000)
  declare @LikeText nvarchar(4000)

set @LikeText=''
set @Searchword=RTRIM(LTRIM(@Searchword))


IF(charindex(' ',@Searchword)>0) --if more than one word in searchkey
 BEGIN
        DECLARE  @rowText nvarchar(4000)
        CREATE TABLE #TblContent 
    (
     RowNum int identity(1,1),
     SearchPageID INT,
     SearchUserModuleID INT,
     SearchHTMLTextID INT,
     HTMLContent nvarchar(max),
              UpdatedContentOn datetime,
     UserModuleTitle nvarchar(500)   
    )

  INSERT INTO @TblSearchText(SearchText)
   SELECT RTRIM(LTRIM(items)) FROM [dbo].split( @Searchword,' ')
     WHERE Len(items)>2 or items not in ('a','is','I','in','of','the','and','on','are','was','has','have','had','would','might','<','>','!','@','#')
    --filtering connector word/letter out

     --select * from @TblSearchText
   SELECT @SearchCount=COUNT(RowNum) FROM @TblSearchText

   SET @Counter=1
    WHILE @Counter<=@SearchCount
     BEGIN
       SELECT @rowText=SearchText from @TblSearchText where RowNum=@Counter
       --dbo.ufn_RegExpLike(Content)
       SET @LikeText=@LikeText +' dbo.ufn_RegExpLike([dbo].[News].[News])  LIKE N''%'+@rowText +'%'' or '

  
      SET @Counter=@Counter+1
      END 

 IF(len(@LikeText)>2)
  SET @LikeText=substring(@LikeText,1,len(@LikeText)-3)


 --print  @LikeText

   set @textSQL=N''
   set @textSQL=@textSQL+'INSERT INTO #TblContent(SearchPageID,SearchUserModuleID,SearchHTMLTextID,HTMLContent,UpdatedContentOn)'
   set @textSQL=@textSQL+'  SELECT [dbo].[Pages].PageID,[dbo].[News].[UserModuleID],[dbo].[News].[NewsID] as HTMLTextID,
   
 dbo.ufn_RegExpLike([dbo].[News].[News])
 as HTMLContent,[dbo].[News].[AddedOn] as UpdatedContentOn FROM [dbo].[News]' 
   set @textSQL=@textSQL+'  INNER JOIN [dbo].[UserModules] ON [dbo].[News].UserModuleID=[dbo].[UserModules].UserModuleID'
   set @textSQL=@textSQL+'  INNER JOIN [dbo].[PageModules] ON [dbo].[PageModules].UserModuleID=[dbo].[UserModules].UserModuleID'
   set @textSQL=@textSQL+'  INNER JOIN [dbo].[Pages] ON [dbo].[Pages].PageID= [dbo].[PageModules].PageID'
   set @textSQL=@textSQL+'  WHERE ([dbo].[News].PortalID ='+CAST (@PortalID as nVarChar)+' and [dbo].[News].CultureCode = '''+@CultureName+''') AND ('+@LikeText+')'
   set @textSQL=@textSQL+'  AND ([dbo].[Pages].IsDeleted=0 OR [dbo].[Pages].IsDeleted IS NULL) AND ([dbo].[UserModules].IsDeleted=0 OR [dbo].[UserModules].IsDeleted IS NULL) AND ([dbo].[PageModules].IsDeleted=0 OR [dbo].[PageModules].IsDeleted IS NULL)'
   set @textSQL=@textSQL+'  AND [dbo].[Pages].IsActive=1 AND [dbo].[UserModules].IsActive=1 AND [dbo].[PageModules].IsActive=1 AND [dbo].[Pages].PortalID='+CAST (@PortalID as nVarChar)+''


 EXEC sp_executesql @textSQL


--inserting the result which consist of all words
 INSERT INTO @TblUserModule(SearchPageID,SearchUserModuleID,SearchHTMLTextID,HTMLContent,UpdatedContentOn)
   SELECT SearchPageID,SearchUserModuleID,SearchHTMLTextID,HTMLContent,UpdatedContentOn FROM #TblContent
    WHERE (HTMLContent  LIKE N'%' + @Searchword+ '%')



--inserting the result which consist of atleast one word from group of words

    SELECT @SearchKey=SearchText FROM @TblSearchText WHERE RowNum=@Counter

     SET @Counter=@Counter+1

    SELECT @SearchCount=COUNT(RowNum) FROM @TblSearchText
     SET @Counter=1
      WHILE @Counter<=@SearchCount
       BEGIN
         SELECT @SearchKey=SearchText FROM @TblSearchText WHERE RowNum=@Counter
         
          INSERT INTO @TblUserModule(SearchPageID,SearchUserModuleID,SearchHTMLTextID,HTMLContent,UpdatedContentOn)
         SELECT SearchPageID,SearchUserModuleID,SearchHTMLTextID,
          SUBSTRING
       (
       
       SUBSTRING
         (
         dbo.ufn_RegExpLike(#TblContent.HTMLContent),
        charindex(@SearchKey,dbo.ufn_RegExpLike(#TblContent.HTMLContent))-150,
         @MaxResultCharacter
         )
         ,
       case 
       when charindex(@SearchKey,
        SUBSTRING
         (
         dbo.ufn_RegExpLike(#TblContent.HTMLContent),
        charindex(@SearchKey,dbo.ufn_RegExpLike(#TblContent.HTMLContent))-150,
         @MaxResultCharacter
         )
        )
        -

    charindex(@code,
        SUBSTRING
         (
         dbo.ufn_RegExpLike(#TblContent.HTMLContent),
        charindex(@SearchKey,dbo.ufn_RegExpLike(#TblContent.HTMLContent))-150,
         @MaxResultCharacter
         )
        )
        <0 then 0
      else 


       Charindex(@code,
         SUBSTRING
         (
         dbo.ufn_RegExpLike(#TblContent.HTMLContent),
        charindex(@SearchKey,dbo.ufn_RegExpLike(#TblContent.HTMLContent))-150,
         @MaxResultCharacter
         )
           )+@length
        END
       ,@MaxResultCharacter
      ) +'...'
     
      as HTMLContent,
         UpdatedContentOn FROM #TblContent
         WHERE (HTMLContent  LIKE N'%' + @SearchKey + '%')and SearchUserModuleID not in( select SearchUserModuleID from @TblUserModule)
         SET @Counter=@Counter+1
        END
        
    DROP TABLE #TblContent
    
  END 
ELSE
  BEGIN
  

     --if only one word
   INSERT INTO @TblUserModule(SearchPageID,SearchUserModuleID,SearchHTMLTextID,HTMLContent,UpdatedContentOn)--DISTINCT
     SELECT  [dbo].[Pages].PageID,[dbo].[News].[UserModuleID],[dbo].[News].[NewsID] as HTMLTextID,
 --dbo.ufn_StripHTML([dbo].[HtmlText].[Content])
    -- SUBSTRING
    -- (
    -- dbo.ufn_StripHTML([dbo].[HtmlText].[Content]),
    --charindex(@Searchword,dbo.ufn_StripHTML([dbo].[HtmlText].[Content]))-150,
    -- 300
    -- )
     
      SUBSTRING
       (
       
       SUBSTRING
         (
         dbo.ufn_RegExpLike([dbo].[News].[News]),
        charindex(@Searchword,dbo.ufn_RegExpLike([dbo].[News].[News]))-150,
         @MaxResultCharacter
         )
         ,
       case 
       when charindex(@Searchword,
        SUBSTRING
         (
         dbo.ufn_RegExpLike([dbo].[News].[News]),
        charindex(@Searchword,dbo.ufn_RegExpLike([dbo].[News].[News]))-150,
         @MaxResultCharacter
         )
        )
        -

    charindex(@code,
        SUBSTRING
         (
         dbo.ufn_RegExpLike([dbo].[News].[News]),
        charindex(@Searchword,dbo.ufn_RegExpLike([dbo].[News].[News]))-150,
         @MaxResultCharacter
         )
        )
        <0 then 0
      else 


       Charindex(@code,
         SUBSTRING
         (
         dbo.ufn_RegExpLike([dbo].[News].[News]),
        charindex(@Searchword,dbo.ufn_RegExpLike([dbo].[News].[News]))-150,
         @MaxResultCharacter
         )
           )+@length
        END
       ,@MaxResultCharacter
      ) +'...'
     
      as HTMLContent,[dbo].[News].[AddedOn] FROM [dbo].[News] 
           INNER JOIN [dbo].[UserModules] ON [dbo].[News].UserModuleID=[dbo].[UserModules].UserModuleID
           INNER JOIN [dbo].[PageModules] ON [dbo].[PageModules].UserModuleID=[dbo].[UserModules].UserModuleID
           INNER JOIN [dbo].[Pages] ON [dbo].[Pages].PageID= [dbo].[PageModules].PageID
      WHERE 
      [dbo].[Pages].PortalID=@PortalID and
       [dbo].[Pages].PageID not in( select SearchPageID from @TblUserModule)  and([dbo].[News].PortalID = @PortalID AND [dbo].[News].CultureCode = @CultureName) AND
      
       dbo.ufn_RegExpLike([dbo].[News].[News])  LIKE '%' + @Searchword + '%'
      
      
      
       AND ([dbo].[Pages].IsDeleted=0 OR [dbo].[Pages].IsDeleted IS NULL) AND ([dbo].[UserModules].IsDeleted=0 OR [dbo].[UserModules].IsDeleted IS NULL) AND ([dbo].[PageModules].IsDeleted=0 OR [dbo].[PageModules].IsDeleted IS NULL)
        AND [dbo].[Pages].IsActive=1 AND [dbo].[UserModules].IsActive=1 AND [dbo].[PageModules].IsActive=1
       AND [dbo].[Pages].PortalID=@PortalID 
  END
--------------------------------------------------------------------------------------------------------------------------------
declare @RowTotal INT
DECLARE @tblFinal Table(PageName nvarchar(100),UserModuleID INT,UserModuleTitle nvarchar(100),HTMLContent ntext,URL nvarchar(100),UpdatedContentOn Datetime,RowNumber int identity(1,1))


DECLARE @IsParentPortal BIT,@PortalSEOName NVARCHAR(500),@PortalPrefix NVARCHAR(500)
 SELECT @IsParentPortal=IsParent,@PortalSEOName=LTRIM(RTRIM(SEOName)) FROM [dbo].[Portal] WHERE PortalID=@PortalID
 SET @PortalPrefix=''
 IF(NOT(@IsParentPortal=1))
 BEGIN
  SET @PortalPrefix='/portal/'+@PortalSEOName
 END
  
   IF @IsUseFriendlyUrls=1
    BEGIN
    ;WITH numbered AS 
     (
     SELECT  [dbo].[Pages].PageName,[dbo].[UserModules].[UserModuleID],[dbo].[UserModules].UserModuleTitle,HTMLContent,
      (CASE WHEN ([dbo].[Pages].Url IS NULL) OR (LEN(LTRIM(RTRIM([dbo].[Pages].Url)))<1)
       THEN '.'+ @PortalPrefix+LTRIM(RTRIM([dbo].[Pages].TabPath))+'.aspx'
        ELSE LTRIM(RTRIM([dbo].[Pages].Url)) END) AS Url,
      UpdatedContentOn,
      rownum=ROW_NUMBER() OVER (PARTITION BY PageName ORDER BY HTMLContent)
     from [dbo].[Pages] 
       inner join  @TblUserModule on [dbo].[Pages].PageID=SearchPageID 
       inner join [dbo].[UserModules] on [dbo].[UserModules].UserModuleID=SearchUserModuleID
     WHERE [dbo].[Pages].PortalID=@PortalID 
     )
     INSERT INTO @tblFinal
     SELECT PageName,UserModuleID,UserModuleTitle,HTMLContent,URL,UpdatedContentOn
      FROM numbered
      WHERE rownum=1
      --and dbo.
    END
   ELSE
    BEGIN
     ;WITH numbered AS 
     (
      SELECT PageName,[dbo].[UserModules].UserModuleID,[dbo].[UserModules].UserModuleTitle,HTMLContent,
      (CASE WHEN ([dbo].[Pages].Url IS NULL) OR (LEN(LTRIM(RTRIM([dbo].[Pages].Url)))<1)
       THEN './Default.aspx?ptlid='+CONVERT(NVARCHAR(18),@PortalID)+'&ptSEO='+@PortalSEOName+'&pgnm='+LTRIM(RTRIM([dbo].[Pages].[SEOName])) 
       ELSE LTRIM(RTRIM([dbo].[Pages].Url)) END) AS Url,
       UpdatedContentOn,
        rownum=ROW_NUMBER() OVER (PARTITION BY PageName ORDER BY HTMLContent)
       from [dbo].[Pages] 
       inner join  @TblUserModule on [dbo].[Pages].PageID=SearchPageID 
       inner join [dbo].[UserModules] on [dbo].[UserModules].UserModuleID=SearchUserModuleID
       WHERE [dbo].[Pages].PortalID=@PortalID 
     )
     INSERT INTO @tblFinal
     SELECT PageName,UserModuleID,UserModuleTitle,HTMLContent,URL,UpdatedContentOn
      FROM numbered
      WHERE rownum=1
    END 
    
    --SELECT @RowTotal=COUNT(*) FROM @tblFinal
    
    SELECT @CultureName as CultureName, t.PageName,t.UserModuleID,t.UserModuleTitle,t.HTMLContent,t.URL,t.UpdatedContentOn from @tblFinal as t
    
   

END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesRollBack]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Modified By: Dinesh Hona
CREATE PROCEDURE [dbo].[sp_ModulesRollBack] 
 @ModuleID int,
 @PortalID INT
AS
BEGIN
DECLARE @ModuleDefID INT
SELECT @ModuleDefID=ISNULL(ModuleDefID,0) FROM [dbo].[ModuleDefinitions] WHERE ModuleID=@ModuleID
DELETE FROM [dbo].[PageModules] WHERE UserModuleID IN (SELECT ISNULL(UserModuleID,0) FROM [dbo].[UserModules] WHERE ModuleDefID=@ModuleDefID)
DELETE FROM [dbo].[UserModulePermission] WHERE UserModuleID IN (SELECT ISNULL(UserModuleID,0) FROM [dbo].[UserModules] WHERE ModuleDefID=@ModuleDefID)
DELETE FROM [dbo].[UserModules] WHERE ModuleDefID=@ModuleDefID
DELETE FROM [dbo].[Packages] WHERE ModuleID=@ModuleID
DELETE FROM [dbo].[ModuleControls]  WHERE ModuleDefID = @ModuleDefID
DELETE FROM [dbo].[PortalModulePermission] WHERE PortalModuleID IN (SELECT PortalModuleID FROM [dbo].[PortalModules] WHERE ModuleID=@ModuleID) --AND PortalID=@PortalID)
DELETE FROM [dbo].[ModuleDefPermission] WHERE ModuleDefID = @ModuleDefID
DELETE FROM [dbo].[PortalModules] WHERE ModuleID=@ModuleID 
DELETE FROM [dbo].[ModuleDefinitions] WHERE ModuleID=@ModuleID
DELETE FROM [dbo].[CoreModules] WHERE ModuleID=@ModuleID
DELETE FROM [dbo].[Modules] WHERE ModuleID=@ModuleID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModulesGetByUserModuleID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ModulesGetByUserModuleID]
 -- Add the parameters for the stored procedure here
 
AS
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON;

    -- Insert statements for procedure here
 SELECT * 
 FROM dbo.UserModules
 Inner Join PageModules 
 ON 
 UserModules.UserModuleID=PageModules.UserModuleID
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlTextUpdate]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_HtmlTextUpdate]
@UserModuleID INT,
@Content NTEXT,
@CultureName NVARCHAR(256),
@IsAllowedToComment BIT,
@IsActive BIT,
@IsModified BIT,
@UpdatedOn DATETIME,
@PortalID INT,
@UpdatedBy NVARCHAR(256)

AS
BEGIN
IF(EXISTS (SELECT * FROM HtmlText WHERE UserModuleID=@UserModuleID AND CultureName=@CultureName))
BEGIN
UPDATE dbo.HtmlText SET
[Content] = @Content,
[CultureName] = @CultureName,
[IsAllowedToComment]=@IsAllowedToComment,
[IsActive] = @IsActive,
[IsModified] = @IsModified,
[UpdatedOn] = @UpdatedOn,
[PortalID] = @PortalID,
[UpdatedBy] = @UpdatedBy
WHERE
[UserModuleID] = @UserModuleID AND CultureName = @CultureName
END
ELSE
BEGIN
INSERT INTO dbo.HtmlText([UserModuleID],[Content],[CultureName],[IsAllowedToComment],[IsModified],[IsActive],[AddedOn],[PortalID],AddedBy)
VALUES (@UserModuleID, @Content,@CultureName,@IsAllowedToComment,@IsModified,@IsActive,GETDATE(),@PortalID,@UpdatedBy)

END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlTextGetByPortalAndUserModule]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Create date: 2010-03-29
-- Description: HTML/Text Module
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_HtmlTextGetByPortalAndUserModule] 
 @PortalID INT,
 @UsermoduleID INT, 
 @CultureName NVARCHAR(256)
AS
BEGIN
 SELECT
 [HtmlTextID],
 [UserModuleID],
 [Content],
 [CultureName],
 [IsAllowedToComment],
 [IsActive],
 [IsDeleted],
 [IsModified],
 [AddedOn],
 [UpdatedOn],
 [DeletedOn],
 [PortalID],
 [AddedBy],
 [UpdatedBy],
 [DeletedBy]
FROM dbo.HtmlText
WHERE
 [PortalID]=@PortalID AND [UsermoduleID]=@UsermoduleID AND [CultureName] = @CultureName AND (IsDeleted=0 OR IsDeleted IS NULL)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlTextAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  DINESH HONA
-- Create date: 2010-03-30
-- Description: HTML/Text Module truncate table cachesearch
-- =============================================

CREATE PROCEDURE [dbo].[sp_HtmlTextAdd]
 @HTMLTextID int output,
 @UserModuleID int, 
 @Content ntext, 
 @CultureName nvarchar(256),
 @IsAllowedToComment bit,
 @IsModified bit,
 @IsActive bit, 
 @AddedOn datetime, 
 @PortalID int, 
 @AddedBy nvarchar(256)
 
AS
BEGIN
  IF(Not Exists(Select * From dbo.HtmlText Where UserModuleID = @UserModuleID And PortalID = @PortalID And [CultureName] = @CultureName))
  Begin
   INSERT INTO dbo.HtmlText([UserModuleID],[Content],[CultureName],[IsAllowedToComment],[IsModified],[IsActive],[AddedOn],[PortalID],AddedBy)
    VALUES (@UserModuleID, @Content,@CultureName,@IsAllowedToComment,@IsModified,@IsActive,@AddedOn,@PortalID,@AddedBy)
   select @HTMLTextID=SCOPE_IDENTITY()
  End

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[sp_HtmlContentSearch]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------

CREATE PROCEDURE [dbo].[sp_HtmlContentSearch] @Searchword NVARCHAR(500)
 ,@SearchBy NVARCHAR(256)
 ,@IsUseFriendlyUrls BIT
 ,@CultureName NVARCHAR(256)
 ,@PortalID INT
AS
BEGIN
 
 DECLARE @MaxResultCharacter INT

 SELECT TOP (1) @MaxResultCharacter = SettingValue
 FROM [dbo].[SageFrameSearchSettingValue]
 WHERE SettingKey = 'MaxResultChracterAllowedWithSpace'
  AND CultureName = @CultureName
  AND PortalID = @PortalID

 DECLARE @length INT
 DECLARE @code NVARCHAR(20)

 IF (@CultureName = 'ne-NP')
 BEGIN
  SET @length = 3
  SET @code = N' ?'
 END
 ELSE
 BEGIN
  SET @length = 1
  SET @code = '.'
 END

 --select @code
 CREATE TABLE #TblSearchText (
  RowNum INT IDENTITY(1, 1)
  ,SearchText NVARCHAR(100)
  )
 CREATE TABLE #TblPage  (
  RowNum INT IDENTITY(1, 1)
  ,PageID INT
  )
 CREATE TABLE #TblUserModule (
  RowNum INT IDENTITY(1, 1)
  ,SearchPageID INT
  ,SearchUserModuleID INT
  ,SearchHTMLTextID INT
  ,HTMLContent NVARCHAR(max)
  ,UpdatedContentOn DATETIME
  ,UserModuleTitle NVARCHAR(500)
  )
 DECLARE @SearchKey NVARCHAR(256)
  ,@SearchCount INT
  ,@Counter INT
 DECLARE @textSQL NVARCHAR(2000)
 DECLARE @sqlStatement  NVARCHAR(4000)
 DECLARE @LikeText NVARCHAR(4000)
 DECLARE @SqlWhere NVARCHAR(4000)

 SET @LikeText = ''
 SET @SqlWhere = ''
 SET @sqlStatement = '' 
 SET @Searchword = RTRIM(LTRIM(@Searchword))


 IF (charindex(' ', @Searchword) > 0) --if more than one word in searchkey
 BEGIN
  DECLARE @rowText NVARCHAR(4000)
  CREATE TABLE #TblContent (
   RowNum INT identity(1, 1)
   ,SearchPageID INT
   ,SearchUserModuleID INT
   ,SearchHTMLTextID INT
   ,HTMLContent NVARCHAR(max)
   ,UpdatedContentOn DATETIME
   ,UserModuleTitle NVARCHAR(500)
   )

  INSERT INTO #TblSearchText (SearchText)
  SELECT RTRIM(LTRIM(items))  FROM [dbo].split(@Searchword, ' ')  
  WHERE Len(items) > 2 OR items NOT IN ( 'a','is','I','in','of','the','and','on','are','was' ,'has' ,'have','had','would','might','<','>','!','@','#')

  --filtering connector word/letter out
  --select * from @TblSearchText
  SELECT @SearchCount = COUNT(RowNum) FROM #TblSearchText

  SET @Counter = 1

  WHILE @Counter <= @SearchCount
  BEGIN
   SELECT @rowText = SearchText
   FROM #TblSearchText
   WHERE RowNum = @Counter
    
   SET @LikeText = @LikeText + ' [dbo].[HtmlText].[Content] LIKE N''%' + @rowText + '%'' or '
   ---SET @SqlWhere = @SqlWhere + ' [HTMLContent] LIKE N''%' + @rowText + '%'' or '
   SET @Counter = @Counter + 1
  END


  IF (len(@LikeText) > 2)
   SET @LikeText = SUBSTRING(@LikeText, 1, LEN(@LikeText) - 3)

  SET @textSQL = N''
  SET @textSQL = @textSQL + '   INSERT INTO #TblContent(SearchPageID,SearchUserModuleID,SearchHTMLTextID,HTMLContent,UpdatedContentOn)'
  SET @textSQL = @textSQL + '   SELECT [dbo].[Pages].PageID,[dbo].[HtmlText].[UserModuleID],[dbo].[HtmlText].HTMLTextID,   
          [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content]) as HTMLContent, 
             [dbo].[HtmlText].[AddedOn] as UpdatedContentOn FROM [dbo].[HtmlText]'
  SET @textSQL = @textSQL + '  LEFT JOIN [dbo].[UserModules] WITH (NOLOCK) ON [dbo].[HtmlText].UserModuleID=[dbo].[UserModules].UserModuleID'
  SET @textSQL = @textSQL + '  LEFT JOIN [dbo].[PageModules]  WITH (NOLOCK) ON [dbo].[PageModules].UserModuleID=[dbo].[UserModules].UserModuleID'
  SET @textSQL = @textSQL + '  LEFT JOIN [dbo].[Pages]  WITH (NOLOCK) ON [dbo].[Pages].PageID= [dbo].[PageModules].PageID'
  SET @textSQL = @textSQL + '  WHERE ([dbo].[HtmlText].PortalID =' + CAST(@PortalID AS NVARCHAR) + ' and [dbo].[HtmlText].CultureName = ''' + @CultureName + ''') AND (' + @LikeText + ')'
  SET @textSQL = @textSQL + '  AND ([dbo].[Pages].IsDeleted=0 OR [dbo].[Pages].IsDeleted IS NULL) AND ([dbo].[UserModules].IsDeleted=0 OR [dbo].[UserModules].IsDeleted IS NULL) AND ([dbo].[PageModules].IsDeleted=0 OR [dbo].[PageModules].IsDeleted IS NULL)'
  SET @textSQL = @textSQL + '  AND [dbo].[Pages].IsActive=1 AND [dbo].[UserModules].IsActive=1 AND [dbo].[PageModules].IsActive=1 AND [dbo].[Pages].PortalID=' + CAST(@PortalID AS NVARCHAR) + ''
  EXEC sp_executesql @textSQL
  
  --inserting the result which consist of all words
  INSERT INTO #TblUserModule (
   SearchPageID
   ,SearchUserModuleID
   ,SearchHTMLTextID
   ,HTMLContent
   ,UpdatedContentOn
   )
  SELECT SearchPageID
   ,SearchUserModuleID
   ,SearchHTMLTextID
   ,HTMLContent
   ,UpdatedContentOn
  FROM #TblContent
  WHERE (HTMLContent LIKE N'%' + @Searchword + '%')

  --inserting the result which consist of atleast one word from group of words
  SELECT @SearchKey = SearchText
  FROM #TblSearchText
  WHERE RowNum = @Counter

  SET @Counter = @Counter + 1

  SELECT @SearchCount = COUNT(RowNum)
  FROM #TblSearchText

  SET @Counter = 1

  WHILE @Counter <= @SearchCount
  BEGIN
   SELECT @SearchKey = SearchText
   FROM #TblSearchText
   WHERE RowNum = @Counter

   INSERT INTO #TblUserModule (
    SearchPageID
    ,SearchUserModuleID
    ,SearchHTMLTextID
    ,HTMLContent
    ,UpdatedContentOn
    )
    SELECT #TblContent.SearchPageID
      ,#TblContent.SearchUserModuleID
      ,#TblContent.SearchHTMLTextID
      ,SUBSTRING(SUBSTRING(#TblContent.HTMLContent, charindex(@SearchKey, #TblContent.HTMLContent) - 150, @MaxResultCharacter), CASE 
        WHEN CHARINDEX(@SearchKey, SUBSTRING(#TblContent.HTMLContent, charindex(@SearchKey, #TblContent.HTMLContent) - 150, @MaxResultCharacter))
         - charindex(@code, SUBSTRING(#TblContent.HTMLContent, charindex(@SearchKey, #TblContent.HTMLContent) - 150, @MaxResultCharacter)) < 0
         THEN 0
        ELSE CHARINDEX(@code, SUBSTRING(#TblContent.HTMLContent, charindex(@SearchKey, #TblContent.HTMLContent) - 150, @MaxResultCharacter)) + @length
        END, @MaxResultCharacter) + '...' AS HTMLContent
      ,#TblContent.UpdatedContentOn  
    FROM #TblContent -- LEFT JOIN  @TblUserModule AS um ON #TblContent.SearchUserModuleID <> um.SearchUserModuleID
    WHERE (#TblContent.HTMLContent LIKE N'%' + @SearchKey + '%')
      AND SearchUserModuleID NOT IN ( SELECT SearchUserModuleID FROM #TblUserModule   )     
   SET @Counter = @Counter + 1
  END
  DROP TABLE #TblContent
 END
 ELSE
 BEGIN
  --if only one word
  INSERT INTO #TblUserModule (
   SearchPageID
   ,SearchUserModuleID
   ,SearchHTMLTextID
   ,HTMLContent
   ,UpdatedContentOn
   ) --DISTINCT
  SELECT [dbo].[Pages].PageID
   ,[dbo].[HtmlText].[UserModuleID]
   ,[dbo].[HtmlText].HTMLTextID
   , SUBSTRING(SUBSTRING( [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content]), charindex(@Searchword,  [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content])) - 150, @MaxResultCharacter),
     CASE WHEN charindex( @Searchword, SUBSTRING( [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content]), charindex(@Searchword,[dbo].[udf_StripHTML]([dbo].[HtmlText].[Content])) - 150, @MaxResultCharacter)) - charindex(@code, SUBSTRING( [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content]), charindex(@Searchword,  [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content])) - 150, @MaxResultCharacter)) < 0
     THEN 0 ELSE Charindex(@code, SUBSTRING( [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content]), charindex(@Searchword,  [dbo].[udf_StripHTML]([dbo].[HtmlText].[Content])) - 150, @MaxResultCharacter)) + @length
     END, @MaxResultCharacter) + '...' AS HTMLContent
   ,[dbo].[HtmlText].[AddedOn]
  FROM [dbo].[HtmlText]
    LEFT JOIN [dbo].[UserModules] ON [dbo].[HtmlText].UserModuleID = [dbo].[UserModules].UserModuleID
    LEFT JOIN [dbo].[PageModules] ON [dbo].[PageModules].UserModuleID = [dbo].[UserModules].UserModuleID
    LEFT JOIN [dbo].[Pages] ON [dbo].[Pages].PageID = [dbo].[PageModules].PageID
    WHERE [dbo].[Pages].PortalID = @PortalID
     AND [dbo].[Pages].PageID NOT IN (
      SELECT SearchPageID
      FROM #TblUserModule
      )
     AND (
      [dbo].[HtmlText].PortalID = @PortalID
      AND [dbo].[HtmlText].CultureName = @CultureName
      )
     AND [dbo].[HtmlText].[Content] LIKE '%' + @Searchword + '%'
     AND (
      [dbo].[Pages].IsDeleted = 0
      OR [dbo].[Pages].IsDeleted IS NULL
      )
     AND (
      [dbo].[UserModules].IsDeleted = 0
      OR [dbo].[UserModules].IsDeleted IS NULL
      )
     AND (
      [dbo].[PageModules].IsDeleted = 0
      OR [dbo].[PageModules].IsDeleted IS NULL
      )
     AND [dbo].[Pages].IsActive = 1
     AND [dbo].[UserModules].IsActive = 1
     AND [dbo].[PageModules].IsActive = 1
     AND [dbo].[Pages].PortalID = @PortalID
     DROP TABLE #TblContent 
 END

 --------------------------------------------------------------------------------------------------------------------------------
 --DECLARE @IsParentPortal BIT,@PortalSEOName NVARCHAR(500),@PortalPrefix NVARCHAR(500)
 -- SELECT @IsParentPortal=IsParent,@PortalSEOName=LTRIM(RTRIM(SEOName)) FROM [dbo].[Portal] WHERE PortalID=@PortalID
 --  SET @PortalPrefix=''
 -- select * from @TblUserModule
 DECLARE @RowTotal INT
 CREATE TABLE #tblFinal  (
  PageName NVARCHAR(100)
  ,UserModuleID INT
  ,UserModuleTitle NVARCHAR(100)
  ,HTMLContent NTEXT
  ,URL NVARCHAR(100)
  ,UpdatedContentOn DATETIME
  ,RowNumber INT identity(1, 1)
  )
 DECLARE @IsParentPortal BIT
  ,@PortalSEOName NVARCHAR(500)
  ,@PortalPrefix NVARCHAR(500)
 DECLARE @pageExtension VARCHAR(10)

 SET @pageExtension = (
   SELECT SettingValue
   FROM SettingValue
   WHERE SettingKey = 'PageExtension'
   )

 SELECT @IsParentPortal = IsParent
  ,@PortalSEOName = LTRIM(RTRIM(SEOName))
 FROM [dbo].[Portal]
 WHERE PortalID = @PortalID

 --SELECT @IsParentPortal
 --select @pageExtension
 SET @PortalPrefix = ''

 IF (NOT (@IsParentPortal = 1))
 BEGIN
  SET @PortalPrefix = '/portal/' + @PortalSEOName
  SET @PortalPrefix = ''
 END

 -- SELECT @IsUseFriendlyUrls
 IF @IsUseFriendlyUrls = 1
 BEGIN
  
  ;WITH numbered
  AS (
   SELECT [dbo].[Pages].PageName
    ,[dbo].[UserModules].[UserModuleID]
    ,[dbo].[UserModules].UserModuleTitle
    ,HTMLContent
    ,( CASE 
      WHEN ([dbo].[Pages].Url IS NULL)
       OR (LEN(LTRIM(RTRIM([dbo].[Pages].Url))) < 1)
       THEN replace('./' + @PortalPrefix + LTRIM(RTRIM([dbo].[Pages].PageName)) + @pageExtension, ' ', '-')
      ELSE LTRIM(RTRIM([dbo].[Pages].Url))
      END
     ) AS Url
    ,UpdatedContentOn
    ,rownum = ROW_NUMBER() OVER (
     PARTITION BY PageName ORDER BY HTMLContent
     )
   FROM [dbo].[Pages]
    INNER JOIN #TblUserModule ON [dbo].[Pages].PageID = SearchPageID
    INNER JOIN [dbo].[UserModules] ON [dbo].[UserModules].UserModuleID = SearchUserModuleID
    WHERE [dbo].[Pages].PortalID = @PortalID
    )
  INSERT INTO #tblFinal
  SELECT PageName
   ,UserModuleID
   ,UserModuleTitle
   ,HTMLContent
   ,URL
   ,UpdatedContentOn
  FROM numbered
  WHERE rownum = 1
  
 END
 ELSE
 BEGIN
  
  ;WITH numbered
  AS (
   SELECT PageName
    ,[dbo].[UserModules].UserModuleID
    ,[dbo].[UserModules].UserModuleTitle
    ,HTMLContent
    ,(
     CASE 
      WHEN ([dbo].[Pages].Url IS NULL)
       OR (LEN(LTRIM(RTRIM([dbo].[Pages].Url))) < 1)
       THEN replace('./Default' + @pageExtension + '?ptlid=' + CONVERT(NVARCHAR(18), @PortalID) + '&ptSEO=' + @PortalSEOName + '&pgnm=' + LTRIM(RTRIM([dbo].[Pages].[SEOName])), ' ', '-')
      ELSE LTRIM(RTRIM([dbo].[Pages].Url))
      END
     ) AS Url
    ,UpdatedContentOn
    ,rownum = ROW_NUMBER() OVER (
     PARTITION BY PageName ORDER BY HTMLContent
     )
   FROM [dbo].[Pages]
   INNER JOIN #TblUserModule ON [dbo].[Pages].PageID = SearchPageID
   INNER JOIN [dbo].[UserModules] ON [dbo].[UserModules].UserModuleID = SearchUserModuleID
   WHERE [dbo].[Pages].PortalID = @PortalID
   )

  INSERT INTO #tblFinal
  SELECT PageName
   ,UserModuleID
   ,UserModuleTitle
   ,HTMLContent
   ,URL
   ,UpdatedContentOn
  FROM numbered
  WHERE rownum = 1
 END


 SELECT @CultureName AS CultureName
  ,t.PageName
  ,t.UserModuleID
  ,t.UserModuleTitle
  ,t.HTMLContent
  ,t.URL
  ,t.UpdatedContentOn
 FROM #tblFinal AS t

DROP TABLE #TblSearchText
DROP TABLE #TblPage
DROP TABLE #TblUserModule

DROP TABLE #tblFinal



END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPageSetting]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATED DATE: 2010-03-12
CREATE PROCEDURE [dbo].[sp_GetPageSetting]
 @ControlType [INT],
 @PageID [INT],
 @PortalID [INT],
 @UserName [NVARCHAR](256)
WITH EXECUTE AS CALLER
AS
BEGIN

CREATE TABLE #tmpTable (
       [PageID] [int]  NOT NULL,
       [PageOrder] [int] NULL,
       [PageName] [nvarchar](100)  NULL,
       [IsVisible] [bit] NULL DEFAULT ((1)),
       [ParentID] [int] NULL,
       [Level] [int] NULL,
       [IconFile] [nvarchar](100) NULL,
       [DisableLink] [bit] NULL,
       [Title] [nvarchar](200) NULL,
       [Description] [nvarchar](500) NULL,
       [KeyWords] [nvarchar](500) NULL,
       [Url] [nvarchar](255) NULL,
       [TabPath] [nvarchar](255) NULL,
       [StartDate] [datetime] NULL,
       [EndDate] [datetime] NULL,
       [RefreshInterval] [decimal](16, 2) NULL,
       [PageHeadText] [nvarchar](500) NULL,
       [IsSecure] [bit] NOT NULL,
       [IsActive] [bit] NULL,
       [IsDeleted] [bit] NULL,
       [IsModified] [bit] NULL,
       [AddedOn] [datetime] NULL ,
       [UpdatedOn] [datetime] NULL ,
       [DeletedOn] [datetime] NULL,
       [PortalID] [int] NULL,
       [AddedBy] [nvarchar](256) NULL,
       [UpdatedBy] [nvarchar](256) NULL,
       [DeletedBy] [nvarchar](256) NULL,
       [SEOName] [nvarchar](100) NULL,
       [IsShowInFooter] BIT NULL,
       [IsRequiredPage] BIT NULL
      )

-------------------------Select Page Setting----------------------------------------
INSERT INTO #tmpTable
SELECT DISTINCT [dbo].[Pages].* 
FROM   [dbo].[Pages] 
    INNER JOIN  [dbo].[PagePermission]  ON [dbo].[PagePermission].PageID = [dbo].[Pages].PageID
WHERE ([dbo].[PagePermission].[RoleID] IN (SELECT [dbo].[aspnet_UsersInRoles].RoleId
           FROM [dbo].[aspnet_UsersInRoles]
           INNER JOIN [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].UserId = [dbo].[aspnet_UsersInRoles].UserId
           WHERE [dbo].[aspnet_Users].UserName = @UserName)
  OR [dbo].[PagePermission].Username=@UserName ) AND [dbo].[Pages].PageID=@PageID

DECLARE @IconFile [nvarchar](100),
 @Title [nvarchar](200),
 @Description [nvarchar](500),
 @KeyWords [nvarchar](500),
 @PageHeadText [nvarchar](500),
 @IsSecure [bit],
 @RefreshInterval [decimal](16, 2)

SELECT @IconFile=CONVERT(NVARCHAR(100),ISNULL(Pages.IconFile,[dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin',@PortalID,'IconFile'))),
@Title=CONVERT(NVARCHAR(200),ISNULL(Pages.Title,[dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin',@PortalID,'PageTitle'))),
@Description=CONVERT(NVARCHAR(500),ISNULL(Pages.Description,[dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin',@PortalID,'MetaDescription'))),
@KeyWords=CONVERT(NVARCHAR(500),ISNULL(Pages.KeyWords,[dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin',@PortalID,'MetaKeywords'))),
@PageHeadText=CONVERT(NVARCHAR(500),ISNULL(Pages.PageHeadText,[dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin',@PortalID,'PageHeadText'))),
@IsSecure=CONVERT(BIT,ISNULL(Pages.IsSecure,[dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin',1,'IsSecure'))),
@RefreshInterval=CONVERT(DECIMAL(16,2),ISNULL(Pages.RefreshInterval,[dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin',@PortalID,'MetaRefresh'))) 
FROM #tmpTable Pages

SELECT PageID, PageOrder, PageName, IsVisible, ParentID, [Level], 
  @IconFile AS [IconFile], 
  DisableLink, 
  @Title AS [Title], 
  @Description AS [Description], 
  @KeyWords AS [KeyWords], 
  Url, TabPath, StartDate, EndDate, 
  @RefreshInterval AS [RefreshInterval], 
  @PageHeadText AS [PageHeadText], 
  @IsSecure AS [IsSecure], 
  IsActive, IsDeleted, IsModified, AddedOn, UpdatedOn, DeletedOn, PortalID, AddedBy, UpdatedBy, DeletedBy,
  SEOName
FROM #tmpTable


---------------------- Select Page Modules-------------------------------
SELECT DISTINCT [dbo].[PageModules].*
FROM  [dbo].[UserModules]
INNER JOIN [dbo].[UserModulePermission] ON [dbo].[UserModulePermission].UserModuleID = [dbo].[UserModules].UserModuleID 
INNER JOIN [dbo].[PageModules] ON [dbo].[UserModules].UserModuleID = [dbo].[PageModules].UserModuleID 
WHERE [dbo].[PageModules].PageID = @PageID AND ([dbo].[UserModulePermission].RoleID IN
                  (SELECT [dbo].[aspnet_UsersInRoles].RoleId
           FROM [dbo].[aspnet_UsersInRoles]
           INNER JOIN [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].UserId = [dbo].[aspnet_UsersInRoles].UserId
           WHERE [dbo].[aspnet_Users].UserName = @UserName)
  OR [dbo].[UserModulePermission].Username=@UserName)
ORDER BY [dbo].[PageModules].ModuleOrder ASC

-----------------------------Select Page Module Controls------------------------
SELECT DISTINCT [dbo].[ModuleControls].*
FROM  [dbo].[UserModulePermission]
INNER JOIN [dbo].[UserModules] ON [dbo].[UserModulePermission].UserModuleID = [dbo].[UserModules].UserModuleID 
INNER JOIN [dbo].[ModuleControls] ON [dbo].[UserModules].ModuleDefID = [dbo].[ModuleControls].ModuleDefID 
INNER JOIN [dbo].[PageModules] ON [dbo].[UserModules].UserModuleID = [dbo].[PageModules].UserModuleID 
WHERE [dbo].[PageModules].PageID = @PageID AND [dbo].[ModuleControls].ControlType=@ControlType
ORDER BY [dbo].[ModuleControls].DisplayOrder ASC

DROP TABLE #tmpTable
END
/****** Object:  StoredProcedure [dbo].[sp_GetPasswordRecoverySuccessfulTokenValue]    Script Date: 12/02/2012 12:51:07 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[usp_PageModulesAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageModulesAdd] 
 @PageID INT,
 @UserModuleID INT,
 @PaneName NVARCHAR(50),
 @ModuleOrder INT,
 @CacheTime INT,
 @Alignment NVARCHAR(50),
 @Color NVARCHAR(20),
 @Border NVARCHAR(1),
 @IconFile NVARCHAR(100),
 @Visibility INT, 
 @IsActive BIT,
 @AddedOn DATETIME,
 @PortalID INT,
 @AddedBy NVARCHAR(256)
AS

INSERT INTO dbo.PageModules (
 [PageID],
 [UserModuleID],
 [PaneName],
 [ModuleOrder],
 [CacheTime],
 [Alignment],
 [Color],
 [Border],
 [IconFile],
 [Visibility], 
 [IsActive],
 [AddedOn],
 [PortalID],
 [AddedBy]
) VALUES (
 @PageID,
 @UserModuleID,
 @PaneName,
 @ModuleOrder,
 @CacheTime,
 @Alignment,
 @Color,
 @Border,
 @IconFile,
 @Visibility, 
 @IsActive,
 @AddedOn,
 @PortalID,
 @AddedBy
)
GO
/****** Object:  StoredProcedure [dbo].[usp_PageModule_Update]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_PageModule_Update]
(
@UserModuleID INT,
@PaneName NVARCHAR(200),
@ModuleOrder INT
)
as
BEGIN
SET NOCOUNT ON;
UPDATE [dbo].[PageModules]
SET PaneName=@PaneName,
 ModuleOrder=@ModuleOrder
WHERE UserModuleID=@UserModuleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPageModulesByPageID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPageModulesByPageID]

 @PageID    INT, 
 @PortalID  INT 
AS
BEGIN
 SELECT PageModules.UserModuleID,PageModules.PaneName,UserModules.UserModuleTitle,PageModules.ModuleOrder
 FROM dbo.PageModules 
        INNER JOIN dbo.UserModules ON PageModules.UserModuleID = UserModules.UserModuleID
 WHERE  PageID = @PageID 
        AND (dbo.PageModules.PortalID = @PortalID OR dbo.PageModules.PortalID = -1) 
        AND (dbo.PageModules.IsDeleted=0 OR dbo.PageModules.IsDeleted IS NULL)    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPageSettingByPageSEONameForAdmin]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPageSettingByPageSEONameForAdmin]
   @ControlType INT
   , @PageSEOName NVARCHAR(1000)
   , @PortalID INT
   , @UserName NVARCHAR(256)
 WITH EXECUTE AS CALLER
AS
BEGIN
  --- page exists  with portalID and SEOName and isnot marked for deletion   --- 

 IF EXISTS (
     SELECT [dbo].[Pages].PageID
     FROM [dbo].[Pages]
     INNER JOIN [dbo].[PagePermission] ON [dbo].[PagePermission].PageID = [dbo].[Pages].PageID
     WHERE (
       [dbo].[Pages].PortalID = @PortalID
       OR [dbo].[Pages].PortalID = - 1
       )
      AND [dbo].[Pages].SEOName = @PageSEOName
      AND (
       [dbo].[Pages].[IsDeleted] = 0
       OR [dbo].[Pages].[IsDeleted] IS NULL
       )
   )
 BEGIN
    
      IF EXISTS (
        SELECT [dbo].[Pages].PageID
        FROM [dbo].[Pages]
        INNER JOIN [dbo].[PagePermission] ON [dbo].[PagePermission].PageID = [dbo].[Pages].PageID
        WHERE (
          [dbo].[PagePermission].[RoleID] IN ( 
                 SELECT [dbo].[aspnet_UsersInRoles].RoleId
                 FROM [dbo].[aspnet_UsersInRoles]
                 INNER JOIN [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].UserId = [dbo].[aspnet_UsersInRoles].UserId
                 WHERE [dbo].[aspnet_Users].UserName = @UserName
           
                UNION ALL
                
                SELECT [RoleId]
                FROM dbo.aspnet_roles
                WHERE LoweredRoleName = 'anonymous user'
               )
                OR [dbo].[PagePermission].Username = @UserName
          )
         AND [dbo].[Pages].SEOName = @PageSEOName
         AND (
          [dbo].[Pages].[IsDeleted] = 0
          OR [dbo].[Pages].[IsDeleted] IS NULL
          )
         AND (
          [dbo].[Pages].PortalID = @PortalID
          OR [dbo].[Pages].PortalID = - 1
          )
         AND (
          [dbo].[PagePermission].[IsDeleted] = 0
          OR [dbo].[PagePermission].[IsDeleted] IS NULL
          )
        )
      BEGIN
       DECLARE @tblRoleID TABLE ([UserRoleId] VARCHAR(50))   
       DECLARE @tblPageID TABLE ([PageID] VARCHAR(50))--,[PortalID] INT  ) -- UNIQUE NONCLUSTERED ([PageID],[PortalID])) 
          
           
        INSERT INTO @tblRoleID
        SELECT [dbo].[aspnet_UsersInRoles].RoleId 
        FROM [dbo].[aspnet_UsersInRoles]
          LEFT JOIN [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].UserId = [dbo].[aspnet_UsersInRoles].UserId
          LEFT JOIN [dbo].[aspnet_roles] ON [dbo].[aspnet_roles].RoleId = [dbo].[aspnet_UsersInRoles].RoleId 
        WHERE [dbo].[aspnet_Users].[UserName] = @UserName OR [dbo].[aspnet_roles].[LoweredRoleName] = 'anonymous user'   
          
          
       INSERT INTO @tblPageID 
       SELECT DISTINCT p.PageID -- ,p.PortalID               
       FROM   [dbo].[Pages] p
           INNER JOIN [dbo].[PagePermission] ON [dbo].[PagePermission].PageID = p.PageID
       WHERE   ISNULL(p.[IsDeleted],0) = 0 
           AND p.SEOName = @PageSEOName
           AND (p.PortalID = @PortalID OR p.PortalID = - 1)
            
        ------------------------------------------------------------------------------------------------------------------------------------------------
         DECLARE @IconFile NVARCHAR(100), @Title NVARCHAR(200), @Description NVARCHAR(500)
         , @KeyWords NVARCHAR(500), @PageHeadText NVARCHAR(500)
         , @IsSecure BIT, @RefreshInterval DECIMAL(16, 2)

       SELECT @IconFile = ISNULL(Pages.IconFile, [dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin', @PortalID, 'IconFile'))
         , @Title = ISNULL(Pages.Title, [dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin', @PortalID, 'PageTitle'))
         , @Description =  ISNULL(Pages.Description, [dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin', @PortalID, 'MetaDescription'))
         , @KeyWords =  ISNULL(Pages.KeyWords, [dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin', @PortalID, 'MetaKeywords'))
         , @PageHeadText =ISNULL(Pages.PageHeadText, [dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin', @PortalID, 'PageHeadText'))
         , @IsSecure =  ISNULL(Pages.IsSecure, [dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin', 1, 'IsSecure'))
         , @RefreshInterval =  ISNULL(Pages.RefreshInterval, [dbo].[fn_GetSettingValueBySettingKey]('SiteAdmin', @PortalID, 'MetaRefresh'))
       FROM  Pages where SEOName = @PageSEOName
       
         ------------------------------------------------------------------------------------------------------------------------------------------------
         DECLARE @IsPageAccessible BIT
         SET @IsPageAccessible = 0 
       
       IF EXISTS (
          SELECT 1
          FROM [dbo].[PortalUser] pu
           LEFT JOIN [dbo].[Portal] p ON p.PortalID = pu.PortalID
           LEFT JOIN aspnet_usersinroles au ON pu.UserID = AU.UserId
           LEFT JOIN aspnet_roles AR ON AR.RoleId = AU.RoleId
          WHERE (pu.Username = @UserName or  AR.RoleName = 'Super User')  and p.PortalID = 1  
           AND pu.IsActive = 1
           AND ISNULL(pu.IsDeleted,0) = 0
            
             
         )
       SET @IsPageAccessible = 1    
        
       SELECT cast(1 AS BIT) AS IsPageAvailable, CAST(@IsPageAccessible AS BIT) AS IsPageAccessible, @IsSecure AS [IsSecure]    
       
       ------------------------------------------------------------------------------------------------------------------------------------------------------------

       DECLARE @PageID INT

       SELECT @PageID = PageID
       FROM   Pages
       WHERE  SEOName = @PageSEOName AND PortalID = @PortalID   

       ------------------------------------------------------------------------------------------------------------------------------------------------------------

       SELECT DISTINCT  p.PageID, PageOrder, PageName, IsVisible, ParentID, [Level],
            @IconFile AS [IconFile], DisableLink, @Title AS [Title],
            @Description AS [Description], @KeyWords AS [KeyWords], 
            Url, TabPath, StartDate, EndDate, @RefreshInterval AS [RefreshInterval],
            @PageHeadText AS [PageHeadText], @IsSecure AS [IsSecure]       
       FROM    [dbo].[Pages] p
           INNER JOIN [dbo].[PagePermission] ON [dbo].[PagePermission].PageID = p.PageID
       WHERE   (p.[IsDeleted] = 0 AND p.SEOName = @PageSEOName
           AND (p.PortalID = @PortalID OR p.PortalID = - 1 ))
         
         ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
         
         SELECT DISTINCT  [dbo].[PageModules].*,[dbo].[ModuleControls].[ModuleControlID],
          [dbo].[ModuleControls].[ControlKey],
          [dbo].[ModuleControls].[ControlTitle],[dbo].[ModuleControls].[ControlSrc],
          [dbo].[ModuleControls].[IconFile] AS [ModuleIconFile],
          [dbo].[ModuleControls].[ControlType],
          [dbo].[ModuleControls].[DisplayOrder],
          [dbo].[ModuleControls].[HelpUrl],
          [dbo].[ModuleControls].[SupportsPartialRendering] 
                   
      FROM  [dbo].[UserModules] INNER JOIN [dbo].[ModuleControls]   ON [dbo].[UserModules].ModuleDefID = [dbo].[ModuleControls].ModuleDefID 
          INNER JOIN [dbo].[UserModulePermission]      ON [dbo].[UserModulePermission].UserModuleID = [dbo].[UserModules].UserModuleID 
          INNER JOIN [dbo].[PageModules]    ON [dbo].[UserModules].UserModuleID = [dbo].[PageModules].UserModuleID 


      WHERE [dbo].[PageModules].PageID IN (SELECT PageID FROM @tblPageID )
          AND   (
            [dbo].[UserModulePermission].RoleID  IN (SELECT [UserRoleId] FROM @tblRoleID )
             OR [dbo].[UserModulePermission].Username=@UserName
             ) 
          AND ([dbo].[PageModules].IsActive =1 
          AND ([dbo].[PageModules].[IsDeleted] = 0 OR [dbo].[PageModules].[IsDeleted] IS NULL)) 

          AND ([dbo].[ModuleControls].IsDeleted=0 OR [dbo].[ModuleControls].[IsDeleted] IS NULL) 
          AND ([dbo].[ModuleControls].[ControlType]= @ControlType) --OR  [dbo].[ModuleControls].[ControlType]=0) 

          AND [dbo].[UserModules].IsActive=1 
          AND ([dbo].[UserModules].IsDeleted=0 OR [dbo].[UserModules].IsDeleted IS NULL)
         
     
          ---- IF EXISTS(SELECT * FROM @tblPageID WHERE PortalID=-1)
          ----BEGIN
          ---- INSERT #TmpModules
          ---- SELECT DISTINCT [dbo].[PageModules].*,
          ----       [dbo].[ModuleControls].[ModuleControlID],
          ----       [dbo].[ModuleControls].[ControlKey],
          ----     [dbo].[ModuleControls].[ControlTitle],
          ----       [dbo].[ModuleControls].[ControlSrc],
          ----       [dbo].[ModuleControls].[IconFile] AS [ModuleIconFile],
          ----     [dbo].[ModuleControls].[ControlType],
          ----     [dbo].[ModuleControls].[DisplayOrder],
          ----     [dbo].[ModuleControls].[HelpUrl],
          ----     [dbo].[ModuleControls].[SupportsPartialRendering]
          ----  FROM  [dbo].[UserModules]
          ---- INNER JOIN [dbo].[ModuleControls] 
          ----   ON [dbo].[UserModules].ModuleDefID = [dbo].[ModuleControls].ModuleDefID 
          ---- INNER JOIN [dbo].[UserModulePermission] 
          ----   ON [dbo].[UserModulePermission].UserModuleID = [dbo].[UserModules].UserModuleID 
          ---- INNER JOIN [dbo].[PageModules] 
          ----   ON [dbo].[UserModules].UserModuleID = [dbo].[PageModules].UserModuleID
          ---- INNER JOIN [dbo].[Pages] 
          ----   ON [dbo].[PageModules].PageID=[dbo].[Pages].PageID 
          ----   AND ([dbo].[Pages].[IsDeleted] = 0 OR [dbo].[Pages].[IsDeleted] IS NULL)
                         
                         
          ---- WHERE [dbo].[UserModules].PortalID=@PortalID 
           
          ----   AND [dbo].[UserModules].AllPages=1  AND [dbo].[PageModules].IsActive=1 
                         
          ----  AND ([dbo].[PageModules].IsDeleted=0 OR [dbo].[PageModules].IsDeleted IS NULL) 
          ----   AND [dbo].[UserModules].IsActive=1 
                         
          ---- AND ([dbo].[UserModules].IsDeleted=0 OR [dbo].[UserModules].IsDeleted IS NULL) 
           
          ---- AND ([dbo].[ModuleControls].[ControlType]= @ControlType OR  [dbo].[ModuleControls].[ControlType]=0) 
                 
          ---- AND [dbo].[Pages].PageID IN(SELECT PageID FROM [dbo].[PageMenu] WHERE IsAdmin=1)
           
          ---- AND @PageID IN (SELECT RTRIM(LTRIM(items)) 
          ----     FROM   Split([dbo].UserModules.[showinpages], ',') 
          ----     WHERE ([dbo].UserModules.isdeleted=0 OR [dbo].UserModules.isdeleted IS NULL))
          ----END
          ----ELSE
          ----BEGIN
          ---- INSERT #TmpModules
          ---- SELECT DISTINCT [dbo].[PageModules].*,
          ----       [dbo].[ModuleControls].[ModuleControlID],
          ----       [dbo].[ModuleControls].[ControlKey],
          ----     [dbo].[ModuleControls].[ControlTitle],
          ----       [dbo].[ModuleControls].[ControlSrc],
          ----       [dbo].[ModuleControls].[IconFile] AS [ModuleIconFile],
          ----     [dbo].[ModuleControls].[ControlType],
          ----     [dbo].[ModuleControls].[DisplayOrder],
          ----     [dbo].[ModuleControls].[HelpUrl],
          ----     [dbo].[ModuleControls].[SupportsPartialRendering]
          ----  FROM  [dbo].[UserModules]
          ----     INNER JOIN [dbo].[ModuleControls] ON [dbo].[UserModules].ModuleDefID = [dbo].[ModuleControls].ModuleDefID 
          ----    INNER JOIN [dbo].[UserModulePermission] ON [dbo].[UserModulePermission].UserModuleID = [dbo].[UserModules].UserModuleID 
          ----    INNER JOIN [dbo].[PageModules] ON [dbo].[UserModules].UserModuleID = [dbo].[PageModules].UserModuleID 
          ----      AND [dbo].[UserModules].PortalID=[dbo].[PageModules].PortalID
          ----    INNER JOIN [dbo].[Pages] ON [dbo].[PageModules].PageID=[dbo].[Pages].PageID AND [dbo].[Pages].IsDeleted=0 
          ----    WHERE [dbo].[Pages].PageID
          ----        IN(SELECT PageID FROM [dbo].[PageMenu] WHERE IsAdmin=1) 
             
              
          ----    AND ([dbo].[PageModules].IsDeleted=0 OR [dbo].[PageModules].IsDeleted IS NULL) 
              
          ----    AND [dbo].[UserModules].IsActive=1 AND ([dbo].[UserModules].IsDeleted=0 OR [dbo].[UserModules].IsDeleted IS NULL)
               
          ----    AND ([dbo].[ModuleControls].[ControlType]= @ControlType 
          ----      OR  [dbo].[ModuleControls].[ControlType]=0)
                
                
          ----    AND [dbo].[UserModules].PortalID=@PortalID  
              
          ----    AND [dbo].[UserModules].AllPages=1 AND [dbo].[PageModules].IsActive=1 
                 
                
          ----    OR @PageID IN (
          ----          SELECT RTRIM(LTRIM(items)) 
          ----          FROM   Split([dbo].UserModules.[showinpages], ',') 
          ----          WHERE ([dbo].UserModules.isdeleted=0 OR [dbo].UserModules.isdeleted IS NULL) 
          ----          AND [dbo].[ModuleControls].[ControlType]= @ControlType
          ----        )
                    
                
                
                
                
          ----END
          ---- SELECT DISTINCT * FROM #TmpModules 
          ---- WHERE (PortalID=@PortalID OR PortalID=-1) --ORDER BY ModuleOrder ASC
          ---- DROP TABLE #TmpModules
           
                  
              
        
        
        
      END
   ELSE
   BEGIN
    SELECT cast(1 AS BIT) AS IsPageAvailable,cast(0 AS BIT) AS IsPageAccessible
   END
 END
 ELSE
  BEGIN
   SELECT cast(0 AS BIT) AS IsPageAvailable, cast(0 AS BIT) AS IsPageAccessible
  END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_ModuleManagerGetPageModules]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_ModuleManagerGetPageModules] (
 @PageID INT
 ,@PortalID INT
 ,@IsHandheld BIT
 )
AS
BEGIN
 DECLARE @IsAdmin BIT

 SELECT @IsAdmin = IsAdmin
 FROM [dbo].[PageMenu]
 WHERE PageID = @PageID;

 SELECT DISTINCT pm.pageid
  ,um.usermoduleid
  ,um.usermoduletitle
  ,um.seoname
  ,pm.pagemoduleid
  ,pm.panename
  ,pm.moduleorder
  ,pm.isactive
  ,um.allpages
  ,um.showinpages
  ,um.ModuleDefID
  ,(
   SELECT COUNT(ModuleControlID)
   FROM ModuleControls mc
   WHERE mc.ModuleDefID = um.ModuleDefID and  IsDeleted<>1
   ) AS ControlsCount
 FROM pages p
 INNER JOIN pagemodules pm ON p.pageid = pm.pageid
 INNER JOIN usermodules um ON pm.usermoduleid = um.usermoduleid
 INNER JOIN pagemenu pmenu ON p.pageid = pmenu.pageid
 WHERE (
   pm.portalid = @PortalID
   
   AND (
    ISNULL(um.IsHandheld, 0) = @IsHandheld
    AND (ISNULL(um.isdeleted, 0) = 0)
    )
   AND (
    (
     pmenu.isadmin = @IsAdmin
     AND um.allpages = 1
     OR @PageID IN (
      SELECT Rtrim(Ltrim(items))
      FROM Split(um.showinpages, ',')
      WHERE (isnull(um.isdeleted, 0) = 0)
      )
     )
    )
   OR (pm.pageid = @PageID)
   )
  AND ISNULL(pm.isdeleted, 0) = 0
  AND um.IsHandheld = @IsHandheld
 ORDER BY pm.moduleorder
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModulePermissionDelete]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserModulePermissionDelete] (
 @UserModuleID INT,
 @PortalID INT
) AS
BEGIN

SET nocount ON ; DELETE
FROM
 UserModulePermission
WHERE
 UserModuleID =@UserModuleID
AND PortalID =@PortalID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModuleIsEditAllowed]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserModuleIsEditAllowed] (
 @UserModuleID INT,
 @PortalID INT,
 @UserName NVARCHAR (250)
) AS
BEGIN
 SELECT
  COUNT (*) AS IsEdit
 FROM
  UserModulePermission ump
 INNER JOIN ModuledefPermission mdp ON ump.ModuledefPermissionId = mdp.ModuledefPermissionId
 AND ump.UserModuleID = @UserModuleID
 AND (
  (
   ump.RoleId IN (
    SELECT
     RoleId
    FROM
     dbo.aspnet_UsersInRoles
    INNER JOIN dbo.aspnet_Users ON dbo.aspnet_UsersInRoles.userid = dbo.aspnet_Users.UserId
    WHERE
     dbo.aspnet_users.UserName = @UserName
   )
  )
  OR ump.Username =@UserName
 )
 AND mdp.PermissionId = 2
 AND ump.PortalID =@PortalID
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModuleGetPermissions]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UserModuleGetPermissions]
( @UserModuleID INT,
 @PortalID INT) AS
BEGIN
 SELECT
  CAST (ump.RoleID AS NVARCHAR(200)) AS RoleID,
  ump.Username,
  ump.AllowAccess,
  mdp.PermissionID
 FROM
  dbo.UserModulePermission ump
 INNER JOIN ModuleDefPermission mdp ON ump.ModuleDefPermissionID = mdp.ModuleDefPermissionID
 WHERE
  ump.UserModuleID =@UserModuleID
 AND ump.PortalID =@PortalID
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModulesPermissionAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UserModulesPermissionAdd] 
(@ModuleDefID INT,
 @UserModuleID INT,
 @AllowAccess BIT,
 @RoleID NVARCHAR (100) = NULL,
 @UserName NVARCHAR (256) = NULL,
 @IsActive BIT,
 @AddedOn DATETIME,
 @PortalID INT,
 @AddedBy NVARCHAR (256),
 @PermissionID INT) AS
BEGIN
 DECLARE
  @ModuleDefPermissionID INT SELECT
   @ModuleDefPermissionID = ModuleDefPermissionID
  FROM
   ModuleDefPermission
  WHERE
   ModuleDefID =@ModuleDefID
  AND PermissionID =@PermissionID INSERT INTO dbo.UserModulePermission (
   [UserModuleID],
   [ModuleDefPermissionID],
   [AllowAccess],
   [RoleID],
   [Username],
   [IsActive],
   [AddedOn],
   [PortalID],
   [AddedBy]
  )
  VALUES
   (
    @UserModuleID,
    @ModuleDefPermissionID,
    @AllowAccess,
    @RoleID,
    @UserName,
    @IsActive,
    @AddedOn,
    @PortalID,
    @AddedBy
   )
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModulesInheritedPermissionAdd]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UserModulesInheritedPermissionAdd] (
 @ModuleDefID INT
 ,@UserModuleID INT
 ,@AllowAccess BIT
 ,@IsActive BIT
 ,@AddedOn DATETIME
 ,@PortalID INT
 ,@AddedBy NVARCHAR(256)
 ,@PageID INT
 )
AS
BEGIN
 DELETE
 FROM UserModulePermission
 WHERE UserModuleID = @UserModuleID

 CREATE TABLE #TablePermission (
  [UserModuleID] INT
  ,[ModuleDefPermissionID] INT
  ,[AllowAccess] BIT
  ,[RoleID] NVARCHAR(250)
  ,[Username] NVARCHAR(250)
  ,[IsActive] BIT
  ,[AddedOn] DATETIME
  ,[PortalID] INT
  ,[AddedBy] NVARCHAR(250)
  ,[PermissionID] INT
  )

 INSERT INTO #TablePermission
 SELECT @UserModuleID
  ,(
   SELECT ModuleDefPermissionID
   FROM ModuleDefPermission m
   WHERE m.ModuleDefID = @ModuleDefID
    AND m.PermissionID = pp.PermissionID
   ) AS ModuleDefPermissionID
  ,@AllowAccess
  ,[RoleID]
  ,[Username]
  ,@IsActive
  ,@AddedOn
  ,@PortalID
  ,@AddedBy
  ,pp.[PermissionID]
 FROM PagePermission pp
 WHERE pp.PageID = @PageID

 INSERT INTO dbo.UserModulePermission (
  [UserModuleID]
  ,[ModuleDefPermissionID]
  ,[AllowAccess]
  ,[RoleID]
  ,[Username]
  ,[IsActive]
  ,[AddedOn]
  ,[PortalID]
  ,[AddedBy]
  )
 SELECT [UserModuleID]
  ,[ModuleDefPermissionID]
  ,[AllowAccess]
  ,[RoleID]
  ,[Username]
  ,[IsActive]
  ,[AddedOn]
  ,1
  ,[AddedBy]
 FROM #TablePermission

 DROP TABLE #TablePermission
END
GO
/****** Object:  StoredProcedure [dbo].[usp_usermodulesgetpagemodules]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_usermodulesgetpagemodules] 
(@IsAdmin BIT) 
AS
BEGIN
 SELECT
  p.PageName,
  um.UserModuleTitle,
  um.UserModuleId
 FROM
  PageModules pm
 INNER JOIN UserModules um ON pm.UserModuleid = um.UserModuleId
 INNER JOIN Pages p ON pm.PageId = p.PageId
 INNER JOIN PageMenu pmenu ON p.PageId = pmenu.PageId
 WHERE
  pmenu.IsAdmin = @IsAdmin
 AND (
  um.IsDeleted IS NULL
  OR um.IsDeleted = 0
 )
 GROUP BY
  p.PageName,
  um.UserModuleTitle,
  um.UserModuleId
 ORDER BY
  p.Pagename ASC
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModulesGetDetails]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserModulesGetDetails] (
 @UserModuleID INT,
 @PortalID INT
) AS
BEGIN
 SELECT
  m.FriendlyName,
  pm.PaneName,
  pm.PageID,
  um.UserModuleID,
  um.UserModuleTitle,
  um.AllPages,
  um.SEOName,
  um.ShowInPages,
  um.IsHandheld,
  um.SuffixClass,
  um.HeaderText,
  um.IsActive,
  um.InheritViewPermissions,
  um.ShowHeaderText
 FROM
  UserModules um
 INNER JOIN ModuleDefinitions md ON um.ModuleDefID = md.ModuleDefID
 INNER JOIN Modules m ON md.ModuleID = m.ModuleID
 INNER JOIN PageModules pm ON um.UserModuleID = pm.UserModuleID
 WHERE
  um.UserModuleID =@UserModuleID
 AND um.PortalID =@PortalID 
 END
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModulesDelete]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[usp_UserModulesDelete] 141, 1, 'superuser'
   ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
 CREATE PROCEDURE [dbo].[usp_UserModulesDelete] 
   (@UserModuleID INT,
    @PortalID INT,
    @DeletedBy NVARCHAR (256))
 AS
 BEGIN
 DECLARE
  @PageID INT DECLARE
  @CurrentSortValue INT,
  @PaneName NVARCHAR (256)
  SELECT  @CurrentSortValue = [ModuleOrder] ,@PageID = PageID,
     @PaneName = PaneName
  FROM  [dbo].[PageModules]
  WHERE UserModuleID =@UserModuleID
  
  UPDATE [dbo].[UserModules] SET [IsDeleted] = 1, [DeletedOn] = getdate(),[DeletedBy] = @DeletedBy
  WHERE [UserModuleID] = @UserModuleID
  
  --UPDATE [dbo].[PageModules] SET ModuleOrder = 9999, [IsDeleted] = 1, [DeletedOn] = getdate(),[DeletedBy] = @DeletedBy 
  --WHERE [UserModuleID] = @UserModuleID
  
  INSERT INTO [PageModules_History]
  SELECT  Getdate(),'D',@DeletedBy,* FROM [dbo].[PageModules] WHERE [UserModuleID] = @UserModuleID;
  UPDATE [PageModules_History] SET [IsActive] =0 ,[IsDeleted] = 1  WHERE [UserModuleID] = @UserModuleID;

  DELETE FROM  PageModules WHERE  [UserModuleID] = @UserModuleID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetModulePermission]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FileManagerGetModulePermission] 
(
  @UserModuleID INT, 
  @UserName     NVARCHAR(256)
) 
AS 
  BEGIN      
      DECLARE @Count INT
      SELECT @Count = COUNT(*) 
      FROM   UserModules um 
             INNER JOIN UserModulePermission ump 
               ON ump.UserModuleID = um.UserModuleID 
      WHERE  um.UserModuleID = @UserModuleID 
             AND ump.Username = @UserName
     
      IF @Count <> 0 
        BEGIN 
            SELECT DISTINCT( ump.ModuleDefPermissionID ), 
                           p.PermissionKey 
            FROM   UserModules um 
                   INNER JOIN UserModulePermission ump 
                     ON ump.UserModuleID= um.UserModuleID 
                        AND ump.PortalID = um.PortalID 
                   INNER JOIN ModuleDefPermission mdp 
                     ON ump.ModuleDefPermissionID = mdp.ModuleDefPermissionID 
                   INNER JOIN Permission p 
                     ON mdp.PermissionID = p.PermissionID 
            WHERE  um.UserModuleID = @UserModuleID 
   AND ump.Username=@UserName
        END       
      ELSE 
        IF @Count = 0 
          BEGIN               
              DECLARE @RoleID UNIQUEIDENTIFIER
              SELECT @RoleID = aur.RoleId
              FROM   aspnet_users au 
                     INNER JOIN aspnet_usersinroles aur 
                       ON au.UserId = aur.UserId 
              WHERE  au.UserName = @UserName 
              DECLARE @RoleName NVARCHAR(200)
              SELECT @RoleName = loweredrolename 
              FROM   aspnet_roles 
              WHERE  RoleId = @RoleID
              IF @RoleName = 'super user' 
                BEGIN 
                    SELECT 'EDIT' AS PermissionKey 
                END 
              ELSE 
                BEGIN                           
                    SELECT DISTINCT( ump.ModuleDefPermissionID ), 
                                   p.PermissionKey 
                    FROM   UserModules um 
                           INNER JOIN UserModulePermission ump 
                             ON ump.UserModuleID = um.UserModuleID 
                                AND ump.PortalID = um.PortalID
                           INNER JOIN ModuleDefPermission mdp 
                             ON ump.ModuleDefPermissionID = 
                                mdp.ModuleDefPermissionID 
                           INNER JOIN Permission p 
                             ON mdp.PermissionID = p.PermissionID 
                    WHERE  um.UserModuleID = @UserModuleID 
                           AND ump.RoleID = @RoleID 
                END 
          END 
  END;
GO
/****** Object:  UserDefinedFunction [dbo].[fn_EditPermissionExists]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_EditPermissionExists] 
(
 @UserName nvarchar(250),
 @UserModuleID int
 
)
RETURNS int
AS
BEGIN
 DECLARE @ReturnValue int
 
 SELECT @ReturnValue=COUNT(*) 
 FROM   usermodulepermission ump 
       INNER JOIN moduledefpermission mdp 
         ON ump.moduledefpermissionid = mdp.moduledefpermissionid 
            AND ump.usermoduleid = @UserModuleID
            AND ump.roleid IN (SELECT roleid 
                               FROM   dbo.aspnet_usersinroles 
                                      INNER JOIN dbo.aspnet_users 
                                        ON dbo.aspnet_usersinroles.userid = 
                                           dbo.aspnet_users.userid 
                               WHERE  dbo.aspnet_users.username = @UserName) 
            AND mdp.permissionid = 2 
    IF @ReturnValue=1  
  SET @ReturnValue=1
 ELSE IF @ReturnValue>1
  SET @ReturnValue=1

 RETURN @ReturnValue

END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_A]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[fn_A]
(
 @Level int
)
RETURNS bit
AS
BEGIN
 DECLARE @ReturnValue bit
 IF(Exists(Select * From dbo.PageModules Where dbo.PageModules.UserModuleID In (Select top 1 ModuleDefID from dbo.ModuleDefinitions Where dbo.ModuleDefinitions.ModuleID = @Level)))
  Begin
   set @ReturnValue = 1
  End
 Else
   Begin
    set @ReturnValue = 0
   End
 RETURN @ReturnValue

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUserModulePermissionByPermissionKeyADO]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CheckUserModulePermissionByPermissionKeyADO]
@PermissionKey NVARCHAR(100),
@UserModuleID  [INT],
@UserName      [NVARCHAR](256),
@PortalID      [INT]
WITH EXECUTE AS caller
AS
  BEGIN
      IF( EXISTS(SELECT *
                 FROM   moduledefpermission mdf
                        INNER JOIN permission p
                                ON mdf.permissionid = p.permissionid
                        INNER JOIN usermodulepermission ump
                                ON
                        ump.moduledefpermissionid = mdf.moduledefpermissionid
                        AND usermoduleid = @UserModuleID
                 WHERE  LOWER(p.permissionkey) = LOWER(@PermissionKey)
                        AND mdf.moduledefid IN (SELECT moduledefid
                                                FROM   usermodules
                                                WHERE
                            usermoduleid = @UserModuleID)
                        AND ( ump.portalid = @PortalID )
                        AND ump.isactive = 1
                        AND ( ump.isdeleted = 0
                               OR ump.isdeleted IS NULL )
                        AND ( ump.username = @UserName
                               OR ump.roleid IN (SELECT uinr.roleid
                                                 FROM   aspnet_users u
                                  INNER JOIN aspnet_usersinroles
                                             uinr
                                          ON
                                  u.userid = uinr.userid
                                                 WHERE  u.username = @UserName)
                            ))
        )
        BEGIN
            SELECT CONVERT(BIT, 1)
        END
      ELSE
        BEGIN
            SELECT CONVERT(BIT, 0)
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckUserModulePermissionByPermissionKey]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CReateD DAte: 2010-03-29
CREATE PROCEDURE [dbo].[sp_CheckUserModulePermissionByPermissionKey]
@PermissionKey NVARCHAR(100),
@UserModuleID  [INT],
@UserName      [NVARCHAR](256),
@PortalID      [INT]
WITH EXECUTE AS caller
AS
  BEGIN
      IF( EXISTS(SELECT *
                 FROM   moduledefpermission mdf
                        INNER JOIN permission p
                                ON mdf.permissionid = p.permissionid
                        INNER JOIN usermodulepermission ump
                                ON
                        ump.moduledefpermissionid = mdf.moduledefpermissionid
                        AND usermoduleid = @UserModuleID
                 WHERE  LOWER(p.permissionkey) = LOWER(@PermissionKey)
                        AND mdf.moduledefid IN (SELECT moduledefid
                                                FROM   usermodules
                                                WHERE
                            usermoduleid = @UserModuleID)
                        AND ( ump.portalid = @PortalID )
                        AND ump.isactive = 1
                        AND ( ump.isdeleted = 0
                               OR ump.isdeleted IS NULL )
                        AND ( ump.username = @UserName
                               OR ump.roleid IN (SELECT uinr.roleid
                                                 FROM   aspnet_users u
                                  INNER JOIN aspnet_usersinroles
                                             uinr
                                          ON
                                  u.userid = uinr.userid
                                                 WHERE  u.username = @UserName)
                            ))
        )
        BEGIN
            RETURN CONVERT(BIT, 1)
        END
      ELSE
        BEGIN
            RETURN CONVERT(BIT, 0)
        END
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_FileManagerGetFolderPermissionByUserID]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_FileManagerGetFolderPermissionByUserID]
(
@FolderID INT,
@UserID INT,
@UserModuleID INT,
@UserName NVARCHAR(256)
)
AS
BEGIN
DECLARE @Count INT
SELECT @Count = COUNT(p.PermissionKey) 
FROM   FolderPermission fp 
       INNER JOIN Permission p 
         ON fp.PermissionID = p.PermissionID
WHERE  fp.FolderID = @FolderID 
       AND fp.UserID = @UserID 
 
IF @Count <> 0 
  BEGIN     
      SELECT p.PermissionKey 
      FROM   FolderPermission fp 
             INNER JOIN Permission p 
               ON fp.PermissionID = p.PermissionID 
      WHERE  fp.FolderID = @FolderID 
             AND fp.UserID = @UserID 
  END 
ELSE 
  IF @Count = 0 
    BEGIN        
        DECLARE @RoleID UNIQUEIDENTIFIER
        SELECT @RoleID = aur.RoleId
        FROM   aspnet_users au 
               INNER JOIN aspnet_usersinroles aur 
                 ON au.UserId = aur.UserId
        WHERE  au.UserName = @UserName    
    
 DECLARE @RoleName NVARCHAR(200)
 SELECT @RoleName=LoweredRoleName FROM aspnet_Roles WHERE RoleID=@RoleID
 IF @RoleName='superuser' OR @RoleName='siteadmin'
     BEGIN
      SELECT 'EDIT' AS PermissionKey
     END
 ELSE
    BEGIN             
     DECLARE @Count2 INT
            SELECT @Count2=COUNT(p.PermissionKey) 
            FROM   FolderPermission fp 
            INNER JOIN Permission p 
            ON fp.PermissionID = p.PermissionID
            WHERE  fp.FolderID = @FolderID 
            AND fp.RoleID= @RoleID   
     IF @Count2<>0
       BEGIN
  SELECT p.PermissionKey
  FROM   FolderPermission fp 
                INNER JOIN Permission p 
                ON fp.PermissionID = p.PermissionID
  WHERE  fp.FolderID = @FolderID 
                AND fp.RoleID = @RoleID 
       END
     ELSE IF @Count2=0
       BEGIN
  EXEC [usp_FileManagerGetModulePermission] @UserModuleID,@UserName
       END
   END
    END 
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_UserModules_Add]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_UserModules_Add] 
(@ModuleDefID            INT, 
                                 @UserModuleTitle        NVARCHAR(256), 
                                 @AllPages               BIT, 
                                 @ShowInPages            NVARCHAR(256), 
                                 @InheritViewPermissions BIT, 
                                 @Header                 NTEXT, 
                                 @Footer                 NTEXT, 
                                 @StartDate              DATETIME, 
                                 @EndDate                DATETIME, 
                                 @SEOName                NVARCHAR(100), 
                                 @UserModulePermissionID INT OUTPUT, 
                                 @AllowAccess            BIT, 
                                 @RoleID                 UNIQUEIDENTIFIER, 
                                 @UserName               NVARCHAR(256), 
                                 @PageID                 INT, 
                                 @PaneName               NVARCHAR(50), 
                                 @ModuleOrder            INT, 
                                 @CacheTime              INT, 
                                 @Alignment              NVARCHAR(50), 
                                 @Color                  NVARCHAR(20), 
                                 @Border                 NVARCHAR(1), 
                                 @IconFile               NVARCHAR(100), 
                                 @Visibility             INT, 
                                 @DisplayTitle           BIT, 
                                 @DisplayPrint           BIT, 
                                 @IsActive               BIT, 
                                 @AddedOn                DATETIME, 
                                 @PortalID               INT, 
                                 @AddedBy                NVARCHAR(256), 
                                 @ErrorCode              INT OUTPUT) 
AS 
  BEGIN 
      DECLARE @TranStarted BIT 

      SET @TranStarted = 0 

      DECLARE @UserModuleID INT 

      --Begin Transaction 
      IF( @@TRANCOUNT = 0 ) 
        BEGIN 
            BEGIN TRANSACTION 

            SET @TranStarted = 1 
        END 
      ELSE 
        SET @TranStarted = 0 

      --Add User Modules First 
      EXEC [dbo].[usp_UserModulesAdd] 

      IF( @@ERROR <> 0 ) 
        BEGIN 
            SET @ErrorCode = 1 

            GOTO CLEANUP 
        END 

      SET @UserModuleID=SCOPE_IDENTITY() 

      --Add Module Permissions 
      EXEC [dbo].[usp_UserModulesPermissionAdd] 

      IF( @@ERROR <> 0 ) 
        BEGIN 
            SET @ErrorCode = 2 

            GOTO CLEANUP 
        END 

      --Add Page Modules 
      EXEC [dbo].[usp_PageModulesAdd] 

      IF( @@ERROR <> 0 ) 
        BEGIN 
            SET @ErrorCode = 3 

            GOTO CLEANUP 
        END 

      --Cleanup errors encountered 
      CLEANUP: 

      IF( @TranStarted = 1 ) 
        BEGIN 
            SET @TranStarted = 0 

            ROLLBACK TRANSACTION 
        END 

      RETURN @ErrorCode 
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_MasterPageGetPageModulesAdmin]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[dbo].[usp_MasterPageGetPageModules] 1,'Admin',1,'superuser'
CREATE PROCEDURE [dbo].[usp_MasterPageGetPageModulesAdmin]
 @ControlType [int],
 @PageSEOName [nvarchar](1000),
 @PortalID [int],
 @UserName [nvarchar](256),
@IsPreview bit,
@PreviewCode nvarchar(256)
WITH EXECUTE AS CALLER
AS
BEGIN
SET NOCOUNT ON;
-----------------------------------------------------------
--Declare All Variables Here
-----------------------------------------------------------
DECLARE @IsPageAvailable bit,@IsPageAccessible bit,@PageID int
DECLARE @AllowPreview BIT
  
SET @AllowPreview  = 0 
-----------------------------------------------------------
--Get PageID From PageSEOName
-----------------------------------------------------------
SELECT @PageID=PageID FROM Pages WHERE SEOName=@PageSEOName AND (PortalID=@PortalID OR PortalID=-1)


--------------------------------------------------------------------------------------
IF EXISTS(SELECT PageID FROM PagePreview WHERE PreviewCode = @PreviewCode and PageID =  @PageID) and (@IsPreview = 1)  
 SET @AllowPreview = 1
 
 -----------------------------------------------------------
--Check If the User Has Access To the Page
-----------------------------------------------------------

--SET @IsPageAvailable = 0

 IF(@IsPreview=1)
 BEGIN
   IF(@AllowPreview=1)
     BEGIN
      IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID)     
       SET @IsPageAvailable=1
     END
    ELSE
     BEGIN
      IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID and IsVisible=1)
        SET @IsPageAvailable = 1
      ELSE
       SET @IsPageAvailable=0
      END
    END
 ELSE
  BEGIN
   IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID and IsVisible=1)
    SET @IsPageAvailable=1
   ELSE
    SET @IsPageAvailable=0   
  END
-----------------------------------------------------------
--Check If the User Has Access To the Page
-----------------------------------------------------------
IF EXISTS(SELECT [dbo].[Pages].* 
FROM   [dbo].[Pages] 
       INNER JOIN [dbo].[PagePermission] 
         ON [dbo].[PagePermission].pageid = [dbo].[Pages].pageid 
WHERE  ( [dbo].[PagePermission].[RoleID] IN (SELECT 
         [dbo].[aspnet_UsersInRoles].roleid 
                                             FROM   [dbo].[aspnet_UsersInRoles] 
         INNER JOIN [dbo].[aspnet_Users] 
           ON 
                  [dbo].[aspnet_Users].userid = 
                  [dbo].[aspnet_UsersInRoles].userid 
                                             WHERE 
                  [dbo].[aspnet_Users].username = @UserName 
                                             UNION ALL 
                                             SELECT [RoleId] 
                                             FROM   dbo.aspnet_roles 
                                             WHERE 
         loweredrolename = 'anonymous user') 
          OR [dbo].[PagePermission].username = @UserName ) 
       AND [dbo].[Pages].seoname = @PageSEOName 
       AND ( [dbo].[Pages].[IsDeleted] = 0 
              OR [dbo].[Pages].[IsDeleted] IS NULL ) 
       AND ( [dbo].[Pages].portalid = @PortalID 
              OR [dbo].[Pages].portalid = -1 ) 
       AND ( [dbo].[PagePermission].[IsDeleted] = 0 
              OR [dbo].[PagePermission].[IsDeleted] IS NULL ) )
BEGIN
SET @IsPageAccessible=1
END
-----------------------------------------------------------
--Create the PageDetails Table
-----------------------------------------------------------
DECLARE @Title nvarchar(250),@RefreshInterval nvarchar(250),@Description nvarchar(500),@KeyWords nvarchar(500)
SELECT @Title=p.Title,@RefreshInterval=CAST(p.RefreshInterval AS nvarchar),@Description=p.Description,@KeyWords=p.KeyWords 
FROM   pages p
WHERE  p.seoname = @PageSEOName
       AND (p.portalid = @PortalID  OR p.PortalID=-1)

-----------------------------------------------------------
--Get The List Of Page Modules By PageSEOName and Portal ID
-----------------------------------------------------------
SELECT DISTINCT @IsPageAvailable AS IsPageAvailable,@IsPageAccessible AS IsPageAccessible,v.PageID,v.usermoduleid,v.panename, 
       v.moduleorder, 
       v.ishandheld, 
       v.suffixclass, 
       v.showheadertext, 
       v.headertext ,
    v.ControlSrc,
    v.SupportsPartialRendering,
    --RoleID,
    v.ControlsCount,
v.PortalID,
    (select
    COUNT(*) as IsEdit 
 FROM   usermodulepermission ump 
       INNER JOIN moduledefpermission mdp 
         ON ump.moduledefpermissionid = mdp.moduledefpermissionid 
            AND ump.usermoduleid = v.UserModuleID
            AND ((ump.roleid IN (SELECT roleid 
                               FROM   dbo.aspnet_usersinroles 
                                      INNER JOIN dbo.aspnet_users 
                                        ON dbo.aspnet_usersinroles.userid = 
                                           dbo.aspnet_users.userid 
                               WHERE  dbo.aspnet_users.username = @UserName)) OR ump.username=@UserName)
            AND mdp.permissionid = 2  and ump.PortalID=@PortalID ) AS IsEdit,
  @Title AS Title,
  @RefreshInterval AS RefreshInterval,
  @Description AS [Description],
  @KeyWords AS KeyWords,
     v.usermoduletitle as UserModuleTitle       
 FROM   vw_PageUserModules v 
 WHERE  ((v.[RoleID] IN (SELECT 
         [dbo].[aspnet_UsersInRoles].roleid 
                                             FROM   [dbo].[aspnet_UsersInRoles] 
         INNER JOIN [dbo].[aspnet_Users] 
           ON 
                  [dbo].[aspnet_Users].userid = 
                  [dbo].[aspnet_UsersInRoles].userid 
                                             WHERE 
                  [dbo].[aspnet_Users].username = @UserName 
                                             UNION ALL 
                                             SELECT [RoleId] 
                                             FROM   dbo.aspnet_roles 
                                             WHERE 
         loweredrolename = 'anonymous user') 
          OR v.username = @UserName)) 
      
AND  ((v.PageID = @PageID) OR(v.AllPages=1)
 or( @PageID IN (SELECT Rtrim(Ltrim(items)) 
            FROM   Split(v.showinpages, ',') WHERE (v.isdeleted=0 or v.IsDeleted is null )))
               )
       AND (v.portalid = 1 or v.portalid=-1)

and v.ControlType=1
and (v.IsDeleted=0 or v.IsDeleted is null)
and v.IsActive=1 
order by v.moduleorder asc


END
GO
/****** Object:  StoredProcedure [dbo].[usp_MasterPageGetPageModules_Superuser]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec usp_MasterPageGetPageModules_Superuser 1,'Home',1,'superuser','en-us',0,'none'
CREATE PROCEDURE [dbo].[usp_MasterPageGetPageModules_Superuser] 
   @CONtrolType [INT],
   @PageSEOName [NVARCHAR](1000),
   @PortalID [INT],
   @UserName [NVARCHAR](256),
   @CultureCode [NVARCHAR](100),
   @IsPreview bit,
   @PreviewCode nvarchar(256)
WITH EXECUTE AS CALLER
AS
BEGIN
SET NOCOUNT ON;
DECLARE @temprole TABLE ( roleid NVARCHAR(250), username NVARCHAR(50))

-----------------------------------------------------------
--Declare All Variables Here
-----------------------------------------------------------
DECLARE @IsPageAvailable BIT,@IsPageAccessible BIT,@PageID INT

DECLARE @AllowPreview BIT
DECLARE @IsModuleEdit BIT 
  
SET @AllowPreview  = 0 

SET @IsModuleEdit  = 1

-----------------------------------------------------------
--Get PageID From PageSEOName
-----------------------------------------------------------
SELECT @PageID=PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID and IsActive = 1 and Isdeleted = 0

--------------------------------------------------------------------------------------
IF EXISTS(SELECT PageID FROM PagePreview WHERE PreviewCode = @PreviewCode and PageID =  @PageID) and (@IsPreview = 1)  
 SET @AllowPreview = 1
--------------------------------------------------------------------------------------
INSERT INTO @temprole 
SELECT  [dbo].[aspnet_UsersInRoles].roleid, [dbo].[aspnet_Users].username
FROM         [dbo].[aspnet_UsersInRoles] INNER JOIN
    [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].userid = [dbo].[aspnet_UsersInRoles].userid
WHERE     [dbo].[aspnet_Users].LoweredUserName = 'superuser'

-----------------------------------------------------------





------------------------------------------------------------------------------------------------------------------------------------------------
---To check if modules are editable or not according to user role, The following is commented as superuser can edit all the modules so no need
 -- to check if particular module is editable or not Dec 3rd 2013 -------


--IF EXISTS(SELECT 1  FROM   usermodulepermissiON ump 
--    LEFT JOIN    moduledefpermissiON mdp  ON ump.moduledefpermissiONid = mdp.moduledefpermissiONid 
--    WHERE
--         ump.roleid IN (SELECT roleid From @temprole where username=@UserName) AND ump.PortalID = @PortalID
--     AND mdp.permissiONid = 2)
--BEGIN 
-- SET @IsModuleEdit =1 
--END

------------------------------------------------------------------------------------------------------------------------------------------- 


-----------------------------------------------------------
--Check If the User Has Access To the Page
-----------------------------------------------------------

--SET @IsPageAvailable = 0

 IF(@IsPreview=1)
 BEGIN
   IF(@AllowPreview=1)
     BEGIN
      IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID)     
       SET @IsPageAvailable=1
     END
    ELSE
     BEGIN
      IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID and IsVisible=1)
        SET @IsPageAvailable = 1
      ELSE
       SET @IsPageAvailable=0
      END
    END
 ELSE
  BEGIN
   IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID and IsVisible=1)
    SET @IsPageAvailable=1
   ELSE
    SET @IsPageAvailable=0
   
  END
  

  
------------------------------------------------------------------------------------------------------------------------------------------------
 -- @IsPageAccessible is set to 1 as superuser can access all the modules so no need to check if particular page is access or not Dec 3rd 2013 -------
 ------------------------------------------------------------------------------------------------------------------------------------------------

 SET @IsPageAccessible=1 

 ------------------------------------------------------------------------------------------------------------------------------------------------

  ----IF(EXISTS(
  ----      SELECT p.PageID
  ----  FROM dbo.Pages p
  ----  INNER join dbo.PagePermission pm on pm.PageID=p.PageID
  ----  inner join dbo.aspnet_UsersInRoles uir on uir.RoleId=pm.RoleID
  ----  Inner join dbo.aspnet_Users u on u.UserId=uir.UserId
  ----  WHERE pm.RoleID='cd3ca2e2-7120-44ad-a520-394e76aac552' 
  ----  and  u.UserName='superuser'
  ----   AND p.PageID = @PageID
  ----    AND ( p.portalid = @PortalID OR p.portalid = -1 ) 
  ----                      AND  ISNULL(pm.IsDeleted,0)=0 
  ----                      AND ISNULL(p.IsDeleted,0)=0  ))

                       
  ----     BEGIN 
  ----          SET @IsPageAccessible=1 
  ----END 
-----------------------------------------------------------
--Create the PageDetails Table
-----------------------------------------------------------
DECLARE @Title NVARCHAR(250),@RefreshINTerval NVARCHAR(250),@DescriptiON NVARCHAR(500),@KeyWords NVARCHAR(500)
SELECT @Title=p.Title,@RefreshINTerval=CAST(p.RefreshINTerval AS NVARCHAR),@DescriptiON=p.DescriptiON,@KeyWords=p.KeyWords 
FROM   pages p
WHERE  p.PageID = @PageID
       AND p.portalid = @PortalID 
-----------------------------------------------------------
--Get The List Of Page Modules BY PageSEOName AND Portal ID 
-----------------------------------------------------------
SELECT DISTINCT @IsPageAvailable AS IsPageAvailable,@IsPageAccessible AS IsPageAccessible,v.PageID,v.usermoduleid,v.panename, 
       v.moduleORDER, 
       v.ishANDheld, 
       v.suffixclass, 
       v.showheadertext, 
       ISNULL(lmt.LocalModuleTitle,v.HeaderText) as headertext, 
    v.CONtrolSrc,
    v.SupportsPartialRENDering,
    --RoleID,
    v.CONtrolsCount,
    v.PortalID,
    @IsModuleEdit  AS IsEdit,
  -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- 
  ---This logic is absolute --  and no more in use
   -- (SELECT count (ump.UserModulePermissionID)
    --FROM   usermodulepermissiON ump 
    -- LEFT JOIN moduledefpermissiON mdp  ON ump.moduledefpermissiONid = mdp.moduledefpermissiONid 
    --       AND ump.usermoduleid = v.UserModuleID
    --       AND ((ump.roleid IN (SELECT roleid From @temprole where username=@UserName)) 
    --        OR ump.username=@UserName)
    --      AND mdp.permissiONid = 2 
    --      AND ump.PortalID=@PortalID
  --) AS IsEdit,
  -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- 
    
  @Title AS Title,
  @RefreshINTerval AS RefreshINTerval,
  @DescriptiON AS [DescriptiON],
  @KeyWords AS KeyWords,
     v.usermoduletitle as UserModuleTitle       
 FROM   vw_PageUserModules v 
 left join dbo.LocalModuleTitle lmt on lmt.UserModuleID=v.UserModuleID and  lmt.CultureCode=@CultureCode
  WHERE  ( v.username = @UserName or
   v.RoleID='cd3ca2e2-7120-44ad-a520-394e76aac552' ) 
             AND ( ( v.pageid = @PageID ) 
                    OR ( v.allpages = 1 ) 
                    OR ( @PageID = (SELECT Rtrim(Ltrim(SplittedValue)) 
                                    FROM   UDFsplit(v.showinpages, ',') 
                                    WHERE  SplittedValue = @PageID 
                                          
                                                  ) ) ) 
             AND v.portalid = @PortalID 
             AND v.controltype = 1 
             AND v.isactive = 1 
      ORDER  BY v.moduleorder ASC 


END
GO
/****** Object:  StoredProcedure [dbo].[usp_MasterPageGetPageModules_Anonymous]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_MasterPageGetPageModules_Anonymous] 
@ControlType [INT], 
@PageSEOName [NVARCHAR](1000), 
@PortalID [INT], 
@UserName [NVARCHAR](256) ,
@CultureCode NVARCHAR(100)
WITH EXECUTE AS caller 
AS 
  BEGIN 
      SET nocount ON; 
     
      DECLARE @IsPageAvailable  BIT, 
              @IsPageAccessible BIT, 
              @PageID           INT 

      ----------------------------------------------------------- 
      --Get PageID From PageSEOName 
      ----------------------------------------------------------- 
      SELECT @PageID = pageid 
      FROM   pages 
      WHERE  seoname = @PageSEOName 
             AND portalid = @PortalID 
             and IsActive = 1 and Isdeleted = 0

      ----------------------------------------------------------- 
      --Check If the User Has Access To the Page 
      ----------------------------------------------------------- 
      IF EXISTS(SELECT pageid 
                FROM   pages 
                WHERE  seoname = @PageSEOName 
                       AND portalid = @PortalID) 
        BEGIN 
            SET @IsPageAvailable=1 
        END 
      
        IF(Exists(
        select p.PageID
    FROM dbo.Pages p
    INNER join dbo.PagePermission pm on pm.PageID=p.PageID
    inner join dbo.aspnet_UsersInRoles uir on uir.RoleId=pm.RoleID
    Inner join dbo.aspnet_Users u on u.UserId=uir.UserId
    where pm.RoleID='A87E850F-14C8-4C89-86F4-4598FF27DA72' 
    and  u.UserName='anonymoususer'
     AND p.seoname = @PageSEOName 
     AND p.IsVisible = 1
                       AND  isnull(p.[isdeleted],0) = 0 
                       AND ( p.portalid = @PortalID 
                              OR p.portalid = -1 ) 
                       AND isnull(pm.[isdeleted],0) = 0  ))

        BEGIN 
            SET @IsPageAccessible=1 
        END 

      ----------------------------------------------------------- 
      --Create the PageDetails Table 
      ----------------------------------------------------------- 
      DECLARE @Title           NVARCHAR(250), 
              @RefreshInterval NVARCHAR(250), 
              @Description     NVARCHAR(500), 
              @KeyWords        NVARCHAR(500) 

      SELECT @Title = p.title, 
             @RefreshInterval = Cast(p.refreshinterval AS NVARCHAR), 
             @Description = p.description, 
             @KeyWords = p.keywords 
      FROM   pages p 
      WHERE  p.seoname = @PageSEOName 
             AND p.portalid = @PortalID 
             and IsActive = 1 and Isdeleted = 0

      
      SELECT DISTINCT @IsPageAvailable  AS IsPageAvailable, 
                      @IsPageAccessible AS IsPageAccessible, 
                      v.pageid, 
                      v.usermoduleid, 
                      v.panename, 
                      v.moduleorder, 
                      v.ishandheld, 
                      v.suffixclass, 
                      v.showheadertext, 
                      ISNULL(lmt.LocalModuleTitle,v.HeaderText) as headertext, 
      
                      v.controlsrc, 
                      v.supportspartialrendering, 
                      v.controlscount, 
                      v.portalid, 
                      0                 AS IsEdit, 
                      @Title            AS Title, 
                      @RefreshInterval  AS RefreshInterval, 
                      @Description      AS [Description], 
                      @KeyWords         AS KeyWords, 
                      v.usermoduletitle AS UserModuleTitle 
      FROM   vw_PageUserModules v
      left join dbo.LocalModuleTitle lmt on lmt.UserModuleID=v.UserModuleID and  lmt.CultureCode=@CultureCode 
      WHERE  ( v.username = @UserName or
   v.RoleID='A87E850F-14C8-4C89-86F4-4598FF27DA72' ) 
    AND ( ( v.pageid = @PageID ) 
                    OR ( v.allpages = 1 ) 
                    OR ( @PageID = (SELECT SplittedValue 
                                    FROM   UDFSplit(v.showinpages, ',') 
                                    WHERE  SplittedValue = @PageID 
                                          
                                                  ) ) ) 
            
             AND v.portalid = @PortalID 
             AND v.controltype = 1 
             AND v.isactive = 1 
      ORDER  BY v.moduleorder ASC 
  END
GO
/****** Object:  StoredProcedure [dbo].[usp_MasterPageGetPageModules]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[usp_MasterPageGetPageModules1] 1, 'footercontent', 1, 'Edge', 'en-US', 0, 'sfXHL123' 
--select * from portal
--[dbo].[usp_MasterPageGetPageModules1] 1,'Home',1,'Edge'
--[dbo].[usp_MasterPageGetPageModules1] 1,'Menu',1,'Edge'
----[usp_MasterPageGetPageModules] 1, 'menu', 1, 'Edge', 'en-US', 0, 'sfXHL123'
CREATE PROCEDURE [dbo].[usp_MasterPageGetPageModules] 
 @ControlType [int]
 ,@PageSEOName [nvarchar] (1000)
 ,@PortalID [int]
 ,@Username [nvarchar] (256)
 ,@CultureCode[NVARCHAR](100)
 ,@IsPreview bit
 ,@PreviewCode nvarchar(256)
 WITH EXECUTE AS CALLER
AS
BEGIN
 SET NOCOUNT ON;

 -----------------------------------------------------------
 --Declare All Variables Here
 -----------------------------------------------------------
 DECLARE @IsPageAvailable BIT
 DECLARE @IsPageAccessible BIT = 0
 DECLARE @PageID INT
 DECLARE @AllowPreview bit
 DECLARE @IsModuleEdit BIT
 
 SET @AllowPreview=0 
 SET @IsModuleEdit = 0 

 -----------------------------------------------------------
 --Get PageID From PageSEOName
 -----------------------------------------------------------
 SELECT @PageID = PageID
 FROM Pages
 WHERE SEOName = @PageSEOName  AND PortalID = @PortalID  and IsActive = 1 and Isdeleted = 0

 -----------------------------------------------------------
 --Check for page review
 -----------------------------------------------------------

 IF EXISTS( SELECT PageID FROM PagePreview WHERE PreviewCode = @PreviewCode and PageID =  @PageID) and (@IsPreview = 1)  
   SET @AllowPreview=1
   
   
 IF(@IsPreview=1)
 BEGIN
  IF(@AllowPreview=1)
   BEGIN
    IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID)     
     SET @IsPageAvailable=1
   END
  ELSE
   BEGIN
    IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID and IsVisible=1)
      SET @IsPageAvailable = 1
    ELSE
     SET @IsPageAvailable=0
   END
 END
 ELSE
 BEGIN
  IF EXISTS(SELECT PageID FROM Pages WHERE SEOName=@PageSEOName AND PortalID=@PortalID and IsVisible=1)
   SET @IsPageAvailable=1
  ELSE
   SET @IsPageAvailable=0
  
 END  
   
 DECLARE @temprole TABLE
 (   roleID NVARCHAR(250), username NVARCHAR(50), UNIQUE NONCLUSTERED (roleid,username) )

 INSERT INTO @temprole
 SELECT [dbo].[aspnet_UsersInRoles].roleid  , [dbo].[aspnet_Users].username
     FROM [dbo].[aspnet_UsersInRoles]
     INNER JOIN [dbo].[aspnet_Users] ON [dbo].[aspnet_Users].userid = [dbo].[aspnet_UsersInRoles].userid
     WHERE [dbo].[aspnet_Users].username = @Username
     
 UNION ALL
     
 SELECT [RoleId],'anonymoususer'
 FROM dbo.aspnet_roles
 WHERE loweredrolename = 'anonymous user'


 -----------------------------------------------------------
 --Check If the User Has Access To the Page
 -----------------------------------------------------------
 IF EXISTS (
   SELECT PageID
   FROM Pages
   WHERE SEOName = @PageSEOName
    AND PortalID = @PortalID
   )
 BEGIN
  SET @IsPageAvailable = 1
 END

 IF EXISTS (
   SELECT [dbo].[Pages].PageID
   FROM [dbo].[Pages]
   INNER JOIN [dbo].[PagePermission] ON [dbo].[PagePermission].pageid = [dbo].[Pages].pageid
   WHERE (
     [dbo].[PagePermission].[RoleID] IN (  SELECT RoleID FROM @temprole)      
     OR [dbo].[PagePermission].username = @Username
     )
    AND [dbo].[Pages].seoname = @PageSEOName
    AND (
     [dbo].[Pages].[IsDeleted] = 0
     OR [dbo].[Pages].[IsDeleted] IS NULL
     )
    AND (
     [dbo].[Pages].portalid = @PortalID
     OR [dbo].[Pages].portalid = - 1
     )
    AND (
     [dbo].[PagePermission].[IsDeleted] = 0
     OR [dbo].[PagePermission].[IsDeleted] IS NULL
     )
   )
 BEGIN
  SET @IsPageAccessible = 1
 END

 -----------------------------------------------------------
 --Create the PageDetails Table
 -----------------------------------------------------------
 DECLARE @Title NVARCHAR(250)
  ,@RefreshInterval NVARCHAR(250)
  ,@Description NVARCHAR(500)
  ,@KeyWords NVARCHAR(500)

 SELECT @Title = p.Title
  ,@RefreshInterval = CAST(p.RefreshInterval AS NVARCHAR)
  ,@Description = p.Description
  ,@KeyWords = p.KeyWords
 FROM pages p
 WHERE p.seoname = @PageSEOName
  AND p.portalid = @PortalID

 -----------------------------------------------------------
 --Get The List Of Page Modules By PageSEOName and Portal ID
 -----------------------------------------------------------
 SELECT DISTINCT @IsPageAvailable AS IsPageAvailable
  ,@IsPageAccessible AS IsPageAccessible
  ,v.PageID
  ,v.usermoduleid
  ,v.panename
  ,v.moduleorder
  ,v.ishandheld
  ,v.suffixclass
  ,v.showheadertext
  ,v.headertext
  ,v.ControlSrc
  ,v.SupportsPartialRendering
  ,
  --RoleID,
  v.ControlsCount
  ,v.PortalID
  ,(
   SELECT COUNT(1) AS IsEdit
   FROM usermodulepermission ump
   INNER JOIN moduledefpermission mdp ON ump.moduledefpermissionid = mdp.moduledefpermissionid
    AND ump.usermoduleid = v.UserModuleID
    AND (
     (
      ump.roleid IN ( SELECT roleid FROM @temprole WHERE username =   @Username)       
      )
     OR ump.username = @Username
     )
    AND mdp.permissionid = 2
    AND ump.PortalID = @PortalID
   ) AS IsEdit
  ,@Title AS Title
  ,@RefreshInterval AS RefreshInterval
  ,@Description AS [Description]
  ,@KeyWords AS KeyWords
  ,v.usermoduletitle AS UserModuleTitle
 FROM vw_PageUserModules v
 WHERE (
   (
    v.[RoleID] IN (  SELECT RoleID FROM @temprole)    
    OR v.username = @Username
    )
   )
  AND (
   (v.PageID = @PageID)
   OR (v.AllPages = 1)
   OR (
    @PageID IN (
    SELECT SplittedValue  FROM   UDFSplit(v.showinpages, ',')     
     WHERE (
       v.isdeleted = 0
       OR v.IsDeleted IS NULL
       )
     )
    )
   )
  AND v.portalid = @PortalID
  AND v.ControlType = 1
  AND (
   v.IsDeleted = 0
   OR v.IsDeleted IS NULL
   )
  AND v.IsActive = 1
 ORDER BY v.moduleorder ASC
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPageSettingByPageSEOName]    Script Date: 12/29/2014 16:38:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetPageSettingByPageSEOName]
 @ControlType INT,
 @PageSEOName NVARCHAR(1000),
 @PortalID INT,
 @UserName NVARCHAR(256)
WITH EXECUTE AS CALLER
AS
BEGIN
DECLARE @IsPageAvailable BIT,@IsPageAccessible BIT,@PageID INT
SELECT @PageID=PageID FROM Pages 
WHERE ([dbo].[Pages].PortalID=@PortalID OR [dbo].[Pages].PortalID=-1) 
AND  [dbo].[Pages].SEOName=@PageSEOName
AND ([dbo].[Pages].[IsDeleted] = 0 OR [dbo].[Pages].[IsDeleted] IS NULL)
IF EXISTS
(SELECT PageID FROM Pages where ([dbo].[Pages].PortalID=@PortalID OR [dbo].[Pages].PortalID=-1) 
AND  [dbo].[Pages].SEOName=@PageSEOName 
AND ([dbo].[Pages].[IsDeleted] = 0 OR [dbo].[Pages].[IsDeleted] IS NULL))
BEGIN
SET @IsPageAvailable=1
END
IF EXISTS(SELECT * 
FROM   Pages p 
       INNER JOIN PagePermission pm 
         ON p.PageID = pm.PageID 
WHERE (p.PortalID=@PortalID OR p.PortalID=-1) AND p.SEOName=@PageSEOName 
AND (p.[IsDeleted] = 0 OR p.[IsDeleted] IS NULL)

AND pm.RoleID IN (SELECT RoleID 
                         FROM   dbo.aspnet_usersinroles 
                                INNER JOIN dbo.aspnet_users 
                                  ON dbo.aspnet_usersinroles.UserId = 
                                     dbo.aspnet_users.UserId 
                         WHERE  dbo.aspnet_users.UserName = @UserName) 
       AND pm.PermissionID = 1 )
BEGIN
SET @IsPageAccessible=1
END
SELECT @IsPageAvailable AS IsPageAvailable,@IsPageAccessible AS IsPageAccessible

SELECT * 
FROM   Pages p
WHERE (p.PortalID=@PortalID OR p.PortalID=-1) AND p.SEOName=@PageSEOName 
AND (p.[IsDeleted] = 0 OR p.[IsDeleted] IS NULL)

SELECT DISTINCT v.PageID,v.usermoduleid,v.panename, 
       v.moduleorder, 
       v.ishandheld, 
       v.suffixclass, 
       v.showheadertext, 
       v.headertext ,
    v.ControlSrc,
    v.SupportsPartialRendering,
    --RoleID,
    v.ControlsCount,
v.PortalID,
     (select dbo.fn_EditPermissionExists(@UserName,v.usermoduleid)) AS IsEdit       
FROM   vw_PageUserModules v 
WHERE  v.seoname = @PageSEOName
       AND v.portalid = @PortalID
AND v.RoleID IN (SELECT roleid 
                         FROM   dbo.aspnet_usersinroles 
                                INNER JOIN dbo.aspnet_users 
                                  ON dbo.aspnet_usersinroles.userid = 
                                     dbo.aspnet_users.userid 
                         WHERE  dbo.aspnet_users.username = @UserName) 
AND v.ControlType=1
AND (v.IsDeleted=0 OR v.IsDeleted IS NULL)
AND v.IsActive=1
UNION
SELECT DISTINCT v.PageID,v.usermoduleid,v.panename, 
       v.moduleorder, 
       v.ishandheld, 
       v.suffixclass, 
       v.showheadertext, 
       v.headertext ,
    v.ControlSrc,
    v.SupportsPartialRendering,
    --RoleID,
    v.ControlsCount,
v.PortalID,
     (SELECT dbo.fn_EditPermissionExists(@UserName,v.usermoduleid)) AS IsEdit       
FROM   vw_PageUserModules v 
WHERE   v.portalid = @PortalID 
  AND v.RoleID IN (SELECT roleid 
                         FROM   dbo.aspnet_usersinroles 
                                INNER JOIN dbo.aspnet_users 
                                  ON dbo.aspnet_usersinroles.userid = 
                                     dbo.aspnet_users.userid 
                         WHERE  dbo.aspnet_users.username = @UserName) 
AND v.ControlType=1
AND (v.IsDeleted=0 OR v.IsDeleted IS NULL)
AND v.IsActive=1
AND v.allpages = 1
OR @PageID IN (SELECT RTRIM(LTRIM(items)) 
               FROM   Split(v.showinpages, ',') 
               WHERE (v.isdeleted=0 OR v.isdeleted IS NULL))
               ORDER BY v.ModuleOrder
END
GO
/****** Object:  Default [DF_MenuPermission_IsActive]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[MenuPermission] ADD  CONSTRAINT [DF_MenuPermission_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_MenuPermission_IsDeleted]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[MenuPermission] ADD  CONSTRAINT [DF_MenuPermission_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_MenuPermission_IsModified]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[MenuPermission] ADD  CONSTRAINT [DF_MenuPermission_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_MenuPermission_AddedOn]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[MenuPermission] ADD  CONSTRAINT [DF_MenuPermission_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_MenuPermission_UpdatedOn]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[MenuPermission] ADD  CONSTRAINT [DF_MenuPermission_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_MenuPermission_PortalID]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[MenuPermission] ADD  CONSTRAINT [DF_MenuPermission_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_BannerImage_DisplayOrder]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[BannerImage] ADD  CONSTRAINT [DF_BannerImage_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
/****** Object:  Default [DF_Users_IsDeleted]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SageFrameSearchProcedure_IsActive]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[SageFrameSearchProcedure] ADD  CONSTRAINT [DF_SageFrameSearchProcedure_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SageFrameSearchProcedure_IsDeleted]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[SageFrameSearchProcedure] ADD  CONSTRAINT [DF_SageFrameSearchProcedure_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SageFrameSearchProcedure_IsModified]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[SageFrameSearchProcedure] ADD  CONSTRAINT [DF_SageFrameSearchProcedure_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SageFrameSearchProcedure_AddedOn]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[SageFrameSearchProcedure] ADD  CONSTRAINT [DF_SageFrameSearchProcedure_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_SageFrameSearchProcedure_UpdatedOn]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[SageFrameSearchProcedure] ADD  CONSTRAINT [DF_SageFrameSearchProcedure_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_SageFrameSearchProcedure_PortalID]    Script Date: 12/29/2014 16:38:49 ******/
ALTER TABLE [dbo].[SageFrameSearchProcedure] ADD  CONSTRAINT [DF_SageFrameSearchProcedure_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_GoogleAnalytics_IsActive]    Script Date: 12/29/2014 16:38:50 ******/
ALTER TABLE [dbo].[GoogleAnalytics] ADD  CONSTRAINT [DF_GoogleAnalytics_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_GoogleAnalytics_IsModified]    Script Date: 12/29/2014 16:38:50 ******/
ALTER TABLE [dbo].[GoogleAnalytics] ADD  CONSTRAINT [DF_GoogleAnalytics_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_GoogleAnalytics_AddedOn]    Script Date: 12/29/2014 16:38:50 ******/
ALTER TABLE [dbo].[GoogleAnalytics] ADD  CONSTRAINT [DF_GoogleAnalytics_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_GoogleAnalytics_UpdatedOn]    Script Date: 12/29/2014 16:38:50 ******/
ALTER TABLE [dbo].[GoogleAnalytics] ADD  CONSTRAINT [DF_GoogleAnalytics_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_TrackSettingValue_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingValue] ADD  CONSTRAINT [DF_TrackSettingValue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_TrackSettingValue_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingValue] ADD  CONSTRAINT [DF_TrackSettingValue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_TrackSettingValue_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingValue] ADD  CONSTRAINT [DF_TrackSettingValue_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_TrackSettingValue_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingValue] ADD  CONSTRAINT [DF_TrackSettingValue_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_TrackSettingValue_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingValue] ADD  CONSTRAINT [DF_TrackSettingValue_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_TrackSettingValue_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingValue] ADD  CONSTRAINT [DF_TrackSettingValue_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_TrackSettingKey_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingKey] ADD  CONSTRAINT [DF_TrackSettingKey_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_TrackSettingKey_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingKey] ADD  CONSTRAINT [DF_TrackSettingKey_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_TrackSettingKey_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingKey] ADD  CONSTRAINT [DF_TrackSettingKey_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_TrackSettingKey_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingKey] ADD  CONSTRAINT [DF_TrackSettingKey_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_TrackSettingKey_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingKey] ADD  CONSTRAINT [DF_TrackSettingKey_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_TrackSettingKey_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[TrackSettingKey] ADD  CONSTRAINT [DF_TrackSettingKey_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_SystemEventLocation_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SystemEventLocation] ADD  CONSTRAINT [DF_SystemEventLocation_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SystemEventLocation_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SystemEventLocation] ADD  CONSTRAINT [DF_SystemEventLocation_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_NewsSetting_IsDeleted_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[NewsSetting] ADD  CONSTRAINT [DF_NewsSetting_IsDeleted_1]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_NewsSetting_IsModified_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[NewsSetting] ADD  CONSTRAINT [DF_NewsSetting_IsModified_1]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_NewsSetting_AddedOn_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[NewsSetting] ADD  CONSTRAINT [DF_NewsSetting_AddedOn_1]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_NewsSetting_UpdatedOn_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[NewsSetting] ADD  CONSTRAINT [DF_NewsSetting_UpdatedOn_1]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_Codes_IsAlreadyUsed]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Codes] ADD  CONSTRAINT [DF_Codes_IsAlreadyUsed]  DEFAULT ((0)) FOR [IsAlreadyUsed]
GO
/****** Object:  Default [DF_PortalModulePermission_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalModulePermission] ADD  CONSTRAINT [DF_PortalModulePermission_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_PortalModulePermission_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalModulePermission] ADD  CONSTRAINT [DF_PortalModulePermission_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_PortalModulePermission_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalModulePermission] ADD  CONSTRAINT [DF_PortalModulePermission_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_PortalModulePermission_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalModulePermission] ADD  CONSTRAINT [DF_PortalModulePermission_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_PortalModulePermission_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalModulePermission] ADD  CONSTRAINT [DF_PortalModulePermission_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF__AspNet_Sq__notif__6F1576F7]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification] ADD  CONSTRAINT [DF__AspNet_Sq__notif__6F1576F7]  DEFAULT (getdate()) FOR [notificationCreated]
GO
/****** Object:  Default [DF__AspNet_Sq__chang__70099B30]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[AspNet_SqlCacheTablesForChangeNotification] ADD  CONSTRAINT [DF__AspNet_Sq__chang__70099B30]  DEFAULT ((0)) FOR [changeId]
GO
/****** Object:  Default [DF__aspnet_Ap__Appli__24134F1B]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[aspnet_Applications] ADD  CONSTRAINT [DF__aspnet_Ap__Appli__24134F1B]  DEFAULT (newid()) FOR [ApplicationId]
GO
/****** Object:  Default [DF__Lists__ParentID__53C2623D]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF__Lists__ParentID__53C2623D]  DEFAULT ((0)) FOR [ParentID]
GO
/****** Object:  Default [DF__Lists__Level__54B68676]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF__Lists__Level__54B68676]  DEFAULT ((0)) FOR [Level]
GO
/****** Object:  Default [DF__Lists__SortOrder__55AAAAAF]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF__Lists__SortOrder__55AAAAAF]  DEFAULT ((0)) FOR [DisplayOrder]
GO
/****** Object:  Default [DF__Lists__Definitio__569ECEE8]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF__Lists__Definitio__569ECEE8]  DEFAULT ((0)) FOR [DefinitionID]
GO
/****** Object:  Default [DF__Lists__PortalID__5792F321]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF__Lists__PortalID__5792F321]  DEFAULT ((-1)) FOR [PortalID]
GO
/****** Object:  Default [DF__Lists__SystemLis__5887175A]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF__Lists__SystemLis__5887175A]  DEFAULT ((0)) FOR [SystemList]
GO
/****** Object:  Default [DF_LanguageSettingValue_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingValue] ADD  CONSTRAINT [DF_LanguageSettingValue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_LanguageSettingValue_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingValue] ADD  CONSTRAINT [DF_LanguageSettingValue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_LanguageSettingValue_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingValue] ADD  CONSTRAINT [DF_LanguageSettingValue_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_LanguageSettingValue_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingValue] ADD  CONSTRAINT [DF_LanguageSettingValue_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_LanguageSettingValue_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingValue] ADD  CONSTRAINT [DF_LanguageSettingValue_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_LanguageSettingValue_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingValue] ADD  CONSTRAINT [DF_LanguageSettingValue_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_LanguageSettingKey_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingKey] ADD  CONSTRAINT [DF_LanguageSettingKey_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_LanguageSettingKey_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingKey] ADD  CONSTRAINT [DF_LanguageSettingKey_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_LanguageSettingKey_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingKey] ADD  CONSTRAINT [DF_LanguageSettingKey_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_LanguageSettingKey_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingKey] ADD  CONSTRAINT [DF_LanguageSettingKey_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_LanguageSettingKey_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingKey] ADD  CONSTRAINT [DF_LanguageSettingKey_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_LanguageSettingKey_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageSettingKey] ADD  CONSTRAINT [DF_LanguageSettingKey_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_LanguageMessageTemplateType_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageMessageTemplateType] ADD  CONSTRAINT [DF_LanguageMessageTemplateType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_LanguageMessageTemplateType_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageMessageTemplateType] ADD  CONSTRAINT [DF_LanguageMessageTemplateType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_LanguageMessageTemplateType_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageMessageTemplateType] ADD  CONSTRAINT [DF_LanguageMessageTemplateType_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_LanguageMessageTemplateType_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageMessageTemplateType] ADD  CONSTRAINT [DF_LanguageMessageTemplateType_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_LanguageMessageTemplateType_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageMessageTemplateType] ADD  CONSTRAINT [DF_LanguageMessageTemplateType_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_LanguageMessageTemplateType_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[LanguageMessageTemplateType] ADD  CONSTRAINT [DF_LanguageMessageTemplateType_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_NewUserProfile_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_NewUserProfile_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_NewUserProfile_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_NewUserProfile_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_NewUserProfile_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_NewUserProfile_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_NewUserProfile_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_NewUserProfile_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_NewUserProfile_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_NewUserProfile_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_Pages_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Pages] ADD  CONSTRAINT [DF_Pages_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Pages_IsRequiredPage]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Pages] ADD  CONSTRAINT [DF_Pages_IsRequiredPage]  DEFAULT ((0)) FOR [IsRequiredPage]
GO
/****** Object:  Default [DF_PageMenu_ShowInMenu]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PageMenu] ADD  CONSTRAINT [DF_PageMenu_ShowInMenu]  DEFAULT ((1)) FOR [ShowInMenu]
GO
/****** Object:  Default [DF_SettingKey_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingKey] ADD  CONSTRAINT [DF_SettingKey_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SettingKey_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingKey] ADD  CONSTRAINT [DF_SettingKey_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SettingKey_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingKey] ADD  CONSTRAINT [DF_SettingKey_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SettingKey_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingKey] ADD  CONSTRAINT [DF_SettingKey_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_SettingKey_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingKey] ADD  CONSTRAINT [DF_SettingKey_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_SettingKey_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingKey] ADD  CONSTRAINT [DF_SettingKey_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_SettingKey_IsCacheable]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingKey] ADD  CONSTRAINT [DF_SettingKey_IsCacheable]  DEFAULT ((0)) FOR [IsCacheable]
GO
/****** Object:  Default [DF_Schedule_IsEnable]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Schedule] ADD  CONSTRAINT [DF_Schedule_IsEnable]  DEFAULT ((0)) FOR [IsEnable]
GO
/****** Object:  Default [DF_SageMenuSettingValue_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingValue] ADD  CONSTRAINT [DF_SageMenuSettingValue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SageMenuSettingValue_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingValue] ADD  CONSTRAINT [DF_SageMenuSettingValue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SageMenuSettingValue_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingValue] ADD  CONSTRAINT [DF_SageMenuSettingValue_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SageMenuSettingValue_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingValue] ADD  CONSTRAINT [DF_SageMenuSettingValue_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_SageMenuSettingValue_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingValue] ADD  CONSTRAINT [DF_SageMenuSettingValue_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_SageMenuSettingValue_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingValue] ADD  CONSTRAINT [DF_SageMenuSettingValue_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_SageMenuSettingkey_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingkey] ADD  CONSTRAINT [DF_SageMenuSettingkey_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SageMenuSettingkey_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingkey] ADD  CONSTRAINT [DF_SageMenuSettingkey_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SageMenuSettingkey_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingkey] ADD  CONSTRAINT [DF_SageMenuSettingkey_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SageMenuSettingkey_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingkey] ADD  CONSTRAINT [DF_SageMenuSettingkey_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_SageMenuSettingkey_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingkey] ADD  CONSTRAINT [DF_SageMenuSettingkey_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_SageMenuSettingkey_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageMenuSettingkey] ADD  CONSTRAINT [DF_SageMenuSettingkey_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_SageFrameSearchSettingValue_CultureName]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSettingValue] ADD  CONSTRAINT [DF_SageFrameSearchSettingValue_CultureName]  DEFAULT (N'en-US') FOR [CultureName]
GO
/****** Object:  Default [DF_SageFrameSearchSettingValue_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSettingValue] ADD  CONSTRAINT [DF_SageFrameSearchSettingValue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SageFrameSearchSettingValue_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSettingValue] ADD  CONSTRAINT [DF_SageFrameSearchSettingValue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SageFrameSearchSettingValue_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSettingValue] ADD  CONSTRAINT [DF_SageFrameSearchSettingValue_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SageFrameSearchSettingValue_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSettingValue] ADD  CONSTRAINT [DF_SageFrameSearchSettingValue_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_SageFrameSearchSettingValue_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSettingValue] ADD  CONSTRAINT [DF_SageFrameSearchSettingValue_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_SageFrameSearchSettingValue_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSettingValue] ADD  CONSTRAINT [DF_SageFrameSearchSettingValue_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_SageFrameSearchSetting_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSetting] ADD  CONSTRAINT [DF_SageFrameSearchSetting_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SageFrameSearchSetting_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSetting] ADD  CONSTRAINT [DF_SageFrameSearchSetting_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SageFrameSearchSetting_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSetting] ADD  CONSTRAINT [DF_SageFrameSearchSetting_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SageFrameSearchSetting_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSetting] ADD  CONSTRAINT [DF_SageFrameSearchSetting_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_SageFrameSearchSetting_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSetting] ADD  CONSTRAINT [DF_SageFrameSearchSetting_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_SageFrameSearchSetting_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SageFrameSearchSetting] ADD  CONSTRAINT [DF_SageFrameSearchSetting_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_PortalStartUp_IsSystem]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalStartUp] ADD  CONSTRAINT [DF_PortalStartUp_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO
/****** Object:  Default [DF_PortalStartUp_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalStartUp] ADD  CONSTRAINT [DF_PortalStartUp_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Table_1_RoleId]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalRole] ADD  CONSTRAINT [DF_Table_1_RoleId]  DEFAULT (newid()) FOR [RoleID]
GO
/****** Object:  Default [DF_PortalRole_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[PortalRole] ADD  CONSTRAINT [DF_PortalRole_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_MessageTemplateType_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateType] ADD  CONSTRAINT [DF_MessageTemplateType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_MessageTemplateType_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateType] ADD  CONSTRAINT [DF_MessageTemplateType_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_MessageTemplateType_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateType] ADD  CONSTRAINT [DF_MessageTemplateType_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_DashBoardSettingValue_IsActive_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingValue] ADD  CONSTRAINT [DF_DashBoardSettingValue_IsActive_1]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_DashBoardSettingValue_IsDeleted_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingValue] ADD  CONSTRAINT [DF_DashBoardSettingValue_IsDeleted_1]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_DashBoardSettingValue_IsModified_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingValue] ADD  CONSTRAINT [DF_DashBoardSettingValue_IsModified_1]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_DashBoardSettingValue_AddedOn_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingValue] ADD  CONSTRAINT [DF_DashBoardSettingValue_AddedOn_1]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_DashBoardSettingValue_UpdatedOn_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingValue] ADD  CONSTRAINT [DF_DashBoardSettingValue_UpdatedOn_1]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_DashBoardSettingValue_PortalID_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingValue] ADD  CONSTRAINT [DF_DashBoardSettingValue_PortalID_1]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_DashboardSettingsKeyValue_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashboardSettingsKeyValue] ADD  CONSTRAINT [DF_DashboardSettingsKeyValue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_DashboardSettingsKeyValue_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashboardSettingsKeyValue] ADD  CONSTRAINT [DF_DashboardSettingsKeyValue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_DashboardSettingsKeyValue_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashboardSettingsKeyValue] ADD  CONSTRAINT [DF_DashboardSettingsKeyValue_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_DashboardSettingsKeyValue_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashboardSettingsKeyValue] ADD  CONSTRAINT [DF_DashboardSettingsKeyValue_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_DashboardSettingsKeyValue_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashboardSettingsKeyValue] ADD  CONSTRAINT [DF_DashboardSettingsKeyValue_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_DashboardSettingsKeyValue_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashboardSettingsKeyValue] ADD  CONSTRAINT [DF_DashboardSettingsKeyValue_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_DashBoardSettingKey_IsActive_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingKey] ADD  CONSTRAINT [DF_DashBoardSettingKey_IsActive_1]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_DashBoardSettingKey_IsDeleted_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingKey] ADD  CONSTRAINT [DF_DashBoardSettingKey_IsDeleted_1]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_DashBoardSettingKey_IsModified_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingKey] ADD  CONSTRAINT [DF_DashBoardSettingKey_IsModified_1]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_DashBoardSettingKey_AddedOn_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingKey] ADD  CONSTRAINT [DF_DashBoardSettingKey_AddedOn_1]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_DashBoardSettingKey_UpdatedOn_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingKey] ADD  CONSTRAINT [DF_DashBoardSettingKey_UpdatedOn_1]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_DashBoardSettingKey_PortalID_1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[DashBoardSettingKey] ADD  CONSTRAINT [DF_DashBoardSettingKey_PortalID_1]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_MessageToken_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageToken] ADD  CONSTRAINT [DF_MessageToken_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_MessageToken_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageToken] ADD  CONSTRAINT [DF_MessageToken_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_MessageToken_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageToken] ADD  CONSTRAINT [DF_MessageToken_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SettingValue_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingValue] ADD  CONSTRAINT [DF_SettingValue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_SettingValue_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingValue] ADD  CONSTRAINT [DF_SettingValue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_SettingValue_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingValue] ADD  CONSTRAINT [DF_SettingValue_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_SettingValue_AddedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingValue] ADD  CONSTRAINT [DF_SettingValue_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_SettingValue_UpdatedOn]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingValue] ADD  CONSTRAINT [DF_SettingValue_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_SettingValue_PortalID]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingValue] ADD  CONSTRAINT [DF_SettingValue_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_SettingValue_IsCacheable]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[SettingValue] ADD  CONSTRAINT [DF_SettingValue_IsCacheable]  DEFAULT ((0)) FOR [IsCacheable]
GO
/****** Object:  Default [DF_ScheduleDate_IsExecuted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[ScheduleDate] ADD  CONSTRAINT [DF_ScheduleDate_IsExecuted]  DEFAULT ((0)) FOR [IsExecuted]
GO
/****** Object:  Default [DF_MessageTemplateTypeToken_IsActive]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateTypeToken] ADD  CONSTRAINT [DF_MessageTemplateTypeToken_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_MessageTemplateTypeToken_IsDeleted]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateTypeToken] ADD  CONSTRAINT [DF_MessageTemplateTypeToken_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_MessageTemplateTypeToken_IsModified]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateTypeToken] ADD  CONSTRAINT [DF_MessageTemplateTypeToken_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF__aspnet_Pa__PathI__69B1A35C]    Script Date: 12/29/2014 16:38:52 ******/
ALTER TABLE [dbo].[aspnet_Paths] ADD  CONSTRAINT [DF__aspnet_Pa__PathI__69B1A35C]  DEFAULT (newid()) FOR [PathId]
GO
/****** Object:  Default [DF_Permissions_ViewOrder]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permissions_ViewOrder]  DEFAULT ((9999)) FOR [DisplayOrder]
GO
/****** Object:  Default [DF_Permissions_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permissions_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Permissions_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permissions_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Permissions_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permissions_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_Permissions_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permissions_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_Permissions_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permissions_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_Permissions_PortalID]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permissions_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_HtmlComment_IsApproved]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[HtmlComment] ADD  CONSTRAINT [DF_HtmlComment_IsApproved]  DEFAULT ((0)) FOR [IsApproved]
GO
/****** Object:  Default [DF_HtmlComment_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[HtmlComment] ADD  CONSTRAINT [DF_HtmlComment_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_HtmlComment_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[HtmlComment] ADD  CONSTRAINT [DF_HtmlComment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_UserPortals_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserPortals] ADD  CONSTRAINT [DF_UserPortals_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_UserPortals_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserPortals] ADD  CONSTRAINT [DF_UserPortals_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_UserPortals_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserPortals] ADD  CONSTRAINT [DF_UserPortals_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_UserPortals_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserPortals] ADD  CONSTRAINT [DF_UserPortals_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_UserPortals_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserPortals] ADD  CONSTRAINT [DF_UserPortals_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_PortalLanguages_IsPublished]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalLanguages] ADD  CONSTRAINT [DF_PortalLanguages_IsPublished]  DEFAULT ((0)) FOR [IsPublished]
GO
/****** Object:  Default [DF__aspnet_Ro__RoleI__569ECEE8]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Roles] ADD  CONSTRAINT [DF__aspnet_Ro__RoleI__569ECEE8]  DEFAULT (newid()) FOR [RoleId]
GO
/****** Object:  Default [DF_Profile_DisplayOrder]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_DisplayOrder]  DEFAULT ((1)) FOR [DisplayOrder]
GO
/****** Object:  Default [DF_Profile_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Profile_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Profile_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_Profile_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_Profile_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_Profile_PortalID]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile] ADD  CONSTRAINT [DF_Profile_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_Image_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Image_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Image_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF__aspnet_Us__UserI__27E3DFFF]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [DF__aspnet_Us__UserI__27E3DFFF]  DEFAULT (newid()) FOR [UserId]
GO
/****** Object:  Default [DF__aspnet_Us__Mobil__28D80438]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [DF__aspnet_Us__Mobil__28D80438]  DEFAULT (NULL) FOR [MobileAlias]
GO
/****** Object:  Default [DF__aspnet_Us__IsAno__29CC2871]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [DF__aspnet_Us__IsAno__29CC2871]  DEFAULT ((0)) FOR [IsAnonymous]
GO
/****** Object:  Default [DF_UserProfile_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_UserProfile_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_UserProfile_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_UserProfile_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_UserProfile_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_UserProfile_PortalID1]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [DF_UserProfile_PortalID1]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_ProfileValue_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue] ADD  CONSTRAINT [DF_ProfileValue_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_ProfileValue_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue] ADD  CONSTRAINT [DF_ProfileValue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_ProfileValue_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue] ADD  CONSTRAINT [DF_ProfileValue_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_ProfileValue_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue] ADD  CONSTRAINT [DF_ProfileValue_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_ProfileValue_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue] ADD  CONSTRAINT [DF_ProfileValue_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ProfileValue_PortalID]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue] ADD  CONSTRAINT [DF_ProfileValue_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF__aspnet_Me__Passw__390E6C01]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Membership] ADD  CONSTRAINT [DF__aspnet_Me__Passw__390E6C01]  DEFAULT ((0)) FOR [PasswordFormat]
GO
/****** Object:  Default [DF__aspnet_Perso__Id__7152C524]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD  CONSTRAINT [DF__aspnet_Perso__Id__7152C524]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_PortalModules_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalModules] ADD  CONSTRAINT [DF_PortalModules_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_PortalModules_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalModules] ADD  CONSTRAINT [DF_PortalModules_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_PortalModules_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalModules] ADD  CONSTRAINT [DF_PortalModules_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_PortalModules_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalModules] ADD  CONSTRAINT [DF_PortalModules_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_PortalModules_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalModules] ADD  CONSTRAINT [DF_PortalModules_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_TabPermission_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission] ADD  CONSTRAINT [DF_TabPermission_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_TabPermission_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission] ADD  CONSTRAINT [DF_TabPermission_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_TabPermission_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission] ADD  CONSTRAINT [DF_TabPermission_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_TabPermission_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission] ADD  CONSTRAINT [DF_TabPermission_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_TabPermission_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission] ADD  CONSTRAINT [DF_TabPermission_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_TabPermission_PortalID]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission] ADD  CONSTRAINT [DF_TabPermission_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_Packages_IsSystemPackage]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Packages_IsSystemPackage]  DEFAULT ((0)) FOR [IsSystemPackage]
GO
/****** Object:  Default [DF_Packages_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Packages_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Packages_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Packages_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Packages_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Packages_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_Packages_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Packages_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_Packages_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages] ADD  CONSTRAINT [DF_Packages_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ModuleDefinitions_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions] ADD  CONSTRAINT [DF_ModuleDefinitions_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_ModuleDefinitions_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions] ADD  CONSTRAINT [DF_ModuleDefinitions_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_ModuleDefinitions_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions] ADD  CONSTRAINT [DF_ModuleDefinitions_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_ModuleDefinitions_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions] ADD  CONSTRAINT [DF_ModuleDefinitions_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_ModuleDefinitions_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions] ADD  CONSTRAINT [DF_ModuleDefinitions_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ModuleDefinitions_PortalID]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions] ADD  CONSTRAINT [DF_ModuleDefinitions_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_ModuleControls_IsActive]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls] ADD  CONSTRAINT [DF_ModuleControls_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_ModuleControls_IsDeleted]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls] ADD  CONSTRAINT [DF_ModuleControls_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_ModuleControls_IsModified]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls] ADD  CONSTRAINT [DF_ModuleControls_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_ModuleControls_AddedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls] ADD  CONSTRAINT [DF_ModuleControls_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_ModuleControls_UpdatedOn]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls] ADD  CONSTRAINT [DF_ModuleControls_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ModuleControls_PortalID]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls] ADD  CONSTRAINT [DF_ModuleControls_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_UserModules_IsHandheld]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserModules] ADD  CONSTRAINT [DF_UserModules_IsHandheld]  DEFAULT ((0)) FOR [IsHandheld]
GO
/****** Object:  Default [DF_ModuleSettings_IsActive]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings] ADD  CONSTRAINT [DF_ModuleSettings_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_ModuleSettings_IsDeleted]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings] ADD  CONSTRAINT [DF_ModuleSettings_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_ModuleSettings_IsModified]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings] ADD  CONSTRAINT [DF_ModuleSettings_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_ModuleSettings_AddedOn]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings] ADD  CONSTRAINT [DF_ModuleSettings_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_ModuleSettings_UpdatedOn]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings] ADD  CONSTRAINT [DF_ModuleSettings_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ModuleSettings_PortalID]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings] ADD  CONSTRAINT [DF_ModuleSettings_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_ModulePermission_IsActive]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission] ADD  CONSTRAINT [DF_ModulePermission_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_ModulePermission_IsDeleted]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission] ADD  CONSTRAINT [DF_ModulePermission_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_ModulePermission_IsModified]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission] ADD  CONSTRAINT [DF_ModulePermission_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_ModulePermission_AddedOn]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission] ADD  CONSTRAINT [DF_ModulePermission_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_ModulePermission_UpdatedOn]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission] ADD  CONSTRAINT [DF_ModulePermission_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_ModulePermission_PortalID]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission] ADD  CONSTRAINT [DF_ModulePermission_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  Default [DF_TabModule_DisplayTitle]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_DisplayTitle]  DEFAULT ((1)) FOR [DisplayTitle]
GO
/****** Object:  Default [DF_TabModule_DisplayPrint]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_DisplayPrint]  DEFAULT ((1)) FOR [DisplayPrint]
GO
/****** Object:  Default [DF_TabModule_IsActive]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_TabModule_IsDeleted]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_TabModule_IsModified]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_IsModified]  DEFAULT ((0)) FOR [IsModified]
GO
/****** Object:  Default [DF_TabModule_AddedOn]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_AddedOn]  DEFAULT (getdate()) FOR [AddedOn]
GO
/****** Object:  Default [DF_TabModule_UpdatedOn]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_UpdatedOn]  DEFAULT (getdate()) FOR [UpdatedOn]
GO
/****** Object:  Default [DF_TabModule_PortalID]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules] ADD  CONSTRAINT [DF_TabModule_PortalID]  DEFAULT ((1)) FOR [PortalID]
GO
/****** Object:  ForeignKey [FK_Pages_Pages1]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [FK_Pages_Pages1] FOREIGN KEY([PageID])
REFERENCES [dbo].[Pages] ([PageID])
GO
ALTER TABLE [dbo].[Pages] CHECK CONSTRAINT [FK_Pages_Pages1]
GO
/****** Object:  ForeignKey [FK_MenuItem_MenuItem]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItem_MenuItem] FOREIGN KEY([MenuItemID])
REFERENCES [dbo].[MenuItem] ([MenuItemID])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItem_MenuItem]
GO
/****** Object:  ForeignKey [FK_Menu_Menu]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Menu]
GO
/****** Object:  ForeignKey [FK_ScheduleDate_Schedule]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[ScheduleDate]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleDate_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
GO
ALTER TABLE [dbo].[ScheduleDate] CHECK CONSTRAINT [FK_ScheduleDate_Schedule]
GO
/****** Object:  ForeignKey [FK_MessageTemplateTypeToken_MessageTemplateType]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateTypeToken]  WITH CHECK ADD  CONSTRAINT [FK_MessageTemplateTypeToken_MessageTemplateType] FOREIGN KEY([MessageTemplateTypeID])
REFERENCES [dbo].[MessageTemplateType] ([MessageTemplateTypeID])
GO
ALTER TABLE [dbo].[MessageTemplateTypeToken] CHECK CONSTRAINT [FK_MessageTemplateTypeToken_MessageTemplateType]
GO
/****** Object:  ForeignKey [FK_MessageTemplateTypeToken_MessageToken]    Script Date: 12/29/2014 16:38:51 ******/
ALTER TABLE [dbo].[MessageTemplateTypeToken]  WITH CHECK ADD  CONSTRAINT [FK_MessageTemplateTypeToken_MessageToken] FOREIGN KEY([MessageTokenID])
REFERENCES [dbo].[MessageToken] ([MessageTokenID])
GO
ALTER TABLE [dbo].[MessageTemplateTypeToken] CHECK CONSTRAINT [FK_MessageTemplateTypeToken_MessageToken]
GO
/****** Object:  ForeignKey [FK_Log_LogType]    Script Date: 12/29/2014 16:38:52 ******/
ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_LogType] FOREIGN KEY([LogTypeID])
REFERENCES [dbo].[LogType] ([LogTypeID])
GO
ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_LogType]
GO
/****** Object:  ForeignKey [FK_ContactUs_Portal]    Script Date: 12/29/2014 16:38:52 ******/
ALTER TABLE [dbo].[ContactUs]  WITH CHECK ADD  CONSTRAINT [FK_ContactUs_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[ContactUs] CHECK CONSTRAINT [FK_ContactUs_Portal]
GO
/****** Object:  ForeignKey [FK__aspnet_Pa__Appli__68BD7F23]    Script Date: 12/29/2014 16:38:52 ******/
ALTER TABLE [dbo].[aspnet_Paths]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pa__Appli__68BD7F23] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Paths] CHECK CONSTRAINT [FK__aspnet_Pa__Appli__68BD7F23]
GO
/****** Object:  ForeignKey [FK_Permission_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Portal]
GO
/****** Object:  ForeignKey [FK_HTMLComment_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[HtmlComment]  WITH CHECK ADD  CONSTRAINT [FK_HTMLComment_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[HtmlComment] CHECK CONSTRAINT [FK_HTMLComment_Portal]
GO
/****** Object:  ForeignKey [FK_UserPortals_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserPortals]  WITH CHECK ADD  CONSTRAINT [FK_UserPortals_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[UserPortals] CHECK CONSTRAINT [FK_UserPortals_Portal]
GO
/****** Object:  ForeignKey [FK_PortalLanguages_PortalLanguages]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalLanguages]  WITH CHECK ADD  CONSTRAINT [FK_PortalLanguages_PortalLanguages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PortalLanguages] CHECK CONSTRAINT [FK_PortalLanguages_PortalLanguages]
GO
/****** Object:  ForeignKey [FK__aspnet_Ro__Appli__55AAAAAF]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Roles]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Ro__Appli__55AAAAAF] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Roles] CHECK CONSTRAINT [FK__aspnet_Ro__Appli__55AAAAAF]
GO
/****** Object:  ForeignKey [FK_Profile_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_Portal]
GO
/****** Object:  ForeignKey [FK_Profile_PropertyType]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_PropertyType] FOREIGN KEY([PropertyTypeID])
REFERENCES [dbo].[PropertyType] ([PropertyTypeID])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [FK_Profile_PropertyType]
GO
/****** Object:  ForeignKey [FK_Image_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Portal]
GO
/****** Object:  ForeignKey [FK_ScheduleWeek_Schedule]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ScheduleWeek]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleWeek_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
GO
ALTER TABLE [dbo].[ScheduleWeek] CHECK CONSTRAINT [FK_ScheduleWeek_Schedule]
GO
/****** Object:  ForeignKey [FK_ScheduleMonth_Schedule]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ScheduleMonth]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleMonth_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
GO
ALTER TABLE [dbo].[ScheduleMonth] CHECK CONSTRAINT [FK_ScheduleMonth_Schedule]
GO
/****** Object:  ForeignKey [FK_ScheduleHistory_Schedule]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ScheduleHistory]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleHistory_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
GO
ALTER TABLE [dbo].[ScheduleHistory] CHECK CONSTRAINT [FK_ScheduleHistory_Schedule]
GO
/****** Object:  ForeignKey [FK_ScheduleDay_Schedule]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ScheduleDay]  WITH CHECK ADD  CONSTRAINT [FK_ScheduleDay_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
GO
ALTER TABLE [dbo].[ScheduleDay] CHECK CONSTRAINT [FK_ScheduleDay_Schedule]
GO
/****** Object:  ForeignKey [FK__aspnet_Us__Appli__26EFBBC6]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Users]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Us__Appli__26EFBBC6] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Users] CHECK CONSTRAINT [FK__aspnet_Us__Appli__26EFBBC6]
GO
/****** Object:  ForeignKey [FK_DesktopModule_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Modules]  WITH CHECK ADD  CONSTRAINT [FK_DesktopModule_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[Modules] CHECK CONSTRAINT [FK_DesktopModule_Portal]
GO
/****** Object:  ForeignKey [FK_UserProfile_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_Portal]
GO
/****** Object:  ForeignKey [FK_UserProfile_Profile]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_Profile]
GO
/****** Object:  ForeignKey [FK_ProfileValue_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue]  WITH CHECK ADD  CONSTRAINT [FK_ProfileValue_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[ProfileValue] CHECK CONSTRAINT [FK_ProfileValue_Portal]
GO
/****** Object:  ForeignKey [FK_ProfileValue_Profile]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ProfileValue]  WITH CHECK ADD  CONSTRAINT [FK_ProfileValue_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
ALTER TABLE [dbo].[ProfileValue] CHECK CONSTRAINT [FK_ProfileValue_Profile]
GO
/****** Object:  ForeignKey [FK__aspnet_Me__Appli__3726238F]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Me__Appli__3726238F] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Membership] CHECK CONSTRAINT [FK__aspnet_Me__Appli__3726238F]
GO
/****** Object:  ForeignKey [FK__aspnet_Me__UserI__381A47C8]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Me__UserI__381A47C8] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Membership] CHECK CONSTRAINT [FK__aspnet_Me__UserI__381A47C8]
GO
/****** Object:  ForeignKey [FK__aspnet_Pr__UserI__4C214075]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_Profile]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pr__UserI__4C214075] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Profile] CHECK CONSTRAINT [FK__aspnet_Pr__UserI__4C214075]
GO
/****** Object:  ForeignKey [FK__aspnet_Pe__PathI__7246E95D]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__PathI__7246E95D] FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] CHECK CONSTRAINT [FK__aspnet_Pe__PathI__7246E95D]
GO
/****** Object:  ForeignKey [FK__aspnet_Pe__UserI__733B0D96]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__UserI__733B0D96] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] CHECK CONSTRAINT [FK__aspnet_Pe__UserI__733B0D96]
GO
/****** Object:  ForeignKey [FK__aspnet_Pe__PathI__6E765879]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__PathI__6E765879] FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] CHECK CONSTRAINT [FK__aspnet_Pe__PathI__6E765879]
GO
/****** Object:  ForeignKey [FK_PortalModules_Modules]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalModules]  WITH CHECK ADD  CONSTRAINT [FK_PortalModules_Modules] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[Modules] ([ModuleID])
GO
ALTER TABLE [dbo].[PortalModules] CHECK CONSTRAINT [FK_PortalModules_Modules]
GO
/****** Object:  ForeignKey [FK_PortalModules_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PortalModules]  WITH CHECK ADD  CONSTRAINT [FK_PortalModules_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[PortalModules] CHECK CONSTRAINT [FK_PortalModules_Portal]
GO
/****** Object:  ForeignKey [FK__aspnet_Us__RoleI__5A6F5FCC]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Us__RoleI__5A6F5FCC] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK__aspnet_Us__RoleI__5A6F5FCC]
GO
/****** Object:  ForeignKey [FK__aspnet_Us__UserI__597B3B93]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Us__UserI__597B3B93] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK__aspnet_Us__UserI__597B3B93]
GO
/****** Object:  ForeignKey [FK_PagePermission_Pages]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission]  WITH CHECK ADD  CONSTRAINT [FK_PagePermission_Pages] FOREIGN KEY([PageID])
REFERENCES [dbo].[Pages] ([PageID])
GO
ALTER TABLE [dbo].[PagePermission] CHECK CONSTRAINT [FK_PagePermission_Pages]
GO
/****** Object:  ForeignKey [FK_PagePermission_Permission]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission]  WITH CHECK ADD  CONSTRAINT [FK_PagePermission_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([PermissionID])
GO
ALTER TABLE [dbo].[PagePermission] CHECK CONSTRAINT [FK_PagePermission_Permission]
GO
/****** Object:  ForeignKey [FK_PagePermission_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission]  WITH CHECK ADD  CONSTRAINT [FK_PagePermission_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[PagePermission] CHECK CONSTRAINT [FK_PagePermission_Portal]
GO
/****** Object:  ForeignKey [FK_PagePermission_Portal1]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission]  WITH CHECK ADD  CONSTRAINT [FK_PagePermission_Portal1] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[PagePermission] CHECK CONSTRAINT [FK_PagePermission_Portal1]
GO
/****** Object:  ForeignKey [FK_TabPermission_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[PagePermission]  WITH CHECK ADD  CONSTRAINT [FK_TabPermission_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[PagePermission] CHECK CONSTRAINT [FK_TabPermission_Portal]
GO
/****** Object:  ForeignKey [FK_Packages_Modules]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_Packages_Modules] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[Modules] ([ModuleID])
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_Packages_Modules]
GO
/****** Object:  ForeignKey [FK_Packages_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_Packages_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_Packages_Portal]
GO
/****** Object:  ForeignKey [FK_ModuleDefinitions_Modules]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions]  WITH CHECK ADD  CONSTRAINT [FK_ModuleDefinitions_Modules] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[Modules] ([ModuleID])
GO
ALTER TABLE [dbo].[ModuleDefinitions] CHECK CONSTRAINT [FK_ModuleDefinitions_Modules]
GO
/****** Object:  ForeignKey [FK_ModuleDefinitions_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefinitions]  WITH CHECK ADD  CONSTRAINT [FK_ModuleDefinitions_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[ModuleDefinitions] CHECK CONSTRAINT [FK_ModuleDefinitions_Portal]
GO
/****** Object:  ForeignKey [FK_CoreModules_Modules]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[CoreModules]  WITH CHECK ADD  CONSTRAINT [FK_CoreModules_Modules] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[Modules] ([ModuleID])
GO
ALTER TABLE [dbo].[CoreModules] CHECK CONSTRAINT [FK_CoreModules_Modules]
GO
/****** Object:  ForeignKey [FK_ModuleControls_ModuleDefinitions]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls]  WITH CHECK ADD  CONSTRAINT [FK_ModuleControls_ModuleDefinitions] FOREIGN KEY([ModuleDefID])
REFERENCES [dbo].[ModuleDefinitions] ([ModuleDefID])
GO
ALTER TABLE [dbo].[ModuleControls] CHECK CONSTRAINT [FK_ModuleControls_ModuleDefinitions]
GO
/****** Object:  ForeignKey [FK_ModuleControls_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleControls]  WITH CHECK ADD  CONSTRAINT [FK_ModuleControls_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[ModuleControls] CHECK CONSTRAINT [FK_ModuleControls_Portal]
GO
/****** Object:  ForeignKey [FK_MainModulePermission_Portal]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefPermission]  WITH CHECK ADD  CONSTRAINT [FK_MainModulePermission_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[ModuleDefPermission] CHECK CONSTRAINT [FK_MainModulePermission_Portal]
GO
/****** Object:  ForeignKey [FK_MainPermission_ModuleDefinitions]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefPermission]  WITH CHECK ADD  CONSTRAINT [FK_MainPermission_ModuleDefinitions] FOREIGN KEY([ModuleDefID])
REFERENCES [dbo].[ModuleDefinitions] ([ModuleDefID])
GO
ALTER TABLE [dbo].[ModuleDefPermission] CHECK CONSTRAINT [FK_MainPermission_ModuleDefinitions]
GO
/****** Object:  ForeignKey [FK_ModuleDefinitions_Permission]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[ModuleDefPermission]  WITH CHECK ADD  CONSTRAINT [FK_ModuleDefinitions_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([PermissionID])
GO
ALTER TABLE [dbo].[ModuleDefPermission] CHECK CONSTRAINT [FK_ModuleDefinitions_Permission]
GO
/****** Object:  ForeignKey [FK_Modules_ModuleDefinitions]    Script Date: 12/29/2014 16:38:53 ******/
ALTER TABLE [dbo].[UserModules]  WITH CHECK ADD  CONSTRAINT [FK_Modules_ModuleDefinitions] FOREIGN KEY([ModuleDefID])
REFERENCES [dbo].[ModuleDefinitions] ([ModuleDefID])
GO
ALTER TABLE [dbo].[UserModules] CHECK CONSTRAINT [FK_Modules_ModuleDefinitions]
GO
/****** Object:  ForeignKey [FK_HtmlText_HtmlText]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[HtmlText]  WITH CHECK ADD  CONSTRAINT [FK_HtmlText_HtmlText] FOREIGN KEY([HTMLTextID])
REFERENCES [dbo].[HtmlText] ([HTMLTextID])
GO
ALTER TABLE [dbo].[HtmlText] CHECK CONSTRAINT [FK_HtmlText_HtmlText]
GO
/****** Object:  ForeignKey [FK_HtmlText_Portal]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[HtmlText]  WITH CHECK ADD  CONSTRAINT [FK_HtmlText_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[HtmlText] CHECK CONSTRAINT [FK_HtmlText_Portal]
GO
/****** Object:  ForeignKey [FK_HtmlText_UserModules]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[HtmlText]  WITH CHECK ADD  CONSTRAINT [FK_HtmlText_UserModules] FOREIGN KEY([UserModuleID])
REFERENCES [dbo].[UserModules] ([UserModuleID])
GO
ALTER TABLE [dbo].[HtmlText] CHECK CONSTRAINT [FK_HtmlText_UserModules]
GO
/****** Object:  ForeignKey [FK_ModuleSettings_Portal]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings]  WITH CHECK ADD  CONSTRAINT [FK_ModuleSettings_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[UserModuleSettings] CHECK CONSTRAINT [FK_ModuleSettings_Portal]
GO
/****** Object:  ForeignKey [FK_ModuleSettings_UserModules]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModuleSettings]  WITH CHECK ADD  CONSTRAINT [FK_ModuleSettings_UserModules] FOREIGN KEY([UserModuleID])
REFERENCES [dbo].[UserModules] ([UserModuleID])
GO
ALTER TABLE [dbo].[UserModuleSettings] CHECK CONSTRAINT [FK_ModuleSettings_UserModules]
GO
/****** Object:  ForeignKey [FK_ModulePermission_MainPermission]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_ModulePermission_MainPermission] FOREIGN KEY([ModuleDefPermissionID])
REFERENCES [dbo].[ModuleDefPermission] ([ModuleDefPermissionID])
GO
ALTER TABLE [dbo].[UserModulePermission] CHECK CONSTRAINT [FK_ModulePermission_MainPermission]
GO
/****** Object:  ForeignKey [FK_ModulePermission_Portal]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_ModulePermission_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[UserModulePermission] CHECK CONSTRAINT [FK_ModulePermission_Portal]
GO
/****** Object:  ForeignKey [FK_UserModulePermission_Portal]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_UserModulePermission_Portal] FOREIGN KEY([PortalID])
REFERENCES [dbo].[Portal] ([PortalID])
GO
ALTER TABLE [dbo].[UserModulePermission] CHECK CONSTRAINT [FK_UserModulePermission_Portal]
GO
/****** Object:  ForeignKey [FK_UserModulePermission_UserModules]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[UserModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_UserModulePermission_UserModules] FOREIGN KEY([UserModuleID])
REFERENCES [dbo].[UserModules] ([UserModuleID])
GO
ALTER TABLE [dbo].[UserModulePermission] CHECK CONSTRAINT [FK_UserModulePermission_UserModules]
GO
/****** Object:  ForeignKey [FK_PageModules_Pages]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules]  WITH CHECK ADD  CONSTRAINT [FK_PageModules_Pages] FOREIGN KEY([PageID])
REFERENCES [dbo].[Pages] ([PageID])
GO
ALTER TABLE [dbo].[PageModules] CHECK CONSTRAINT [FK_PageModules_Pages]
GO
/****** Object:  ForeignKey [FK_PageModules_UserModules]    Script Date: 12/29/2014 16:38:54 ******/
ALTER TABLE [dbo].[PageModules]  WITH CHECK ADD  CONSTRAINT [FK_PageModules_UserModules] FOREIGN KEY([UserModuleID])
REFERENCES [dbo].[UserModules] ([UserModuleID])
GO
ALTER TABLE [dbo].[PageModules] CHECK CONSTRAINT [FK_PageModules_UserModules]
GO
