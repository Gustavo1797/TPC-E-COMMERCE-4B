using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Compra
    {
        public int IdCompra { get; set; }
        //public int IdCliente { get; set; }        
        public Cliente Cliente { get; set; }
        public EstadoCompra EstadoCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }

    }
}
