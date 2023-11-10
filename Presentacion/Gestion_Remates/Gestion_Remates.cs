using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

using Logica.Gestion_Remates;
using System.Media;
using System.Reflection;
using static Acceso_Datos.Interfaz_Base_Datos;
using static System.Media.SoundPlayer;
using System.Text.RegularExpressions;
namespace Presentacion.Gestion_Remates
{
        using static Metodos_Extension_Y_Otros;
        public partial class Gestion_Remates : Form
        {
                int? ID_Remate_Actual = null;

                string Categoria
                {
                        get { return DropDownList_Tipo.Text; }
                        set { DropDownList_Tipo.Text = value; }
                }

                string Metodo_Pago
                {
                        get { return DropDownList_Metodo_Pago.Text; }
                        set { DropDownList_Metodo_Pago.Text = value; }
                }

                // Por conveniencia, hize el metodo estatico `GetString`.
                static readonly DateTime Minimo_MonthCalendar = Convert.ToDateTime("1/1/1753");
                DateTime Momento_Inicio;
                DateTime Momento_Fin;
                // Respecto al check de la fecha maxima...
                // Cuando se trata de un limite artificial... No hay motivos para que eista en primer lugar.
                // No hay porque limitar la fecha maxima que puede elegir el usuario. Eso es totalmente arbitrario.
                // Cuado se trata de el limite teorico de los tipos de datos...
                // Tanto MySQL como C# tienen el mismo limite para los DataTime, el ultimo dia del ano 9999.
                // Es imposible que un DateTime de MySQL supere uno de C# o viceversa.

                public Gestion_Remates()
                {
                        InitializeComponent();
                        // Configuracion sistema de tres estados para formualrios de dos grillas
                        Grilla_Derecha = Grilla_Integrantes_Remate;
                        Grilla_Izquierda = Grilla_Elementos_Disponibles;
                        // ---------------------------------------------------------------------

                        // CheckBox_Permitir_Fechas_Pasadas.Checked = false ;
                        Momento_Inicio = (Momento_Fin = DateTime.Now);
                        Categoria = "Ninguna";
                        // Asigna los metodos de pago de la base de datos a el DropDownList
                        List<string> Valores_Enum = Procesamiento_Remates.Get_Valore_Enum_Metodo_Pago();
                        DropDownList_Metodo_Pago.Items.AddRange(Valores_Enum.ToArray<object>());
                        DropDownList_Metodo_Pago.Text = Valores_Enum[0];

                        DropDownList_Seleccion_Momento.Text = "Momento de Inicio"; // Por algun motivo, cuando el form carga, la accion de esta asignacion causa que se permita selecciona fechas pasadas por defecto
                        Calendar_Momento.MinDate = Minimo_MonthCalendar;
                }

                # region >>---- Sistema de tres estados para formularios de gestion de dos grillas
                // Configuracion
                private DataGridView Grilla_Izquierda;
                private DataGridView Grilla_Derecha;
                private int? ID_Actual_Entidad
                {
                        get { return ID_Remate_Actual; }
                        set { ID_Remate_Actual = value; }
                }

                // `Estados` del form
                bool Se_Esta_Editando_Plantilla
                {
                        get
                        {
                                if (Grilla_Derecha.DataSource is not null) { return false; }
                                if (ID_Remate_Actual is not null) { return false; }
                                if (Grilla_Derecha.Columns.Count == 0) { return false; }
                                return true;
                        }
                }
                bool Se_Esta_Editando_Entidad
                {
                        get
                        {
                                if (ID_Remate_Actual is null) { return false; }
                                if (Grilla_Derecha.Columns.Count == 0) { return false; }
                                if (Grilla_Derecha.DataSource is null) { return false; }
                                return true;
                        }
                }
                bool Form_Esta_Vacio
                {
                        get
                        {
                                if (ID_Remate_Actual is not null) { return false; }
                                if (Grilla_Izquierda.Columns.Count != 0 || Grilla_Derecha.Columns.Count != 0) { return false; }
                                if (Grilla_Izquierda.DataSource is not null || Grilla_Derecha.DataSource is not null) { return false; }
                                return true;
                        }
                }

                // Poner cabeceras grilla
                private void Poner_Cabecera_Grilla_Derecha(bool Modo_Plantilla)
                { // Pone una grilla vacia con las columnas adecuadas
                        if (Modo_Plantilla)
                        { // Define la cabecera de la Plantilla
                                Grilla_Derecha.Columns.Add("ID", "ID");
                                Grilla_Derecha.Columns.Add("Tipo_Elemento", "Tipo_Elemento");
                                Grilla_Derecha.Columns.Add("Nombre", "Nombre");
                                Grilla_Derecha.Columns.Add("Valor", "Valor");
                                Grilla_Derecha.Columns.Add("Precio_Base", "Precio_Base");
                                Grilla_Derecha.Columns.Add("Categoria_Lote", "Categoria_Lote");
                                Grilla_Derecha.Columns.Add("Tipo_Producto", "Tipo_Producto");
                                Grilla_Derecha.Columns.Add("Descripcion", "Descripcion");
                        }
                        if (!Modo_Plantilla)
                        {
                                DataTable Tabla = new DataTable();
                                Tabla.Columns.Add("ID");
                                Tabla.Columns.Add("Tipo_Elemento");
                                Tabla.Columns.Add("Nombre");
                                Tabla.Columns.Add("Valor");
                                Tabla.Columns.Add("Precio_Base");
                                Tabla.Columns.Add("Categoria_Lote");
                                Tabla.Columns.Add("Tipo_Producto");
                                Tabla.Columns.Add("Descripcion");
                                Grilla_Derecha.DataSource = Tabla;
                        }
                }

                // Quitar cabeceras grillas
                private void Limpiar_Columnas_Grilla_Derecha(bool Columnas_DataViewGrid)
                { // Limpia las columnas que pertenecen a la grilla como tal
                        if (Columnas_DataViewGrid)
                        {
                                Grilla_Derecha.DataSource = null;
                                Grilla_Derecha.Columns.Clear();
                        }
                }

                // Mover filas
                /// <summary>Mueve una fila de la grilla izquierda a la fila derecha manejando el estado del form de manera interna.</summary>
                /// <param name="Fila_Grilla_Izquierda">La fila de la grilla izquierda que se pretende mover a la grilla derecha.</param>
                void Mover_Fila_De_Izquierda_A_Derecha(DataGridViewRow Fila_Grilla_Izquierda)
                {
                        if (Se_Esta_Editando_Entidad)
                        {
                                DataTable Productos_Seleccionados = ((DataTable)Grilla_Derecha.DataSource);
                                DataTable Productos_Libres = ((DataTable)Grilla_Izquierda.DataSource);
                                DataRow Producto_Libre = (Fila_Grilla_Izquierda.DataBoundItem as DataRowView)!.Row;

                                Productos_Seleccionados.ImportRow(Producto_Libre);
                                Productos_Libres.Rows.Remove( /*ex-*/Producto_Libre);
                        }
                        if (Se_Esta_Editando_Plantilla)
                        {
                                int Indice_Producto_Seleccionado = Grilla_Derecha.Rows.Add();
                                for (int Indice_Columna = 0; Indice_Columna < Grilla_Izquierda.Columns.Count; Indice_Columna++) { Grilla_Derecha.Rows[Indice_Producto_Seleccionado].Cells[Indice_Columna].Value = Fila_Grilla_Izquierda.Cells[Indice_Columna].Value; }
                                Grilla_Izquierda.Rows.Remove(Fila_Grilla_Izquierda);
                        }
                }
                /// <summary>Mueve una fila de la grilla derecha a la grilla izquierda manejando el `Estado` del form de manera interna.</summary>
                /// <param name="Indice_Fila_Derecha">El indice de la fila de la fila derecha.</param>
                void Mover_Fila_Derecha_A_Izquierda(int Indice_Fila_Derecha)
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
                        Producto_Lote = DataTable_Productos_Seleccionados.Rows[Indice_Fila_Derecha];

                        ((DataTable)Grilla_Izquierda.DataSource).ImportRow(Producto_Lote);

                        // Remueve el Producto de la grilla de Productos seleccionados
                        if (Se_Esta_Editando_Entidad) { ((DataTable)Grilla_Derecha.DataSource).Rows.Remove(Producto_Lote); }
                        if (Se_Esta_Editando_Plantilla) { Grilla_Derecha.Rows.Remove(DataGridViewRow_Producto_Lote); }
                }

                // Quitar filas
                void Quitar_Fila_Derecha(int Indice_Fila)
                {
                        DataRow Fila = ((DataTable)Grilla_Derecha.DataSource).Rows[Indice_Fila];
                        ((DataTable)Grilla_Derecha.DataSource).Rows.Remove(Fila);
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
                # region >>---- Dinamicas de la seleccion de `Momento`
                /// <summary>
                /// Pone las fechas minimas de los controles a las adecuadas.
                /// Si se esta trabajando con fechas pasadas, setea el minimo al minimo de los controles.
                /// De lo contrario setea el minimo a la fecha actual
                /// </summary>
                /// <param name="Invertir_Checkbox">
                /// Indica si se lanza desde dentro del evento del checkbox click, el cual no actualiza el valor del checkbox por si mismo.
                /// Por ende, si se lanza desde dentro de tal evento, el checkbox tiene el valor que tenia justo antes de ser clickado.
                /// </param>
                void Adecuar_Fechas_Minimas( bool El_Checkbox_Esta_Siendo_Clickado )
                {
                        bool Permitir_Fechas_Pasadas = CheckBox_Permitir_Fechas_Pasadas.Checked ;
                        if ( El_Checkbox_Esta_Siendo_Clickado ) { Permitir_Fechas_Pasadas = ! Permitir_Fechas_Pasadas ; }

                        if ( Permitir_Fechas_Pasadas ) { Calendar_Momento.MinDate = Minimo_MonthCalendar ; }
                        else { Calendar_Momento.MinDate = DateTime.Now.Date ; }
                }

                /// <summary>
                /// Deterina si la fecha nueva es valida.
                /// El parametro "Abortar_Ejecucion" indica si se deberia continuar con el flujo de la funcion que llama a esta.
                /// Devuelve false en caso de que se no se permitan fechas pasadas y se haya seleccionado una.
                /// </summary>
                ///
                ///
                void Validar_Nueva_Fecha( DateTime Nuevo_Momento, Fallos_Fecha Fallo_Nueva_Fecha, out bool Abortar_Ejecucion )
                {
                        switch ( Fallo_Nueva_Fecha )
                        { 
                                case Fallos_Fecha.Ninguno: Abortar_Ejecucion = false ; break ;
                                case Fallos_Fecha.Inferior_Al_Minimo_Teorico:
                                        Mostrar_MessageBox_Fecha_Inferior_Minimo_Teorico() ;
                                        Rollback_Momento_Sin_Disparar_Eventos() ;
                                        Abortar_Ejecucion = true ;
                                        return ;
                                case Fallos_Fecha.No_Es_Coherente_Con_El_Otro_Momento:
                                        Mostrar_MessageBox_Rango_Invalido( Nuevo_Momento, ( DropDownList_Seleccion_Momento.Text == "Momento de Inicio" ) ) ;
                                        Rollback_Momento_Sin_Disparar_Eventos() ;
                                        Abortar_Ejecucion = true ;
                                        return ;
                                case Fallos_Fecha.Precede_Momento_Actual:
                                        if ( Mostrar_MessageBox_Continuar_Operacion() != DialogResult.OK ) { Abortar_Ejecucion = true ; return ; }
                                        Abortar_Ejecucion = false ;
                                        return ;
                                default: Abortar_Ejecucion = false ; break ; // Esto pa que C# no joda.
                        }
                }
                
                private void DropDownList_Seleccion_Momento_SelectedIndexChanged(object sender, EventArgs e)
                {
                        // Antes de setear los valores hay que ver la fecha minima
                        // Si se esta trabajando con fechas pasadas, las fechas minimas deben ser las minimas de los controles
                        // De lo contrario la fecha minima debe ser el momento actual
                        
                        // Validar_Nueva_Fecha() ;
                        Adecuar_Fechas_Minimas( El_Checkbox_Esta_Siendo_Clickado: false ) ;

                        DateTime Momento = new DateTime();
                        switch (DropDownList_Seleccion_Momento.Text)
                        {
                                case "Momento de Inicio": Momento = Momento_Inicio; break;
                                case "Momento de Fin": Momento = Momento_Fin; break;
                        }
                        // Calendar_Momento.SetDate((Momento.Date < Calendar_Momento.MinDate.Date) ? Calendar_Momento.MinDate.Date : Momento.Date);
                        Calendar_Momento.SetDate( Momento.Date ) ;
                        TimePicker_Hora_Momento.Text = Momento.ToString("HH:mm");

                        if ( DropDownList_Seleccion_Momento.Text == "Momento de Inicio" ) { Momento_Incio_Anterior = Momento ; }
                        else { Momento_Fin_Anterior = Momento ; }
                }

                void Mostrar_MessageBox_Rango_Invalido(DateTime Momento, bool Es_Momento_Inicio)
                {
                        MessageBox.Show
                        (
                                caption: "El plazo del Remate es invalido.",
                                text: $"El momento de fin `{((!Es_Momento_Inicio) ? Momento.ToString("dd/MM/yyyy HH:mm") : Momento_Fin.ToString("dd/MM/yyyy HH:mm"))}`" +
                                $" es inferior al momento de inicio `{((Es_Momento_Inicio) ? Momento.ToString("dd/MM/yyyy HH:mm") : Momento_Inicio.ToString("dd/MM/yyyy HH:mm"))}` no se puede seleccionar este momento.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }

                enum Fallos_Fecha
                { 
                        Inferior_Al_Minimo_Teorico,
                        No_Es_Coherente_Con_El_Otro_Momento,
                        Precede_Momento_Actual,
                        Ninguno
                }
                Fallos_Fecha Nueva_Fecha_Es_Valida(ref DateTime Nuevo_Momento, bool Las_Fechas_Pasadas_Son_Permitidas )
                {
                        string Tipo_Momento_Seleccionado = DropDownList_Seleccion_Momento.Text ;
                 
                        if ( Nuevo_Momento.Date < Minimo_MonthCalendar.Date ) { return Fallos_Fecha.Inferior_Al_Minimo_Teorico ; }
                        // No es necesario checkear por el maximo
                        if ( Tipo_Momento_Seleccionado == "Momento de Inicio" && Las_Fechas_Pasadas_Son_Permitidas )
                        {
                                if ( Nuevo_Momento.Date > Momento_Fin.Date ) { return Fallos_Fecha.No_Es_Coherente_Con_El_Otro_Momento ; }
                        }
                        if ( Tipo_Momento_Seleccionado == "Momento de Inicio" && ! Las_Fechas_Pasadas_Son_Permitidas )
                        {
                                if ( Nuevo_Momento.Date < DateTime.Now.Date ) { return Fallos_Fecha.Precede_Momento_Actual ; }
                        }
                        if ( Tipo_Momento_Seleccionado == "Fecha de Fin" && Nuevo_Momento.Date < Momento_Inicio.Date ) { return Fallos_Fecha.No_Es_Coherente_Con_El_Otro_Momento ; }
                        return Fallos_Fecha.Ninguno ;
                }

                // Dialogos sobre cambios de tiempo
                void Mostrar_MessageBox_Se_Cambiara_Fecha_Minima()
                { 
                        MessageBox.
                        Show
                        (
                                caption: $"La fecha del {DropDownList_Seleccion_Momento.Text} será actualizada.",
                                text: "La fecha del momento seleccionado es menor a la fecha mínimia actual.\n" +
                                      "Se bajará la fecha minima minima actual para trabajar con el valor.",
                                icon: MessageBoxIcon.Warning,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Fecha_Inferior_Minimo_Teorico()
                { 
                        MessageBox.Show
                        (
                                caption: "La fecha seleccionada es demasiado baja.",
                                text: "Bro, no.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        ) ;
                }
                DialogResult Mostrar_MessageBox_Continuar_Operacion()
                {
                        return
                        MessageBox.Show
                        (
                                caption: $"La fecha del {DropDownList_Seleccion_Momento.Text} será actualizada.",
                                text: $"Se deseleccionó la opción para permitir fechas pasadas.\n" +
                                $"Se actualizará la fecha del de {Calendar_Momento.SelectionRange.Start.ToString("dd/MM/yyyy")} a la fecha actual( {DateTime.Now.ToString("dd/MM/yyyy")} ).",
                                icon: MessageBoxIcon.Warning,
                                buttons: MessageBoxButtons.OKCancel,
                                owner: this
                        ) ;
                }

                private void CheckBox_Permitir_Fechas_Pasadas_Click(object sender, EventArgs e)
                {
                        // Advertencia, como la propiedad autocheck esta deshabilitada...
                        // El checked del checkbox representa el valor que tiene en el momento en el que el usuario toco el boton. No despues de eso.
                        // Mientras que normalmente, cuando accedes a el campo, este ya tiene el valor opuesto al que tenia cuando el usuario le dio
                        // click.
                        bool Las_Fechas_Pasadas_Son_Permitidas = ! CheckBox_Permitir_Fechas_Pasadas.Checked ;
                        
                        DateTime Momento = new DateTime();
                        switch (DropDownList_Seleccion_Momento.Text)
                        {
                                case "Momento de Inicio": Momento = Momento_Inicio; break;
                                case "Momento de Fin": Momento = Momento_Fin; break;
                        }
                        Fallos_Fecha Fallo_Nueva_Fecha = Nueva_Fecha_Es_Valida(ref Momento, Las_Fechas_Pasadas_Son_Permitidas ) ;
                        Validar_Nueva_Fecha( Momento, Fallo_Nueva_Fecha, out bool Abortar_Ejecucion ) ;
                        if ( Abortar_Ejecucion ) { return ; }
                        
                        Adecuar_Fechas_Minimas( El_Checkbox_Esta_Siendo_Clickado: true ) ;
                        CheckBox_Permitir_Fechas_Pasadas.Checked = (!CheckBox_Permitir_Fechas_Pasadas.Checked);
                }

                DateTime Momento_Incio_Anterior = new DateTime() ;
                DateTime Momento_Fin_Anterior = new DateTime() ;
                private void TimePicker_Hora_Momento_ValueChanged(object sender, EventArgs e) { Actualizar_Momento(); }
                private void Calendar_Momento_DateChanged(object sender, DateRangeEventArgs e)
                {
                        // Por motivos desconocidos al calendario le apetece actualizarse de la nada cada 2 minutos o asi.
                        // Microsoft haciendo bien su trabajo para variar. Asi que se supone que cuando eso ocurra se activa
                        // esta clausula guardian y el progroama no muere basicamente.
                        if ( Momento_Inicio == Momento_Incio_Anterior && Momento_Fin == Momento_Fin_Anterior ) { return ; }
                        Actualizar_Momento(); 
                        
                }                                                                                                         // Hay un error que hace que cuando cambias el mes, el evento se dispare dos veces, esto ocurria en versiones anteriores a VS2010, parece que nunca fue arreglado o algo.
                void Rollback_Momento_Sin_Disparar_Eventos()                                                              // Aun asi, el form deberia funcionar de igual forma, ya que el valor de la fecha del calendario no cambia, lo que va a ocurrir es que se va a asignar dos veces cuando se use el boton de cambiar mes.
                {                                                                                                         // La verdad me da igual para reporparlo. Es el ultimo de mis problemas.
                        // Dehabilita temporalmente los eventos
                        Calendar_Momento.DateChanged -= Calendar_Momento_DateChanged;
                        TimePicker_Hora_Momento.ValueChanged -= TimePicker_Hora_Momento_ValueChanged;
                        if ( DropDownList_Seleccion_Momento.Text == "Momento de Inicio")
                        {
                                Calendar_Momento.SetDate(Momento_Inicio.Date);
                                TimePicker_Hora_Momento.Text = Momento_Inicio.ToString("HH:mm");
                        }
                        if ( DropDownList_Seleccion_Momento.Text == "Momento de Fin")
                        {
                                Calendar_Momento.SetDate(Momento_Fin.Date);
                                TimePicker_Hora_Momento.Text = Momento_Fin.ToString("HH:mm");
                        }
                        // Habilita los eventos de nuevo
                        Calendar_Momento.DateChanged += Calendar_Momento_DateChanged;
                        TimePicker_Hora_Momento.ValueChanged += TimePicker_Hora_Momento_ValueChanged;
                }

                void Actualizar_Momento()
                {
                        if (TimePicker_Hora_Momento.Text == "") { return; }

                        string Fecha_Momento = Calendar_Momento.SelectionRange.Start.ToString("dd-MM-yyyy");
                        string Hora_Momento = TimePicker_Hora_Momento.Text;
                        DateTime Momento = Convert.ToDateTime((Fecha_Momento + ' ' + Hora_Momento));

                        switch (DropDownList_Seleccion_Momento.Text)
                        {
                                case "Momento de Inicio":
                                        if (Momento > Momento_Fin)
                                        {
                                                Mostrar_MessageBox_Rango_Invalido(Momento, Es_Momento_Inicio: true);
                                                Rollback_Momento_Sin_Disparar_Eventos();
                                                return;
                                        }
                                        Momento_Inicio = Momento;
                                        break;
                                case "Momento de Fin":
                                        if (Momento < Momento_Inicio)
                                        {
                                                Mostrar_MessageBox_Rango_Invalido(Momento, Es_Momento_Inicio: false);
                                                Rollback_Momento_Sin_Disparar_Eventos();
                                                return;
                                        }
                                        Momento_Fin = Momento;
                                        break;
                        }
                }
                # endregion
                # region >>---- Dinamicas de seleccion de Categoria
                string Anterior_Categoria_Seleccionada = "";
                private void DropDownList_Tipo_SelectedIndexChanged(object sender, EventArgs e)
                {
                        // Se encarga de que los integrantes del Lote sean coherentes con la categoria del mismo
                        // ----------------------------------------------------------------------------------------------
                        // Se encarga de que los posibles integrantes del Lote sean coherentes con la categoria del mismo
                        // ----------------------------------------------------------------------------------------------

                        bool Hay_Elementos_Invalidos()
                        { // Compureba si hay elementos incompatibles
                                string Tipo_Elemento_Compatible = "";
                                switch (Categoria)
                                {
                                        case "Animales": Tipo_Elemento_Compatible = "Animal"; break;
                                        case "Maquinaria": Tipo_Elemento_Compatible = "Maquinaria"; break;
                                }

                                foreach (DataGridViewRow Elemento in Grilla_Integrantes_Remate.Rows)
                                {
                                        if (Elemento.Cells["Tipo_Producto"].Value.ToString() != Tipo_Elemento_Compatible)
                                        {
                                                return true;
                                                break;
                                        }
                                }
                                return false;
                        }
                        if (Form_Esta_Vacio) { return; }
                        if (Categoria == Anterior_Categoria_Seleccionada) { return; }

                        if (Categoria != "Ninguna" && Hay_Elementos_Invalidos())
                        {
                                DialogResult Respuesta_Usuario =
                                MessageBox.Show
                                (
                                        caption: "Hay elementos incompatibles con la nueva categoria.",
                                        text: $"Se encontraron elementos del Tipo {Anterior_Categoria_Seleccionada} despues de seleccionar la categoria {Categoria}.\n" +
                                               "Estos elementos serán expulsados del Remate y podrás seguir editando.",
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
                                        for (int Indice_Fila = Grilla_Derecha.Rows.Count - 1; Indice_Fila >= 0; Indice_Fila--)
                                        {
                                                string Tipo_Actual = "";
                                                switch (Categoria)
                                                {
                                                        case "Animales": Tipo_Actual = "Animal"; break;
                                                        case "Maquinaria": Tipo_Actual = "Maquinaria"; break;
                                                }

                                                DataGridViewRow Elemento = Grilla_Derecha.Rows[Indice_Fila];
                                                if (Elemento.Cells["Tipo_Producto"].Value.ToString() != Tipo_Actual) { Quitar_Fila_Derecha(Indice_Fila); }
                                        }
                                }
                        }
                        Anterior_Categoria_Seleccionada = Categoria;
                        Actualizar_Estado_Grillas(Cargar_Atributos_Remate: false, Mostrar_Aviso_No_Quedan_Elementos: true);
                }
                private void DropDownList_Tipo_MouseWheel(object sender, MouseEventArgs e) { ((HandledMouseEventArgs)e).Handled = true; }

                void Cambiar_Categoria_Sin_Disparar_Evento(string Nueva_Categoria)
                {
                        // Esto es medio MMMMHHHHH pero ta.
                        DropDownList_Tipo.SelectedIndexChanged -= DropDownList_Tipo_SelectedIndexChanged;
                        Categoria = Nueva_Categoria;
                        DropDownList_Tipo.SelectedIndexChanged += DropDownList_Tipo_SelectedIndexChanged;
                }
                # endregion
                # region >>---- Dinamicas de estado de los Remates y ELementos(grillas, atributos, etc)
                void Actualizar_Label_Numero_Remate() { Label_ID_Remate_Actual.Text = "ID del Remate actual = " + ((ID_Remate_Actual is not null) ? ID_Remate_Actual : "@ID_Remate"); }

                void Actualizar_Informacion_Remate(int ID_Remate, bool Cargar_Atributos_Remate, bool Autoasignar_Categoria_Remate) // En realidad seria mas como "Mostrar representacion Remate" pero ta
                {
                        // No voy a checkar que el Lote existe, esi deberia se manejado en un orden superior

                        // Asegura los discriminantes del estado `Lote`.
                        Limpiar_Columnas_Grilla_Derecha(Columnas_DataViewGrid: true);
                        Actualizar_Label_Numero_Remate();
                        Poner_Cabecera_Grilla_Derecha(Modo_Plantilla: false);

                        if (Cargar_Atributos_Remate)
                        { // Cargar los atributos del Remate
                                Dictionary<string, object>? Atributos_Remate = Procesamiento_Remates.Marshal_Get_Remate(ID_Remate);

                                Momento_Inicio = ((DateTime)Atributos_Remate!["Momento_Inicio"]);
                                Momento_Fin = ((DateTime)Atributos_Remate["Momento_Fin"]);
                                Categoria = Atributos_Remate["Categoria"].ToString()!;
                                Metodo_Pago = Atributos_Remate["Metodo_Pago"].ToString()!;
                        }
                        { // Actualiza los controles de Momento 
                                DropDownList_Seleccion_Momento.Text = "Momento de Inicio";
                                DropDownList_Seleccion_Momento_SelectedIndexChanged(this, EventArgs.Empty);  // No se lanza solo nc
                        }
                        if (Categoria == (Procesamiento_Remates.Marshal_Get_Remate(ID_Remate)!)["Categoria"].ToString() || Categoria == "Ninguna")
                        { // Popular la grilla con los Elementos que pertenecen al Remate.
                                DataTable? Elementos_Remate = Procesamiento_Remates.Marshal_Get_Integrantes_Remate(ID_Remate);

                                if (Elementos_Remate is null) { return; }
                                Grilla_Derecha.DataSource = Elementos_Remate; // Si en algun momento uso el SelectionChanged, esto podria volverse inviable.
                                Grilla_Derecha.Refresh();
                        }
                        Grilla_Derecha.ClearSelection();
                        // Nota:
                        // Si alguien (incluido yo) fuera a refactorizar este codigo... Sea conciente que el bloque que popula la grilla con Productos utiliza un early return.
                        // Debido a que es un bloque y no una funcion, el return termina toda la funcion. En el orden en que estan lo bloques esto no es un problema, ya que el
                        // fin de ese bloque tambien es el fin de la funcion, ya que no se ejecuta nada mas despues del bloque, pero si esto se cambia, el early return evitara
                        // la ejecucion de las siguientes partes de la funcion.
                }
                void Actualizar_Grilla_Izquierda(string Categoria_Remate, bool Mostrar_Aviso_No_Quedan_Elementos = false)
                {
                        DataTable? Elementos_Subastables = (DataTable?)
                        Procesamiento_Remates.Marshal_Get_Elementos_Subastables(Categoria_Remate);

                        if (Elementos_Subastables is null)
                        {
                                if (Mostrar_Aviso_No_Quedan_Elementos)
                                {
                                        MessageBox.Show
                                        (
                                                caption: "No hay elementos libres",
                                                text: $"Actualmente no se encontraró en el sistema elementos habilitados {((Categoria_Remate != "Ninguna") ? $"del tipo `{Categoria_Remate}`" : "")}.",
                                                icon: MessageBoxIcon.Error,
                                                buttons: MessageBoxButtons.OK,
                                                owner: this
                                        );
                                }

                                { // Mostrar grilla izquierda vacia
                                        Grilla_Elementos_Disponibles.AllowUserToAddRows = true;
                                        if (Grilla_Elementos_Disponibles.DataSource is not null && Grilla_Elementos_Disponibles.Rows.Count != 0)
                                        {
                                                ((DataTable)Grilla_Elementos_Disponibles.DataSource).Rows.Clear();
                                                return;
                                        }
                                        Grilla_Elementos_Disponibles.Columns.Add("ID", "ID");
                                        Grilla_Elementos_Disponibles.Columns.Add("Tipo_Elemento", "Tipo_Elemento");
                                        Grilla_Elementos_Disponibles.Columns.Add("Nombre", "Nombre");
                                        Grilla_Elementos_Disponibles.Columns.Add("Valor", "Valor");
                                        Grilla_Elementos_Disponibles.Columns.Add("Precio_Base", "Precio_Base");
                                        Grilla_Elementos_Disponibles.Columns.Add("Categoria_Lote", "Categoria_Lote");
                                        Grilla_Elementos_Disponibles.Columns.Add("Tipo_Producto", "Tipo_Producto");
                                        Grilla_Elementos_Disponibles.Columns.Add("Descripcion", "Descripcion");
                                }
                                return;
                        }
                        Grilla_Elementos_Disponibles.DataSource = null;
                        Grilla_Elementos_Disponibles.Columns.Clear();
                        Grilla_Elementos_Disponibles.DataSource = Elementos_Subastables;
                        Grilla_Elementos_Disponibles.AllowUserToAddRows = false;
                        Grilla_Elementos_Disponibles.ClearSelection();
                }
                void Actualizar_Estado_Grillas(bool Cargar_Atributos_Remate, bool Modo_Plantilla_Remate = false, bool Mostrar_Aviso_No_Quedan_Elementos = false, bool Autoseleccionar_Categoria_Remate = false)
                { // Actualizar los Productos del Lote
                        if (Modo_Plantilla_Remate) { Activar_Plantilla_Remate(); }
                        if (!Modo_Plantilla_Remate && !Se_Esta_Editando_Plantilla) { Actualizar_Informacion_Remate((int)ID_Remate_Actual!, Cargar_Atributos_Remate, Autoseleccionar_Categoria_Remate); }
                        Button_Modificar.Enabled = (Button_Eliminar.Enabled = (!Se_Esta_Editando_Plantilla));
                        Actualizar_Grilla_Izquierda(Categoria_Remate: Categoria, Mostrar_Aviso_No_Quedan_Elementos);
                }

                void Activar_Plantilla_Remate()
                {
                        ID_Remate_Actual = null;
                        Grilla_Derecha.DataSource = null;

                        { // Re-inicia la informacion del formulario
                                Actualizar_Label_Numero_Remate();
                                Momento_Fin = (Momento_Inicio = DateTime.Now);
                                DropDownList_Seleccion_Momento.Text = "Momento de Inicio";
                                CheckBox_Permitir_Fechas_Pasadas.Checked = false;
                        }
                        Poner_Cabecera_Grilla_Derecha(Modo_Plantilla: true);
                }
                # endregion
                # region >>---- Dinamicas de seleccion de Remates
                private void Buscar_Por_Elemento_Click(object sender, EventArgs e)
                {
                        Buscar_Por_Elemento Form_Busqueda = new Buscar_Por_Elemento();
                        Form_Busqueda.ShowDialog(owner: this);

                        if (Form_Busqueda.ID_Remate_De_Elemento is null) { return; }
                        TextBox_ID.Text = ((int)Form_Busqueda.ID_Remate_De_Elemento).ToString();
                        Button_Ir_A_ID.PerformClick();
                }

                string Respaldo_Text = "";
                private void TextBox_ID_TextChanged(object sender, EventArgs e)
                { // Se asegura de que el contenido ingresado al textbox sea solo numeros.
                        foreach (char Caracter in TextBox_ID.Text)
                        {
                                if (!char.IsDigit(Caracter))
                                {
                                        TextBox_ID.Text = Respaldo_Text; // Cuando esto ocurre el cursor es movido al principio del texto.
                                        TextBox_ID.SelectionStart = TextBox_ID.Text.Length; // Pone el cursor al final del texto.
                                        TextBox_ID.ScrollToCaret(); // Si por algun motivo el texto es mas largo que el ancho del TextBox, scrollea(desliza) el texto del TextBox hasta el cursor.
                                        return;
                                }
                        }
                        Respaldo_Text = TextBox_ID.Text;

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
                private void Button_Ir_A_ID_Click(object sender, EventArgs e)
                {
                        if (TextBox_ID.Text == "")
                        {
                                TextBox_ID.Focus();
                                return;
                        }
                        int ID_Remate = Convert.ToInt32(TextBox_ID.Text);

                        if (!Procesamiento_Remates.Marshal_Remate_Existe(ID_Remate))
                        {
                                MessageBox.Show
                                (
                                        caption: "No se encontro el Remate",
                                        text: $"No se ha encontrado un Remate para la ID `{ID_Remate}`.",
                                        icon: MessageBoxIcon.Error,
                                        buttons: MessageBoxButtons.OK,
                                        owner: this
                                );
                                return;
                        }

                        if (Procesamiento_Remates.Remate_Ya_Ocurrio(ID_Remate))
                        {
                                if (
                                MessageBox.Show
                                (
                                        caption: "El Remate seleccionado ya ocurrió.",
                                        text: "La fecha de fin del Remate seleccionado ya ha expirado.\n" +
                                              "Se editará el Remate de todos modos.",
                                        icon: MessageBoxIcon.Warning,
                                        buttons: MessageBoxButtons.OKCancel,
                                        owner: this
                                ) != DialogResult.OK) { return; }
                        }

                        ID_Remate_Actual = ID_Remate;
                        Actualizar_Estado_Grillas(Cargar_Atributos_Remate: true, Autoseleccionar_Categoria_Remate: true);
                }
                private void TextBox_ID_KeyPress(object sender, KeyPressEventArgs e) { if (((Keys)e.KeyChar) == Keys.Enter) { Button_Ir_A_ID.PerformClick(); } }
                #endregion
                #region >>---- Paso de filas de una grilla a la otra
                private void Button_Derecha_Click(object sender, EventArgs e)
                {
                        // Depende de poder clickar cuando hay un estado otro que `Form vacio`
                        if (Grilla_Izquierda.SelectedRows.Count == 0) { return; }
                        foreach (DataGridViewRow Fila in Grilla_Izquierda.SelectedRows) { if (Fila.IsNewRow) { return; } }

                        foreach (DataGridViewRow Producto_Libre in Grilla_Izquierda.SelectedRows) { Mover_Fila_De_Izquierda_A_Derecha(Producto_Libre); }
                        Grilla_Izquierda.ClearSelection();
                        if (Grilla_Derecha.Rows.Count == 1) { Grilla_Derecha.ClearSelection(); }
                }
                private void Button_Izquierda_Click(object sender, EventArgs e)
                {
                        if (Grilla_Derecha.SelectedRows.Count == 0) { return; }

                        for (int Indice_Fila = Grilla_Derecha.SelectedRows.Count - 1; Indice_Fila > -1; Indice_Fila--) { Mover_Fila_Derecha_A_Izquierda(Indice_Fila); }
                        Grilla_Derecha.ClearSelection();
                        if (Grilla_Izquierda.Rows.Count == 1) { Grilla_Izquierda.ClearSelection(); }
                }

                // Pasar una fila al otro lado con doble click
                private void Grilla_Izquierda_MouseDoubleClick(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { Button_Derecha.PerformClick(); } }
                private void Grilla_Derecha_MouseDoubleClick(object sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { Button_Izquierda.PerformClick(); } }

                // Habilitar botones cuando hay una o mas filas seleccionadas
                private void Grilla_Izquierda_SelectionChanged(object sender, EventArgs e)
                {
                        Button_Derecha.Enabled = (Grilla_Elementos_Disponibles.SelectedRows.Count > 0);
                        foreach (DataGridViewRow Fila in Grilla_Elementos_Disponibles.SelectedRows) { if (Fila.IsNewRow) { Button_Derecha.Enabled = false; } }
                }
                private void Grilla_Derecha_SelectionChanged(object sender, EventArgs e)
                {
                        Button_Izquierda.Enabled = (Grilla_Derecha.SelectedRows.Count > 0);
                        foreach (DataGridViewRow Fila in Grilla_Derecha.SelectedRows) { if (Fila.IsNewRow) { Button_Izquierda.Enabled = false; } }
                }
                #endregion
                #region >>---- Dinamicas de los Controles(Gestion de los Remates)
                private void Button_Crear_Click(object sender, EventArgs e)
                {
                        if (!Se_Esta_Editando_Plantilla) { goto Crear_Plantilla_Nuevo_Remate; }
                        else { goto Concretar_Creacion_Remate; }

                //------------------------------------------------------------------------------
                Crear_Plantilla_Nuevo_Remate: //--------------------------------------------------
                        if ((
                        MessageBox.Show
                        (
                                caption: "Se creará un Lote vacío",
                                text: "A continuación se creará una plantilla de un nuevo Lote vacío.\n" +
                                      "Los cambios no se guardaran hasta que pongas Productos en el Lote y presiones el botón `Crear` nuevamente." +
                                ((ID_Remate_Actual is not null) ? "\nPD: Los cambios no guardados en el Lote actual se perderán." : ""),
                                icon: MessageBoxIcon.Question,
                                buttons: MessageBoxButtons.OKCancel,
                                owner: this
                        ))
                                != DialogResult.OK) { return; }
                        Actualizar_Estado_Grillas(Cargar_Atributos_Remate: false, Modo_Plantilla_Remate: true, Mostrar_Aviso_No_Quedan_Elementos: true);
                        return;
                Concretar_Creacion_Remate: //-----------------------------------------------------
                        object[] ID_Elementos = (new object[] { });
                        Recompilar_Informacion_Remate(ref ID_Elementos);

                        if (Momento_Fin < DateTime.Now)
                        { // Construir y mostrar advertencia sobre atributos del Remate.
                                if ((
                                MessageBox.Show
                                (
                                        caption: "Se creará un Remate donde su momento de inicio o fin esta en el pasado.",
                                        text: $"Se indicó que el Remate comenzaria en el momento {Momento_Inicio.ToString("dd/MM/yyyy HH:mm")} y terminaria en el momento {Momento_Fin.ToString("dd/MM/yyyy HH:mm")}.\n" +
                                               "Se creará un Remate con tales atributos.",
                                        icon: MessageBoxIcon.Warning,
                                        buttons: MessageBoxButtons.OKCancel,
                                        owner: this
                                )
                                  != DialogResult.OK)) { return; }
                        }

                        int ID_Remate_Creado = ((int)Procesamiento_Remates.Crear_Remate(Momento_Inicio, Momento_Fin, Categoria, Metodo_Pago.Replace(' ', '_'), ID_Elementos, Devolver_ID_Remate: true)!);
                        ID_Remate_Actual = ID_Remate_Creado;
                        Actualizar_Estado_Grillas(Cargar_Atributos_Remate: true, Mostrar_Aviso_No_Quedan_Elementos: false, Autoseleccionar_Categoria_Remate: true);
                        Reproducir_Tono_Producto_Guardado();
                        return;
                }
                private void Button_Modificar_Click(object sender, EventArgs e)
                {
                        if (ID_Remate_Actual is null) { throw new InvalidOperationException("Se intento lleva a cabo la modificaciond de un Remate mientras no habia ningun remate selccionado."); }

                        object[] ID_Elementos_Remate = (new object[] { });
                        Recompilar_Informacion_Remate
                        (
                                ref ID_Elementos_Remate
                        //ref Momento_Inicio,
                        //ref Momento_Fin,
                        //ref Categoria
                        );
                        Procesamiento_Remates.Gestionar_Remates
                        (
                                Operacion_Gestion.Modificacion,
                                ((int)ID_Remate_Actual!),
                                ID_Elementos_Remate,
                                Momento_Inicio,
                                Momento_Fin,
                                Categoria,
                                Metodo_Pago.Replace(' ', '_')
                        );
                        Actualizar_Estado_Grillas(Cargar_Atributos_Remate: true, Autoseleccionar_Categoria_Remate: true, Mostrar_Aviso_No_Quedan_Elementos: false);
                        Reproducir_Tono_Modificado();
                }
                private void Button_Eliminar_Click(object sender, EventArgs e)
                {
                        if (ID_Remate_Actual is null) { throw new InvalidOperationException("Se intento lleva a cabo la baja de un Remate mientras no habia ningun Remate selccionado."); }

                        Procesamiento_Remates.Gestionar_Remates
                        (
                                Operacion_Gestion.Baja,
                                ID_Remate_Actual,
                                (new object[] { }),
                                (new DateTime()),
                                (new DateTime()),
                                "",
                                ""
                        );
                        Actualizar_Estado_Grillas(Cargar_Atributos_Remate: false, Modo_Plantilla_Remate: true, Mostrar_Aviso_No_Quedan_Elementos: false);
                        Reproducir_Tono_Producto_Eliminado();
                }
                void Recompilar_Informacion_Remate
                (
                        ref object[] ID_Elementos_Remate
                        //ref DateTime Momento_Inicio_Remate,
                        //ref DateTime Momento_Fin_Remate,
                        //ref string Categoria_Remate,
                        //ref string Metodo_Pago_Remate
                )
                {
                        // Recompila las ID de los Elementos de Subasta
                        ID_Elementos_Remate = new object[Grilla_Integrantes_Remate.Rows.Count];
                        for (int Indice_Elemento = 0; Indice_Elemento < ID_Elementos_Remate.Length; Indice_Elemento++)
                        {
                                DataGridViewCellCollection Valores_Elemento = Grilla_Integrantes_Remate.Rows[Indice_Elemento].Cells;
                                ID_Elementos_Remate[Indice_Elemento] = Convert.ToInt32( Valores_Elemento["ID"].Value ) ;
                        }
                        //Momento_Inicio_Remate = Momento_Inicio ;
                        //Momento_Fin_Remate = Momento_Fin ;
                        //Categoria_Remate = Categoria ;
                        //Metodo_Pago_Remate = Metodo_Pago ;
                }

                #endregion
        }

        public static class Metodos_Extension_Y_Otros
        {
                public static string GetString(this DateTime Momento) { string Hola = Momento.ToString("dd-MM-yyyy yyyy HH:mm"); return Momento.ToString("dd-MM-yyyy yyyy HH:mm"); }
                public static string GetHora(this DateTime Momento) { return Momento.GetString().Substring(11); }

                public static DateTime NewDateTimeNuevaHora(DateTime Momento, string Nueva_Hora)
                {
                        DateTime Nuevo_Momento = Momento;
                        { // Setea la hora del Momento a cero
                                Nuevo_Momento = Nuevo_Momento.AddSeconds(-Momento.Second);
                                Nuevo_Momento = Nuevo_Momento.AddMinutes(-Momento.Minute);
                                Nuevo_Momento = Nuevo_Momento.AddHours(-Momento.Hour);
                        }

                        TimeOnly Hora_NuevoMomento;
                        try { Hora_NuevoMomento = TimeOnly.Parse(Nueva_Hora); } catch { throw new ArgumentException("No se pudo convertir el argumento NuevaHora en un TimeOnly, el formato debe ser incorrecto."); }
                        { // Setea la hora del Momento
                                Nuevo_Momento = Nuevo_Momento.AddHours(Hora_NuevoMomento.Hour);
                                Nuevo_Momento = Nuevo_Momento.AddMinutes(Hora_NuevoMomento.Minute);
                        }
                        return Nuevo_Momento;
                }
        }
}
