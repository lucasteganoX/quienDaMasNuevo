using Org.BouncyCastle.Tls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// using Microsoft.DotNet.DesignTools.Designers ;
namespace Presentacion.Librerias_Locales ;

// [Designer("TextBoxSeguro")]
[Serializable]
public class TextBoxSeguro : TextBox
{
        private string Respaldo_Text = "" ; // Es el valor anterior al del atributo Text. Si el input ingresado no es valido, a Text se le asigna este valor.
                                                // Comienza como un string vacio el paso anterior a ingresar algo inadecuado de primeras es no tener nada en primer lugar.
        private bool Variable_Prohibir_Numeros ;
        [Category("Normas")]
        [DefaultValue(false)]
        public bool Prohibir_Numeros
        {
                get { return Variable_Prohibir_Numeros ; } 
                set
                { 
                        if ( Violacion_Restriccion_Numerica( Respaldo_Text ) ) { Respaldo_Text = "" ; }
                        if ( Violacion_Restriccion_Numerica( Text ) ) { Text = "" ; }
                        else { Respaldo_Text = Text ; }
                } 
        }
        private bool Variable_Prohibir_Letras = false ;
        [Category("Normas")]
        [DefaultValue(false)]
        public bool Prohibir_Letras
        { 
                get { return Variable_Prohibir_Letras ; }
                set
                {
                        if ( Violacion_Restriccion_Alphabetica( Respaldo_Text ) ) { Respaldo_Text = "" ; }
                        if ( Violacion_Restriccion_Alphabetica( Text ) ) { Text = "" ; }
                        else { Respaldo_Text = Text ; }
                }
        }
        private bool Variable_Prohibir_Espacios = false ;
        [Category("Normas")]
        [DefaultValue(false)]
        public bool Prohibir_Espacios
        {
                get { return Variable_Prohibir_Espacios ; } 
                set
                { 
                        if ( Violacion_Restriccion_Espacios( Respaldo_Text ) ) { Respaldo_Text = "" ; }
                        if ( Violacion_Restriccion_Espacios( Text ) ) { Text = "" ; }
                        else { Respaldo_Text = "" ; }
                }
        }

        // Implementacion externa
        public static bool Violacion_Restriccion_Numerica( string Muestra, bool Numeros_Estan_Permitidos )
        {
                if ( Numeros_Estan_Permitidos ) { return false ; }
                foreach ( char Caracter in Muestra) { if ( char.IsDigit( Caracter ) ) { return true ; } }
                return false ;       
        }
        public static bool Violacion_Restriccion_Alphabetica( string Muestra, bool Letras_Estan_Permitidas )
        {
                if ( Letras_Estan_Permitidas ) { return false ; }
                foreach ( char Caracter in Muestra ) { if ( char.IsLetter( Caracter ) ) { return true ; } }
                return false ;
        }
        public static bool Violacion_Restriccion_Espacios( string Muestra, bool Espacios_Estan_Permitidos )
        { 
                if ( Espacios_Estan_Permitidos ) { return false ; }
                foreach ( char Caracter in Muestra ) { if ( char.IsWhiteSpace( Caracter ) ) { return true ; } }
                return false ;
        }
        public static void Revertir_Text( ref TextBox TextBox_Operando, ref string Respaldo_Text )
        { 
                TextBox_Operando.Text = Respaldo_Text ; // Cuando esto ocurre el cursor es movido al principio del texto.
                TextBox_Operando.SelectionStart = TextBox_Operando.Text.Length ; // Pone el cursor al final del texto.
                TextBox_Operando.ScrollToCaret() ; // Si por algun motivo el texto es mas largo que el ancho del TextBox, scrollea(desliza) el texto del TextBox hasta el cursor.
                return ;
        }
        /// <summary>
        /// Llama a este metodo durante el evento textchanged de un textbox, y este se comportara como un textbox seguro.
        /// <remarks>Si el Respaldo_Text no es una opcion valida, este se restablecera a un string vacio. Ademas, si el metodo nunca llega a llamarse, el textbox no sera seguro, claramente.</remarks>
        /// </summary>
        /// <param name="TextBox_Operando">El textbox que se desea hacer seguro.</param>
        /// <param name="Respaldo_Text">El texto al que se restablecera el textbox cuando se hace una asignacion ilegal.</param>
        /// <param name="Numeros_Estan_Permitidos">Si se permitira ingresar numeros al textbox.</param>
        /// <param name="Letras_Estan_Permitidas">Si se permite ingresar letras al textbox.</param>
        /// <param name="Espacios_Estan_Permitidos">Si se permite ingresae espacios al textbox.</param>
        public static void Comportamiento_TextBoxSeguro( ref TextBox TextBox_Operando, ref string Respaldo_Text, bool Numeros_Estan_Permitidos, bool Letras_Estan_Permitidas, bool Espacios_Estan_Permitidos )
        { 
                if 
                ( 
                     Violacion_Restriccion_Numerica( TextBox_Operando.Text, Numeros_Estan_Permitidos ) ||
                     Violacion_Restriccion_Alphabetica( TextBox_Operando.Text, Letras_Estan_Permitidas ) || 
                     Violacion_Restriccion_Espacios( TextBox_Operando.Text, Espacios_Estan_Permitidos ) 
                )
                {
                        if
                        (
                                Violacion_Restriccion_Numerica( Respaldo_Text, Numeros_Estan_Permitidos ) ||
                                Violacion_Restriccion_Alphabetica( Respaldo_Text, Letras_Estan_Permitidas ) || 
                                Violacion_Restriccion_Espacios( Respaldo_Text, Espacios_Estan_Permitidos ) 
                        ) { Respaldo_Text = "" ; }
                        Revertir_Text( ref TextBox_Operando, ref Respaldo_Text ) ;
                        return ;
                }
                Respaldo_Text = TextBox_Operando.Text ;
        }

        // Implementacion interna
        private bool Violacion_Restriccion_Numerica( string? Muestra = null )
        {
                if ( ! Prohibir_Numeros ) { return false ; }
                foreach ( char Caracter in ( ( Muestra is null ) ? base.Text : Muestra ) ) { if ( char.IsDigit( Caracter ) ) { return true ; } }
                return false ;
        }
        private bool Violacion_Restriccion_Alphabetica( string? Muestra = null )
        { 
                if ( ! Prohibir_Letras ) { return false ; }
                foreach ( char Caracter in ( ( Muestra is null ) ? base.Text : Muestra ) ) { if ( char.IsLetter( Caracter ) ) { return true ; } }
                return false ;
        }
        private bool Violacion_Restriccion_Espacios( string? Muestra = null )
        { 
                if ( ! Prohibir_Espacios ) { return false ; }
                foreach ( char Caracter in ( ( Muestra is null ) ? base.Text : Muestra ) ) { if ( char.IsWhiteSpace( Caracter ) ) { return true ; } }
                return false ;
        }
        private void Revertir_Cambio()
        {
                base.Text = Respaldo_Text ; // Cuando esto ocurre el cursor es movido al principio del texto.
                base.SelectionStart = base.Text.Length ; // Pone el cursor al final del texto.
                base.ScrollToCaret() ; // Si por algun motivo el texto es mas largo que el ancho del TextBox, scrollea(desliza) el texto del TextBox hasta el cursor.
                return ;
        }

        protected override void OnTextChanged( EventArgs e )
        {
                if ( Violacion_Restriccion_Numerica() || Violacion_Restriccion_Alphabetica() || Violacion_Restriccion_Espacios() ) { Revertir_Cambio() ; }
                Respaldo_Text = base.Text ;
                base.OnTextChanged( e ) ;
        }

        // protected override void OnPaint(PaintEventArgs e){ base.OnPaint(e); }
        public TextBoxSeguro()
        {
                Size = new Size( 50, 30 ) ;
                MaxLength = 10 ; // El valor maximo de Int32 es un numero de 10 cifras.
        }
        public void InitializeComponent() { }
}
