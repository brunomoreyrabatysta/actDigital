USE [master]
GO

/****** Object:  Database [Financeiro]    Script Date: 10/10/2022 16:39:21 ******/
CREATE DATABASE [Financeiro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Financeiro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Financeiro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Financeiro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Financeiro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Financeiro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Financeiro] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Financeiro] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Financeiro] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Financeiro] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Financeiro] SET ARITHABORT OFF 
GO

ALTER DATABASE [Financeiro] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [Financeiro] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Financeiro] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Financeiro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Financeiro] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Financeiro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Financeiro] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Financeiro] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Financeiro] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Financeiro] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Financeiro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Financeiro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Financeiro] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Financeiro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Financeiro] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Financeiro] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [Financeiro] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Financeiro] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Financeiro] SET  MULTI_USER 
GO

ALTER DATABASE [Financeiro] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Financeiro] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Financeiro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Financeiro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Financeiro] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Financeiro] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Financeiro] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Financeiro] SET  READ_WRITE 
GO


