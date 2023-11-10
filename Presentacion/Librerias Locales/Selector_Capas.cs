using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Librerias_Locales
{
        public enum Caracterizacion_Formulario
        {
                Personas,
                Usuarios,
                Empleados,
                Proveedores
        }

        public class Selector_Capas : Panel
        {
                // Siendo Selector de Capas una clase y siendo el Formulario de Administracion de Usuarios una clase totalmente diferente...
                // No es posible asignar un handler que pertenece a una instancia de el formulario a una instancia de el Selector de Capas es necesario hacer cambios a la arquitectura
                // de ambos para que tal cosa sea posible.

                // La mas rapida y sencilla seria hacer que los botones que aparecen en el selector "pertenezcan" al formulario y no al selector; osea que sean definidos en el scope
                // del formulario, esto rompe la encapsulacion logica que tiene el selector con el formulario y hasta cierto punto viola la modularidad de ese elemento en el formulario
                // , la cual busco para simplificar el diseno del formulario. Ninguna de las dos cosas me agrada, para nada.

                // Termine optando por crear una clase capaz de alterarse a si misma en vez de requerir ser reconstruida.
                // Asi que para probocar un cambio en el selector, en vez de recontruirlo para que sea de diferente forma, opto por que el objeto del selector sea capaz de cambiarse a 
                // si mismo para que se vuelva de la manera que se espera que sea. Con esto me evito el lio de sincronizar instancias y/o referencias/acceso por parte de las instnacia
                // s del selector y el formulario.
                // Esto parece ir en contra de la mayoria de sistemas creados en C# como por ejemplo los componentes graficos y demas donde se da ese "cambio por recontruccion" en vez
                // de este "cambio por alteracion", pero creo que la simplicidad que aporta vale romper con ese paradigma tan comun.

#if DEBUG_Administracion_Sujetos
                public Button Button_Personas;
                public Button Button_Usuarios;
                public Button Button_Empleados;
                public Button Button_Proveedores;
#else
                private Button Button_Personas;
                private Button Button_Usuarios;
                private Button Button_Empleados;
                private Button Button_Proveedores;
#endif
                // Los botones siguen el orden: Personas, Usuarios, Empleados, Proveedores

                public Caracterizacion_Formulario? Caracterizacion_Actual = null;
                public bool La_Caracterizacion_Ha_Cambiado;

                const int Location_x_Primer_Boton = 26,
                                Location_x_Segundo_Boton = 233,
                                Location_x_Tercer_Boton = 379,
                                Location_x_Cuarto_Boton = 525 ;

                const int Location_y_Primer_Boton = 7,
                                Location_y_Segundo_Boton = 7,
                                Location_y_Tercer_Boton = 7,
                                Location_y_Cuarto_Boton = 7;

                readonly Point Location_Primer_Boton = new Point( x: Location_x_Primer_Boton, y: Location_y_Primer_Boton ) ;
                readonly Point Location_Segundo_Boton = new Point( x: Location_x_Segundo_Boton, y: Location_y_Segundo_Boton ) ;
                readonly Point Location_Tercer_Boton = new Point( x: Location_x_Tercer_Boton, y: Location_y_Tercer_Boton ) ;
                readonly Point Location_Cuarto_Boton = new Point( x: Location_x_Cuarto_Boton, y: Location_y_Cuarto_Boton ) ;
                // Curiosamente no te deja asignarle el mismo valor a todas... Nc si es una opcion del compilador o algo.
                // En linea encontre ejemplos de gente haciendolo, pero si lo hago de esa manera solo asigna la ultima variable, bueh :(

# if DEBUG_Administracion_Sujetos
                public
# else
                private
# endif
                        void Recaracterizar(Caracterizacion_Formulario Boton_Seleccionado)
                { // Se encarga de alterar el formulario poniendo los botones en su posicion correcta, en base al boton que fue seleccionado, el cual va primero.
                        if (Boton_Seleccionado == Caracterizacion_Actual) { return; }
                        switch (Boton_Seleccionado)
                        {
                                case Caracterizacion_Formulario.Personas:
                                        Button_Personas.Location = Location_Primer_Boton ;
                                        Button_Usuarios.Location = Location_Segundo_Boton ;
                                        Button_Empleados.Location = Location_Tercer_Boton ;
                                        Button_Proveedores.Location = Location_Cuarto_Boton ;
                                        break;
                                case Caracterizacion_Formulario.Usuarios:
                                        Button_Usuarios.Location = Location_Primer_Boton ;
                                        Button_Personas.Location = Location_Segundo_Boton ;
                                        Button_Empleados.Location = Location_Tercer_Boton ;
                                        Button_Proveedores.Location = Location_Cuarto_Boton ;
                                        break;
                                case Caracterizacion_Formulario.Empleados:
                                        Button_Empleados.Location = Location_Primer_Boton ;
                                        Button_Personas.Location = Location_Segundo_Boton ;
                                        Button_Usuarios.Location = Location_Tercer_Boton ;
                                        Button_Proveedores.Location = Location_Cuarto_Boton ;
                                        break;
                                case Caracterizacion_Formulario.Proveedores:
                                        Button_Proveedores.Location = Location_Primer_Boton ;
                                        Button_Personas.Location = Location_Segundo_Boton ;
                                        Button_Usuarios.Location = Location_Tercer_Boton ;
                                        Button_Empleados.Location = Location_Cuarto_Boton ;
                                        break;
                        }
                        Caracterizacion_Actual = Boton_Seleccionado;
                }

                private void Recaracterizar_Selector_Para_Personas(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Personas); La_Caracterizacion_Ha_Cambiado = true; }
                private void Recaracterizar_Selector_Para_Usuarios(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Usuarios); La_Caracterizacion_Ha_Cambiado = true; }
                private void Recaracterizar_Selector_Para_Empleados(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Empleados); La_Caracterizacion_Ha_Cambiado = true; }
                private void Recaracterizar_Selector_Para_Proveedores(object? sender, EventArgs e) { Recaracterizar(Caracterizacion_Formulario.Proveedores); La_Caracterizacion_Ha_Cambiado = true; }


                public Selector_Capas() : base()
                {
                        // El contructor se encarga de caracterizar adecuadamente el Panel en el que el selector opera.
                        // Y ademas se encarga de hacer que el Selector sea caracterizado con el boton `Usuarios` seleccionado por defecto.
                        // Para hacer que el selector sea diferente, llama al metodo `Recaracterizar`, no crees una nueva instancia del selector.
                        // Lee el comentario que esta al inicio de la clase para mas informacion.

                        { // Caracteriza el Panel 
                                this.Name = "Panel_Selector_Capas";
                                this.Location = new Point(23, 12);
                                this.BorderStyle = BorderStyle.FixedSingle ;
                                this.Size = new Size(691, 58);
                                this.TabIndex = 3;
                        }

                        { // Define los botones del selector, sin definir su posicion.
                                Button_Personas = new Button();
                                {
                                        Button_Personas.BackColor = Color.YellowGreen;
                                        Button_Personas.FlatAppearance.BorderColor = Color.OliveDrab;
                                        Button_Personas.FlatAppearance.BorderSize = 2;
                                        Button_Personas.FlatStyle = FlatStyle.Flat;
                                        Button_Personas.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                        Button_Personas.ForeColor = Color.LightYellow;
                                        //  Button_Personas.Location = new Point(233, 7);
                                        Button_Personas.Name = "Button_Personas";
                                        Button_Personas.Size = new Size(140, 43);
                                        Button_Personas.TabIndex = 1;
                                        Button_Personas.Text = "Personas";
                                        Button_Personas.UseVisualStyleBackColor = false;

                                        Button_Personas.Click += Recaracterizar_Selector_Para_Personas;
                                }

                                Button_Usuarios = new Button();
                                {
                                        Button_Usuarios.BackColor = Color.DarkCyan;
                                        Button_Usuarios.FlatAppearance.BorderColor = Color.DarkSlateGray;
                                        Button_Usuarios.FlatAppearance.BorderSize = 2;
                                        Button_Usuarios.FlatStyle = FlatStyle.Flat;
                                        Button_Usuarios.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                        Button_Usuarios.ForeColor = Color.LightYellow;
                                        // Button_Usuarios.Location = new Point(26, 7);
                                        Button_Usuarios.Name = "Button_Usuarios";
                                        Button_Usuarios.Size = new Size(140, 43);
                                        Button_Usuarios.TabIndex = 0;
                                        Button_Usuarios.Text = "Usuarios";
                                        Button_Usuarios.UseVisualStyleBackColor = false;

                                        Button_Usuarios.Click += Recaracterizar_Selector_Para_Usuarios;
                                }

                                Button_Empleados = new Button();
                                {
                                        Button_Empleados.BackColor = Color.FromArgb(255, 140, 50);
                                        Button_Empleados.FlatAppearance.BorderColor = Color.Sienna;
                                        Button_Empleados.FlatAppearance.BorderSize = 2;
                                        Button_Empleados.FlatStyle = FlatStyle.Flat;
                                        Button_Empleados.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                        Button_Empleados.ForeColor = Color.LightYellow;
                                        // Button_Empleados.Location = new Point(379, 7);
                                        Button_Empleados.Name = "Button_Empleados";
                                        Button_Empleados.Size = new Size(140, 43);
                                        Button_Empleados.TabIndex = 2;
                                        Button_Empleados.Text = "Empleados";
                                        Button_Empleados.UseVisualStyleBackColor = false;

                                        Button_Empleados.Click += Recaracterizar_Selector_Para_Empleados;
                                }

                                Button_Proveedores = new Button();
                                {
                                        Button_Proveedores.BackColor = Color.SlateBlue;
                                        Button_Proveedores.FlatAppearance.BorderColor = Color.Indigo;
                                        Button_Proveedores.FlatAppearance.BorderSize = 2;
                                        Button_Proveedores.FlatStyle = FlatStyle.Flat;
                                        Button_Proveedores.Font = new Font("Leelawadee", 9F, FontStyle.Bold, GraphicsUnit.Point);
                                        Button_Proveedores.ForeColor = Color.LightYellow;
                                        // Button_Proveedores.Location = new Point(525, 7);
                                        Button_Proveedores.Name = "Button_Proveedores";
                                        Button_Proveedores.Size = new Size(140, 43);
                                        Button_Proveedores.TabIndex = 3;
                                        Button_Proveedores.Text = "Proveedores";
                                        Button_Proveedores.UseVisualStyleBackColor = false;

                                        Button_Proveedores.Click += Recaracterizar_Selector_Para_Proveedores;
                                }
                        }

                        { // Agrega los botones YA INICIALIZADOS a la coleccion de controles
                                this.Controls.Add(Button_Personas);
                                this.Controls.Add(Button_Usuarios);
                                this.Controls.Add(Button_Empleados);
                                this.Controls.Add(Button_Proveedores);
                        }

                        { // Caracteriza el selector de forma que el boton seleccionado sea el boton `Usuarios` 
                                this.Recaracterizar(Caracterizacion_Formulario.Usuarios);
                        }
                }
        }
}
