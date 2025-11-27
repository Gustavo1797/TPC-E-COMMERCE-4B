using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class WebForm1 : Page
    {
        public List<Producto> listProductos;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

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
    }
}