using System;
using System.Diagnostics;
using Xunit;

//[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass)]
//Esta decoração determina que cada classe é uma coleção dentro deste assembly, ou seja, as destge assembly classes são executadas em paralel (configuração defoult do xUnit).
//[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
//Esta decoração determina que cada assembly é uma coleção, ou seja, não importa quantos metodos exista dentro dele, serão todos executados sequencialmente
namespace ParallelFixtureTests
{
    //Definindo o nome do Collection (contexto) que será compartilhado por várias classes diferentes
    [CollectionDefinition("Main")]
    public class MainCollection : ICollectionFixture<MainCollection>, IDisposable
    {
        public string marcador;
        public int testeAtual;

        //Constutor que será usado para criar um contexto compartilhado entre todas as classes que referenciam a Collection "Main"
        public MainCollection()
        {
            this.testeAtual++;
            this.marcador = "Construtor da MainCollection chamado. Devo ser chamado apenas uma vez";
            Debug.WriteLine(marcador);
        }

        public void Dispose()
        {
            this.marcador = "Fim da execução da Collection Main ";
        }
    }

    //Referencia a Collection que será usada para forncer o contexto. Neste caso é a Main
    [Collection("Main")]
    public class CallingCollectionMain
    {
        MainCollection exeParalela;

        //Passando a classe de contexto como parâmetro para usar suas propriedades. Instância é fornecida automagicamente pelo xUnit
        public CallingCollectionMain(MainCollection exeParalela)
        {
            this.exeParalela = exeParalela;
        }

        [Fact]
        public void Teste1()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "CallingCollectionMain teste 1";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste2()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "CallingCollectionMain teste 2";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste3()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "CallingCollectionMain teste 3";
            Debug.WriteLine(exeParalela.marcador);
        }
    }

    //Referencia a Collection que será usada para forncer o contexto. Neste caso é a Main
    [Collection("Main")]
    public class CallingCollectionMainAgain
    {
        MainCollection exeParalela;

        //Passando a classe de contexto como parâmetro para usar suas propriedades. Instância é fornecida automagicamente pelo xUnit
        public CallingCollectionMainAgain(MainCollection exeParalela)
        {
            this.exeParalela = exeParalela;
        }

        [Fact]
        public void Teste4()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "CallingCollectionMainAgain teste 1";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste5()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "CallingCollectionMainAgain teste 2";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste6()
        {
            exeParalela.testeAtual++;
            exeParalela.marcador = "CallingCollectionMainAgain teste 3";
            Debug.WriteLine(exeParalela.marcador);
        }
    }
}