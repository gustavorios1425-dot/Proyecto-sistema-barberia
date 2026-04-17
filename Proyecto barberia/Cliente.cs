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

        private void CargarClientes()
        {
            var repo = new ClienteRepository();
            var clientes = repo.ObtenerTodos();

            // Asignar la lista al DataGridView
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes;

            // Configurar las columnas: ocultar algunas y cambiar títulos
            if (dgvClientes.Columns.Contains("ID_Cliente"))
                dgvClientes.Columns["ID_Cliente"].Visible = false;

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

            // Ajustar el ancho de las columnas automáticamente
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            // Si el formulario padre (Inicio) está oculto, mostrarlo
            var inicio = Application.OpenForms.OfType<Inicio>().FirstOrDefault();
            if (inicio != null) inicio.Show();
        }
    }
}
