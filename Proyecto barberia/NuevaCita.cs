using Proyecto_barberia.Entities;
using Proyecto_barberia.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_barberia
{
    public partial class NuevaCita : Form
    {
        public NuevaCita()
        {
            InitializeComponent();
            //this.Load += NuevaCita_Load;  // importante
        }

        private bool cargado = false; // bandera

        private void NuevaCita_Load(object sender, EventArgs e)
        {
            if (cargado) return;
            cargado = true;

            // Limpieza profunda
            cmbCliente.DataSource = null;
            cmbCliente.Items.Clear();
            cmbBarbero.DataSource = null;
            cmbBarbero.Items.Clear();
            cmbServicio.DataSource = null;
            if (cmbServicio.Items.Count > 0)
                cmbServicio.SelectedIndex = 0;  // esto dispara el evento
            cmbServicio.Items.Clear();

            // Clientes (no suelen tener duplicados, pero por seguridad)
            var repoCliente = new ClienteRepository();
            var clientes = repoCliente.ObtenerTodos();
            if (clientes.Count > 0)
            {
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "NombreCompleto";
                cmbCliente.ValueMember = "ID_Cliente";
            }

            // Barberos
            var repoBarbero = new BarberoRepository();
            var barberos = repoBarbero.ObtenerTodos();
            if (barberos.Count > 0)
            {
                cmbBarbero.DataSource = barberos;
                cmbBarbero.DisplayMember = "NombreCompleto";
                cmbBarbero.ValueMember = "ID_Barbero";
            }

            // Servicios
            var repoServicio = new ServicioRepository();
            var servicios = repoServicio.ObtenerTodos();
            if (servicios.Count > 0)
            {
                cmbServicio.DataSource = servicios;
                cmbServicio.DisplayMember = "Nombre";
                cmbServicio.ValueMember = "ID_Servicio";
            }

            // Estados
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "Pendiente", "Confirmada", "Completada", "Cancelada" });
            cmbEstado.SelectedIndex = 0;
        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicio.SelectedItem is ServicioEntidad servicio)
            {
                txtPrecio.Text = servicio.Precio.ToString("0.00");
            }
        }

        private void btnCrearCita_Click(object sender, EventArgs e)
        {
            // Validar que todos los combos tengan selección
            if (cmbCliente.SelectedItem == null || cmbBarbero.SelectedItem == null || cmbServicio.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar cliente, barbero y servicio.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = (int)cmbCliente.SelectedValue;
            bool esLegendario = false;

            // Verificar si el cliente es legendario
            var repoCliente = new ClienteRepository();
            var cliente = repoCliente.ObtenerPorId(idCliente);
            if (cliente != null && cliente.EsLegendario)
            {
                esLegendario = true;
                txtPrecio.Text = "0";
                MessageBox.Show("Este cliente es legendario. La cita tendrá costo $0.", "Cita gratuita", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Obtener precio del txtPrecio (puede ser el automático o 0)
            decimal precio = 0;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("El precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (precio < 0) precio = 0;

            var cita = new CitaEntidad
            {
                ID_Cliente = idCliente,
                ID_Barbero = (int)cmbBarbero.SelectedValue,
                ID_Servicio = (int)cmbServicio.SelectedValue,
                FechaHora = dtpFechaHora.Value,
                Estado = cmbEstado.SelectedItem.ToString(),
                Notas = txtNotas.Text,
                Precio = precio
            };

            var repo = new CitaRepository();
            int id = repo.Insertar(cita);
            if (id > 0)
            {
                if (esLegendario)
                {
                    repoCliente.DesactivarLegendario(idCliente);
                }
                MessageBox.Show("Cita guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar la cita. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { maskedTextBox1.SelectionStart = 0; });
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { maskedTextBox2.SelectionStart = 0; });
        }
        */

        private void CargarCombos()
        {
            // Clientes
            var repoCliente = new ClienteRepository();
            var clientes = repoCliente.ObtenerTodos();
            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "ID_Cliente";

            // Barbero
            var repoBarbero = new BarberoRepository();
            var barberos = repoBarbero.ObtenerTodos();
            cmbBarbero.DataSource = barberos;
            cmbBarbero.DisplayMember = "NombreCompleto";
            cmbBarbero.ValueMember = "ID_Barbero";

            // Servicios
            var repoServicio = new ServicioRepository();
            var servicios = repoServicio.ObtenerTodos();
            cmbServicio.DataSource = servicios;
            cmbServicio.DisplayMember = "Nombre";
            cmbServicio.ValueMember = "ID_Servicio";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
