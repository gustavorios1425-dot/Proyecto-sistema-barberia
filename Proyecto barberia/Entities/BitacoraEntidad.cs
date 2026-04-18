using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_barberia.Entities
{
    public class BitacoraEntidad
    {
        public int ID_Bitacora { get; set; }
        public int ID_Cliente { get; set; }
        public string NombreCliente { get; set; }   // para mostrar en grid
        public int ID_Servicio { get; set; }
        public string NombreServicio { get; set; }   // para mostrar
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public string Notas { get; set; }
    }
}
