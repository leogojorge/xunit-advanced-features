using System.Threading;
using Xunit;

namespace ParallelFixtureTests.SemParalelismo
{
    //Se estas duas classes são executadas dentro da mesma Collection,
    //a duração total da execução deve ser de ~12 segundos (cada teste dura 2 segundos, 6 metodos no total)

    //Se estas duas classes são executadas em Collections separadas,
    //a duração total da execução deve ser de ~6 segundos, pois serão executadas em paralelo
    //Basta retirar a decoração "[Collection("Sem paralelismo aqui")]" das classes 

    [Collection("Sem paralelismo aqui")]
    public class SomeTests
    {
        [Fact]
        public void TesteSequencial4()
        {
            Thread.Sleep(2000);
        }

        [Fact]
        public void TesteSequencial5()
        {
            Thread.Sleep(2000);
        }

        [Fact]
        public void TesteSequencial6()
        {
            Thread.Sleep(2000);
        }
    }

    [Collection("Sem paralelismo aqui")]
    public class MoreTests
    {
        [Fact]
        public void TesteSequencial1()
        {
            Thread.Sleep(2000);
        }

        [Fact]
        public void TesteSequencial2()
        {
            Thread.Sleep(2000);
        }

        [Fact]
        public void TesteSequencial3()
        {
            Thread.Sleep(2000);
        }
    }
}
