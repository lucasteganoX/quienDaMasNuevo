//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Acceso_Datos ;
//using Logica.Sistema_de_Usuarios ;
//namespace Logica.Login
//{
//        public static void Login()
//        {
//                Formulario_Login Instancia_Formulario_Login;

//                void Formulario_Es_Valido()
//                {
//                        if ( Instancia_Formulario_Login.Quedan_Campos_Vacios() ) { throw new Formulario_Login.QuedanCamposVaciosException() ; }
//                        // if ( Instancia_Formulario_Login.Hay_Campos_Invalidos() ) { throw new Formulario_Login.HayCamposInvalidosException() ; }
//                }

//                void Modo_Ingreso()
//                {
//                        Clase_Sujeto Acceso()
//                        {
//                                Clase_Sujeto Sujeto_Tratando_Acceder ; // Es el Sujeto asociado a el Nombre_Identificador ingresado por el Usuario.
//                                bool Sujeto_Existe ; // Si se encontro un Sujeto con tal Nombre Identificador
//                                bool Sujeto_Tiene_Permitido_El_Acceso ; // El Usuario del Sujeto no esta Inactivo.
//                                bool Sujeto_Fue_Autenticado ; // Si el Sujeto tiene ese Nombre Identificador y Contrasena.
//                                Clase_Sujeto? Sujeto_Autenticado ; // Es el Sujeto con el que se continua el programa. Capaz de operar en el sistema.

//                                Sujeto_Tratando_Acceder = Instancia_Formulario_Login.Conseguir_Sujeto_Formulario() ;
//                                Sujeto_Existe = Interfaz_Base_Datos.Sujeto_Existe( Sujeto_Tratando_Acceder.Usuario!.Nombre_Identificador ) ;
//                                if ( ! Sujeto_Existe ) { throw new Formulario_Login.UsuarioOContrasenaIncorrectosException() ; }

//                                Sujeto_Fue_Autenticado = Autenticación_Sujetos.Autenticar_Sujeto( Sujeto_Tratando_Acceder ) ;
//                                if ( ! Sujeto_Fue_Autenticado ) { throw new Formulario_Login.UsuarioOContrasenaIncorrectosException() ; }
                                        
//                                // Console.WriteLine( $"Nombre_Identificador = { Sujeto_Tratando_Acceder.Usuario.Nombre_Identificador}" ) ;
//                                Sujeto_Tiene_Permitido_El_Acceso = ( ! ( Autenticación_Sujetos.Usuario_Esta_Inactivo( Sujeto_Tratando_Acceder.Usuario.Nombre_Identificador ) ) ) ;
//                                if ( ! Sujeto_Tiene_Permitido_El_Acceso ) { throw new Formulario_Login.UsuarioInactivoException() ; }

//                                Sujeto_Autenticado = Autenticación_Sujetos.Conseguir_Sujeto( Sujeto_Tratando_Acceder ) ;
//                                if ( Sujeto_Autenticado is null ) { throw new Exception("Oh, oh, no se consiguio el Sujeto...") ; }

//                                return Sujeto_Autenticado ;
//                        }

//                        if ( ( Instancia_Formulario_Login.Modo_Invitado ) && ( Instancia_Formulario_Login.Modo_Seleccionado.ToString() == "Registro" ) ) { throw new Formulario_Login.RegistroEnModoInvitadoException() ; }
//                        if ( Instancia_Formulario_Login.Modo_Invitado )
//                        {
//                                Clase_Sujeto Sujeto_Invitado = new Clase_Sujeto(Parametro_Construir_Sujeto_Invitdo: true);
//                                Sujeto_Operando = Sujeto_Invitado;
//                                return;
//                        }
//                        Formulario_Es_Valido() ; // Lanza las excepciones correspondientes si no es valido.
//                        Sujeto_Operando = Acceso() ; // Lanza las excepciones corresponidentes si no se llega a un Sujeto valido para continuar el programa.                   
//                }

//                bool Login_En_Curso = true;
//                Instancia_Formulario_Login = new Formulario_Login();

//                Thread Hilo_Formulario_Login = new Thread
//                (
//                        () =>
//                        {
//                                Application.Run(Instancia_Formulario_Login);
//                        }
//                );

//                Hilo_Formulario_Login.Start();
//#if DEBUG
//                Console.WriteLine("Se inicio el ciclo de Login.");
//#endif

//                while (Login_En_Curso)
//                {
//                        Thread.Sleep(500);
//                        if ( Instancia_Formulario_Login.IsDisposed ) { break ;}
//                        if (!Instancia_Formulario_Login.Intento_De_Continuar_En_Espera) { continue; } // Se espera hasta que el usuario haya tocado el botón "Continuar".
//#if DEBUG
//                        Debug.WriteLine("Se inicio un intento de Login.");
//#endif
//                        Instancia_Formulario_Login.Intento_De_Continuar_En_Espera = false;
//                        switch (Instancia_Formulario_Login.Modo_Seleccionado.ToString())
//                        {
//                                // case "Registro":

//                                //break ;
//                                case "Ingreso":
//                                        try { Modo_Ingreso(); Login_En_Curso = false; }
//                                        catch (Formulario_Login.RegistroEnModoInvitadoException Excepcion) { Instancia_Formulario_Login.Cambiar_Modo_Formulario(Excepcion); }
//                                        catch (Formulario_Login.QuedanCamposVaciosException Excepcion) { Instancia_Formulario_Login.Mostrar_MessageBox_Quedan_Campos_Vacios(Excepcion); }
//                                        catch (Formulario_Login.UsuarioOContrasenaIncorrectosException Excepcion) { Instancia_Formulario_Login.Mostrar_MessageBox_Usuario_O_Contrasena_Incorrectos(Excepcion); }
//                                        catch ( Formulario_Login.UsuarioInactivoException Excepcion ) { Instancia_Formulario_Login.Mostrar_MessageBox_Usuario_Inactivo( Excepcion ) ; }
//                                        //..... resto de excepciones si hay
//                                        usuario_Solicito_Continuar = false;
//                                        break;
//                        }
//                }
//#if DEBUG
//                Console.WriteLine("Se acabó el ciclo de Login.");
//                Console.WriteLine("Se esperará que se acabe con el hilo anterior.");
//#endif
//                Instancia_Formulario_Login.Close() ;
//                Hilo_Formulario_Login.Join() ;
//        }
//}