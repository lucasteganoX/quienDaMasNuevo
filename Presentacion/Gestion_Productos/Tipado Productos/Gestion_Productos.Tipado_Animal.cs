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
                                if (NumericUpDown_Peso.Value == 0 && DropDownList_Sexo.SelectedIndex == -1) { return true; }
                                return false;
                        }
                }

                # region >>---- Items para el DropDownList_Especializacion segun el tipo de animal
                object[] Opciones_Especializacion_Vacuna =
                {
                        "Produccion Leche",
                        "Produccion Carne",
                        "Exposicion",
                        "Cria",
                        "Ninguna"
                };


                object[] Opciones_Especializacion_Equina =
                {
                        "Carreras",
                        "Salto",
                        "Trabajo",
                        "Exposicion",
                        "Reproduccion",
                        "Ninguna"
                };

                object[] Opciones_Especializacion_Ovina =
                {
                        "Produccion Lana",
                        "Produccion Carne",
                        "Cria",
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

                # region >>---- Metodos para los campos del formulario
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
                        // CheckBox_Nombre.Checked = false;
                        // TextBox_Nombre.Enabled = false;
                        NumericUpDown_Edad.Value = 0;
                        CheckBox_Castrado.Checked = false;
                        CheckBox_Raza.Checked = false;
                        TextBox_Raza.Enabled = false;
                        NumericUpDown_Peso.Value = 0;
                        DropDownList_Especializacion.Items.Add("Ninguna");
                        DropDownList_Especializacion.SelectedItem = "Ninguna";
                        // DropDownList_Sexo.SelectedItem = null;
                        DropDownList_Sexo.SelectedIndex = -1;

                        ResumeLayout();
                }

                public void Cargar_Animal(DataRow? Informacion_Animal)
                { // Asigna los datos del Animal y su subclase al formulario
                        object Tipo_Animal;
                        try
                        {
                                Tipo_Animal = Informacion_Animal["Tipo"] as string; // .Field< string >("Tipo") ;
                                switch (Tipo_Animal)
                                {
                                        case null:
                                                DropDownList_Tipo_Animal.SelectedItem = "Otro";
                                                break;
                                        case "Vacuno":
                                                DropDownList_Tipo_Animal.SelectedItem = "Vacuno";
                                                break;
                                        case "Equino":
                                                DropDownList_Tipo_Animal.SelectedItem = "Equino";
                                                break;
                                        case "Ovino":
                                                DropDownList_Tipo_Animal.SelectedItem = "Ovino";
                                                break;
                                        default:
                                                throw new Exception("Se consiguio un tipo de Animal no soportado desde la base de datos.");
                                                break;
                                }
                        }
                        catch (NullReferenceException)
                        {
                                /* La unica manera en que esto ocurra es que el Animal exista en la grilla pero no en la base de datos.
                                 * El programa no actualia las filas cada vez que vas a actualizar una de ellas. Y ademas las filas no
                                 * son bloqueadas en la base de datos mientras una de ellas esta en edicion. Por eso...
                                 * En un programa pensado para que solo una persona tenga acceso al editor de Productos... 
                                 * Como esta ahora el programa, esto solo puede ocurrir si alguien metio mano en la base de datos mien
                                 * tras otra persona estaba editando un determinado Producto.
                                 */

                                MessageBox.Show
                                (
                                      caption: "No se puede seleccionar este Producto",
                                      text: "El Producto que seleccionaste se encuentra desactualizado.\nSe actualizaran todos los productos",
                                      icon: MessageBoxIcon.Error,
                                      buttons: MessageBoxButtons.OK
                                );

                                Limpiar_Formulario();
                                Close();
                        }

                        NumericUpDown_Edad.Value = Convert.ToInt32(Informacion_Animal["Edad"]);
                        CheckBox_Castrado.Checked = Convert.ToBoolean(Informacion_Animal["Esta_Castrado"]);
                        if (Informacion_Animal["Raza"] is string Raza_ToString)
                        {
                                CheckBox_Raza.Checked = true;
                                TextBox_Raza.Text = Raza_ToString;
                        }
                        NumericUpDown_Peso.Value = Convert.ToInt32(Informacion_Animal["Peso"]);
                        DropDownList_Sexo.Text = Informacion_Animal["Sexo"].ToString();

                        if (Informacion_Animal["Especializacion"] is string Especializacion_ToString) { DropDownList_Especializacion.SelectedItem = Especializacion_ToString; }
                }
                # endregion

                public Gestion_Productos_Tipado_Animal(DataRow? Informacion_Animal = null)
                {
                        InitializeComponent();
                        { // Selecciona las opciones iniciales de los DropDownList(spinners) 
                                DropDownList_Tipo_Animal.SelectedItem = "Otro";
                                DropDownList_Especializacion.Items.Add("Ninguna");
                                DropDownList_Especializacion.SelectedItem = "Ninguna";
                        }

                        if (Informacion_Animal is not null) { Cargar_Animal(Informacion_Animal); }

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

                                // if (CheckBox_Nombre.Checked && string.IsNullOrWhiteSpace(TextBox_Nombre.Text)) { Formulario_Esta_Incompleto = true; Campos_Incompletos.AppendLine(" > Se indico que el Animal tiene un Nombre, pero no se indico cual."); }
                                if (CheckBox_Raza.Checked && string.IsNullOrWhiteSpace(TextBox_Raza.Text)) { Formulario_Esta_Incompleto = true; Campos_Incompletos.AppendLine(" > Se especifica la Raza del Animal, pero no se indico cual es."); }
                                if (NumericUpDown_Peso.Value == 0) { Formulario_Esta_Incompleto = true; Campos_Incompletos.AppendLine(" > El peso del Animal es de 0 kilos."); }
                                if (DropDownList_Sexo.Text == "") { Formulario_Esta_Incompleto = true; Campos_Incompletos.AppendLine(" > No se especificó el Sexo del Animal."); }
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
