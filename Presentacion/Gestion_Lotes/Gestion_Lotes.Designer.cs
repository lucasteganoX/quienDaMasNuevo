namespace Presentacion.Gestion_Lotes
{
        partial class Gestion_Lotes
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
                        GroupBox_Seleccion_Productos = new GroupBox();
                        Grilla_Productos_Seleccionados = new DataGridView();
                        Grilla_Productos_Libres = new DataGridView();
                        Label_ID_Lote_Actual = new Label();
                        Button_Izquierda = new Button();
                        Button_Derecha = new Button();
                        Label_Seleccion_Productos = new Label();
                        Label_Productos_Libres = new Label();
                        CheckBox_Habilitado = new CheckBox();
                        Label_Habilitado = new Label();
                        GroupBox_Seleccion = new GroupBox();
                        Button_Ir_A_ID = new Button();
                        Button_Buscar_Por_Producto = new Button();
                        TextBox_ID_Lote = new TextBox();
                        GroupBox_Controles = new GroupBox();
                        Button_Eliminar = new Button();
                        Button_Modificar = new Button();
                        Button_Crear = new Button();
                        GroupBox_Atributos_Lote = new GroupBox();
                        DropDownList_Categoria = new ComboBox();
                        Label_Categoria = new Label();
                        NumericUpDown_Precio_Base = new NumericUpDown();
                        Label_Precio_Base = new Label();
                        NumericUpDown_Valor = new NumericUpDown();
                        Label_Valor = new Label();
                        GroupBox_Seleccion_Productos.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos_Seleccionados).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos_Libres).BeginInit();
                        GroupBox_Seleccion.SuspendLayout();
                        GroupBox_Controles.SuspendLayout();
                        GroupBox_Atributos_Lote.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Precio_Base).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Valor).BeginInit();
                        SuspendLayout();
                        // 
                        // GroupBox_Seleccion_Productos
                        // 
                        GroupBox_Seleccion_Productos.Controls.Add(Grilla_Productos_Seleccionados);
                        GroupBox_Seleccion_Productos.Controls.Add(Grilla_Productos_Libres);
                        GroupBox_Seleccion_Productos.Controls.Add(Label_ID_Lote_Actual);
                        GroupBox_Seleccion_Productos.Controls.Add(Button_Izquierda);
                        GroupBox_Seleccion_Productos.Controls.Add(Button_Derecha);
                        GroupBox_Seleccion_Productos.Controls.Add(Label_Seleccion_Productos);
                        GroupBox_Seleccion_Productos.Controls.Add(Label_Productos_Libres);
                        GroupBox_Seleccion_Productos.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Seleccion_Productos.Location = new Point(12, 12);
                        GroupBox_Seleccion_Productos.Name = "GroupBox_Seleccion_Productos";
                        GroupBox_Seleccion_Productos.Size = new Size(1046, 598);
                        GroupBox_Seleccion_Productos.TabIndex = 1;
                        GroupBox_Seleccion_Productos.TabStop = false;
                        GroupBox_Seleccion_Productos.Text = "Seleccion de Productos del Lote";
                        // 
                        // Grilla_Productos_Seleccionados
                        // 
                        Grilla_Productos_Seleccionados.AllowUserToAddRows = false;
                        Grilla_Productos_Seleccionados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Productos_Seleccionados.Location = new Point(613, 67);
                        Grilla_Productos_Seleccionados.Name = "Grilla_Productos_Seleccionados";
                        Grilla_Productos_Seleccionados.ReadOnly = true;
                        Grilla_Productos_Seleccionados.RowHeadersWidth = 51;
                        Grilla_Productos_Seleccionados.RowTemplate.Height = 29;
                        Grilla_Productos_Seleccionados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Productos_Seleccionados.Size = new Size(409, 491);
                        Grilla_Productos_Seleccionados.TabIndex = 9;
                        Grilla_Productos_Seleccionados.SelectionChanged += Grilla_Derecha_SelectionChanged;
                        Grilla_Productos_Seleccionados.MouseDoubleClick += Grilla_Productos_Seleccionados_MouseDoubleClick;
                        // 
                        // Grilla_Productos_Libres
                        // 
                        Grilla_Productos_Libres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Productos_Libres.Location = new Point(22, 67);
                        Grilla_Productos_Libres.Name = "Grilla_Productos_Libres";
                        Grilla_Productos_Libres.ReadOnly = true;
                        Grilla_Productos_Libres.RowHeadersWidth = 51;
                        Grilla_Productos_Libres.RowTemplate.Height = 29;
                        Grilla_Productos_Libres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Productos_Libres.Size = new Size(481, 491);
                        Grilla_Productos_Libres.TabIndex = 8;
                        Grilla_Productos_Libres.SelectionChanged += Grilla_Izquierda_SelectionChanged;
                        Grilla_Productos_Libres.MouseDoubleClick += Grilla_Derecha_MouseDoubleClick;
                        // 
                        // Label_ID_Lote_Actual
                        // 
                        Label_ID_Lote_Actual.AutoSize = true;
                        Label_ID_Lote_Actual.BackColor = SystemColors.AppWorkspace;
                        Label_ID_Lote_Actual.Enabled = false;
                        Label_ID_Lote_Actual.Font = new Font("Segoe UI Semilight", 7.20000029F, FontStyle.Italic, GraphicsUnit.Point);
                        Label_ID_Lote_Actual.ForeColor = SystemColors.ControlDarkDark;
                        Label_ID_Lote_Actual.Location = new Point(613, 561);
                        Label_ID_Lote_Actual.Name = "Label_ID_Lote_Actual";
                        Label_ID_Lote_Actual.Size = new Size(212, 17);
                        Label_ID_Lote_Actual.TabIndex = 7;
                        Label_ID_Lote_Actual.Text = "ID del Lote actual = @ID_Lote_Actual";
                        // 
                        // Button_Izquierda
                        // 
                        Button_Izquierda.Cursor = Cursors.Hand;
                        Button_Izquierda.Enabled = false;
                        Button_Izquierda.FlatStyle = FlatStyle.Popup;
                        Button_Izquierda.Location = new Point(534, 291);
                        Button_Izquierda.Name = "Button_Izquierda";
                        Button_Izquierda.Size = new Size(51, 67);
                        Button_Izquierda.TabIndex = 5;
                        Button_Izquierda.Text = "◄";
                        Button_Izquierda.UseVisualStyleBackColor = true;
                        Button_Izquierda.Click += Button_Izquierda_Click;
                        // 
                        // Button_Derecha
                        // 
                        Button_Derecha.Cursor = Cursors.Hand;
                        Button_Derecha.Enabled = false;
                        Button_Derecha.FlatStyle = FlatStyle.Popup;
                        Button_Derecha.Location = new Point(534, 195);
                        Button_Derecha.Name = "Button_Derecha";
                        Button_Derecha.Size = new Size(51, 67);
                        Button_Derecha.TabIndex = 4;
                        Button_Derecha.Text = "►";
                        Button_Derecha.UseVisualStyleBackColor = true;
                        Button_Derecha.Click += Button_Derecha_Click;
                        // 
                        // Label_Seleccion_Productos
                        // 
                        Label_Seleccion_Productos.AutoSize = true;
                        Label_Seleccion_Productos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Seleccion_Productos.Location = new Point(871, 41);
                        Label_Seleccion_Productos.Name = "Label_Seleccion_Productos";
                        Label_Seleccion_Productos.RightToLeft = RightToLeft.Yes;
                        Label_Seleccion_Productos.Size = new Size(163, 23);
                        Label_Seleccion_Productos.TabIndex = 3;
                        Label_Seleccion_Productos.Text = "Integrantes del Lote";
                        // 
                        // Label_Productos_Libres
                        // 
                        Label_Productos_Libres.AutoSize = true;
                        Label_Productos_Libres.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Productos_Libres.Location = new Point(22, 41);
                        Label_Productos_Libres.Name = "Label_Productos_Libres";
                        Label_Productos_Libres.Size = new Size(136, 23);
                        Label_Productos_Libres.TabIndex = 1;
                        Label_Productos_Libres.Text = "Productos Libres";
                        // 
                        // CheckBox_Habilitado
                        // 
                        CheckBox_Habilitado.AutoSize = true;
                        CheckBox_Habilitado.Location = new Point(957, 54);
                        CheckBox_Habilitado.Name = "CheckBox_Habilitado";
                        CheckBox_Habilitado.Size = new Size(18, 17);
                        CheckBox_Habilitado.TabIndex = 8;
                        CheckBox_Habilitado.UseVisualStyleBackColor = true;
                        // 
                        // Label_Habilitado
                        // 
                        Label_Habilitado.AutoSize = true;
                        Label_Habilitado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Habilitado.Location = new Point(871, 51);
                        Label_Habilitado.Name = "Label_Habilitado";
                        Label_Habilitado.Size = new Size(80, 20);
                        Label_Habilitado.TabIndex = 8;
                        Label_Habilitado.Text = "Habilitado";
                        // 
                        // GroupBox_Seleccion
                        // 
                        GroupBox_Seleccion.Controls.Add(Button_Ir_A_ID);
                        GroupBox_Seleccion.Controls.Add(Button_Buscar_Por_Producto);
                        GroupBox_Seleccion.Controls.Add(TextBox_ID_Lote);
                        GroupBox_Seleccion.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Seleccion.Location = new Point(12, 764);
                        GroupBox_Seleccion.Name = "GroupBox_Seleccion";
                        GroupBox_Seleccion.Size = new Size(614, 151);
                        GroupBox_Seleccion.TabIndex = 2;
                        GroupBox_Seleccion.TabStop = false;
                        GroupBox_Seleccion.Text = "Seleccion del Lote";
                        // 
                        // Button_Ir_A_ID
                        // 
                        Button_Ir_A_ID.Cursor = Cursors.Hand;
                        Button_Ir_A_ID.FlatAppearance.BorderColor = Color.Silver;
                        Button_Ir_A_ID.FlatStyle = FlatStyle.Flat;
                        Button_Ir_A_ID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Ir_A_ID.Location = new Point(66, 46);
                        Button_Ir_A_ID.Name = "Button_Ir_A_ID";
                        Button_Ir_A_ID.Size = new Size(331, 40);
                        Button_Ir_A_ID.TabIndex = 2;
                        Button_Ir_A_ID.Text = "Editar Lote por ID";
                        Button_Ir_A_ID.UseVisualStyleBackColor = true;
                        Button_Ir_A_ID.Click += Button_Ir_A_ID_Click;
                        // 
                        // Button_Buscar_Por_Producto
                        // 
                        Button_Buscar_Por_Producto.Cursor = Cursors.Hand;
                        Button_Buscar_Por_Producto.FlatAppearance.BorderColor = Color.Silver;
                        Button_Buscar_Por_Producto.FlatStyle = FlatStyle.Flat;
                        Button_Buscar_Por_Producto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Buscar_Por_Producto.Location = new Point(66, 98);
                        Button_Buscar_Por_Producto.Name = "Button_Buscar_Por_Producto";
                        Button_Buscar_Por_Producto.Size = new Size(331, 40);
                        Button_Buscar_Por_Producto.TabIndex = 3;
                        Button_Buscar_Por_Producto.Text = "Buscar por Producto";
                        Button_Buscar_Por_Producto.UseVisualStyleBackColor = true;
                        Button_Buscar_Por_Producto.Click += Buscar_Por_Producto_Click;
                        // 
                        // TextBox_ID_Lote
                        // 
                        TextBox_ID_Lote.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_ID_Lote.Cursor = Cursors.IBeam;
                        TextBox_ID_Lote.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                        TextBox_ID_Lote.Location = new Point(430, 46);
                        TextBox_ID_Lote.MaxLength = 10;
                        TextBox_ID_Lote.Name = "TextBox_ID_Lote";
                        TextBox_ID_Lote.PlaceholderText = "ID del Lote";
                        TextBox_ID_Lote.Size = new Size(155, 28);
                        TextBox_ID_Lote.TabIndex = 1;
                        TextBox_ID_Lote.TextChanged += TextBox_ID_Lote_TextChanged;
                        TextBox_ID_Lote.KeyPress += TextBox_ID_Lote_KeyPress;
                        // 
                        // GroupBox_Controles
                        // 
                        GroupBox_Controles.Controls.Add(Button_Eliminar);
                        GroupBox_Controles.Controls.Add(Button_Modificar);
                        GroupBox_Controles.Controls.Add(Button_Crear);
                        GroupBox_Controles.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Controles.Location = new Point(632, 764);
                        GroupBox_Controles.Name = "GroupBox_Controles";
                        GroupBox_Controles.Size = new Size(426, 151);
                        GroupBox_Controles.TabIndex = 3;
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
                        Button_Eliminar.Location = new Point(116, 103);
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
                        Button_Modificar.Location = new Point(116, 62);
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
                        Button_Crear.Location = new Point(116, 21);
                        Button_Crear.Name = "Button_Crear";
                        Button_Crear.Size = new Size(198, 35);
                        Button_Crear.TabIndex = 9;
                        Button_Crear.Text = "Crear";
                        Button_Crear.UseVisualStyleBackColor = false;
                        Button_Crear.Click += Button_Guardar_Click;
                        // 
                        // GroupBox_Atributos_Lote
                        // 
                        GroupBox_Atributos_Lote.Controls.Add(DropDownList_Categoria);
                        GroupBox_Atributos_Lote.Controls.Add(Label_Categoria);
                        GroupBox_Atributos_Lote.Controls.Add(CheckBox_Habilitado);
                        GroupBox_Atributos_Lote.Controls.Add(NumericUpDown_Precio_Base);
                        GroupBox_Atributos_Lote.Controls.Add(Label_Habilitado);
                        GroupBox_Atributos_Lote.Controls.Add(Label_Precio_Base);
                        GroupBox_Atributos_Lote.Controls.Add(NumericUpDown_Valor);
                        GroupBox_Atributos_Lote.Controls.Add(Label_Valor);
                        GroupBox_Atributos_Lote.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        GroupBox_Atributos_Lote.Location = new Point(12, 616);
                        GroupBox_Atributos_Lote.Name = "GroupBox_Atributos_Lote";
                        GroupBox_Atributos_Lote.Size = new Size(1046, 142);
                        GroupBox_Atributos_Lote.TabIndex = 4;
                        GroupBox_Atributos_Lote.TabStop = false;
                        GroupBox_Atributos_Lote.Text = "Atributos del Lote";
                        // 
                        // DropDownList_Categoria
                        // 
                        DropDownList_Categoria.Cursor = Cursors.IBeam;
                        DropDownList_Categoria.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Categoria.FlatStyle = FlatStyle.Flat;
                        DropDownList_Categoria.FormattingEnabled = true;
                        DropDownList_Categoria.Items.AddRange(new object[] { "Ninguna", "Animales", "Maquinaria" });
                        DropDownList_Categoria.Location = new Point(613, 65);
                        DropDownList_Categoria.Name = "DropDownList_Categoria";
                        DropDownList_Categoria.Size = new Size(151, 31);
                        DropDownList_Categoria.TabIndex = 11;
                        DropDownList_Categoria.SelectedIndexChanged += DropDownList_Categoria_SelectedIndexChanged;
                        // 
                        // Label_Categoria
                        // 
                        Label_Categoria.AutoSize = true;
                        Label_Categoria.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Categoria.Location = new Point(613, 42);
                        Label_Categoria.Name = "Label_Categoria";
                        Label_Categoria.Size = new Size(75, 20);
                        Label_Categoria.TabIndex = 10;
                        Label_Categoria.Text = "Categoria";
                        // 
                        // NumericUpDown_Precio_Base
                        // 
                        NumericUpDown_Precio_Base.BorderStyle = BorderStyle.FixedSingle;
                        NumericUpDown_Precio_Base.Cursor = Cursors.IBeam;
                        NumericUpDown_Precio_Base.Location = new Point(353, 74);
                        NumericUpDown_Precio_Base.Maximum = new decimal(new int[] { int.MinValue, 0, 0, 0 });
                        NumericUpDown_Precio_Base.Name = "NumericUpDown_Precio_Base";
                        NumericUpDown_Precio_Base.Size = new Size(150, 30);
                        NumericUpDown_Precio_Base.TabIndex = 7;
                        // 
                        // Label_Precio_Base
                        // 
                        Label_Precio_Base.AutoSize = true;
                        Label_Precio_Base.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Precio_Base.Location = new Point(353, 51);
                        Label_Precio_Base.Name = "Label_Precio_Base";
                        Label_Precio_Base.Size = new Size(133, 20);
                        Label_Precio_Base.TabIndex = 2;
                        Label_Precio_Base.Text = "Precio Base(U$Ds)";
                        // 
                        // NumericUpDown_Valor
                        // 
                        NumericUpDown_Valor.BorderStyle = BorderStyle.FixedSingle;
                        NumericUpDown_Valor.Cursor = Cursors.IBeam;
                        NumericUpDown_Valor.Location = new Point(66, 74);
                        NumericUpDown_Valor.Maximum = new decimal(new int[] { int.MinValue, 0, 0, 0 });
                        NumericUpDown_Valor.Name = "NumericUpDown_Valor";
                        NumericUpDown_Valor.Size = new Size(150, 30);
                        NumericUpDown_Valor.TabIndex = 6;
                        // 
                        // Label_Valor
                        // 
                        Label_Valor.AutoSize = true;
                        Label_Valor.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Valor.Location = new Point(66, 51);
                        Label_Valor.Name = "Label_Valor";
                        Label_Valor.Size = new Size(91, 20);
                        Label_Valor.TabIndex = 0;
                        Label_Valor.Text = "Valor(U$Ds)";
                        // 
                        // Gestion_Lotes
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        AutoScroll = true;
                        ClientSize = new Size(1073, 961);
                        Controls.Add(GroupBox_Atributos_Lote);
                        Controls.Add(GroupBox_Controles);
                        Controls.Add(GroupBox_Seleccion);
                        Controls.Add(GroupBox_Seleccion_Productos);
                        FormBorderStyle = FormBorderStyle.FixedSingle;
                        Name = "Gestion_Lotes";
                        Text = "Gestion_Lotes";
                        GroupBox_Seleccion_Productos.ResumeLayout(false);
                        GroupBox_Seleccion_Productos.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos_Seleccionados).EndInit();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos_Libres).EndInit();
                        GroupBox_Seleccion.ResumeLayout(false);
                        GroupBox_Seleccion.PerformLayout();
                        GroupBox_Controles.ResumeLayout(false);
                        GroupBox_Atributos_Lote.ResumeLayout(false);
                        GroupBox_Atributos_Lote.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Precio_Base).EndInit();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Valor).EndInit();
                        ResumeLayout(false);
                }

                #endregion

                private GroupBox GroupBox_Seleccion_Productos;
                private Label Label_Decoracion;
                private Button Button_Izquierda;
                private Button Button_Derecha;
                private Label Label_Seleccion_Productos;
                private Label Label_Productos_Libres;
                private GroupBox GroupBox_Seleccion;
                private TextBox TextBox_ID_Lote;
                private Button Button_Buscar_Por_Producto;
                private GroupBox GroupBox_Controles;
                private Button Button_Eliminar;
                private Button Button_Modificar;
                private Button Button_Crear;
                private Button Button_Ir_A_ID;
                private Label Label_ID_Lote_Actual;
                private CheckBox CheckBox_Habilitado;
                private Label Label_Habilitado;
                private GroupBox GroupBox_Atributos_Lote;
                private Label Label_Valor;
                private NumericUpDown NumericUpDown_Precio_Base;
                private Label Label_Precio_Base;
                private NumericUpDown NumericUpDown_Valor;
                private ComboBox DropDownList_Categoria;
                private Label Label_Categoria;
                private DataGridView Grilla_Productos_Libres;
                private DataGridView Grilla_Productos_Seleccionados;
        }
}