using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using Acceso_Datos ;
namespace Logica.Gestion_Productos
{
        public static class Procesamiento_Productos
        {
                public static DataTable? Marshal_Get_Resumen_Productos( string Filtro_Consulta = "", string Argumento_Consulta = "" ) { return Interfaz_Base_Datos.Get_Resumen_Productos( Filtro_Consulta, Argumento_Consulta ) ; }
                /// <summary>
                /// Este metodo pasa su input a el metodo <see cref="Interfaz_Base_Datos.Get_Fotos_Producto(int)"/> de la capa de persistencia.
                /// </summary>
                /// <param name="ID_Producto"></param>
                /// <returns></returns>
                public static byte[][]? Marshal_Get_Fotos_Producto( int ID_Producto ) { return Interfaz_Base_Datos.Get_Fotos_Producto( ID_Producto ) ; }
                public static DataTable? Marshal_Get_Resumen_Animal( int ID_Animal ) { return Interfaz_Base_Datos.Get_Resumen_Animal( ID_Animal ) ; }
                public static DataTable? Marshal_Get_Maquinaria( int ID_Maquinaria ) { return Interfaz_Base_Datos.Get_Maquinaria( ID_Maquinaria ) ; }
                /// <summary>
                /// Pasa los argumentos al metodo <see cref="Interfaz_Base_Datos.Eliminar_Animal(int)"/>.
                /// </summary>
                /// <param name="ID_Animal"></param>
                public static void Marshal_Eliminar_Animal( int ID_Animal ) { Interfaz_Base_Datos.Eliminar_Animal( ID_Animal ) ; }
                /// <summary>
                /// Pasa los argumentos al metodo <see cref="Interfaz_Base_Datos.Eliminar_Maquinaria(int)"/>.
                /// </summary>
                /// <param name="ID_Maquinaria"></param>
                public static void Marshal_Eliminar_Maquinaria( int ID_Maquinaria ) { Interfaz_Base_Datos.Eliminar_Maquinaria( ID_Maquinaria ) ; }
                /// <summary>
                /// Consigue los resumenes de los Productos disponibles que pertenecen a un determinado Proveedor
                /// </summary>
                /// <param name="ID_Proveedor">La ID del Proveedor al que pertenecen los Productos.</param>
                /// <param name="Campo_Filtro_Producto">La columna de la tabla en base a la cual se filtraran los resultados.</param>
                /// <param name="Argumento_Filtrado_Producto">El valor con el que se utilizara un `like` en la base de datos para filtrar la busqueda.</param>
                /// <remarks>
                /// Si el filtro, o el argumento es un string vacio, no se filtrara la busqueda.
                /// </remarks>
                /// <returns>
                /// Una DataTable con los resumenes de los Productos que pertenecen a un determinado Proveedor, los cuales estan libres. O una referencia null si el Proveedor no tiene Productos validos o ninguno que coincida con la busqueda.
                /// </returns>
                public static DataTable? Marshal_Get_Resumen_Productos_Proveedor( object ID_Proveedor, string Campo_Filtro_Producto = "", string Argumento_Filtrado_Producto = "" ) { return Interfaz_Base_Datos.Get_Productos_Proveedor( ID_Proveedor, Campo_Filtro_Producto, Argumento_Filtrado_Producto) ; }

                public static DataTable Get_Columnas_Grilla( bool Modo_Proveedor )
                {
                        DataTable Tabla_Vacia = new DataTable() ;
                        string[] Columnas_Tabla ;
                        if ( Modo_Proveedor ) { Columnas_Tabla = Interfaz_Base_Datos.Get_Columnas_Tabla_O_View("Productos_Libres") ; }
                        else { Columnas_Tabla = Interfaz_Base_Datos.Get_Columnas_Tabla_O_View("Resumen_Productos") ; }

                        foreach ( string Columna in Columnas_Tabla ) { Tabla_Vacia.Columns.Add(Columna) ; }
                        return Tabla_Vacia ;
                }
                public static void Marshal_Gestion_Producto_Completo
                (
                    Interfaz_Base_Datos.Operacion_Gestion Operacion_Seleccionada,
                    Dictionary< string, object? > Campos_Elemento_Subasta, 
                    Dictionary< string, object? > Campos_Producto,
                    Dictionary< string, object? >? Campos_Animal = null,
                    Dictionary< string, object >? Campos_Maquinaria = null
                ) { Interfaz_Base_Datos.Gestion_Producto_Completo( Operacion_Seleccionada, Campos_Elemento_Subasta, Campos_Producto, Campos_Animal, Campos_Maquinaria ) ; }

                
        }
}
