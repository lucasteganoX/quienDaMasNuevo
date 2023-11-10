using Acceso_Datos ;
using Logica.Sistema_de_Usuarios ;
namespace Presentacion.Login
{
        public sealed partial class Login : Form
        {
                /*      Por motivos de que no se cómo hacer para que el diseñador de ventanas escriba en otro lugar que no sea en el archivo "Tu_Clase.Designer.cs"
                 *      y para tener una mejor separación...
                 *      
                 *      La clase "Formulario_Login" es una clase parcial, la cuál está divida en los siguientes archivos:
                 *      * Formulario_Login.Designer.cs
                 *      * Formulario_Login.Mirador.cs
                 *      
                 *      El principio en el que me base para dividir la clase de esta manera es diferenciar "el formulario" de la clase en la que está:
                 *      Para mi el formulario es ese programita que es una interfaz a la que le metes información y cuando interactuas con él pasan cosas.
                 *      Mientras que la clase es la que contiene lo que hace al fomulario además de otras cosas que no están directamente relacionadas con
                 *      la manera en la que está constituido, lo que este hace, y lo que le ocurre.
                 *      A medida que mi visión del programa fue cambiando, hacer esta distinsión se volvió valioso.
                 *      
                 *      Ahora, de qué trata cada archivo?:
                 *      Cada parte de la clase encapsula un aspecto en la que esta se enfoca...
                 *      * Formulario_Login.Designer.cs: encapsula cómo el formulario es, y cómo funciona.
                 *      * Formulario_Login.Mirador.cs: encapsula los miembros(métodos, getters y variables) que reflejan información sobre el formulario.
                 */

                /*      Al principio esta separación era puramente pq no sabía cómo cambiar lo del diseñador, y quedaba medio feo...
                 *      Ahora me alegra de que la separación tiene un significado, que hace más fácil entender, modificar y manejar la clase entera,
                 *      y haciendo uso de esto que tiene C# que son las clases parciales, de las cuales no soy fan.
                 *      
                 *      ( v ‿‿ v )
                 */

                public Clase_Sujeto Sujeto_Operando ;

                void Formulario_Es_Valido()
                {
                        if ( Quedan_Campos_Vacios() ) { throw new QuedanCamposVaciosException() ; }
                        // if ( Instancia_Formulario_Login.Hay_Campos_Invalidos() ) { throw new Formulario_Login.HayCamposInvalidosException() ; }
                }

                void Modo_Ingreso()
                {
                        Clase_Sujeto Acceso()
                        {
                                Clase_Sujeto Sujeto_Tratando_Acceder ; // Es el Sujeto asociado a el Nombre_Identificador ingresado por el Usuario.
                                bool Sujeto_Existe ; // Si se encontro un Sujeto con tal Nombre Identificador
                                bool Sujeto_Tiene_Permitido_El_Acceso ; // El Usuario del Sujeto no esta Inactivo.
                                bool Sujeto_Fue_Autenticado ; // Si el Sujeto tiene ese Nombre Identificador y Contrasena.
                                Clase_Sujeto? Sujeto_Autenticado ; // Es el Sujeto con el que se continua el programa. Capaz de operar en el sistema.

                                Sujeto_Tratando_Acceder = Conseguir_Sujeto_Formulario() ;
                                Sujeto_Existe = Interfaz_Base_Datos.Sujeto_Existe( Sujeto_Tratando_Acceder.Usuario!.Nombre_Identificador ) ;
                                if ( ! Sujeto_Existe ) { throw new UsuarioOContrasenaIncorrectosException() ; }

                                Sujeto_Fue_Autenticado = Autenticación_Sujetos.Autenticar_Sujeto( Sujeto_Tratando_Acceder ) ;
                                if ( ! Sujeto_Fue_Autenticado ) { throw new UsuarioOContrasenaIncorrectosException() ; }
                                        
                                // Console.WriteLine( $"Nombre_Identificador = { Sujeto_Tratando_Acceder.Usuario.Nombre_Identificador}" ) ;
                                Sujeto_Tiene_Permitido_El_Acceso = ( ! ( Autenticación_Sujetos.Usuario_Esta_Inactivo( Sujeto_Tratando_Acceder.Usuario.Nombre_Identificador ) ) ) ;
                                if ( ! Sujeto_Tiene_Permitido_El_Acceso ) { throw new UsuarioInactivoException() ; }

                                Sujeto_Autenticado = Autenticación_Sujetos.Conseguir_Sujeto( Sujeto_Tratando_Acceder ) ;
                                if ( Sujeto_Autenticado is null ) { throw new Exception("Oh, oh, no se consiguio el Sujeto...") ; }

                                return Sujeto_Autenticado ;
                        }

                        if ( ( Modo_Invitado ) && ( Modo_Seleccionado.ToString() == "Registro" ) ) { throw new RegistroEnModoInvitadoException() ; }
                        if ( Modo_Invitado )
                        {
                                Clase_Sujeto Sujeto_Invitado = new Clase_Sujeto(Parametro_Construir_Sujeto_Invitdo: true);
                                Sujeto_Operando = Sujeto_Invitado;
                                return;
                        }
                        Formulario_Es_Valido() ; // Lanza las excepciones correspondientes si no es valido.
                        Sujeto_Operando = Acceso() ; // Lanza las excepciones corresponidentes si no se llega a un Sujeto valido para continuar el programa.
                }

                public void Continuar()
                { 
                        switch ( Modo_Seleccionado.ToString() )
                        {
                                case "Registro": this.Hide() ; ( new Registro.Registro() ).ShowDialog() ; this.Show() ; break ;
                                case "Ingreso":
                                        try { Modo_Ingreso(); Close() ; }
                                        catch ( RegistroEnModoInvitadoException Excepcion ) { Cambiar_Modo_Formulario(Excepcion) ; }
                                        catch ( QuedanCamposVaciosException Excepcion ) { Mostrar_MessageBox_Quedan_Campos_Vacios(Excepcion) ; }
                                        catch ( UsuarioOContrasenaIncorrectosException Excepcion ) { Mostrar_MessageBox_Usuario_O_Contrasena_Incorrectos(Excepcion) ; }
                                        catch ( UsuarioInactivoException Excepcion ) { Mostrar_MessageBox_Usuario_Inactivo(Excepcion) ; }
                                        //..... resto de excepciones si hay
                                break;
                        }
                }
        }
}

