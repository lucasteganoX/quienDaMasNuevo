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

using Logica.Gestion_Remates;
namespace Presentacion.Gestion_Remates
{
        public partial class Buscar_Por_Elemento : Form
        {
                public int? ID_Remate_De_Elemento = null;

                public Buscar_Por_Elemento()
                {
                        InitializeComponent();
                        // Por cada columna de los "Elementos" pone un filtro de busqueda y elige la primera columna como filtro por defecto
                        string[] Columnas = Procesamiento_Remates.Get_Columnas_Resumen_Elementos_Subasta_NoLibres() ;
                        for ( int Indice_Columna = 0 ; Indice_Columna < Columnas.Count() ; Indice_Columna++ ) { Columnas[ Indice_Columna ] = Columnas[ Indice_Columna ].Replace('_', ' ') ; }
                        DropDownList_Filtro_Busqueda.Items.AddRange( Columnas ) ;
                        DropDownList_Filtro_Busqueda.SelectedIndex = 0 ;
                }

                private void Buscar_Por_Elemento_Load(object sender, EventArgs e) { Grilla_Resumen_Elementos_Subasta_NoLibres.DataSource = Procesamiento_Remates.Marshal_Get_Resumen_Elementos_Subasta_NoLibres(); }

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
                        DataTable? Resumen_Elementos_Subasta_NoLibres;
                        string Filtro_Busqueda = DropDownList_Filtro_Busqueda.Text.Replace(' ', '_');
                        string Valor_Filtro = ((CheckBox_Autocompletar_Principio.Checked) ? '%' : "") + TextBox_Buscar.Text + ((CheckBox_Autocompletar_Final.Checked) ? '%' : "");

                        if (Valor_Filtro != "") { Resumen_Elementos_Subasta_NoLibres = Procesamiento_Remates.Marshal_Get_Resumen_Elementos_Subasta_NoLibres(Filtro_Busqueda, Valor_Filtro); }
                        else { Resumen_Elementos_Subasta_NoLibres = Procesamiento_Remates.Marshal_Get_Resumen_Elementos_Subasta_NoLibres(); }

                        Grilla_Resumen_Elementos_Subasta_NoLibres.DataSource = Resumen_Elementos_Subasta_NoLibres;
                }
                private void DropDownList_Filtro_Busqueda_SelectedIndexChanged(object sender, EventArgs e) { TextBox_Buscar.PlaceholderText = "Buscar Producto del Lote por " + DropDownList_Filtro_Busqueda.Text; }

                // Destranque
                private void Grilla_Resumen_Elementos_Subasta_NoLibres_SelectionChanged(object sender, EventArgs e) { Button_Ir_A_Remate.Enabled = (Grilla_Resumen_Elementos_Subasta_NoLibres.SelectedRows.Count == 1); }

                // Ir a Lote
                private void Button_Ir_A_Remate_MouseClick(object sender, MouseEventArgs e)
                {
                        int ID_Elemento_Seleccionado = Convert.ToInt32(Grilla_Resumen_Elementos_Subasta_NoLibres.CurrentRow.Cells[0].Value);
                        ID_Remate_De_Elemento = Procesamiento_Remates.Get_ID_Remate_Dueno_De_Elemento((int)ID_Elemento_Seleccionado);
                        Close();
                }
                private void Grilla_Elementos_Subasta_NoLibres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
                {
                        Button_Ir_A_Remate.PerformClick(); // No anda, no voy a ver proeque. Invoco el evento manualmente:
                        Button_Ir_A_Remate_MouseClick((new object()), (new MouseEventArgs(x: 49, y: 9, button: MouseButtons.Left, clicks: 2, delta: 0)));
                }
        }
}
