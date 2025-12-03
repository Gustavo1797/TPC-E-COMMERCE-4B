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
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            imagenPerfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png";

            if (!(Page is PaginaLogin || Page is AltaUsuario || Page is WebForm1 || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("PaginaLogin.aspx", false);
                
            }
            if(!(Seguridad.sesionPerfilAdmin((Usuario)Session["usuario"])) && Session["usuario"] != null)
            {
                Usuario usuario = ((Usuario)Session["usuario"]);
                lblUser.Text = usuario.Email;
                if (!string.IsNullOrEmpty(usuario.ImagenUrl)) 
                    imagenPerfil.ImageUrl = "~/Images/" + usuario.ImagenUrl;
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("PaginaLogin.aspx", false);
        }
    }
}