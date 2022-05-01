using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class Login : Form
    {
        private RedSocial rs;

        public Login(RedSocial rs1)
        {
            this.rs = rs1;
            InitializeComponent();
        }

        public Login(Login formLogin)
        {
            //this.rs = rs1;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(rs.IniciarSesion(textBox1.Text, textBox2.Text))
            {
                this.Hide();
                Forms.Home home = new Forms.Home(rs);                
                home.Show();
            }
            else
            {
                label7.Show();
                label7.Text = "Inicio de sesión Fallido, quedan 2 intentos";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro reg = new Registro(rs, this);
            this.Enabled = false;
            reg.Show();
        }
    }
}
