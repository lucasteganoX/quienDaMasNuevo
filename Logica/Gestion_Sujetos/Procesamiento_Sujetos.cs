using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data ;
using Acceso_Datos ;
using static Acceso_Datos.Interfaz_Base_Datos ;
using System.Web;

namespace Logica.Procesamiento_Sujetos
{
        public enum Caracterizacion_Formulario
        {
                Personas,
                Usuarios,
                Empleados,
                Proveedores
        }

        public class Procesamiento_Sujetos
        {
                // Getters
                public static string[] Get_Columnas_Capa( Caracterizacion_Formulario Nueva_Caracterizacion )
                {
                        string[] Get_Columnas_Proveedores_JOIN_Direccion_Empresa_Proveedores()
                        {
                                List<string> Columnas_Join ;
                                string[] Columnas_Proveedores = Interfaz_Base_Datos.Get_Columnas_Tabla_O_View( "Proveedores" ) ;
                                string[] Columnas_Direccion_Empresa = Interfaz_Base_Datos.Get_Columnas_Tabla_O_View( "Direccion_Empresa_Proveedor" ) ;

                                Columnas_Join = Columnas_Proveedores.Concat( Columnas_Direccion_Empresa ).ToList<string>() ;
                                Columnas_Join.Remove( "ID" ) ;
                                return Columnas_Join.ToArray<string>() ;
                        }

                        string[] Columnas_Capa ;
                        switch ( Nueva_Caracterizacion )
                        { 
                                case Caracterizacion_Formulario.Personas: Columnas_Capa = Interfaz_Base_Datos.Get_Columnas_Tabla_O_View( "Personas" ) ; break ;
                                case Caracterizacion_Formulario.Usuarios: Columnas_Capa = Interfaz_Base_Datos.Get_Columnas_Tabla_O_View( "Usuarios" ) ; break ;
                                case Caracterizacion_Formulario.Empleados: Columnas_Capa = Interfaz_Base_Datos.Get_Columnas_Tabla_O_View( "Empleados" ) ; break ;
                                case Caracterizacion_Formulario.Proveedores: Columnas_Capa = Get_Columnas_Proveedores_JOIN_Direccion_Empresa_Proveedores() ; break ;
                                default: throw new Exception("Fallo de cohesion.") ; // Estoy pensando en hacer esto un tipo de excepcion, ya me va artando escribir lo mismo una y otra vez.
                        }

                        if ( Nueva_Caracterizacion.ToString() == "Usuarios" )
                        { // Quita la columna de la contrasena 
                                List<string> Lista_Columnas = Columnas_Capa.ToList<string>() ;
                                Lista_Columnas.Remove("Contrasena") ;
                                Columnas_Capa = Lista_Columnas.ToArray<string>() ;
                        }
                        return Columnas_Capa ;
                }
                public static int Get_ID_Persona_De_Capa_Rol( Caracterizacion_Formulario Tipo_Capas, object Identificador_Capa )
                {
                        string Campo_Identificador_Capa = "" ;

                        switch ( Tipo_Capas )
                        { 
                                case Caracterizacion_Formulario.Personas: throw new Exception("whut") ;
                                case Caracterizacion_Formulario.Usuarios: Campo_Identificador_Capa = "Nombre_Identificador_Usuario" ; break ;
                                case Caracterizacion_Formulario.Empleados: Campo_Identificador_Capa = "ID_Empleado" ; break ;
                                case Caracterizacion_Formulario.Proveedores: Campo_Identificador_Capa = "ID_Proveedor" ; break ;
                        }
                        int ID_Persona = Convert.ToInt32(
                        Interfaz_Base_Datos.Ejecutar
                        (
                                $"select ID_Persona from Sujetos where { Campo_Identificador_Capa } = @Identificador_Capa ",
                                Tipos_Comando_Sql.Query_Escalar,
                                "@Identificador_Capa",
                                Identificador_Capa                                
                        ) ) ;
                        return ID_Persona ;
                }
                public static DataTable? Marshal_Get_Tareas_Empleado( int ID_Empleado, string Filtro_Busqueda, string Argumento_Busqueda ) { return Interfaz_Base_Datos.Get_Tareas_Empleado( ID_Empleado, Filtro_Busqueda, Argumento_Busqueda ) ; }
                public static DataTable? Get_Capas_Sujeto( Caracterizacion_Formulario Tipo_Capa, string Filtro_Busqueda = "", string Argumneto_Busqueda = "" )
                {
                        DataTable? Capas = null ;
                        switch ( Tipo_Capa )
                        { 
                                case Caracterizacion_Formulario.Personas: Capas = Interfaz_Base_Datos.Get_Personas( Filtro_Busqueda, Argumneto_Busqueda ) ; break ;
                                case Caracterizacion_Formulario.Usuarios: Capas = Interfaz_Base_Datos.Get_Usuarios( Filtro_Busqueda.Replace(' ', '_'), Argumneto_Busqueda ) ; break ;
                                case Caracterizacion_Formulario.Empleados: Capas = Interfaz_Base_Datos.Get_Empleados( Filtro_Busqueda, Argumneto_Busqueda ) ; break ;
                                case Caracterizacion_Formulario.Proveedores: Capas = Interfaz_Base_Datos.Get_Proveedores_JOIN_Direccion_Empresa_Proveedor( Filtro_Busqueda, Argumneto_Busqueda ) ; break ;
                                default: throw new Exception("Fallo de cohesion, fallo de coupling.") ;
                        }
                        return Capas;
                }

                // Checks
                public static bool Nombre_Identificador_Ya_Existente( string Nombre_Identificador ) { return Interfaz_Base_Datos.Nombre_Identificador_Ya_Existente( Nombre_Identificador ) ; }

                // Procesamiento tareas de Empleados
                public static void Modificar_Tarea_Empleado( string Tarea_Premodificacion, string Tarea_Postmodificacion, int ID_Empleado )
                { 
                        if ( string.IsNullOrWhiteSpace( Tarea_Postmodificacion ) ) { throw new InvalidOperationException("Se paso un valor de tarea null, vacio o espacios en blanco. Considere borrar la tarea.") ; }

                        Iniciar_Transaccion_Manual() ;
                        Delete_Tarea_Empleado( ID_Empleado, Tarea_Premodificacion, true ) ;
                        Insert_Tarea_Empleado( ID_Empleado, Tarea_Postmodificacion, true ) ;
                        Commit_Transaccion() ;
                }
                public static void Marshal_Delete_Tarea( int ID_Empleado, string Antigua_Tarea ) { Interfaz_Base_Datos.Delete_Tarea_Empleado( ID_Empleado, Antigua_Tarea ) ; }
                public static void Marshal_Insert_Tarea_Empleado( int ID_Empleado, string Nueva_Tarea ) { Interfaz_Base_Datos.Insert_Tarea_Empleado( ID_Empleado, Nueva_Tarea ) ; }

                // Seleccion de Sujetos
                public static DataTable? Get_Resumen_Sujetos_Validos( string Columna_Null, string Filtro_Busqueda = "", string Argumento_Busqueda = "" )
                {
                        // De nuevo, esto es una mala idea, lo optimo seria implementar esto como una vista en la base de datos
                        // Pero meto esta query de atrevido y me ahorro cambiar la entrega de bases de datos.

                        string Query = 
                        "select\n" +
                        "Sujetos.ID_Persona,\n" +
                        "Personas.Nombre,\n" +
                        "Personas.Apellido,\n" +
                        "Personas.Telefono,\n" +
                        "Sujetos.Nombre_Identificador_Usuario,\n" +
                        "Sujetos.ID_Empleado,\n" +
                        "Sujetos.ID_Proveedor\n" +
                        "from\n" +
                        "( Sujetos join Personas on( Personas.ID = Sujetos.ID_Persona) )\n" +
                        $"where { Columna_Null } is null\n" ;

                        DataTable? Sujetos_Validos ;
                        if ( Argumento_Busqueda != "" ) { Sujetos_Validos = ( DataTable? ) Ejecutar( ( Query + $"and { Filtro_Busqueda } like @Argumento_Busqueda ;" ), Tipos_Comando_Sql.Query, "@Argumento_Busqueda", Argumento_Busqueda ) ; }
                        else { Sujetos_Validos = ( DataTable? ) Ejecutar( Query, Tipos_Comando_Sql.Query ) ; }
                        return Sujetos_Validos ;
                }

                // Gestion de capas
                /// <param name="IDentificador_Capa">La ID o el Nombre Identificador de la capa.</param>
                public static void Eliminar_Capa( Caracterizacion_Formulario Tipo_Caracterizacion, object IDentificador_Capa )
                {
                        switch ( Tipo_Caracterizacion )
                        { 
                                case Caracterizacion_Formulario.Personas: Interfaz_Base_Datos.Eliminar_Sujeto( ID_Persona: Convert.ToInt32( IDentificador_Capa ) ) ; break ;
                                case Caracterizacion_Formulario.Usuarios: Interfaz_Base_Datos.Delete_Usuario( Nombre_Identificador: IDentificador_Capa.ToString() ) ; break ;
                                case Caracterizacion_Formulario.Empleados: Interfaz_Base_Datos.Delete_Empleado( ID_Empleado: Convert.ToInt32( IDentificador_Capa ) ) ; break ;
                                case Caracterizacion_Formulario.Proveedores: Interfaz_Base_Datos.Delete_Proveedor( ID_Proveedor: Convert.ToInt32( IDentificador_Capa ) ) ; break ;
                        }
                } 
                public static object? Crear_Capa_O_Entidad( Caracterizacion_Formulario Caracterizacion_Actual, Dictionary<string, object?> Atributos_Capa )
                {
                        static int Crear_Nuevo_Sujeto( Dictionary<string, object> Atributos_Nueva_Persona )
                        {
                                { // Asegura que los campos son valido 
                                        if ( Atributos_Nueva_Persona["Nombre"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Nueva_Persona["Apellido"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Nueva_Persona["Telefono"] is null ) { throw new ArgumentNullException() ; }
                                }

                                string Nombre = Atributos_Nueva_Persona["Nombre"].ToString()! ;
                                string Apellido = Atributos_Nueva_Persona["Apellido"].ToString()! ;
                                string Telefono = Atributos_Nueva_Persona["Telefono"].ToString()! ;
                                int ID_Nueva_Persona = Interfaz_Base_Datos.Crear_Sujeto( Nombre, Apellido, Telefono ) ;
                                return ID_Nueva_Persona ;
                        }
                        static void Crear_Nuevo_Usuario( Dictionary<string, object> Atributos_Usuario )
                        {
                                { // Asegura que los campos son validos 
                                        if ( Atributos_Usuario["ID_Persona"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Usuario["Nombre_Identificador"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Usuario["Contrasena"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Usuario["Nivel_Confidencialidad"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Usuario["Inactivo"] is null ) { throw new ArgumentNullException() ; }
                                }
                                int ID_Persona = Convert.ToInt32( Atributos_Usuario["ID_Persona"] ) ; 
                                string Nombre_Identificador = Atributos_Usuario["Nombre_Identificador"].ToString() ;
                                string Contrasena = Atributos_Usuario["Contrasena"].ToString() ;
                                string Nivel_Confidencialidad = Atributos_Usuario["Nivel_Confidencialidad"].ToString() ;
                                bool Inactivo = Convert.ToBoolean( Atributos_Usuario["Inactivo"] ) ;
                                Interfaz_Base_Datos.Agregar_Usuario( ID_Persona, Nombre_Identificador, Contrasena, Nivel_Confidencialidad, Inactivo ) ;
                        }
                        static int Crear_Nuevo_Empleado( Dictionary<string, object> Atributos_Empleado )
                        {
                                { // Comprueba los valores 
                                        if ( Atributos_Empleado["ID_Persona"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Empleado["Horas_Trabajadas"] is null ) { throw new ArgumentNullException() ; }
                                }
                                int ID_Persona = Convert.ToInt32( Atributos_Empleado["ID_Persona"] ) ;
                                int Horas_Trabajadas = Convert.ToInt32( Atributos_Empleado["Horas_Trabajadas"] ) ;
                                int ID_Nuevo_Empleado = Interfaz_Base_Datos.Agregar_Empleado( ID_Persona, Horas_Trabajadas ) ;
                                return ID_Nuevo_Empleado ;
                        }
                        static int Crear_Nuevo_Proveedor( Dictionary<string, object> Atributos_Proveedor )
                        {
                                { // Valida los campos
                                        if ( Atributos_Proveedor["ID_Persona"] is null ) { throw new ArgumentNullException() ; }
                                        if (  ( Atributos_Proveedor["Nombre_Empresa"] is null && Atributos_Proveedor["Email_Empresa"] is null &&
                                                Atributos_Proveedor["Barrio"] is null && Atributos_Proveedor["Email_Empresa"] is null && Atributos_Proveedor["Calle1"] is null && Atributos_Proveedor["Calle2"] is null
                                              ) ==
                                              (
                                                Atributos_Proveedor["Nombre_Empresa"] is not null && Atributos_Proveedor["Email_Empresa"] is not null &&
                                                Atributos_Proveedor["Barrio"] is not null && Atributos_Proveedor["Email_Empresa"] is not null && Atributos_Proveedor["Calle1"] is not null && Atributos_Proveedor["Calle2"] is not null
                                              )

                                        ) { throw new ArgumentException("Se proporciono informacion parcial sobre la Empresa o no Empresa del Proveedor.") ; }
                                }
                                int ID_Persona = Convert.ToInt32( Atributos_Proveedor["ID_Persona"] ) ;
                                string? Nombre_Empresa = ( ( Atributos_Proveedor["Nombre_Empresa"] is not null ) ? Atributos_Proveedor["Nombre_Empresa"].ToString() : null ) ;
                                string? Email_Empresa = ( ( Atributos_Proveedor["Email_Empresa"] is not null ) ? Atributos_Proveedor["Email_Empresa"].ToString() : null ) ;
                                string? Barrio = ( ( Atributos_Proveedor["Barrio"] is not null ) ? Atributos_Proveedor["Barrio"].ToString() : null ) ;
                                string? Calle1 = ( ( Atributos_Proveedor["Calle1"] is not null ) ? Atributos_Proveedor["Calle1"].ToString() : null ) ;
                                string? Calle2 = ( ( Atributos_Proveedor["Calle2"] is not null ) ? Atributos_Proveedor["Calle2"].ToString() : null ) ;
                                string? Indicaciones = ( ( Atributos_Proveedor["Indicaciones"] is not null ) ? Atributos_Proveedor["Indicaciones"].ToString() : null ) ;
                                int ID_Nuevo_Proveedor = Interfaz_Base_Datos.Agregar_Proveedor( ID_Persona, Nombre_Empresa, Email_Empresa, Barrio, Calle1, Calle2, Indicaciones ) ;
                                return ID_Nuevo_Proveedor ;
                        }

                        object? IDentificador_Nueva_Capa ;
                        switch ( Caracterizacion_Actual )
                        { 
                                case Caracterizacion_Formulario.Personas: IDentificador_Nueva_Capa = Crear_Nuevo_Sujeto( ( Dictionary<string, object> ) Atributos_Capa! ) ; break ;
                                case Caracterizacion_Formulario.Usuarios: IDentificador_Nueva_Capa = null ; Crear_Nuevo_Usuario( ( Dictionary<string, object> ) Atributos_Capa! ) ;  break ;
                                case Caracterizacion_Formulario.Empleados: IDentificador_Nueva_Capa = Crear_Nuevo_Empleado( ( Dictionary<string, object> ) Atributos_Capa! ) ; break ;
                                case Caracterizacion_Formulario.Proveedores: IDentificador_Nueva_Capa = Crear_Nuevo_Proveedor( ( Dictionary<string, object> ) Atributos_Capa! ) ; break ;
                                default: throw new Exception("Fallo de cohesion.") ;
                        }
                        return IDentificador_Nueva_Capa ;
                }
                public static void Modificar_Capa( Caracterizacion_Formulario Tipo_Caracterizacion, Dictionary<string, object> Atributos_Capa )
                {
                        void Modificar_Persona()
                        {
                                { // No faltan campos
                                        if ( Atributos_Capa["ID"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Capa["Nombre"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Capa["Apellido"] is null ) { throw new ArgumentNullException() ; }
                                        if ( Atributos_Capa["Telefono"] is null ) { throw new ArgumentNullException() ; }
                                }

                                int ID_Persona = Convert.ToInt32( Atributos_Capa["ID"] ) ;
                                string Nombre = Atributos_Capa["Nombre"].ToString()! ;
                                string Apellido = Atributos_Capa["Apellido"].ToString()! ;
                                string Telefono = Atributos_Capa["Telefono"].ToString()! ;

                                Interfaz_Base_Datos.Update_Persona( ID_Persona, Nombre, Apellido, Telefono ) ;
                        }
                        void Modificar_Usuario()
                        {
                                string Nombre_Identificador = Atributos_Capa["Nombre_Identificador"].ToString()! ;
                                string? Nombre_Identificador_Actual = ( ( Atributos_Capa.ContainsKey("Nombre_Identificador_Actual") ) ? Atributos_Capa["Nombre_Identificador_Actual"].ToString()! : null )   ;
                                string? Contrasena = ( ( Atributos_Capa.ContainsKey("Contrasena") ) ? Atributos_Capa["Contrasena"].ToString() : null ) ;
                                string Nivel_Confidencialidad = Atributos_Capa["Nivel_Confidencialidad"].ToString()! ;
                                bool Inactivo = Convert.ToBoolean(Atributos_Capa["Inactivo"] ) ;
                                if ( Contrasena is not null ) { Update_Usuario( Nombre_Identificador, Nivel_Confidencialidad, Inactivo, Hash_Contrasena: Contrasena, Nombre_Identificador_Actual: ( ( Nombre_Identificador_Actual is not null ) ? Nombre_Identificador_Actual : "" ) ) ; return ; }
                                Update_Usuario( Nombre_Identificador, Nivel_Confidencialidad, Inactivo, Nombre_Identificador_Actual: ( ( Nombre_Identificador_Actual is not null ) ? Nombre_Identificador_Actual : "" ) ) ;
                        }
                        void Modificar_Empleado()
                        { 
                                int ID_Empleado = Convert.ToInt32( Atributos_Capa["ID"] ) ;
                                int Horas_Trabajadas = Convert.ToInt32( Atributos_Capa["Horas_Trabajadas"] ) ;
                                Interfaz_Base_Datos.Update_Empleado( ID_Empleado, Horas_Trabajadas ) ;
                        }
                        void Modificar_Proveedor()
                        {
                                // Trabaja bajo la asuncion de que si el nombre de empresa es null, entonces se quiere que el Proveedor
                                // NO tenga una empresa asociada al final de esto. A partir de eso se presume que si el nombre de empresa es null
                                // el resto de campos que tratan sobre la empresa tambien lo son.

                                int ID_Proveedor = Convert.ToInt32( Atributos_Capa["ID_Proveedor"] ) ;
                                string? Nombre_Empresa = ( string? ) Atributos_Capa["Nombre_Empresa"] ;
                                string? Email_Empresa = ( string? ) Atributos_Capa["Email_Empresa"] ;
                                string? Barrio = ( string? ) Atributos_Capa["Barrio"] ;
                                string? Calle1 = ( string? ) Atributos_Capa["Calle1"] ;
                                string? Calle2 = ( string? ) Atributos_Capa["Calle2"] ;
                                string? Indicaciones = ( string? ) Atributos_Capa["Indicaciones"] ;

                                Iniciar_Transaccion_Manual() ;
                                Update_Proveedor( ID_Proveedor, Nombre_Empresa, Email_Empresa, true ) ;
                                if ( Nombre_Empresa is not null )
                                {
                                        if ( Proveedor_Tiene_Direccion_Empresa( ID_Proveedor, true ) )
                                        { 
                                                Update_Direccion_Empresa_Proveedor( ID_Proveedor, Barrio!, Calle1!, Calle2!, Indicaciones, true ) ;
                                                Commit_Transaccion() ;
                                                return ;
                                        }
                                        Insert_Direccion_Empresa_Proveedor( ID_Proveedor, Barrio!, Calle1!, Calle2!, Indicaciones, true ) ;
                                        Commit_Transaccion() ;
                                        return ;
                                }
                                Delete_Direccion_Empresa_Proveedor( ID_Proveedor, true ) ;
                                Commit_Transaccion() ;
                        }

                        switch ( Tipo_Caracterizacion )
                        { 
                                case Caracterizacion_Formulario.Personas: Modificar_Persona() ; break ;
                                case Caracterizacion_Formulario.Usuarios: Modificar_Usuario() ; break ;
                                case Caracterizacion_Formulario.Empleados: Modificar_Empleado() ; break ;
                                case Caracterizacion_Formulario.Proveedores: Modificar_Proveedor() ; break ;
                        }
                }

                // Registro de Sujetos
                public static void Registrar_Sujeto( Dictionary<string, string> Atributos_Persona, Dictionary<string, string>? Atributos_Usuario, Dictionary<string, string?>? Atributos_Proveedor )
                {
                        string Nombre_Persona = Atributos_Persona["Nombre"].ToString() ;
                        string Apellido = Atributos_Persona["Apellido"].ToString() ;
                        string Telefono = Atributos_Persona["Telefono"].ToString() ;

                        Iniciar_Transaccion_Manual() ;
                        int ID_Sujeto = Crear_Sujeto( Nombre_Persona, Apellido, Telefono, true ) ;
                        if ( Atributos_Usuario is not null )
                        { 
                                string Nombre_Usuario = Atributos_Usuario["Nombre_Identificador"].ToString() ;
                                string Hash_Contrasena = Atributos_Usuario["Contrasena"].ToString() ;
                                Agregar_Usuario( ID_Sujeto, Nombre_Usuario, Hash_Contrasena, Nivel_Confidencialidad: ( ( Atributos_Proveedor is not null ) ? "0001" : "0000" ), Inactivo: false, true ) ;
                        }
                        if ( Atributos_Proveedor is not null )
                        {
                                string? Nombre_Empresa = ( string? ) Atributos_Proveedor["Nombre_Empresa"] ;
                                string? Email_Empresa = ( string? ) Atributos_Proveedor["Email_Empresa"] ;
                                string? Barrio = ( string? ) Atributos_Proveedor["Barrio"] ;
                                string? Calle1 = ( string? ) Atributos_Proveedor["Calle1"] ;
                                string? Calle2 = ( string? ) Atributos_Proveedor["Calle2"] ;
                                string? Indicaciones = ( string? ) Atributos_Proveedor["Indicaciones"] ;
                                Agregar_Proveedor( ID_Sujeto!, Nombre_Empresa!, Email_Empresa!, Barrio!, Calle1!, Calle2!, Indicaciones!, true ) ;
                        }
                        Commit_Transaccion() ;
                }
        }
}
