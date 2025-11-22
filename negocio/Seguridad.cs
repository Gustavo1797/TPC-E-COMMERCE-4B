using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        { 
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.IdUsuario != 0) 
                return true;
            else 
                return false;
        }

        public static bool sesionPerfilProveedor(object prov)
        {
            Proveedor proveedor = prov != null ? (Proveedor)prov : null;
            if (proveedor != null && proveedor.IdProveedor != 0)
                return true;
            else
                return false;
        }
    }
}
