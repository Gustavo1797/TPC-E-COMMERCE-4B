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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                if (Seguridad.sesionActiva(Session["usuario"])) 
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    txtEmail.Text = usuario.Email;
                    txtPassword.Attributes["placeholder"] = "****";                    
                    if(!(string.IsNullOrEmpty(usuario.Nombre))) 
                        txtNombre.Text = usuario.Nombre;
                    if(!(string.IsNullOrEmpty(usuario.ImagenUrl))) 
                    {                        
                        imagenView.ImageUrl = "~/Images/" + usuario.ImagenUrl;
                    }

                    Cliente cliente = new Cliente();
                    cliente.IdUsuario = usuario.IdUsuario;
                    cliente.IdCliente = 0;
                    clienteNegocio.obtenerCliente(cliente);
                    if (cliente.IdCliente != 0)
                    {
                        if (!(string.IsNullOrEmpty(cliente.Apellido))) txtApellido.Text = cliente.Apellido;
                        if (cliente.FechaNacimiento is DBNull) txtFechaNacimiento.Text = cliente.FechaNacimiento.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];
                if (!(string.IsNullOrEmpty(txtPassword.Text)) && usuario.Password != txtPassword.Text) 
                    usuario.Password = txtPassword.Text;
                usuario.Email = txtEmail.Text;
                usuario.Nombre = txtNombre.Text;
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.IdUsuario + ".jpg");
                    usuario.ImagenUrl = "perfil-" + usuario.IdUsuario + ".jpg";
                }
                if (usuarioNegocio.Modificar(usuario)) 
                {
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    Cliente cliente = new Cliente();
                    cliente.IdUsuario = usuario.IdUsuario;
                    bool existeCliente = clienteNegocio.obtenerCliente(cliente);
                    cliente.Apellido = txtApellido.Text;
                    cliente.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                    if (existeCliente)
                    {
                        clienteNegocio.Modificar(cliente);
                    }
                    else
                    {
                        if (!clienteNegocio.Agregar(cliente))
                        {
                            Session.Add("error", "No se pudo actualizar el usuario.");
                            Response.Redirect("Error.aspx");
                        }
                    }

                    string msg = "Se actualizo correctamente la informacion";
                    Session.Add("msgOk", msg);
                    Response.Redirect("AltaModObj.aspx");
                }
                else
                {
                    Session.Add("error", "No se pudo actualizar el usuario.");
                    Response.Redirect("Error.aspx");
                }

                

            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx");

            }
        }
    }
}