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
    public partial class Home : System.Web.UI.Page
    {
        //public List<Articulo> Lista { get; set; }
        public Articulo ArtDetalle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloDatos datos = new ArticuloDatos();
                //Lista = datos.Listar();
                RepArticulos.DataSource = datos.Listar();
                RepArticulos.DataBind();
            }
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            ArtDetalle = datos.TraerArtDetalles(((Button)sender).CommandArgument);

            lblNombre.Text = ArtDetalle.Nombre;
            imgUrl.ImageUrl = ArtDetalle.ImagenUrl;
            lblDescripcion.Text = ArtDetalle.Descripcion;
            lblMarca.Text = ArtDetalle.Marca.Descripcion;
            lblCategoria.Text = ArtDetalle.Categoria.Descripcion;
            lblPrecio.Text = ArtDetalle.Precio.ToString();

        }
    }
}