USE [master]
GO
/****** Object:  Database [Menu]    Script Date: 2016-11-07 22:44:08 ******/
CREATE DATABASE [Menu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Menu', FILENAME = N'G:\代码存放\数据库代码\Menu.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Menu_log', FILENAME = N'G:\代码存放\数据库代码\Menu_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Menu] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Menu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Menu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Menu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Menu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Menu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Menu] SET ARITHABORT OFF 
GO
ALTER DATABASE [Menu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Menu] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Menu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Menu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Menu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Menu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Menu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Menu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Menu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Menu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Menu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Menu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Menu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Menu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Menu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Menu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Menu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Menu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Menu] SET RECOVERY FULL 
GO
ALTER DATABASE [Menu] SET  MULTI_USER 
GO
ALTER DATABASE [Menu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Menu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Menu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Menu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Menu', N'ON'
GO
USE [Menu]
GO
/****** Object:  Table [dbo].[ActionInfo]    Script Date: 2016-11-07 22:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionInfo](
	[ActionID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[ICON] [nvarchar](50) NULL,
	[ActionName] [nvarchar](30) NULL,
	[ControllerName] [nvarchar](30) NULL,
	[ParID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleActionInfo]    Script Date: 2016-11-07 22:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleActionInfo](
	[RoleActionID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[ActionID] [nvarchar](100) NULL,
 CONSTRAINT [PK__RoleActi__34397BD60E01D529] PRIMARY KEY CLUSTERED 
(
	[RoleActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleInfo]    Script Date: 2016-11-07 22:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleInfo](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserActionInfo]    Script Date: 2016-11-07 22:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActionInfo](
	[UserActionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[ActionID] [int] NULL,
	[IsTrue] [bit] NOT NULL,
 CONSTRAINT [PK__UserActi__40CADDC227657C4E] PRIMARY KEY CLUSTERED 
(
	[UserActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2016-11-07 22:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[Pwd] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoleInfo]    Script Date: 2016-11-07 22:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleInfo](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RoleID] [nvarchar](100) NULL,
 CONSTRAINT [PK__UserRole__3D978A55CC607F3C] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ActionInfo] ON 

INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (1, N'首页', N'icon-home', N'Index2', N'Admin', 0)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (2, N'简介', N'icon-profile', NULL, N'', 0)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (3, N'群成员', N'icon-group', NULL, N'', 0)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (4, N'互动交流', N'icon-comunicate', NULL, NULL, 0)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (5, N'问题或需求', N'icon-question', NULL, NULL, 0)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (6, N'网站建议', N'icon-pencil', NULL, NULL, 0)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (7, N'权限管理', N'icon-jurisdiction', NULL, NULL, 0)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (8, N'添加简介', NULL, N'SummaryAdd', N'WebSummary', 2)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (9, N'简介列表', NULL, N'SummaryList', N'WebSummary', 2)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (10, N'添加成员', NULL, N'AddGroupMenber', N'GroupMember', 3)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (11, N'成员列表', NULL, N'GroupMenberList', N'GroupMember', 3)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (12, N'交流列表', NULL, N'Index', N'Chat', 4)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (13, N'问题列表', NULL, N'Question', N'AskQuestion', 5)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (14, N'需求列表', NULL, N'XuQiu', N'AskQuestion', 5)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (15, N'建议列表', NULL, N'Index', N'WebAdvice', 6)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (16, N'给用户设置角色', NULL, N'SetRole', N'Power', 7)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (17, N'给角色设置权限', NULL, N'SetAction', N'Power', 7)
INSERT [dbo].[ActionInfo] ([ActionID], [Name], [ICON], [ActionName], [ControllerName], [ParID]) VALUES (18, N'给用户设置特殊权限', NULL, N'SetSpecialAction', N'Power', 7)
SET IDENTITY_INSERT [dbo].[ActionInfo] OFF
SET IDENTITY_INSERT [dbo].[RoleActionInfo] ON 

INSERT [dbo].[RoleActionInfo] ([RoleActionID], [RoleID], [ActionID]) VALUES (1, 1, N'1,2,3,4,5,6,7')
INSERT [dbo].[RoleActionInfo] ([RoleActionID], [RoleID], [ActionID]) VALUES (2, 2, N'1,2,3,4,5,6')
INSERT [dbo].[RoleActionInfo] ([RoleActionID], [RoleID], [ActionID]) VALUES (3, 3, N'1')
INSERT [dbo].[RoleActionInfo] ([RoleActionID], [RoleID], [ActionID]) VALUES (4, 4, N'1,2')
SET IDENTITY_INSERT [dbo].[RoleActionInfo] OFF
SET IDENTITY_INSERT [dbo].[RoleInfo] ON 

INSERT [dbo].[RoleInfo] ([RoleID], [RoleName]) VALUES (1, N'超级管理员')
INSERT [dbo].[RoleInfo] ([RoleID], [RoleName]) VALUES (2, N'管理员')
INSERT [dbo].[RoleInfo] ([RoleID], [RoleName]) VALUES (3, N'游客')
INSERT [dbo].[RoleInfo] ([RoleID], [RoleName]) VALUES (4, N'群众')
SET IDENTITY_INSERT [dbo].[RoleInfo] OFF
SET IDENTITY_INSERT [dbo].[UserActionInfo] ON 

INSERT [dbo].[UserActionInfo] ([UserActionID], [UserID], [ActionID], [IsTrue]) VALUES (10, 1, 2, 0)
SET IDENTITY_INSERT [dbo].[UserActionInfo] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([UserID], [UserName], [Pwd]) VALUES (1, N'admin', N'4297f44b13955235245b2497399d7a93')
INSERT [dbo].[UserInfo] ([UserID], [UserName], [Pwd]) VALUES (2, N'ryj', N'96e79218965eb72c92a549dd5a330112')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
SET IDENTITY_INSERT [dbo].[UserRoleInfo] ON 

INSERT [dbo].[UserRoleInfo] ([UserRoleID], [UserID], [RoleID]) VALUES (1, 1, N'1')
INSERT [dbo].[UserRoleInfo] ([UserRoleID], [UserID], [RoleID]) VALUES (2, 2, N'e2e2e2e2e2e2e')
SET IDENTITY_INSERT [dbo].[UserRoleInfo] OFF
USE [master]
GO
ALTER DATABASE [Menu] SET  READ_WRITE 
GO
