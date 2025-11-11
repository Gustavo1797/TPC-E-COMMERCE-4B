using System;
using System.Web.UI;

namespace TPC_E_COMMERCE_Grupo_4B
{
    public partial class Carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Más adelante acá vas a cargar los productos del carrito
                // Por ahora lo dejamos vacío para que solo navegue sin errores.
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Por ahora, solo redirigimos luego de "confirmar"
            // Podés cambiarlo por una página de "Gracias por tu compra" si querés.
            Response.Redirect("Default.aspx");
        }
    }
}