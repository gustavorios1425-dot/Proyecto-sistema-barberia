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
            this.Load += NuevaCita_Load;  // importante
        }

        private void NuevaCita_Load(object sender, EventArgs e)
        {
            // Clientes
            var repoCliente = new ClienteRepository();
            var clientes = repoCliente.ObtenerTodos();
            if (clientes.Count > 0)
            {
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "NombreCompleto";
                cmbCliente.ValueMember = "ID_Cliente";
            }
            else
            {
                MessageBox.Show("No hay clientes registrados. Agrega uno primero.");
            }

            // Barbero (similar)
            var repoBarbero = new BarberoRepository();
            var barberos = repoBarbero.ObtenerTodos();
            if (barberos.Count > 0)
            {
                cmbBarbero.DataSource = barberos;
                cmbBarbero.DisplayMember = "NombreCompleto";
                cmbBarbero.ValueMember = "ID_Barbero";
            }

            // Servicio (similar)
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

            var cita = new CitaEntidad
            {
                ID_Cliente = (int)cmbCliente.SelectedValue,
                ID_Barbero = (int)cmbBarbero.SelectedValue,
                ID_Servicio = (int)cmbServicio.SelectedValue,
                FechaHora = dtpFechaHora.Value,
                Estado = cmbEstado.SelectedItem.ToString(),
                Notas = txtNotas.Text
            };

            var repo = new CitaRepository();
            int id = repo.Insertar(cita);
            if (id > 0)
            {
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
