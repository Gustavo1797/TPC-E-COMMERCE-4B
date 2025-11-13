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
    }
}
