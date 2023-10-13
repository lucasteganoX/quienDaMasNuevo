namespace Presentacion.Gestion_Productos.Manejo_de_Fotos
{
        partial class Visualizar_Foto
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
                        PictureBox_Foto = new PictureBox();
                        ((System.ComponentModel.ISupportInitialize)PictureBox_Foto).BeginInit();
                        SuspendLayout();
                        // 
                        // PictureBox_Foto
                        // 
                        PictureBox_Foto.Location = new Point(12, 12);
                        PictureBox_Foto.Name = "PictureBox_Foto";
                        PictureBox_Foto.Size = new Size(776, 426);
                        PictureBox_Foto.TabIndex = 0;
                        PictureBox_Foto.TabStop = false;
                        // 
                        // Visualizar_Foto
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(800, 450);
                        Controls.Add(PictureBox_Foto);
                        Name = "Visualizar_Foto";
                        Text = "Visualizar Foto";
                        ((System.ComponentModel.ISupportInitialize)PictureBox_Foto).EndInit();
                        ResumeLayout(false);
                }

                #endregion

                private PictureBox PictureBox_Foto;
        }
}