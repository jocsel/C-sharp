--agregue nobre a sala

go
create database DBCine on primary
(
name = Dbcine_fisico,
filename = 'f:\DBcine.mdf',
size = 5mb,
filegrowth = 2mb
)
log on

(
name = Dbcine_logico,
filename = 'f:\DBcine.ldf',
size = 5mb,
filegrowth = 2mb

)
go
use DBCine
go

create table Sucursal
(
Id_Sucursal int identity(1,1) primary key not null,
Nombre nvarchar(20),
Ciudad nvarchar(20) not null,
Telefono int,
Direccion nvarchar(60) not null
)

create table Sala
(
Id_Sala int identity(1,1) primary key not null,
nombre nvarchar(10) not null,
Id_Sucursal int  not null references Sucursal on delete cascade,
Capacidad int not null
)

create table Pelicula
(
Id_Pelicula int identity(1,1) primary key not null,
Nombre nvarchar(20) not null,
Genero nvarchar(15) not null,
Idioma nvarchar(15) not null,
Subtitulo nvarchar(3),
Año int,
Duracion time
)

create table Cartelera
(
Id_Cartelera int identity (1,1) primary key not null,
Id_Pelicula int not null references Pelicula on delete cascade,
Id_Sala int not null references Sala on delete cascade,
Fecha Date not null,
Hora time not null,
Valor money not null
)

create table Venta
(
Id_Venta int identity (1,1) primary key not null,
Id_Cartelera int not null references Cartelera on delete cascade,
Fecha date not null,
Hora time not null,
Num_ticket int not null,
Costo_total money not null
)

CREATE TABLE Usuarios
(
	Usuario nvarchar (100) primary key NOT NULL,
	Password nvarchar (max) NULL,
	 Nombre nvarchar(100) NULL,
	Apellido nvarchar(100) NULL
)


CREATE TABLE Permiso
(
	Usuario nvarchar(100) NULL,
	Sucursal bit NULL,
	Sala bit NULL,
	Pelicula bit NULL,
	Cartelera bit  NULL,
	Venta bit NULL,
	usuarios bit NULL,
	Password bit NULL
) 

GO



--PROCEDIMIENTOS ALMACENADOS



go
CREATE PROC INSERTAR_SUC
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
go
CREATE PROCEDURE ELIMINAR_SUC
(
@Id_Sucursal int
 )
AS
BEGIN
DELETE FROM Sucursal WHERE Id_Sucursal=@Id_Sucursal
END 

--PROC DE ACTUALIZAR SUCURSAL
go
CREATE PROCEDURE ACTUALIZAR_SUC
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
go
CREATE PROC BUSCAR_SUCURSAL
AS 
BEGIN
SELECT * FROM Sucursal
END





-----PROC DE INSERTAR SALA
go
CREATE PROCEDURE INSERTAR_SALA
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
go
CREATE PROCEDURE ELIMINAR_SALA
(
@Id_Sala int
)
AS 
BEGIN
DELETE FROM Sala WHERE Id_Sala=@Id_Sala
END

--PROC DE ACTUALIZAR SALA
go
CREATE PROCEDURE ACTUALIZAR_SALA
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
go
CREATE PROC BUSCAR_SALA
AS BEGIN 
SELECT sa.Id_Sala,sa.Id_Sucursal,sa.nombre,sa.Capacidad,sc.Nombre,sc.Ciudad,sc.Telefono,sc.Direccion FROM Sala sa
inner join Sucursal sc on sa.Id_Sucursal=sc.Id_Sucursal
END




--PROC DE INSERTAR PELICULA
go
CREATE PROCEDURE INSERTAR_PELI
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
go
CREATE PROCEDURE ELIMINAR_PELI
(
@Id_Pelicula int
)
AS BEGIN 
DELETE FROM Pelicula WHERE Id_Pelicula=@Id_Pelicula
END

--PROC DE ACTUALIZAR PELICULA
go
CREATE PROCEDURE ACTUALIZAR_PELI
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
go
CREATE PROCEDURE BUSCAR_PELI
AS BEGIN 
SELECT * FROM Pelicula
END




--PROC DE INSERTAR CARTELERA
go 
CREATE PROCEDURE INSERTAR_CARTELERA
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
go 
CREATE PROCEDURE ELIMINAR_CARTELERA
(
@Id_Cartelera int

)
AS BEGIN 
DELETE FROM Cartelera WHERE Id_Cartelera=@Id_Cartelera
END

--PRO DE ACTUALIZAR CARTELERA
go 
CREATE PROCEDURE ACTUALIZAR_CARTELERA
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
go
CREATE PROC BUSCAR_CARTELERA
AS BEGIN 
SELECT car.Id_Cartelera,car.Id_Pelicula,car.Id_Sala,car.Fecha,car.Hora,car.Valor,
peli.Nombre,peli.Genero,peli.Idioma,peli.Subtitulo,peli.Año,
peli.Duracion,sl.nombre,sl.Capacidad 
FROM Cartelera car
inner join Pelicula peli on peli.Id_Pelicula=car.Id_Pelicula
inner join sala sl on sl.Id_Sala=car.Id_Sala 
END




--PROC DE INSERTAR  VENTAS
go 
CREATE PROCEDURE INSERTAR_VENTAS
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
go
CREATE PROC BUSCAR_VENTAS
AS BEGIN 
SELECT v.Id_Venta,v.Id_Cartelera,pel.Nombre,Sala.nombre,v.Fecha,v.Hora,v.Num_ticket,car.Valor,v.Costo_total FROM Venta v
inner join Cartelera car on car.Id_Cartelera=v.Id_Cartelera
inner join Pelicula pel on pel.Id_Pelicula=car.Id_Pelicula
inner join Sala on Sala.Id_Sala=car.Id_Sala
END
























GO
/****** Object:  Trigger [dbo].[tr_boletosvendidos]    Script Date: 14/11/2017 2:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER tr_boletosvendidos
   ON  Venta
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




