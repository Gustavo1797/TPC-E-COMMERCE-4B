using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            Producto prdAct = null;
            int idPrdAct = -1, idNuevoPrd = -1;

            try
            {
                datos.setearConsulta("select it.IdProducto,it.Nombre,it.Descripcion,it.Precio,it.Stock,it.IdCategoria,it.IdMarca,it.IdProveedor,it.Peso,it.Estado,e.IdImagen,e.ImagenUrl " +
                    " from ITEM it, IMAGEN E, MARCA M, CATEGORIA C" +
                    " WHERE it.IdProducto = e.IdProducto" +
                    " AND it.IdCategoria = c.IdCategoria" +
                    " AND it.IdMarca = m.IdMarca" +
                    " order by it.IdProducto");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    idNuevoPrd = datos.Lector.GetInt32(0);
                    if (idPrdAct != idNuevoPrd)
                    {
                        if (idPrdAct != -1) lista.Add(prdAct);
                        prdAct = new Producto();
                        idPrdAct = idNuevoPrd;
                        prdAct.IdProducto = idNuevoPrd;
                        prdAct.Nombre = (string)datos.Lector["Nombre"];
                        prdAct.Descripcion = (string)datos.Lector["Descripcion"];
                        prdAct.Precio = (decimal)datos.Lector["Precio"];
                        prdAct.Stock = (int)datos.Lector["Stock"];
                        prdAct.Categoria = new Categoria();
                        prdAct.Categoria.IdCatergoria = (int)datos.Lector["IdCategoria"];
                    }

                    Imagen auxImagen = new Imagen();
                    auxImagen.ID = (int)datos.Lector["IdImagen"];
                    auxImagen.IdArticulo = (int)datos.Lector["IdProducto"];
                    auxImagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    prdAct.ListImagen.Add(auxImagen);
                }

                if (idPrdAct != -1) lista.Add(prdAct);

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Producto GetProducto(int IdProducto)
        {
            Producto producto = new Producto();
            AccesoDatos datos = new AccesoDatos();
            int idPrdAct = -1, idNuevoPRD = -1;

            try
            {
                datos.setearStoreProcedure("SP_GET_ITEM");
                /*
                datos.setearConsulta("select it.IdProducto,it.Nombre,it.Descripcion,it.Precio,it.Stock,it.IdCategoria,it.Nombre as cNombre,it.IdMarca,it.Nombre as mNombre,it.IdProveedor,it.Peso,it.Estado,e.IdImagen,e.ImagenUrl  " +
                    " from ITEM it, IMAGEN E, MARCA M, CATEGORIA C" +
                    " WHERE it.IdProducto = e.IdProducto" +
                    " AND it.IdCategoria = c.IdCategoria" +
                    " AND it.IdMarca = m.IdMarca" +
                    " AND it.IdProducto = @Id");
                */
                datos.setearParametro("@Id", IdProducto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    idNuevoPRD = (int)datos.Lector["IdProducto"];
                    if (idPrdAct != idNuevoPRD)
                    {
                        producto.IdProducto = (int)datos.Lector["IdProducto"];
                        producto.Nombre = (string)datos.Lector["Nombre"];
                        producto.Descripcion = (string)datos.Lector["Descripcion"];
                        producto.Precio = (decimal)datos.Lector["Precio"];
                        producto.Stock = (int)datos.Lector["Stock"];
                        producto.Marca = new Marca();
                        producto.Marca.idMarca = (int)datos.Lector["IdMar"];
                        producto.Marca.nombre = (string)datos.Lector["mNombre"];
                        producto.Categoria = new Categoria();
                        producto.Categoria.IdCatergoria = (int)datos.Lector["IdCat"];
                        producto.Categoria.Nombre = (string)datos.Lector["cNombre"];
                        producto.Proveedor = new Proveedor();
                        producto.Proveedor.IdProveedor = (int)datos.Lector["IdProveedor"];
                        producto.Peso = (decimal)datos.Lector["Peso"];
                        producto.Estado = (bool)datos.Lector["Estado"];
                    }
                    Imagen auxImagen = new Imagen();
                    auxImagen.ID = (int)datos.Lector["IdImagen"];
                    auxImagen.IdArticulo = (int)datos.Lector["IdProducto"];
                    auxImagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    producto.ListImagen.Add(auxImagen);
                }

                

                return producto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
