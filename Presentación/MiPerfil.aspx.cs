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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && (Seguridad.Validar(Session["Logueado"])))
            {
                txtNombre.Text = ((Usuario)Session["Logueado"]).nombre;
                txtApellido.Text = ((Usuario)Session["Logueado"]).apellido;
                txtEmail.Text = ((Usuario)Session["Logueado"]).email;
                txtContra.Text = ((Usuario)Session["Logueado"]).pass;
                chkAdmin.Checked = ((Usuario)Session["Logueado"]).admin ? true : false;
                imgImagen.ImageUrl = ((Usuario)Session["Logueado"]).urlImagenPerfil;
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Seguridad.Validar(Session["Logueado"]))
                {
                    UsuarioDatos datos = new UsuarioDatos();
                    Usuario usuario = (Usuario)Session["Logueado"];
                    usuario.nombre = txtNombre.Text;
                    usuario.apellido = txtApellido.Text;
                    usuario.email = txtEmail.Text;
                    usuario.pass = txtContra.Text;
                    usuario.admin = chkAdmin.Checked ? true : false;

                    if (txtImagen.PostedFile.FileName != "")
                    {
                        string ruta = Server.MapPath("./Images/");
                        txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + usuario.Id + ".jpg");
                        usuario.urlImagenPerfil = "Perfil-" + usuario.Id + ".jpg";
                    }
                    ((Image)Master.FindControl("imgAvatar")).ImageUrl = "~/Images/" + usuario.urlImagenPerfil;

                    datos.actualizar(usuario);
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