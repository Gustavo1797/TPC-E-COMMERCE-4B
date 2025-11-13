using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PagoNegocios
    {
        List<Pago> Listar() 
        {
            List<Pago> lista = new List<Pago>();
            AccesoDatos datos = new AccesoDatos();
            Pago pagoAct = null;
            int idPagoAct = -1, idNuevoPago = -1;

            try
            {
                datos.setearConsulta("select IdPago, IdCliente, IdCarro, " +
                                     "MetodoDePago, Monto, FechaDePago, EstadoDePago from PAGO");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    idNuevoPago = datos.Lector.GetInt32(0);
                    if (idPagoAct != idNuevoPago) 
                    {
                        if (idPagoAct != -1) lista.Add(pagoAct);
                        pagoAct = new Pago();
                        idPagoAct = idNuevoPago;
                        pagoAct.idPago = idNuevoPago;
                        pagoAct.idCliente = (int)datos.Lector["IdCliente"];
                        pagoAct.idCarro = (int)datos.Lector["IdCarro"];
                        pagoAct.metodoDePago = (string)datos.Lector["MetodoDePago"];
                        pagoAct.monto = (float)datos.Lector["Monto"];
                        pagoAct.fechaPago = (DateTime)datos.Lector["FechaDePago"];
                        pagoAct.estadoPago = (bool)datos.Lector["EstadoDePago"];
                    }
                }

                if (idPagoAct != -1) lista.Add(pagoAct);

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
