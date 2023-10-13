using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Acceso_Datos ;
namespace Logica.Gestion_Productos
{
        public static class Gestion_Productos
        {
                public static DataTable? Marshal_Get_Productos_Join_Elementos_Subasta( string Filtro_Consulta = "", string Argumento_Consulta = "" ) { return Interfaz_Base_Datos.Get_Productos_Join_Elementos_Subasta( Filtro_Consulta, Argumento_Consulta ) ; }
                public static void Marshal_Insert_Producto_Completo
                (
                    Dictionary< string, object > Campos_Elemento_Subasta, 
                    Dictionary< string, object > Campos_Producto,
                    Dictionary< string, object >? Campos_Animal = null,
                    Dictionary< string, object >? Campos_Maquinaria = null
                )
                { // Interfaz_Base_Datos.Insert_Producto_Completo( Campos_Elemento_Subasta, Campos_Producto, Campos_Animal, Campos_Maquinaria ) ; }
                }
        }
}
