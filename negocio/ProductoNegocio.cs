using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> ListarTodosProductos()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            Producto prdAct = null;
            int idPrdAct = -1, idNuevoPrd = -1;

            try
            {
                string consulta = "select it.IdProducto,it.Nombre,it.Descripcion,it.Precio,it.Stock,it.IdCategoria,c.Nombre as cNombre,it.IdMarca,m.Nombre as mNombre,it.Peso,it.Estado,e.IdImagen,e.ImagenUrl " +
                    " from ITEM it " +
                    " INNER JOIN MARCA M on it.IdMarca = m.IdMarca " +
                    " INNER JOIN CATEGORIA C on it.IdCategoria = c.IdCategoria " +
                    " LEFT JOIN IMAGEN e on it.IdProducto = e.IdProducto order by it.IdProducto";

                datos.setearConsulta(consulta);
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
                        prdAct.Estado = (bool)datos.Lector["Estado"];
                        prdAct.Categoria = new Categoria();
                        prdAct.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                        prdAct.Categoria.Nombre = (string)datos.Lector["cNombre"];
                        prdAct.Marca = new Marca();
                        prdAct.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                        prdAct.Marca.Nombre = (string)datos.Lector["mNombre"];
                        prdAct.ListImagen = new List<Imagen>();
                    }

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("IdImagen")))
                    {
                        Imagen auxImagen = new Imagen();
                        auxImagen.ID = (int)datos.Lector["IdImagen"];
                        auxImagen.IdArticulo = (int)datos.Lector["IdProducto"];
                        auxImagen.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                        prdAct.ListImagen.Add(auxImagen);
                    }
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

        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            Producto prdAct = null;
            int idPrdAct = -1, idNuevoPrd = -1;

            try
            {
                datos.setearConsulta("select it.IdProducto,it.Nombre,it.Descripcion,it.Precio,it.Stock,it.IdCategoria,c.Nombre as cNombre,it.IdMarca,m.Nombre as mNombre,it.Peso,it.Estado,e.IdImagen,e.ImagenUrl " +
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
                        prdAct.Estado = (bool)datos.Lector["Estado"];
                        prdAct.Categoria = new Categoria();
                        prdAct.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                        prdAct.Categoria.Nombre = (string)datos.Lector["cNombre"];
                        prdAct.Marca = new Marca();
                        prdAct.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                        prdAct.Marca.Nombre = (string)datos.Lector["mNombre"];
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
                //datos.setearStoreProcedure("SP_GET_ITEM");

                datos.setearConsulta("select it.IdProducto,it.Nombre,it.Descripcion,it.Precio,it.Stock,it.IdCategoria,it.Nombre as cNombre,it.IdMarca,it.Nombre as mNombre,it.IdProveedor,it.Peso, it.PaisOrigen, it.Estado,e.IdImagen,e.ImagenUrl  " +
                    " from ITEM it, IMAGEN E, MARCA M, CATEGORIA C" +
                    " WHERE it.IdProducto = e.IdProducto" +
                    " AND it.IdCategoria = c.IdCategoria" +
                    " AND it.IdMarca = m.IdMarca" +
                    " AND it.IdProducto = @Id");

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
                        producto.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                        producto.Marca.Nombre = (string)datos.Lector["mNombre"];
                        producto.Categoria = new Categoria();
                        producto.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                        producto.Categoria.Nombre = (string)datos.Lector["cNombre"];
                        producto.Peso = (decimal)datos.Lector["Peso"];
                        if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("PaisOrigen")))
                        {
                            producto.Pais = (string)datos.Lector["PaisOrigen"];
                        }
                        else
                        {
                            producto.Pais = "Sin especificar";
                        }

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

        public int Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            int IdProducto = 0;

            try
            {
                string consulta = "Insert into Item(Nombre, Descripcion, Precio, Stock, IdCategoria, IdMarca, Peso, PaisOrigen, Estado) " +
                    " values(@Nombre, @Descripcion, @Precio, @Stock, @IdCategoria, @IdMarca, @Peso, @PaisOrigen, @Estado) " +
                    " SELECT SCOPE_IDENTITY();";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@Stock", nuevo.Stock);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.IdCategoria);
                datos.setearParametro("@IdMarca", nuevo.Marca.IdMarca);
                datos.setearParametro("@Peso", nuevo.Peso);
                datos.setearParametro("@PaisOrigen", nuevo.Pais);
                datos.setearParametro("@Estado", nuevo.Estado);
                return datos.ejecutarReturn();

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

        public void Modificar(Producto modificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "update Item set Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock," +
                    "IdCategoria = @IdCategoria, IdMarca = @IdMarca , Peso = @Peso , PaisOrigen = @PaisOrigen , Estado = @Estado where IdProducto = @IdProducto";


                datos.setearConsulta(consulta);
                datos.setearParametro("@IdProducto", modificado.IdProducto);
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@Precio", modificado.Precio);
                datos.setearParametro("@Stock", modificado.Stock);
                datos.setearParametro("@IdCategoria", modificado.Categoria.IdCategoria);
                datos.setearParametro("@IdMarca", modificado.Marca.IdMarca);
                datos.setearParametro("@Peso", modificado.Peso);
                datos.setearParametro("@PaisOrigen", modificado.Pais);
                datos.setearParametro("@Estado", modificado.Estado);
                datos.ejecutarAccion();

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
