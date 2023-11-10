namespace Pruebas2
{
        partial class Form1
        {
                /// <summary>
                ///  Required designer variable.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                ///  Clean up any resources being used.
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
                ///  Required method for Designer support - do not modify
                ///  the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
                        components = new System.ComponentModel.Container();
                        openFileDialog1 = new OpenFileDialog();
                        saveFileDialog1 = new SaveFileDialog();
                        errorProvider1 = new ErrorProvider(components);
                        Button_Proveedores = new Button();
                        groupBox1 = new GroupBox();
                        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
                        groupBox1.SuspendLayout();
                        SuspendLayout();
                        // 
                        // errorProvider1
                        // 
                        errorProvider1.ContainerControl = this;
                        // 
                        // Button_Proveedores
                        // 
                        Button_Proveedores.BackColor = Color.SlateBlue;
                        Button_Proveedores.FlatAppearance.BorderColor = Color.Indigo;
                        Button_Proveedores.FlatAppearance.BorderSize = 2;
                        Button_Proveedores.FlatStyle = FlatStyle.Flat;
                        Button_Proveedores.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        Button_Proveedores.ForeColor = Color.LightYellow;
                        Button_Proveedores.Location = new Point(525, 7);
                        Button_Proveedores.Name = "Button_Proveedores";
                        Button_Proveedores.Size = new Size(140, 43);
                        Button_Proveedores.TabIndex = 3;
                        Button_Proveedores.Text = "Proveedores";
                        Button_Proveedores.UseVisualStyleBackColor = false;
                        // 
                        // groupBox1
                        // 
                        groupBox1.Controls.Add(Button_Proveedores);
                        groupBox1.Location = new Point(43, 153);
                        groupBox1.Name = "groupBox1";
                        groupBox1.Size = new Size(776, 125);
                        groupBox1.TabIndex = 2;
                        groupBox1.TabStop = false;
                        groupBox1.Text = "groupBox1";
                        // 
                        // Form1
                        // 
                        AutoScaleDimensions = new SizeF(8F, 20F);
                        AutoScaleMode = AutoScaleMode.Font;
                        ClientSize = new Size(800, 450);
                        Controls.Add(groupBox1);
                        Name = "Form1";
                        Text = "Form1";
                        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
                        groupBox1.ResumeLayout(false);
                        ResumeLayout(false);
                }

                #endregion
                private OpenFileDialog openFileDialog1;
                private SaveFileDialog saveFileDialog1;
                private ErrorProvider errorProvider1;
                public Button Button_Usuarios;
                public Button Button_Empleados;
                public Button Button_Proveedores;
                private GroupBox groupBox1;
        }
}