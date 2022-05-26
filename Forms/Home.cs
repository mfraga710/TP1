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
            
            refreshNoAmigos();

            refreshHomePosts(rs.posts);

            dataGridView1.Rows.Clear();
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
            agregarAmigo();
        }
        private void agregarAmigo()
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
            eliminarAmigo();
        }

        private void eliminarAmigo()
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
            string[] sTags = textBox2.Text.Split('#');
            
            rs.postear(post, crearTag());
            refreshHomePosts(rs.posts);
            textBox1.Clear();
            textBox2.Clear();
            MessageBox.Show("Su posteo ha sido publicado correctamente");
        }
        //corregir y ver si lo cambio a la clase red social
        private List<Tag> crearTag()
        {
            string[] sTags = textBox2.Text.Split('#');
            List<Tag> listTags = new List<Tag>();

            foreach (var word in sTags)
            {
                Console.Write("1: "+word);
                if (word.Length > 1)
                {
                    if (rs.tags.Count > 0)
                    {

                        foreach (Tag tag in rs.tags)
                        {
                            Console.Write("4: " + tag);
                            if (!tag.palabra.Equals("#" + word))
                            {
                                listTags.Add(new Tag("#" + word));
                            }
                        }
                    }
                    else
                    {
                        listTags.Add(new Tag("#" + word));
                    }
                }
            }
            Console.Write("5: " + listTags);
            return listTags;
        }


        // BUTTON 4 - COMENTA EL POST
        private void button4_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());

            crearContenido(postId);
            
            textBox3.Clear();
            MessageBox.Show("Su comentario ha sido ingresado correctamente");
        }

        private void crearContenido(int idP)
        {
            foreach (Post p in rs.posts)
            {
                if (p.id == idP)
                {
                    string contenido = textBox3.Text;
                    Comentario coment = new Comentario(p, rs.usuarioActual, contenido);
                    rs.comentar(p, coment);
                    refreshList(p);
                }
            }
        }
        // BUTTON 6 - EDITAR USUARIO
        private void button6_Click(object sender, EventArgs e)
        {
            EditarUsuario edit = new EditarUsuario(rs,this, rs.searchUser(rs.usuarioActual.id), frm);
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
            eliminarRegistro();
            MessageBox.Show("Su posteo ha sido eliminado correctamente");
        }

        private void eliminarRegistro()
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
            editarComent();
        }

        private void editarComent()
        {
            var selrow = dataGridView2.SelectedRows;
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

            rs.quitarComentario(rs.searchPost(postId), rs.searchComent(commentId));
            refreshCommentsGrid();
        }
        
        // IDENTIFICADOR DEL ID DEL POST
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selrow = dataGridView1.SelectedRows;
            int postId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
            Post p = rs.searchPost(postId);
            refreshList(p);
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
            if(p != null) { 
                dataGridView2.Rows.Clear();
                foreach (Comentario c in p.comentarios)
                {
                    dataGridView2.Rows.Add(c.id, c.usuario.nombre + " " + c.usuario.apellido, c.contenido);
                }
            }
        }
        // BOTON MOSTRAR MIS POSTS
        private void button12_Click(object sender, EventArgs e)
        {
            refreshHomePosts(rs.mostrarPosts());
        }


        //buscador de post a traves de tags
        private void button14_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dateTimePicker1.Value;
            DateTime fechaHasta = dateTimePicker2.Value;
            string pContenido = textBox4.Text;
            List<Tag> tags = new List<Tag>();
            string[] sTags = textBox5.Text.Split('#');

            foreach (var word in sTags)
            {
                if (word.Length > 1)
                {
                        tags.Add(new Tag("#" + word));
                }                                       
            }
            List<Post> listaPost = rs.buscarPosts(pContenido, fechaDesde, fechaHasta, tags);

            if (listaPost.Count > 0)
            {
                MessageBox.Show("Su busqueda se ha realizado con exito");
                refreshHomePosts(listaPost);
            }
            else
            {
                MessageBox.Show("Su busqueda devolvio 0 coincidencias");
                refreshHomePosts(rs.posts);
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            List<Post> listaPost = rs.mostrarPostsAmigos();

            if (listaPost.Count > 0)
            {
                refreshHomePosts(listaPost);
            }
            else
            {
                MessageBox.Show("Usted no tiene amigos");
            }


        }

        private void button15_Click(object sender, EventArgs e)
        {
            refreshHomePosts(rs.posts);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void refreshHomePosts(List<Post> listaPost)
        {

            dataGridView1.Rows.Clear();
            string pTags = "";
            foreach (Post p in listaPost)
            {
                Console.Write("2: "+p.contentido);
                foreach (Tag t in p.tags)
                {
                    Console.Write("3: "+t.palabra);
                    pTags = pTags + t.palabra + " ";
                }
                dataGridView1.Rows.Add(p.id, p.user.nombre + " " + p.user.apellido, p.contentido, pTags);
            }
            
        }

       
    }
}
