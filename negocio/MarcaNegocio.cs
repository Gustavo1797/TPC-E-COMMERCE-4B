using System;
using System.Collections.Generic;
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

            try
            {
                datos.setearConsulta("select IdMarca, Nombre, Descripcion, Estado from Marca order by Estado desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    marcaAct = new Marca();
                    marcaAct.IdMarca = datos.Lector.GetInt32(0);
                    marcaAct.Nombre = (string)datos.Lector["Nombre"];
                    marcaAct.Descripcion = (string)datos.Lector["Descripcion"];
                    marcaAct.Estado = (bool)datos.Lector["Estado"];
                    lista.Add(marcaAct);
                }

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

        public bool Agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "insert into Marca (Nombre, Descripcion, Estado) values (@Nombre, @descripcion, @estado); SELECT SCOPE_IDENTITY();";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@estado", nuevo.Estado);

                if (datos.ejecutarReturn() > 0)
                    return true;
                else
                    return false;
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

        public void Modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update Marca set Nombre = @nombre, Descripcion = @descripcion, Estado = @estado where IdMarca = @IdMarca";
                datos.setearConsulta(consulta);

                datos.setearParametro("@IdMarca", marca.IdMarca);
                datos.setearParametro("@nombre", marca.Nombre);
                datos.setearParametro("@descripcion", marca.Descripcion);
                datos.setearParametro("@estado", marca.Estado);

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

        public Marca GetMarca(int IdMarca)
        {
            Marca marca = new Marca();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select IdMarca, Nombre, Descripcion, Estado from Marca where IdMarca = @Id order by Estado desc";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Id", IdMarca);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    marca.IdMarca = (int)datos.Lector["IdMarca"];
                    marca.Nombre = (string)datos.Lector["Nombre"];
                    marca.Descripcion = (string)datos.Lector["Descripcion"];
                    marca.Estado = (bool)datos.Lector["Estado"];
                }

                return marca;
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

        public void Eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from Marca where IdMarca = @idMarca");
                datos.setearParametro("@idMarca", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
