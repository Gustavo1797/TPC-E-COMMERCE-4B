using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CompraNegocio
    {

        public List<Compra> Listar()
        {
            List<Compra> list = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();
            Compra compra = null;

            try
            {
                string consulta = "select com.IdCompra, com.IdCliente, com.IdEstadoCompra, com.FechaCompra, com.Total, ec.Nombre, ec.Descripcion, us.Email " +
                    " from Compra com " +
                    " inner join EstadoCompra ec on ec.IdEstadoCompra = com.IdEstadoCompra " +
                    " inner join Clientes cl on cl.IdCliente = com.IdCliente" +
                    " inner join Usuarios us on us.IdUsuario = cl.IdUsuario " +
                    " order by com.IdCompra desc";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    compra = new Compra();
                    compra.IdCompra = (int)datos.Lector["IdCompra"];
                    compra.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    compra.Total = (decimal)datos.Lector["Total"];

                    compra.Cliente = new Cliente();
                    compra.Cliente.Usuario = new Usuario();
                    compra.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    compra.Cliente.Usuario.Email = (string)datos.Lector["Email"];

                    compra.EstadoCompra = new EstadoCompra();
                    compra.EstadoCompra.IdEstadoCompra = (int)datos.Lector["IdEstadoCompra"];
                    compra.EstadoCompra.Nombre = (string)datos.Lector["Nombre"];
                    compra.EstadoCompra.Descripcion = (string)datos.Lector["Descripcion"];

                    list.Add(compra);
                }

                return list;
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

        public Compra ObtenerCompra(int IdCompra)
        {
            AccesoDatos datos = new AccesoDatos();
            Compra compra = new Compra();

            try
            {
                compra.IdCompra = 0;
                string consulta = "select com.IdCompra, com.IdCliente, com.IdEstadoCompra, com.FechaCompra, com.Total, ec.Nombre, ec.Descripcion, us.Email " +
                    " from Compra com " +
                    " inner join EstadoCompra ec on ec.IdEstadoCompra = com.IdEstadoCompra " +
                    " inner join Clientes cl on cl.IdCliente = com.IdCliente" +
                    " inner join Usuarios us on us.IdUsuario = cl.IdUsuario " +                    
                    " where IdCompra = @IdCompra";
                datos.setearConsulta(consulta);
                datos.setearParametro("@IdCompra", IdCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    compra = new Compra();
                    compra.IdCompra = (int)datos.Lector["IdCompra"];
                    compra.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    compra.Total = (decimal)datos.Lector["Total"];

                    compra.Cliente = new Cliente();
                    compra.Cliente.Usuario = new Usuario();
                    compra.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    compra.Cliente.Usuario.Email = (string)datos.Lector["Email"];

                    compra.EstadoCompra = new EstadoCompra();
                    compra.EstadoCompra.IdEstadoCompra = (int)datos.Lector["IdEstadoCompra"];
                    compra.EstadoCompra.Nombre = (string)datos.Lector["Nombre"];
                    compra.EstadoCompra.Descripcion = (string)datos.Lector["Descripcion"];
                }

                return compra;
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

        public bool Agregar(Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Insert into Compra (IdCliente, IdEstadoCompra, FechaCompra, Total) " +
                    " values (@IdCliente ,@IdEstadoCompra ,@FechaCompra ,@Total) ";
                datos.setearConsulta(consulta);

                datos.setearParametro("@IdCliente", compra.Cliente.IdCliente);
                datos.setearParametro("@IdEstadoCompra", compra.EstadoCompra.IdEstadoCompra);
                datos.setearParametro("@FechaCompra", compra.FechaCompra);
                datos.setearParametro("@Total", compra.Total);
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Modificar(Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Compra " +
                    " Set IdEstadoCompra = @IdEstadoCompra " +
                    " where IdCompra = @IdCompra ";
                datos.setearConsulta(consulta);                

                datos.setearParametro("@IdEstadoCompra", compra.EstadoCompra.IdEstadoCompra);
                datos.setearParametro("@IdCompra", compra.IdCompra);

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

    }
}
