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
    public partial class ABMCategorias : System.Web.UI.Page
    {
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { loadGrid(); }
        }



        protected void btnClick(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.Nombre = txtNombre.Text;
            categoria.Descripcion = txtDescripcion.Text;
            categoria.Estado = true;

            if (Session["IdCategoria"] == null)
            {
                categoriaNegocio.Agregar(categoria);
            }
            else
            {
                categoria.IdCategoria = (int)Session["IdCategoria"];
                categoriaNegocio.Modificar(categoria);
            }

            Session["IdCategoria"] = null;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Attributes["placeholder"] = "Ej: Mi Categoria";
            txtDescripcion.Attributes["placeholder"] = "Ingresa una descripción...";
            chkEstado.Enabled = false;
            btnGuardar.Text = "Guardar";
            lblTituloCard.Text = "Alta de Categoria";

        }

        private void loadGrid()
        {
            dgvCategorias.DataSource = categoriaNegocio.Listar();
            dgvCategorias.DataBind();
        }

        protected void txtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategorias.PageIndex = e.NewPageIndex;
            loadGrid();
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkEstado.Enabled = true;
            btnGuardar.Text = "Actualizar";
            lblTituloCard.Text = "Modificar Categoria";

            int idCategoria = (int)dgvCategorias.SelectedDataKey.Value;
            Categoria categoria = categoriaNegocio.ObtenerCategoria(idCategoria);
            txtNombre.Text = categoria.Nombre;
            txtDescripcion.Text = categoria.Descripcion;
            if (categoria.Estado)
            { chkEstado.Checked = true; }
            else
            { chkEstado.Checked = false; }
            Session["IdCategoria"] = idCategoria;

        }
    }
}