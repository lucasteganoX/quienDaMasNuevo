namespace Pruebas2
{
        partial class Form2
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
                        rjToggleButton1 = new Presentacion.Librerias_Locales.RJToggleButton();
                        SuspendLayout();
                        // 
                        // rjToggleButton1
                        // 
                        rjToggleButton1.AutoSize = true;
                        rjToggleButton1.Location = new Point(488, 187);
                        rjToggleButton1.MinimumSize = new Size(45, 22);
                        rjToggleButton1.Name = "rjToggleButton1";
                        rjToggleButton1.OffBackColor = Color.Gray;
                        rjToggleButton1.OffToggleColor = Color.Gainsboro;
                        rjToggleButton1.OnBackColor = Color.MediumSlateBlue;
                        rjToggleButton1.OnToggleColor = Color.WhiteSmoke;
                        rjToggleButton1.Size = new Size(45, 22);
                        rjToggleButton1.TabIndex = 0;
                        rjToggleButton1.UseVisualStyleBackColor = true;
                        // 
                        // Form2
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(800, 450);
                        Controls.Add(rjToggleButton1);
                        Name = "Form2";
                        Text = "Form2";
                        ResumeLayout(false);
                        PerformLayout();
                }

                #endregion

                private Presentacion.Librerias_Locales.RJToggleButton rjToggleButton1;
        }
}