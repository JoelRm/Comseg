USE [master]
GO
/****** Object:  Database [BDVentas]    Script Date: 12/09/2020 16:35:58 ******/
CREATE DATABASE [BDVentas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDVentas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDVentas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDVentas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDVentas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDVentas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDVentas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDVentas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDVentas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDVentas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDVentas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDVentas] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDVentas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDVentas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDVentas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDVentas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDVentas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDVentas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDVentas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDVentas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDVentas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDVentas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDVentas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDVentas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDVentas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDVentas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDVentas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDVentas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDVentas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDVentas] SET RECOVERY FULL 
GO
ALTER DATABASE [BDVentas] SET  MULTI_USER 
GO
ALTER DATABASE [BDVentas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDVentas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDVentas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDVentas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDVentas] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDVentas', N'ON'
GO
ALTER DATABASE [BDVentas] SET QUERY_STORE = OFF
GO
USE [BDVentas]
GO
/****** Object:  Table [dbo].[Almacen]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen](
	[IdAlmacen] [int] IDENTITY(1,1) NOT NULL,
	[NombreAlmacen] [varchar](50) NOT NULL,
	[DireccionAlmacen] [varchar](50) NULL,
	[IdSucursal] [int] NOT NULL,
	[IsPrincipal] [char](1) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoAlmacen] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Almacen] PRIMARY KEY CLUSTERED 
(
	[IdAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoDocumento] [int] NOT NULL,
	[NroDocumentoCliente] [varchar](12) NOT NULL,
	[NombreCliente] [varchar](max) NOT NULL,
	[DireccionCliente] [varchar](100) NOT NULL,
	[NumeroContactoCliente] [varchar](9) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoCliente] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impuesto]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impuesto](
	[IdImpuesto] [int] IDENTITY(1,1) NOT NULL,
	[NombreImpuesto] [varchar](50) NOT NULL,
	[ValorImpuesto] [decimal](18, 2) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoImpuesto] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Impuesto] PRIMARY KEY CLUSTERED 
(
	[IdImpuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Linea]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linea](
	[IdLinea] [int] IDENTITY(1,1) NOT NULL,
	[NombreLinea] [varchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoLinea] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Linea] PRIMARY KEY CLUSTERED 
(
	[IdLinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[NombreMarca] [varchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoMarca] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moneda]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[IdMoneda] [int] IDENTITY(1,1) NOT NULL,
	[NombreMoneda] [varchar](50) NOT NULL,
	[SimboloMoneda] [varchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoMoneda] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED 
(
	[IdMoneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [varchar](5) NOT NULL,
	[NombreProducto] [varchar](100) NOT NULL,
	[IdLinea] [int] NOT NULL,
	[IdMarca] [int] NOT NULL,
	[IdImpuesto] [int] NOT NULL,
	[IdMoneda] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoProducto] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoAlmacen]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoAlmacen](
	[IdProductoAlmacen] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[StockFisico] [int] NOT NULL,
	[StockSistema] [int] NOT NULL,
	[IsActivo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoEliminación] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoAlmacen] PRIMARY KEY CLUSTERED 
(
	[IdProductoAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoSucursalCosto]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoSucursalCosto](
	[IdProductoSucursalCosto] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[CostoUnitario] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_ProductoSucursalCosto] PRIMARY KEY CLUSTERED 
(
	[IdProductoSucursalCosto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoUnidad]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoUnidad](
	[IdProductoUnidad] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdUnidad] [int] NOT NULL,
	[IsUnidadBase] [bit] NOT NULL,
	[IsUnidadVenta] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoProductoUnidad] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoUnidad] PRIMARY KEY CLUSTERED 
(
	[IdProductoUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoPersona] [int] NOT NULL,
	[NroDocumentoProveedor] [varchar](12) NOT NULL,
	[NombreProveedor] [varchar](max) NOT NULL,
	[DireccionProveedor] [varchar](100) NULL,
	[NombreContactoProveedor] [varchar](100) NULL,
	[NumeroContactoProveedor] [varchar](9) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoProveedor] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[NombreSucursal] [varchar](50) NOT NULL,
	[IdTipoTienda] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoSucursal] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[IdTipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionTipoDocumento] [varchar](50) NOT NULL,
	[AbreviacionTipoDocumento] [varchar](20) NOT NULL,
	[LongitudTipoDocumento] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoTipoDocumento] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[IdTipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPersona]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[IdTipoPersona] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoPersona] [varchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoTipoPersona] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NOT NULL,
 CONSTRAINT [PK_TipoPersona] PRIMARY KEY CLUSTERED 
(
	[IdTipoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoTienda]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoTienda](
	[IdTipoTienda] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoTienda] [varchar](50) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoTipoTienda] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NULL,
 CONSTRAINT [PK_TipoTienda] PRIMARY KEY CLUSTERED 
(
	[IdTipoTienda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unidad]    Script Date: 12/09/2020 16:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidad](
	[IdUnidad] [int] IDENTITY(1,1) NOT NULL,
	[NombreUnidad] [varchar](50) NOT NULL,
	[Factor] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioCreacion] [varchar](20) NOT NULL,
	[FechaModificacion] [datetime] NOT NULL,
	[UsuarioModificacion] [varchar](20) NOT NULL,
	[EstadoUnidad] [bit] NOT NULL,
	[EstadoEliminacion] [bit] NULL,
 CONSTRAINT [PK_Unidad] PRIMARY KEY CLUSTERED 
(
	[IdUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BDVentas] SET  READ_WRITE 
GO
