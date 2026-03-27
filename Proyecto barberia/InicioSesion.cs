using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Proyecto_barberia
{
    public partial class InicioSesion : Form
    {
        public int clickX, clickY; //variables declardas para mover el form
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {
            panelSuperior.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar)
            {
                // Contraseña oculta (puntos) → la mostramos en texto
                textBox2.UseSystemPasswordChar = false;
                // Ponemos ojo cerrado para indicar que ahora se puede ocultar
                pictureBox1.Image = Properties.Resources.esconder;
            }
            else
            {
                // Contraseña visible → la volvemos a ocultar
                textBox2.UseSystemPasswordChar = true;
                // Ponemos ojo abierto para indicar que se puede mostrar
                pictureBox1.Image = Properties.Resources.ojo_abierto;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide(); // Oculta el formulario actual
            CrearCuenta frm = new CrearCuenta();
            frm.ShowDialog();
            this.Close(); // Cierra el formulario actual
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            RecuperarContraseña frm = new RecuperarContraseña();
            frm.ShowDialog();
            this.Close(); // Cierra el formulario actual
        }

        

        private void InicioSesion_Load(object sender, EventArgs e)
        {

        }

        // Importar funciones de Windows para el movimiento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


    }

}
