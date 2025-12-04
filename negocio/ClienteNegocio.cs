using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public bool Agregar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Insert into Clientes (IdUsuario, Apellido, FechaNacimiento) " +
                          "values(@IdUsuario, @Apellido, @FechaNacimiento); ";

                datos.setearConsulta(consulta);

                datos.setearParametro("@IdUsuario", cliente.IdUsuario);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@FechaNacimiento", cliente.FechaNacimiento);

                datos.ejecutarAccion();

                return true;
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

        public bool Modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Clientes " +
                          " SET Apellido = @Apellido, FechaNacimiento = @FechaNacimiento " +
                          " where IdCliente = @IdCliente ";

                datos.setearConsulta(consulta);

                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@FechaNacimiento", cliente.FechaNacimiento);
                datos.setearParametro("@IdCliente", cliente.IdCliente);
                datos.ejecutarAccion();
                return true;
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

        public Cliente obtenerCliente(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = new Cliente();
            try
            {
                cliente.IdCliente = 0;

                string consulta = "select IdCliente, Apellido, FechaNacimiento from Clientes where IdUsuario = @IdUsuario ";
                datos.setearConsulta(consulta);
                datos.setearParametro("@IdUsuario", IdUsuario);
                datos.ejecutarLectura();             
                

                if (datos.Lector.Read())
                {
                    cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    
                    if (!(datos.Lector["Apellido"] is DBNull))
                        cliente.Apellido = (string)datos.Lector["Apellido"];
                    
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        cliente.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
                }

                return cliente;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
