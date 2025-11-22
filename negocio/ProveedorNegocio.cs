using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedorNegocio
    {
        public int Agregar(Usuario usuario, Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Insert into Proveedores (IdUsuario,RazonSocial,Cuit) " +
                          "values( @IdUsuario, @RazonSocial, @Cuit); " +
                          "SELECT SCOPE_IDENTITY();";

                datos.setearConsulta(consulta);

                datos.setearParametro("@IdUsuario", usuario.IdUsuario);
                datos.setearParametro("@RazonSocial", proveedor.RazonSocial);
                datos.setearParametro("@Cuit", proveedor.Cuit);

                return datos.ejecutarReturn();
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

        public Proveedor GetProveedor(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Proveedor auxProveedor = new Proveedor();
            auxProveedor.IdProveedor = 0;
            try
            {
                datos.setearConsulta("select IdProveedor,RazonSocial,Cuit from Proveedores where IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", IdUsuario);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    auxProveedor.IdProveedor = (int)datos.Lector["IdProveedor"];
                    auxProveedor.RazonSocial = (string)datos.Lector["RazonSocial"];
                    auxProveedor.Cuit = (string)datos.Lector["Cuit"];
                    
                }
                return auxProveedor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "UPDATE Proveedores (RazonSocial,Cuit) " +
                          "values( @RazonSocial, @Cuit);";

                datos.setearConsulta(consulta);

                datos.setearParametro("@RazonSocial",   proveedor.RazonSocial);
                datos.setearParametro("@Cuit",          proveedor.Cuit);

                return datos.ejecutarReturn();
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
