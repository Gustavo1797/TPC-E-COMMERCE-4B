using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        List<Categoria> Listar() 
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            Categoria categoriaAct = null;
            int idCategoriaAct = -1, idNuevaCategoria = -1;

            try
            {
                datos.setearConsulta("select IdCategoria, Descripcion, Estado from Categoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    idNuevaCategoria = datos.Lector.GetInt32(0);
                    if (idCategoriaAct != idNuevaCategoria) 
                    {
                        if (idCategoriaAct != -1) lista.Add(categoriaAct);
                        categoriaAct = new Categoria();
                        idCategoriaAct = idNuevaCategoria;
                        categoriaAct.IdCatergoria = idNuevaCategoria;
                        categoriaAct.Descripcion = (string)datos.Lector["Descripcion"];
                        categoriaAct.Estado = (bool)datos.Lector["Estado"];
                    }
                }

                if (idCategoriaAct != -1) lista.Add(categoriaAct);

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
