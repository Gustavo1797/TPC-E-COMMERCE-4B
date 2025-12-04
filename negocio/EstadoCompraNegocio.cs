using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class EstadoCompraNegocio
    {
        public List<EstadoCompra> Listar()
        {            
            List<EstadoCompra> list = new List<EstadoCompra>();
            AccesoDatos datos = new AccesoDatos();
            EstadoCompra estado = null;

            try
            {
                string consulta = "select IdEstadoCompra, Nombre, Descripcion from EstadoCompra ";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    estado = new EstadoCompra();
                    estado.IdEstadoCompra = (int)datos.Lector["IdEstadoCompra"];
                    estado.Nombre = (string)datos.Lector["Nombre"];
                    estado.Descripcion = (string)datos.Lector["Descripcion"];
                    list.Add(estado);
                }

                return list;
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

        public EstadoCompra ObtenerEstadoCompra(int IdEstadoCompra)
        {            
            AccesoDatos datos = new AccesoDatos();
            EstadoCompra estado = null;

            try
            {
                estado.IdEstadoCompra = 0;
                string consulta = "select Nombre, Descripcion from EstadoCompra where IdEstadoCompra = @IdEstadoCompra ";
                datos.setearConsulta(consulta);
                datos.setearParametro("@IdEstadoCompra", IdEstadoCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    estado.IdEstadoCompra = (int)datos.Lector["IdEstadoCompra"];
                    estado.Nombre = (string)datos.Lector["Nombre"];
                    estado.Descripcion = (string)datos.Lector["Descripcion"];                    
                }

                return estado;
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
