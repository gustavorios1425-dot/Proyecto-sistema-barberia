using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_barberia.Entities
{
    public class ClienteEntidad
    {
        public int ID_Cliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string FechaRegistro { get; set; }
        public int TotalVisitas { get; set; }
        public bool EsLegendario { get; set; }
    }
}
