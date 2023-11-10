namespace Presentacion.Gestion_Sujetos
{
        partial class Gestion_Sujetos
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
                        components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestion_Sujetos));
                        Seleccion_Capas = new GroupBox();
                        Button_Proveedores = new Button();
                        Button_Empleados = new Button();
                        Button_Usuarios = new Button();
                        Button_Personas = new Button();
                        GroupBox_Grilla = new GroupBox();
                        Label_ID_Capa = new Label();
                        Label_ID_Persona = new Label();
                        DropDownList_Buscador = new Librerias_Locales.FlatComboBox();
                        TextBox_Buscador = new TextBox();
                        Grilla_Capas_Sujeto = new DataGridView();
                        GroupBox_Atributos = new GroupBox();
                        panel2 = new Panel();
                        Atributos_Capa = new TabControl();
                        Personas = new TabPage();
                        TextBox_Telefono = new TextBox();
                        Label_Telefono = new Label();
                        TextBox_Apellido = new TextBox();
                        Label_Apellido = new Label();
                        TextBox_Nombre = new TextBox();
                        Label_Nombre = new Label();
                        Usuarios = new TabPage();
                        CheckBox_Nueva_Contrasena = new CheckBox();
                        panel1 = new Panel();
                        CheckedListBox_Permisos = new CheckedListBox();
                        Label_Permisos = new Label();
                        CheckBox_Inactivo = new CheckBox();
                        TextBox_Contrasena = new TextBox();
                        Label_Nueva_Contrasena = new Label();
                        TextBox_Nombre_Identificador = new TextBox();
                        Label_Nombre_Identificador = new Label();
                        Empleados = new TabPage();
                        Button_Gestionar_Tareas = new Button();
                        NumericUpDown_Horas_Trabajadas = new NumericUpDown();
                        Label_Horas_Trabajadas = new Label();
                        Proveedores = new TabPage();
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
                        toolTip1 = new ToolTip(components);
                        GroupBox_Controles = new GroupBox();
                        Button_Eliminar = new Button();
                        Button_Modificar = new Button();
                        Button_Crear = new Button();
                        Seleccion_Capas.SuspendLayout();
                        GroupBox_Grilla.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Capas_Sujeto).BeginInit();
                        GroupBox_Atributos.SuspendLayout();
                        Atributos_Capa.SuspendLayout();
                        Personas.SuspendLayout();
                        Usuarios.SuspendLayout();
                        Empleados.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Horas_Trabajadas).BeginInit();
                        Proveedores.SuspendLayout();
                        GroupBox_Controles.SuspendLayout();
                        SuspendLayout();
                        // 
                        // Seleccion_Capas
                        // 
                        Seleccion_Capas.Controls.Add(Button_Proveedores);
                        Seleccion_Capas.Controls.Add(Button_Empleados);
                        Seleccion_Capas.Controls.Add(Button_Usuarios);
                        Seleccion_Capas.Controls.Add(Button_Personas);
                        Seleccion_Capas.Location = new Point(12, 12);
                        Seleccion_Capas.Name = "Seleccion_Capas";
                        Seleccion_Capas.Size = new Size(906, 91);
                        Seleccion_Capas.TabIndex = 0;
                        Seleccion_Capas.TabStop = false;
                        // 
                        // Button_Proveedores
                        // 
                        Button_Proveedores.BackColor = Color.SlateBlue;
                        Button_Proveedores.Cursor = Cursors.Hand;
                        Button_Proveedores.FlatAppearance.BorderColor = Color.Indigo;
                        Button_Proveedores.FlatAppearance.BorderSize = 2;
                        Button_Proveedores.FlatStyle = FlatStyle.Flat;
                        Button_Proveedores.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Proveedores.ForeColor = Color.LightYellow;
                        Button_Proveedores.Location = new Point(629, 26);
                        Button_Proveedores.Name = "Button_Proveedores";
                        Button_Proveedores.Size = new Size(140, 43);
                        Button_Proveedores.TabIndex = 4;
                        Button_Proveedores.Text = "Proveedores";
                        Button_Proveedores.UseVisualStyleBackColor = false;
                        Button_Proveedores.Click += Button_Proveedores_Click;
                        // 
                        // Button_Empleados
                        // 
                        Button_Empleados.BackColor = Color.FromArgb(255, 140, 50);
                        Button_Empleados.Cursor = Cursors.Hand;
                        Button_Empleados.FlatAppearance.BorderColor = Color.Sienna;
                        Button_Empleados.FlatAppearance.BorderSize = 2;
                        Button_Empleados.FlatStyle = FlatStyle.Flat;
                        Button_Empleados.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Empleados.ForeColor = Color.LightYellow;
                        Button_Empleados.Location = new Point(483, 26);
                        Button_Empleados.Name = "Button_Empleados";
                        Button_Empleados.Size = new Size(140, 43);
                        Button_Empleados.TabIndex = 3;
                        Button_Empleados.Text = "Empleados";
                        Button_Empleados.UseVisualStyleBackColor = false;
                        Button_Empleados.Click += Button_Empleados_Click;
                        // 
                        // Button_Usuarios
                        // 
                        Button_Usuarios.BackColor = Color.DarkCyan;
                        Button_Usuarios.Cursor = Cursors.Hand;
                        Button_Usuarios.FlatAppearance.BorderColor = Color.DarkSlateGray;
                        Button_Usuarios.FlatAppearance.BorderSize = 2;
                        Button_Usuarios.FlatStyle = FlatStyle.Flat;
                        Button_Usuarios.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Usuarios.ForeColor = Color.LightYellow;
                        Button_Usuarios.Location = new Point(337, 26);
                        Button_Usuarios.Name = "Button_Usuarios";
                        Button_Usuarios.Size = new Size(140, 43);
                        Button_Usuarios.TabIndex = 2;
                        Button_Usuarios.Text = "Usuarios";
                        Button_Usuarios.UseVisualStyleBackColor = false;
                        Button_Usuarios.Click += Button_Usuarios_Click;
                        // 
                        // Button_Personas
                        // 
                        Button_Personas.BackColor = Color.YellowGreen;
                        Button_Personas.Cursor = Cursors.Hand;
                        Button_Personas.FlatAppearance.BorderColor = Color.OliveDrab;
                        Button_Personas.FlatAppearance.BorderSize = 2;
                        Button_Personas.FlatStyle = FlatStyle.Flat;
                        Button_Personas.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Personas.ForeColor = Color.LightYellow;
                        Button_Personas.Location = new Point(130, 26);
                        Button_Personas.Name = "Button_Personas";
                        Button_Personas.Size = new Size(140, 43);
                        Button_Personas.TabIndex = 1;
                        Button_Personas.Text = "Personas";
                        Button_Personas.UseVisualStyleBackColor = false;
                        Button_Personas.Click += Button_Personas_Click;
                        // 
                        // GroupBox_Grilla
                        // 
                        GroupBox_Grilla.Controls.Add(Label_ID_Capa);
                        GroupBox_Grilla.Controls.Add(Label_ID_Persona);
                        GroupBox_Grilla.Controls.Add(DropDownList_Buscador);
                        GroupBox_Grilla.Controls.Add(TextBox_Buscador);
                        GroupBox_Grilla.Controls.Add(Grilla_Capas_Sujeto);
                        GroupBox_Grilla.Location = new Point(12, 109);
                        GroupBox_Grilla.Name = "GroupBox_Grilla";
                        GroupBox_Grilla.Size = new Size(517, 701);
                        GroupBox_Grilla.TabIndex = 1;
                        GroupBox_Grilla.TabStop = false;
                        // 
                        // Label_ID_Capa
                        // 
                        Label_ID_Capa.AutoSize = true;
                        Label_ID_Capa.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
                        Label_ID_Capa.Location = new Point(24, 659);
                        Label_ID_Capa.Name = "Label_ID_Capa";
                        Label_ID_Capa.Size = new Size(140, 17);
                        Label_ID_Capa.TabIndex = 4;
                        Label_ID_Capa.Text = "ID @Capa = @ID_Capa";
                        // 
                        // Label_ID_Persona
                        // 
                        Label_ID_Persona.AutoSize = true;
                        Label_ID_Persona.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
                        Label_ID_Persona.Location = new Point(24, 642);
                        Label_ID_Persona.Name = "Label_ID_Persona";
                        Label_ID_Persona.Size = new Size(158, 17);
                        Label_ID_Persona.TabIndex = 3;
                        Label_ID_Persona.Text = "ID Persona = @ID_Persona";
                        // 
                        // DropDownList_Buscador
                        // 
                        DropDownList_Buscador.BackColor = Color.FromArgb(192, 255, 150);
                        DropDownList_Buscador.BorderColor = Color.OliveDrab;
                        DropDownList_Buscador.ButtonColor = Color.YellowGreen;
                        DropDownList_Buscador.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Buscador.FlatStyle = FlatStyle.Flat;
                        DropDownList_Buscador.FormattingEnabled = true;
                        DropDownList_Buscador.Location = new Point(326, 26);
                        DropDownList_Buscador.Name = "DropDownList_Buscador";
                        DropDownList_Buscador.Size = new Size(166, 28);
                        DropDownList_Buscador.TabIndex = 6;
                        DropDownList_Buscador.SelectedIndexChanged += DropDownList_Buscador_SelectedIndexChanged;
                        // 
                        // TextBox_Buscador
                        // 
                        TextBox_Buscador.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Buscador.Location = new Point(24, 26);
                        TextBox_Buscador.Name = "TextBox_Buscador";
                        TextBox_Buscador.Size = new Size(283, 27);
                        TextBox_Buscador.TabIndex = 5;
                        TextBox_Buscador.TextChanged += TextBox_Buscador_TextChanged;
                        TextBox_Buscador.KeyPress += TextBox_Buscador_KeyPress;
                        // 
                        // Grilla_Capas_Sujeto
                        // 
                        Grilla_Capas_Sujeto.AllowUserToDeleteRows = false;
                        Grilla_Capas_Sujeto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Capas_Sujeto.Location = new Point(24, 67);
                        Grilla_Capas_Sujeto.MultiSelect = false;
                        Grilla_Capas_Sujeto.Name = "Grilla_Capas_Sujeto";
                        Grilla_Capas_Sujeto.ReadOnly = true;
                        Grilla_Capas_Sujeto.RowHeadersWidth = 51;
                        Grilla_Capas_Sujeto.RowTemplate.Height = 29;
                        Grilla_Capas_Sujeto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Capas_Sujeto.Size = new Size(468, 572);
                        Grilla_Capas_Sujeto.TabIndex = 7;
                        Grilla_Capas_Sujeto.CellClick += Grilla_Capas_Sujeto_CellClick;
                        Grilla_Capas_Sujeto.DoubleClick += Grilla_Capas_Sujeto_DoubleClick;
                        // 
                        // GroupBox_Atributos
                        // 
                        GroupBox_Atributos.Controls.Add(panel2);
                        GroupBox_Atributos.Controls.Add(Atributos_Capa);
                        GroupBox_Atributos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Atributos.Location = new Point(535, 109);
                        GroupBox_Atributos.Name = "GroupBox_Atributos";
                        GroupBox_Atributos.Size = new Size(383, 528);
                        GroupBox_Atributos.TabIndex = 0;
                        GroupBox_Atributos.TabStop = false;
                        GroupBox_Atributos.Text = "Atributos de la capa";
                        // 
                        // panel2
                        // 
                        panel2.Location = new Point(12, 26);
                        panel2.Name = "panel2";
                        panel2.Size = new Size(347, 20);
                        panel2.TabIndex = 18;
                        // 
                        // Atributos_Capa
                        // 
                        Atributos_Capa.Appearance = TabAppearance.FlatButtons;
                        Atributos_Capa.Controls.Add(Personas);
                        Atributos_Capa.Controls.Add(Usuarios);
                        Atributos_Capa.Controls.Add(Empleados);
                        Atributos_Capa.Controls.Add(Proveedores);
                        Atributos_Capa.ItemSize = new Size(100, 1);
                        Atributos_Capa.Location = new Point(12, 33);
                        Atributos_Capa.Name = "Atributos_Capa";
                        Atributos_Capa.SelectedIndex = 0;
                        Atributos_Capa.Size = new Size(347, 476);
                        Atributos_Capa.TabIndex = 0;
                        // 
                        // Personas
                        // 
                        Personas.Controls.Add(TextBox_Telefono);
                        Personas.Controls.Add(Label_Telefono);
                        Personas.Controls.Add(TextBox_Apellido);
                        Personas.Controls.Add(Label_Apellido);
                        Personas.Controls.Add(TextBox_Nombre);
                        Personas.Controls.Add(Label_Nombre);
                        Personas.Location = new Point(4, 5);
                        Personas.Name = "Personas";
                        Personas.Padding = new Padding(3);
                        Personas.Size = new Size(339, 467);
                        Personas.TabIndex = 0;
                        Personas.Text = "Personas";
                        Personas.UseVisualStyleBackColor = true;
                        // 
                        // TextBox_Telefono
                        // 
                        TextBox_Telefono.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Telefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Telefono.Location = new Point(62, 221);
                        TextBox_Telefono.MaxLength = 20;
                        TextBox_Telefono.Name = "TextBox_Telefono";
                        TextBox_Telefono.Size = new Size(193, 27);
                        TextBox_Telefono.TabIndex = 10;
                        TextBox_Telefono.TextChanged += TextBox_Telefono_TextChanged;
                        // 
                        // Label_Telefono
                        // 
                        Label_Telefono.AutoSize = true;
                        Label_Telefono.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Telefono.Location = new Point(62, 198);
                        Label_Telefono.Name = "Label_Telefono";
                        Label_Telefono.Size = new Size(150, 20);
                        Label_Telefono.TabIndex = 5;
                        Label_Telefono.Text = "Número de Teléfono";
                        // 
                        // TextBox_Apellido
                        // 
                        TextBox_Apellido.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Apellido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Apellido.Location = new Point(62, 141);
                        TextBox_Apellido.MaxLength = 20;
                        TextBox_Apellido.Name = "TextBox_Apellido";
                        TextBox_Apellido.Size = new Size(193, 27);
                        TextBox_Apellido.TabIndex = 9;
                        TextBox_Apellido.TextChanged += TextBox_Apellido_TextChanged;
                        // 
                        // Label_Apellido
                        // 
                        Label_Apellido.AutoSize = true;
                        Label_Apellido.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Apellido.Location = new Point(62, 118);
                        Label_Apellido.Name = "Label_Apellido";
                        Label_Apellido.Size = new Size(66, 20);
                        Label_Apellido.TabIndex = 3;
                        Label_Apellido.Text = "Apellido";
                        // 
                        // TextBox_Nombre
                        // 
                        TextBox_Nombre.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Nombre.Location = new Point(62, 60);
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
                        Label_Nombre.Location = new Point(62, 37);
                        Label_Nombre.Name = "Label_Nombre";
                        Label_Nombre.Size = new Size(66, 20);
                        Label_Nombre.TabIndex = 1;
                        Label_Nombre.Text = "Nombre";
                        // 
                        // Usuarios
                        // 
                        Usuarios.Controls.Add(CheckBox_Nueva_Contrasena);
                        Usuarios.Controls.Add(panel1);
                        Usuarios.Controls.Add(CheckedListBox_Permisos);
                        Usuarios.Controls.Add(Label_Permisos);
                        Usuarios.Controls.Add(CheckBox_Inactivo);
                        Usuarios.Controls.Add(TextBox_Contrasena);
                        Usuarios.Controls.Add(Label_Nueva_Contrasena);
                        Usuarios.Controls.Add(TextBox_Nombre_Identificador);
                        Usuarios.Controls.Add(Label_Nombre_Identificador);
                        Usuarios.Location = new Point(4, 14);
                        Usuarios.Name = "Usuarios";
                        Usuarios.Padding = new Padding(3);
                        Usuarios.Size = new Size(339, 458);
                        Usuarios.TabIndex = 1;
                        Usuarios.Text = "Usuarios";
                        Usuarios.UseVisualStyleBackColor = true;
                        // 
                        // CheckBox_Nueva_Contrasena
                        // 
                        CheckBox_Nueva_Contrasena.AutoSize = true;
                        CheckBox_Nueva_Contrasena.Location = new Point(201, 121);
                        CheckBox_Nueva_Contrasena.Name = "CheckBox_Nueva_Contrasena";
                        CheckBox_Nueva_Contrasena.Size = new Size(18, 17);
                        CheckBox_Nueva_Contrasena.TabIndex = 12;
                        toolTip1.SetToolTip(CheckBox_Nueva_Contrasena, "Si se le va a asignar la contraseña indicada al Usuario(ya sea que tenga una o no)");
                        CheckBox_Nueva_Contrasena.UseVisualStyleBackColor = true;
                        CheckBox_Nueva_Contrasena.CheckedChanged += CheckBox_Nueva_Contrasena_CheckedChanged;
                        // 
                        // panel1
                        // 
                        panel1.Location = new Point(0, -7);
                        panel1.Name = "panel1";
                        panel1.Size = new Size(363, 10);
                        panel1.TabIndex = 10;
                        // 
                        // CheckedListBox_Permisos
                        // 
                        CheckedListBox_Permisos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        CheckedListBox_Permisos.FormattingEnabled = true;
                        CheckedListBox_Permisos.Items.AddRange(new object[] { "Gestion Comercial", "Gestion de Sujetos", "Pago", "Publicar bienes" });
                        CheckedListBox_Permisos.Location = new Point(62, 222);
                        CheckedListBox_Permisos.Name = "CheckedListBox_Permisos";
                        CheckedListBox_Permisos.Size = new Size(193, 92);
                        CheckedListBox_Permisos.TabIndex = 14;
                        toolTip1.SetToolTip(CheckedListBox_Permisos, resources.GetString("CheckedListBox_Permisos.ToolTip"));
                        // 
                        // Label_Permisos
                        // 
                        Label_Permisos.AutoSize = true;
                        Label_Permisos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Permisos.Location = new Point(62, 199);
                        Label_Permisos.Name = "Label_Permisos";
                        Label_Permisos.Size = new Size(69, 20);
                        Label_Permisos.TabIndex = 8;
                        Label_Permisos.Text = "Permisos";
                        toolTip1.SetToolTip(Label_Permisos, "Lo que puede o no hacer un Usuario en el programa.");
                        // 
                        // CheckBox_Inactivo
                        // 
                        CheckBox_Inactivo.AutoSize = true;
                        CheckBox_Inactivo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        CheckBox_Inactivo.Location = new Point(62, 348);
                        CheckBox_Inactivo.Name = "CheckBox_Inactivo";
                        CheckBox_Inactivo.Size = new Size(85, 24);
                        CheckBox_Inactivo.TabIndex = 15;
                        CheckBox_Inactivo.Text = "Inactivo";
                        toolTip1.SetToolTip(CheckBox_Inactivo, "Si el Usuario tiene permitido o no ingresar al programa.");
                        CheckBox_Inactivo.UseVisualStyleBackColor = true;
                        // 
                        // TextBox_Contrasena
                        // 
                        TextBox_Contrasena.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Contrasena.Enabled = false;
                        TextBox_Contrasena.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Contrasena.Location = new Point(62, 141);
                        TextBox_Contrasena.MaxLength = 100;
                        TextBox_Contrasena.Name = "TextBox_Contrasena";
                        TextBox_Contrasena.PlaceholderText = "La nueva contraseña";
                        TextBox_Contrasena.Size = new Size(193, 27);
                        TextBox_Contrasena.TabIndex = 13;
                        toolTip1.SetToolTip(TextBox_Contrasena, "El texto que un Usuario debe ingresar junto a su Nombre Identificador para ingresar al programa.");
                        // 
                        // Label_Nueva_Contrasena
                        // 
                        Label_Nueva_Contrasena.AutoSize = true;
                        Label_Nueva_Contrasena.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nueva_Contrasena.Location = new Point(62, 118);
                        Label_Nueva_Contrasena.Name = "Label_Nueva_Contrasena";
                        Label_Nueva_Contrasena.Size = new Size(133, 20);
                        Label_Nueva_Contrasena.TabIndex = 4;
                        Label_Nueva_Contrasena.Text = "Nueva contraseña";
                        // 
                        // TextBox_Nombre_Identificador
                        // 
                        TextBox_Nombre_Identificador.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre_Identificador.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Nombre_Identificador.Location = new Point(62, 60);
                        TextBox_Nombre_Identificador.MaxLength = 30;
                        TextBox_Nombre_Identificador.Name = "TextBox_Nombre_Identificador";
                        TextBox_Nombre_Identificador.Size = new Size(193, 27);
                        TextBox_Nombre_Identificador.TabIndex = 11;
                        toolTip1.SetToolTip(TextBox_Nombre_Identificador, "El nombre que usa un Usuario para ingresar e identificarse en el sistema");
                        // 
                        // Label_Nombre_Identificador
                        // 
                        Label_Nombre_Identificador.AutoSize = true;
                        Label_Nombre_Identificador.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nombre_Identificador.Location = new Point(62, 37);
                        Label_Nombre_Identificador.Name = "Label_Nombre_Identificador";
                        Label_Nombre_Identificador.Size = new Size(157, 20);
                        Label_Nombre_Identificador.TabIndex = 2;
                        Label_Nombre_Identificador.Text = "Nombre Identificador";
                        // 
                        // Empleados
                        // 
                        Empleados.Controls.Add(Button_Gestionar_Tareas);
                        Empleados.Controls.Add(NumericUpDown_Horas_Trabajadas);
                        Empleados.Controls.Add(Label_Horas_Trabajadas);
                        Empleados.Location = new Point(4, 14);
                        Empleados.Name = "Empleados";
                        Empleados.Padding = new Padding(3);
                        Empleados.Size = new Size(339, 458);
                        Empleados.TabIndex = 2;
                        Empleados.Text = "Empleados";
                        Empleados.UseVisualStyleBackColor = true;
                        // 
                        // Button_Gestionar_Tareas
                        // 
                        Button_Gestionar_Tareas.Enabled = false;
                        Button_Gestionar_Tareas.FlatStyle = FlatStyle.Flat;
                        Button_Gestionar_Tareas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Gestionar_Tareas.Location = new Point(62, 115);
                        Button_Gestionar_Tareas.Name = "Button_Gestionar_Tareas";
                        Button_Gestionar_Tareas.Size = new Size(150, 39);
                        Button_Gestionar_Tareas.TabIndex = 17;
                        Button_Gestionar_Tareas.Text = "Gestionar tareas";
                        Button_Gestionar_Tareas.UseVisualStyleBackColor = true;
                        // 
                        // NumericUpDown_Horas_Trabajadas
                        // 
                        NumericUpDown_Horas_Trabajadas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        NumericUpDown_Horas_Trabajadas.Location = new Point(62, 60);
                        NumericUpDown_Horas_Trabajadas.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
                        NumericUpDown_Horas_Trabajadas.Name = "NumericUpDown_Horas_Trabajadas";
                        NumericUpDown_Horas_Trabajadas.Size = new Size(150, 27);
                        NumericUpDown_Horas_Trabajadas.TabIndex = 16;
                        // 
                        // Label_Horas_Trabajadas
                        // 
                        Label_Horas_Trabajadas.AutoSize = true;
                        Label_Horas_Trabajadas.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Horas_Trabajadas.Location = new Point(62, 37);
                        Label_Horas_Trabajadas.Name = "Label_Horas_Trabajadas";
                        Label_Horas_Trabajadas.Size = new Size(124, 20);
                        Label_Horas_Trabajadas.TabIndex = 3;
                        Label_Horas_Trabajadas.Text = "Horas trabajadas";
                        // 
                        // Proveedores
                        // 
                        Proveedores.AutoScroll = true;
                        Proveedores.Controls.Add(TextBox_Email_Empresa);
                        Proveedores.Controls.Add(Label_Email_Empresa);
                        Proveedores.Controls.Add(TextBox_Nombre_Empresa);
                        Proveedores.Controls.Add(Label_Nombre_Empresa);
                        Proveedores.Controls.Add(Label_Direccion_Empresa);
                        Proveedores.Controls.Add(TextBox_Indicaciones);
                        Proveedores.Controls.Add(Label_Indicaciones);
                        Proveedores.Controls.Add(TextBox_Calle2);
                        Proveedores.Controls.Add(label1);
                        Proveedores.Controls.Add(TextBox_Calle1);
                        Proveedores.Controls.Add(Label_Calle1);
                        Proveedores.Controls.Add(TextBox_Barrio);
                        Proveedores.Controls.Add(Label_Barrio);
                        Proveedores.Controls.Add(CheckBox_Tiene_Empresa);
                        Proveedores.Location = new Point(4, 14);
                        Proveedores.Name = "Proveedores";
                        Proveedores.Padding = new Padding(3);
                        Proveedores.Size = new Size(339, 458);
                        Proveedores.TabIndex = 3;
                        Proveedores.Text = "Proveedores";
                        Proveedores.UseVisualStyleBackColor = true;
                        // 
                        // TextBox_Email_Empresa
                        // 
                        TextBox_Email_Empresa.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Email_Empresa.Enabled = false;
                        TextBox_Email_Empresa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Email_Empresa.Location = new Point(60, 234);
                        TextBox_Email_Empresa.MaxLength = 50;
                        TextBox_Email_Empresa.Name = "TextBox_Email_Empresa";
                        TextBox_Email_Empresa.Size = new Size(193, 27);
                        TextBox_Email_Empresa.TabIndex = 20;
                        TextBox_Email_Empresa.TextChanged += TextBox_Email_Empresa_TextChanged;
                        // 
                        // Label_Email_Empresa
                        // 
                        Label_Email_Empresa.AutoSize = true;
                        Label_Email_Empresa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Email_Empresa.Location = new Point(60, 211);
                        Label_Email_Empresa.Name = "Label_Email_Empresa";
                        Label_Email_Empresa.Size = new Size(145, 20);
                        Label_Email_Empresa.TabIndex = 18;
                        Label_Email_Empresa.Text = "Email de la Empresa";
                        // 
                        // TextBox_Nombre_Empresa
                        // 
                        TextBox_Nombre_Empresa.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre_Empresa.Enabled = false;
                        TextBox_Nombre_Empresa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Nombre_Empresa.Location = new Point(60, 152);
                        TextBox_Nombre_Empresa.MaxLength = 20;
                        TextBox_Nombre_Empresa.Name = "TextBox_Nombre_Empresa";
                        TextBox_Nombre_Empresa.Size = new Size(193, 27);
                        TextBox_Nombre_Empresa.TabIndex = 19;
                        toolTip1.SetToolTip(TextBox_Nombre_Empresa, "El texto que un Usuario debe ingresar junto a su Nombre Identificador para ingresar al programa.");
                        // 
                        // Label_Nombre_Empresa
                        // 
                        Label_Nombre_Empresa.AutoSize = true;
                        Label_Nombre_Empresa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nombre_Empresa.Location = new Point(63, 129);
                        Label_Nombre_Empresa.Name = "Label_Nombre_Empresa";
                        Label_Nombre_Empresa.Size = new Size(165, 20);
                        Label_Nombre_Empresa.TabIndex = 16;
                        Label_Nombre_Empresa.Text = "Nombre de la Empresa";
                        // 
                        // Label_Direccion_Empresa
                        // 
                        Label_Direccion_Empresa.AutoSize = true;
                        Label_Direccion_Empresa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Direccion_Empresa.Location = new Point(60, 93);
                        Label_Direccion_Empresa.Name = "Label_Direccion_Empresa";
                        Label_Direccion_Empresa.Size = new Size(178, 23);
                        Label_Direccion_Empresa.TabIndex = 14;
                        Label_Direccion_Empresa.Text = "Datos de la Empresa:";
                        // 
                        // TextBox_Indicaciones
                        // 
                        TextBox_Indicaciones.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Indicaciones.Enabled = false;
                        TextBox_Indicaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Indicaciones.Location = new Point(60, 604);
                        TextBox_Indicaciones.MaxLength = 300;
                        TextBox_Indicaciones.Multiline = true;
                        TextBox_Indicaciones.Name = "TextBox_Indicaciones";
                        TextBox_Indicaciones.Size = new Size(252, 48);
                        TextBox_Indicaciones.TabIndex = 24;
                        toolTip1.SetToolTip(TextBox_Indicaciones, "El texto que un Usuario debe ingresar junto a su Nombre Identificador para ingresar al programa.");
                        // 
                        // Label_Indicaciones
                        // 
                        Label_Indicaciones.AutoSize = true;
                        Label_Indicaciones.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Indicaciones.Location = new Point(60, 581);
                        Label_Indicaciones.Name = "Label_Indicaciones";
                        Label_Indicaciones.Size = new Size(173, 20);
                        Label_Indicaciones.TabIndex = 12;
                        Label_Indicaciones.Text = "Indicaciones adicionales";
                        // 
                        // TextBox_Calle2
                        // 
                        TextBox_Calle2.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Calle2.Enabled = false;
                        TextBox_Calle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Calle2.Location = new Point(60, 511);
                        TextBox_Calle2.MaxLength = 20;
                        TextBox_Calle2.Name = "TextBox_Calle2";
                        TextBox_Calle2.Size = new Size(193, 27);
                        TextBox_Calle2.TabIndex = 23;
                        toolTip1.SetToolTip(TextBox_Calle2, "El texto que un Usuario debe ingresar junto a su Nombre Identificador para ingresar al programa.");
                        // 
                        // label1
                        // 
                        label1.AutoSize = true;
                        label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        label1.Location = new Point(60, 488);
                        label1.Name = "label1";
                        label1.Size = new Size(91, 20);
                        label1.TabIndex = 10;
                        label1.Text = "La otra calle";
                        // 
                        // TextBox_Calle1
                        // 
                        TextBox_Calle1.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Calle1.Enabled = false;
                        TextBox_Calle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Calle1.Location = new Point(60, 415);
                        TextBox_Calle1.MaxLength = 20;
                        TextBox_Calle1.Name = "TextBox_Calle1";
                        TextBox_Calle1.Size = new Size(193, 27);
                        TextBox_Calle1.TabIndex = 22;
                        toolTip1.SetToolTip(TextBox_Calle1, "El texto que un Usuario debe ingresar junto a su Nombre Identificador para ingresar al programa.");
                        // 
                        // Label_Calle1
                        // 
                        Label_Calle1.AutoSize = true;
                        Label_Calle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Calle1.Location = new Point(60, 392);
                        Label_Calle1.Name = "Label_Calle1";
                        Label_Calle1.Size = new Size(42, 20);
                        Label_Calle1.TabIndex = 8;
                        Label_Calle1.Text = "Calle";
                        // 
                        // TextBox_Barrio
                        // 
                        TextBox_Barrio.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Barrio.Enabled = false;
                        TextBox_Barrio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        TextBox_Barrio.Location = new Point(60, 319);
                        TextBox_Barrio.MaxLength = 20;
                        TextBox_Barrio.Name = "TextBox_Barrio";
                        TextBox_Barrio.Size = new Size(193, 27);
                        TextBox_Barrio.TabIndex = 21;
                        toolTip1.SetToolTip(TextBox_Barrio, "El texto que un Usuario debe ingresar junto a su Nombre Identificador para ingresar al programa.");
                        // 
                        // Label_Barrio
                        // 
                        Label_Barrio.AutoSize = true;
                        Label_Barrio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Barrio.Location = new Point(60, 296);
                        Label_Barrio.Name = "Label_Barrio";
                        Label_Barrio.Size = new Size(51, 20);
                        Label_Barrio.TabIndex = 6;
                        Label_Barrio.Text = "Barrio";
                        // 
                        // CheckBox_Tiene_Empresa
                        // 
                        CheckBox_Tiene_Empresa.AutoSize = true;
                        CheckBox_Tiene_Empresa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        CheckBox_Tiene_Empresa.Location = new Point(62, 37);
                        CheckBox_Tiene_Empresa.Name = "CheckBox_Tiene_Empresa";
                        CheckBox_Tiene_Empresa.Size = new Size(181, 24);
                        CheckBox_Tiene_Empresa.TabIndex = 18;
                        CheckBox_Tiene_Empresa.Text = "Representa a empresa";
                        CheckBox_Tiene_Empresa.UseVisualStyleBackColor = true;
                        CheckBox_Tiene_Empresa.CheckedChanged += CheckBox_Tiene_Empresa_CheckedChanged;
                        // 
                        // GroupBox_Controles
                        // 
                        GroupBox_Controles.Controls.Add(Button_Eliminar);
                        GroupBox_Controles.Controls.Add(Button_Modificar);
                        GroupBox_Controles.Controls.Add(Button_Crear);
                        GroupBox_Controles.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Controles.Location = new Point(535, 643);
                        GroupBox_Controles.Name = "GroupBox_Controles";
                        GroupBox_Controles.Size = new Size(383, 167);
                        GroupBox_Controles.TabIndex = 4;
                        GroupBox_Controles.TabStop = false;
                        GroupBox_Controles.Text = "Controles";
                        // 
                        // Button_Eliminar
                        // 
                        Button_Eliminar.BackColor = Color.FromArgb(192, 0, 0);
                        Button_Eliminar.Cursor = Cursors.Hand;
                        Button_Eliminar.Enabled = false;
                        Button_Eliminar.FlatAppearance.BorderColor = Color.Maroon;
                        Button_Eliminar.FlatAppearance.BorderSize = 3;
                        Button_Eliminar.FlatStyle = FlatStyle.Flat;
                        Button_Eliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Eliminar.ForeColor = Color.Silver;
                        Button_Eliminar.Location = new Point(116, 103);
                        Button_Eliminar.Name = "Button_Eliminar";
                        Button_Eliminar.Size = new Size(198, 35);
                        Button_Eliminar.TabIndex = 27;
                        Button_Eliminar.Text = "Eliminar";
                        Button_Eliminar.UseVisualStyleBackColor = false;
                        Button_Eliminar.Click += Button_Eliminar_Click;
                        // 
                        // Button_Modificar
                        // 
                        Button_Modificar.BackColor = Color.Gold;
                        Button_Modificar.Cursor = Cursors.Hand;
                        Button_Modificar.Enabled = false;
                        Button_Modificar.FlatAppearance.BorderColor = Color.Goldenrod;
                        Button_Modificar.FlatAppearance.BorderSize = 3;
                        Button_Modificar.FlatStyle = FlatStyle.Flat;
                        Button_Modificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Modificar.ForeColor = SystemColors.ActiveCaptionText;
                        Button_Modificar.Location = new Point(116, 62);
                        Button_Modificar.Name = "Button_Modificar";
                        Button_Modificar.Size = new Size(198, 35);
                        Button_Modificar.TabIndex = 26;
                        Button_Modificar.Text = "Modificar";
                        Button_Modificar.UseVisualStyleBackColor = false;
                        Button_Modificar.Click += Button_Modificar_Click;
                        // 
                        // Button_Crear
                        // 
                        Button_Crear.BackColor = Color.ForestGreen;
                        Button_Crear.Cursor = Cursors.Hand;
                        Button_Crear.FlatAppearance.BorderColor = Color.YellowGreen;
                        Button_Crear.FlatAppearance.BorderSize = 3;
                        Button_Crear.FlatStyle = FlatStyle.Flat;
                        Button_Crear.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Crear.ForeColor = SystemColors.Control;
                        Button_Crear.Location = new Point(116, 21);
                        Button_Crear.Name = "Button_Crear";
                        Button_Crear.Size = new Size(198, 35);
                        Button_Crear.TabIndex = 25;
                        Button_Crear.Text = "Crear";
                        Button_Crear.UseVisualStyleBackColor = false;
                        Button_Crear.Click += Button_Crear_Click;
                        // 
                        // Gestion_Sujetos
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(930, 822);
                        Controls.Add(GroupBox_Controles);
                        Controls.Add(GroupBox_Atributos);
                        Controls.Add(GroupBox_Grilla);
                        Controls.Add(Seleccion_Capas);
                        Name = "Gestion_Sujetos";
                        Text = "Quién Da Más?: Gestion de Sujetos";
                        Seleccion_Capas.ResumeLayout(false);
                        GroupBox_Grilla.ResumeLayout(false);
                        GroupBox_Grilla.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Capas_Sujeto).EndInit();
                        GroupBox_Atributos.ResumeLayout(false);
                        Atributos_Capa.ResumeLayout(false);
                        Personas.ResumeLayout(false);
                        Personas.PerformLayout();
                        Usuarios.ResumeLayout(false);
                        Usuarios.PerformLayout();
                        Empleados.ResumeLayout(false);
                        Empleados.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Horas_Trabajadas).EndInit();
                        Proveedores.ResumeLayout(false);
                        Proveedores.PerformLayout();
                        GroupBox_Controles.ResumeLayout(false);
                        ResumeLayout(false);
                }

                #endregion

                private TabControl Atributos_Capa;
                private TabPage Personas;
                private TabPage Usuarios;
                private Label Label_Nombre;
                private Label Label_Indicaciones;
                private GroupBox Seleccion_Capas;
                public Button Button_Personas;
                public Button Button_Usuarios;
                public Button Button_Empleados;
                public Button Button_Proveedores;
                private GroupBox GroupBox_Grilla;
                private DataGridView Grilla_Capas_Sujeto;
                private TextBox TextBox_Buscador;
                private Librerias_Locales.FlatComboBox DropDownList_Buscador;
                private GroupBox GroupBox_Atributos;
                private TextBox TextBox_Nombre;
                private TextBox TextBox_Telefono;
                private Label Label_Telefono;
                private TextBox TextBox_Apellido;
                private Label Label_Apellido;
                private Label Label_Nombre_Identificador;
                private TextBox TextBox_Nombre_Identificador;
                private CheckBox CheckBox_Inactivo;
                private TextBox TextBox_Contrasena;
                private Label Label_Contrasena;
                private CheckedListBox CheckedListBox_Permisos;
                private Label Label_Permisos;
                private ToolTip toolTip1;
                private TabPage Empleados;
                private Label Label_Horas_Trabajadas;
                private NumericUpDown NumericUpDown_Horas_Trabajadas;
                private Button Button_Gestionar_Tareas;
                private TabPage Proveedores;
                private CheckBox CheckBox_Tiene_Empresa;
                private TextBox TextBox_Calle1;
                private Label Label_Calle1;
                private Label Label_Barrio;
                private TextBox TextBox_Calle2;
                private Label label1;
                private TextBox TextBox_Indicaciones;
                private Label Label_Direccion_Empresa;
                private Label Label_ID_Persona;
                private Label Label_ID_Capa;
                private Panel panel1;
                private Label Label_Nombre_Empresa;
                private TextBox TextBox_Nombre_Empresa;
                private Panel panel2;
                private GroupBox GroupBox_Controles;
                private Button Button_Eliminar;
                private Button Button_Modificar;
                private Button Button_Crear;
                private TextBox TextBox_Email_Empresa;
                private Label Label_Email_Empresa;
                private TextBox TextBox_Barrio;
                private CheckBox CheckBox_Nueva_Contrasena;
                private Label Label_Nueva_Contrasena;
        }
}