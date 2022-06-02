using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class AdminPosts : Form
    {
        private RedSocial rs;
        private Post post;
        private Admin frm1;

        public AdminPosts(RedSocial rs1, Admin frm1, Post post)
        {
            this.frm1 = frm1;
            this.rs = rs1;
            this.post = post;
            InitializeComponent();
            refreshPost();

        }

        public void refreshPost()
        {
            foreach (Post p in rs.posts)
            {
                if (p.id == post.id)
                {
                    label1.Text = p.contenido;
                }
            }
        }

        public void refreshComent()
        {
           /* foreach (Post p in rs.posts)
            {
                foreach(Comentario c in post.comentarios)
                {
                    if (p.id == post.id)
                }
                if (p.id == post.id)
                {
                    label1.Text = p.contenido;
                }
            }*/
        }

        private void editarPosteoBotton_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            textBox1.Show();
            textBox1.Text = label1.Text;
            button1.Show();
            button6.Show();
        }

        private void editComentButton_Click(object sender, EventArgs e)
        {
            var selrow = dataGridView1.SelectedRows;
            if (selrow.Count > 0)
            {
                int comentId = Int32.Parse(selrow[0].Cells[0].Value.ToString());
                Comentario c = rs.searchComent(comentId);
                groupBox6.Show();
                textBox2.Show();
                textBox2.Text = c.contenido;
                button2.Show();
                button7.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario");
            }
        }
    }
}
