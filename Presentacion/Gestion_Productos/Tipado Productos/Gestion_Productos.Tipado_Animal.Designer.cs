namespace Presentacion.Gestion_Productos
{
        partial class Gestion_Productos_Tipado_Animal
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
                        Label_Tipo_Animal = new Label();
                        DropDownList_Tipo_Animal = new ComboBox();
                        Label_Sexo = new Label();
                        TextBox_Nombre = new TextBox();
                        Label_Edad = new Label();
                        Castrado = new Label();
                        CheckBox_Castrado = new CheckBox();
                        Label_Raza = new Label();
                        TextBox_Raza = new TextBox();
                        NumericUpDown_Edad = new NumericUpDown();
                        Label_Peso = new Label();
                        NumericUpDown_Peso = new NumericUpDown();
                        Label_Especializacion = new Label();
                        DropDownList_Especializacion = new ComboBox();
                        CheckBox_Raza = new CheckBox();
                        DropDownList_Sexo = new ComboBox();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Edad).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Peso).BeginInit();
                        SuspendLayout();
                        // 
                        // Label_Tipo_Animal
                        // 
                        Label_Tipo_Animal.AutoSize = true;
                        Label_Tipo_Animal.Location = new Point(67, 43);
                        Label_Tipo_Animal.Name = "Label_Tipo_Animal";
                        Label_Tipo_Animal.Size = new Size(112, 20);
                        Label_Tipo_Animal.TabIndex = 0;
                        Label_Tipo_Animal.Text = "Tipo de Animal";
                        // 
                        // DropDownList_Tipo_Animal
                        // 
                        DropDownList_Tipo_Animal.Cursor = Cursors.Hand;
                        DropDownList_Tipo_Animal.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Tipo_Animal.FlatStyle = FlatStyle.Flat;
                        DropDownList_Tipo_Animal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Tipo_Animal.FormattingEnabled = true;
                        DropDownList_Tipo_Animal.Items.AddRange(new object[] { "Equino", "Vacuno", "Ovino", "Otro" });
                        DropDownList_Tipo_Animal.Location = new Point(67, 66);
                        DropDownList_Tipo_Animal.Name = "DropDownList_Tipo_Animal";
                        DropDownList_Tipo_Animal.Size = new Size(127, 28);
                        DropDownList_Tipo_Animal.TabIndex = 1;
                        DropDownList_Tipo_Animal.SelectedIndexChanged += DropDownList_Tipo_Animal_SelectedIndexChanged;
                        // 
                        // Label_Sexo
                        // 
                        Label_Sexo.AutoSize = true;
                        Label_Sexo.Location = new Point(294, 196);
                        Label_Sexo.Name = "Label_Sexo";
                        Label_Sexo.Size = new Size(42, 20);
                        Label_Sexo.TabIndex = 2;
                        Label_Sexo.Text = "Sexo";
                        // 
                        // TextBox_Nombre
                        // 
                        TextBox_Nombre.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Nombre.Cursor = Cursors.IBeam;
                        TextBox_Nombre.Enabled = false;
                        TextBox_Nombre.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Nombre.Location = new Point(294, 292);
                        TextBox_Nombre.Name = "TextBox_Nombre";
                        TextBox_Nombre.PlaceholderText = "Deshabilitado";
                        TextBox_Nombre.Size = new Size(125, 27);
                        TextBox_Nombre.TabIndex = 999999999;
                        TextBox_Nombre.TabStop = false;
                        TextBox_Nombre.Visible = false;
                        // 
                        // Label_Edad
                        // 
                        Label_Edad.AutoSize = true;
                        Label_Edad.Location = new Point(67, 121);
                        Label_Edad.Name = "Label_Edad";
                        Label_Edad.Size = new Size(43, 20);
                        Label_Edad.TabIndex = 4;
                        Label_Edad.Text = "Edad";
                        // 
                        // Castrado
                        // 
                        Castrado.AutoSize = true;
                        Castrado.Location = new Point(67, 197);
                        Castrado.Name = "Castrado";
                        Castrado.Size = new Size(69, 20);
                        Castrado.TabIndex = 6;
                        Castrado.Text = "Castrado";
                        // 
                        // CheckBox_Castrado
                        // 
                        CheckBox_Castrado.AutoSize = true;
                        CheckBox_Castrado.Cursor = Cursors.Hand;
                        CheckBox_Castrado.FlatStyle = FlatStyle.Flat;
                        CheckBox_Castrado.Location = new Point(142, 200);
                        CheckBox_Castrado.Name = "CheckBox_Castrado";
                        CheckBox_Castrado.Size = new Size(14, 13);
                        CheckBox_Castrado.TabIndex = 3;
                        CheckBox_Castrado.UseVisualStyleBackColor = true;
                        // 
                        // Label_Raza
                        // 
                        Label_Raza.AutoSize = true;
                        Label_Raza.Location = new Point(69, 239);
                        Label_Raza.Name = "Label_Raza";
                        Label_Raza.Size = new Size(41, 20);
                        Label_Raza.TabIndex = 8;
                        Label_Raza.Text = "Raza";
                        // 
                        // TextBox_Raza
                        // 
                        TextBox_Raza.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Raza.Cursor = Cursors.IBeam;
                        TextBox_Raza.Enabled = false;
                        TextBox_Raza.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Raza.Location = new Point(69, 262);
                        TextBox_Raza.MaxLength = 20;
                        TextBox_Raza.Name = "TextBox_Raza";
                        TextBox_Raza.Size = new Size(125, 27);
                        TextBox_Raza.TabIndex = 5;
                        // 
                        // NumericUpDown_Edad
                        // 
                        NumericUpDown_Edad.BorderStyle = BorderStyle.FixedSingle;
                        NumericUpDown_Edad.Cursor = Cursors.IBeam;
                        NumericUpDown_Edad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        NumericUpDown_Edad.Location = new Point(67, 144);
                        NumericUpDown_Edad.Name = "NumericUpDown_Edad";
                        NumericUpDown_Edad.Size = new Size(125, 27);
                        NumericUpDown_Edad.TabIndex = 2;
                        // 
                        // Label_Peso
                        // 
                        Label_Peso.AutoSize = true;
                        Label_Peso.Location = new Point(294, 43);
                        Label_Peso.Name = "Label_Peso";
                        Label_Peso.Size = new Size(82, 20);
                        Label_Peso.TabIndex = 11;
                        Label_Peso.Text = "Peso(Kilos)";
                        // 
                        // NumericUpDown_Peso
                        // 
                        NumericUpDown_Peso.BorderStyle = BorderStyle.FixedSingle;
                        NumericUpDown_Peso.Cursor = Cursors.IBeam;
                        NumericUpDown_Peso.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        NumericUpDown_Peso.Location = new Point(294, 66);
                        NumericUpDown_Peso.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
                        NumericUpDown_Peso.Name = "NumericUpDown_Peso";
                        NumericUpDown_Peso.Size = new Size(125, 27);
                        NumericUpDown_Peso.TabIndex = 6;
                        // 
                        // Label_Especializacion
                        // 
                        Label_Especializacion.AutoSize = true;
                        Label_Especializacion.Location = new Point(294, 121);
                        Label_Especializacion.Name = "Label_Especializacion";
                        Label_Especializacion.Size = new Size(111, 20);
                        Label_Especializacion.TabIndex = 13;
                        Label_Especializacion.Text = "Especialización";
                        // 
                        // DropDownList_Especializacion
                        // 
                        DropDownList_Especializacion.Cursor = Cursors.Hand;
                        DropDownList_Especializacion.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Especializacion.Enabled = false;
                        DropDownList_Especializacion.FlatStyle = FlatStyle.Flat;
                        DropDownList_Especializacion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Especializacion.FormattingEnabled = true;
                        DropDownList_Especializacion.Items.AddRange(new object[] { "Equino", "Vacuno", "Ovino", "Otro" });
                        DropDownList_Especializacion.Location = new Point(294, 143);
                        DropDownList_Especializacion.Name = "DropDownList_Especializacion";
                        DropDownList_Especializacion.Size = new Size(127, 28);
                        DropDownList_Especializacion.TabIndex = 7;
                        // 
                        // CheckBox_Raza
                        // 
                        CheckBox_Raza.AutoSize = true;
                        CheckBox_Raza.Cursor = Cursors.Hand;
                        CheckBox_Raza.FlatStyle = FlatStyle.Flat;
                        CheckBox_Raza.Location = new Point(116, 243);
                        CheckBox_Raza.Name = "CheckBox_Raza";
                        CheckBox_Raza.Size = new Size(14, 13);
                        CheckBox_Raza.TabIndex = 4;
                        CheckBox_Raza.UseVisualStyleBackColor = true;
                        CheckBox_Raza.CheckedChanged += CheckBox_Raza_CheckedChanged;
                        // 
                        // DropDownList_Sexo
                        // 
                        DropDownList_Sexo.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Sexo.FlatStyle = FlatStyle.Flat;
                        DropDownList_Sexo.FormattingEnabled = true;
                        DropDownList_Sexo.Items.AddRange(new object[] { "Macho", "Hembra" });
                        DropDownList_Sexo.Location = new Point(294, 219);
                        DropDownList_Sexo.Name = "DropDownList_Sexo";
                        DropDownList_Sexo.Size = new Size(125, 28);
                        DropDownList_Sexo.TabIndex = 8;
                        // 
                        // Gestion_Productos_Tipado_Animal
                        // 
                        AutoScaleDimensions = new SizeF(9F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(488, 350);
                        Controls.Add(DropDownList_Sexo);
                        Controls.Add(CheckBox_Raza);
                        Controls.Add(DropDownList_Especializacion);
                        Controls.Add(Label_Especializacion);
                        Controls.Add(NumericUpDown_Peso);
                        Controls.Add(Label_Peso);
                        Controls.Add(NumericUpDown_Edad);
                        Controls.Add(TextBox_Raza);
                        Controls.Add(Label_Raza);
                        Controls.Add(CheckBox_Castrado);
                        Controls.Add(Castrado);
                        Controls.Add(Label_Edad);
                        Controls.Add(TextBox_Nombre);
                        Controls.Add(Label_Sexo);
                        Controls.Add(DropDownList_Tipo_Animal);
                        Controls.Add(Label_Tipo_Animal);
                        Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Name = "Gestion_Productos_Tipado_Animal";
                        Text = "Tipado de Animal";
                        FormClosing += Gestion_Productos_Tipado_Animal_FormClosing;
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Edad).EndInit();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Peso).EndInit();
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion

                private Label Label_Tipo_Animal;
                private Label Label_Nombre;
                private TextBox TextBox_Nombre;
                private Label Label_Edad;
                private Label Castrado;
                private Label Label_Raza;
                private Label Label_Peso;
                private Label Label_Especializacion;
                private CheckBox CheckBox_Nombre;
                internal ComboBox DropDownList_Tipo_Animal;
                internal CheckBox CheckBox_Castrado;
                internal TextBox TextBox_Raza;
                internal NumericUpDown NumericUpDown_Edad;
                internal NumericUpDown NumericUpDown_Peso;
                internal ComboBox DropDownList_Especializacion;
                internal CheckBox CheckBox_Raza;
                private Label label1;
                private Label Label_Sexo;
                internal ComboBox DropDownList_Sexo;
        }
}