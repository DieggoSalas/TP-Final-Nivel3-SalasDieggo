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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDatos datos = new UsuarioDatos();
                Usuario usuario = new Usuario();
                usuario.email = txtCorreo.Text;
                usuario.pass = txtContra.Text;
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
    }
}