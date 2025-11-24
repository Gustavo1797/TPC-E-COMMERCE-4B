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
            if (!(Page is PaginaLogin || Page is AltaUsuario))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                Response.Redirect("PaginaLogin.aspx", false);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e) 
        {
            Session.Clear();
            Response.Redirect("PaginaLogin.aspx",false);
        }
    }
}