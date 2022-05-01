
namespace TP1
{
    partial class Registro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rpassword = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Apellido";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(354, 116);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(191, 23);
            this.apellido.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "DNI";
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(354, 199);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(191, 23);
            this.dni.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mail";
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(64, 199);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(191, 23);
            this.mail.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contraseña";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(64, 291);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(191, 23);
            this.password.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Repita su contraseña";
            // 
            // rpassword
            // 
            this.rpassword.Location = new System.Drawing.Point(354, 291);
            this.rpassword.Name = "rpassword";
            this.rpassword.Size = new System.Drawing.Size(191, 23);
            this.rpassword.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Crear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(64, 116);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(191, 23);
            this.nombre.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(64, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Errores";
            this.label7.Visible = false;
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 442);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rpassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Registro";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rpassword;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label7;
    }
}