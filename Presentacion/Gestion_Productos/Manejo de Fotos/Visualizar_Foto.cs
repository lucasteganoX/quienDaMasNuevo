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
                void MessageBox_Foto_A_Mostrar_Invalida()
                {
                        MessageBox.Show
                        (
                                caption: "La foto a mostrar es invalida.",
                                text: "Por algún motivo, esta foto no es valida y no puede mostrarse.\nDe ser posible, contactese con El Bueno el Malo y Stephano sobre este dilema.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        ) ;
                }

                Bitmap Bytes_A_Bitmap( byte[] Foto_En_Bytes )
                { 
                        Bitmap? Imagen ;
                        using MemoryStream Stream = new MemoryStream( Foto_En_Bytes ) ;
                        Imagen = new Bitmap( Stream ) ;
                        return Imagen ;
                }

                public Visualizar_Foto( byte[] Foto_En_Bytes )
                {
                        InitializeComponent() ;
                        PictureBox_Foto.SizeMode = PictureBoxSizeMode.Zoom ;
                        try { Bitmap Foto_A_Mostrar = Bytes_A_Bitmap( Foto_En_Bytes ) ; }
                        catch { MessageBox_Foto_A_Mostrar_Invalida() ; return ; }

                        PictureBox_Foto.Image = Bytes_A_Bitmap( Foto_En_Bytes ) ;
                }
        }
}
