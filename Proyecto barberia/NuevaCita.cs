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
    public partial class NuevaCita : Form
    {
        public NuevaCita()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { maskedTextBox1.SelectionStart = 0; });
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate { maskedTextBox2.SelectionStart = 0; });
        }
    }
}
