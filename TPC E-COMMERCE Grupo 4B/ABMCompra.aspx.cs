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
    public partial class ABMCompra : System.Web.UI.Page
    {
        CompraNegocio compraNegocio = new CompraNegocio();
        EstadoCompraNegocio estadoCompraNegocio = new EstadoCompraNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<EstadoCompra> listEstadoCompra = new List<EstadoCompra>();
                listEstadoCompra = estadoCompraNegocio.Listar();

                int idCompra = (int)Session["idCompra"];
                Compra compra = compraNegocio.ObtenerCompra(idCompra);

                lblIdVenta.Text = compra.IdCompra.ToString();
                txtUsuario.Text = compra.Cliente.Usuario.Email;
                txtFecha.Text = compra.FechaCompra.ToString("yyyy-MM-dd");
                txtTotal.Text = compra.Total.ToString("0");
                ddlEstados.DataSource = listEstadoCompra;
                ddlEstados.DataTextField = "Nombre";
                ddlEstados.DataValueField = "IdEstadoCompra";
                ddlEstados.DataBind();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session["idCompra"] = null;
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCompra = (int)Session["idCompra"];
                Compra compra = compraNegocio.ObtenerCompra(idCompra);

                compra.EstadoCompra.IdEstadoCompra = int.Parse(ddlEstados.SelectedValue);

                bool actOk = compraNegocio.Modificar(compra);

                if (actOk) 
                {
                    string msg = "Se actualizo correctamente la compra";
                    Session.Add("msgOk", msg);
                    Response.Redirect("AltaModObj.aspx");
                } 
                else 
                {
                    Session.Add("error", "No se pudo actualizar la compra");
                    Response.Redirect("Error.aspx");
                }

                
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}