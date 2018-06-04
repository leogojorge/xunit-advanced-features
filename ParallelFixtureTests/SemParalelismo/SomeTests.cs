using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ParallelFixtureTests.SemParalelismo
{


    //Se estas duas classes são executadas dentro da mesma Collection,
    //a duração total da execução deve ser de ~12 segundos (cada teste dura 2 segundos, 6 metodos no total)

    //Se estas duas classes são executadas em Collections separadas,
    //a duração total da execução deve ser de ~6 segundos, pois serão executadas em paralelo
    //Basta retirar a decoração "[Collection("Sem paralelismo aqui")]" de ambas
    [Collection("Sem paralelismo aqui")]
    public class SomeTests
    {
        [Fact]
        public void TesteSequencial4()
        {
            Task.Delay(1000);
        }

        [Fact]
        public void TesteSequencial5()
        {
            Task.Delay(1000);
        }

        [Fact]
        public void TesteSequencial6()
        {
            Task.Delay(1000);
        }
    }

    [Collection("Sem paralelismo aqui")]
    public class MoreTests
    {
        [Fact]
        public void TesteSequencial1()
        {
            Task.Delay(1000);
        }

        [Fact]
        public void TesteSequencial2()
        {
            Task.Delay(1000);
        }

        [Fact]
        public void TesteSequencial3()
        {
            Task.Delay(1000);
        }
    }
}
