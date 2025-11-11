using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar() 
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            Marca marcaAct = null;
            int idMarcaAct = -1, idMarcaNueva = -1;

            try
            {
                datos.setearConsulta("select IdMarca, Nombre, Descripcion, PaisOrigen, Estado from Marca");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    idMarcaNueva = datos.Lector.GetInt32(0);
                    if (idMarcaAct != idMarcaNueva) 
                    {
                        if (idMarcaAct != -1) lista.Add(marcaAct);
                        marcaAct = new Marca();
                        idMarcaAct = idMarcaNueva;
                        marcaAct.idMarca = idMarcaNueva;
                        marcaAct.nombre = (string)datos.Lector["Nombre"];
                        marcaAct.descripcion = (string)datos.Lector["Descripcion"];
                        marcaAct.paisOrigen = (string)datos.Lector["PaisOrigen"];
                        //opcional(?
                        marcaAct.estado = (bool)datos.Lector["Estado"];
                    }
                }

                if (idMarcaAct != -1) lista.Add(marcaAct);

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
               datos.cerrarConexion();
            }
        }
    }
}
