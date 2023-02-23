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
            if (!(Page is Home || Page is Login || Page is Perfil || Page is Error))
            {
                if (!(Seguridad.Validar(Session["Logueado"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            if (Seguridad.Validar(Session["Logueado"]))
            {
                imgAvatar.ImageUrl = "~/Images/Perfil-" + ((Usuario)Session["Logueado"]).Id;
                ddlUsuario.InnerText = ((Usuario)Session["Logueado"]).nombre;
            }
            else
                imgAvatar.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}