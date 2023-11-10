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
namespace Presentacion.Gestion_Sujetos
{
        public partial class Seleccion_Sujeto_Capa : Form
        {
                public int? ID_Persona_Sujeto_Seleccionado = null;

                string Filtro_Busqueda { get { return DropDownList_Filtro_Busqueda.Text.Replace(' ', '_'); } set { DropDownList_Filtro_Busqueda.Text = value; } }
                string Argumento_Busqueda
                {
                        get
                        {
                                string Argumento = TextBox_Buscador.Text;
                                return
                                ((Autocompletar_Principio && Argumento != "") ? '%' : "") +
                                Argumento +
                                ((Autocompletar_Final && Argumento != "") ? '%' : "");
                        }
                        set { TextBox_Buscador.Text = value; }
                }

                bool Autocompletar_Principio { get { return CheckBox_Autocompletar_Principio.Checked; } set { CheckBox_Autocompletar_Principio.Checked = value; } }
                bool Autocompletar_Final { get { return CheckBox_Autocompletar_Final.Checked; } set { CheckBox_Autocompletar_Final.Checked = value; } }

                Caracterizacion_Formulario Tipo_Capa;
                string Columna_Null
                {
                        get
                        {
                                switch (Tipo_Capa)
                                {
                                        case Caracterizacion_Formulario.Personas: return "ID_Persona";
                                        case Caracterizacion_Formulario.Usuarios: return "Nombre_Identificador_Usuario";
                                        case Caracterizacion_Formulario.Empleados: return "ID_Empleado";
                                        case Caracterizacion_Formulario.Proveedores: return "ID_Proveedor";
                                        default: throw new Exception("Fallo de cohesion.");
                                }
                        }
                }
                string Nombre_Tipo_Capa
                {
                        get
                        {
                                switch (Tipo_Capa)
                                {
                                        case Caracterizacion_Formulario.Personas: return "Persona";
                                        case Caracterizacion_Formulario.Usuarios: return "Usuario";
                                        case Caracterizacion_Formulario.Empleados: return "Empleado";
                                        case Caracterizacion_Formulario.Proveedores: return "Proveedor";
                                        default: throw new Exception("Fallo de cohesion.");
                                }
                        }
                }

                public Seleccion_Sujeto_Capa(Caracterizacion_Formulario Caracterizacion_Actual)
                {
                        Tipo_Capa = Caracterizacion_Actual;
                        InitializeComponent();
                        DropDownList_Filtro_Busqueda.Text = "ID Persona";
                }
                private void Seleccionar_Tarea_Empleado_Load(object sender, EventArgs e) { Llenar_Grilla_Sujetos_Disponibles(); }
                void Llenar_Grilla_Sujetos_Disponibles()
                {
                        void Mostrar_MessageBox_No_Hay_Sujetos()
                        {
                                MessageBox.Show
                                (
                                        caption: "No hay Sujetos validos disponibles.",
                                        text: $"No se econtraron Sujetos sin un capa de de tipo `{Nombre_Tipo_Capa}` ya asignada.",
                                        icon: MessageBoxIcon.Error,
                                        buttons: MessageBoxButtons.OK,
                                        owner: this
                                );
                        }

                        DataTable? Sujetos_Validos = Procesamiento_Sujetos.Get_Resumen_Sujetos_Validos(Columna_Null, Filtro_Busqueda, Argumento_Busqueda);
                        if (Sujetos_Validos is null && Argumento_Busqueda != "") { Mostrar_MessageBox_No_Hay_Sujetos(); }
                        Grilla_Tareas.DataSource = Sujetos_Validos;
                        Grilla_Tareas.ClearSelection();
                }

                private void Button_Editar_Tarea_Click(object sender, EventArgs e)
                {
                        ID_Persona_Sujeto_Seleccionado = Convert.ToInt32(Grilla_Tareas.CurrentRow.Cells["ID_Persona"].Value);
                        Close();
                }

                private void TextBox_Buscador_KeyPress(object sender, KeyPressEventArgs e) { if (((Keys)e.KeyChar) == Keys.Enter) { Llenar_Grilla_Sujetos_Disponibles(); } }
                private void Grilla_Tareas_SelectionChanged(object sender, EventArgs e) { Button_Seleccionar_Sujeto.Enabled = (Grilla_Tareas.SelectedRows.Count == 1); }
                private void Grilla_Tareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { Button_Seleccionar_Sujeto.PerformClick(); }

                private void DropDownList_Filtro_Busqueda_SelectedIndexChanged(object sender, EventArgs e) { TextBox_Buscador.PlaceholderText = $"Buscar Sujeto por `{DropDownList_Filtro_Busqueda.Text}`"; }
        }
}
