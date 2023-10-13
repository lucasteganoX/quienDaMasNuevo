# define DEBUG_Conexion_Base_Datos
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;

using MySql.Data.MySqlClient ;

namespace Acceso_Datos
{
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
                static MySqlTransaction? Transaccion ; // Cuando la referencia no es null, significa que hay una transaccion en curso.
                        
                static string Servidor = "localhost" ;
                static string Base_Datos = "quien da mas" ;
                static string Usuario = "root" ;
                static string Contrasena = "" ;
                static string Llave_Conexion = "Database=" + Base_Datos +
                                               " ; Data Source=" + Servidor +
                                               " ; User Id=" + Usuario +
                                               " ; Password=" + Contrasena +
                                               "" ;

                public enum Tipos_Comando_Sql
                {
                        Query ,
                        Query_Escalar,
                        No_Query
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
                /// Ejecuta una unica setencia sql en la base de datos. Es capaz de ejecutar sentencias de tipo Query, Query Escalar y no Queries bajo indicacion explicita.
                /// Al ejecutar una No Query, devuelve una referencia null.
                /// Al ejecutar una Query Escalar, aplica el prosedimiento estandar para queries escalares. Osea: devuelve un objeto? que podria ser casteado a un determinado tipo primitivo si la query arrojo un resultado, o una referencia null si la query no arrojo nungun resultado.
                /// Al ejecutar una Query normal, se devuelve un objeto? que podria ser casteado a una DataTable si la query arrojo resultados, o una referencia null si la query no arrojo resultados.
                /// </summary>
                /// <param name="Sentencia_A_Ejecutar">Es la sentencia sql que se ejecutara en la base de datos.</param>
                /// <param name="Tipo_Comando_Sql_Seleccionado">Especifica el tipo de setencia sql a ejecutar. Puede ser una `Query`, `Query_Escalar` o `No_Query`.</param>
                /// <param name="Unico_Parametro_Query">Si se realiza una Query que requiere un argumento, aqui se debe ingresar la cadena de caracteres dentro de la</param>
                /// <param name="Unico_Argumento_Query">Si se realiza una Query que requiere un argumento, aqui se debe ingresar el argumento que si ingresara al objeto MySqlCommand. Se admite un string o el valor DBNull. Ver: "6.1.4 Working with Parameters" https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-parameters.html#:~:text=6.1.4%C2%A0Working%20with%20Parameters 
                /// </param>
                /// <returns></returns>
                /// <exception cref="ArgumentException"></exception>
                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static object? Ejecutar( string Sentencia_A_Ejecutar, Tipos_Comando_Sql Tipo_Comando_Sql_Seleccionado, string Unico_Parametro_Query = "", string? Unico_Argumento_Query = "" )
                {
                        // if ( Tipo_Comando_Sql_Seleccionado == Tipos_Comando_Sql.No_Query && ( Unico_Parametro_Query != "" || Unico_Argumento_Query != null ) ) { throw new ArgumentException("Las no queries a ejecutar no admiten argumentos o parametros.") ; }
                        if ( ( Unico_Argumento_Query != "" ) ^ ( Unico_Argumento_Query != "" ) ) { throw new ArgumentException("Se debe proporcionar tanto un parametro como su argumento o ninguno de los dos.") ; }

                        if ( String_Es_Solo_Espacios_O_Null( Unico_Parametro_Query ) ) { throw new ArgumentException("Se proporciono un parametro null o que solo consta de espacios.") ; }
                        if (  Unico_Argumento_Query is not null && String_Es_Solo_Espacios( Unico_Argumento_Query ) ) { throw new ArgumentException("Se ingreso un parametro que solo consta de espacios, considere ingresar null o no parametrizar la sentencia.") ; }
                        

                        if ( Unico_Parametro_Query == "" ) { return Ejecutar( Sentencia_A_Ejecutar, Tipo_Comando_Sql_Seleccionado, Parametros_Query: null , Argumentos_Query: null ) ; }
                        
                        { // Llama al metodo base `Ejecutar`, envolviendo el unico parametro y argumento de la query en arrays.
                                string[] Parametro_Como_Array ;
                                string[] Argumento_Como_Array ;

                                Parametro_Como_Array = new string[] { Unico_Parametro_Query } ;
                                Argumento_Como_Array = new string[] { Unico_Argumento_Query! } ; // El argumento puede ser null aqui, y es un funcionalidad intencional.

                                return Ejecutar( Sentencia_A_Ejecutar, Tipo_Comando_Sql_Seleccionado, Parametro_Como_Array, Argumento_Como_Array) ;
                        }
                }

                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
                static object? Ejecutar( string Sentencia_A_Ejecutar, Tipos_Comando_Sql Tipo_Comando_Sql_Seleccionado, string[]? Parametros_Query, string[]? Argumentos_Query )
                {
                        MySqlCommand Comando ;

                        DataTable? Resultado_No_Escalar = new DataTable() ;
                        object? Resultado_Escalar = null ;
                        object? Salida ; // Es la informacion que devuelve la funcion. Puede o no contener informacion.
                        
                        { // Se hace la conexion y el comando
                                Conexion = new MySqlConnection( Llave_Conexion ) ;
                                Comando = new MySqlCommand( Sentencia_A_Ejecutar, Conexion ) ;

                                Conexion.Open() ;
                        }

                        { // Se preparan los argumentos
                                if ( Parametros_Query is not null && Argumentos_Query is not null )
                                {
                                        if ( Parametros_Query.Length != Argumentos_Query.Length ) { throw new ArgumentException("El numero de parametros y argumentos de la query no coincide.") ; }
                                        for ( int Indice_Valor = 0 ; Indice_Valor < Parametros_Query.Length ; Indice_Valor++ )
                                        {
                                                if ( string.IsNullOrWhiteSpace( Parametros_Query[ Indice_Valor ] ) ) { throw new ArgumentException($"El parametro numero `{ Indice_Valor }` es null, espacios o esta vacio.") ; }
                                                if ( String_Es_Solo_Espacios( Argumentos_Query[ Indice_Valor ] ) ) { throw new ArgumentException($"El argumento numero `{ Indice_Valor }` es solo espacios.") ; }

                                                Comando.Parameters.AddWithValue( Parametros_Query[ Indice_Valor ], ( ! Convert.IsDBNull( Argumentos_Query[ Indice_Valor ] ) ) ? Argumentos_Query[ Indice_Valor ].ToString() : DBNull.Value ) ;
                                        }
                                }
                        }

                        switch ( Tipo_Comando_Sql_Seleccionado )
                        { // Se ejecutan las sentencias
                                case Tipos_Comando_Sql.No_Query: 
                                        Comando.ExecuteNonQuery() ;

                                        Salida = null ;
                                break ;
                                case Tipos_Comando_Sql.Query:
                                        MySqlDataAdapter Adaptador = new MySqlDataAdapter( Comando ) ; // Adaptará una query no escalar a una DataTable
                                        Adaptador.Fill( Resultado_No_Escalar ) ;
                                        
                                        Salida = ( ( object ) Resultado_No_Escalar ) ;
                                break ;
                                case Tipos_Comando_Sql.Query_Escalar:
                                        Resultado_Escalar = Comando.ExecuteScalar() ;

                                        Salida = ( ( object ) Resultado_Escalar ) ;
                                break ;
                                default:
                                        throw new ArgumentException( "El tipo de orden es incorrecto." ) ; // Por la naturaleza del enum, esto nunca deberia llegar a ocurrir. Pero algo me dice que lo ponga de igual forma.
                                break ;
                        }

                        { // Se prepara para finalizar
                                Conexion.Close() ;
                                Conexion.Dispose() ;
                                Conexion = null ;
                                return Salida ;
                        }
                }

                /// <summary>
                /// Ejecuta una conjunto de sentencias sql como parte de una misma transaccion en la base de datos.
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
                        if ( Transaccion is not null ) { throw new Exception("Se trato de realizar una transaccion mientras otra transaccion esta en curso.") ; }

                        { // Prepar la transaccion
                                Conexion = new MySqlConnection( $"{ Llave_Conexion }; AllowUserVariables=true" ) ;

                                Console.WriteLine($"Iniciando conexion con la base de datos `{ Base_Datos }`.") ;
                                Conexion.Open() ;
                                Console.WriteLine("Conexion iniciada.") ;

                                Console.WriteLine("Se inicio la transaccion.") ;
                                Transaccion = Conexion.BeginTransaction() ;
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
                                Transaccion.Commit() ;
                                Console.WriteLine("La transaccion fue confirmada(commit) con exito.") ;
                                
                        }
                        catch ( MySqlException ErrorBaseDatos )
                        { 
                                Transaccion.Rollback() ;
                                Console.WriteLine("Caso de fallo. Se cancelo la transaccion haciendo un rollback...\n") ;
                                throw ErrorBaseDatos ;
                        } 
                        finally
                        { // Limpia la transaccion y la conexion
                                Transaccion.Dispose() ;
                                Transaccion = null ;
                                Conexion.Close() ;   
                                Conexion.Dispose() ;
                                Conexion = null ;
                                Console.WriteLine("Se cerro y limpio la transaccion y la conexion.") ;
                        }
                }
                # endregion
                # region >>---- Inserciones de Capas
                public static void Insertar_Persona( string Nombre, string Apellido, string Telefono )
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

                        Ejecutar( $"insert into Personas( Nombre, Apellido, Telefono ) values ( '{ Nombre }', '{ Apellido }', '{ Telefono }' ) ;", Tipos_Comando_Sql.No_Query ) ;
                }

                public static void Insertar_Usuario( string Nombre_Identificador, string Contrasena, string Nivel_Confidencialidad, bool Inactivo )
                {
                        # region >>---- Clausula Guardian / Guardian Clause
                        if ( Nombre_Identificador is null ) { throw new ArgumentNullException("El Nombre identificador del Usuario a insertar no puede ser null.") ; }
                        if ( Contrasena is null ) { throw new ArgumentNullException("La Contrasena del usuario a insertar no puede ser null.") ; }
                        if ( Nivel_Confidencialidad is null ) { throw new ArgumentNullException("La cadena que representa el Nivel de Confidencialidad del Usuario a insertar no puede ser null.") ; }
                        // Los valores booleanos no son nullbles.

                        if ( Nombre_Identificador.Length > 30 ) { throw new ArgumentException("El Nombre Identificador del Usuario a insertar supera los 30 caracteres.") ; }

                        if ( Contrasena.Length > 40 ) { throw new ArgumentException("La Contrasena del Usuario a insertar supera los 40 caracteres.") ; }
                        if ( Nivel_Confidencialidad.Length > 4 ) { throw new ArgumentException("La cadena que representa el Nivel de Confidenciaidad no debe ser mayor a 4 caracteres.") ; }
                        foreach ( char Caracter in Nivel_Confidencialidad ) { if ( Caracter != '0' && Caracter != '1' ) { throw new ArgumentException("La cadena que representa el nivel de confidencialidad debe estar compuesta exclusivamente de digitos binarios(ceros y unos).") ; } }
                        # endregion >>-------------------
                        
                        Ejecutar( $"insert into Usuarios( Nombre_Identificador, Contrasena, Nivel_Confidencialidad, Inactivo ) values ( '{ Nombre_Identificador }', '{ Contrasena }', '{ Nivel_Confidencialidad }', '{ Inactivo }' ) ;", Tipos_Comando_Sql.No_Query ) ;
                }

                public static void Insertar_Empleado( int Horas_Trabajadas )
                {
                        #region >>---- Clausula Guardian / Guardian Clause
                        if ( Horas_Trabajadas > int.MaxValue ) { throw new ArgumentException("El empleado a trabajado demasiado, jubilenlo.") ; }
                        if ( Horas_Trabajadas < 0 ) { throw new ArgumentException("Se le quiere asignar al Empleado a insertar una cantidad de Horas Trabajadas negativas. Ni modo que les faltaba cobrarle por trabajar al tipo XDDDD") ; }
                        # endregion >>------------------------------------

                        Ejecutar( $"insert into Empleados( Horas_Trabajadas ) values ( '{ Horas_Trabajadas }' ) ;", Tipos_Comando_Sql.No_Query ) ;
                }

                public static void Insertar_Proveedor() { Ejecutar( $"insert into Proveedores() values () ;", Tipos_Comando_Sql.No_Query ) ; }

                public static void Insertar_Proveedor( string Nombre_Empresa, string Barrio, string Calle1, string Calle2, string Indicaciones = null )
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

                        if ( Indicaciones is not null ) { Indicaciones = $"'{ Indicaciones }'" ; }
                        Ejecutar
                        (
                            new string[]
                            {  
                                $"insert into Proveedores( Nombre_Empresa ) values ( '{ Nombre_Empresa }' ) ;",
                                $"insert into Direccion_Empresa_Proveedor( ID_Proveedor, Barrio, Calle1, Calle2, Indicaciones ) values ( LAST_INSERT_ID(), '{ Barrio }', '{ Calle1 }', '{ Calle2 }', { Indicaciones } ) ;"
                            } 
                        ) ;
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

                                if ( ID_Empleado is null ) { throw new ArgumentException($"No se encontro un Sujeto para el Nombre_Identificador `{ Nombre_Identificador_Usuario }`") ; }
                                if ( Convert.IsDBNull( ID_Empleado ) ) { return null ; }


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


                        if ( ID_Proveedor is null ) { throw new Exception($"No se encontro un Sujeto para el Nombre_Identififcador `{ Nombre_Identificador_Usuario }`.") ; }
                        if ( Convert.IsDBNull( ID_Proveedor ) ) { return null ; }
                        DataTable_Proveedor = ( DataTable? ) 
                        Ejecutar
                        (
                            "select * from Proveedores where ID = @ID_Proveedor ;",
                            Tipos_Comando_Sql.Query,
                            Unico_Parametro_Query: "@ID_Proveedor",
                            Unico_Argumento_Query: ID_Proveedor.ToString()!
                        ) ;
                        
                        if ( DataTable_Proveedor is DBNull ) { throw new Exception($"No se encontro un Proveedor para la ID de Proveedor `{ ID_Proveedor }`") ; } // La documentacion dice que SqlCommand.ExecuteScalar devuelve null.... En realidad devuelve DBNull. Jajajaja voy a prender fuego a los de microsoft
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
                #region >>---- Inserciones
                public static void Update_Producto_Completo
                (
                    Dictionary< string, object > Campos_Elemento_Subasta, 
                    Dictionary< string, object > Campos_Producto,
                    Dictionary< string, object >? Campos_Animal = null,
                    Dictionary< string, object >? Campos_Maquinaria = null
                )
                {
                        // Campos Elemento_Subasta
                        int ID ;
                        object Valor ;
                        object Precio_Base ;
                        bool Habilitado ;
                        // Campos Producto
                        object Nombre ;
                        object Descripcion ;
                        // Campos Animal
                        string Sexo ;
                        object Raza ;
                        int Edad ;
                        int Peso ;
                        bool Esta_Castrado ;
                                // Subclase Animal
                                string Tipo_Animal ;  // Esta variable se utiliza para saber si hay que consruir una subclase de Animal y cual.
                                string Especializacion ;
                        // Campos Maquinaria
                        string Marca ;
                        string Numero_Serial ;
                        string Historial_Propiedad ;
                        string Es_Nueva ;
                        int Ano_Adquisicion ;

                        string Subclase_Animal_A_Contruir ;
                        {
                                ID = Convert.ToInt32( Campos_Elemento_Subasta["ID"] ) ;
                                Valor = ( Campos_Elemento_Subasta["Valor"] ) ;
                                Precio_Base = Convert.ToInt32( Campos_Elemento_Subasta["Precio_Base"] ) ;
                                Habilitado = Convert.ToBoolean( Campos_Elemento_Subasta["Habilitado"] ) ;
                        }

                        { 
                                Nombre = Campos_Elemento_Subasta["Nombre"] ;
                                Descripcion = Campos_Elemento_Subasta["Descripcion"] ;
                        }

                        if ( ! Convert.IsDBNull( Campos_Animal ) )
                        {
                                // Tipo de Animal
                                switch ( Campos_Animal["Tipo_Animal"] )
                                { 
                                        case "Vacuno":
                                                //Subclase_Animal_A_Contruir =   
                                        break ;
                                                        
                                }
                        }


                        Ejecutar
                        (
                             "update Elementos_Subasta\n" +
                             "set\n" +
                             "Valor = @Valor," +
                             "Precio_Base = @Precio_Base," +
                             "Habilitado = @Habilitado\n" +
                             "where ID = @ID ;",
                             Tipo_Comando_Sql_Seleccionado: Tipos_Comando_Sql.Query,
                             Parametros_Query: ( new string[] { "@Valor", "@Precio_Base", "@Habilitado" } ),
                             Argumentos_Query: ( new string[] { Valor.ToString(), Precio_Base.ToString(), Habilitado.ToString() } )
                        ) ;

                        Ejecutar
                        (
                            "update Productos\n" +
                            "set\n" +
                            "Nombre = @Nombre\n" +
                            "Descripcion = @Descripcion\n" +
                            "where ID = @ID ;",
                            Tipo_Comando_Sql_Seleccionado: Tipos_Comando_Sql.Query,
                            Parametros_Query: ( new string[] { "@Nombre", "@Descripcion", "@ID" } ),
                            Argumentos_Query: ( new string[] { Nombre.ToString(), Descripcion.ToString(), ID.ToString() } ) // Es que la funcion no esta pensada para que se le inserte un objeto DBNull
                        ) ;

                }
                # endregion
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
                                    Interfaz_Base_Datos.Tipos_Comando_Sql.Query,
                                    Unico_Parametro_Query: "@Nombre_Identificador_Usuario",
                                    Unico_Argumento_Query: Nombre_Identificador_Usuario
                                ) ;
                        
                        Sujeto_Existe = ( Resultado_Query.Rows.Count != 0 ) ? true : false ;
                        if ( Sujeto_Existe )
                        { 
                                if ( Resultado_Query.Rows.Count != 1 ) { throw new Exception($"Se encontraron `{ Resultado_Query.Rows.Count}` Sujetos para el Nombre_Identificador `{ Nombre_Identificador_Usuario }`.") ; }
                                return true ;
                        }
                        return false ;
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

                # if DEBUG_Conexion_Base_Datos
                public
                # else
                private
                # endif
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
                
                /// <summary>
                /// Consigue un join entre los Elementos de Subasta y Productos del sistema.
                /// </summary>
                /// <param name="Filtro_Consulta">Es el parametro que se usa para filtrar entre filas de los resultados de la busqueda. El solo se soportan como argumento "ID" o "Nombre".</param>
                /// <returns></returns>
                /// <exception cref="Exception"></exception>
                public static DataTable? Get_Productos_Join_Elementos_Subasta( string Filtro_Consulta = "", string Argumento_Consulta = "" )
                {
                        DataTable? Elementos_Subasta_JOIN_Productos ;

                        if ( ! ( Filtro_Consulta == "" && Argumento_Consulta == "" ) )
                        { 
                                if ( Filtro_Consulta != "ID" && Filtro_Consulta != "Nombre" ) { throw new Exception("Se ingreso un parametro no soportado para buscar entre el join de Elementos de Subasta y Productos.") ; }
                                string Parametro_Sentencia_Where ;

                                Parametro_Sentencia_Where = ( Filtro_Consulta == "ID" ) ? "Elementos_Subasta.ID" : "Productos.Nombre" ;
                                Console.WriteLine( $"where { Parametro_Sentencia_Where } = @Argumento_Consulta ;" ) ;

                                Elementos_Subasta_JOIN_Productos = ( DataTable? )
                                Ejecutar
                                (
                                     "select\n" +
                                     "Elementos_Subasta.ID,\n" +
                                     "Productos.Nombre,\n" +
                                     "Elementos_Subasta.Valor,\n" +
                                     "Elementos_Subasta.Precio_Base,\n" +
                                     "Elementos_Subasta.Habilitado,\n" +
                                     "Productos.Descripcion\n" +
                                     "from Elementos_Subasta\n" +
                                     "inner join Productos on Elementos_Subasta.ID = Productos.ID\n" +
                                    $"where { Parametro_Sentencia_Where } like @Argumento_Consulta ;",
                                     Tipos_Comando_Sql.Query,
                                     Unico_Parametro_Query: "@Argumento_Consulta",
                                     Unico_Argumento_Query: Argumento_Consulta
                                ) ;

                                if ( Convert.IsDBNull( Elementos_Subasta_JOIN_Productos ) ) { return null ; }
                                return Elementos_Subasta_JOIN_Productos ;
                                        
                        }
                        
                        
                        Elementos_Subasta_JOIN_Productos = ( DataTable? )
                        Ejecutar
                        (
                             "select " +
                             "Elementos_Subasta.ID, " +
                             "Productos.Nombre, " +
                             "Elementos_Subasta.Valor, " +
                             "Elementos_Subasta.Precio_Base, " +
                             "Elementos_Subasta.Habilitado " +
                             "from Elementos_Subasta " +
                             "inner join Productos on Elementos_Subasta.ID = Productos.ID ;",
                             Tipos_Comando_Sql.Query
                        ) ;

                        if ( Convert.IsDBNull( Elementos_Subasta_JOIN_Productos ) ) { return null ; }
                        return Elementos_Subasta_JOIN_Productos ;
                }
        }
}