using Logica.Gestion_de_Lotes;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Gestion_Lotes
{
        public partial class Buscar_Por_Producto : Form
        {
                public Buscar_Por_Producto()
                {
                        InitializeComponent();
                        DropDownList_Filtro_Busqueda.Text = "ID Producto";
                }

                public int? ID_Lote_De_Producto_Seleccionado = null;

                private void Buscar_Por_Producto_Load(object sender, EventArgs e) { Grilla_Productos_NoLibres.DataSource = Procesamiento_Lotes.Marshal_Get_Productos_NoLibres(); }

                // Busqueda
                string Respaldo_Text = "";
                private void TextBox_Buscar_TextChanged(object sender, EventArgs e)
                {
                        if (DropDownList_Filtro_Busqueda.Text == "ID")
                        { // Se asegura de que el contenido ingresado al textbox sea solo numeros.
                                foreach (char Caracter in TextBox_Buscar.Text)
                                {
                                        if (!char.IsDigit(Caracter))
                                        {
                                                TextBox_Buscar.Text = Respaldo_Text; // Cuando esto ocurre el cursor es movido al principio del texto.
                                                TextBox_Buscar.SelectionStart = TextBox_Buscar.Text.Length; // Pone el cursor al final del texto.
                                                TextBox_Buscar.ScrollToCaret(); // Si por algun motivo el texto es mas largo que el ancho del TextBox, scrollea(desliza) el texto del TextBox hasta el cursor.
                                                return;
                                        }
                                }
                                Respaldo_Text = TextBox_Buscar.Text;

                                // Toda esta funcionalidad estaba encapsulada en una extension de un TextBox que cree,
                                // la cual se llama simplemente `TextBoxNumerico`, pero por algun motivo no fui capaz
                                // de hacer que el constructor de ventanas de visual pudiera usar el control propiamente.
                                // Asi que lo implemento de esta forma.

                                // Detalles de la implementacion...
                                // En cada cambio del texto del textbox, se prohibe cualquier caracter que no sea un numero.
                                // En caso de de que se haya encontrado un caracter que no es un numero, se devuelve el texto
                                // al estado anterior.
                                // Aplica para TODOS los cambios en el texto. Esto significa que...
                                // * No se puede teclear caracteres no numericos al textbox.
                                // * No se puede pegar un texto que contenga caracteres no numericos en el textbox.
                                // * No se puede agregar de forma programatica texto con caracteres no numericos al textbox.
                                // Esto lo hace completamente seguro; garantiza que siempre su contenido son numeros.
                                // En esta implementacion... Esa garantia existe siempre y cuando no se deshabilite el evento
                                // `TextChanged`, claro.
                        }
                }
                private void TextBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if (!((Keys)e.KeyChar == Keys.Enter)) { return; }
                        DataTable? Productos_NoLibres;
                        string Filtro_Busqueda = DropDownList_Filtro_Busqueda.Text.Replace(' ', '_');
                        string Valor_Filtro = ((CheckBox_Autocompletar_Principio.Checked) ? '%' : "") + TextBox_Buscar.Text + ((CheckBox_Autocompletar_Final.Checked) ? '%' : "");

                        if (Valor_Filtro != "") { Productos_NoLibres = (DataTable?)Procesamiento_Lotes.Marshal_Get_Productos_NoLibres(Filtro_Busqueda, Valor_Filtro); }
                        else { Productos_NoLibres = (DataTable?)Procesamiento_Lotes.Marshal_Get_Productos_NoLibres(); }

                        Grilla_Productos_NoLibres.DataSource = Productos_NoLibres;
                }
                private void DropDownList_Filtro_Busqueda_SelectedIndexChanged(object sender, EventArgs e) { TextBox_Buscar.PlaceholderText = "Buscar Producto del Lote por " + DropDownList_Filtro_Busqueda.Text; }

                // Destranque
                private void Grilla_Productos_NoLibres_SelectionChanged(object sender, EventArgs e) { Button_Ir_A_Lote.Enabled = (Grilla_Productos_NoLibres.SelectedRows.Count == 1); }

                // Ir a Lote
                private void Button_Ir_A_Lote_MouseClick(object sender, MouseEventArgs e)
                {
                        ID_Lote_De_Producto_Seleccionado = Convert.ToInt32(Grilla_Productos_NoLibres.CurrentRow.Cells["ID_Lote"].Value);
                        Close();
                }
                private void Grilla_Productos_NoLibres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
                {
                        Button_Ir_A_Lote.PerformClick(); // No anda, no voy a ver proeque. Invoco el evento manualmente:
                        Button_Ir_A_Lote_MouseClick((new object()), (new MouseEventArgs(x: 49, y: 9, button: MouseButtons.Left, clicks: 2, delta: 0)));
                }
        }
}
