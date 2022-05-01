using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1
{
    public partial class Registro : Form
    {
        private RedSocial rs = new RedSocial();

        public Registro(RedSocial rs1)
        {
            this.rs = rs1;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crearButton_Click(object sender, EventArgs e)
        {
            int dni1 = Convert.ToInt32(dni.Text);
            if (password.Text.Equals(rpassword.Text))
            {
                rs.RegistrarUsuario(nombre.Text, apellido.Text, mail.Text, dni1, password.Text);
                MessageBox.Show("Su usuario ha sido creado correctamente. Ya puede iniciar sesion.");
                this.Close();
            }
            else
            {
                label7.Show();
                label7.Text = "La contraseña no coincide, PONELE VOLUNTAAAA";
            }
        }
    }
}
