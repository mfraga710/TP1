﻿using System;
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
            label1.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;
            foreach (Usuario user in rs.usuarios)
            {
                listBox2.Items.Add(user.nombre + " " + user.apellido);
            }

            dataGridView1.Rows.Clear();

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
            listBox2.Show();
            button1.Show();
            button2.Show();
            listBox2.Items.Remove(rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido);
        }

        // BUTTON 1 - AGREGA AMIGO
        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedUser;
            selectedUser = listBox2.SelectedItem.ToString();
            

            foreach (Usuario user in rs.usuarios)
            {
                if ((user.nombre + " " + user.apellido).Equals(selectedUser))
                {
                    rs.agregarAmigo(user);
                    listBox2.Items.Remove(selectedUser);                    
                    listBox1.Items.Clear();

                    foreach (Usuario userName in rs.usuarioActual.amigos)
                    {
                        listBox1.Items.Add(userName.nombre + " " + userName.apellido);
                    }
                }
            }            
        }

        // BUTTON 2 - CIERRA LISTBOX 2
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label3.Visible = false;
            listBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        // PICTUREBOX 2 - ELIMINA AMIGO
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string selectedUser;

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un usuario a eliminar de la lista");
            }
            else
            {
                selectedUser = listBox1.SelectedItem.ToString();
                foreach (Usuario user in rs.usuarios)
                {
                    if ((user.nombre + " " + user.apellido).Equals(selectedUser))
                    {
                        rs.quitarAmigo(user);
                        listBox1.Items.Remove(selectedUser);
                        listBox2.Items.Add(selectedUser);
                    }
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
                    Comentario coment = new Comentario();
                    coment.contenido = textBox3.Text;
                    rs.comentar(p, coment);
                    refreshList(p);
                }
            }
            textBox3.Clear();
        }

        // METODO PARA REFRESTAR LA LISTA DE POST
        private void refreshList(Post p)
        {
            listBox3.Items.Clear();
            foreach (Comentario c in p.comentarios)
            {
                listBox3.Items.Add(c.contenido);
            }
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

        // BUTTON 5 - ELIMINA COMENTARIO
        private void button5_Click(object sender, EventArgs e)

        {
            //falta arreglar para quitar comentarios 


           /* string selectedUser;

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un usuario a eliminar de la lista");
            }
            else
            {
                selectedUser = listBox1.SelectedItem.ToString();
                foreach (Usuario user in rs.usuarios)
                {
                    if ((user.nombre + " " + user.apellido).Equals(selectedUser))
                    {
                        rs.usuarioActual.amigos.Remove(user);
                        user.amigos.Remove(rs.usuarioActual);
                        listBox1.Items.Remove(selectedUser);
                        listBox2.Items.Add(selectedUser);
                    }*/

            /*string selectedComment;

            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un comentario a eliminar de la lista");
            }
            else
            {
                selectedComment = listBox3.SelectedItem.ToString();

                var commentId = Int32.Parse(listBox3.SelectedItem.ToString());

            foreach (Post p in rs.posts)
            {
                if ( == )
                {

                    listBox3.Items.Remove(selectedComment);
                    listBox3.Items.Clear();
                    rs.quitarComentario(p,commentId);
                    refreshList(p);
                }
            }
            textBox3.Clear();
        }*/
        }

        // BUTTON 6 - EDITAR USUARIO
        private void button6_Click(object sender, EventArgs e)
        {
            EditarUsuario edit = new EditarUsuario(rs,this);
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

        private void button11_Click(object sender, EventArgs e)
        {

            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un comentario a modificar");
            }
            else
            {
                textBox4.Show();
                textBox4.Text = listBox3.SelectedItem.ToString();
                button12.Show();
            }
            
        }
    }
}
