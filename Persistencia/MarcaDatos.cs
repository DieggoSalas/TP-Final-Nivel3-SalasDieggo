using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Datos
{
    public class MarcaDatos
    {
        List<Marca> lista = new List<Marca>();
        AccesoDatos datos = new AccesoDatos();
        public List<Marca> listar()
        {
            try
            {
                datos.Consultar("select Id, Descripcion from MARCAS");
                datos.LeerDatos();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void agregar(Marca nuevo)
        {
            try
            {
                datos.Consultar("insert into MARCAS (Descripcion) values (@Descripcion)");
                datos.SetearParametros("@Descripcion", nuevo.Descripcion);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            try
            {
                datos.Consultar("delete from MARCAS where Id = @Id");
                datos.SetearParametros("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
