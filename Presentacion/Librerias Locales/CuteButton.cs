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
        public partial class CuteButton : Control
        {
                public CuteButton()
                {
                        InitializeComponent();
                }

                protected override void OnPaint(PaintEventArgs pe)
                {
                        base.OnPaint(pe);
                }
        }
}
