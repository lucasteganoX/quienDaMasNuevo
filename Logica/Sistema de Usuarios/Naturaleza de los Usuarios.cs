using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

using Acceso_Datos ;
namespace Logica.Sistema_de_Usuarios
{
    // En el siguiente ejeplo "PepitoDominguez" es un Sujeto. "Persona", "Usuario" y "Proveedor" son tambien Objetos.
    // PepitoDominguez.Persona.Apellido ;
    // PepitoDominguez.Usuario.Nivel_Confidencialidad ;
    // PepitoDominguez.Proveedor.Nombre_Empresa ;

    // Eso es lo que quiero lograr.

    // Accede a la explicación del Sistema de Usuario a través de el siguiente documento: https://docs.google.com/document/d/1vkniu-EVmxt5IGS440FTfLy1h66yVYNEWEpHWglnBds/edit?usp=drivesdk

public class Clase_Sujeto
{
        # region >>---- Sobrecarga y Remplazo de miembros --------------------------------------------------------
        public static bool operator == ( Clase_Sujeto? Sujeto_Operando_1, Clase_Sujeto? Sujeto_Operando_2 )
        {
                const bool Los_Sujetos_NO_Son_Iguales = false ;
                const bool Los_Sujetos_Son_Iguales = true ;

                # region >>---- Igualdad de campos de los Sujetos ----------------------------------
                if ( ( Sujeto_Operando_1.Persona is null ) ^ ( Sujeto_Operando_2.Persona is null ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                if ( ( Sujeto_Operando_1.Usuario is null ) ^ ( Sujeto_Operando_2.Usuario is null ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                if ( ( Sujeto_Operando_1.Empleado is null ) ^ ( Sujeto_Operando_2.Empleado is null ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                if ( ( Sujeto_Operando_1.Proveedor is null ) ^ ( Sujeto_Operando_2.Proveedor is null ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                # endregion ------------------------------------------------------------------------

                # region >>---- Igualdad de las capas de los Sujetos -------------------------------
                if ( ! ( Sujeto_Operando_1.Persona == Sujeto_Operando_2.Persona ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                if ( ! ( Sujeto_Operando_1.Usuario == Sujeto_Operando_2.Usuario ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                if ( ! ( Sujeto_Operando_1.Empleado == Sujeto_Operando_2.Empleado ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                if ( ! ( Sujeto_Operando_1.Proveedor == Sujeto_Operando_2.Proveedor ) ) { return Los_Sujetos_NO_Son_Iguales ; }
                # endregion ------------------------------------------------------------------------

                return Los_Sujetos_Son_Iguales ;
        }

        public static bool operator != ( Clase_Sujeto Operando_Sujeto_1, Clase_Sujeto Operando_Sujeto_2 )
        { 
                return ! ( Operando_Sujeto_1 == Operando_Sujeto_2 ) ;
        }
        #endregion -----------------------------------------------------------------------------------------------

        #region >>---- Estado -----------------------------------------------------------------------------------
        public Clase_Persona? Persona { get; set; }
        public Clase_Usuario? Usuario { get; set; }
        public Clase_Empleado? Empleado { get; set; }
        public Clase_Proveedor? Proveedor { get; set; }
        #endregion ----------------------------------------------------------------------------------------------

        #region >>---- Claves Primarias -------------------------------------------------------------------------
        public string? Clave_Primaria
        {
                get
                {
                        if ( this.Persona is null ) { return null ; }
                        return this.Persona!.ID.ToString() ;
                }
        }

        public string? Clave_Primaria_Persona
        {
                get { return this.Persona!.ID!.ToString() ; }
        }

        public string? Clave_Primaria_Usuario
        {
                get
                {
                        if ( this.Persona == null || this.Usuario == null ) { return null ; }
                        return this.Persona!.ID! + ", " + this.Usuario!.Nombre_Identificador! ;
                }
        }

        public string? Clave_Primaria_Empleado
        {
                get
                {
                        if ( this.Persona == null || this.Empleado == null ) { return null ; }
                        return this.Persona!.ID! + ", " + this.Empleado!.ID! ;
                }
        }

        public string? Clave_Primaria_Proveedor
        {
                get
                {
                        if ( this.Persona == null || this.Proveedor == null ) { return null ; }
                        return this.Persona!.ID! + ", " + this.Proveedor!.ID! ;
                }

                // los this se podrían obvíar, simplificando los nombres, pero quizás se ve mejor así. Nc, despúes consulto con alguna gente.
        }

        #endregion ----------------------------------------------------------------------------------------------

        #region >>---- Metodos ----------------------------------------------------------------------------------
        private bool Sujeto_Solo_Contiene_Usuario()
        {
                if ( Persona is not null ) { return false ; }
                if ( Usuario is null ) { return false ; }
                if ( Empleado is not null ) { return false ; }
                if ( Proveedor is not null ) { return false ; }
         
                return true ;
        }
        
        public bool Es_Un_Sujeto_Invitado()
        {
                bool Usuario_Es_Invitado()
                { 
                        // Esta función NO checkea si la capa existe o no...
                        if ( Usuario.Nivel_Confidencialidad is null ) { return false ; }
                        if ( Usuario.Activo is null ) { return false ; }

                        if ( Usuario.Nombre_Identificador != "Invitado" ) { return false ; }
                        if ( Usuario.Contrasena != null ) { return false ; }
                        if ( Usuario.Nivel_Confidencialidad != Clase_Usuario.Confidencialidad_Minima ) { return false ; }
                        if ( Usuario.Activo != true ) { return false ; }
                        if ( Usuario.Pendiente_Sincronizar != false ) { return false ; }

                        return true ;
                }

                if ( ! Sujeto_Solo_Contiene_Usuario() ) { return false ; }
                if ( ! Usuario_Es_Invitado() ) { return false ; }

                return true ;
        }

        public bool Es_Un_Sujeto_Inidentificado()
        {   
               const bool Sujeto_Es_Inidentificado = true ;
                      
               bool Usuario_Es_Inidentificado()
               {
                       const bool Es_Inidentificado = true ;

                       // Esta función NO checkea si Usuario existe en primer lugar o no...
                       if ( ! ( Usuario.Nombre_Identificador is not null ) ) { return ( ! Es_Inidentificado ) ; }
                       if ( ! ( Usuario.Contrasena is not null ) ) { return ( ! Es_Inidentificado ) ; }
                       if ( ! ( Usuario.Nivel_Confidencialidad is null ) ) { return ( ! Es_Inidentificado ) ; }
                       if ( ! ( Usuario.Activo is null ) ) { return ( ! Es_Inidentificado ) ; }
                       if ( ! ( Usuario.Pendiente_Sincronizar is null ) ) { return ( ! Es_Inidentificado ) ; }

                      return Es_Inidentificado ;
               }
         
               if ( ! Sujeto_Solo_Contiene_Usuario() ) { return ( ! Sujeto_Es_Inidentificado ) ; }
               if ( ! Usuario_Es_Inidentificado() ) { return ( ! Sujeto_Es_Inidentificado ) ; }
 
               return Sujeto_Es_Inidentificado ;
        }

        public bool[] Capas_Pendientes_De_Sincronizar()
        {
                bool[] Capas_Pendientes = new bool[] { false, false, false, false } ;

                if ( Persona?.Pendiente_Sincronizar == true ) { Capas_Pendientes[0] = true ; }
                if ( Usuario?.Pendiente_Sincronizar == true ) { Capas_Pendientes[1] = true ; }
                if ( Empleado?.Pendiente_Sincronizar == true ) { Capas_Pendientes[2] = true ; }
                if ( Proveedor?.Pendiente_Sincronizar == true ) { Capas_Pendientes[3] = true ; }

                return Capas_Pendientes ;
        }

        // bool Sujeto_Es_Temporal()
        // bool Capa_Es_Temporal( enum Parametro_Capa_En_Cuestion )
                // enum Capa_En_Cuestion { Persona, Usuario, Empleado, Proveedor, Todas }

        #endregion ----------------------------------------------------------------------------------------------

        #region >>---- Constructores ----------------------------------------------------------------------------
        public Clase_Sujeto() { }
        public Clase_Sujeto( bool Parametro_Construir_Sujeto_Invitdo ) // ~Constructor de Sujeto Invitado
        {
                if ( Parametro_Construir_Sujeto_Invitdo == false ) { throw new ArgumentException("La gracia de el constructor del Sujeto Invitado, es que el Sujeto sea un Sujeto Invitado, sí, que locura ; el parametro booleano Construir Sujeto Invitado del constructor de Sujeto Invitado no puede valer falso.")  ; }

                this.Persona = null ;
                this.Empleado = null ;
                this.Proveedor = null ;

                this.Usuario = new Clase_Sujeto.Clase_Usuario( Parametro_Construir_Usuario_Invitado: true ) ;

        }
        public Clase_Sujeto (
                                bool Parametro_Construir_Sujeto_Inidentificado ,
                                string Parametro_Nombre_Identificador_Usuario_Inidentificado ,
                                string Parametro_Contrasena_Usuario_Inidentificado
                            )
        {
                this.Persona = null ;
                this.Empleado = null ;
                this.Proveedor = null ;

                this.Usuario = new Clase_Usuario( Parametro_Construir_Usuario_Inidentificado: true, Parametro_Nombre_Identificador: Parametro_Nombre_Identificador_Usuario_Inidentificado, Parametro_Contrasena: Parametro_Contrasena_Usuario_Inidentificado ) ;
        }

        public Clase_Sujeto(Acceso_Datos.Interfaz_Base_Datos.Representacion_Sujeto Representacion_Sujeto )
        {
                { 
                        Persona =
                                new Clase_Persona
                                (
                                    Parametro_ID: Convert.ToInt32( Representacion_Sujeto.Atributos_Persona[0] ),
                                    Parametro_Nombre: Representacion_Sujeto.Atributos_Persona[1],
                                    Parametro_Apellido: Representacion_Sujeto.Atributos_Persona[2],
                                    Parametro_Telefono: Representacion_Sujeto.Atributos_Persona[3],
                                    Parametro_Pendiente_Sincronizar: false
                                ) ;               
                }

                if ( Representacion_Sujeto.Atributos_Usuario is not null )
                {
                        Usuario =
                                new Clase_Usuario
                                (
                                        Parametro_Nombre_Identificador: Representacion_Sujeto.Atributos_Usuario[0],
                                        Parametro_Contrasena: Representacion_Sujeto.Atributos_Usuario[1],
                                        Parametro_Nivel_Confidencialidad: Representacion_Sujeto.Atributos_Usuario[2],
                                        Parametro_Activo: ( Representacion_Sujeto.Atributos_Usuario[3] == "true" ) ? false : true // Recordar que `Representacion_Sujeto.Atributos_Usuario[3]` representa la INactividad, mientras que el campo del Usuario representa la ACTIVIDAD. Si, lo diseñe diferente en un inicio y no lo cambiare ahora.
                                ) ;
                }
               
                if ( Representacion_Sujeto.Atributos_Empleado is not null )
                { 
                        bool Empleado_Tiene_Tareas_Asignadas ;

                        Empleado =
                                new Clase_Empleado
                                (
                                    Parametro_ID: Convert.ToInt32( Representacion_Sujeto.Atributos_Empleado[0] ),
                                    Parametro_Cantidad_Horas_Trabajadas: Convert.ToInt32( Representacion_Sujeto.Atributos_Empleado[1] ),
                                    Parametro_Pendiente_Sincronizar: false
                                ) ;

                        Empleado_Tiene_Tareas_Asignadas = ( Representacion_Sujeto.Atributos_Empleado.Length > 2 ) ? true : false ;
                        if ( Empleado_Tiene_Tareas_Asignadas )
                        {
                                string[] Tareas_Asignadas ; // Las Tareas Asignadas que contiene la representacion del Sujeto para el Empleado.
                                int Cantidad_Tareas_Asignadas ; // La cantidad de Tareas Asignadas que tiene el Empleado.

                                Cantidad_Tareas_Asignadas = Representacion_Sujeto.Atributos_Empleado.Length - 2 ;
                                Tareas_Asignadas = new string[ Cantidad_Tareas_Asignadas ] ;
                                        
                                for ( int Indice_Tarea_Asignada = 0 ; Indice_Tarea_Asignada > Cantidad_Tareas_Asignadas ; Indice_Tarea_Asignada++ ) { Tareas_Asignadas[ Indice_Tarea_Asignada ] = Representacion_Sujeto.Atributos_Empleado[ Indice_Tarea_Asignada + 2 ] ; }
                                if ( Tareas_Asignadas.Length != Cantidad_Tareas_Asignadas ) { throw new Exception("Se trato de construir un Empleado basado en una Representacion_Sujeto y la Cantidad de Tareas Asignadas que hay en la representacion y en la construccion no coinciden. Uh-uh!") ; }

                                Empleado.Tareas_Asignadas = Tareas_Asignadas ;
                        }
                }

                if ( Representacion_Sujeto.Atributos_Proveedor is not null )
                {
                        Proveedor =
                                new Clase_Proveedor
                                (
                                    Parametro_ID: Convert.ToInt32( Representacion_Sujeto.Atributos_Proveedor[0] ),
                                    Parametro_Nombre_Empresa: Representacion_Sujeto.Atributos_Proveedor[1]
                                ) ;
                }
                       
        }
        #endregion ----------------------------------------------------------------------------------------------

        #region >>---- Delcaración de Capas ---------------------------------------------------------------------
        public sealed class Clase_Persona
        {
                #region >>---- Sobrecarga y remplazo de miembros ----------------------------------------------------
                public static bool operator == ( Clase_Persona? Persona_Operando_1, Clase_Persona? Persona_Operando_2 )
                {
                        const bool Las_Personas_NO_Son_Iguales = false ;
                        const bool Las_Personas_Son_Iguales = true ;

                        if ( ! ( Persona_Operando_1?.ID == Persona_Operando_2?.ID ) ) { return Las_Personas_NO_Son_Iguales ; }
                        if ( ! ( Persona_Operando_1?.Nombre == Persona_Operando_2?.Nombre ) ) { return Las_Personas_NO_Son_Iguales ; }
                        if ( ! ( Persona_Operando_1?.Apellido == Persona_Operando_2?.Apellido ) ) { return Las_Personas_NO_Son_Iguales ; }
                        if ( ! ( Persona_Operando_1?.Telefono == Persona_Operando_2?.Telefono ) ) { return Las_Personas_NO_Son_Iguales ; }
                        if ( ! ( Persona_Operando_1?.Pendiente_Sincronizar == Persona_Operando_2?.Pendiente_Sincronizar ) ) { return Las_Personas_NO_Son_Iguales ; }
                        
                        return Las_Personas_Son_Iguales ;
                }

                public static bool operator != ( Clase_Persona Persona_Operando_1, Clase_Persona Persona_Operando_2 )
                {
                        return  ( ! ( Persona_Operando_1 == Persona_Operando_2 ) ) ;
                }
        
                public override bool Equals( Object? Objeto_A_Comparar )
                { 
                        if ( Objeto_A_Comparar is not Clase_Persona ) { return false ; }
                        if ( ( this is null ) ^ ( Objeto_A_Comparar is null ) ) { return false ; }

                        return ( this == (Clase_Persona) Objeto_A_Comparar! ) ; 
                }
                #endregion ----------------------------------------------------------------------------------------------


                public bool Pendiente_Sincronizar { get; set; }

                private int? _Variable_ID = null ; // La variable detrás de la propiedad, o método getter "ID".
                public int? ID // Un número arbitrario de un contador en la base de datos. // Esto es++ un método getter para la Variable ID.
                {
                        set
                        {
                                if ( value < 0 ) { throw new ArgumentException("El valor del string que representa a Numero de Identificion no puede ser negativo.") ; }
                                _Variable_ID = value ;
                        }

                        get
                        {
                                return _Variable_ID ;
                        }
                }

                public string Nombre { get; set; }
                public string Apellido { get; set; }
                public string Telefono { get; set; } 

                public Clase_Persona
                ( 
                    int Parametro_ID,
                    string Parametro_Nombre,
                    string Parametro_Apellido,
                    string Parametro_Telefono,
                    bool Parametro_Pendiente_Sincronizar = false
                )
                {
                        this.ID = Parametro_ID ; // La referencia ID es una propiedad set personalizada. La cual solo checkea si el valor es menor a cero.
                        this.Nombre = Parametro_Nombre ;
                        this.Apellido = Parametro_Apellido ;
                        this.Telefono = Parametro_Telefono ;
                        this.Pendiente_Sincronizar = Parametro_Pendiente_Sincronizar ;
                }
        }

        public sealed class Clase_Usuario
        {
                #region >>---- Sobrecarga y remplazo de miembros ----------------------------------------------------
                public static bool operator == ( Clase_Usuario? Usuario_Operando_1, Clase_Usuario? Usuario_Operando_2 )
                {
                        const bool Los_Usuarios_NO_Son_Iguales = false ;
                        const bool Las_Usuarios_Son_Iguales = true ;
                
                         if ( ! ( Usuario_Operando_1?.Nombre_Identificador == Usuario_Operando_2?.Nombre_Identificador ) ) { return Los_Usuarios_NO_Son_Iguales ; }
                         if ( ! ( Usuario_Operando_1?.Contrasena == Usuario_Operando_2?.Contrasena ) ) { return Los_Usuarios_NO_Son_Iguales ; }
                         if ( ! ( Usuario_Operando_1?.Nivel_Confidencialidad == Usuario_Operando_2?.Nivel_Confidencialidad ) ) { return Los_Usuarios_NO_Son_Iguales ; }
                         if ( ! ( Usuario_Operando_1?.Activo == Usuario_Operando_2?.Activo )) { return Los_Usuarios_NO_Son_Iguales ; }
                         if ( ! ( Usuario_Operando_1?.Pendiente_Sincronizar == Usuario_Operando_2?.Pendiente_Sincronizar ) ) { return Los_Usuarios_NO_Son_Iguales ; }
                
                         return Las_Usuarios_Son_Iguales ;
                }

                public static bool operator != ( Clase_Usuario? Usuario_Operando_1, Clase_Usuario? Usuario_Operando_2 )
                {
                         return  ( ! ( Usuario_Operando_1 == Usuario_Operando_2 ) ) ;
                }
        
                public override bool Equals( Object? Objeto_A_Comparar )
                {
                         if ( Objeto_A_Comparar is not Clase_Usuario ) { return false ; }
                         if ( ( this is null ) ^ ( Objeto_A_Comparar is null ) ) { return false ; }

                         return ( this == (Clase_Usuario) Objeto_A_Comparar! ) ; 
                }
                #endregion ------------------------------------------------------------------------------------------
                # region >>---- Métodos -----------------------------------------------------------------------------
                bool Nivel_De_Confidencialidad_Es_Valido( string Cadena )
                {
                        const int Cantidad_Digitos_Nivel_Confidencialidad = 4 ;
                        
                        if ( Cadena.Length != Cantidad_Digitos_Nivel_Confidencialidad ) { return false ; }
                        foreach ( char Caracter in Cadena ) { if ( Caracter is not '0' || Caracter is not '1' ) { return false ; } }
                        return true ;
                }
                # endregion -----------------------------------------------------------------------------------------

                // Nivel Confidencialidad:
                // Representa la collecion de permisos o cosas que tiene permitido hacer un determinado Usuario.
                // Una cadena de bits, en donde cada posicion de un bit representa una accion que tiene permitida hacer un Usuario.
                // Naturalmente, un bit en 1, significa que el Usuario puede hacer la accion que corresponde a ese bit. Un bit en 0 significa que no tiene permitido hacer esa accion.
                // 
                // Posiciones de los bits:
                // Bit numero - Accion que le corresponde
                // 0 - Administración de Sujetos
                // 1 - Administración de Lotes y Productos
                // 2 - Pago a Sujetos
                // 3 - Publicación de Lotes y Productos
                //
                // Hay una excepcion a esto. El nivel de confidencialidad es null para Usuaeios Invitados.


                public const string Confidencialidad_Maxima = "1111" ;
                public const string Confidencialidad_Minima = "0000" ;

                public bool? Pendiente_Sincronizar { get; set; }

                public string Nombre_Identificador { get; set; }
                public string? Contrasena { get; set; }
                public string? Nivel_Confidencialidad { get; set; }
                public bool? Activo { get; set; }

                public Clase_Usuario
                ( // ~Constructor de Usuario // ~Constructor Usuario
                        string Parametro_Nombre_Identificador ,
                        string Parametro_Contrasena ,
                        string Parametro_Nivel_Confidencialidad = Confidencialidad_Minima ,
                        bool Parametro_Activo = true ,
                        bool Parametro_Pendiente_Sincronizar = false
                )
                {
                #region >>----- Guard Clause / Clausula Guardian
            if ( string.IsNullOrWhiteSpace(Parametro_Nombre_Identificador) ) { throw new ArgumentOutOfRangeException("Se debe proporcionar un Nombre Identificador para el Usuario, el cual no puede estar vacio ni ser solo espacios en blanco.")  ; }
            if ( string.IsNullOrEmpty(Parametro_Contrasena) ) { throw new ArgumentOutOfRangeException($"Se debe proporcionar una Contrasena para el Usuario {Parametro_Nombre_Identificador} que se pretenden crear y esta no debe estar vacia.")  ; }

            if ( Parametro_Nombre_Identificador == "Invitado" ) { throw new ArgumentException("El Nombre Identificador 'Invitado' solo está permitido para Usuarios Invitados, los cuales solo están permitidos para Sujetos Invitados. Considera construir un Sujeto Invitado.")  ; }
            
            if ( Nivel_De_Confidencialidad_Es_Valido( Parametro_Nivel_Confidencialidad ) ) { throw new ArgumentException("El Nivel de Confidencialidad no valido. Asegurate que la cadena sea de el largo adecuado y que solo contenga digitos binarios(ceros y unos).") ; }
            #endregion -------------------------------------

                        Nombre_Identificador = Parametro_Nombre_Identificador ;
                        Contrasena = Parametro_Contrasena ;
                        Nivel_Confidencialidad = Parametro_Nivel_Confidencialidad ;
                        Activo = Parametro_Activo ;
                        Pendiente_Sincronizar = Parametro_Pendiente_Sincronizar ;
                }

                public Clase_Usuario( bool Parametro_Construir_Usuario_Invitado ) // ~Constructor de Usuario Invitado // ~Constructor Usuario Invitado
                {
                        if ( Parametro_Construir_Usuario_Invitado == false ) { throw new ArgumentOutOfRangeException( "Vos sos re listo. Si NO vas hacer un Usuario Invitado, NO utilices su constructor ; El valor del Parametro de Invitado no puede ser false en el constructor de Sujetos Invitados.") ; }

                        this.Nombre_Identificador = "Invitado" ;
                        this.Contrasena = null ;
                        this.Nivel_Confidencialidad = Confidencialidad_Minima ;
                        this.Activo = true ;
                        this.Pendiente_Sincronizar = false ;
                }

                public Clase_Usuario
                ( // ~Constructor de Usuario Inidentificado // ~Constructor Usuario Inidentificado
                   bool Parametro_Construir_Usuario_Inidentificado ,
                   string Parametro_Nombre_Identificador ,
                   string Parametro_Contrasena
                )
                {
                        this.Nombre_Identificador = Parametro_Nombre_Identificador ;
                        this.Contrasena = Parametro_Contrasena ;
                        this.Nivel_Confidencialidad = null ;
                        this.Activo = null ;
                        this.Pendiente_Sincronizar = null ;
                }


        }

        public sealed class Clase_Empleado
        {
                #region >>---- Sobrecarga y remplazo de miembros ----------------------------------------------------
                public static bool operator == ( Clase_Empleado? Empleado_Operando_1, Clase_Empleado? Empleado_Operando_2 )
                {
                        const bool Los_Empleados_NO_Son_Iguales = false ;
                        const bool Los_Empleados_Son_Iguales = true ;

                        if ( ! ( Empleado_Operando_1?.ID == Empleado_Operando_2?.ID ) ) { return Los_Empleados_NO_Son_Iguales ; }
                        if ( ! ( Empleado_Operando_1?.Cantidad_Horas_Trabajadas == Empleado_Operando_2?.Cantidad_Horas_Trabajadas ) ) { return Los_Empleados_NO_Son_Iguales ; }
                        if ( ! ( Empleado_Operando_1?.Tareas_Asignadas == Empleado_Operando_2?.Tareas_Asignadas ) ) { return Los_Empleados_NO_Son_Iguales ; }
                        if ( ! ( Empleado_Operando_1?.Pendiente_Sincronizar == Empleado_Operando_2?.Pendiente_Sincronizar ) ) { return Los_Empleados_NO_Son_Iguales ; }
                  
                        return Los_Empleados_Son_Iguales ;
                }

                public static bool operator != ( Clase_Empleado? Empleado_Operando_1, Clase_Empleado? Empleado_Operando_2 )
                {
                        return  ( ! ( Empleado_Operando_1 == Empleado_Operando_2 ) ) ;
                }
        
                public override bool Equals( Object? Objeto_A_Comparar )
                {
                        if ( Objeto_A_Comparar is not Clase_Empleado ) { return false ; }
                        if ( ( this is null ) ^ ( Objeto_A_Comparar is null ) ) { return false ; }

                        return ( this == (Clase_Empleado) Objeto_A_Comparar! ) ; 
                }
                #endregion ------------------------------------------------------------------------------------------

                public bool Pendiente_Sincronizar { get; set; }

                private int? _Variable_ID = null ; // La variable detrás de la propiedad, o método getter "ID".
                public int? ID // Un número arbitrario de un contador en la base de datos. // Esto es un método getter para la Variable ID.
                {
                        set
                        {
                                if ( value < 0 ) { throw new ArgumentException("El valor del string que representa a la ID del Empleado no puede ser negativo.") ; }
                                _Variable_ID = value ;
                        }

                        get
                        {
                                return _Variable_ID ;
                        }
                }

                public int Cantidad_Horas_Trabajadas ;
                public string[]? Tareas_Asignadas ; // Tareas que es? Vano' a ponerlo como un Array y después cualquier cosa lo cambiamos. Seguramente termine siendo un ArrayList o algo. Veremos...


                public Clase_Empleado( int Parametro_ID, int Parametro_Cantidad_Horas_Trabajadas, string[] Parametro_Tareas_Asignadas = null!, bool Parametro_Pendiente_Sincronizar = false )
                {
                        if ( Cantidad_Horas_Trabajadas < 0 ) { throw new ArgumentOutOfRangeException("La Cantidad de Horas Trabajadas no puede ser menor que cero :)") ; }

                        ID = Parametro_ID ;
                        Cantidad_Horas_Trabajadas = Parametro_Cantidad_Horas_Trabajadas ;
                        if ( Parametro_Tareas_Asignadas is null ) { Tareas_Asignadas = new string[0] ; } // En vez de esto ví que se puede utilizar el operador "??=". Esto es más simple.
                        this.Pendiente_Sincronizar = Parametro_Pendiente_Sincronizar ;
                }
        }

        public sealed class Clase_Proveedor
        {
                #region >>---- Sobrecarga y remplazo de miembros ----------------------------------------------------
                public static bool operator == ( Clase_Proveedor? Proveedor_Operando_1, Clase_Proveedor? Proveedor_Operando_2 )
                {
                        const bool Los_Proveedores_NO_Son_Iguales = false ;
                        const bool Los_Proveedores_Son_Iguales = true ;

                        if ( ! ( Proveedor_Operando_1?.ID == Proveedor_Operando_2?.ID ) ) { return Los_Proveedores_NO_Son_Iguales ; }
                       // if ( ! ( Proveedor_Operando_1?.Nombre_Empresa == Proveedor_Operando_2?.Nombre_Empresa ) ) { return Los_Proveedores_NO_Son_Iguales ; }
                        if ( ! ( Proveedor_Operando_1?.Pendiente_Sincronizar == Proveedor_Operando_2?.Pendiente_Sincronizar ) ) { return Los_Proveedores_NO_Son_Iguales ; }
                     
                        return Los_Proveedores_Son_Iguales ;
                }

                public static bool operator != ( Clase_Proveedor? Proveedor_Operando_1, Clase_Proveedor? Proveedor_Operando_2 )
                {
                        return  ( ! ( Proveedor_Operando_1 == Proveedor_Operando_2 ) ) ;
                }
        
                public override bool Equals( Object? Objeto_A_Comparar )
                {
                        if ( Objeto_A_Comparar is not Clase_Proveedor ) { return false ; }
                        if ( ( this is null ) ^ ( Objeto_A_Comparar is null ) ) { return false ; }

                        return ( this == (Clase_Proveedor) Objeto_A_Comparar! ) ; 
                }
                #endregion ------------------------------------------------------------------------------------------

                public bool Pendiente_Sincronizar { get; set; }

                private int? _Variable_ID = null ; // La variable detrás de la propiedad, o método getter "ID".
                public int? ID // Un número arbitrario de un contador en la base de datos.
                {
                        set
                        {
                                if ( value < 0 ) { throw new ArgumentException("El valor del string que representa a la ID del Empleado no puede ser negativo.") ; }
                                _Variable_ID = value ;
                        }

                        get
                        {
                                return _Variable_ID ;
                        }
                }

                string? _Variable_Nombre_Empresa ;
                public string? Nombre_Empresa { get; set; }

                public Clase_Proveedor( int Parametro_ID, string? Parametro_Nombre_Empresa, bool Parametro_Pendiente_Sincronizar = false )
                {
                        ID = Parametro_ID ;
                        Nombre_Empresa = Parametro_Nombre_Empresa ;
                        Pendiente_Sincronizar = Parametro_Pendiente_Sincronizar ;
                }
        }
                #endregion --------------------------------------------------------------------------------------
}
}
