using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Gestion_Productos
{
        public partial class Gestion_Productos_Quitar_Fotos : Form
        {
                public byte[][] Fotos_Producto { get; private set; }

                private void Popular_Seleccion_Fotos_DropDownList()
                {
                        for (int Indice_Foto = 0; Indice_Foto < Fotos_Producto.Length; Indice_Foto++)
                        {
                                string Item_Seleccion;
                                const string Prefijo_Item = "Imagen ";

                                Item_Seleccion = Prefijo_Item + (Indice_Foto + 1).ToString();
                                DropDown_Foto_Numero.Items.Add(Item_Seleccion);
                        }
                        DropDown_Foto_Numero_SelectedIndexChanged( this, EventArgs.Empty ) ; // Por algun motivo cuando el indice se vuelve -1 el evento no se levanta solo. No tengo npi porque.
                }

                public Gestion_Productos_Quitar_Fotos(byte[][] Fotos_Producto_En_Edicion)
                {
                        InitializeComponent();
                        Fotos_Producto = Fotos_Producto_En_Edicion;

                        Popular_Seleccion_Fotos_DropDownList();
                }

                private void DropDown_Foto_Numero_SelectedIndexChanged(object sender, EventArgs e)
                {
                        if (DropDown_Foto_Numero.SelectedItem is not null) { Button_Quitar_Foto.Enabled = true; }
                        else { Button_Quitar_Foto.Enabled = false; }
                }

                private void Button_Quitar_Foto_Click(object sender, EventArgs e)
                {
                        if (DropDown_Foto_Numero.SelectedItem is null) { throw new Exception("Se presiono el boton borrar cuando no habia ninguna foto seleccionada."); }

                        List<byte[]> Nueva_Seleccion_Fotos_Producto = Fotos_Producto.ToList();
                        Nueva_Seleccion_Fotos_Producto.RemoveAt(DropDown_Foto_Numero.SelectedIndex);
                        Fotos_Producto = Nueva_Seleccion_Fotos_Producto.ToArray();

                        DropDown_Foto_Numero.Items.Clear();
                        Popular_Seleccion_Fotos_DropDownList();
                        // DropDown_Foto_Numero.SelectedIndex = -1 ;
                }
        }
}
