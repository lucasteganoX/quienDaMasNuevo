namespace Presentacion.Gestion_Remates
{
        partial class Buscar_Por_Elemento
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
                        Grilla_Resumen_Elementos_Subasta_NoLibres = new DataGridView();
                        CheckBox_Autocompletar_Final = new CheckBox();
                        CheckBox_Autocompletar_Principio = new CheckBox();
                        Button_Ir_A_Remate = new Button();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Resumen_Elementos_Subasta_NoLibres).BeginInit();
                        SuspendLayout();
                        // 
                        // DropDownList_Filtro_Busqueda
                        // 
                        DropDownList_Filtro_Busqueda.Cursor = Cursors.Hand;
                        DropDownList_Filtro_Busqueda.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Filtro_Busqueda.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        DropDownList_Filtro_Busqueda.FormattingEnabled = true;
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
                        TextBox_Buscar.PlaceholderText = "Buscar Elemento del Remate por ID";
                        TextBox_Buscar.Size = new Size(372, 30);
                        TextBox_Buscar.TabIndex = 2;
                        TextBox_Buscar.TextChanged += TextBox_Buscar_TextChanged;
                        TextBox_Buscar.KeyPress += TextBox_Buscar_KeyPress;
                        // 
                        // Grilla_Resumen_Elementos_Subasta_NoLibres
                        // 
                        Grilla_Resumen_Elementos_Subasta_NoLibres.AllowUserToAddRows = false;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.AllowUserToDeleteRows = false;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.AllowUserToOrderColumns = true;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.Location = new Point(12, 79);
                        Grilla_Resumen_Elementos_Subasta_NoLibres.MultiSelect = false;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.Name = "Grilla_Resumen_Elementos_Subasta_NoLibres";
                        Grilla_Resumen_Elementos_Subasta_NoLibres.ReadOnly = true;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.RowHeadersWidth = 51;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.RowTemplate.Height = 29;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.Size = new Size(776, 359);
                        Grilla_Resumen_Elementos_Subasta_NoLibres.TabIndex = 3;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.CellDoubleClick += Grilla_Elementos_Subasta_NoLibres_CellDoubleClick;
                        Grilla_Resumen_Elementos_Subasta_NoLibres.SelectionChanged += Grilla_Resumen_Elementos_Subasta_NoLibres_SelectionChanged;
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
                        // Button_Ir_A_Remate
                        // 
                        Button_Ir_A_Remate.Cursor = Cursors.Hand;
                        Button_Ir_A_Remate.Enabled = false;
                        Button_Ir_A_Remate.FlatStyle = FlatStyle.Flat;
                        Button_Ir_A_Remate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Ir_A_Remate.Location = new Point(817, 359);
                        Button_Ir_A_Remate.Name = "Button_Ir_A_Remate";
                        Button_Ir_A_Remate.Size = new Size(202, 55);
                        Button_Ir_A_Remate.TabIndex = 6;
                        Button_Ir_A_Remate.Text = "Ir a Remate";
                        Button_Ir_A_Remate.UseVisualStyleBackColor = true;
                        Button_Ir_A_Remate.MouseClick += Button_Ir_A_Remate_MouseClick;
                        // 
                        // Buscar_Por_Elemento
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(1073, 450);
                        Controls.Add(Button_Ir_A_Remate);
                        Controls.Add(CheckBox_Autocompletar_Principio);
                        Controls.Add(CheckBox_Autocompletar_Final);
                        Controls.Add(Grilla_Resumen_Elementos_Subasta_NoLibres);
                        Controls.Add(DropDownList_Filtro_Busqueda);
                        Controls.Add(TextBox_Buscar);
                        FormBorderStyle = FormBorderStyle.FixedSingle;
                        Name = "Buscar_Por_Elemento";
                        Text = "Buscar Producto en Lote";
                        Load += Buscar_Por_Elemento_Load;
                        ((System.ComponentModel.ISupportInitialize)Grilla_Resumen_Elementos_Subasta_NoLibres).EndInit();
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion

                private ComboBox DropDownList_Filtro_Busqueda;
                private TextBox TextBox_Buscar;
                private DataGridView Grilla_Resumen_Elementos_Subasta_NoLibres;
                private CheckBox CheckBox_Autocompletar_Final;
                private CheckBox CheckBox_Autocompletar_Principio;
                private Button Button_Ir_A_Remate;
        }
}