USE [master]
GO
/****** Object:  Database [HealthcareBookingDB]    Script Date: 12/29/2022 3:55:26 PM ******/
CREATE DATABASE [HealthcareBookingDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthcareBookingDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HealthcareBookingDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HealthcareBookingDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HealthcareBookingDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HealthcareBookingDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthcareBookingDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthcareBookingDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthcareBookingDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthcareBookingDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HealthcareBookingDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthcareBookingDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HealthcareBookingDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HealthcareBookingDB] SET  MULTI_USER 
GO
ALTER DATABASE [HealthcareBookingDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthcareBookingDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthcareBookingDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthcareBookingDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HealthcareBookingDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HealthcareBookingDB', N'ON'
GO
USE [HealthcareBookingDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/29/2022 3:55:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[doctorID] [int] NULL,
	[userID] [int] NULL,
	[from] [datetime2](7) NULL,
	[status] [bit] NOT NULL,
	[dayAr] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[city] [nvarchar](max) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClinicPhotos]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicPhotos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[doctorID] [int] NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClinicPhotos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](max) NULL,
	[lastName] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[massage] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[photo] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[subDescription] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[services] [nvarchar](max) NULL,
	[views] [float] NULL,
	[price] [decimal](18, 2) NULL,
	[cityID] [int] NULL,
	[specializationID] [int] NULL,
	[gender] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DoctorAppointments]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorAppointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[doctorID] [int] NULL,
	[from] [datetime2](7) NULL,
	[to] [datetime2](7) NULL,
	[dayAr] [nvarchar](max) NULL,
	[dayEn] [nvarchar](max) NULL,
	[duration] [int] NULL,
	[order] [int] NULL,
 CONSTRAINT [PK_DoctorAppointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Offer]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[doctorID] [int] NULL,
	[title] [nvarchar](max) NULL,
	[subTitle] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[mainPhoto] [nvarchar](max) NULL,
	[price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OfferPhotos]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferPhotos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[offerID] [int] NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_OfferPhotos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Review]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[doctorID] [int] NULL,
	[userID] [int] NULL,
	[comment] [nvarchar](max) NULL,
	[rate] [real] NULL,
	[date] [datetime2](7) NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 12/29/2022 3:55:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL DEFAULT (CONVERT([bit],(0))),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220731200509_firtsMigration', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220905121759_removeRoleTbl', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220905142601_UpdateColumn', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220905151048_ColumnAllowNull', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221010084008_updateoffertbl', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221024162946_UpdateAppointmentsTbl', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221027225409_AddOrderToAppointmentsTbl', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221102104215_addGenderToDoctorTbl', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221116141325_addContuctUsTBL', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221116144756_addContuctUsTBL', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221223162939_updateTbls', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221224115532_deleteRole', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221226185916_AddIsActive', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221227160727_updateTblUsers', N'6.0.8')
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([Id], [doctorID], [userID], [from], [status], [dayAr]) VALUES (18, 1070, 3, CAST(N'2022-11-09 11:30:00.0000000' AS DateTime2), 1, N'الأحد')
INSERT [dbo].[Appointments] ([Id], [doctorID], [userID], [from], [status], [dayAr]) VALUES (2004, 1071, 2002, CAST(N'2022-12-18 10:30:00.0000000' AS DateTime2), 0, N'السبت')
INSERT [dbo].[Appointments] ([Id], [doctorID], [userID], [from], [status], [dayAr]) VALUES (2005, 1071, 2002, CAST(N'2022-12-18 09:00:00.0000000' AS DateTime2), 0, N'الأحد')
INSERT [dbo].[Appointments] ([Id], [doctorID], [userID], [from], [status], [dayAr]) VALUES (3005, 1070, 2002, CAST(N'2022-11-09 10:00:00.0000000' AS DateTime2), 0, N'الأحد')
INSERT [dbo].[Appointments] ([Id], [doctorID], [userID], [from], [status], [dayAr]) VALUES (3006, 1070, 2002, CAST(N'2022-11-09 10:30:00.0000000' AS DateTime2), 0, N'الأحد')
SET IDENTITY_INSERT [dbo].[Appointments] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [city]) VALUES (1, N'القاهرة')
INSERT [dbo].[City] ([Id], [city]) VALUES (2, N'المنوفية')
INSERT [dbo].[City] ([Id], [city]) VALUES (3, N'الاسكندرية')
INSERT [dbo].[City] ([Id], [city]) VALUES (4, N'الغربية')
INSERT [dbo].[City] ([Id], [city]) VALUES (5, N'الجيزة')
INSERT [dbo].[City] ([Id], [city]) VALUES (6, N'الدقهلية')
INSERT [dbo].[City] ([Id], [city]) VALUES (7, N'البحيرة')
INSERT [dbo].[City] ([Id], [city]) VALUES (8, N'كفر الشيخ')
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[ClinicPhotos] ON 

INSERT [dbo].[ClinicPhotos] ([Id], [doctorID], [image]) VALUES (2127, 1070, N'3bf7ce55-73d8-4ba6-bf7b-7bb21da3b79a.jpg')
INSERT [dbo].[ClinicPhotos] ([Id], [doctorID], [image]) VALUES (2128, 1070, N'b784b453-3d8e-465b-b793-513c9f8c0e22.jpg')
INSERT [dbo].[ClinicPhotos] ([Id], [doctorID], [image]) VALUES (2129, 1070, N'3b7443fc-036f-41be-a674-7eb93f9c36b8.jpg')
INSERT [dbo].[ClinicPhotos] ([Id], [doctorID], [image]) VALUES (2130, 1070, N'0e578a88-3c01-4ba1-8474-2693299f859a.jpg')
INSERT [dbo].[ClinicPhotos] ([Id], [doctorID], [image]) VALUES (2131, 1070, N'1560855e-7cb7-436c-aba5-e5029a876867.jpg')
INSERT [dbo].[ClinicPhotos] ([Id], [doctorID], [image]) VALUES (2132, 1070, N'01d0e5e4-6922-4adb-9de1-e45cdc27002c.jpg')
INSERT [dbo].[ClinicPhotos] ([Id], [doctorID], [image]) VALUES (2133, 1070, N'3317faba-ce80-4ab9-b993-98fd2571f756.jpg')
SET IDENTITY_INSERT [dbo].[ClinicPhotos] OFF
SET IDENTITY_INSERT [dbo].[ContactUs] ON 

INSERT [dbo].[ContactUs] ([Id], [firstName], [lastName], [email], [phone], [massage]) VALUES (1, N'ahmed', N'samy', N'ahmed@gmail.com', N'01029405663', N'test')
INSERT [dbo].[ContactUs] ([Id], [firstName], [lastName], [email], [phone], [massage]) VALUES (2, N'ahmed', N'samy', N'ahmed@gmail.com', N'01029405663', N'test')
INSERT [dbo].[ContactUs] ([Id], [firstName], [lastName], [email], [phone], [massage]) VALUES (3, N'test', N'test', N'aas@a', N'01234567892', N'ss')
INSERT [dbo].[ContactUs] ([Id], [firstName], [lastName], [email], [phone], [massage]) VALUES (1002, N'ahmed', N'samyq', N'aa@aa', N'01010101010', N'tete')
SET IDENTITY_INSERT [dbo].[ContactUs] OFF
SET IDENTITY_INSERT [dbo].[Doctor] ON 

INSERT [dbo].[Doctor] ([Id], [name], [email], [phone], [photo], [password], [address], [subDescription], [description], [services], [views], [price], [cityID], [specializationID], [gender], [IsActive]) VALUES (1070, N'احمد سامي', N'doctor@gmail.com', N'01029405663', N'6ad18656-2392-40c2-8089-7374b871c9ce.jpg', N'doctor', N'المنوفيه شبين الكوم', N'استشاري طب الفم و الاسنان و تجميل الاسنان', N'أخصائي زراعه وتقويم الاسنان

', N'تقويم وتجميل الاسنان,جراحات الفم و الاسنان,زراعه الاسنان,تبيض الاسنان,علاج الجذور وحشو العصب', 5, CAST(180.00 AS Decimal(18, 2)), 2, 1041, N'male', 1)
INSERT [dbo].[Doctor] ([Id], [name], [email], [phone], [photo], [password], [address], [subDescription], [description], [services], [views], [price], [cityID], [specializationID], [gender], [IsActive]) VALUES (1071, N'محمد علي', N'ali@gmail.com', N'01236456788', N'doc7.jpg', N'ali', N'المنوفيه قويسنا', NULL, NULL, NULL, 5, CAST(140.00 AS Decimal(18, 2)), 2, 1040, N'male', 1)
INSERT [dbo].[Doctor] ([Id], [name], [email], [phone], [photo], [password], [address], [subDescription], [description], [services], [views], [price], [cityID], [specializationID], [gender], [IsActive]) VALUES (3054, N'سعيد علي', N'said@gmail.com', N'010123456789', N'54ab5e48-d45e-4e27-a0a4-78ffe3ebd8ea.jpg', N'said', N'القاهرة التجمع الخامس', N'طيبيب جراح', NULL, NULL, NULL, CAST(120.00 AS Decimal(18, 2)), 1, 1, N'male', 1)
INSERT [dbo].[Doctor] ([Id], [name], [email], [phone], [photo], [password], [address], [subDescription], [description], [services], [views], [price], [cityID], [specializationID], [gender], [IsActive]) VALUES (3055, N'محمد سعيد', N'mohamed@gmail.com', N'010000', N'43a641b4-9fdb-4cc8-927d-65a9355e442f.jpg', N'mohamed', N'الجيزة الاهرام', N'دكتور علاج طبيعي', NULL, NULL, NULL, CAST(200.00 AS Decimal(18, 2)), 5, 2, N'male', 1)
INSERT [dbo].[Doctor] ([Id], [name], [email], [phone], [photo], [password], [address], [subDescription], [description], [services], [views], [price], [cityID], [specializationID], [gender], [IsActive]) VALUES (3056, N'ahmed', N'ahmed@gmail.com', N'01232424545', N'aefb75ed-0046-4dfe-8646-3c1a4fbc48bc.jpg', N'ahmed', N'المهندسين', NULL, NULL, NULL, NULL, CAST(350.00 AS Decimal(18, 2)), 1, 1, N'male', 1)
INSERT [dbo].[Doctor] ([Id], [name], [email], [phone], [photo], [password], [address], [subDescription], [description], [services], [views], [price], [cityID], [specializationID], [gender], [IsActive]) VALUES (3057, N'amr gamal', N'amr@gmail.com', N'01212121', N'8beea7fb-81d7-4dfc-937b-f4b127221fcb.jpg', N'amr', N'القاهرة الحي التاني', N'اخصائي جراحة', N'مدير عام قسم الجراحة  ', N'جراحة', NULL, CAST(210.00 AS Decimal(18, 2)), 1, 1, N'male', 1)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
SET IDENTITY_INSERT [dbo].[DoctorAppointments] ON 

INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3054, 1071, CAST(N'2022-12-18 09:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 17:00:00.0000000' AS DateTime2), N'السبت', N'saturday', 30, 1)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3055, 1071, CAST(N'2022-12-18 09:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 16:00:00.0000000' AS DateTime2), N'الأحد', N'sunday', 30, 2)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3056, 1071, CAST(N'2022-12-18 10:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 18:00:00.0000000' AS DateTime2), N'الاثنين', N'monday', 30, 3)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3057, 1071, CAST(N'2022-12-18 09:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 16:00:00.0000000' AS DateTime2), N'الثلاثاء', N'tuesday', 30, 4)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3058, 1071, CAST(N'2022-12-18 10:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 17:00:00.0000000' AS DateTime2), N'الأربعاء', N'wednesday', 30, 5)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3059, 3054, CAST(N'2022-12-18 09:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 17:20:00.0000000' AS DateTime2), N'الاثنين', N'monday', 30, 3)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3060, 3054, CAST(N'2022-12-18 08:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 16:00:00.0000000' AS DateTime2), N'الثلاثاء', N'tuesday', 30, 4)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3061, 3054, CAST(N'2022-12-18 10:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 17:00:00.0000000' AS DateTime2), N'الأربعاء', N'wednesday', 30, 5)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3062, 3054, CAST(N'2022-12-18 07:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 18:00:00.0000000' AS DateTime2), N'الخميس', N'thursday', 30, 6)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3063, 3055, CAST(N'2022-12-18 09:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 15:00:00.0000000' AS DateTime2), N'الأحد', N'sunday', 30, 2)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3064, 3055, CAST(N'2022-12-18 09:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 14:00:00.0000000' AS DateTime2), N'الاثنين', N'monday', 30, 3)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3065, 3055, CAST(N'2022-12-18 15:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 19:00:00.0000000' AS DateTime2), N'الثلاثاء', N'tuesday', 30, 4)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3066, 3055, CAST(N'2022-12-18 17:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 22:00:00.0000000' AS DateTime2), N'الخميس', N'thursday', 30, 6)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3070, 3056, CAST(N'2022-12-18 22:45:00.0000000' AS DateTime2), CAST(N'2022-12-18 23:45:00.0000000' AS DateTime2), N'السبت', N'saturday', 30, 1)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3071, 3056, CAST(N'2022-12-18 15:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 19:00:00.0000000' AS DateTime2), N'الاثنين', N'monday', 30, 3)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3072, 3056, CAST(N'2022-12-18 08:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 15:00:00.0000000' AS DateTime2), N'الأربعاء', N'wednesday', 30, 5)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (3073, 3056, CAST(N'2022-12-18 10:00:00.0000000' AS DateTime2), CAST(N'2022-12-18 18:00:00.0000000' AS DateTime2), N'الخميس', N'thursday', 30, 6)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (4059, 1070, CAST(N'2022-12-28 10:00:00.0000000' AS DateTime2), CAST(N'2022-12-28 17:00:00.0000000' AS DateTime2), N'الأحد', N'sunday', 30, 2)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (4060, 1070, CAST(N'2022-12-28 09:00:00.0000000' AS DateTime2), CAST(N'2022-12-28 22:00:00.0000000' AS DateTime2), N'الاثنين', N'monday', 30, 3)
INSERT [dbo].[DoctorAppointments] ([Id], [doctorID], [from], [to], [dayAr], [dayEn], [duration], [order]) VALUES (4061, 1070, CAST(N'2022-12-28 17:00:00.0000000' AS DateTime2), CAST(N'2022-12-28 18:00:00.0000000' AS DateTime2), N'الثلاثاء', N'tuesday', 30, 4)
SET IDENTITY_INSERT [dbo].[DoctorAppointments] OFF
SET IDENTITY_INSERT [dbo].[Offer] ON 

INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (1004, 1070, N'طقم اسنان جزئي متحرك مرن', N'فك واحد تركيب طقم اسنان متحرك مرن', N'test', N'3b1fb525-8269-4b68-95db-307e2173b3e6.jpg', CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (1005, 1071, N'عرض جديد', N'عنوان فرعي للعرض', N'test', N'04d5b62a-8f3e-420c-936c-ffc381d2249e.jpg', CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (1007, 3057, N'عرض لفتره محدودة', N'عنوان فرغي للعرض', N'test', N'c1bad045-52c9-4398-9ddb-a83dd52b5d0b.jpg', CAST(122.00 AS Decimal(18, 2)))
INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (2002, 1070, N'عرض', N'عنوان', N'تفاصيل العرض', N'47e7103c-3508-4906-a800-0dfe440c9cc0.jpg', CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (2008, 1070, N'عرض اخر', N'عنوان اخر', N'تفاصيل جديده', N'60c977fc-f859-4130-b3d3-195e8040c574.jpg', CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (2009, 1070, N'تركيب فك اسنان', N'عنوان فرعي', N'تفاصيل', N'ea1b6c77-884f-4452-b38c-2f7f1c8d3926.jpg', CAST(140.00 AS Decimal(18, 2)))
INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (2010, 3056, N'عرض', N'عرض', N'تفاصيل', N'300703ef-06eb-4c71-89b6-8b571d918bce.jpg', CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[Offer] ([Id], [doctorID], [title], [subTitle], [description], [mainPhoto], [price]) VALUES (2011, 3056, N'test', N'test', N'test', N'd77c86fb-9ac0-4478-a257-49a7b993673d.jpg', CAST(111.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Offer] OFF
SET IDENTITY_INSERT [dbo].[OfferPhotos] ON 

INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1002, 1004, N'6f8c9c58-be2b-44fc-9a86-809f50c73668.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1003, 1004, N'e235e7fb-5f4d-4d9a-b08b-d05d1f7ec4ba.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1004, 1004, N'227261c1-1b33-499e-9d4b-29ee277290b4.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1005, 1004, N'ef4621e3-d5ca-45c5-9d98-79b61efb334e.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1006, 1005, N'684c5008-b8b7-422a-92e0-05c43015865e.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1007, 1005, N'201f57a2-c62a-4594-a22f-05734b836775.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1008, 1005, N'87a1910f-642f-47d5-a0c2-38aaeebdad1e.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1009, 1005, N'03ef09dc-a46a-451d-b0f4-525c42c3c97d.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1014, 1007, N'717f51a3-fd0a-4158-b1aa-950dc5f6206b.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1015, 1007, N'c9d5f641-c8ed-4d51-8c2b-8de2e1d59bdc.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1016, 1007, N'b082a346-a218-4c48-bc51-600660c1931e.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (1017, 1007, N'3ef16a88-387b-498a-8cb1-a5be23086a52.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2002, 2002, N'c1ce336c-96d2-42b0-8133-35f66831545c.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2009, 2002, N'796baa03-742f-46a0-a21a-a8cd81452bfe.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2011, 2002, N'e37c0892-5814-4189-9c99-557c5a08a60a.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2012, 2002, N'0dd927a2-e329-4437-826a-897c51abe9bd.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2026, 2008, N'4230cbc4-bf49-48c1-a11f-cd40a7e0514e.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2027, 2008, N'ba29108c-fed9-4284-8ae4-71772e680b21.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2028, 2008, N'3ce0c2a6-a336-4bf0-9650-e1950a7e97da.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2029, 2008, N'd9149eda-8ad4-4be0-a373-49415d381b56.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2030, 2009, N'2042f094-6e4b-4204-9ed9-5f21bd0e7795.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2031, 2009, N'37657ed4-bd74-4db6-ac7e-799df75f51e6.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2032, 2009, N'aab8291c-b5cd-4e87-b5e3-a00a0820deb8.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2033, 2009, N'28c5c61e-33f5-4d4d-9125-634b10829c23.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2034, 2010, N'65fb7e9b-04ae-4a4c-8540-26ee30b3d907.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2035, 2010, N'e622ff57-47a6-49b4-9130-f5bd5e686e89.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2036, 2010, N'a0949e01-4076-42fc-bb11-2439abe0fc99.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2037, 2010, N'064c2b34-1231-4a99-937a-fc69a0cb7948.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2038, 2011, N'78275bb5-8ac5-4bc7-97b9-c1b617442fc8.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2039, 2011, N'aa81e035-816d-4b3e-84de-d676b69bc117.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2040, 2011, N'60d6431a-d307-452f-8577-f98fad2bae9b.jpg')
INSERT [dbo].[OfferPhotos] ([Id], [offerID], [image]) VALUES (2041, 2011, N'2a1e2a70-e743-4990-8177-3bb39a217f8d.jpg')
SET IDENTITY_INSERT [dbo].[OfferPhotos] OFF
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([Id], [doctorID], [userID], [comment], [rate], [date]) VALUES (1, 1070, 1, N'جيد', 3, CAST(N'2022-09-20 12:00:00.0000000' AS DateTime2))
INSERT [dbo].[Review] ([Id], [doctorID], [userID], [comment], [rate], [date]) VALUES (2, 1070, 2, N'جيد جدا', 5, CAST(N'2022-09-20 12:00:00.0000000' AS DateTime2))
INSERT [dbo].[Review] ([Id], [doctorID], [userID], [comment], [rate], [date]) VALUES (3, 1070, 3, N'رائع', 3.5, CAST(N'2022-09-22 12:00:00.0000000' AS DateTime2))
INSERT [dbo].[Review] ([Id], [doctorID], [userID], [comment], [rate], [date]) VALUES (1002, 3054, 1004, N'جيد جدا', 4, CAST(N'2022-11-21 15:25:21.0133707' AS DateTime2))
INSERT [dbo].[Review] ([Id], [doctorID], [userID], [comment], [rate], [date]) VALUES (2002, 3054, 2002, N'جيد', 3, CAST(N'2022-12-04 16:17:18.5375708' AS DateTime2))
INSERT [dbo].[Review] ([Id], [doctorID], [userID], [comment], [rate], [date]) VALUES (2004, 3054, 3, N'good', 2, CAST(N'2022-12-04 16:19:47.2267549' AS DateTime2))
INSERT [dbo].[Review] ([Id], [doctorID], [userID], [comment], [rate], [date]) VALUES (2005, 1071, 3, N'جيد', 2, CAST(N'2022-12-04 16:20:23.4187035' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Review] OFF
SET IDENTITY_INSERT [dbo].[Specialization] ON 

INSERT [dbo].[Specialization] ([Id], [name]) VALUES (1, N'جراحة')
INSERT [dbo].[Specialization] ([Id], [name]) VALUES (2, N'علاج طبيعي')
INSERT [dbo].[Specialization] ([Id], [name]) VALUES (1040, N'عيون')
INSERT [dbo].[Specialization] ([Id], [name]) VALUES (1041, N'اسنان')
SET IDENTITY_INSERT [dbo].[Specialization] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [name], [email], [phone], [password], [IsActive]) VALUES (1, N'محمد سعيد', N'mohamed@gmail.com', N'01000000', N'123', 1)
INSERT [dbo].[User] ([Id], [name], [email], [phone], [password], [IsActive]) VALUES (2, N'علي', N'ali@gmail.com', N'01010', N'123', 1)
INSERT [dbo].[User] ([Id], [name], [email], [phone], [password], [IsActive]) VALUES (3, N'احمد', N'ahmed@gmail.com', N'01111111', N'123', 1)
INSERT [dbo].[User] ([Id], [name], [email], [phone], [password], [IsActive]) VALUES (1004, N'ahmed', N'ahmed.samyy4000@gmail.com', N'11111111', N'123', 1)
INSERT [dbo].[User] ([Id], [name], [email], [phone], [password], [IsActive]) VALUES (2002, N'محمد علي', N'user@gmail.com', N'01012345678', N'user', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Index [IX_Appointments_doctorID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_doctorID] ON [dbo].[Appointments]
(
	[doctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_userID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_userID] ON [dbo].[Appointments]
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClinicPhotos_doctorID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClinicPhotos_doctorID] ON [dbo].[ClinicPhotos]
(
	[doctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_cityID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_cityID] ON [dbo].[Doctor]
(
	[cityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Doctor_specializationID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Doctor_specializationID] ON [dbo].[Doctor]
(
	[specializationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DoctorAppointments_doctorID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_DoctorAppointments_doctorID] ON [dbo].[DoctorAppointments]
(
	[doctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Offer_doctorID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Offer_doctorID] ON [dbo].[Offer]
(
	[doctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OfferPhotos_offerID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_OfferPhotos_offerID] ON [dbo].[OfferPhotos]
(
	[offerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Review_doctorID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Review_doctorID] ON [dbo].[Review]
(
	[doctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Review_userID]    Script Date: 12/29/2022 3:55:27 PM ******/
CREATE NONCLUSTERED INDEX [IX_Review_userID] ON [dbo].[Review]
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Doctor_doctorID] FOREIGN KEY([doctorID])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Doctor_doctorID]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_User_userID] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_User_userID]
GO
ALTER TABLE [dbo].[ClinicPhotos]  WITH CHECK ADD  CONSTRAINT [FK_ClinicPhotos_Doctor_doctorID] FOREIGN KEY([doctorID])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[ClinicPhotos] CHECK CONSTRAINT [FK_ClinicPhotos_Doctor_doctorID]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_City_cityID] FOREIGN KEY([cityID])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_City_cityID]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Specialization_specializationID] FOREIGN KEY([specializationID])
REFERENCES [dbo].[Specialization] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Specialization_specializationID]
GO
ALTER TABLE [dbo].[DoctorAppointments]  WITH CHECK ADD  CONSTRAINT [FK_DoctorAppointments_Doctor_doctorID] FOREIGN KEY([doctorID])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[DoctorAppointments] CHECK CONSTRAINT [FK_DoctorAppointments_Doctor_doctorID]
GO
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Doctor_doctorID] FOREIGN KEY([doctorID])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Doctor_doctorID]
GO
ALTER TABLE [dbo].[OfferPhotos]  WITH CHECK ADD  CONSTRAINT [FK_OfferPhotos_Offer_offerID] FOREIGN KEY([offerID])
REFERENCES [dbo].[Offer] ([Id])
GO
ALTER TABLE [dbo].[OfferPhotos] CHECK CONSTRAINT [FK_OfferPhotos_Offer_offerID]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Doctor_doctorID] FOREIGN KEY([doctorID])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Doctor_doctorID]
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_User_userID] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_User_userID]
GO
USE [master]
GO
ALTER DATABASE [HealthcareBookingDB] SET  READ_WRITE 
GO
