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
        public Home(RedSocial rs1)
        {
            this.rs = rs1;
            InitializeComponent();
            label1.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;
            foreach (Usuario user in rs.usuarios)
            {
                listBox2.Items.Add(user.nombre + " " + user.apellido);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label3.Show();
            listBox2.Show();
            button1.Show();
            button2.Show();
            listBox2.Items.Remove(rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string selectedUser;
            selectedUser = listBox2.SelectedItem.ToString();
            

            foreach (Usuario user in rs.usuarios)
            {
                if ((user.nombre + " " + user.apellido).Equals(selectedUser))
                {
                    rs.usuarioActual.amigos.Add(user);
                    user.amigos.Add(rs.usuarioActual);
                    listBox2.Items.Remove(selectedUser);                    
                    listBox1.Items.Clear();

                    foreach (Usuario userName in rs.usuarioActual.amigos)
                    {
                        listBox1.Items.Add(userName.nombre + " " + userName.apellido);
                    }
                }
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label3.Visible = false;
            listBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

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
                        rs.usuarioActual.amigos.Remove(user);
                        user.amigos.Remove(rs.usuarioActual);
                        listBox1.Items.Remove(selectedUser);
                        listBox2.Items.Add(selectedUser);
                    }
                }

            }
        }
    }
}
