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