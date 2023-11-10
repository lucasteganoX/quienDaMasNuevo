namespace Presentacion.Gestion_Productos
{
        partial class Gestion_Productos
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
                        GroupBox_Controles = new GroupBox();
                        Button_Eliminar = new Button();
                        Button_Modificar = new Button();
                        Button_Guardar = new Button();
                        GroupBox_Atributos_Producto = new GroupBox();
                        CheckBox_Habilitado = new CheckBox();
                        Label_Habilitado = new Label();
                        NumericUpDown_Precio_Base = new NumericUpDown();
                        Label_Precio_Base = new Label();
                        DropDownList_Tipado = new ComboBox();
                        Button_Editar = new Button();
                        Label_Tipado = new Label();
                        TextBox_Descripcion = new TextBox();
                        Label_Descripcion = new Label();
                        Button_Quitar_Fotos = new Button();
                        Button_Seleccionar = new Button();
                        Button_Ver_Fotos = new Button();
                        Label_Fotos = new Label();
                        NumericUpDown_Valor = new NumericUpDown();
                        Label_Valor = new Label();
                        TextBox_Nombre = new TextBox();
                        Label_Nombre = new Label();
                        GroupBox_Productos_En_El_Sistema = new GroupBox();
                        Label_Modo_Admin = new Label();
                        DropDownList_Filtro_Busqueda = new ComboBox();
                        TextBox_Buscar = new TextBox();
                        Grilla_Productos = new DataGridView();
                        GroupBox_Controles.SuspendLayout();
                        GroupBox_Atributos_Producto.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Precio_Base).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Valor).BeginInit();
                        GroupBox_Productos_En_El_Sistema.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos).BeginInit();
                        SuspendLayout();
                        // 
                        // GroupBox_Controles
                        // 
                        GroupBox_Controles.Controls.Add(Button_Eliminar);
                        GroupBox_Controles.Controls.Add(Button_Modificar);
                        GroupBox_Controles.Controls.Add(Button_Guardar);
                        GroupBox_Controles.FlatStyle = FlatStyle.Flat;
                        GroupBox_Controles.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Controles.Location = new Point(493, 425);
                        GroupBox_Controles.Name = "GroupBox_Controles";
                        GroupBox_Controles.Size = new Size(460, 191);
                        GroupBox_Controles.TabIndex = 5;
                        GroupBox_Controles.TabStop = false;
                        GroupBox_Controles.Text = "Controles";
                        // 
                        // Button_Eliminar
                        // 
                        Button_Eliminar.BackColor = Color.FromArgb(192, 0, 0);
                        Button_Eliminar.Enabled = false;
                        Button_Eliminar.FlatAppearance.BorderColor = Color.Maroon;
                        Button_Eliminar.FlatAppearance.BorderSize = 3;
                        Button_Eliminar.FlatStyle = FlatStyle.Flat;
                        Button_Eliminar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Eliminar.ForeColor = Color.Silver;
                        Button_Eliminar.Location = new Point(70, 127);
                        Button_Eliminar.Name = "Button_Eliminar";
                        Button_Eliminar.Size = new Size(198, 35);
                        Button_Eliminar.TabIndex = 5;
                        Button_Eliminar.Text = "Eliminar";
                        Button_Eliminar.UseVisualStyleBackColor = false;
                        Button_Eliminar.Click += Button_Eliminar_Click;
                        // 
                        // Button_Modificar
                        // 
                        Button_Modificar.BackColor = Color.Gold;
                        Button_Modificar.Enabled = false;
                        Button_Modificar.FlatAppearance.BorderColor = Color.Goldenrod;
                        Button_Modificar.FlatAppearance.BorderSize = 3;
                        Button_Modificar.FlatStyle = FlatStyle.Flat;
                        Button_Modificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Modificar.ForeColor = SystemColors.ActiveCaptionText;
                        Button_Modificar.Location = new Point(70, 86);
                        Button_Modificar.Name = "Button_Modificar";
                        Button_Modificar.Size = new Size(198, 35);
                        Button_Modificar.TabIndex = 4;
                        Button_Modificar.Text = "Modificar";
                        Button_Modificar.UseVisualStyleBackColor = false;
                        Button_Modificar.Click += Button_Modificar_Click;
                        // 
                        // Button_Guardar
                        // 
                        Button_Guardar.BackColor = Color.ForestGreen;
                        Button_Guardar.FlatAppearance.BorderColor = Color.YellowGreen;
                        Button_Guardar.FlatAppearance.BorderSize = 3;
                        Button_Guardar.FlatStyle = FlatStyle.Flat;
                        Button_Guardar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Guardar.ForeColor = SystemColors.Control;
                        Button_Guardar.Location = new Point(70, 45);
                        Button_Guardar.Name = "Button_Guardar";
                        Button_Guardar.Size = new Size(198, 35);
                        Button_Guardar.TabIndex = 3;
                        Button_Guardar.Text = "Guardar";
                        Button_Guardar.UseVisualStyleBackColor = false;
                        Button_Guardar.Click += Button_Guardar_Click;
                        // 
                        // GroupBox_Atributos_Producto
                        // 
                        GroupBox_Atributos_Producto.Controls.Add(CheckBox_Habilitado);
                        GroupBox_Atributos_Producto.Controls.Add(Label_Habilitado);
                        GroupBox_Atributos_Producto.Controls.Add(NumericUpDown_Precio_Base);
                        GroupBox_Atributos_Producto.Controls.Add(Label_Precio_Base);
                        GroupBox_Atributos_Producto.Controls.Add(DropDownList_Tipado);
                        GroupBox_Atributos_Producto.Controls.Add(Button_Editar);
                        GroupBox_Atributos_Producto.Controls.Add(Label_Tipado);
                        GroupBox_Atributos_Producto.Controls.Add(TextBox_Descripcion);
                        GroupBox_Atributos_Producto.Controls.Add(Label_Descripcion);
                        GroupBox_Atributos_Producto.Controls.Add(Button_Quitar_Fotos);
                        GroupBox_Atributos_Producto.Controls.Add(Button_Seleccionar);
                        GroupBox_Atributos_Producto.Controls.Add(Button_Ver_Fotos);
                        GroupBox_Atributos_Producto.Controls.Add(Label_Fotos);
                        GroupBox_Atributos_Producto.Controls.Add(NumericUpDown_Valor);
                        GroupBox_Atributos_Producto.Controls.Add(Label_Valor);
                        GroupBox_Atributos_Producto.Controls.Add(TextBox_Nombre);
                        GroupBox_Atributos_Producto.Controls.Add(Label_Nombre);
                        GroupBox_Atributos_Producto.FlatStyle = FlatStyle.Flat;
                        GroupBox_Atributos_Producto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Atributos_Producto.Location = new Point(493, 10);
                        GroupBox_Atributos_Producto.Name = "GroupBox_Atributos_Producto";
                        GroupBox_Atributos_Producto.Size = new Size(460, 413);
                        GroupBox_Atributos_Producto.TabIndex = 4;
                        GroupBox_Atributos_Producto.TabStop = false;
                        GroupBox_Atributos_Producto.Text = "Atributos del producto";
                        // 
                        // CheckBox_Habilitado
                        // 
                        CheckBox_Habilitado.AutoSize = true;
                        CheckBox_Habilitado.Location = new Point(331, 201);
                        CheckBox_Habilitado.Name = "CheckBox_Habilitado";
                        CheckBox_Habilitado.Size = new Size(18, 17);
                        CheckBox_Habilitado.TabIndex = 7;
                        CheckBox_Habilitado.UseVisualStyleBackColor = true;
                        // 
                        // Label_Habilitado
                        // 
                        Label_Habilitado.AutoSize = true;
                        Label_Habilitado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Habilitado.Location = new Point(245, 201);
                        Label_Habilitado.Name = "Label_Habilitado";
                        Label_Habilitado.Size = new Size(80, 20);
                        Label_Habilitado.TabIndex = 15;
                        Label_Habilitado.Text = "Habilitado";
                        // 
                        // NumericUpDown_Precio_Base
                        // 
                        NumericUpDown_Precio_Base.BorderStyle = BorderStyle.FixedSingle;
                        NumericUpDown_Precio_Base.Cursor = Cursors.IBeam;
                        NumericUpDown_Precio_Base.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        NumericUpDown_Precio_Base.Location = new Point(28, 224);
                        NumericUpDown_Precio_Base.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
                        NumericUpDown_Precio_Base.Name = "NumericUpDown_Precio_Base";
                        NumericUpDown_Precio_Base.Size = new Size(125, 27);
                        NumericUpDown_Precio_Base.TabIndex = 6;
                        // 
                        // Label_Precio_Base
                        // 
                        Label_Precio_Base.AutoSize = true;
                        Label_Precio_Base.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Precio_Base.Location = new Point(27, 201);
                        Label_Precio_Base.Name = "Label_Precio_Base";
                        Label_Precio_Base.Size = new Size(127, 20);
                        Label_Precio_Base.TabIndex = 13;
                        Label_Precio_Base.Text = "Precio Base(U$D)";
                        // 
                        // DropDownList_Tipado
                        // 
                        DropDownList_Tipado.AutoCompleteCustomSource.AddRange(new string[] { "Ninguno", "Animal", "Maquinaria" });
                        DropDownList_Tipado.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Tipado.FlatStyle = FlatStyle.Flat;
                        DropDownList_Tipado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Tipado.FormattingEnabled = true;
                        DropDownList_Tipado.Items.AddRange(new object[] { "Ninguno", "Animal", "Maquinaria" });
                        DropDownList_Tipado.Location = new Point(245, 304);
                        DropDownList_Tipado.Name = "DropDownList_Tipado";
                        DropDownList_Tipado.Size = new Size(151, 28);
                        DropDownList_Tipado.TabIndex = 11;
                        DropDownList_Tipado.SelectedIndexChanged += DropDownList_Tipado_SelectedIndexChanged;
                        // 
                        // Button_Editar
                        // 
                        Button_Editar.Cursor = Cursors.Hand;
                        Button_Editar.Enabled = false;
                        Button_Editar.FlatStyle = FlatStyle.Flat;
                        Button_Editar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        Button_Editar.Location = new Point(245, 344);
                        Button_Editar.Name = "Button_Editar";
                        Button_Editar.Size = new Size(95, 29);
                        Button_Editar.TabIndex = 12;
                        Button_Editar.Text = "Editar";
                        Button_Editar.UseVisualStyleBackColor = true;
                        Button_Editar.Click += Button_Editar_Click;
                        // 
                        // Label_Tipado
                        // 
                        Label_Tipado.AutoSize = true;
                        Label_Tipado.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Tipado.Location = new Point(245, 278);
                        Label_Tipado.Name = "Label_Tipado";
                        Label_Tipado.Size = new Size(62, 23);
                        Label_Tipado.TabIndex = 10;
                        Label_Tipado.Text = "Tipado";
                        // 
                        // TextBox_Descripcion
                        // 
                        TextBox_Descripcion.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Descripcion.Cursor = Cursors.IBeam;
                        TextBox_Descripcion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Descripcion.Location = new Point(177, 75);
                        TextBox_Descripcion.MaxLength = 500;
                        TextBox_Descripcion.Multiline = true;
                        TextBox_Descripcion.Name = "TextBox_Descripcion";
                        TextBox_Descripcion.Size = new Size(248, 102);
                        TextBox_Descripcion.TabIndex = 4;
                        // 
                        // Label_Descripcion
                        // 
                        Label_Descripcion.AutoSize = true;
                        Label_Descripcion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Descripcion.Location = new Point(177, 49);
                        Label_Descripcion.Name = "Label_Descripcion";
                        Label_Descripcion.Size = new Size(248, 20);
                        Label_Descripcion.TabIndex = 8;
                        Label_Descripcion.Text = "Descripcion(informacion adicional)";
                        // 
                        // Button_Quitar_Fotos
                        // 
                        Button_Quitar_Fotos.Cursor = Cursors.Hand;
                        Button_Quitar_Fotos.Enabled = false;
                        Button_Quitar_Fotos.FlatStyle = FlatStyle.Flat;
                        Button_Quitar_Fotos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        Button_Quitar_Fotos.Location = new Point(29, 344);
                        Button_Quitar_Fotos.Name = "Button_Quitar_Fotos";
                        Button_Quitar_Fotos.Size = new Size(88, 29);
                        Button_Quitar_Fotos.TabIndex = 10;
                        Button_Quitar_Fotos.Text = "Quitar";
                        Button_Quitar_Fotos.UseVisualStyleBackColor = true;
                        Button_Quitar_Fotos.Click += Button_Quitar_Click;
                        // 
                        // Button_Seleccionar
                        // 
                        Button_Seleccionar.Cursor = Cursors.Hand;
                        Button_Seleccionar.FlatStyle = FlatStyle.Flat;
                        Button_Seleccionar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        Button_Seleccionar.Location = new Point(97, 309);
                        Button_Seleccionar.Name = "Button_Seleccionar";
                        Button_Seleccionar.Size = new Size(103, 29);
                        Button_Seleccionar.TabIndex = 9;
                        Button_Seleccionar.Text = "Seleccionar";
                        Button_Seleccionar.UseVisualStyleBackColor = true;
                        Button_Seleccionar.Click += Button_Seleccionar_Click;
                        // 
                        // Button_Ver_Fotos
                        // 
                        Button_Ver_Fotos.Cursor = Cursors.Hand;
                        Button_Ver_Fotos.Enabled = false;
                        Button_Ver_Fotos.FlatStyle = FlatStyle.Flat;
                        Button_Ver_Fotos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        Button_Ver_Fotos.Location = new Point(29, 309);
                        Button_Ver_Fotos.Name = "Button_Ver_Fotos";
                        Button_Ver_Fotos.Size = new Size(62, 29);
                        Button_Ver_Fotos.TabIndex = 8;
                        Button_Ver_Fotos.Text = "Ver";
                        Button_Ver_Fotos.UseVisualStyleBackColor = true;
                        Button_Ver_Fotos.Click += Button_Ver_Fotos_Click;
                        // 
                        // Label_Fotos
                        // 
                        Label_Fotos.AutoSize = true;
                        Label_Fotos.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Fotos.Location = new Point(25, 278);
                        Label_Fotos.Name = "Label_Fotos";
                        Label_Fotos.Size = new Size(52, 23);
                        Label_Fotos.TabIndex = 4;
                        Label_Fotos.Text = "Fotos";
                        // 
                        // NumericUpDown_Valor
                        // 
                        NumericUpDown_Valor.BorderStyle = BorderStyle.FixedSingle;
                        NumericUpDown_Valor.Cursor = Cursors.IBeam;
                        NumericUpDown_Valor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        NumericUpDown_Valor.Location = new Point(29, 150);
                        NumericUpDown_Valor.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
                        NumericUpDown_Valor.Name = "NumericUpDown_Valor";
                        NumericUpDown_Valor.Size = new Size(125, 27);
                        NumericUpDown_Valor.TabIndex = 5;
                        // 
                        // Label_Valor
                        // 
                        Label_Valor.AutoSize = true;
                        Label_Valor.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Valor.Location = new Point(29, 127);
                        Label_Valor.Name = "Label_Valor";
                        Label_Valor.Size = new Size(91, 20);
                        Label_Valor.TabIndex = 2;
                        Label_Valor.Text = "Valor(U$Ds)";
                        // 
                        // TextBox_Nombre
                        // 
                        TextBox_Nombre.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre.Cursor = Cursors.IBeam;
                        TextBox_Nombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Nombre.Location = new Point(28, 75);
                        TextBox_Nombre.MaxLength = 20;
                        TextBox_Nombre.Name = "TextBox_Nombre";
                        TextBox_Nombre.Size = new Size(125, 27);
                        TextBox_Nombre.TabIndex = 3;
                        // 
                        // Label_Nombre
                        // 
                        Label_Nombre.AutoSize = true;
                        Label_Nombre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nombre.Location = new Point(28, 49);
                        Label_Nombre.Name = "Label_Nombre";
                        Label_Nombre.Size = new Size(66, 20);
                        Label_Nombre.TabIndex = 0;
                        Label_Nombre.Text = "Nombre";
                        // 
                        // GroupBox_Productos_En_El_Sistema
                        // 
                        GroupBox_Productos_En_El_Sistema.Controls.Add(Label_Modo_Admin);
                        GroupBox_Productos_En_El_Sistema.Controls.Add(DropDownList_Filtro_Busqueda);
                        GroupBox_Productos_En_El_Sistema.Controls.Add(TextBox_Buscar);
                        GroupBox_Productos_En_El_Sistema.Controls.Add(Grilla_Productos);
                        GroupBox_Productos_En_El_Sistema.FlatStyle = FlatStyle.Flat;
                        GroupBox_Productos_En_El_Sistema.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Productos_En_El_Sistema.Location = new Point(12, 10);
                        GroupBox_Productos_En_El_Sistema.Name = "GroupBox_Productos_En_El_Sistema";
                        GroupBox_Productos_En_El_Sistema.Size = new Size(475, 606);
                        GroupBox_Productos_En_El_Sistema.TabIndex = 3;
                        GroupBox_Productos_En_El_Sistema.TabStop = false;
                        GroupBox_Productos_En_El_Sistema.Text = "Productos en el sistema || Tus Productos libres";
                        // 
                        // Label_Modo_Admin
                        // 
                        Label_Modo_Admin.AutoSize = true;
                        Label_Modo_Admin.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Modo_Admin.ForeColor = Color.Green;
                        Label_Modo_Admin.Location = new Point(23, 580);
                        Label_Modo_Admin.Margin = new Padding(0);
                        Label_Modo_Admin.Name = "Label_Modo_Admin";
                        Label_Modo_Admin.Size = new Size(200, 17);
                        Label_Modo_Admin.TabIndex = 6;
                        Label_Modo_Admin.Text = "Modo Administrador: Activado";
                        // 
                        // DropDownList_Filtro_Busqueda
                        // 
                        DropDownList_Filtro_Busqueda.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Filtro_Busqueda.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        DropDownList_Filtro_Busqueda.FormattingEnabled = true;
                        DropDownList_Filtro_Busqueda.Items.AddRange(new object[] { "ID", "Nombre" });
                        DropDownList_Filtro_Busqueda.Location = new Point(295, 39);
                        DropDownList_Filtro_Busqueda.Name = "DropDownList_Filtro_Busqueda";
                        DropDownList_Filtro_Busqueda.Size = new Size(151, 31);
                        DropDownList_Filtro_Busqueda.TabIndex = 2;
                        DropDownList_Filtro_Busqueda.SelectedIndexChanged += DropDownList_Filtro_Busqueda_SelectedIndexChanged;
                        // 
                        // TextBox_Buscar
                        // 
                        TextBox_Buscar.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
                        TextBox_Buscar.Location = new Point(23, 39);
                        TextBox_Buscar.Name = "TextBox_Buscar";
                        TextBox_Buscar.Size = new Size(266, 30);
                        TextBox_Buscar.TabIndex = 1;
                        TextBox_Buscar.KeyPress += TextBox_Buscar_KeyPress;
                        TextBox_Buscar.Leave += TextBox_Buscar_Leave;
                        // 
                        // Grilla_Productos
                        // 
                        Grilla_Productos.AllowUserToAddRows = false;
                        Grilla_Productos.AllowUserToDeleteRows = false;
                        Grilla_Productos.AllowUserToOrderColumns = true;
                        Grilla_Productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Productos.Location = new Point(23, 76);
                        Grilla_Productos.MultiSelect = false;
                        Grilla_Productos.Name = "Grilla_Productos";
                        Grilla_Productos.ReadOnly = true;
                        Grilla_Productos.RowHeadersWidth = 51;
                        Grilla_Productos.RowTemplate.Height = 29;
                        Grilla_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Productos.Size = new Size(423, 501);
                        Grilla_Productos.TabIndex = 0;
                        Grilla_Productos.SelectionChanged += Grilla_Productos_SelectionChanged;
                        // 
                        // Gestion_Productos
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(965, 626);
                        Controls.Add(GroupBox_Controles);
                        Controls.Add(GroupBox_Atributos_Producto);
                        Controls.Add(GroupBox_Productos_En_El_Sistema);
                        FormBorderStyle = FormBorderStyle.FixedSingle;
                        MaximizeBox = false;
                        Name = "Gestion_Productos";
                        Text = "Quien Da Más?: Gestión de Productos";
                        Load += Gestion_Productos_Load;
                        GroupBox_Controles.ResumeLayout(false);
                        GroupBox_Atributos_Producto.ResumeLayout(false);
                        GroupBox_Atributos_Producto.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Precio_Base).EndInit();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Valor).EndInit();
                        GroupBox_Productos_En_El_Sistema.ResumeLayout(false);
                        GroupBox_Productos_En_El_Sistema.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos).EndInit();
                        ResumeLayout(false);
                }

                #endregion

                private GroupBox GroupBox_Controles;
                private Button Button_Eliminar;
                private Button Button_Modificar;
                private Button Button_Guardar;
                private GroupBox GroupBox_Atributos_Producto;
                private NumericUpDown NumericUpDown_Precio_Base;
                private Label Label_Precio_Base;
                private ComboBox DropDownList_Tipado;
                private Button Button_Editar;
                private Label Label_Tipado;
                private TextBox TextBox_Descripcion;
                private Label Label_Descripcion;
                private Button Button_Quitar_Fotos;
                private Button Button_Seleccionar;
                private Button Button_Ver_Fotos;
                private Label Label_Fotos;
                private NumericUpDown NumericUpDown_Valor;
                private Label Label_Valor;
                private TextBox TextBox_Nombre;
                private Label Label_Nombre;
                private GroupBox GroupBox_Productos_En_El_Sistema;
                private ComboBox DropDownList_Filtro_Busqueda;
                private TextBox TextBox_Buscar;
                private DataGridView Grilla_Productos;
                private Label Label_Habilitado;
                private CheckBox CheckBox_Habilitado;
                private Label Label_Modo_Admin;
        }
}