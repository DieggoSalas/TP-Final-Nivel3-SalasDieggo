using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Datos
{
    public class ArticuloDatos
    {
        private AccesoDatos datos = new AccesoDatos();
        private List<Articulo> lista = new List<Articulo>();
        private Articulo articulo;
        private bool Todo = false;
        private bool opc = false;
        public List<Articulo> Listar()
        {
            try
            {
                datos.ConsultarSP("TraerArticulos");
                datos.LeerDatos();
                Todo = true;
                RecorrerConsulta();

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

        public List<Articulo> TraerArticulo(string Id)
        {
            try
            {
                datos.ConsultarSP("TraerArticulo");
                datos.SetearParametros("@Id", Id);
                datos.LeerDatos();
                opc = true;
                RecorrerConsulta();

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
        public Articulo TraerArtDetalles(string Id)
        {
            try
            {
                datos.ConsultarSP("TraerArtDetalles");
                datos.SetearParametros("@Id", Id);
                datos.LeerDatos();
                RecorrerConsulta();

                return articulo;
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

        public void Agregar(Articulo nuevo)
        {
            try
            {
                datos.ConsultarSP("NuevoArticulo");
                datos.SetearParametros("@Nombre", nuevo.Nombre);
                datos.SetearParametros("@Descripcion", nuevo.Descripcion);
                datos.SetearParametros("@ImagenUrl", nuevo.ImagenUrl);
                datos.SetearParametros("@Precio", nuevo.Precio);
                datos.SetearParametros("@Codigo", nuevo.Codigo);
                datos.SetearParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.SetearParametros("@IdMarca", nuevo.Marca.Id);
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

        public void Modificar(Articulo modificado)
        {
            try
            {
                datos.ConsultarSP("ModificarArticulo");
                datos.SetearParametros("@Nombre", modificado.Nombre);
                datos.SetearParametros("@Descripcion", modificado.Descripcion);
                datos.SetearParametros("@ImagenUrl", modificado.ImagenUrl);
                datos.SetearParametros("@Precio", modificado.Precio);
                datos.SetearParametros("@Codigo", modificado.Codigo);
                datos.SetearParametros("@IdCategoria", modificado.Categoria.Id);
                datos.SetearParametros("@IdMarca", modificado.Marca.Id);
                datos.SetearParametros("@Id", modificado.Id);
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

        public void Eliminar(int id)
        {
            try
            {
                datos.ConsultarSP("EliminarArticulo");
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

        public List<Articulo> Filtrar(string campo, string criterio, string filtro)
        {
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id IdMarca, M.Descripcion Marca, C.Id IdCategoria, C.Descripcion Categoria, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdCategoria = C.Id and A.IdMarca = M.Id and ";
                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con...":
                                consulta += "Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con...":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a...":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a...":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Comienza con...":
                                consulta += "Codigo like '" + filtro + "%' ";
                                break;
                            case "Termina con...":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                datos.Consultar(consulta);
                datos.LeerDatos();
                Todo = true;
                RecorrerConsulta();

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

        private void RecorrerConsulta()
        {
            while (datos.Lector.Read())
            {
                Articulo aux = new Articulo();
                aux.Id = (int)datos.Lector["Id"];
                aux.Codigo = (string)datos.Lector["Codigo"];
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Descripcion = (string)datos.Lector["Descripcion"];
                aux.Marca = new Marca();
                aux.Categoria = new Categoria();
                if (Todo)
                {
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                }
                else
                {
                    if (opc)
                    {
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                }
                if (!(datos.Lector["ImagenUrl"] is DBNull))
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                aux.Precio = datos.Lector.GetDecimal(Todo ? 9 : 7);
                if (Todo || opc)
                    lista.Add(aux);
                else
                    articulo = aux;
            }
        }
    }
}