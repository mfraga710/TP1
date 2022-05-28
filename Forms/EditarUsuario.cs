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
        private Login log;

        public EditarUsuario(RedSocial rs1,Home frm1, Usuario user, Login log)
        {
            this.frm = frm1;
            this.rs = rs1;
            this.usuario = user;
            this.log = log;
            InitializeComponent();
            nombre.Text = rs.usuarioActual.nombre;
            apellido.Text = rs.usuarioActual.apellido;
            mail.Text = rs.usuarioActual.email;
            dni.Text = rs.usuarioActual.dni.ToString();
        }

        // BUTTON 1 - GUARDAR MODIFICACIONES
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            Usuario editedUsuario = rs.searchUser(usuario.id);
            editedUsuario.nombre = nombre.Text;
            editedUsuario.apellido = apellido.Text;
            editedUsuario.email = mail.Text;
            editedUsuario.dni = Convert.ToInt32(dni.Text);
            rs.modificaUsuario(editedUsuario);
            frm.labelNombreUsuario.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;
            frm.Enabled = true;
            this.Close();
        }
        // BUTTON 2 - CANCELAR Y SALIR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            rs.eliminarUsuario(usuario);
            rs.cerrarSesion(frm, log);
            this.Close();
            
        }
    }
}
