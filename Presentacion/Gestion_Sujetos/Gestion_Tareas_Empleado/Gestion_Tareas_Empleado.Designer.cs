namespace Presentacion.Gestion_Sujetos
{
        partial class Gestion_Tareas_Empleado
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
                        Button_Seleccionar_Tarea = new Button();
                        TextBox_Texto_Tarea = new TextBox();
                        Label_Descripcion_Tarea = new Label();
                        Button_Eliminar = new Button();
                        Button_Modificar = new Button();
                        Button_Crear = new Button();
                        SuspendLayout();
                        // 
                        // Button_Seleccionar_Tarea
                        // 
                        Button_Seleccionar_Tarea.Location = new Point(38, 190);
                        Button_Seleccionar_Tarea.Name = "Button_Seleccionar_Tarea";
                        Button_Seleccionar_Tarea.Size = new Size(188, 44);
                        Button_Seleccionar_Tarea.TabIndex = 0;
                        Button_Seleccionar_Tarea.Text = "Seleccionar tarea";
                        Button_Seleccionar_Tarea.UseVisualStyleBackColor = true;
                        Button_Seleccionar_Tarea.Click += Button_Seleccionar_Tarea_Click;
                        // 
                        // TextBox_Texto_Tarea
                        // 
                        TextBox_Texto_Tarea.BorderStyle = BorderStyle.FixedSingle;
                        TextBox_Texto_Tarea.Location = new Point(38, 60);
                        TextBox_Texto_Tarea.MaxLength = 1000;
                        TextBox_Texto_Tarea.Multiline = true;
                        TextBox_Texto_Tarea.Name = "TextBox_Texto_Tarea";
                        TextBox_Texto_Tarea.PlaceholderText = "Aquí va la descripción la tarea";
                        TextBox_Texto_Tarea.Size = new Size(722, 100);
                        TextBox_Texto_Tarea.TabIndex = 1;
                        TextBox_Texto_Tarea.TextChanged += TextBox_Texto_Tarea_TextChanged;
                        // 
                        // Label_Descripcion_Tarea
                        // 
                        Label_Descripcion_Tarea.AutoSize = true;
                        Label_Descripcion_Tarea.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Descripcion_Tarea.Location = new Point(38, 32);
                        Label_Descripcion_Tarea.Name = "Label_Descripcion_Tarea";
                        Label_Descripcion_Tarea.Size = new Size(201, 25);
                        Label_Descripcion_Tarea.TabIndex = 2;
                        Label_Descripcion_Tarea.Text = "Descripción de la tarea";
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
                        Button_Eliminar.Location = new Point(562, 190);
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
                        Button_Modificar.Enabled = false;
                        Button_Modificar.FlatAppearance.BorderColor = Color.Goldenrod;
                        Button_Modificar.FlatAppearance.BorderSize = 3;
                        Button_Modificar.FlatStyle = FlatStyle.Flat;
                        Button_Modificar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Modificar.ForeColor = SystemColors.ActiveCaptionText;
                        Button_Modificar.Location = new Point(358, 190);
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
                        Button_Crear.Location = new Point(453, 231);
                        Button_Crear.Name = "Button_Crear";
                        Button_Crear.Size = new Size(198, 35);
                        Button_Crear.TabIndex = 9;
                        Button_Crear.Text = "Crear";
                        Button_Crear.UseVisualStyleBackColor = false;
                        Button_Crear.Click += Button_Crear_Click;
                        // 
                        // Gestion_Tareas_Empleado
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(800, 307);
                        Controls.Add(Button_Eliminar);
                        Controls.Add(Button_Modificar);
                        Controls.Add(Label_Descripcion_Tarea);
                        Controls.Add(Button_Crear);
                        Controls.Add(TextBox_Texto_Tarea);
                        Controls.Add(Button_Seleccionar_Tarea);
                        Name = "Gestion_Tareas_Empleado";
                        Text = "Gestion de Tareas del Empleado";
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion

                private Button Button_Seleccionar_Tarea;
                private TextBox TextBox_Texto_Tarea;
                private Label Label_Descripcion_Tarea;
                private Button Button_Eliminar;
                private Button Button_Modificar;
                private Button Button_Crear;
        }
}