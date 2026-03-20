using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_barberia
{
    public partial class Form1 : Form
    {
        public int clickX, clickY; //variables declardas para mover el form
        public Form1()
        {
            InitializeComponent();
        }

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {
            panelSuperior.BackColor = Color.FromArgb(45,45,45);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Left mueve las ejes de las x
            //Top mueve las ejes de las y
            if(e.Button != MouseButtons.Left)
            {
                clickX = e.X;  clickY = e.Y;

            } 
            else
            {
                this.Left = this.Left + (e.X);
                this.Top = this.Top + (e.Y);
            }


        }
    }
}
