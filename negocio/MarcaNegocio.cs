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
        void Agregar(Marca nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Marca (IdMarca, Nombre, Descripcion, PaisOrigen, Estado) values (@idMarca, @nombre, @descripcion, @paisOrigen, @estado)");
                datos.setearParametro("@idMarca", nuevo.idMarca);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@descripcion", nuevo.descripcion);
                datos.setearParametro("@estado", nuevo.estado);

                datos.ejecutarAccion();
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
        void Modificar(Marca marca) 
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("update Marca set IdMarca = @idMarca, Nombre = @nombre, Descripcion = @descripcion, PaisOrigen = @paisOrigen, Estado = @estado");

            datos.setearParametro("@idMarca", marca.idMarca);
            datos.setearParametro("@nombre", marca.nombre);
            datos.setearParametro("@descripcion", marca.descripcion);
            datos.setearParametro("@estado", marca.estado);

            datos.ejecutarAccion();
        }

        public void Eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(" delete from Marca where idMarca = @idMarca ");
                datos.setearParametro("@idMarca ", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}