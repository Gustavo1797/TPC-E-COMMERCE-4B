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
    public partial class ItemSeleccionado : System.Web.UI.Page
    {
        public Producto producto=null;
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                 
                int idProductoSeleccionado = (int.Parse)(Request.QueryString["id"].ToString());
                ProductoNegocio productoNegocio = new ProductoNegocio();
                producto = productoNegocio.GetProducto(idProductoSeleccionado);

                lblNombreItem.Text = producto.Nombre;
                lblPrecio.Text = producto.Precio.ToString();
                lblCategoria.Text = producto.Categoria.IdCategoria.ToString();
                lblMarca.Text = producto.Marca.IdMarca.ToString();                    
                lblVendedor.Text = producto.Proveedor.IdProveedor.ToString();
                lblStock.Text = producto.Stock.ToString();
                lblPeso.Text = producto.Peso.ToString();
                litDescripcion.Text = producto.Descripcion;

                
                imgPrincipal.ImageUrl = "https://placehold.co/150x150/EBF5FF/7F9CF5?text=Img+1";
                
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            

        }
    }
}