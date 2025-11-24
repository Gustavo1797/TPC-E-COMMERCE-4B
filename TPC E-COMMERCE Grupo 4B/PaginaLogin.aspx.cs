using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class PaginaLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Proveedor proveedor = new Proveedor();
            Cliente cliente = new Cliente();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;

                if (usuarioNegocio.Login(usuario))
                {
                    proveedor = proveedorNegocio.GetProveedor(usuario.IdUsuario);
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "No existe el usuario o el password es incorrecto");
                    Response.Redirect("Error.aspx", false);
                }
                
            }
            catch (Exception ex)
            {
                Session.Add("error",ex.ToString());
                Response.Redirect("Error.aspx",false);
            }

        }
    }
}