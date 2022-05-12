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
        private int id;
        private Home frm;
        

        public EditarComentario(RedSocial rs1, Home frm1, int id)
        {
            this.frm = frm1;
            this.rs = rs1;
            this.id = id;
            
            InitializeComponent();

            foreach (Post p in rs1.posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == id)
                    {
                        textBox1.Text = c.contenido;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newComent = textBox1.Text;
            //*rs.modificarComentario();
            foreach (Post p in rs.posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == id)
                    {
                        c.contenido = newComent;
                    }
                }
            }
            frm.dataGridView2.Rows.Clear();
            foreach (Post p in rs.posts)
            {
                foreach (Comentario c in p.comentarios)
                {
                    if (c.id == id)
                    {
                        frm.dataGridView2.Rows.Add(c.id, c.usuario.nombre + " " + c.usuario.apellido, c.contenido);
                        frm.dataGridView2.Refresh();
                    }
                }
            }
            
            frm.Enabled = true;
            this.Close();


        }
    }
}
