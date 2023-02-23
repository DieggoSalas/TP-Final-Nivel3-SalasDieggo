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
        public List<Articulo> Lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            Lista = datos.Listar();
        }
    }
}