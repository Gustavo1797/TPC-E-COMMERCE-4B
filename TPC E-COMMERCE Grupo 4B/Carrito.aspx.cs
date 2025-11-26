using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class Carrito : Page
    {
      
        private class ItemCarritoMostrar
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }

        private List<ItemCarrito> ObtenerCarrito()
        {
            if (Session["Carrito"] == null)
                Session["Carrito"] = new List<ItemCarrito>();

            return (List<ItemCarrito>)Session["Carrito"];
        }

        private void AgregarAlCarrito(Producto prod)
        {
            List<ItemCarrito> carrito = ObtenerCarrito();
            ItemCarrito encontrado = null;

            foreach (ItemCarrito item in carrito)
            {
                if (item.Producto.IdProducto == prod.IdProducto)
                {
                    encontrado = item;
                    break;
                }
            }

            if (encontrado == null)
            {
                ItemCarrito nuevo = new ItemCarrito();
                nuevo.Producto = prod;
                nuevo.Cantidad = 1;
                carrito.Add(nuevo);
            }
            else
            {
                encontrado.Cantidad = encontrado.Cantidad + 1;
            }
        }

        private void CargarCarrito()
        {
            List<ItemCarrito> carrito = ObtenerCarrito();
            List<ItemCarritoMostrar> listaMostrar = new List<ItemCarritoMostrar>();
            decimal total = 0;

            foreach (ItemCarrito item in carrito)
            {
                ItemCarritoMostrar fila = new ItemCarritoMostrar();
                fila.IdProducto = item.Producto.IdProducto;
                fila.Nombre = item.Producto.Nombre;
                fila.Cantidad = item.Cantidad;
                fila.PrecioUnitario = item.Producto.Precio;
                fila.Subtotal = item.Producto.Precio * item.Cantidad;

                total = total + fila.Subtotal;

                listaMostrar.Add(fila);
            }

            gvCarrito.DataSource = listaMostrar;
            gvCarrito.DataBind();

            lblTotal.Text = total.ToString("C");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["add"] != null)
            {
                int id = int.Parse(Request.QueryString["add"]);

                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> lista = negocio.Listar();
                Producto prod = null;

                foreach (Producto p in lista)
                {
                    if (p.IdProducto == id)
                    {
                        prod = p;
                        break;
                    }
                }

                if (prod != null)
                    AgregarAlCarrito(prod);

                Response.Redirect("Carrito.aspx");
                return;
            }

            if (!IsPostBack)
                CargarCarrito();
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idProducto = int.Parse(e.CommandArgument.ToString());
                List<ItemCarrito> carrito = ObtenerCarrito();

                ItemCarrito encontrado = null;
                foreach (ItemCarrito item in carrito)
                {
                    if (item.Producto.IdProducto == idProducto)
                    {
                        encontrado = item;
                        break;
                    }
                }

                if (encontrado != null)
                    carrito.Remove(encontrado);

                CargarCarrito();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            List<ItemCarrito> carrito = ObtenerCarrito();

            int cantidadTotal = 0;
            decimal precioUnitario = 0;

            foreach (ItemCarrito item in carrito)
            {
                cantidadTotal += item.Cantidad;
                precioUnitario += item.Producto.Precio;
            }

            // Enviar los datos al checkout
            Response.Redirect("PantallaPago.aspx?cantidad=" + cantidadTotal + "&total=" + precioUnitario);
        }
    }
}