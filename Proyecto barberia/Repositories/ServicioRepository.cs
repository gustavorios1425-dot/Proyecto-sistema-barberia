using Proyecto_barberia.Database;
using Proyecto_barberia.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_barberia.Repositories
{
    public class ServicioRepository
    {
        public List<ServicioEntidad> ObtenerTodos()
        {
            var servicios = new List<ServicioEntidad>();
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ID_Servicio, Nombre, DuracionMin, Precio, Activo FROM SERVICIO WHERE Activo = 1 ORDER BY Nombre";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        servicios.Add(new ServicioEntidad
                        {
                            ID_Servicio = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            DuracionMin = reader.GetInt32(2),
                            Precio = reader.GetDecimal(3),
                            Activo = reader.GetInt32(4) == 1
                        });
                    }
                }
            }
            return servicios;
        }

        // Opcional: Insertar un nuevo servicio (si lo necesitas)
        public int Insertar(ServicioEntidad servicio)
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO SERVICIO (Nombre, DuracionMin, Precio, Activo)
                    VALUES (@nombre, @duracion, @precio, @activo);
                    SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", servicio.Nombre);
                    cmd.Parameters.AddWithValue("@duracion", servicio.DuracionMin);
                    cmd.Parameters.AddWithValue("@precio", servicio.Precio);
                    cmd.Parameters.AddWithValue("@activo", servicio.Activo ? 1 : 0);
                    return System.Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Opcional: Obtener un servicio por ID
        public ServicioEntidad ObtenerPorId(int id)
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ID_Servicio, Nombre, DuracionMin, Precio, Activo FROM SERVICIO WHERE ID_Servicio = @id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ServicioEntidad
                            {
                                ID_Servicio = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                DuracionMin = reader.GetInt32(2),
                                Precio = reader.GetDecimal(3),
                                Activo = reader.GetInt32(4) == 1
                            };
                        }
                    }
                }
            }
            return null;
        }

    }
}
