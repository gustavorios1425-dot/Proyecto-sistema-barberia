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
using Proyecto_barberia.Repositories;

namespace Proyecto_barberia
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            ActualizarContadores();
            this.Activated += Inicio_Activated; // suscribir evento
        }

        private void Inicio_Activated(object sender, EventArgs e)
        {
            ActualizarContadores();
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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Buscar la instancia del login (está oculta)
            var login = Application.OpenForms.OfType<InicioSesion>().FirstOrDefault();
            if (login != null)
            {
                login.LimpiarCampos();
                login.Show();  // Muestra el login nuevamente
            }
            else
            {
                // Por si acaso, crear uno nuevo
                new InicioSesion().Show();
            }
            this.Close(); // Cierra el menú principal (el login sigue vivo)

        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            this.Hide(); // oculta Inicio mientras está el hijo
            using (Citas frm = new Citas())
            {
                frm.ShowDialog();
            }
            this.Show(); // al cerrar Cliente, muestra Inicio nuevamente
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide(); // oculta Inicio mientras está el hijo
            using (Cliente frm = new Cliente())
            {
                frm.ShowDialog();
            }
            this.Show(); // al cerrar Cliente, muestra Inicio nuevamente
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            this.Hide(); // oculta Inicio mientras está el hijo
            using (Bitacora frm = new Bitacora())
            {
                frm.ShowDialog();
            }
            this.Show(); // al cerrar Cliente, muestra Inicio nuevamente
        }

        public void ActualizarContadores()
        {   
            var repoClientes = new ClienteRepository();
            var clientes = repoClientes.ObtenerTodos();
            lblTotalClientes.Text = clientes.Count.ToString();
            lblTotalLegendarios.Text = clientes.Count(c => c.EsLegendario).ToString();

            var repoCitas = new CitaRepository();
            var citas = repoCitas.ObtenerTodas();

            // Actualiza los controles en tu UI
            lblTotalCitas.Text = citas.Count.ToString();
            // Si tienes un control para legendarios, por ejemplo lblLegendarios, actualízalo:
            // lblLegendarios.Text = legendarios.ToString();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}
