using System;
using System.Diagnostics;
using Xunit;

namespace FixtureTests
{
    public class ExecucaoParalela : IDisposable
    {
        public string marcador;
        public int testeAtual;

        //Constutor que será usado para criar um contexto compartilhado entre todos os testes da classe que o usa como ClassFixture
        public ExecucaoParalela()
        {
            this.testeAtual++;
            this.marcador = $"Devo aparecer apenas uma vez";
            Debug.WriteLine(marcador);
        }

        public void Dispose()
        {
            this.marcador = "Disposed";
        }
    }
    //ClassFixture determina qual classe será usada pra ser a 'Initialize' para outra classe de teste.
    //Dessa forma, o construtor da classe passada para o IClassFixture<> será executado apenas uma vez,
    //criando um contexto específico para aquela classe de teste.
    //Importante: Usar IClassFixture<> determina que o contexto será compartilhado com apenas uma classe, ou seja,
    //o construtor da classe usada como Fixture será executado uma vez antes da classe de teste em si ser instanciada. O construtor da propria 
    //classe de teste sempre será chamado antes da execução de cada teste como é feito por default.
    //Warning! Se usarmos a classe de teste para herdar de IClassFixture passando a propria classe ( MyTestClass : IClassFixture<MyTestClass>), 
    //seu construtor será executado duas vezes antes do primerio teste ser executado e, por default, uma vez antes de cada teste.
    public class Executando1 : IClassFixture<ExecucaoParalela>
    {
        public ExecucaoParalela exeParalela;
        public Executando1(ExecucaoParalela exeParalela)
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

    public class Executando2 : IClassFixture<ExecucaoParalela>
    {
        ExecucaoParalela exeParalela;
        public Executando2(ExecucaoParalela exeParalela)
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