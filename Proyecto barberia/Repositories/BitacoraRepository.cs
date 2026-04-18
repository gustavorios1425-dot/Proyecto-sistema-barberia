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
    public class BitacoraRepository
    {
        // Obtener todas las entradas con JOIN para nombres
        public List<BitacoraEntidad> ObtenerTodas()
        {
            var lista = new List<BitacoraEntidad>();
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"
                    SELECT b.ID_Bitacora, b.ID_Cliente, c.NombreCompleto,
                           b.ID_Servicio, s.Nombre, b.Precio, b.Fecha, b.Notas
                    FROM BITACORA b
                    JOIN CLIENTE c ON b.ID_Cliente = c.ID_Cliente
                    JOIN SERVICIO s ON b.ID_Servicio = s.ID_Servicio
                    ORDER BY b.Fecha DESC";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new BitacoraEntidad
                        {
                            ID_Bitacora = reader.GetInt32(0),
                            ID_Cliente = reader.GetInt32(1),
                            NombreCliente = reader.GetString(2),
                            ID_Servicio = reader.GetInt32(3),
                            NombreServicio = reader.GetString(4),
                            Precio = reader.GetDecimal(5),
                            Fecha = reader.GetDateTime(6),
                            Notas = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }
            return lista;
        }

        // Insertar nueva entrada
        public int Insertar(BitacoraEntidad entrada)
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"
                    INSERT INTO BITACORA (ID_Cliente, ID_Servicio, Precio, Fecha, Notas)
                    VALUES (@idCliente, @idServicio, @precio, @fecha, @notas);
                    SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@idCliente", entrada.ID_Cliente);
                    cmd.Parameters.AddWithValue("@idServicio", entrada.ID_Servicio);
                    cmd.Parameters.AddWithValue("@precio", entrada.Precio);
                    cmd.Parameters.AddWithValue("@fecha", entrada.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@notas", entrada.Notas ?? (object)DBNull.Value);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Obtener suma total de precios (ganancias)
        public decimal ObtenerTotalGanancias()
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT SUM(Precio) FROM BITACORA";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
                }
            }
        }

        // Búsqueda por cliente o servicio
        public List<BitacoraEntidad> Buscar(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return ObtenerTodas();

            filtro = filtro.ToLower();
            var todas = ObtenerTodas();
            return todas.FindAll(e =>
                e.NombreCliente.ToLower().Contains(filtro) ||
                e.NombreServicio.ToLower().Contains(filtro) ||
                e.Notas?.ToLower().Contains(filtro) == true
            );
        }
    }
}
