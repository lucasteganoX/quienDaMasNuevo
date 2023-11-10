namespace TextBoxNumerico
{
        // [Designer("TextBoxNumerico")]
        public partial class TextBoxNumerico : System.Windows.Forms.TextBox
        {
                private string Respaldo_Text = "" ; // Es el valor anterior al del atributo Text. Si el input ingresado no es valido, a Text se le asigna este valor.
                                                        // Comienza como un string vacio el paso anterior a ingresar algo inadecuado de primeras es no tener nada en primer lugar.

                protected override void OnTextChanged( System.EventArgs e )
                {
                        foreach ( char Caracter in base.Text )
                        {
                                if ( ! char.IsDigit( Caracter ) ) 
                                {
                                        base.Text = Respaldo_Text ; // Cuando esto ocurre el cursor es movido al principio del texto.
                                        base.SelectionStart = base.Text.Length ; // Pone el cursor al final del texto.
                                        base.ScrollToCaret() ; // Si por algun motivo el texto es mas largo que el ancho del TextBox, scrollea(desliza) el texto del TextBox hasta el cursor.
                                        return ;
                                }
                        }
                        Respaldo_Text = base.Text ;

                        base.OnTextChanged( e ) ;
                }

                public TextBoxNumerico() { }

                // hololoolol

        }
}