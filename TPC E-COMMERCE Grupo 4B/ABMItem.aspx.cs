using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class ABMItem : System.Web.UI.Page
    {
        MarcaNegocio marcaNegocio = new MarcaNegocio();
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        ProductoNegocio productoNegocio = new ProductoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                List<Marca> listMarcas = new List<Marca>();
                List<Categoria> listCategorias = new List<Categoria>();

                listMarcas = marcaNegocio.Listar();
                listCategorias = categoriaNegocio.Listar();

                ddlCategoria.DataSource = listCategorias;
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();

                ddlMarca.DataSource = listMarcas;
                ddlMarca.DataTextField = "Nombre";
                ddlMarca.DataValueField = "IdMarca";
                ddlMarca.DataBind();
                
                if (!(Session["idProducto"] is null))
                {
                    try
                    {
                        int id = int.Parse(Session["idProducto"].ToString());
                        Producto producto = new Producto();
                        producto = productoNegocio.GetProducto(id);

                        sTituloCard.Text = "Modificacion del Producto: " + producto.Nombre;
                        btnGuardar.Text = "Modificar Producto";
                        btnLimpiar.Enabled = false;
                        btnLimpiar.Visible = false;

                        txtNombre.Text = producto.Nombre;
                        txtDescripcion.Text = producto.Descripcion;
                        txtPrecio.Text = producto.Precio.ToString();
                        txtStock.Text = producto.Stock.ToString();
                        txtPeso.Text = producto.Peso.ToString();
                        txtPaisOrigen.Text = producto.Pais;
                        ddlCategoria.SelectedIndex = producto.Categoria.IdCategoria;
                        ddlMarca.SelectedIndex = producto.Marca.IdMarca;
                        chkEstado.Checked = producto.Estado;
                        Session["listImagen"] = producto.ListImagen;
                        cargarGridView(producto.ListImagen);
                    }
                    catch (Exception ex)
                    {
                        Session.Add("Error", ex.ToString());
                        Response.Redirect("Error.aspx", false);
                    }                    
                }                 
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = decimal.Parse(txtPrecio.Text);
            producto.Stock = int.Parse(txtStock.Text);
            producto.Categoria = new Categoria();
            producto.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
            producto.Marca = new Marca();
            producto.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
            producto.Peso = decimal.Parse(txtPeso.Text);
            producto.Pais = txtPaisOrigen.Text;
            producto.Estado = chkEstado.Checked;
            

            if (!(Session["idProducto"] is null))
            {
                try
                {
                    producto.IdProducto = int.Parse(Session["idProducto"].ToString());
                    productoNegocio.Modificar(producto);

                    List<Imagen> listaUrlImagenes = obtenerListaUrlImagenes();
                    if (listaUrlImagenes.Count > 0) 
                    {
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        foreach (Imagen imagen in listaUrlImagenes) 
                        {
                            if (imagen.ID == 0) 
                            {
                                imagen.IdArticulo = producto.IdProducto;
                                imagenNegocio.Agregar(imagen);
                            } 
                            else if (imagen.Estado == false && imagen.ID > 0) 
                            { 
                                imagenNegocio.Eliminar(imagen);
                            }
                        }
                    }

                    string msg = "El producto: " + producto.Nombre + ", se modifico correctamente";
                    Session.Add("msgOk", msg);
                    Response.Redirect("AltaModObj.aspx", false);
                    return;
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                    return;
                }

            }
            else 
            {
                producto.IdProducto = productoNegocio.Agregar(producto);
            }
            
            if (producto.IdProducto > 0)
            {
                try
                {
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    List<Imagen> listImagen = new List<Imagen>();
                    listImagen = obtenerListaUrlImagenes();                    

                    foreach (Imagen imagen in listImagen)
                    {
                        imagen.IdArticulo = producto.IdProducto;
                        imagen.Estado = true;
                        imagenNegocio.Agregar(imagen);
                    }

                    string msg = "El producto: " + producto.Nombre + ", se dio de alta correctamente";
                    Session.Add("msgOk", msg);
                    Response.Redirect("AltaModObj.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.ToString());
                    Response.Redirect("Error.aspx", false);
                }

            }

        }

        
        protected void borrarMensajeStatus(object sender, EventArgs e)
        {
            lblProductoStatus.Visible = false;
            lblProductoStatus.Text = string.Empty;
        }
        

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarPantalla();
        }

        private void limpiarPantalla()
        {
            sTituloCard.Text = "Alta de Producto";
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtPaisOrigen.Text = string.Empty;
            lblImagenStatus.Text = string.Empty;

            txtNombre.Attributes["placeholder"] = "Ej: Nombre del producto";
            txtDescripcion.Attributes["placeholder"] = "Detalle técnico y características...";
            txtPrecio.Attributes["placeholder"] = "0.00";
            txtStock.Attributes["placeholder"] = "0";
            ddlCategoria.SelectedValue = "0";
            ddlMarca.SelectedValue = "0";
            txtPeso.Attributes["placeholder"] = "0.00";
            txtPaisOrigen.Attributes["placeholder"] = "Ej: Argentina";
            chkEstado.Checked = true;
            limpiarSession();
            cargarGridView(new List<Imagen>());
        }

        private void limpiarSession() 
        {
            Session["listImagen"] = null;
            Session["msgOk"] = null;
            Session["idProducto"] = null;
            Session["Error"] = null;
        }

        /*
         Cargar grid de imagenes
         */
        private void cargarGridView(List<Imagen> list)
        {
            try
            {
                lblImagenStatus.Text = string.Empty;
                txtUrlImagen.Text = string.Empty;
                txtUrlImagen.Attributes["placeholder"] = "https://ejemplo.com/imagen.jpg";
                dgvImagenes.DataSource = list;
                dgvImagenes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }


        /*
        Manejo de Imagenes 
         */

        private bool EsImagenValidaRemota(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string contentType = response.ContentType.ToLower();
                        return contentType.StartsWith("image/");
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool existeLaImagen(List<Imagen> listImagen, string imageUrl)
        {
            foreach (Imagen imagen in listImagen)
            {
                if (imagen.ImagenUrl.Equals(imageUrl))
                {
                    return true;
                }
            }
            return false;
        }

        private List<Imagen> obtenerListaUrlImagenes()
        {
            if (Session["listImagen"] != null)
            {
                return (List<Imagen>)Session["listImagen"];
            }
            return new List<Imagen>();
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            string urlIngresada = txtUrlImagen.Text;
            imgPreview.ImageUrl = urlIngresada;
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string imageUrl = txtUrlImagen.Text;
            lblImagenStatus.Text = "";
            try
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    lblImagenStatus.Text = "Debe ingresar una URL.";
                    return;
                }

                Imagen imageAux = new Imagen();
                imageAux.ID = 0;
                imageAux.Estado = true;
                imageAux.ImagenUrl = imageUrl;
                List<Imagen> listImagen = obtenerListaUrlImagenes();

                if (existeLaImagen(listImagen, imageUrl))
                {
                    lblImagenStatus.Text = "Esta URL ya existe en la lista.";
                    return;
                }

                if (EsImagenValidaRemota(imageUrl))
                {
                    listImagen.Add(imageAux);
                    Session["listImagen"] = listImagen;
                    cargarGridView(listImagenEstadoTrue());
                }
                else
                {
                    lblImagenStatus.Text = "No es una imagen valida o fallo la conexion.";
                    cargarGridView(listImagenEstadoTrue());
                    return;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }        
        }

        protected void dgvImagenes_DeleteUrlImage(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            int indiceFila = e.RowIndex;
            List<Imagen> listImagen = obtenerListaUrlImagenes();

            if (listImagen.Count > 0)
            {
                Imagen imagenPorBorrar = listImagen[indiceFila];
                if (imagenPorBorrar.ID > 0)
                {
                    imagenPorBorrar.Estado = false;
                }
                else
                {
                    listImagen.RemoveAt(indiceFila);
                }
                Session["listImagen"] = listImagen;               

                cargarGridView(listImagenEstadoTrue());
            }
            else
            {
                cargarGridView(new List<Imagen>());
            }
        }

        protected void dgvImagenes_SelectedIndexChanged (object sender, EventArgs e) 
        {
            int indiceFila = dgvImagenes.SelectedIndex;
            List<Imagen> listImagen = listImagenEstadoTrue();
            imgPreview.ImageUrl = listImagen[indiceFila].ImagenUrl;
        }

        private List<Imagen> listImagenEstadoTrue() 
        {
            List<Imagen> listImagen = obtenerListaUrlImagenes();
            List<Imagen> listImagenAux = new List<Imagen>();
            foreach (Imagen imagen in listImagen)
            {
                int id = imagen.ID;
                if (imagen.Estado)
                {
                    listImagenAux.Add(imagen);
                }
            }
            return listImagenAux;
        }
    }
}