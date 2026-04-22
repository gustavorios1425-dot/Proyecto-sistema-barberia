using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_barberia.Entities;
using Proyecto_barberia.Repositories;

namespace Proyecto_barberia
{
    public partial class EditarCita : Form
    {
        private CitaEntidad _citaOriginal;
        private CitaEntidad _citaEditada;
        private ClienteRepository _repoCliente;
        private CitaRepository _repoCita;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnlTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void pnlTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        public EditarCita(CitaEntidad cita)
        {
            InitializeComponent();

            this.Size = new Size(345, 620);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            _citaOriginal = cita;
            _citaEditada = new CitaEntidad
            {
                ID_Cita = cita.ID_Cita,
                ID_Cliente = cita.ID_Cliente,
                ID_Barbero = cita.ID_Barbero,
                ID_Servicio = cita.ID_Servicio,
                FechaHora = cita.FechaHora,
                Estado = cita.Estado,
                Notas = cita.Notas,
                Precio = cita.Precio,
                NombreCliente = cita.NombreCliente,
                NombreBarbero = cita.NombreBarbero,
                NombreServicio = cita.NombreServicio
            };
            _repoCliente = new ClienteRepository();
            _repoCita = new CitaRepository();
            this.Load += EditarCita_Load;
        }

        private void EditarCita_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDatosActuales();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CargarCombos()
        {
            // Clientes
            var repoCliente = new ClienteRepository();
            var clientes = repoCliente.ObtenerTodos();
            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "ID_Cliente";
            cmbCliente.SelectedValue = _citaOriginal.ID_Cliente;

            // Barberos
            var repoBarbero = new BarberoRepository();
            var barberos = repoBarbero.ObtenerTodos();
            cmbBarbero.DataSource = barberos;
            cmbBarbero.DisplayMember = "NombreCompleto";
            cmbBarbero.ValueMember = "ID_Barbero";
            cmbBarbero.SelectedValue = _citaOriginal.ID_Barbero;

            // Servicios
            var repoServicio = new ServicioRepository();
            var servicios = repoServicio.ObtenerTodos();
            cmbServicio.DataSource = servicios;
            cmbServicio.DisplayMember = "Nombre";
            cmbServicio.ValueMember = "ID_Servicio";
            cmbServicio.SelectedValue = _citaOriginal.ID_Servicio;
            cmbServicio.SelectedIndexChanged += (s, ev) => ActualizarPrecioPorServicio();

            // Estados
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "Pendiente", "Confirmada", "Completada", "Cancelada" });
            cmbEstado.SelectedItem = _citaOriginal.Estado;
        }

        private void CargarDatosActuales()
        {
            dtpFechaHora.Value = _citaOriginal.FechaHora;
            txtPrecio.Text = _citaOriginal.Precio.ToString("0.00");
            txtNotas.Text = _citaOriginal.Notas;
        }

        private void ActualizarPrecioPorServicio()
        {
            if (cmbServicio.SelectedItem is ServicioEntidad servicio)
            {
                txtPrecio.Text = servicio.Precio.ToString("0.00");
                _citaEditada.Precio = servicio.Precio;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar selecciones
            if (cmbCliente.SelectedItem == null || cmbBarbero.SelectedItem == null || cmbServicio.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar cliente, barbero y servicio.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Capturar nuevos valores
            _citaEditada.ID_Cliente = (int)cmbCliente.SelectedValue;
            _citaEditada.ID_Barbero = (int)cmbBarbero.SelectedValue;
            _citaEditada.ID_Servicio = (int)cmbServicio.SelectedValue;
            _citaEditada.FechaHora = dtpFechaHora.Value;
            _citaEditada.Estado = cmbEstado.SelectedItem.ToString();
            _citaEditada.Notas = txtNotas.Text;
            _citaEditada.Precio = decimal.Parse(txtPrecio.Text);

            // Si se está completando la cita (de un estado no completado a completado)
            if (_citaOriginal.Estado != "Completada" && _citaEditada.Estado == "Completada")
            {
                var confirm = MessageBox.Show($"¿Completar cita de {_citaOriginal.NombreCliente}? Se creará un registro en bitácora y la cita se eliminará.", "Confirmar completado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                // Crear entrada en bitácora
                var bitacora = new BitacoraEntidad
                {
                    ID_Cliente = _citaEditada.ID_Cliente,
                    ID_Servicio = _citaEditada.ID_Servicio,
                    Precio = _citaEditada.Precio,
                    Fecha = DateTime.Now,
                    Notas = $"Cita completada el {_citaEditada.FechaHora:dd/MM/yyyy HH:mm}. Notas originales: {_citaEditada.Notas}"
                };
                var repoBit = new BitacoraRepository();
                repoBit.Insertar(bitacora);

                // Incrementar visitas del cliente
                var repoCliente = new ClienteRepository();
                repoCliente.IncrementarVisitas(_citaEditada.ID_Cliente);

                // Eliminar la cita
                bool ok = _repoCita.Eliminar(_citaOriginal.ID_Cita);
                if (ok)
                {
                    MessageBox.Show("Cita completada y registrada en bitácora.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            // Para otros cambios de estado (no completado) o edición normal
            // (aquí mantienes la lógica anterior de actualización de visitas si cambia cliente o se descompleta, etc.)
            // Pero como ya no hay citas completadas, solo manejamos otros casos.
            // Simplificamos: si no es completado, simplemente actualizar la cita.
            bool okUpdate = _repoCita.ActualizarCita(_citaEditada);
            if (okUpdate)
            {
                // Si cambió el cliente y la cita estaba completada? Ya no se da. Solo manejar otros cambios.
                // Si cambia el cliente en una cita no completada, no afecta visitas.
                MessageBox.Show("Cita actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
