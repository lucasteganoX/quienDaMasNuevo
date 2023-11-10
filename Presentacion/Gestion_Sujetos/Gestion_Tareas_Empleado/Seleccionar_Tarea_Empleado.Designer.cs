﻿namespace Presentacion.Gestion_Sujetos
{
        partial class Seleccionar_Tarea_Empleado
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
                        CheckBox_Autocompletar_Principio = new CheckBox();
                        CheckBox_Autocompletar_Final = new CheckBox();
                        Grilla_Tareas = new DataGridView();
                        TextBox_Buscador = new TextBox();
                        DropDownList_Filtro_Busqueda = new ComboBox();
                        Button_Editar_Tarea = new Button();
                        ((System.ComponentModel.ISupportInitialize)Grilla_Tareas).BeginInit();
                        SuspendLayout();
                        // 
                        // CheckBox_Autocompletar_Principio
                        // 
                        CheckBox_Autocompletar_Principio.AutoSize = true;
                        CheckBox_Autocompletar_Principio.FlatStyle = FlatStyle.System;
                        CheckBox_Autocompletar_Principio.Location = new Point(817, 95);
                        CheckBox_Autocompletar_Principio.Name = "CheckBox_Autocompletar_Principio";
                        CheckBox_Autocompletar_Principio.Size = new Size(225, 25);
                        CheckBox_Autocompletar_Principio.TabIndex = 8;
                        CheckBox_Autocompletar_Principio.Text = "Auto-completar el principio";
                        CheckBox_Autocompletar_Principio.UseVisualStyleBackColor = true;
                        // 
                        // CheckBox_Autocompletar_Final
                        // 
                        CheckBox_Autocompletar_Final.AutoSize = true;
                        CheckBox_Autocompletar_Final.Checked = true;
                        CheckBox_Autocompletar_Final.CheckState = CheckState.Checked;
                        CheckBox_Autocompletar_Final.FlatStyle = FlatStyle.System;
                        CheckBox_Autocompletar_Final.Location = new Point(817, 54);
                        CheckBox_Autocompletar_Final.Name = "CheckBox_Autocompletar_Final";
                        CheckBox_Autocompletar_Final.Size = new Size(195, 25);
                        CheckBox_Autocompletar_Final.TabIndex = 7;
                        CheckBox_Autocompletar_Final.Text = "Auto-completar el final";
                        CheckBox_Autocompletar_Final.UseVisualStyleBackColor = true;
                        // 
                        // Grilla_Tareas
                        // 
                        Grilla_Tareas.AllowUserToAddRows = false;
                        Grilla_Tareas.AllowUserToDeleteRows = false;
                        Grilla_Tareas.AllowUserToOrderColumns = true;
                        Grilla_Tareas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        Grilla_Tareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                        Grilla_Tareas.Location = new Point(12, 54);
                        Grilla_Tareas.MultiSelect = false;
                        Grilla_Tareas.Name = "Grilla_Tareas";
                        Grilla_Tareas.ReadOnly = true;
                        Grilla_Tareas.RowHeadersWidth = 51;
                        Grilla_Tareas.RowTemplate.Height = 29;
                        Grilla_Tareas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        Grilla_Tareas.Size = new Size(776, 345);
                        Grilla_Tareas.TabIndex = 6;
                        Grilla_Tareas.CellDoubleClick += Grilla_Tareas_CellDoubleClick;
                        Grilla_Tareas.SelectionChanged += Grilla_Tareas_SelectionChanged;
                        // 
                        // TextBox_Buscador
                        // 
                        TextBox_Buscador.Location = new Point(12, 14);
                        TextBox_Buscador.Multiline = true;
                        TextBox_Buscador.Name = "TextBox_Buscador";
                        TextBox_Buscador.PlaceholderText = "Buscar una tarea por su descripción";
                        TextBox_Buscador.Size = new Size(324, 34);
                        TextBox_Buscador.TabIndex = 9;
                        TextBox_Buscador.KeyPress += TextBox_Buscador_KeyPress;
                        // 
                        // DropDownList_Filtro_Busqueda
                        // 
                        DropDownList_Filtro_Busqueda.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Filtro_Busqueda.FlatStyle = FlatStyle.Flat;
                        DropDownList_Filtro_Busqueda.FormattingEnabled = true;
                        DropDownList_Filtro_Busqueda.Items.AddRange(new object[] { "Tarea" });
                        DropDownList_Filtro_Busqueda.Location = new Point(342, 14);
                        DropDownList_Filtro_Busqueda.Name = "DropDownList_Filtro_Busqueda";
                        DropDownList_Filtro_Busqueda.Size = new Size(180, 28);
                        DropDownList_Filtro_Busqueda.TabIndex = 10;
                        // 
                        // Button_Editar_Tarea
                        // 
                        Button_Editar_Tarea.Enabled = false;
                        Button_Editar_Tarea.Location = new Point(817, 329);
                        Button_Editar_Tarea.Name = "Button_Editar_Tarea";
                        Button_Editar_Tarea.Size = new Size(209, 45);
                        Button_Editar_Tarea.TabIndex = 11;
                        Button_Editar_Tarea.Text = "Editar tarea";
                        Button_Editar_Tarea.UseVisualStyleBackColor = true;
                        Button_Editar_Tarea.Click += Button_Editar_Tarea_Click;
                        // 
                        // Seleccionar_Tarea_Empleado
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(1053, 411);
                        Controls.Add(Button_Editar_Tarea);
                        Controls.Add(DropDownList_Filtro_Busqueda);
                        Controls.Add(TextBox_Buscador);
                        Controls.Add(CheckBox_Autocompletar_Principio);
                        Controls.Add(CheckBox_Autocompletar_Final);
                        Controls.Add(Grilla_Tareas);
                        Name = "Seleccionar_Tarea_Empleado";
                        Text = "Seleccionar la tarea del Empleado";
                        Load += Seleccionar_Tarea_Empleado_Load;
                        ((System.ComponentModel.ISupportInitialize)Grilla_Tareas).EndInit();
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion

                private CheckBox CheckBox_Autocompletar_Principio;
                private CheckBox CheckBox_Autocompletar_Final;
                private DataGridView Grilla_Productos_NoLibres;
                private TextBox TextBox_Buscador;
                private ComboBox DropDownList_Filtro_Busqueda;
                private Button Button_Editar_Tarea;
                private DataGridView Grilla_Tareas;
        }
}