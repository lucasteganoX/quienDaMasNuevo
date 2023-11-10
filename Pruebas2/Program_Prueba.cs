using System.Data;
using System.Runtime.CompilerServices;

using Logica.Sistema_de_Usuarios ;
using Acceso_Datos ;
using Presentacion.Administracion_Sujetos ;

namespace Prueba
{
        internal static class Program_Prueba
        {
                static void Continuar( string Mensaje = "" )
                {
                                if ( ! string.IsNullOrWhiteSpace(Mensaje) ) { Console.WriteLine(Mensaje) ; }
                                Console.WriteLine("Presiona enter para continuar.") ;
                                Console.ReadLine() ;
                }

                static void Mostrar_Tabla( DataTable Tabla_A_Mostrar )
                {
                        void Mostrar_Cabezeras() 
                        { // Draw the headers of the table
                                foreach ( DataColumn Actual_DataColumn in Tabla_A_Mostrar.Columns )
                                {
                                        Console.Write( Actual_DataColumn.ColumnName ) ;

                                        if ( Tabla_A_Mostrar.Columns.IndexOf( Actual_DataColumn ) == ( Tabla_A_Mostrar.Columns.Count - 1 ) ) { Console.Write(".") ; }
                                        else { Console.Write(", ") ; }
                                }
                                Console.WriteLine() ;
                        }

                        void Mostrar_Filas()
                        {
                                foreach ( DataRow Actual_DataRow in Tabla_A_Mostrar.Rows )
                                { // Draw the rows of the table
                                        for ( int i = 0 ; i < Actual_DataRow.ItemArray.Length ; i++ )
                                        {
                                                Console.Write( Actual_DataRow.ItemArray[i] ) ;

                                                if ( i == ( Actual_DataRow.ItemArray.Length - 1 ) ) { Console.WriteLine(".") ; }
                                                else { Console.Write(", ") ; }                                
                                        }
                                }
                        }

                        Mostrar_Cabezeras() ;
                        Mostrar_Filas() ;
                }

        /*
                 static void Mostrar_Sujeto( Logica.Sistema_de_Usuarios.Clase_Sujeto? Sujeto )
                 {
                         if ( Sujeto is null ) { Console.WriteLine("El Sujeto es null.") ; return ; }
                         Console.WriteLine() ;
                         { 
                                 Console.WriteLine
                                 (
                                     "Persona...\n" +
                                     $"Nombre = { Sujeto.Persona.Nombre }\n" +
                                     $"Apellido = { Sujeto.Persona.Apellido }\n" +
                                     $"Telefono = { Sujeto.Persona.Telefono }\n"    
                                 ) ;
                         }

                         if ( Sujeto.Usuario is not null )
                         { 
                                 Console.WriteLine
                                 (
                                     "Usuario...\n" +
                                     $"Nombre_Identificador = { Sujeto.Usuario.Nombre_Identificador }\n" +
                                     $"Contrasena = { Sujeto.Usuario.Contrasena }\n" +
                                     $"Nivel_Confidencialidad = { Sujeto.Usuario.Nivel_Confidencialidad }\n" +
                                     $"Activo = { Sujeto.Usuario.Activo }\n"    
                                 ) ;
                         }

                         if ( Sujeto.Empleado is not null )
                         { 
                                Console.WriteLine
                                (
                                    "Empleado...\n" +
                                    $"ID = { Sujeto.Empleado.ID }\n" +
                                    $"Horas_Trabajadas = { Sujeto.Empleado.Cantidad_Horas_Trabajadas }\n"
                                ) ;                                      
                         }

                         if ( Sujeto.Proveedor is not null )
                         { 
                                Console.WriteLine
                                (
                                    "Proveedor...\n" +
                                    $"ID = { Sujeto.Proveedor.ID }\n" +
                                    $"Nombre_Empresa = { Sujeto.Proveedor.Nombre_Empresa }\n"        
                                ) ;
                         }
                 }

                */

                //static void Lanzando_Formularios()
                //{ 
                //        Console.WriteLine("Holis. Presiona enter para lanzar el formulario :)") ;
                //        Console.ReadLine() ;

                //        ApplicationConfiguration.Initialize(); // no se que es esto pero no me voy a meter por ahora.
                //        Application.Run(new Form1());

                //        Console.WriteLine("El formulario termino huray!!!!. Presiona enter para terminar el programa :)") ;
                //        Console.ReadLine() ;

                //        Application.Run( new Form1() ) ;

                //        Console.WriteLine("Opa") ;
                //        Console.ReadLine() ;
                       

                        
                //        //static void Method1() { Console.WriteLine("This is Method1") ; }
                //        //static void Method2()
                //        //{
                //        //        void Method3() { Console.WriteLine("This is Method3") ; }

                //        //        Console.WriteLine("This is Method2") ;
                //        //        Method3() ;
                //        //}
                //        //Console.WriteLine("Holis. Presiona enter para arrancar la prueba :)") ;
                //        //Console.ReadLine() ;
                //        //Method1() ;
                //        //Method2() ;
                //        //Console.WriteLine("Chauis. Presiona enter para finalizar la prueba :)") ;
                //        //Console.ReadLine() ;
                //}

                //class MyForm : Form
                //{       internal Panel? Instancia_Panel ;
                //        internal Label? Instancia_Label ;
                //        internal Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Selector_Capas? Instancia_Selector_Capas ;                
                //}
                
                //class SuperButton : Button 
                //{
                //        internal enum Posicion
                //        { 
                //                Uno ,
                //                Dos
                //        }
                //        // Posicion Uno = 100, 50 ; Posicion Dos = 50, 100

                //        internal void Alterar( Posicion Posicion_En_La_Que_poner_Al_Boton )
                //        { 
                //                if ( Posicion_En_La_Que_poner_Al_Boton == Posicion.Uno ) { Location = new Point( 100, 50 ) ; }
                //                if ( Posicion_En_La_Que_poner_Al_Boton == Posicion.Dos ) { Location = new Point( 50, 100 ) ; }
                //                // Pudo hacerlo con else solo, no quiero :]
                //        }
                //}

                //static void Agregar_Cosas_A_Un_Componente()
                //{ 
                //        void Continuar( string Mensaje = "" )
                //        {
                //                if ( ! string.IsNullOrWhiteSpace(Mensaje) ) { Console.WriteLine(Mensaje) ; }
                //                Console.WriteLine("Presiona enter para continuar.") ;
                //                Console.ReadLine() ;
                //        }

                        // Form Instancia_Formulario = new Form() ;
                        // Thread Hilo_Instancia_Formulario = new Thread
                        // (
                        //         () => { Application.Run( Instancia_Formulario ) ; }
                        // ) ;

                        // Vi que los componentes de un formulario(incluyendo la propia ventna) son suspendidos antes de agregarles cosas...
                        // Ademas tambien se llama a un metodo que segun dice su sumario, se encarga de "informale al objeto que inicio su inicializacion".
                        // lo que sea que eso signifique.
                        // Ambas cosas se deshacen al final de la inicializacion de un formulario creado por el constructor de ventanas.
                        // Vamos a probar un par de cosas...

                        // Puedo agregar un control a la ventana si no la lanzo primero verdad? (esta es de prueba)
                        // { 
                        //      Instancia_Formulario.Controls.Add( ( new Label() { Text = "Esto es un control cualquiera.", Size = new Size( 100, 50 ) } ) ) ;
                        //      Hilo_Instancia_Formulario.Start() ;
                        // } Continuar() ;

                        // Si trato de agregar un control a la ventana sin suspenderla y sin "avisarle que esta siendo inicializada" saltara una excepcion?
                        // { 
                        //         Hilo_Instancia_Formulario.Start() ;
                        //         // Continuar("Se agregara una label a la ventana") ;
                        //         Instancia_Formulario.Controls.Add( ( new Label() { Text = "Esto es un control cualquiera." } ) ) ; // Falla si coloco un `Continuar` antes de la sentencia.... Curioso. Lo tomo como que se supone que falle.
                        //         Continuar("Se agrego la label.") ;
                        //         Instancia_Formulario.Controls.Add( new Panel() ) ; // Falla.

                        // No se puede. No deja, justo como esperaba.
                        // } Continuar() ;

                        // Si trato de agregarle un control suspendiendo el layout y "avisandole que se le va a inicializar" como hace el designer, y luego de terminar deshago esas dos cosas deja?
                        // {
                        //        Hilo_Instancia_Formulario.Start() ;
                        //        Continuar("Se inicio el formulario, se suspendera el layout.") ;

                        //        Instancia_Formulario.SuspendLayout() ;
                        //        Continuar("Se suspendio el layout, se tratara de agregar una label.") ;

                        //        Instancia_Formulario.Controls.Add( ( new Label() { Text = "Esto es un control cualquiera." } ) ) ;
                        //        Continuar("Se agrego la label. ") ;
                        // }

                        // Si trato de agregarle un control el cual es inicializado dentro del hilo UI?
                        //{
                        //        Label Label_Que_Se_Usara_Mas_Tarde_En_El_Hilo_UI = new Label()
                        //        { 
                        //                                Text = "Esto es una label cuya *referencia* fue creada dentro del subproceso." ,
                        //                                Size = new Size( 50, 200 )
                        //        } ;

                        //        Continuar("Se creo la label que se inicilizara adecuadamente dentro del hilo(subproceso) de UI.") ;

                        //        Thread Hilo_Instancia_Formulario_Y_Creacion_Control = new Thread
                        //        (
                        //                () =>
                        //                {
                        //                        Label Label_Inicializada_Dentro_Del_Subproceso_UI = Label_Que_Se_Usara_Mas_Tarde_En_El_Hilo_UI ;
                        //                        Application.Run( Instancia_Formulario ) ;
                        //                }
                        //        ) ;

                        //        Hilo_Instancia_Formulario_Y_Creacion_Control.Start() ;
                        //        Continuar("Se corrio el formulario, se agregara la label a dicho formulario.") ;

                        //        Instancia_Formulario.Controls.Add( ) ;
                        //}

                        // Puedo alterar un control CUALQUIERA cambiando su posicion?
                        //{ 
                        //        Button Boton_A_Alterar = new Button()
                        //        {
                        //                Text = "Este es un boton a alterar" ,
                        //                Size = new Size( 50, 200 ) ,
                        //                Location = new Point( 100, 100 )         
                        //        } ;
                        //        Continuar("Se creo un boton a alterar, se anadira al formulario, y se correra el mismo.") ;
                                
                        //        Instancia_Formulario.Controls.Add( Boton_A_Alterar ) ;
                        //        Hilo_Instancia_Formulario.Start() ;
                        //        Continuar("Hay un boton delante de ti, se tratara de alterar el mismo.") ;

                        //        int Indice_Boton_A_Alterar = Instancia_Formulario.Controls.IndexOf( Boton_A_Alterar ) ;
                        //        Instancia_Formulario.Controls[ Indice_Boton_A_Alterar ].Location = new Point( 50,50 ) ;
                        //        Instancia_Formulario.Controls[ Indice_Boton_A_Alterar ].Size = new Size( 200, 50 ) ;
                        //        Continuar("El boton fue alterado.") ;

                        //        // Exito. Si es posible cmabiar tanto su tamano como su posicion. Como extra tambien se que lo puedo alterar utilizando la referencia del formulario
                        //        // en vez de alterarlo directamente.
                        //}

                        // Puede la version (opuesto a upcast)eada de un objeto alterar el estado de los miembros del mismo?
                        //{ 
                                
                        //        SuperButton Instancia_SuperButton = new SuperButton()
                        //        {
                        //                Text = "Este NO es un SuperButton" ,
                        //                Size = new Size( 50, 200 ) ,
                        //                Location = new Point( 10, 10 )         
                        //        } ;
                        //        Button Instancia_Upcastead_SuperButton = ( Button ) Instancia_SuperButton ; // Me da igual si el cast es redundante :]

                        //        Continuar("Se creo un SuperBoton a alterar, se anadira al formulario, y se correra el mismo.") ;
                                
                        //        Instancia_Formulario.Controls.Add( Instancia_Upcastead_SuperButton ) ; 
                        //        Hilo_Instancia_Formulario.Start() ;
                        //        Continuar("Hay un button delante de ti, el cual es un upcast de un SuperButton. Se tratara de alterar el mismo a traves de una llamada a su metodo mediante upcast.") ;
                                
                        //        ( ( SuperButton) Instancia_Upcastead_SuperButton ).Alterar( SuperButton.Posicion.Uno ) ;
                        //        Continuar("El boton upcasteado fue alterado. Solo por si acaso se alterara de nuevo de forma diferente...") ;
                                
                        //        ( ( SuperButton) Instancia_Upcastead_SuperButton ).Alterar( SuperButton.Posicion.Dos ) ;
                        //        Continuar("Se volvio a alterar el boton upcasteado.") ;

                        //        // Si, si funciona. No se que tan "bueno" es hacer esto, pues siento que va en contra del proposito de poner tipos en las referencias.
                        //        // El tipo de la referencia dice como se supone que se comporte el objeto que tiene dentro. Pero al hacer este "truco", logras hacer 
                        //        // que el objeto que guarda se comporte efectivamente como otro tipo de objeto utilizando como base la misma referencia.
                        //        // Pero si bien en este caso un `SuperButton` tiene un comportamiento extra al que tiene un `Button` cualquiera, este comportamiento 
                        //        // es modificar el estado del button que hay detras de superbutton... Por eso no considero que este tan mal. Ademas, en este caso esta
                        //        // gimica esta muy bien autocontenida dentro de la clase `SuperButton`, la cual es extremadamente simple por si misma.
                        //        // Lo considero viable, pero considerare si implementarlo de esta manera.
                        //}
                        
                        //{
                        //        Continuar("Se creara un selector de capas.") ;

                        //        Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Selector_Capas Instancia_Local_Selector_Capas = new Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Selector_Capas() ;
                        //        Continuar("Se alterara el selector de capas.") ;

                        //        Instancia_Local_Selector_Capas.Recaracterizar( Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Selector_Capas.Posible_Boton_Seleccionado.Personas) ;
                        //        Continuar("Se asignara el selector de capas a un panel mediante un upcast y ademas se creara un formulario.") ;

                        //        Panel Instancia_Local_Panel = ( Panel ) Instancia_Local_Selector_Capas ;

                        //        MyForm Instancia_MyFormulario = new MyForm()
                        //        {
                        //                Instancia_Selector_Capas = Instancia_Local_Selector_Capas ,
                        //                Instancia_Panel = Instancia_Local_Panel
                        //        } ;

                        //        Thread Hilo_MyFormulario = new Thread
                        //        (
                        //                () => { Application.Run( Instancia_MyFormulario ) ;  }
                        //        ) ;
                        //        Hilo_MyFormulario.Start() ;

                        //        Continuar("Se dara informacion sobre el panel de myformulary.") ;
                        //        Console.WriteLine() ;

                        //}
              //}

        //static void Upcasting_Probando_El_Selector_Paneles()
        //{
        //        void Continuar()
        //        { 
        //                Console.WriteLine("Presiona enter para continuar.") ;
        //                Console.ReadLine() ;
        //        }


        //        // using static Presentacion.Administracion_Sujetos ;
        //    //  { // Creamos un formulario
        //                MyForm Instancia_Formulario = new MyForm() ;
        //                Instancia_Formulario.Size = new Size( 1000, 500 ) ;

        //    //  {
        //        Console.WriteLine("Hay un formulario delante de ti.") ;
        //        Continuar() ;

        //   //   { // Creamos un panel vacio con bordes visibles y lo agregamos al formulario
        //                Panel Instancia_Local_Panel = new Panel() ;
        //                Instancia_Local_Panel.BorderStyle = BorderStyle.FixedSingle ;
        //                Instancia_Formulario.Instancia_Panel = Instancia_Local_Panel ;
        //                Instancia_Formulario.Controls.Add( Instancia_Formulario.Instancia_Panel ) ;
        //                Continuar() ;
        //  //    }


        //                Thread Hilo_Instancia_Lanzando_Formularios = new Thread
        //                (
        //                        void () => { Application.Run( Instancia_Formulario ) ; }        
        //                ) ;
        //                Hilo_Instancia_Lanzando_Formularios.Start() ;
        //                Console.WriteLine("Ahora deberias ver un formulario enfrente de ti.") ;
        //                Continuar() ;

        //            //  Instancia_Local_Panel.BorderStyle = BorderStyle.Fixed3D ;
        //            //  Console.WriteLine("El panel en pantalla cambio?") ;
        //            //  Continuar() ;

        //                Instancia_Local_Panel.Size = new Size( 900, 400 ) ;
        //                Console.WriteLine("Se agrando el panel.") ;
        //                Continuar() ;

        //                Label Instancia_Local_Label =
        //                new Label() {
        //                        Text = "Esto es una label.",
        //                        Font =  new Font("Leelawadee", 15F, FontStyle.Bold, GraphicsUnit.Point)
        //                } ;
        //                Instancia_Formulario.Instancia_Label = Instancia_Local_Label ;

        //                Instancia_Formulario.SuspendLayout() ;
        //                Instancia_Formulario.Instancia_Panel.SuspendLayout() ;

        //                Instancia_Formulario.Instancia_Panel.Controls.Add( Instancia_Formulario.Instancia_Label ) ;
        //                Console.WriteLine("Hay una label enfrente de ti.") ;
        //                Continuar() ;

        //                Instancia_Local_Panel = ( new Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Selector_Capas() ) ;
        //                Console.WriteLine("Se asigno una instancia del selector de capas a `Instancia_Local_Panel` sin catrarla.") ;
        //                Continuar() ;

        //                Instancia_Local_Panel = ( ( Panel ) ( new Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Selector_Capas() ) ) ;
        //                Console.WriteLine("Se asigno una instancia del selector de capas a `Instancia_Local_Panel` mediante upcast.") ;

        //}

        //static void Debug_Selector_Capas()
        //{
        //        // Se utiliza `Selector_Panel` de `Presentacion.Administracion_Sujetos ;


        //        // Como jack el destripador, voy a ir por partes:
        //        // He identificado 4 capas de complejidad, las cuales se apilan una encima de la otra;
        //        // * Hilos
        //        // * Formulario
        //        // * Selector_Panel
        //        // * Panel

        //        // Asi que voy de lo mas basico a lo mas complejo
        //        Form Instancia_Formulario = new Form() ;
        //        Thread Hilo_UI = new Thread
        //         (
        //                () => { Application.Run( Instancia_Formulario ) ; }
        //         ) ;

        //        // Anda el panel que hay debajo de `Selector_Capas`?
        //        //{ 
        //        //        Continuar("Se creara un `Selector_Capa`.") ;

        //        //        Formulario_Administracion_Sujetos.Selector_Capas Instancia_Selector_Capas = new Formulario_Administracion_Sujetos.Selector_Capas() ;
        //        //        Continuar("Se evaluara si `Instancia_Selector_Capas` es null o no.") ;

        //        //        if ( Instancia_Selector_Capas is null ) { Console.WriteLine("`Instancia_Selector_Capas` es null.") ; }
        //        //        else { Console.WriteLine("`Instancia_Selector_Capas` NO es null.") ; }
        //        //        Continuar("Se creara un upcast de ese selector de capas.") ;

        //        //        Panel Upcast_Selector_Capas = ( Panel ) Instancia_Selector_Capas ; 
        //        //        Continuar("Se evaluara si el upcast es null o no. Si no es null se enumeraran algunos de sus atributos.") ;

        //        //        if ( Upcast_Selector_Capas is null ) { Console.WriteLine("El upcast es null.") ; }
        //        //        else
        //        //        { 
        //        //                Console.WriteLine("El upcast NO es null.") ; 
        //        //                Console.WriteLine("Atributos del upcast:" +
        //        //                        "\nName: " + Upcast_Selector_Capas.Name +
        //        //                        "\nLocation: " + Upcast_Selector_Capas.Location +
        //        //                        "\nSize: " + Upcast_Selector_Capas.Size +
        //        //                        "\nBorderStyle: " + Upcast_Selector_Capas.BorderStyle +
        //        //                        ".") ;        
        //        //        }
        //        //        Continuar("Se evaluara si el upcast es valido como panel.") ;

        //        //        if ( Upcast_Selector_Capas is Panel ) { Console.WriteLine("El upcast es valido como un `Panel.`") ; }
        //        //        else { Console.WriteLine("El upcast NO es valido como panel.") ; }
        //        //        Continuar("Se agregara el upcast del selector de capas al formulario.") ;

        //        //        Instancia_Formulario.Controls.Add( Upcast_Selector_Capas ) ;                             
        //        //        Continuar("Se evaluar si el control en el formulario es null.") ;

        //        //        // if ( Instancia_Formulario.Controls[ "Upcast_Selector_Capas" ] is null ) { Console.WriteLine("El upcast como control en el formulario es null.") ; }
        //        //        // else { Console.WriteLine("El upcast como control en el formulario NO es null.") ; }

        //        //        int Indice_Upcast = Instancia_Formulario.Controls.IndexOf( Upcast_Selector_Capas ) ;
        //        //        if ( Indice_Upcast == -1 ) { Console.WriteLine("El upcast como control no existe en el formulario.") ; }
        //        //        else
        //        //        { 
        //        //                Console.WriteLine("El upcast como control existe en el formulario.") ;

        //        //                if ( Instancia_Formulario.Controls[ Indice_Upcast ] is null ) { Console.WriteLine("El upcast como control en el formulario es null.") ; }
        //        //                else { Console.WriteLine("El upcast como control en el formulario es null.") ; }
        //        //        }
        //        //        Continuar("Ahora se probara si el upcast como `Panel` es null.") ;

        //        //        if ( ( ( Panel ) Instancia_Formulario.Controls[ Indice_Upcast ] ) is null  ) { Console.WriteLine("El upcast como panel en el formulario es null.") ; }
        //        //        else { Console.WriteLine("El upcast como `Panel` en el formulario NO es null.") ; }
        //        //        Continuar("Se probara si el upcast del formulario es valido como `Panel`, si lo es trata de mostrar atributos del upcast del fromulario como `Panel`.") ;

        //        //        if ( Instancia_Formulario.Controls[ Indice_Upcast ] is Panel )
        //        //        {
        //        //                Console.WriteLine("El upcast en el formulario es valido como `Panel`.") ;

        //        //                Console.WriteLine("Informacion del upcast del formulario como `Panel`:" +
        //        //                        "\nName: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Upcast ] ).Name + 
        //        //                        "\nLocation: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Upcast ] ).Location + 
        //        //                        "\nSize: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Upcast ] ).Size + 
        //        //                        "\nBorderStyle: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Upcast ] ).BorderStyle +
        //        //                        ".") ;
        //        //        }
        //        //        else { Console.WriteLine("El upcast en el formulario NO es valido como `Panel`.") ; }

        //        //        Continuar("Se lanzara el formulario.") ;

        //        //        Hilo_UI.Start() ;
        //        //        Continuar("Se agregara un borde al panel para que sea facilmente visible.") ;


        //        //        ( ( Panel ) ( Instancia_Formulario.Controls[ Indice_Upcast ] ) ).BorderStyle = BorderStyle.FixedSingle ; // Esta linea me la enseno ChatGPT, le prestare mas detalle despues.
        //        //        Continuar("Se lanzo el formulario. EL panel se muestra adecuadamente.") ;

        //        //        // Continuar("Se creara una referencia que acceda al objeto detras de `Upcast_Selector_Capas` a traves del formulario en vez de acceder a el objeto directamente.") ;

        //        //        /*
        //        //        Panel Referencia_Indirecta_Upcast_Selector_Capas = ( ( Panel )Instancia_Formulario.Controls[ "Upcast_Selector_Capas" ] ) ;
        //        //        Continuar("Se comprobara si la referencia es o no null.") ;

        //        //        if ( Referencia_Indirecta_Upcast_Selector_Capas is null ) { Console.WriteLine("La referncia es null.") ; }
        //        //        else { Console.WriteLine("La referencia NO es null.") ; }
        //        //        Continuar("Se comprobara si el objeto detras de la referencia directa es o no null.") ;

        //        //        if ( Upcast_Selector_Capas is null ) { Console.WriteLine("El objeto detras de la referencia directa es null.") ; }
        //        //        else { Console.WriteLine("El objeto detras de la referencia directa NO es null.") ; }
        //        //        Continuar("Se agregara un borde al panel para que sea facilmente visible.") ;


        //        //        Referencia_Indirecta_Upcast_Selector_Capas.BorderStyle = BorderStyle.FixedSingle ; // Esta linea me la enseno ChatGPT, le prestare mas detalle despues.
        //        //        Continuar("Se lanzo el formulario. EL panel se muestra adecuadamente.") ;
        //        //        */
        //        //}

        //        //{
        //        //        Form Formulary_Instance = new Form() ;
        //        //        Formulario_Administracion_Sujetos.Selector_Capas Layer_Selector_Instance = new Formulario_Administracion_Sujetos.Selector_Capas() ;
        //        //        Panel Upcasted_Layer_Selector = ( ( Panel ) Layer_Selector_Instance ) ;

        //        //        Formulary_Instance.Controls.Add( Upcasted_Layer_Selector ) ;
        //        //        int Index_Layer_Selector = Formulary_Instance.Controls.IndexOf( Upcasted_Layer_Selector ) ;

        //        //        if ( Formulary_Instance.Controls[ Index_Layer_Selector ] is null )
        //        //        {
        //        //                Console.WriteLine("`Upcasted_Layer_Selector` as a `Control` is null in the form.") ;
        //        //        }
        //        //        else
        //        //        {
        //        //                Console.WriteLine("`Upcasted_Layer_Selector` as a `Control` is NOT null in the form.") ;
        //        //        }

        //        //        if ( ( ( Panel ) Formulary_Instance.Controls[ Index_Layer_Selector ] ) is null ) {
        //        //                Console.WriteLine("`Upcasted_Layer_Selector` as a `Panel` is null in the form.") ;
        //        //        }
        //        //        else
        //        //        {
        //        //                Console.WriteLine("`Upcasted_Layer_Selector` as a `Panel` is NOT null in the form.") ; 
        //        //        }

        //        //        // Output of the snippet:
        //        //        // `Upcasted_Layer_Selector` as a `Control` is NOT null in the form.
        //        //        // `Upcasted_Layer_Selector` as a `Panel` is NOT null in the form.
        //        //}

        //       // { 
        //       //       Console.WriteLine("&Los atributos de el `Panel` en el `Selector_Panel` son correctos:") ;
        //       //       Continuar("Se creara un `Selector_Capas`, ademas de eso se agregara la instancia del selector de capas mediante un upcast.") ;
        //       //
        //       //       Instancia_Formulario = new Form() ;
        //       //       Formulario_Administracion_Sujetos.Selector_Capas Instancia_Selector_Capas = new Formulario_Administracion_Sujetos.Selector_Capas() ;

        //       //       Instancia_Formulario.Controls.Add( ( ( Panel ) Instancia_Selector_Capas ) ) ;
        //       //       int Indice_Selector_Capas = Instancia_Formulario.Controls.IndexOf( Instancia_Selector_Capas ) ;
        //       //       Continuar() ;

        //       //       Continuar("Se corroborara si el panel es null, y se mostraran los atributos del `Panel` que subyace en el selector de capas.") ;
        //       //       if ( ( ( Panel ) Instancia_Formulario.Controls[ Indice_Selector_Capas ] ) is not null )
        //       //       {
        //       //               Console.WriteLine("El panel que subyace en el selector de capas es NO null.") ;
        //       //               Console.WriteLine("Los atributos son: " +
        //       //                               "\nName: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Selector_Capas ] ).Name + 
        //       //                               "\nLocation: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Selector_Capas ] ).Location + 
        //       //                               "\nSize: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Selector_Capas ] ).Size +
        //       //                               "\nAutoScroll: " + ( ( Panel ) Instancia_Formulario.Controls[ Indice_Selector_Capas ] ).AutoScroll +
        //       //                               ".") ;
        //       //       }
        //       //       else { Console.WriteLine("El panel que subyace en el subyace en el selector de capas es null; osea no hay panel que subyazca en el selector de capas.") ; }
        //       //       Continuar("El panel tiene atributos correctos.") ;
        //      //}

        //        { 
        //                Console.WriteLine("&Botones del selector de capas: ") ;
        //                Continuar("Se arrancara un proceso para determinar cuales son los controles de el selector de capas(si es que hay alguno)..") ;

        //                Continuar("Se configurara el formulario, un selector para el mismo y un hilo para correr tal winform antes de arrancar." +
        //                          "Por si no estaba ya.") ;
        //                Formulario_Administracion_Sujetos.Selector_Capas Instancia_Selector_Capas = new Formulario_Administracion_Sujetos.Selector_Capas() ;
        //                Instancia_Selector_Capas.BorderStyle = BorderStyle.FixedSingle ;
        //                Instancia_Formulario.Controls.Add( Instancia_Selector_Capas ) ;

        //                Console.WriteLine("Tambien se le dio un borde al panel subyacente en el selector.") ;

        //                Continuar("Se mostrara la cantidad de controles en el formulario(mas no es en el selector).") ;
        //                Console.WriteLine( "Cantidad de controles del formulario: " + Instancia_Formulario.Controls.Count ) ;

        //                Continuar("Se conseguira el indice del selector de capas.") ;
        //                int Indice_Selector_Capas = 0 ;
        //                foreach ( Control Control_Actual in Instancia_Formulario.Controls )
        //                {
        //                        if ( Control_Actual.Name == "Panel_Selector_Capas" ) { break ; }        
        //                        Indice_Selector_Capas++ ;
        //                }
        //                Console.WriteLine("El indice del selector es: " + Indice_Selector_Capas ) ;
        //                Continuar() ;

        //                Console.WriteLine("Controles en el panel:") ;
        //                foreach ( Control Control_Actual in Instancia_Formulario.Controls[ Indice_Selector_Capas ].Controls ) { Console.WriteLine( Control_Actual.Name + ", " ) ; }
        //                Console.WriteLine(".") ;
        //                Console.WriteLine("Controles en el selector de capas = " + Instancia_Formulario.Controls[ Indice_Selector_Capas ].Controls.Count ) ;
        //                Continuar() ;

        //                Continuar("Se tratara de agregar un control arbitrario para probar si afecta o no que sea una subclase.") ;
        //                Label Control_Arbitrario = new Label() ;
        //                {
        //                        Control_Arbitrario.Text = "Este es un control arbitrario" ;
        //                        Control_Arbitrario.Size = new Size( 200, 100 ) ;
        //                }
        //                Instancia_Selector_Capas.Controls.Add( Control_Arbitrario ) ;
        //                Continuar("Se lanzara el formulario.") ;
        //                Hilo_UI.Start() ;

        //                Continuar("Se quitara ese control arbitrario.") ;
        //                Instancia_Selector_Capas.Controls.Remove( Control_Arbitrario ) ;
        //                Instancia_Selector_Capas.Refresh() ;

        //                // Continuar("Se cerrara el formulario.") ;
        //                // Instancia_Formulario.Close() ;
        //                // Hilo_UI.Join() ;

        //                { // Prueba del contructor + el metodo `Recaracterizar` 
        //                        Console.WriteLine("&Prueba del metodo `Recaracterizar`:") ;
        //                        Continuar("Se recaracterizara el selector con el boton `Proveedor` como el elegido.") ;

        //                        // Instancia_Selector_Capas.Recaracterizar( Formulario_Administracion_Sujetos.Selector_Capas.Opcion_Selector_Capas.Proveedores ) ;
        //                        Console.WriteLine("El selector fue recaracterizado.") ;

        //                        Continuar("Se robara codigo del recaracterizador para agregar un boton.") ;


        //                        Continuar() ;
        //                }

        //                Continuar("Se mostraran los atributos de los botones.") ;
        //                foreach ( Button Boton_Actual in Instancia_Formulario.Controls[ Indice_Selector_Capas ].Controls )
        //                {
        //                        Console.WriteLine("Atributos " + Boton_Actual.Name + ": " +
        //                                "\nLocation: " + Boton_Actual.Location + 
        //                                "\nVisible: " + Boton_Actual.Visible + 
        //                                "\nBackColor: " + Boton_Actual.BackColor +
        //                                "\nBorderColor: " + Boton_Actual.FlatAppearance.BorderColor + 
        //                                "\n" +
        //                                "\nSize: " + Boton_Actual.Size +
        //                                "\nBorderStyle: " + Boton_Actual.FlatStyle +
        //                                "\nBorderSize: " + Boton_Actual.FlatAppearance.BorderSize +
        //                                ".") ;
        //                        Continuar("Se mostrara el siguiente boton.") ;
        //                }

        //                Continuar("Se mostrara la caracterizacion actual del selector. Este proceso se hara 4 veces con una pausa en medio de cada repreticion.") ;
        //                Continuar("Se consultara la caracterizacion del selector.") ;
        //                for ( int i = 0 ; i < 4 ; i++ )
        //                {
        //                       Console.WriteLine("La caracterizacion actual del selector es: " + Instancia_Selector_Capas.Caracterizacion_Actual ) ;
        //                       Continuar("Se consultara la caracterizacion nuevamente.") ;
        //                }
        //                Continuar() ;
        //        }
        //}

        //static void Prueba_Selector_Capas()
        //{ 
        //        Formulario_Administracion_Sujetos Instancia_Selector_Capas = new Formulario_Administracion_Sujetos() ;
        //        Thread Hilo_UI = new Thread
        //        (
        //            () => { Application.Run() ; }        
        //        ) ;

        //        Hilo_UI.Start() ;

        //        Continuar("Se consultara la posicion del segundo boton.") ;
        //        Console.WriteLine( Instancia_Selector_Capas ) ;
        //}


        //static void Conexion_A_La_Base_De_Datos()
        //{
        //        DataTable? Resultado_Select ;

        //        Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql Tipo_Comando = Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query ;
        //        Resultado_Select = ( DataTable ) Acceso_Datos.Interfaz_Base_Datos.Ejecutar( Sentencia_A_Ejecutar: "select * from tabla_2 where Nombre_De_Alguien=@Nombre_De_Alguien" , Tipo_Comando_Sql_Seleccionado: Tipo_Comando , Unico_Parametro_Query: "@Nombre_De_Alguien", Unico_Argumento_Query: "elpepe" ) ;

        //        Console.WriteLine("A continuacion se mostrara el resultado de una query no escalar:") ;
        //        Mostrar_Tabla( Resultado_Select ) ;
        //}


        //static void Debug_Atributos_Capa()
        //{ 
        //        Form Instancia_Formulario = new Form{ Padding = new Padding(0), Margin = new Padding(0) } ;
        //        Thread Hilo_Ui = new Thread
        //        (
        //                () => { Application.Run( Instancia_Formulario ) ; }
        //        ) ;

        //        Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Atributos_Capa Instancia_Atributos_Capa ;

        //        Continuar("&Se probara a `Atributos_Capa`") ;
        //        Instancia_Atributos_Capa = new Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Atributos_Capa( Formulario_Administracion_Sujetos.Caracterizacion_Formulario.Empleados ) ;

        //        Instancia_Formulario.Controls.Add( Instancia_Atributos_Capa ) ;
        //        Console.WriteLine( "El padding de todo el panel es: " + Instancia_Atributos_Capa.Padding.All + ", el margin de todo el panel es: " + Instancia_Atributos_Capa.Margin.All ) ;

        //        int Numero_Controles_Atributos_Capa = Instancia_Atributos_Capa.Controls.Count - 1 ;
        //        Button Boton_Que_Es_Una_Label = new Button
        //        {
        //                Size = (Instancia_Atributos_Capa.Controls[ Numero_Controles_Atributos_Capa ]).Size,
        //                AutoSize = true,
        //                Location = (Instancia_Atributos_Capa.Controls[ Numero_Controles_Atributos_Capa ]).Location,
        //                Text = (Instancia_Atributos_Capa.Controls[ Numero_Controles_Atributos_Capa ]).Text,
        //                Padding = new Padding(0), // (Instancia_Atributos_Capa.Controls[ Numero_Controles_Atributos_Capa ]).Padding,
        //                Margin = new Padding(26), //(Instancia_Atributos_Capa.Controls[ Numero_Controles_Atributos_Capa ]).Margin,
        //                FlatStyle = FlatStyle.Flat

        //        } ;
        //        // Instancia_Atributos_Capa.Controls.RemoveAt( Numero_Controles_Atributos_Capa ) ;
        //        // Instancia_Atributos_Capa.Controls.Add( Boton_Que_Es_Una_Label ) ;
        //        Hilo_Ui.Start() ;

        //        Continuar() ;
        //}

        //class Person
        //{
        //        public string Name { get; set; }
        //        public int Age { get; set; }
        //}
        //static void Prueba_DataGridView()
        //{ 
        //        // Este es un pequeño ejemplo de ChatGPT adaptado para correr en un Hilo de Interfaz de Usuario.
        //        var form = new Form();
        //        Thread Hilo_UI = new Thread
        //        (
        //                () => { Application.Run( form ) ; } 
        //        ) ;





        //        //  Application.EnableVisualStyles();
        //        //  Application.SetCompatibleTextRenderingDefault(false);

        //        // Create a BindingList of Person objects
        //        var people = new System.ComponentModel.BindingList<Person>
        //        {
        //            new Person { Name = "Alice", Age = 30 },
        //            new Person { Name = "Bob", Age = 25 },
        //            new Person { Name = "Charlie", Age = 40 }
        //        };

        //        // Create a DataGridView and set its DataSource to the BindingList
        //        var dataGridView = new DataGridView
        //        {
        //            DataSource = people
        //        };

        //        // Create a form and add the DataGridView to it

        //        form.Controls.Add(dataGridView);

        //        // Add a button to modify the data source
        //        var addButton = new Button
        //        {
        //            Text = "Add Person"
        //        };
        //        addButton.Click += (sender, e) =>
        //        {
        //            // Add a new person to the BindingList
        //            people.Add(new Person { Name = "New Person", Age = 50 });
        //        };
        //        form.Controls.Add(addButton);

        //        Hilo_UI.Start() ;
        //        Continuar() ;
        //        people.Add(new Person { Name = "New Person", Age = 50 });
        //        Continuar() ;

        //        form.Close() ;

        //}

        //static void Prueba_TextBoxNumerico()
        //{ 
        //        Form Instancia_Formulario = new Form();
        //        Thread Hilo_UI = new Thread
        //        (
        //                () => { Application.Run( Instancia_Formulario ) ; } 
        //        ) ;

        //        Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Atributos_Capa.TextBoxNumerico Instancia_TextBoxNumerico = new Formulario_Administracion_Sujetos.Atributos_Capa.TextBoxNumerico() ; 
        //        Instancia_Formulario.Controls.Add( Instancia_TextBoxNumerico ) ;

        //        Hilo_UI.Start() ;
        //}

        //static void Prueba_CheckedList_Nivel_Confidencialidad()
        //{ 
        //        Form Instancia_Formulario = new Form();
        //        Thread Hilo_UI = new Thread
        //        (
        //                () => { Application.Run( Instancia_Formulario ) ; } 
        //        ) ;

        //        Formulario_Administracion_Sujetos.Atributos_Capa.CheckedListBox_Nivel_Confidencialidad Eso = new Formulario_Administracion_Sujetos.Atributos_Capa.CheckedListBox_Nivel_Confidencialidad() ;
        //        Eso.Size = ( new Size( width: 180, height: 100 ) ) ;

        //        Instancia_Formulario.Controls.Add( Eso ) ;

        //        Hilo_UI.Start() ;
        //}

        //static void Prueba_Administrador_Tareas_Asignadas()
        //{ 
        //        Form Instancia_Formulario = new Form();
        //        Thread Hilo_UI = new Thread
        //        (
        //                () => { Application.Run( Instancia_Formulario ) ; } 
        //        ) ;

        //        Presentacion.Administracion_Sujetos.Formulario_Administracion_Sujetos.Atributos_Capa.Administrador_Tareas_Asignadas Eso = new Formulario_Administracion_Sujetos.Atributos_Capa.Administrador_Tareas_Asignadas( new Point(450, 200) ) ;
        //        Instancia_Formulario.Controls.Add( Eso ) ;

        //        Hilo_UI.Start() ;

        //        Continuar() ;
        //        Instancia_Formulario.Controls.Add( Eso.Cabecera_Tareas_Asignadas ) ;
        //        Continuar() ;
        //        Eso.Controls.Add( Eso.Cabecera_Tareas_Asignadas ) ;
        //        Continuar() ;
        //        // Eso.Bounds = null ;
        //}

        //static void Prueba_Insercion_Usuarios()
        //{ 
        //        // Console.WriteLine( $"El Length del string '1010' es = { ("1010").Length }" ) ;
        //        Continuar("Se continuara pronando a insertar un Usuario en la base de datos con los siguientes campos:" +
        //                "Nombre_Identificador:\n" +
        //                "Prueba Insercion de Usuario\n" +
        //                "Contrasena: Contrasena de prueba en texto plano\n" +
        //                "Nivel_Confidencialidad: 1010\n" +
        //                "Inactivo: true") ;

        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Insertar_Usuario
        //                ( 
        //                    "Prueba Insercion de Usuario", 
        //                    "Contrasena de prueba en texto plano", 
        //                    "1010", 
        //                    true
        //                ) ;
        //}

        //static void Prueba_Insecion_Persona()
        //{ 
        //        Continuar("Se insertara una Persona de prueba en la base de datos.") ;

        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Insertar_Persona
        //                (
        //                    "PersonaDePrueba",
        //                    "ApellidoDePrueba",
        //                    "TelefonoDePrueba"
        //                ) ;
        //}

        //static void Prueba_Insercion_Empleado()
        //{ 
        //        Continuar("Se insertara un Empleado de prueba. El cual tendra 666 horas trabajadas.") ;

        //        Acceso_Datos.Interfaz_Base_Datos.Insertar_Empleado( Horas_Trabajadas: 666 ) ;
        //}

        //static void Prueba_Transaccion_Base_Datos()
        //{
        //        Continuar("Se probara a hacer una transaccion.") ;
        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Ejecutar
        //                (
        //                        new string[]
        //                        {  
        //                                "insert into Proveedores() values () ;",
        //                                "set @ID_Proveedor = LAST_INSERT_ID() ;",// Despues me di cuenta de que podia llamar a la funcion directamente pero ta.
        //                                "insert into Direccion_Empresa_Proveedor( ID_Proveedor, Barrio, Calle1, Calle2, Indicaciones ) values ( @ID_Proveedor, 'Un barrio', 'Una calle', 'Otra calle', 'Una descripcion' ) ;"
        //                        } 
        //                ) ;
        //}

        //static void Prueba_Insercion_Proveedor_Con_Empresa()
        //{ 
        //        Continuar("Se insertara un Proveedor con una empresa asociada.\n" +
        //                "---- Tabla > Proveedores\n" +
        //                "Nombre_Empresa: 'una empresa'\n" +
        //                "---- Tabla > Direccion_Empresa_Proveedor\n" +
        //                "Nombre_Empresa: 'una empresa'" +
        //                "Barrio: 'un barrio'\n" +
        //                "Calle1: 'una calle'\n" +
        //                "Calle2: 'otra calle'\n" +
        //                "Indicaciones: 'unas indicaciones'") ;

        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Insertar_Proveedor
        //                (
        //                    Nombre_Empresa: "una empresa",
        //                    Barrio: "un barrio",
        //                    Calle1: "una calle",
        //                    Calle2: "otra calle",
        //                    Indicaciones: "unas indicaciones"
        //                ) ;
        //}

        //static void Prueba_Administracion_Sujetos()
        //{ 
        //        Presentacion.Administracion_Sujetos.
        //                Formulario_Administracion_Sujetos Instancia_Administracion_Sujetos = new Formulario_Administracion_Sujetos() ;
        //        Thread Hilo_UI = new Thread
        //        (
        //                () => { Application.Run( Instancia_Administracion_Sujetos ) ; } 
        //        ) ;

        //        Hilo_UI.Start() ;
        //}

        //static void Prueba_Devolucion_Bit()
        //{
        //        object? Resultado =
        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Ejecutar
        //                (
        //                    "select Inactivo from Usuarios ;",
        //                    Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query_Escalar
        //                ) ;

        //        Type Tipo_Resultado = Resultado.GetType() ;
        //        Type Tipo_Subayacente_Resultado = Nullable.GetUnderlyingType( Tipo_Resultado ) ;

        //        Console.WriteLine( Tipo_Resultado ) ;
        //        Console.WriteLine( Tipo_Subayacente_Resultado ) ;
        //}

        //static void Prueba_Get_Usuario()
        //{
        //        string[]? Atributos_Usuario =
        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Get_Atributos_Usuario( "elPePeHunter_Xx" ) ;

        //        Console.WriteLine
        //        (
        //            $"Nombre_Identificador = { Atributos_Usuario[0] }\n" +
        //            $"Contrasena = { Atributos_Usuario[1] }\n" +
        //            $"Nivel_Confidencialidad = { Atributos_Usuario[2] }\n" +
        //            $"Inactivo = {Atributos_Usuario[3] }"        
        //        ) ;


        //}

        //static void Prueba_Get_Persona()
        //{
        //        string[]? Atributos_Persona =
        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Get_Atributos_Persona( "elPePeHunter_XxZ" ) ;

        //        /*
        //        string[]? Resultado = Acceso_Datos.Interfaz_Base_Datos.
        //                Get_Atributos_Persona( "elPePeHunter_XxZ" ) ;
        //        if ( Resultado is null ) { Console.WriteLine("Resultado es null. (is)") ; return ; } else { Console.WriteLine("Resultado no es null.(is)") ; }
        //        if ( Resultado == null ) { Console.WriteLine("Resultado es null. (==)") ; return ; } else { Console.WriteLine("Resultado no es null. (==)") ; }
        //        Console.WriteLine( $"T { Resultado.GetType() } ") ;
        //        */

        //        if ( Atributos_Persona is null ) { Console.WriteLine("La Persona es null.") ; return ; } // Me habia olvidado de cortar el flujo con un return. Y asi se me fueron 40 minutos al pedo.
        //        Console.WriteLine("Se mostrara la informacion de la persona encontrada...\n") ;
        //        foreach ( string Atributo in Atributos_Persona ) { Console.WriteLine( $"{ Atributo }" ) ; }
        //}

        //static void Prueba_Get_Empleado()
        //{ 
        //        string[]? Atributos_Empleado =
        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Get_Atributos_Empleado( "elPepeHunter_Xx" ) ;

        //        if ( Atributos_Empleado is null ) { Console.WriteLine("No hay tal Empleado.") ; return ; }
        //        foreach ( string Atributo in Atributos_Empleado ) { Console.WriteLine( Atributo ) ; }
        //}

        //static void Prueba_Get_Proveedor()
        //{ 
        //        string[]? Atributos_Proveedor =
        //        Acceso_Datos.Interfaz_Base_Datos.
        //                Get_Atributos_Proveedor( "elPepeHunter_Xx" ) ;

        //        if ( Atributos_Proveedor is null ) { Console.WriteLine("No hay tal Proveedor.") ; return ; }
        //        foreach ( string Atributo in Atributos_Proveedor ) { Console.WriteLine( Atributo ) ; }
        //}

        static void Prueba_Get_Sujeto()
        {
                Acceso_Datos.Interfaz_Base_Datos.Representacion_Sujeto? Representacion_Sujeto =
                Acceso_Datos.Interfaz_Base_Datos.
                        Get_Representacion_Sujeto("uggiugi");

                if (Representacion_Sujeto is null) { Console.WriteLine("No se encontro tal Sujeto."); return; }
                { // Show the attributes
                        Console.WriteLine("Persona:");
                        foreach (string Atributo in Representacion_Sujeto.Atributos_Persona) { Console.WriteLine(Atributo); }
                        Console.WriteLine();

                        Console.WriteLine("Usuario:");
                        if (Representacion_Sujeto.Atributos_Usuario is not null) { foreach (string Atributo in Representacion_Sujeto.Atributos_Usuario) { Console.WriteLine(Atributo); } }
                        Console.WriteLine();

                        Console.WriteLine("Empleado:");
                        if (Representacion_Sujeto.Atributos_Empleado is not null) { foreach (string Atributo in Representacion_Sujeto.Atributos_Empleado) { Console.WriteLine(Atributo); } }
                        Console.WriteLine();

                        Console.WriteLine("Proveedor:");
                        if (Representacion_Sujeto.Atributos_Proveedor is not null) { foreach (string Atributo in Representacion_Sujeto.Atributos_Proveedor) { Console.WriteLine(Atributo); } }
                        Console.WriteLine();
                }


        }

                //static void Prueba_Construccion_De_Sujeto_A_Partir_De_Representacion()
                //{ 
                //        Acceso_Datos.Interfaz_Base_Datos.Representacion_Sujeto? Representacion_Sujeto ;
                //        Logica.Sistema_de_Usuarios.Clase_Sujeto? Sujeto ;

                //        Representacion_Sujeto = Acceso_Datos.Interfaz_Base_Datos.
                //                Get_Representacion_Sujeto( "elPePeHunter_Xx" ) ;
                //        if ( Representacion_Sujeto is null ) { Console.WriteLine("No existe tal Sujeto.") ; return ; }

                //        Sujeto = new Logica.Sistema_de_Usuarios.Clase_Sujeto( Representacion_Sujeto ) ;
                //        Mostrar_Sujeto( Sujeto ) ;
                //}

                //static void Prueba_Autenticacion_Sujeto_Basado_En_Nombre_Identificador()
                //{

                //        /*
                //        Acceso_Datos.Interfaz_Base_Datos.
                //                Ejecutar
                //                ( 
                //                    "select * from Sujetos where Nombre_Identificador_Usuario = @Nombre_Identificador_Usuario ;",
                //                    Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query,
                //                    Parametro_De_La_Query: "@Nombre_Identificador_Usuario",
                //                    Argumento_De_La_Query: "elPePeHunter_Xx"
                //                ) ;
                //        */

                //        bool Sujeto_Existe =
                //        Acceso_Datos.Interfaz_Base_Datos.Sujeto_Existe( "pepe" ) ;

                //        Console.WriteLine( $"El Sujeto Existe: { Sujeto_Existe }" ) ;
                //}

                ///*
                //static void Prueba_Compound_Argument()
                //{ 
                //        DataTable? Tabla = ( DataTable? )
                //        Acceso_Datos.Interfaz_Base_Datos.
                //                Ejecutar
                //                (
                //                    "select * from Usuarios where Nombre_Identificador = @aloja  ;",
                //                    Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query,
                //                    Parametro_De_La_Query: "@aloja",
                //                    Argumento_De_La_Query: "'elPePeHunter_Xx' and Contrasena = '#$%%^^$#'"
                //                ) ;

                //        Mostrar_Tabla( Tabla ) ;
                //}
                //*/

                //static void Prueba_Nuevo_Ejecutar_Parametros_Null()
                //{ 
                //        DataTable? Tabla = ( DataTable? ) 
                //        Acceso_Datos.Interfaz_Base_Datos.
                //                Ejecutar
                //                (
                //                    "select * from Usuarios ;",
                //                    Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query,
                //                    Parametros_Query: null,
                //                    Argumentos_Query: null
                //                ) ;
                //        /*
                //        Acceso_Datos.Interfaz_Base_Datos
                //                .Ejecutar
                //                ( 
                //                    "select * from Usuarios where Nombre_Identificador = @Nombre_Identificador and Contrasena = @Contrasena ;",
                //                    Tipo_Comando_Sql_Seleccionado: Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query,
                //                    Parametros_Query: ( new string[] { "@Nombre_Identificador", "Contrasena" } ),
                //                    Argumentos_Query: ( new string[] { "elPePeHunter_Xx", "#$%%^^$#" } )
                //                ) ;
                //        */
                //        Mostrar_Tabla( Tabla ) ;
                //}

                //static void Prueba_Nuevo_Ejecutar_Unico_Parametro()
                //{ 
                //        DataTable? Tabla = ( DataTable? )

                //        Acceso_Datos.Interfaz_Base_Datos
                //                .Ejecutar
                //                ( 
                //                    "select * from Usuarios ;",
                //                    Tipo_Comando_Sql_Seleccionado: Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query
                //                ) ;
                //        /*
                //        Acceso_Datos.Interfaz_Base_Datos
                //                .Ejecutar
                //                ( 
                //                    "select * from Usuarios where Nombre_Identificador = @Nombre_Identificador ;",
                //                    Tipo_Comando_Sql_Seleccionado: Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query,
                //                    Unico_Parametro_Query: "@Nombre_Identificador",
                //                    Unico_Argumento_Query: "xX_Onichan_Xx"
                //                ) ;
                //        */

                //        Mostrar_Tabla( Tabla ) ;
                //}

                static void Prueba_Sujeto_Existe()
                {
                        if (
                        Acceso_Datos.Interfaz_Base_Datos.
                                Sujeto_Existe("elPePeHunter_Xx")
                           )
                        { Console.WriteLine("Sujeto existe."); }
                        else { Console.WriteLine("Sujeto no existe."); }
                }

                //static void Prueba_Usuario_Esta_Inactivo()
                //{
                //        bool Usuario_Esta_Inactivo =
                //        Logica.Sistema_de_Usuarios.Autenticación_Sujetos.
                //                Usuario_Esta_Inactivo( /* "elPePeHunter_Xx" */ "S-Men" ) ;

                //        Console.WriteLine($"El Usuario esta Inactivo: { Usuario_Esta_Inactivo }") ;
                //}

                //static void Prueba_DBNull_Fallo_Coincidencia_En_Sentencia_Where()
                //{
                //        object? Cosa ;

                //        Cosa = 

                //               /* Acceso_Datos.Interfaz_Base_Datos.
                //                                Ejecutar
                //                                (
                //                                        "select ID_Proveedor from Sujetos where Nombre_Identificador_Usuario = @Nombre_Identificador_Usuario ;",
                //                                        Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query_Escalar,
                //                                        Unico_Parametro_Query: "@Nombre_Identificador_Usuario",
                //                                        Unico_Argumento_Query: "EsteUsuarioNoExisteLokjwrpovjfgkwyoegr"
                //                                ) ;
                //               */ // Esto devuelve una referencia `null`.

                //                /*      Acceso_Datos.Interfaz_Base_Datos
                //                                .Ejecutar
                //                                (
                //                                   "select * from Sujetos where ID_Proveedor = @ID_Proveedor ;",
                //                                   Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query,
                //                                   Unico_Parametro_Query: "@ID_Proveedor",
                //                                   Unico_Argumento_Query: "ValorNoExistenteVsdvsgrgrgsggs"
                //                                )
                //             */ // Esto devuelve una DataTable, la cual tiene cero filas en total.

                //                Acceso_Datos.Interfaz_Base_Datos.
                //                                Ejecutar
                //                                (
                //                                        "select ID_Proveedor from Sujetos where Nombre_Identificador_Usuario = @Nombre_Identificador_Usuario ;",
                //                                        Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query_Escalar,
                //                                        Unico_Parametro_Query: "@Nombre_Identificador_Usuario",
                //                                        Unico_Argumento_Query: "S-Men"
                //                                ) ; // El Usuario "S-Men", su Sujeto tiene una ID_Proveedor null en la base de datos.
                //                // Esto devuelve DBNull.

                //        Console.WriteLine( Cosa.GetType() )  ;

                //        /*      DBNull es la representacion de un valor null en la base de datos.
                //         *      Una query escalar Devuelve `null` si no hay coincidencias. Y devuelve null si el campo coincidente es literalmente `null`.
                //         * 
                //         */
                //}

                //static void Debug_Conseguir_Sujeto_Con_Capas_Null()
                //{
                //        Acceso_Datos.Interfaz_Base_Datos.Get_Atributos_Empleado( "S-Men" ) ;

                //        Clase_Sujeto Sujeto =
                //        Logica.Sistema_de_Usuarios.
                //                Autenticación_Sujetos.Conseguir_Sujeto( ( new Logica.Sistema_de_Usuarios.Clase_Sujeto( true, "S-Men", "hotlineGOD" ) ) ) ;


                //        Mostrar_Sujeto( Sujeto ) ;
                //}

                //static void Prueba_Atributos_Empleado_Null()
                //{
                //        string[]? Atributos_Empleado =
                //        Acceso_Datos.Interfaz_Base_Datos.Get_Atributos_Empleado( "elPePeHunter_Xx" ) ;

                //        if ( Atributos_Empleado is null ) { Console.WriteLine("No tiene Empleado.") ; return ; }
                //        foreach ( string Atributo in Atributos_Empleado ) { Console.WriteLine( Atributo ) ; }
                //}

                //static void Prueba_Atributos_Proveedor_Null()
                //{
                //        string[]? Atributos_Proveedor =
                //        Acceso_Datos.Interfaz_Base_Datos.Get_Atributos_Proveedor( "S-Men" ) ;

                //        if ( Atributos_Proveedor is null ) { Console.WriteLine("No tiene Proveedor.") ; return ; }
                //        foreach ( string Atributo in Atributos_Proveedor ) { Console.WriteLine( Atributo ) ; }
                //}

                //static void Prueba_Atributos_Persona()
                //{ 
                //        string[]? Atributos_Persona =
                //        Acceso_Datos.Interfaz_Base_Datos.Get_Atributos_Persona( "loll" ) ;

                //        if ( Atributos_Persona is null ) { Console.WriteLine("No tiene Persona.") ; return ; }
                //        foreach ( string Atributo in Atributos_Persona ) { Console.WriteLine( Atributo ) ; }        
                //}

                //static void Prueba_Hash_SHA256()
                //{
                //        string Get_Hash_SHA256( string Contrasena )
                //        {
                //                using ( System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
                //                {
                //                        string Hash_Contrasena ; // El hash de la Contrasena en formato alphanumerico(string de toda la vida).
                //                        byte[] Bytes_Contrasena ; // Es la Contrasena en bytes
                //                        byte[] Bytes_Hash_Contrasena ; // Es el hash de la Contrasena en bytes

                //                        Bytes_Contrasena = System.Text.Encoding.UTF8.GetBytes( Contrasena );
                //                        Bytes_Hash_Contrasena = sha256.ComputeHash(Bytes_Contrasena);

                //                        System.Text.StringBuilder builder = new System.Text.StringBuilder();
                //                        for (int i = 0; i < Bytes_Hash_Contrasena.Length; i++) { builder.Append( Bytes_Hash_Contrasena[i].ToString("x2") ) ; } // Convierte a hexadecimal

                //                        Hash_Contrasena = builder.ToString() ; 
                //                        return  Hash_Contrasena ;
                //                }
                //                // Esta es una adaptacion de una solucion dada por ChatGPT.
                //        }

                //        string Contrasena_A_Hashear = "ASamalalama" ;

                //        Console.WriteLine( $"El Hash de `{ Contrasena_A_Hashear }` = { Get_Hash_SHA256( Contrasena_A_Hashear ) }" ) ;
                //}

                static void Prueba_Gestion_Productos()
        { 
                Application.Run( new Presentacion.Gestion_Productos.Gestion_Productos() ) ;        
        }

        //static void Prueba_Seleccion_Productos()
        //{

        //        void Crear_Archivo_Imagen( byte[] Imagen_En_Bytes )
        //        {
        //                Bitmap Bitmap_Imagen ;

        //                using ( MemoryStream Stream_Imagen = new MemoryStream( Imagen_En_Bytes ) ) { Bitmap_Imagen = new Bitmap( Stream_Imagen ) ; }
        //                Bitmap_Imagen.Save( "C:\\Users\\sgh4n\\AppData\\Local\\Temp\\MyImage.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg ) ;
        //        }

        //        Presentacion.Gestion_Productos.Gestion_Productos Formulario_Gestion_Productos = new Presentacion.Gestion_Productos.Gestion_Productos() ;
        //        // Formulario_Gestion_Productos.Producto_En_Edicion = new Logica.Sistema_de_cosas_a_subastar.Naturaleza_de_las_cosas_a_subastar.Producto() ;

        //        Formulario_Gestion_Productos.Button_Seleccionar_Click( ( new object() ), EventArgs.Empty ) ;


      //}

        static void Prueba_Argumento_MySqlCommand()
        { 
                Mostrar_Tabla( ( DataTable? )
                Interfaz_Base_Datos.Ejecutar( "select * from Usuarios where Inactivo = @valor ;", Tipos_Comando_Sql.Query, Unico_Parametro_Query: "@valor", Unico_Argumento_Query: true )
                ) ;
        }

        //static void Prueba_Get_Productos_Join_Elementos_Subasta()
        //{
        //        DataTable? Productos_Join_Elmentos_Subasta ;
        //        Productos_Join_Elmentos_Subasta = Interfaz_Base_Datos.Get_Productos_Join_Elementos_Subasta() ;

        //        Mostrar_Tabla( Productos_Join_Elmentos_Subasta );
        //}

                //static void Prueba_Ejecutar_Query_Sin_Resultados()
                //{
                //        DataTable? Tabla = ( DataTable? )
                //        Interfaz_Base_Datos.Ejecutar("select * from Maquinaria where ID = -666 ;", Interfaz_Base_Datos.Tipos_Comando_Sql.Query );

                //        if ( Tabla is null ) { Console.WriteLine("Is Null.") ; }
                //        if ( Convert.IsDBNull( Tabla ) ) { Console.WriteLine("Is DBNull.") ; }
                //        Continuar() ;
                //}

                static void Prueba_DateTime()
                { 
                        DateTime Momento_Inicio = DateTime.Now ;
                        DateTime Momento_Fin = DateTime.Now.AddDays(1) ;

                        Acceso_Datos.Interfaz_Base_Datos.
                        Ejecutar
                        ( 
                                "insert into Remates ( Momento_Inicio, Momento_Fin, Categoria ) values ( @Momento_Inicio, @Momento_Fin, 'Animales' ) ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@Momento_Inicio", "@Momento_Fin" } ) ,
                                Argumentos_Query: ( new object[] { Momento_Inicio, Momento_Fin } ) 
                        ) ;
                }

                static void Prueba_Gestion_Lotes() { Application.Run( new Presentacion.Gestion_Lotes.Gestion_Lotes() ) ; }
                static void Prueba_Form1() { Application.Run( new Pruebas2.Form1() ) ; }
                static void Prueba_Gestion_Remates() { Application.Run( new Presentacion.Gestion_Remates.Gestion_Remates() ) ; }
                static void Prueba_Hub() { Application.Run( new Presentacion.Hub_Menu_Principal.Hub_Menu_Principal( new Clase_Sujeto() ) ) ; }
                static void Prueba_Nuevo_Login() { Application.Run( new Presentacion.Login.Login() ) ; }
                static void Prueba_Gestion_Sujetos() { Application.Run( new Presentacion.Gestion_Sujetos.Gestion_Sujetos() ) ; }
                static void Prueba_Gestion_Tareas_Empleado() { Application.Run( new Presentacion.Gestion_Sujetos.Gestion_Tareas_Empleado(1) ) ; }
                static void Prueba_Registro() { Application.Run( new Presentacion.Registro.Registro() ) ; }
                static void Prueba_Publicacion_Productos() { Application.Run( new Presentacion.Gestion_Productos.Gestion_Productos( 5 ) ) ; }

                [STAThread]
                static void Main()
                {
                        // Lanzando_Formularios() ;
                        // Upcasting_Probando_El_Selector_Paneles() ;
                        // Agregar_Cosas_A_Un_Componente() ;
                        // Debug_Selector_Capas() ;
                        // Conexion_A_La_Base_De_Datos() ;
                        // Debug_Atributos_Capa() ;
                        // Prueba_DataGridView() ;
                        // Prueba_TextBoxNumerico() ;
                        // Prueba_CheckedList_Nivel_Confidencialidad() ;
                        // Prueba_Administrador_Tareas_Asignadas() ;
                        // Prueba_Insercion_Usuarios() ;
                        // Prueba_Insecion_Persona() ;
                        // Prueba_Insercion_Empleado() ;
                        // Prueba_Transaccion_Base_Datos() ;
                        // Prueba_Insercion_Proveedor_Con_Empresa() ;
                        // Prueba_Administracion_Sujetos() ;
                        // Prueba_Devolucion_Bit() ;
                        // Prueba_Get_Usuario() ;
                        // Prueba_Get_Persona() ;
                        // Prueba_Get_Empleado() ;
                        // Prueba_Get_Proveedor() ;
                        // Prueba_Get_Sujeto() ;
                        // Prueba_Construccion_De_Sujeto_A_Partir_De_Representacion() ;
                        // Prueba_Autenticacion_Sujeto_Basado_En_Nombre_Identificador() ;
                        // Prueba_Compound_Argument() ;
                        // Prueba_Nuevo_Ejecutar_Parametros_Null() ;
                        // Prueba_Nuevo_Ejecutar_Unico_Parametro() ;
                        // Prueba_Sujeto_Existe() ;
                        // Prueba_Usuario_Esta_Inactivo() ;
                        // Debug_Conseguir_Sujeto_Con_Capas_Null() ;
                        // Prueba_DBNull_Fallo_Coincidencia_En_Sentencia_Where() ;
                        // Prueba_Atributos_Empleado_Null() ;
                        // Prueba_Atributos_Proveedor_Null() ;
                        // Prueba_Atributos_Persona() ;
                        // Prueba_Hash_SHA256() ;
                        // Prueba_Ejecutar_Query_Sin_Resultados() ;
                        // Prueba_Gestion_Productos() ;
                        // Prueba_Seleccion_Productos() ;
                        // Prueba_Get_Productos_Join_Elementos_Subasta() ;
                        // Prueba_Argumento_MySqlCommand() ;
                        // Prueba_Gestion_Lotes() ;
                        // Prueba_Form1() ;
                        // Prueba_Gestion_Remates() ;
                        // Prueba_DateTime() ;
                        // Prueba_Hub() ;
                        // Prueba_Nuevo_Login() ;
                        // Prueba_Gestion_Sujetos() ;
                        // Prueba_Gestion_Tareas_Empleado() ;
                        // Prueba_Registro() ;
                           Prueba_Publicacion_Productos() ;
                }
        }
}