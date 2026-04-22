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
    public partial class NuevaEntrada : Form
    {
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
        public NuevaEntrada()
        {
            InitializeComponent();
            this.Size = new Size(345, 430);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.Load += NuevaEntrada_Load;
        }

        private void NuevaEntrada_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            // Cargar clientes
            var repoCliente = new ClienteRepository();
            var clientes = repoCliente.ObtenerTodos();
            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "ID_Cliente";

            // Cargar servicios
            var repoServicio = new ServicioRepository();
            var servicios = repoServicio.ObtenerTodos();
            cmbServicio.DataSource = servicios;
            cmbServicio.DisplayMember = "Nombre";
            cmbServicio.ValueMember = "ID_Servicio";

            // Precio solo lectura
            txtPrecio.ReadOnly = true;

            // Verificar cuántos servicios se cargaron
            if (cmbServicio.Items.Count == 0)
            {
                MessageBox.Show("No hay servicios registrados. Agrega servicios para poder crear entradas.");
            }
            else
            {
                // Forzar la selección del primer elemento para que el precio se muestre
                if (cmbServicio.Items.Count > 0)
                    cmbServicio.SelectedIndex = 0;
            }

        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServicio.SelectedItem != null)
            {
                // Intenta convertir el objeto seleccionado a ServicioEntidad
                if (cmbServicio.SelectedItem is ServicioEntidad servicio)
                {
                    txtPrecio.Text = servicio.Precio.ToString("0.00");
                }
                else
                {
                    // Si no se puede convertir, intenta obtener el precio desde el ValueMember
                    // Esto es por si el DataSource está mal configurado
                    try
                    {
                        decimal precio = Convert.ToDecimal(cmbServicio.SelectedValue);
                        txtPrecio.Text = precio.ToString("0.00");
                    }
                    catch
                    {
                        txtPrecio.Text = "";
                        MessageBox.Show("No se pudo obtener el precio del servicio seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                txtPrecio.Text = "";
            }
        }

        private void btnCrearEntrada_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (cmbCliente.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbServicio.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un servicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var entrada = new BitacoraEntidad
            {
                ID_Cliente = (int)cmbCliente.SelectedValue,
                ID_Servicio = (int)cmbServicio.SelectedValue,
                Precio = precio,
                Fecha = DateTime.Now,
                Notas = txtNotas.Text.Trim()
            };

            var repo = new BitacoraRepository();
            int id = repo.Insertar(entrada);
            if (id > 0)
            {
                MessageBox.Show("Entrada registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar la entrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
