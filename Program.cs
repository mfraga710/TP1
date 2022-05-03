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
            /*Usuario user1 = new Usuario("Manuel","Fraga","bla@bla.com",32982710,"1234");
            Usuario user2 = new Usuario("Mariano", "Rojas", "ble@ble.com", 2451231, "1234");
            Usuario user3 = new Usuario("Paula", "Lezcano", "blo@blo.com", 15515312, "1234");*/
            /*Usuario user1 = new Usuario();
            user1.id = 0;
            user1.dni = 32982710;
            user1.nombre = "Manuel";
            user1.apellido = "Fraga";
            user1.email = "m.fraga710@gmail.com";
            user1.password = "123456789";
            user1.intentosFallidos = 0;
            user1.bloqueado = false;
            user1.amigos = new List<Usuario>();
            user1.misPosts = new List<Post>();
            user1.misComentarios = new List<Comentario>();
            user1.misReacciones = new List<Reaccion>();*/

            RedSocial rs1 = new RedSocial();
            rs1.registrarUsuario("Manuel", "Fraga", "bla@bla.com", 32982710, "1234");
            rs1.registrarUsuario("Mariano", "Rojas", "ble@ble.com", 2451231, "1234");
            rs1.registrarUsuario("Paula", "Lezcano", "blo@blo.com", 15515312, "1234");
            


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(rs1));
        }
    }
}
