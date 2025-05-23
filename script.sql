USE [master]
GO
/****** Object:  Database [ArabaKiralamaOtomasyonu]    Script Date: 21.05.2025 16:04:13 ******/
CREATE DATABASE [ArabaKiralamaOtomasyonu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArabaKiralamaOtomasyonu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ArabaKiralamaOtomasyonu.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArabaKiralamaOtomasyonu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ArabaKiralamaOtomasyonu_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArabaKiralamaOtomasyonu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET  MULTI_USER 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET QUERY_STORE = ON
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ArabaKiralamaOtomasyonu]
GO
/****** Object:  Table [dbo].[araba_yonetimi]    Script Date: 21.05.2025 16:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[araba_yonetimi](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[plaka] [nvarchar](max) NOT NULL,
	[marka] [nvarchar](50) NOT NULL,
	[seri] [nchar](20) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[kasa] [nvarchar](20) NOT NULL,
	[yili] [int] NOT NULL,
	[vites] [nvarchar](10) NOT NULL,
	[yakit] [nvarchar](20) NOT NULL,
	[rengi] [nvarchar](15) NOT NULL,
	[fotografi] [varbinary](max) NULL,
	[kira_ucreti] [int] NULL,
	[durumu] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__araba_yo__3213E83FEB0E73B0] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[kullanici]    Script Date: 21.05.2025 16:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kullanici](
	[k_adi] [nvarchar](25) NOT NULL,
	[k_soyadi] [nvarchar](25) NOT NULL,
	[k_sifre] [nvarchar](25) NOT NULL,
	[k_görevi] [nvarchar](25) NOT NULL,
	[k_adresi] [nvarchar](max) NOT NULL,
	[k_mail] [nvarchar](max) NOT NULL,
	[k_tel] [nvarchar](10) NOT NULL,
	[k_tel_yakin] [nvarchar](10) NOT NULL,
	[k_id] [int] IDENTITY(1,1) NOT NULL,
	[fotografi] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[musteri_yonetimi]    Script Date: 21.05.2025 16:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteri_yonetimi](
	[m_id] [smallint] IDENTITY(1,1) NOT NULL,
	[tc_no] [nvarchar](11) NOT NULL,
	[isim] [nvarchar](35) NOT NULL,
	[soy_isim] [nvarchar](25) NOT NULL,
	[tel1] [nvarchar](10) NOT NULL,
	[tel2] [nvarchar](10) NULL,
	[mail] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[m_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tc_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sozlesme]    Script Date: 21.05.2025 16:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sozlesme](
	[s_id] [smallint] IDENTITY(1,1) NOT NULL,
	[tc_no] [varchar](11) NOT NULL,
	[isim] [nvarchar](35) NOT NULL,
	[soy_isim] [nvarchar](25) NOT NULL,
	[telefon] [nvarchar](10) NOT NULL,
	[plaka] [nvarchar](max) NOT NULL,
	[marka] [nvarchar](50) NOT NULL,
	[seri] [nchar](20) NOT NULL,
	[model] [nvarchar](50) NOT NULL,
	[kasa] [nvarchar](20) NOT NULL,
	[yili] [nvarchar](10) NOT NULL,
	[vites] [nvarchar](10) NOT NULL,
	[yakit] [nvarchar](20) NOT NULL,
	[rengi] [nvarchar](15) NOT NULL,
	[kira_ucreti] [nvarchar](25) NOT NULL,
	[borcu] [nvarchar](25) NOT NULL,
	[gun] [nvarchar](25) NOT NULL,
	[baslangic] [datetime] NOT NULL,
	[bitis] [datetime] NOT NULL,
	[k_adi] [nvarchar](25) NOT NULL,
	[odeme_yontemi] [nchar](20) NOT NULL,
	[sDurumu] [nvarchar](20) NULL,
 CONSTRAINT [PK__sozlesme__2F3684F4045E7EFC] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tamamlananSozlesme]    Script Date: 21.05.2025 16:04:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tamamlananSozlesme](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[tc] [varchar](11) NOT NULL,
	[isim] [nvarchar](35) NOT NULL,
	[soyisim] [nvarchar](35) NOT NULL,
	[telefon] [nvarchar](10) NOT NULL,
	[plaka] [nvarchar](8) NOT NULL,
	[baslangic] [datetime] NOT NULL,
	[bitis] [datetime] NOT NULL,
	[gun] [nvarchar](25) NOT NULL,
	[ucret] [nchar](10) NULL,
	[k_adi] [nvarchar](25) NOT NULL,
	[durum] [nvarchar](20) NULL,
 CONSTRAINT [PK__tamamlan__3213E83F9F7296E7] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[araba_yonetimi] ADD  CONSTRAINT [DF_araba_durum]  DEFAULT ('MUSAIT') FOR [durumu]
GO
ALTER TABLE [dbo].[sozlesme] ADD  CONSTRAINT [DF__sozlesme__sDurum__681373AD]  DEFAULT ('Beklemede') FOR [sDurumu]
GO
ALTER TABLE [dbo].[tamamlananSozlesme] ADD  CONSTRAINT [DF__tamamlana__durum__671F4F74]  DEFAULT ('Aktif') FOR [durum]
GO
USE [master]
GO
ALTER DATABASE [ArabaKiralamaOtomasyonu] SET  READ_WRITE 
GO
