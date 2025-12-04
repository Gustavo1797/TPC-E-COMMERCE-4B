using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ClienteTarjetaNegocio
    {

        public bool Agregar(ClienteTarjeta tarjeta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Insert into ClienteTarjeta (IdCliente, Nombre, NumeroDeSerie, ImagenUrlTarj) " +
                          "values(@IdCliente, @Nombre, @NumeroDeSerie, @ImagenUrlTarj); ";

                datos.setearConsulta(consulta);

                datos.setearParametro("@IdCliente", tarjeta.IdCliente);
                datos.setearParametro("@Nombre", tarjeta.Nombre);
                datos.setearParametro("@NumeroDeSerie", tarjeta.NumeroDeSerie);
                datos.setearParametro("@ImagenUrlTarj", tarjeta.ImagenUrlTarj);

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

        public bool Modificar(ClienteTarjeta tarjeta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update ClienteTarjeta " +
                          " SET Nombre = @Nombre, NumeroDeSerie = @NumeroDeSerie , ImagenUrlTarj = @ImagenUrlTarj " +
                          " where IdCliente = @IdCliente ";

                datos.setearConsulta(consulta);

                datos.setearParametro("@Nombre", tarjeta.Nombre);
                datos.setearParametro("@NumeroDeSerie", tarjeta.NumeroDeSerie);
                datos.setearParametro("@ImagenUrlTarj", tarjeta.ImagenUrlTarj);
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

        public List<ClienteTarjeta> listarClienteTarjeta(int IdCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            List<ClienteTarjeta> list = new List<ClienteTarjeta>();
            ClienteTarjeta tarjeta;


            try
            {
                string consulta = "select IdTarjeta, Nombre, NumeroDeSerie, ImagenUrlTarj from ClienteTarjeta where IdCliente = @IdCliente ";
                datos.setearConsulta(consulta);
                datos.setearParametro("@IdCliente", IdCliente);
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                { 
                    tarjeta = new ClienteTarjeta();
                    tarjeta.IdCliente = IdCliente;
                    if (!(datos.Lector["IdTarjeta"] is DBNull))
                        tarjeta.IdTarjeta = (int)datos.Lector["IdTarjeta"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        tarjeta.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["NumeroDeSerie"] is DBNull))
                        tarjeta.NumeroDeSerie = (string)datos.Lector["NumeroDeSerie"];
                    if (!(datos.Lector["ImagenUrlTarj"] is DBNull))
                        tarjeta.NumeroDeSerie = (string)datos.Lector["ImagenUrlTarj"];

                    list.Add(tarjeta);

                }

                return list;

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
