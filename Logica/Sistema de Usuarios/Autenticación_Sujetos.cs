using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Acceso_Datos ;
namespace Logica.Sistema_de_Usuarios
{
        public static class Autenticación_Sujetos
        {
           /*   Enum Modo_Operacion
                {
                        Muestra = 1 ; // Hace que el programa compare el Usuario_Inidentificado con una lista de Usuarios en memoria.
                        Operacion = 0 ; // Hace que el programa compare el Usuario_Inidentificado con los Usuarios registrados en la base de datos.

                }
           */

                public class AccesoDenegadoException : ApplicationException
                { 
                        public AccesoDenegadoException() : base( message: "El Acceso fue denegado." ) { }  
                }
                
                /// <summary>
                /// Consigue el Sujeto que esta indirectamente asociado a un Nombre_Identificador.
                /// </summary>
                /// <param name="Nombre_Identificador_Usuario">El Nombre_Identificador que estaria asociado a un Sujeto.</param>
                /// <returns>Devuelve un `Clase_Sujeto` si hubo una coincidencia con el Nombre_Identificado.</returns>
                /// <exception cref="ArgumentException">Ocurre cuando no se encuentra un Sujeto asociado al Nombre_Identificador indicado. Asegurate de checkar si existe utilizando el metodo `Autenticar_Sujeto`</exception>
                public static Clase_Sujeto? Conseguir_Sujeto( Clase_Sujeto Sujeto_Especificado )
                {
                        if ( ! Sujeto_Especificado.Es_Un_Sujeto_Inidentificado() ) { throw new ArgumentOutOfRangeException("Se esperaba un Sujeto Inidentificado.") ; }
                        // `Clase_Sujeto.Es_Un_Sujeto_Inidentificado` indirectamente corrobora si el Usuario es null.
                        if ( Sujeto_Especificado is null ) { throw new ArgumentNullException("El Sujeto a conseguir es null.") ; }


                        Clase_Sujeto Sujeto_Conseguido ; // Es el Sujeto que se consigio del sistema, identificado; con todas sus capas y capaz de operar en el sistema. El cual sera devuelto por la funcion.
                        Acceso_Datos.Interfaz_Base_Datos.Representacion_Sujeto? Representacion_Sujeto_A_Devolver ; // Contiene los atributos de todas las capas del Sujeto que pretende ingresar al sistema.
                                

                        Representacion_Sujeto_A_Devolver = Acceso_Datos.Interfaz_Base_Datos.Get_Representacion_Sujeto( Sujeto_Especificado.Usuario!.Nombre_Identificador ) ;
                        if ( Representacion_Sujeto_A_Devolver is null ) { throw new Exception("No se encontro un Sujeto que corresponda al Usuario.") ; }
                        
                        Sujeto_Conseguido = new Clase_Sujeto( Representacion_Sujeto_A_Devolver ) ;
                        return Sujeto_Conseguido ;
                }

                public static bool Autenticar_Sujeto( Clase_Sujeto Sujeto_A_Autenticar )
                {
                        if ( Sujeto_A_Autenticar.Es_Un_Sujeto_Invitado() ) { throw new Exception("El Sujeto a autenticar es un Sujeto Invitado.") ; }
                        if ( ! Sujeto_A_Autenticar.Es_Un_Sujeto_Inidentificado() ) { throw new Exception("El Sujeto a autenticar NO es un Sujeto Inidentificado. No requiere identificacion.") ; }
                        if ( Sujeto_A_Autenticar.Usuario is null ) { throw new ArgumentException("El Sujeto ingresado no tiene un Usuario.") ; }

                        if ( ! Autenticacion_Capas.Usuario_Coincidente_Existe( Sujeto_A_Autenticar.Usuario.Nombre_Identificador, Sujeto_A_Autenticar.Usuario.Contrasena ) ) { return false ; }
                        return true ;
                }

                public static bool Usuario_Esta_Inactivo( string Nombre_Identificador_Usuario )
                { 
                        bool Usuario_Es_Inactivo ;
                        object? Resultado_Busqueda ;

                        Console.WriteLine( $"Usuarios_Esta_Inactivo>> Nombre_Identificador_Usuario = { Nombre_Identificador_Usuario }" ) ;
                        Resultado_Busqueda =
                        Acceso_Datos.Interfaz_Base_Datos.
                                Ejecutar
                                (
                                   "select Inactivo from Usuarios where Nombre_Identificador = @Nombre_Identificador ;",
                                   Acceso_Datos.Interfaz_Base_Datos.Tipos_Comando_Sql.Query_Escalar, // Al parecer el asunto esta con la query escalar...
                                   Unico_Parametro_Query: "@Nombre_Identificador",
                                   Unico_Argumento_Query: Nombre_Identificador_Usuario
                                ) ;
                        
                        if ( Resultado_Busqueda is null ) { throw new Exception($"No se encontro el campo inactivo para el Usuario `{ Nombre_Identificador_Usuario }`") ; }
                        Console.WriteLine( $"Type of ResultadoBusqueda: { Resultado_Busqueda.GetType() }" ) ;
                        if ( Resultado_Busqueda is not UInt64 ) { throw new Exception("El campo `Inactivo` no es un Int64.") ; } // No me preguntes porque, pero la query escalar para un campo del tipo bit, devuelve un UInt64.
                        
                        Usuario_Es_Inactivo = ( Convert.ToBoolean( Resultado_Busqueda ) ) ;
                        
                        if ( Usuario_Es_Inactivo ) { return true ; }
                        return false ;
                }

                #region >>---- Metodos Archivados
                /*
                public static int? Autenticar_Sujeto( Clase_Sujeto Sujeto_Inidentificado )
                {
                        // Por ahora la autenticación es meramente de muestra. Solo compara el Usuario_Inidentificado con una lista de usuarios de prueba.
                        // En el futuro todo esto se volverá el modo de prueba

                        // Para fines conceptuales, sería mejor dividir este proceso en Autenticación y Acceso.
                        // Autenticación sería ver si el Usuario es quién dice ser. Acceso es si se le permite utilizar el programa.
                        // Ya que es imposible darle nombres descriptivos a elementos que cumplen funciones diferentes en diferentes procesos,
                        // los cuales están mezclados en uno solo.
                        // Esto solucionaría todo el asunto con los nombres, y creo que haría el proceso de Acceso más sencillo de entender.
                        // Pero por ahora esto es suficientemente sencillo como para que dejarlo así sea la opción razonable.
                        // Mientras que cambiarlo sea un capricho mio para el que no tengo tiempo desgraciadamente.

                        int? Fallo_Autenticacion = null ;
                        int Indice_Sujeto_Identificado ;

                        Clase_Sujeto.Clase_Usuario Usuario_Inidentificado ;
                        Clase_Sujeto.Clase_Usuario Coincidencia_De_Usuario = null ; // Este nombre es malo porque sintetizo en él tanto que hay una coincidencia con un Usuario, como cuál es esa coincidencia. La información que representa no es suficientemente átomica o fundamental.

                        if ( ! ( Sujeto_Inidentificado.Es_Un_Sujeto_Inidentificado() ) ) { throw new ArgumentException("El Sujeto ingresado no es un Sujeto Inidentificado.") ; }
                        Usuario_Inidentificado = Sujeto_Inidentificado.Usuario! ;

                        int Indice_Usuario_Registrado = 0 ;
                        //foreach ( Clase_Sujeto.Clase_Usuario Usuario_Registrado in Libreta_Usuarios )
                        //{
                        //        if ( Usuario_Registrado!.Nombre_Identificador == Usuario_Inidentificado.Nombre_Identificador ) { Coincidencia_De_Usuario = Usuario_Registrado ; break ;  }
                        //        Indice_Usuario_Registrado++ ;
                        //}
                        
                        if ( Coincidencia_De_Usuario is null ) { return Fallo_Autenticacion ; }
                        if ( ! ( Coincidencia_De_Usuario.Contrasena == Usuario_Inidentificado.Contrasena ) ) { return Fallo_Autenticacion ; }
                        // A este punto definitivamente el usuario es quién dice ser.

                        Indice_Sujeto_Identificado = Indice_Usuario_Registrado ;
                        return Indice_Sujeto_Identificado ;
                }
                */

                /*
                public static Clase_Sujeto? Conseguir_Sujeto(int? Parametro_Indice_Sujeto_A_Conseguir)
                {
                        if (Parametro_Indice_Sujeto_A_Conseguir is null) { throw new ArgumentException("El Sujeto a conseguir es null."); }

                        return Libreta_Sujetos[(int)Parametro_Indice_Sujeto_A_Conseguir];
                }
                */
                # endregion

        }
}
