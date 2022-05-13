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
        private Usuario usuario;
        private Home frm;

        public EditarUsuario(RedSocial rs1,Home frm1, Usuario user)
        {
            this.frm = frm1;
            this.rs = rs1;
            this.usuario = user;
            InitializeComponent();
            nombre.Text = rs.usuarioActual.nombre;
            apellido.Text = rs.usuarioActual.apellido;
            mail.Text = rs.usuarioActual.email;
            dni.Text = rs.usuarioActual.dni.ToString();
        }

        // BUTTON 1 - GUARDAR MODIFICACIONES
        private void button1_Click(object sender, EventArgs e)
        {
            string newNom = nombre.Text;
            string newApe = apellido.Text;
            string newEmail = mail.Text;
            int newDni = Convert.ToInt32(dni.Text);
            Usuario editedUsuario = frm.searchUser(usuario.id);
            editedUsuario.nombre = newNom;
            editedUsuario.apellido = newApe;
            editedUsuario.email = newEmail;
            editedUsuario.dni = newDni;
            rs.modificaUsuario(editedUsuario);
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
