USE [master]
GO
/****** Object:  Database [B1_DB]    Script Date: 24.01.2024 17:56:00 ******/
CREATE DATABASE [B1_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'B1_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\B1_DB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'B1_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\B1_DB_log.ldf' , SIZE = 204800KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [B1_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [B1_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [B1_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [B1_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [B1_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [B1_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [B1_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [B1_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [B1_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [B1_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [B1_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [B1_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [B1_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [B1_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [B1_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [B1_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [B1_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [B1_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [B1_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [B1_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [B1_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [B1_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [B1_DB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [B1_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [B1_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [B1_DB] SET  MULTI_USER 
GO
ALTER DATABASE [B1_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [B1_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [B1_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [B1_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [B1_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [B1_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'B1_DB', N'ON'
GO
ALTER DATABASE [B1_DB] SET QUERY_STORE = OFF
GO
USE [B1_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24.01.2024 17:56:00 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblAccounts]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](max) NOT NULL,
	[TblSheetClassId] [int] NOT NULL,
 CONSTRAINT [PK_TblAccounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblBanks]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBanks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TblBanks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblClosedBalances]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblClosedBalances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActiveBalance] [decimal](18, 2) NOT NULL,
	[PassiveBalance] [decimal](18, 2) NOT NULL,
	[TblSheetClassId] [int] NOT NULL,
 CONSTRAINT [PK_TblClosedBalances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblContents]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](max) NOT NULL,
	[StringEU] [nvarchar](max) NOT NULL,
	[StringRU] [nvarchar](max) NOT NULL,
	[PositiveNumber] [nvarchar](max) NOT NULL,
	[FolatNumber] [nvarchar](max) NOT NULL,
	[TblDocumentId] [int] NOT NULL,
 CONSTRAINT [PK_TblContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblDocuments]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDocuments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TblDocuments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOpeningBalances]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOpeningBalances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActiveBalance] [decimal](18, 2) NOT NULL,
	[PassiveBalance] [decimal](18, 2) NOT NULL,
	[TblSheetClassId] [int] NOT NULL,
 CONSTRAINT [PK_TblOpeningBalances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblProcedureResults]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblProcedureResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalSumPositive] [bigint] NOT NULL,
	[MedianValue] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TblProcedureResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblSheetClasses]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblSheetClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TblSheetId] [int] NOT NULL,
	[SumTurnoversCredit] [decimal](18, 2) NOT NULL,
	[SumCloseActiveBalance] [decimal](18, 2) NOT NULL,
	[SumClosePassiveBalance] [decimal](18, 2) NOT NULL,
	[SumOpenActiveBalance] [decimal](18, 2) NOT NULL,
	[SumOpenPassiveBalance] [decimal](18, 2) NOT NULL,
	[SumTurnoversDebit] [decimal](18, 2) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TblSheetClasses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblSheets]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblSheets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TblBankId] [int] NOT NULL,
	[StartDate] [nvarchar](max) NOT NULL,
	[EndDate] [nvarchar](max) NOT NULL,
	[TotalSumCloseActiveBalance] [decimal](18, 2) NOT NULL,
	[TotalSumClosePassiveBalance] [decimal](18, 2) NOT NULL,
	[TotalSumOpenActiveBalance] [decimal](18, 2) NOT NULL,
	[TotalSumOpenPassiveBalance] [decimal](18, 2) NOT NULL,
	[TotalSumTurnoversCredit] [decimal](18, 2) NOT NULL,
	[TotalSumTurnoversDebit] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TblSheets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblTurnovers]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblTurnovers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[TblSheetClassId] [int] NOT NULL,
 CONSTRAINT [PK_TblTurnovers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblAccounts_TblSheetClassId]    Script Date: 24.01.2024 17:56:00 ******/
CREATE NONCLUSTERED INDEX [IX_TblAccounts_TblSheetClassId] ON [dbo].[TblAccounts]
(
	[TblSheetClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblClosedBalances_TblSheetClassId]    Script Date: 24.01.2024 17:56:00 ******/
CREATE NONCLUSTERED INDEX [IX_TblClosedBalances_TblSheetClassId] ON [dbo].[TblClosedBalances]
(
	[TblSheetClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblContents_TblDocumentId]    Script Date: 24.01.2024 17:56:00 ******/
CREATE NONCLUSTERED INDEX [IX_TblContents_TblDocumentId] ON [dbo].[TblContents]
(
	[TblDocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblOpeningBalances_TblSheetClassId]    Script Date: 24.01.2024 17:56:00 ******/
CREATE NONCLUSTERED INDEX [IX_TblOpeningBalances_TblSheetClassId] ON [dbo].[TblOpeningBalances]
(
	[TblSheetClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblSheetClasses_TblSheetId]    Script Date: 24.01.2024 17:56:00 ******/
CREATE NONCLUSTERED INDEX [IX_TblSheetClasses_TblSheetId] ON [dbo].[TblSheetClasses]
(
	[TblSheetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblSheets_TblBankId]    Script Date: 24.01.2024 17:56:00 ******/
CREATE NONCLUSTERED INDEX [IX_TblSheets_TblBankId] ON [dbo].[TblSheets]
(
	[TblBankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TblTurnovers_TblSheetClassId]    Script Date: 24.01.2024 17:56:00 ******/
CREATE NONCLUSTERED INDEX [IX_TblTurnovers_TblSheetClassId] ON [dbo].[TblTurnovers]
(
	[TblSheetClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TblDocuments] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[TblSheetClasses] ADD  DEFAULT ((0.0)) FOR [SumTurnoversCredit]
GO
ALTER TABLE [dbo].[TblSheetClasses] ADD  DEFAULT ((0.0)) FOR [SumCloseActiveBalance]
GO
ALTER TABLE [dbo].[TblSheetClasses] ADD  DEFAULT ((0.0)) FOR [SumClosePassiveBalance]
GO
ALTER TABLE [dbo].[TblSheetClasses] ADD  DEFAULT ((0.0)) FOR [SumOpenActiveBalance]
GO
ALTER TABLE [dbo].[TblSheetClasses] ADD  DEFAULT ((0.0)) FOR [SumOpenPassiveBalance]
GO
ALTER TABLE [dbo].[TblSheetClasses] ADD  DEFAULT ((0.0)) FOR [SumTurnoversDebit]
GO
ALTER TABLE [dbo].[TblSheetClasses] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[TblSheets] ADD  DEFAULT (N'') FOR [EndDate]
GO
ALTER TABLE [dbo].[TblSheets] ADD  DEFAULT ((0.0)) FOR [TotalSumCloseActiveBalance]
GO
ALTER TABLE [dbo].[TblSheets] ADD  DEFAULT ((0.0)) FOR [TotalSumClosePassiveBalance]
GO
ALTER TABLE [dbo].[TblSheets] ADD  DEFAULT ((0.0)) FOR [TotalSumOpenActiveBalance]
GO
ALTER TABLE [dbo].[TblSheets] ADD  DEFAULT ((0.0)) FOR [TotalSumOpenPassiveBalance]
GO
ALTER TABLE [dbo].[TblSheets] ADD  DEFAULT ((0.0)) FOR [TotalSumTurnoversCredit]
GO
ALTER TABLE [dbo].[TblSheets] ADD  DEFAULT ((0.0)) FOR [TotalSumTurnoversDebit]
GO
ALTER TABLE [dbo].[TblAccounts]  WITH CHECK ADD  CONSTRAINT [FK_TblAccounts_TblSheetClasses_TblSheetClassId] FOREIGN KEY([TblSheetClassId])
REFERENCES [dbo].[TblSheetClasses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblAccounts] CHECK CONSTRAINT [FK_TblAccounts_TblSheetClasses_TblSheetClassId]
GO
ALTER TABLE [dbo].[TblClosedBalances]  WITH CHECK ADD  CONSTRAINT [FK_TblClosedBalances_TblSheetClasses_TblSheetClassId] FOREIGN KEY([TblSheetClassId])
REFERENCES [dbo].[TblSheetClasses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblClosedBalances] CHECK CONSTRAINT [FK_TblClosedBalances_TblSheetClasses_TblSheetClassId]
GO
ALTER TABLE [dbo].[TblContents]  WITH CHECK ADD  CONSTRAINT [FK_TblContents_TblDocuments_TblDocumentId] FOREIGN KEY([TblDocumentId])
REFERENCES [dbo].[TblDocuments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblContents] CHECK CONSTRAINT [FK_TblContents_TblDocuments_TblDocumentId]
GO
ALTER TABLE [dbo].[TblOpeningBalances]  WITH CHECK ADD  CONSTRAINT [FK_TblOpeningBalances_TblSheetClasses_TblSheetClassId] FOREIGN KEY([TblSheetClassId])
REFERENCES [dbo].[TblSheetClasses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblOpeningBalances] CHECK CONSTRAINT [FK_TblOpeningBalances_TblSheetClasses_TblSheetClassId]
GO
ALTER TABLE [dbo].[TblSheetClasses]  WITH CHECK ADD  CONSTRAINT [FK_TblSheetClasses_TblSheets_TblSheetId] FOREIGN KEY([TblSheetId])
REFERENCES [dbo].[TblSheets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSheetClasses] CHECK CONSTRAINT [FK_TblSheetClasses_TblSheets_TblSheetId]
GO
ALTER TABLE [dbo].[TblSheets]  WITH CHECK ADD  CONSTRAINT [FK_TblSheets_TblBanks_TblBankId] FOREIGN KEY([TblBankId])
REFERENCES [dbo].[TblBanks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblSheets] CHECK CONSTRAINT [FK_TblSheets_TblBanks_TblBankId]
GO
ALTER TABLE [dbo].[TblTurnovers]  WITH CHECK ADD  CONSTRAINT [FK_TblTurnovers_TblSheetClasses_TblSheetClassId] FOREIGN KEY([TblSheetClassId])
REFERENCES [dbo].[TblSheetClasses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TblTurnovers] CHECK CONSTRAINT [FK_TblTurnovers_TblSheetClasses_TblSheetClassId]
GO
/****** Object:  StoredProcedure [dbo].[CalculateSumAndMedianForTblContent]    Script Date: 24.01.2024 17:56:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalculateSumAndMedianForTblContent]
AS
BEGIN
    DECLARE @SumPositive BIGINT
	DECLARE @Median DECIMAL(18, 8);

    SELECT @SumPositive = SUM(TRY_CAST(PositiveNumber AS BIGINT))
    FROM dbo.TblContents
    WHERE ISNUMERIC(PositiveNumber) = 1 AND TRY_CAST(PositiveNumber AS BIGINT) IS NOT NULL;

	WITH OrderedFolatNumbers AS (
		SELECT 
			CAST(REPLACE(FolatNumber, ',', '.') AS DECIMAL(18, 8)) AS ConvertedFolatNumber,
			ROW_NUMBER() OVER (ORDER BY CAST(REPLACE(FolatNumber, ',', '.') AS DECIMAL(18, 8))) AS RowAsc,
			ROW_NUMBER() OVER (ORDER BY CAST(REPLACE(FolatNumber, ',', '.') AS DECIMAL(18, 8)) DESC) AS RowDesc
		FROM dbo.TblContents
		WHERE FolatNumber IS NOT NULL AND ISNUMERIC(FolatNumber) = 1
	)
	SELECT @Median = AVG(ConvertedFolatNumber)
	FROM OrderedFolatNumbers
	WHERE RowAsc = RowDesc OR RowAsc + 1 = RowDesc OR RowAsc = RowDesc + 1;
	INSERT INTO TblProcedureResults (TotalSumPositive,MedianValue)
	VALUES (@SumPositive,@Median)
    SELECT @SumPositive AS TotalSumPositive, @Median AS MedianValue;

END

GO
USE [master]
GO
ALTER DATABASE [B1_DB] SET  READ_WRITE 
GO
