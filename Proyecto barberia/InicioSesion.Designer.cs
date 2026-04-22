using System.Windows.Forms;

namespace Proyecto_barberia
{
    partial class InicioSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioSesion));
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.linkCrearCuenta = new System.Windows.Forms.LinkLabel();
            this.lblNoTienesCuenta = new System.Windows.Forms.Label();
            this.linkRecuperar = new System.Windows.Forms.LinkLabel();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.picBoxOculContra = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblTituloLB = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pnlCentral.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOculContra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCentral
            // 
            this.pnlCentral.AllowDrop = true;
            this.pnlCentral.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlCentral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlCentral.Controls.Add(this.linkCrearCuenta);
            this.pnlCentral.Controls.Add(this.lblNoTienesCuenta);
            this.pnlCentral.Controls.Add(this.linkRecuperar);
            this.pnlCentral.Controls.Add(this.btnIniciarSesion);
            this.pnlCentral.Controls.Add(this.label7);
            this.pnlCentral.Controls.Add(this.txtUsuario);
            this.pnlCentral.Controls.Add(this.label6);
            this.pnlCentral.Controls.Add(this.label5);
            this.pnlCentral.Controls.Add(this.label4);
            this.pnlCentral.Controls.Add(this.pnlPassword);
            this.pnlCentral.Location = new System.Drawing.Point(357, 420);
            this.pnlCentral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(415, 452);
            this.pnlCentral.TabIndex = 0;
            this.pnlCentral.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCentral_Paint);
            // 
            // linkCrearCuenta
            // 
            this.linkCrearCuenta.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkCrearCuenta.AutoSize = true;
            this.linkCrearCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCrearCuenta.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.linkCrearCuenta.Location = new System.Drawing.Point(229, 396);
            this.linkCrearCuenta.Name = "linkCrearCuenta";
            this.linkCrearCuenta.Size = new System.Drawing.Size(120, 25);
            this.linkCrearCuenta.TabIndex = 5;
            this.linkCrearCuenta.TabStop = true;
            this.linkCrearCuenta.Text = "Regístrate";
            this.linkCrearCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkCrearCuenta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCrearCuenta_LinkClicked);
            // 
            // lblNoTienesCuenta
            // 
            this.lblNoTienesCuenta.AutoSize = true;
            this.lblNoTienesCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTienesCuenta.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNoTienesCuenta.Location = new System.Drawing.Point(58, 398);
            this.lblNoTienesCuenta.Name = "lblNoTienesCuenta";
            this.lblNoTienesCuenta.Size = new System.Drawing.Size(165, 22);
            this.lblNoTienesCuenta.TabIndex = 0;
            this.lblNoTienesCuenta.Text = "¿No tienes cuenta?";
            // 
            // linkRecuperar
            // 
            this.linkRecuperar.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkRecuperar.AutoSize = true;
            this.linkRecuperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRecuperar.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(154)))), ((int)(((byte)(175)))));
            this.linkRecuperar.Location = new System.Drawing.Point(95, 356);
            this.linkRecuperar.Name = "linkRecuperar";
            this.linkRecuperar.Size = new System.Drawing.Size(219, 22);
            this.linkRecuperar.TabIndex = 4;
            this.linkRecuperar.TabStop = true;
            this.linkRecuperar.Text = "¿Olvidaste tu contraseña?";
            this.linkRecuperar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecuperarClicked);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnIniciarSesion.Location = new System.Drawing.Point(45, 301);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(325, 48);
            this.btnIniciarSesion.TabIndex = 3;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(40, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtUsuario.Location = new System.Drawing.Point(45, 133);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(325, 44);
            this.txtUsuario.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(39, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Usuario";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(41, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ingresa tus credenciales para continuar";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.label4.Location = new System.Drawing.Point(130, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Iniciar Sesión";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlPassword
            // 
            this.pnlPassword.Controls.Add(this.picBoxOculContra);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(45, 224);
            this.pnlPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(325, 44);
            this.pnlPassword.TabIndex = 10;
            // 
            // picBoxOculContra
            // 
            this.picBoxOculContra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxOculContra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picBoxOculContra.Image = global::Proyecto_barberia.Properties.Resources.esconder;
            this.picBoxOculContra.Location = new System.Drawing.Point(272, 0);
            this.picBoxOculContra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBoxOculContra.Name = "picBoxOculContra";
            this.picBoxOculContra.Size = new System.Drawing.Size(53, 44);
            this.picBoxOculContra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxOculContra.TabIndex = 6;
            this.picBoxOculContra.TabStop = false;
            this.picBoxOculContra.Click += new System.EventHandler(this.picBoxOculContra_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Location = new System.Drawing.Point(0, 0);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(325, 44);
            this.txtPassword.TabIndex = 2;
            // 
            // lblTituloLB
            // 
            this.lblTituloLB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTituloLB.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloLB.Font = new System.Drawing.Font("Georgia", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.lblTituloLB.Location = new System.Drawing.Point(326, 292);
            this.lblTituloLB.Name = "lblTituloLB";
            this.lblTituloLB.Size = new System.Drawing.Size(460, 66);
            this.lblTituloLB.TabIndex = 0;
            this.lblTituloLB.Text = "Legendary Barber";
            this.lblTituloLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubTitulo.Location = new System.Drawing.Point(376, 358);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(345, 29);
            this.lblSubTitulo.TabIndex = 0;
            this.lblSubTitulo.Text = "Sistema de gestión profesional";
            this.lblSubTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxLogo.Image = global::Proyecto_barberia.Properties.Resources.Logo;
            this.picBoxLogo.Location = new System.Drawing.Point(357, 86);
            this.picBoxLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(381, 202);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogo.TabIndex = 5;
            this.picBoxLogo.TabStop = false;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlSuperior.Controls.Add(this.btnMinimizar);
            this.pnlSuperior.Controls.Add(this.btnMaximizar);
            this.pnlSuperior.Controls.Add(this.btnCerrar);
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1104, 50);
            this.pnlSuperior.TabIndex = 6;
            this.pnlSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseDown);
            this.pnlSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseMove);
            this.pnlSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseUp);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnMinimizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMinimizar.Location = new System.Drawing.Point(965, 0);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(45, 45);
            this.btnMinimizar.TabIndex = 6;
            this.btnMinimizar.Text = "—";
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnMaximizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMaximizar.Location = new System.Drawing.Point(1012, 0);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(45, 45);
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.Text = "🗖";
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrar.Location = new System.Drawing.Point(1059, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(45, 45);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "x";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlInferior.Location = new System.Drawing.Point(0, 902);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1104, 70);
            this.pnlInferior.TabIndex = 7;
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1104, 972);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.lblSubTitulo);
            this.Controls.Add(this.lblTituloLB);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.picBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1104, 972);
            this.Name = "InicioSesion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Legendary Barber";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InicioSesion_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InicioSesion_MouseUp);
            this.pnlCentral.ResumeLayout(false);
            this.pnlCentral.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOculContra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlCentral;
        private Label lblTituloLB;
        private Label lblSubTitulo;
        private PictureBox picBoxLogo;
        private Label label5;
        private Label label4;
        private TextBox txtUsuario;
        private Label label6;
        private Label label7;
        private TextBox txtPassword;
        private Button btnIniciarSesion;
        private LinkLabel linkRecuperar;
        private Label lblNoTienesCuenta;
        private LinkLabel linkCrearCuenta;
        private Panel pnlPassword;
        private PictureBox picBoxOculContra;
        private Panel pnlSuperior;
        private Button btnCerrar;
        private Button btnMaximizar;
        private Button btnMinimizar;
        private Panel pnlInferior;
    }
}

