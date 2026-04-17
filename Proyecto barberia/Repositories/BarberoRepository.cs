using Proyecto_barberia.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_barberia.Entities;

namespace Proyecto_barberia.Repositories
{
    public class BarberoRepository
    {
        public List<BarberoEntidad> ObtenerTodos()
        {
            var barberos = new List<BarberoEntidad>();
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ID_Barbero, Nombre1, Apellido_Paterno FROM BARBERO WHERE Activo = 1";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        barberos.Add(new BarberoEntidad
                        {
                            ID_Barbero = reader.GetInt32(0),
                            NombreCompleto = reader.GetString(1) + " " + reader.GetString(2)
                        });
                    }
                }
            }
            return barberos;
        }
    }
}
