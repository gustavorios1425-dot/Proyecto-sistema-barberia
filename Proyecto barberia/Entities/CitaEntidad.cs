using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_barberia.Entities
{
    public class CitaEntidad
    {
        public int ID_Cita { get; set; }
        public int ID_Cliente { get; set; }
        public string NombreCliente { get; set; } // para mostrar en el grid
        public int ID_Barbero { get; set; }
        public string NombreBarbero { get; set; }
        public int ID_Servicio { get; set; }
        public string NombreServicio { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal Precio { get; set; }
    }
}
