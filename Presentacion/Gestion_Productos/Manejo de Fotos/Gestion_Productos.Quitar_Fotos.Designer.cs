namespace Presentacion.Gestion_Productos
{
        partial class Gestion_Productos_Quitar_Fotos : Form
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
                        Panel_Fotos_Disponibles = new Panel();
                        Button_Quitar_Foto = new Button();
                        DropDown_Foto_Numero = new ComboBox();
                        Label_Fotos_Disponibles = new Label();
                        Panel_Fotos_Disponibles.SuspendLayout();
                        SuspendLayout();
                        // 
                        // Panel_Fotos_Disponibles
                        // 
                        Panel_Fotos_Disponibles.BorderStyle = BorderStyle.FixedSingle;
                        Panel_Fotos_Disponibles.Controls.Add(Button_Quitar_Foto);
                        Panel_Fotos_Disponibles.Controls.Add(DropDown_Foto_Numero);
                        Panel_Fotos_Disponibles.Location = new Point(12, 12);
                        Panel_Fotos_Disponibles.Name = "Panel_Fotos_Disponibles";
                        Panel_Fotos_Disponibles.Size = new Size(389, 203);
                        Panel_Fotos_Disponibles.TabIndex = 0;
                        // 
                        // Button_Quitar_Foto
                        // 
                        Button_Quitar_Foto.Cursor = Cursors.Hand;
                        Button_Quitar_Foto.Enabled = false;
                        Button_Quitar_Foto.FlatStyle = FlatStyle.Flat;
                        Button_Quitar_Foto.Location = new Point(244, 32);
                        Button_Quitar_Foto.Name = "Button_Quitar_Foto";
                        Button_Quitar_Foto.Size = new Size(94, 29);
                        Button_Quitar_Foto.TabIndex = 1;
                        Button_Quitar_Foto.Text = "Quitar Foto";
                        Button_Quitar_Foto.UseVisualStyleBackColor = true;
                        Button_Quitar_Foto.Click += Button_Quitar_Foto_Click;
                        // 
                        // DropDown_Foto_Numero
                        // 
                        DropDown_Foto_Numero.Cursor = Cursors.Hand;
                        DropDown_Foto_Numero.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDown_Foto_Numero.FlatStyle = FlatStyle.Flat;
                        DropDown_Foto_Numero.FormattingEnabled = true;
                        DropDown_Foto_Numero.Location = new Point(24, 33);
                        DropDown_Foto_Numero.Name = "DropDown_Foto_Numero";
                        DropDown_Foto_Numero.Size = new Size(151, 28);
                        DropDown_Foto_Numero.TabIndex = 0;
                        DropDown_Foto_Numero.SelectedIndexChanged += DropDown_Foto_Numero_SelectedIndexChanged;
                        // 
                        // Label_Fotos_Disponibles
                        // 
                        Label_Fotos_Disponibles.AutoSize = true;
                        Label_Fotos_Disponibles.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
                        Label_Fotos_Disponibles.Location = new Point(36, -2);
                        Label_Fotos_Disponibles.Name = "Label_Fotos_Disponibles";
                        Label_Fotos_Disponibles.Size = new Size(185, 28);
                        Label_Fotos_Disponibles.TabIndex = 0;
                        Label_Fotos_Disponibles.Text = "Fotos del producto";
                        // 
                        // Gestion_Productos_Quitar_Fotos
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(413, 227);
                        Controls.Add(Label_Fotos_Disponibles);
                        Controls.Add(Panel_Fotos_Disponibles);
                        Name = "Gestion_Productos_Quitar_Fotos";
                        Text = "Quitar Fotos";
                        Panel_Fotos_Disponibles.ResumeLayout(false);
                        ResumeLayout(false);
                        PerformLayout();
                }

                private void Gestion_Productos_Quitar_Fotos_Click(object sender, EventArgs e)
                {
                        throw new NotImplementedException();
                }

                #endregion

                private Panel Panel_Fotos_Disponibles;
                private Label Label_Fotos_Disponibles;
                private ComboBox DropDown_Foto_Numero;
                private Button Button_Quitar_Foto;
        }
}