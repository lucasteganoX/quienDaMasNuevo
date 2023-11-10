# define DEBUG_Gestion_Productos
# define DEBUG_Seleccion_Fotos

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica.Sistema_de_cosas_a_subastar;
using Logica.Gestion_Productos;
using Presentacion.Gestion_Productos.Tipado_Productos;
using System.Media;

namespace Presentacion.Gestion_Productos
{
        public partial class Gestion_Productos : Form
        {
                bool Modo_Publicacion_Proveedor { get { return (ID_Proveedor is not null); } }
                int? ID_Proveedor = null;

                bool Hay_Un_Producto_Cargado = false;
                byte[][]? Fotos_Producto = null;

                int? ID_Producto
                {
                        get
                        {
                                if ( ! Form_Cargado ) { return null ; }
                                return ( int? ) Grilla_Productos.SelectedRows[0].Cells["ID"].Value ;
                        }
                }

                bool Form_Vacio
                { 
                        get
                        {
                                if ( Grilla_Productos.DataSource is not null ) { return false ; }
                                if ( Grilla_Productos.Columns.Count != 0 ) { return false ; }
                                if ( Grilla_Productos.Rows.Count != 0 ) { return false ; }
                                return true ;
                        }
                }
                bool Form_Pelado
                { 
                        get
                        { 
                                if ( Grilla_Productos.DataSource is null ) { return false ; }
                                if ( Grilla_Productos.Columns.Count == 0 ) { return false ; }
                                if ( Grilla_Productos.Rows.Count != 0 ) { return false ; }
                                return true ;
                        }        
                }
                bool Form_Descargado
                { 
                        get
                        { 
                                if ( Grilla_Productos.DataSource is null ) { return false ; }
                                if ( Grilla_Productos.Columns.Count == 0 ) { return false ; }
                                if ( Grilla_Productos.Rows.Count != 0 ) { return false ; }
                                if ( Grilla_Productos.SelectedRows.Count != 0 ) { return false ; }
                                return true ;
                        }
                }
                bool Form_Cargado
                { 
                        get
                        { 
                                if ( Grilla_Productos.DataSource is null ) { return false ; }
                                if ( Grilla_Productos.Columns.Count == 0 ) { return false ; }
                                if ( Grilla_Productos.Rows.Count == 0 ) { return false ; }
                                if ( Grilla_Productos.SelectedRows.Count != 1 ) { return false ; }
                                return true ;
                        }
                }

                Gestion_Productos_Ver_Fotos? Formulario_Ver_Fotos;
                Gestion_Productos_Quitar_Fotos Formulario_Quitar_Fotos;
                Gestion_Productos_Tipado_Animal Formulario_Tipado_Animal;
                Gestion_Productos_Tipado_Maquinaria Formulario_Tipado_Maquinaria;
                bool Se_Advirtio_Al_Usuario_Sobre_Clickar_Y_Arrastrar;

                public Gestion_Productos(int? ID_Proveedor = null)
                {
                        this.ID_Proveedor = ID_Proveedor;

                        InitializeComponent();
                        // Ya el constructor de ventanas me ha jugado malas pasadas de diferenes tipos.
                        // Voy a evitar modificar el codigo que este genera a lo mayor posible.
                        // Si tengo que hacer algun cambio medio rocambolezco lo hare aqui.

                        { // Se setean algunos aspectos graficos predeterminados. 
                                DropDownList_Tipado.SelectedItem = DropDownList_Tipado.Items[0];
                                DropDownList_Filtro_Busqueda.SelectedItem = "ID";
                                TextBox_Buscar.PlaceholderText = "Buscar por ID de Producto";
                        }

                        { // Se inician los formularios que persisten al ser cerrados.
                                Formulario_Tipado_Animal = new Gestion_Productos_Tipado_Animal();
                                Formulario_Tipado_Maquinaria = new Gestion_Productos_Tipado_Maquinaria();
                        }
                        Label_Modo_Admin.Visible = !Modo_Publicacion_Proveedor;
                        GroupBox_Productos_En_El_Sistema.Text = ( ( ! Modo_Publicacion_Proveedor ) ? "Productos en el sistema" : "Tus productos libres" ) ;
                }

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
                # region >>---- Dinamicas de Fotos
                private void Button_Ver_Fotos_Click(object sender, EventArgs e)
                {
                        if (Fotos_Producto is null) { throw new Exception("Se presiono el boton `Ver` cuando las fotos del Producto en Edicion es null."); }

                        Formulario_Ver_Fotos = new Gestion_Productos_Ver_Fotos(Fotos_Producto);
                        Formulario_Ver_Fotos.ShowDialog(owner: this);
                }
                private void Button_Quitar_Click(object sender, EventArgs e)
                {
                        if (Fotos_Producto is null) { throw new Exception("Se presiono el boton `Quitar` cuando las fotos del Producto en Edicion son null."); }

                        void Actualizar_Opciones_De_Fotos()
                        {
                                if (Fotos_Producto.Length == 0)
                                {
                                        Button_Quitar_Fotos.Enabled = false;
                                        Button_Ver_Fotos.Enabled = false;
                                }
                        }
                        void Actualizar_Seleccion_Fotos() { Fotos_Producto = Formulario_Quitar_Fotos.Fotos_Producto; }

                        Formulario_Quitar_Fotos = new Gestion_Productos_Quitar_Fotos(Fotos_Producto);
                        Formulario_Quitar_Fotos.ShowDialog(owner: this);

                        Actualizar_Seleccion_Fotos();
                        Actualizar_Opciones_De_Fotos();

                }
                void Button_Seleccionar_Click(object sender, EventArgs e)
                {
                        byte[] Get_Foto_En_Bytes(string Ruta_Foto)
                        {
                                byte[] Foto_En_Bytes;

                                if (!File.Exists(Ruta_Foto)) { throw new Exception($"La Foto de la ruta `{Ruta_Foto}` no existe"); }
                                Foto_En_Bytes = File.ReadAllBytes(Ruta_Foto);

                                return Foto_En_Bytes;
                        }

                        Bitmap Bytes_A_Bitmap(byte[] Foto_En_Bytes)
                        {
                                Bitmap? Imagen;
                                using MemoryStream Stream = new MemoryStream(Foto_En_Bytes);
                                Imagen = new Bitmap(Stream);
                                return Imagen;
                        }

                        void Mostrar_MessageBox_Imagen_Invalida(int Foto_Numero)
                        {
                                MessageBox.Show
                                (
                                        caption: "La foto a mostrar es invalida.",
                                        text: $"Por algún motivo, la foto numero `{Foto_Numero}` es invalida y no puede utilizar.\nDicha foto se descartará.",
                                        icon: MessageBoxIcon.Error,
                                        buttons: MessageBoxButtons.OK,
                                        owner: this
                                );
                        }

                        //
                        //   Podría diferenciar estas excepciones como excepciones del Gesto de Productos, capaz de ser atrapadas y de dar informacion util.
                        //
                        OpenFileDialog Ventana_Seleccionar_Archivos;
                        string Filtro_Para_Archivos_De_Imagen;

                        Filtro_Para_Archivos_De_Imagen = "Archivos de Imagen Soportados(*.png, *.jpg, *.jpeg, *.bmp) |*.png;*.jpg;*.jpeg;*.bmp";
                        Ventana_Seleccionar_Archivos = new OpenFileDialog
                        {
                                Title = "Selecciona fotos del producto",

                                Multiselect = true,
                                // SupportMultiDottedExtensions = true, // Esto ayudaria a casos muy puntuales, pudiendo traer muchos problemas.
                                CheckPathExists = true,
                                CheckFileExists = true,
                                Filter = Filtro_Para_Archivos_De_Imagen
                        };


                        if (!Se_Advirtio_Al_Usuario_Sobre_Clickar_Y_Arrastrar)
                        {
                                MessageBox.Show
                                (
                                    owner: this,
                                    caption: "Multiples Imagenes",
                                    text: "Presiona Ctrl + Click o clicka y arrastra para seleccionar multiples imagenes para el Producto.",
                                    icon: MessageBoxIcon.Information,
                                    buttons: MessageBoxButtons.OK
                                );
                                Se_Advirtio_Al_Usuario_Sobre_Clickar_Y_Arrastrar = true;
                        }
                        DialogResult Resultado_Dialog = Ventana_Seleccionar_Archivos.ShowDialog(owner: this);
                        if (!(Resultado_Dialog == DialogResult.OK)) { return; }

                        { // Agregar las Fotos seleccionada al Producto en edicion
                                int Cantidad_Fotos;
                                const int Max_Bytes_Por_Foto = 16777215; // Esta es una limitacion del tipo de campo `longblob` de MySql, el cual usamos para guardar las imagenes.

                                if (Ventana_Seleccionar_Archivos.FileNames.Length == -1) { throw new Exception(); }
                                Cantidad_Fotos = Ventana_Seleccionar_Archivos.FileNames.Length;
                                Fotos_Producto = new byte[Cantidad_Fotos][];

                                for (int Indice_Foto = 0; Indice_Foto < Cantidad_Fotos; Indice_Foto++)
                                {
                                        string Ruta_Foto = Ventana_Seleccionar_Archivos.FileNames[Indice_Foto];
                                        byte[] Foto_En_Bytes = Get_Foto_En_Bytes(Ruta_Foto);

                                        // Comprueba que la foto puede ser mostrada por el formulario.
                                        try { Bytes_A_Bitmap(Foto_En_Bytes); } catch { Mostrar_MessageBox_Imagen_Invalida(Indice_Foto); continue; }
                                        if (Foto_En_Bytes.Length > Max_Bytes_Por_Foto) { throw new Exception("La foto seleccionada numero `{ Indice_Foto }` es demasiado grande."); }
                                        Fotos_Producto[Indice_Foto] = Foto_En_Bytes;
                                }
                        }
                        if (Fotos_Producto.Length >= 0)
                        {
                                Button_Quitar_Fotos.Enabled = true;
                                Button_Ver_Fotos.Enabled = true;
                        }

                }
                # endregion
                # region >>---- Dinamicas de Tipado
                private void DropDownList_Tipado_SelectedIndexChanged(object sender, EventArgs e)
                {
                        if (DropDownList_Tipado.Text != "Ninguno") { Button_Editar.Enabled = true; }
                        else { Button_Editar.Enabled = false; }
                }

                private void Button_Editar_Click(object sender, EventArgs e)
                {
                        if (DropDownList_Tipado.Text == "Ninguno") { throw new Exception("Se intento abrir la edicion mientras que la opcion de tipo seleccionada es `Ninguno`."); }

                        string Tipo_Del_Producto = DropDownList_Tipado.SelectedItem.ToString()!;
                        switch (Tipo_Del_Producto)
                        {
                                case "Animal":
                                        if (Formulario_Tipado_Maquinaria is not null && !Formulario_Tipado_Maquinaria.Esta_Vacio) { Formulario_Tipado_Maquinaria.Limpiar_Formulario(); }

                                        Formulario_Tipado_Animal.ShowDialog(owner: this);

                                        if (Formulario_Tipado_Animal.Esta_Vacio) { DropDownList_Tipado.Text = "Ninguno"; }
                                        break;
                                case "Maquinaria":
                                        if (Formulario_Tipado_Animal is not null && !Formulario_Tipado_Animal.Esta_Vacio) { Formulario_Tipado_Animal.Limpiar_Formulario(); }

                                        Formulario_Tipado_Maquinaria.ShowDialog(owner: this);
                                        if (Formulario_Tipado_Maquinaria.Esta_Vacio) { DropDownList_Tipado.Text = "Ninguno"; }
                                        break;
                                default:
                                        throw new Exception($"No se puede editar el tipado de `{DropDownList_Tipado.SelectedItem.ToString()}`, pues tal tipo no es soportado.");
                                        break;
                        }
                }
                # endregion
                # region >>---- Dinamicas del Buscador(y la grilla)
                private void DropDownList_Filtro_Busqueda_SelectedIndexChanged(object sender, EventArgs e) { TextBox_Buscar.PlaceholderText = $"Buscar por {DropDownList_Filtro_Busqueda.Text} de Producto"; }
                private void TextBox_Buscar_Leave(object sender, EventArgs e) { TextBox_Buscar.PlaceholderText = $"Buscar por {DropDownList_Filtro_Busqueda.Text} de Producto"; }

                private void TextBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if (!(e.KeyChar == (char)Keys.Enter)) { return; }

                        {  // ReCargar Grilla con los resultados 
                                string Campo_Filtro_Producto;
                                string Argumento_Filtrado_Producto;

                                if (TextBox_Buscar.Text != "")
                                {
                                        Campo_Filtro_Producto = DropDownList_Filtro_Busqueda.Text;
                                        Argumento_Filtrado_Producto = TextBox_Buscar.Text + "%";
                                }
                                else
                                {
                                        Campo_Filtro_Producto = "";
                                        Argumento_Filtrado_Producto = "";
                                }
                                Recargar_La_Grilla(Campo_Filtro_Producto, Argumento_Filtrado_Producto);
                        }
                }

                // Dinamicas de la grilla
                void Recargar_La_Grilla(string Campo_Filtro_Producto = "", string Argumento_Filtrado_Producto = "")
                {
                        // Por algun motivo, a veces al llamar a este metodo, ocurre que la CurrentRow de la grilla se vuelve null.
                        // Muchas veces ocurre despues de llamarlo y a veces no. Nc pq pero el form funciona. Asi que por ahora asi se queda.

                        DataTable? Resumen_Productos;
                        if (Modo_Publicacion_Proveedor) { Resumen_Productos = Procesamiento_Productos.Marshal_Get_Resumen_Productos_Proveedor((int)ID_Proveedor!, Campo_Filtro_Producto, Argumento_Filtrado_Producto); }
                        else { Resumen_Productos = Procesamiento_Productos.Marshal_Get_Resumen_Productos(Campo_Filtro_Producto, Argumento_Filtrado_Producto); }

                        if ( Resumen_Productos is null ) { Grilla_Productos.DataSource = Procesamiento_Productos.Get_Columnas_Grilla( Modo_Publicacion_Proveedor ) ; return ; }
                        using DataTable DataSource_Grilla = (DataTable)Grilla_Productos.DataSource;
                        DataSource_Grilla.Rows.Clear();
                        foreach (DataRow Fila_Resumen_Producto in Resumen_Productos.Rows)
                        {
                                DataRow Nueva_Fila_Resumen_Producto_Grilla = DataSource_Grilla.NewRow();
                                Nueva_Fila_Resumen_Producto_Grilla.ItemArray = Fila_Resumen_Producto.ItemArray;
                                DataSource_Grilla.Rows.Add(Nueva_Fila_Resumen_Producto_Grilla);
                        }
                }
                private void Grilla_Productos_SelectionChanged(object sender, EventArgs e)
                {
                        // Prepara los formularios para trabajar con un Producto y todos sus relacionados,
                        // el cual fue clickado en la grilla.

                        if (Grilla_Productos.DataSource is null) { return; }
                        if (Grilla_Productos.CurrentRow is null) { return; }

                        DataGridViewCellCollection Campos = Grilla_Productos.CurrentRow.Cells;
                        object Tipo_Producto = Campos["Tipo"].Value;

                        void Cargar_Informacion_Ajena_A_El_Tipo()
                        {
                                { // Cargar informacion del Elemento de Subasta
                                        NumericUpDown_Valor.Value = (!Convert.IsDBNull(Campos["Valor"].Value)) ? Convert.ToUInt32(Campos["Valor"].Value) : 0;
                                        NumericUpDown_Precio_Base.Value = (!Convert.IsDBNull(Campos["Precio_Base"].Value)) ? Convert.ToInt32(Campos["Precio_Base"].Value) : 0;
                                        CheckBox_Habilitado.Checked = (Convert.ToBoolean(Campos["Habilitado"].Value)) ? true : false;
                                }

                                { // Carga informacion del Producto
                                        TextBox_Nombre.Text = (!Convert.IsDBNull(Campos["Nombre"].Value)) ? Campos["Nombre"].Value.ToString() : "";
                                        TextBox_Descripcion.Text = (!Convert.IsDBNull(Campos["Descripcion"].Value)) ? Campos["Descripcion"].Value.ToString() : "";
                                }

                                { // Cargar Fotos del Producto
                                        byte[][]? Fotos_Producto_Seleccionado;
                                        int ID_Producto = Convert.ToInt32(Campos["ID"].Value);

                                        Fotos_Producto_Seleccionado = Procesamiento_Productos.Marshal_Get_Fotos_Producto(ID_Producto);
                                        Fotos_Producto = Fotos_Producto_Seleccionado;
                                }
                        }
                        void Cargar_Informacion_Del_Tipo()
                        {
                                if (Convert.IsDBNull(Tipo_Producto))
                                {
                                        Formulario_Tipado_Animal.Limpiar_Formulario();
                                        Formulario_Tipado_Maquinaria.Limpiar_Formulario();
                                        return;
                                }

                                switch (Tipo_Producto.ToString())
                                {
                                        case "Animal":
                                                DataTable? Resumen_Animal;
                                                DataRow? Informacion_Animal;
                                                int ID_Animal;

                                                ID_Animal = Convert.ToInt32(Grilla_Productos.CurrentRow.Cells["ID"].Value);
                                                Resumen_Animal = Procesamiento_Productos.Marshal_Get_Resumen_Animal(ID_Animal);
                                                Informacion_Animal = (Resumen_Animal is not null && !Convert.IsDBNull(Resumen_Animal)) ? Resumen_Animal.Rows[0] as DataRow : null;

                                                Formulario_Tipado_Maquinaria.Limpiar_Formulario();
                                                Formulario_Tipado_Animal.Cargar_Animal(Informacion_Animal);
                                                break;
                                        case "Maquinaria":
                                                int ID_Maquinaria;

                                                ID_Maquinaria = Convert.ToInt32(Campos["ID"].Value);
                                                Formulario_Tipado_Animal.Limpiar_Formulario();
                                                Formulario_Tipado_Maquinaria.Cargar_Maquinaria(ID_Maquinaria);
                                                break;
                                }
                        }
                        DataGridViewRow Fila_Actual;
                        Fila_Actual = Grilla_Productos.CurrentRow;

                        if (!Fila_Actual.IsNewRow)
                        { // Cargar informacion del Producto seleccionado
                                Cargar_Informacion_Ajena_A_El_Tipo();
                                Cargar_Informacion_Del_Tipo();
                                Hay_Un_Producto_Cargado = true;
                        }
                        else
                        {
                                TextBox_Nombre.Text = "";
                                NumericUpDown_Valor.Value = 0;
                                NumericUpDown_Precio_Base.Value = 0;
                                TextBox_Descripcion.Text = "";
                                CheckBox_Habilitado.Checked = false;

                                Formulario_Tipado_Animal.Limpiar_Formulario();
                                Formulario_Tipado_Maquinaria.Limpiar_Formulario();
                                Hay_Un_Producto_Cargado = false;
                        }

                        { // Actualizacion de acceso a controles
                                // Tranca o destranca los controles
                                Button_Modificar.Enabled = (Hay_Un_Producto_Cargado);
                                Button_Eliminar.Enabled = (Hay_Un_Producto_Cargado);

                                // Tranca o destranca los botones de fotos segun corresponda
                                Button_Ver_Fotos.Enabled = (Fotos_Producto is not null);
                                Button_Quitar_Fotos.Enabled = (Fotos_Producto is not null);

                                // Selecciona el tipo del Producto
                                switch (Tipo_Producto)
                                {
                                        case "Animal":
                                                DropDownList_Tipado.SelectedItem = Tipo_Producto;
                                                break;
                                        case "Maquinaria":
                                                DropDownList_Tipado.SelectedItem = Tipo_Producto;
                                                break;
                                        default:
                                                DropDownList_Tipado.SelectedItem = "Ninguno";
                                                break;
                                }
                        }
                }

                private void Gestion_Productos_Load(object sender, EventArgs e)
                {
                        void Cargar_Resumen_Productos_Grilla(string Campo_Filtro_Producto = "", string Argumento_Filtrado_Producto = "")
                        { // Cargar Grilla
                                // Si se le mete como filtro un campo que no existe explota
                                DataTable? Resumen_Productos;

                                if (Modo_Publicacion_Proveedor) { Resumen_Productos = Procesamiento_Productos.Marshal_Get_Resumen_Productos_Proveedor((int)ID_Proveedor!, Campo_Filtro_Producto, Argumento_Filtrado_Producto); }
                                else { Resumen_Productos = Logica.Gestion_Productos.Procesamiento_Productos.Marshal_Get_Resumen_Productos(Campo_Filtro_Producto, Argumento_Filtrado_Producto); }
                                Grilla_Productos.DataSource = Resumen_Productos;
                        }
                        Cargar_Resumen_Productos_Grilla();
                }
                #endregion
                # region >>---- Dinamicas de los controles de Producto
                object ID_Producto_Gestionado;
                void Reseleccionar_Producto()
                {
                        if (ID_Producto_Gestionado is null) { return; } // Solo por si acaso...

                        foreach (DataGridViewRow Fila in Grilla_Productos.Rows) { if (Fila.Cells["ID"].Value == ID_Producto_Gestionado) { Grilla_Productos.CurrentCell = Fila.Cells["ID"]; } }
                        // Qué pasa si no la encontramos?
                        // https://www.google.com/imgres?imgurl=https%3A%2F%2Fimages3.memedroid.com%2Fimages%2FUPLOADED499%2F62be9c0ecf38e.jpeg&tbnid=ievDRF7Zy3reDM&vet=12ahUKEwjmneT3n4KCAxW4iJUCHdKZCMcQMygBegQIARBE..i&imgrefurl=https%3A%2F%2Fwww.memedroid.com%2Fmemes%2Fdetail%2F3724058%2FPlantilla-gratis-gente&docid=gm0ZtNFyHI9XJM&w=505&h=268&q=es%20nada%20meme&hl=es-419&ved=2ahUKEwjmneT3n4KCAxW4iJUCHdKZCMcQMygBegQIARBE
                }

                bool Tipado_Invalido()
                {
                        switch (DropDownList_Tipado.Text)
                        {
                                default: return false; // default = "Ninguno"
                                case "Animal": return (Formulario_Tipado_Animal.Esta_Vacio);
                                case "Maquinaria": return (Formulario_Tipado_Maquinaria.Esta_Vacio);
                        }
                }

                void Mostrar_MessageBox_Tipado_Invalido()
                {
                        MessageBox.Show
                        (
                                caption: "El tipado es invalido.",
                                text: $"El tipado del Producto esta vacío, debe completar el tipado de `{DropDownList_Tipado.Text}` antes de proseguir.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }

                private void Button_Guardar_Click(object sender, EventArgs e)
                {
                        if (Tipado_Invalido()) { Mostrar_MessageBox_Tipado_Invalido(); return; }

                        Dictionary<string, object?> Campos_Elemento_Subasta;
                        Dictionary<string, object?> Campos_Producto;
                        Dictionary<string, object?>? Campos_Animal;
                        Dictionary<string, object>? Campos_Maquinaria;

                        { // Inicializar los campos
                                Campos_Elemento_Subasta = new Dictionary<string, object?>();
                                Campos_Producto = new Dictionary<string, object?>();
                                Campos_Animal = null;
                                Campos_Maquinaria = null;
                        }
                        Recompilar_Campos_Producto_Completo
                        (
                                ref Campos_Elemento_Subasta,
                                ref Campos_Producto,
                                ref Campos_Animal,
                                ref Campos_Maquinaria
                        );

                        Procesamiento_Productos.
                        Marshal_Gestion_Producto_Completo
                        (
                                Acceso_Datos.Interfaz_Base_Datos.Operacion_Gestion.Alta,
                                Campos_Elemento_Subasta,
                                Campos_Producto,
                                Campos_Animal,
                                Campos_Maquinaria
                        );
                        Recargar_La_Grilla();
                        Reseleccionar_Producto();
                        Reproducir_Tono_Producto_Guardado();
                }
                private void Button_Modificar_Click(object sender, EventArgs e)
                {
                        if (!Hay_Un_Producto_Cargado) { throw new InvalidOperationException("Se presionó el botón `Modificar` cuando no había ningún Producto cargado."); }
                        if (Grilla_Productos.CurrentRow.IsNewRow) { return; }
                        if (Tipado_Invalido()) { Mostrar_MessageBox_Tipado_Invalido(); return; }

                        Dictionary<string, object?> Campos_Elemento_Subasta;
                        Dictionary<string, object?> Campos_Producto;
                        Dictionary<string, object?>? Campos_Animal;
                        Dictionary<string, object>? Campos_Maquinaria;

                        void MessageBox_El_Tipado_Esta_Incompleto()
                        {
                                MessageBox.Show
                                (
                                     caption: "El tipado del Producto está incompleto",
                                     text: $"Se seleccionó el tipo `{DropDownList_Tipado.Text}` para el Producto pero el tipado está incompleto o vacío.\n" +
                                            "Complete el tipado antes de modificar el Producto.",
                                     icon: MessageBoxIcon.Error,
                                     buttons: MessageBoxButtons.OK,
                                     owner: this
                                );
                        }

                        string Tipo_Producto_Seleccionado = DropDownList_Tipado.Text;
                        switch (Tipo_Producto_Seleccionado)
                        {
                                case "Ninguno":
                                        break;
                                case "Animal": if (Formulario_Tipado_Animal.Esta_Vacio) { MessageBox_El_Tipado_Esta_Incompleto(); return; } break;
                                case "Maquinaria": if (Formulario_Tipado_Maquinaria.Esta_Vacio) { MessageBox_El_Tipado_Esta_Incompleto(); return; } break;
                        }

                        { // Inicializar los campos
                                Campos_Elemento_Subasta = new Dictionary<string, object?>();
                                Campos_Producto = new Dictionary<string, object?>();
                                Campos_Animal = null;
                                Campos_Maquinaria = null;
                        }
                        Recompilar_Campos_Producto_Completo
                        (
                                ref Campos_Elemento_Subasta,
                                ref Campos_Producto,
                                ref Campos_Animal,
                                ref Campos_Maquinaria
                        );

                        if (Campos_Animal is null && Campos_Maquinaria is null)
                        {
                                // Arreglar la especializacion de Juan....
                                Procesamiento_Productos.
                                        Marshal_Gestion_Producto_Completo
                                        (
                                            Acceso_Datos.Interfaz_Base_Datos.Operacion_Gestion.Modificacion,
                                            Campos_Elemento_Subasta,
                                            Campos_Producto
                                        );
                                return;
                        }

                        if (Campos_Animal is not null)
                        {
                                Procesamiento_Productos.
                                        Marshal_Gestion_Producto_Completo
                                        (
                                            Acceso_Datos.Interfaz_Base_Datos.Operacion_Gestion.Modificacion,
                                            Campos_Elemento_Subasta,
                                            Campos_Producto,
                                            Campos_Animal: Campos_Animal
                                        );
                        }
                        if (Campos_Maquinaria is not null)
                        {
                                Procesamiento_Productos.
                                        Marshal_Gestion_Producto_Completo
                                        (
                                            Acceso_Datos.Interfaz_Base_Datos.Operacion_Gestion.Modificacion,
                                            Campos_Elemento_Subasta,
                                            Campos_Producto,
                                            Campos_Maquinaria: Campos_Maquinaria
                                        );
                        }

                        Recargar_La_Grilla();
                        Reseleccionar_Producto();
                        Reproducir_Tono_Modificado();
                }
                private void Button_Eliminar_Click(object sender, EventArgs e)
                {
                        if (!Hay_Un_Producto_Cargado) { throw new InvalidOperationException("Se presionó el botón `Eliminar` cuando no había ningún Producto cargado."); }

                        Dictionary<string, object?> Campos_Elemento_Subasta_Dummy; // Un envoltorio para el dato `ID`
                        Dictionary<string, object?> Campos_Producto_Dummy; // Un miembro con informacion de relleno, necesario para reutilizar el metodo `Gestion_Producto_Completo` tal cual está.
                        const DialogResult El_Usuario_Desea_Continuar = DialogResult.OK;

                        if (
                                MessageBox.Show
                                (
                                        caption: "Se eliminará el Producto",
                                        text: $"A continuacion se eliminará el Producto seleccionado. El cual es del tipo `{DropDownList_Tipado.Text}`.",
                                        icon: MessageBoxIcon.Question,
                                        buttons: MessageBoxButtons.OKCancel
                                )
                                != El_Usuario_Desea_Continuar
                        ) { return; }

                        { // Crear `Campos de Elementos de Subasta Dummy` 
                                Campos_Elemento_Subasta_Dummy = new Dictionary<string, object?>();
                                Campos_Elemento_Subasta_Dummy["ID"] = Grilla_Productos.CurrentRow.Cells["ID"].Value;
                                Campos_Elemento_Subasta_Dummy["Valor"] = null;
                                Campos_Elemento_Subasta_Dummy["Precio_Base"] = null;
                                Campos_Elemento_Subasta_Dummy["Habilitado"] = false;
                        }

                        { // Crear `Campos_producto_Dummy` 
                                Campos_Producto_Dummy = new Dictionary<string, object?>();
                                Campos_Producto_Dummy["Nombre"] = null;
                                Campos_Producto_Dummy["Descripcion"] = null;
                        }

                        Procesamiento_Productos.
                        Marshal_Gestion_Producto_Completo
                        (
                                Acceso_Datos.Interfaz_Base_Datos.Operacion_Gestion.Baja,
                                Campos_Elemento_Subasta_Dummy,
                                Campos_Producto_Dummy

                        );

                        Recargar_La_Grilla();
                        Reproducir_Tono_Producto_Eliminado();
                }
                # endregion

                void Recompilar_Campos_Producto_Completo
                (
                        ref Dictionary<string, object?> Campos_Elemento_Subasta,
                        ref Dictionary<string, object?> Campos_Producto,
                        ref Dictionary<string, object?>? Campos_Animal,
                        ref Dictionary<string, object>? Campos_Maquinaria
                )
                {
                        { // Compilar campos Elemento_Subasta
                                Campos_Elemento_Subasta["ID"] = ID_Producto ;
                                Campos_Elemento_Subasta["Valor"] = (NumericUpDown_Valor.Value != 0) ? NumericUpDown_Valor.Value : null;
                                Campos_Elemento_Subasta["Precio_Base"] = (NumericUpDown_Precio_Base.Value != 0) ? NumericUpDown_Precio_Base.Value : null;
                                Campos_Elemento_Subasta["Habilitado"] = (CheckBox_Habilitado.Checked) ? true : false;
                        }

                        { // Compilar campos Producto 
                                Campos_Producto["Nombre"] = (TextBox_Nombre.Text != "") ? TextBox_Nombre.Text : null;
                                Campos_Producto["Descripcion"] = (TextBox_Descripcion.Text != "") ? TextBox_Descripcion.Text : null;

                                if (Fotos_Producto is not null) { Campos_Producto["Fotos"] = Fotos_Producto; }
                        }

                        if (DropDownList_Tipado.Text == "Ninguno") { return; }
                        if (DropDownList_Tipado.Text == "Animal")
                        {
                                Campos_Animal = new Dictionary<string, object?>();

                                Campos_Animal["Tipo_Animal"] = Formulario_Tipado_Animal!.DropDownList_Tipo_Animal.Text;
                                Campos_Animal["Edad"] = (Formulario_Tipado_Animal.NumericUpDown_Edad.Value != 0) ? Formulario_Tipado_Animal.NumericUpDown_Edad.Value : null;
                                Campos_Animal["Esta_Castrado"] = (Formulario_Tipado_Animal.CheckBox_Castrado.Checked) ? true : false;
                                Campos_Animal["Raza"] = (Formulario_Tipado_Animal.TextBox_Raza.Text != "") ? Formulario_Tipado_Animal.TextBox_Raza.Text : null;
                                Campos_Animal["Peso"] = Formulario_Tipado_Animal.NumericUpDown_Peso.Value;
                                Campos_Animal["Especializacion"] = Formulario_Tipado_Animal.DropDownList_Especializacion.Text.Replace(' ', '_');
                                Campos_Animal["Sexo"] = Formulario_Tipado_Animal.DropDownList_Sexo.Text;

                        }
                        if (DropDownList_Tipado.Text == "Maquinaria")
                        { // Tipo es "Maquinaria"
                                Campos_Maquinaria = new Dictionary<string, object>();

                                Campos_Maquinaria["Tipo_Maquinaria"] = Formulario_Tipado_Maquinaria!.DropDownList_Tipo_Maquina.Text;
                                Campos_Maquinaria["Marca"] = Formulario_Tipado_Maquinaria.TextBox_Marca.Text;
                                Campos_Maquinaria["Modelo"] = Formulario_Tipado_Maquinaria.TextBox_Modelo.Text;
                                Campos_Maquinaria["Numero_Serial"] = Formulario_Tipado_Maquinaria.TextBox_Numero_Serial.Text;
                                Campos_Maquinaria["Historial_Propiedad"] = Formulario_Tipado_Maquinaria.DropDownList_Historial_Propiedad.Text.Replace(' ', '_');
                                Campos_Maquinaria["Es_Nueva"] = Formulario_Tipado_Maquinaria.CheckBox_Nueva.Checked;
                                Campos_Maquinaria["Ano_Adquisicion"] = Formulario_Tipado_Maquinaria.NumericUpDown_Ano_Adquisicion.Value;
                        }
                }
        }
}
