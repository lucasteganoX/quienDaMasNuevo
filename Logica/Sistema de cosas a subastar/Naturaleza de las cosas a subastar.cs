using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Logica.Sistema_de_cosas_a_subastar
{
        public class Naturaleza_de_las_cosas_a_subastar // Esto deberia ser un namespace, no una clase, no me di cuenta lol
        {
                public class Elemento_Subasta
                { 
                        public int ID { get; set; }
                        public int? Precio_Base { get; set; }
                        public int Valor { get; set; }
                        // Puja[] Pujas hechas por el elemento
                        public bool Habilitado
                        { 
                                get { return Habilitado ; }
                                set
                                { 
                                        if ( value == true )
                                        {
                                                if ( Valor == 0 ) { throw new ArgumentException("No se puede habilitar un Elemento de Subasta que no tiene un Valor(mayor a cero).") ; }
                                                Habilitado = value ;        
                                        }
                                }
                        }

                        protected Elemento_Subasta() { }
                        protected Elemento_Subasta
                        (
                            int Parametro_ID,
                            int Parametro_Precio_Base = 0,
                            int Valor = 0,
                            // Puja[] Parametro_Pujas_ = new Pujas[] {}
                            bool Parametro_Habilitado = false
                        )
                        {
                                ID = Parametro_ID ;
                                Precio_Base = Parametro_Precio_Base ;
                                // Pujas hechas por el elemento = Parametro_Pujas_ ;
                                Habilitado = Parametro_Habilitado ;
                        }
                }

                public class Lote : Elemento_Subasta
                {
                        // int ID_Lote { get; set; }
                        Producto[] Productos_Lote { get; set; }

                        public Lote
                        ( 
                            int Parametro_ID,
                            // Puja[] Pujas
                            int Parametro_Precio_Base,

                            Producto[] Parametro_Productos_Lote,

                            int Parametro_Valor = 0,
                            bool Parametro_Habilitado = false
                        )
                        {
                                { // Construccion Elemento Subasta
                                        ID = Parametro_ID ;
                                        Valor = Parametro_Valor ;
                                        Precio_Base = Parametro_Precio_Base ;
                                        Habilitado = Parametro_Habilitado ;
                                }

                                { // Construccion Lote
                                        Productos_Lote = Parametro_Productos_Lote ;       
                                }
                        }
                }

                public class Producto : Elemento_Subasta
                {
                        public string Nombre { get; set; }
                        public byte[][]? Fotos { get; set; }

                        public Producto() { }
                        public Producto
                        (
                            int Parametro_ID,
                            string Parametro_Nombre,

                            int Parametro_Valor = 0,
                            // Puja[] Pujas = new Puja[] {}
                            int Parametro_Precio_Base = 0,
                            bool Parametro_Habilitado = false
                        )
                        {
                                { // Construccion Elemento Subasta
                                        ID = Parametro_ID ;   
                                        Valor = Parametro_Valor ;
                                        Precio_Base = Parametro_Precio_Base ;
                                        Habilitado = Parametro_Habilitado ;
                                }

                                { // Construccion Producto
                                        Nombre = Parametro_Nombre ;
                                }
                        }
                }

                public enum Tipos_Mano
                { 
                        Primera_Mano,
                        Segunda_Mano,
                        Tercera_Mano
                }
                public enum Tipos_Maquinaria
                { 
                        Tractor,
                        Retroexcavadora,
                        Camion,
                        Camioneta,
                        Fumigadora,
                        Cosechadora,
                        Sembradora,
                        Fertilizadora,
                        Tolva,
                        Otra
                }
                public class Maquinaria : Producto
                {
                        public string Marca { get; set; }
                        public string Modelo { get; set; }
                        public int Numero_Serie { get; set; }
                        public bool No_Tiene_Uso { get; set; }
                        public Tipos_Mano Historial_Propiedad { get; set; }
                        public Tipos_Maquinaria Tipo_Maquinaria { get; set; }

                        public Maquinaria
                        (
                            // Maquinaria
                            string Parametro_Marca,
                            string Parametro_Modelo,
                            int Parametro_Numero_serie,
                            bool Parametro_No_Tiene_Uso,
                            Tipos_Mano Parametro_Historia_Propiedad,
                            Tipos_Maquinaria Parametro_Tipo_Maquinaria,
                            
                            // Producto
                            string Parametro_Nombre,


                            // Elemento Subasta
                            int Parametro_Valor = 0,
                            int Parametro_Precio_Base = 0,
                            bool Parametro_Habilitado = false,

                            // Producto
                            byte[][]? Parametro_Fotos = null
                        )
                        {
                                { // Construccion Elemento Subasta
                                        Valor = Parametro_Valor ;
                                        Precio_Base = Parametro_Precio_Base ;
                                        Habilitado = Parametro_Habilitado ;
                                }

                                { // Construccion Producto
                                        Nombre = Parametro_Nombre ;
                                        Fotos = Parametro_Fotos ;
                                }

                                { // Construccion Maquinaria
                                        Marca = Parametro_Marca ;
                                        Modelo = Parametro_Modelo ;
                                        Numero_Serie = Parametro_Numero_serie ;
                                        No_Tiene_Uso = Parametro_No_Tiene_Uso ;
                                        Historial_Propiedad = Parametro_Historia_Propiedad ;
                                        Tipo_Maquinaria = Parametro_Tipo_Maquinaria ;
                                }
                        }
                }

                public enum Sexo_Animal
                {
                        Macho,
                        Hembra
                } 
                public class Animal : Producto
                { 
                        public Sexo_Animal Sexo { get; set; }
                        public int Edad { get; set; }
                        public bool Esta_Castrado { get; set; }
                        public string Raza { get; set; } // Esto podria ser representado en un enum
                        public int Peso { get; set; }

                        public Animal() { }
                        public Animal
                        (
                            int Parametro_ID,

                            string Parametro_Nombre,

                            Sexo_Animal Parametro_Sexo,
                            int Parametro_Edad,
                            bool Parametro_Esta_Castrado,
                            string Parametro_Raza,
                            int Parametro_Peso,


                            int Parametro_Valor = 0,
                            int Parametro_Precio_Base = 0,
                            bool Parametro_Habilitado = false,
                            byte[][]? Parametro_Fotos = null
                        )
                        {
                                { // Construccion Elemento Subasta
                                        ID = Parametro_ID ;   
                                        Valor = Parametro_Valor ;
                                        Precio_Base = Parametro_Precio_Base ;
                                        Habilitado = Parametro_Habilitado ;
                                }

                                { // Construccion Producto 
                                        Nombre = Parametro_Nombre ;
                                        Fotos = Parametro_Fotos ;
                                }

                                { // Construccion Animal
                                        Sexo = Parametro_Sexo ;
                                        Edad = Parametro_Edad ;
                                        Esta_Castrado = Parametro_Esta_Castrado ;
                                        Raza = Parametro_Raza ;
                                        Peso = Parametro_Peso ;
                                }
                        }
                }

                # region >>---- Subclases de Animal
                public enum Especializacion_Vacuna
                { 
                        Produccion_Leche,
                        Produccion_Carne,
                        Exposicion,
                        Cria,
                        Ninguna,

                        // Alias:
                        Competicion = Exposicion,
                        Reproduccion = Cria,
                        Otra = Ninguna  // Que malvado jajajajaja
                }
                public class Vacuno : Animal
                {
                        Especializacion_Vacuna Especializacion { get; set; }

                        public Vacuno
                        (
                            int Parametro_ID,

                            string Parametro_Nombre,

                            Sexo_Animal Parametro_Sexo,
                            int Parametro_Edad,
                            bool Parametro_Esta_Castrado,
                            string Parametro_Raza,
                            int Parametro_Peso,

                            Especializacion_Vacuna Parametro_Especializacion,

                            int Parametro_Valor = 0,
                            int Parametro_Precio_Base = 0,
                            bool Parametro_Habilitado = false
                        )
                        { 
                                { // Construccion Elemento Subasta
                                        ID = Parametro_ID ;   
                                        Valor = Parametro_Valor ;
                                        Precio_Base = Parametro_Precio_Base ;
                                        Habilitado = Parametro_Habilitado ;
                                }

                                { // Construccion Producto 
                                        Nombre = Parametro_Nombre ;
                                }

                                { // Construccion Animal
                                        Sexo = Parametro_Sexo ;
                                        Edad = Parametro_Edad ;
                                        Esta_Castrado = Parametro_Esta_Castrado ;
                                        Raza = Parametro_Raza ;
                                        Peso = Parametro_Peso ;
                                }

                                { // Construccion Vacuno 
                                        Especializacion = Parametro_Especializacion ;
                                }
                        }
                }

                public enum Especializacion_Equina
                {
                        Carreras,
                        Salto,
                        Trabajo,
                        Exposicion,
                        Reproduccion,
                        Ninguna,

                        // Alias:
                        Cria = Reproduccion,
                        Otra = Ninguna
                }
                public class Equino : Animal
                {
                        Especializacion_Equina Especializacion { get; set; }

                        public Equino() { }
                        public Equino
                        (
                            int Parametro_ID,

                            string Parametro_Nombre,

                            Sexo_Animal Parametro_Sexo,
                            int Parametro_Edad,
                            bool Parametro_Esta_Castrado,
                            string Parametro_Raza,
                            int Parametro_Peso,

                            Especializacion_Equina Parametro_Especializacion,

                            int Parametro_Valor = 0,
                            int Parametro_Precio_Base = 0,
                            bool Parametro_Habilitado = false
                        )
                        {
                                { // Construccion Elemento Subasta
                                        ID = Parametro_ID ;   
                                        Valor = Parametro_Valor ;
                                        Precio_Base = Parametro_Precio_Base ;
                                        Habilitado = Parametro_Habilitado ;
                                }

                                { // Construccion Producto 
                                        Nombre = Parametro_Nombre ;
                                }

                                { // Construccion Animal
                                        Sexo = Parametro_Sexo ;
                                        Edad = Parametro_Edad ;
                                        Esta_Castrado = Parametro_Esta_Castrado ;
                                        Raza = Parametro_Raza ;
                                        Peso = Parametro_Peso ;
                                }

                                { // Construccion Equino
                                        Especializacion = Parametro_Especializacion ;
                                }   
                        }
                }

                public enum Especializacion_Ovina
                { 
                        Produccion_Lana,
                        Produccion_Carne,
                        Cria,
                        Ninguna
                }
                public class Ovino : Animal
                {
                        Especializacion_Ovina Especializacion { get; set; }

                        public Ovino() { }
                        public Ovino
                        (
                            int Parametro_ID,

                            string Parametro_Nombre,

                            Sexo_Animal Parametro_Sexo,
                            int Parametro_Edad,
                            bool Parametro_Esta_Castrado,
                            string Parametro_Raza,
                            int Parametro_Peso,

                            Especializacion_Ovina Parametro_Especializacion,

                            int Parametro_Valor = 0,
                            int Parametro_Precio_Base = 0,
                            bool Parametro_Habilitado = false
                        )
                        {
                                { // Construccion Elemento Subasta
                                        ID = Parametro_ID ;   
                                        Valor = Parametro_Valor ;
                                        Precio_Base = Parametro_Precio_Base ;
                                        Habilitado = Parametro_Habilitado ;
                                }

                                { // Construccion Producto 
                                        Nombre = Parametro_Nombre ;
                                }

                                { // Construccion Animal
                                        Sexo = Parametro_Sexo ;
                                        Edad = Parametro_Edad ;
                                        Esta_Castrado = Parametro_Esta_Castrado ;
                                        Raza = Parametro_Raza ;
                                        Peso = Parametro_Peso ;
                                }

                                { // Construccion Equino
                                        Especializacion = Parametro_Especializacion ;
                                }   
                        }
                }
                // Podria convinar las Especializaciones y volverlas un atributo de la clase `Animal` ya que son tan similares, pero por ahora hacerlo asi es el camino de menor resistencia. Despues si me queda tiempo lo cambiare.
                # endregion
        }
}
