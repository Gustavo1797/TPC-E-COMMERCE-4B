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
            ,it.Peso
            ,it.Estado
            ,it.PaisOrigen
            ,IM.IdImagen
            ,IM.ImagenUrl
        FROM ITEM it
        INNER JOIN MARCA M on it.IdMarca = m.IdMarca
        INNER JOIN CATEGORIA C on it.IdCategoria = c.IdCategoria
        LEFT JOIN IMAGEN IM on it.IdProducto = IM.IdProducto
        WHERE it.IdProducto = @ID
    
    END TRY
    BEGIN CATCH

        RAISERROR ('Fallo en sp_get_item', 16, 1);
       
    END CATCH
END

