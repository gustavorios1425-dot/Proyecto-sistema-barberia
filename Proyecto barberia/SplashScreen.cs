using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_barberia
{
    public partial class SplashScreen : Form
    {
        // P/Invoke para justificar texto en RichTextBox
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int EM_SETPARAFORMAT = 0x447;
        private const int PFM_ALIGNMENT = 0x00000008;
        private const int PFA_JUSTIFY = 0x00000004;

        [StructLayout(LayoutKind.Sequential)]
        private struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }

        private void JustificarRichTextBox(RichTextBox rtb)
        {
            PARAFORMAT2 pf = new PARAFORMAT2();
            pf.cbSize = Marshal.SizeOf(pf);
            pf.dwMask = PFM_ALIGNMENT;
            pf.wAlignment = PFA_JUSTIFY;
            IntPtr lParam = Marshal.AllocHGlobal(pf.cbSize);
            Marshal.StructureToPtr(pf, lParam, false);
            SendMessage(rtb.Handle, EM_SETPARAFORMAT, IntPtr.Zero, lParam);
            Marshal.FreeHGlobal(lParam);
        }

        public SplashScreen()
        {
            InitializeComponent();
            pictureBoxLogo.Image = Properties.Resources.LogoJIGSinFondo;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            // Aplicar justificación a cada RichTextBox
            JustificarRichTextBox(rtbDescripcion);
            JustificarRichTextBox(rtbVisionTexto);
            JustificarRichTextBox(rtbMisionTexto);
            JustificarRichTextBox(rtbContactoTexto);
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            InicioSesion login = new InicioSesion();
            login.Show();
            this.Hide();
        }

        // Arrastre de la ventana
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnlTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void pnlTitulo_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
