
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

using Logica.Sistema_de_Usuarios;

/*      Esta seccion de la clase Formulario Login se encarga de almacenar todo aquello que permite acceder al estado e informacion del Formulario_Login.
 *      Esta parte de la clase contiene:
 *      * Métodos que operan sobre el Formulario_Login y arrojan información sobre él.
 *      * Getters que devuelven cachos especificos del estado del Formulario_Login.
 *      * Variables que representan cosas que le ocurren al formulario pero no están directamente involucradas con su funcionamiento.
 *      
 *      Llamé a este archivo "Formulario_Login.Mirador.cs" porque aquí se proveen formas de ver cómo está y qué le ocurre al Formulario_Login, sin inter
 *      ferir en el accionar del mismo. Similar a cómo somos capaces de observar a los animales desde miradores y averiguar que les ocurre sin que ellos
 *      sean quienes nos dicen; sin que ellos se involucren activamente en dejarnos saber.
 *      Entonces el nombre representa que es en este archivo que se puede acceder a información sobre lo que le ocurre a el Formulario_Login. Y que aquí
 *      no se trata su funcionamiento.
 */

namespace Presentacion.Login
{
        public partial class Login
        {
                public CloseReason Motivo_Ceirre_Formulario ;

                public enum Codigo_Salida_Formulario_Login
                { 
                        Acceso_Conseguido ,
                        Interrupcion_Voluntaria
                }
                        
                public enum Modos_Formulario_Login
                {
                        Ingreso ,
                        Registro
                }

                public Modos_Formulario_Login Modo_Seleccionado
                {
                        get
                        {
                                if ( RJToggleButton_ModoIngreso.Checked ) { return Modos_Formulario_Login.Ingreso ; }
                                return Modos_Formulario_Login.Registro ;
                        }
                }

                public bool Modo_Invitado
                { 
                        get
                        {
                                return CheckBox_ModoInvitado.Checked ;
                        }
                }
               

                
                public class QuedanCamposVaciosException : ApplicationException
                {
                        public QuedanCamposVaciosException() : base( message: "Quedaron campos vacios en este ciclo del Formulario_Login." ) {}
                }

                public class RegistroEnModoInvitadoException : ApplicationException
                {
                        public RegistroEnModoInvitadoException() : base( message: "Se trató de registrarse en Modo Invitado." ) {}        
                }

                public class UsuarioOContrasenaIncorrectosException : ApplicationException
                {
                        public UsuarioOContrasenaIncorrectosException() : base("El Nombre Identificador o la Contrasena del Usuario Inidentificado ingresado no son correctos.") {}
                }

                public class UsuarioInactivoException : ApplicationException
                { 
                        public UsuarioInactivoException() : base("El Usuario ingresado esta inactivo. Se le deniega el acceso al sistema.") {}        
                }

                public bool Quedan_Campos_Vacios() // "usuario" = persona usando el programa. "Usuario" = capa de usuario.
                {
                        Modos_Formulario_Login Intencion_usuario = Modo_Seleccionado ;
                        const bool Hay_Campos_Vacios = true ;

                        if ( string.IsNullOrWhiteSpace( TextBox_NombreUsuario.Text ) ) { return Hay_Campos_Vacios ; }
                        if ( string.IsNullOrWhiteSpace( TextBox_Contrasena.Text ) ) { return Hay_Campos_Vacios ; }

                        if ( Intencion_usuario.ToString() == "Registro" )
                        {
                                // Si campo a esta vacío devolver verdadero
                                // Y así con los demás...
                        }
                        return ( ! Hay_Campos_Vacios ) ;
                }

                public Clase_Sujeto Conseguir_Sujeto_Formulario()
                {
                        string Get_Hash_SHA256( string Contrasena )
                        {
                                using ( System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
                                {
                                        byte[] Bytes_Contrasena = Encoding.UTF8.GetBytes( Contrasena );
                                        byte[] Hash_Contrasena_En_Bytes = sha256.ComputeHash(Bytes_Contrasena);

                                        StringBuilder builder = new StringBuilder();
                                        for (int i = 0; i < Hash_Contrasena_En_Bytes.Length; i++) { builder.Append( Hash_Contrasena_En_Bytes[i].ToString("x2") ) ; } // Convierte a hexadecimal

                                        return builder.ToString();
                                }
                        }

                        string Nombre_Identificador = TextBox_NombreUsuario.Text ;
                        string Contrasena = Get_Hash_SHA256( TextBox_Contrasena.Text ) ;

                        return new Clase_Sujeto( Parametro_Construir_Sujeto_Inidentificado: true, Parametro_Nombre_Identificador_Usuario_Inidentificado: Nombre_Identificador, Parametro_Contrasena_Usuario_Inidentificado: Contrasena ) ;
                }
        }
}
