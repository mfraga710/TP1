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
        private Login frm;
        public Home(RedSocial rs1, Login formLogin)
        {
            this.rs = rs1;
            frm = formLogin;
            InitializeComponent();
            // AGREGA NOMBRE DE USUARIO
            label1.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;
            refreshAmigos();
            // AGREGA LA LISTA DE NO AMIGOS
            refreshNoAmigos();

            dataGridView1.Rows.Clear();

            // AGREGA LOS POST YA GENERADOS
            foreach (Post p in rs.posts)
            {
                string pTags = "";
                foreach (Tag t in p.tags)
                {
                    pTags = pTags + t.palabra + " ";
                }

                dataGridView1.Rows.Add(p.id, p.user.nombre + " " + p.user.apellido, p.contentido, pTags);
            }
        }

        // PICTURE BOX 1 - MUESTRA LOS AMIGOS A AGREGAR
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label3.Show();
            dataGridView3.Show();
            button1.Show();
            button2.Show();
            
        }

        // BUTTON 1 - AGREGA AMIGO
        private void button1_Click_1(object sender, EventArgs e)
        {
            var selrow = dataGridView3.SelectedRows;
            int amigoId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                foreach (Usuario u in rs.usuarios)
                {
                    if (u.id == amigoId)
                    {
                        rs.agregarAmigo(u);
                        dataGridView3.Rows.Remove(selrow[0]);
                        refreshAmigos();
                        break;
                    }
                }
        }

        // BUTTON 2 - CIERRA LISTBOX 2
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label3.Visible = false;
            dataGridView3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        // PICTUREBOX 2 - ELIMINA AMIGO
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView4.SelectedRows;
            int amigoId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
            foreach (Usuario u in rs.usuarios)
            {
                if (u.id == amigoId)
                {
                    rs.quitarAmigo(u);
                    dataGridView4.Rows.Remove(selrow[0]);
                    refreshAmigos();
                    refreshNoAmigos();
                    break;
                }
            }
        }

        // BUTTON 3 - POSTEA
        private void button3_Click(object sender, EventArgs e)
        {
            Post post = new Post(rs.usuarioActual,textBox1.Text);
            List<Tag> tags = new List<Tag>();
            string[] sTags = textBox2.Text.Split('#');
            foreach (var word in sTags)
            {
                if (word.Length > 1)
                {
                    if (rs.tags.Count > 0)
                    {
                        foreach (Tag tag in rs.tags)
                        {
                            if (!tag.palabra.Equals("#" + word))
                            {
                                tags.Add(new Tag("#" + word));
                            }
                        }
                    }
                    else
                    {
                        tags.Add(new Tag("#" + word));
                    }
                }
            }    

            rs.postear(post, tags);
            
            dataGridView1.Rows.Clear();

            foreach (Post p in rs.posts)
            {
                string pTags = "";
                foreach (Tag t in p.tags)
                {
                    pTags = pTags + t.palabra + " " ;
                }

                dataGridView1.Rows.Add(p.id,p.user.nombre + " " + p.user.apellido, p.contentido, pTags);                
            }
            
            textBox1.Clear();
            textBox2.Clear();
            MessageBox.Show("Su posteo ha sido publicado correctamente");
        }

        // BUTTON 4 - COMENTA EL POST
        private void button4_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());

            foreach(Post p in rs.posts)
            {
                if (p.id == postId)
                {      
                    string contenido = textBox3.Text;
                    Comentario coment = new Comentario(p, rs.usuarioActual, contenido);
                    rs.comentar(p, coment);
                    refreshList(p);
                }
            }
            textBox3.Clear();
            MessageBox.Show("Su comentario ha sido ingresado correctamente");
        }

        // BUTTON 6 - EDITAR USUARIO
        private void button6_Click(object sender, EventArgs e)
        {
            EditarUsuario edit = new EditarUsuario(rs,this, searchUser(rs.usuarioActual.id));
            this.Enabled = false;         
            edit.Show();            
        }

        // BUTTON 7 - MODIFICAR POST
        private void button7_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
            Posteos edit = new Posteos(rs, this, postId);
            this.Enabled = false;
            edit.Show();
        }

        // BUTTON 7 - ELIMINAR POST
        private void button8_Click(object sender, EventArgs e)
        {
            Post pBorrar = null;
            var selrow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());            

            foreach (Post p in rs.posts)
            {
                if (p.id == postId)
                {
                    pBorrar = p;
                    break;
                }
            }
            if (pBorrar == null)
            {
                MessageBox.Show("El registro seleccionado no existe");
            }
            else
            {
                dataGridView1.Rows.RemoveAt(postId);
                rs.eliminarPost(pBorrar);
                dataGridView2.Rows.Clear();
            }
            
            MessageBox.Show("Su posteo ha sido eliminado correctamente");
        }

        // CERRAR SESION
        private void button9_Click(object sender, EventArgs e)
        {
            rs.cerrarSesion(this,frm);
        }

        // BUTTON 10 - MOSTRAR DATOS
        private void button10_Click(object sender, EventArgs e)
        {
            MostrarUsuario mostrar = new MostrarUsuario(rs, this, rs.usuarioActual);
            this.Enabled = false;
            mostrar.Show();
        }

        // BUTTON 11 - EDITAR COMENTARIO
        private void button11_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView2.SelectedRows;
            var selPostrow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());

            // selrow.Count para que no pinche cuando no se selecciona ningún comentario
            if (selrow == null || selrow.Count <= 0)
            {
                MessageBox.Show("Por favor seleccione un comentario a modificar");
            }
            else
            {
                int comtId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                EditarComentario edit = new EditarComentario(rs, this, comtId, postId);
                this.Enabled = false;
                edit.Show();
            }
        }
        // BUTTON 5 - ELIMINA COMENTARIO
        private void button5_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView2.SelectedRows;
            int commentId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
            var selPostRow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selPostRow[0].Cells[0].Value.ToString());

            rs.quitarComentario(searchPost(postId), searchComent(commentId));
            refreshCommentsGrid();
        }
        // IDENTIFICADOR DE COMENTARIO
        public Comentario searchComent(int id)
        {
            foreach (Post p in rs.posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == id)
                    {
                        return c;
                    }
                }
            }
            return null;
        }
        // IDENTIFICADOR DE POST
        public Post searchPost(int idPost)
        {
            foreach (Post p in rs.posts)
            {
                if (idPost == p.id)
                {
                    return p;
                }
            }
            return null;
        }
        // IDENTIFICADOR DE USUARIO
        public Usuario searchUser(int idUser)
        {
            foreach (Usuario u in rs.usuarios)
            {
                if (idUser == u.id)
                {
                    return u;
                }
            }
            return null;
        }
        // IDENTIFICADOR DEL ID DEL POST
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selrow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());

            foreach (Post p in rs.posts)
            {
                if (p.id == postId)
                {
                    refreshList(p);
                }
            }
        }
        // RECARGAR COMENTARIOS
        public void refreshCommentsGrid()
        {
            dataGridView2.Rows.Clear();
            foreach (Post p in rs.posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    dataGridView2.Rows.Add(c.id, c.usuario.nombre + " " + c.usuario.apellido, c.contenido);
                }
            }
        }
        // FUNCION QUE REFRESCA LISTA NO AMIGO
        public void refreshNoAmigos()
        {
            dataGridView3.Rows.Clear();
            // VERIFICA QUE NO TENGA AMIGOS
            if (rs.usuarioActual.amigos.Count <= 0)
            {   // CARGA TODOS LOS USUARIOS
                foreach (Usuario user in rs.usuarios)
                {
                    if (user.id != rs.usuarioActual.id)
                    {
                        dataGridView3.Rows.Add(user.id, user.nombre + " " + user.apellido);
                    }
                }
            }
            else
            {   // TRAE TODAS LA LISTA DE USUARIOS QUE NO AMIGOS
                foreach (Usuario amigo in rs.usuarioActual.amigos)
                {   // INDICADOR DE NO AMIGO
                    bool isnotamego = true;
                    foreach (Usuario user in rs.usuarios) // VERIFICA QUE EL NO AMIGO LO TENGA
                    {
                        if (user.id == amigo.id)
                            isnotamego = false;
                    }
                    if (isnotamego) // AGREGA A LA LISTA
                        dataGridView3.Rows.Add(amigo.id, amigo.nombre + " " + amigo.apellido);
                }
            }
        }

        // FUNCION QUE REFRESCA LISTA DE AMIGO
        public void refreshAmigos()
        {
            dataGridView4.Rows.Clear();
            foreach (Usuario user in rs.usuarioActual.amigos)
            {
                dataGridView4.Rows.Add(user.id, user.nombre + " " + user.apellido);
            }
        }
        // RECARGAR LA LISTA DE POST
        private void refreshList(Post p)
        {
            dataGridView2.Rows.Clear();
            foreach (Comentario c in p.comentarios)
            {
                dataGridView2.Rows.Add(c.id, c.usuario.nombre + " " + c.usuario.apellido, c.contenido);
            }
        }
        // BOTON MOSTRAR MIS POSTS
        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<Post> po = rs.mostrarPosts();
            foreach (Post p in po)
            {
                string pTags = "";
                foreach (Tag t in p.tags)
                {
                    pTags = pTags + t.palabra + " ";
                }
                dataGridView1.Rows.Add(p.id, p.user.nombre + " " + p.user.apellido, p.contentido, pTags);
            }
        }
    }
}
