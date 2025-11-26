using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class ListaItem : System.Web.UI.Page
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { loadGrid(); }
        }

        private void loadGrid()
        {
            dgvProductos.DataSource = productoNegocio.ListarTodosProductos();
            dgvProductos.DataBind();
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            loadGrid();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = (int)dgvProductos.SelectedDataKey.Value;
            Session["idProducto"] = idProducto;
            Response.Redirect("ABMItem.aspx", false);
        }
    }
}