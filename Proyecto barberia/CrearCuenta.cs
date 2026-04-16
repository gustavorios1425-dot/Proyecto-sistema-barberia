using Proyecto_barberia.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_barberia.DatosGlobales;

namespace Proyecto_barberia
{
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private void picBoxOculContra_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                // Contraseña oculta (puntos) → la mostramos en texto
                txtPassword.UseSystemPasswordChar = false;
                // Ponemos ojo cerrado para indicar que ahora se puede ocultar
                picBoxOculContra.Image = Properties.Resources.esconder;
            }
            else
            {
                // Contraseña visible → la volvemos a ocultar
                txtPassword.UseSystemPasswordChar = true;
                // Ponemos ojo abierto para indicar que se puede mostrar
                picBoxOculContra.Image = Properties.Resources.ojo_abierto;
            }
        }

        private void linkIniciarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); // Cierra el formulario de registro
        }

        // Importar funciones de Windows para el movimiento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void CrearCuenta_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string email = txtCorreo.Text.Trim();

            // Validaciones básicas
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidos))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                // Verificar si el nombre de usuario ya existe
                string checkUser = "SELECT COUNT(*) FROM USUARIO WHERE NombreUsuario = @user";
                using (var cmdCheck = new SQLiteCommand(checkUser, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@user", usuario);
                    if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("El nombre de usuario ya existe. Elige otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 1. Insertar nuevo barbero
                string insertBarbero = @"
                    INSERT INTO BARBERO (Nombre1, Apellido_Paterno, Telefono)
                    VALUES (@nombre, @apellido, '000-000-0000');
                    SELECT last_insert_rowid();";
                int idBarbero;
                using (var cmdBarbero = new SQLiteCommand(insertBarbero, conn))
                {
                    cmdBarbero.Parameters.AddWithValue("@nombre", nombres);
                    cmdBarbero.Parameters.AddWithValue("@apellido", apellidos);
                    idBarbero = Convert.ToInt32(cmdBarbero.ExecuteScalar());
                }

                // 2. Insertar usuario asociado al barbero
                string insertUsuario = @"
                    INSERT INTO USUARIO (ID_Barbero, NombreUsuario, Password, Rol, Activo)
                    VALUES (@idBarbero, @user, @pass, 'barbero', 1)";
                using (var cmdUser = new SQLiteCommand(insertUsuario, conn))
                {
                    cmdUser.Parameters.AddWithValue("@idBarbero", idBarbero);
                    cmdUser.Parameters.AddWithValue("@user", usuario);
                    cmdUser.Parameters.AddWithValue("@pass", password);
                    cmdUser.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cuenta creada exitosamente. Ahora puedes iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
