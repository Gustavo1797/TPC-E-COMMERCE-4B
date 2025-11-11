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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Producto> listProductos = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                listProductos = productoNegocio.Listar();
            }
        }
    }




}