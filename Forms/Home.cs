using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class Home : Form
    {
        private RedSocial rs;
        public Home(RedSocial rs1)
        {
            this.rs = rs1;
            InitializeComponent();
            label1.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.BuscadorAmigos buscador = new Forms.BuscadorAmigos(rs);
            
            buscador.Show();

            /*Usuario user2 = new Usuario("Mariano", "Rojas", "ble@ble.com", 2451231, "1234");
            rs.agregarAmigo(user2);
            listBox1.Items.Add(user2.nombre + " " + user2.apellido);*/
        }

        private void form_closing() 
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Forms.BuscadorAmigos buscador = new Forms.BuscadorAmigos(rs);

            buscador.Show();
        }
    }
}
