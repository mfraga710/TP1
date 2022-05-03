using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP1.Forms
{
    public partial class BuscadorAmigos : Form
    {
        private RedSocial rs;
        public BuscadorAmigos(RedSocial rs1)
        {
            rs = rs1;
            InitializeComponent();
            foreach (Usuario user in rs.usuarios)
            {
                listBox1.Items.Add(user.nombre + " " + user.apellido);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedUser;
            selectedUser = listBox1.SelectedItem.ToString();

            foreach (Usuario user in rs.usuarios)
            {
                if ((user.nombre + " " + user.apellido).Equals(selectedUser))
                {
                    rs.usuarioActual.amigos.Add(user);
                    user.amigos.Add(rs.usuarioActual);
                }
            }
        }
    }
}
