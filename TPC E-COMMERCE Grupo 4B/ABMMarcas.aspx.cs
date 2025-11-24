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
    public partial class ABMMarcas : System.Web.UI.Page
    {
        MarcaNegocio marcaNegocio = new MarcaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { loadGrid(); }
        }



        protected void btnClick(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.Nombre = txtNombre.Text;
            marca.Descripcion = txtDescripcion.Text;
            marca.Estado = true;

            if (Session["IdMarca"] == null) 
            {
                marcaNegocio.Agregar(marca);
                //if (marcaNegocio.Agregar(marca)) loadGrid();
            } 
            else 
            {
                marca.IdMarca = (int)Session["IdMarca"];
                marcaNegocio.Modificar(marca);                
            }

            Session["IdMarca"] = null;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Attributes["placeholder"] = "Ej: Mi Marca";
            txtDescripcion.Attributes["placeholder"] = "Ingresa una descripción...";
            chkEstado.Enabled = false;
            btnGuardar.Text = "Guardar";
            lblTituloCard.Text = "Alta de Marca";

        }

        private void loadGrid()
        {            
            dgvMarcas.DataSource = marcaNegocio.Listar();
            dgvMarcas.DataBind();
        }

        protected void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarcas.PageIndex = e.NewPageIndex;
            loadGrid();
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkEstado.Enabled = true;
            btnGuardar.Text = "Actualizar";
            lblTituloCard.Text = "Modificar Marca";

            int idMarca = (int)dgvMarcas.SelectedDataKey.Value;
            Marca marca = marcaNegocio.GetMarca(idMarca);
            txtNombre.Text = marca.Nombre;
            txtDescripcion.Text = marca.Descripcion;
            if (marca.Estado) 
            { chkEstado.Checked = true; }
            else 
            { chkEstado.Checked = false; }
            Session["IdMarca"] = idMarca;

        }

    }
}