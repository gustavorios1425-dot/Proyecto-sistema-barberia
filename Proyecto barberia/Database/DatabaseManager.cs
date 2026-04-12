using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_barberia.Database
{
    public sealed class DatabaseManager
    {
        private static DatabaseManager _instance;
        private static readonly object _lock = new object();
        private readonly string _connectionString;

        private DatabaseManager()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "barberia.db");
            _connectionString = $"Data Source={dbPath};Version=3;";
            InitializeDatabase();
        }

        public static DatabaseManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DatabaseManager();
                    return _instance;
                }
            }
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        private void InitializeDatabase()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS BARBERO (
                        ID_Barbero INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre1 TEXT NOT NULL,
                        Nombre2 TEXT,
                        Apellido_Paterno TEXT NOT NULL,
                        Apellido_Materno TEXT,
                        Telefono TEXT NOT NULL,
                        Activo INTEGER NOT NULL DEFAULT 1
                    );
                    CREATE TABLE IF NOT EXISTS SERVICIO (
                        ID_Servicio INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nombre TEXT NOT NULL,
                        DuracionMin INTEGER NOT NULL,
                        Precio REAL NOT NULL,
                        Activo INTEGER NOT NULL DEFAULT 1
                    );
                    CREATE TABLE IF NOT EXISTS CLIENTE (
                        ID_Cliente INTEGER PRIMARY KEY AUTOINCREMENT,
                        NombreCompleto TEXT NOT NULL,
                        Telefono TEXT NOT NULL UNIQUE,
                        Email TEXT,
                        FechaRegistro TEXT NOT NULL DEFAULT (date('now', 'localtime')),
                        TotalVisitas INTEGER NOT NULL DEFAULT 0,
                        EsLegendario INTEGER NOT NULL DEFAULT 0
                    );
                    CREATE TABLE IF NOT EXISTS USUARIO (
                        ID_Usuario INTEGER PRIMARY KEY AUTOINCREMENT,
                        ID_Barbero INTEGER NOT NULL UNIQUE,
                        NombreUsuario TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Rol TEXT NOT NULL DEFAULT 'barbero' CHECK(Rol IN ('barbero', 'administrador')),
                        Activo INTEGER NOT NULL DEFAULT 1,
                        UltimoAcceso TEXT,
                        FOREIGN KEY (ID_Barbero) REFERENCES BARBERO(ID_Barbero)
                    );
                    CREATE TABLE IF NOT EXISTS CITA (
                        ID_Cita INTEGER PRIMARY KEY AUTOINCREMENT,
                        ID_Cliente INTEGER NOT NULL,
                        ID_Barbero INTEGER NOT NULL,
                        ID_Servicio INTEGER NOT NULL,
                        FechaHora TEXT NOT NULL,
                        Estado TEXT NOT NULL DEFAULT 'Pendiente' CHECK(Estado IN ('Pendiente', 'Confirmada', 'Completada', 'Cancelada')),
                        Notas TEXT,
                        FechaSolicitud TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                        FOREIGN KEY (ID_Cliente) REFERENCES CLIENTE(ID_Cliente),
                        FOREIGN KEY (ID_Barbero) REFERENCES BARBERO(ID_Barbero),
                        FOREIGN KEY (ID_Servicio) REFERENCES SERVICIO(ID_Servicio)
                    );
                    CREATE TABLE IF NOT EXISTS HISTORIAL_CORTE (
                        ID_Hist INTEGER PRIMARY KEY AUTOINCREMENT,
                        ID_Cita INTEGER NOT NULL UNIQUE,
                        ID_Cliente INTEGER NOT NULL,
                        ID_Usuario INTEGER NOT NULL,
                        FechaCorte TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                        Precio REAL NOT NULL,
                        Observaciones TEXT,
                        FOREIGN KEY (ID_Cita) REFERENCES CITA(ID_Cita),
                        FOREIGN KEY (ID_Cliente) REFERENCES CLIENTE(ID_Cliente),
                        FOREIGN KEY (ID_Usuario) REFERENCES USUARIO(ID_Usuario)
                    );
                    CREATE TABLE IF NOT EXISTS CONFIGURACION (
                        ID_Config INTEGER PRIMARY KEY AUTOINCREMENT,
                        UmbralLegendario INTEGER NOT NULL DEFAULT 5,
                        Beneficio TEXT NOT NULL DEFAULT 'Corte gratis',
                        Description TEXT
                    );
                    -- Datos de ejemplo
                    INSERT OR IGNORE INTO BARBERO (Nombre1, Apellido_Paterno, Telefono) VALUES ('Carlos', 'Mendoza', '656-200-0001');
                    INSERT OR IGNORE INTO BARBERO (Nombre1, Apellido_Paterno, Telefono) VALUES ('Héctor', 'Ríos', '656-200-0002');
                    INSERT OR IGNORE INTO SERVICIO (Nombre, DuracionMin, Precio) VALUES ('Corte clásico', 30, 120);
                    INSERT OR IGNORE INTO SERVICIO (Nombre, DuracionMin, Precio) VALUES ('Corte + barba', 45, 180);
                    INSERT OR IGNORE INTO SERVICIO (Nombre, DuracionMin, Precio) VALUES ('Afeitado tradicional', 20, 90);
                    INSERT OR IGNORE INTO USUARIO (ID_Barbero, NombreUsuario, Password, Rol) VALUES (1, 'admin', 'admin123', 'administrador');
                    INSERT OR IGNORE INTO CLIENTE (NombreCompleto, Telefono, Email) VALUES ('Juan Pérez', '656-111-2233', 'juan@mail.com');
                    INSERT OR IGNORE INTO CLIENTE (NombreCompleto, Telefono, Email) VALUES ('María López', '656-444-5566', 'maria@mail.com');
                    INSERT OR IGNORE INTO CONFIGURACION (UmbralLegendario, Beneficio) VALUES (5, '10% de descuento en tu próximo corte');
                ";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
