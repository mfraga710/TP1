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
            frm = formLogin;
            DB = new DAL();
            InitializeComponent();
            refreshUsuarios();
            refreshTags();
            refreshPost();
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
            listadoPost.Rows.Clear();
            foreach (Post post in rs.posts)
            {
                listadoPost.Rows.Add(post.id, post.user.nombre + " " + post.user.apellido, post.contenido);
            }
        }


        public void refreshTags()
        {
            listadoTags.Rows.Clear();
            foreach (Tag t in rs.tags)
            {
                listadoTags.Rows.Add(t.id, t.palabra);
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

        private void button4_Click(object sender, EventArgs e)
        {
            rs.cerrarSesionAdm(this, frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selrow = listadoPost.SelectedRows;
            if (selrow.Count > 0)
            {
                int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Post p = rs.searchPost(postId);
                AdminPosts adminPost = new AdminPosts(rs, this, p);
                this.Enabled = false;
                adminPost.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Post");
            }
        }

        private void eliminarTag_Click(object sender, EventArgs e)
        {
           /* var selrow = listadoTags.SelectedRows;
            if (selrow.Count > 0)
            {
                EliminarTags.Enabled = true;
                int tagId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                List<tag> t = rs.tag;
                rs.eliminarTag(t);
                refreshPost();
                MessageBox.Show("El post fue borrado");
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Post");
            }*/

        }

        private void eliminarPost_Click(object sender, EventArgs e)
        {
            var selrow = listadoPost.SelectedRows;
            if (selrow.Count > 0)
            {
                int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Post p = rs.searchPost(postId);
                rs.eliminarPost(p);
                refreshPost();
                MessageBox.Show("El post fue borrado");
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Post");
            }
        }
    }
}
