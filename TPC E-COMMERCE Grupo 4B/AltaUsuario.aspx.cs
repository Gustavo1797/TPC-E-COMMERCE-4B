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
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text)) 
                { 
                    usuario.Email = txtEmail.Text;
                    usuario.Password = txtPassword.Text;
                    usuario.Rol = Seguridad.sesionPerfilAdmin(Session["usuario"]) ? TipoUsuario.ADMIN : TipoUsuario.USUARIOS;                    
                    usuario.Activo = true;
                    usuario.fechaRegistro = DateTime.Now;

                    usuario.IdUsuario = usuarioNegocio.Agregar(usuario);
                    if (Seguridad.sesionPerfilAdmin(Session["usuario"]))
                    {
                        txtEmail.Text = "";
                        txtPassword.Text = "";
                        txtConfirmPassword.Text = "";

                        string msg = "El usuario admin: " + usuario.Email + ", se dio de alta correctamente";
                        Session.Add("msgOk", msg);
                        Response.Redirect("AltaModObj.aspx", false);
                        return;
                    }
                    else 
                    {
                        Session.Add("usuario", usuario);
                        Response.Redirect("Default.aspx", false);
                    }
                    
                }
                else
                {
                    litMensaje.Text = "<div class='alert alert-danger mt-3'>Error: Las contraseñas no coinciden.</div>";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}