using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class EditarUsuario : Form
    {
        private RedSocial rs;

        private Home frm;

        public EditarUsuario(RedSocial rs1,Home frm1)
        {
            this.frm = frm1;
            this.rs = rs1;
            InitializeComponent();
            nombre.Text = rs.usuarioActual.nombre;
            apellido.Text = rs.usuarioActual.apellido;
            mail.Text = rs.usuarioActual.email;
            dni.Text = rs.usuarioActual.dni.ToString();
        }

        // BUTTON 1 - GUARDAR MODIFICACIONES
        private void button1_Click(object sender, EventArgs e)
        {
            rs.usuarioActual.nombre = nombre.Text;
            rs.usuarioActual.apellido = apellido.Text;
            rs.usuarioActual.email = mail.Text;
            rs.usuarioActual.dni = Convert.ToInt32(dni.Text);         
            frm.label1.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;
            frm.Enabled = true;
            this.Close();
        }
        // BUTTON 2 - CANCELAR Y SALIR
        private void button2_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }
    }
}
