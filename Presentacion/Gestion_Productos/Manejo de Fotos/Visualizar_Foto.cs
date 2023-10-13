using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Gestion_Productos.Manejo_de_Fotos
{
        public partial class Visualizar_Foto : Form
        {
                Bitmap Bytes_A_Bitmap( byte[] Foto_En_Bytes )
                { 
                        Bitmap Imagen ;

                        using MemoryStream Stream = new MemoryStream( Foto_En_Bytes ) ;
                        Imagen = new Bitmap( Stream ) ;
                        
                        return Imagen ;
                }

                public Visualizar_Foto( byte[] Foto_En_Bytes )
                {
                        InitializeComponent() ;
                        PictureBox_Foto.SizeMode = PictureBoxSizeMode.Zoom ;
                        PictureBox_Foto.Image = Bytes_A_Bitmap( Foto_En_Bytes ) ;
                }
        }
}
