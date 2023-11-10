namespace Presentacion.Registro
{
        partial class Registro
        {
                /// <summary>
                /// Required designer variable.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// Clean up any resources being used.
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
                /// Required method for Designer support - do not modify
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                        GroupBox_Persona = new GroupBox();
                        TextBox_Email = new TextBox();
                        Label_Email = new Label();
                        TextBox_Telefono = new TextBox();
                        Label_Telefono = new Label();
                        TextBox_Apellido = new TextBox();
                        Label_Apellido = new Label();
                        TextBox_Nombre = new TextBox();
                        Label_Nombre = new Label();
                        GroupBox_Usuario = new GroupBox();
                        TextBox_Confirmacion_Contrasena = new TextBox();
                        label2 = new Label();
                        TextBox_Contrasena = new TextBox();
                        Label_Contrasena = new Label();
                        CheckBox_Usuario = new CheckBox();
                        TextBox_Nombre_Identificador = new TextBox();
                        Label_Nombre_Identificador = new Label();
                        GroupBox_Proveedor = new GroupBox();
                        Panel_Proveedor = new Panel();
                        TextBox_Email_Empresa = new TextBox();
                        Label_Email_Empresa = new Label();
                        TextBox_Nombre_Empresa = new TextBox();
                        Label_Nombre_Empresa = new Label();
                        Label_Direccion_Empresa = new Label();
                        TextBox_Indicaciones = new TextBox();
                        Label_Indicaciones = new Label();
                        TextBox_Calle2 = new TextBox();
                        label1 = new Label();
                        TextBox_Calle1 = new TextBox();
                        Label_Calle1 = new Label();
                        TextBox_Barrio = new TextBox();
                        Label_Barrio = new Label();
                        CheckBox_Tiene_Empresa = new CheckBox();
                        CheckBox_Proveedor = new CheckBox();
                        Button_Registrarse = new Button();
                        GroupBox_Persona.SuspendLayout();
                        GroupBox_Usuario.SuspendLayout();
                        GroupBox_Proveedor.SuspendLayout();
                        Panel_Proveedor.SuspendLayout();
                        SuspendLayout();
                        // 
                        // GroupBox_Persona
                        // 
                        GroupBox_Persona.Controls.Add(TextBox_Email);
                        GroupBox_Persona.Controls.Add(Label_Email);
                        GroupBox_Persona.Controls.Add(TextBox_Telefono);
                        GroupBox_Persona.Controls.Add(Label_Telefono);
                        GroupBox_Persona.Controls.Add(TextBox_Apellido);
                        GroupBox_Persona.Controls.Add(Label_Apellido);
                        GroupBox_Persona.Controls.Add(TextBox_Nombre);
                        GroupBox_Persona.Controls.Add(Label_Nombre);
                        GroupBox_Persona.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Persona.Location = new Point(12, 12);
                        GroupBox_Persona.Name = "GroupBox_Persona";
                        GroupBox_Persona.Size = new Size(276, 361);
                        GroupBox_Persona.TabIndex = 0;
                        GroupBox_Persona.TabStop = false;
                        GroupBox_Persona.Text = "Datos personales";
                        // 
                        // TextBox_Email
                        // 
                        TextBox_Email.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Email.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Email.Location = new Point(38, 316);
                        TextBox_Email.MaxLength = 20;
                        TextBox_Email.Name = "TextBox_Email";
                        TextBox_Email.Size = new Size(193, 27);
                        TextBox_Email.TabIndex = 14;
                        TextBox_Email.TextChanged += TextBox_Email_TextChanged;
                        // 
                        // Label_Email
                        // 
                        Label_Email.AutoSize = true;
                        Label_Email.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Email.Location = new Point(38, 293);
                        Label_Email.Name = "Label_Email";
                        Label_Email.Size = new Size(46, 20);
                        Label_Email.TabIndex = 13;
                        Label_Email.Text = "Email";
                        // 
                        // TextBox_Telefono
                        // 
                        TextBox_Telefono.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Telefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Telefono.Location = new Point(38, 235);
                        TextBox_Telefono.MaxLength = 20;
                        TextBox_Telefono.Name = "TextBox_Telefono";
                        TextBox_Telefono.Size = new Size(193, 27);
                        TextBox_Telefono.TabIndex = 12;
                        TextBox_Telefono.TextChanged += TextBox_Telefono_TextChanged;
                        // 
                        // Label_Telefono
                        // 
                        Label_Telefono.AutoSize = true;
                        Label_Telefono.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Telefono.Location = new Point(38, 212);
                        Label_Telefono.Name = "Label_Telefono";
                        Label_Telefono.Size = new Size(150, 20);
                        Label_Telefono.TabIndex = 11;
                        Label_Telefono.Text = "Número de Teléfono";
                        // 
                        // TextBox_Apellido
                        // 
                        TextBox_Apellido.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Apellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Apellido.Location = new Point(38, 155);
                        TextBox_Apellido.MaxLength = 20;
                        TextBox_Apellido.Name = "TextBox_Apellido";
                        TextBox_Apellido.Size = new Size(193, 27);
                        TextBox_Apellido.TabIndex = 10;
                        TextBox_Apellido.TextChanged += TextBox_Apellido_TextChanged;
                        // 
                        // Label_Apellido
                        // 
                        Label_Apellido.AutoSize = true;
                        Label_Apellido.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Apellido.Location = new Point(38, 132);
                        Label_Apellido.Name = "Label_Apellido";
                        Label_Apellido.Size = new Size(66, 20);
                        Label_Apellido.TabIndex = 9;
                        Label_Apellido.Text = "Apellido";
                        // 
                        // TextBox_Nombre
                        // 
                        TextBox_Nombre.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Nombre.Location = new Point(38, 74);
                        TextBox_Nombre.MaxLength = 20;
                        TextBox_Nombre.Name = "TextBox_Nombre";
                        TextBox_Nombre.Size = new Size(193, 27);
                        TextBox_Nombre.TabIndex = 8;
                        TextBox_Nombre.TextChanged += TextBox_Nombre_TextChanged;
                        // 
                        // Label_Nombre
                        // 
                        Label_Nombre.AutoSize = true;
                        Label_Nombre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nombre.Location = new Point(38, 51);
                        Label_Nombre.Name = "Label_Nombre";
                        Label_Nombre.Size = new Size(66, 20);
                        Label_Nombre.TabIndex = 7;
                        Label_Nombre.Text = "Nombre";
                        // 
                        // GroupBox_Usuario
                        // 
                        GroupBox_Usuario.Controls.Add(TextBox_Confirmacion_Contrasena);
                        GroupBox_Usuario.Controls.Add(label2);
                        GroupBox_Usuario.Controls.Add(TextBox_Contrasena);
                        GroupBox_Usuario.Controls.Add(Label_Contrasena);
                        GroupBox_Usuario.Controls.Add(CheckBox_Usuario);
                        GroupBox_Usuario.Controls.Add(TextBox_Nombre_Identificador);
                        GroupBox_Usuario.Controls.Add(Label_Nombre_Identificador);
                        GroupBox_Usuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Usuario.Location = new Point(331, 12);
                        GroupBox_Usuario.Name = "GroupBox_Usuario";
                        GroupBox_Usuario.Size = new Size(290, 361);
                        GroupBox_Usuario.TabIndex = 1;
                        GroupBox_Usuario.TabStop = false;
                        GroupBox_Usuario.Text = "Registrarse con un Usuario";
                        // 
                        // TextBox_Confirmacion_Contrasena
                        // 
                        TextBox_Confirmacion_Contrasena.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Confirmacion_Contrasena.Enabled = false;
                        TextBox_Confirmacion_Contrasena.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Confirmacion_Contrasena.Location = new Point(40, 235);
                        TextBox_Confirmacion_Contrasena.MaxLength = 100;
                        TextBox_Confirmacion_Contrasena.Name = "TextBox_Confirmacion_Contrasena";
                        TextBox_Confirmacion_Contrasena.PasswordChar = '*';
                        TextBox_Confirmacion_Contrasena.Size = new Size(193, 27);
                        TextBox_Confirmacion_Contrasena.TabIndex = 11;
                        // 
                        // label2
                        // 
                        label2.AutoSize = true;
                        label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        label2.Location = new Point(40, 212);
                        label2.Name = "label2";
                        label2.Size = new Size(180, 20);
                        label2.TabIndex = 10;
                        label2.Text = "Confirmación contraseña";
                        // 
                        // TextBox_Contrasena
                        // 
                        TextBox_Contrasena.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Contrasena.Enabled = false;
                        TextBox_Contrasena.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Contrasena.Location = new Point(40, 155);
                        TextBox_Contrasena.MaxLength = 100;
                        TextBox_Contrasena.Name = "TextBox_Contrasena";
                        TextBox_Contrasena.PasswordChar = '*';
                        TextBox_Contrasena.Size = new Size(193, 27);
                        TextBox_Contrasena.TabIndex = 9;
                        // 
                        // Label_Contrasena
                        // 
                        Label_Contrasena.AutoSize = true;
                        Label_Contrasena.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Contrasena.Location = new Point(40, 132);
                        Label_Contrasena.Name = "Label_Contrasena";
                        Label_Contrasena.Size = new Size(86, 20);
                        Label_Contrasena.TabIndex = 8;
                        Label_Contrasena.Text = "Contraseña";
                        // 
                        // CheckBox_Usuario
                        // 
                        CheckBox_Usuario.AutoSize = true;
                        CheckBox_Usuario.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
                        CheckBox_Usuario.Location = new Point(262, 10);
                        CheckBox_Usuario.Name = "CheckBox_Usuario";
                        CheckBox_Usuario.Size = new Size(18, 17);
                        CheckBox_Usuario.TabIndex = 0;
                        CheckBox_Usuario.UseVisualStyleBackColor = true;
                        CheckBox_Usuario.CheckedChanged += CheckBox_Usuario_CheckedChanged;
                        // 
                        // TextBox_Nombre_Identificador
                        // 
                        TextBox_Nombre_Identificador.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre_Identificador.Enabled = false;
                        TextBox_Nombre_Identificador.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Nombre_Identificador.Location = new Point(40, 74);
                        TextBox_Nombre_Identificador.MaxLength = 30;
                        TextBox_Nombre_Identificador.Name = "TextBox_Nombre_Identificador";
                        TextBox_Nombre_Identificador.Size = new Size(193, 27);
                        TextBox_Nombre_Identificador.TabIndex = 7;
                        // 
                        // Label_Nombre_Identificador
                        // 
                        Label_Nombre_Identificador.AutoSize = true;
                        Label_Nombre_Identificador.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nombre_Identificador.Location = new Point(40, 51);
                        Label_Nombre_Identificador.Name = "Label_Nombre_Identificador";
                        Label_Nombre_Identificador.Size = new Size(157, 20);
                        Label_Nombre_Identificador.TabIndex = 6;
                        Label_Nombre_Identificador.Text = "Nombre Identificador";
                        // 
                        // GroupBox_Proveedor
                        // 
                        GroupBox_Proveedor.Controls.Add(Panel_Proveedor);
                        GroupBox_Proveedor.Controls.Add(CheckBox_Proveedor);
                        GroupBox_Proveedor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Proveedor.Location = new Point(651, 12);
                        GroupBox_Proveedor.Name = "GroupBox_Proveedor";
                        GroupBox_Proveedor.Size = new Size(300, 361);
                        GroupBox_Proveedor.TabIndex = 2;
                        GroupBox_Proveedor.TabStop = false;
                        GroupBox_Proveedor.Text = "Registrarse como Proveedor";
                        // 
                        // Panel_Proveedor
                        // 
                        Panel_Proveedor.AutoScroll = true;
                        Panel_Proveedor.Controls.Add(TextBox_Email_Empresa);
                        Panel_Proveedor.Controls.Add(Label_Email_Empresa);
                        Panel_Proveedor.Controls.Add(TextBox_Nombre_Empresa);
                        Panel_Proveedor.Controls.Add(Label_Nombre_Empresa);
                        Panel_Proveedor.Controls.Add(Label_Direccion_Empresa);
                        Panel_Proveedor.Controls.Add(TextBox_Indicaciones);
                        Panel_Proveedor.Controls.Add(Label_Indicaciones);
                        Panel_Proveedor.Controls.Add(TextBox_Calle2);
                        Panel_Proveedor.Controls.Add(label1);
                        Panel_Proveedor.Controls.Add(TextBox_Calle1);
                        Panel_Proveedor.Controls.Add(Label_Calle1);
                        Panel_Proveedor.Controls.Add(TextBox_Barrio);
                        Panel_Proveedor.Controls.Add(Label_Barrio);
                        Panel_Proveedor.Controls.Add(CheckBox_Tiene_Empresa);
                        Panel_Proveedor.Location = new Point(6, 33);
                        Panel_Proveedor.Name = "Panel_Proveedor";
                        Panel_Proveedor.Size = new Size(264, 299);
                        Panel_Proveedor.TabIndex = 2;
                        // 
                        // TextBox_Email_Empresa
                        // 
                        TextBox_Email_Empresa.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Email_Empresa.Enabled = false;
                        TextBox_Email_Empresa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Email_Empresa.Location = new Point(22, 218);
                        TextBox_Email_Empresa.MaxLength = 20;
                        TextBox_Email_Empresa.Name = "TextBox_Email_Empresa";
                        TextBox_Email_Empresa.Size = new Size(193, 27);
                        TextBox_Email_Empresa.TabIndex = 33;
                        TextBox_Email_Empresa.TextChanged += TextBox_Email_Empresa_TextChanged;
                        // 
                        // Label_Email_Empresa
                        // 
                        Label_Email_Empresa.AutoSize = true;
                        Label_Email_Empresa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Email_Empresa.Location = new Point(22, 195);
                        Label_Email_Empresa.Name = "Label_Email_Empresa";
                        Label_Email_Empresa.Size = new Size(145, 20);
                        Label_Email_Empresa.TabIndex = 32;
                        Label_Email_Empresa.Text = "Email de la Empresa";
                        // 
                        // TextBox_Nombre_Empresa
                        // 
                        TextBox_Nombre_Empresa.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre_Empresa.Enabled = false;
                        TextBox_Nombre_Empresa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Nombre_Empresa.Location = new Point(22, 136);
                        TextBox_Nombre_Empresa.MaxLength = 20;
                        TextBox_Nombre_Empresa.Name = "TextBox_Nombre_Empresa";
                        TextBox_Nombre_Empresa.Size = new Size(193, 27);
                        TextBox_Nombre_Empresa.TabIndex = 31;
                        // 
                        // Label_Nombre_Empresa
                        // 
                        Label_Nombre_Empresa.AutoSize = true;
                        Label_Nombre_Empresa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nombre_Empresa.Location = new Point(25, 113);
                        Label_Nombre_Empresa.Name = "Label_Nombre_Empresa";
                        Label_Nombre_Empresa.Size = new Size(165, 20);
                        Label_Nombre_Empresa.TabIndex = 30;
                        Label_Nombre_Empresa.Text = "Nombre de la Empresa";
                        // 
                        // Label_Direccion_Empresa
                        // 
                        Label_Direccion_Empresa.AutoSize = true;
                        Label_Direccion_Empresa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Direccion_Empresa.Location = new Point(22, 77);
                        Label_Direccion_Empresa.Name = "Label_Direccion_Empresa";
                        Label_Direccion_Empresa.Size = new Size(178, 23);
                        Label_Direccion_Empresa.TabIndex = 29;
                        Label_Direccion_Empresa.Text = "Datos de la Empresa:";
                        // 
                        // TextBox_Indicaciones
                        // 
                        TextBox_Indicaciones.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Indicaciones.Enabled = false;
                        TextBox_Indicaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Indicaciones.Location = new Point(22, 588);
                        TextBox_Indicaciones.MaxLength = 300;
                        TextBox_Indicaciones.Multiline = true;
                        TextBox_Indicaciones.Name = "TextBox_Indicaciones";
                        TextBox_Indicaciones.Size = new Size(252, 48);
                        TextBox_Indicaciones.TabIndex = 28;
                        // 
                        // Label_Indicaciones
                        // 
                        Label_Indicaciones.AutoSize = true;
                        Label_Indicaciones.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Indicaciones.Location = new Point(22, 565);
                        Label_Indicaciones.Name = "Label_Indicaciones";
                        Label_Indicaciones.Size = new Size(173, 20);
                        Label_Indicaciones.TabIndex = 27;
                        Label_Indicaciones.Text = "Indicaciones adicionales";
                        // 
                        // TextBox_Calle2
                        // 
                        TextBox_Calle2.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Calle2.Enabled = false;
                        TextBox_Calle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Calle2.Location = new Point(22, 495);
                        TextBox_Calle2.MaxLength = 20;
                        TextBox_Calle2.Name = "TextBox_Calle2";
                        TextBox_Calle2.Size = new Size(193, 27);
                        TextBox_Calle2.TabIndex = 26;
                        // 
                        // label1
                        // 
                        label1.AutoSize = true;
                        label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        label1.Location = new Point(22, 472);
                        label1.Name = "label1";
                        label1.Size = new Size(91, 20);
                        label1.TabIndex = 25;
                        label1.Text = "La otra calle";
                        // 
                        // TextBox_Calle1
                        // 
                        TextBox_Calle1.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Calle1.Enabled = false;
                        TextBox_Calle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Calle1.Location = new Point(22, 399);
                        TextBox_Calle1.MaxLength = 20;
                        TextBox_Calle1.Name = "TextBox_Calle1";
                        TextBox_Calle1.Size = new Size(193, 27);
                        TextBox_Calle1.TabIndex = 24;
                        // 
                        // Label_Calle1
                        // 
                        Label_Calle1.AutoSize = true;
                        Label_Calle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Calle1.Location = new Point(22, 376);
                        Label_Calle1.Name = "Label_Calle1";
                        Label_Calle1.Size = new Size(42, 20);
                        Label_Calle1.TabIndex = 23;
                        Label_Calle1.Text = "Calle";
                        // 
                        // TextBox_Barrio
                        // 
                        TextBox_Barrio.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Barrio.Enabled = false;
                        TextBox_Barrio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Barrio.Location = new Point(22, 303);
                        TextBox_Barrio.MaxLength = 20;
                        TextBox_Barrio.Name = "TextBox_Barrio";
                        TextBox_Barrio.Size = new Size(193, 27);
                        TextBox_Barrio.TabIndex = 22;
                        // 
                        // Label_Barrio
                        // 
                        Label_Barrio.AutoSize = true;
                        Label_Barrio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Barrio.Location = new Point(22, 280);
                        Label_Barrio.Name = "Label_Barrio";
                        Label_Barrio.Size = new Size(51, 20);
                        Label_Barrio.TabIndex = 21;
                        Label_Barrio.Text = "Barrio";
                        // 
                        // CheckBox_Tiene_Empresa
                        // 
                        CheckBox_Tiene_Empresa.AutoSize = true;
                        CheckBox_Tiene_Empresa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        CheckBox_Tiene_Empresa.Location = new Point(22, 17);
                        CheckBox_Tiene_Empresa.Name = "CheckBox_Tiene_Empresa";
                        CheckBox_Tiene_Empresa.Size = new Size(181, 24);
                        CheckBox_Tiene_Empresa.TabIndex = 20;
                        CheckBox_Tiene_Empresa.Text = "Representa a empresa";
                        CheckBox_Tiene_Empresa.UseVisualStyleBackColor = true;
                        CheckBox_Tiene_Empresa.CheckedChanged += CheckBox_Tiene_Empresa_CheckedChanged;
                        // 
                        // CheckBox_Proveedor
                        // 
                        CheckBox_Proveedor.AutoSize = true;
                        CheckBox_Proveedor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
                        CheckBox_Proveedor.Location = new Point(276, 10);
                        CheckBox_Proveedor.Name = "CheckBox_Proveedor";
                        CheckBox_Proveedor.Size = new Size(18, 17);
                        CheckBox_Proveedor.TabIndex = 1;
                        CheckBox_Proveedor.UseVisualStyleBackColor = true;
                        CheckBox_Proveedor.CheckedChanged += CheckBox_Proveedor_CheckedChanged;
                        // 
                        // Button_Registrarse
                        // 
                        Button_Registrarse.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Registrarse.Location = new Point(331, 416);
                        Button_Registrarse.Name = "Button_Registrarse";
                        Button_Registrarse.Size = new Size(280, 77);
                        Button_Registrarse.TabIndex = 3;
                        Button_Registrarse.Text = "Concreatar registro";
                        Button_Registrarse.UseVisualStyleBackColor = true;
                        Button_Registrarse.Click += Button_Registrarse_Click;
                        // 
                        // Registro
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(996, 530);
                        Controls.Add(Button_Registrarse);
                        Controls.Add(GroupBox_Proveedor);
                        Controls.Add(GroupBox_Usuario);
                        Controls.Add(GroupBox_Persona);
                        Name = "Registro";
                        Text = "Quién Da Más?: Registro";
                        GroupBox_Persona.ResumeLayout(false);
                        GroupBox_Persona.PerformLayout();
                        GroupBox_Usuario.ResumeLayout(false);
                        GroupBox_Usuario.PerformLayout();
                        GroupBox_Proveedor.ResumeLayout(false);
                        GroupBox_Proveedor.PerformLayout();
                        Panel_Proveedor.ResumeLayout(false);
                        Panel_Proveedor.PerformLayout();
                        ResumeLayout(false);
                }

                #endregion

                private GroupBox GroupBox_Persona;
                private GroupBox GroupBox_Usuario;
                private CheckBox CheckBox_Usuario;
                private GroupBox GroupBox_Proveedor;
                private CheckBox CheckBox_Proveedor;
                private TextBox TextBox_Telefono;
                private Label Label_Telefono;
                private TextBox TextBox_Apellido;
                private Label Label_Apellido;
                private TextBox TextBox_Nombre;
                private Label Label_Nombre;
                private Panel Panel_Proveedor;
                private TextBox TextBox_Email_Empresa;
                private Label Label_Email_Empresa;
                private TextBox TextBox_Nombre_Empresa;
                private Label Label_Nombre_Empresa;
                private Label Label_Direccion_Empresa;
                private TextBox TextBox_Indicaciones;
                private Label Label_Indicaciones;
                private TextBox TextBox_Calle2;
                private Label label1;
                private TextBox TextBox_Calle1;
                private Label Label_Calle1;
                private TextBox TextBox_Barrio;
                private Label Label_Barrio;
                private CheckBox CheckBox_Tiene_Empresa;
                private TextBox TextBox_Confirmacion_Contrasena;
                private Label label2;
                private TextBox TextBox_Contrasena;
                private Label Label_Contrasena;
                private TextBox TextBox_Nombre_Identificador;
                private Label Label_Nombre_Identificador;
                private Button Button_Registrarse;
                private TextBox TextBox_Email;
                private Label Label_Email;
        }
}