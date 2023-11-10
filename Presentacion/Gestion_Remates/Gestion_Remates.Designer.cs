namespace Presentacion.Gestion_Remates
{
        partial class Gestion_Remates
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
                        GroupBox_Grillas = new GroupBox();
                        Label_ID_Remate_Actual = new Label();
                        Button_Izquierda = new Button();
                        Button_Derecha = new Button();
                        Label_Seleccion_Elementos_Subasta = new Label();
                        Grilla_Integrantes_Remate = new DataGridView();
                        Label_Elementos_Subasta = new Label();
                        Grilla_Elementos_Disponibles = new DataGridView();
                        GroupBox_Atributos = new GroupBox();
                        DropDownList_Metodo_Pago = new ComboBox();
                        Label_Metodo_Pago = new Label();
                        Label_Categoria = new Label();
                        Label_Opciones = new Label();
                        Label_Hora = new Label();
                        Label_Dia = new Label();
                        CheckBox_Permitir_Fechas_Pasadas = new CheckBox();
                        DropDownList_Tipo = new ComboBox();
                        DropDownList_Seleccion_Momento = new ComboBox();
                        TimePicker_Hora_Momento = new DateTimePicker();
                        Calendar_Momento = new MonthCalendar();
                        TextBox_ID = new TextBox();
                        Button_Ir_A_ID = new Button();
                        GroupBox_Seleccionar_Remate = new GroupBox();
                        Button_Seleccionar_Por_Elemento = new Button();
                        GroupBox_Controles = new GroupBox();
                        Button_Eliminar = new Button();
                        Button_Modificar = new Button();
                        Button_Crear = new Button();
                        GroupBox_Grillas.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Integrantes_Remate).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Elementos_Disponibles).BeginInit();
                        GroupBox_Atributos.SuspendLayout();
                        GroupBox_Seleccionar_Remate.SuspendLayout();
                        GroupBox_Controles.SuspendLayout();
                        SuspendLayout();
                        // 
                        // GroupBox_Grillas
                        // 
                        GroupBox_Grillas.Controls.Add(Label_ID_Remate_Actual);
                        GroupBox_Grillas.Controls.Add(Button_Izquierda);
                        GroupBox_Grillas.Controls.Add(Button_Derecha);
                        GroupBox_Grillas.Controls.Add(Label_Seleccion_Elementos_Subasta);
                        GroupBox_Grillas.Controls.Add(Grilla_Integrantes_Remate);
                        GroupBox_Grillas.Controls.Add(Label_Elementos_Subasta);
                        GroupBox_Grillas.Controls.Add(Grilla_Elementos_Disponibles);
                        GroupBox_Grillas.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Grillas.Location = new Point(12, 12);
                        GroupBox_Grillas.Name = "GroupBox_Grillas";
                        GroupBox_Grillas.Size = new Size(1133, 478);
                        GroupBox_Grillas.TabIndex = 12;
                        GroupBox_Grillas.TabStop = false;
                        GroupBox_Grillas.Text = "Seleccion de Integrantes del Remate";
                        // 
                        // Label_ID_Remate_Actual
                        // 
                        Label_ID_Remate_Actual.AutoSize = true;
                        Label_ID_Remate_Actual.Enabled = false;
                        Label_ID_Remate_Actual.Font = new Font("Segoe UI Semilight", 7.20000029F, FontStyle.Italic, GraphicsUnit.Point);
                        Label_ID_Remate_Actual.Location = new Point(645, 433);
                        Label_ID_Remate_Actual.Name = "Label_ID_Remate_Actual";
                        Label_ID_Remate_Actual.Size = new Size(209, 17);
                        Label_ID_Remate_Actual.TabIndex = 18;
                        Label_ID_Remate_Actual.Text = "ID del Remate actual = @ID_Remate";
                        // 
                        // Button_Izquierda
                        // 
                        Button_Izquierda.Cursor = Cursors.Hand;
                        Button_Izquierda.Enabled = false;
                        Button_Izquierda.FlatStyle = FlatStyle.Popup;
                        Button_Izquierda.Location = new Point(566, 241);
                        Button_Izquierda.Name = "Button_Izquierda";
                        Button_Izquierda.Size = new Size(51, 67);
                        Button_Izquierda.TabIndex = 17;
                        Button_Izquierda.Text = "◄";
                        Button_Izquierda.UseVisualStyleBackColor = true;
                        Button_Izquierda.Click += Button_Izquierda_Click;
                        // 
                        // Button_Derecha
                        // 
                        Button_Derecha.Cursor = Cursors.Hand;
                        Button_Derecha.Enabled = false;
                        Button_Derecha.FlatStyle = FlatStyle.Popup;
                        Button_Derecha.Location = new Point(566, 145);
                        Button_Derecha.Name = "Button_Derecha";
                        Button_Derecha.Size = new Size(51, 67);
                        Button_Derecha.TabIndex = 16;
                        Button_Derecha.Text = "►";
                        Button_Derecha.UseVisualStyleBackColor = true;
                        Button_Derecha.Click += Button_Derecha_Click;
                        // 
                        // Label_Seleccion_Elementos_Subasta
                        // 
                        Label_Seleccion_Elementos_Subasta.AutoSize = true;
                        Label_Seleccion_Elementos_Subasta.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Seleccion_Elementos_Subasta.Location = new Point(883, 35);
                        Label_Seleccion_Elementos_Subasta.Name = "Label_Seleccion_Elementos_Subasta";
                        Label_Seleccion_Elementos_Subasta.RightToLeft = RightToLeft.Yes;
                        Label_Seleccion_Elementos_Subasta.Size = new Size(189, 23);
                        Label_Seleccion_Elementos_Subasta.TabIndex = 15;
                        Label_Seleccion_Elementos_Subasta.Text = "Integrantes del Remate";
                        // 
                        // Grilla_Integrantes_Remate
                        // 
                        Grilla_Integrantes_Remate.AllowUserToAddRows = false;
                        Grilla_Integrantes_Remate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Integrantes_Remate.Location = new Point(645, 72);
                        Grilla_Integrantes_Remate.Name = "Grilla_Integrantes_Remate";
                        Grilla_Integrantes_Remate.ReadOnly = true;
                        Grilla_Integrantes_Remate.RowHeadersWidth = 51;
                        Grilla_Integrantes_Remate.RowTemplate.Height = 29;
                        Grilla_Integrantes_Remate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Integrantes_Remate.Size = new Size(427, 358);
                        Grilla_Integrantes_Remate.TabIndex = 14;
                        Grilla_Integrantes_Remate.SelectionChanged += Grilla_Derecha_SelectionChanged;
                        Grilla_Integrantes_Remate.MouseDoubleClick += Grilla_Derecha_MouseDoubleClick;
                        // 
                        // Label_Elementos_Subasta
                        // 
                        Label_Elementos_Subasta.AutoSize = true;
                        Label_Elementos_Subasta.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Elementos_Subasta.Location = new Point(54, 35);
                        Label_Elementos_Subasta.Name = "Label_Elementos_Subasta";
                        Label_Elementos_Subasta.Size = new Size(254, 23);
                        Label_Elementos_Subasta.TabIndex = 13;
                        Label_Elementos_Subasta.Text = "Todos los elementos disponibles";
                        // 
                        // Grilla_Elementos_Disponibles
                        // 
                        Grilla_Elementos_Disponibles.AllowUserToAddRows = false;
                        Grilla_Elementos_Disponibles.AllowUserToDeleteRows = false;
                        Grilla_Elementos_Disponibles.AllowUserToOrderColumns = true;
                        Grilla_Elementos_Disponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Elementos_Disponibles.Location = new Point(54, 72);
                        Grilla_Elementos_Disponibles.Name = "Grilla_Elementos_Disponibles";
                        Grilla_Elementos_Disponibles.ReadOnly = true;
                        Grilla_Elementos_Disponibles.RowHeadersWidth = 51;
                        Grilla_Elementos_Disponibles.RowTemplate.Height = 29;
                        Grilla_Elementos_Disponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Elementos_Disponibles.Size = new Size(481, 358);
                        Grilla_Elementos_Disponibles.TabIndex = 12;
                        Grilla_Elementos_Disponibles.SelectionChanged += Grilla_Izquierda_SelectionChanged;
                        Grilla_Elementos_Disponibles.MouseDoubleClick += Grilla_Izquierda_MouseDoubleClick;
                        // 
                        // GroupBox_Atributos
                        // 
                        GroupBox_Atributos.Controls.Add(DropDownList_Metodo_Pago);
                        GroupBox_Atributos.Controls.Add(Label_Metodo_Pago);
                        GroupBox_Atributos.Controls.Add(Label_Categoria);
                        GroupBox_Atributos.Controls.Add(Label_Opciones);
                        GroupBox_Atributos.Controls.Add(Label_Hora);
                        GroupBox_Atributos.Controls.Add(Label_Dia);
                        GroupBox_Atributos.Controls.Add(CheckBox_Permitir_Fechas_Pasadas);
                        GroupBox_Atributos.Controls.Add(DropDownList_Tipo);
                        GroupBox_Atributos.Controls.Add(DropDownList_Seleccion_Momento);
                        GroupBox_Atributos.Controls.Add(TimePicker_Hora_Momento);
                        GroupBox_Atributos.Controls.Add(Calendar_Momento);
                        GroupBox_Atributos.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Atributos.Location = new Point(1151, 12);
                        GroupBox_Atributos.Name = "GroupBox_Atributos";
                        GroupBox_Atributos.Size = new Size(531, 409);
                        GroupBox_Atributos.TabIndex = 20;
                        GroupBox_Atributos.TabStop = false;
                        GroupBox_Atributos.Text = "Atributos del Remate";
                        // 
                        // DropDownList_Metodo_Pago
                        // 
                        DropDownList_Metodo_Pago.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Metodo_Pago.FlatStyle = FlatStyle.Flat;
                        DropDownList_Metodo_Pago.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Metodo_Pago.FormattingEnabled = true;
                        DropDownList_Metodo_Pago.Location = new Point(315, 326);
                        DropDownList_Metodo_Pago.Name = "DropDownList_Metodo_Pago";
                        DropDownList_Metodo_Pago.Size = new Size(151, 28);
                        DropDownList_Metodo_Pago.TabIndex = 24;
                        // 
                        // Label_Metodo_Pago
                        // 
                        Label_Metodo_Pago.AutoSize = true;
                        Label_Metodo_Pago.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Metodo_Pago.Location = new Point(315, 303);
                        Label_Metodo_Pago.Name = "Label_Metodo_Pago";
                        Label_Metodo_Pago.Size = new Size(123, 20);
                        Label_Metodo_Pago.TabIndex = 23;
                        Label_Metodo_Pago.Text = "Metodo de Pago";
                        // 
                        // Label_Categoria
                        // 
                        Label_Categoria.AutoSize = true;
                        Label_Categoria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Categoria.Location = new Point(315, 40);
                        Label_Categoria.Name = "Label_Categoria";
                        Label_Categoria.Size = new Size(75, 20);
                        Label_Categoria.TabIndex = 16;
                        Label_Categoria.Text = "Categoria";
                        // 
                        // Label_Opciones
                        // 
                        Label_Opciones.AutoSize = true;
                        Label_Opciones.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Opciones.Location = new Point(315, 212);
                        Label_Opciones.Name = "Label_Opciones";
                        Label_Opciones.Size = new Size(72, 20);
                        Label_Opciones.TabIndex = 22;
                        Label_Opciones.Text = "Opciones";
                        // 
                        // Label_Hora
                        // 
                        Label_Hora.AutoSize = true;
                        Label_Hora.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Hora.Location = new Point(315, 127);
                        Label_Hora.Name = "Label_Hora";
                        Label_Hora.Size = new Size(43, 20);
                        Label_Hora.TabIndex = 21;
                        Label_Hora.Text = "Hora";
                        // 
                        // Label_Dia
                        // 
                        Label_Dia.AutoSize = true;
                        Label_Dia.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Dia.Location = new Point(68, 127);
                        Label_Dia.Name = "Label_Dia";
                        Label_Dia.Size = new Size(32, 20);
                        Label_Dia.TabIndex = 20;
                        Label_Dia.Text = "Día";
                        // 
                        // CheckBox_Permitir_Fechas_Pasadas
                        // 
                        CheckBox_Permitir_Fechas_Pasadas.AutoCheck = false;
                        CheckBox_Permitir_Fechas_Pasadas.AutoSize = true;
                        CheckBox_Permitir_Fechas_Pasadas.Checked = true;
                        CheckBox_Permitir_Fechas_Pasadas.CheckState = CheckState.Checked;
                        CheckBox_Permitir_Fechas_Pasadas.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
                        CheckBox_Permitir_Fechas_Pasadas.Location = new Point(315, 250);
                        CheckBox_Permitir_Fechas_Pasadas.Name = "CheckBox_Permitir_Fechas_Pasadas";
                        CheckBox_Permitir_Fechas_Pasadas.Size = new Size(169, 21);
                        CheckBox_Permitir_Fechas_Pasadas.TabIndex = 19;
                        CheckBox_Permitir_Fechas_Pasadas.Text = "Permitir fechas pasadas";
                        CheckBox_Permitir_Fechas_Pasadas.UseVisualStyleBackColor = true;
                        CheckBox_Permitir_Fechas_Pasadas.Click += CheckBox_Permitir_Fechas_Pasadas_Click;
                        // 
                        // DropDownList_Tipo
                        // 
                        DropDownList_Tipo.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Tipo.FlatStyle = FlatStyle.Flat;
                        DropDownList_Tipo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Tipo.FormattingEnabled = true;
                        DropDownList_Tipo.Items.AddRange(new object[] { "Ninguna", "Animales", "Maquinaria" });
                        DropDownList_Tipo.Location = new Point(315, 72);
                        DropDownList_Tipo.Name = "DropDownList_Tipo";
                        DropDownList_Tipo.Size = new Size(151, 28);
                        DropDownList_Tipo.TabIndex = 16;
                        DropDownList_Tipo.SelectedIndexChanged += DropDownList_Tipo_SelectedIndexChanged;
                        // 
                        // DropDownList_Seleccion_Momento
                        // 
                        DropDownList_Seleccion_Momento.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Seleccion_Momento.FlatStyle = FlatStyle.Flat;
                        DropDownList_Seleccion_Momento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        DropDownList_Seleccion_Momento.FormattingEnabled = true;
                        DropDownList_Seleccion_Momento.Items.AddRange(new object[] { "Momento de Inicio", "Momento de Fin" });
                        DropDownList_Seleccion_Momento.Location = new Point(68, 72);
                        DropDownList_Seleccion_Momento.Name = "DropDownList_Seleccion_Momento";
                        DropDownList_Seleccion_Momento.Size = new Size(151, 28);
                        DropDownList_Seleccion_Momento.TabIndex = 14;
                        DropDownList_Seleccion_Momento.SelectedIndexChanged += DropDownList_Seleccion_Momento_SelectedIndexChanged;
                        // 
                        // TimePicker_Hora_Momento
                        // 
                        TimePicker_Hora_Momento.CustomFormat = "HH:mm";
                        TimePicker_Hora_Momento.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TimePicker_Hora_Momento.Format = DateTimePickerFormat.Custom;
                        TimePicker_Hora_Momento.Location = new Point(315, 156);
                        TimePicker_Hora_Momento.Name = "TimePicker_Hora_Momento";
                        TimePicker_Hora_Momento.ShowUpDown = true;
                        TimePicker_Hora_Momento.Size = new Size(111, 27);
                        TimePicker_Hora_Momento.TabIndex = 13;
                        TimePicker_Hora_Momento.ValueChanged += TimePicker_Hora_Momento_ValueChanged;
                        // 
                        // Calendar_Momento
                        // 
                        Calendar_Momento.AccessibleRole = AccessibleRole.None;
                        Calendar_Momento.FirstDayOfWeek = Day.Sunday;
                        Calendar_Momento.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
                        Calendar_Momento.Location = new Point(68, 156);
                        Calendar_Momento.MaxSelectionCount = 1;
                        Calendar_Momento.Name = "Calendar_Momento";
                        Calendar_Momento.ShowTodayCircle = false;
                        Calendar_Momento.TabIndex = 12;
                        Calendar_Momento.DateChanged += Calendar_Momento_DateChanged;
                        // 
                        // TextBox_ID
                        // 
                        TextBox_ID.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_ID.Location = new Point(437, 51);
                        TextBox_ID.MaxLength = 10;
                        TextBox_ID.Name = "TextBox_ID";
                        TextBox_ID.PlaceholderText = "ID del Remate";
                        TextBox_ID.Size = new Size(125, 27);
                        TextBox_ID.TabIndex = 22;
                        TextBox_ID.TextChanged += TextBox_ID_TextChanged;
                        TextBox_ID.KeyPress += TextBox_ID_KeyPress;
                        // 
                        // Button_Ir_A_ID
                        // 
                        Button_Ir_A_ID.Cursor = Cursors.Hand;
                        Button_Ir_A_ID.FlatAppearance.BorderColor = Color.Silver;
                        Button_Ir_A_ID.FlatStyle = FlatStyle.Flat;
                        Button_Ir_A_ID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Ir_A_ID.Location = new Point(77, 51);
                        Button_Ir_A_ID.Name = "Button_Ir_A_ID";
                        Button_Ir_A_ID.Size = new Size(331, 40);
                        Button_Ir_A_ID.TabIndex = 23;
                        Button_Ir_A_ID.Text = "Ir a Remate por ID";
                        Button_Ir_A_ID.UseVisualStyleBackColor = true;
                        Button_Ir_A_ID.Click += Button_Ir_A_ID_Click;
                        // 
                        // GroupBox_Seleccionar_Remate
                        // 
                        GroupBox_Seleccionar_Remate.Controls.Add(Button_Seleccionar_Por_Elemento);
                        GroupBox_Seleccionar_Remate.Controls.Add(TextBox_ID);
                        GroupBox_Seleccionar_Remate.Controls.Add(Button_Ir_A_ID);
                        GroupBox_Seleccionar_Remate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Seleccionar_Remate.Location = new Point(12, 496);
                        GroupBox_Seleccionar_Remate.Name = "GroupBox_Seleccionar_Remate";
                        GroupBox_Seleccionar_Remate.Size = new Size(1133, 186);
                        GroupBox_Seleccionar_Remate.TabIndex = 24;
                        GroupBox_Seleccionar_Remate.TabStop = false;
                        GroupBox_Seleccionar_Remate.Text = "Seleccionar Remate";
                        // 
                        // Button_Seleccionar_Por_Elemento
                        // 
                        Button_Seleccionar_Por_Elemento.Cursor = Cursors.Hand;
                        Button_Seleccionar_Por_Elemento.FlatAppearance.BorderColor = Color.Silver;
                        Button_Seleccionar_Por_Elemento.FlatStyle = FlatStyle.Flat;
                        Button_Seleccionar_Por_Elemento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Seleccionar_Por_Elemento.Location = new Point(77, 97);
                        Button_Seleccionar_Por_Elemento.Name = "Button_Seleccionar_Por_Elemento";
                        Button_Seleccionar_Por_Elemento.Size = new Size(331, 40);
                        Button_Seleccionar_Por_Elemento.TabIndex = 24;
                        Button_Seleccionar_Por_Elemento.Text = "Buscar Remate por Elemento";
                        Button_Seleccionar_Por_Elemento.UseVisualStyleBackColor = true;
                        Button_Seleccionar_Por_Elemento.Click += Buscar_Por_Elemento_Click;
                        // 
                        // GroupBox_Controles
                        // 
                        GroupBox_Controles.Controls.Add(Button_Eliminar);
                        GroupBox_Controles.Controls.Add(Button_Modificar);
                        GroupBox_Controles.Controls.Add(Button_Crear);
                        GroupBox_Controles.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Controles.Location = new Point(1151, 423);
                        GroupBox_Controles.Name = "GroupBox_Controles";
                        GroupBox_Controles.Size = new Size(531, 259);
                        GroupBox_Controles.TabIndex = 25;
                        GroupBox_Controles.TabStop = false;
                        GroupBox_Controles.Text = "Controles";
                        // 
                        // Button_Eliminar
                        // 
                        Button_Eliminar.BackColor = Color.FromArgb(192, 0, 0);
                        Button_Eliminar.Cursor = Cursors.Hand;
                        Button_Eliminar.FlatAppearance.BorderColor = Color.Maroon;
                        Button_Eliminar.FlatAppearance.BorderSize = 3;
                        Button_Eliminar.FlatStyle = FlatStyle.Flat;
                        Button_Eliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Eliminar.ForeColor = Color.Silver;
                        Button_Eliminar.Location = new Point(160, 170);
                        Button_Eliminar.Name = "Button_Eliminar";
                        Button_Eliminar.Size = new Size(198, 35);
                        Button_Eliminar.TabIndex = 11;
                        Button_Eliminar.Text = "Eliminar";
                        Button_Eliminar.UseVisualStyleBackColor = false;
                        Button_Eliminar.Click += Button_Eliminar_Click;
                        // 
                        // Button_Modificar
                        // 
                        Button_Modificar.BackColor = Color.Gold;
                        Button_Modificar.Cursor = Cursors.Hand;
                        Button_Modificar.FlatAppearance.BorderColor = Color.Goldenrod;
                        Button_Modificar.FlatAppearance.BorderSize = 3;
                        Button_Modificar.FlatStyle = FlatStyle.Flat;
                        Button_Modificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Modificar.ForeColor = SystemColors.ActiveCaptionText;
                        Button_Modificar.Location = new Point(160, 129);
                        Button_Modificar.Name = "Button_Modificar";
                        Button_Modificar.Size = new Size(198, 35);
                        Button_Modificar.TabIndex = 10;
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
                        Button_Crear.Location = new Point(160, 88);
                        Button_Crear.Name = "Button_Crear";
                        Button_Crear.Size = new Size(198, 35);
                        Button_Crear.TabIndex = 9;
                        Button_Crear.Text = "Crear";
                        Button_Crear.UseVisualStyleBackColor = false;
                        Button_Crear.Click += Button_Crear_Click;
                        // 
                        // Gestion_Remates
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(1924, 694);
                        Controls.Add(GroupBox_Controles);
                        Controls.Add(GroupBox_Seleccionar_Remate);
                        Controls.Add(GroupBox_Atributos);
                        Controls.Add(GroupBox_Grillas);
                        Name = "Gestion_Remates";
                        Text = "Gestion Remates";
                        GroupBox_Grillas.ResumeLayout(false);
                        GroupBox_Grillas.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Integrantes_Remate).EndInit();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Elementos_Disponibles).EndInit();
                        GroupBox_Atributos.ResumeLayout(false);
                        GroupBox_Atributos.PerformLayout();
                        GroupBox_Seleccionar_Remate.ResumeLayout(false);
                        GroupBox_Seleccionar_Remate.PerformLayout();
                        GroupBox_Controles.ResumeLayout(false);
                        ResumeLayout(false);
                }

                #endregion

                private GroupBox GroupBox_Grillas;
                private Button Button_Izquierda;
                private Button Button_Derecha;
                private Label Label_Seleccion_Elementos_Subasta;
                private Label Label_Elementos_Subasta;
                private GroupBox GroupBox_Atributos;
                private Panel panel1;
                private Label Label_Inicio;
                private DateTimePicker TimePicker_Hora_Momento;
                private MonthCalendar Calendar_Momento;
                private Label Label_Momento_Fin;
                private DateTimePicker TimePicker_Fin;
                private MonthCalendar Calendario_Fin;
                private ComboBox DropDownList_Seleccion_Momento;
                private ComboBox DropDownList_Tipo;
                private TextBox TextBox_ID;
                private Button Button_Ir_A_ID;
                private Label Label_Hora;
                private Label Label_Dia;
                private Label Label_Opciones;
                private Label Label_Categoria;
                private GroupBox GroupBox_Seleccionar_Remate;
                private Button Button_Seleccionar_Por_Elemento;
                private Label Label_ID_Remate_Actual;
                private CheckBox CheckBox_Permitir_Fechas_Pasadas;
                private Label Label_Metodo_Pago;
                private ComboBox DropDownList_Metodo_Pago;
                private GroupBox GroupBox_Controles;
                private Button Button_Eliminar;
                private Button Button_Modificar;
                private Button Button_Crear;
                private DataGridView Grilla_Integrantes_Remate;
                private DataGridView Grilla_Elementos_Disponibles;
        }
}