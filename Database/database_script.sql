USE [master]
GO
/****** Object:  Database [HiTechStore]    Script Date: 11/27/2021 10:01:20 AM Sanushi  ******/
CREATE DATABASE [HiTechStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LabAssignment', FILENAME = N'D:\Setups\Microsoft_SQL_Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HiTechStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LabAssignment_log', FILENAME = N'D:\Setups\Microsoft_SQL_Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HiTechStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HiTechStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HiTechStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HiTechStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HiTechStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HiTechStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HiTechStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HiTechStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [HiTechStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HiTechStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HiTechStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HiTechStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HiTechStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HiTechStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HiTechStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HiTechStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HiTechStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HiTechStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HiTechStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HiTechStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HiTechStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HiTechStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HiTechStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HiTechStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HiTechStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HiTechStore] SET RECOVERY FULL 
GO
ALTER DATABASE [HiTechStore] SET  MULTI_USER 
GO
ALTER DATABASE [HiTechStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HiTechStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HiTechStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HiTechStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HiTechStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HiTechStore', N'ON'
GO
ALTER DATABASE [HiTechStore] SET QUERY_STORE = OFF
GO
USE [HiTechStore]
GO
/****** Object:  Table [dbo].[CustomerContactDetails]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerContactDetails](
	[customer_contact_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[country_code] [varchar](6) NOT NULL,
	[contact_no] [varchar](14) NOT NULL,
	[address] [varchar](150) NOT NULL,
	[city] [varchar](20) NOT NULL,
	[postal_code] [varchar](10) NOT NULL,
	[state] [varchar](15) NULL,
	[country] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CustomerContactDetails] PRIMARY KEY CLUSTERED 
(
	[customer_contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrder]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrder](
	[customer_order_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_CustomerOrder] PRIMARY KEY CLUSTERED 
(
	[customer_order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[discount_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[total_price] [decimal](10, 2) NOT NULL,
	[discount] [decimal](10, 0) NOT NULL,
	[discounted_price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[discount_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoyaltyCustomer]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoyaltyCustomer](
	[loyalty_customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[joined_at] [datetime] NOT NULL,
 CONSTRAINT [PK_LoyaltyCustomer] PRIMARY KEY CLUSTERED 
(
	[loyalty_customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderedItem]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderedItem](
	[ordered_item_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_order_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderedItem] PRIMARY KEY CLUSTERED 
(
	[ordered_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[payment_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[total_amount] [decimal](10, 2) NOT NULL,
	[discount_id] [int] NULL,
	[amount_paid] [decimal](10, 2) NOT NULL,
	[status] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[type_id] [int] NOT NULL,
	[name] [varchar](20) NOT NULL,
	[sku] [varchar](15) NOT NULL,
	[image_url] [varchar](200) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[product_type_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[product_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_role_id] [int] NOT NULL,
	[first_name] [varchar](15) NOT NULL,
	[last_name] [varchar](15) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemView]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemView](
	[view_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_SystemView] PRIMARY KEY CLUSTERED 
(
	[view_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPrivilege]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPrivilege](
	[privilege_id] [int] IDENTITY(1,1) NOT NULL,
	[user_role_id] [int] NOT NULL,
	[view_id] [int] NOT NULL,
	[can_view] [bit] NOT NULL,
	[can_add] [bit] NOT NULL,
	[can_edit] [bit] NOT NULL,
	[can_delete] [bit] NOT NULL,
 CONSTRAINT [PK_UserPrivilege] PRIMARY KEY CLUSTERED 
(
	[privilege_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/27/2021 10:01:21 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[user_role_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](25) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[user_role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [type_id], [name], [sku], [image_url], [price], [created_at]) VALUES (1, 1, N'lkmlkoij', N'iojo', N'string', CAST(19.00 AS Decimal(10, 2)), CAST(N'2021-10-31T19:05:07.853' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([product_type_id], [name]) VALUES (1, N'Smart Phones')
INSERT [dbo].[ProductType] ([product_type_id], [name]) VALUES (2, N'Tablets')
INSERT [dbo].[ProductType] ([product_type_id], [name]) VALUES (3, N'Smart Watches')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemUser] ON 

INSERT [dbo].[SystemUser] ([user_id], [user_role_id], [first_name], [last_name], [email], [password]) VALUES (1, 1, N'asa', N'asds', N'aas@gmail.com', N'YXNkc2Q=')
SET IDENTITY_INSERT [dbo].[SystemUser] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([user_role_id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([user_role_id], [name]) VALUES (2, N'Customer')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[CustomerContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_Customer_CustomerContactDetails] FOREIGN KEY([customer_id])
REFERENCES [dbo].[SystemUser] ([user_id])
GO
ALTER TABLE [dbo].[CustomerContactDetails] CHECK CONSTRAINT [FK_Customer_CustomerContactDetails]
GO
ALTER TABLE [dbo].[CustomerOrder]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Order] FOREIGN KEY([customer_id])
REFERENCES [dbo].[SystemUser] ([user_id])
GO
ALTER TABLE [dbo].[CustomerOrder] CHECK CONSTRAINT [FK_Customer_Order]
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD  CONSTRAINT [FK_CustomerOrder_Discount] FOREIGN KEY([order_id])
REFERENCES [dbo].[CustomerOrder] ([customer_order_id])
GO
ALTER TABLE [dbo].[Discount] CHECK CONSTRAINT [FK_CustomerOrder_Discount]
GO
ALTER TABLE [dbo].[LoyaltyCustomer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_LoyaltyCustomer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[SystemUser] ([user_id])
GO
ALTER TABLE [dbo].[LoyaltyCustomer] CHECK CONSTRAINT [FK_Customer_LoyaltyCustomer]
GO
ALTER TABLE [dbo].[OrderedItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderedItem_Product] FOREIGN KEY([item_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[OrderedItem] CHECK CONSTRAINT [FK_OrderedItem_Product]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Discount_Payment] FOREIGN KEY([order_id])
REFERENCES [dbo].[CustomerOrder] ([customer_order_id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Discount_Payment]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_ProductType_Product] FOREIGN KEY([type_id])
REFERENCES [dbo].[ProductType] ([product_type_id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_ProductType_Product]
GO
ALTER TABLE [dbo].[SystemUser]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_SystemUser] FOREIGN KEY([user_role_id])
REFERENCES [dbo].[UserRole] ([user_role_id])
GO
ALTER TABLE [dbo].[SystemUser] CHECK CONSTRAINT [FK_UserRole_SystemUser]
GO
ALTER TABLE [dbo].[UserPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_SystemView_Privilege] FOREIGN KEY([view_id])
REFERENCES [dbo].[SystemView] ([view_id])
GO
ALTER TABLE [dbo].[UserPrivilege] CHECK CONSTRAINT [FK_SystemView_Privilege]
GO
USE [master]
GO
ALTER DATABASE [HiTechStore] SET  READ_WRITE 
GO
