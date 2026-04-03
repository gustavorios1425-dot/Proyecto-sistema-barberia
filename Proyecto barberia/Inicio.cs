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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        // Importar funciones de Windows para el movimiento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Inicio_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            InicioSesion frm = new InicioSesion();
            frm.ShowDialog();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Citas frm = new Citas();
            frm.ShowDialog();
            this.Close(); // Cierra el formulario actual
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Cliente frm = new Cliente();
            frm.ShowDialog();
            this.Close(); // Cierra el formulario actual
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            Bitacora frm = new Bitacora();
            frm.ShowDialog();
            this.Close();
        }
    }
}
