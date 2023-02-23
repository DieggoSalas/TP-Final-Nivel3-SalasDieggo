using Clases;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentación
{
    public partial class Perfil : System.Web.UI.Page
    {
        UsuarioDatos datos = new UsuarioDatos();
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.Validar(Session["Logueado"]))
            {
                usuario = (Usuario)Session["Logueado"];
                txtNombre.Text = usuario.nombre;
                txtApellido.Text = usuario.apellido;
                txtCorreo.Text = usuario.email;
                txtContra.Text = usuario.pass;
                imgImagen.ImageUrl = usuario.urlImagenPerfil;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario.email = txtCorreo.Text;
                usuario.pass = txtContra.Text;
                usuario.nombre = txtNombre.Text;
                usuario.apellido = txtApellido.Text;
                string ruta = Server.MapPath("./Images/");
                txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + usuario.Id + ".jpg");
                usuario.urlImagenPerfil = "Perfil-" + usuario.Id + ".jpg";
                if (Seguridad.Validar(Session["Logueado"]))
                {
                    datos.actualizar(usuario);
                    Session.Add("Logueado", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    usuario.Id = datos.registrar(usuario);
                    Session.Add("Logueado", usuario);
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.apsx", false);
            }
        }
    }
}