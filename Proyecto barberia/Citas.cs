using Proyecto_barberia.Entities;
using Proyecto_barberia.Repositories;
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
    public partial class Citas : Form
    {
        /*
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
        */

        private List<CitaEntidad> _listaCompleta;

        public Citas()
        {
            InitializeComponent();
            dgvCitas.CellClick += dgvCitas_CellClick;
            this.Load += Citas_Load;
            txtBuscarCita.TextChanged += txtBuscarCita_TextChanged;
        }

        private void Citas_Load(object sender, EventArgs e)
        {
            CargarCitas();
        }

        private void CargarCitas()
        {
            var repo = new CitaRepository();
            _listaCompleta = repo.ObtenerTodas();
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = _listaCompleta;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            // Ocultar columnas que no quieras mostrar
            if (dgvCitas.Columns.Contains("ID_Cita"))
                dgvCitas.Columns["ID_Cita"].Visible = false;
            if (dgvCitas.Columns.Contains("ID_Cliente"))
                dgvCitas.Columns["ID_Cliente"].Visible = false;
            if (dgvCitas.Columns.Contains("ID_Barbero"))
                dgvCitas.Columns["ID_Barbero"].Visible = false;
            if (dgvCitas.Columns.Contains("ID_Servicio"))
                dgvCitas.Columns["ID_Servicio"].Visible = false;

            // Cambiar títulos
            if (dgvCitas.Columns.Contains("NombreCliente"))
                dgvCitas.Columns["NombreCliente"].HeaderText = "Cliente";
            if (dgvCitas.Columns.Contains("NombreBarbero"))
                dgvCitas.Columns["NombreBarbero"].HeaderText = "Barbero";
            if (dgvCitas.Columns.Contains("NombreServicio"))
                dgvCitas.Columns["NombreServicio"].HeaderText = "Servicio";
            if (dgvCitas.Columns.Contains("FechaHora"))
                dgvCitas.Columns["FechaHora"].HeaderText = "Fecha y hora";
            if (dgvCitas.Columns.Contains("Estado"))
                dgvCitas.Columns["Estado"].HeaderText = "Estado";
            if (dgvCitas.Columns.Contains("Notas"))
                dgvCitas.Columns["Notas"].HeaderText = "Notas";

            // Agregar columna de botón Editar
            if (!dgvCitas.Columns.Contains("btnEditar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "btnEditar";
                btnEditar.HeaderText = "Acción";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                dgvCitas.Columns.Add(btnEditar);
            }

            // Agregar columna de botón Eliminar
            if (!dgvCitas.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "btnEliminar";
                btnEliminar.HeaderText = "Acción";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgvCitas.Columns.Add(btnEliminar);
            }

            // Forzar que los botones estén a la derecha
            if (dgvCitas.Columns.Contains("btnEditar"))
                dgvCitas.Columns["btnEditar"].DisplayIndex = dgvCitas.Columns.Count - 1; // penúltimo
            if (dgvCitas.Columns.Contains("btnEliminar"))
                dgvCitas.Columns["btnEliminar"].DisplayIndex = dgvCitas.Columns.Count - 1; // último

            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FiltrarCitas(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                dgvCitas.DataSource = null;
                dgvCitas.DataSource = _listaCompleta;
            }
            else
            {
                filtro = filtro.ToLower();
                var filtrados = _listaCompleta.Where(c =>
                    c.NombreCliente.ToLower().Contains(filtro) ||
                    c.NombreBarbero.ToLower().Contains(filtro) ||
                    c.NombreServicio.ToLower().Contains(filtro) ||
                    c.Estado.ToLower().Contains(filtro)
                ).ToList();
                dgvCitas.DataSource = null;
                dgvCitas.DataSource = filtrados;
            }
            ConfigurarColumnas(); // Reconfigurar columnas para asegurarse de que los botones sigan funcionando
        }

        private void txtBuscarCita_TextChanged(object sender, EventArgs e)
        {
            FiltrarCitas(txtBuscarCita.Text);
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            using (NuevaCita frm = new NuevaCita())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarCitas(); // refrescar
                    ActualizarContadorCitasEnInicio();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var inicio = Application.OpenForms.OfType<Inicio>().FirstOrDefault();
            if (inicio != null) inicio.Show();
        }

        private void ActualizarContadorCitasEnInicio()
        {
            var inicio = Application.OpenForms.OfType<Inicio>().FirstOrDefault();
            if (inicio != null)
            {
                // Asumiendo que en Inicio tienes un método público para actualizar contadores
                inicio.ActualizarContadores();
            }
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clics en encabezados (RowIndex = -1)
            if (e.RowIndex < 0) return;

            // Asegura _listaCompleta no sea null y tenga elementos en el índice e.RowIndex
            if (e.RowIndex >= _listaCompleta.Count) return;

            // Verificar que se hizo clic en una fila válida y en la columna del botón
            if (e.RowIndex >= 0 && dgvCitas.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                CitaEntidad cita = _listaCompleta[e.RowIndex];
                using (EditarCita frm = new EditarCita(cita))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarCitas(); // refrescar la lista
                        ActualizarContadorCitasEnInicio(); // actualizar contador en inicio
                    }
                }
            }
            else if (dgvCitas.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                CitaEntidad cita = _listaCompleta[e.RowIndex];

                // No permitir eliminar citas completadas (ya que se eliminan al completarse)
                if (cita.Estado == "Completada")
                {
                    MessageBox.Show("Las citas completadas se eliminan automáticamente al ser marcadas como completadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Preguntar confirmación
                DialogResult result = MessageBox.Show(
                    $"¿Eliminar cita de {cita.NombreCliente} el {cita.FechaHora:dd/MM/yyyy HH:mm}?\n\nEsta acción no afecta las visitas del cliente.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    var repo = new CitaRepository();
                    if (repo.Eliminar(cita.ID_Cita))
                    {
                        MessageBox.Show("Cita eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas(); // refrescar lista
                        ActualizarContadorCitasEnInicio();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /*
        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            NuevaCita frm = new NuevaCita();
            frm.ShowDialog();
            this.Close(); // Cierra el formulario actual
        }
        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        */


    }
}
