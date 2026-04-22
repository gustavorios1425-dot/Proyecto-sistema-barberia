namespace Proyecto_barberia
{
    partial class RecuperarContraseña
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperarContraseña));
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.linkVolver = new System.Windows.Forms.LinkLabel();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.lblTituloLB = new System.Windows.Forms.Label();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 902);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(1104, 70);
            this.pnlInferior.TabIndex = 1;
            // 
            // pnlCentral
            // 
            this.pnlCentral.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlCentral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlCentral.Controls.Add(this.linkVolver);
            this.pnlCentral.Controls.Add(this.btnRecuperar);
            this.pnlCentral.Controls.Add(this.txtUsuario);
            this.pnlCentral.Controls.Add(this.label3);
            this.pnlCentral.Controls.Add(this.label2);
            this.pnlCentral.Controls.Add(this.label1);
            this.pnlCentral.Location = new System.Drawing.Point(337, 422);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(415, 320);
            this.pnlCentral.TabIndex = 2;
            // 
            // linkVolver
            // 
            this.linkVolver.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.linkVolver.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkVolver.AutoSize = true;
            this.linkVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.linkVolver.LinkColor = System.Drawing.Color.WhiteSmoke;
            this.linkVolver.Location = new System.Drawing.Point(71, 256);
            this.linkVolver.Name = "linkVolver";
            this.linkVolver.Size = new System.Drawing.Size(277, 25);
            this.linkVolver.TabIndex = 5;
            this.linkVolver.TabStop = true;
            this.linkVolver.Text = "Volver al inicio de sesión";
            this.linkVolver.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkVolver.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVolver_LinkClicked);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecuperar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.btnRecuperar.FlatAppearance.BorderSize = 0;
            this.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecuperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnRecuperar.Location = new System.Drawing.Point(66, 196);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(282, 40);
            this.btnRecuperar.TabIndex = 4;
            this.btnRecuperar.Text = "Recuperar Contraseña";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.Location = new System.Drawing.Point(37, 126);
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(339, 40);
            this.txtUsuario.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(85, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingresa tu nombre de usuario";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.label1.Location = new System.Drawing.Point(83, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recuperar contraseña";
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblSubTitulo.Location = new System.Drawing.Point(374, 355);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(345, 29);
            this.lblSubTitulo.TabIndex = 6;
            this.lblSubTitulo.Text = "Sistema de gestión profesional";
            this.lblSubTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloLB
            // 
            this.lblTituloLB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTituloLB.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloLB.Font = new System.Drawing.Font("Georgia", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.lblTituloLB.Location = new System.Drawing.Point(324, 289);
            this.lblTituloLB.Name = "lblTituloLB";
            this.lblTituloLB.Size = new System.Drawing.Size(460, 66);
            this.lblTituloLB.TabIndex = 7;
            this.lblTituloLB.Text = "Legendary Barber";
            this.lblTituloLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxLogo.Image = global::Proyecto_barberia.Properties.Resources.Logo;
            this.picBoxLogo.Location = new System.Drawing.Point(355, 83);
            this.picBoxLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(381, 202);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogo.TabIndex = 8;
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
            this.pnlSuperior.TabIndex = 9;
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
            this.btnMinimizar.Size = new System.Drawing.Size(45, 50);
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
            this.btnMaximizar.Size = new System.Drawing.Size(45, 50);
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
            this.btnCerrar.Size = new System.Drawing.Size(45, 50);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.Text = "x";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // RecuperarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1104, 972);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.lblSubTitulo);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.lblTituloLB);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.picBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1104, 972);
            this.Name = "RecuperarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InicioSesion_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InicioSesion_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InicioSesion_MouseUp);
            this.pnlCentral.ResumeLayout(false);
            this.pnlCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Panel pnlInferior;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.LinkLabel linkVolver;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.Label lblTituloLB;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnCerrar;
    }
}