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

using Presentacion.Gestion_Productos.Tipado_Productos;

namespace Presentacion.Gestion_Productos
{
        public partial class Gestion_Productos : Form
        {
                Naturaleza_de_las_cosas_a_subastar.Producto? Producto_En_Edicion { get; set; }

                Gestion_Productos_Ver_Fotos? Formulario_Ver_Fotos;
                Gestion_Productos_Quitar_Fotos? Formulario_Quitar_Fotos;
                Gestion_Productos_Tipado_Animal? Formulario_Tipado_Animal;
                Gestion_Productos_Tipado_Maquinaria? Formulario_Tipado_Maquinaria;
                bool Se_Advirtio_Al_Usuario_Sobre_Clickar_Y_Arrastrar;

                public Gestion_Productos()
                {
                        InitializeComponent();
                        // Ya el constructor de ventanas me ha jugado malas pasadas de diferenes tipos.
                        // Voy a evitar modificar el codigo que este genera a lo mayor posible.
                        // Si tengo que hacer algun cambio medio rocambolezco lo hare aqui.

                        DropDownList_Tipado.SelectedItem = DropDownList_Tipado.Items[0];
                        DropDownList_Filtro_Busqueda.SelectedItem = "ID";
                        TextBox_Buscar.PlaceholderText = "Buscar por ID de Producto";

#if DEBUG_Seleccion_Fotos
                        Logica.Sistema_de_cosas_a_subastar.Naturaleza_de_las_cosas_a_subastar.
                        Producto Producto_Dummy = new Naturaleza_de_las_cosas_a_subastar.Producto(Parametro_ID: 0, Parametro_Nombre: "Dummy");
                        Producto_En_Edicion = Producto_Dummy;
                        // Deshabilitar los controles tambien estaria bien. Pero ahora mismo no es necesario.
#endif
                }

                private void Gestion_Productos_Load(object sender, EventArgs e)
                {
                        { // Cargar Grilla
                                DataTable? Productos_JOIN_Elementos_Base_Datos;

                                Productos_JOIN_Elementos_Base_Datos = Logica.Gestion_Productos.Gestion_Productos.Marshal_Get_Productos_Join_Elementos_Subasta();
                                Grilla_Productos.DataSource = Productos_JOIN_Elementos_Base_Datos;
                        }
                }


                # region >>---- Dinamicas de Fotos
                private void Button_Ver_Fotos_Click(object sender, EventArgs e)
                {
                        if (Producto_En_Edicion is null) { throw new Exception("Se presiono el boton `Ver` cuando el Producto en Edicion es null."); }
                        if (Producto_En_Edicion.Fotos is null) { throw new Exception("Se presiono el boton `Ver` cuando las fotos del Producto en Edicion es null."); }

                        if (Formulario_Ver_Fotos is null) { Formulario_Ver_Fotos = new Gestion_Productos_Ver_Fotos(Producto_En_Edicion); }
                        Formulario_Ver_Fotos.ShowDialog(owner: this);
                }

                private void Button_Quitar_Click(object sender, EventArgs e)
                {
                        void Actualizar_Opciones_De_Fotos()
                        {
                                if (Producto_En_Edicion.Fotos.Length == 0)
                                {
                                        Button_Quitar_Fotos.Enabled = false;
                                        Button_Ver_Fotos.Enabled = false;
                                }
                        }

                        void Actualizar_Seleccion_Fotos() { Producto_En_Edicion.Fotos = Formulario_Quitar_Fotos.Fotos_Producto; }

                        if (Producto_En_Edicion is null) { throw new Exception("Se presiono el boton `Quitar` cuando el Producto en Edicion es null."); }
                        if (Producto_En_Edicion.Fotos is null) { throw new Exception("Se presiono el boton `Quitar` cuando las fotos del Producto en Edicion son null."); }

                        Formulario_Quitar_Fotos = new Gestion_Productos_Quitar_Fotos(Producto_En_Edicion.Fotos);
                        Formulario_Quitar_Fotos.ShowDialog(owner: this);

                        Actualizar_Seleccion_Fotos();
                        Actualizar_Opciones_De_Fotos();

                }

#if DEBUG_Gestion_Productos
                public
#else
                private
#endif
                void Button_Seleccionar_Click(object sender, EventArgs e)
                {
                        if (Producto_En_Edicion is null) { throw new Exception("Se lanzo el Selector de Fotos del Gestor de Productos sin tener ningun producto en edicion."); }
                        //
                        //   Deberia diferenciar estas excepciones como excepciones del Gesto de Productos, capaz de ser atrapadas y de dar informacion util.
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
                                    text: "Clicka y arrastra para seleccionar multiples imagenes para el Producto.",
                                    icon: MessageBoxIcon.Information,
                                    buttons: MessageBoxButtons.OK
                                );
                                Se_Advirtio_Al_Usuario_Sobre_Clickar_Y_Arrastrar = true;
                        }
                        DialogResult Resultado_Dialog = Ventana_Seleccionar_Archivos.ShowDialog(owner: this);
                        if (!(Resultado_Dialog == DialogResult.OK)) {; return; }

                        { // Agregar las Fotos seleccionada al Producto_En_Edicion
                                byte[] Get_Foto_En_Bytes(string Ruta_Foto)
                                {
                                        byte[] Foto_En_Bytes;

                                        if (!File.Exists(Ruta_Foto)) { throw new Exception($"La Foto de la ruta `{Ruta_Foto}` no existe"); }
                                        Foto_En_Bytes = File.ReadAllBytes(Ruta_Foto);

                                        return Foto_En_Bytes;
                                }

                                int Cantidad_Fotos;
                                const int Max_Bytes_Por_Foto = 16777215; // Esta es una limitacion del tipo de campo `longblob` de MySql, el cual usamos para guardar las imagenes.

                                if (Ventana_Seleccionar_Archivos.FileNames.Length == -1) { throw new Exception(); }
                                Cantidad_Fotos = Ventana_Seleccionar_Archivos.FileNames.Length;
                                Producto_En_Edicion.Fotos = new byte[Cantidad_Fotos][];

                                for (int Indice_Foto = 0; Indice_Foto < Cantidad_Fotos; Indice_Foto++)
                                {
                                        string Ruta_Foto = Ventana_Seleccionar_Archivos.FileNames[Indice_Foto];
                                        byte[] Foto_En_Bytes = Get_Foto_En_Bytes(Ruta_Foto);

                                        if (Foto_En_Bytes.Length > Max_Bytes_Por_Foto) { throw new Exception("La foto seleccionada numero `{ Indice_Foto }` es demasiado grande."); }
                                        Producto_En_Edicion.Fotos[Indice_Foto] = Foto_En_Bytes;
                                }
                        }
                        if (Producto_En_Edicion.Fotos.Length >= 0)
                        {
                                Button_Quitar_Fotos.Enabled = true;
                                Button_Ver_Fotos.Enabled = true;
                        }

                }
                # endregion

                # region >>---- Dinamicas de Tipado
                private void DropDownList_Tipado_SelectedIndexChanged(object sender, EventArgs e)
                {
                        if (DropDownList_Tipado.SelectedItem.ToString() != "Ninguno") { Button_Editar.Enabled = true; }
                        else { Button_Editar.Enabled = false; }
                }

                private void Button_Editar_Click(object sender, EventArgs e)
                {
                        if (DropDownList_Tipado.SelectedItem.ToString() == "Ninguno") { throw new Exception("Se intento abrir la edicion mientras que la opcion de tipo seleccionada es `Ninguno`."); }
                        switch (DropDownList_Tipado.SelectedItem.ToString())
                        {
                                case "Animal":
                                        if (Formulario_Tipado_Maquinaria is not null && !Formulario_Tipado_Maquinaria.Esta_Vacio) { Formulario_Tipado_Maquinaria.Limpiar_Formulario(); }
                                        
                                        if (Formulario_Tipado_Animal is null) { Formulario_Tipado_Animal = new Gestion_Productos_Tipado_Animal(); }
                                        Formulario_Tipado_Animal.ShowDialog(owner: this);
                                        if ( Formulario_Tipado_Animal.Esta_Vacio ) { DropDownList_Tipado.SelectedText = "Ninguno" ; }
                                        break;
                                case "Maquinaria":
                                        if (Formulario_Tipado_Animal is not null && !Formulario_Tipado_Animal.Esta_Vacio) { Formulario_Tipado_Animal.Limpiar_Formulario(); }
                                        
                                        if (Formulario_Tipado_Maquinaria is null) { Formulario_Tipado_Maquinaria = new Gestion_Productos_Tipado_Maquinaria(); }
                                        Formulario_Tipado_Maquinaria.ShowDialog(owner: this);
                                        if ( Formulario_Tipado_Maquinaria.Esta_Vacio ) { DropDownList_Tipado.Text = "Ninguno" ; }
                                        break;
                                default:
                                        throw new Exception($"No se puede editar el tipado de `{DropDownList_Tipado.SelectedItem.ToString()}`, pues tal tipo no es soportado.");
                                        break;
                        }
                }
                # endregion

                # region >>---- Dinamicas del Buscador
                private void DropDownList_Filtro_Busqueda_SelectedIndexChanged(object sender, EventArgs e) { TextBox_Buscar.PlaceholderText = $"Buscar por {DropDownList_Filtro_Busqueda.Text} de Producto"; }
                private void TextBox_Buscar_Leave(object sender, EventArgs e) { TextBox_Buscar.PlaceholderText = $"Buscar por {DropDownList_Filtro_Busqueda.Text} de Producto"; }

                private void TextBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if (!(e.KeyChar == (char)Keys.Enter)) { return; }

                        {  // Cargar Grilla 
                                DataTable? Productos_JOIN_Elementos_Base_Datos;
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

                                Productos_JOIN_Elementos_Base_Datos = Logica.Gestion_Productos.Gestion_Productos.Marshal_Get_Productos_Join_Elementos_Subasta(Campo_Filtro_Producto, Argumento_Filtrado_Producto);
                                Grilla_Productos.DataSource = Productos_JOIN_Elementos_Base_Datos;
                        }
                }
                #endregion

                private void Grilla_Productos_SelectionChanged(object sender, EventArgs e)
                {
                        const int Indice_Fila_Cabeceras = -1;
                        int Indice_Fila_Actual_Real = ( Grilla_Productos.CurrentRow.Index == 0 ) ? Grilla_Productos.RowCount : Grilla_Productos.CurrentRow.Index - 1 ; // Por algun motivo interesante, Grilla_Productos.CurrentRow contiene la fila anterior a la actual. Nc pq. No voy a tratar de buscarle la vuelta.
                        
                        bool Fila_Actual_Es_Cabeceras() { return (Grilla_Productos.CurrentRow.Index == Indice_Fila_Cabeceras) ? true : false; }

                        if ( Grilla_Productos.DataSource is null ) { return ; }
                        if ( Grilla_Productos.CurrentRow is null || Fila_Actual_Es_Cabeceras() ) { return ; }

                        DataGridViewRow Fila_Actual = Grilla_Productos.Rows[ Indice_Fila_Actual_Real ] ;
                        // Grilla_Productos.Columns ;

                        if (  true /*! Grilla_Productos.Rows[ Indice_Fila_Actual_Real ] */)
                        {
                                TextBox_Nombre.Text = (!Convert.IsDBNull(Fila_Actual.Cells["Nombre"].Value)) ? Fila_Actual.Cells["Nombre"].Value.ToString() : "";
                                NumericUpDown_Valor.Value = (!Convert.IsDBNull(Fila_Actual.Cells["Valor"].Value)) ? Convert.ToUInt32(Fila_Actual.Cells["Valor"].Value) : 0;
                                NumericUpDown_Precio_Base.Value = (!Convert.IsDBNull(Fila_Actual.Cells["Precio_Base"].Value)) ? Convert.ToInt32(Fila_Actual.Cells["Precio_Base"].Value) : 0;
                                TextBox_Descripcion.Text = (!Convert.IsDBNull(Fila_Actual.Cells["Descripcion"].Value)) ? Fila_Actual.Cells["Descripcion"].Value.ToString() : "";
                                CheckBox_Habilitado.Checked = (Convert.ToBoolean(Fila_Actual.Cells["Habilitado"].Value)) ? true : false;
                        }
                        else
                        {
                                TextBox_Nombre.Text = "";
                                NumericUpDown_Valor.Value = 0;
                                NumericUpDown_Precio_Base.Value = 0;
                                TextBox_Descripcion.Text = "";
                                CheckBox_Habilitado.Checked = false;
                        }
                }

                private void Button_Modificar_Click(object sender, EventArgs e)
                {
                        if (Grilla_Productos.CurrentRow.IsNewRow) { return; }

                        Dictionary<string, object?> Campos_Elemento_Subasta;
                        Dictionary<string, object?> Campos_Producto;
                        Dictionary<string, object?>? Campos_Animal;
                        Dictionary<string, object?>? Campos_Maquinaria;

                        void Recompilar_Campos()
                        {
                                Campos_Elemento_Subasta = new Dictionary<string, object>();
                                Campos_Producto = new Dictionary<string, object>();
                                Campos_Animal = null ;
                                Campos_Maquinaria = null ;

                                { // Compilar campos Elemento_Subasta
                                        Campos_Elemento_Subasta["ID"] = Grilla_Productos.CurrentRow.Cells["ID"].Value ;
                                        Campos_Elemento_Subasta["Valor"] = (NumericUpDown_Valor.Value != 0) ? NumericUpDown_Valor.Value : null ;
                                        Campos_Elemento_Subasta["Precio_Base"] = (NumericUpDown_Precio_Base.Value != 0) ? NumericUpDown_Precio_Base.Value : null ;
                                        Campos_Elemento_Subasta["Habilitado"] = ( CheckBox_Habilitado.Checked ) ? true : false ;
                                }

                                { // Compilar campos Producto 
                                        Campos_Producto["Nombre"] = ( TextBox_Nombre.Text != "" ) ? TextBox_Nombre.Text : null ;
                                        Campos_Producto["Descripcion"] = ( TextBox_Descripcion.Text != "" ) ? TextBox_Descripcion.Text : null ;

                                        if ( Producto_En_Edicion.Fotos is null ) { return ; }
                                        Campos_Producto["Fotos"] = Producto_En_Edicion.Fotos ;
                                }

                                if ( DropDownList_Tipado.SelectedText == "Ninguno" ) { return ; }
                                if ( DropDownList_Tipado.SelectedText == "Animal" )
                                {
                                        Campos_Animal = new Dictionary<string, object>() ;

                                        Campos_Animal["Tipo_Animal"] = Formulario_Tipado_Animal!.DropDownList_Tipo_Animal.SelectedText ;
                                        Campos_Animal["Edad"] = ( Formulario_Tipado_Animal.NumericUpDown_Edad.Value != 0 ) ? Formulario_Tipado_Animal.NumericUpDown_Edad.Value : null ;
                                        Campos_Animal["Castrado"] = ( Formulario_Tipado_Animal.CheckBox_Castrado.Checked ) ? true : false ;
                                        Campos_Animal["Especializacion"] = Formulario_Tipado_Animal.DropDownList_Especializacion.SelectedText ;
                                        if ( Formulario_Tipado_Animal.CheckBox_Raza.Checked ) { Campos_Animal["Raza"] = ( Formulario_Tipado_Animal.TextBox_Raza.Text != "" ) ? Formulario_Tipado_Animal.TextBox_Raza.Text : null ; }
                                }
                                else
                                { // Tipo es "Maquinaria"
                                        Campos_Maquinaria = new Dictionary<string, object?> () ;

                                        Campos_Maquinaria["Tipo_Maquina"] = Formulario_Tipado_Maquinaria!.DropDownList_Tipo_Maquina.Text ;
                                        Campos_Maquinaria["Marca"] = Formulario_Tipado_Maquinaria.TextBox_Marca.Text ;
                                        Campos_Maquinaria["Numero_Serial"] = Formulario_Tipado_Maquinaria.TextBox_Numero_Serial.Text ;
                                        Campos_Maquinaria["Historial_Propiedad"] = Formulario_Tipado_Maquinaria.DropDownList_Historial_Propiedad.Text ;
                                        Campos_Maquinaria["Maquina_Es_Nueva"] = Formulario_Tipado_Maquinaria.CheckBox_Nueva.Checked ;
                                        Campos_Maquinaria["Ano_Adquisicion"] = Formulario_Tipado_Maquinaria.NumericUpDown_Ano_Adquisicion.Value ;
                                }
                        }
                        
                        Recompilar_Campos() ;
                        if ( Campos_Animal is null && Campos_Maquinaria is null )
                        { 
                                Logica.Gestion_Productos.Gestion_Productos.Marshal_Insert_Producto_Completo( Campos_Elemento_Subasta, Campos_Producto ) ;
                                return ;
                        }
                        Logica.Gestion_Productos.Gestion_Productos.Marshal_Insert_Producto_Completo( Campos_Elemento_Subasta, Campos_Producto, ( Campos_Animal is not null ) ? Campos_Animal : Campos_Maquinaria ) ;
                }
        }
}
