# define DEBUG_Conexion_Base_Datos
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

using MySql.Data.MySqlClient ;
using MySql.Data.Types;

using Org.BouncyCastle.Crypto.Tls;

namespace Acceso_Datos
{


        public enum Tipos_Comando_Sql
        {
                Query ,
                Query_Escalar,
                No_Query
        }

        public enum Tipos_Elemento_Subasta_Remate
        { 
                Animales,
                Maquinaria
        }

        public static class Interfaz_Base_Datos
        {
                // Antes de arrancar...
                // Seria mucho mas seguro que el programa solo tenga acceso a funciones especializadas de la base de datos, las cuales pertenecer a un usuario de la misma con privilegios minimos.
                // Asi el programa solo tiene acceso a un entorno controlado de la base de datos.
                // De esa manera si el codigo fuente es comprometido, los hackers no tendrian el sistema servido en bandeja; operar con el usuario root aqui es bastante peligroso en el aspecto de seguridad,
                // porque podrias armar algun desastre tu mismo, o porque si te hackean se pueden hacer de la base de datos al toque.
                // Al permitir al programa interactur con la base de datos solo a traves de funciones, creas un entorno controlado en el que tanto te evitas poder armar un desastr tu mismo como que si hackers
                // acceden al codigo fuente puedan tener herramientas para compometer la base de datos o informacion confidencial de ella.
                // Pero dado que esto es un simulacro, tal cosa nunca llegara a ocurrir. Solo voy a ejecutar sentencias asi nomas.
                // Si el franklin se pone a hackear mi programa lo denuncio :v

                static MySqlConnection? Conexion ; // Cuando la referencia no es null, significa que hay una llamada del metodo `Ejecucion` en curso.
                static MySqlTransaction? Transaccion_Actual ; // Cuando la referencia no es null, significa que hay una transaccion en curso.
                // static using Transaction.TransactionScope ;
                        
                static string Servidor = "localhost" ;
                static string Base_Datos = "quien da mas" ;
                static string Usuario = "root" ;
                static string Contrasena = "" ;
                static string Llave_Conexion = "Database=" + Base_Datos +
                                               " ; Data Source=" + Servidor +
                                               " ; User Id=" + Usuario +
                                               " ; Password=" + Contrasena +
                                               "" ;

                // Transacciones Manuales
                public static void Iniciar_Transaccion_Manual()
                { // Comienza la transaccion
                        if ( Conexion is not null ) { throw new InvalidOperationException("No se puede comenzar una nueva transaccion mientras una conexion esta en uso.") ; }
                        if ( Transaccion_Actual is not null ) { throw new InvalidOperationException("No se puede comenzar una nueva transaccion mientras otra transaccion esta en curso.") ; }

                        Conexion = new MySqlConnection( Llave_Conexion ) ;
                        Conexion.Open() ;
                        Transaccion_Actual = Conexion.BeginTransaction() ;
                }
                public static void Rollback_Transaccion()
                {
                        if ( Transaccion_Actual is null ) { throw new InvalidOperationException("No hay una transaccion en curso a la cual hacer rollback.") ; }
                        Transaccion_Actual.Rollback() ;
                        Limpiar_Entorno_Transaccion() ;
                }
                public static void Commit_Transaccion()
                { 
                        if ( Transaccion_Actual is null ) { throw new InvalidOperationException("No hay una transaccion en curso a la cual hacer commit.") ; }
                        Transaccion_Actual.Commit() ;
                        Limpiar_Entorno_Transaccion() ;
                }
                private static void Limpiar_Entorno_Transaccion()
                {
                        if ( Conexion is null ) { throw new InvalidOperationException("No se puede llevar a cabo la limpieza del entorno de Ejecucion pues no hay una conexion que limpiar.") ; }
                        if ( Transaccion_Actual is null ) { throw new InvalidOperationException("No se puede llevar a cabo la limpieza del entorno de Ejecucion pues no hay una transaccion que limpiar.") ; }

                        Conexion!.Close() ;
                        Conexion.Dispose() ;
                        Conexion = null ;
                        Transaccion_Actual.Dispose() ;
                        Transaccion_Actual = null ;
                }


                #region >>---- Miselania
                private static void Mostrar_Tabla( DataTable Tabla_A_Mostrar )
                {
                        void Mostrar_Cabezeras() 
                        { // Dibuja las cabeceras de la tabla.
                                foreach ( DataColumn Actual_DataColumn in Tabla_A_Mostrar.Columns )
                                {
                                        Console.Write( Actual_DataColumn.ColumnName ) ;

                                        if ( Tabla_A_Mostrar.Columns.IndexOf( Actual_DataColumn ) == ( Tabla_A_Mostrar.Columns.Count - 1 ) ) { Console.Write(".") ; }
                                        else { Console.Write(", ") ; }
                                }
                                        Console.WriteLine() ;
                        }

                        void Mostrar_Filas()
                        { // Dibuja las filas de la tabla. O podrias decir que dibuja el resto de las columnas.
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

                private static bool String_Es_Solo_Espacios( /*this*/ string Cadena )
                { 
                        if ( Cadena.Length == 0 ) { return false ; }
                        for ( int i = 0 ; i < Cadena.Length ; i++ ) { if ( ! char.IsWhiteSpace(Cadena[i]) ) { return false ; } }
                        return true ;
                }

                private static bool String_Es_Solo_Espacios_O_Null( /* this */ string Cadena )
                { 
                        if ( String_Es_Solo_Espacios( Cadena ) ) { return true ; }
                        if ( Cadena is null ) { return true ; }
                        return false ;
                }
                # endregion

                # region >>---- Ejecucion basica
                /// <summary>
                /// Ejecuta una unica setencia sql en la base de datos, la cual hace uso de un unico parametro.
                ///  Ver: "6.1.4 Working with Parameters" https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-parameters.html#:~:text=6.1.4%C2%A0Working%20with%20Parameters 
                /// </summary>
                /// <param name="Sentencia_A_Ejecutar">La sentencia a ejecutar en la base de datos.</param>
                /// <param name="Tipo_Comando_Sql_Seleccionado">Especifica el tipo de setencia sql a ejecutar. Puede ser una `Query`, `Query_Escalar` o `No_Query`.</param>
                /// <param name="Unico_Parametro_Query">El parametro para el MySqlCommand.</param>
                /// <param name="Unico_Argumento_Query">El argumento que se le asignara al parametro del MySqlCommand. Se admite un tipo primitivo, string o null representando a DBNull.
                /// </param>
                /// <returns>
                /// Si se selecciono una Query, en el object subyace una DataTable?.
                /// Si se selecciono una Query_Escalar, en el object? subyace un tipo de variable primitiva o string del mismo tipo que el resultado arrojado.
                /// Si se selecciono una No_Query, el object? es null.
                /// </returns>
                /// <exception cref="ArgumentException"></exception>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static object? Ejecutar( string Sentencia_A_Ejecutar, Tipos_Comando_Sql Tipo_Comando_Sql_Seleccionado, string Unico_Parametro_Query, object? Unico_Argumento_Query, bool Conforma_Transaccion_Manual = false )
                {
                        // if ( Tipo_Comando_Sql_Seleccionado == Tipos_Comando_Sql.No_Query && ( Unico_Parametro_Query != "" || Unico_Argumento_Query != null ) ) { throw new ArgumentException("Las no queries a ejecutar no admiten argumentos o parametros.") ; }
                        if ( string.IsNullOrWhiteSpace( Unico_Parametro_Query ) ) { throw new ArgumentException("Se proporciono un parametro para la sentencia el cual es null, un string vacio o consta solo de espacios en blanco.") ; }
                        if ( Unico_Argumento_Query is not null && Unico_Argumento_Query is string Argumento_ToString && String_Es_Solo_Espacios( Argumento_ToString ) ) { throw new ArgumentException("El unico argumento de la sentencia solo consta de espacios, considere no parametrizar la sentencia.") ; }
                        
                        { // Llama al metodo base `Ejecutar`, envolviendo el unico parametro y argumento de la query en arrays.
                                string[] Parametro_Como_Array ;
                                object[] Argumento_Como_Array ;

                                Parametro_Como_Array = new string[] { Unico_Parametro_Query } ;
                                Argumento_Como_Array = new object[] { Unico_Argumento_Query! } ; // El argumento puede ser null aqui, y es un funcionalidad intencional.

                                return Ejecutar( Sentencia_A_Ejecutar, Tipo_Comando_Sql_Seleccionado, Parametro_Como_Array, Argumento_Como_Array, Conforma_Transaccion_Manual ) ;
                        }
                }

                /// <summary>
                /// Ejecuta una unica setencia sql en la base de datos, la cual hace uso de un conjunto de parametros dados a la funcion.
                /// Tanto los parametros como sus aargumentos se proporcionan en arrays. Un argumento se asocia a el parametro con el que comparten el indice en sus respectivos array.
                /// Asi al parametro del indice numero 1 se le asigna el argumento de indice numero 1. Asegurate de pasar esos valores en el orden correcto.
                /// Pasar un array null de parametros y un array null de argumentos resulta en la ejecucion de una sentencia sin parametros, pero si esa es tu intencion es mas conveniente utilizar la primera sobrecarga del metodo.
                ///  Ver: "6.1.4 Working with Parameters" https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-parameters.html#:~:text=6.1.4%C2%A0Working%20with%20Parameters 
                /// </summary>
                /// <param name="Sentencia_A_Ejecutar">La sentencia a ejecutar en la base de datos.</param>
                /// <param name="Tipo_Comando_Sql_Seleccionado">Especifica el tipo de setencia sql a ejecutar. Puede ser una `Query`, `Query_Escalar` o `No_Query`.</param>
                /// <param name="Parametros_Query">El array de parametros de la sentencia.</param>
                /// <param name="Argumentos_Query">El array de argumentos para los parametros de la sentencia. Un argumento null representa el valor NULL en la base de datos.</param>
                /// <returns>
                /// Si se selecciono una Query, en el object subyace una DataTable?.
                /// Si se selecciono una Query_Escalar, en el object? subyace un tipo de variable primitiva o string del mismo tipo que el resultado arrojado.
                /// Si se selecciono una No_Query, el object? es null.
                /// </returns>
                /// <exception cref="ArgumentException"></exception>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static object? Ejecutar( string Sentencia_A_Ejecutar, Tipos_Comando_Sql Tipo_Comando_Sql_Seleccionado, string[]? Parametros_Query = null, object[]? Argumentos_Query = null, bool Conforma_Transaccion_Manual = false )
                {
                        MySqlCommand Comando = new MySqlCommand() ;

                        DataTable? Resultado_No_Escalar = new DataTable() ;
                        object? Resultado_Escalar = null ;
                        object? Salida ; // Es la informacion que devuelve la funcion. Puede o no contener informacion.
                        
                        void Abortar_Transaccion_Manual_En_Curso()
                        { 
                                Transaccion_Actual!.Rollback() ;
                                Transaccion_Actual.Dispose() ;
                                Transaccion_Actual = null ;
                        }

                        void Crear_Conexion_Y_Comando()
                        { // Se hace la conexion y el comando
                                if ( Conforma_Transaccion_Manual && Transaccion_Actual is null ) { throw new InvalidOperationException("Debe haber una transaccion en curso para poder Ejecutar un comando que forma parte de tal transaccion.") ; }
                                if ( Transaccion_Actual is not null && Conexion is null ) { throw new InvalidOperationException("Hay una transaccion en curso, pero la conexion no esta abierta.") ; }

                                if ( Transaccion_Actual is null ) { Conexion = new MySqlConnection( Llave_Conexion ) ; Conexion.Open() ; }
                                if ( Conforma_Transaccion_Manual ) { Comando.Transaction = Transaccion_Actual ; }
                                Comando.CommandText = Sentencia_A_Ejecutar ;
                                Comando.Connection = Conexion ;
                        }

                        Crear_Conexion_Y_Comando() ;

                        if ( Parametros_Query is not null && Argumentos_Query is not null )
                        { // Se preparan los argumentos
                                
                                if ( Parametros_Query.Length != Argumentos_Query.Length ) { throw new ArgumentException("El numero de parametros y argumentos de la query no coincide.") ; }
                                string Parametro_Actual ;
                                object? Argumento_Actual ;
                                for ( int Indice_Valor = 0 ; Indice_Valor < Parametros_Query.Length ; Indice_Valor++ )
                                {
                                        Parametro_Actual = Parametros_Query[ Indice_Valor ] ;
                                        Argumento_Actual = ( Argumentos_Query[ Indice_Valor ] is not null ) ? Argumentos_Query[ Indice_Valor ] : null ;

                                        if ( string.IsNullOrWhiteSpace( Parametro_Actual ) ) { throw new ArgumentException($"El parametro numero `{ Indice_Valor }` es null, espacios o esta vacio.") ; }
                                        if ( Argumento_Actual is not null && Argumento_Actual is string Argumento_ToString && String_Es_Solo_Espacios( Argumento_ToString ) ) { throw new ArgumentException($"El argumento numero `{ Indice_Valor }` es solo espacios.") ; }

                                        Comando.Parameters.AddWithValue( Parametro_Actual, Argumento_Actual ) ;
                                }
                        }

                        switch ( Tipo_Comando_Sql_Seleccionado )
                        { // Se ejecutan las sentencias
                                case Tipos_Comando_Sql.No_Query:
                                        try { Comando.ExecuteNonQuery() ; }
                                        catch when ( Conforma_Transaccion_Manual )
                                        {
                                                Abortar_Transaccion_Manual_En_Curso() ;
                                                throw ;
                                        }


                                        Salida = null ;
                                break ;
                                case Tipos_Comando_Sql.Query:
                                        MySqlDataAdapter Adaptador = new MySqlDataAdapter( Comando ) ; // Adaptará una query no escalar a una DataTable
                                        try { if ( Adaptador.Fill( Resultado_No_Escalar ) == 0 ) { Resultado_No_Escalar = null ; } }
                                        catch when ( Conforma_Transaccion_Manual )
                                        {
                                                Abortar_Transaccion_Manual_En_Curso() ;
                                                throw ;
                                        }

                                        Salida = ( ( object ) Resultado_No_Escalar! ) ;
                                break ;
                                case Tipos_Comando_Sql.Query_Escalar:
                                        try { Resultado_Escalar = Comando.ExecuteScalar() ; }
                                        catch when ( Conforma_Transaccion_Manual )
                                        { 
                                                Abortar_Transaccion_Manual_En_Curso() ;
                                                throw ;
                                        }

                                        Salida = ( ( ! Convert.IsDBNull( Resultado_Escalar ) ) ? Resultado_Escalar : null ) ;
                                break ;
                                default:
                                        throw new ArgumentException( "El tipo de orden es incorrecto." ) ; // Por la naturaleza del enum, esto nunca deberia llegar a ocurrir. Pero algo me dice que lo ponga de igual forma.
                                break ;
                        }

                        if ( Transaccion_Actual is null )
                        {
                                Conexion!.Close() ;
                                Conexion.Dispose() ;
                                Conexion = null ;
                        }
                        return Salida ;
                }

                /// <summary>
                /// Ejecuta una conjunto de sentencias sql sin parametros como parte de una misma transaccion en la base de datos.
                /// </summary>
                /// <param name="Sentencias_De_La_Transaccion">Un arraay de strings donde cada entrada representa una sentencia sql del tipo No_Query a ser ejecutada en la base de datos.</param>
                /// <exception cref="Exception"></exception>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static void Ejecutar( string[] Sentencias_De_La_Transaccion )
                {
                        if ( Transaccion_Actual is not null ) { throw new Exception("Se trato de realizar una transaccion mientras otra transaccion esta en curso.") ; }

                        { // Prepar la transaccion
                                Conexion = new MySqlConnection( $"{ Llave_Conexion }; AllowUserVariables=true" ) ;

                                Console.WriteLine($"Iniciando conexion con la base de datos `{ Base_Datos }`.") ;
                                Conexion.Open() ;
                                Console.WriteLine("Conexion iniciada.") ;

                                Console.WriteLine("Se inicio la transaccion.") ;
                                Transaccion_Actual = Conexion.BeginTransaction() ;
                        }

                        try
                        { // Lleva a cabo las sentencias indicadas
                                MySqlCommand Sentencia_Sql = new MySqlCommand() ;
                                Sentencia_Sql.Connection = Conexion ;

                                foreach ( string Sentencia in Sentencias_De_La_Transaccion )
                                {
                                        // Console.WriteLine( $"La sentencia es: { Sentencia }" ) ;
                                        Sentencia_Sql.CommandText = Sentencia ;
                                        Sentencia_Sql.ExecuteNonQuery() ;
                                }
                                Transaccion_Actual.Commit() ;
                                Console.WriteLine("La transaccion fue confirmada(commit) con exito.") ;
                                
                        }
                        catch ( MySqlException ErrorBaseDatos )
                        { 
                                Transaccion_Actual.Rollback() ;
                                Console.WriteLine("Caso de fallo. Se cancelo la transaccion haciendo un rollback...\n") ;
                                throw ErrorBaseDatos ;
                        } 
                        finally
                        { // Limpia la transaccion y la conexion
                                Transaccion_Actual.Dispose() ;
                                Transaccion_Actual = null ;
                                Conexion.Close() ;   
                                Conexion.Dispose() ;
                                Conexion = null ;
                                Console.WriteLine("Se cerro y limpio la transaccion y la conexion.") ;
                        }
                }
                # endregion

                // Schema base de datos
                public static string[] Get_Columnas_Tabla_O_View( string Nombre_Tabla_O_View )
                {
                        if ( string.IsNullOrWhiteSpace( Nombre_Tabla_O_View ) ) { throw new ArgumentNullException("El nombre de la tabla o view es null, espacios en blanco o esta vacio") ; }

                        DataTable? Columnas_Tabla_DataTable = ( DataTable? ) Ejecutar( $"show columns from { Nombre_Tabla_O_View } ;", Tipos_Comando_Sql.Query ) ;
                        if ( Columnas_Tabla_DataTable is null ) { throw new ArgumentException($"No se encontraron columnas para la tabla o view { Nombre_Tabla_O_View }. Corrobora que el nombre sea correcto.") ; }

                        List<string> Columnas = new List<string>() ;
                        for ( int Indice_Fila = 0 ; Indice_Fila < Columnas_Tabla_DataTable.Rows.Count ; Indice_Fila++ )
                        {
                                DataRow Nombres_Columna = Columnas_Tabla_DataTable.Rows[ Indice_Fila ] ;
                                Columnas.Add( Nombres_Columna["Field"].ToString()! ) ;
                        }
                        return Columnas.ToArray<string>() ;
                }

                // Sistema de Sujetos
                # region >>---- Inserciones de Capas de Sujeto
                public static int Insertar_Persona( string Nombre, string Apellido, string Telefono, bool Conforma_Transaccion_Manual = false )
                {
                        #region >>---- Clausula Guardian / Gaurdian Clause
                        if ( Nombre is null ) { throw new ArgumentNullException("El Nombre del Persona a insertar no puede ser null.") ; }
                        if ( Apellido is null ) { throw new ArgumentNullException("El Apellido del Persona a insertar no puede ser null.") ; }
                        if ( Telefono is null ) { throw new ArgumentNullException("El Telefono del Persona a insertar no puede ser null.") ; }
                        
                        if ( Nombre.Length > 20 ) { throw new ArgumentException("El Nombre de el Persona a insertar excede los 20 caracteres.") ; }
                        foreach ( char Caracter in Nombre ) { if ( ! char.IsLetter( Caracter ) ) { throw new ArgumentException("El Nombre de la Persona a insertar no puede tener otros caracteres que letras.") ; } }

                        if ( Apellido.Length > 20 ) { throw new ArgumentException("El Apellido de la Persona a insertar excede los 20 caracteres.") ;  }
                        foreach ( char Caracter in Apellido ) { if ( ! char.IsLetter( Caracter ) ) { throw new ArgumentException("El Apellido de la Persona a insertar no puede tener otros caracteres que letras.") ; } }

                        if ( Telefono.Length > 20 ) { throw new ArgumentException("El Telefono de la Persona a ingresar supera los 20 caracteres.") ; }
                        // Aqui para compobar si es un telefono o no tendria que adecuarme a los diferentes numeros de telefono segun los paises, tanto nacionales de brazil, uruguay, argentina y quizas algun otro tanto nacionales como internacionales. Por ahora solo voy a checkar si tiene algun caracter no permitido.
                        // Si se vuelve una necesidad mas adelante hare una sanetizacion mas exhaustiva.
                        foreach ( char Caracter in Telefono ) { if ( ! char.IsDigit( Caracter ) && ! ( Caracter == '+' ) && ( Caracter == '-' ) ) { throw new ArgumentException("El numero de Telefono ingresado contiene caracteres ilegales. Solo se permiten numeros(llendo del cero al nueve), signos de mas(+) y guiones(-).") ; } }
                        #endregion ---------------------------------------
                        int ID_Persona = Convert.ToInt32(
                        Ejecutar
                        (
                                "insert into Personas( Nombre, Apellido, Telefono )\n" +
                                "values ( @Nombre, @Apellido, @Telefono ) ;\n" +
                                "select LAST_INSERT_ID() ;",
                                Tipos_Comando_Sql.Query_Escalar,
                                ( new string[] { "@Nombre", "@Apellido", "@Telefono" } ),
                                ( new object[] { Nombre, Apellido, Telefono } ),
                                Conforma_Transaccion_Manual
                        )
                        ) ;
                        return ID_Persona ;
                }

                public static void Insertar_Usuario( string Nombre_Identificador, string Contrasena, string Nivel_Confidencialidad, bool Inactivo, bool Conforma_Transaccion_Manual = false )
                {
                        # region >>---- Clausula Guardian / Guardian Clause
                        if ( Nombre_Identificador is null ) { throw new ArgumentNullException("El Nombre identificador del Usuario a insertar no puede ser null.") ; }
                        if ( Contrasena is null ) { throw new ArgumentNullException("La Contrasena del usuario a insertar no puede ser null.") ; }
                        if ( Nivel_Confidencialidad is null ) { throw new ArgumentNullException("La cadena que representa el Nivel de Confidencialidad del Usuario a insertar no puede ser null.") ; }
                        // Los valores booleanos no son nullbles.

                        if ( Nombre_Identificador.Length > 30 ) { throw new ArgumentException("El Nombre Identificador del Usuario a insertar supera los 30 caracteres.") ; }

                        if ( Contrasena.Length > 64 ) { throw new ArgumentException("La Contrasena del Usuario a insertar supera los 40 caracteres.") ; }
                        if ( Nivel_Confidencialidad.Length > 4 ) { throw new ArgumentException("La cadena que representa el Nivel de Confidenciaidad no debe ser mayor a 4 caracteres.") ; }
                        foreach ( char Caracter in Nivel_Confidencialidad ) { if ( Caracter != '0' && Caracter != '1' ) { throw new ArgumentException("La cadena que representa el nivel de confidencialidad debe estar compuesta exclusivamente de digitos binarios(ceros y unos).") ; } }
                        # endregion >>-------------------
                        Ejecutar
                        ( 
                                "insert into Usuarios( Nombre_Identificador, Contrasena, Nivel_Confidencialidad, Inactivo )\n" +
                                "values( @Nombre_Identificador, @Contrasena, @Nivel_Confidencialidad, @Inactivo ) ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Nombre_Identificador", "@Contrasena", "@Nivel_Confidencialidad", "@Inactivo" } ),
                                ( new object[] { Nombre_Identificador, Contrasena, Nivel_Confidencialidad, Inactivo } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }

                public static int Insertar_Empleado( int Horas_Trabajadas, bool Conforma_Transaccion_Manual = false )
                {
                        #region >>---- Clausula Guardian / Guardian Clause
                        if ( Horas_Trabajadas > int.MaxValue ) { throw new ArgumentException("El empleado a trabajado demasiado, jubilenlo.") ; }
                        if ( Horas_Trabajadas < 0 ) { throw new ArgumentException("Se le quiere asignar al Empleado a insertar una cantidad de Horas Trabajadas negativas. Ni modo que les faltaba cobrarle por trabajar al tipo XDDDD") ; }
                        # endregion >>------------------------------------
                        int ID_Empleado = Convert.ToInt32(
                        Ejecutar
                        ( 
                                "insert into Empleados( Horas_Trabajadas )\n" +
                                "values( @Horas_Trabajadas ) ;\n" +
                                "select LAST_INSERT_ID() ;",
                                Tipos_Comando_Sql.Query_Escalar,
                                "@Horas_Trabajadas",
                                Horas_Trabajadas,
                                Conforma_Transaccion_Manual
                        )
                        ) ;
                        return ID_Empleado ;
                }

                public static int Insertar_Proveedor( bool Conforma_Transaccion_Manual = false )
                { 
                        int ID_Proveedor = Convert.ToInt32(
                        Ejecutar( $"insert into Proveedores() values () ; select LAST_INSERT_ID() ;", Tipos_Comando_Sql.Query_Escalar, Conforma_Transaccion_Manual: Conforma_Transaccion_Manual ) 
                        ) ;
                        return ID_Proveedor ;
                }

                public static int Insertar_Proveedor
                ( 
                        string Nombre_Empresa,
                        string Email_Empresa,
                        string Barrio,
                        string Calle1, 
                        string Calle2, 
                        string? Indicaciones = null, 
                        bool Conforma_Transaccion_Manual = false )
                {
                        #region >>---- Clausula Guardian / Guardian Clause
                        if ( string.IsNullOrWhiteSpace( Nombre_Empresa ) ) { throw new ArgumentException("El Nombre de la empresa asociada al Proveedor a a insertar debe contener informacion.") ; }
                        if ( string.IsNullOrWhiteSpace( Calle1 ) || string.IsNullOrWhiteSpace( Calle2 ) ) { throw new ArgumentException("Se debe ingresar ambas calles para la direccion de la empresa asociada al Proveedor a insertar.") ; }
                        if ( String_Es_Solo_Espacios( Indicaciones ) ) { throw new ArgumentOutOfRangeException("Las indicaciones para la direccion de la empresa asociada al Proveedor a insertar no puede ser espacios en blanco. Considera no pasar el parametro o llenarlo con informacion.") ; }

                        if ( Nombre_Empresa.Length > 20 ) { throw new ArgumentException("El Nombre de Empresa del Proveedor a insertar excede los 20 caracteres.") ; }
                        // No checkeo que significan los caracteres pq anda a saber los nombres mas raros que les ponen a la empresa. Mira el elon que le puso 'x' a twitter nms.

                        if ( Nombre_Empresa.Length > 20 ) { throw new ArgumentOutOfRangeException("El Nombre de la empresa asociada al Proveedor a insertar supera los 20 caracteres.") ; }
                        if ( Barrio.Length > 20 ) { throw new ArgumentOutOfRangeException("El Barrio de la direccion de la empresa asociada al Proveedor a insertar supera los 20 caracteres.") ; }
                        if ( Calle1.Length > 20 ) { throw new ArgumentOutOfRangeException("La primera calle de la empresa asociada al Proveedor a insertar supera los 20 caracteres.") ; }
                        if ( Calle2.Length > 20 ) { throw new ArgumentOutOfRangeException("La segunda calle de la empresa asociada al Proveedor a insertar supera los 20 caracteres.") ; }
                        if ( Indicaciones is not null && Indicaciones.Length > 300 ) { throw new ArgumentOutOfRangeException("Las indicaciones adicionales sobre la direccion de la empresa asociada al Proveedor a insertar supera los 100 caracteres.") ; }
                        # endregion >>------------------------------------
                        int ID_Proveedor = Convert.ToInt32(
                        Ejecutar
                        (
                                "insert into Proveedores( Nombre_Empresa, Email_Empresa)\n" +
                                "values( @Nombre_Empresa, @Email_Empresa ) ;\n" +
                                "select LAST_INSERT_ID() ;",
                                Tipos_Comando_Sql.Query_Escalar,
                                ( new string[] { "@Nombre_Empresa", "@Email_Empresa" } ),
                                ( new object[] { Nombre_Empresa, Email_Empresa } ),
                                Conforma_Transaccion_Manual
                        )
                        ) ;
                        Ejecutar
                        (
                                "insert into Direccion_Empresa_Proveedor ( ID_Proveedor, Barrio, Calle1, Calle2, Indicaciones )\n" +
                                "values( @ID_Proveedor, @Barrio, @Calle1, @Calle2, @Indicaciones ) ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@ID_Proveedor", "@Barrio", "@Calle1", "@Calle2", "@Indicaciones" } ),
                                ( new object[] { ID_Proveedor, Barrio, Calle1, Calle2, Indicaciones! } ),
                                Conforma_Transaccion_Manual

                        ) ; 

                        return ID_Proveedor ;
                }
                # endregion ------------------------
                # region >>---- Getters de las Capas y de Sujetos


                /// <summary>
                /// Devuelve los atributos de una capa Persona asociada a una determinada capa Usuario.
                /// </summary>
                /// <param name="Nombre_Identificador_Usuario">El Nombre_Identificador del Usuario asoicado a la Persona.</param>
                /// <returns>
                /// Devuelve un array de strings, los cuales representan los atributos de la Persona.
                /// Formato: * ID = string[0]
                ///          * Nombre = string[1]
                ///          * Apellido = string[2]
                ///          * Telefono = string[3]
                /// 
                /// La ID es un int representado como string.
                /// </returns>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static string[]? Get_Atributos_Persona( string Nombre_Identificador_Usuario )
                {
                        string[]? Atributos_Persona ;
                        object? ID_Persona ; // La ID de la Persona en forma de objeto. Su clase subyacente es `int`.
                        DataTable? DataTable_Persona ; // La Persona devuelta en forma de DataTable. Deberia constar de una unica fila.
                        DataRow Persona ; // La Persona devuelta en forma de DataRow.

                        ID_Persona =
                        Ejecutar
                        ( 
                            "select ID_Persona from Sujetos where Nombre_Identificador_Usuario = @Nombre_Identificador_Usuario ;",
                            Tipos_Comando_Sql.Query_Escalar,
                            Unico_Parametro_Query: "@Nombre_Identificador_Usuario",
                            Unico_Argumento_Query: Nombre_Identificador_Usuario
                        ) ;

                        if ( ID_Persona is null || Convert.IsDBNull( ID_Persona ) ) { throw new Exception($"No se encontro una Persona para el Usuario `{ ID_Persona }`.") ; }
                        DataTable_Persona = ( DataTable? )
                        Ejecutar
                        (
                            "select * from Personas where ID = @ID_Persona ;",
                            Tipos_Comando_Sql.Query,
                            Unico_Parametro_Query: "@ID_Persona",
                            Unico_Argumento_Query: ( ID_Persona.ToString() )
                        ) ;

                        if ( DataTable_Persona is null ) { throw new Exception($"No se encontro una Persona que corresponda a una determinada ID de Persona, esto es un error grave. No se encontro una Persona para la ID de Persona `{ ( int ) ID_Persona }`.\n") ; }
                        if ( DataTable_Persona.Rows.Count != 1 )
                        { 
                                Console.WriteLine
                                (
                                    $"Una ID de Persona no esta asociada a una unica capa Persona. Esto es un error grave. Para la misma ID de Persona se encontraron `{ DataTable_Persona.Rows.Count }` Personas.\n" +
                                    $"Se mostrara el resultado de la query que da lugar a esta excepcion...\n"
                                ) ;
                                Mostrar_Tabla( DataTable_Persona ) ;
                                throw new Exception() ;
                        }

                        Persona = DataTable_Persona.Rows[0] ;
                        Atributos_Persona = new string[]
                        {
                                Persona["ID"].ToString()!,
                                Persona["Nombre"].ToString()!,
                                Persona["Apellido"].ToString()!,
                                Persona["Telefono"].ToString()!
                        } ;

                        return Atributos_Persona ;
                }

                /// <summary>
                /// Devuelve los atributos de una capa Usuario.
                /// </summary>
                /// <param name="Nombre_Identificador_Usuario">El Nombre_Identificador del Usuario.</param>
                /// <returns>
                /// Devuelve un array de strings, los cuales representan los atributos del Usuario.
                /// Formato: * Nombre_Identificador = string[0]
                ///          * Contrasena = string[1]
                ///          * Nivel_Confidencialidad = string[2]
                ///          * Inactivo = string[3]
                /// 
                /// El atributo `Inactivo` es un valor booleano representado como string. Por ejemplo, si el valor es true, entonces el atributo sera "true".
                /// </returns>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static string[]? Get_Atributos_Usuario( string Nombre_Identificador_Usuario )
                { 
                        DataTable? DataTable_Usuario_Devuelto ;
                        DataRow Usuario_Devuelto ;
                        string[] Atributos_Usuario_Devuelto ;

                        string Nombre_Identificador_Devuelto ;
                        string Contrasena_Devuelta ;
                        string Nivel_Confidencialidad_Devuelto ;
                        string Inactivo_Devuelto ;
                        
                        DataTable_Usuario_Devuelto = ( DataTable? )
                        Ejecutar
                        (
                            "select * from Usuarios where Nombre_Identificador = @Nombre_Identificador ;",
                            Tipos_Comando_Sql.Query, "@Nombre_Identificador",
                            Nombre_Identificador_Usuario
                        ) ;
                        if ( DataTable_Usuario_Devuelto is null ) { return null ; }
                        if ( DataTable_Usuario_Devuelto.Rows.Count == 0 ) { return null ; }
                        if ( DataTable_Usuario_Devuelto.Rows.Count != 1 ) { throw new Exception($"La query que consigue el Sujeto asociados a un determinado Nombre_Identificador devolvio { DataTable_Usuario_Devuelto.Rows.Count } Usuarios. Esto es un error grave.") ; }
                        
                        Usuario_Devuelto = DataTable_Usuario_Devuelto.Rows[0] ;
                        Nombre_Identificador_Devuelto = Usuario_Devuelto["Nombre_Identificador"].ToString()! ;
                        Contrasena_Devuelta = Usuario_Devuelto["Contrasena"].ToString()! ;
                        Nivel_Confidencialidad_Devuelto = Usuario_Devuelto["Nivel_Confidencialidad"].ToString()! ;
                        Inactivo_Devuelto = ( ( UInt64 ) Usuario_Devuelto["Inactivo"] == 0 ) ? "true" : "false" ;

                        Atributos_Usuario_Devuelto = new string[]
                        {
                                Nombre_Identificador_Devuelto,
                                Contrasena_Devuelta,
                                Nivel_Confidencialidad_Devuelto,
                                Inactivo_Devuelto
                        } ;

                        return Atributos_Usuario_Devuelto ;
                }

                /// <summary>
                /// Devuelve los atributos de una capa Empleado asociada a una determinada capa Usuario.
                /// </summary>
                /// <param name="Nombre_Identificador_Usuario">El Nombre_Identificador del Usuario asoicado a el Empleado.</param>
                /// <returns>
                /// Devuelve un array de strings, los cuales representan los atributos del Empleado.
                /// Formato: * ID = string[0]
                ///          * Horas_Trabajadas = string[1]
                ///          * Tarea = string[2]
                ///          * Otra Tarea = string[2...]
                /// 
                /// La ID es un int representado como string.
                /// </returns>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static string[]? Get_Atributos_Empleado( string Nombre_Identificador_Usuario )
                {
                        string[]? Atributos_Empleado ; // Los atributos del Empleado devuelto.
                        object? ID_Empleado ; // La ID del Empleado encontrado, su tipo subyacente es int.
                        DataTable? DataTable_Empleado ; // El Empleado devuelto en forma de DataTable. De contener algo, deberia contener una unica fila.
                        DataTable? Tareas_Empleado ; // Contiene las tareas del Empleado, si es que tiene.
                        
                        void Compilar_Atributos_Empleado()
                        { // Junta los atributos del Empleado y los pone en el array `Atributos_Empleado`.
                                DataRow Empleado ; // El Empleado devuelto en forma de DataRow.
                                int Cantidad_Atributos_Empleado ; // La cantidad de atributos que se compilaran.
                                bool Empleado_Tiene_Tareas ;

                                Empleado = DataTable_Empleado.Rows[0] ;
                                Empleado_Tiene_Tareas = ( Tareas_Empleado is not null ) ? true : false ;
                                Cantidad_Atributos_Empleado = ( ! Empleado_Tiene_Tareas ) ? 2 : ( 2 + Tareas_Empleado!.Rows.Count ) ;

                                { // Compila los atributos basicos de un empleado
                                        Atributos_Empleado = new string[ Cantidad_Atributos_Empleado ] ;
                                        Atributos_Empleado[0] = Empleado["ID"].ToString()! ;
                                        Atributos_Empleado[1] = Empleado["Horas_Trabajadas"].ToString()! ;
                                }
                                if ( ! Empleado_Tiene_Tareas ) { return ; }
                                { // Compila las tareas del empleado
                                        int Indice_Atributo_Tarea ; // El indice que tendra una tarea en el array de atributos del Empleado.
                                        Indice_Atributo_Tarea = 2 ;
                                        foreach ( DataRow Fila_Tarea in Tareas_Empleado!.Rows ) { Atributos_Empleado[ Indice_Atributo_Tarea ] = Fila_Tarea["Tarea"].ToString()! ; Indice_Atributo_Tarea++ ; }
                                }
                        }

                        { // Busca al Empleado especificado. En caso de no encontrarlo retorna null. Consiguiendo todos sus datos en el proceso.
                                ID_Empleado =
                                Ejecutar
                                (
                                    "select ID_Empleado from Sujetos where Nombre_Identificador_Usuario = @Nombre_Identificador_Usuario ;",
                                    Tipos_Comando_Sql.Query_Escalar,
                                    Unico_Parametro_Query: "@Nombre_Identificador_Usuario",
                                    Unico_Argumento_Query: Nombre_Identificador_Usuario
                                ) ;

                                if ( ID_Empleado is null ) { return null ; /* throw new ArgumentException($"No se encontro un Sujeto para el Nombre_Identificador `{ Nombre_Identificador_Usuario }`") ;*/ }

                                DataTable_Empleado = ( DataTable? )
                                Ejecutar
                                (
                                   "select * from Empleados where ID = @ID_Empleado ;",
                                   Tipos_Comando_Sql.Query,
                                   Unico_Parametro_Query: "@ID_Empleado",
                                   Unico_Argumento_Query: ID_Empleado.ToString()!
                                ) ;

                                if ( DataTable_Empleado is null ) { throw new Exception($"No se encontro ningun Empleado asociado a la ID de Empleado `{ ID_Empleado }`. Esto es un error grave.") ; }
                                if ( DataTable_Empleado.Rows.Count != 1 )
                                {
                                        Console.WriteLine("Una query para la ID de un Proveedor no arrojo un unico Proveedor. Esto es un error grave.\rResultado de la query:") ;
                                        Mostrar_Tabla( DataTable_Empleado ) ;
                                        throw new Exception() ;        
                                }

                                Tareas_Empleado = ( DataTable? )
                                Ejecutar
                                (
                                   "select Tarea from Tareas_Empleado where ID_Empleado = @ID_Empleado;",
                                   Tipos_Comando_Sql.Query,
                                   Unico_Parametro_Query: "@ID_Empleado",
                                   Unico_Argumento_Query: ID_Empleado.ToString()!
                                ) ;
                        }

                        Compilar_Atributos_Empleado() ;
                        return Atributos_Empleado ;
                }

                /// <summary>
                /// Devuelve los atributos de una capa Proveedor asociada a una determinada capa Usuario.
                /// </summary>
                /// <param name="Nombre_Identificador_Usuario">Nombre_Identificador del Usuario asociado al Proveedor.</param>
                /// <returns>
                /// Devuelve un array de strings que representa los atributos de un Proveedor.
                /// Formato: * ID_Proveedor = string[0]
                ///          * Nombre_Empresa = string[1]
                /// El Nombre_Empresa puede o no ser null.
                /// </returns>
                /// <exception cref="Exception">Ocurrio una aparente violacion a la integridad de la base de datos.</exception>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static string[]? Get_Atributos_Proveedor( string Nombre_Identificador_Usuario )
                {
                        string[]? Atributos_Proveedor ;
                        object? ID_Proveedor ;
                        DataTable? DataTable_Proveedor ;
                        DataRow Proveedor ;

                        ID_Proveedor =
                        Ejecutar
                        (
                            "select ID_Proveedor from Sujetos where Nombre_Identificador_Usuario = @Nombre_Identificador_Usuario ;",
                            Tipos_Comando_Sql.Query_Escalar,
                            Unico_Parametro_Query: "@Nombre_Identificador_Usuario",
                            Unico_Argumento_Query: Nombre_Identificador_Usuario
                        ) ;


                        if ( ID_Proveedor is null ) { return null ; /* throw new Exception($"No se encontro un Sujeto para el Nombre_Identififcador `{ Nombre_Identificador_Usuario }`.") */ ; }
                        if ( Convert.IsDBNull( ID_Proveedor ) ) { return null ; }
                        DataTable_Proveedor = ( DataTable? ) 
                        Ejecutar
                        (
                            "select * from Proveedores where ID = @ID_Proveedor ;",
                            Tipos_Comando_Sql.Query,
                            Unico_Parametro_Query: "@ID_Proveedor",
                            Unico_Argumento_Query: ID_Proveedor.ToString()!
                        ) ;
                        
                        if ( DataTable_Proveedor is null ) { throw new Exception($"No se encontro un Proveedor para la ID de Proveedor `{ ID_Proveedor }`") ; } // La documentacion dice que SqlCommand.ExecuteScalar devuelve null.... En realidad devuelve DBNull. Jajajaja voy a prender fuego a los de microsoft
                        if ( DataTable_Proveedor.Rows.Count == 0 ) { return null ; }
                        if ( DataTable_Proveedor.Rows.Count != 1 ) { throw new Exception($"Se encontraron `{ DataTable_Proveedor.Rows.Count }` para la ID de Proveedor `{ ID_Proveedor }`. Esto es un error grave.") ; }

                        Proveedor = DataTable_Proveedor.Rows[0] ;
                        
                        Atributos_Proveedor = new string[]
                        {
                                Proveedor["ID"].ToString()!,
                                Proveedor["Nombre_Empresa"].ToString()!
                        } ;

                        return Atributos_Proveedor ;
                }

                /// <summary>
                /// Devuelve los atributos de las capas de un Sujeto con capa de Usuario, a partir del Nombre_Identificador del mismo.
                /// 
                /// 
                /// Dentro de cada array se encuentran los atributos en orden.
                /// </summary>
                /// <param name="Nombre_Identificador_Usuario"></param>
                /// <returns>
                /// Devuelve una estructura del tipo `Representacion_Sujeto`.
                /// Como recordatorio....
                /// Formato:
                ///             Representacion_Sujeto.Atributos_Persona[]
                ///             Representacion_Sujeto.Atributos_Usuario[]
                ///             Representacion_Sujeto.Atributos_Empleado[]
                ///             Representacion_Sujeto.Atributos_Proveedor[]
                ///             
                /// El formato de cada array esta definido en la descripcion del metodo que consigue a cada uno. 
                /// </returns>

                #endregion
                # region >>---- Checks
                /// <summary>
                /// Comprueba si existe un Sujeto asociado a un determinado Usuario asociado a un Nombre_Identificador pasado como argumento.
                /// </summary>
                /// <param name="Nombre_Identificador_Usuario">El Nombre_Identificador de un supuesto Usuario, el cual estaria o no asociado a un Sujeto.</param>
                /// <returns>Devuelve true si un Sujeto coincidio. Devuelve false si no coincidio ningun Sujeto.</returns>
                /// <exception cref="Exception">Se encontro mas de 1 Sujeto coincidente. Esto seria un error grave por parte de la base de datos.</exception>
                public static bool Sujeto_Existe( string Nombre_Identificador_Usuario )
                {
                        bool Sujeto_Existe ;
                        DataTable? Resultado_Query ;

                        Resultado_Query = ( DataTable? )
                        Interfaz_Base_Datos.
                                Ejecutar
                                ( 
                                    "select * from Sujetos where Nombre_Identificador_Usuario = @Nombre_Identificador_Usuario ;",
                                    Tipos_Comando_Sql.Query,
                                    Unico_Parametro_Query: "@Nombre_Identificador_Usuario",
                                    Unico_Argumento_Query: Nombre_Identificador_Usuario
                                ) ;
                         
                        Sujeto_Existe = ( Resultado_Query is not null ) ? true : false ;
                        if ( Sujeto_Existe )
                        { 
                                if ( Resultado_Query.Rows.Count != 1 ) { throw new Exception($"Se encontraron `{ Resultado_Query.Rows.Count}` Sujetos para el Nombre_Identificador `{ Nombre_Identificador_Usuario }`.") ; }
                                return true ;
                        }
                        return false ;
                }
                public static bool Nombre_Identificador_Ya_Existente( string Nombre_Identificador ) { return Convert.ToBoolean( Ejecutar( "select exists( select * from Usuarios where Nombre_Identificador = @Nombre_Identificador ) ;", Tipos_Comando_Sql.Query_Escalar, "@Nombre_Identificador", Nombre_Identificador ) ) ; }
                # endregion

                // Elementos Subasta
                # region >>---- Ordenes de Elementos de Subasta
                public static int? Insert_Elemento_Subasta( object? Precio_Base, object? Valor, object Habilitado, bool Devolver_Last_Insert_ID = false, bool Conforma_Transaccion_Manual = false )
                { 
                        int Last_Insert_ID ;
                        
                        Last_Insert_ID = Convert.ToInt32(
                                Ejecutar
                                (
                                        "insert into Elementos_Subasta\n" +
                                        "( Precio_Base, Valor, Habilitado ) \n" +
                                        "values( @Precio_Base, @Valor, @Habilitado ) \n" +
                                        ( ( Devolver_Last_Insert_ID ) ? "; select Last_Insert_ID() ;" : ";" ),
                                        ( ( Devolver_Last_Insert_ID ) ? Tipos_Comando_Sql.Query_Escalar : Tipos_Comando_Sql.No_Query ),
                                        Parametros_Query: ( new string[] { "@Precio_Base", "@Valor", "@Habilitado" } ),
                                        Argumentos_Query: ( new object[] { Precio_Base!, Valor!, Habilitado } ),
                                        Conforma_Transaccion_Manual
                                )
                        ) ;

                        if ( Devolver_Last_Insert_ID ) { return Last_Insert_ID ; }
                        else { return null ; }
                }
                public static void Update_Elemento_Subasta( object? Valor, object? Precio_Base, object Habilitado, object ID, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                             "update Elementos_Subasta\n" +
                             "set\n" +
                             "Valor = @Valor,\n" +
                             "Precio_Base = @Precio_Base,\n" +
                             "Habilitado = @Habilitado\n" +
                             "where ID = @ID ;",
                             Tipo_Comando_Sql_Seleccionado: Tipos_Comando_Sql.No_Query,
                             Parametros_Query: ( new string[] { "@Valor", "@Precio_Base", "@Habilitado", "@ID" } ),
                             Argumentos_Query: ( new object[] { Valor!, Precio_Base!, Habilitado, ID } ),
                             Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Delete_Elemento_Subasta( int ID_Producto, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Elementos_Subasta where ID = @ID_Producto ;", Tipos_Comando_Sql.No_Query, Unico_Parametro_Query: "@ID_Producto", ID_Producto, Conforma_Transaccion_Manual ) ; }
                public static void Insert_Elemento_Subasta_Proveedor( object ID_Proveedor, object ID_Elemento_Subasta, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        ( 
                                "insert into Elementos_Subasta_Proveedor( ID_Proveedor, ID_Elemento_Subasta )\n" +
                                "values( @ID_Proveedor, @ID_Elemento_Subasta ) ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@ID_Proveedor", "@ID_Elemento_Subasta" } ),
                                ( new object[] { ID_Proveedor, ID_Elemento_Subasta } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                # endregion
                # region >>---- Queries
                public static Dictionary< string, object? >? Get_Elemento_Subasta( int ID )
                { 
                        DataTable? Elemento_Subasta_DataTable = ( DataTable? )
                        Ejecutar( "select * from Elementos_Subasta where ID = @ID ;", Tipos_Comando_Sql.Query, "@ID", ID ) ;

                        if ( Elemento_Subasta_DataTable is null ) { return null ; }
                        DataRow Valores = Elemento_Subasta_DataTable.Rows[0] ;

                        Dictionary< string, object? > Elemento_Subasta = new Dictionary< string, object? >() ;
                        Elemento_Subasta["Valor"] = Valores["Valor"] ;
                        Elemento_Subasta["Precio_Base"] = Valores["Precio_Base"] ;
                        Elemento_Subasta["Habilitado"] = Valores["Habilitado"] ;

                        return Elemento_Subasta ;
                }
                # endregion

                // Jerarquia de Productos
                # region >>---- Inserts de jerarquia de Productos
                public static void Insert_Producto( object ID, object? Nombre, object? Descripcion, bool Conforma_Transaccion_Manual = false )
                {
                        // La tabla que tiene el autoincrement deberia ser la que tiene la clave no-foranea no?
                        Ejecutar
                        (
                                "insert into Productos\n" +
                                "( ID_Elemento_Subasta, Nombre, Descripcion ) \n" +
                                "values ( @ID, @Nombre, @Descripcion ) ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@ID", "@Nombre", "@Descripcion" } ),
                                Argumentos_Query: ( new object[] { ID, Nombre!, Descripcion! } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Insert_Animal( object ID, object Sexo, object Edad, object? Raza, object Peso, object Esta_Castrado, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "insert into Animales\n" +
                                "( ID_Producto, Sexo, Edad, Raza, Peso, Esta_Castrado ) \n" +
                                "values ( @ID, @Sexo, @Edad, @Raza, @Peso, @Esta_Castrado ) ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@ID", "@Sexo", "@Edad", "@Raza", "@Peso", "@Esta_Castrado" } ),
                                Argumentos_Query: ( new object[] { ID, Sexo, Edad, Raza!, Peso, Esta_Castrado } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Insert_Maquinaria( object ID_Maquinaria, object Marca, object Modelo, object Numero_Serie, object No_Tiene_Uso, object Historial_Propiedad, object Tipo_Maquinaria, object Ano_Adquisicion, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                            "insert into Maquinaria\n" +
                            "( ID_Producto, Marca, Modelo, Numero_Serie, No_Tiene_Uso, Historial_Propiedad, Tipo_Maquinaria, Ano_Adquisicion ) \n" +
                            "values ( @ID_Maquinaria, @Marca, @Modelo, @Numero_Serie, @No_Tiene_Uso, @Historial_Propiedad, @Tipo_Maquinaria, @Ano_Adquisicion ) ;",
                            Tipos_Comando_Sql.No_Query,
                            Parametros_Query: ( new string[] { "@ID_Maquinaria", "@Marca", "@Modelo", "@Numero_Serie", "@No_Tiene_Uso", "@Historial_Propiedad", "@Tipo_Maquinaria", "@Ano_Adquisicion" } ),
                            Argumentos_Query: ( new object[] { ID_Maquinaria, Marca, Modelo, Numero_Serie, No_Tiene_Uso, Historial_Propiedad, Tipo_Maquinaria, Ano_Adquisicion } ),
                            Conforma_Transaccion_Manual
                        ) ; 
                }
                public static void Insert_Vacuno( object ID_Vacuno, object Especializacion_Vacuna, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                            "insert into Vacunos\n" +
                            "( ID_Animal, Especializacion_Vacuna ) \n" +
                            "values ( @ID_Vacuno, @Especializacion_Vacuna ) ;",
                            Tipos_Comando_Sql.No_Query,
                            Parametros_Query: ( new string[] { "@ID_Vacuno", "@Especializacion_Vacuna" } ),
                            Argumentos_Query: ( new object[] { ID_Vacuno, Especializacion_Vacuna } ),
                            Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Insert_Equino( object ID_Equino, object Especializacion_Equina, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "insert into Equinos\n" +
                                "( ID_Animal, Especializacion_Equina ) " +
                                "values ( @ID_Equino, @Especializacion_Equina ) ;\n",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@ID_Equino", "@Especializacion_Equina" } ),
                                Argumentos_Query: ( new object[] { ID_Equino, Especializacion_Equina } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Insert_Ovino( object ID_Ovino, object Especializacion, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                            "insert into Ovinos\n" +
                            "( ID_Animal, Especializacion_Ovina ) \n" +
                            "values( @ID_Ovino, @Especializacion_Ovina ) ;",
                            Tipos_Comando_Sql.No_Query,
                            Parametros_Query: ( new string[] { "@ID_Ovino", "@Especializacion_Ovina" } ),
                            Argumentos_Query: ( new object[] { ID_Ovino, Especializacion } ),
                            Conforma_Transaccion_Manual
                        ) ;        
                }

                public static void Insert_Fotos_Producto( object ID_Producto, byte[][] Fotos_Producto, bool Conforma_Transaccion_Manual = false )
                {
                        foreach ( byte[] Foto in Fotos_Producto )
                        { 
                                Ejecutar
                                (
                                        "insert into Fotos_Producto\n" +
                                        "( ID_Producto, Bytes_Foto )" +
                                        "values ( @ID, @Foto ) ;",
                                        Tipos_Comando_Sql.No_Query,
                                        Parametros_Query: ( new string[] { "@ID", "@Foto" } ),
                                        Argumentos_Query: ( new object[] { ID_Producto, Foto } ),
                                        Conforma_Transaccion_Manual
                                ) ;
                        }
                }
                # endregion
                # region >>---- Updates de jerarquia de Productos
                public static void Update_Producto( object? Nombre, object? Descripcion, object ID, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                            "update Productos\n" +
                            "set\n" +
                            "Nombre = @Nombre,\n" +
                            "Descripcion = @Descripcion\n" +
                            "where ID_Elemento_Subasta = @ID ;",
                            Tipo_Comando_Sql_Seleccionado: Tipos_Comando_Sql.Query,
                            Parametros_Query: ( new string[] { "@Nombre", "@Descripcion", "@ID" } ),
                            Argumentos_Query: ( new object[] { Nombre!, Descripcion!, ID } ),
                            Conforma_Transaccion_Manual
                        ) ;        
                }
                public static void Update_Animal( object Sexo, object Edad, object? Raza, object Peso, object Esta_Castrado, object ID, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                                "update Animales\n" +
                                "set\n" +
                                "Sexo = @Sexo,\n" +
                                "Edad = @Edad,\n" +
                                "Raza = @Raza,\n" +
                                "Peso = @Peso,\n" +
                                "Esta_Castrado = @Esta_Castrado\n" +
                                "where ID_Producto = @ID ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@Sexo", "@Edad", "@Raza", "@Peso", "@Esta_Castrado", "@ID" } ),
                                Argumentos_Query: ( new object[] { Sexo, Edad, Raza!, Peso, Esta_Castrado, ID } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Update_Maquinaria( object Marca, object Modelo, object Numero_Serial, object Es_Nueva, object Historial_Propiedad, object Tipo_Maquinaria, object Ano_Adquisicion, object ID, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                                "update Maquinaria\n" +
                                "set\n" +
                                "Marca = @Marca,\n" +
                                "Modelo = @Modelo,\n" +
                                "Numero_Serie = @Numero_Serial,\n" +
                                "No_Tiene_Uso = @Es_Nueva,\n" +
                                "Historial_Propiedad = @Historial_Propiedad,\n" +
                                "Tipo_Maquinaria = @Tipo_Maquinaria,\n" +
                                "Ano_Adquisicion = @Ano_Adquisicion\n" +
                                "where ID_Producto = @ID ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@Marca", "@Modelo", "@Numero_Serial", "@Es_Nueva", "@Historial_Propiedad", "@Tipo_Maquinaria", "@Ano_Adquisicion", "@ID" } ),
                                Argumentos_Query: ( new object[] { Marca, Modelo, Numero_Serial, Es_Nueva, Historial_Propiedad, Tipo_Maquinaria, Ano_Adquisicion, ID } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Update_Vacuno( object Especializacion, object ID_Vacuno, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                                "update Vacunos\n" +
                                "set\n" +
                                "Especializacion_Vacuna = @Especializacion_Vacuna\n" +
                                "where ID_Animal = @ID_Vacuno ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@Especializacion_Vacuna", "@ID_Vacuno" } ),
                                Argumentos_Query: ( new object[] { Especializacion, ID_Vacuno } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Update_Equino( object Especializacion, object ID, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "update Equinos\n" +
                                "set\n" +
                                "Especializacion_Equina = @Especializacion_Equina\n" +
                                "where ID_Animal = @ID ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@Especializacion_Equina", "@ID" } ),
                                Argumentos_Query: ( new object[] { Especializacion, ID } ),
                                Conforma_Transaccion_Manual

                        ) ;
                }
                public static void Update_Ovino( object Especializacion, object ID, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                                "update Ovinos\n" +
                                "set\n" +
                                "Especializacion_Ovina = @Especializacion_Ovina\n" +
                                "where ID_Animal = @ID ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@Especializacion_Ovina", "@ID" } ),
                                Argumentos_Query: ( new object[] { Especializacion, ID } ),
                                Conforma_Transaccion_Manual
                        ) ;        
                }
                # endregion
                # region >>---- Deletes de jerarquias de Productos
                /// <summary>
                /// Elimina el registro de la tabla Animales el cual coincida con la ID proporcionada.
                /// Se cuidadoso, ya que eliminar un registro de la tabla de Animales gatillara un borrado en cascada de las subclases de tal Animal.
                /// Pero no borra a las super entidades asociadas a tal Animal.
                /// </summary>
                /// <param name="ID_Animal">La ID del Animal a borrar.</param>
                public static void Eliminar_Animal( int ID_Animal, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Animales where ID_Producto = @ID_Animal ;", Tipos_Comando_Sql.No_Query, Unico_Parametro_Query: "@ID_Animal", Unico_Argumento_Query: ID_Animal, Conforma_Transaccion_Manual ) ; }
                /// <summary>
                /// Elimina el registro de la tabla Maquinaria el cual coincida con la ID proporcionada.
                /// </summary>
                /// <param name="ID_Maquinaria">La ID de la Maquinaria a borrar.</param>
                public static void Eliminar_Maquinaria( int ID_Maquinaria, bool Conforma_Transaccion_Manual = true ) { Ejecutar( "delete from Maquinaria where ID_Producto = @ID_Maquinaria ;", Tipos_Comando_Sql.No_Query, Unico_Parametro_Query: "@ID_Maquinaria", Unico_Argumento_Query: ID_Maquinaria, Conforma_Transaccion_Manual ) ; }
                public static void Delete_Producto( int ID_Producto, bool Conforma_Transaccion_Manual = false) { Ejecutar( "delete from Productos where ID_Elemento_Subasta = @ID_Producto ;", Tipos_Comando_Sql.No_Query, "@ID_Producto", ID_Producto, Conforma_Transaccion_Manual ) ; }
                public static void Delete_Vacuno( int ID_Vacuno, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Vacunos where ID_Animal = @ID_Vacuno ;", Tipos_Comando_Sql.No_Query, "@ID_Vacuno", ID_Vacuno, Conforma_Transaccion_Manual ) ; }
                public static void Delete_Equino( int ID_Equino, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Equinos where ID_Animal = @ID_Equino ;", Tipos_Comando_Sql.No_Query, "@ID_Equino", ID_Equino, Conforma_Transaccion_Manual ) ; }
                public static void Delete_Ovino( int ID_Ovino, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Ovinos where ID_Animal = @ID_Ovino ;", Tipos_Comando_Sql.No_Query, "@ID_Ovino", ID_Ovino, Conforma_Transaccion_Manual ) ; }
                # endregion
                # region >>---- Checks jerarquia de Productos
                public static bool Animal_Existe( int ID_Animal, bool Conforma_Transaccion_Manual = false )
                {
                        bool Animal_Existe ;

                        Animal_Existe = Convert.ToBoolean(
                        Ejecutar ( "select exists( select * from Animales where ID_Producto = @ID_Animal ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Animal", ID_Animal, Conforma_Transaccion_Manual )
                        ) ;

                        return Animal_Existe ;
                }
                public static bool Maquinaria_Existe( int ID_Maquinaria, bool Conforma_Transaccion_Manual = false )
                { 
                        bool Maquinaria_Existe ;

                        Maquinaria_Existe = Convert.ToBoolean(
                        Ejecutar( "select exists( select * from Maquinaria where ID_Producto = @ID_Maquinaria ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Maquinaria", ID_Maquinaria, Conforma_Transaccion_Manual )         
                        ) ;

                        return Maquinaria_Existe ;
                }
                public static bool Vacuno_Existe( int ID_Vacuno, bool Conforma_Transaccion_Manual = false )
                {
                        bool Vacuno_Existe ;

                        Vacuno_Existe = Convert.ToBoolean(
                        Ejecutar ( "select exists( select * from Vacunos where ID_Animal = @ID_Vacuno ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Vacuno", ID_Vacuno, Conforma_Transaccion_Manual ) 
                        ) ;

                        return Vacuno_Existe ;
                }
                public static bool Equino_Existe( int ID_Equino, bool Conforma_Transaccion_Manual = false )
                {
                        bool Equino_Existe ;

                        Equino_Existe = Convert.ToBoolean(
                        Ejecutar( "select exists( select * from Equinos where ID_Animal = @ID_Equino ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Equino", ID_Equino, Conforma_Transaccion_Manual )        
                        ) ;

                        return Equino_Existe ;
                }
                public static bool Ovino_Existe( int ID_Ovino, bool Conforma_Transaccion_Manual = false )
                { 
                        bool Ovino_Existe ;
                        
                        Ovino_Existe =   Convert.ToBoolean(
                        Ejecutar( "select exists( select * from Ovinos where ID_Animal = @ID_Ovino ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Ovino", ID_Ovino, Conforma_Transaccion_Manual )         
                        ) ;

                        return Ovino_Existe ;
                }

                /*  Es posible que te preguntes...
                 *  "Por que implementar la opcion de hacer estos checks como parte de una transaccion? Realmente es lo mimo si estan fuera o dentro de una."
                 *  Pues es por algo interesante... Ejecutar un comando con el conector de MySQL es totalmente sincronico. Una vez se ejecuta la sentencia,
                 *  la base de datos se pone en marcha para ejecutar el comando. Sin embargo... Esto tiene una triquinuela, la ejecucion de los comandos es sincronica
                 *  dentro de una misma conexion abierta. A menos que se le pase el parametro `Conforma_Transaccion_Manual` como verdadero, el metodo `Ejecutar`, abre
                 *  una conexion por sentencia para la base de datos. Esto te deja a pensar que como la ejecucion del metodo es sincronica, y la base de datos ejecuta
                 *  las sentencias de forma sincronica, entonces la base de datos y el programa estan en sincronia. Bueno...
                 *  La triquinuela de las conexiones es que no necesariamente se crean una despues de la otra. Si esto ocurre o no, depende de en que orden lleguen las
                 *  sentencias a la base de datos, sin embargo, el orden en que les llega, depende del reloj de la base de datos, y del reloj del cliente. El tema es q
                 *  ue si bien estos relojes son muy muy precisos, no son perfectos, y generalmente no estan en sincronia. Por lo que lei, el reloj de MySQL suele tene
                 *  r una diferencia de 5 a 10 fracciones de tiempo respecto al cliente. Esto depende de hardware y demas pero el punto es que mientras mas empujes la
                 *  ventana de demora entre conexion y conexion, es mas y mas posible que termine por llegar una sentencia en un orden inesperado. Por lo que vi, esto 
                 *  se puede empezar a tornar en un problema cuando empiezas a abrir y cerrar conexiones con una diferencia de aproxiamdamente 15 milisegundos. Debido
                 *  a la naturaleza del metodo `Ejecutar` esto podria llegar a pasar. Perfilando un poco el metodo llegue a ver que algunas veces llega a 7 milisegundo
                 *  s entre ejecucion y ejecucion. Entonces la manera menos rocambolezca de protejer contra una de estas fallas es meter las sentencias que sea 100% ne
                 *  cesario que se ejecuten en orden en una transaccion especialmente si estan demasiado cerca. 
                 */
                #endregion
                #region >>---- Queries
                public static DataTable? Get_Maquinaria( int ID_Maquinaria )
                { 
                        DataTable? Datos_Maquinaria ;

                        Datos_Maquinaria = ( DataTable? )
                        Ejecutar
                        (
                            "select * from Maquinaria where ID_Producto = @ID_Maquinaria ;",
                            Tipos_Comando_Sql.Query,
                            Unico_Parametro_Query: "@ID_Maquinaria",
                            Unico_Argumento_Query: ID_Maquinaria
                        ) ;

                        if ( Datos_Maquinaria is null ) { return null ; }
                        return Datos_Maquinaria ;
                }
                /// <summary>
                /// Consigue las fotos asociadas a un determinado Producto de la base de datos.
                /// </summary>
                /// <param name="ID_Producto">La ID del Producto del que se quieren las fotos.</param>
                /// <returns>
                /// Si hay fotos asociadas a esa ID de Producto, devuelve un byte[][] representando los bytes de las mismas.
                /// Si NO hay fotos asociadas a esa ID de Producto, devuelve null.
                /// </returns>
                public static byte[][]? Get_Fotos_Producto( int ID_Producto )
                {
                        byte[][] Fotos_Del_Producto ;
                        DataTable? Query_Fotos_producto ;
                        int Cantidad_Fotos_Producto ;

                        Query_Fotos_producto = ( DataTable? )
                        Ejecutar
                        (
                            "select Bytes_Foto from Fotos_Producto where ID_Producto = @ID_Producto ;",
                            Tipos_Comando_Sql.Query,
                            Unico_Parametro_Query: "@ID_Producto",
                            Unico_Argumento_Query: ID_Producto
                        ) ;

                        if ( Query_Fotos_producto is null ) { return null ; }
                        Cantidad_Fotos_Producto = Query_Fotos_producto.Rows.Count ;

                        Fotos_Del_Producto = new byte[ Cantidad_Fotos_Producto ][] ;
                        int Indice_Foto = 0 ;
                        foreach ( DataRow Tupla_Foto in Query_Fotos_producto.Rows )
                        {
                                byte[] Foto_Actual = Tupla_Foto.Field< byte[] >(0)! ;
                                Fotos_Del_Producto[ Indice_Foto ] = Foto_Actual ;

                                Indice_Foto++ ;
                        }

                        return Fotos_Del_Producto ;
                }
                # endregion

                #region >>---- Gestion de el Producto Completo ( Esto realmente deberia ambientarse en la capa Logica )
                // Con `Producto_Completo` me refiero a las suma de todas la asociasion de entidades.
                // Osea, a: El Elemento de Subasta, el Producto, la subclase si la hay (Animal o Maquinaria) y las subclases de que le siguen (Animal> Equino, Vacuno, Ovino, etc).

                public enum Operacion_Gestion
                { 
                       Alta,
                       Baja,
                       Modificacion,

                       // Aliases
                       Crear = Alta,
                       Eliminar = Baja,
                       Modificar = Modificacion
                }


                /// <Summary>Se encarga de modificar un Producto, y toda la informacion que a este corresponde.</Summary>
                /// <param name="Campos_Elemento_Subasta">Continene los campos del Elemento de Subasta asociado a un Producto.</param>
                /// <param name="Campos_Producto">Contiene los campos del Producto + las fotos del mismo si las hay.</param>
                /// <param name="Campos_Animal">Contiene los campos de la subclase del Producto `Animal` + los datos de la subclase de Animal si es que hay una.</param>
                /// <param name="Campos_Maquinaria">Contiene los campos de la subclase del Producto `Maquinaria`.</param>
                public static void Gestion_Producto_Completo
                (
                    Operacion_Gestion Operacion_Seleccionada,
                    Dictionary< string, object? > Campos_Elemento_Subasta, 
                    Dictionary< string, object? > Campos_Producto,
                    Dictionary< string, object? >? Campos_Animal = null,
                    Dictionary< string, object >? Campos_Maquinaria = null,
                    int ID_Proveedor = 1 // ooo
                )
                {
                        // Lo suyo seria hacer que si se selecciono `Baja` entonces no se deban cargar todos los valores al cuete.
                        // Pero ahora mismo no hare eso. Si me sobra tiempo estaria bien.

                        // Campos Elemento_Subasta
                        object ID ;
                        object? Valor ;
                        object? Precio_Base ;
                        object Habilitado ;
                        // Campos Producto
                        object? Nombre ;
                        object? Descripcion ;
                        // Fotos del Producto
                        byte[][] Fotos_Producto = null! ;
                        // Campos Animal
                        object Sexo = null! ;
                        object? Raza = null ;
                        object Edad = null! ;
                        object Peso = null! ;
                        object Esta_Castrado = null! ;
                                // Subclase Animal
                                object? Subclase_Animal_A_Contruir = null ;
                                object Especializacion = null! ;
                        // Campos Maquinaria
                        object Marca = null! ;
                        object Modelo = null! ;
                        object Numero_Serial = null! ;
                        object Historial_Propiedad = null! ;
                        object Tipo_Maquinaria = null! ;
                        object Es_Nueva = null! ;
                        object Ano_Adquisicion = null! ;

                       /* Inicializacion y uso condicional de variables...
                        * El compilador de C# es estatico. Eso significa que decide si el codigo es seguro sin ejecutarlo.
                        * En el caso de estas variables, el compilador es incapaz de ver que solo son declaradas y usadas bajo las mismas condiciones.
                        * Por eso es que algo como:
                        * 
                        * MiVariable ;
                        * if ( Condicion ) { MiVariable = algo ; }
                        * 
                        * if ( Condicion ) { MiVariable.HacerCosas ; }
                        * 
                        * Siempre da error, proque el compilador no evalua las condiciones, solo la estructura del codigo. Solo va a darlo como bueno si
                        * la asignacion y uso se dan en una mismo camino de ejecucion o si se dan en ramas distintas pero que la rama que hace uso de la 
                        * variable depende; o ocurre a partir de la rama que hace la asignacion. Pero no si la asignacion y el uso ocurren en ramas para
                        * lelas, incluso si su naturaleza dicta que si se ejecuta una siempre se ejecutara la otra.
                        * 
                        * Para estructurar el codigo de forma mas sencilla, inicialize las variables relacionadas a las subclase de los productos como null.
                        * De esta manera el codigo se mantiene sencillo y el compilador queda contento. Todos felices.
                        */
                        
                        bool Producto_Tiene_Subclase()
                        {
                                if ( Campos_Animal is not null ) { return true ; }
                                if ( Campos_Maquinaria is not null ) { return true ; }
                                return false ;
                        }

                        void Eliminar_Antiguas_Fotos_Producto( object ID, bool Conforma_Transaccion_Manual = false )
                        { 
                                Ejecutar
                                (
                                        "delete from Fotos_Producto where ID_Producto = @ID ;",
                                        Tipos_Comando_Sql.No_Query,
                                        Unico_Parametro_Query: "@ID",
                                        Unico_Argumento_Query: ID,
                                        Conforma_Transaccion_Manual
                                ) ;
                        }

                        { // Asignacion
                                { // Elemento_Subasta
                                        ID = Campos_Elemento_Subasta["ID"]! ;
                                        Valor = Campos_Elemento_Subasta["Valor"]! ;
                                        Precio_Base = Campos_Elemento_Subasta["Precio_Base"]! ;
                                        Habilitado = Campos_Elemento_Subasta["Habilitado"]! ;
                                }
                        
                                { // Producto
                                        Nombre = Campos_Producto["Nombre"]! ;
                                        Descripcion = Campos_Producto["Descripcion"]! ;
                                        if ( Campos_Producto.ContainsKey("Fotos") ) { Fotos_Producto = ( byte[][] ) Campos_Producto["Fotos"]! ; }
                                }

                                if ( Campos_Animal is not null )
                                { // Animal
                                        Sexo = Campos_Animal["Sexo"]! ;
                                        Raza = Campos_Animal["Raza"]! ;
                                        Edad = Campos_Animal["Edad"]! ;
                                        Peso = Campos_Animal["Peso"]! ;
                                        Esta_Castrado = Campos_Animal["Esta_Castrado"]! ;

                                        // Subclase Animal
                                        Subclase_Animal_A_Contruir = Campos_Animal["Tipo_Animal"]! ;
                                        Especializacion = Campos_Animal["Especializacion"]! ;
                                }

                                if ( Campos_Maquinaria is not null )
                                { // Maquinaria
                                        Marca = Campos_Maquinaria["Marca"]! ;
                                        Modelo = Campos_Maquinaria["Modelo"]! ;
                                        Numero_Serial = Campos_Maquinaria["Numero_Serial"]! ;
                                        Historial_Propiedad = Campos_Maquinaria["Historial_Propiedad"]! ;
                                        Tipo_Maquinaria = Campos_Maquinaria["Tipo_Maquinaria"]! ;
                                        Es_Nueva = Campos_Maquinaria["Es_Nueva"]! ;
                                        Ano_Adquisicion = Campos_Maquinaria["Ano_Adquisicion"]! ;
                                }
                        }

                        
                        int int_ID = Convert.ToInt32( ID ) ;

                        switch ( Operacion_Seleccionada )
                        { 
                                case Operacion_Gestion.Modificacion or Operacion_Gestion.Modificar: goto Actualizar_Producto_Completo ;
                                case Operacion_Gestion.Alta or Operacion_Gestion.Crear: goto Insertar_Producto_Completo ;
                                case Operacion_Gestion.Baja or Operacion_Gestion.Eliminar: goto Eliminar_Producto_Completo ;
                        }

                        Actualizar_Producto_Completo: //------------------------------------
                        Iniciar_Transaccion_Manual() ;
                        Update_Elemento_Subasta( Valor, Precio_Base, Habilitado, ID, true ) ;
                        Update_Producto( Nombre, Descripcion, ID, true ) ;
                        { // Actualizar las Fotos del Producto
                                Eliminar_Antiguas_Fotos_Producto( ID, true ) ;
                                if ( Fotos_Producto is not null ) { Insert_Fotos_Producto( ID, Fotos_Producto, true ) ; }
                        }

                        if ( ! Producto_Tiene_Subclase() )
                        { 
                                Eliminar_Animal( int_ID, true ) ;
                                Eliminar_Maquinaria( int_ID, true ) ;
                                Commit_Transaccion() ;
                                return ;
                        }
                        
                        // Actualizar Maquinaria
                        if ( Campos_Maquinaria is not null )
                        {
                                Eliminar_Animal( int_ID, true ) ;
                                if ( Maquinaria_Existe( int_ID, true ) ) { Update_Maquinaria( Marca, Modelo, Numero_Serial, Es_Nueva, Historial_Propiedad, Tipo_Maquinaria, Ano_Adquisicion, ID, true ) ; }
                                else { Insert_Maquinaria( ID, Marca, Modelo, Numero_Serial, Es_Nueva, Historial_Propiedad, Tipo_Maquinaria, Ano_Adquisicion, true ) ; }
                                Commit_Transaccion() ;
                                return ;
                        }
                        
                        // Actualizar Animal
                        if ( Campos_Animal is not null )
                        {
                                Eliminar_Maquinaria( int_ID, true ) ;
                                if ( Animal_Existe( int_ID, true ) ) { Update_Animal( Sexo, Edad, Raza, Peso, Esta_Castrado, ID, true ) ; }
                                else { Insert_Animal( ID, Sexo, Edad, Raza, Peso, Esta_Castrado, true ) ; }

                                // Actualizar subclase de Animal
                                switch ( Subclase_Animal_A_Contruir )
                                { 
                                        case null:
                                        break ;
                                        case "Vacuno":
                                                Delete_Equino( int_ID, true ) ;
                                                Delete_Ovino( int_ID, true ) ;

                                                if ( Vacuno_Existe( int_ID, true ) ) { Update_Vacuno( Especializacion, ID, true ) ; }
                                                else { Insert_Vacuno( ID, Especializacion, true ) ; }
                                        break ;
                                        case "Equino":
                                                Delete_Vacuno( int_ID, true  ) ;
                                                Delete_Ovino( int_ID, true ) ;

                                                if ( Equino_Existe( int_ID, true ) ) { Update_Equino( Especializacion, ID, true ) ; }
                                                else { Insert_Equino( ID, Especializacion, true ) ; }
                                        break ;
                                        case "Ovino":
                                                Delete_Vacuno( int_ID, true ) ;
                                                Delete_Equino( int_ID, true ) ;

                                                if ( Ovino_Existe( int_ID, true ) ) { Update_Ovino( Especializacion, ID, true ) ; }
                                                else { Insert_Ovino( ID, Especializacion, true ) ; }
                                        break ;
                                        case "Otro":
                                                Delete_Vacuno( int_ID, true ) ;
                                                Delete_Equino( int_ID, true ) ;
                                                Delete_Ovino( int_ID, true ) ;
                                        break ;
                                        // Todo este switch se podria refactorizar en una sentencia if. Ejecutando el metodo `Ejecutar` una sola vez.
                                        // Sin embargo de esta manera lo que ocurre es mas evidente y sencillo de entender.
                                }
                        }
                        Commit_Transaccion() ;
                        return ;

                        Insertar_Producto_Completo: //--------------------------------------
                        Iniciar_Transaccion_Manual() ;
                        object ID_Nuevo_Producto =
                        Insert_Elemento_Subasta( Precio_Base, Valor, Habilitado, Devolver_Last_Insert_ID: true, true )! ;
                        Insert_Elemento_Subasta_Proveedor( ID_Proveedor, ID_Nuevo_Producto, true ) ;
                        Insert_Producto( ID_Nuevo_Producto, Nombre, Descripcion, true ) ;
                        if ( Fotos_Producto is not null ) { Insert_Fotos_Producto( ID_Nuevo_Producto, Fotos_Producto, true ) ; }

                        if ( ! Producto_Tiene_Subclase() ) { Commit_Transaccion() ; return ; }
                        if ( Campos_Animal is not null )
                        {
                                Insert_Animal( ID_Nuevo_Producto, Sexo, Edad, Raza, Peso, Esta_Castrado, true ) ;
                                switch ( Subclase_Animal_A_Contruir )
                                {
                                        case null:
                                        break ;
                                        case "Vacuno": Insert_Vacuno( ID_Nuevo_Producto, Especializacion, true ) ; break ;
                                        case "Equino": Insert_Equino( ID_Nuevo_Producto, Especializacion, true ) ; break ;
                                        case "Ovino": Insert_Ovino( ID_Nuevo_Producto, Especializacion, true ) ; break ;
                                }
                        }

                        if ( Campos_Maquinaria is not null ) { Insert_Maquinaria( ID_Nuevo_Producto, Marca, Modelo, Numero_Serial, Es_Nueva, Historial_Propiedad, Tipo_Maquinaria, Ano_Adquisicion, true ) ; }
                        Commit_Transaccion() ;
                        return ;

                        Eliminar_Producto_Completo: // -------------------------------------
                        // Delete_Producto( int_ID , true ) ; // Ahora las fotos se borran en cascada junto con el resto de cosas
                        Delete_Elemento_Subasta( int_ID ) ;
                        return ;
                }

                #endregion // Esto realmente deberia ambientarse en la capa Logica // Esto realmente deberia ambientarse en la capa Logica

                // Lotes
                #region >>---- Productos de Lote, Productos Libres y No-Libres
                public static void Insert_Producto_Lote( int ID_Lote, int ID_Producto, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "insert into Productos_Lote\n" +
                                "( ID_Lote, ID_Producto ) \n" +
                                "values ( @ID_Lote, @ID_Producto ) ;",
                                Tipos_Comando_Sql.No_Query,
                                Parametros_Query: ( new string[] { "@ID_Lote", "@ID_Producto" } ),
                                Argumentos_Query: ( new object[] { ID_Lote, ID_Producto } ),
                                Conforma_Transaccion_Manual
                        ) ;        
                }
                public static void Delete_Productos_Lote( int ID_Lote, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        ( 
                                "delete from Productos_Lote\n" +
                                "where ID_Lote = @ID_Lote ;",
                                Tipos_Comando_Sql.No_Query,
                                "@ID_Lote",
                                ID_Lote,
                                Conforma_Transaccion_Manual
                        ) ;
                }

                public static DataTable? Get_Resumen_Productos_Lote( int ID_Lote )
                {
                        return ( ( DataTable? )
                        Ejecutar
                        (
                                "select Resumen_Productos.* from ( Resumen_Productos join Productos_Lote on (true) ) \n" +
                                "where ( Resumen_Productos.ID = Productos_Lote.ID_Producto ) \n" +
                                "and Productos_Lote.ID_Lote = @ID_Lote ;",
                                Tipos_Comando_Sql.Query,
                                "@ID_Lote",
                                ID_Lote
                        ) 
                        ) ;
                }
                public static DataTable? Get_Productos_Libres( string Categoria_Lote )
                {
                        DataTable? Productos_Compatibles ;
                        string Tipo_Producto_Compatible = "" ;
                        switch ( Categoria_Lote )
                        { 
                                case "Animales": Tipo_Producto_Compatible = "Animal" ; break ;
                                case "Maquinaria": Tipo_Producto_Compatible = "Maquinaria" ; break ;
                                case "Ninguna": Tipo_Producto_Compatible = "Cualquiera" ; break ;
                                default: throw new Exception() ; break ;
                        }

                        if ( Tipo_Producto_Compatible == "Cualquiera" ) { Productos_Compatibles = ( DataTable? ) Ejecutar( "select * from Productos_Libres ;", Tipos_Comando_Sql.Query ) ; }
                        else { Productos_Compatibles = ( DataTable? ) Ejecutar( $"select * from Productos_Libres where Tipo = @Tipo_Producto_Compatible ;", Tipos_Comando_Sql.Query, "@Tipo_Producto_Compatible", Tipo_Producto_Compatible ) ; }

                        return Productos_Compatibles ;
                        
                }
                public static DataTable? Get_Productos_NoLibres()
                { 
                        DataTable? Productos_NoLibres = ( DataTable? )
                        Ejecutar( "select * from Productos_NoLibres ;", Tipos_Comando_Sql.Query ) ;

                        return Productos_NoLibres ;
                }
                public static DataTable? Get_Productos_NoLibres( string Filtro_Busqueda, object Valor )
                {
                        DataTable? Productos_NoLibres_Coincidentes = ( DataTable? )
                        Ejecutar
                        (
                               $"select * from Productos_NoLibres where { Filtro_Busqueda } like @Valor ;",
                                Tipos_Comando_Sql.Query,
                                "@Valor",
                                Valor
                        ) ;

                        return Productos_NoLibres_Coincidentes ;
                }
                # endregion
                # region >>---- Ordenes de Lotes
                public static void Insert_Lote( int ID_Lote, string Categoria, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        ( 
                                "insert into Lotes ( ID_Elemento_Subasta, Categoria ) values ( @ID_Lote, @Categoria ) ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@ID_Lote", "@Categoria" } ),
                                ( new object[] { ID_Lote, Categoria } ),
                                Conforma_Transaccion_Manual
                        ) ; 
                }
                public static void Update_Lote( object ID_Lote, string Categoria, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                                "update Lotes set Categoria = @Categoria where ID_Elemento_Subasta = @ID_Lote ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@ID_Lote", "@Categoria" } ),
                                ( new object[] { ID_Lote, Categoria } ),
                                Conforma_Transaccion_Manual
                        ) ; 
                }
                public static void Delete_Lote( int ID_Lote, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Elementos_Subasta where ID = @ID_Lote ;", Tipos_Comando_Sql.No_Query, "@ID_Lote", ID_Lote, Conforma_Transaccion_Manual ) ; }
                public static bool Lote_Existe( int ID_Lote )
                { 
                        bool Lote_Existe = Convert.ToBoolean (
                        Ejecutar( "select exists( select * from Lotes where ID_Elemento_Subasta = @ID_Lote ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Lote", ID_Lote )
                        ) ;

                        return Lote_Existe ;
                }
                public static string Get_Categoria_Lote( int ID_Lote )
                {
                        string Categoria_Lote = Ejecutar( "select Categoria from Lotes where ID_Elemento_Subasta = @ID_Lote ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Lote", ID_Lote )!.ToString()! ;
                        return Categoria_Lote ;
                }
                # endregion

                // Resumenes y vistas en general
                public static DataTable? Get_Resumen_Animal( int ID_Animal )
                {
                        DataTable? Datos_Animal ;

                        Datos_Animal = ( DataTable? )
                        Ejecutar
                        (
                            "select * from Resumen_Animales\n" +
                            "where ID = @ID_Animal ;",
                            Tipos_Comando_Sql.Query,
                            Unico_Parametro_Query: "@ID_Animal",
                            Unico_Argumento_Query: ID_Animal
                        ) ;

                        if ( Convert.IsDBNull( Datos_Animal ) ) { return null ; }
                        return Datos_Animal ;
                }
                /// <summary>
                /// Hace una query a los Productos Completos, ya sean todas las tuplas o las que coinciden con un criterio en especifico.
                /// </summary>
                /// <param name="Filtro_Consulta">Es la columna que se usara como criterio de busqueda para las tuplas.</param>
                /// <param name="Argumento_Consulta">El valor del criterio de busqueda.</param>
                /// <returns>
                /// Si la query arrojo resultados, una DataTable? con los mismos.
                /// Si la query no devolvio resultados, null.
                /// </returns>
                /// <exception cref="Exception"></exception>
                public static DataTable? Get_Resumen_Productos( string Filtro_Consulta = "", string Argumento_Consulta = ""  )
                { 
                        DataTable? Resumen_Productos ;
                        if ( ! ( Filtro_Consulta == "" && Argumento_Consulta == "" ) )
                        { 
                                if ( Filtro_Consulta != "ID" && Filtro_Consulta != "Nombre" ) { throw new Exception("Se ingreso un parametro no soportado para queriar Productos Completos.") ; }
                                
                                Resumen_Productos = ( DataTable? )
                                Ejecutar
                                (
                                     "select * from Resumen_Productos\n" +
                                    $"where { Filtro_Consulta } like @Argumento_Consulta ;",
                                     Tipos_Comando_Sql.Query,
                                     Unico_Parametro_Query: "@Argumento_Consulta",
                                     Unico_Argumento_Query: Argumento_Consulta
                                ) ;

                                if ( Resumen_Productos is null ) { return null ; }
                                return Resumen_Productos ;
                        }
                        
                        
                        Resumen_Productos = ( DataTable? )
                        Ejecutar
                        (
                             "select * from Resumen_Productos ;",
                             Tipos_Comando_Sql.Query
                        ) ;

                        if ( Resumen_Productos is null ) { return null ; }
                        return Resumen_Productos ;
                }
                public static DataTable? Get_Resumen_Productos( bool Habilitado, string Tipo_Producto )
                {
                        DataTable? Resumen_Productos = ( DataTable? )
                        Ejecutar
                        (
                                "select * from Resumen_Productos where Habilitado = @Habilitado and Tipo = @Tipo ;",
                                Tipos_Comando_Sql.Query,
                                ( new string[] { "@Habilitado", "@Tipo" } ),
                                ( new object[] { Habilitado, Tipo_Producto } )
                        ) ;
                        return Resumen_Productos ;
                }
                public static DataTable? Get_Resumen_Elementos_Subasta_NoLibres( string Filtro_Busqueda, string Valor_Filtro )
                {
                        DataTable? Resumen_Elementos_Subasta_NoLibres_Coincidentes = ( DataTable? )
                        Ejecutar( $"select * from Resumen_Elementos_Subasta_NoLibres where { Filtro_Busqueda } like @Valor_Filtro ;", Tipos_Comando_Sql.Query, "@Valor_Filtro", Valor_Filtro ) ;        
                        return Resumen_Elementos_Subasta_NoLibres_Coincidentes ;
                }
                public static DataTable? Get_Resumen_Elementos_Subasta_NoLibres()
                { 
                        DataTable? Resumen_Elementos_Subasta = ( DataTable? )
                        Ejecutar( "select * from Resumen_Elementos_Subasta_NoLibres ;", Tipos_Comando_Sql.Query ) ;
                        return Resumen_Elementos_Subasta ;
                }
                public static DataTable? Get_Elementos_Subastables( string? Categoria_Remate )
                { 
                        DataTable? Elementos_Subastales ;
                        if ( string.IsNullOrWhiteSpace( Categoria_Remate ) || Categoria_Remate == "Ninguna" ) { Elementos_Subastales = ( DataTable? ) Ejecutar( "select * from Elementos_Subastables ;", Tipos_Comando_Sql.Query ) ; }
                        else
                        {
                                string Tipo_Producto_Adecuado = "" ;
                                switch ( Categoria_Remate )
                                { 
                                        case "Animales": Tipo_Producto_Adecuado = "Animal" ; break ;
                                        case "Maquinaria": Tipo_Producto_Adecuado = "Maquinaria" ; break ;
                                }

                                Elementos_Subastales = ( DataTable? )
                                Ejecutar
                                ( 
                                        "select * from Elementos_Subastables where Tipo_Producto = @Tipo_Producto or Categoria_Lote = @Categoria_Remate ;",
                                        Tipos_Comando_Sql.Query,
                                        ( new string[] { "@Tipo_Producto", "@Categoria_Remate" } ),
                                        ( new object[] { Tipo_Producto_Adecuado, Categoria_Remate } )
                                ) ;
                        }
                        return Elementos_Subastales ;
                }
                public static DataTable? Get_Productos_Proveedor( object ID_Proveedor, string Campo_Filtro_Producto = "", string Argumento_Filtrado_Producto = "" )
                {
                        DataTable? Productos_Libres_Del_Proveedor = ( DataTable? )
                        Ejecutar
                        ( 
                                "select * from Productos_Libres\n" +
                                "where ID in ( select ID_Elemento_Subasta from Elementos_Subasta_Proveedor where ID_Proveedor = @ID_Proveedor ) ;",
                                Tipos_Comando_Sql.Query,
                                "@ID_Proveedor",
                                ID_Proveedor
                        ) ;
                        return Productos_Libres_Del_Proveedor ;
                }

                /*
                public static bool Sujeto_Existe( Clase_Sujeto Sujeto_A_Identificar )
                { 
                        if ( Sujeto_A_Identificar.Es_Un_Sujeto_Invitado() ) { throw new Exception("El Sujeto a autenticar es un Sujeto Invitado.") ; }
                        if ( ! Sujeto_A_Identificar.Es_Un_Sujeto_Inidentificado() ) { throw new Exception("El Sujeto a autenticar NO es un Sujeto Inidentificado.") ; }
                        
                        if ( Sujeto_A_Identificar.Usuario is not null ) { return ( Sujeto_Existe( Sujeto_A_Identificar.Usuario.Nombre_Identificador ) ) ; }
                        return false ;
                }
                */

                // Remates
                public static DataTable? Get_Remates()
                {
                        DataTable? Remates = ( DataTable? )
                        Ejecutar( "select * from Remates ;", Tipos_Comando_Sql.Query ) ;        
                        
                        return Remates ;
                }
                public static Dictionary< string, object >? Get_Remate( int ID_Remate )
                {
                        DataTable? DataTable_Remate = ( DataTable? )
                        ( ( DataTable? ) Ejecutar( "select * from Remates where ID = @ID_Remate ;", Tipos_Comando_Sql.Query, "@ID_Remate", ID_Remate ) ) ;

                        if ( DataTable_Remate is null ) { return null ; }
                        DataRow Remate = DataTable_Remate.Rows[0] ;
                        Dictionary< string, object > Atributos_Remate = new Dictionary<string, object>() ;
                        { 
                                Atributos_Remate["ID"] = Remate["ID"] ;
                                Atributos_Remate["Momento_Inicio"] = Remate["Momento_Inicio"] ;
                                Atributos_Remate["Momento_Fin"] = Remate["Momento_Fin"] ;
                                Atributos_Remate["Categoria"] = Remate["Categoria"] ;
                                Atributos_Remate["Metodo_Pago"] = Remate["Metodo_Pago"] ;
                        }

                        return Atributos_Remate ;
                }
                public static DataTable? Get_Integrantes_Remate( object ID_Remate )
                {
                        // Hacerlo de esta forma hace que un cambio en la estructura de la tabla Elementos_Subasta_Remate
                        // rompa la consulta. Seria mejor con un Proceso en la base de datos... O como chanchada, hacer una
                        // vista, la cual su select tome como argumento una variable local o funcion a la cual se encarga de
                        // pasarle a la consulta de la vista el valor que le pasaste a la funcion, o algun hack similar.
                        return ( DataTable? )
                        Ejecutar
                        (
                                "select\n" +
                                "ID,\n" +
                                "Tipo_Elemento,\n" +
                                "Nombre,\n" +
                                "Valor,\n" +
                                "Precio_Base,\n" +
                                "Tipo_Producto,\n" +
                                "Descripcion\n" +
                                "from Resumen_Elementos_Subasta where ID in\n" +
                                "( select ID_Elemento_Subasta from Elementos_Subasta_Remate where ID_Remate = @ID_Remate ) ;",
                                Tipos_Comando_Sql.Query,
                                "@ID_Remate",
                                ID_Remate
                        ) ; 
                }
                public static bool Remate_Existe( int ID_Remate, bool Conforma_Transaccion_Manual = false )
                {
                        bool Remate_Existe = Convert.ToBoolean ( 
                        Ejecutar( "select exists( select ID from Remates where ID = @ID_Remate ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Remate", ID_Remate, Conforma_Transaccion_Manual )
                        ) ;

                        return Remate_Existe ;
                }
                public static int? Insert_Remate( DateTime Momento_Inicio, DateTime Momento_Fin, string Categoria, string Metodo_Pago, bool Devolver_ID_Remate = false, bool Conforma_Transaccion_Manual = false )
                {
                        int? ID_Remate = ( ( int? ) Convert.ToInt32(
                        Ejecutar
                        (
                                "insert into Remates ( Momento_Inicio, Momento_Fin, Categoria, Metodo_Pago )\n" +
                                "values( @Momento_Inicio, @Momento_Fin, @Categoria, @Metodo_Pago ) ;\n" +
                                "select Last_Insert_ID() ;",
                                Tipos_Comando_Sql.Query_Escalar,
                                ( new string[] { "@Momento_Inicio", "@Momento_Fin", "@Categoria", "@Metodo_Pago" } ),
                                ( new object[] { Momento_Inicio, Momento_Fin, Categoria, Metodo_Pago } ),
                                Conforma_Transaccion_Manual
                        )
                        ) );

                        if ( Devolver_ID_Remate ) { return ID_Remate ; }
                        return null ;
                }
                public static void Delete_Remate( object ID_Remate, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Remates where ID = @ID_Remate ;", Tipos_Comando_Sql.No_Query, "@ID_Remate", ID_Remate, Conforma_Transaccion_Manual ) ; }
                public static void Update_Remate( object ID_Remate, DateTime Momento_Inicio, DateTime Momento_Fin, string Categoria, string Metodo_Pago, bool Conforma_Transaccion_Manual )
                {
                        Ejecutar
                        (
                                "update Remates\n" +
                                "set\n" +
                                "Momento_Inicio = @Momento_Inicio,\n" +
                                "Momento_Fin = @Momento_Fin,\n" +
                                "Categoria = @Categoria,\n" +
                                "Metodo_Pago = @Metodo_Pago\n" +
                                "where ID = @ID_Remate ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Momento_Inicio", "@Momento_Fin", "@Categoria", "@Metodo_Pago", "@ID_Remate" } ),
                                ( new object[] { Momento_Inicio, Momento_Fin, Categoria, Metodo_Pago, ID_Remate } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Delete_Elementos_Subasta_Remate( object ID_Remate, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Elementos_Subasta_Remate where ID_Remate = @ID_Remate ;", Tipos_Comando_Sql.No_Query, "@ID_Remate", ID_Remate, Conforma_Transaccion_Manual ) ; }
                public static void Insert_Elementos_Subasta_Remate( object ID_Remate, object[] ID_Elementos_Remate, bool Conforma_Transaccion_Manual = false )
                { 
                        foreach ( int ID_Elemento in ID_Elementos_Remate )
                        { 
                                Ejecutar
                                ( 
                                        "insert into Elementos_Subasta_Remate\n" +
                                        "( ID_Remate, ID_Elemento_Subasta ) \n" +
                                        "values ( @ID_Remate, @ID_Elemento ) ;",
                                        Tipos_Comando_Sql.No_Query,
                                        ( new string[] { "@ID_Remate", "@ID_Elemento" } ),
                                        ( new object[] { ID_Remate, ID_Elemento } ),
                                        Conforma_Transaccion_Manual
                                ) ;
                        }
                }
                public static int Get_ID_Remate_Dueno_De_Elemento( int ID_Elemento_Seleccionado )
                {
                        int ID_Remate = Convert.ToInt32(
                        Ejecutar
                        ( 
                                "select ID_Remate from Elementos_Subasta_Remate where ID_Elemento_Subasta = @ID_Elemento_Seleccionado ;",
                                Tipos_Comando_Sql.Query_Escalar,
                                "@ID_Elemento_Seleccionado",
                                ID_Elemento_Seleccionado
                        )
                        ) ;

                        return ID_Remate ;
                }

                // Getters de lista de capas y relacionados
                public static DataTable? Get_Personas() { return ( DataTable? ) Ejecutar( "select * from Personas ;", Tipos_Comando_Sql.Query ) ; }
                public static DataTable? Get_Usuarios( bool Devolver_Contrasenas = false )
                {
                        if ( Devolver_Contrasenas ) { return ( DataTable? ) Ejecutar( "select * from Usuarios ;", Tipos_Comando_Sql.Query ) ; }
                        DataTable? Tabla_Usuarios = ( DataTable? )
                        Ejecutar( "select * from Usuarios ;", Tipos_Comando_Sql.Query ) ;

                        if ( Tabla_Usuarios is null ) { return null ; }
                        Tabla_Usuarios.Columns.Remove( "Contrasena" ) ;
                        return Tabla_Usuarios ;
                }
                public static DataTable? Get_Empleados() { return ( DataTable? ) Ejecutar( "select * from Empleados ;", Tipos_Comando_Sql.Query ) ; }
                public static DataTable? Get_Proveedores() { return ( DataTable? ) Ejecutar( "select * from Proveedores ;", Tipos_Comando_Sql.Query ) ; }
                public static DataTable? Get_Tareas_Empleado( int ID_Empleado ) { return ( DataTable? ) Ejecutar( "select * from Tareas_Empleado where ID_Empleado = @ID_Empleado ;", Tipos_Comando_Sql.Query, "ID_Empleado", ID_Empleado ) ; }

                public static DataTable? Get_Personas( string Filtro_Busqueda, string Argumento_Busqueda )
                {
                        if ( Filtro_Busqueda == "" || Argumento_Busqueda == "" ) { return Get_Personas() ; }
                        return ( DataTable? ) Ejecutar( $"select * from Personas where { Filtro_Busqueda } like @Argumento_Busqueda ; ", Tipos_Comando_Sql.Query, "@Argumento_Busqueda", Argumento_Busqueda ) ;
                }
                public static DataTable? Get_Usuarios( string Filtro_Busqueda, string Argumento_Busqueda, bool Devolver_Contrasenas = false )
                {
                        if ( Filtro_Busqueda == "" || Argumento_Busqueda == "" ) { return Get_Usuarios( Devolver_Contrasenas ) ; }
                        DataTable? Tabla_Usuarios = ( DataTable? )
                        Ejecutar
                        (
                                $"select * from Usuarios where { Filtro_Busqueda } like @Argumento_Busqueda ; ",
                                Tipos_Comando_Sql.Query,
                                "@Argumento_Busqueda",
                                Argumento_Busqueda
                        ) ;

                        if ( Devolver_Contrasenas ) { return Tabla_Usuarios ; }
                        if ( Tabla_Usuarios is null ) { return null ; }
                        Tabla_Usuarios.Columns.Remove("Contrasena") ;
                        return Tabla_Usuarios ;
                }
                public static DataTable? Get_Empleados( string Filtro_Busqueda, string Argumento_Busqueda )
                {
                        if ( Filtro_Busqueda == "" || Argumento_Busqueda == "" ) { return Get_Empleados() ; }
                        return ( DataTable? ) Ejecutar( $"select * from Empleados where { Filtro_Busqueda } like @Argumento_Busqueda ; ", Tipos_Comando_Sql.Query, "@Argumento_Busqueda", Argumento_Busqueda ) ;
                }
                public static DataTable? Get_Proveedores( string Filtro_Busqueda, string Argumento_Busqueda )
                {
                        if ( Filtro_Busqueda == "" || Argumento_Busqueda == "" ) { return Get_Proveedores() ; }
                        return ( DataTable? ) Ejecutar( $"select * from Proveedores where { Filtro_Busqueda } like @Argumento_Busqueda ; ", Tipos_Comando_Sql.Query, "@Argumento_Busqueda", Argumento_Busqueda ) ;
                }
                /* public static DataTable? Get_Direccion_Empresa_Proveedor( object ID_Proveedor )
                /* {
                /*      if ( ID_Proveedor is null ) { throw new ArgumentNullException("Se paso un valor null para identificar la direccion de empresa de un Proveedor.") ; }
                /*      return ( DataTable? ) Ejecutar( "select * from Direccion_Empresa_Proveedor where ID_Proveedor = @ID_Proveedor ;", Tipos_Comando_Sql.Query, "@ID_Proveedor", ID_Proveedor ) ;
                /*}
                 */
                public static DataTable? Get_Proveedores_JOIN_Direccion_Empresa_Proveedor( string Filtro_Busqueda, string Argumento_Busqueda )
                {
                        // Hago esto pq ahora mismo si pongo esa informacion a la mano en una vista tendria que actualizar varias cosas de la entrega de bases de datos.
                        // Realmente no tengo tiempo para eso. Esto es una mala decision, ya que hacer que el programa opere directamente con la estructura de la base de datos
                        // hace que el programa deba ser re-escrito si se hace algun cambio en ella. Con palabras bonitas y profesionales, estableces una relacion de `Tight coupling`.
                        // Pero bueno. Si esto fuera un producto comercial esto sería una de esas cosas que deberían retocarse con urgencia.
                        const string Join =
                        "select\n" + 
                        "Proveedores.ID as ID_Proveedor,\n" + 
                        "Proveedores.Nombre_Empresa,\n" +
                        "Proveedores.Email_Empresa,\n" + 
                        "Direccion_Empresa_Proveedor.Barrio,\n" + 
                        "Direccion_Empresa_Proveedor.Calle1,\n" + 
                        "Direccion_Empresa_Proveedor.Calle2,\n" + 
                        "Direccion_Empresa_Proveedor.Indicaciones\n" + 
                        "from\n" +
                        "( Proveedores left join Direccion_Empresa_Proveedor on( ID = ID_Proveedor ) ) \n" ;
                        if ( Filtro_Busqueda == "" || Argumento_Busqueda == "" ) { return ( DataTable? ) Ejecutar( $"{ Join } ;", Tipos_Comando_Sql.Query ) ; }
                        return ( DataTable? ) Ejecutar( $"{ Join } where { Filtro_Busqueda } like @Argumento_Busqueda ;", Tipos_Comando_Sql.Query, "@Argumento_Busqueda", Argumento_Busqueda ) ;
                }

                // Creacion de Sujeto y sus capas
                // Esta seccion de metodos crea las capas asignandolas directamente a un Sujeto
                /// <summary>
                /// Inserta un nuevo Sujeto a partir de los datos de una nueva capa Persona.
                /// No esta pensado para ser utilizado como parte de una transaccion, ya que conforma una transaccion en si mismo.
                /// </summary>
                /// <param name="Atributos_Persona">Los atributos o campos de la nueva Persona.</param>
                /// <returns>La ID de la nueva Persona.</returns>
                /// <exception cref="ArgumentNullException"></exception>
                public static int Crear_Sujeto( string Nombre_Persona, string Apellido_Persona, string Telefono_Persona, bool Conforma_Transaccion_Manual = false )
                {
                        // Esto seria mejor si ocurriera del lado de la base de datos. De esa manera se la hace responsable de su estructura interna.

                        int ID_Persona ;
                        if ( ! Conforma_Transaccion_Manual ) { Iniciar_Transaccion_Manual() ; }
                        ID_Persona = Insertar_Persona( Nombre_Persona, Apellido_Persona, Telefono_Persona, true ) ;
                        Ejecutar( "insert into Sujetos ( ID_Persona ) values( @ID_Persona ) ;", Tipos_Comando_Sql.No_Query, "@ID_Persona", ID_Persona, true ) ;
                        if ( ! Conforma_Transaccion_Manual ) { Commit_Transaccion() ; } ;
                        return ID_Persona ;
                }
                /// <summary>
                /// Inserta una nueva capa de Usuario en el sistema y se asocia con un Sujeto.
                /// </summary>
                /// <param name="ID_Sujeto">La ID del la Persona que representa un Sujeto.</param>
                public static void Agregar_Usuario( int ID_Persona, string Nombre_Identificador, string Hash_Contrasena, string Nivel_Confidencialidad, bool Inactivo, bool Conforma_Transaccion_Manual = false )
                { 
                        if ( ! Conforma_Transaccion_Manual ) { Iniciar_Transaccion_Manual() ; }
                        Insertar_Usuario( Nombre_Identificador, Hash_Contrasena, Nivel_Confidencialidad, Inactivo, true ) ;
                        Ejecutar
                        (
                                "update Sujetos set Nombre_Identificador_Usuario = @Nombre_Identificador where ID_Persona = @ID_Persona ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Nombre_Identificador", "@ID_Persona" } ),
                                ( new object[] { Nombre_Identificador, ID_Persona } ),
                                true
                        ) ;
                        if ( ! Conforma_Transaccion_Manual ) { Commit_Transaccion() ; }
                }
                public static int Agregar_Empleado( int ID_Persona, int Horas_Trabajadas )
                { 
                        Iniciar_Transaccion_Manual() ;
                        int ID_Empleado = Insertar_Empleado( Horas_Trabajadas, true ) ;
                        Ejecutar
                        (
                                "update Sujetos set ID_Empleado = @ID_Empleado where ID_Persona = @ID_Persona ;\n" +
                                "select LAST_INSERT_ID() ;",
                                Tipos_Comando_Sql.Query_Escalar,
                                ( new string[] { "@ID_Empleado", "@ID_Persona" } ),
                                ( new object[] { ID_Empleado, ID_Persona } ),
                                true
                        ) ;
                        Commit_Transaccion() ;
                        return ID_Empleado ;
                }
                public static int Agregar_Proveedor ( int ID_Persona, string? Nombre_Empresa, string? Email_Empresa, string? Barrio, string? Calle1, string? Calle2, string? Indicaciones, bool Conforma_Transaccion_Manual = false )
                {
                        // Esto se basa en que el Nombre de Empresa solo sea not null si el resto de valores es not null
                        // Checkar que la nullidad de todos los campos sea simetrica, siendo la cantidad de estos impar

                        if (  ! (
                                        Nombre_Empresa is null && Email_Empresa is null && Barrio is null && Calle1 is null && Calle2 is null ||
                                        Nombre_Empresa is not null && Email_Empresa is not null && Barrio is not null && Calle1 is not null && Calle2 is not null
                                )
                        ) { throw new ArgumentException("Se pasaron datos parciales para la Empresa del Proveedor.") ; }
                        bool Proveedor_Tiene_Empresa() { return ( ( Nombre_Empresa is null ) ? false : true ) ; }
                        void Proseguir_Sin_Empresa( ref int ID_Proveedor )
                        {
                                if ( ! Conforma_Transaccion_Manual ) { Iniciar_Transaccion_Manual() ; }
                                ID_Proveedor = Insertar_Proveedor( Conforma_Transaccion_Manual: true ) ;
                                Ejecutar
                                ( 
                                        "update Sujetos set ID_Proveedor = @ID_Proveedor where ID_Persona = @ID_Persona ;",
                                        Tipos_Comando_Sql.No_Query,
                                        ( new string[] { "@ID_Proveedor", "@ID_Persona" } ),
                                        ( new object[] { ID_Proveedor, ID_Persona } ),
                                        true
                                ) ;
                                if ( ! Conforma_Transaccion_Manual ) { Commit_Transaccion() ; }
                                return ;
                        }
                        void Proseguir_Con_Empresa( ref int ID_Proveedor )
                        {
                                if ( ! Conforma_Transaccion_Manual ) { Iniciar_Transaccion_Manual() ; }
                                ID_Proveedor = Insertar_Proveedor( Nombre_Empresa!, Email_Empresa!, Barrio!, Calle1!, Calle2!, Indicaciones, true ) ;
                                Ejecutar
                                ( 
                                        "update Sujetos set ID_Proveedor = @ID_Proveedor where ID_Persona = @ID_Persona ;",
                                        Tipos_Comando_Sql.No_Query,
                                        ( new string[] { "@ID_Proveedor", "@ID_Persona" } ),
                                        ( new object[] { ID_Proveedor, ID_Persona } ),
                                        true
                                ) ;
                                if ( ! Conforma_Transaccion_Manual ) { Commit_Transaccion() ; }
                        }

                        int ID_Proveedor = 0 ;
                        if ( Proveedor_Tiene_Empresa() ) { Proseguir_Con_Empresa( ref ID_Proveedor ) ; }
                        else { Proseguir_Sin_Empresa( ref ID_Proveedor ) ; }
                        return ID_Proveedor ;
                }

                // Eliminado de capas
                /// <summary>
                /// Elimina un Sujeto junto a todas sus capas a partir de la ID de su capa Persona.
                /// Este metodo no esta hecho para usarse como parte de una transaccion, si no para conforar su propia transaccion.
                /// </summary>
                /// <param name="ID_Persona"></param>
                public static void Eliminar_Sujeto( int ID_Persona )
                { 
                        string? Nombre_Identificador ;
                        int? ID_Empleado ;
                        int? ID_Proveedor ;

                        Iniciar_Transaccion_Manual() ;
                        { // Consigue los identificadores de las capas de un determinado Sujeto
                                Nombre_Identificador = ( string? )
                                Ejecutar
                                (
                                        "select Nombre_Identificador_Usuario from Sujetos where ID_Persona = @ID_Persona ;",
                                        Tipos_Comando_Sql.Query_Escalar,
                                        "@ID_Persona",
                                        ID_Persona,
                                        true
                                ) ;
                                ID_Empleado = ( int? )
                                Ejecutar
                                (
                                        "select ID_Empleado from Sujetos where ID_Persona = @ID_Persona ;",
                                        Tipos_Comando_Sql.Query_Escalar,
                                        "@ID_Persona",
                                        ID_Persona,
                                        true
                                ) ;
                                ID_Proveedor = ( int? )
                                Ejecutar
                                (
                                        "select ID_Proveedor from Sujetos where ID_Persona = @ID_Persona ;",
                                        Tipos_Comando_Sql.Query_Escalar,
                                        "@ID_Persona",
                                        ID_Persona,
                                        true
                                ) ;
                        }
                        { // Elimina las capas del Sujeto
                                if ( Nombre_Identificador is not null ) { Delete_Usuario( ( string ) Nombre_Identificador, true ) ; }
                                if ( ID_Empleado is not null ) { Delete_Empleado( ( int ) ID_Empleado, true ) ; }
                                if ( ID_Proveedor is not null ) { Delete_Proveedor( ( int ) ID_Proveedor, true ) ; }
                                Delete_Persona( ID_Persona, true ) ;
                                // En la base de datos, al borrar a una persona se borra la entrada en la tabla Sujetos,
                                // pero no son borradas las capas que lo componene, eso requeriria un "trigger", "gatillo" o "disparador"
                        }
                        Commit_Transaccion() ;
                }
                /// <summary>
                /// Elimina una capa Persona del sistema.
                /// Ten cuidado, ya que elimina una capa Persona, junto con la entrada en la tabla Sujetos, pero no elimina las capas que conforman a un Sujeto.
                /// Si lo que quieres es borrar un Sujeto entero entonces llama a la funcion `Eliminar_Sujeto`.
                /// </summary>
                public static void Delete_Persona( int ID_Persona, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Personas where ID = @ID_Persona ;", Tipos_Comando_Sql.No_Query, "@ID_Persona", ID_Persona, Conforma_Transaccion_Manual ) ; }
                public static void Delete_Usuario( string Nombre_Identificador, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Usuarios where Nombre_Identificador = @Nombre_Identificador ;", Tipos_Comando_Sql.No_Query, "@Nombre_Identificador", Nombre_Identificador ) ; }
                public static void Delete_Empleado( int ID_Empleado, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Empleados where ID = @ID_Empleado ;", Tipos_Comando_Sql.No_Query, "@ID_Empleado", ID_Empleado, Conforma_Transaccion_Manual ) ; }
                public static void Delete_Proveedor( int ID_Proveedor, bool Conforma_Transaccion_Manual = false ) { Ejecutar( "delete from Proveedores where ID = @ID_Proveedor ;", Tipos_Comando_Sql.No_Query, "@ID_Proveedor", ID_Proveedor, Conforma_Transaccion_Manual ) ; }

                // Actualizacion de capas
                public static void Update_Persona( int ID_Persona, string Nombre, string Apellido, string Telefono, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "update Personas set\n" +
                                "Nombre = @Nombre,\n" +
                                "Apellido = @Apellido,\n" +
                                "Telefono = @Telefono\n" +
                                "where ID = @ID_Persona ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Nombre", "@Apellido", "@Telefono", "@ID_Persona" } ),
                                ( new object[] { Nombre, Apellido, Telefono, ID_Persona } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                //public static void Update_Usuario( string Nombre_Identificador, string Hash_Contrasena, string Nivel_Confidencialidad, bool Inactivo, bool Conforma_Transaccion_Manual = false )
                //{
                //        Ejecutar
                //        (
                //                "update Usuarios set\n" +
                //                "Nombre_Identificador = @Nombre_Identificador,\n" +
                //                "Contrasena = @Hash_Contrasena,\n" +
                //                "Nivel_Confidencialidad = @Nivel_Confidencialidad,\n" +
                //                "Inactivo = @Inactivo" +
                //                "where Nombre_Identificador = @Nombre_Identificador ;",
                //                Tipos_Comando_Sql.No_Query,
                //                ( new string[] { "@Nombre_Identificador", "@Contrasena", "@Nivel_Confidencialidad", "@Inactivo", "@Nombre_Identificador" } ),
                //                ( new object[] { Nombre_Identificador, Hash_Contrasena, Nivel_Confidencialidad, Inactivo, Nombre_Identificador } ),
                //                Conforma_Transaccion_Manual
                //        ) ;        
                //}
                //public static void Update_Usuario( string Nombre_Identificador, string Nivel_Confidencialidad, bool Inactivo, bool Conforma_Transaccion_Manual )
                //{
                //        Ejecutar
                //        (
                //                "update Usuarios set\n" +
                //                "Nombre_Iden" +
                //                "where Nombre_Identificador = @Nombre_Identificador ;"        
                //        ) ;
                //}
                /// <summary>
                /// Realiza un update sobre un Usuario.
                /// </summary>
                /// <remarks>
                /// Al ingresar un nombre identificador diferente al nombre identificador actual, se cambia el nombre identificador del Usuario.
                /// </remarks>
                /// <param name="Nombre_Identificador">El nombre identificador que tendra el Usuario despues del update.</param>
                /// <param name="Nombre_Identificador_Actual">El nombre identificador que tiene actualmente el Usuario.</param>
                /// <param name="Conforma_Transaccion_Manual"></param>
                public static void Update_Usuario( string Nombre_Identificador, string Nivel_Confidencialidad, bool Inactivo, string? Hash_Contrasena = null, string Nombre_Identificador_Actual = "", bool Conforma_Transaccion_Manual = false )
                {
                        if ( Nombre_Identificador_Actual == "" ) { Nombre_Identificador_Actual = Nombre_Identificador ; }
                        if ( Hash_Contrasena is not null )
                        {
                                Ejecutar
                                (
                                        "update Usuarios set\n" +
                                        "Nombre_Identificador = @Nombre_Identificador,\n" +
                                        "Contrasena = @Hash_Contrasena,\n" +
                                        "Nivel_Confidencialidad = @Nivel_Confidencialidad,\n" + 
                                        "Inactivo = @Inactivo\n" +
                                        "where Nombre_Identificador = @Nombre_Identificador_Actual ;",
                                        Tipos_Comando_Sql.No_Query,
                                        ( new string[] { "@Nombre_Identificador", "@Hash_Contrasena", "@Nivel_Confidencialidad", "@Inactivo", "@Nombre_Identificador_Actual" } ),
                                        ( new object[] { Nombre_Identificador , Hash_Contrasena, Nivel_Confidencialidad, Inactivo, Nombre_Identificador_Actual } ),
                                        Conforma_Transaccion_Manual
                                ) ;
                                return ;
                        }
                        Ejecutar
                        (
                                "update Usuarios set\n" +
                                "Nombre_Identificador = @Nombre_Identificador,\n" +
                                "Nivel_Confidencialidad = @Nivel_Confidencialidad,\n" +
                                "Inactivo = @Inactivo\n" +
                                "where Nombre_Identificador = @Nombre_Identificador_Actual ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Nombre_Identificador", "@Nivel_Confidencialidad", "@Inactivo", "@Nombre_Identificador_Actual" } ),
                                ( new object[] { Nombre_Identificador, Nivel_Confidencialidad, Inactivo, Nombre_Identificador_Actual } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Update_Empleado( int ID_Empleado, int Horas_Trabajadas, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "update Empleados set\n" +
                                "Horas_Trabajadas = @Horas_Trabajadas\n" +
                                "where ID = @ID_Empleado ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Horas_Trabajadas", "@ID_Empleado" } ),
                                ( new object[] { Horas_Trabajadas, ID_Empleado } ),
                                Conforma_Transaccion_Manual
                        ) ;        
                }
                public static void Update_Proveedor( int ID_Proveedor, string? Nombre_Empresa, string? Email_Empresa, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        ( 
                                "update Proveedores set\n" +
                                "Nombre_Empresa = @Nombre_Empresa,\n" +
                                "Email_Empresa = @Email_Empresa\n" +
                                "where ID = @ID_Proveedor ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Nombre_Empresa", "@Email_Empresa", "@ID_Proveedor" } ) ,
                                ( new object[] { Nombre_Empresa!, Email_Empresa!, ID_Proveedor! } ),
                                Conforma_Transaccion_Manual 
                        ) ; 
                }
                
                // Relacionado a capas
                public static void Update_Direccion_Empresa_Proveedor( int ID_Proveedor, string Barrio, string Calle1, string Calle2, string? Indicaciones, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "update Direccion_Empresa_Proveedor set\n" +
                                "Barrio = @Barrio,\n" +
                                "Calle1 = @Calle1,\n" +
                                "Calle2 = @Calle2,\n" +
                                "Indicaciones = @Indicaciones\n" +
                                "where ID_Proveedor = @ID_Proveedor ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@Barrio", "@Calle1", "@Calle2", "Indicaciones", "@ID_Proveedor" } ),
                                ( new object[] { Barrio, Calle1, Calle2, Indicaciones!, ID_Proveedor } ),
                                Conforma_Transaccion_Manual
                        ) ;        
                }
                public static void Insert_Direccion_Empresa_Proveedor( int ID_Proveedor, string Barrio, string Calle1, string Calle2, string? Indicaciones, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        (
                                "insert into Direccion_Empresa_Proveedor\n" +
                                "( ID_Proveedor, Barrio, Calle1, Calle2, Indicaciones ) \n" +
                                "values( @ID_Proveedor, @Barrio, @Calle1, @Calle2, @Indicaciones ) ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@ID_Proveedor", "@Barrio", "@Calle1", "@Calle2", "@Indicaciones" } ),
                                ( new object[] { ID_Proveedor, Barrio, Calle1, Calle2, Indicaciones! } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Delete_Direccion_Empresa_Proveedor( int ID_Proveedor, bool Conforma_Transaccion_Manual ) { Ejecutar( "delete from Direccion_Empresa_Proveedor where ID_Proveedor = @ID_Proveedor ;", Tipos_Comando_Sql.No_Query, "@ID_Proveedor", ID_Proveedor, Conforma_Transaccion_Manual ) ; }
                public static bool Proveedor_Tiene_Direccion_Empresa( int ID_Proveedor, bool Conforma_Transaccion_Manual ) { return Convert.ToBoolean( Ejecutar( "select exists( select * from Direccion_Empresa_Proveedor where ID_Proveedor = @ID_Proveedor ) ;", Tipos_Comando_Sql.Query_Escalar, "@ID_Proveedor", ID_Proveedor, Conforma_Transaccion_Manual ) ) ; }

                // Tareas de Empleado
                public static DataTable? Get_Tareas_Empleado( int ID_Empleado, string Filtro_Busqueda, string Argumento_Busqueda )
                {
                        if ( Filtro_Busqueda == "" || Argumento_Busqueda == "" ) { return Get_Tareas_Empleado( ID_Empleado ) ; }
                        return ( DataTable? )
                        Ejecutar
                        (
                                "select * from Tareas_Empleado where ID_Empleado = @ID_Empleado\n" +
                                "and Tarea like @Argumento_Busqueda ;",
                                Tipos_Comando_Sql.Query,
                                ( new string[] { "@ID_Empleado", "@Argumento_Busqueda" } ),
                                ( new object[] { ID_Empleado, Argumento_Busqueda } )
                        ) ;
                }
                public static void Delete_Tarea_Empleado( int ID_Empleado, string Antigua_Tarea, bool Conforma_Transaccion_Manual = false )
                {
                        Ejecutar
                        ( 
                                "delete from Tareas_Empleado\n" +
                                "where\n" +
                                "ID_Empleado = @ID_Empleado\n" +
                                "and\n" +
                                "Tarea = @Antigua_Tarea ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@ID_Empleado", "@Antigua_Tarea" } ),
                                ( new object[] { ID_Empleado, Antigua_Tarea } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }
                public static void Insert_Tarea_Empleado( int ID_Empleado, string Nueva_Tarea, bool Conforma_Transaccion_Manual = false )
                { 
                        Ejecutar
                        (
                                "insert into Tareas_Empleado ( ID_Empleado, Tarea )\n" +
                                "values( @ID_Empleado, @Nueva_Tarea ) ;",
                                Tipos_Comando_Sql.No_Query,
                                ( new string[] { "@ID_Empleado", "@Nueva_Tarea" } ),
                                ( new object[] { ID_Empleado, Nueva_Tarea } ),
                                Conforma_Transaccion_Manual
                        ) ;
                }

#if DEBUG_Conexion_Base_Datos
                public
#else
                private
#endif
                static Representacion_Sujeto? Get_Representacion_Sujeto( string Nombre_Identificador_Usuario )
                {
                        Representacion_Sujeto? Representacion_Sujeto ; // Un objeto que guarda los atributos de cada capa de un Sujeto.
                        string[] Atributos_Persona ; // Los atributos de una determinada capa Persona
                        string[] Atributos_Usuario ; // Los atributos de una determinada capa Usuario asociada a la capa Persona.
                        string[]? Atributos_Empleado ; // Los atributos de una determinada capa Empleado asociada a la capa Persona.
                        string[]? Atributos_Proveedor ; // Los atributos de una determinada capa Proveedor asociada a la capa Persona.
                        // Cabe destacar que la capa Persona es indispensable por la forma en que los Sujetos estan construidos.
                        // La capa Usuario no es indispensable, pero porque este metodo consigue un Sujeto a partir del Nombre_Identificador de una capa de Usuario.

                        Atributos_Usuario = Get_Atributos_Usuario( Nombre_Identificador_Usuario )! ;
                        if ( Atributos_Usuario is null ) { return null ; }

                        Atributos_Persona = Get_Atributos_Persona( Nombre_Identificador_Usuario )! ;
                        if ( Atributos_Persona is null ) { throw new Exception($"La capa de Persona es null, no se encontro una capa Persona asociada para el Nombre_Identificador `{ Nombre_Identificador_Usuario }`. Esto es un error grave.") ; }
                        
                        Atributos_Empleado = Get_Atributos_Empleado( Nombre_Identificador_Usuario )! ;
                        Atributos_Proveedor = Get_Atributos_Proveedor( Nombre_Identificador_Usuario )! ;
                        // Tener en cuenta que tanto `Atributos_Empleado` como `Atributos_Proveedor` pueden ser null.

                        Representacion_Sujeto = new Representacion_Sujeto( Atributos_Persona, Atributos_Usuario, Atributos_Empleado, Atributos_Proveedor ) ;
                        return Representacion_Sujeto ;
                }

                /// <summary>
                /// Representa las capas de un determinado Sujeto, a traves de arrays que contiene los atributos de cada capa.
                /// Considera utilizar el constructor de `Clase_Sujeto` que toma una `Representacion_Sujeto` para construirlo facilmente a partir de este metodo.
                /// Formato:
                ///             Representacion_Sujeto.Atributos_Persona[]
                ///             Representacion_Sujeto.Atributos_Usuario[]?
                ///             Representacion_Sujeto.Atributos_Empleado[]?
                ///             Representacion_Sujeto.Atributos_Proveedor[]?
                ///             
                /// Formato Atributos_Persona[]:
                /// * ID = string[0]
                ///            * Nombre = string[1]
                ///            * Apellido = string[2]
                ///            * Telefono = string[3]
                ///            
                /// Formato Atributos_Usuario[]?:
                ///            * Nombre_Identificador = string[0]
                ///            * Contrasena = string[1]
                ///            * Nivel_Confidencialidad = string[2]
                ///            * Inactivo = string[3]
                ///            
                /// Formato Atributos_Empleado[]?:
                ///            * ID = string[0]
                ///            * Horas_Trabajadas = string[1]
                ///            * Tarea = string[2]
                ///            * Otra Tarea = string[2...]
                ///            
                /// Formato Atributos_Proveedor[]?:
                ///            * ID_Proveedor = string[0]
                ///            * Nombre_Empresa = string[1]
                /// </summary>
                public class Representacion_Sujeto
                {
                        public readonly string[] Atributos_Persona ;
                        public readonly string[]? Atributos_Usuario ;
                        public readonly string[]? Atributos_Empleado ;
                        public readonly string[]? Atributos_Proveedor ;

                        public Representacion_Sujeto
                        ( 
                            string[] Argumento_Atributos_Persona,
                            string[]? Argumento_Atributos_Usuario,
                            string[]? Argumento_Atributos_Empleado,
                            string[]? Argumento_Atributos_Proveedor
                        )
                        { 
                                Atributos_Persona = Argumento_Atributos_Persona ;
                                Atributos_Usuario = Argumento_Atributos_Usuario ;
                                Atributos_Empleado = Argumento_Atributos_Empleado ;
                                Atributos_Proveedor = Argumento_Atributos_Proveedor ;
                        }
                }
        }
}