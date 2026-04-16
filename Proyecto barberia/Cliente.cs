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
            CargarListaClientes();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            using (NuevoCliente frm = new NuevoCliente())
            {
                // Abre NuevoCliente como diálogo modal; Cliente se queda detrás
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Si se guardó un cliente, refrescar la lista
                    CargarListaClientes(); // método que llena el DataGridView
                }
            }
        }

        private void CargarListaClientes()
        {
            var repo = new ClienteRepository();
            var clientes = repo.ObtenerTodos();
            dataGridViewClientes.DataSource = null;
            dataGridViewClientes.DataSource = clientes;
            // Opcional: ocultar columnas que no quieras mostrar
            if (dataGridViewClientes.Columns.Contains("ID_Cliente"))
                dataGridViewClientes.Columns["ID_Cliente"].Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
