using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class Admin : Form
    {
        private RedSocial rs;
        private Login frm;
        private DAL DB;
        public Admin(RedSocial rs1, Login formLogin)
        {
            this.rs = rs1;
            //frm = formLogin;
            DB = new DAL();
            InitializeComponent();
            refreshUsuarios();
        }


        public void refreshUsuarios()
        {
            listaUsuarios.Rows.Clear();
            foreach (Usuario user in rs.usuarios)
            {
                listaUsuarios.Rows.Add(user.id, user.nombre + " " + user.apellido);
            }
        }

        public void refreshPost()
        {
            listaUsuarios.Rows.Clear();
            foreach (Usuario user in rs.usuarios)
            {
                listaUsuarios.Rows.Add(user.id, user.nombre + " " + user.apellido);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {

            var selrow = listaUsuarios.SelectedRows;
            if (selrow.Count > 0)
            {
                int userId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Usuario u = rs.searchUser(userId);
                EditarUsuario mostrar = new EditarUsuario(rs, this, u);
                this.Enabled = false;
                mostrar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario");
            }
        }
     }
}
