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
    public partial class PaginaMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
            if (!(Page is Home || Page is Perfil || Page is Error))
            {
                if (!(Seguridad.Validar(Session["Logueado"])))
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            else if(Seguridad.Validar(Session["Logueado"]))
            {
                if (string.IsNullOrEmpty(((Usuario)Session["Logueado"]).urlImagenPerfil))
                    imgAvatar.ImageUrl = "~/Images/Perfil-" + ((Usuario)Session["Logueado"]).Id;
                ddlUsuario.InnerText = ((Usuario)Session["Logueado"]).nombre;                
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDatos datos = new UsuarioDatos();
                Usuario usuario = new Usuario();
                usuario.nombre = txtNombreNuevo.Text;
                usuario.email = txtCorreoNuevo.Text;
                usuario.pass = txtContraNueva.Text;
                usuario.Id = datos.registrar(usuario);
                Session.Add("Logueado", usuario);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.apsx", false);
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDatos datos = new UsuarioDatos();
                Usuario usuario = new Usuario();
                usuario.email = txtCorreo.Text;
                usuario.pass = txtContraseña.Text;
                datos.loguear(usuario);
                Session.Add("Logueado", usuario);
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}