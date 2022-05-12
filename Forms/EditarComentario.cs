using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class EditarComentario : Form
    {
        private RedSocial rs;
        private int idComment;
        private int idPost;
        private Home frm;
        

        public EditarComentario(RedSocial rs1, Home frm1, int idComment1, int idPost1)
        {
            this.frm = frm1;
            this.rs = rs1;
            this.idComment = idComment1;
            this.idPost = idPost1;
            
            InitializeComponent();

            foreach (Post p in rs1.posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == idComment)
                    {
                        textBox1.Text = c.contenido;
                    }
                }
            }
        }

        //GUARDAR CAMBIOS COMENTARIO EDITADO
        private void button1_Click(object sender, EventArgs e)
        {
            string newComent = textBox1.Text;
            Comentario editedComment = frm.searchComent(idComment);
            editedComment.contenido = newComent;
            rs.modificarComentario(frm.searchPost(idPost), editedComment);
            frm.refreshCommentsGrid();
            frm.Enabled = true;
            this.Close();
        }

    }
}
