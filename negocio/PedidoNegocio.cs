using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class PedidoNegocio
    {
        List<Pedido> Listar() 
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();
            Pedido pedidoAct = null;
            int idPedidoAct = -1, idNuevoPedido = -1;

            try
            {
                datos.setearConsulta("select IdPedido, IdCliente, FechaCreacion, " +
                                    "EstadoPedido, DireccionEntrega, MontoTotal " +
                                    "from PEDIDO");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    idNuevoPedido = datos.Lector.GetInt32(0);
                    if (idPedidoAct != idNuevoPedido) 
                    {
                        pedidoAct = new Pedido();
                        idPedidoAct = idNuevoPedido;
                        pedidoAct.idPedido = idNuevoPedido;
                        pedidoAct.idCLiente = (int)datos.Lector["IdCliente"];
                        pedidoAct.fechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                        pedidoAct.estadoPedido = (bool)datos.Lector["EstadoPedido"];
                        pedidoAct.direccionEntrega = (string)datos.Lector["DireccionEntrega"];
                        pedidoAct.montoTotal = (float)datos.Lector["MontoTotal"];
                    } 
                }
                if (idPedidoAct != -1) lista.Add(pedidoAct);

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
