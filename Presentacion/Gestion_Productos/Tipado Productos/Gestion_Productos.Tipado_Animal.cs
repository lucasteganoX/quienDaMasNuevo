using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica.Sistema_de_cosas_a_subastar;
namespace Presentacion.Gestion_Productos
{
        public partial class Gestion_Productos_Tipado_Animal : Form
        {
                public bool Esta_Vacio
                {
                        get
                        {
                                if (NumericUpDown_Peso.Value == 0) { return true; }
                                return false;
                        }
                }

                # region >>---- Items para el DropDownList_Especializacion segun el tipo de animal
                object[] Opciones_Especializacion_Vacuna =
                {
                        "Produccion_Leche",
                        "Produccion_Carne",
                        "Exposicion",
                        "Cria",
                        "Ninguna",

                        // Alias:
                        "Competicion",
                        "Reproduccion",
                        "Otra"
                };


                object[] Opciones_Especializacion_Equina =
                {
                        "Carreras",
                        "Salto",
                        "Trabajo",
                        "Exposicion",
                        "Reproduccion",
                        "Ninguna",

                        // Alias:
                        "Cria",
                        "Otra"
                };

                object[] Opciones_Especializacion_Ovina =
                {
                        "Produccion_Lana",
                        "Produccion_Carne",
                        "Cria",
                        "Ninguna_De_Las_Anteriores",

                        // Alias:
                        "Reproduccion",
                        "Ninguna"
                };
                # endregion

                void Reemplazar_Items_DropDownList_Especializacion(object[] Nueva_Lista_Items)
                {
                        // Atento, pues no controla que contiene la lista de Items.
                        DropDownList_Especializacion.Items.Clear();
                        foreach (string Item in Nueva_Lista_Items) { DropDownList_Especializacion.Items.Add(Item); }
                        DropDownList_Especializacion.SelectedItem = "Ninguna";
                }

                public void Limpiar_Formulario()
                {
                        SuspendLayout();
                        /*
                         * Controls.Clear() ;
                         * InitializeComponent();
                         * DropDownList_Tipo_Animal.SelectedItem = "Otro";
                         * DropDownList_Especializacion.Items.Add("Ninguna");
                         * DropDownList_Especializacion.SelectedItem = "Ninguna";
                         */ // Esto que seria lo mas logico y sencillo, termina generando un formulario diferente a pesar de que es exactamente lo mismo que el constructor

                        DropDownList_Tipo_Animal.SelectedItem = "Otro";
                        TextBox_Nombre.Text = null;
                        CheckBox_Nombre.Checked = false;
                        TextBox_Nombre.Enabled = false;
                        NumericUpDown_Edad.Value = 0;
                        CheckBox_Castrado.Checked = false;
                        CheckBox_Raza.Checked = false;
                        TextBox_Raza.Enabled = false;
                        NumericUpDown_Peso.Value = 0;
                        DropDownList_Especializacion.Items.Add("Ninguna");
                        DropDownList_Especializacion.SelectedItem = "Ninguna";

                        ResumeLayout();
                }

                public Gestion_Productos_Tipado_Animal()
                {
                        InitializeComponent();
                        DropDownList_Tipo_Animal.SelectedItem = "Otro";
                        DropDownList_Especializacion.Items.Add("Ninguna");
                        DropDownList_Especializacion.SelectedItem = "Ninguna";
                }

                # region >>---- Eventos
                private void DropDownList_Tipo_Animal_SelectedIndexChanged(object sender, EventArgs e)
                {
                        string Tipo_Seleccionado;

                        Tipo_Seleccionado = DropDownList_Tipo_Animal.Text;
                        if (Tipo_Seleccionado == "Otro")
                        {
                                DropDownList_Especializacion.Enabled = false;
                                DropDownList_Especializacion.SelectedItem = "Ninguna";
                                return;
                        }

                        if (!DropDownList_Especializacion.Enabled) { DropDownList_Especializacion.Enabled = true; }

                        switch (Tipo_Seleccionado)
                        {
                                case "Vacuno":
                                        Reemplazar_Items_DropDownList_Especializacion(Opciones_Especializacion_Vacuna);
                                        break;
                                case "Equino":
                                        Reemplazar_Items_DropDownList_Especializacion(Opciones_Especializacion_Equina);
                                        break;
                                case "Ovino":
                                        Reemplazar_Items_DropDownList_Especializacion(Opciones_Especializacion_Ovina);
                                        break;
                                default:
                                        throw new Exception("Se selecciono un tipo de Animal indefinido a la hora del tipado del Producto.");
                                        break;
                        }
                }

                private void CheckBox_Nombre_CheckedChanged(object sender, EventArgs e)
                {
                        if (!CheckBox_Nombre.Checked)
                        {
                                TextBox_Nombre.Enabled = false;
                                TextBox_Nombre.Text = "";
                                TextBox_Nombre.PlaceholderText = "";
                        }
                        else
                        {
                                TextBox_Nombre.Enabled = true;
                                TextBox_Nombre.PlaceholderText = "Ingresa su Nombre";
                        }
                }
                #endregion

                private void Gestion_Productos_Tipado_Animal_FormClosing(object sender, FormClosingEventArgs e)
                {
                        string? Campos_Incompletos_Tipado_Animal()
                        {
                                bool Formulario_Esta_Incompleto;
                                string Mensaje_Campos_Incompletos;
                                StringBuilder Campos_Incompletos;

                                Formulario_Esta_Incompleto = false;
                                Campos_Incompletos = new StringBuilder();

                                if (CheckBox_Nombre.Checked && string.IsNullOrWhiteSpace(TextBox_Nombre.Text)) { Formulario_Esta_Incompleto = true; Campos_Incompletos.AppendLine(" > Se indico que el Animal tiene un Nombre, pero no se indico cual."); }
                                if (CheckBox_Raza.Checked && string.IsNullOrWhiteSpace(TextBox_Raza.Text)) { Formulario_Esta_Incompleto = true; Campos_Incompletos.AppendLine(" > Se especifica la Raza del Animal, pero no se indico cual es."); }
                                if (NumericUpDown_Peso.Value == 0) { Formulario_Esta_Incompleto = true; Campos_Incompletos.AppendLine(" > El peso del Animal es de 0 kilos."); }
                                // El tema con la edad es que se podrian tratar de vender Animales de menos de un ano de edad, raro pero posible.

                                if (!Formulario_Esta_Incompleto) { return null; }
                                Mensaje_Campos_Incompletos = Campos_Incompletos.ToString();

                                return Mensaje_Campos_Incompletos;
                        }

                        if (this.Esta_Vacio) { return; }
                        string? Campos_Incompletos = Campos_Incompletos_Tipado_Animal();
                        if (Campos_Incompletos is null) { return; }

                        DialogResult Eleccion_Usuario =
                        MessageBox.Show
                        (
                            owner: this,
                            caption: "Tipado de Animal incompleto",
                            text: "A el tipado de Animal que esta en curso le faltan campos.\n" +
                                  "Si sales ahora se perdera todos los detalles de tipado del Animal.\n" +
                                  "Campos Invalidos:\n" +
                                   Campos_Incompletos + "\n" +
                                  "Se cerrara la ventana ahora y se descartaran los cambios.",
                            icon: MessageBoxIcon.Warning,
                            buttons: MessageBoxButtons.OKCancel
                        );

                        if (Eleccion_Usuario == DialogResult.Cancel) { e.Cancel = true; return; }
                        Limpiar_Formulario();

                }

                private void CheckBox_Raza_CheckedChanged(object sender, EventArgs e)
                {
                        if (CheckBox_Raza.Checked)
                        {
                                TextBox_Raza.Enabled = true;
                                TextBox_Raza.PlaceholderText = "Ingrese su Raza";
                                return;
                        }

                        if (!CheckBox_Raza.Checked)
                        {
                                TextBox_Raza.Enabled = false;
                                TextBox_Raza.Text = null;
                                TextBox_Raza.PlaceholderText = null;
                        }
                }
        }
}
