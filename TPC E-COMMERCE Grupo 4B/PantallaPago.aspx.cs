using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;


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
                lblTotal.Text = Request.QueryString["total"];

                lblTotal.Text = decimal.Parse(Request.QueryString["total"])
                    .ToString("0");
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            string url = CrearPreferencia();
            Response.Redirect(url);
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
    }
}
