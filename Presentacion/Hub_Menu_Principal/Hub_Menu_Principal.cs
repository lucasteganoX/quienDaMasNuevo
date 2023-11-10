using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica.Sistema_de_Usuarios;
namespace Presentacion.Hub_Menu_Principal
{
        public partial class Hub_Menu_Principal : Form
        {
                public Clase_Sujeto Sujeto_Operando;

                string Opcion_Administracion
                {
                        get { return DropDownList_Administracion.Text; }
                        set { DropDownList_Administracion.Text = value; }
                }

                string Opcion_Envolverse
                {
                        get { return DropDownList_Envolverse.Text; }
                        set { DropDownList_Envolverse.Text = value; }
                }

                public Hub_Menu_Principal(Clase_Sujeto Sujeto_Logeado)
                {
                        Sujeto_Operando = Sujeto_Logeado;
                        InitializeComponent();
                        DropDownList_Administracion.Text = "Administración";
                }

                private void DropDownList_Administracion_SelectedIndexChanged(object sender, EventArgs e)
                {
                        { // Esconder placeholder
                                Panel_Placeholder_Administracion.Visible = false;
                                Texto_Placeholder_Administracion.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(Opcion_Envolverse))
                        { // Resetear menu Envolverse
                                DropDownList_Envolverse.SelectedIndexChanged -= DropDownList_Envolverse_SelectedIndexChanged;
                                DropDownList_Envolverse.SelectedIndex = -1;
                                DropDownList_Envolverse.SelectedIndexChanged += DropDownList_Envolverse_SelectedIndexChanged;
                                Panel_Placeholder_Envolverse.Visible = true;
                                Texto_Placeholder_Envolverse3.Visible = true;
                        }
                        Continuar_Flujo_Ejecucion();
                }

                private void DropDownList_Envolverse_SelectedIndexChanged(object sender, EventArgs e)
                {
                        { // Esconder placeholder
                                Panel_Placeholder_Envolverse.Visible = false;
                                Texto_Placeholder_Envolverse3.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(Opcion_Administracion))
                        { // Resetea el menu de Administracion
                                DropDownList_Administracion.SelectedIndexChanged -= DropDownList_Administracion_SelectedIndexChanged;
                                DropDownList_Administracion.SelectedIndex = -1;
                                DropDownList_Administracion.SelectedIndexChanged += DropDownList_Administracion_SelectedIndexChanged;
                                Panel_Placeholder_Administracion.Visible = true;
                                Texto_Placeholder_Administracion.Visible = true;
                        }
                        Continuar_Flujo_Ejecucion();
                }

                // Placeholder Administracion
                private void Panel_Placeholder_Administracion_Click(object sender, EventArgs e) { Desplegar_Menu_Administracion(); }
                private void Texto_Placeholder_Administracion_Click(object sender, EventArgs e) { Desplegar_Menu_Administracion(); }
                void Desplegar_Menu_Administracion() { DropDownList_Administracion.DroppedDown = !DropDownList_Administracion.DroppedDown; }

                // Placeholder Envolverse
                private void Panel_Placeholder_Envolverse_Click_1(object sender, EventArgs e) { Desplegar_Menu_Envolverse(); }
                private void Texto_Placeholder_Envolverse3_Click(object sender, EventArgs e) { Desplegar_Menu_Envolverse(); }
                void Desplegar_Menu_Envolverse() { DropDownList_Envolverse.DroppedDown = !DropDownList_Envolverse.DroppedDown; }

                // Denegacion de accesso
                void Mostrar_Mensaje_Permiso_Denegado(string Opcion_Seleccionada)
                {
                        MessageBox.Show
                        (
                                caption: "Se deniega el acceso.",
                                text: $"Usted no tiene permiso para acceder al apartado `{Opcion_Seleccionada}`.\nSe denegó el acceso.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }

                bool Usuario_Tiene_Permiso_Gestion_Comercial()
                {
                        int Permiso_Gestion_Comercial = ((int)char.GetNumericValue(Sujeto_Operando.Usuario.Nivel_Confidencialidad[1]));
                        bool El_Usuario_Tiene_Permiso = Convert.ToBoolean(Permiso_Gestion_Comercial);
                        return El_Usuario_Tiene_Permiso;
                }
                bool Usuario_Tiene_Permiso_Gestion_Sujetos()
                {
                        int Permiso_Gestion_Sujetos = ((int)char.GetNumericValue(Sujeto_Operando.Usuario.Nivel_Confidencialidad[0]));
                        bool El_Usuario_Tiene_Permiso = Convert.ToBoolean(Permiso_Gestion_Sujetos);
                        return El_Usuario_Tiene_Permiso;
                }
                bool Usuario_Tiene_Permiso_Pagar()
                {
                        int Permiso_Pago = ((int)char.GetNumericValue(Sujeto_Operando.Usuario.Nivel_Confidencialidad[2]));
                        bool El_Usuario_Tiene_Permiso = Convert.ToBoolean(Permiso_Pago);
                        return El_Usuario_Tiene_Permiso;
                }
                bool Usuario_Tiene_Permiso_Publicar_Lotes()
                {
                        int Permiso_Publicar_Lotes = ((int)char.GetNumericValue(Sujeto_Operando.Usuario.Nivel_Confidencialidad[3]));
                        bool El_Usuario_Tiene_Permiso = Convert.ToBoolean(Permiso_Publicar_Lotes);
                        return El_Usuario_Tiene_Permiso;
                }
                bool Usuario_No_Tiene_Proveedor() { return Sujeto_Operando.ID_Proveedor is null ; }

                void Mostrar_MessageBox_No_Es_Proveedor()
                { 
                        MessageBox.Show
                        (
                               caption: "Tienes permiso para publicar Lotes y Productos, pero no eres un Proveedor.",
                               text: "Tienes el permiso para publicar Lotes y Productos aún así no se te permite hacerlo pues no tienes información de Proveedor.\n" +
                               "Contactate con El Bueno, El Malo y Stephano para reportar este problema si es posible.",
                               icon: MessageBoxIcon.Error,
                               buttons: MessageBoxButtons.OK,
                               owner: this
                        ) ;        
                }
                void Continuar_Flujo_Ejecucion()
                {
                        if (!(string.IsNullOrEmpty(Opcion_Administracion) ^ string.IsNullOrEmpty(Opcion_Envolverse))) { throw new InvalidOperationException("Hay dos opciones seleccionadas. No se puede continuar el flujo del programa."); }

                        string Opcion_Seleccionada = ((!string.IsNullOrEmpty(Opcion_Administracion)) ? Opcion_Administracion : Opcion_Envolverse);
                        switch (Opcion_Seleccionada)
                        {
                                case "Gestión de Productos":
                                        if (!Usuario_Tiene_Permiso_Gestion_Comercial()) { Mostrar_Mensaje_Permiso_Denegado(Opcion_Seleccionada); return; }
                                        Visible = false;
                                        (new Gestion_Productos.Gestion_Productos()).ShowDialog(owner: this);
                                        Visible = true;
                                        break;
                                case "Gestión de Lotes":
                                        if (!Usuario_Tiene_Permiso_Gestion_Comercial()) { Mostrar_Mensaje_Permiso_Denegado(Opcion_Seleccionada); return; }
                                        Visible = false;
                                        (new Gestion_Lotes.Gestion_Lotes()).ShowDialog(owner: this);
                                        Visible = true;
                                        break;
                                case "Gestión de Remates":
                                        if (!Usuario_Tiene_Permiso_Gestion_Comercial()) { Mostrar_Mensaje_Permiso_Denegado(Opcion_Seleccionada); return; }
                                        Visible = false;
                                        (new Gestion_Remates.Gestion_Remates()).ShowDialog(owner: this);
                                        Visible = true;
                                        break;
                                case "Gestión de Sujetos":
                                        if ( ! Usuario_Tiene_Permiso_Gestion_Sujetos()) { Mostrar_Mensaje_Permiso_Denegado(Opcion_Seleccionada); return; }
                                        Hide() ;
                                        ( new Gestion_Sujetos.Gestion_Sujetos() ).ShowDialog() ;
                                        Show() ;
                                        break;
                                case "Ir a remates":
                                        // ...
                                        break;
                                case "Ir a historial de remates":
                                        // ...
                                        break;
                                case "Publicar producto":
                                        //if (!Usuario_Tiene_Permiso_Publicar_Lotes()) { Mostrar_Mensaje_Permiso_Denegado(Opcion_Seleccionada); return; }
                                        //if ( Usuario_No_Tiene_Proveedor() ) { Mostrar_MessageBox_No_Es_Proveedor() ; return ; }
                                        //Hide() ;
                                        //( new Gestion_Productos.Gestion_Productos( Sujeto_Operando.ID_Proveedor ) ).ShowDialog() ;
                                        //Show() ;
                                        //break;
                                case "Publicar lote":
                                        if (!Usuario_Tiene_Permiso_Publicar_Lotes()) { Mostrar_Mensaje_Permiso_Denegado(Opcion_Seleccionada); return; }
                                        // ...
                                        break;
                        }
                }
        }
}
