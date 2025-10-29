using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    class Pago
    {
        public int idPago { get; set; }
        public int idCliente { get; set; }
        public int idCarro { get; set; }
        public string metodoDePago { get; set; }
        public float monto { get; set; }
        public DateTime fechaPago { get; set; }
        public bool estadoPago { get; set; }
    }
}