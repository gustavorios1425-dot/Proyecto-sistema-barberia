using System;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Proyecto_barberia.Database;

namespace Proyecto_barberia
{
    public partial class RecuperarContraseña : Form
    {
        // Variables para arrastrar la ventana
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        // Variables para redimensionamiento
        private bool resizing = false;
        private int resizeBorder = 10;
        private ResizeDirection resizeDir = ResizeDirection.None;
        private enum ResizeDirection { None, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight }

        // Placeholder
        private string placeholderUsuario = "Tu nombre de usuario";

        public RecuperarContraseña()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(900, 700);
            this.Size = new Size(900, 700);
            this.BackColor = Color.FromArgb(18, 18, 18);

            // Configurar placeholder
            SetPlaceholder(txtUsuario, placeholderUsuario);
            txtUsuario.Enter += TxtUsuario_Enter;
            txtUsuario.Leave += TxtUsuario_Leave;

            // Eventos de redimensionamiento
            this.MouseDown += InicioSesion_MouseDown;
            this.MouseMove += InicioSesion_MouseMove;
            this.MouseUp += InicioSesion_MouseUp;

            // Agregar label para volver al SplashScreen en panel inferior
            AgregarLabelVolverSplash();
        }

        private void SetPlaceholder(TextBox txt, string texto)
        {
            if (string.IsNullOrWhiteSpace(txt.Text) || txt.Text == texto)
            {
                txt.Text = texto;
                txt.ForeColor = Color.Gray;
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

        private void AgregarLabelVolverSplash()
        {
            Label lblVolver = new Label();
            lblVolver.Text = "← Volver a J.I.G. Software";
            lblVolver.ForeColor = Color.WhiteSmoke;
            lblVolver.BackColor = Color.Transparent;
            lblVolver.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblVolver.Cursor = Cursors.Hand;
            lblVolver.Dock = DockStyle.Right;
            lblVolver.Padding = new Padding(10, 0, 10, 0);
            lblVolver.TextAlign = ContentAlignment.MiddleCenter;
            lblVolver.Click += (s, ev) =>
            {
                var splash = Application.OpenForms.OfType<SplashScreen>().FirstOrDefault();
                if (splash != null) splash.Show();
                else new SplashScreen().Show();
                this.Close();
            };
            pnlInferior.Controls.Add(lblVolver);
        }

        // --- Arrastre desde panel superior ---
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
        private void btnMinimizar_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximizar.Text = "🗖";
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximizar.Text = "❐";
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e) => Application.Exit();

        // --- Redimensionamiento ---
        private void InicioSesion_MouseDown(object sender, MouseEventArgs e) {
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
        private void InicioSesion_MouseMove(object sender, MouseEventArgs e) {
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
        private void InicioSesion_MouseUp(object sender, MouseEventArgs e) {
            resizing = false;
            this.Capture = false;
            this.Cursor = Cursors.Default;
        }

        // --- Lógica de recuperación ---
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(usuario) || usuario == placeholderUsuario)
            {
                MessageBox.Show("Ingrese su nombre de usuario.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT NombreUsuario, Password FROM USUARIO WHERE NombreUsuario = @user";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", usuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string password = reader.GetString(1);
                            MessageBox.Show($"Su contraseña es: {password}\n\nGuárdela en un lugar seguro.", "Recuperación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró un usuario con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => this.Close();

    }
}