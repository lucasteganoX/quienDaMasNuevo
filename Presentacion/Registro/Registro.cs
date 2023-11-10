using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Media;
using System.Reflection;
using Logica.Procesamiento_Sujetos;
namespace Presentacion.Registro
{
        public partial class Registro : Form
        {
                public Registro()
                {
                        InitializeComponent();
                }

                // Persona
                string Nombre { get { return TextBox_Nombre.Text; } set { TextBox_Nombre.Text = value; } }
                string Apellido { get { return TextBox_Apellido.Text; } set { TextBox_Apellido.Text = value; } }
                string Telefono { get { return TextBox_Telefono.Text; } set { TextBox_Telefono.Text = value; } }
                string Email { get { return TextBox_Email.Text; } set { TextBox_Email.Text = value; } }

                // Usuario
                bool Registrar_Usuario
                {
                        get { return CheckBox_Usuario.Checked; }
                        set
                        {
                                Nombre_Identificador = "";
                                Contrasena = "";
                                Confirmacion_Contrasena = "";
                                TextBox_Nombre_Identificador.Enabled = value;
                                TextBox_Contrasena.Enabled = value;
                                TextBox_Confirmacion_Contrasena.Enabled = value;
                        }
                }
                string Nombre_Identificador { get { return TextBox_Nombre_Identificador.Text; } set { TextBox_Nombre_Identificador.Text = value; } }
                string Contrasena { get { return TextBox_Contrasena.Text; } set { TextBox_Contrasena.Text = value; } }
                string Confirmacion_Contrasena { get { return TextBox_Confirmacion_Contrasena.Text; } set { TextBox_Confirmacion_Contrasena.Text = value; } }

                // Proveedor
                bool Registrar_Proveedor
                {
                        get { return CheckBox_Proveedor.Checked; }
                        set
                        {
                                Nombre_Empresa = "";
                                Email_Empresa = "";
                                CheckBox_Tiene_Empresa.Checked = value;
                                CheckBox_Tiene_Empresa.Enabled = value;
                        }
                }
                bool Representa_Empresa
                {
                        get { return CheckBox_Tiene_Empresa.Checked; }
                        set
                        {
                                Barrio = "";
                                Calle1 = "";
                                Calle2 = "";
                                Indicaciones = "";
                                TextBox_Nombre_Empresa.Enabled = value;
                                TextBox_Email_Empresa.Enabled = value;
                                TextBox_Barrio.Enabled = value;
                                TextBox_Calle1.Enabled = value;
                                TextBox_Calle2.Enabled = value;
                                TextBox_Indicaciones.Enabled = value;
                        }
                }
                string? Nombre_Empresa { get { return ((TextBox_Nombre_Empresa.Text != "") ? TextBox_Nombre_Empresa.Text : null); } set { TextBox_Nombre_Empresa.Text = value; } }
                string? Email_Empresa { get { return ((TextBox_Email_Empresa.Text != "") ? TextBox_Email_Empresa.Text : null); } set { TextBox_Email_Empresa.Text = value; } }
                string? Barrio { get { return ((TextBox_Barrio.Text != "") ? TextBox_Barrio.Text : null); } set { TextBox_Barrio.Text = value; } }
                string? Calle1 { get { return ((TextBox_Calle1.Text != "") ? TextBox_Calle1.Text : null); } set { TextBox_Calle1.Text = value; } }
                string? Calle2 { get { return ((TextBox_Calle2.Text != "") ? TextBox_Calle2.Text : null); } set { TextBox_Calle2.Text = value; } }
                string? Indicaciones { get { return ((TextBox_Indicaciones.Text != "") ? TextBox_Indicaciones.Text : null); } set { TextBox_Indicaciones.Text = value; } }

                // Efecto de sonido
                void Reproducir_Tono_Registrado()
                {
                        SoundPlayer Reproductor;
                        using Stream Tono_Registrado = Assembly.GetExecutingAssembly().GetManifestResourceStream("Presentacion.Registro.Tono_Registrado.wav");
                        Reproductor = new SoundPlayer(Tono_Registrado);
                        try { Reproductor.Play(); }
                        catch { }
                }

                Dictionary<string, string> Get_Atributos_Persona()
                {
                        Dictionary<string, string>? Atributos_Persona = new Dictionary<string, string>();
                        Atributos_Persona["Nombre"] = Nombre;
                        Atributos_Persona["Apellido"] = Apellido;
                        Atributos_Persona["Telefono"] = Telefono;
                        Atributos_Persona["Email"] = Email;
                        return Atributos_Persona;
                }
                Dictionary<string, string>? Get_Atributos_Usuario()
                {
                        // Esta es una adaptacion de una solucion dada por ChatGPT.
                        string Get_Hash_SHA256(string Contrasena)
                        {
                                using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
                                {
                                        string Hash_Contrasena; // El hash de la Contrasena en formato alphanumerico(string de toda la vida).
                                        byte[] Bytes_Contrasena; // Es la Contrasena en bytes
                                        byte[] Bytes_Hash_Contrasena; // Es el hash de la Contrasena en bytes

                                        Bytes_Contrasena = System.Text.Encoding.UTF8.GetBytes(Contrasena);
                                        Bytes_Hash_Contrasena = sha256.ComputeHash(Bytes_Contrasena);

                                        System.Text.StringBuilder builder = new System.Text.StringBuilder();
                                        for (int i = 0; i < Bytes_Hash_Contrasena.Length; i++) { builder.Append(Bytes_Hash_Contrasena[i].ToString("x2")); } // Convierte a hexadecimal

                                        Hash_Contrasena = builder.ToString();
                                        return Hash_Contrasena;
                                }
                        }
                        if (!Registrar_Usuario) { return null; }
                        Dictionary<string, string>? Atributos_Usuario = new Dictionary<string, string>();
                        Atributos_Usuario["Nombre_Identificador"] = Nombre_Identificador;
                        Atributos_Usuario["Contrasena"] = Get_Hash_SHA256(Contrasena);
                        return Atributos_Usuario;
                }
                Dictionary<string, string?>? Get_Atributos_Proveedor()
                {
                        if (!Registrar_Proveedor) { return null; }
                        Dictionary<string, string?>? Atributos_Proveedor = new Dictionary<string, string?>();
                        Atributos_Proveedor["Nombre_Empresa"] = Nombre_Empresa!;
                        Atributos_Proveedor["Email_Empresa"] = Email_Empresa!;
                        Atributos_Proveedor["Barrio"] = Barrio!;
                        Atributos_Proveedor["Calle1"] = Calle1!;
                        Atributos_Proveedor["Calle2"] = Calle2!;
                        Atributos_Proveedor["Indicaciones"] = Indicaciones!;
                        return Atributos_Proveedor;
                }

                private void CheckBox_Proveedor_CheckedChanged(object sender, EventArgs e) { Registrar_Proveedor = CheckBox_Proveedor.Checked; }
                private void CheckBox_Tiene_Empresa_CheckedChanged(object sender, EventArgs e) { Representa_Empresa = CheckBox_Tiene_Empresa.Checked; }
                private void CheckBox_Usuario_CheckedChanged(object sender, EventArgs e) { Registrar_Usuario = CheckBox_Usuario.Checked; }


                // MessageBoxes
                void Mostrar_MessageBox_Se_Necesita_Una_Contrasena()
                {
                        MessageBox.Show
                        (
                                caption: "Falta una contraseña",
                                text: "Ingresa una contraseña para poder crear el Usuario. Los Usuarios sin contraseña no son permitidos.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Falta_Un_Nombre_Identificador()
                {
                        MessageBox.Show
                        (
                                caption: "Falta un Nombre Identificador.",
                                text: "Ingresa un Nombre Identificador para crear el Usuario.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Nombre_Identificador_Ya_Tomado()
                {
                        MessageBox.Show
                        (
                                caption: "Nombre Identificador ya tomado.",
                                text: $"El Nombre Identificador `{Nombre_Identificador}`ya es propiedad de otro Usuario. Selecciona otro.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                DialogResult Mostrar_MessageBox_Confirmar_Contrasena_Corta()
                {
                        DialogResult Eleccion_Usuario =
                        MessageBox.Show
                        (
                                caption: "La contraseña seleccionada es corta.",
                                text: "La contraseña que indicaste es bastante corta y sencilla de sobrepasar.\nSe continuará con la contraseña que seleccionaste de igual forma.",
                                buttons: MessageBoxButtons.OKCancel,
                                icon: MessageBoxIcon.Warning,
                                owner: this
                        );
                        return Eleccion_Usuario;
                }
                void Mostrar_MessageBox_Informacion_Parcial_Empresa()
                {
                        MessageBox.Show
                        (
                                caption: "Se proporcionó información parcial sobre la empresa.",
                                text: "Llena todos los datos de la empresa para registrarte representando a una.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Faltan_Campos_Persona()
                {
                        MessageBox.Show
                        (
                                caption: "Falta información personal.",
                                text: "Se requiere el nombre, el apellido y un telefono para registrar a una Persona.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Contrasenas_No_Coinciden()
                {
                        MessageBox.Show
                        (
                                caption: "Las contraseñas no coinciden.",
                                text: "Asegurate de que la primera contraseña sea la misma que la segunda.",
                                icon: MessageBoxIcon.Error,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }
                void Mostrar_MessageBox_Se_Ha_Registrado_Con_Exito()
                {
                        MessageBox.Show
                        (
                                caption: "Exito",
                                text: "El registro se ha completado con exito",
                                icon: MessageBoxIcon.Exclamation,
                                buttons: MessageBoxButtons.OK,
                                owner: this
                        );
                }

                // Registrarse
                private void Button_Registrarse_Click(object sender, EventArgs e)
                {
                        if (!Se_Puede_Registrar_Sujeto()) { return; }
                        Procesamiento_Sujetos.Registrar_Sujeto(Get_Atributos_Persona(), Get_Atributos_Usuario(), Get_Atributos_Proveedor());
                        Reproducir_Tono_Registrado();
                        Thread.Sleep(2000);
                        Mostrar_MessageBox_Se_Ha_Registrado_Con_Exito();
                        Close();
                }

                // Validacion
                bool Se_Puede_Registrar_Sujeto()
                {
                        bool Se_Puede_Crear_La_Persona()
                        {
                                if (Nombre == "" || Apellido == "" || Telefono == "" || Email == "") { Mostrar_MessageBox_Faltan_Campos_Persona(); return false; }
                                return true;
                        }
                        bool Se_Puede_Crear_El_Usuario()
                        {
                                if (string.IsNullOrWhiteSpace(Nombre_Identificador)) { Mostrar_MessageBox_Falta_Un_Nombre_Identificador(); return false; }
                                if (string.IsNullOrWhiteSpace(Contrasena))
                                {
                                        Mostrar_MessageBox_Se_Necesita_Una_Contrasena();
                                        return false;
                                }
                                if (Contrasena != Confirmacion_Contrasena) { Mostrar_MessageBox_Contrasenas_No_Coinciden(); return false; }
                                if (Procesamiento_Sujetos.Nombre_Identificador_Ya_Existente(Nombre_Identificador)) { Mostrar_MessageBox_Nombre_Identificador_Ya_Tomado(); return false; }
                                if (Contrasena.Length < 8 && Mostrar_MessageBox_Confirmar_Contrasena_Corta() != DialogResult.OK) { return false; }
                                return true;
                        }
                        bool Se_Puede_Crear_El_Proveedor()
                        {
                                if (!Representa_Empresa) { return true; }
                                if (!(Nombre_Empresa is not null && Email_Empresa is not null && Barrio is not null && Calle1 is not null && Calle2 is not null))
                                { Mostrar_MessageBox_Informacion_Parcial_Empresa(); return false; }
                                return true;
                        }

                        if (!Se_Puede_Crear_La_Persona()) { return false; }
                        if (Registrar_Usuario && !Se_Puede_Crear_El_Usuario()) { return false; }
                        if (Registrar_Proveedor && !Se_Puede_Crear_El_Proveedor()) { return false; }
                        return true;
                }

                string Respaldo_Nombre = "";
                string Respaldo_Telefono = "";
                string Respaldo_Apellido = "";
                string Respaldo_Email = "";
                string Respaldo_Email_Empresa = "";
                // Datos Persona
                private void TextBox_Nombre_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Nombre,
                                ref Respaldo_Nombre,
                                Numeros_Estan_Permitidos: false,
                                Letras_Estan_Permitidas: true,
                                Espacios_Estan_Permitidos: false
                        );
                }
                private void TextBox_Apellido_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Apellido,
                                ref Respaldo_Apellido,
                                Numeros_Estan_Permitidos: false,
                                Letras_Estan_Permitidas: true,
                                Espacios_Estan_Permitidos: false
                        );
                }
                private void TextBox_Telefono_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Telefono,
                                ref Respaldo_Telefono,
                                Numeros_Estan_Permitidos: true,
                                Letras_Estan_Permitidas: false,
                                Espacios_Estan_Permitidos: false
                        );
                }
                private void TextBox_Email_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Email,
                                ref Respaldo_Email,
                                Numeros_Estan_Permitidos: true,
                                Letras_Estan_Permitidas: true,
                                Espacios_Estan_Permitidos: false
                        );
                }
                // Datos Proveedor
                private void TextBox_Email_Empresa_TextChanged(object sender, EventArgs e)
                {
                        Librerias_Locales.TextBoxSeguro.Comportamiento_TextBoxSeguro
                        (
                                ref TextBox_Email_Empresa,
                                ref Respaldo_Email_Empresa,
                                Numeros_Estan_Permitidos: true,
                                Letras_Estan_Permitidas: true,
                                Espacios_Estan_Permitidos: false
                        );
                }
        }
}
