using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_barberia
{
    internal static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creamos el formulario de registro pero NO lo metemos en Run() todavía
            CrearCuenta registro = new CrearCuenta();

            // Si el registro se cierra o se oculta, el programa sigue vivo
            registro.Show();

            // Esta línea mantiene el programa funcionando aunque ocultes ventanas
            Application.Run();

        }
    }
}
