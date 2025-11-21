use master 
go
create database TPC_ECOMMERCE_4B_DB
go
use TPC_ECOMMERCE_4B_DB
go

DROP TABLE IF EXISTS Imagen;
go
DROP TABLE IF EXISTS Item;    
go
DROP TABLE IF EXISTS Proveedores;
go
DROP TABLE IF EXISTS Clientes;
go
DROP TABLE IF EXISTS Usuarios;
go
DROP TABLE IF EXISTS Marca;
go
DROP TABLE IF EXISTS Categoria;
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

Create Table Proveedores(
    IdProveedor int not null primary key identity(1, 1),
    IdUsuario  int not null,
    RazonSocial varchar(100) not null,
    Cuit varchar(13) null,

    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
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
    IdProveedor int not null,
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
    FOREIGN KEY (IdMarca) REFERENCES Marca(IdMarca),
    FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor)
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

Insert into Categoria(Nombre ,Descripcion, Estado)
Values ('Celulares', 'Todos los celulares', 0);

go

Insert into Marca(Nombre, Descripcion, Estado)
Values ('Samsung', 'Samsung', 0),
 ('Motorola', 'Motorola', 0),
 ('Xiaomi', 'Xiaomi', 0);

go

Insert into Usuarios(Email, Password, Rol, Estado, FechaRegistro)
Values ('admin@admin.com', 'admin', 0, 1, GETDATE())

update Usuarios set Email = 'admin@admin.com' where IdUsuario = 1
select * from Usuarios

go


ALTER PROCEDURE dbo.SP_GET_ITEM(
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
