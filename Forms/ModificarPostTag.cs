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

        private Home frm;

        public ModificarPostTag(RedSocial rs1,Home frm1)
        {
            this.frm = frm1;
            this.rs = rs1;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
