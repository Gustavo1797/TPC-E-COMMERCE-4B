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

            if (!IsPostBack) 
            {
                if (Request.QueryString["Id"] != null) 
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    mostrarDetalle(id);
                }
            }
        }

        private void mostrarDetalle(int id) 
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto prod = negocio.GetProducto(id);

            if (prod == null) return;

            imgDetalle.ImageUrl = prod.ListImagen[0].ImagenUrl;
            lblNombre.Text = prod.Nombre;
            lblDescripcion.Text = prod.Descripcion;
            lblMarca.Text = "Marca; " + prod.Marca.Nombre;
            lblCategoria.Text = "Categoria: " + prod.Categoria.Nombre;
            lblPrecio.Text = "Precio: $" + prod.Precio.ToString("N0");

            panelDetalle.Visible = true;
        }

    }
}