namespace Presentacion.Gestion_Productos.Tipado_Productos
{
        partial class Gestion_Productos_Tipado_Maquinaria
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
                        Label_Nueva = new Label();
                        CheckBox_Nueva = new CheckBox();
                        Label_Marca = new Label();
                        TextBox_Marca = new TextBox();
                        Label_Numerio_Serial = new Label();
                        TextBox_Numero_Serial = new TextBox();
                        DropDownList_Historial_Propiedad = new ComboBox();
                        Label_Historial_Propiedad = new Label();
                        Label_Tipo_Maquina = new Label();
                        NumericUpDown_Ano_Adquisicion = new NumericUpDown();
                        Label_Ano_Adquisicion = new Label();
                        Label_Modelo = new Label();
                        TextBox_Modelo = new TextBox();
                        DropDownList_Tipo_Maquina = new ComboBox();
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Ano_Adquisicion).BeginInit();
                        SuspendLayout();
                        // 
                        // Label_Nueva
                        // 
                        Label_Nueva.AutoSize = true;
                        Label_Nueva.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Nueva.Location = new Point(45, 412);
                        Label_Nueva.Name = "Label_Nueva";
                        Label_Nueva.Size = new Size(152, 20);
                        Label_Nueva.TabIndex = 33;
                        Label_Nueva.Text = "La maquina es nueva";
                        // 
                        // CheckBox_Nueva
                        // 
                        CheckBox_Nueva.AutoSize = true;
                        CheckBox_Nueva.Cursor = Cursors.Hand;
                        CheckBox_Nueva.FlatStyle = FlatStyle.Flat;
                        CheckBox_Nueva.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        CheckBox_Nueva.Location = new Point(203, 416);
                        CheckBox_Nueva.Name = "CheckBox_Nueva";
                        CheckBox_Nueva.Size = new Size(14, 13);
                        CheckBox_Nueva.TabIndex = 6;
                        CheckBox_Nueva.UseVisualStyleBackColor = true;
                        // 
                        // Label_Marca
                        // 
                        Label_Marca.AutoSize = true;
                        Label_Marca.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Marca.Location = new Point(45, 103);
                        Label_Marca.Name = "Label_Marca";
                        Label_Marca.Size = new Size(52, 20);
                        Label_Marca.TabIndex = 35;
                        Label_Marca.Text = "Marca";
                        // 
                        // TextBox_Marca
                        // 
                        TextBox_Marca.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Marca.Cursor = Cursors.IBeam;
                        TextBox_Marca.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Marca.Location = new Point(45, 126);
                        TextBox_Marca.MaxLength = 20;
                        TextBox_Marca.Name = "TextBox_Marca";
                        TextBox_Marca.Size = new Size(125, 27);
                        TextBox_Marca.TabIndex = 2;
                        // 
                        // Label_Numerio_Serial
                        // 
                        Label_Numerio_Serial.AutoSize = true;
                        Label_Numerio_Serial.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Numerio_Serial.Location = new Point(45, 255);
                        Label_Numerio_Serial.Name = "Label_Numerio_Serial";
                        Label_Numerio_Serial.Size = new Size(108, 20);
                        Label_Numerio_Serial.TabIndex = 37;
                        Label_Numerio_Serial.Text = "Numero Serial";
                        // 
                        // TextBox_Numero_Serial
                        // 
                        TextBox_Numero_Serial.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Numero_Serial.Cursor = Cursors.IBeam;
                        TextBox_Numero_Serial.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Numero_Serial.Location = new Point(45, 278);
                        TextBox_Numero_Serial.MaxLength = 20;
                        TextBox_Numero_Serial.Name = "TextBox_Numero_Serial";
                        TextBox_Numero_Serial.Size = new Size(125, 27);
                        TextBox_Numero_Serial.TabIndex = 4;
                        // 
                        // DropDownList_Historial_Propiedad
                        // 
                        DropDownList_Historial_Propiedad.AutoCompleteCustomSource.AddRange(new string[] { "Primera Mano", "Segunda Mano", "Tercera Mano" });
                        DropDownList_Historial_Propiedad.Cursor = Cursors.Hand;
                        DropDownList_Historial_Propiedad.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Historial_Propiedad.FlatStyle = FlatStyle.Flat;
                        DropDownList_Historial_Propiedad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Historial_Propiedad.FormattingEnabled = true;
                        DropDownList_Historial_Propiedad.Items.AddRange(new object[] { "Primera Mano", "Segunda Mano", "Tercera Mano" });
                        DropDownList_Historial_Propiedad.Location = new Point(45, 360);
                        DropDownList_Historial_Propiedad.Name = "DropDownList_Historial_Propiedad";
                        DropDownList_Historial_Propiedad.Size = new Size(159, 28);
                        DropDownList_Historial_Propiedad.TabIndex = 5;
                        // 
                        // Label_Historial_Propiedad
                        // 
                        Label_Historial_Propiedad.AutoSize = true;
                        Label_Historial_Propiedad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Historial_Propiedad.Location = new Point(45, 333);
                        Label_Historial_Propiedad.Name = "Label_Historial_Propiedad";
                        Label_Historial_Propiedad.Size = new Size(162, 20);
                        Label_Historial_Propiedad.TabIndex = 40;
                        Label_Historial_Propiedad.Text = "Historial de Propiedad";
                        // 
                        // Label_Tipo_Maquina
                        // 
                        Label_Tipo_Maquina.AutoSize = true;
                        Label_Tipo_Maquina.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Tipo_Maquina.Location = new Point(45, 36);
                        Label_Tipo_Maquina.Name = "Label_Tipo_Maquina";
                        Label_Tipo_Maquina.Size = new Size(124, 20);
                        Label_Tipo_Maquina.TabIndex = 42;
                        Label_Tipo_Maquina.Text = "Tipo de maquina";
                        // 
                        // NumericUpDown_Ano_Adquisicion
                        // 
                        NumericUpDown_Ano_Adquisicion.BorderStyle = BorderStyle.FixedSingle;
                        NumericUpDown_Ano_Adquisicion.Cursor = Cursors.IBeam;
                        NumericUpDown_Ano_Adquisicion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        NumericUpDown_Ano_Adquisicion.Location = new Point(45, 481);
                        NumericUpDown_Ano_Adquisicion.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
                        NumericUpDown_Ano_Adquisicion.Minimum = new decimal(new int[] { 1800, 0, 0, 0 });
                        NumericUpDown_Ano_Adquisicion.Name = "NumericUpDown_Ano_Adquisicion";
                        NumericUpDown_Ano_Adquisicion.Size = new Size(159, 27);
                        NumericUpDown_Ano_Adquisicion.TabIndex = 7;
                        NumericUpDown_Ano_Adquisicion.Value = new decimal(new int[] { 2000, 0, 0, 0 });
                        // 
                        // Label_Ano_Adquisicion
                        // 
                        Label_Ano_Adquisicion.AutoSize = true;
                        Label_Ano_Adquisicion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Ano_Adquisicion.Location = new Point(45, 458);
                        Label_Ano_Adquisicion.Name = "Label_Ano_Adquisicion";
                        Label_Ano_Adquisicion.Size = new Size(142, 20);
                        Label_Ano_Adquisicion.TabIndex = 43;
                        Label_Ano_Adquisicion.Text = "Año de Adquisicion";
                        // 
                        // Label_Modelo
                        // 
                        Label_Modelo.AutoSize = true;
                        Label_Modelo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Modelo.Location = new Point(45, 180);
                        Label_Modelo.Name = "Label_Modelo";
                        Label_Modelo.Size = new Size(62, 20);
                        Label_Modelo.TabIndex = 45;
                        Label_Modelo.Text = "Modelo";
                        // 
                        // TextBox_Modelo
                        // 
                        TextBox_Modelo.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Modelo.Cursor = Cursors.IBeam;
                        TextBox_Modelo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        TextBox_Modelo.Location = new Point(45, 203);
                        TextBox_Modelo.MaxLength = 20;
                        TextBox_Modelo.Name = "TextBox_Modelo";
                        TextBox_Modelo.Size = new Size(125, 27);
                        TextBox_Modelo.TabIndex = 3;
                        // 
                        // DropDownList_Tipo_Maquina
                        // 
                        DropDownList_Tipo_Maquina.AutoCompleteCustomSource.AddRange(new string[] { "Primera Mano", "Segunda Mano", "Tercera Mano" });
                        DropDownList_Tipo_Maquina.Cursor = Cursors.Hand;
                        DropDownList_Tipo_Maquina.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Tipo_Maquina.FlatStyle = FlatStyle.Flat;
                        DropDownList_Tipo_Maquina.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Tipo_Maquina.FormattingEnabled = true;
                        DropDownList_Tipo_Maquina.Items.AddRange(new object[] { "Tractor", "Retroexcavadora", "Camion", "Camioneta", "Fumigadora", "Cosechadora", "Sembradora", "Fertilizadora", "Tolva", "Otra" });
                        DropDownList_Tipo_Maquina.Location = new Point(45, 59);
                        DropDownList_Tipo_Maquina.Name = "DropDownList_Tipo_Maquina";
                        DropDownList_Tipo_Maquina.Size = new Size(159, 28);
                        DropDownList_Tipo_Maquina.TabIndex = 1;
                        // 
                        // Gestion_Productos_Tipado_Maquinaria
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(380, 539);
                        Controls.Add(DropDownList_Tipo_Maquina);
                        Controls.Add(TextBox_Modelo);
                        Controls.Add(Label_Modelo);
                        Controls.Add(NumericUpDown_Ano_Adquisicion);
                        Controls.Add(Label_Ano_Adquisicion);
                        Controls.Add(Label_Tipo_Maquina);
                        Controls.Add(Label_Historial_Propiedad);
                        Controls.Add(DropDownList_Historial_Propiedad);
                        Controls.Add(TextBox_Numero_Serial);
                        Controls.Add(Label_Numerio_Serial);
                        Controls.Add(TextBox_Marca);
                        Controls.Add(Label_Marca);
                        Controls.Add(CheckBox_Nueva);
                        Controls.Add(Label_Nueva);
                        Name = "Gestion_Productos_Tipado_Maquinaria";
                        Text = "Tipado de Maquinaria";
                        FormClosing += Gestion_Productos_Tipado_Maquinaria_FormClosing;
                        ((System.ComponentModel.ISupportInitialize)NumericUpDown_Ano_Adquisicion).EndInit();
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion
                private Label Label_Nueva;
                private Label Label_Marca;
                private Label Label_Numerio_Serial;
                private Label Label_Historial_Propiedad;
                private Label Label_Tipo_Maquina;
                private Label Label_Ano_Adquisicion;
                internal CheckBox CheckBox_Nueva;
                internal TextBox TextBox_Marca;
                internal TextBox TextBox_Numero_Serial;
                internal ComboBox DropDownList_Historial_Propiedad;
                internal NumericUpDown NumericUpDown_Ano_Adquisicion;
                private Label Label_Modelo;
                internal TextBox TextBox_Modelo;
                internal ComboBox DropDownList_Tipo_Maquina;
        }
}