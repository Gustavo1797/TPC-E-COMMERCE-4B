using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    class Carrito
    {
        public int idCarro { get; set; }
        public int idCliente { get; set; }
        public int cantidad { get; set; }
        public float precioUnitario { get; set; }
        public int items { get; set; }
        public float total { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Boolean estado { get; set; }
    }
}