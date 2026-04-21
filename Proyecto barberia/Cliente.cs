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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
            this.Load += Cliente_Load;  // si ya existe, no duplicar
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (NuevoCliente frm = new NuevoCliente())
            {
                // Abre NuevoCliente como diálogo modal; Cliente se queda detrás
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Si se guardó un cliente, refrescar la lista
                    CargarClientes(); // método que llena el DataGridView
                }
            }
        }

        /*
        private void CargarListaClientes()
        {
            var repo = new ClienteRepository();
            var clientes = repo.ObtenerTodos();
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes;
            // Opcional: ocultar columnas que no quieras mostrar
            if (dgvClientes.Columns.Contains("ID_Cliente"))
                dgvClientes.Columns["ID_Cliente"].Visible = false;
        }
        */

        private List<ClienteEntidad> _listaCompleta;

        private void CargarClientes()
        {
            var repo = new ClienteRepository();
            _listaCompleta = repo.ObtenerTodos();
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = _listaCompleta;
            ConfigurarColumnas(); // en lugar del código inline
        }

        private void ConfigurarColumnas()
        {
            // Ocultar columnas de ID
            if (dgvClientes.Columns.Contains("ID_Cliente"))
                dgvClientes.Columns["ID_Cliente"].Visible = false;

            // Cambiar títulos
            if (dgvClientes.Columns.Contains("NombreCompleto"))
                dgvClientes.Columns["NombreCompleto"].HeaderText = "Nombre completo";
            if (dgvClientes.Columns.Contains("Telefono"))
                dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
            if (dgvClientes.Columns.Contains("Email"))
                dgvClientes.Columns["Email"].HeaderText = "Correo";
            if (dgvClientes.Columns.Contains("FechaRegistro"))
                dgvClientes.Columns["FechaRegistro"].HeaderText = "Fecha registro";
            if (dgvClientes.Columns.Contains("TotalVisitas"))
                dgvClientes.Columns["TotalVisitas"].HeaderText = "Visitas";
            if (dgvClientes.Columns.Contains("EsLegendario"))
                dgvClientes.Columns["EsLegendario"].HeaderText = "Legendario";

            // Botón Eliminar (solo si no existe)
            if (!dgvClientes.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "btnEliminar";
                btnEliminar.HeaderText = "Acción";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgvClientes.Columns.Add(btnEliminar);
            }

            // Forzar que el botón Eliminar esté a la derecha (última columna)
            if (dgvClientes.Columns.Contains("btnEliminar"))
                dgvClientes.Columns["btnEliminar"].DisplayIndex = dgvClientes.Columns.Count - 1;

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FiltrarClientes(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = _listaCompleta;
            }
            else
            {
                filtro = filtro.ToLower();
                var filtrados = _listaCompleta.Where(c =>
                    c.NombreCompleto.ToLower().Contains(filtro) ||
                    c.Telefono.Contains(filtro) ||
                    (c.Email != null && c.Email.ToLower().Contains(filtro))
                ).ToList();
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = filtrados;
            }
            // Replicar la configuracion de columnas después de cambiar el DataSource
            ConfigurarColumnas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes(txtBuscar.Text);
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            // Si el formulario padre (Inicio) está oculto, mostrarlo
            var inicio = Application.OpenForms.OfType<Inicio>().FirstOrDefault();
            if (inicio != null) inicio.Show();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                ClienteEntidad cliente = _listaCompleta[e.RowIndex];

                // Preguntar confirmación
                DialogResult confirm = MessageBox.Show(
                    $"¿Eliminar cliente '{cliente.NombreCompleto}'?\n\nSe eliminarán también todas sus citas pendientes.\nNo se eliminarán registros de bitácora.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    var repo = new ClienteRepository();
                    string mensaje;
                    if (repo.EliminarCliente(cliente.ID_Cliente, out mensaje))
                    {
                        MessageBox.Show($"Cliente {cliente.NombreCompleto} eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
                        // Opcional: actualizar contadores en Inicio
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
