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

        public EditarCita(CitaEntidad cita)
        {
            InitializeComponent();
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

            // --- Lógica de ajuste de visitas y legendario ---
            bool estadoCambio = _citaOriginal.Estado != _citaEditada.Estado;
            bool clienteCambio = _citaOriginal.ID_Cliente != _citaEditada.ID_Cliente;

            // Caso 1: La cita estaba completada y ahora ya no → restar visita al cliente original
            if (_citaOriginal.Estado == "Completada" && _citaEditada.Estado != "Completada")
            {
                _repoCliente.DecrementarVisitas(_citaOriginal.ID_Cliente);
            }
            // Caso 2: La cita no estaba completada y ahora se completa → sumar visita al cliente actual (puede ser el mismo u otro)
            if (_citaOriginal.Estado != "Completada" && _citaEditada.Estado == "Completada")
            {
                _repoCliente.IncrementarVisitas(_citaEditada.ID_Cliente);
            }
            // Caso 3: Si cambia el cliente y la cita estaba completada → restar al antiguo y sumar al nuevo
            if (clienteCambio && _citaOriginal.Estado == "Completada")
            {
                // Ya se restó en el caso 1 si aplicaba, pero si el estado no cambió y solo cambió el cliente, debemos hacer el ajuste
                if (_citaOriginal.Estado == "Completada" && _citaEditada.Estado == "Completada")
                {
                    _repoCliente.DecrementarVisitas(_citaOriginal.ID_Cliente);
                    _repoCliente.IncrementarVisitas(_citaEditada.ID_Cliente);
                }
            }

            // Actualizar la cita en la BD
            bool ok = _repoCita.ActualizarCita(_citaEditada);
            if (ok)
            {
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

    }
}
