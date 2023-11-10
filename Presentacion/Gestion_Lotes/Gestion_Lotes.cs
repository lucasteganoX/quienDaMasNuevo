using Logica.Gestion_Productos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Media;
using System.Reflection;
using Logica.Gestion_de_Lotes;
using System.Net.Http.Headers;
using System.Drawing.Text;

using Logica.Gestion_Productos ;
namespace Presentacion.Gestion_Lotes
{
        public partial class Gestion_Lotes : Form
        {
                int? ID_Lote_Actual;

                public Gestion_Lotes()
                {
                        InitializeComponent();
                        Cambiar_Categoria_Sin_Disparar_Evento(Nueva_Categoria: "Ninguna");
                        DropDownList_Categoria.MouseWheel += DropDownList_Categoria_MouseWheel;

                        // Configuracion del sistema de grillas
                        Grilla_Izquierda = Grilla_Productos_Libres ;
                        Grilla_Derecha = Grilla_Productos_Seleccionados ;
                }

                # region >>---- Sistema de tres estados para formularios de gestion de dos grillas
                // Configuracion
                private DataGridView Grilla_Izquierda ;
                private DataGridView Grilla_Derecha ;
                private int? ID_Actual_Entidad
                {
                        get { return ID_Lote_Actual ; }
                        set { ID_Lote_Actual = value ; }
                }

                // `Estados` del form
                bool Se_Esta_Editando_Plantilla
                {
                        get
                        {
                                if (Grilla_Derecha.DataSource is not null) { return false; }
                                if (ID_Lote_Actual is not null) { return false; }
                                if (Grilla_Derecha.Columns.Count == 0) { return false; }
                                return true;
                        }
                }
                bool Se_Esta_Editando_Entidad
                {
                        get
                        {
                                if (ID_Lote_Actual is null) { return false; }
                                if (Grilla_Derecha.Columns.Count == 0) { return false; }
                                if (Grilla_Derecha.DataSource is null) { return false; }
                                return true;
                        }
                }
                bool Form_Esta_Vacio
                {
                        get
                        {
                                if (ID_Lote_Actual is not null) { return false; }
                                if (Grilla_Izquierda.Columns.Count != 0 || Grilla_Derecha.Columns.Count != 0) { return false; }
                                if (Grilla_Izquierda.DataSource is not null || Grilla_Derecha.DataSource is not null) { return false; }
                                return true;
                        }
                }

                // Poner cabeceras grilla
                private void Poner_Cabecera_Grilla_Derecha( bool Modo_Plantilla )
                { // Pone una grilla vacia con las columnas adecuadas
                        if ( Modo_Plantilla )
                        { // Define la cabecera de la Plantilla
                                Grilla_Derecha.Columns.Add("ID", "ID");
                                Grilla_Derecha.Columns.Add("Nombre", "Nombre");
                                Grilla_Derecha.Columns.Add("Valor", "Valor");
                                Grilla_Derecha.Columns.Add("Precio_Base", "Precio_Base");
                                Grilla_Derecha.Columns.Add("Tipo", "Tipo");
                                Grilla_Derecha.Columns.Add("Descripcion", "Descripcion");
                        }
                        if ( ! Modo_Plantilla )
                        {  // Crea un DataSource vacia, valida para el estado `Editando Lote`
                                DataTable Tabla = new DataTable();
                                Tabla.Columns.Add("ID");
                                Tabla.Columns.Add("Nombre");
                                Tabla.Columns.Add("Valor");
                                Tabla.Columns.Add("Precio_Base");
                                Tabla.Columns.Add("Tipo");
                                Tabla.Columns.Add("Descripcion");
                                Grilla_Derecha.DataSource = Tabla;
                        }        
                }
                
                // Quitar cabeceras grillas
                private void Limpiar_Columnas_Grilla_Derecha( bool Columnas_DataViewGrid )
                { // Limpia las columnas que pertenecen a la grilla como tal
                        if ( Columnas_DataViewGrid )
                        { 
                                Grilla_Derecha.DataSource = null ;
                                Grilla_Derecha.Columns.Clear() ;
                        }
                }

                // Mover filas
                /// <summary>Mueve una fila de la grilla izquierda a la fila derecha manejando el estado del form de manera interna.</summary>
                /// <param name="Fila_Grilla_Izquierda">La fila de la grilla izquierda que se pretende mover a la grilla derecha.</param>
                void Mover_Fila_De_Izquierda_A_Derecha( DataGridViewRow Fila_Grilla_Izquierda )
                { 
                        if ( Se_Esta_Editando_Entidad ) 
                        {
                                DataTable Productos_Seleccionados = ((DataTable)Grilla_Derecha.DataSource);
                                DataTable Productos_Libres = ((DataTable)Grilla_Izquierda.DataSource);
                                DataRow Producto_Libre = ( Fila_Grilla_Izquierda.DataBoundItem as DataRowView)!.Row;

                                Productos_Seleccionados.ImportRow(Producto_Libre);
                                Productos_Libres.Rows.Remove( /*ex-*/Producto_Libre);
                        }
                        if ( Se_Esta_Editando_Plantilla )
                        { 
                                int Indice_Producto_Seleccionado = Grilla_Derecha.Rows.Add();
                                for (int Indice_Columna = 0; Indice_Columna < Grilla_Izquierda.Columns.Count; Indice_Columna++) { Grilla_Derecha.Rows[Indice_Producto_Seleccionado].Cells[Indice_Columna].Value = Fila_Grilla_Izquierda.Cells[Indice_Columna].Value; }
                                Grilla_Izquierda.Rows.Remove( Fila_Grilla_Izquierda );
                        }
                }
                /// <summary>Mueve una fila de la grilla derecha a la grilla izquierda manejando el `Estado` del form de manera interna.</summary>
                /// <param name="Indice_Fila_Derecha">El indice de la fila de la fila derecha.</param>
                void Mover_Fila_Derecha_A_Izquierda( int Indice_Fila_Derecha )
                { 
                        DataTable Get_Filas_Plantilla()
                        { // Consigue una DataTable que representa a los Productos seleccionados del Lote
                                DataTable Representacion_Filas_Seleccionadas = ((DataTable)Grilla_Izquierda.DataSource).Clone();
                                foreach (DataGridViewRow Fila_Seleccionada in Grilla_Derecha.SelectedRows)
                                {
                                        object[]? Atributos_Fila = new object[Fila_Seleccionada.Cells.Count];
                                        for (int Indice_Celda = 0; Indice_Celda < Fila_Seleccionada.Cells.Count; Indice_Celda++) { Atributos_Fila[Indice_Celda] = Fila_Seleccionada.Cells[Indice_Celda].Value; }
                                        Representacion_Filas_Seleccionadas.Rows.Add(Atributos_Fila);
                                }
                                return Representacion_Filas_Seleccionadas;
                        }

                        DataTable DataTable_Productos_Seleccionados = (Se_Esta_Editando_Plantilla) ? Get_Filas_Plantilla() : ((DataTable)Grilla_Derecha.DataSource);
                        DataGridViewRow DataGridViewRow_Producto_Lote = Grilla_Derecha.SelectedRows[Indice_Fila_Derecha];
                        DataRow Producto_Lote;

                        // Consigue el producto seleccionado
                        Producto_Lote = DataTable_Productos_Seleccionados.Rows[ Indice_Fila_Derecha ] ;

                        ((DataTable)Grilla_Izquierda.DataSource).ImportRow(Producto_Lote) ;

                        // Remueve el Producto de la grilla de Productos seleccionados
                        if ( Se_Esta_Editando_Entidad ) { ( ( DataTable ) Grilla_Derecha.DataSource ).Rows.Remove( Producto_Lote ) ; }
                        if ( Se_Esta_Editando_Plantilla ) { Grilla_Derecha.Rows.Remove( DataGridViewRow_Producto_Lote ) ; }
                }

                // Quitar filas
                void Quitar_Fila_Derecha( int Indice_Fila )
                { 
                        DataRow Fila = ( ( DataTable ) Grilla_Derecha.DataSource ).Rows[ Indice_Fila ] ;
                        ( ( DataTable ) Grilla_Derecha.DataSource ).Rows.Remove( Fila ) ;
                }
                # endregion

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
                # region >>---- Actualizacion de estado
                void Actualizar_Label_Numero_Lote() { Label_ID_Lote_Actual.Text = "ID del Lote actual = " + ((ID_Lote_Actual is null) ? "@ID_Lote_Actual" : ID_Lote_Actual); }

                void Actualizar_Informacion_Lote(int ID_Lote, bool Cargar_Atributos_Lote, bool Autoasignar_Categoria_Lote) // En realidad seria mas como "Mostrar representacion Lote" pero ta
                {
                        // No voy a checkar que el Lote existe, esi deberia se manejado en un orden superior

                        // Asegura los discriminantes del estado `Lote`.
                        Limpiar_Columnas_Grilla_Derecha( Columnas_DataViewGrid: true ) ;
                        Actualizar_Label_Numero_Lote();
                        Poner_Cabecera_Grilla_Derecha( Modo_Plantilla: false ) ;

                        DataTable? Resumen_Productos_Lote = (DataTable?)
                        Procesamiento_Lotes.Marshal_Get_Resumen_Productos_Lote(ID_Lote);

                        if (Cargar_Atributos_Lote)
                        { // Cargar los atributos del Lote
                                Dictionary<string, object?>? Elemento_Subasta = Procesamiento_Lotes.Marshal_Get_Elemento_Subasta(ID_Lote);

                                // Atributos de Elementos Subasta
                                NumericUpDown_Valor.Value = ((Elemento_Subasta!["Valor"] is not null) ? Convert.ToInt32(Elemento_Subasta["Valor"]) : 0);
                                NumericUpDown_Precio_Base.Value = ((Elemento_Subasta["Precio_Base"] is not null) ? Convert.ToInt32(Elemento_Subasta["Precio_Base"]) : 0);
                                CheckBox_Habilitado.Checked = Convert.ToBoolean(Elemento_Subasta["Habilitado"]);

                                // Atributos de Lote
                                if (Autoasignar_Categoria_Lote) { DropDownList_Categoria.Text = (Anterior_Categoria_Seleccionada = Procesamiento_Lotes.Marshal_Get_Categoria_Lote(ID_Lote)); }
                        }
                        if (Resumen_Productos_Lote is null) { return; }

                        // Popular la grilla con los Resumen de los Productos que pertenecen al Lote.
                        if (DropDownList_Categoria.Text == Procesamiento_Lotes.Marshal_Get_Categoria_Lote(ID_Lote) || DropDownList_Categoria.Text == "Ninguna")
                        {
                                Grilla_Derecha.DataSource = Resumen_Productos_Lote; // Si en algun momento uso el SelectionChanged, esto podria volverse inviable.
                                Grilla_Derecha.Refresh();
                        }
                        Grilla_Productos_Seleccionados.ClearSelection();
                        // Nota:
                        // Si alguien (incluido yo) fuera a refactorizar este codigo... Sea conciente que el bloque que popula la grilla con Productos utiliza un early return.
                        // Debido a que es un bloque y no una funcion, el return termina toda la funcion. En el orden en que estan lo bloques esto no es un problema, ya que el
                        // fin de ese bloque tambien es el fin de la funcion, ya que no se ejecuta nada mas despues del bloque, pero si esto se cambia, el early return evitara
                        // la ejecucion de las siguientes partes de la funcion.
                }
                void Actualizar_Grilla_Productos_Libres(string Categoria_Lote, bool Mostrar_Aviso_No_Quedan_Productos = false)
                {
                        DataTable? Productos_Libres = (DataTable?)
                        Procesamiento_Lotes.Marshal_Get_Productos_Libres(Categoria_Lote);

                        if (Productos_Libres is null)
                        {
                                if (Mostrar_Aviso_No_Quedan_Productos)
                                {
                                        MessageBox.Show
                                        (
                                                caption: "No hay Productos libres",
                                                text: $"Actualmente no se encontraró en el sistema Productos habilitados {((Categoria_Lote != "Ninguna") ? $"del tipo `{Categoria_Lote}`" : "")} que no pertenezcan a ningún Lote.",
                                                icon: MessageBoxIcon.Error,
                                                buttons: MessageBoxButtons.OK,
                                                owner: this
                                        );
                                }

                                { // Mostrar grilla de Productos Libres vacia
                                        Grilla_Productos_Libres.AllowUserToAddRows = true;
                                        if (Grilla_Productos_Libres.DataSource is not null && Grilla_Productos_Libres.Rows.Count != 0)
                                        {
                                                ((DataTable)Grilla_Productos_Libres.DataSource).Rows.Clear();
                                                return;
                                        }
                                        Grilla_Productos_Libres.Columns.Add("ID", "ID");
                                        Grilla_Productos_Libres.Columns.Add("Nombre", "Nombre");
                                        Grilla_Productos_Libres.Columns.Add("Valor", "Valor");
                                        Grilla_Productos_Libres.Columns.Add("Precio_Base", "Precio_Base");
                                        Grilla_Productos_Libres.Columns.Add("Tipo", "Tipo");
                                        Grilla_Productos_Libres.Columns.Add("Descripcion", "Descripcion");
                                }
                                return;
                        }
                        Grilla_Productos_Libres.DataSource = null;
                        Grilla_Productos_Libres.Columns.Clear();
                        Grilla_Productos_Libres.DataSource = Productos_Libres;
                        Grilla_Productos_Libres.AllowUserToAddRows = false;
                        Grilla_Productos_Libres.ClearSelection();
                }
                void Actualizar_Estado_Lotes(bool Cargar_Atributos_Lote, bool Modo_Plantilla_Lote = false, bool Mostrar_Aviso_No_Quedan_Productos = false, bool Autoseleccionar_Categoria_Lote = false)
                { // Actualizar los Productos del Lote
                        if (Modo_Plantilla_Lote) { Activar_Plantilla_Lote(); }
                        if (!Modo_Plantilla_Lote && !Se_Esta_Editando_Plantilla) { Actualizar_Informacion_Lote((int)ID_Lote_Actual!, Cargar_Atributos_Lote, Autoseleccionar_Categoria_Lote); }
                        Button_Modificar.Enabled = (Button_Eliminar.Enabled = (!Se_Esta_Editando_Plantilla));
                        Actualizar_Grilla_Productos_Libres(Categoria_Lote: DropDownList_Categoria.Text, Mostrar_Aviso_No_Quedan_Productos);
                }

                void Activar_Plantilla_Lote()
                {
                        ID_Lote_Actual = null;
                        Grilla_Productos_Seleccionados.DataSource = null;

                        { // Re-inicia la informacion del formulario
                                Actualizar_Label_Numero_Lote();
                                NumericUpDown_Valor.Value = 0;
                                NumericUpDown_Precio_Base.Value = 0;
                                CheckBox_Habilitado.Checked = false;
                        }

                        Poner_Cabecera_Grilla_Derecha( Modo_Plantilla: true );
                }
                #endregion
                #region >>---- Validacion de Lote y Productos Libres
                string Anterior_Categoria_Seleccionada = "Ninguna";
                private void DropDownList_Categoria_SelectedIndexChanged(object sender, EventArgs e)
                {
                        // Se encarga de que los integrantes del Lote sean coherentes con la categoria del mismo
                        // ----------------------------------------------------------------------------------------------
                        // Se encarga de que los posibles integrantes del Lote sean coherentes con la categoria del mismo
                        // ----------------------------------------------------------------------------------------------
                        if (Form_Esta_Vacio) { return; }
                        if (DropDownList_Categoria.Text == Anterior_Categoria_Seleccionada) { return; }
                        bool Hay_Productos_Incompatibles_Con_La_Nueva_Categoria = false;

                        if ( Se_Esta_Editando_Plantilla )
                        { 
                                Grilla_Productos_Seleccionados.Rows.Clear() ;
                                Anterior_Categoria_Seleccionada = DropDownList_Categoria.Text;
                                Actualizar_Estado_Lotes(Cargar_Atributos_Lote: false, Mostrar_Aviso_No_Quedan_Productos: true);
                                return ;
                        }

                        if (DropDownList_Categoria.Text != "Ninguna")
                        { // Compureba si hay Productos incompatibles

                                // Determina el tipo de Producto compatible con la categoria actual del Lote
                                string Tipo_Producto_Compatible = "";
                                switch (DropDownList_Categoria.Text)
                                {
                                        case "Animales": Tipo_Producto_Compatible = "Animal"; break;
                                        case "Maquinaria": Tipo_Producto_Compatible = "Maquinaria"; break;
                                }

                                foreach (DataGridViewRow Producto in Grilla_Productos_Seleccionados.Rows)
                                {
                                        if (Producto.Cells["Tipo"].Value.ToString() != Tipo_Producto_Compatible)
                                        {
                                                Hay_Productos_Incompatibles_Con_La_Nueva_Categoria = true;
                                                break;
                                        }
                                }
                        }

                        if (Hay_Productos_Incompatibles_Con_La_Nueva_Categoria)
                        {
                                DialogResult Respuesta_Usuario =
                                MessageBox.Show
                                (
                                        caption: "Hay Productos incompatibles con la nueva categoria.",
                                        text: $"Se encontraron Productos del Tipo {Anterior_Categoria_Seleccionada} despues de seleccionar la categoria {DropDownList_Categoria.Text}.\n" +
                                               "Estos Productos serán expulsados del Lote y podrás seguir editando.",
                                        icon: MessageBoxIcon.Warning,
                                        buttons: MessageBoxButtons.OKCancel,
                                        owner: this
                                );
                                if (Respuesta_Usuario != DialogResult.OK)
                                {
                                        Cambiar_Categoria_Sin_Disparar_Evento(Anterior_Categoria_Seleccionada);
                                        return;
                                }

                                { // Quita los Porductos incompatibles del Lote
                                        string Tipo_Actual = "";
                                        switch (DropDownList_Categoria.Text)
                                        {
                                                case "Animales": Tipo_Actual = "Animal"; break;
                                                case "Maquinaria": Tipo_Actual = "Maquinaria"; break;
                                        }

                                        for (int Indice_Fila = Grilla_Productos_Seleccionados.Rows.Count - 1; Indice_Fila >= 0; Indice_Fila--)
                                        {
                                                string? Tipo_Producto = ( string? ) Grilla_Productos_Seleccionados.Rows[ Indice_Fila ].Cells["Tipo"].Value ;
                                                if ( Tipo_Producto != Tipo_Actual ) { Quitar_Fila_Derecha( Indice_Fila ) ; }
                                        }
                                }
                        }
                        Anterior_Categoria_Seleccionada = DropDownList_Categoria.Text;
                        Actualizar_Estado_Lotes(Cargar_Atributos_Lote: false, Mostrar_Aviso_No_Quedan_Productos: true);
                }
                private void DropDownList_Categoria_MouseWheel(object sender, MouseEventArgs e) { ((HandledMouseEventArgs)e).Handled = true; }

                void Cambiar_Categoria_Sin_Disparar_Evento(string Nueva_Categoria)
                {
                        // Esto es medio MMMMHHHHH pero ta.
                        DropDownList_Categoria.SelectedIndexChanged -= DropDownList_Categoria_SelectedIndexChanged;
                        DropDownList_Categoria.Text = Nueva_Categoria;
                        DropDownList_Categoria.SelectedIndexChanged += DropDownList_Categoria_SelectedIndexChanged;
                }
                # endregion
                # region >>---- Seleccion de Lotes
                private void Buscar_Por_Producto_Click(object sender, EventArgs e)
                {
                        Buscar_Por_Producto Form_Busqueda = new Buscar_Por_Producto();
                        Form_Busqueda.ShowDialog(owner: this);

                        if (Form_Busqueda.ID_Lote_De_Producto_Seleccionado is null) { return; }
                        TextBox_ID_Lote.Text = ((int)Form_Busqueda.ID_Lote_De_Producto_Seleccionado).ToString();
                        Button_Ir_A_ID.PerformClick();
                }

                private void Button_Ir_A_ID_Click(object sender, EventArgs e)
                {
                        if (TextBox_ID_Lote.Text == "")
                        {
                                TextBox_ID_Lote.Focus();
                                return;
                        }
                        int ID_Lote = Convert.ToInt32(TextBox_ID_Lote.Text);
                        // El texto puede no ser un int

                        if (!Procesamiento_Lotes.Marshal_Lote_Existe(ID_Lote))
                        {
                                MessageBox.Show
                                (
                                        caption: "No se encontro el Lote",
                                        text: $"No se ha encontrado un Lote para la ID `{ID_Lote}`.",
                                        icon: MessageBoxIcon.Error,
                                        buttons: MessageBoxButtons.OK,
                                        owner: this
                                );
                                return;
                        }

                        ID_Lote_Actual = ID_Lote;
                        Actualizar_Estado_Lotes(Cargar_Atributos_Lote: true, Autoseleccionar_Categoria_Lote: true);
                }
                private void TextBox_ID_Lote_KeyPress(object sender, KeyPressEventArgs e) { if (((Keys)e.KeyChar) == Keys.Enter) { Button_Ir_A_ID.PerformClick(); return; } }

                private string Respaldo_Text = "";
                private void TextBox_ID_Lote_TextChanged(object sender, EventArgs e)
                { // Se asegura de que el contenido ingresado al textbox sea solo numeros.
                        foreach (char Caracter in TextBox_ID_Lote.Text)
                        {
                                if (!char.IsDigit(Caracter))
                                {
                                        TextBox_ID_Lote.Text = Respaldo_Text; // Cuando esto ocurre el cursor es movido al principio del texto.
                                        TextBox_ID_Lote.SelectionStart = TextBox_ID_Lote.Text.Length; // Pone el cursor al final del texto.
                                        TextBox_ID_Lote.ScrollToCaret(); // Si por algun motivo el texto es mas largo que el ancho del TextBox, scrollea(desliza) el texto del TextBox hasta el cursor.
                                        return;
                                }
                        }
                        Respaldo_Text = TextBox_ID_Lote.Text;

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
                # endregion
                # region >>---- Paso de filas de una grilla a la otra
                // Pasar filas de un lado al otro
                private void Button_Derecha_Click(object sender, EventArgs e)
                {
                        // Depende de poder clickar cuando hay un estado otro que `Form vacio`
                        if (Grilla_Izquierda.SelectedRows.Count == 0) { return; }
                        foreach (DataGridViewRow Fila in Grilla_Izquierda.SelectedRows) { if (Fila.IsNewRow) { return; } }

                        foreach (DataGridViewRow Producto_Libre in Grilla_Izquierda.SelectedRows) { Mover_Fila_De_Izquierda_A_Derecha( Producto_Libre ) ; }
                        Grilla_Izquierda.ClearSelection();
                        if (Grilla_Derecha.Rows.Count == 1) { Grilla_Derecha.ClearSelection(); }
                }
                private void Button_Izquierda_Click(object sender, EventArgs e)
                {
                        if (Grilla_Derecha.SelectedRows.Count == 0) { return; }

                        for (int Indice_Fila = Grilla_Derecha.SelectedRows.Count - 1; Indice_Fila > -1; Indice_Fila--) { Mover_Fila_Derecha_A_Izquierda( Indice_Fila ) ; }
                        Grilla_Derecha.ClearSelection();
                        if (Grilla_Izquierda.Rows.Count == 1) { Grilla_Izquierda.ClearSelection(); }
                }

                // Pasar una fila al otro lado con doble click
                private void Grilla_Derecha_MouseDoubleClick(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { Button_Derecha.PerformClick(); } }
                private void Grilla_Productos_Seleccionados_MouseDoubleClick(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { Button_Izquierda.PerformClick(); } }

                // Habilitar botones cuando hay una o mas filas seleccionadas
                private void Grilla_Izquierda_SelectionChanged(object sender, EventArgs e)
                {
                        Button_Derecha.Enabled = (Grilla_Izquierda.SelectedRows.Count > 0);
                        foreach (DataGridViewRow Fila in Grilla_Izquierda.SelectedRows) { if (Fila.IsNewRow) { Button_Derecha.Enabled = false; } }
                }
                private void Grilla_Derecha_SelectionChanged(object sender, EventArgs e)
                {
                        Button_Izquierda.Enabled = (Grilla_Derecha.SelectedRows.Count > 0);
                        foreach (DataGridViewRow Fila in Grilla_Derecha.SelectedRows) { if (Fila.IsNewRow) { Button_Izquierda.Enabled = false; } }
                }
                #endregion
                # region >>---- Controles(Gestion de Lotes)
                private void Button_Guardar_Click(object sender, EventArgs e)
                {
                        if (!Se_Esta_Editando_Plantilla) { goto Crear_Plantilla_Nuevo_Lote; }
                        else { goto Concretar_Creacion_Lote; }

                //------------------------------------------------------------------------------
                Crear_Plantilla_Nuevo_Lote: //--------------------------------------------------
                        if ((
                        MessageBox.Show
                        (
                                caption: "Se creará un Lote vacío",
                                text: "A continuación se creará una plantilla de un nuevo Lote vacío.\n" +
                                      "Los cambios no se guardaran hasta que pongas Productos en el Lote y presiones el botón `Crear` nuevamente." +
                                ((ID_Lote_Actual is not null) ? "\nPD: Los cambios no guardados en el Lote actual se perderán." : ""),
                                icon: MessageBoxIcon.Question,
                                buttons: MessageBoxButtons.OKCancel,
                                owner: this
                        ))
                                != DialogResult.OK) { return; }

                        // Mostrar_Lote_Vacio();
                        // Actualizar_Grilla_Productos_Libres( Categoria_Lote: DropDownList_Categoria.Text, Mostrar_Aviso_No_Quedan_Productos: true ) ;
                        Actualizar_Estado_Lotes(Cargar_Atributos_Lote: false, Modo_Plantilla_Lote: true, Mostrar_Aviso_No_Quedan_Productos: true);
                        return;

                Concretar_Creacion_Lote: //-----------------------------------------------------
                        int? Valor = ((int)NumericUpDown_Valor.Value);
                        int? Precio_Base = ((int)NumericUpDown_Precio_Base.Value);
                        string Categoria = DropDownList_Categoria.Text;
                        bool Habilitado = CheckBox_Habilitado.Checked;
                        int[] ID_Productos = (new int[] { }); Recompilar_ID_Productos_Lote(ref ID_Productos);

                        if (Valor == 0 || Precio_Base == 0)
                        { // Construir y mostrar advertencia sobre atributos del Lote.
                                if ((
                                MessageBox.Show
                                (
                                        caption: "Se creará un Lote con Valor o Precio Base iguales a 0 dolares.",
                                        text: "Se indicó que el Lote tendría un Valor o Precio Base equivalente a 0 dolares.\n" +
                                              "Se creará un Lote con tales atributos.",
                                        icon: MessageBoxIcon.Warning,
                                        buttons: MessageBoxButtons.OKCancel,
                                        owner: this
                                )
                                  != DialogResult.OK)) { return; }
                        }

                        int ID_Lote_Creado = ((int)Procesamiento_Lotes.Crear_Lote(Precio_Base, Valor, Categoria, Habilitado, ID_Productos, Devolver_ID_Lote: true)!);
                        ID_Lote_Actual = ID_Lote_Creado;
                        Actualizar_Estado_Lotes(Cargar_Atributos_Lote: true, Mostrar_Aviso_No_Quedan_Productos: false, Autoseleccionar_Categoria_Lote: true);
                        Reproducir_Tono_Producto_Guardado();
                        return;
                }
                private void Button_Modificar_Click(object sender, EventArgs e)
                {
                        if (ID_Lote_Actual is null) { return; }

                        int[] ID_Productos_Lote = new int[] { };
                        Recompilar_ID_Productos_Lote(ref ID_Productos_Lote);
                        int Valor_Lote = ((int)NumericUpDown_Valor.Value);
                        int Precio_Base = ((int)NumericUpDown_Precio_Base.Value);
                        string Categoria = DropDownList_Categoria.Text;
                        bool Habilitacion_Lote = CheckBox_Habilitado.Checked;
                        Procesamiento_Lotes.Modificar_Lote((int)ID_Lote_Actual, ID_Productos_Lote, Valor_Lote, Precio_Base, Categoria, Habilitacion_Lote);
                        Actualizar_Estado_Lotes(Cargar_Atributos_Lote: true, Autoseleccionar_Categoria_Lote: true, Mostrar_Aviso_No_Quedan_Productos: false);
                        Reproducir_Tono_Modificado();
                }
                private void Button_Eliminar_Click(object sender, EventArgs e)
                {
                        // Depende de que no se pueda hacer click a "Eliminar" cuando se esta editando una Plantilla de Lote.
                        if ((
                        MessageBox.Show
                        (
                               caption: "Se eliminará el Lote",
                               text: $"A continuacion se eliminará el Lote de ID `{ID_Lote_Actual}`.",
                               icon: MessageBoxIcon.Warning,
                               buttons: MessageBoxButtons.OKCancel,
                               owner: this
                        ))
                            != DialogResult.OK) { return; }

                        Procesamiento_Lotes.Marshal_Delete_Lote((int)ID_Lote_Actual);
                        ID_Lote_Actual = null;
                        Actualizar_Estado_Lotes(Cargar_Atributos_Lote: false, Modo_Plantilla_Lote: true, Mostrar_Aviso_No_Quedan_Productos: false);
                        // Actualizar_Informacion_Lote( ( int ) ID_Lote_Actual ) ;
                        // Actualizar_Grilla_Productos_Libres( Categoria_Lote: DropDownList_Categoria.Text) ;
                        Reproducir_Tono_Producto_Eliminado();
                }

                void Recompilar_ID_Productos_Lote(ref int[] ID_Productos_Lote)
                { // Recompilar las ID de los Productos del Lote 
                        int Cantidad_Productos_Lote = Grilla_Productos_Seleccionados.Rows.Count;
                        ID_Productos_Lote = new int[Cantidad_Productos_Lote];

                        for (int Indice_Producto_Lote = 0; Indice_Producto_Lote < Cantidad_Productos_Lote; Indice_Producto_Lote++)
                        {
                                int ID_Producto_Lote_Actual = Convert.ToInt32(Grilla_Productos_Seleccionados.Rows[Indice_Producto_Lote].Cells["ID"].Value);
                                ID_Productos_Lote[Indice_Producto_Lote] = ID_Producto_Lote_Actual;
                        }
                }
                #endregion
        }
}
