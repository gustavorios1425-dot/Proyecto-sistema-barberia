using Xunit;

namespace ProyectoBarberia.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PruebaSimple()
        {
            int resultado = 2 + 2;
            Assert.Equal(4, resultado);
        }
    }
}
