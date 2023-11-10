using Logica.Sistema_de_Usuarios;

using Presentacion.Hub_Menu_Principal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
        public class Clase_Main
        {
                [STAThread]
                static void Main()
                {
                        Login.Login Instancia_Login = new Login.Login() ;
                        // Se accede al login
                        Application.Run( Instancia_Login ) ;

                        // Si no se logeo un Sujeto, termina
                        Clase_Sujeto Sujeto_Logeado = Instancia_Login.Sujeto_Operando ;
                        if ( Sujeto_Logeado is null ) { return ; }
                        
                        // Se accede al hub
                        Application.Run( new Hub_Menu_Principal.Hub_Menu_Principal( Sujeto_Logeado ) ) ;

                        // El hub controla el flujo del programa mediante dialogs. Cuando acabe el hub, se acaba todo.
                }
        }
}
