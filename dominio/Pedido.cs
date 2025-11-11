using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public int idCLiente { get; set; }
        public DateTime fechaCreacion { get; set; }
        //List<detallePedido> detallePedido;
        public bool estadoPedido { get; set; }
        public string direccionEntrega { get; set; }
        public float montoTotal { get; set; }
        //public Pago pago_ { get; set; }
    }
}
