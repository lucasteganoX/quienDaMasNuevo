# define DEBUG_Ver_Fotos
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Gestion_Productos.Manejo_de_Fotos;

namespace Presentacion.Gestion_Productos
{
        public partial class Gestion_Productos_Ver_Fotos : Form
        {
                public Gestion_Productos_Ver_Fotos( byte[][] Fotos_Producto_Seleccionado )
                {
                        if ( Fotos_Producto_Seleccionado is null) { throw new Exception("Se trato de lanzar el formulario Ver Fotos sin que el Producto en Edicion tenga fotos cargadas en el."); }
                        InitializeComponent();

                        Fotos_Producto = Fotos_Producto_Seleccionado ;
                        Popular_Seleccion_Fotos_DropDownList();
                }

                private byte[][] Fotos_Producto { get; init; }
                private Form? Formulario_Visualizar_Foto;

                // private Process Proceso_Mostrar_Foto ;
                /*
                string Crear_Foto_Temporal_Producto(byte[] Imagen_En_Bytes)
                {
                        Bitmap Bitmap_Imagen;
                        string Ruta_Carpeta_Temp_Windows;
                        const string Nombre_Imagen_Temporal = "Quién_Da_Más-Foto_Producto.jpeg";
                        string Ruta_Foto_Producto;

                        Ruta_Carpeta_Temp_Windows = Path.GetTempPath();
                        Ruta_Foto_Producto = Path.Combine( Ruta_Carpeta_Temp_Windows, Nombre_Imagen_Temporal ) ;
                        using MemoryStream Stream_Imagen = new MemoryStream(Imagen_En_Bytes);

                        Bitmap_Imagen = new Bitmap(Stream_Imagen);
                        Bitmap_Imagen.Save(Ruta_Foto_Producto, System.Drawing.Imaging.ImageFormat.Jpeg);

                        return Ruta_Foto_Producto ;
                }
                */

                /*
                        void Mostrar_Foto( string Ruta_Foto )
                        {
                                if ( ! File.Exists( Ruta_Foto ) ) { throw new Exception($"La Foto a mostrar `{ Ruta_Foto }` no existe."); }
                                Proceso_Mostrar_Foto = new Process() ;
                                Proceso_Mostrar_Foto.StartInfo.WorkingDirectory = Path.GetTempPath() ;
                                Proceso_Mostrar_Foto.StartInfo.FileName = "explorer.exe" ;
                                Proceso_Mostrar_Foto.StartInfo.Arguments = Ruta_Foto ;

                                Proceso_Mostrar_Foto.Start() ;       
                        }
                */

                private void Popular_Seleccion_Fotos_DropDownList()
                {
                        for (int Indice_Foto = 0; Indice_Foto < Fotos_Producto.Length; Indice_Foto++)
                        {
                                string Item_Seleccion;
                                const string Prefijo_Item = "Imagen ";

                                Item_Seleccion = Prefijo_Item + (Indice_Foto + 1).ToString();
                                DropDown_Foto_Numero.Items.Add(Item_Seleccion);
                        }
                }

                int Get_Indice_Foto_Seleccionada() { return DropDown_Foto_Numero.SelectedIndex; }
                private void Button_Ver_Foto_Click(object sender, EventArgs e)
                {
                        if ( DropDown_Foto_Numero.SelectedIndex == -1 ) { throw new Exception("Se presiono el boton `Ver` cuando no habia ninguna foto seleccionada.") ; }
                        Formulario_Visualizar_Foto = new Visualizar_Foto(Fotos_Producto[Get_Indice_Foto_Seleccionada()]);
                        Formulario_Visualizar_Foto.ShowDialog(owner: this);
                }

                private void DropDown_Foto_Numero_SelectedIndexChanged(object sender, EventArgs e)
                {
                        if ( DropDown_Foto_Numero.SelectedIndex == -1 ) { Button_Ver_Foto.Enabled = false ; }
                        else { Button_Ver_Foto.Enabled = true ; }
                }
        }
}
