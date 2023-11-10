using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Media;
using System.Reflection;
using Logica.Procesamiento_Sujetos;
using System.Windows.Markup;
using System.Diagnostics;
using MercadoPago.Http;

namespace Presentacion.Gestion_Sujetos
{
        public partial class Gestion_Sujetos : Form
        {
                Caracterizacion_Formulario Caracterizacion_Actual = Caracterizacion_Formulario.Personas;
                bool Form_Vacio
                {
                        get
                        {
                                if (ID_Persona is not null) { return false; }
                                if (IDentificador_La_Otra_Capa is not null) { return false; }
                                if (Grilla_Capas_Sujeto.DataSource is not null) { return false; }
                                return true;
                        }
                }
                bool Form_Cargado
                {
                        get
                        {
                                if (ID_Persona is null) { return false; }
                                if (Grilla_Capas_Sujeto.DataSource is null) { return false; }
                                return true;
                        }
                }
                // Se transiciona, o setea al estado `Form Cargado` cuando se llama al metodo `Cargar Capa Seleccionada`.
                bool Form_Descargado
                {
                        get
                        {
                                if (ID_Persona is not null) { return false; }
                                if (Grilla_Capas_Sujeto.DataSource is null) { return false; }
                                return true;
                        }
                        set
                        {
                                ID_Persona = null;
                                IDentificador_La_Otra_Capa = null;
                                Button_Modificar.Enabled = (Button_Eliminar.Enabled = false);
                                Button_Gestionar_Tareas.Enabled = false;
                        }
                }


                public Gestion_Sujetos()
                {
                        InitializeComponent();
                        // Establece la posicion de los botones
                        Location_Primer_Boton = Button_Personas.Location;
                        Location_Segundo_Boton = Button_Usuarios.Location;
                        Location_Tercer_Boton = Button_Empleados.Location;
                        Location_Cuarto_Boton = Button_Proveedores.Location;
                }
                int? Variable_ID_Persona = null;
                int? ID_Persona
                {
                        get { return Variable_ID_Persona; }
                        set
                        {
                                Variable_ID_Persona = value;
                                Label_ID_Persona.Text = "ID Persona = " + ((Variable_ID_Persona is not null) ? Variable_ID_Persona : "@ID_Persona");
                        }
                }

                object? Variable_IDentificador_La_Otra_Capa = null;
                object? IDentificador_La_Otra_Capa
                {
                        get { return Variable_IDentificador_La_Otra_Capa; }
                        set
                        {
                                Variable_IDentificador_La_Otra_Capa = value;
                                Label_ID_Capa.Text = "IDentificador Capa Rol = " + ((Variable_IDentificador_La_Otra_Capa is not null) ? Variable_IDentificador_La_Otra_Capa : "@ID_Capa_Rol");
                        }
                }

                // Atributos Personas
                string Nombre { get { return TextBox_Nombre.Text; } set { TextBox_Nombre.Text = value; } }
                string Apellido { get { return TextBox_Apellido.Text; } set { TextBox_Apellido.Text = value; } }
                string Telefono { get { return TextBox_Telefono.Text; } set { TextBox_Telefono.Text = value; } }

                // Atributos Usuario
                string Nombre_Identificador { get { return TextBox_Nombre_Identificador.Text; } set { TextBox_Nombre_Identificador.Text = value; } }
                bool Asignar_Nueva_Contrasena { get { return CheckBox_Nueva_Contrasena.Checked; } set { CheckBox_Nueva_Contrasena.Checked = value; } }
                string Contrasena { get { return TextBox_Contrasena.Text; } set { TextBox_Contrasena.Text = value; } }
                bool Permiso_Gestion_Comercial { get { return CheckedListBox_Permisos.GetItemChecked(0); } set { CheckedListBox_Permisos.SetItemChecked(0, value); } }
                bool Permiso_Gestion_Sujetos { get { return CheckedListBox_Permisos.GetItemChecked(1); } set { CheckedListBox_Permisos.SetItemChecked(1, value); } }
                bool Permiso_Pagar { get { return CheckedListBox_Permisos.GetItemChecked(2); } set { CheckedListBox_Permisos.SetItemChecked(2, value); } }
                bool Permiso_Publicar_Elementos { get { return CheckedListBox_Permisos.GetItemChecked(3); } set { CheckedListBox_Permisos.SetItemChecked(3, value); } }
                string Nivel_Confidencialidad
                {
                        get
                        {
                                StringBuilder Confidencialidad = new StringBuilder();
                                Confidencialidad.Append((Permiso_Gestion_Sujetos) ? '1' : '0');
                                Confidencialidad.Append((Permiso_Gestion_Comercial) ? '1' : '0');
                                Confidencialidad.Append((Permiso_Pagar) ? '1' : '0');
                                Confidencialidad.Append((Permiso_Publicar_Elementos) ? '1' : '0');
                                // Se conciente de el orden de los valores. De otra forma se puede armar un desastre.
                                return Confidencialidad.ToString();
                        }
                }
                bool Inactivo { get { return CheckBox_Inactivo.Checked; } set { CheckBox_Inactivo.Checked = value; } }

                // Atributos Empleado
                int Horas_Trabajadas { get { return (int)NumericUpDown_Horas_Trabajadas.Value; } set { NumericUpDown_Horas_Trabajadas.Value = value; } }
                // Get_Tarea( int Indice_Tarea ) {}

                // Atributos Proveedor
                bool Tiene_Empresa { get { return CheckBox_Tiene_Empresa.Checked; } set { CheckBox_Tiene_Empresa.Checked = value; } }
                string? Nombre_Empresa { get { return ((TextBox_Nombre_Empresa.Text != "") ? TextBox_Nombre_Empresa.Text : null); } set { TextBox_Nombre_Empresa.Text = value; } }
                string? Barrio { get { return ((TextBox_Barrio.Text != "") ? TextBox_Barrio.Text : null); } set { TextBox_Barrio.Text = value; } }
                string? Email_Empresa { get { return ((TextBox_Email_Empresa.Text != "") ? TextBox_Email_Empresa.Text : null); } set { TextBox_Email_Empresa.Text = value; } }
                string? Calle1 { get { return ((TextBox_Calle1.Text != "") ? TextBox_Calle1.Text : null); } set { TextBox_Calle1.Text = value; } }
                string? Calle2 { get { return ((TextBox_Calle2.Text != "") ? TextBox_Calle2.Text : null); } set { TextBox_Calle2.Text = value; } }
                string? Indicaciones { get { return ((TextBox_Indicaciones.Text != "") ? TextBox_Indicaciones.Text : null); } set { TextBox_Indicaciones.Text = value; } }

                // Buscador
                string Filtro_Busqueda { get { return DropDownList_Buscador.Text; } }
                string Argumento_Busqueda { get { return TextBox_Buscador.Text; } set { TextBox_Buscador.Text = value; } }


                #region >>---- Efectos de Sonido
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

                void Recaracterizar_Formulario(Caracterizacion_Formulario Nueva_Caracterizacion)
                {
                        if (Nueva_Caracterizacion == Caracterizacion_Actual && Grilla_Capas_Sujeto.DataSource is not null) { return; }

                        SuspendLayout();
                        // Limpiar el estado anterior del formulario
                        Limpiar_Atributos_Capa();

                        // Actualizar al nuevo estado
                        Recaracterizar_Botones(Nueva_Caracterizacion);
                        Recaracterizar_Atributos_Capa(Nueva_Caracterizacion); // Selecciona la tab correspondiente
                        Recaracterizar_Buscador(Nueva_Caracterizacion);
                        Cargar_Capas();
                        Grilla_Capas_Sujeto.ClearSelection();
                        Form_Descargado = true;
                        ResumeLayout();

                        Caracterizacion_Actual = Nueva_Caracterizacion;
                }
                Point Location_Primer_Boton;
                Point Location_Segundo_Boton;
                Point Location_Tercer_Boton;
                Point Location_Cuarto_Boton;
                void Recaracterizar_Botones(Caracterizacion_Formulario Boton_Seleccionado)
                { // Se encarga de alterar el formulario poniendo los botones en su posicion correcta, en base al boton que fue seleccionado, el cual va primero.
                        switch (Boton_Seleccionado)
                        {
                                case Caracterizacion_Formulario.Personas:
                                        Button_Personas.Location = Location_Primer_Boton;
                                        Button_Usuarios.Location = Location_Segundo_Boton;
                                        Button_Empleados.Location = Location_Tercer_Boton;
                                        Button_Proveedores.Location = Location_Cuarto_Boton;
                                        break;
                                case Caracterizacion_Formulario.Usuarios:
                                        Button_Usuarios.Location = Location_Primer_Boton;
                                        Button_Personas.Location = Location_Segundo_Boton;
                                        Button_Empleados.Location = Location_Tercer_Boton;
                                        Button_Proveedores.Location = Location_Cuarto_Boton;
                                        break;
                                case Caracterizacion_Formulario.Empleados:
                                        Button_Empleados.Location = Location_Primer_Boton;
                                        Button_Personas.Location = Location_Segundo_Boton;
                                        Button_Usuarios.Location = Location_Tercer_Boton;
                                        Button_Proveedores.Location = Location_Cuarto_Boton;
                                        break;
                                case Caracterizacion_Formulario.Proveedores:
                                        Button_Proveedores.Location = Location_Primer_Boton;
                                        Button_Personas.Location = Location_Segundo_Boton;
                                        Button_Usuarios.Location = Location_Tercer_Boton;
                                        Button_Empleados.Location = Location_Cuarto_Boton;
                                        break;
                        }
                        Caracterizacion_Actual = Boton_Seleccionado;
                }
                void Recaracterizar_Atributos_Capa(Caracterizacion_Formulario Nueva_Caracterizacion)
                {
                        switch (Nueva_Caracterizacion)
                        {
                                case Caracterizacion_Formulario.Personas: Atributos_Capa.SelectedTab = Personas; break;
                                case Caracterizacion_Formulario.Usuarios: Atributos_Capa.SelectedTab = Usuarios; break;
                                case Caracterizacion_Formulario.Empleados: Atributos_Capa.SelectedTab = Empleados; break;
                                case Caracterizacion_Formulario.Proveedores: Atributos_Capa.SelectedTab = Proveedores; break;
                        }
                }
                void Recaracterizar_Diseno_DropDownList_Busqueda(Caracterizacion_Formulario Nueva_Caracterizacion)
                {
                        switch (Nueva_Caracterizacion)
                        {
                                case Caracterizacion_Formulario.Personas:
                                        DropDownList_Buscador.BorderColor = Color.OliveDrab;
                                        DropDownList_Buscador.ButtonColor = Color.YellowGreen;
                                        DropDownList_Buscador.BackColor = Color.FromArgb(190, 255, 150);
                                        break;
                                case Caracterizacion_Formulario.Usuarios:
                                        DropDownList_Buscador.BorderColor = Color.Navy;
                                        DropDownList_Buscador.ButtonColor = Color.CadetBlue;
                                        DropDownList_Buscador.BackColor = Color.FromArgb(192, 192, 255);
                                        break;
                                case Caracterizacion_Formulario.Empleados:
                                        DropDownList_Buscador.BorderColor = Color.Chocolate;
                                        DropDownList_Buscador.ButtonColor = Color.FromArgb(255, 140, 50);
                                        DropDownList_Buscador.BackColor = Color.Khaki;
                                        break;
                                case Caracterizacion_Formulario.Proveedores:
                                        DropDownList_Buscador.BorderColor = Color.Indigo;
                                        DropDownList_Buscador.ButtonColor = Color.SlateBlue;
                                        DropDownList_Buscador.BackColor = Color.Thistle;
                                        break;
                                default: throw new Exception("Fallo de cohesion.");
                        }
                }

                /// <summary>
                /// Actualiza el placeholder de la barra de buqueda, se conciente,
                /// depende del estado *actual* de la barra de busqueda.
                /// </summary>
                void Actualizar_Placeholder_Busqueda()
                {
                        string Singular_De_La_Capa_Actual;
                        switch (Caracterizacion_Actual)
                        {
                                case Caracterizacion_Formulario.Personas: Singular_De_La_Capa_Actual = "Persona"; break;
                                case Caracterizacion_Formulario.Usuarios: Singular_De_La_Capa_Actual = "Usuario"; break;
                                case Caracterizacion_Formulario.Empleados: Singular_De_La_Capa_Actual = "Empleado"; break;
                                case Caracterizacion_Formulario.Proveedores: Singular_De_La_Capa_Actual = "Proveedor"; break;
                                default: throw new Exception("Fallo de cohesion");
                        }
                        TextBox_Buscador.PlaceholderText = $"Buscar {Singular_De_La_Capa_Actual} por `{DropDownList_Buscador.Text.Replace('_', ' ')}`.";
                }
                void Recaracterizar_Buscador(Caracterizacion_Formulario Nueva_Caracterizacion)
                {
                        Recaracterizar_Diseno_DropDownList_Busqueda(Nueva_Caracterizacion);
                        Actualizar_Filtros_Busqueda(Nueva_Caracterizacion);
                        Actualizar_Placeholder_Busqueda();
                }
                void Actualizar_Filtros_Busqueda(Caracterizacion_Formulario Nueva_Caracterizacion)
                {
                        string[] Columnas_Capa = Procesamiento_Sujetos.Get_Columnas_Capa(Nueva_Caracterizacion);

                        // Actualizar los filtros de busqueda de la capa
                        DropDownList_Buscador.Items.Clear();
                        foreach (string Columna_Capa in Columnas_Capa) { DropDownList_Buscador.Items.Add(Columna_Capa.Replace('_', ' ')); }
                        DropDownList_Buscador.SelectedIndex = 0;
                }
                void Limpiar_Atributos_Capa()
                {
                        void Limpiar_Atributos_Persona()
                        {
                                Nombre = "";
                                Apellido = "";
                                Telefono = "";
                        }
                        void Limpiar_Atributos_Usuario()
                        {
                                Nombre_Identificador = "";
                                Contrasena = "";
                                CheckedListBox_Permisos.ClearSelected();
                                Inactivo = false;
                        }
                        void Limpiar_Atributos_Empleado()
                        {
                                Horas_Trabajadas = 0;
                                // Form_Tareas_Asignadas.Limpiar_Tareas() ;
                        }
                        void Limpiar_Atributos_Proveedores()
                        {
                                Tiene_Empresa = false;
                                Barrio = "";
                                Calle1 = "";
                                Calle2 = "";
                                Indicaciones = "";
                        }

                        switch (Caracterizacion_Actual)
                        {
                                case Caracterizacion_Formulario.Personas: Limpiar_Atributos_Persona(); break;
                                case Caracterizacion_Formulario.Usuarios: Limpiar_Atributos_Usuario(); break;
                                case Caracterizacion_Formulario.Empleados: Limpiar_Atributos_Empleado(); break;
                                case Caracterizacion_Formulario.Proveedores: Limpiar_Atributos_Proveedores(); break;
                        }
                }
                void Cargar_Capas(string Filtro_Busqueda = "", string Argumento_Busqueda = "")
                {
                        DataTable? Capas_Sujeto = Procesamiento_Sujetos.Get_Capas_Sujeto(Caracterizacion_Actual, Filtro_Busqueda, Argumento_Busqueda);
                        Grilla_Capas_Sujeto.DataSource = Capas_Sujeto;

                        // Mueve la fila en blanco a la primera posicion
                        // Grilla_Capas_Sujeto.FirstDisplayedScrollingRowIndex = Grilla_Capas_Sujeto.NewRowIndex ;
                        /*  Mover la fila nueva parece no funcionar
                         *  La solucion que se me ocurre es hacer lo que hice en otros forms, hacer una "plantilla"
                         *  cuando clickas el boton "crear" una vez, y guardarla cuando lo clickas de vuelta.
                         *  Pero seria ponerme a solucionar un problema que aun no existe y no tengo tiempo para eso.
                         */
                }
                void Cargar_Capa_Seleccionada()
                {
                        if (Grilla_Capas_Sujeto.SelectedRows.Count == 0) { return; } // Esto ocurre cuando el usuario usa el CTRL + click
                        void Actualizar_ID_Rol(DataGridViewCellCollection Capa_Actual)
                        {
                                switch (Caracterizacion_Actual)
                                {
                                        case Caracterizacion_Formulario.Personas:
                                                Label_ID_Capa.Text = "IDentificador Capa Rol = @ID_Capa_Rol";
                                                return;
                                                break;
                                        case Caracterizacion_Formulario.Usuarios: IDentificador_La_Otra_Capa = Capa_Actual["Nombre_Identificador"].Value.ToString()!; break;
                                        case Caracterizacion_Formulario.Empleados: IDentificador_La_Otra_Capa = Capa_Actual["ID"].Value.ToString()!; break;
                                        case Caracterizacion_Formulario.Proveedores: IDentificador_La_Otra_Capa = Capa_Actual["ID_Proveedor"].Value.ToString()!; break;
                                }
                        }
                        void Actualizar_ID_Persona(Caracterizacion_Formulario Caracterizacion, DataGridViewCellCollection Capa_Seleccionada)
                        {
                                if (Caracterizacion == Caracterizacion_Formulario.Personas) { ID_Persona = Convert.ToInt32(Capa_Seleccionada["ID"].Value); return ;}
                                object Identificcador_Capa = new object();
                                switch (Caracterizacion)
                                {
                                        case Caracterizacion_Formulario.Usuarios: Identificcador_Capa = Capa_Seleccionada["Nombre_Identificador"].Value; break;
                                        case Caracterizacion_Formulario.Empleados: Identificcador_Capa = Capa_Seleccionada["ID"].Value; break;
                                        case Caracterizacion_Formulario.Proveedores: Identificcador_Capa = Capa_Seleccionada["ID_Proveedor"].Value; break;
                                }
                                ID_Persona = Procesamiento_Sujetos.Get_ID_Persona_De_Capa_Rol(Caracterizacion, Identificcador_Capa);
                        }

                        void Cargar_Persona(DataGridViewCellCollection Persona_Seleccionada)
                        {
                                Nombre = Persona_Seleccionada["Nombre"].Value.ToString()!;
                                Apellido = Persona_Seleccionada["Apellido"].Value.ToString()!;
                                Telefono = Persona_Seleccionada["Telefono"].Value.ToString()!;
                        }
                        void Cargar_Usuario(DataGridViewCellCollection Usuario_Seleccionado)
                        {
                                // if ( Editar_Hash_Contrasena ) { Usuario_Seleccionado["Contrasena].Value.ToString()! ; }

                                Nombre_Identificador = Usuario_Seleccionado["Nombre_Identificador"].Value.ToString()!;
                                Inactivo = Convert.ToBoolean(Usuario_Seleccionado["Inactivo"].Value);
                                // Cargar permisos
                                string Confidencialidad = Usuario_Seleccionado["Nivel_Confidencialidad"].Value.ToString()!;

                                Permiso_Gestion_Sujetos = (Confidencialidad[0] == '1');
                                Permiso_Gestion_Comercial = (Confidencialidad[1] == '1');
                                Permiso_Pagar = (Confidencialidad[2] == '1');
                                Permiso_Publicar_Elementos = (Confidencialidad[3] == '1');
                        }
                        void Cargar_Empleado(DataGridViewCellCollection Empleado_Seleccionado) { Horas_Trabajadas = Convert.ToInt32(Empleado_Seleccionado["Horas_Trabajadas"].Value); }
                        void Cargar_Proveedor(DataGridViewCellCollection Proveedor_Seleccionado)
                        {
                                Tiene_Empresa = (Proveedor_Seleccionado["Nombre_Empresa"].Value.ToString() != "");
                                CheckBox_Tiene_Empresa.Checked = Tiene_Empresa;
                                if (!Tiene_Empresa) { return; }

                                Nombre_Empresa = Proveedor_Seleccionado["Nombre_Empresa"].Value.ToString()!;
                                Email_Empresa = Proveedor_Seleccionado["Email_Empresa"].Value.ToString();
                                Barrio = Proveedor_Seleccionado["Barrio"].Value.ToString()!;
                                Calle1 = Proveedor_Seleccionado["Calle1"].Value.ToString()!;
                                Calle2 = Proveedor_Seleccionado["Calle2"].Value.ToString()!;
                                Indicaciones = ((Proveedor_Seleccionado["Indicaciones"].Value is not null) ? Proveedor_Seleccionado["Indicaciones"].Value.ToString()! : "");
                        }

                        DataGridViewCellCollection Capa_Seleccionada = Grilla_Capas_Sujeto.SelectedRows[0].Cells;

                        switch (Caracterizacion_Actual)
                        {
                                case Caracterizacion_Formulario.Personas: Cargar_Persona(Capa_Seleccionada); break;
                                case Caracterizacion_Formulario.Usuarios: Cargar_Usuario(Capa_Seleccionada); break;
                                case Caracterizacion_Formulario.Empleados: Cargar_Empleado(Capa_Seleccionada); break;
                                case Caracterizacion_Formulario.Proveedores: Cargar_Proveedor(Capa_Seleccionada); break;
                                default: throw new Exception("Fallo de cohesion.");
                        }

                        // Grilla_Capas_Sujeto.ClearSelection();
                        // Cambios de transicion al estado Form Cargado
                        Actualizar_ID_Rol(Capa_Seleccionada);
                        Actualizar_ID_Persona(Caracterizacion_Actual, Capa_Seleccionada);
                        Button_Eliminar.Enabled = (Button_Modificar.Enabled = true);
                        CheckBox_Nueva_Contrasena.Enabled = true;
                        Button_Gestionar_Tareas.Enabled = true;

                }
                void Reseleccionar_Capa(object? IDentificador_Nueva_Capa)
                {
                        switch (Caracterizacion_Actual)
                        {
                                case Caracterizacion_Formulario.Usuarios:
                                        foreach (DataGridViewRow Capa in Grilla_Capas_Sujeto.Rows)
                                        {
                                                if (Capa.IsNewRow) { continue; }
                                                if (Capa.Cells["Nombre_Identificador"].Value.ToString()! == IDentificador_Nueva_Capa!.ToString()) { Capa.Selected = true; return; }
                                        }
                                        break;
                                case Caracterizacion_Formulario.Proveedores:
                                        foreach (DataGridViewRow Capa in Grilla_Capas_Sujeto.Rows)
                                        {
                                                if (Capa.IsNewRow) { continue; }
                                                if (Convert.ToInt32(Capa.Cells["ID_Proveedor"].Value) == Convert.ToInt32(IDentificador_Nueva_Capa)) { Capa.Selected = true; return; }
                                        }
                                        break;
                                default:
                                        foreach (DataGridViewRow Capa in Grilla_Capas_Sujeto.Rows)
                                        {
                                                if (Capa.IsNewRow) { continue; }
                                                if (Convert.ToInt32(Capa.Cells["ID"].Value) == Convert.ToInt32(IDentificador_Nueva_Capa)) { Capa.Selected = true; return; }
                                        }
                                        break;
                        }
                }
                /// <summary>
                /// Recompila la informacion de la capa en cuestion.
                /// </summary>
                /// <param name="ID_Sujeto_Capa_Rol_A_Crear">En caso de estar presente, se usa esta ID para crear una capa y que esta sea asignada al Sujeto de esta ID. De lo contrario se recoje la ID de Persona del formulario.</param>
                /// <returns></returns>
                /// <exception cref="Exception"></exception>
                Dictionary<string, object?> Recompilar_Campos_Capa(int? ID_Sujeto_Capa_Rol_A_Crear)
                {
                        Dictionary<string, object?> Campos_Capa = new Dictionary<string, object?>();
                        void Recompilar_Campos_Persona()
                        {
                                Campos_Capa["ID"] = ((ID_Sujeto_Capa_Rol_A_Crear is not null) ? ID_Sujeto_Capa_Rol_A_Crear : ID_Persona!); // Campos_Capa["ID_Persona"] = ((ID_Sujeto_Capa_Rol_A_Crear is not null) ? ID_Sujeto_Capa_Rol_A_Crear : ID_Persona!);
                                Campos_Capa["Nombre"] = Nombre;
                                Campos_Capa["Apellido"] = Apellido;
                                Campos_Capa["Telefono"] = Telefono;
                        }
                        void Recompilas_Campos_Usuario()
                        {
                                // Esta es una adaptacion de una solucion dada por ChatGPT.
                                string Get_Hash_SHA256(string Contrasena)
                                {
                                        using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
                                        {
                                                string Hash_Contrasena; // El hash de la Contrasena en formato alphanumerico(string de toda la vida).
                                                byte[] Bytes_Contrasena; // Es la Contrasena en bytes
                                                byte[] Bytes_Hash_Contrasena; // Es el hash de la Contrasena en bytes

                                                Bytes_Contrasena = System.Text.Encoding.UTF8.GetBytes(Contrasena);
                                                Bytes_Hash_Contrasena = sha256.ComputeHash(Bytes_Contrasena);

                                                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                                                for (int i = 0; i < Bytes_Hash_Contrasena.Length; i++) { builder.Append(Bytes_Hash_Contrasena[i].ToString("x2")); } // Convierte a hexadecimal

                                                Hash_Contrasena = builder.ToString();
                                                return Hash_Contrasena;
                                        }
                                }
                                bool Se_Ingreso_Un_Nuevo_Nombre()
                                {
                                        if (Form_Descargado) { return false; }
                                        return IDentificador_La_Otra_Capa.ToString() != Nombre_Identificador;
                                }

                                Campos_Capa["ID_Persona"] = ((ID_Sujeto_Capa_Rol_A_Crear is not null) ? ID_Sujeto_Capa_Rol_A_Crear : ID_Persona!);
                                Campos_Capa["Nombre_Identificador"] = Nombre_Identificador; // IDentificador_La_Otra_Capa!;
                                if (Se_Ingreso_Un_Nuevo_Nombre()) { Campos_Capa["Nombre_Identificador_Actual"] = IDentificador_La_Otra_Capa; }
                                if (Asignar_Nueva_Contrasena) { Campos_Capa["Contrasena"] = Get_Hash_SHA256(Contrasena); }
                                Campos_Capa["Nivel_Confidencialidad"] = Nivel_Confidencialidad;
                                Campos_Capa["Inactivo"] = Inactivo;
                        }
                        void Recompilar_Campos_Empleado()
                        {
                                Campos_Capa["ID_Persona"] = ((ID_Sujeto_Capa_Rol_A_Crear is not null) ? ID_Sujeto_Capa_Rol_A_Crear : ID_Persona!);
                                Campos_Capa["ID"] = IDentificador_La_Otra_Capa;
                                Campos_Capa["Horas_Trabajadas"] = Horas_Trabajadas;
                        }
                        void Recompilar_Campos_Proveedor()
                        {
                                Campos_Capa["ID_Persona"] = ((ID_Sujeto_Capa_Rol_A_Crear is not null) ? ID_Sujeto_Capa_Rol_A_Crear : ID_Persona!);
                                Campos_Capa["ID_Proveedor"] = IDentificador_La_Otra_Capa;
                                Campos_Capa["Nombre_Empresa"] = Nombre_Empresa;
                                Campos_Capa["Email_Empresa"] = Email_Empresa;
                                Campos_Capa["Barrio"] = Barrio;
                                Campos_Capa["Calle1"] = Calle1;
                                Campos_Capa["Calle2"] = Calle2;
                                Campos_Capa["Indicaciones"] = Indicaciones!;
                        }

                        switch (Caracterizacion_Actual)
                        {
                                case Caracterizacion_Formulario.Personas: Recompilar_Campos_Persona(); break;
                                case Caracterizacion_Formulario.Usuarios: Recompilas_Campos_Usuario(); break;
                                case Caracterizacion_Formulario.Empleados: Recompilar_Campos_Empleado(); break;
                                case Caracterizacion_Formulario.Proveedores: Recompilar_Campos_Proveedor(); break;
                                default: throw new Exception("Fallo de cohesion");
                        }
                        return Campos_Capa;

                }
                Dictionary<string, object?> Get_Aributos_Capa()//Este quizas necesite ser removido, o quizas no despues veo
                {
                        void Get_Atributos_Persona(ref Dictionary<string, object?> Atributos_Persona)
                        {
                                Atributos_Persona["ID"] = ID_Persona; // Puede ser null
                                Atributos_Persona["Nombre"] = Nombre;
                                Atributos_Persona["Apellido"] = Apellido;
                                Atributos_Persona["Telefono"] = Telefono;
                        }
                        void Get_Atributos_Usuario(ref Dictionary<string, object?> Atributos_Usuario)
                        {
                                Atributos_Usuario["Nombre_Identificador"] = Nombre_Identificador!;
                                //Atributos_Usuario["Contrasena"] = Get_Hash( Contrasena ) ;
                                Atributos_Usuario["Nivel_Confidencialidad"] = Nivel_Confidencialidad;
                                Atributos_Usuario["Inactivo"] = Inactivo;
                        }
                        void Get_Atributos_Empleado(ref Dictionary<string, object?> Atributos_Empleado)
                        {
                                Atributos_Empleado["ID"] = IDentificador_La_Otra_Capa; // Puede ser null
                                Atributos_Empleado["Horas_Trabajadas"] = Horas_Trabajadas;
                                // Las tareas son manejadas de forma independiente en el form `Gestion de Tareas Empleado` y su gestion es independiente a la gestion del resto de la capa.
                        }
                        void Get_Atributos_Proveedor(ref Dictionary<string, object?> Atributos_Proveedor)
                        {
                                Atributos_Proveedor["ID"] = IDentificador_La_Otra_Capa!;
                                Atributos_Proveedor["Nombre_Empresa"] = Nombre_Empresa!;
                                Atributos_Proveedor["Barrio"] = Barrio!;
                                Atributos_Proveedor["Calle1"] = Calle1!;
                                Atributos_Proveedor["Calle2"] = Calle2!;
                                Atributos_Proveedor["Indicaciones"] = Indicaciones!;
                        }

                        Dictionary<string, object?> Atributos_Capa = new Dictionary<string, object?>();
                        switch (Caracterizacion_Actual)
                        {
                                case Caracterizacion_Formulario.Personas: Get_Atributos_Persona(ref Atributos_Capa); break;
                                case Caracterizacion_Formulario.Usuarios: Get_Atributos_Usuario(ref Atributos_Capa); break;
                                case Caracterizacion_Formulario.Empleados: Get_Atributos_Empleado(ref Atributos_Capa); break;
                                case Caracterizacion_Formulario.Proveedores: Get_Atributos_Proveedor(ref Atributos_Capa); break;
                        }
                        return Atributos_Capa;
                }
                bool Se_Cambio_El_Nombre_Del_Usuario() { return (Caracterizacion_Actual == Caracterizacion_Formulario.Usuarios && Nombre_Identificador != IDentificador_La_Otra_Capa /* .ToString() */ ); }

                // Recaracterizar formulario
                private void Button_Personas_Click(object sender, EventArgs e) { Recaracterizar_Formulario(Caracterizacion_Formulario.Personas); }
                private void Button_Usuarios_Click(object sender, EventArgs e) { Recaracterizar_Formulario(Caracterizacion_Formulario.Usuarios); }
                private void Button_Empleados_Click(object sender, EventArgs e) { Recaracterizar_Formulario(Caracterizacion_Formulario.Empleados); }
                private void Button_Proveedores_Click(object sender, EventArgs e) { Recaracterizar_Formulario(Caracterizacion_Formulario.Proveedores); }

                // Dinamicas del buscador
                private void TextBox_Buscador_KeyPress(object sender, KeyPressEventArgs e) { if (((Keys)e.KeyChar == Keys.Enter)) { Cargar_Capas(Filtro_Busqueda.Replace(' ', '_'), Argumento_Busqueda + '%'); } }
                private void DropDownList_Buscador_SelectedIndexChanged(object sender, EventArgs e) { Actualizar_Placeholder_Busqueda(); TextBox_Buscador_TextChanged(this, EventArgs.Empty); }

                // Dinamicas de la grilla
                private void Grilla_Capas_Sujeto_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                        if (Grilla_Capas_Sujeto.SelectedRows.Count > 1) { throw new Exception("No se debe poder seleccionar mas de una fila."); }
                        if (Grilla_Capas_Sujeto.SelectedRows.Count == 0 || Grilla_Capas_Sujeto.SelectedRows[0].IsNewRow)
                        {
                                Limpiar_Atributos_Capa();
                                Form_Descargado = true;
                                return;
                        }
                        Cargar_Capa_Seleccionada();
                }
                private void Grilla_Capas_Sujeto_DoubleClick(object sender, EventArgs e)
                {
                        if (Grilla_Capas_Sujeto.SelectedRows.Count > 1) { throw new Exception("No se debe poder seleccionar mas de una fila."); }
                        if (Grilla_Capas_Sujeto.SelectedRows.Count == 0 || Grilla_Capas_Sujeto.SelectedRows[0].IsNewRow)
                        {
                                Limpiar_Atributos_Capa();
                                Form_Descargado = true;
                                return;
                        }
                }

                // Opciones de edicion de capas
                private void CheckBox_Tiene_Empresa_CheckedChanged(object sender, EventArgs e)
                {
                        TextBox_Nombre_Empresa.Enabled = TextBox_Email_Empresa.Enabled =
                        TextBox_Barrio.Enabled = TextBox_Calle1.Enabled = TextBox_Calle2.Enabled =
                        TextBox_Indicaciones.Enabled = (Tiene_Empresa);

                        Nombre_Empresa = Email_Empresa = Barrio =
                        Calle1 = Calle2 = Indicaciones = "";
                }
                private void CheckBox_Nueva_Contrasena_CheckedChanged(object sender, EventArgs e)
                {
                        TextBox_Contrasena.Enabled = Asignar_Nueva_Contrasena;
                        if (!Asignar_Nueva_Contrasena) { TextBox_Contrasena.Text = ""; }
                }

                // MessageBoxes
                void Mostrar_MessageBox_Se_Necesita_Una_Contrasena()
                {
                        MessageBox.Show
                        (
                                caption: "Falta una contraseña",
                                text: "Ingresa una contraseña para poder crear el Usuario. Los Usuarios sin contraseña no son permitidos.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Falta_Un_Nombre_Identificador()
                {
                        MessageBox.Show
                        (
                                caption: "Falta un Nombre Identificador.",
                                text: "Ingresa un Nombre Identificador para crear el Usuario.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Nombre_Identificador_Ya_Tomado()
                {
                        MessageBox.Show
                        (
                                caption: "Nombre Identificador ya tomado.",
                                text: $"El Nombre Identificador `{Nombre_Identificador}`ya es propiedad de otro Usuario. Selecciona otro.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                DialogResult Mostrar_MessageBox_Confirmar_Contrasena_Corta()
                {
                        DialogResult Eleccion_Usuario =
                        MessageBox.Show
                        (
                                caption: "La contraseña seleccionada es corta.",
                                text: "La contraseña que indicaste es bastante corta y sencilla de sobrepasar.\nSe continuará con la contraseña que seleccionaste de igual forma.",
                                buttons: MessageBoxButtons.OKCancel,
                                icon: MessageBoxIcon.Warning,
                                owner: this
                        );
                        return Eleccion_Usuario;
                }
                void Mostrar_MessageBox_Informacion_Parcial_Empresa()
                {
                        MessageBox.Show
                        (
                                caption: "Se proporcionó información parcial sobre la empresa.",
                                text: "Llena todos los datos de la empresa para registrarte representando a una.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Faltan_Campos_Persona()
                {
                        MessageBox.Show
                        (
                                caption: "Falta información personal.",
                                text: "Se requiere el nombre, el apellido y un telefono para registrar a una Persona.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }

                // Validacion
                bool Se_Puede_Crear_La_Capa()
                {
                        bool Se_Puede_Crear_La_Persona()
                        {
                                if (Nombre == "" || Apellido == "" || Telefono == "") { Mostrar_MessageBox_Faltan_Campos_Persona(); return false; }
                                return true;
                        }
                        bool Se_Puede_Crear_El_Usuario()
                        {
                                if (string.IsNullOrWhiteSpace(Nombre_Identificador)) { Mostrar_MessageBox_Falta_Un_Nombre_Identificador(); return false; }
                                if (!Asignar_Nueva_Contrasena || string.IsNullOrWhiteSpace(Contrasena))
                                {
                                        Mostrar_MessageBox_Se_Necesita_Una_Contrasena();
                                        Asignar_Nueva_Contrasena = true;
                                        CheckBox_Nueva_Contrasena.Enabled = false;
                                        return false;
                                }
                                if ( Se_Cambio_El_Nombre_Del_Usuario() && Procesamiento_Sujetos.Nombre_Identificador_Ya_Existente(Nombre_Identificador)) { Mostrar_MessageBox_Nombre_Identificador_Ya_Tomado(); return false; }
                                if (Contrasena.Length < 8 && Mostrar_MessageBox_Confirmar_Contrasena_Corta() != DialogResult.OK) { return false; }
                                return true;
                        }
                        bool Se_Puede_Crear_El_Proveedor()
                        {
                                if (!Tiene_Empresa) { return true; }
                                if (!(Nombre_Empresa is not null && Email_Empresa is not null && Barrio is not null && Calle1 is not null && Calle2 is not null))
                                { Mostrar_MessageBox_Informacion_Parcial_Empresa(); return false; }
                                return true;
                        }

                        switch (Caracterizacion_Actual)
                        {
                                case Caracterizacion_Formulario.Personas: return Se_Puede_Crear_La_Persona();
                                case Caracterizacion_Formulario.Usuarios: return Se_Puede_Crear_El_Usuario();
                                case Caracterizacion_Formulario.Empleados: return true;
                                case Caracterizacion_Formulario.Proveedores: return Se_Puede_Crear_El_Proveedor();
                                default: throw new Exception("Fallo de cohesion");
                        }
                }

                // Gestion de Sujetos
                private void Button_Modificar_Click(object sender, EventArgs e)
                {
                        if (Form_Vacio || Form_Descargado) { throw new InvalidOperationException("No se puede modificar una capa cuando el form esta vacio o descargado, pues no hay ninguna que modificar."); }

                        if (Caracterizacion_Actual == Caracterizacion_Formulario.Usuarios && IDentificador_La_Otra_Capa == null) { throw new InvalidOperationException("No se puede modificar a un Usuario si no se tiene la IDentificacion actual del sistema."); }
                        if (!Se_Puede_Crear_La_Capa()) { return; }
                        Procesamiento_Sujetos.Modificar_Capa(Caracterizacion_Actual, (Dictionary<string, object>)Recompilar_Campos_Capa(null)!);
                        Cargar_Capas();

                        if (Se_Cambio_El_Nombre_Del_Usuario()) { IDentificador_La_Otra_Capa = Nombre_Identificador; }
                        Reseleccionar_Capa((Caracterizacion_Actual == Caracterizacion_Formulario.Personas ? ID_Persona : IDentificador_La_Otra_Capa));
                        Cargar_Capa_Seleccionada();
                        Reproducir_Tono_Modificado();
                }
                private void Button_Eliminar_Click(object sender, EventArgs e)
                {
                        { // Checkea que la operacion es valida
                                if (Form_Vacio || Form_Descargado) { throw new InvalidOperationException("No se puede eliminar una capa cuando el form esta vacio o descargado, pues no hay ninguna que eliminar."); }
                                if (Caracterizacion_Actual == Caracterizacion_Formulario.Personas && ID_Persona is null) { throw new InvalidOperationException("Se trato de borrar una capa Persona cuando no hay una seleccionada."); }
                                if (Caracterizacion_Actual != Caracterizacion_Formulario.Personas && IDentificador_La_Otra_Capa is null) { throw new InvalidOperationException("Se trato de eliminar una capa de rol cuando no hay una seleccionada."); }
                                if (Grilla_Capas_Sujeto.SelectedRows[0].IsNewRow) { throw new InvalidOperationException("No se puede eliminar la capa porque la fila es newrow."); }
                        }
                        Procesamiento_Sujetos.Eliminar_Capa(Caracterizacion_Actual, ((Caracterizacion_Actual == Caracterizacion_Formulario.Personas) ? ID_Persona : IDentificador_La_Otra_Capa)!);
                        Limpiar_Atributos_Capa();
                        Cargar_Capas();
                        Form_Descargado = true;
                        Grilla_Capas_Sujeto.ClearSelection();
                        Reproducir_Tono_Producto_Eliminado();
                }
                private void Button_Crear_Click(object sender, EventArgs e)
                {
                        if (!Se_Puede_Crear_La_Capa()) { return; }

                        object? ID_Nueva_Capa;
                        if (Caracterizacion_Actual != Caracterizacion_Formulario.Personas)
                        {
                                Seleccion_Sujeto_Capa Form_Seleccionar_Sujeto = new Seleccion_Sujeto_Capa(Caracterizacion_Actual);
                                Form_Seleccionar_Sujeto.ShowDialog(owner: this);
                                if (Form_Seleccionar_Sujeto.ID_Persona_Sujeto_Seleccionado is null) { return; }
                                ID_Nueva_Capa = Procesamiento_Sujetos.Crear_Capa_O_Entidad(Caracterizacion_Actual, Recompilar_Campos_Capa(Form_Seleccionar_Sujeto.ID_Persona_Sujeto_Seleccionado));
                        }
                        else { ID_Nueva_Capa = Procesamiento_Sujetos.Crear_Capa_O_Entidad(Caracterizacion_Actual, Recompilar_Campos_Capa(null)); }
                        Cargar_Capas();
                        Reseleccionar_Capa((Caracterizacion_Actual != Caracterizacion_Formulario.Usuarios ? ID_Nueva_Capa : Nombre_Identificador));
                        Cargar_Capa_Seleccionada();
                        Reproducir_Tono_Producto_Guardado();
                }

                // Seguridad del input de textboxes
                string Nombre_Respaldo = "";
                string Apellido_Respaldo = "";
                string Telefono_Respaldo = "";
                string Respaldo_Email_Empresa = "";
                string Respaldo_Buscador = "";
                private void TextBox_Nombre_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Nombre,
                                ref Nombre_Respaldo,
                                Numeros_Estan_Permitidos: false,
                                Letras_Estan_Permitidas: true,
                                Espacios_Estan_Permitidos: false
                        );
                }
                private void TextBox_Apellido_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Apellido,
                                ref Apellido_Respaldo,
                                Numeros_Estan_Permitidos: false,
                                Letras_Estan_Permitidas: true,
                                Espacios_Estan_Permitidos: false
                        );
                }
                private void TextBox_Telefono_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Telefono,
                                ref Telefono_Respaldo,
                                Numeros_Estan_Permitidos: true,
                                Letras_Estan_Permitidas: false,
                                Espacios_Estan_Permitidos: false
                        );
                }
                private void TextBox_Email_Empresa_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Email_Empresa,
                                ref Respaldo_Email_Empresa,
                                Numeros_Estan_Permitidos: true,
                                Letras_Estan_Permitidas: true,
                                Espacios_Estan_Permitidos: false
                        );
                }
                private void TextBox_Buscador_TextChanged(object sender, EventArgs e)
                {
                        bool Permitir_Letras = false;
                        bool Permitir_Numeros = false;
                        bool Permitir_Espacos = false;
                        switch (Filtro_Busqueda)
                        {
                                case "ID" or "ID Proveedor" or "Telefono" or "Telefono Empresa": Permitir_Numeros = true; break;
                                case "Nombre" or "Apellido": Permitir_Letras = true; break;
                                case "Nombre Identificador": Permitir_Letras = (Permitir_Numeros = (Permitir_Espacos = true)); break;
                                case "Nivel Confidencialidad": Permitir_Numeros = true; break;
                                case "Email" or "Email Empresa": Permitir_Letras = (Permitir_Numeros = true); break;
                                case "Horas Trabajadas": Permitir_Numeros = true; break;
                                default: Permitir_Letras = (Permitir_Numeros = (Permitir_Espacos = true)); break;
                        }

                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Buscador,
                                ref Respaldo_Buscador,
                                Numeros_Estan_Permitidos: Permitir_Numeros,
                                Letras_Estan_Permitidas: Permitir_Letras,
                                Espacios_Estan_Permitidos: Permitir_Espacos
                        );
                }
        }
}
