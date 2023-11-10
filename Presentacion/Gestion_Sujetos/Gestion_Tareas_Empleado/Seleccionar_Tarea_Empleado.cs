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
        public partial class Seleccionar_Tarea_Empleado : Form
        {
                int ID_Empleado;
                public string? Tarea_Seleccionada = null;

                string Filtro_Busqueda { get { return DropDownList_Filtro_Busqueda.Text; } set { DropDownList_Filtro_Busqueda.Text = value; } }
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

                public Seleccionar_Tarea_Empleado(int ID_Empleado)
                {
                        this.ID_Empleado = ID_Empleado;
                        InitializeComponent();
                        DropDownList_Filtro_Busqueda.Text = "Tarea";
                }
                private void Seleccionar_Tarea_Empleado_Load(object sender, EventArgs e) { Llenar_Grilla_Tareas(); }
                void Llenar_Grilla_Tareas()
                {
                        void Mostrar_MessageBox_No_Hay_Tareas()
                        {
                                MessageBox.Show
                                (
                                        caption: "No hay tareas para el Empleado.",
                                        text: $"No se econtraron tareas para el Empleado con la ID `{ID_Empleado}`.",
                                        icon: MessageBoxIcon.Error,
                                        buttons: MessageBoxButtons.OK,
                                        owner: this
                                );
                        }

                        DataTable? Tareas = Procesamiento_Sujetos.Marshal_Get_Tareas_Empleado(ID_Empleado, Filtro_Busqueda, Argumento_Busqueda);
                        if (Tareas is null && Argumento_Busqueda != "") { Mostrar_MessageBox_No_Hay_Tareas(); }
                        Grilla_Tareas.DataSource = Tareas;
                        Grilla_Tareas.ClearSelection();
                }

                private void Button_Editar_Tarea_Click(object sender, EventArgs e)
                {
                        Tarea_Seleccionada = Grilla_Tareas.CurrentRow.Cells["Tarea"].Value.ToString();
                        Close();
                }

                private void TextBox_Buscador_KeyPress(object sender, KeyPressEventArgs e) { if (((Keys)e.KeyChar) == Keys.Enter) { Llenar_Grilla_Tareas(); } }
                private void Grilla_Tareas_SelectionChanged(object sender, EventArgs e) { Button_Editar_Tarea.Enabled = (Grilla_Tareas.SelectedRows.Count == 1); }
                private void Grilla_Tareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { Button_Editar_Tarea.PerformClick(); }
        }
}
