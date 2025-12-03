using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int Agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Insert into Usuarios (Email, Password, Rol, Estado, fechaRegistro) " +
                          "values(@Email, @Password, @Rol, @Estado, @Fecha); " +
                          "SELECT SCOPE_IDENTITY();";

                datos.setearConsulta(consulta);

                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Password", nuevo.Password);
                datos.setearParametro("@Rol", (int)nuevo.Rol);
                datos.setearParametro("@Estado", nuevo.Activo);
                datos.setearParametro("@Fecha", nuevo.fechaRegistro);

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

        public bool Modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Usuarios " +
                            " SET Email = @Email, Password = @Password, Nombre = @Nombre, ImagenUrl = @ImagenUrl " +
                            " where IdUsuario = @IdUsuario ";

                datos.setearConsulta(consulta);

                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Password",  usuario.Password);
                datos.setearParametro("@Nombre",    usuario.Nombre);
                datos.setearParametro("@ImagenUrl", usuario.ImagenUrl);
                datos.setearParametro("@IdUsuario", usuario.IdUsuario);

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

        public bool Login(Usuario usuario) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IdUsuario,Rol,ImagenUrl,Nombre from usuarios where Email = @email and Password = @pass");
                datos.setearParametro("@email",usuario.Email);
                datos.setearParametro("@pass",usuario.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                { 
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Rol = (TipoUsuario)datos.Lector["Rol"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        usuario.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    return true;
                }
                return false;
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
