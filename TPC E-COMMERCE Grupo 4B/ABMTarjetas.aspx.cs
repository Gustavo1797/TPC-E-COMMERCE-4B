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
    public partial class ABMTarjetas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            { 
                loadGrid();
            }
        }

        private void loadGrid()
        {
            dgvTarjetas.DataSource = new List<ClienteTarjeta>();
            dgvTarjetas.DataBind();
        }

        protected void dgvTarjetas_RowCommand(object sender, GridViewCommandEventArgs e)
        {            

        }
    }
}