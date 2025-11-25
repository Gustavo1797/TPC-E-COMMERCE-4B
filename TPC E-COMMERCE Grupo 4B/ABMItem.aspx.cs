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

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            

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
            producto.IdProducto = productoNegocio.Agregar(producto);

            if (producto.IdProducto > 0) 
            {
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                List<Imagen> listImagen = new List<Imagen>();
                if (Session["listImagen"] != null)
                {
                    listImagen = (List<Imagen>)Session["listImagen"];
                }

                foreach (Imagen imagen in listImagen) 
                {
                    imagen.IdArticulo = producto.IdProducto;
                    imagen.Estado = true;
                    imagenNegocio.Agregar(imagen);
                }
            }
            else
            { 
            
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {            

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

            if (string.IsNullOrEmpty(imageUrl)) 
            {
                lblImagenStatus.Text = "Debe ingresar una URL.";
                return;
            }


            Imagen imageAux = new Imagen();
            imageAux.ImagenUrl = imageUrl;
            List<Imagen> listImagen = new List<Imagen>();

            if (Session["listImagen"] != null)
            {
                listImagen = (List<Imagen>)Session["listImagen"];                
            } 
            
            if (existeLaImagen(listImagen, imageUrl))
            {
                lblImagenStatus.Text = "Esta URL ya existe en la lista.";
                return;
            }

            if (EsImagenValidaRemota(imageUrl))
            {
                listImagen.Add(imageAux);
                Session["listImagen"] = listImagen;
                cargarGridView(listImagen);
            }
            else
            {
                lblImagenStatus.Text = "No es una imagen valida o fallo la conexion.";
                cargarGridView(listImagen);
                return;
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

        private void cargarGridView(List<Imagen> list) 
        {            
            dgvImagenes.DataSource = list;
            dgvImagenes.DataBind();            
        }
    }
}