using System;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Proyecto_barberia.Database;

namespace Proyecto_barberia
{
    public partial class CrearCuenta : Form
    {
        // Variables para arrastrar y redimensionar
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        private bool resizing = false;
        private int resizeBorder = 10;
        private ResizeDirection resizeDir = ResizeDirection.None;
        private enum ResizeDirection { None, Left, Right, Top, Bottom, TopLeft, TopRight, BottomLeft, BottomRight }

        // Placeholders para campos normales (sin contraseña)
        private string placeholderNombres = "Tus nombres";
        private string placeholderApellidos = "Tus apellidos";
        private string placeholderUsuario = "Tu nombre de usuario";
        private string placeholderCorreo = "Correo@ejemplo.com";

        public CrearCuenta()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(900, 750);
            this.Size = new Size(900, 750);
            this.BackColor = Color.FromArgb(18, 18, 18);

            // Configurar placeholders para campos normales
            SetPlaceholder(txtNombres, placeholderNombres);
            SetPlaceholder(txtApellidos, placeholderApellidos);
            SetPlaceholder(txtUsuario, placeholderUsuario);
            SetPlaceholder(txtCorreo, placeholderCorreo);

            // Configurar contraseña: vacía, oculta, sin placeholder
            txtPassword.Text = "";
            txtPassword.UseSystemPasswordChar = true;   // Oculto por defecto
            txtPassword.ForeColor = Color.Black;
            picBoxOculContra.Image = Properties.Resources.esconder;  // Ojo tachado

            // Eventos para placeholders normales
            txtNombres.Enter += Txt_Enter; txtNombres.Leave += Txt_Leave;
            txtApellidos.Enter += Txt_Enter; txtApellidos.Leave += Txt_Leave;
            txtUsuario.Enter += Txt_Enter; txtUsuario.Leave += Txt_Leave;
            txtCorreo.Enter += Txt_Enter; txtCorreo.Leave += Txt_Leave;

            // Eventos de redimensionamiento
            this.MouseDown += InicioSesion_MouseDown;
            this.MouseMove += InicioSesion_MouseMove;
            this.MouseUp += InicioSesion_MouseUp;

            // Label volver a splash
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

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Text == placeholderNombres || txt.Text == placeholderApellidos || txt.Text == placeholderUsuario || txt.Text == placeholderCorreo)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
            }
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                if (txt == txtNombres) txt.Text = placeholderNombres;
                else if (txt == txtApellidos) txt.Text = placeholderApellidos;
                else if (txt == txtUsuario) txt.Text = placeholderUsuario;
                else if (txt == txtCorreo) txt.Text = placeholderCorreo;
                txt.ForeColor = Color.Gray;
            }
        }

        private void AgregarLabelVolverSplash()
        {
            Label lblVolver = new Label();
            lblVolver.Text = "← Volver a J.I.G. Software";
            lblVolver.ForeColor = Color.Gray;
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
        private void InicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) return;
            Rectangle formRect = this.ClientRectangle;
            Point mousePos = this.PointToClient(MousePosition);

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

        // --- Botón del ojo (MUESTRA/OCULTA CONTRASEÑA) ---
        private void picBoxOculContra_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                // Mostrar contraseña
                txtPassword.UseSystemPasswordChar = false;
                picBoxOculContra.Image = Properties.Resources.ojo_abierto;
            }
            else
            {
                // Ocultar contraseña
                txtPassword.UseSystemPasswordChar = true;
                picBoxOculContra.Image = Properties.Resources.esconder;
            }
        }

        // --- Crear cuenta (con validación de campos) ---
        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string email = txtCorreo.Text.Trim();

            // Si el campo tiene placeholder, lo tratamos como vacío
            if (usuario == placeholderUsuario) usuario = "";
            if (nombres == placeholderNombres) nombres = "";
            if (apellidos == placeholderApellidos) apellidos = "";
            if (email == placeholderCorreo) email = "";

            // Validaciones
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(nombres))
            {
                MessageBox.Show("Los nombres son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(apellidos))
            {
                MessageBox.Show("Los apellidos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
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

                // Insertar barbero
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

                // Insertar usuario
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

        private void linkIniciarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}