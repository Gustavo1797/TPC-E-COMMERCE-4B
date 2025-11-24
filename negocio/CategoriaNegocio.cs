using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar() 
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            Categoria categoriaAct = null;            

            try
            {
                datos.setearConsulta("select IdCategoria, Nombre , Descripcion , Estado from Categoria order by Estado desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    categoriaAct = new Categoria();                    
                    categoriaAct.IdCategoria = datos.Lector.GetInt32(0);
                    categoriaAct.Nombre = (string)datos.Lector["Nombre"];
                    categoriaAct.Descripcion = (string)datos.Lector["Descripcion"];
                    categoriaAct.Estado = (bool)datos.Lector["Estado"];
                    lista.Add(categoriaAct);
                }               

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

        public bool Agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "insert into Categoria (Nombre, Descripcion, Estado) " +
                    "values (@nombre, @descripcion, @estado)" +
                    "SELECT SCOPE_IDENTITY();";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@estado", nuevo.Estado);

                if (datos.ejecutarReturn() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public void Modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Categoria set Nombre = @nombre, Descripcion = @descripcion, Estado = @estado " +
               "where IdCategoria = @idCategoria";

                datos.setearConsulta(consulta);

                datos.setearParametro("@idCategoria", categoria.IdCategoria);
                datos.setearParametro("@nombre", categoria.Nombre);
                datos.setearParametro("@descripcion", categoria.Descripcion);
                datos.setearParametro("@estado", categoria.Estado);

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

        public Categoria ObtenerCategoria(int IdCategoria)
        {
            Categoria categoria = new Categoria();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select IdCategoria, Nombre, Descripcion, Estado " +
                    "from Categoria " +
                    "where IdCategoria = @Id " +
                    "order by Estado desc";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Id", IdCategoria);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    categoria.Nombre = (string)datos.Lector["Nombre"];
                    categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    categoria.Estado = (bool)datos.Lector["Estado"];
                }

                return categoria;

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
