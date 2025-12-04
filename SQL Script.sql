use master 
go
create database TPC_ECOMMERCE_4B_DB
go
use TPC_ECOMMERCE_4B_DB
go


DROP TABLE IF EXISTS Compra;
go
DROP TABLE IF EXISTS ClienteTarjeta;
go
DROP TABLE IF EXISTS Imagen;
go
DROP TABLE IF EXISTS Item;    
go
DROP TABLE IF EXISTS Clientes;
go
DROP TABLE IF EXISTS Usuarios;
go
DROP TABLE IF EXISTS Marca;
go
DROP TABLE IF EXISTS Categoria;
go
DROP TABLE IF EXISTS EstadoCompra;
go





Create Table Usuarios(
    IdUsuario  int not null primary key identity(1, 1),
    Email varchar(255) not null,
    Password varchar(max) not null,
    Nombre varchar(100) null,
    Rol int not null,
    Estado bit not null,
    FechaRegistro date not null,
    ImagenUrl varchar(1000) null    
)
go


Create Table Clientes(
    IdCliente int not null primary key identity(1, 1),
    IdUsuario int not null,
    Apellido varchar(100) null,
    FechaNacimiento date null,
    
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
)
go

Create Table Marca(
    IdMarca int not null primary key identity(1, 1),
    Nombre varchar(50) not null,
    Descripcion varchar(255) null,
    Estado bit not null
)
go

Create Table Categoria(
    IdCategoria int not null primary key identity(1, 1),
	Nombre varchar(50) not null,
    Descripcion varchar(255) null,
    Estado bit not null
)
go

Create Table Item(
    IdProducto int not null primary key identity(1, 1),
    Nombre varchar(255) not null,
    Descripcion varchar(1000) not null,
    Precio money not null,
    Stock int not null,
    IdCategoria int not null,
    IdMarca int not null,    
    Peso decimal(10, 2) not null,    
	PaisOrigen varchar(50) null, 
    Estado bit not null,
    
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria),
    FOREIGN KEY (IdMarca) REFERENCES Marca(IdMarca)
)
go

Create Table Imagen(
    IdImagen int not null primary key identity(1, 1),
    IdProducto int not null,
    ImagenUrl varchar(1000) not null,
    Estado bit not null,
    
    FOREIGN KEY (IdProducto) REFERENCES Item(IdProducto)
)
go

Create Table ClienteTarjeta(
    IdTarjeta int not null primary key identity(1, 1),
    IdCliente int not null,
    Nombre varchar(100) not null,
    NumeroDeSerie varchar(20) not null,
    ImagenUrlTarj varchar(1000) not null,
    
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
)
go

CREATE TABLE EstadoCompra (
    IdEstadoCompra INT PRIMARY KEY IDENTITY(1,1), 
    Nombre VARCHAR(50) NOT NULL UNIQUE,           
    Descripcion VARCHAR(255) NULL                 
)

go

INSERT INTO EstadoCompra (Nombre, Descripcion) VALUES
('Pendiente De Entrega', 'El pedido se encuentra en almacen para ser entregado al cliente.'),
('Pagado', 'El pago ha sido confirmado exitosamente.'),
('Procesando', 'El pedido está siendo preparado en el almacén.'),
('En Reparto', 'El pedido ha salido para ser entregado al cliente.'),
('Entregado', 'El pedido ha sido entregado satisfactoriamente al cliente.'),
('Cancelado', 'La orden fue cancelada por el cliente o el sistema.'),
('Devuelto', 'El cliente ha iniciado un proceso de devolución.');

go

CREATE TABLE Compra (
    
    IdCompra INT PRIMARY KEY IDENTITY(1,1), 
    IdCliente INT NOT NULL, 
    IdEstadoCompra INT NOT NULL, 
    FechaCompra DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10, 2) NOT NULL,    
    
    FOREIGN KEY (IdEstadoCompra) REFERENCES EstadoCompra (IdEstadoCompra),    
    FOREIGN KEY (IdCliente)  REFERENCES Clientes (IdCliente)
)

go


Insert into Usuarios(Email,             Password,   Rol,    Estado, FechaRegistro)
Values (            'admin@admin.com',  'admin',    0,      1,      GETDATE())


go


CREATE PROCEDURE dbo.SP_GET_ITEM(
    @ID INT
)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        
        SELECT it.IdProducto
            ,it.Nombre
            ,it.Descripcion
            ,it.Precio
            ,it.Stock
            ,c.IdCategoria as IdCat
            ,c.Nombre as cNombre
            ,M.IdMarca as IdMar
            ,M.Nombre as mNombre
            ,it.IdProveedor
            ,it.Peso
            ,it.Estado
            ,IM.IdImagen
            ,IM.ImagenUrl
        FROM ITEM it,
            IMAGEN IM, 
            MARCA M, 
            CATEGORIA C 
        WHERE it.IdProducto = IM.IdProducto
        AND it.IdCategoria = c.IdCategoria
        AND it.IdMarca = m.IdMarca
        AND it.IdProducto = @ID;
    
    END TRY
    BEGIN CATCH

        RAISERROR ('Fallo en sp_get_item', 16, 1);
       
    END CATCH
END
