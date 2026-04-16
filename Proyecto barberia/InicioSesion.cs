using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.SQLite;
using Proyecto_barberia.Database;

namespace Proyecto_barberia
{
    public partial class InicioSesion : Form
    {
        //public int clickX, clickY; //variables declardas para mover el form

        public InicioSesion()
        {
            InitializeComponent();
        }

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {
            panelSuperior.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void linkCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();  // Oculta el login
            using (CrearCuenta frm = new CrearCuenta())
            {
                frm.ShowDialog();  // Abre como diálogo modal
            }
            this.Show();  // Cuando se cierre CrearCuenta, muestra el login nuevamente
        }

        private void linkRecuperarClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
            this.Hide(); // Oculta el formulario actual
            RecuperarContraseña frm = new RecuperarContraseña();
            frm.ShowDialog();
            this.Close(); // Cierra el formulario actual
            */

            this.Hide();  // Oculta el login
            using (RecuperarContraseña frm = new RecuperarContraseña())
            {
                frm.ShowDialog();  // Abre como diálogo modal
            }
            this.Show();  // Cuando se cierre CrearCuenta, muestra el login nuevamente
        }

        /*/ Importar funciones de Windows para el movimiento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        */

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ID_Usuario, Rol FROM USUARIO WHERE NombreUsuario = @user AND Password = @pass";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", usuario);
                    cmd.Parameters.AddWithValue("@pass", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idUsuario = reader.GetInt32(0);
                            string rol = reader.GetString(1);
                            // Guardar datos del usuario logueado
                            DatosGlobales.UsuarioActual = idUsuario;
                            DatosGlobales.RolActual = rol;
                            DatosGlobales.NombreUsuario = usuario; // Para mostrar en UI

                            // Abrir el formulario principal
                            this.Hide();  // No this.Close()
                            Inicio main = new Inicio();
                            main.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            /*
            // Dentro del botón "Iniciar Sesión"
            string correo = textBox1.Text;
            string pass = textBox2.Text;

            // Buscamos en la lista global
            var user = DatosGlobales.Repositorio.ListaUsuarios
                .FirstOrDefault(u => u.Correo == correo && u.Contrasena == pass);

            if (user != null)
            {
                MessageBox.Show("¡Bienvenido " + user.Nombres + "!");
                // Aquí abrirías tu formulario principal (Dashboard)
                Inicio Ventana2 = new Inicio();
                Ventana2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
            }
            */

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

        public void LimpiarCampos()
        {
            txtUsuario.Text = "Tu Usuario";
            txtPassword.Text = "********";
        }

        /*
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        */

    }

}
