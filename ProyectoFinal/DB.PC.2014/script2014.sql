USE [master]
GO
/****** Object:  Database [DBCine]    Script Date: 23/11/2017 16:35:47 ******/
CREATE DATABASE [DBCine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dbcine_fisico', FILENAME = N'f:\DBcine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'Dbcine_logico', FILENAME = N'f:\DBcine.ldf' , SIZE = 5120KB , MAXSIZE = 2048GB , FILEGROWTH = 2048KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBCine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBCine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBCine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBCine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBCine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBCine] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBCine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBCine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBCine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBCine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBCine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBCine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBCine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBCine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBCine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBCine] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBCine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBCine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBCine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBCine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBCine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBCine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBCine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBCine] SET RECOVERY FULL 
GO
ALTER DATABASE [DBCine] SET  MULTI_USER 
GO
ALTER DATABASE [DBCine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBCine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBCine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBCine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBCine] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBCine', N'ON'
GO
USE [DBCine]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DBCine]
GO
/****** Object:  Table [dbo].[Cartelera]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartelera](
	[Id_Cartelera] [int] IDENTITY(1,1) NOT NULL,
	[Id_Pelicula] [int] NOT NULL,
	[Id_Sala] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](7) NOT NULL,
	[Valor] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cartelera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pelicula](
	[Id_Pelicula] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Genero] [nvarchar](15) NOT NULL,
	[Idioma] [nvarchar](15) NOT NULL,
	[Subtitulo] [nvarchar](3) NULL,
	[Año] [int] NULL,
	[Duracion] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Usuario] [nvarchar](100) NULL,
	[Sucursal] [bit] NULL,
	[Sala] [bit] NULL,
	[Pelicula] [bit] NULL,
	[Cartelera] [bit] NULL,
	[Venta] [bit] NULL,
	[usuarios] [bit] NULL,
	[Password] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sala]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala](
	[Id_Sala] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](10) NOT NULL,
	[Id_Sucursal] [int] NOT NULL,
	[Capacidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Id_Sucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NULL,
	[Ciudad] [nvarchar](20) NOT NULL,
	[Telefono] [int] NULL,
	[Direccion] [nvarchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Venta]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Id_Venta] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cartelera] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Hora] [time](7) NOT NULL,
	[Num_ticket] [int] NOT NULL,
	[Costo_total] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Cartelera]  WITH CHECK ADD FOREIGN KEY([Id_Pelicula])
REFERENCES [dbo].[Pelicula] ([Id_Pelicula])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cartelera]  WITH CHECK ADD FOREIGN KEY([Id_Sala])
REFERENCES [dbo].[Sala] ([Id_Sala])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sala]  WITH CHECK ADD FOREIGN KEY([Id_Sucursal])
REFERENCES [dbo].[Sucursal] ([Id_Sucursal])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([Id_Cartelera])
REFERENCES [dbo].[Cartelera] ([Id_Cartelera])
ON DELETE CASCADE
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_CARTELERA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_CARTELERA]
(
@Id_Cartelera int,
@Id_Pelicula int,
@Id_Sala int,
@Fecha Date,
@Hora time,
@Valor money 
)
AS BEGIN
UPDATE Cartelera SET Id_Pelicula=@Id_Pelicula,Id_Sala=@Id_Sala,Fecha=@Fecha,Hora=@Hora,Valor=@Valor WHERE Id_Cartelera=@Id_Cartelera
END

--PROC DE BUSCAR

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_PELI]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_PELI]
(
@Id_Pelicula int,
@Nombre nvarchar(20),
@Genero nvarchar(15),
@Idioma nvarchar(15),
@Subtitulo nvarchar(3),
@Año int,
@Duracion time
)
AS BEGIN 
UPDATE Pelicula SET Nombre=@Nombre,Genero=@Genero,Idioma=@Idioma,Subtitulo=@Subtitulo,Año=@Año,Duracion=@Duracion WHERE Id_Pelicula=@Id_Pelicula
END

--PROC DE BUSCAR

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_SALA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_SALA]
(
@Id_Sala int,
@Nombre nvarchar(10),
@Id_Sucursal int,
@Capacidad int
)
AS
BEGIN
UPDATE Sala SET nombre=@Nombre,Id_Sucursal=@Id_Sucursal,Capacidad=@Capacidad WHERE Id_Sala=@Id_Sala
END

--PROC DE BUSCAR

GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZAR_SUC]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZAR_SUC]
(
@Id_Sucursal int,
@Nombre nvarchar(20),
@Ciudad nvarchar(20),
@Telefono int,
@Direccion nvarchar(60)
)
AS 
BEGIN
UPDATE Sucursal SET Nombre=@Nombre,Ciudad=@Ciudad,Telefono=@Telefono,Direccion=@Direccion WHERE Id_Sucursal=@Id_Sucursal
END

--PROC SELECT SUCURSAL

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_CARTELERA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_CARTELERA]
AS BEGIN 
SELECT car.Id_Cartelera,car.Id_Pelicula,car.Id_Sala,car.Fecha,car.Hora,car.Valor,
peli.Nombre,peli.Genero,peli.Idioma,peli.Subtitulo,peli.Año,
peli.Duracion,sl.nombre,sl.Capacidad 
FROM Cartelera car
inner join Pelicula peli on peli.Id_Pelicula=car.Id_Pelicula
inner join sala sl on sl.Id_Sala=car.Id_Sala 
END




--PROC DE INSERTAR  VENTAS

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_PELI]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BUSCAR_PELI]
AS BEGIN 
SELECT * FROM Pelicula
END




--PROC DE INSERTAR CARTELERA

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_SALA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_SALA]
AS BEGIN 
SELECT sa.Id_Sala,sa.Id_Sucursal,sa.nombre,sa.Capacidad,sc.Nombre,sc.Ciudad,sc.Telefono,sc.Direccion FROM Sala sa
inner join Sucursal sc on sa.Id_Sucursal=sc.Id_Sucursal
END




--PROC DE INSERTAR PELICULA

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_SUCURSAL]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_SUCURSAL]
AS 
BEGIN
SELECT * FROM Sucursal
END





-----PROC DE INSERTAR SALA

GO
/****** Object:  StoredProcedure [dbo].[BUSCAR_VENTAS]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_VENTAS]
AS BEGIN 
SELECT v.Id_Venta,v.Id_Cartelera,pel.Nombre,Sala.nombre,v.Fecha,v.Hora,v.Num_ticket,car.Valor,v.Costo_total FROM Venta v
inner join Cartelera car on car.Id_Cartelera=v.Id_Cartelera
inner join Pelicula pel on pel.Id_Pelicula=car.Id_Pelicula
inner join Sala on Sala.Id_Sala=car.Id_Sala
END

























GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_CARTELERA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_CARTELERA]
(
@Id_Cartelera int

)
AS BEGIN 
DELETE FROM Cartelera WHERE Id_Cartelera=@Id_Cartelera
END

--PRO DE ACTUALIZAR CARTELERA

GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_PELI]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_PELI]
(
@Id_Pelicula int
)
AS BEGIN 
DELETE FROM Pelicula WHERE Id_Pelicula=@Id_Pelicula
END

--PROC DE ACTUALIZAR PELICULA

GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_SALA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_SALA]
(
@Id_Sala int
)
AS 
BEGIN
DELETE FROM Sala WHERE Id_Sala=@Id_Sala
END

--PROC DE ACTUALIZAR SALA

GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_SUC]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_SUC]
(
@Id_Sucursal int
 )
AS
BEGIN
DELETE FROM Sucursal WHERE Id_Sucursal=@Id_Sucursal
END 

--PROC DE ACTUALIZAR SUCURSAL

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_CARTELERA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_CARTELERA]
(
@Id_Pelicula int,
@Id_Sala int,
@Fecha Date,
@Hora time,
@Valor money 
)
AS BEGIN
INSERT INTO Cartelera (Id_Pelicula,Id_Sala,Fecha,Hora,Valor)
values (@Id_Pelicula,@Id_Sala,@Fecha,@Hora,@Valor)
end

--PROC DE ELIMINAR  CARTELERA

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_PELI]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_PELI]
(

@Nombre nvarchar(20),
@Genero nvarchar(15),
@Idioma nvarchar(15),
@Subtitulo nvarchar(3),
@Año int,
@Duracion time
)
AS
BEGIN
INSERT INTO Pelicula (Nombre,Genero,Idioma,Subtitulo,Año,Duracion)
VALUES (@Nombre,@Genero,@Idioma,@Subtitulo,@Año,@Duracion)
END

--PROC DE ELIMINAR PELI 

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_SALA]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_SALA]
(
@Nombre nvarchar(10),
@Id_Sucursal int,
@Capacidad int
)
AS 
BEGIN
INSERT INTO Sala(nombre,Id_Sucursal,Capacidad)
VALUES(@Nombre,@Id_Sucursal,@Capacidad)
END 

--PROC DE ELIMINAR SALA

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_SUC]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[INSERTAR_SUC]
(

@Nombre nvarchar(20),
@Ciudad nvarchar(20),
@Telefono int,
@Direccion nvarchar(60)
)
AS
BEGIN
INSERT INTO Sucursal(Nombre,Ciudad,Telefono,Direccion)
VALUES (@Nombre,@Ciudad,@Telefono,@Direccion)
END

--PROC DE ELIMINAR SUCURSAL

GO
/****** Object:  StoredProcedure [dbo].[INSERTAR_VENTAS]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTAR_VENTAS]
(

@Id_Cartelera int,
@Fecha date,
@Hora time ,
@Num_ticket int,
@Costo_total money
)
AS BEGIN 
INSERT INTO Venta (Id_Cartelera,Fecha,Hora,Num_ticket,Costo_total)
VALUES (@Id_Cartelera,@Fecha,@Hora,@Num_ticket,@Costo_total)
END 

--PROC DE BUSCAR

GO
/****** Object:  Trigger [dbo].[tr_boletosvendidos]    Script Date: 23/11/2017 16:35:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[tr_boletosvendidos]
   ON  [dbo].[Venta]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @idventa int
	declare @idcartelera int 
	declare @cantidad_ticket int
	declare @idsala int
	declare @capacidad int

    -- Insert statements for trigger here
	select @idventa=Id_Venta,@idcartelera=Id_Cartelera,@cantidad_ticket=Num_ticket from inserted
	select @idsala = Id_sala from Cartelera where Id_Cartelera=@idcartelera
	select @capacidad=Capacidad from Sala where Id_Sala=@idsala

	if (select Capacidad from Sala) < 0 
		print 'Lo siento no hay mas boleto disponible'
	else
		update Sala set Capacidad = @capacidad-@cantidad_ticket where Id_Sala=@idsala


END





GO
ALTER TABLE [dbo].[Venta] ENABLE TRIGGER [tr_boletosvendidos]
GO
USE [master]
GO
ALTER DATABASE [DBCine] SET  READ_WRITE 
GO
