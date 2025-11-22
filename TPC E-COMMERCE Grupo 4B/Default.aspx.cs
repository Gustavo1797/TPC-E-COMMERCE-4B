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
            listProductos = productoNegocio.Listar();
        }
    }
}