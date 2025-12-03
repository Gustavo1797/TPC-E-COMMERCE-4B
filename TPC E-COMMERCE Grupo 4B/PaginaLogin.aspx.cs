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
            Page.Validate();
            if (!Page.IsValid)
                return;

            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                Session.Add("error", "Debes completar ambos campos...");
                Response.Redirect("Error.aspx");
            }

            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;

                if (usuarioNegocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    if (usuario.Rol == TipoUsuario.USUARIOS) 
                    {                        
                        Response.Redirect("Default.aspx", false);
                    } 
                    else 
                    {                        
                        Response.Redirect("ListaItem.aspx", false);
                    }
                }
                else
                {
                    Session.Add("error", "No existe el usuario o el password es incorrecto");
                    Response.Redirect("Error.aspx", false);
                }
                
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error",ex.ToString());
                Response.Redirect("Error.aspx",false);
            }

        }
    }
}