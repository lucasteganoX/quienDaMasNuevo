using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data ;

using Acceso_Datos ;
using System.Security.Policy;

namespace Logica.Gestion_de_Lotes
{
        public class Procesamiento_Lotes
        {
                # region >>---- "Marshals" (intermediarios)                
                // Operaciones de Lotes
                public static void Marshal_Delete_Lote( int ID_Lote ) { Interfaz_Base_Datos.Delete_Lote( ID_Lote ) ; }
                public static bool Marshal_Lote_Existe( int ID_Lote ) { return Interfaz_Base_Datos.Lote_Existe( ID_Lote ) ; }
                public static string Marshal_Get_Categoria_Lote( int ID_Lote ) { return Interfaz_Base_Datos.Get_Categoria_Lote( ID_Lote ) ; }
                
                // Elementos_Subasta
                public static Dictionary< string, object? >? Marshal_Get_Elemento_Subasta( int ID_Lote ) { return Interfaz_Base_Datos.Get_Elemento_Subasta( ID_Lote ) ; }

                // Resumen Productos
                public static DataTable? Marshal_Get_Resumen_Productos_Lote( int ID_Lote ) { return Interfaz_Base_Datos.Get_Resumen_Productos_Lote( ID_Lote ) ; }

                // Productos Libres
                public static DataTable? Marshal_Get_Productos_Libres( string Categoria_Lote ) { return Interfaz_Base_Datos.Get_Productos_Libres( Categoria_Lote ) ; }

                // Productos No-Libres
                public static DataTable? Marshal_Get_Productos_NoLibres() { return Interfaz_Base_Datos.Get_Productos_NoLibres() ; }
                public static DataTable? Marshal_Get_Productos_NoLibres( string Filtro_Busqueda, object Valor ) { return Interfaz_Base_Datos.Get_Productos_NoLibres( Filtro_Busqueda, Valor ) ; }
                # endregion

                // Administracion Lotes ( controles de Lotes )
                public static int? Crear_Lote( object? Precio_Base, object? Valor, string Categoria, bool Habilitado, int[] ID_Productos_Lote, bool Devolver_ID_Lote )
                { 
                        Interfaz_Base_Datos.Iniciar_Transaccion_Manual() ;
                        int ID_Lote = ( ( int ) Interfaz_Base_Datos.Insert_Elemento_Subasta( Precio_Base, Valor, Habilitado, true, true )! ) ;
                        Interfaz_Base_Datos.Insert_Lote( ID_Lote, Categoria, true ) ;
                        foreach ( int ID_Producto in ID_Productos_Lote ) { Interfaz_Base_Datos.Insert_Producto_Lote( ID_Lote, ID_Producto, true ) ; }
                        Interfaz_Base_Datos.Commit_Transaccion() ;

                        return ( ( Devolver_ID_Lote ) ? ID_Lote : null ) ;
                }
                public static void Modificar_Lote( int ID_Lote, int[] ID_Productos_Lote, int Valor, int Precio_Base, string Categoria, bool Habilitacion )
                {
                        // if ( ! Marshal_Lote_Existe( ID_Lote ) ) { throw new ArgumentException($"No se encontro un Lote para la ID `{ ID_Lote }`.") ; }

                        Interfaz_Base_Datos.Iniciar_Transaccion_Manual() ;
                        Interfaz_Base_Datos.Delete_Productos_Lote( ID_Lote, true ) ;
                        foreach ( int ID_Producto in ID_Productos_Lote ) { Interfaz_Base_Datos.Insert_Producto_Lote( ID_Lote, ID_Producto, true ) ; }
                        Interfaz_Base_Datos.Update_Elemento_Subasta( Valor, Precio_Base, Habilitacion, ID_Lote, true ) ;
                        Interfaz_Base_Datos.Update_Lote( ID_Lote, Categoria, true ) ;
                        Interfaz_Base_Datos.Commit_Transaccion() ;
                }
        }
}
