using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Proyecto_barberia.Database;

namespace Proyecto_barberia.Tests
{
    public class DatabaseManagerTests // Pruebas unitarias para DatabaseManager 
    {
        [Fact]
        public void Singleton_DevolverMismaInstancia()
        {
            var instancia1 = DatabaseManager.Instance;
            var instancia2 = DatabaseManager.Instance;
            Assert.Same(instancia1, instancia2);
        }

        [Fact]
        public void GetConnection_RetornaConexionNoNula()
        {
            using (var conn = DatabaseManager.Instance.GetConnection())
            {
                Assert.NotNull(conn);
            }
        }
    }
}
