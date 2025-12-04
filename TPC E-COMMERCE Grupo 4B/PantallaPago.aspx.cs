using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.UI.WebControls;
using dominio;
using negocio;


namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private string AccessToken = "APP_USR-4979078649708032-112420-be1a6e30d8aa3c6816426db315731d1e-3013802145";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblCantidad.Text = Request.QueryString["cantidad"];
                lblTotal.Text = decimal.Parse(Request.QueryString["total"])
                    .ToString("0");

                CargarTarjetas();
            }
        }

        private void CargarTarjetas()
        {
            Cliente cliente = new Cliente();
            cliente = (Cliente)Session["cliente"];
            ClienteTarjetaNegocio clienteTarjetaNegocio = new ClienteTarjetaNegocio();
            List<ClienteTarjeta> listTarjetas = new List<ClienteTarjeta>();
            listTarjetas = clienteTarjetaNegocio.listarClienteTarjeta(cliente.IdCliente);

            if (listTarjetas.Count > 0)
            {
                rptTarjetas.DataSource = listTarjetas;
                rptTarjetas.DataBind();
            }
            else
            {
                lblSinTarjetas.Visible = true;
            }
        }

        private string CrearPreferencia()
        {
            var preference = new
            {
                items = new[]
                {
                    new {
                        title = "Muñeco.store",
                        quantity = 1,
                        unit_price = Convert.ToDecimal(Request.QueryString["total"])
                    }
                },
                back_urls = new
                {
                    success = "https://localhost:44300/Default.aspx",
                    failure = "https://localhost:44300/Error.aspx",
                },
                auto_return = "approved"
            };

            string json = JsonConvert.SerializeObject(preference);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var response = client.PostAsync(
                    "https://api.mercadopago.com/checkout/preferences",
                    new StringContent(json, Encoding.UTF8, "application/json")
                ).Result;

                var contenido = response.Content.ReadAsStringAsync().Result;
                dynamic resp = JsonConvert.DeserializeObject(contenido);

                return resp.init_point;
            }
        }

        protected void MetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            DesmarcarTodasLasTarjetasDelRepeater();
        }

        protected void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSeleccionado = (RadioButton)sender;
            rbMercadoPago.Checked = false;
            rbEfectivo.Checked = false;

            foreach (RepeaterItem item in rptTarjetas.Items)
            {
                RadioButton rb = (RadioButton)item.FindControl("rbTarjeta");
                if (rb != rbSeleccionado)
                {
                    rb.Checked = false;
                }
            }
        }

        private void DesmarcarTodasLasTarjetasDelRepeater()
        {
            foreach (RepeaterItem item in rptTarjetas.Items)
            {
                RadioButton rb = (RadioButton)item.FindControl("rbTarjeta");
                if (rb != null) rb.Checked = false;
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {

                bool check = false;
                int idTarjetaSeleccionada = 0;

                if (rbMercadoPago.Checked)
                {
                    string url = CrearPreferencia();
                    Response.Redirect(url);
                }
                else if (rbEfectivo.Checked)
                {
                    check = true;
                }
                else
                {
                    foreach (RepeaterItem item in rptTarjetas.Items)
                    {
                        RadioButton rb = (RadioButton)item.FindControl("rbTarjeta");
                        if (rb.Checked)
                        {
                            HiddenField hfId = (HiddenField)item.FindControl("hfIdTarjeta");
                            idTarjetaSeleccionada = int.Parse(hfId.Value);
                            check = true;
                            break;
                        }
                    }
                }

                if (check == false)
                {
                    lblMensaje.Text = "Por favor, seleccioná un método de pago.";
                    return;
                }
                else
                {
                    CompraNegocio compraNegocio = new CompraNegocio();
                    Compra compra = new Compra();
                    Cliente cliente = (Cliente)Session["cliente"];
                    compra.Total = decimal.Parse(Request.QueryString["total"]);
                    compra.FechaCompra = DateTime.Now;
                    compra.IdEstadoCompra = 1;
                    compra.IdCliente = cliente.IdCliente;
                    bool compraOk = compraNegocio.Agregar(compra);
                    if (compraOk)
                    {
                        string msg = "Se registro la compra correctamente";
                        Session.Add("msgOk", msg);
                        Response.Redirect("AltaModObj.aspx");
                    }
                    else
                    {
                        Session.Add("error", "\"No se pudo realizar la compra.");
                        Response.Redirect("Error.aspx");
                    }
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception)
            {
                Session.Add("error", "No se pudo realizar la compra.");
                Response.Redirect("Error.aspx");
            }
        }
    }
}
