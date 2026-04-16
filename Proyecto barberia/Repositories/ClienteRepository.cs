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
    public class ClienteRepository
    {
        public int Insertar(ClienteEntidad cliente)
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO CLIENTE (NombreCompleto, Telefono, Email) 
                               VALUES (@nombre, @telefono, @email);
                               SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cliente.NombreCompleto);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@email", cliente.Email ?? (object)DBNull.Value);
                    return System.Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<ClienteEntidad> ObtenerTodos()
        {
            var clientes = new List<ClienteEntidad>();
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT ID_Cliente, NombreCompleto, Telefono, Email, FechaRegistro, TotalVisitas, EsLegendario FROM CLIENTE ORDER BY NombreCompleto";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new ClienteEntidad
                        {
                            ID_Cliente = reader.GetInt32(0),
                            NombreCompleto = reader.GetString(1),
                            Telefono = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                            FechaRegistro = reader.GetString(4),
                            TotalVisitas = reader.GetInt32(5),
                            EsLegendario = reader.GetInt32(6) == 1
                        });
                    }
                }
            }
            return clientes;
        }
    }
}
