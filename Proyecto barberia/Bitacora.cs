using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_barberia.Repositories;
using Proyecto_barberia.Entities;

namespace Proyecto_barberia
{
    public partial class Bitacora : Form
    {
        private BitacoraRepository _repo;
        private List<BitacoraEntidad> _listaCompleta;

        public Bitacora()
        {
            InitializeComponent();
            _repo = new BitacoraRepository();
            this.Load += Bitacora_Load;
            txtBuscarBitacora.TextChanged += txtBuscarBitacora_TextChanged;
            // Opcional: pantalla completa
            this.WindowState = FormWindowState.Maximized;
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            CargarBitacora();
            ActualizarTotalGanancias();
        }

        private void CargarBitacora()
        {
            _listaCompleta = _repo.ObtenerTodas();
            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = _listaCompleta;
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            // Ocultar columnas de ID
            if (dgvBitacora.Columns.Contains("ID_Bitacora"))
                dgvBitacora.Columns["ID_Bitacora"].Visible = false;
            if (dgvBitacora.Columns.Contains("ID_Cliente"))
                dgvBitacora.Columns["ID_Cliente"].Visible = false;
            if (dgvBitacora.Columns.Contains("ID_Servicio"))
                dgvBitacora.Columns["ID_Servicio"].Visible = false;

            // Personalizar títulos
            if (dgvBitacora.Columns.Contains("NombreCliente"))
                dgvBitacora.Columns["NombreCliente"].HeaderText = "Cliente";
            if (dgvBitacora.Columns.Contains("NombreServicio"))
                dgvBitacora.Columns["NombreServicio"].HeaderText = "Servicio";
            if (dgvBitacora.Columns.Contains("Precio"))
                dgvBitacora.Columns["Precio"].HeaderText = "Precio ($)";
            if (dgvBitacora.Columns.Contains("Fecha"))
                dgvBitacora.Columns["Fecha"].HeaderText = "Fecha";
            if (dgvBitacora.Columns.Contains("Notas"))
                dgvBitacora.Columns["Notas"].HeaderText = "Notas";

            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ActualizarTotalGanancias()
        {
            decimal total = _repo.ObtenerTotalGanancias();
            txtTotalGanancias.Text = total.ToString("C2"); // Formato moneda
        }

        private void txtBuscarBitacora_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarBitacora.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                dgvBitacora.DataSource = null;
                dgvBitacora.DataSource = _listaCompleta;
            }
            else
            {
                var filtrados = _repo.Buscar(filtro);
                dgvBitacora.DataSource = null;
                dgvBitacora.DataSource = filtrados;
            }
        }

        private void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            using (NuevaEntrada frm = new NuevaEntrada())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarBitacora();          // Refrescar grid
                    ActualizarTotalGanancias(); // Actualizar total
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var inicio = Application.OpenForms.OfType<Inicio>().FirstOrDefault();
            if (inicio != null) inicio.Show();
        }
    }
}
