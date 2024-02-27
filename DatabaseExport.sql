USE [master]
GO
/****** Object:  Database [pirich]    Script Date: 27.02.2024 23:07:00 ******/
CREATE DATABASE [pirich]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pirich', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\pirich.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pirich_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\pirich_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [pirich] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pirich].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pirich] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pirich] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pirich] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pirich] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pirich] SET ARITHABORT OFF 
GO
ALTER DATABASE [pirich] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [pirich] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pirich] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pirich] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pirich] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pirich] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pirich] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pirich] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pirich] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pirich] SET  ENABLE_BROKER 
GO
ALTER DATABASE [pirich] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pirich] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pirich] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pirich] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pirich] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pirich] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pirich] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pirich] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [pirich] SET  MULTI_USER 
GO
ALTER DATABASE [pirich] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pirich] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pirich] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pirich] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pirich] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pirich] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [pirich] SET QUERY_STORE = OFF
GO
USE [pirich]
GO
/****** Object:  Table [dbo].[CZslovnik]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CZslovnik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[slovo] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ENslovnik]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENslovnik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[word] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[link]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[link](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CZ_id] [int] NOT NULL,
	[EN_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machine]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[dimenX] [varchar](50) NOT NULL,
	[dimenY] [varchar](50) NOT NULL,
	[dimenZ] [varchar](50) NOT NULL,
	[price] [int] NOT NULL,
	[value] [decimal](3, 2) NULL,
	[manufacturer_id] [int] NOT NULL,
	[isNew] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[surname] [varchar](20) NOT NULL,
	[dateOfBirth] [date] NULL,
	[plat] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhoneNumber]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneNumber](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[phoneNumber] [varchar](20) NOT NULL,
	[manufacturer_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Replacement]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Replacement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[spareParts_id] [int] NOT NULL,
	[machine_id] [int] NOT NULL,
	[date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpareParts]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpareParts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[dimenX] [varchar](50) NOT NULL,
	[dimenY] [varchar](50) NOT NULL,
	[dimenZ] [varchar](50) NOT NULL,
	[price] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tabulka]    Script Date: 27.02.2024 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tabulka](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Machine] ON 
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (7, N'Type A', N'Machine 1', N'10', N'20', N'30', 1000, CAST(9.99 AS Decimal(3, 2)), 1, 1)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (8, N'Type B', N'Machine 2', N'15', N'25', N'35', 1500, CAST(9.99 AS Decimal(3, 2)), 2, 0)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (9, N'Type C', N'Machine 3', N'20', N'30', N'40', 2000, CAST(9.99 AS Decimal(3, 2)), 3, 1)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (10, N'Type D', N'Machine 4', N'25', N'35', N'45', 2500, CAST(9.99 AS Decimal(3, 2)), 4, 0)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (11, N'Type E', N'Machine 5', N'30', N'40', N'50', 3000, CAST(9.99 AS Decimal(3, 2)), 5, 1)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (12, N'Type F', N'Machine 6', N'35', N'45', N'55', 3500, CAST(9.99 AS Decimal(3, 2)), 6, 0)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (13, N'Type G', N'Machine 7', N'40', N'50', N'60', 4000, CAST(9.99 AS Decimal(3, 2)), 7, 1)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (14, N'Type H', N'Machine 8', N'45', N'55', N'65', 4500, CAST(9.99 AS Decimal(3, 2)), 8, 0)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (15, N'Type I', N'Machine 9', N'50', N'60', N'70', 5000, CAST(9.99 AS Decimal(3, 2)), 9, 1)
GO
INSERT [dbo].[Machine] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price], [value], [manufacturer_id], [isNew]) VALUES (16, N'Type J', N'Machine 10', N'55', N'65', N'75', 5500, CAST(9.99 AS Decimal(3, 2)), 10, 0)
GO
SET IDENTITY_INSERT [dbo].[Machine] OFF
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (1, N'Manufacturer A')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (2, N'Manufacturer B')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (3, N'Manufacturer C')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (4, N'Manufacturer D')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (5, N'Manufacturer E')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (6, N'Manufacturer F')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (7, N'Manufacturer G')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (8, N'Manufacturer H')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (9, N'Manufacturer I')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (10, N'Manufacturer J')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (11, N'PBworks')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (12, N'ABC.inc')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (14, N'AFG.works')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (15, N'GGboost.works')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (16, N'GGboost.works')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (17, N'Jecna.inc')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (18, N'hello.xd')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (19, N'Jecna.corp')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (20, N'Jecna.inc')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (21, N'Jecna.inc')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (22, N'Zitna.inc')
GO
INSERT [dbo].[Manufacturer] ([id], [name]) VALUES (23, N'Panska.inc')
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
GO
SET IDENTITY_INSERT [dbo].[PhoneNumber] ON 
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (1, N'1234567890', 1)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (2, N'2345678901', 2)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (3, N'3456789012', 3)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (4, N'4567890123', 4)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (5, N'5678901234', 5)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (6, N'6789012345', 6)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (7, N'7890123456', 7)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (8, N'8901234567', 8)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (9, N'9012345678', 9)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (10, N'0123456789', 10)
GO
INSERT [dbo].[PhoneNumber] ([id], [phoneNumber], [manufacturer_id]) VALUES (13, N'+4204898984', 1)
GO
SET IDENTITY_INSERT [dbo].[PhoneNumber] OFF
GO
SET IDENTITY_INSERT [dbo].[Replacement] ON 
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (5, 1, 7, CAST(N'2023-01-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (6, 2, 8, CAST(N'2023-02-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (7, 3, 9, CAST(N'2023-03-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (8, 4, 10, CAST(N'2023-04-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (9, 5, 11, CAST(N'2023-05-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (10, 6, 12, CAST(N'2023-06-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (12, 8, 14, CAST(N'2023-08-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (13, 9, 15, CAST(N'2023-09-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (14, 10, 16, CAST(N'2023-10-01' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (15, 8, 10, CAST(N'2005-12-20' AS Date))
GO
INSERT [dbo].[Replacement] ([id], [spareParts_id], [machine_id], [date]) VALUES (16, 8, 8, CAST(N'1970-01-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Replacement] OFF
GO
SET IDENTITY_INSERT [dbo].[SpareParts] ON 
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (1, N'Type A', N'Spare Part 1', N'5', N'5', N'5', 50)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (2, N'Type B', N'Spare Part 2', N'10', N'10', N'10', 100)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (3, N'Type C', N'Spare Part 3', N'15', N'15', N'15', 150)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (4, N'Type D', N'Spare Part 4', N'20', N'20', N'20', 200)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (5, N'Type E', N'Spare Part 5', N'25', N'25', N'25', 250)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (6, N'Type F', N'Spare Part 6', N'30', N'30', N'30', 300)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (7, N'Type G', N'Spare Part 7', N'35', N'35', N'35', 350)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (8, N'Type H', N'Spare Part 8', N'40', N'40', N'40', 400)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (9, N'Type I', N'Spare Part 9', N'45', N'45', N'45', 450)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (10, N'Type J', N'Spare Part 10', N'50', N'50', N'50', 500)
GO
INSERT [dbo].[SpareParts] ([id], [type], [name], [dimenX], [dimenY], [dimenZ], [price]) VALUES (11, N'dfdfdf', N'dfdfdf', N'dfdfdf', N'dfdfdf', N'dfdffd', 150)
GO
SET IDENTITY_INSERT [dbo].[SpareParts] OFF
GO
SET IDENTITY_INSERT [dbo].[Tabulka] ON 
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (1, N'Ahoj')
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (2, N'Ahoj')
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (3, N'Ahoj')
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (4, N'Ahoj')
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (5, N'Ahoj')
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (6, N'Ahoj')
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (7, N'hallo')
GO
INSERT [dbo].[Tabulka] ([id], [text]) VALUES (8, N'hallo')
GO
SET IDENTITY_INSERT [dbo].[Tabulka] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__CZslovni__63108060B7479FEA]    Script Date: 27.02.2024 23:07:01 ******/
ALTER TABLE [dbo].[CZslovnik] ADD UNIQUE NONCLUSTERED 
(
	[slovo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ENslovni__83974054CBC5C4ED]    Script Date: 27.02.2024 23:07:01 ******/
ALTER TABLE [dbo].[ENslovnik] ADD UNIQUE NONCLUSTERED 
(
	[word] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PhoneNum__4849DA01D38B3EF9]    Script Date: 27.02.2024 23:07:01 ******/
ALTER TABLE [dbo].[PhoneNumber] ADD UNIQUE NONCLUSTERED 
(
	[phoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[link]  WITH CHECK ADD FOREIGN KEY([CZ_id])
REFERENCES [dbo].[CZslovnik] ([id])
GO
ALTER TABLE [dbo].[link]  WITH CHECK ADD FOREIGN KEY([EN_id])
REFERENCES [dbo].[ENslovnik] ([id])
GO
ALTER TABLE [dbo].[Machine]  WITH CHECK ADD FOREIGN KEY([manufacturer_id])
REFERENCES [dbo].[Manufacturer] ([id])
GO
ALTER TABLE [dbo].[PhoneNumber]  WITH CHECK ADD FOREIGN KEY([manufacturer_id])
REFERENCES [dbo].[Manufacturer] ([id])
GO
ALTER TABLE [dbo].[Replacement]  WITH CHECK ADD FOREIGN KEY([machine_id])
REFERENCES [dbo].[Machine] ([id])
GO
ALTER TABLE [dbo].[Replacement]  WITH CHECK ADD FOREIGN KEY([spareParts_id])
REFERENCES [dbo].[SpareParts] ([id])
GO
USE [master]
GO
ALTER DATABASE [pirich] SET  READ_WRITE 
GO
