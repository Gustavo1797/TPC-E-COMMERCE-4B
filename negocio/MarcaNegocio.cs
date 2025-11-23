using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar() 
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            Marca marcaAct = null;

            try
            {
                datos.setearConsulta("select IdMarca, Nombre, Descripcion, Estado from Marca order by Estado desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    marcaAct = new Marca();
                    marcaAct.idMarca = datos.Lector.GetInt32(0);
                    marcaAct.nombre = (string)datos.Lector["Nombre"];
                    marcaAct.descripcion = (string)datos.Lector["Descripcion"];
                    marcaAct.estado = (bool)datos.Lector["Estado"];    
                    lista.Add(marcaAct);
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
        public bool Agregar(Marca nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "insert into Marca (Nombre, Descripcion, Estado) " +
                    "values (@nombre, @descripcion, @estado)" +
                    "SELECT SCOPE_IDENTITY();";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@descripcion", nuevo.descripcion);
                datos.setearParametro("@estado", nuevo.estado);

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

        public void Modificar(Marca marca) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Marca set Nombre = @nombre, Descripcion = @descripcion, Estado = @estado " +
               "where IdMarca = @IdMarca";

                datos.setearConsulta(consulta);

                datos.setearParametro("@idMarca", marca.idMarca);
                datos.setearParametro("@nombre", marca.nombre);
                datos.setearParametro("@descripcion", marca.descripcion);
                datos.setearParametro("@estado", marca.estado);

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

        public Marca GetMarca(int IdMarca)
        {
            Marca marca = new Marca();
            AccesoDatos datos = new AccesoDatos();            

            try
            {
                string consulta = "select IdMarca, Nombre, Descripcion, Estado " +
                    "from Marca " +
                    "where IdMarca = @Id " +
                    "order by Estado desc";
                datos.setearConsulta(consulta);             
                datos.setearParametro("@Id", IdMarca);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    marca.idMarca = (int)datos.Lector["IdMarca"];
                    marca.nombre = (string)datos.Lector["Nombre"];
                    marca.descripcion = (string)datos.Lector["Descripcion"];
                    marca.estado = (bool)datos.Lector["Estado"];
                }

                return marca;

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

        public void Eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(" delete from Marca where idMarca = @idMarca ");
                datos.setearParametro("@idMarca ", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}