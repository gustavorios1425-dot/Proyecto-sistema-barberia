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
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LegendaryBarber");
            if (!Directory.Exists(appDataFolder))
                Directory.CreateDirectory(appDataFolder);
            string dbPath = Path.Combine(appDataFolder, "barberia.db");
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
                    CREATE TABLE IF NOT EXISTS CONFIGURACION (
                        ID_Config INTEGER PRIMARY KEY AUTOINCREMENT,
                        UmbralLegendario INTEGER NOT NULL DEFAULT 5,
                        Beneficio TEXT NOT NULL DEFAULT 'Corte gratis',
                        Description TEXT
                    );

                    CREATE TABLE IF NOT EXISTS BITACORA (
                        ID_Bitacora INTEGER PRIMARY KEY AUTOINCREMENT,
                        ID_Cliente INTEGER NOT NULL,
                        ID_Servicio INTEGER NOT NULL,
                        Precio REAL NOT NULL,
                        Fecha TEXT NOT NULL DEFAULT (datetime('now', 'localtime')),
                        Notas TEXT,
                        FOREIGN KEY (ID_Cliente) REFERENCES CLIENTE(ID_Cliente),
                        FOREIGN KEY (ID_Servicio) REFERENCES SERVICIO(ID_Servicio)
                    );

                    -- Datos de ejemplo
                    -- Insertar barberos solo si no hay ninguno
                    INSERT OR IGNORE INTO BARBERO (Nombre1, Apellido_Paterno, Telefono)
                    SELECT 'Carlos', 'Mendoza', '656-200-0001'
                    WHERE NOT EXISTS (SELECT 1 FROM BARBERO LIMIT 1);

                    INSERT OR IGNORE INTO BARBERO (Nombre1, Apellido_Paterno, Telefono)
                    SELECT 'Héctor', 'Ríos', '656-200-0002'
                    WHERE NOT EXISTS (SELECT 1 FROM BARBERO LIMIT 1);

                    -- Insertar servicios solo si no hay ninguno
                    INSERT OR IGNORE INTO SERVICIO (Nombre, DuracionMin, Precio)
                    SELECT 'Corte clásico', 30, 120
                    WHERE NOT EXISTS (SELECT 1 FROM SERVICIO LIMIT 1);

                    INSERT OR IGNORE INTO SERVICIO (Nombre, DuracionMin, Precio)
                    SELECT 'Corte + barba', 45, 180
                    WHERE NOT EXISTS (SELECT 1 FROM SERVICIO LIMIT 1);

                    INSERT OR IGNORE INTO SERVICIO (Nombre, DuracionMin, Precio)
                    SELECT 'Afeitado tradicional', 20, 90
                    WHERE NOT EXISTS (SELECT 1 FROM SERVICIO LIMIT 1);

                    -- Insertar usuario admin solo si no existe
                    INSERT OR IGNORE INTO USUARIO (ID_Barbero, NombreUsuario, Password, Rol)
                    SELECT 1, 'admin', 'admin123', 'administrador'
                    WHERE NOT EXISTS (SELECT 1 FROM USUARIO LIMIT 1);

                    -- Insertar clientes solo si no hay ninguno (evita duplicar los mismos)
                    INSERT OR IGNORE INTO CLIENTE (NombreCompleto, Telefono, Email)
                    SELECT 'Juan Pérez', '656-111-2233', 'juan@mail.com'
                    WHERE NOT EXISTS (SELECT 1 FROM CLIENTE LIMIT 1);

                    INSERT OR IGNORE INTO CLIENTE (NombreCompleto, Telefono, Email)
                    SELECT 'María López', '656-444-5566', 'maria@mail.com'
                    WHERE NOT EXISTS (SELECT 1 FROM CLIENTE LIMIT 1);

                    -- Insertar configuración solo si no existe
                    INSERT OR IGNORE INTO CONFIGURACION (UmbralLegendario, Beneficio)
                    SELECT 5, 'Proximo servicio sin costo.'
                    WHERE NOT EXISTS (SELECT 1 FROM CONFIGURACION LIMIT 1);
                ";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
