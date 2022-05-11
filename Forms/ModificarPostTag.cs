using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class ModificarPostTag : Form
    {
        private RedSocial rs;
        private int id;
        private Post p;
        private Home frm;

        public ModificarPostTag(RedSocial rs1,Home frm1, int postId)
        {
            this.frm = frm1;
            this.rs = rs1;
            this.id = postId;
            InitializeComponent();
            foreach (Post p in rs1.posts)
            {
                if (p.id == postId)
                {
                    textBox1.Text = p.contentido;

                    foreach (Tag t in p.tags)
                    {
                        listView1.Items.Add(t.palabra);
                    }
                }
            }
        }

        // BOTON GUARDAR
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Post p in rs.posts)
            {
                if (p.id == id)
                {
                    //*rs.modificarPost(p);
                    p.contentido = textBox1.Text;
                }
            }
            
            frm.dataGridView1.Rows.Clear();

            foreach (Post p in rs.posts)
            {
                string pTags = "";
                foreach (Tag t in p.tags)
                {
                    pTags = pTags + t.palabra + " ";
                }
                frm.dataGridView1.Rows.Add(p.id, p.user.nombre + " " + p.user.apellido, p.contentido, pTags);
            }
            frm.Enabled = true;
            this.Close();
        }

        // BOTON CANCELAR
        private void button2_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }

    }
}
