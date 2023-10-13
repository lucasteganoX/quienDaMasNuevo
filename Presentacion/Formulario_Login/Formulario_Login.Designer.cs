using System.IO;
using System.Drawing;
using System;
using static System.Windows.Forms.AxHost;
using System.Runtime.CompilerServices;

using Presentacion.Librerias_Locales;
using System.Diagnostics ;

/*      En esta parte de Formulario_Sujeto se encapsua todo lo que tiene que ver con el funcionamiento del formulario como tal.
 *      Dividiendose en:
 *      * Parte Gráfica del formulario
 *      * Parte Lógica del formulario
 * 
 *      Donde la parte gráfica se encarga de declarar los componentes y controles del formulario, asignarles valores, asignarles
 *      handlers a los eventos de los controles, etc.
 *      Mientras que la parte logica se encarga de declarar los handlers para los eventos, contener el constructor del formulari
 *      o, etc.
 *      
 *      No se si se puede llamar al archivo de forma diferente, y que le window builder siga funcionando medio bien. Pero es ver
 *      dad que la palabra "Designer" evoca el aspecto de diseño del formulario. Y eso me parece bastante acertado. Ya que a par
 *      tir de una serie de reflexiones, el nombre "Formulario_Login.Designer.cs" para mí representa que es la parte de diseño d
 *      el formulario, la parte que define todo lo necesario para ver lso dibujitos en pantalla y que cuando piques un botón el 
 *      coso haga algo.
 */

namespace Presentacion.Formulario_Login
{
        public partial class Formulario_Login
        {
                #region >>---- Parte Grafica Formulario ---------------------------

                /* TextBoxs:
                 * El fondo de los TextBox es color "GainsBoro" pq se parece al color de las TextBox del inicio de seccion de Facebook.
                 * La letra de los TextBox es de color ""

                */

                /// <summary>
                ///  Required designer variable.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                ///  Clean up any resources being used.
                /// </summary>
                /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null))
                        {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Windows Form Designer generated code
                /// <summary>
                ///  Required method for Designer support - do not modify
                ///  the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario_Login));
                        Label_Titulo = new Label();
                        Label_Modo_Ingreso = new Label();
                        Label_Modo_Registro = new Label();
                        TextBox_NombreUsuario = new TextBox();
                        TextBox_Contrasena = new TextBox();
                        Button_Continuar = new Button();
                        GroupBox_InformacionUsuario = new GroupBox();
                        Button_MostrarContrasena = new Button();
                        GroupBox_IntencionUsuario = new GroupBox();
                        RJToggleButton_ModoIngreso = new RJToggleButton();
                        GroupBox_Controles = new GroupBox();
                        Button_OlvidoSuContrsena = new Button();
                        Label_Copyright = new Label();
                        GroupBox_IngresarComoInvitado = new GroupBox();
                        CheckBox_ModoInvitado = new CheckBox();
                        PictureBox_Banner = new PictureBox();
                        GroupBox_InformacionUsuario.SuspendLayout();
                        GroupBox_IntencionUsuario.SuspendLayout();
                        GroupBox_Controles.SuspendLayout();
                        GroupBox_IngresarComoInvitado.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)PictureBox_Banner).BeginInit();
                        SuspendLayout();
                        // 
                        // Label_Titulo
                        // 
                        Label_Titulo.AutoSize = true;
                        Label_Titulo.Font = new Font("Sylfaen", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
                        Label_Titulo.Location = new Point(11, 21);
                        Label_Titulo.Name = "Label_Titulo";
                        Label_Titulo.Size = new Size(186, 36);
                        Label_Titulo.TabIndex = 0;
                        Label_Titulo.Text = "Quién da más?";
                        Label_Titulo.TextAlign = ContentAlignment.MiddleCenter;
                        // 
                        // Label_Modo_Ingreso
                        // 
                        Label_Modo_Ingreso.AutoSize = true;
                        Label_Modo_Ingreso.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Modo_Ingreso.ForeColor = Color.Goldenrod;
                        Label_Modo_Ingreso.Location = new Point(173, 35);
                        Label_Modo_Ingreso.Name = "Label_Modo_Ingreso";
                        Label_Modo_Ingreso.Size = new Size(65, 20);
                        Label_Modo_Ingreso.TabIndex = 2;
                        Label_Modo_Ingreso.Text = "Ingresar";
                        // 
                        // Label_Modo_Registro
                        // 
                        Label_Modo_Registro.AutoSize = true;
                        Label_Modo_Registro.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Modo_Registro.ForeColor = Color.DarkGray;
                        Label_Modo_Registro.Location = new Point(32, 35);
                        Label_Modo_Registro.Name = "Label_Modo_Registro";
                        Label_Modo_Registro.Size = new Size(84, 20);
                        Label_Modo_Registro.TabIndex = 3;
                        Label_Modo_Registro.Text = "Registrarse";
                        // 
                        // TextBox_NombreUsuario
                        // 
                        TextBox_NombreUsuario.AccessibleDescription = "";
                        TextBox_NombreUsuario.BackColor = Color.Gainsboro;
                        TextBox_NombreUsuario.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_NombreUsuario.Cursor = Cursors.IBeam;
                        TextBox_NombreUsuario.Font = new Font("Lucida Sans", 8F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_NombreUsuario.ForeColor = Color.DimGray;
                        TextBox_NombreUsuario.Location = new Point(32, 27);
                        TextBox_NombreUsuario.Name = "TextBox_NombreUsuario";
                        TextBox_NombreUsuario.PlaceholderText = "  Nombre Usuario";
                        TextBox_NombreUsuario.Size = new Size(312, 23);
                        TextBox_NombreUsuario.TabIndex = 4;
                        // 
                        // TextBox_Contrasena
                        // 
                        TextBox_Contrasena.AccessibleDescription = "";
                        TextBox_Contrasena.BackColor = Color.Gainsboro;
                        TextBox_Contrasena.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Contrasena.Cursor = Cursors.IBeam;
                        TextBox_Contrasena.Font = new Font("Lucida Sans", 8F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Contrasena.ForeColor = Color.DimGray;
                        TextBox_Contrasena.Location = new Point(32, 55);
                        TextBox_Contrasena.Name = "TextBox_Contrasena";
                        TextBox_Contrasena.PasswordChar = '•';
                        TextBox_Contrasena.PlaceholderText = "  Contraseña";
                        TextBox_Contrasena.Size = new Size(312, 23);
                        TextBox_Contrasena.TabIndex = 5;
                        // 
                        // Button_Continuar
                        // 
                        Button_Continuar.BackColor = Color.Gold;
                        Button_Continuar.Cursor = Cursors.Hand;
                        Button_Continuar.FlatStyle = FlatStyle.Popup;
                        Button_Continuar.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Continuar.ForeColor = Color.DarkGoldenrod;
                        Button_Continuar.Location = new Point(39, 27);
                        Button_Continuar.Name = "Button_Continuar";
                        Button_Continuar.Size = new Size(312, 29);
                        Button_Continuar.TabIndex = 6;
                        Button_Continuar.Text = "Continuar";
                        Button_Continuar.UseVisualStyleBackColor = false;
                        Button_Continuar.Click += Button_Continuar_Click;
                        // 
                        // GroupBox_InformacionUsuario
                        // 
                        GroupBox_InformacionUsuario.Controls.Add(TextBox_NombreUsuario);
                        GroupBox_InformacionUsuario.Controls.Add(Button_MostrarContrasena);
                        GroupBox_InformacionUsuario.Controls.Add(TextBox_Contrasena);
                        GroupBox_InformacionUsuario.Location = new Point(11, 72);
                        GroupBox_InformacionUsuario.Name = "GroupBox_InformacionUsuario";
                        GroupBox_InformacionUsuario.Size = new Size(386, 125);
                        GroupBox_InformacionUsuario.TabIndex = 7;
                        GroupBox_InformacionUsuario.TabStop = false;
                        // 
                        // Button_MostrarContrasena
                        // 
                        Button_MostrarContrasena.BackColor = Color.Transparent;
                        Button_MostrarContrasena.Cursor = Cursors.Hand;
                        Button_MostrarContrasena.FlatAppearance.BorderColor = Color.DimGray;
                        Button_MostrarContrasena.Image = (Image)resources.GetObject("Button_MostrarContrasena.Image");
                        Button_MostrarContrasena.Location = new Point(306, 59);
                        Button_MostrarContrasena.Name = "Button_MostrarContrasena";
                        Button_MostrarContrasena.Size = new Size(21, 19);
                        Button_MostrarContrasena.TabIndex = 11;
                        Button_MostrarContrasena.UseVisualStyleBackColor = false;
                        Button_MostrarContrasena.MouseDown += Button_MostrarContrasena_MouseDown;
                        Button_MostrarContrasena.MouseUp += Button_MostrarContrasena_MouseUp;
                        // 
                        // GroupBox_IntencionUsuario
                        // 
                        GroupBox_IntencionUsuario.Controls.Add(RJToggleButton_ModoIngreso);
                        GroupBox_IntencionUsuario.Controls.Add(Label_Modo_Registro);
                        GroupBox_IntencionUsuario.Controls.Add(Label_Modo_Ingreso);
                        GroupBox_IntencionUsuario.Location = new Point(11, 203);
                        GroupBox_IntencionUsuario.Name = "GroupBox_IntencionUsuario";
                        GroupBox_IntencionUsuario.Size = new Size(261, 100);
                        GroupBox_IntencionUsuario.TabIndex = 8;
                        GroupBox_IntencionUsuario.TabStop = false;
                        // 
                        // RJToggleButton_ModoIngreso
                        // 
                        RJToggleButton_ModoIngreso.AutoSize = true;
                        RJToggleButton_ModoIngreso.BackColor = SystemColors.ControlDarkDark;
                        RJToggleButton_ModoIngreso.Checked = true;
                        RJToggleButton_ModoIngreso.CheckState = CheckState.Checked;
                        RJToggleButton_ModoIngreso.Location = new Point(122, 35);
                        RJToggleButton_ModoIngreso.MinimumSize = new Size(45, 22);
                        RJToggleButton_ModoIngreso.Name = "RJToggleButton_ModoIngreso";
                        RJToggleButton_ModoIngreso.OffBackColor = Color.OliveDrab;
                        RJToggleButton_ModoIngreso.OffToggleColor = Color.YellowGreen;
                        RJToggleButton_ModoIngreso.OnBackColor = Color.Gold;
                        RJToggleButton_ModoIngreso.OnToggleColor = Color.Goldenrod;
                        RJToggleButton_ModoIngreso.Size = new Size(45, 22);
                        RJToggleButton_ModoIngreso.TabIndex = 12;
                        RJToggleButton_ModoIngreso.UseVisualStyleBackColor = false;
                        RJToggleButton_ModoIngreso.CheckedChanged += RJToggleButton_ModoIngreso_CheckedChanged;
                        // 
                        // GroupBox_Controles
                        // 
                        GroupBox_Controles.Controls.Add(Button_OlvidoSuContrsena);
                        GroupBox_Controles.Controls.Add(Button_Continuar);
                        GroupBox_Controles.Location = new Point(279, 203);
                        GroupBox_Controles.Name = "GroupBox_Controles";
                        GroupBox_Controles.Size = new Size(392, 100);
                        GroupBox_Controles.TabIndex = 9;
                        GroupBox_Controles.TabStop = false;
                        // 
                        // Button_OlvidoSuContrsena
                        // 
                        Button_OlvidoSuContrsena.BackColor = Color.Transparent;
                        Button_OlvidoSuContrsena.Cursor = Cursors.Hand;
                        Button_OlvidoSuContrsena.FlatStyle = FlatStyle.Popup;
                        Button_OlvidoSuContrsena.Font = new Font("Arial", 7.20000029F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_OlvidoSuContrsena.ForeColor = Color.OliveDrab;
                        Button_OlvidoSuContrsena.Location = new Point(39, 61);
                        Button_OlvidoSuContrsena.Name = "Button_OlvidoSuContrsena";
                        Button_OlvidoSuContrsena.Size = new Size(312, 29);
                        Button_OlvidoSuContrsena.TabIndex = 7;
                        Button_OlvidoSuContrsena.Text = "Olvidó su contraseña?";
                        Button_OlvidoSuContrsena.UseVisualStyleBackColor = false;
                        // 
                        // Label_Copyright
                        // 
                        Label_Copyright.AutoSize = true;
                        Label_Copyright.Font = new Font("Magneto", 7F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Copyright.ForeColor = Color.Black;
                        Label_Copyright.Location = new Point(11, 424);
                        Label_Copyright.Name = "Label_Copyright";
                        Label_Copyright.Size = new Size(255, 16);
                        Label_Copyright.TabIndex = 4;
                        Label_Copyright.Text = "El Bueno, El Malo y Stephano © 2023";
                        // 
                        // GroupBox_IngresarComoInvitado
                        // 
                        GroupBox_IngresarComoInvitado.Controls.Add(CheckBox_ModoInvitado);
                        GroupBox_IngresarComoInvitado.Location = new Point(421, 72);
                        GroupBox_IngresarComoInvitado.Name = "GroupBox_IngresarComoInvitado";
                        GroupBox_IngresarComoInvitado.Size = new Size(250, 125);
                        GroupBox_IngresarComoInvitado.TabIndex = 10;
                        GroupBox_IngresarComoInvitado.TabStop = false;
                        // 
                        // CheckBox_ModoInvitado
                        // 
                        CheckBox_ModoInvitado.AutoSize = true;
                        CheckBox_ModoInvitado.Cursor = Cursors.Hand;
                        CheckBox_ModoInvitado.Location = new Point(32, 27);
                        CheckBox_ModoInvitado.Name = "CheckBox_ModoInvitado";
                        CheckBox_ModoInvitado.Size = new Size(129, 24);
                        CheckBox_ModoInvitado.TabIndex = 0;
                        CheckBox_ModoInvitado.Text = "Modo Invitado";
                        CheckBox_ModoInvitado.UseVisualStyleBackColor = true;
                        CheckBox_ModoInvitado.CheckedChanged += CheckBox_ModoInvitado_CheckedChanged;
                        // 
                        // PictureBox_Banner
                        // 
                        PictureBox_Banner.Cursor = Cursors.Hand;
                        PictureBox_Banner.Image = (Image)resources.GetObject("PictureBox_Banner.Image");
                        PictureBox_Banner.Location = new Point(807, 0);
                        PictureBox_Banner.Margin = new Padding(3, 4, 3, 4);
                        PictureBox_Banner.Name = "PictureBox_Banner";
                        PictureBox_Banner.Size = new Size(640, 426);
                        PictureBox_Banner.SizeMode = PictureBoxSizeMode.AutoSize;
                        PictureBox_Banner.TabIndex = 11;
                        PictureBox_Banner.TabStop = false;
                        // 
                        // Formulario_Login
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(833, 469);
                        Controls.Add(PictureBox_Banner);
                        Controls.Add(GroupBox_IngresarComoInvitado);
                        Controls.Add(Label_Copyright);
                        Controls.Add(GroupBox_Controles);
                        Controls.Add(GroupBox_IntencionUsuario);
                        Controls.Add(GroupBox_InformacionUsuario);
                        Controls.Add(Label_Titulo);
                        FormBorderStyle = FormBorderStyle.FixedSingle;
                        MaximizeBox = false;
                        Name = "Formulario_Login";
                        Text = "Quién da más?: Acceso";
                        FormClosing += Formulario_Login_FormClosing;
                        Load += Form1_Load;
                        GroupBox_InformacionUsuario.ResumeLayout(false);
                        GroupBox_InformacionUsuario.PerformLayout();
                        GroupBox_IntencionUsuario.ResumeLayout(false);
                        GroupBox_IntencionUsuario.PerformLayout();
                        GroupBox_Controles.ResumeLayout(false);
                        GroupBox_IngresarComoInvitado.ResumeLayout(false);
                        GroupBox_IngresarComoInvitado.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)PictureBox_Banner).EndInit();
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion

                private Label Label_Titulo;
                private Label Label_Modo_Ingreso;
                private Label Label_Modo_Registro;
                private TextBox TextBox_NombreUsuario;
                private TextBox TextBox_Contrasena;
                private Button Button_Continuar;
                private GroupBox GroupBox_InformacionUsuario;
                private GroupBox GroupBox_IntencionUsuario;
                private GroupBox GroupBox_Controles;
                private Button Button_OlvidoSuContrsena;
                private Label Label_Copyright;
                private GroupBox GroupBox_IngresarComoInvitado;
                private CheckBox CheckBox_ModoInvitado;
                private Button Button_MostrarContrasena;
                private PictureBox PictureBox_Banner;
                private RJToggleButton RJToggleButton_ModoIngreso;

                enum MessageBoxButton
                {
                        OK = 0,
                        OKCancel = 1,
                        YesNo = 4,
                        YesNoCancel = 3
                }

                /* 
                enum MessageBoxImage
                {
                        Nada = 0,
                        Error = 16,
                        Informacion = 48,
                        Advertencia = 48,
                        Pregunta = 32,
                }
                */

                #endregion >>---- Declaracion Componentes ------------------------

                #region >>---- Parte Logica Formulario ----------------------------

                public bool Intento_De_Continuar_En_Espera = false; // Este valor lo utilizará el Script para iniciar la secuencia de Ingreso o Registro
                                                                    // según corresponda.
                public Formulario_Login()
                {
                        InitializeComponent();
                }

                public void Cambiar_Modo_Formulario( RegistroEnModoInvitadoException Excepcion )
                {
                        RJToggleButton_ModoIngreso.Checked = true;
                }

                public void Mostrar_MessageBox_Usuario_O_Contrasena_Incorrectos( UsuarioOContrasenaIncorrectosException Excepcion )
                {
                        // MessageBox.Show( Formulario dueño, Mensaje, Titulo, Boton, Imagen )
                        MessageBox.Show
                        (
                            this,
                            "El Usuario o la Contraseña son incorrectos.",
                            "Quién Da Más?",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        ) ;
                }

                public void Mostrar_MessageBox_Quedan_Campos_Vacios( QuedanCamposVaciosException Excepcion )
                { 
                        // MessageBox.Show( Formulario dueño, Mensaje, Titulo, Boton, Imagen )
                        MessageBox.Show
                        (
                            this,
                            "Quedan campos vacíos. Llenelos antes de continuar.",
                            "Quién Da Más?",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        ) ;
                }

                public void Mostrar_MessageBox_Usuario_Inactivo( UsuarioInactivoException Excepcion )
                { 
                        // MessageBox.Show( Formulario dueño, Mensaje, Titulo, Boton, Imagen )
                        MessageBox.Show
                        (
                           this,
                           "El Usuario ingresado se encuentra inactivo, no se le permite el acceso. Comuniquese con administracion para solucionar el problema." ,
                           "Quién Da Más?",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                        ) ;
                }

                private void Form1_Load(object sender, EventArgs e)
                {
                        // En realidad todo esto deberia hacerse en la declaracion del panel.
                        // Aqui solo deberia mostrarse el panel.
                        int Ancho_Formulario_Maximizado = this.Width;
                        int Largo_Formulario_Maximizdo = this.Height;
                        int Ancho_Formulario_Normal = 749;
                        int Largo_Formulario_Normal = 341;

                        PictureBox_Banner.Left = GroupBox_Controles.Right + 300;

                }

                private void Formulario_Login_FormClosing(object Sender, EventArgs e)
                {

                }

                private void RJToggleButton_ModoIngreso_CheckedChanged(object sender, EventArgs e)
                {
                        if (RJToggleButton_ModoIngreso.Checked)
                        {
                                #region >>---- Anular efectos del boton deschcekeado --------------------------------------------------------

                                //Label_Modo_Registro = new Label() ;
                                //{
                                //    Text = "Ingresar" ;
                                //    Font = new Font( "Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point ) ;
                                //    ForeColor = Color.LightGoldenrodYellow ;
                                //} ;

                                Label_Modo_Registro.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                Label_Modo_Registro.ForeColor = Color.DarkGray;

                                #endregion --------------------------------------------------------------------------------------------------

                                // Label_Modo_Registro.Font = new System.Drawing.Font("Lucida Handwriting", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte)) ;
                                Label_Modo_Ingreso.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                Label_Modo_Ingreso.ForeColor = Color.Goldenrod;
                        }
                        else
                        {
                                #region >>---- Anular efectos del boton chcekeado -----------------------------------------------------------

                                Label_Modo_Ingreso.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                Label_Modo_Ingreso.ForeColor = Color.DarkGray;

                                #endregion --------------------------------------------------------------------------------------------------

                                if (CheckBox_ModoInvitado.Checked) { CheckBox_ModoInvitado.Checked = false; }
                                Label_Modo_Registro.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                Label_Modo_Registro.ForeColor = Color.OliveDrab;
                        }
                }

                private void CheckBox_ModoInvitado_CheckedChanged(object sender, EventArgs e)
                {
                        void El_Cambiazo(bool Modo_Invitado_Checked)
                        {
                                // Aquí voy a hacer una pequeña triquimuela....
                                // Quiero mostrar "Usuario Invitado" en el Textbox_NombreUsuario.
                                // Pero para evitarme hacer una variable que guarde el nombre original del Usuario y demás...
                                // Lo que voy a hacer es remplazar el placeholder por el nombre de Usuario, y el nombre de Usuario lo vuelvo "Usuario Invitado".
                                // Cuando desactive el Modo Invitado se intercambian de nuevo y se designa el placeholder normal.
                                // https://i.kym-cdn.com/entries/icons/facebook/000/032/987/Mind_Size_Banner.jpg

                                const string Placeholder_Original_Nombre = " Nombre Usuario";
                                const string Placeholder_Contrasena = " Contraseña";

                                if (Modo_Invitado_Checked)
                                {
                                        string Nombre_Usuario = TextBox_NombreUsuario.Text;

                                        TextBox_NombreUsuario.PlaceholderText = Nombre_Usuario;
                                        TextBox_NombreUsuario.Text = " Usuario Invitado";

                                        return;
                                }

                                TextBox_NombreUsuario.Text = TextBox_NombreUsuario.PlaceholderText;

                                TextBox_NombreUsuario.PlaceholderText = Placeholder_Original_Nombre;
                                TextBox_Contrasena.PlaceholderText = Placeholder_Contrasena;

                                return;
                        }

                        if (CheckBox_ModoInvitado.Checked)
                        {
                                GroupBox_InformacionUsuario.Enabled = false;
                                TextBox_NombreUsuario.Enabled = false;
                                TextBox_Contrasena.Enabled = false;
                                Button_MostrarContrasena.Enabled = false;

                                TextBox_NombreUsuario.PlaceholderText = "";
                                TextBox_Contrasena.PlaceholderText = "";
                                TextBox_NombreUsuario.BackColor = Color.DarkGray;
                                TextBox_Contrasena.BackColor = Color.DarkGray;
                                TextBox_NombreUsuario.ForeColor = Color.LightGray;
                                TextBox_Contrasena.ForeColor = Color.LightGray;
                                Button_MostrarContrasena.Visible = false;

                                // TextBox_NombreUsuario.Text = "ModoInvitado Activado" ;

                                El_Cambiazo(true);
                                if (!RJToggleButton_ModoIngreso.Checked) { RJToggleButton_ModoIngreso.Checked = true; }
                        }
                        else
                        {
                                GroupBox_InformacionUsuario.Enabled = true;
                                TextBox_NombreUsuario.Enabled = true;
                                TextBox_Contrasena.Enabled = true;
                                Button_MostrarContrasena.Enabled = true;


                                // TextBox_NombreUsuario.PlaceholderText = "Nombre Usuario";
                                TextBox_NombreUsuario.BackColor = Color.Gainsboro;
                                TextBox_Contrasena.BackColor = Color.Gainsboro;
                                TextBox_NombreUsuario.ForeColor = Color.DimGray;
                                TextBox_Contrasena.ForeColor = Color.DimGray;
                                Button_MostrarContrasena.Visible = true;

                                El_Cambiazo(false);
                                // TextBox_NombreUsuario.Text = "ModoInvitado desactivado" ;
                        }


                }

                private void Button_MostrarContrasena_MouseDown(object sender, MouseEventArgs e)
                {
                        // Button_MostrarContrasena.ForeColor = Color.DarkRed ;
                        TextBox_Contrasena.PasswordChar = '\0';
                        // Image image = Load(Administracion_Usuarios.Formulario.Icono_Ojo_Abierto.png) ;
                }

                private void Button_MostrarContrasena_MouseUp(object sender, MouseEventArgs e)
                {
                        TextBox_Contrasena.PasswordChar = '•';
                }

                private void PictureBox_Icono_Ojo_Abierto_MostrarContrasena_MouseDown(object sender, MouseEventArgs e)
                {
                        TextBox_Contrasena.PasswordChar = '\0';
                }

                private void PictureBox_Icono_Ojo_Abierto_MostrarContrasena_MouseUp(object sender, MouseEventArgs e)
                {
                        TextBox_Contrasena.PasswordChar = '•';
                }


                private void Button_Continuar_Click(object sender, EventArgs e)
                {
                        Intento_De_Continuar_En_Espera = true ;
                }

                #endregion >>---- Logica Formulario --------------------------------
        }
}