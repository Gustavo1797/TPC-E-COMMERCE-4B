use master 
go
create database TPC_ECOMMERCE_4B_DB
go
use TPC_ECOMMERCE_4B_DB
go


Create Table Categoria(
    IdCategoria int not null primary key identity(1, 1),
    Nombre varchar(50) not null,
    Descripcion varchar(255) null, -- Agregado: opcional (NULL)
    Estado bit not null
)
go


Create Table Marca(
    IdMarca int not null primary key identity(1, 1),
    Nombre varchar(50) not null,
    Descripcion varchar(255) null -- Agregado: opcional (NULL)
    ,Estado bit not null
)
go


Create Table Proveedor(
    IdProveedor int not null primary key identity(1, 1),
    Nombre varchar(255) not null,
    Cuit_RazonSocial varchar(100) not null, -- Agregado: para CUIT o Razón Social
    Telefono varchar(20) null, -- Agregado: opcional
    Email varchar(255) null, -- Agregado: opcional
    Direccion varchar(500) null -- Agregado: opcional
    ,Estado bit not null
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
    IdProveedor int not null,
    Peso decimal(10, 2) not null,
    Estado bit not null,
    
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria),
    FOREIGN KEY (IdMarca) REFERENCES Marca(IdMarca),
    FOREIGN KEY (IdProveedor) REFERENCES Proveedor(IdProveedor)
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



Insert into Categoria(Nombre, Descripcion, Estado)
Values ('Celulares', 'Todos los celulares', 0);

Insert into Marca(Nombre, Descripcion, Estado)
Values ('Samsung', 'Samsung', 0),
 ('Motorola', 'Motorola', 0),
 ('Xiaomi', 'Xiaomi', 0);

Insert into Proveedor(Nombre, Cuit_RazonSocial, Telefono, Email, Direccion, Estado)
Values ('Samsung','1111-111111','+54-0123-4567','samsung@samsung.com','Calle Samsung 1234',0),
 ('Motorola','2222-222222','+54-4567-8901','motorola@motorola.com','Calle Motorola 1234',0),
 ('Xiaomi','3333-333333','+54-2345-6789','xiaomi@xiaomi.com','Calle Xiaomi 1234',0);

Insert into Item(Nombre, Descripcion, Precio, Stock, IdCategoria, IdMarca, IdProveedor, Peso, Estado)
Values ('S25','Año 2025',1000,50,1,1,1,250.55,0),
('S24','Año 2023',900,60 ,1,1,1,270.50,0),
('G80','Año 2022',800,70 ,1,2,2,280.50,0),
('G60','Año 2021',700,80 ,1,2,2,230.50,0),
('14T','Año 2025',600,90 ,1,3,3,225.00,0),
('13T','Año 2024',500,91 ,1,3,3,300.00,0);

Insert into Imagen(IdProducto, ImagenUrl, Estado)
Values 
 (1,'https://media.flixcar.com/webp/synd-asset/Samsung-298685862-ar-galaxy-s25-s931-534316-sm-s931bzsmaro-544696198--Download-Source--zoom.png',0),
 (1,'https://www.lacuracaonline.com/media/catalog/product/4/6/468748200012_1.jpg?optimize=medium&bg-color=255,255,255&fit=bounds&height=700&width=700&canvas=700:700',0),
 (2,'https://images.samsung.com/is/image/samsung/p6pim/ar/sm-s721bzamaro/gallery/ar-galaxy-s24-fe-s721-sm-s721bzamaro-543972566?$684_547_PNG$',0),
 (2,'https://celulardaclaro.com.br/wp-content/uploads/2024/12/41WiF2xWUiL.jpg',0),
 (3,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSAudyOpG71c4Es_qgeSdmn6SV9mZhMOxxSQQ&s',0),
 (3,'https://www.mobiledokan.co/wp-content/uploads/2021/03/Motorola-Moto-G60-500x500.jpg',0),
 (4,'https://braincorp.com.ve/wp-content/uploads/2023/03/MOTOROLA-G60-4RAM-128GB-DUAL-SIM-MOTO-G60-4-128GB.webp',0),
 (4,'https://resources.claroshop.com/medios-plazavip/t1/1732914884MotoG60NEjpg',0),
 (5,'https://acdn-us.mitiendanube.com/stores/004/109/744/products/14t-3-5d0fc5a0e26b15ba1f17296424888791-1024-1024.jpg',0),
 (5,'https://pycca.vteximg.com.br/arquivos/ids/265006-600-600/O19949.png?v=638630701340200000',0),
 (6,'https://cdn.billowshop.com/9ef84dda-32dd-4016-7da3-1c0a824fffb4/img/Producto/6420d3f3-8dfa-fd0d-ef99-e513d7b830ab/MI13T7-654955e0e4470.jpg',0),
 (6,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTC8IwIBOdD2SFhQvsMUFiL13InMrhLC132jBWOkNjjifBFwF8AqUQnGPW_LvX6b-P1se4&usqp=CAU',0);
