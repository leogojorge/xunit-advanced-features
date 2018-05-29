using System;
using System.Diagnostics;
using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass)]
namespace FixtureTests
{
    //Definindo o nome do contexto que será compartilhado por várias classes diferentes
    [CollectionDefinition("Main")]
    public class MainCollection : ICollectionFixture<MainCollection>, IDisposable
    {
        public string marcador;
        public int testeAtual;

        //Constutor que será usado para criar um contexto compartilhado entre todas as classes que referenciam a Collection "Main"
        public MainCollection()
        {
            this.testeAtual++;
            this.marcador = "";
            Debug.WriteLine(marcador);
        }

        public void Dispose()
        {
            this.marcador = "BREAK";
        }
    }

    [Collection("Main")]
    public class CallingCollectionMain
    {
        public MainCollection exeParalela;
        public CallingCollectionMain(MainCollection exeParalela)
        {
            this.exeParalela = exeParalela;
        }

        [Fact]
        public void Teste1()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "Chamando teste 1";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste2()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "Chamando teste 2";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste3()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "Chamando teste 3";
            Debug.WriteLine(exeParalela.marcador);
        }
    }

    [Collection("Main")]
    public class CallingCollectionMainToo
    {
        MainCollection exeParalela;
        public CallingCollectionMainToo(MainCollection exeParalela)
        {
            this.exeParalela = exeParalela;
        }

        [Fact]
        public void Teste4()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "Chamando teste 4";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste5()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "Chamando teste 5";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste6()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "Chamando teste 6";
            Debug.WriteLine(exeParalela.marcador);
        }
    }
}