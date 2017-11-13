--agregue nobre a sala

go
create database DBCine on primary
(
name = Dbcine_fisico,
filename = 'F:\PortableGit\C-sharp\ProyectoFinal\DB.PC.2014\DBcine.mdf',
size = 5mb,
filegrowth = 2mb
)
log on

(
name = Dbcine_logico,
filename = 'F:\PortableGit\C-sharp\ProyectoFinal\DB.PC.2014\DBcine.ldf',
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
Id_Sucursal int  not null references Sucursal,
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
Id_Pelicula int not null references Pelicula,
Id_Sala int not null references Sala,
Fecha Date not null,
Hora time not null,
Valor money not null
)

create table Venta
(
Id_Venta int identity (1,1) primary key not null,
Id_Cartelera int not null references Cartelera,
Fecha date not null,
Hora time not null,
Num_ticket int not null,
Costo_total money not null
)

create table Usuarios
(
Id int identity (1,1),
Nombre_apellido nvarchar (50) not null,
Nombre_Usuario nvarchar(50) primary key not null,
Contraseña nvarchar(max) not null,
Tipo_De_Usuario nvarchar(15) not null
)








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
SELECT * FROM Cartelera
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
SELECT * FROM Venta
END




--PROC DE INSERTAR USAURIO
go
CREATE PROC INSERTAR_USUARIO
(
@Nombre nvarchar(50),
@Nombre_Usuario nvarchar(50),
@Contraseña nvarchar(max),
@Tipo_De_Usuario nvarchar(15)
)
AS BEGIN
INSERT INTO Usuarios(Nombre_apellido,Nombre_Usuario,Contraseña,Tipo_De_Usuario)
VALUES (@Nombre,@Nombre_Usuario,@Contraseña,@Tipo_De_Usuario)
END 

--PROC DE ELIMAR USUARIO
go
CREATE PROC ELIMINAR_USUARIO 
(
@Id nvarchar
)
AS BEGIN
DELETE FROM Usuarios WHERE Id=@Id
END

--PROC DE ACTUALIZAR
go
CREATE PROC ACTUALIZAR_USUARIO
(
@Id int,
@Nombre_Apellido nvarchar(50),
@Nombre_Usuario nvarchar(50),
@Contraseña nvarchar(max),
@Tipo_De_Usuario nvarchar(15)
)
AS BEGIN 
UPDATE Usuarios SET Nombre_apellido=@Nombre_Apellido,Contraseña=@Contraseña,Tipo_De_Usuario=@Tipo_De_Usuario, Nombre_Usuario=@Nombre_Usuario WHERE Id=@Id
END

--PROC DE BUSCAR
go
CREATE PROC BUSCAR_USUARIO
AS BEGIN 
SELECT * FROM Usuarios
END

--logeo
go
create proc logeo
(
@usuario nvarchar(50),
@contraseña nvarchar(max)
)
as
begin
select * from Usuarios where Nombre_Usuario=@usuario and Contraseña=@contraseña 
end
