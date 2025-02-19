USE [InventoryDB]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Suppliers', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Employees]
GO
ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [FK_Suppliers_People]
GO
ALTER TABLE [dbo].[SalesDetails] DROP CONSTRAINT [FK__SalesDeta__SaleI__2FCF1A8A]
GO
ALTER TABLE [dbo].[SalesDetails] DROP CONSTRAINT [FK__SalesDeta__Produ__30C33EC3]
GO
ALTER TABLE [dbo].[SalesDetails] DROP CONSTRAINT [FK__SalesDeta__Batch__31B762FC]
GO
ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK__Sales__CustomerI__0B91BA14]
GO
ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK__Purchases__Suppl__08B54D69]
GO
ALTER TABLE [dbo].[PurchaseDetails] DROP CONSTRAINT [FK__PurchaseD__Purch__245D67DE]
GO
ALTER TABLE [dbo].[PurchaseDetails] DROP CONSTRAINT [FK__PurchaseD__Produ__25518C17]
GO
ALTER TABLE [dbo].[PurchaseDetails] DROP CONSTRAINT [FK__PurchaseD__Batch__2645B050]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK__Products__Catego__19DFD96B]
GO
ALTER TABLE [dbo].[ProductBatches] DROP CONSTRAINT [FK__ProductBa__Suppl__1F98B2C1]
GO
ALTER TABLE [dbo].[ProductBatches] DROP CONSTRAINT [FK__ProductBa__Produ__1EA48E88]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_People]
GO
ALTER TABLE [dbo].[DamagedProducts] DROP CONSTRAINT [FK__DamagedPr__Produ__37703C52]
GO
ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [DF__Suppliers__Modif__70DDC3D8]
GO
ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [DF__Suppliers__Creat__6FE99F9F]
GO
ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [DF__Suppliers__IsAct__6EF57B66]
GO
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF__Roles__ModifiedD__6383C8BA]
GO
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF__Roles__CreatedDa__628FA481]
GO
ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [DF__Purchases__Updat__07C12930]
GO
ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [DF__Purchases__Creat__06CD04F7]
GO
ALTER TABLE [dbo].[PurchaseDetails] DROP CONSTRAINT [DF__PurchaseD__Modif__236943A5]
GO
ALTER TABLE [dbo].[PurchaseDetails] DROP CONSTRAINT [DF__PurchaseD__Creat__22751F6C]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [DF__Products__IsActi__18EBB532]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [DF__Products__StockL__17F790F9]
GO
ALTER TABLE [dbo].[ProductBatches] DROP CONSTRAINT [DF__ProductBa__Creat__1DB06A4F]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF__Employees__Modif__5E8A0973]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF__Employees__Creat__5D95E53A]
GO
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [DF__Employees__IsAct__5CA1C101]
GO
ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [DF__Customers__Modif__03F0984C]
GO
ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [DF__Customers__Creat__02FC7413]
GO
ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [DF__Customers__IsAct__02084FDA]
GO
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF__Categorie__IsAct__10566F31]
GO
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF__Categorie__Creat__0F624AF8]
GO
/****** Object:  Index [UQ__Roles__8A2B6160BDB72723]    Script Date: 2/16/2025 6:33:15 AM ******/
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [UQ__Roles__8A2B6160BDB72723]
GO
/****** Object:  Index [UQ__ProductB__F869ED6DA3E801A3]    Script Date: 2/16/2025 6:33:15 AM ******/
ALTER TABLE [dbo].[ProductBatches] DROP CONSTRAINT [UQ__ProductB__F869ED6DA3E801A3]
GO
/****** Object:  Index [UQ__Categori__8517B2E014776F0C]    Script Date: 2/16/2025 6:33:15 AM ******/
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [UQ__Categori__8517B2E014776F0C]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suppliers]') AND type in (N'U'))
DROP TABLE [dbo].[Suppliers]
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SalesDetails]') AND type in (N'U'))
DROP TABLE [dbo].[SalesDetails]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sales]') AND type in (N'U'))
DROP TABLE [dbo].[Sales]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Purchases]') AND type in (N'U'))
DROP TABLE [dbo].[Purchases]
GO
/****** Object:  Table [dbo].[PurchaseDetails]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseDetails]') AND type in (N'U'))
DROP TABLE [dbo].[PurchaseDetails]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[ProductBatches]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductBatches]') AND type in (N'U'))
DROP TABLE [dbo].[ProductBatches]
GO
/****** Object:  Table [dbo].[DamagedProducts]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DamagedProducts]') AND type in (N'U'))
DROP TABLE [dbo].[DamagedProducts]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO
/****** Object:  View [dbo].[EmployeesData]    Script Date: 2/16/2025 6:33:15 AM ******/
DROP VIEW [dbo].[EmployeesData]
GO
/****** Object:  Table [dbo].[People]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND type in (N'U'))
DROP TABLE [dbo].[People]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2/16/2025 6:33:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
DROP TABLE [dbo].[Employees]
GO
USE [master]
GO
/****** Object:  Database [InventoryDB]    Script Date: 2/16/2025 6:33:15 AM ******/
DROP DATABASE [InventoryDB]
GO
/****** Object:  Database [InventoryDB]    Script Date: 2/16/2025 6:33:15 AM ******/
CREATE DATABASE [InventoryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [InventoryDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InventoryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryDB] SET RECOVERY FULL 
GO
ALTER DATABASE [InventoryDB] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'InventoryDB', N'ON'
GO
ALTER DATABASE [InventoryDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [InventoryDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [InventoryDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Designation] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
	[Salary] [smallmoney] NOT NULL,
	[Notes] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Employee__7AD04FF1C0098945] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[EmployeesData]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[EmployeesData] AS
SELECT 
    Employees.EmployeeID, 
    Employees.PersonID, 
    People.Name, 
    People.Phone, 
    People.Email, 
    People.Address, 
    Employees.Designation, 
    Employees.Department, 
    Employees.Salary, 
    Employees.Notes, 
    Employees.IsActive, 
    Employees.CreatedDate, 
    Employees.ModifiedDate
FROM 
    Employees 
INNER JOIN 
    People 
ON 
    Employees.PersonID = People.PersonID;
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK__Categori__19093A2BDC836FA6] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Notes] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Customer__A4AE64B82068C2F9] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DamagedProducts]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DamagedProducts](
	[DamageID] [int] IDENTITY(1,1) NOT NULL,
	[ProductBatchID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Reason] [nvarchar](255) NULL,
	[DateReported] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DamageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductBatches]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductBatches](
	[BatchID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[BatchNumber] [nvarchar](50) NOT NULL,
	[ProductionDate] [datetime] NOT NULL,
	[ExpiryDate] [datetime] NULL,
	[Quantity] [int] NOT NULL,
	[PurchasePricePerUnit] [decimal](12, 2) NOT NULL,
	[SellingPricePerUnit] [decimal](12, 2) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK__ProductB__5D55CE38A808E0CE] PRIMARY KEY CLUSTERED 
(
	[BatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[UnitOfMeasure] [nvarchar](20) NOT NULL,
	[PricePerUnit] [decimal](12, 2) NOT NULL,
	[StockLevel] [int] NOT NULL,
	[ReorderLevel] [int] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseDetails]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetails](
	[PurchaseDetailID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[BatchID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PricePerUnit] [decimal](12, 2) NOT NULL,
	[TotalPrice]  AS ([Quantity]*[PricePerUnit]) PERSISTED,
	[ReceivedDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[PurchaseID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[TotalPrice] [decimal](12, 2) NOT NULL,
	[TotalPaid] [decimal](12, 2) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Notes] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[TotalPrice] [decimal](12, 2) NOT NULL,
	[TotalPaid] [decimal](12, 2) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Notes] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesDetails]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDetails](
	[SaleDetailID] [int] IDENTITY(1,1) NOT NULL,
	[SaleID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[BatchID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PricePerUnit] [decimal](12, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Notes] [nvarchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Supplier__4BE6669466C00A2C] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/16/2025 6:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK__Users__1788CCAC0026019A] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (1, N'Electronics', N'Devices like phones, tablets, and laptops', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (2, N'Home Appliances', N'Refrigerators, washing machines, and more', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (3, N'Furniture', N'Tables, chairs, and office furniture', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (4, N'Clothing', N'Men, women, and kids apparel', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (5, N'Footwear', N'Shoes, sandals, and boots', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (6, N'Accessories', N'Bags, watches, and jewelry', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (7, N'Groceries', N'Food items and daily essentials', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (8, N'Books', N'Educational and leisure reading material', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (9, N'Toys', N'Children’s toys and games', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [CreatedDate], [IsActive]) VALUES (10, N'Sports Equipment', N'Fitness and outdoor sports gear', CAST(N'2025-01-22T09:05:57.010' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, 1, N'Regular customer', 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, 2, N'Wholesale buyer', 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, 3, NULL, 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, 4, N'Bulk purchases in Q4', 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, 5, NULL, 0, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, 6, NULL, 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (7, 7, N'Frequent buyer', 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (8, 8, N'Loyal customer since 2022', 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (9, 9, NULL, 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
INSERT [dbo].[Customers] ([CustomerID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (10, 10, NULL, 1, CAST(N'2025-01-22T05:20:31.843' AS DateTime), CAST(N'2025-01-22T05:20:31.843' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[DamagedProducts] ON 

INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (1, 1, 5, N'Expired', CAST(N'2025-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (2, 2, 3, N'Defective packaging', CAST(N'2025-01-05T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (3, 3, 9, N'Storage damage', CAST(N'2025-01-10T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (4, 4, 8, N'Transit damage', CAST(N'2025-01-12T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (5, 5, 2, N'Incorrect labeling', CAST(N'2025-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (6, 6, 10, N'Expired', CAST(N'2025-01-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (7, 7, 7, N'Damaged during unloading', CAST(N'2025-01-17T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (8, 8, 4, N'Leaking containers', CAST(N'2025-01-18T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (9, 9, 6, N'Spoiled', CAST(N'2025-01-19T00:00:00.000' AS DateTime))
INSERT [dbo].[DamagedProducts] ([DamageID], [ProductBatchID], [Quantity], [Reason], [DateReported]) VALUES (10, 10, 1, N'Expired', CAST(N'2025-01-20T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DamagedProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [Designation], [Department], [Salary], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, 1, N'Manager', N'Sales', 2000.0000, N'Experienced sales manager', 1, CAST(N'2025-02-03T03:39:39.023' AS DateTime), CAST(N'2025-02-03T03:39:39.023' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [Designation], [Department], [Salary], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, 2, N'Software Engineer', N'IT', 5000.0000, N'Backend developer', 1, CAST(N'2025-02-03T03:39:39.023' AS DateTime), CAST(N'2025-02-03T03:39:39.023' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [Designation], [Department], [Salary], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, 3, N'HR Specialist', N'Human Resources', 3000.0000, N'Handles recruitment', 1, CAST(N'2025-02-03T03:39:39.023' AS DateTime), CAST(N'2025-02-03T03:39:39.023' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [Designation], [Department], [Salary], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, 4, N'Accountant', N'Finance', 4000.0000, N'Manages company finances', 1, CAST(N'2025-02-03T03:39:39.023' AS DateTime), CAST(N'2025-02-03T03:39:39.023' AS DateTime))
INSERT [dbo].[Employees] ([EmployeeID], [PersonID], [Designation], [Department], [Salary], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, 5, N'Marketing Lead', N'Marketing', 1000.0000, N'Social media strategist', 1, CAST(N'2025-02-03T03:39:39.023' AS DateTime), CAST(N'2025-02-03T03:39:39.023' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (1, N'Mohamed Hany', N'01125226780', N'mh@gmail.com', N'123 Updated Street')
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (2, N'Jane Smith', N'234-567-8901', N'janesmith@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (3, N'Michael Johnson', N'345-678-9012', N'michaelj@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (4, N'Emily Davis', N'456-789-0123', N'emilyd@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (5, N'David Wilson', N'567-890-1234', N'davidw@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (6, N'Sarah Brown', N'678-901-2345', N'sarahb@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (7, N'James Taylor', N'789-012-3456', N'jamest@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (8, N'Olivia Anderson', N'890-123-4567', N'oliviaa@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (9, N'William Thomas', N'901-234-5678', N'williamt@example.com', NULL)
INSERT [dbo].[People] ([PersonID], [Name], [Phone], [Email], [Address]) VALUES (10, N'Sophia Martinez', N'012-345-6789', N'sophiam@example.com', NULL)
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductBatches] ON 

INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (1, 1, N'B20250101', CAST(N'2025-01-01T00:00:00.000' AS DateTime), CAST(N'2026-01-01T00:00:00.000' AS DateTime), 50, CAST(500.00 AS Decimal(12, 2)), CAST(600.00 AS Decimal(12, 2)), 1, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (2, 2, N'B20250102', CAST(N'2025-01-01T00:00:00.000' AS DateTime), NULL, 30, CAST(1000.00 AS Decimal(12, 2)), CAST(1200.00 AS Decimal(12, 2)), 2, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (3, 3, N'B20250103', CAST(N'2024-12-15T00:00:00.000' AS DateTime), NULL, 100, CAST(120.00 AS Decimal(12, 2)), CAST(150.00 AS Decimal(12, 2)), 3, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (4, 4, N'B20250104', CAST(N'2024-11-20T00:00:00.000' AS DateTime), CAST(N'2025-11-20T00:00:00.000' AS DateTime), 10, CAST(700.00 AS Decimal(12, 2)), CAST(800.00 AS Decimal(12, 2)), 4, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (5, 5, N'B20250105', CAST(N'2025-01-01T00:00:00.000' AS DateTime), CAST(N'2025-07-01T00:00:00.000' AS DateTime), 200, CAST(10.00 AS Decimal(12, 2)), CAST(15.00 AS Decimal(12, 2)), 5, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (6, 6, N'B20250106', CAST(N'2025-01-01T00:00:00.000' AS DateTime), NULL, 75, CAST(40.00 AS Decimal(12, 2)), CAST(50.00 AS Decimal(12, 2)), 6, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (7, 7, N'B20250107', CAST(N'2025-01-10T00:00:00.000' AS DateTime), CAST(N'2026-01-10T00:00:00.000' AS DateTime), 40, CAST(60.00 AS Decimal(12, 2)), CAST(80.00 AS Decimal(12, 2)), 7, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (8, 8, N'B20250108', CAST(N'2024-12-01T00:00:00.000' AS DateTime), NULL, 500, CAST(5.00 AS Decimal(12, 2)), CAST(10.00 AS Decimal(12, 2)), 8, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (9, 9, N'B20250109', CAST(N'2025-01-05T00:00:00.000' AS DateTime), CAST(N'2025-12-31T00:00:00.000' AS DateTime), 150, CAST(10.00 AS Decimal(12, 2)), CAST(20.00 AS Decimal(12, 2)), 9, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
INSERT [dbo].[ProductBatches] ([BatchID], [ProductID], [BatchNumber], [ProductionDate], [ExpiryDate], [Quantity], [PurchasePricePerUnit], [SellingPricePerUnit], [SupplierID], [CreatedDate]) VALUES (10, 10, N'B20250110', CAST(N'2025-01-15T00:00:00.000' AS DateTime), NULL, 20, CAST(80.00 AS Decimal(12, 2)), CAST(100.00 AS Decimal(12, 2)), 10, CAST(N'2025-01-22T09:36:47.987' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProductBatches] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (1, N'Phone', 1, N'Piece', CAST(600.00 AS Decimal(12, 2)), 50, 20, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (2, N'Laptop', 1, N'Piece', CAST(1200.00 AS Decimal(12, 2)), 30, 10, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (3, N'Chair', 3, N'Piece', CAST(150.00 AS Decimal(12, 2)), 100, 25, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (4, N'Refrigerator', 2, N'Piece', CAST(800.00 AS Decimal(12, 2)), 10, 5, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (5, N'T-Shirt', 4, N'Piece', CAST(15.00 AS Decimal(12, 2)), 200, 50, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (6, N'Shoes', 5, N'Pair', CAST(50.00 AS Decimal(12, 2)), 75, 20, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (7, N'Watch', 6, N'Piece', CAST(80.00 AS Decimal(12, 2)), 40, 10, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (8, N'Book', 8, N'Piece', CAST(10.00 AS Decimal(12, 2)), 500, 100, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (9, N'Toy', 9, N'Piece', CAST(20.00 AS Decimal(12, 2)), 150, 30, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [CategoryID], [UnitOfMeasure], [PricePerUnit], [StockLevel], [ReorderLevel], [IsActive]) VALUES (10, N'Dumbbell Set', 10, N'Set', CAST(100.00 AS Decimal(12, 2)), 20, 5, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseDetails] ON 

INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (4, 1, 1, 1, 20, CAST(500.00 AS Decimal(12, 2)), CAST(N'2025-01-02T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (5, 6, 2, 2, 10, CAST(1000.00 AS Decimal(12, 2)), CAST(N'2025-01-02T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (6, 2, 3, 3, 50, CAST(120.00 AS Decimal(12, 2)), CAST(N'2025-01-12T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (7, 7, 4, 4, 5, CAST(700.00 AS Decimal(12, 2)), CAST(N'2025-01-12T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (8, 3, 5, 5, 50, CAST(10.00 AS Decimal(12, 2)), CAST(N'2025-01-14T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (9, 8, 6, 6, 10, CAST(40.00 AS Decimal(12, 2)), CAST(N'2025-01-14T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (10, 4, 7, 7, 20, CAST(60.00 AS Decimal(12, 2)), CAST(N'2025-01-16T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (11, 9, 8, 8, 100, CAST(5.00 AS Decimal(12, 2)), CAST(N'2025-01-16T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (12, 5, 9, 9, 50, CAST(10.00 AS Decimal(12, 2)), CAST(N'2025-01-18T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
INSERT [dbo].[PurchaseDetails] ([PurchaseDetailID], [PurchaseID], [ProductID], [BatchID], [Quantity], [PricePerUnit], [ReceivedDate], [CreatedDate], [ModifiedDate]) VALUES (13, 10, 10, 10, 10, CAST(80.00 AS Decimal(12, 2)), CAST(N'2025-01-18T00:00:00.000' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime), CAST(N'2025-01-22T09:36:47.997' AS DateTime))
SET IDENTITY_INSERT [dbo].[PurchaseDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchases] ON 

INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (1, CAST(N'2025-01-10T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(12, 2)), CAST(1500.00 AS Decimal(12, 2)), 1, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), N'Monthly supply of electronics')
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (2, CAST(N'2025-01-12T00:00:00.000' AS DateTime), CAST(2450.75 AS Decimal(12, 2)), CAST(2000.00 AS Decimal(12, 2)), 2, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), N'Quarterly bulk order')
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (3, CAST(N'2025-01-14T00:00:00.000' AS DateTime), CAST(680.50 AS Decimal(12, 2)), CAST(500.00 AS Decimal(12, 2)), 3, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), NULL)
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (4, CAST(N'2025-01-16T00:00:00.000' AS DateTime), CAST(3250.30 AS Decimal(12, 2)), CAST(3000.00 AS Decimal(12, 2)), 4, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), N'One-time order of spare parts')
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (5, CAST(N'2025-01-18T00:00:00.000' AS DateTime), CAST(1190.00 AS Decimal(12, 2)), CAST(0.00 AS Decimal(12, 2)), 6, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), N'Custom uniforms for employees')
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (6, CAST(N'2025-01-20T00:00:00.000' AS DateTime), CAST(200.00 AS Decimal(12, 2)), CAST(200.00 AS Decimal(12, 2)), 7, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), NULL)
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (7, CAST(N'2025-01-22T00:00:00.000' AS DateTime), CAST(875.00 AS Decimal(12, 2)), CAST(875.00 AS Decimal(12, 2)), 8, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), N'Sustainable packaging')
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (8, CAST(N'2025-01-24T00:00:00.000' AS DateTime), CAST(450.60 AS Decimal(12, 2)), CAST(450.00 AS Decimal(12, 2)), 9, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), NULL)
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (9, CAST(N'2025-01-26T00:00:00.000' AS DateTime), CAST(750.00 AS Decimal(12, 2)), CAST(750.00 AS Decimal(12, 2)), 5, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), N'Emergency replacement supplies')
INSERT [dbo].[Purchases] ([PurchaseID], [PurchaseDate], [TotalPrice], [TotalPaid], [SupplierID], [CreatedDate], [UpdatedDate], [Notes]) VALUES (10, CAST(N'2025-01-28T00:00:00.000' AS DateTime), CAST(1580.00 AS Decimal(12, 2)), CAST(1000.00 AS Decimal(12, 2)), 10, CAST(N'2025-01-22T08:51:29.443' AS DateTime), CAST(N'2025-01-22T08:51:29.443' AS DateTime), N'Miscellaneous goods for store')
SET IDENTITY_INSERT [dbo].[Purchases] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (1, N'Admin', N'Full system access and control', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (2, N'Manager', N'Can manage sales, purchases, and employees', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (3, N'Clerk', N'Can manage day-to-day operations like sales', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (4, N'Supervisor', N'Responsible for overseeing operations', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (5, N'Technician', N'Handles technical maintenance and support', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (6, N'Trainer', N'Conducts training and skill development programs', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (7, N'Consultant', N'Provides expert advice on HR and operations', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (8, N'Driver', N'Handles transportation and logistics', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (9, N'Assistant', N'Provides clerical and administrative support', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [ModifiedDate]) VALUES (10, N'Engineer', N'Develops and maintains IT systems', CAST(N'2025-01-22T05:18:48.587' AS DateTime), CAST(N'2025-01-22T05:18:48.587' AS DateTime))
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (1, CAST(N'2025-01-01T00:00:00.000' AS DateTime), CAST(230.50 AS Decimal(12, 2)), CAST(100.00 AS Decimal(12, 2)), 1, N'First-time purchase')
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (2, CAST(N'2025-01-03T00:00:00.000' AS DateTime), CAST(145.75 AS Decimal(12, 2)), CAST(145.00 AS Decimal(12, 2)), 2, N'Returned item discount included')
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (3, CAST(N'2025-01-05T00:00:00.000' AS DateTime), CAST(870.00 AS Decimal(12, 2)), CAST(870.00 AS Decimal(12, 2)), 3, NULL)
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (4, CAST(N'2025-01-07T00:00:00.000' AS DateTime), CAST(465.80 AS Decimal(12, 2)), CAST(465.00 AS Decimal(12, 2)), 4, N'Bulk order by wholesale buyer')
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (5, CAST(N'2025-01-09T00:00:00.000' AS DateTime), CAST(920.20 AS Decimal(12, 2)), CAST(920.00 AS Decimal(12, 2)), 5, N'Delayed payment expected')
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (6, CAST(N'2025-01-11T00:00:00.000' AS DateTime), CAST(189.99 AS Decimal(12, 2)), CAST(189.00 AS Decimal(12, 2)), 6, NULL)
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (7, CAST(N'2025-01-13T00:00:00.000' AS DateTime), CAST(340.75 AS Decimal(12, 2)), CAST(340.00 AS Decimal(12, 2)), 7, N'Frequent buyer with discount')
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (8, CAST(N'2025-01-15T00:00:00.000' AS DateTime), CAST(520.40 AS Decimal(12, 2)), CAST(520.00 AS Decimal(12, 2)), 8, NULL)
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (9, CAST(N'2025-01-17T00:00:00.000' AS DateTime), CAST(110.00 AS Decimal(12, 2)), CAST(110.00 AS Decimal(12, 2)), 9, N'Small retail purchase')
INSERT [dbo].[Sales] ([SaleID], [SaleDate], [TotalPrice], [TotalPaid], [CustomerID], [Notes]) VALUES (10, CAST(N'2025-01-19T00:00:00.000' AS DateTime), CAST(750.50 AS Decimal(12, 2)), CAST(750.50 AS Decimal(12, 2)), 10, N'Loyal customer special rate')
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesDetails] ON 

INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (1, 1, 1, 1, 2, CAST(600.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (2, 1, 2, 2, 1, CAST(1200.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (3, 2, 3, 3, 10, CAST(150.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (4, 2, 4, 4, 1, CAST(800.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (5, 3, 5, 5, 20, CAST(15.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (6, 3, 6, 6, 5, CAST(50.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (7, 4, 7, 7, 5, CAST(80.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (8, 4, 8, 8, 30, CAST(10.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (9, 5, 9, 9, 10, CAST(20.00 AS Decimal(12, 2)))
INSERT [dbo].[SalesDetails] ([SaleDetailID], [SaleID], [ProductID], [BatchID], [Quantity], [PricePerUnit]) VALUES (10, 5, 10, 10, 2, CAST(100.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[SalesDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (1, 1, N'Delivers weekly', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (2, 2, N'Preferred for electronics', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, 3, N'Organic produce supplier', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, 4, N'Hardware parts specialist', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, 5, NULL, 0, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, 6, N'Custom uniforms provider', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (7, 7, N'Fast delivery partner', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (8, 8, N'Sustainable goods', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (9, 9, N'Provides both supply and logistics', 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
INSERT [dbo].[Suppliers] ([SupplierID], [PersonID], [Notes], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (10, 10, NULL, 1, CAST(N'2025-01-22T05:22:27.177' AS DateTime), CAST(N'2025-01-22T05:22:27.177' AS DateTime))
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [EmployeeID], [UserName], [Password], [RoleID]) VALUES (1, 1, N'johndoe', N'hashedpassword1', 1)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [UserName], [Password], [RoleID]) VALUES (2, 2, N'janesmith', N'hashedpassword2', 2)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [UserName], [Password], [RoleID]) VALUES (3, 3, N'michaelj', N'hashedpassword3', 3)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [UserName], [Password], [RoleID]) VALUES (4, 4, N'emilyd', N'hashedpassword4', 2)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [UserName], [Password], [RoleID]) VALUES (5, 5, N'davidw', N'hashedpassword5', 4)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Categori__8517B2E014776F0C]    Script Date: 2/16/2025 6:33:16 AM ******/
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [UQ__Categori__8517B2E014776F0C] UNIQUE NONCLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ProductB__F869ED6DA3E801A3]    Script Date: 2/16/2025 6:33:16 AM ******/
ALTER TABLE [dbo].[ProductBatches] ADD  CONSTRAINT [UQ__ProductB__F869ED6DA3E801A3] UNIQUE NONCLUSTERED 
(
	[BatchNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Roles__8A2B6160BDB72723]    Script Date: 2/16/2025 6:33:16 AM ******/
ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF__Categorie__Creat__0F624AF8]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF__Categorie__IsAct__10566F31]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Customers__IsAct__02084FDA]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Customers__Creat__02FC7413]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF__Customers__Modif__03F0984C]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF__Employees__IsAct__5CA1C101]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF__Employees__Creat__5D95E53A]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF__Employees__Modif__5E8A0973]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[ProductBatches] ADD  CONSTRAINT [DF__ProductBa__Creat__1DB06A4F]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [StockLevel]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PurchaseDetails] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[PurchaseDetails] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Purchases] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Purchases] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[Suppliers] ADD  CONSTRAINT [DF__Suppliers__IsAct__6EF57B66]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Suppliers] ADD  CONSTRAINT [DF__Suppliers__Creat__6FE99F9F]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Suppliers] ADD  CONSTRAINT [DF__Suppliers__Modif__70DDC3D8]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[DamagedProducts]  WITH CHECK ADD FOREIGN KEY([ProductBatchID])
REFERENCES [dbo].[ProductBatches] ([BatchID])
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_People]
GO
ALTER TABLE [dbo].[ProductBatches]  WITH CHECK ADD  CONSTRAINT [FK__ProductBa__Produ__1EA48E88] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductBatches] CHECK CONSTRAINT [FK__ProductBa__Produ__1EA48E88]
GO
ALTER TABLE [dbo].[ProductBatches]  WITH CHECK ADD  CONSTRAINT [FK__ProductBa__Suppl__1F98B2C1] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
ALTER TABLE [dbo].[ProductBatches] CHECK CONSTRAINT [FK__ProductBa__Suppl__1F98B2C1]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD  CONSTRAINT [FK__PurchaseD__Batch__2645B050] FOREIGN KEY([BatchID])
REFERENCES [dbo].[ProductBatches] ([BatchID])
GO
ALTER TABLE [dbo].[PurchaseDetails] CHECK CONSTRAINT [FK__PurchaseD__Batch__2645B050]
GO
ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[PurchaseDetails]  WITH CHECK ADD FOREIGN KEY([PurchaseID])
REFERENCES [dbo].[Purchases] ([PurchaseID])
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK__Purchases__Suppl__08B54D69] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK__Purchases__Suppl__08B54D69]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK__Sales__CustomerI__0B91BA14] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK__Sales__CustomerI__0B91BA14]
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD FOREIGN KEY([BatchID])
REFERENCES [dbo].[ProductBatches] ([BatchID])
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[SalesDetails]  WITH CHECK ADD FOREIGN KEY([SaleID])
REFERENCES [dbo].[Sales] ([SaleID])
GO
ALTER TABLE [dbo].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_People]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Employees]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Active, 0 = Inactive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Active, 0 = Inactive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Active, 0 = Inactive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Suppliers', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
USE [master]
GO
ALTER DATABASE [InventoryDB] SET  READ_WRITE 
GO
