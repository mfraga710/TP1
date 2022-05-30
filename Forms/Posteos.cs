﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class Posteos : Form
    {
    private RedSocial rs;
    private int id;
    private Home frm;
    
        public Posteos(RedSocial rs1, Home frm1, int postId)
        {
            this.frm = frm1;
            this.rs = rs1;
            this.id = postId;
            InitializeComponent();
            foreach (Post p in rs1.posts)
            {
                if (p.id == postId)
                {
                    label5.Text = p.contenido;
                    label6.Text = p.fecha.ToString("d");
                    foreach (Tag t in p.tags)
                    {
                        listBox1.Items.Add(t.palabra);
                    }
                }
            }
            refreshReacciones();
        }
        // BOTON GUARDAR
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Post p in rs.posts)
            {
                if (p.id == id)
                {
                    string newPost = textBox1.Text;
                    Post editedPost = rs.searchPost(id);
                    editedPost.contenido = newPost;
                    rs.modificarPost(editedPost);
                }
            }
            refreshpost();
        }

        // BOTON CANCELAR EL POST
        private void button3_Click_1(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }

        // BOTON EDITAR POST
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            textBox1.Show();
            textBox1.Text = label5.Text;
            button1.Show();
        }

        // BOTON SELECCION DE TAGS PARA EDIT
        private void button5_Click(object sender, EventArgs e)
        {
            string selectTag;

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un tag a modificar");
            }
            else
            {
                selectTag = listBox1.SelectedItem.ToString();
                groupBox5.Show();
                textBox2.Show();
                textBox2.Text = selectTag;
                button6.Show();
            }   
        }
        // BOTON CANCELAR POST
        private void button4_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }

        // BOTON MODIFICAR TAGS
        private void button6_Click(object sender, EventArgs e)
        {
            Post editedPost = rs.searchPost(id);
            foreach (Tag tag in editedPost.tags)
            {
                if (tag.id == editedPost.id)
                {
                    tag.palabra = textBox2.Text;
                }
            }
            refreshpost();
            frm.Enabled = true;
            frm.dataGridViewPosts.Refresh();
            this.Close();


        }


        private void refreshpost()
        {
            frm.dataGridViewPosts.Rows.Clear();
            foreach (Post p in rs.posts)
            {
                string pTags = "";
                foreach (Tag t in p.tags)
                {
                    pTags = pTags + t.palabra + " ";
                }
                frm.dataGridViewPosts.Rows.Add(p.id, p.user.nombre + " " + p.user.apellido, p.contenido, pTags);
            }
            frm.Enabled = true;
            this.Close();
        }
        // CLICK ME GUSTA
        private void button7_Click(object sender, EventArgs e)
        {
            Post editedPost = rs.searchPost(id);
            Reaccion reaccion = new Reaccion(Reaccion.ME_GUSTA, editedPost, rs.usuarioActual);
            rs.reaccionar(editedPost, reaccion);
            refreshReacciones();
        }
        // CLICK NO ME GUSTA
        private void button8_Click(object sender, EventArgs e)
        {
            Post editedPost = rs.searchPost(id);
            Reaccion reaccion = new Reaccion(Reaccion.NO_ME_GUSTA, editedPost, rs.usuarioActual);
            rs.reaccionar(editedPost, reaccion);
            refreshReacciones();
        }
        // CLICK ELIINAR REACCION
        private void button9_Click(object sender, EventArgs e)
        {
            Post editedPost = rs.searchPost(id);
            Reaccion reaccion = new Reaccion(Reaccion.NO_ME_GUSTA, editedPost, rs.usuarioActual);
            rs.quitarReacion(editedPost, reaccion);
            refreshReacciones();
        }

        private int countReacciones(String tipo, Post post)
        {
            int cont = 0;
            foreach (Reaccion r in  post.reacciones)
            {
                if (r.tipoReaccion.Equals(tipo))
                {
                    cont++;
                }
            }
            return cont;
        }

        private void refreshReacciones()
        {
            Post editedPost = rs.searchPost(id);
            label2.Text = countReacciones(Reaccion.ME_GUSTA, editedPost).ToString();
            label3.Text = countReacciones(Reaccion.NO_ME_GUSTA, editedPost).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }
    }
}
