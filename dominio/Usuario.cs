using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario 
    {
        ADMIN = 0, 
        USUARIOS = 1
    }

    public class Usuario
    {
        public int IdUsuario { get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string ImagenUrl { get; set; }
        public TipoUsuario Rol { get; set; }
        public bool Activo { get; set; }
    }
}
