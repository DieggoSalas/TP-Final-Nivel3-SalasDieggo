using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDatos
    {
        private AccesoDatos datos = new AccesoDatos();
        public int registrar(Usuario nuevo)
        {
            try
            {
                datos.ConsultarSP("NuevoUsuario");
                datos.SetearParametros("@email", nuevo.email);
                datos.SetearParametros("@pass", nuevo.pass);
                datos.SetearParametros("@nombre", nuevo.nombre);
                datos.SetearParametros("@apellido", nuevo.apellido);
                datos.SetearParametros("@img", nuevo.urlImagenPerfil);
                return datos.EjecutarScaler();
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
        public bool loguear(Usuario usuario)
        {
            try
            {
                datos.ConsultarSP("LoguearUsuario");
                datos.SetearParametros("@email", usuario.email);
                datos.SetearParametros("@pass", usuario.pass);
                datos.LeerDatos();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.email = (string)datos.Lector["email"];
                    usuario.pass = (string)datos.Lector["pass"];
                    usuario.nombre = (string)datos.Lector["nombre"];
                    usuario.apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlimagenPerfil"] is DBNull))
                        usuario.urlImagenPerfil = (string)datos.Lector["urlimagenPerfil"];
                    usuario.admin = (bool)datos.Lector["admin"];
                    return true;
                }
                return false;
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
        public void actualizar(Usuario usuario)
        {
            try
            {
                datos.ConsultarSP("ModificarUsuario");
                datos.SetearParametros("@id", usuario.Id);
                datos.SetearParametros("@email", usuario.email);
                datos.SetearParametros("@pass", usuario.pass);
                datos.SetearParametros("@nombre", usuario.nombre);
                datos.SetearParametros("@apellido", usuario.apellido);
                datos.SetearParametros("@img", usuario.urlImagenPerfil);
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
