using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Gestion_Productos.Tipado_Productos
{
        public partial class Gestion_Productos_Tipado_Maquinaria : Form
        {
                public Gestion_Productos_Tipado_Maquinaria()
                {
                        InitializeComponent();
                }

                public bool Esta_Vacio
                {
                        get
                        {
                                if (NumericUpDown_Ano_Adquisicion.Value == 2000)
                                {
                                        if (DropDownList_Tipo_Maquina.SelectedItem is null) { return true; }
                                        if (TextBox_Marca.Text is null) { return true; }
                                        if (TextBox_Numero_Serial is null) { return true; }
                                        if (DropDownList_Historial_Propiedad is null) { return true; }
                                }
                                return false;

                        }
                }

                public void Limpiar_Formulario()
                {
                        SuspendLayout();
                        DropDownList_Tipo_Maquina.SelectedItem = null;
                        TextBox_Marca.Text = null;
                        TextBox_Numero_Serial.Text = null;
                        DropDownList_Historial_Propiedad.SelectedItem = null;
                        CheckBox_Nueva.Checked = false;
                        NumericUpDown_Ano_Adquisicion.Value = 2000;
                        ResumeLayout(false);

                }

                private void Gestion_Productos_Tipado_Maquinaria_FormClosing(object sender, FormClosingEventArgs e)
                {
                        string? Get_Campos_Invalidos_Tipado_Maquinaria()
                        {
                                bool Formulario_Esta_Incompleto;
                                string Mensaje_Campos_Invalidos;
                                StringBuilder Campos_Invalidos;

                                Formulario_Esta_Incompleto = false;
                                Campos_Invalidos = new StringBuilder();

                                if (DropDownList_Tipo_Maquina.SelectedItem is null) { Formulario_Esta_Incompleto = true; Campos_Invalidos.AppendLine(" > No se selecciono un tipo de maquina."); }
                                if (string.IsNullOrEmpty(TextBox_Marca.Text)) { Formulario_Esta_Incompleto = true; Campos_Invalidos.AppendLine(" > No se especifico la Marca de la maquina."); }
                                if (string.IsNullOrEmpty(TextBox_Numero_Serial.Text)) { Formulario_Esta_Incompleto = true; Campos_Invalidos.AppendLine(" > No se indico un Numero Serial para la maquina. Si no lo tiene, considere contactar con la empresa de la maquina."); }
                                if (DropDownList_Historial_Propiedad.SelectedItem is null) { Formulario_Esta_Incompleto = true; Campos_Invalidos.AppendLine(" > No se indico el procedencia(Historial de Propiedad) de la maquina."); }
                                if (NumericUpDown_Ano_Adquisicion.Value < 1800) { Formulario_Esta_Incompleto = true; Campos_Invalidos.AppendLine(" > La gente vive no mas ed 150 años, y las personas andaban en carretas en el 1800, cambia la fecha o considera verder la maquina en un remate de arte."); }
                                if (NumericUpDown_Ano_Adquisicion.Value > 3000) { Formulario_Esta_Incompleto = true; Campos_Invalidos.AppendLine(" > \"Callete y toma todo mi dinero\". ( Selecciona un año de adquisicion menor a 3000)"); }

                                if (!Formulario_Esta_Incompleto) { return null; }
                                Mensaje_Campos_Invalidos = Campos_Invalidos.ToString();

                                return Mensaje_Campos_Invalidos;
                        }

                        if (this.Esta_Vacio) { return; }
                        string? Campos_Invalidos;

                        Campos_Invalidos = Get_Campos_Invalidos_Tipado_Maquinaria();
                        if (Campos_Invalidos is null) { return; }

                        DialogResult Eleccion_Usuario =
                        MessageBox.Show
                        (
                            owner: this,
                            caption: "Tipado de Animal incompleto",
                            text: "A el tipado de Maquinaria que esta en curso no es valido ahora mismo. Se necesitan hacer cambios en el.\n" +
                                  "Si sales ahora se perdera todos los detalles de tipado del Animal.\n" +
                                  "Campos Invalidos:\n" +
                                  Campos_Invalidos + "\n" +
                                  "Se cerrara la ventana ahora y descartar los cambios.",
                            icon: MessageBoxIcon.Warning,
                            buttons: MessageBoxButtons.OKCancel
                        );

                        if (Eleccion_Usuario == DialogResult.Cancel) { e.Cancel = true; return; }
                        Limpiar_Formulario();
                }
        }
}
