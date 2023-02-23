using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public static class ImagenDatos
    {        
        public static void cargarImagen(PictureBox imagen, string url)
        {
            try
            {                
                imagen.Load(url);
            }
            catch (Exception)
            {
                imagen.Load("https://coffeesearch.guatemalancoffees.com//uploads/coverPhoto.png");
            }
        }
    }
}
