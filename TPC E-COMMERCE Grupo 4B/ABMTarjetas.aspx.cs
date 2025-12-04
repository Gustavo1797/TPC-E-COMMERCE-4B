using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class ABMTarjetas : System.Web.UI.Page
    {
        ClienteTarjetaNegocio clienteTarjetaNegocio = new ClienteTarjetaNegocio();
        ClienteNegocio clienteNegocio = new ClienteNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        private void loadGrid()
        {
            try
            {
                Cliente cliente = new Cliente();

                if (Session["cliente"] == null)
                {
                    Usuario usario = (Usuario)Session["usuario"];
                    cliente.IdUsuario = usario.IdUsuario;
                    cliente = clienteNegocio.obtenerCliente(cliente.IdUsuario);
                    if (cliente.IdCliente != 0)
                    {
                        Session.Add("cliente", cliente);
                    }
                    else
                    {
                        Response.Redirect("AltaCliente.aspx");
                    }
                }
                else
                {
                    cliente = (Cliente)Session["cliente"];
                }

                dgvTarjetas.DataSource = clienteTarjetaNegocio.listarClienteTarjeta(cliente.IdCliente);
                dgvTarjetas.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvTarjetas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idTarjeta = Convert.ToInt32(e.CommandArgument);
                ClienteTarjeta tarjeta = clienteTarjetaNegocio.obtenerTarjeta(idTarjeta);

                lblTituloCard.Text = "Modificar Tarjeta";
                txtNombre.Text = tarjeta.Nombre;
                txtNumeroSerie.Text = tarjeta.NumeroDeSerie;
                btnEliminar.Visible = true;
                Session["tarjeta"] = tarjeta;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                ClienteTarjeta clienteTarjeta = new ClienteTarjeta();
                clienteTarjeta.Nombre = txtNombre.Text;
                clienteTarjeta.NumeroDeSerie = txtNumeroSerie.Text;
                AsignarImagenCompania(txtNumeroSerie.Text, clienteTarjeta);

                if (Session["tarjeta"] == null)
                {
                    clienteTarjeta.IdCliente = ((Cliente)Session["cliente"]).IdCliente;
                    clienteTarjetaNegocio.Agregar(clienteTarjeta);
                    loadGrid();
                }
                else
                {
                    ClienteTarjeta tarjAux = (ClienteTarjeta)Session["tarjeta"];
                    clienteTarjeta.IdCliente = tarjAux.IdCliente;
                    clienteTarjeta.IdTarjeta = tarjAux.IdTarjeta;
                    clienteTarjetaNegocio.Modificar(clienteTarjeta);

                    string msg = "La tarjeta: " + clienteTarjeta.Nombre + ", se modifico correctamente";
                    Session.Add("msgOk", msg);
                    Response.Redirect("AltaModObj.aspx", false);
                }

                Session["tarjeta"] = null;
                txtNombre.Text = "";
                txtNumeroSerie.Text = "";
                txtNombre.Attributes["placeholder"] = "Ej: Visa Debito Banco Nacion";
                txtNumeroSerie.Attributes["placeholder"] = "Ingrese solo los numeros de la tarjeta";
                btnGuardar.Text = "Guardar";
                lblTituloCard.Text = "Alta de Categoria";

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        private void AsignarImagenCompania(string text, ClienteTarjeta t)
        {
            string primerDigito = text.Substring(0, 1);
            if (text.Substring(0, 1) == "4")
            {
                t.ImagenUrlTarj = "https://img.icons8.com/color/48/visa.png";
            }
            else if (text.Substring(0, 1) == "5")
            {
                t.ImagenUrlTarj = "https://img.icons8.com/color/48/mastercard.png";
            }
            else if (text.Substring(0, 2) == "34" || text.Substring(0, 2) == "37")
            {
                t.ImagenUrlTarj = "https://img.icons8.com/color/48/amex.png";
            }
            else
            {
                t.ImagenUrlTarj = "https://img.icons8.com/color/48/card-in-use.png";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}