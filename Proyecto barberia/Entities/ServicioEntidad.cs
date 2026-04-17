using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_barberia.Entities
{
    public class ServicioEntidad
    {
        public int ID_Servicio { get; set; }
        public string Nombre { get; set; }
        public int DuracionMin { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }
    }
}
