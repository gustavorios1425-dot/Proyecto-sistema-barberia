namespace Proyecto_barberia
{
    partial class SplashScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSobre = new System.Windows.Forms.Label();
            this.rtbDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblVisionTitulo = new System.Windows.Forms.Label();
            this.rtbVisionTexto = new System.Windows.Forms.RichTextBox();
            this.lblMisionTitulo = new System.Windows.Forms.Label();
            this.rtbMisionTexto = new System.Windows.Forms.RichTextBox();
            this.lblContactoTitulo = new System.Windows.Forms.Label();
            this.rtbContactoTexto = new System.Windows.Forms.RichTextBox();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.pnlSuperior.SuspendLayout();
            this.pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.pnlDerecho.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnlSuperior.Controls.Add(this.lblTitulo);
            this.pnlSuperior.Controls.Add(this.btnMinimizar);
            this.pnlSuperior.Controls.Add(this.btnCerrar);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(900, 49);
            this.pnlSuperior.TabIndex = 0;
            this.pnlSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseDown);
            this.pnlSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseMove);
            this.pnlSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseUp);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(279, 28);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "J.I.G. Software Development";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(809, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(43, 49);
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.Text = "—";
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(855, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(45, 46);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "✕";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlIzquierdo.Controls.Add(this.pictureBoxLogo);
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierdo.Location = new System.Drawing.Point(0, 49);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Size = new System.Drawing.Size(400, 551);
            this.pnlIzquierdo.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogo.Image = global::Proyecto_barberia.Properties.Resources.LogoJIGSinFondo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(400, 551);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlDerecho.Controls.Add(this.tableLayoutPanel1);
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecho.Location = new System.Drawing.Point(400, 49);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDerecho.Size = new System.Drawing.Size(500, 551);
            this.pnlDerecho.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblSobre, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbDescripcion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblVisionTitulo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rtbVisionTexto, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMisionTitulo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.rtbMisionTexto, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblContactoTitulo, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.rtbContactoTexto, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnAcceder, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 511);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblSobre
            // 
            this.lblSobre.AutoSize = true;
            this.lblSobre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSobre.Location = new System.Drawing.Point(3, 0);
            this.lblSobre.Name = "lblSobre";
            this.lblSobre.Size = new System.Drawing.Size(209, 40);
            this.lblSobre.TabIndex = 0;
            this.lblSobre.Text = "Sobre J.I.G.";
            // 
            // rtbDescripcion
            // 
            this.rtbDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.rtbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbDescripcion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbDescripcion.Location = new System.Drawing.Point(3, 43);
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = true;
            this.rtbDescripcion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDescripcion.Size = new System.Drawing.Size(454, 84);
            this.rtbDescripcion.TabIndex = 1;
            this.rtbDescripcion.Text = resources.GetString("rtbDescripcion.Text");
            // 
            // lblVisionTitulo
            // 
            this.lblVisionTitulo.AutoSize = true;
            this.lblVisionTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVisionTitulo.Location = new System.Drawing.Point(3, 130);
            this.lblVisionTitulo.Name = "lblVisionTitulo";
            this.lblVisionTitulo.Size = new System.Drawing.Size(92, 30);
            this.lblVisionTitulo.TabIndex = 2;
            this.lblVisionTitulo.Text = "Visión:";
            // 
            // rtbVisionTexto
            // 
            this.rtbVisionTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.rtbVisionTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbVisionTexto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbVisionTexto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbVisionTexto.Location = new System.Drawing.Point(3, 163);
            this.rtbVisionTexto.Name = "rtbVisionTexto";
            this.rtbVisionTexto.ReadOnly = true;
            this.rtbVisionTexto.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbVisionTexto.Size = new System.Drawing.Size(454, 74);
            this.rtbVisionTexto.TabIndex = 3;
            this.rtbVisionTexto.Text = resources.GetString("rtbVisionTexto.Text");
            // 
            // lblMisionTitulo
            // 
            this.lblMisionTitulo.AutoSize = true;
            this.lblMisionTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMisionTitulo.Location = new System.Drawing.Point(3, 240);
            this.lblMisionTitulo.Name = "lblMisionTitulo";
            this.lblMisionTitulo.Size = new System.Drawing.Size(99, 30);
            this.lblMisionTitulo.TabIndex = 4;
            this.lblMisionTitulo.Text = "Misión:";
            // 
            // rtbMisionTexto
            // 
            this.rtbMisionTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.rtbMisionTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMisionTexto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbMisionTexto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbMisionTexto.Location = new System.Drawing.Point(3, 273);
            this.rtbMisionTexto.Name = "rtbMisionTexto";
            this.rtbMisionTexto.ReadOnly = true;
            this.rtbMisionTexto.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbMisionTexto.Size = new System.Drawing.Size(454, 74);
            this.rtbMisionTexto.TabIndex = 5;
            this.rtbMisionTexto.Text = resources.GetString("rtbMisionTexto.Text");
            // 
            // lblContactoTitulo
            // 
            this.lblContactoTitulo.AutoSize = true;
            this.lblContactoTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblContactoTitulo.Location = new System.Drawing.Point(3, 350);
            this.lblContactoTitulo.Name = "lblContactoTitulo";
            this.lblContactoTitulo.Size = new System.Drawing.Size(124, 30);
            this.lblContactoTitulo.TabIndex = 6;
            this.lblContactoTitulo.Text = "Contacto:";
            // 
            // rtbContactoTexto
            // 
            this.rtbContactoTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.rtbContactoTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContactoTexto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbContactoTexto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbContactoTexto.Location = new System.Drawing.Point(3, 383);
            this.rtbContactoTexto.Name = "rtbContactoTexto";
            this.rtbContactoTexto.ReadOnly = true;
            this.rtbContactoTexto.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbContactoTexto.Size = new System.Drawing.Size(454, 54);
            this.rtbContactoTexto.TabIndex = 7;
            this.rtbContactoTexto.Text = "Gustavorios1425@gmail.com\nIvan_vallec_13@hotmail.com\nJuanangellorenzana853@gmail." +
    "com\n";
            // 
            // btnAcceder
            // 
            this.btnAcceder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAcceder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(172)))), ((int)(((byte)(107)))));
            this.btnAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAcceder.ForeColor = System.Drawing.Color.Black;
            this.btnAcceder.Location = new System.Drawing.Point(80, 458);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(300, 50);
            this.btnAcceder.TabIndex = 8;
            this.btnAcceder.Text = "Acceder al sistema";
            this.btnAcceder.UseVisualStyleBackColor = false;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierdo);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.Text = "J.I.G. Software";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.pnlDerecho.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSobre;
        private System.Windows.Forms.RichTextBox rtbDescripcion;
        private System.Windows.Forms.Label lblVisionTitulo;
        private System.Windows.Forms.RichTextBox rtbVisionTexto;
        private System.Windows.Forms.Label lblMisionTitulo;
        private System.Windows.Forms.RichTextBox rtbMisionTexto;
        private System.Windows.Forms.Label lblContactoTitulo;
        private System.Windows.Forms.RichTextBox rtbContactoTexto;
        private System.Windows.Forms.Button btnAcceder;
    }
}