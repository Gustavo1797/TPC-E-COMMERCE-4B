using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                string consulta = "select IdCompra, IdCliente, IdEstadoCompra, FechaCompra, Total from Compra order by IdCompra desc ";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    compra = new Compra();
                    compra.IdCompra = (int)datos.Lector["IdCompra"];
                    compra.IdCliente = (int)datos.Lector["IdCliente"];
                    compra.IdEstadoCompra = (int)datos.Lector["IdEstadoCompra"];
                    compra.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    compra.Total = (decimal)datos.Lector["Total"];
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
                compra.IdEstadoCompra = 0;
                string consulta = "select IdCompra, IdCliente, IdEstadoCompra, FechaCompra, Total from Compra where IdCompra = @IdCompra ";
                datos.setearConsulta(consulta);
                datos.setearParametro("@IdCompra", IdCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    compra = new Compra();
                    compra.IdCompra = (int)datos.Lector["IdCompra"];
                    compra.IdCliente = (int)datos.Lector["IdCliente"];
                    compra.IdEstadoCompra = (int)datos.Lector["IdEstadoCompra"];
                    compra.FechaCompra = (DateTime)datos.Lector["FechaCompra"];
                    compra.Total = (decimal)datos.Lector["Total"];
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

                datos.setearParametro("@IdCliente", compra.IdCliente);
                datos.setearParametro("@IdEstadoCompra", compra.IdEstadoCompra);
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

                datos.setearParametro("@IdEstadoCompra", compra.IdEstadoCompra);
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
