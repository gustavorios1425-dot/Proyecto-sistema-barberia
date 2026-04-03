using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_barberia
{
    internal class DatosGlobales
    {
        public class Usuario
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Correo { get; set; }
            public string Contrasena { get; set; }
        }

        public static class Repositorio
        {
            // Aquí se guardarán los usuarios mientras el programa esté ejecutándose
            public static List<Usuario> ListaUsuarios = new List<Usuario>();
        }
    }
}
