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
    public class CitaRepository
    {
        public List<CitaEntidad> ObtenerTodas()
        {
            var citas = new List<CitaEntidad>();
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT c.ID_Cita, c.ID_Cliente, cl.NombreCompleto AS NombreCliente,
                           c.ID_Barbero, b.Nombre1 || ' ' || b.Apellido_Paterno AS NombreBarbero,
                           c.ID_Servicio, s.Nombre AS NombreServicio,
                           c.FechaHora, c.Estado, c.Notas, c.FechaSolicitud, c.Precio
                    FROM CITA c
                    JOIN CLIENTE cl ON c.ID_Cliente = cl.ID_Cliente
                    JOIN BARBERO b ON c.ID_Barbero = b.ID_Barbero
                    JOIN SERVICIO s ON c.ID_Servicio = s.ID_Servicio
                    ORDER BY c.FechaHora DESC";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        citas.Add(new CitaEntidad
                        {
                            ID_Cita = reader.GetInt32(0),
                            ID_Cliente = reader.GetInt32(1),
                            NombreCliente = reader.GetString(2),
                            ID_Barbero = reader.GetInt32(3),
                            NombreBarbero = reader.GetString(4),
                            ID_Servicio = reader.GetInt32(5),
                            NombreServicio = reader.GetString(6),
                            FechaHora = reader.GetDateTime(7),
                            Estado = reader.GetString(8),
                            Notas = reader.IsDBNull(9) ? null : reader.GetString(9),
                            FechaSolicitud = reader.GetDateTime(10),
                            Precio = reader.GetDecimal(11)
                        });
                    }
                }
            }
            return citas;
        }

        public int Insertar(CitaEntidad cita)
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO CITA (ID_Cliente, ID_Barbero, ID_Servicio, FechaHora, Estado, Notas, Precio)
                    VALUES (@idCliente, @idBarbero, @idServicio, @fechaHora, @estado, @notas, @precio);
                    SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", cita.ID_Cliente);
                    cmd.Parameters.AddWithValue("@idBarbero", cita.ID_Barbero);
                    cmd.Parameters.AddWithValue("@idServicio", cita.ID_Servicio);
                    cmd.Parameters.AddWithValue("@fechaHora", cita.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@estado", cita.Estado ?? "Pendiente");
                    cmd.Parameters.AddWithValue("@notas", cita.Notas ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", cita.Precio);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool ActualizarCita(CitaEntidad cita)
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"
                    UPDATE CITA 
                    SET ID_Cliente = @idCliente, ID_Barbero = @idBarbero, ID_Servicio = @idServicio,
                        FechaHora = @fechaHora, Estado = @estado, Notas = @notas, Precio = @precio
                    WHERE ID_Cita = @id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", cita.ID_Cliente);
                    cmd.Parameters.AddWithValue("@idBarbero", cita.ID_Barbero);
                    cmd.Parameters.AddWithValue("@idServicio", cita.ID_Servicio);
                    cmd.Parameters.AddWithValue("@fechaHora", cita.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@estado", cita.Estado);
                    cmd.Parameters.AddWithValue("@notas", cita.Notas ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@precio", cita.Precio);
                    cmd.Parameters.AddWithValue("@id", cita.ID_Cita);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
