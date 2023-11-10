namespace Presentacion.Gestion_Lotes
{
        partial class Buscar_Por_Producto
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
                        DropDownList_Filtro_Busqueda = new ComboBox();
                        TextBox_Buscar = new TextBox();
                        Grilla_Productos_NoLibres = new DataGridView();
                        CheckBox_Autocompletar_Final = new CheckBox();
                        CheckBox_Autocompletar_Principio = new CheckBox();
                        Button_Ir_A_Lote = new Button();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos_NoLibres).BeginInit();
                        SuspendLayout();
                        // 
                        // DropDownList_Filtro_Busqueda
                        // 
                        DropDownList_Filtro_Busqueda.Cursor = Cursors.Hand;
                        DropDownList_Filtro_Busqueda.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Filtro_Busqueda.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        DropDownList_Filtro_Busqueda.FormattingEnabled = true;
                        DropDownList_Filtro_Busqueda.Items.AddRange(new object[] { "ID Producto", "Nombre", "Descripcion" });
                        DropDownList_Filtro_Busqueda.Location = new Point(390, 41);
                        DropDownList_Filtro_Busqueda.Name = "DropDownList_Filtro_Busqueda";
                        DropDownList_Filtro_Busqueda.Size = new Size(151, 31);
                        DropDownList_Filtro_Busqueda.TabIndex = 1;
                        DropDownList_Filtro_Busqueda.SelectedIndexChanged += DropDownList_Filtro_Busqueda_SelectedIndexChanged;
                        // 
                        // TextBox_Buscar
                        // 
                        TextBox_Buscar.Cursor = Cursors.IBeam;
                        TextBox_Buscar.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point);
                        TextBox_Buscar.Location = new Point(12, 42);
                        TextBox_Buscar.MaxLength = 10;
                        TextBox_Buscar.Name = "TextBox_Buscar";
                        TextBox_Buscar.PlaceholderText = "Buscar Producto del Lote por ID";
                        TextBox_Buscar.Size = new Size(372, 30);
                        TextBox_Buscar.TabIndex = 2;
                        TextBox_Buscar.TextChanged += TextBox_Buscar_TextChanged;
                        TextBox_Buscar.KeyPress += TextBox_Buscar_KeyPress;
                        // 
                        // Grilla_Productos_NoLibres
                        // 
                        Grilla_Productos_NoLibres.AllowUserToAddRows = false;
                        Grilla_Productos_NoLibres.AllowUserToDeleteRows = false;
                        Grilla_Productos_NoLibres.AllowUserToOrderColumns = true;
                        Grilla_Productos_NoLibres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Productos_NoLibres.Location = new Point(12, 79);
                        Grilla_Productos_NoLibres.MultiSelect = false;
                        Grilla_Productos_NoLibres.Name = "Grilla_Productos_NoLibres";
                        Grilla_Productos_NoLibres.ReadOnly = true;
                        Grilla_Productos_NoLibres.RowHeadersWidth = 51;
                        Grilla_Productos_NoLibres.RowTemplate.Height = 29;
                        Grilla_Productos_NoLibres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Productos_NoLibres.Size = new Size(776, 359);
                        Grilla_Productos_NoLibres.TabIndex = 3;
                        Grilla_Productos_NoLibres.CellDoubleClick += Grilla_Productos_NoLibres_CellDoubleClick;
                        Grilla_Productos_NoLibres.SelectionChanged += Grilla_Productos_NoLibres_SelectionChanged;
                        // 
                        // CheckBox_Autocompletar_Final
                        // 
                        CheckBox_Autocompletar_Final.AutoSize = true;
                        CheckBox_Autocompletar_Final.Checked = true;
                        CheckBox_Autocompletar_Final.CheckState = CheckState.Checked;
                        CheckBox_Autocompletar_Final.FlatStyle = FlatStyle.System;
                        CheckBox_Autocompletar_Final.Location = new Point(817, 93);
                        CheckBox_Autocompletar_Final.Name = "CheckBox_Autocompletar_Final";
                        CheckBox_Autocompletar_Final.Size = new Size(195, 25);
                        CheckBox_Autocompletar_Final.TabIndex = 4;
                        CheckBox_Autocompletar_Final.Text = "Auto-completar el final";
                        CheckBox_Autocompletar_Final.UseVisualStyleBackColor = true;
                        // 
                        // CheckBox_Autocompletar_Principio
                        // 
                        CheckBox_Autocompletar_Principio.AutoSize = true;
                        CheckBox_Autocompletar_Principio.FlatStyle = FlatStyle.System;
                        CheckBox_Autocompletar_Principio.Location = new Point(817, 134);
                        CheckBox_Autocompletar_Principio.Name = "CheckBox_Autocompletar_Principio";
                        CheckBox_Autocompletar_Principio.Size = new Size(225, 25);
                        CheckBox_Autocompletar_Principio.TabIndex = 5;
                        CheckBox_Autocompletar_Principio.Text = "Auto-completar el principio";
                        CheckBox_Autocompletar_Principio.UseVisualStyleBackColor = true;
                        // 
                        // Button_Ir_A_Lote
                        // 
                        Button_Ir_A_Lote.Cursor = Cursors.Hand;
                        Button_Ir_A_Lote.Enabled = false;
                        Button_Ir_A_Lote.FlatStyle = FlatStyle.Flat;
                        Button_Ir_A_Lote.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Ir_A_Lote.Location = new Point(817, 359);
                        Button_Ir_A_Lote.Name = "Button_Ir_A_Lote";
                        Button_Ir_A_Lote.Size = new Size(202, 55);
                        Button_Ir_A_Lote.TabIndex = 6;
                        Button_Ir_A_Lote.Text = "Ir a Lote";
                        Button_Ir_A_Lote.UseVisualStyleBackColor = true;
                        Button_Ir_A_Lote.MouseClick += Button_Ir_A_Lote_MouseClick;
                        // 
                        // Buscar_Por_Producto
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(1073, 450);
                        Controls.Add(Button_Ir_A_Lote);
                        Controls.Add(CheckBox_Autocompletar_Principio);
                        Controls.Add(CheckBox_Autocompletar_Final);
                        Controls.Add(Grilla_Productos_NoLibres);
                        Controls.Add(DropDownList_Filtro_Busqueda);
                        Controls.Add(TextBox_Buscar);
                        FormBorderStyle = FormBorderStyle.FixedSingle;
                        Name = "Buscar_Por_Producto";
                        Text = "Buscar Producto en Lote";
                        Load += Buscar_Por_Producto_Load ;
                        ((System.ComponentModel.ISupportInitialize)Grilla_Productos_NoLibres).EndInit();
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion

                private ComboBox DropDownList_Filtro_Busqueda;
                private TextBox TextBox_Buscar;
                private DataGridView Grilla_Productos_NoLibres;
                private CheckBox CheckBox_Autocompletar_Final;
                private CheckBox CheckBox_Autocompletar_Principio;
                private Button Button_Ir_A_Lote;
        }
}