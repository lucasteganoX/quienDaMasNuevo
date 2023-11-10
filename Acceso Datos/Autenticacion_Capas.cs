using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data ;
namespace Acceso_Datos
{
        public static class Autenticacion_Capas
        {
                public static bool Usuario_Coincidente_Existe( string Nombre_Identificador_Usuario, string Contrasena )
                { // Comprueba que en el sistema existe un Usuario con el mismo Nombre_Identificador y Contrasena que el ingresado.
                        DataTable? Coincidencia_Usuario ; // Un Usuario en el sistema que coincide con el Usuario a identificar.

                        Coincidencia_Usuario = ( DataTable? )
                        Acceso_Datos.Interfaz_Base_Datos.Ejecutar
                                (
                                        "select * from Usuarios where Nombre_Identificador = @Nombre_Identificador and Contrasena = @Contrasena ;",
                                        Acceso_Datos.Tipos_Comando_Sql.Query,
                                        Parametros_Query: ( new string[] { "@Nombre_Identificador", "@Contrasena" } ),
                                        Argumentos_Query: ( new string[] { Nombre_Identificador_Usuario, Contrasena } )
                                ) ;

                        if ( Coincidencia_Usuario is null || Coincidencia_Usuario.Rows.Count == 0 ) { return false ; }
                        if ( Coincidencia_Usuario.Rows.Count > 1 ) { throw new Exception($"Se encontro mas de un Usuario con el Nombre_Identificador `{ Nombre_Identificador_Usuario }` y Contrasena `{ Contrasena }`. Esto es un error grave.") ; }
                        return true ;
                }       
        }
}
