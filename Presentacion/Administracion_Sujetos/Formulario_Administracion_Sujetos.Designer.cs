# define DEBUG_Administracion_Sujetos 
# define DEBUG_Atributos_Capa
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;

// using Logica.Interfaz_Base_Datos;

namespace Presentacion.Administracion_Sujetos
{

        partial class Formulario_Administracion_Sujetos
        {
                public enum Caracterizacion_Formulario
                {
                        Personas,
                        Usuarios,
                        Empleados,
                        Proveedores
                }

                # region >>---- Componenetes del Formulario
                public class Selector_Capas : Panel
                {
                        // Siendo Selector de Capas una clase y siendo el Formulario de Administracion de Usuarios una clase totalmente diferente...
                        // No es posible asignar un handler que pertenece a una instancia de el formulario a una instancia de el Selector de Capas es necesario hacer cambios a la arquitectura
                        // de ambos para que tal cosa sea posible.

                        // La mas rapida y sencilla seria hacer que los botones que aparecen en el selector "pertenezcan" al formulario y no al selector; osea que sean definidos en el scope
                        // del formulario, esto rompe la encapsulacion logica que tiene el selector con el formulario y hasta cierto punto viola la modularidad de ese elemento en el formulario
                        // , la cual busco para simplificar el diseno del formulario. Ninguna de las dos cosas me agrada, para nada.

                        // Termine optando por crear una clase capaz de alterarse a si misma en vez de requerir ser reconstruida.
                        // Asi que para probocar un cambio en el selector, en vez de recontruirlo para que sea de diferente forma, opto por que el objeto del selector sea capaz de cambiarse a 
                        // si mismo para que se vuelva de la manera que se espera que sea. Con esto me evito el lio de sincronizar instancias y/o referencias/acceso por parte de las instnacia
                        // s del selector y el formulario.
                        // Esto parece ir en contra de la mayoria de sistemas creados en C# como por ejemplo los componentes graficos y demas donde se da ese "cambio por recontruccion" en vez
                        // de este "cambio por alteracion", pero creo que la simplicidad que aporta vale romper con ese paradigma tan comun.

#if DEBUG_Administracion_Sujetos
                        public Button Button_Personas;
                        public Button Button_Usuarios;
                        public Button Button_Empleados;
                        public Button Button_Proveedores;
#else
                        private Button Button_Personas;
                        private Button Button_Usuarios;
                        private Button Button_Empleados;
                        private Button Button_Proveedores;
#endif
                        // Los botones siguen el orden: Personas, Usuarios, Empleados, Proveedores

                        public Caracterizacion_Formulario? Caracterizacion_Actual = null;
                        public bool La_Caracterizacion_Ha_Cambiado;

                        const int Location_x_Primer_Boton = 26,
                                  Location_x_Segundo_Boton = 233,
                                  Location_x_Tercer_Boton = 379,
                                  Location_x_Cuarto_Boton = 525 ;

                        const int Location_y_Primer_Boton = 7,
                                  Location_y_Segundo_Boton = 7,
                                  Location_y_Tercer_Boton = 7,
                                  Location_y_Cuarto_Boton = 7;

                        readonly Point Location_Primer_Boton = new Point( x: Location_x_Primer_Boton, y: Location_y_Primer_Boton ) ;
                        readonly Point Location_Segundo_Boton = new Point( x: Location_x_Segundo_Boton, y: Location_y_Segundo_Boton ) ;
                        readonly Point Location_Tercer_Boton = new Point( x: Location_x_Tercer_Boton, y: Location_y_Tercer_Boton ) ;
                        readonly Point Location_Cuarto_Boton = new Point( x: Location_x_Cuarto_Boton, y: Location_y_Cuarto_Boton ) ;
                        // Curiosamente no te deja asignarle el mismo valor a todas... Nc si es una opcion del compilador o algo.
                        // En linea encontre ejemplos de gente haciendolo, pero si lo hago de esa manera solo asigna la ultima variable, bueh :(

# if DEBUG_Administracion_Sujetos
                        public
# else
                        private
# endif
                                void Recaracterizar(Caracterizacion_Formulario Boton_Seleccionado)
                        { // Se encarga de alterar el formulario poniendo los botones en su posicion correcta, en base al boton que fue seleccionado, el cual va primero.
                                if (Boton_Seleccionado == Caracterizacion_Actual) { return; }
                                switch (Boton_Seleccionado)
                                {
                                        case Caracterizacion_Formulario.Personas:
                                                Button_Personas.Location = Location_Primer_Boton ;
                                                Button_Usuarios.Location = Location_Segundo_Boton ;
                                                Button_Empleados.Location = Location_Tercer_Boton ;
                                                Button_Proveedores.Location = Location_Cuarto_Boton ;
                                                break;
                                        case Caracterizacion_Formulario.Usuarios:
                                                Button_Usuarios.Location = Location_Primer_Boton ;
                                                Button_Personas.Location = Location_Segundo_Boton ;
                                                Button_Empleados.Location = Location_Tercer_Boton ;
                                                Button_Proveedores.Location = Location_Cuarto_Boton ;
                                                break;
                                        case Caracterizacion_Formulario.Empleados:
                                                Button_Empleados.Location = Location_Primer_Boton ;
                                                Button_Personas.Location = Location_Segundo_Boton ;
                                                Button_Usuarios.Location = Location_Tercer_Boton ;
                                                Button_Proveedores.Location = Location_Cuarto_Boton ;
                                                break;
                                        case Caracterizacion_Formulario.Proveedores:
                                                Button_Proveedores.Location = Location_Primer_Boton ;
                                                Button_Personas.Location = Location_Segundo_Boton ;
                                                Button_Usuarios.Location = Location_Tercer_Boton ;
                                                Button_Empleados.Location = Location_Cuarto_Boton ;
                                                break;
                                }
                                Caracterizacion_Actual = Boton_Seleccionado;
                        }

                        private void Recaracterizar_Selector_Para_Personas(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Personas); La_Caracterizacion_Ha_Cambiado = true; }
                        private void Recaracterizar_Selector_Para_Usuarios(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Usuarios); La_Caracterizacion_Ha_Cambiado = true; }
                        private void Recaracterizar_Selector_Para_Empleados(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Empleados); La_Caracterizacion_Ha_Cambiado = true; }
                        private void Recaracterizar_Selector_Para_Proveedores(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Proveedores); La_Caracterizacion_Ha_Cambiado = true; }


                        public Selector_Capas() : base()
                        {
                                // El contructor se encarga de caracterizar adecuadamente el Panel en el que el selector opera.
                                // Y ademas se encarga de hacer que el Selector sea caracterizado con el boton `Usuarios` seleccionado por defecto.
                                // Para hacer que el selector sea diferente, llama al metodo `Recaracterizar`, no crees una nueva instancia del selector.
                                // Lee el comentario que esta al inicio de la clase para mas informacion.

                                { // Caracteriza el Panel 
                                        this.Name = "Panel_Selector_Capas";
                                        this.Location = new Point(23, 12);
                                        this.BorderStyle = BorderStyle.FixedSingle ;
                                        this.Size = new Size(691, 58);
                                        this.TabIndex = 3;
                                }

                                { // Define los botones del selector, sin definir su posicion.
                                        Button_Personas = new Button();
                                        {
                                                Button_Personas.BackColor = Color.YellowGreen;
                                                Button_Personas.FlatAppearance.BorderColor = Color.OliveDrab;
                                                Button_Personas.FlatAppearance.BorderSize = 2;
                                                Button_Personas.FlatStyle = FlatStyle.Flat;
                                                Button_Personas.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                                Button_Personas.ForeColor = Color.LightYellow;
                                                //  Button_Personas.Location = new Point(233, 7);
                                                Button_Personas.Name = "Button_Personas";
                                                Button_Personas.Size = new Size(140, 43);
                                                Button_Personas.TabIndex = 1;
                                                Button_Personas.Text = "Personas";
                                                Button_Personas.UseVisualStyleBackColor = false;

                                                Button_Personas.Click += Recaracterizar_Selector_Para_Personas;
                                        }

                                        Button_Usuarios = new Button();
                                        {
                                                Button_Usuarios.BackColor = Color.DarkCyan;
                                                Button_Usuarios.FlatAppearance.BorderColor = Color.DarkSlateGray;
                                                Button_Usuarios.FlatAppearance.BorderSize = 2;
                                                Button_Usuarios.FlatStyle = FlatStyle.Flat;
                                                Button_Usuarios.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                                Button_Usuarios.ForeColor = Color.LightYellow;
                                                // Button_Usuarios.Location = new Point(26, 7);
                                                Button_Usuarios.Name = "Button_Usuarios";
                                                Button_Usuarios.Size = new Size(140, 43);
                                                Button_Usuarios.TabIndex = 0;
                                                Button_Usuarios.Text = "Usuarios";
                                                Button_Usuarios.UseVisualStyleBackColor = false;

                                                Button_Usuarios.Click += Recaracterizar_Selector_Para_Usuarios;
                                        }

                                        Button_Empleados = new Button();
                                        {
                                                Button_Empleados.BackColor = Color.FromArgb(255, 140, 50);
                                                Button_Empleados.FlatAppearance.BorderColor = Color.Sienna;
                                                Button_Empleados.FlatAppearance.BorderSize = 2;
                                                Button_Empleados.FlatStyle = FlatStyle.Flat;
                                                Button_Empleados.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                                Button_Empleados.ForeColor = Color.LightYellow;
                                                // Button_Empleados.Location = new Point(379, 7);
                                                Button_Empleados.Name = "Button_Empleados";
                                                Button_Empleados.Size = new Size(140, 43);
                                                Button_Empleados.TabIndex = 2;
                                                Button_Empleados.Text = "Empleados";
                                                Button_Empleados.UseVisualStyleBackColor = false;

                                                Button_Empleados.Click += Recaracterizar_Selector_Para_Empleados;
                                        }

                                        Button_Proveedores = new Button();
                                        {
                                                Button_Proveedores.BackColor = Color.SlateBlue;
                                                Button_Proveedores.FlatAppearance.BorderColor = Color.Indigo;
                                                Button_Proveedores.FlatAppearance.BorderSize = 2;
                                                Button_Proveedores.FlatStyle = FlatStyle.Flat;
                                                Button_Proveedores.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                                Button_Proveedores.ForeColor = Color.LightYellow;
                                                // Button_Proveedores.Location = new Point(525, 7);
                                                Button_Proveedores.Name = "Button_Proveedores";
                                                Button_Proveedores.Size = new Size(140, 43);
                                                Button_Proveedores.TabIndex = 3;
                                                Button_Proveedores.Text = "Proveedores";
                                                Button_Proveedores.UseVisualStyleBackColor = false;

                                                Button_Proveedores.Click += Recaracterizar_Selector_Para_Proveedores;
                                        }
                                }

                                { // Agrega los botones YA INICIALIZADOS a la coleccion de controles
                                        this.Controls.Add(Button_Personas);
                                        this.Controls.Add(Button_Usuarios);
                                        this.Controls.Add(Button_Empleados);
                                        this.Controls.Add(Button_Proveedores);
                                }

                                { // Caracteriza el selector de forma que el boton seleccionado sea el boton `Usuarios` 
                                        this.Recaracterizar(Caracterizacion_Formulario.Usuarios);
                                }
                                La_Caracterizacion_Ha_Cambiado = false;
                        }
                }

# if DEBUG_Atributos_Capa
                public class Atributos_Capa : Panel
# else
                private class Atributos_Capa : Panel
# endif
                {
                        static class Atributo_Capa
                        {
                                // `Atributo de Capa`, representado como `Atributo_Capa`: Es el conjunto de un `Control de Atributo` y la `Cabecera de Atributo` que le pertenece. Son los elementos que formn el panel `Atributos_Capa`.
                                // `Control de Atributo`: Un Control a traves de el cual se es capaz de modificar un atributo o campo de una determinada capa. 
                                // `Cabecera de Atributo`: Una Label la cual se encuentra encima del control del atributo, muestra el nombre de el atributo qo campo ue pertenece a el `Control de Atributo` que se encuentra debajo de ella. 
                                //                         El nombre de una `Cabecera de Atributo` en el codigo es la suma de la palabra "Cabecera" + El nombre del `Control de Atributo`.
                                //                         Por ejemplo:
                                //                         TextBox Nombre ; ← Este es el `Control de Atributo`.
                                //                         Label Cabecera_Nombre ; ← Esta es la `Cabecera de Atributo` de el `Control de Atributo` "Nombre".
                                //                         Cabecera_Nombre.Text = "Nombre" ;


                                static internal int Posicion_y_Inicial_Atributos_Capa ; // El punto y en que arrancan los `Atributos de Capa`.
                                internal const int Posicion_x_Horizontal_Controles = 26; // Es la distancia desde el borde del panel de la clase hasta todos los controles, tanto a los `Atributos de Capa`, como a la cabecera por ejemplo.
                                static internal readonly Size Size_Cabecera_Atributos = new Size( 64, 20 ) ; // El atributo Size de las `Cabeceras_Atributo`.

                                static internal Point Get_Location_Cabecera_Atributo( Control Control_Atributo_Anterior ) // Devuelve la Location de una `Cabecera de Atributo` respecto a el `Control de Atributo` del `Atributo` anterior.
                                {
                                        int y_Respecto_Al_Atributo_Anterior() // Devuelve la posicion y respecto a el `Control de Atributo` del `Atributo` anterior.
                                        {
                                                int y_Incial_Atributo_Actual ; // Es la posicion y en la que arranca un nuevo atributo.
                                                int y_Del_Control_Atributo_Anterior ; // Es la posicion Y del `Control de Atributo` anterior, y como el `Control de Atributo` es a ultima parte de un `Atriuto`, tambien la posicion Y del borde del anterior `Atributo`.
                                                int Margen_y_Atributos_Capa ; // Es la distancia vertical que separa a los `Atributos de Capa` entre si.
                                                             
                                                Margen_y_Atributos_Capa = 10 ; 
                                                y_Del_Control_Atributo_Anterior = Control_Atributo_Anterior.Location.Y + Control_Atributo_Anterior.Size.Height ;
                                                y_Incial_Atributo_Actual = ( y_Del_Control_Atributo_Anterior + Margen_y_Atributos_Capa ) + Margen_y_Atributos_Capa ;

                                                return y_Incial_Atributo_Actual ;

                                                // Otra posible forma de conseguir lo mismo....
                                                // Si el numero de un `Atributo de Capa` es el numero de `Atributos de Capa` en el Panel...
                                                // Desde la distancia donde comienzan los atributos...
                                                // Un atribtuo ocupa un espacio determinado el cual es constante...
                                                // La distancia que hay entre un `Atributo de Capa` y otro tambien es constante...
                                                // Entonces la posicion y de un atributo es igual a la altura de un `Atributo de Capa` + La separacion entre ellos por el numero del atributo + La distancia inicial...
                                                // int Formula_De_Posicion_Atributo_Capa = ( y_Del_Control_Atributo_Anterior + Margen_y_Atributos_Capa ) * Numero_De_Atributo ;
                                                // Pero voy a mantenerlo simple...
                                        }

                                        Point Location_Cabecera_Atributo ;
                                        const int x_Cabecera_Atributo = Posicion_x_Horizontal_Controles ; 
                                        int y_Cabecera_Atributo ;

                                        y_Cabecera_Atributo = y_Respecto_Al_Atributo_Anterior() ;
                                        Location_Cabecera_Atributo = new Point( x: x_Cabecera_Atributo, y: y_Cabecera_Atributo ) ;

                                        return Location_Cabecera_Atributo ;
                                }

                                internal static Point Get_Location_Control_Atributo( Control Cabecera_Atributo_Capa ) // Dado una `Cabecera de Atributo`, te da la posicion y del `Control de Atributo` que le corresponde.
                                {
                                        Point Location_Control_Atributo ;        // El punto que se le asignara a un `Control de Capa`, el cual se basa en la `Cabecera de Atributo` que le pertenece.
                                        int y_Borde_Inferior_Cabecera_Atributo ; // Posicion y en la cual comienza el borde de la `Cabecera del Atributo`.
                                        const int Posicion_x_Controles_Atributo = Posicion_x_Horizontal_Controles ; // Es la posicion x en la que comienzan tanto los `Controles de Atributo` como las `Cabeceras de Atributo`.   

                                        if ( Cabecera_Atributo_Capa is null ) { throw new ArgumentException("Para conseguir la Location de un `Control de Atributo` la `Cabecera de Atributo` que se usa como referencia no puede ser null.") ; }
                                        y_Borde_Inferior_Cabecera_Atributo = ( Cabecera_Atributo_Capa.Location.Y + Cabecera_Atributo_Capa.Size.Height ) ;
                                        Location_Control_Atributo = new Point( x: Posicion_x_Controles_Atributo, y: y_Borde_Inferior_Cabecera_Atributo ) ;

                                        return Location_Control_Atributo ;
                                }
                        }

                        
                        #region >>---- Controles Especiales ---------------------------------------------------------

                        # if DEBUG_Administracion_Sujetos
                        public
                        # else
                        private
                        #endif
                        class TextBoxNumerico : TextBox
                        {
                                private string Respaldo_Text = "" ; // Es el valor anterior al del atributo Text. Si el input ingresado no es valido, a Text se le asigna este valor.
                                                                    // Comienza como un string vacio el paso anterior a ingresar algo inadecuado de primeras es no tener nada en primer lugar.

                                protected override void OnTextChanged( EventArgs e )
                                {
                                        foreach ( char caracter in Text )
                                        {
                                                if ( ! char.IsDigit( caracter ) ) 
                                                {
                                                        Text = Respaldo_Text ; // Cuando esto ocurre el cursor es movido al principio del texto.
                                                        SelectionStart = Text.Length ; // Pone el cursor al final del texto.
                                                        ScrollToCaret() ; // Si por algun motivo el texto es mas largo que el ancho del TextBox, scrollea(desliza) el texto del TextBox hasta el cursor.
                                                        return ;
                                                }
                                        }
                                        Respaldo_Text = Text ;

                                        base.OnTextChanged( e ) ;
                                }
                        }

                        # if DEBUG_Administracion_Sujetos
                        public
                        # else
                        private
                        #endif
                        class CheckedListBox_Nivel_Confidencialidad : CheckedListBox
                        {
                                string Nivel_Confidencialidad
                                // Posiciones de los bits:
                                // Bit numero - Accion que le corresponde
                                // 0 - Administración de Sujetos
                                // 1 - Administración de Lotes y Productos
                                // 2 - Pago a Sujetos
                                // 3 - Publicación de Lotes y Productos
                                //
                                { 
                                        get
                                        { // Para funcionar esta funcion asume que los permisos estan en un orden concreto. Un orden que es implicito en el codigo.

                                                // Aqui hay dos opciones o comprobar que los permisos esten en el orden adecuado o hacer que la propia construccion de la clase ya esten en un orden adecuado.
                                                // Creo que voy a ir por la segunda nc. Ahora debo hacer otra cosa.
                                                { // Comprueba que los permisos estan en orden 
                                        
                                                }

                                                { // Devuelve el Nivel de Conidencilidad representado en un string
                                                        System.Text.StringBuilder Cadena_Nivel_Confidencialidad = new System.Text.StringBuilder("") ; // Cadena de digitos binarios que representa los permisos de un Usuario
                                                        int Indice_String = 0 ; // Indice de la cadena Nivel de Confidencialidad

                                                        foreach ( CheckState Permiso_Checkado in Items )
                                                        {
                                                                switch ( Permiso_Checkado )
                                                                { 
                                                                        case CheckState.Unchecked:
                                                                                Cadena_Nivel_Confidencialidad[ Indice_String ] = '0' ;
                                                                        break ;
                                                                        case CheckState.Checked:
                                                                                Cadena_Nivel_Confidencialidad[ Indice_String ] = '1' ;
                                                                        break ;
                                                                        case CheckState.Indeterminate:
                                                                                throw new Exception("El estado del permiso es indeterminado para la CheckedListBox, eso no deberia ocurrir.") ;
                                                                        break ;
                                                                }
                                                                Indice_String++ ;
                                                        }
                                                        return ( Cadena_Nivel_Confidencialidad.ToString() ) ;
                                                }
                                        }
                                        set
                                        { // Esto lo pesaba usar para implementar un modo de solo lectura para la lista. Ya que queria implementar un modo de solo lectura en la lista. Y eso para permitir seleccionar plantillas de permisos o permisos libremente a cada Usuario. Pero por ahora queda en desuso.
                                                foreach ( char Caracter in value ) { if ( Caracter != '0' || Caracter != '1' ) { throw new ArgumentException("Una cadena que represente el Nivel de Confidencialidad solo puede estar compuesta de digitos binarios") ; } }
                                                if ( value.Length > 3 ) { throw new ArgumentException("La cadena que represntaria el Nivel de Confidencialidad solo puede tener 4 caracteres.") ; }

                                                int Indice_Permiso = 0 ;
                                                foreach ( char Caracter in value )
                                                {
                                                        switch ( Caracter )
                                                        { 
                                                                case '0':
                                                                        Items[ Indice_Permiso ] = CheckState.Unchecked ;
                                                                break ;
                                                                case '1':
                                                                        Items[ Indice_Permiso ] = CheckState.Checked ;
                                                                break ;
                                                        }
                                                        Indice_Permiso++ ;
                                                }
                                        }
                                }

                                # if DEBUG_Administracion_Sujetos
                                public
                                # else
                                private
                                # endif
                                CheckedListBox_Nivel_Confidencialidad()
                                { 
                                        Items.Add( "Administrar Sujetos", isChecked: false ) ;
                                        Items.Add( "Administrar Lotes y Productos", isChecked: false ) ;
                                        Items.Add( "Pagar a Sujetos", isChecked: false ) ;
                                        Items.Add( "Publicar Lotes y Productos", isChecked: false ) ;
                                }
                        }

                        # if DEBUG_Administracion_Sujetos
                        public
                        # else
                        private
                        #endif
                        class Administrador_Tareas_Asignadas : Panel
                        {
                                public bool Se_Cambio_De_Tarea_Asignada = false ;
                                public int Indice_Tarea_Actual { get { return ( ( int ) Spinner_Tareas_Asignadas.Value ) ; } }
                                public string Text_Tarea_Asignada_Actual { set { TextBox_Tareas_Asignadas.Text = value ; } }

                                TextBox TextBox_Tareas_Asignadas ;
                                public Label Cabecera_Tareas_Asignadas ;
                                NumericUpDown Spinner_Tareas_Asignadas ;
                                Label Cantidad_Tareas_Modificadas ;

                                void Cambiar_Tarea( object sender, EventArgs e ) { Se_Cambio_De_Tarea_Asignada = true ; }

                                # if DEBUG_Administracion_Sujetos
                                public
                                # else
                                private
                                # endif
                                Administrador_Tareas_Asignadas( Point Location_Primera_Cabecera )
                                {
                                        Location = new Point( ( Location_Primera_Cabecera.X + 50 ), ( Location_Primera_Cabecera.Y - 15 ) ) ;
                                        Size = new Size( 200, 100 ) ;
                                        {
                                                Cabecera_Tareas_Asignadas = new Label
                                                { 
                                                        Location = new Point(0,0),
                                                        AutoSize = true,
                                                        Size = Atributo_Capa.Size_Cabecera_Atributos,
                                                        Text = "Tareas Asignadas"
                                                } ;
                                                TextBox_Tareas_Asignadas = new TextBox
                                                {
                                                        Location = new Point(0, ( Cabecera_Tareas_Asignadas.Location.Y + Cabecera_Tareas_Asignadas.Size.Height ) ),
                                                        Multiline = true,
                                                        ScrollBars = ScrollBars.Vertical,
                                                        Size = new Size(158, (26 * 2))
                                                };
                                                Spinner_Tareas_Asignadas = new NumericUpDown
                                                {
                                                        Location = new Point(x: ((TextBox_Tareas_Asignadas.Location.X + TextBox_Tareas_Asignadas.Size.Width) + 5), y: TextBox_Tareas_Asignadas.Location.Y),
                                                        Size = new Size(width: 40, height: 20),
                                                        Value = 0,
                                                        Minimum = 0,
                                                        Maximum = int.MaxValue,
                                                };
                                                /*
                                                Cantidad_Tareas_Modificadas = new Label
                                                { 
                                                        Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Tareas_Asignadas ),
                                                        Margin = new Padding( 0, 0, 0, 26 ),
                                                        AutoSize = true,
                                                        Font = new Font( Font.FontFamily, emSize: 8  ),
                                                        Text = "Tareas modificadas: "
                                                } ;
                                                */
                                        }
                                        { 
                                                Spinner_Tareas_Asignadas.ValueChanged += Cambiar_Tarea ;
                                        }

                                        { 
                                                Controls.Add(Cabecera_Tareas_Asignadas) ;
                                                Controls.Add(TextBox_Tareas_Asignadas) ;
                                                Controls.Add(Spinner_Tareas_Asignadas) ;
                                                //Controls.Add() ;
                                                
                                        }
                                }
                        }

                        # endregion ---------------------------------------------------------------------------------

                        bool Caracterizacion_Ha_Cambiado;

                        
                        // const int Separacion_Cabecera_Y_Control_Atributo = 10 ;
                        
                        Label Label_Cabecera ;
                        Control Margen_Inferior ; // Me arté de buscar porque corno el margen de los botones no anda. Me pudri. Voy a agregar un boton transparente debajo de el ultimo `Atributo` de forma que entre el ultimo atributo y el borde de el panel haya un espacio de 26px
                        
                        Point Location_Cabecera_Atributo_Inicial ;


# if DEBUG_Atributos_Capa
                        public
# else
                        private
# endif
                                void Caracterizar_Como_Personas()
                        {       
                                // Faltaria un numero de telefono quizas....

                                TextBox ID;
                                Label Cabecera_ID ;
                                TextBox Nombre;
                                Label Cabecera_Nombre ;
                                TextBox Apellido;
                                Label Cabecera_Apellido ;
                                TextBoxNumerico Numero_Telefono ;
                                Label Cabecera_Numero_Telefono ;
                                Control Margen_Inferior ;


                                { // Caracteriza los `Controles de Atributos` y sus `Cabeceras de Atributos`
                                        Cabecera_ID = new Label
                                        {
                                                Text = "ID",
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,                               
                                                Location = Location_Cabecera_Atributo_Inicial ,
                                        } ;

                                        ID = new TextBox
                                        {
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_ID ),
                                                // PlaceholderText = "La ID de una Persona irá aquá" 
                                        } ;


                                        Cabecera_Nombre = new Label
                                        {
                                                Text = "Nombre",
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,          
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( ID ),
                                        } ;
                                        Nombre = new TextBox 
                                        {
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Nombre ),
                                                // PlaceholderText = "El Nombre de una Persona irá aquá"
                                        } ;

                                        Cabecera_Apellido = new Label
                                        { 
                                                Text = "Apellido",
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,          
                                                Location = Atributo_Capa.Get_Location_Control_Atributo(Nombre),
                                        } ;
                                        Apellido = new TextBox 
                                        {
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Apellido ),
                                                // PlaceholderText = "El Apellido de una Persona irá aquá"
                                        } ;

                                        Cabecera_Numero_Telefono = new Label
                                        {
                                                Text = "Numero de Telefono",
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Apellido )
                                        } ;
                                        Numero_Telefono = new TextBoxNumerico 
                                        { 
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Numero_Telefono )    
                                        } ;

                                        Margen_Inferior = new Control
                                        {
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Numero_Telefono ) , // Si bien no es un `Control de Atributo` el margen sigue casi la misma logica
                                        } ;
                                }

                                { // Agrega los `Atributos de Capa`
                                        Controls.Add((Control)Cabecera_ID ) ;
                                        Controls.Add((Control)ID) ;
                                        Controls.Add((Control)Cabecera_Nombre) ;
                                        Controls.Add((Control)Nombre);
                                        Controls.Add((Control)Cabecera_Apellido) ;
                                        Controls.Add((Control)Apellido);
                                        Controls.Add( ( Control ) Cabecera_Numero_Telefono ) ;
                                        Controls.Add( ( Control ) Numero_Telefono ) ;
                                        Controls.Add( Margen_Inferior ) ;
                                }
                        }

                        
                        private void Caracterizar_Como_Usuario()
                        {
                                TextBox Nombre_Identificador  ;
                                Label Cabecera_Nombre_Identificador ;
                                TextBox Contrasena ;
                                Label Cabecera_Contrasena ;
                                CheckedListBox Nivel_Confidencialidad ;
                                Label Cabecera_Nivel_Confidencialidad ;
                                CheckBox Activo ;
                                Label Cabecera_Activo ;

                                {
                                        Cabecera_Nombre_Identificador = new Label
                                        { 
                                                Location = Location_Cabecera_Atributo_Inicial,
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,  
                                                Text = "Nombre Identificador"
                                        } ;
                                        Nombre_Identificador = new TextBox 
                                        {
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Nombre_Identificador ) ,
                                        } ;

                                        Cabecera_Contrasena = new Label
                                        { 
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Nombre_Identificador ),
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,  
                                                Text = "Contraseña"
                                        } ;
                                        Contrasena = new TextBox
                                        { 
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Contrasena )        
                                        } ;

                                        Cabecera_Nivel_Confidencialidad = new Label
                                        { 
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Contrasena ),
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,
                                                Text = "Nivel de Confidencialidad(permisos)"
                                        } ;
                                        Nivel_Confidencialidad = new CheckedListBox_Nivel_Confidencialidad
                                        {  
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Nivel_Confidencialidad ),
                                                Size = new Size( width: 180, height: 100 )
                                        } ;
                                        // Margen_Inferior.Location = Atributo_Capa.Get_Location_Control_Atributo( Nivel_Confidencialidad ) ;
                                }

                                { 
                                        Controls.Add( Cabecera_Nombre_Identificador ) ;
                                        Controls.Add( Nombre_Identificador ) ;
                                        Controls.Add( Cabecera_Contrasena ) ;
                                        Controls.Add( Contrasena ) ;
                                        Controls.Add( Cabecera_Nivel_Confidencialidad ) ;
                                        Controls.Add( Nivel_Confidencialidad ) ;
                                        Controls.Add( Margen_Inferior ) ;
                                }
                        }
                        

# if DEBUG_Atributos_Capa
                        public
# else
                        private
# endif
                                void Caracterizar_Como_Empleado()
                        { 
                                // Esta caracterizacion requiere una mecanica especial...
                                // * Cuando la persona usando la herramienta cambia el numero del UpDown, se debe actualizar la TextBox con el string correspondiente.
                                // Ademas de eso... Una TextBox que fue modificada debe guardar otra tarea asignada debe guardar la informacion modificada.
                                // Eso signifiacatia qu tambien deberia tener un boton que que reinicie una textbox a el valor que tenia antes.
                                // Una senal que indique si una tarea es la original o la que se piensa asignar.
                                // Una indicacion de cuantas tareas se asignaran si la persona continua.
                                // Una forma de navegar hasta la siguiente y la anterior tarea que se asignaran si la persona continua.
                                // Y un boton para limpiar todo seria genial.


                                TextBox ID ;
                                Label Cabecera_ID ;
                                NumericUpDown Horas_Trabajadas ;
                                Label Cabecera_Horas_Trabajadas ;
                                Administrador_Tareas_Asignadas Tareas_Asignadas ;
                                // Label Cabecera_Tareas_Asignadas ;

                                void Actualizar_TextBox_Tareas_Asignadas(object sender, EventArgs e)
                                { 
                                        // En base a la informacion del Empleado seleccionado...
                                        // Si la tarea esta modificada, entonces llenar la TextBox con la tarea modificada, la cual esta indicada por el indice.
                                        // Si no, llenar la TextBox con la tarea indicada por el indice.

                                        // Esto plantea un asunto.... El del acceso a la capa seleccionada. Si los componentes no son capaces de assessar la informacion de la herramienta en absoluto, entonces deberia pasar la capa seleccionada a cada componente individual....
                                        //      Esto complicaria la cordinacion entre componentes. Al usar referencias diferentes, seria indispensable mantener la igualdad de las capas seleccionadas entre todos los componentes.
                                        // Al hacerlo de esta forma, se obtiene una encapsulacion total... Eso simplifica la naturaleza de cada componente por separado, pero parece complejizar muchisimo las interacciones entre ellos, y la coordinacion de todos ellos.
                                        // En cambio... Podria hacer que los componentes solo fueran capaces de assessar a la capa seleccionada y ya esta.
                                        //      Esto contribuiria a que la coordinacion entre los componentes sea sencilla. A pesar de que romperia la encapsulacion que hasta ahora tenia cada componente.
                                        //      Pero si los componentes son capaces de causar cambios en el estado de tal capa, eso significaria que los componentes comportarse de una forma que de ellos no se espera al compartir esa pieza de estado.
                                        //      Por ejemplo, si los atributos de tal capa son modificados en el a traves de los `Controles de Atributo`, si tal modificacion afecta la representacion de la capa de todos los componentes, entonces es posible que la grilla llegue a reflejar tal cambio de la capa como si el estado persistente de la capa fuera ese. Aunque supongo que eso depende la funcion que le de a la grilla.
                                        //      Si la grilla cumple la funcion de relfejar como serian las cosas en la base de datos luego de la intervencion de la persona utilizando la herramienta entonces eso estaria bien.
                                        //      La grilla supongo que estaria bien que cumpliera esa funcion. Pq asi lo hizo el profe en la clase, pq serviria para el control de lo que estas haciendo y ta.
                                        //      Si voy a hacer eso. Aun asi, deberia desarrollar las interacciones entre las partes.
                                        // El script deberia mantener registro de la capa seleccionada en primer lugar?
                                }

                                {
                                        Cabecera_ID = new Label
                                        {
                                                Text = "ID",
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,                               
                                                Location = new Point( x: Atributo_Capa.Posicion_x_Horizontal_Controles, y: Atributo_Capa.Posicion_y_Inicial_Atributos_Capa /* x: 10, y: 50 */ ),
                                        } ;
                                        ID = new TextBox
                                        {
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_ID ),
                                                // PlaceholderText = "La ID de una Persona irá aquá" 
                                        } ;

                                        Cabecera_Horas_Trabajadas = new Label
                                        { 
                                                Text = "Horas Trabajadas",
                                                AutoSize = true,
                                                Size = Atributo_Capa.Size_Cabecera_Atributos,
                                                Location = Atributo_Capa.Get_Location_Control_Atributo(ID),
                                                
                                        } ;
                                        Horas_Trabajadas = new NumericUpDown
                                        {
                                                Location = Atributo_Capa.Get_Location_Control_Atributo( Cabecera_Horas_Trabajadas ),
                                                Value = 0,
                                                Minimum = 0
                                        } ;

                                        Tareas_Asignadas = new Administrador_Tareas_Asignadas( Atributo_Capa.Get_Location_Cabecera_Atributo( Horas_Trabajadas ) ) ;
                                        
                                        Margen_Inferior.Location = Atributo_Capa.Get_Location_Control_Atributo( Tareas_Asignadas ) ;

                                        {  // Agrega los `Controles de Atributo`
                                                Controls.Add( Cabecera_ID ) ;
                                                Controls.Add( ID ) ;
                                                Controls.Add( Cabecera_Horas_Trabajadas ) ;
                                                Controls.Add( Horas_Trabajadas ) ;
                                                Controls.Add( Cabecera_Horas_Trabajadas ) ;
                                                Controls.Add( Horas_Trabajadas ) ;
                                                //Controls.Add( Cabecera_Tareas_Asignadas ) ;
                                                //Controls.Add( TextBox_Tareas_Asignadas ) ;
                                                //Controls.Add( Spinner_Tareas_Asignadas ) ;
                                                // Controls.Add( Cantidad_Tareas_Modificadas ) ;
                                                Controls.Add( Margen_Inferior ) ;
                                        }
                                }
                        }

# if DEBUG_Atributos_Capa
                        public 
# else
                        private
# endif
                                Atributos_Capa( Caracterizacion_Formulario  Caracterizacion_Actual )
                        {
                                { // Caracteriza el panel subyacente 
                                        this.AutoScroll = true;
                                        this.Location = new Point(720, 12);
                                        this.Name = "this";
                                        this.Size = new Size(250, 263);
                                        this.TabIndex = 1;
                                        this.BorderStyle = BorderStyle.FixedSingle ;
                                        this.Padding = new Padding(0) ;
                                        this.Margin = new Padding(0) ;
                                }

                                { // Caraceriza y agrega la cabecera
                                        Label_Cabecera = new Label
                                        {
                                                AutoSize = true,
                                                Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point),
                                                Location = new Point(26, 14),
                                                Name = "",
                                                Size = new Size(185, 25),
                                                TabIndex = 0,
                                                Text = "Atributos de la Capa"
                                        };
                                        Controls.Add( Label_Cabecera ) ;
                                }

                                { // Caracteriza el Margen Inferior 
                                        Margen_Inferior = new Control
                                        {
                                                // BackColor = Color.Transparent,
                                                // ForeColor = Color.Transparent,
                                                Text = "",
                                                Size = new Size( width: 158, height: 26 )
                                        } ;
                                }

                                { // Inicializa la posicion inicial para las cabecera
                                        Atributo_Capa.Posicion_y_Inicial_Atributos_Capa = Label_Cabecera.Location.Y + Label_Cabecera.Size.Height + 5 ;
                                        Location_Cabecera_Atributo_Inicial = new Point( Atributo_Capa.Posicion_x_Horizontal_Controles, Atributo_Capa.Posicion_y_Inicial_Atributos_Capa ) ;
                                }

                                switch ( Caracterizacion_Actual ) 
                                {
                                        case Caracterizacion_Formulario.Personas:
                                               Caracterizar_Como_Personas() ;
                                        break ;
                                        case Caracterizacion_Formulario.Empleados:
                                                Caracterizar_Como_Empleado() ;
                                        break ;
                                        case Caracterizacion_Formulario.Usuarios:
                                                Caracterizar_Como_Usuario() ;
                                        break ;
                                        default:
                                                throw new ArgumentException("El valor de caracterizacion es incorrecto") ;
                                        break ;
                                }
                        }

                        //public Atributos_Capa(Caracterizacion_Formulario Capa_Seleccionada)
                        //{

                        //}
                }
                # endregion

                #region >>---- Parte Grafica Formulario ---------------------------------------------------------
                ///// <summary>
                ///// Required designer variable.
                ///// </summary>
                //private System.ComponentModel.IContainer components = null;

                ///// <summary>
                ///// Clean up any resources being used.
                ///// </summary>
                ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
                //protected override void Dispose(bool disposing)
                //{
                //        if (disposing && (components != null))
                //        {
                //                components.Dispose();
                //        }
                //        base.Dispose(disposing);
                //}

                //#region Windows Form Designer generated code

                ///// <summary>
                ///// Required method for Designer support - do not modify
                ///// the contents of this method with the code editor.
                ///// </summary>
                private void InitializeComponent()
                {
                //        Panel_Controles = new Panel();
                        Button_Eliminar = new Button();
                        Button_Modificar = new Button();
                        Button_Guardar = new Button();
                //        Panel_Selector_Capas = new Selector_Capas() ;
                //        Panel_Atributos_Capa = new Atributos_Capa( Caracterizacion_Formulario.Usuarios );
                //        Panel_Grilla = new Panel();
                //        Grilla_Integrantes = new DataGridView();
                //        Panel_Controles.SuspendLayout();
                //        Panel_Atributos_Capa.SuspendLayout();
                //        Panel_Grilla.SuspendLayout();
                //        ((System.ComponentModel.ISupportInitialize)Grilla_Integrantes).BeginInit();
                //        SuspendLayout();
                //        // 
                //        // Panel_Controles
                //        // 
                        //Panel_Controles.Controls.Add(Button_Eliminar);
                        //Panel_Controles.Controls.Add(Button_Modificar);
                        //Panel_Controles.Controls.Add(Button_Guardar);
                        //Panel_Controles.Location = new Point(720, 281);
                        //Panel_Controles.Name = "Panel_Controles";
                        //Panel_Controles.Size = new Size(250, 160);
                        //Panel_Controles.TabIndex = 0;
                //        // 
                //        // Button_Eliminar
                //        // 
                        Button_Eliminar.BackColor = Color.FromArgb(192, 0, 0);
                        Button_Eliminar.FlatAppearance.BorderColor = Color.Maroon;
                        Button_Eliminar.FlatAppearance.BorderSize = 3;
                        Button_Eliminar.FlatStyle = FlatStyle.Flat;
                        Button_Eliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Eliminar.ForeColor = Color.Silver;
                        Button_Eliminar.Location = new Point(26, 98);
                        Button_Eliminar.Name = "Button_Eliminar";
                        Button_Eliminar.Size = new Size(198, 35);
                        Button_Eliminar.TabIndex = 2;
                        Button_Eliminar.Text = "Eliminar";
                        Button_Eliminar.UseVisualStyleBackColor = false;
                          // 
                //        // Button_Modificar
                //        // 
                        Button_Modificar.BackColor = Color.Gold;
                        Button_Modificar.FlatAppearance.BorderColor = Color.Goldenrod;
                        Button_Modificar.FlatAppearance.BorderSize = 3;
                        Button_Modificar.FlatStyle = FlatStyle.Flat;
                        Button_Modificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Modificar.ForeColor = SystemColors.ActiveCaptionText;
                        Button_Modificar.Location = new Point(26, 57);
                        Button_Modificar.Name = "Button_Modificar";
                        Button_Modificar.Size = new Size(198, 35);
                        Button_Modificar.TabIndex = 1;
                        Button_Modificar.Text = "Modificar";
                        Button_Modificar.UseVisualStyleBackColor = false;
                //        // 
                //        // Button_Guardar
                //        // 
                        Button_Guardar.BackColor = Color.ForestGreen;
                        Button_Guardar.FlatAppearance.BorderColor = Color.YellowGreen;
                        Button_Guardar.FlatAppearance.BorderSize = 3;
                        Button_Guardar.FlatStyle = FlatStyle.Flat;
                        Button_Guardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Guardar.ForeColor = SystemColors.Control;
                        Button_Guardar.Location = new Point(26, 16);
                        Button_Guardar.Name = "Button_Guardar";
                        Button_Guardar.Size = new Size(198, 35);
                        Button_Guardar.TabIndex = 0;
                        Button_Guardar.Text = "Guardar";
                        Button_Guardar.UseVisualStyleBackColor = false;
                //        // 
                //        // Panel_Atributos_Capa
                //        // 
                //                //Panel_Atributos_Capa.AutoScroll = true;
                //                //Panel_Atributos_Capa.Location = new Point(720, 12);
                //                //Panel_Atributos_Capa.Name = "Panel_Atributos_Capa";
                //                //Panel_Atributos_Capa.Size = new Size(250, 263);
                //                //Panel_Atributos_Capa.TabIndex = 1;
                //        // 
                //        // Panel_Grilla
                //        // 
                //        Panel_Grilla.Controls.Add(Grilla_Integrantes);
                //        Panel_Grilla.Location = new Point(23, 68);
                //        Panel_Grilla.Name = "Panel_Grilla";
                //        Panel_Grilla.Size = new Size(691, 373);
                //        Panel_Grilla.TabIndex = 2;
                //        // 
                //        // Grilla_Integrantes
                //        // 
                //        Grilla_Integrantes.AllowUserToAddRows = false;
                //        Grilla_Integrantes.AllowUserToDeleteRows = false;
                //        Grilla_Integrantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                //        Grilla_Integrantes.Location = new Point(26, 8);
                //        Grilla_Integrantes.MultiSelect = false;
                //        Grilla_Integrantes.Name = "Grilla_Integrantes";
                //        Grilla_Integrantes.ReadOnly = true;
                //        Grilla_Integrantes.RowHeadersWidth = 51;
                //        Grilla_Integrantes.RowTemplate.Height = 29;
                //        Grilla_Integrantes.Size = new Size(639, 359);
                //        Grilla_Integrantes.TabIndex = 1;
                //        // 
                //        // Formulario_Administracion_Sujetos
                //        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                //        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(982, 453);
                        Controls.Add( Button_Eliminar ) ;
                        Controls.Add( Button_Modificar ) ;
                        Controls.Add( Button_Guardar ) ;
                        // Controls.Add(Panel_Grilla);
                        //        Controls.Add( Panel_Selector_Capas ) ;
                        //        Controls.Add( Panel_Atributos_Capa );
                        //        // Controls.Add( Panel_Controles );
                        //        Name = "Formulario_Administracion_Sujetos";
                        //        Text = "visuaestudiolareputaqueteremilpario";
                        //        // Panel_Controles.ResumeLayout(false);
                        //        // Panel_Atributos_Capa.ResumeLayout(false);
                        //        // Panel_Atributos_Capa.PerformLayout();
                        //        Panel_Grilla.ResumeLayout(false);
                        //        ((System.ComponentModel.ISupportInitialize)Grilla_Integrantes).EndInit();
                        //        ResumeLayout(false);
                }

                //#endregion

                //private Panel Panel_Controles;
                private Button Button_Guardar;
                private Button Button_Modificar;
                private Button Button_Eliminar;
                //private Panel Panel_Atributos_Capa;
                //private Panel Panel_Grilla;
                //private DataGridView Grilla_Integrantes;
                //private Panel Panel_Selector_Capas;
                //private Button Button_Empleados;
                //private Button Button_Proveedores;
                #endregion ------------------------------------------------------------------------------------------------------

                #region >>---- Parte Logica Formulario ----------------------------------------------------------


                public Formulario_Administracion_Sujetos()
                {
                        // InitializeComponent();
                        // Panel_Selector_Capas = ( ( Panel ) new Selector_Capas() ) ;
                        // Panel_Atributos_Capa = ( ( Panel ) new Atributos_Capa( Caracterizacion_Formulario.Usuarios ) ) ;


                        //{ 
                                Controls.Add( new Selector_Capas() ) ; 
                                Controls.Add( new Atributos_Capa( Caracterizacion_Formulario.Usuarios ) ) ;
                        //}
                }

                #endregion ---------------------------------------------------------------------------------------------
        }
}