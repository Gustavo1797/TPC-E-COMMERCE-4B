using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class WebForm1 : Page
    {
        public List<Producto> listProductos;

        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            FiltroAvanzado = chkBoxAvanzado.Checked;

            if (!IsPostBack)
            {

                List<Producto> listProductosAux = productoNegocio.Listar();
                listProductos = new List<Producto>();

                foreach (Producto prd in listProductosAux)
                {
                    if (prd.Estado == true)
                    {
                        listProductos.Add(prd);
                    }
                }

                Session["listaProductos"] = listProductos;
            }
            else
            {
                listProductos = (List<Producto>)Session["listaProductos"];
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listaOriginal = (List<Producto>)Session["listaProductos"];

            listProductos = listaOriginal.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            DataBind();
        }
        protected void chkBoxAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkBoxAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }
        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlValor.Items.Clear();

            if (ddlCampo.SelectedValue == "Marca")
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();

                ddlValor.DataSource = marcaNegocio.Listar();
                ddlValor.DataTextField = "Nombre";
                ddlValor.DataValueField = "IdMarca";
                ddlValor.DataBind();

                ddlValor.Items.Insert(0, "Seleccioná una marca");
            }

            else if (ddlCampo.SelectedValue == "Categoria")
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                ddlValor.DataSource = categoriaNegocio.Listar();
                ddlValor.DataTextField = "Nombre";
                ddlValor.DataValueField = "IdCategoria";
                ddlValor.DataBind();

                ddlValor.Items.Insert(0, "Selecciona una categoría");
            }

            // FILTRO POR PRECIO
            else if (ddlCampo.SelectedValue == "Precio")
            {
                ddlValor.Items.Add("Mayor a menor");
                ddlValor.Items.Add("Menor a mayor");
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> lista = new List<Producto>();

                string campo = ddlCampo.SelectedValue;
                string valor = ddlValor.SelectedValue;
                string estado = ddlEstado.SelectedValue;

                if (campo == "0" || valor == "0")
                    return;

                if (campo == "Precio")
                {
                    List<Producto> listaOriginal = (List<Producto>)Session["listaProductos"];

                    if (valor == "Mayor a menor")
                        lista = listaOriginal.OrderByDescending(x => x.Precio).ToList();
                    else if (valor == "Menor a mayor")
                        lista = listaOriginal.OrderBy(x => x.Precio).ToList();

                    listProductos = lista;
                    Session["listaProductos"] = lista;
                    DataBind();
                    return;
                }

                lista = negocio.ListarConFiltro(campo, valor, estado);

                listProductos = lista;
                Session["listaProductos"] = lista;

                DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

    }
}
