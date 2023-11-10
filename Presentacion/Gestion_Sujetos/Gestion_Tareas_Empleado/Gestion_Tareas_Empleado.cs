using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica.Procesamiento_Sujetos;
using System.Media ;
using System.Reflection ;
namespace Presentacion.Gestion_Sujetos
{
        public partial class Gestion_Tareas_Empleado : Form
        {
                int ID_Empleado;
                string Tarea { get { return TextBox_Texto_Tarea.Text; } set { TextBox_Texto_Tarea.Text = value; } }
                string? Tarea_Premodificacion;

                public Gestion_Tareas_Empleado(int ID_Empleado)
                {
                        this.ID_Empleado = ID_Empleado;
                        InitializeComponent();
                }

                # region >>---- Efectos de Sonido
                void Reproducir_Tono_Producto_Guardado()
                {
                        SoundPlayer Reproductor;

                        using Stream Tono_Producto_Guardado = Assembly.GetExecutingAssembly().GetManifestResourceStream("Presentacion.Gestion_Productos.Efectos_Sonido.Tono_Producto_Guardado.wav");
                        Reproductor = new SoundPlayer(Tono_Producto_Guardado);
                        try { Reproductor.Play(); }
                        catch { }
                }
                void Reproducir_Tono_Modificado()
                {
                        SoundPlayer Reproductor;
                        using Stream Tono_Producto_Modificado = Assembly.GetExecutingAssembly().GetManifestResourceStream("Presentacion.Gestion_Productos.Efectos_Sonido.Tono_Producto_Modificado.wav"); ;
                        Reproductor = new SoundPlayer(Tono_Producto_Modificado);
                        try { Reproductor.Play(); }
                        catch { }
                }
                void Reproducir_Tono_Producto_Eliminado()
                {
                        SoundPlayer Reproductor;
                        using Stream Tono_Producto_Eliminado = Assembly.GetExecutingAssembly().GetManifestResourceStream("Presentacion.Gestion_Productos.Efectos_Sonido.Tono_Producto_Borrado.wav");
                        Reproductor = new SoundPlayer(Tono_Producto_Eliminado);
                        try { Reproductor.Play(); }
                        catch { }
                }
                # endregion
                private void Button_Seleccionar_Tarea_Click(object sender, EventArgs e)
                {
                        Seleccionar_Tarea_Empleado Tarea_Empleado = new Seleccionar_Tarea_Empleado(ID_Empleado);
                        Tarea_Empleado.ShowDialog(owner: this);
                        if (Tarea_Empleado.Tarea_Seleccionada is null) { return; }
                        Tarea = (Tarea_Premodificacion = Tarea_Empleado.Tarea_Seleccionada);
                        Button_Eliminar.Enabled = (Button_Modificar.Enabled = true);
                }
                private void TextBox_Texto_Tarea_TextChanged(object sender, EventArgs e)
                { 
                        Button_Crear.Enabled = (!string.IsNullOrWhiteSpace(Tarea) ) ;
                        Button_Modificar.Enabled = ( Tarea_Premodificacion is not null && ! string.IsNullOrEmpty( Tarea ) ) ;
                }

                private void Button_Modificar_Click(object sender, EventArgs e)
                {
                        if (string.IsNullOrEmpty(Tarea)) { throw new InvalidOperationException(); }
                        if ( string.IsNullOrEmpty( Tarea_Premodificacion ) ) { throw new InvalidOperationException() ; }

                        Procesamiento_Sujetos.Modificar_Tarea_Empleado(Tarea_Premodificacion, Tarea, ID_Empleado);
                        Tarea_Premodificacion = Tarea ;
                        Reproducir_Tono_Modificado();
                }
                private void Button_Eliminar_Click(object sender, EventArgs e)
                {
                        if (Tarea_Premodificacion is null ) { throw new InvalidOperationException(); }

                        Procesamiento_Sujetos.Marshal_Delete_Tarea(ID_Empleado, Antigua_Tarea: Tarea_Premodificacion);
                        Tarea = "" ;
                        Tarea_Premodificacion = null ;
                        Button_Eliminar.Enabled = (Button_Modificar.Enabled = false);
                        Reproducir_Tono_Producto_Eliminado();
                }
                private void Button_Crear_Click(object sender, EventArgs e)
                {
                        Procesamiento_Sujetos.Marshal_Insert_Tarea_Empleado(ID_Empleado, Nueva_Tarea: Tarea);
                        Tarea_Premodificacion = Tarea;
                        Button_Eliminar.Enabled = (Button_Modificar.Enabled = true);
                        Reproducir_Tono_Producto_Guardado();
                }
        }
}
