using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        CompraNegocio compraNegocio = new CompraNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        private void loadGrid()
        {
            try
            {
                dgvCompras.DataSource = compraNegocio.Listar();
                dgvCompras.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void dgvCompras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCompras.PageIndex = e.NewPageIndex;
            loadGrid();
        }

        protected void dgvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCompra = (int)dgvCompras.SelectedDataKey.Value;
            Session["idCompra"] = idCompra;
            Response.Redirect("ABMCompra.aspx", false);
        }
    }
}