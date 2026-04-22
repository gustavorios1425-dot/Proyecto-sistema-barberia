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
        // Variables para arrastrar la ventana
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        // Variables para redimensionamiento manual
        private bool resizing = false;
        private int resizeBorder = 10; // grosor del borde para redimensionar
        private ResizeDirection resizeDir = ResizeDirection.None;

        private string placeholderUsuario = "Tu usuario";
        private string placeholderPassword = "Contraseña";

        private enum ResizeDirection
        {
            None, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight
        }

        public InicioSesion()
        {
            InitializeComponent();

            // Configuración de la ventana sin bordes
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(500, 500); // Tamaño mínimo (evita que se deforme)
            this.Size = new Size(1104, 700); // ajusta según tu contenido

            // Asignar eventos de redimensionamiento
            this.MouseDown += InicioSesion_MouseDown;
            this.MouseMove += InicioSesion_MouseMove;
            this.MouseUp += InicioSesion_MouseUp;

            // Configurar placeholders solo para campos no sensibles
            SetPlaceholder(txtUsuario, placeholderUsuario);

            // Contraseña: sin placeholder, oculta por defecto
            txtPassword.Text = "";
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.ForeColor = Color.Black;
            picBoxOculContra.Image = Properties.Resources.esconder;

            // Suscribir eventos (solo para entrada y salida básica, sin placeholder)
            txtPassword.Enter += TxtPassword_Enter;
            txtPassword.Leave += TxtPassword_Leave;
            txtUsuario.Enter += TxtUsuario_Enter;
            txtUsuario.Leave += TxtUsuario_Leave;

            // Agregar label en pnlInferior
            Label lblVolverSplash = new Label();
            lblVolverSplash.Text = "← Volver a J.I.G. Software";
            lblVolverSplash.ForeColor = Color.WhiteSmoke;
            lblVolverSplash.BackColor = Color.Transparent;
            lblVolverSplash.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblVolverSplash.Cursor = Cursors.Hand;
            lblVolverSplash.Dock = DockStyle.Right; // o Left, según prefieras
            lblVolverSplash.Padding = new Padding(10, 0, 10, 0);
            lblVolverSplash.TextAlign = ContentAlignment.MiddleCenter;
            lblVolverSplash.Click += (s, ev) =>
            {
                // Mostrar el SplashScreen (debe existir una instancia oculta)
                SplashScreen splash = Application.OpenForms.OfType<SplashScreen>().FirstOrDefault();
                if (splash != null)
                {
                    splash.Show();
                }
                else
                {
                    new SplashScreen().Show();
                }
                this.Close();
            };
            pnlInferior.Controls.Add(lblVolverSplash);
        }

        private void SetPlaceholder(TextBox txt, string texto, bool isPassword = false)
        {
            if (string.IsNullOrWhiteSpace(txt.Text) || txt.Text == texto)
            {
                txt.Text = texto;
                txt.ForeColor = Color.Gray;
                if (isPassword)
                {
                    txt.UseSystemPasswordChar = false;
                    txtPassword.UseSystemPasswordChar = false; // para que se vea el texto
                }
            }
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == placeholderUsuario)
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = placeholderUsuario;
                txtUsuario.ForeColor = Color.Gray;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == placeholderPassword)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true; // restaurar modo contraseña
                picBoxOculContra.Image = Properties.Resources.esconder;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = placeholderPassword;
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false; // mostrar texto plano del placeholder
                picBoxOculContra.Image = Properties.Resources.esconder; // ícono consistente
            }
        }

        // --- Arrastre desde la barra de título ---
        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.WindowState != FormWindowState.Maximized)
            {
                dragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void pnlTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && this.WindowState != FormWindowState.Maximized)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void pnlTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // --- Botones de la barra ---
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximizar.Text = "🗖"; // icono de maximizar (puedes cambiarlo)
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximizar.Text = "❐"; // icono de restaurar
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }

        // --- Redimensionamiento manual (bordes) ---
        private void InicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) return;
            Rectangle formRect = this.ClientRectangle;
            Point mousePos = this.PointToClient(MousePosition);

            // Detectar en qué borde se hizo clic
            if (mousePos.X <= resizeBorder && mousePos.Y <= resizeBorder)
                resizeDir = ResizeDirection.TopLeft;
            else if (mousePos.X >= formRect.Width - resizeBorder && mousePos.Y <= resizeBorder)
                resizeDir = ResizeDirection.TopRight;
            else if (mousePos.X <= resizeBorder && mousePos.Y >= formRect.Height - resizeBorder)
                resizeDir = ResizeDirection.BottomLeft;
            else if (mousePos.X >= formRect.Width - resizeBorder && mousePos.Y >= formRect.Height - resizeBorder)
                resizeDir = ResizeDirection.BottomRight;
            else if (mousePos.X <= resizeBorder)
                resizeDir = ResizeDirection.Left;
            else if (mousePos.X >= formRect.Width - resizeBorder)
                resizeDir = ResizeDirection.Right;
            else if (mousePos.Y <= resizeBorder)
                resizeDir = ResizeDirection.Top;
            else if (mousePos.Y >= formRect.Height - resizeBorder)
                resizeDir = ResizeDirection.Bottom;
            else
                resizeDir = ResizeDirection.None;

            if (resizeDir != ResizeDirection.None)
            {
                resizing = true;
                this.Capture = true;
            }
        }

        private void InicioSesion_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) return;
            if (!resizing)
            {
                // Cambiar el cursor según la zona del borde
                Rectangle formRect = this.ClientRectangle;
                Point mousePos = this.PointToClient(MousePosition);
                if (mousePos.X <= resizeBorder && mousePos.Y <= resizeBorder)
                    this.Cursor = Cursors.SizeNWSE;
                else if (mousePos.X >= formRect.Width - resizeBorder && mousePos.Y <= resizeBorder)
                    this.Cursor = Cursors.SizeNESW;
                else if (mousePos.X <= resizeBorder && mousePos.Y >= formRect.Height - resizeBorder)
                    this.Cursor = Cursors.SizeNESW;
                else if (mousePos.X >= formRect.Width - resizeBorder && mousePos.Y >= formRect.Height - resizeBorder)
                    this.Cursor = Cursors.SizeNWSE;
                else if (mousePos.X <= resizeBorder || mousePos.X >= formRect.Width - resizeBorder)
                    this.Cursor = Cursors.SizeWE;
                else if (mousePos.Y <= resizeBorder || mousePos.Y >= formRect.Height - resizeBorder)
                    this.Cursor = Cursors.SizeNS;
                else
                    this.Cursor = Cursors.Default;
            }
            else
            {
                // Redimensionar
                int newWidth = this.Width;
                int newHeight = this.Height;
                int newLeft = this.Left;
                int newTop = this.Top;

                switch (resizeDir)
                {
                    case ResizeDirection.Left:
                        newWidth = this.Width - (MousePosition.X - this.Left);
                        newLeft = MousePosition.X;
                        break;
                    case ResizeDirection.Right:
                        newWidth = MousePosition.X - this.Left;
                        break;
                    case ResizeDirection.Top:
                        newHeight = this.Height - (MousePosition.Y - this.Top);
                        newTop = MousePosition.Y;
                        break;
                    case ResizeDirection.Bottom:
                        newHeight = MousePosition.Y - this.Top;
                        break;
                    case ResizeDirection.TopLeft:
                        newWidth = this.Width - (MousePosition.X - this.Left);
                        newLeft = MousePosition.X;
                        newHeight = this.Height - (MousePosition.Y - this.Top);
                        newTop = MousePosition.Y;
                        break;
                    case ResizeDirection.TopRight:
                        newWidth = MousePosition.X - this.Left;
                        newHeight = this.Height - (MousePosition.Y - this.Top);
                        newTop = MousePosition.Y;
                        break;
                    case ResizeDirection.BottomLeft:
                        newWidth = this.Width - (MousePosition.X - this.Left);
                        newLeft = MousePosition.X;
                        newHeight = MousePosition.Y - this.Top;
                        break;
                    case ResizeDirection.BottomRight:
                        newWidth = MousePosition.X - this.Left;
                        newHeight = MousePosition.Y - this.Top;
                        break;
                }
                // Aplicar restricciones de tamaño mínimo
                if (newWidth < this.MinimumSize.Width) newWidth = this.MinimumSize.Width;
                if (newHeight < this.MinimumSize.Height) newHeight = this.MinimumSize.Height;
                if (newLeft + newWidth > Screen.PrimaryScreen.WorkingArea.Right) newLeft = Screen.PrimaryScreen.WorkingArea.Right - newWidth;
                if (newTop < 0) newTop = 0;
                if (newLeft < 0) newLeft = 0;
                if (newTop + newHeight > Screen.PrimaryScreen.WorkingArea.Bottom) newTop = Screen.PrimaryScreen.WorkingArea.Bottom - newHeight;

                this.SetBounds(newLeft, newTop, newWidth, newHeight);
            }
        }

        private void InicioSesion_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
            this.Capture = false;
            this.Cursor = Cursors.Default;
        }

        private void pnlCentral_Paint(object sender, PaintEventArgs e)
        {
            pnlCentral.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void linkCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (CrearCuenta frm = new CrearCuenta())
            {
                frm.ShowDialog();
            }
            LimpiarCampos();
            this.Show();
        }

        private void linkRecuperarClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (RecuperarContraseña frm = new RecuperarContraseña())
            {
                frm.ShowDialog();
            }
            LimpiarCampos();
            this.Show();
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
                // Contraseña oculta -> mostrarla
                txtPassword.UseSystemPasswordChar = false;
                picBoxOculContra.Image = Properties.Resources.ojo_abierto; // ojo abierto
            }
            else
            {
                // Contraseña visible -> ocultarla
                txtPassword.UseSystemPasswordChar = true;
                picBoxOculContra.Image = Properties.Resources.esconder; // ojo cerrado
            }
        }

        public void LimpiarCampos()
        {
            txtUsuario.Text = placeholderUsuario;
            txtUsuario.ForeColor = Color.Gray;
            txtPassword.Text = placeholderPassword;
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false; // para mostrar el placeholder
            picBoxOculContra.Image = Properties.Resources.esconder;
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
