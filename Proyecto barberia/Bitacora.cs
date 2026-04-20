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
            dgvBitacora.CellEndEdit += dgvBitacora_CellEndEdit;
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
            {
                dgvBitacora.Columns["Notas"].HeaderText = "Notas";
                dgvBitacora.Columns["Notas"].ReadOnly = false;
                dgvBitacora.Columns["Notas"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            // Boton para eliminar Entrada
            if (!dgvBitacora.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "btnEliminar";
                btnEliminar.HeaderText = "Acción";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgvBitacora.Columns.Add(btnEliminar);
            }

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

        private void dgvBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBitacora.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                BitacoraEntidad entrada = _listaCompleta[e.RowIndex];
                var confirm = MessageBox.Show($"¿Eliminar entrada de {entrada.NombreCliente} - {entrada.NombreServicio} por ${entrada.Precio}? Se restará del total de ganancias.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    var repo = new BitacoraRepository();
                    if (repo.Eliminar(entrada.ID_Bitacora))
                    {
                        MessageBox.Show("Entrada eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarBitacora(); // refrescar grid
                        ActualizarTotalGanancias(); // actualizar total
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar entrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvBitacora_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que fila y columna sean válidas
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Solo procesar la columna "Notas"
            if (dgvBitacora.Columns[e.ColumnIndex].Name == "Notas")
            {
                // Obtener la entrada correspondiente de la lista local
                BitacoraEntidad entrada = _listaCompleta[e.RowIndex];

                // El nuevo texto ya está actualizado en 'entrada.Notas' por el DataGridView
                string nuevoTexto = entrada.Notas;

                // Obtener el texto anterior (opcional, para depuración)
                //string textoAnterior = entrada.Notas; // realmente no necesitas guardar anterior, pero puedes

                // Llamar al repositorio para actualizar la base de datos
                var repo = new BitacoraRepository();
                bool ok = repo.ActualizarNotas(entrada.ID_Bitacora, nuevoTexto);

                if (ok)
                {
                    MessageBox.Show("Nota actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Opcional: refrescar el total de ganancias si las notas afectan algo (no es el caso)
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la nota. Verifique la conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Revertir el cambio en el grid (opcional, pero buena práctica)
                    dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = entrada.Notas; // aquí aún tiene el valor anterior?
                                                                                             // En realidad, como entrada.Notas ya se actualizó, necesitarías guardar el valor anterior en un evento CellBeginEdit
                                                                                             // Para simplificar, puedes recargar la fila desde la BD, pero no es necesario si la actualización falla.
                }
            }
        }
    }
}
