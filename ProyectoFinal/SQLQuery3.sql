create database DBCine on primary
(
name = Dbcine_fisico,
filename = 'D:\9no cuatrimestre\POO\ProyectoFinal\DBcine.mdf',
size = 5mb,
filegrowth = 2mb
)
log on

(
name = Dbcine_logico,
filename = 'D:\9no cuatrimestre\POO\ProyectoFinal\DBcine.ldf',
size = 5mb,
filegrowth = 2mb

)
use DBCine
create table Sucursal
(
Id_Sucursal nvarchar(4) primary key not null,
Nombre nvarchar(20),
Ciudad nvarchar(20) not null,
Telefono int,
Direccion nvarchar(60) not null
)

create table Sala
(
Id_Sala nvarchar(3) primary key not null,
Id_Sucursal nvarchar(4) not null references Sucursal,
Capacidad int not null
)

create table Pelicula
(
Id_Pelicula nvarchar(3) primary key not null,
Nombre nvarchar(20) not null,
Genero nvarchar(15) not null,
Idioma nvarchar(15) not null,
Subtitulo nvarchar(3),
Año int,
Duracion time
)

create table Cartelera
(
Id_Cartelera nvarchar(3) primary key not null,
Id_Pelicula nvarchar(3) not null references Pelicula,
Id_Sala nvarchar(3) not null references Sala,
Fecha Date not null,
Hora time not null,
Valor money not null
)

create table Venta
(
Id_Venta nvarchar(3) primary key not null,
Id_Cartelera nvarchar(3) not null references Cartelera,
Fecha date not null,
Hora time not null,
Num_ticket int not null,
Costo_total money not null
)

create table Usuarios
(
Id int identity not null,
Nombre_Usuario nvarchar(50) primary key not null,
Contraseña nvarchar(max) not null,
Tipo_De_Usuario nvarchar(15) not null
)
--PROCEDIMIENTOS ALMACENADOS
CREATE PROC INSERTAR_SUC
(
@Id_Sucursal nvarchar(4),
@Nombre nvarchar(20),
@Ciudad nvarchar(20),
@Telefono int,
@Direccion nvarchar(60)
)
AS
BEGIN
INSERT INTO Sucursal(Id_Sucursal,Nombre,Ciudad,Telefono,Direccion)
VALUES (@Id_Sucursal,@Nombre,@Ciudad,@Telefono,@Direccion)
END

--PROC DE ELIMINAR SUCURSAL

CREATE PROCEDURE ELIMINAR_SUC
(
@Id_Sucursal nvarchar(4)
 )
AS
BEGIN
DELETE FROM Sucursal WHERE Id_Sucursal=@Id_Sucursal
END 

--PROC DE ACTUALIZAR SUCURSAL

CREATE PROCEDURE ACTUALIZAR_SUC
(
@Id_Sucursal nvarchar(4),
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
CREATE PROC BUSCAR_SUCURSAL
AS 
BEGIN
SELECT * FROM Sucursal
END
-----PROC DE INSERTAR SALA

CREATE PROCEDURE INSERTAR_SALA
(
@Id_Sala nvarchar(3),
@Id_Sucursal nvarchar(4),
@Capacidad int
)
AS 
BEGIN
INSERT INTO Sala(Id_Sala,Id_Sucursal,Capacidad)
VALUES(@Id_Sala,@Id_Sucursal,@Capacidad)
END 

--PROC DE BUSCAR
CREATE PROC BUSCAR_SUC
AS BEGIN 
SELECT * FROM Sucursal
END

--PROC DE ELIMINAR SALA
CREATE PROCEDURE ELIMINAR_SALA
(
@Id_Sala nvarchar(3)
)
AS 
BEGIN
DELETE FROM Sala WHERE Id_Sala=@Id_Sala
END

--PROC DE ACTUALIZAR SALA
CREATE PROCEDURE ACTUALIZAR_SALA
(
@Id_Sala nvarchar(3),
@Id_Sucursal nvarchar(4),
@Capacidad int
)
AS
BEGIN
UPDATE Sala SET Id_Sucursal=@Id_Sucursal,Capacidad=@Capacidad WHERE Id_Sala=@Id_Sala
END

--PROC DE BUSCAR
CREATE PROC BUSCAR_SALA
AS BEGIN 
SELECT * FROM Sala
END

--PROC DE INSERTAR PELICULA

CREATE PROCEDURE INSERTAR_PELI
(
@Id_Pelicula nvarchar(3),
@Nombre nvarchar(20),
@Genero nvarchar(15),
@Idioma nvarchar(15),
@Subtitulo nvarchar(3),
@Año int,
@Duracion time
)
AS
BEGIN
INSERT INTO Pelicula (Id_Pelicula,Nombre,Genero,Idioma,Subtitulo,Año,Duracion)
VALUES (@Id_Pelicula,@Nombre,@Genero,@Idioma,@Subtitulo,@Año,@Duracion)
END

--PROC DE ELIMINAR PELI 

CREATE PROCEDURE ELIMINAR_PELI
(
@Id_Pelicula nvarchar(3)
)
AS BEGIN 
DELETE FROM Pelicula WHERE Id_Pelicula=@Id_Pelicula
END


--PROC DE ACTUALIZAR PELICULA
CREATE PROCEDURE ACTUALIZAR_PELI
(
@Id_Pelicula nvarchar(3),
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
CREATE PROCEDURE BUSCAR_PELI
AS BEGIN 
SELECT * FROM Pelicula
END

--PROC DE INSERTAR CARTELERA 
CREATE PROCEDURE INSERTAR_CARTELERA
(
@Id_Cartelera nvarchar(3),
@Id_Pelicula nvarchar(3),
@Id_Sala nvarchar(3),
@Fecha Date,
@Hora time,
@Valor money 
)
AS BEGIN
INSERT INTO Cartelera (Id_Cartelera,Id_Pelicula,Id_Sala,Fecha,Hora,Valor)
values (@Id_Cartelera,@Id_Pelicula,@Id_Sala,@Fecha,@Hora,@Valor)
end

--PROC DE ELIMINAR  CARTELERA 
CREATE PROCEDURE ELIMINAR_CARTELERA
(
@Id_Cartelera nvarchar(3)

)
AS BEGIN 
DELETE FROM Cartelera WHERE Id_Cartelera=@Id_Cartelera
END

--PRO DE ACTUALIZAR CARTELERA 
CREATE PROCEDURE ACTUALIZAR_CARTELERA
(
@Id_Cartelera nvarchar(3),
@Id_Pelicula nvarchar(3),
@Id_Sala nvarchar(3),
@Fecha Date,
@Hora time,
@Valor money 
)
AS BEGIN
UPDATE Cartelera SET Id_Pelicula=@Id_Pelicula,Id_Sala=@Id_Sala,Fecha=@Fecha,Hora=@Hora,Valor=@Valor WHERE Id_Cartelera=@Id_Cartelera
END

--PROC DE BUSCAR
CREATE PROC BUSCAR_CARTELERA
AS BEGIN 
SELECT * FROM Cartelera
END

--PROC DE INSERTAR  VENTAS 
CREATE PROCEDURE INSERTAR_VENTAS
(
@Id_Venta nvarchar(3),
@Id_Cartelera nvarchar(3),
@Fecha date,
@Hora time ,
@Num_ticket int,
@Costo_total money
)
AS BEGIN 
INSERT INTO Venta (Id_Venta,Id_Cartelera,Fecha,Hora,Num_ticket,Costo_total)
VALUES (@Id_Venta,@Id_Cartelera,@Fecha,@Hora,@Num_ticket,@Costo_total)
END 

--PROC DE BUSCAR
CREATE PROC BUSCAR_VENTAS
AS BEGIN 
SELECT * FROM Venta
END

--PROC DE INSERTAR USAURIO
CREATE PROC INSERTAR_USUARIO
(
@Nombre_Usuario nvarchar(50),
@Contraseña nvarchar(max),
@Tipo_De_Usuario nvarchar(15)
)
AS BEGIN
INSERT INTO Usuarios(Nombre_Usuario,Contraseña,Tipo_De_Usuario)
VALUES (@Nombre_Usuario,@Contraseña,@Tipo_De_Usuario)
END 

--PROC DE ELIMAR USUARIO

CREATE PROC ELIMINAR_USUARIO 
(
@Nombre_Usuario nvarchar(50)
)
AS BEGIN
DELETE FROM Usuarios WHERE Nombre_Usuario=@Nombre_Usuario
END

--PROC DE ACTUALIZAR

CREATE PROC ACTUALIZAR_USUARIO
(
@Nombre_Usuario nvarchar(50),
@Contraseña nvarchar(max),
@Tipo_De_Usuario nvarchar(15)
)
AS BEGIN 
UPDATE Usuarios SET Contraseña=@Contraseña,Tipo_De_Usuario=@Tipo_De_Usuario WHERE  Nombre_Usuario=@Nombre_Usuario
END

--PROC DE BUSCAR
CREATE PROC BUSCAR_USUARIO
AS BEGIN 
SELECT * FROM Usuarios
END

insert into Pelicula values ('2','Scary Movie 2','Parodia','Español Latino','No',2000,'1:30')
select * from Pelicula
delete from Pelicula where Id_Pelicula='1' 

update Sucursal set Telefono =84121587 where Id_Sucursal =1
