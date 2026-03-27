using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_barberia
{
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox4.UseSystemPasswordChar)
            {
                // Contraseña oculta (puntos) → la mostramos en texto
                textBox4.UseSystemPasswordChar = false;
                // Ponemos ojo cerrado para indicar que ahora se puede ocultar
                pictureBox1.Image = Properties.Resources.esconder;
            }
            else
            {
                // Contraseña visible → la volvemos a ocultar
                textBox4.UseSystemPasswordChar = true;
                // Ponemos ojo abierto para indicar que se puede mostrar
                pictureBox1.Image = Properties.Resources.ojo_abierto;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            InicioSesion frm = new InicioSesion();
            frm.ShowDialog();
            this.Close(); // Cierra el formulario actual
        }

        private void CrearCuenta_Load(object sender, EventArgs e)
        {

        }

        // Importar funciones de Windows para el movimiento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void CrearCuenta_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
