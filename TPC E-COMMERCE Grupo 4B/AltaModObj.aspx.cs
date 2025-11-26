using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class AltaModObj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (!(Session["msgOk"] is null))
                {
                    lblMensajeConfirmacion.Text = Session["msgOk"].ToString();
                    Session["msgOk"] = null;
                }
                else
                {
                    lblMensajeConfirmacion.Text = "Se creo o actualizo el objeto correctamente.";
                }
            }
        }
    }
}