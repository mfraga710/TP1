using System;
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
    private Post p;
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
                    label5.Text = p.contentido;

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
        private void button3_Click_1(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            textBox1.Show();
            textBox1.Text = label5.Text;
            button1.Show();
        }
    }
}
