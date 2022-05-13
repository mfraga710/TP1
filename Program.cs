using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    static class Program
    {        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            RedSocial rs1 = new RedSocial();
            rs1.registrarUsuario("Manuel", "Fraga", "bla@bla.com", 32982710, "1234");
            rs1.registrarUsuario("Mariano", "Rojas", "ble@ble.com", 2451231, "1234");
            rs1.registrarUsuario("Paula", "Lezcano", "blo@blo.com", 15515312, "1234");
            rs1.registrarUsuario("Mariano", "Ghislanzoni", "bli@bli.com", 15515312, "1234");


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(rs1));
        }
    }
}
