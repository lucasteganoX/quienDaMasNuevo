using Acceso_Datos;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Acceso_Datos.Interfaz_Base_Datos ;
using System.Text.RegularExpressions ;
namespace Logica.Gestion_Remates
{
        public class Procesamiento_Remates
        {
                // "Marshals"
                // public static DataTable? Marshal_Get_Remates() { return Interfaz_Base_Datos.Get_Remates() ; }
                public static DataTable? Marshal_Get_Resumen_Productos_Remate( bool Habilitado, string Tipo_Producto ) { return Interfaz_Base_Datos.Get_Resumen_Productos( Habilitado: true, Tipo_Producto  ) ; }
                public static Dictionary< string, object >? Marshal_Get_Remate( int ID_Remate ) { return Interfaz_Base_Datos.Get_Remate( ID_Remate ) ; }
                public static bool Marshal_Remate_Existe( int ID_Remate ) { return Interfaz_Base_Datos.Remate_Existe( ID_Remate ) ; }
                public static DataTable? Marshal_Get_Integrantes_Remate( object ID_Remate ) { return Interfaz_Base_Datos.Get_Integrantes_Remate( ID_Remate ) ; }
                public static DataTable? Marshal_Get_Elementos_Subastables( string Categoria_Remate ) { return Interfaz_Base_Datos.Get_Elementos_Subastables( Categoria_Remate ) ; }
                public static string[] Get_Columnas_Resumen_Elementos_Subasta_NoLibres() { return Interfaz_Base_Datos.Get_Columnas_Tabla_O_View("Resumen_Elementos_Subasta_NoLibres") ; }
                public static DataTable? Marshal_Get_Resumen_Elementos_Subasta_NoLibres( string Filtro_Busqueda, string Valor_Filtro ) { return Interfaz_Base_Datos.Get_Resumen_Elementos_Subasta_NoLibres( Filtro_Busqueda, Valor_Filtro ) ; }
                public static DataTable? Marshal_Get_Resumen_Elementos_Subasta_NoLibres() { return Interfaz_Base_Datos.Get_Resumen_Elementos_Subasta_NoLibres() ; }
                public static int Get_ID_Remate_Dueno_De_Elemento( int ID_Elemento_Seleccionado ) { return Interfaz_Base_Datos.Get_ID_Remate_Dueno_De_Elemento( ID_Elemento_Seleccionado ) ; }

                public static int? Crear_Remate( DateTime Momento_Inicio, DateTime Momento_Fin, string Categoria, string Metodo_Pago, object[] ID_Elementos, bool Devolver_ID_Remate )
                {
                        Iniciar_Transaccion_Manual() ;
                        int ID_Remate = ( ( int ) Insert_Remate( Momento_Inicio, Momento_Fin, Categoria, Metodo_Pago, Devolver_ID_Remate: true, true )! ) ; // No deberia devolver la ID del Remate?
                        Insert_Elementos_Subasta_Remate( ID_Remate, ID_Elementos, true ) ;
                        Commit_Transaccion() ;

                        if ( Devolver_ID_Remate ) { return ID_Remate ; }
                        return null ;
                }

                public static bool Remate_Ya_Ocurrio( int ID_Remate )
                {
                        Dictionary< string, object >? Atributos_Remate =
                        Get_Remate( ID_Remate ) ;

                        if ( Atributos_Remate is null ) { throw new ArgumentException($"No se encontro un Remate para la ID { ID_Remate }") ; }
                        bool Remate_Ya_Ocurrio = ( ( ( DateTime ) Atributos_Remate["Momento_Fin"] ) < DateTime.Now ) ;

                        return Remate_Ya_Ocurrio ;
                }
                public static int? Gestionar_Remates
                (
                        Operacion_Gestion Operacion_Remate,
                        object ID_Remate,
                        object[] ID_Elementos_Remate,
                        DateTime Momento_Inicio,
                        DateTime Momento_Fin,
                        string Categoria,
                        string Metodo_Pago,
                        bool Devolver_ID_Remate_Creado = false
                )
                {
                        int int_ID = Convert.ToInt32( ID_Remate ) ;
                        switch( Operacion_Remate )
                        {
                                case Operacion_Gestion.Crear or Operacion_Gestion.Alta: goto Crear_Remate ; break ;
                                case Operacion_Gestion.Modificar or Operacion_Gestion.Modificar: goto Modificar_Remate ; break ;
                                case Operacion_Gestion.Eliminar or Operacion_Gestion.Baja: goto Eliminar_Remate ; break ;
                        }

                Crear_Remate:
                        Iniciar_Transaccion_Manual() ;
                        int? ID_Remate_Creado = ( int? ) Insert_Remate( Momento_Inicio, Momento_Fin, Categoria, Metodo_Pago, true ) ;
                        Insert_Elementos_Subasta_Remate( ID_Remate, ID_Elementos_Remate, true ) ;
                        Commit_Transaccion() ;

                        if ( Devolver_ID_Remate_Creado ) { return ID_Remate_Creado ; }
                return null ;
                Modificar_Remate:
                        Iniciar_Transaccion_Manual() ;
                        Update_Remate( ID_Remate, Momento_Inicio, Momento_Fin, Categoria, Metodo_Pago, true ) ;
                        Delete_Elementos_Subasta_Remate( ID_Remate, true ) ;
                        Insert_Elementos_Subasta_Remate( ID_Remate, ID_Elementos_Remate , true ) ;
                        Commit_Transaccion() ;
                return null ;
                Eliminar_Remate:
                        Iniciar_Transaccion_Manual() ;
                        Delete_Remate( int_ID, true ) ;
                        Commit_Transaccion() ;
                return null ;
                }

                /// <summary>
                /// Consigue los tipos de Metodos de Pago soportados para los Remates.
                /// </summary>
                /// <returns>
                /// Un array de strings donde cada posicion es el valor del Enum de los Metodos de Pago.
                /// Los caracteres `_` en el nombre son remplzados por ` `(espacio en blanco). 
                /// </returns>
                public static List<string> Get_Valore_Enum_Metodo_Pago()
                {
                        // PD: Quizas sea mas adecuado que este metodo este en la capa de Acceso a Datos directamente.
                        // POV: Le llega un enum null a la funcion: https://media.tenor.com/e27m0IEM8GMAAAAd/husky-explosion.gif

                        List<string> Valores_Enum = new List<string>() ;
                        const string Nombre_Columna_Metodos_Pago = "Metodo_Pago" ;
                        
                        string Definicion_Columna_Enum = (
                        Interfaz_Base_Datos.Ejecutar
                        (
                                "select COLUMN_TYPE \n" +
                                "from \n" +
                                "information_schema.COLUMNS \n" +
                                "where TABLE_NAME = 'Remates' \n" +
                               $"and COLUMN_NAME = '{ Nombre_Columna_Metodos_Pago }' ;",
                                Tipos_Comando_Sql.Query_Escalar
                        )!
                        ).ToString()! ;

                        // Extrae los valores del Enum
                        foreach ( Match Valor_Enum in Regex.Matches( Definicion_Columna_Enum, "'(.*?)'")) { Valores_Enum.Add( Valor_Enum.Groups[1].Value.Replace('_', ' ') ) ; }
                        return Valores_Enum ;
                }
        }
}
