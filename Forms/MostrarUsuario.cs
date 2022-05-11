using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class MostrarUsuario : Form
    {
        private RedSocial rs;
        private Home frm;
        public MostrarUsuario(RedSocial rs1, Home frm1, Usuario u)
        {
            this.frm = frm1;
            this.rs = rs1;
            InitializeComponent();
            rs.mostrarDatos(u);
            label5.Text = u.nombre;
            label6.Text = u.apellido;
            label7.Text = u.email;
            label8.Text = u.dni.ToString();
        }
        // BUTTON 2 - CIERRA FORMULARIO
        private void button2_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }
    }
}
