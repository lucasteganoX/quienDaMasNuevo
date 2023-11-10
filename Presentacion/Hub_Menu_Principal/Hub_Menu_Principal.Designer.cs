namespace Presentacion.Hub_Menu_Principal
{
        partial class Hub_Menu_Principal
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hub_Menu_Principal));
                        PicturBox_Portada = new PictureBox();
                        Panel_Menu = new Panel();
                        Panel_Placeholder_Envolverse = new Panel();
                        Texto_Placeholder_Envolverse3 = new Label();
                        DropDownList_Envolverse = new ComboBox();
                        Panel_Placeholder_Administracion = new Panel();
                        Texto_Placeholder_Administracion = new Label();
                        DropDownList_Administracion = new ComboBox();
                        Texto_Placeholder_Envolverse = new Label();
                        ((System.ComponentModel.ISupportInitialize)PicturBox_Portada).BeginInit();
                        Panel_Menu.SuspendLayout();
                        Panel_Placeholder_Envolverse.SuspendLayout();
                        Panel_Placeholder_Administracion.SuspendLayout();
                        SuspendLayout();
                        // 
                        // PicturBox_Portada
                        // 
                        PicturBox_Portada.Image = (Image)resources.GetObject("PicturBox_Portada.Image");
                        PicturBox_Portada.InitialImage = null;
                        PicturBox_Portada.Location = new Point(0, 51);
                        PicturBox_Portada.Name = "PicturBox_Portada";
                        PicturBox_Portada.Size = new Size(1309, 650);
                        PicturBox_Portada.SizeMode = PictureBoxSizeMode.StretchImage;
                        PicturBox_Portada.TabIndex = 0;
                        PicturBox_Portada.TabStop = false;
                        // 
                        // Panel_Menu
                        // 
                        Panel_Menu.BackColor = Color.FloralWhite;
                        Panel_Menu.Controls.Add(Panel_Placeholder_Envolverse);
                        Panel_Menu.Controls.Add(DropDownList_Envolverse);
                        Panel_Menu.Controls.Add(Panel_Placeholder_Administracion);
                        Panel_Menu.Controls.Add(DropDownList_Administracion);
                        Panel_Menu.Location = new Point(0, -1);
                        Panel_Menu.Name = "Panel_Menu";
                        Panel_Menu.Size = new Size(1309, 60);
                        Panel_Menu.TabIndex = 1;
                        // 
                        // Panel_Placeholder_Envolverse
                        // 
                        Panel_Placeholder_Envolverse.BackColor = Color.Gainsboro;
                        Panel_Placeholder_Envolverse.Controls.Add(Texto_Placeholder_Envolverse3);
                        Panel_Placeholder_Envolverse.Location = new Point(688, 0);
                        Panel_Placeholder_Envolverse.Name = "Panel_Placeholder_Envolverse";
                        Panel_Placeholder_Envolverse.Size = new Size(325, 57);
                        Panel_Placeholder_Envolverse.TabIndex = 5;
                        Panel_Placeholder_Envolverse.Click += Panel_Placeholder_Envolverse_Click_1;
                        // 
                        // Texto_Placeholder_Envolverse3
                        // 
                        Texto_Placeholder_Envolverse3.AutoSize = true;
                        Texto_Placeholder_Envolverse3.BackColor = Color.Gainsboro;
                        Texto_Placeholder_Envolverse3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
                        Texto_Placeholder_Envolverse3.ForeColor = SystemColors.GrayText;
                        Texto_Placeholder_Envolverse3.Location = new Point(3, 3);
                        Texto_Placeholder_Envolverse3.Name = "Texto_Placeholder_Envolverse3";
                        Texto_Placeholder_Envolverse3.Size = new Size(178, 46);
                        Texto_Placeholder_Envolverse3.TabIndex = 2;
                        Texto_Placeholder_Envolverse3.Text = "Envolverse";
                        Texto_Placeholder_Envolverse3.Click += Texto_Placeholder_Envolverse3_Click;
                        // 
                        // DropDownList_Envolverse
                        // 
                        DropDownList_Envolverse.BackColor = Color.Gainsboro;
                        DropDownList_Envolverse.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Envolverse.FlatStyle = FlatStyle.Flat;
                        DropDownList_Envolverse.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Envolverse.ForeColor = SystemColors.GrayText;
                        DropDownList_Envolverse.FormattingEnabled = true;
                        DropDownList_Envolverse.Items.AddRange(new object[] { "Ir a remates", "Ir a historial de remates", "Pagar", "Publicar producto", "Publicar lote" });
                        DropDownList_Envolverse.Location = new Point(688, 0);
                        DropDownList_Envolverse.Name = "DropDownList_Envolverse";
                        DropDownList_Envolverse.Size = new Size(347, 53);
                        DropDownList_Envolverse.TabIndex = 4;
                        DropDownList_Envolverse.SelectedIndexChanged += DropDownList_Envolverse_SelectedIndexChanged;
                        // 
                        // Panel_Placeholder_Administracion
                        // 
                        Panel_Placeholder_Administracion.BackColor = Color.Gainsboro;
                        Panel_Placeholder_Administracion.Controls.Add(Texto_Placeholder_Administracion);
                        Panel_Placeholder_Administracion.Location = new Point(335, 0);
                        Panel_Placeholder_Administracion.Name = "Panel_Placeholder_Administracion";
                        Panel_Placeholder_Administracion.Size = new Size(325, 57);
                        Panel_Placeholder_Administracion.TabIndex = 3;
                        Panel_Placeholder_Administracion.Click += Panel_Placeholder_Administracion_Click;
                        // 
                        // Texto_Placeholder_Administracion
                        // 
                        Texto_Placeholder_Administracion.AutoSize = true;
                        Texto_Placeholder_Administracion.BackColor = Color.Gainsboro;
                        Texto_Placeholder_Administracion.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
                        Texto_Placeholder_Administracion.ForeColor = SystemColors.GrayText;
                        Texto_Placeholder_Administracion.Location = new Point(3, 3);
                        Texto_Placeholder_Administracion.Name = "Texto_Placeholder_Administracion";
                        Texto_Placeholder_Administracion.Size = new Size(244, 46);
                        Texto_Placeholder_Administracion.TabIndex = 2;
                        Texto_Placeholder_Administracion.Text = "Administracion";
                        Texto_Placeholder_Administracion.Click += Texto_Placeholder_Administracion_Click;
                        // 
                        // DropDownList_Administracion
                        // 
                        DropDownList_Administracion.BackColor = Color.Gainsboro;
                        DropDownList_Administracion.DropDownStyle = ComboBoxStyle.DropDownList;
                        DropDownList_Administracion.FlatStyle = FlatStyle.Flat;
                        DropDownList_Administracion.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
                        DropDownList_Administracion.ForeColor = SystemColors.GrayText;
                        DropDownList_Administracion.FormattingEnabled = true;
                        DropDownList_Administracion.Items.AddRange(new object[] { "Gestión de Productos", "Gestión de Lotes", "Gestión de Remates", "Gestión de Sujetos" });
                        DropDownList_Administracion.Location = new Point(335, 0);
                        DropDownList_Administracion.Name = "DropDownList_Administracion";
                        DropDownList_Administracion.Size = new Size(347, 53);
                        DropDownList_Administracion.TabIndex = 1;
                        DropDownList_Administracion.SelectedIndexChanged += DropDownList_Administracion_SelectedIndexChanged;
                        // 
                        // Texto_Placeholder_Envolverse
                        // 
                        Texto_Placeholder_Envolverse.AutoSize = true;
                        Texto_Placeholder_Envolverse.BackColor = Color.Gainsboro;
                        Texto_Placeholder_Envolverse.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
                        Texto_Placeholder_Envolverse.ForeColor = SystemColors.GrayText;
                        Texto_Placeholder_Envolverse.Location = new Point(3, 3);
                        Texto_Placeholder_Envolverse.Name = "Texto_Placeholder_Envolverse";
                        Texto_Placeholder_Envolverse.Size = new Size(178, 46);
                        Texto_Placeholder_Envolverse.TabIndex = 2;
                        Texto_Placeholder_Envolverse.Text = "Envolverse";
                        // 
                        // Hub_Menu_Principal
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(1307, 697);
                        Controls.Add(Panel_Menu);
                        Controls.Add(PicturBox_Portada);
                        FormBorderStyle = FormBorderStyle.FixedSingle;
                        MaximizeBox = false;
                        Name = "Hub_Menu_Principal";
                        Text = "Quién Da Más? Menú Principal";
                        ((System.ComponentModel.ISupportInitialize)PicturBox_Portada).EndInit();
                        Panel_Menu.ResumeLayout(false);
                        Panel_Placeholder_Envolverse.ResumeLayout(false);
                        Panel_Placeholder_Envolverse.PerformLayout();
                        Panel_Placeholder_Administracion.ResumeLayout(false);
                        Panel_Placeholder_Administracion.PerformLayout();
                        ResumeLayout(false);
                }

                #endregion

                private PictureBox PicturBox_Portada;
                private Panel panel1;
                private ComboBox ComboBox_Administracion;
                private ComboBox DropDownList_Administracion;
                private Panel Panel_Placeholder_Administracion;
                private Label Texto_Placeholder_Administracion;
                private Panel Panel_Menu;
                private Label Texto_Placeholder_Envolverse;
                private Panel Panel_Placeholder_Envolverse;
                private Label Texto_Placeholder_Envolverse3;
                private ComboBox DropDownList_Envolverse;
        }
}