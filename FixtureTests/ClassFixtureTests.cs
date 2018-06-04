using System;
using System.Diagnostics;
using Xunit;

namespace FixtureTests
{
    //ClassFixture determina qual classe será usada pra ser um 'Initialize' para outra classe de teste.
    //Dessa forma, o construtor da classe passada para o IClassFixture<> será executado apenas uma vez,
    //criando um contexto específico para aquela classe de teste.
    //Importante: Usar IClassFixture<> determina que o contexto será compartilhado com apenas uma classe, ou seja,
    //o construtor da classe usada como Fixture será executado uma vez antes da classe de teste em si ser instanciada. O construtor da propria 
    //classe de teste sempre será chamado antes da execução de cada teste como é feito por default.
    //Warning1! Se usar a mesma classe como ClassFixture para duas ou mais classes de teste, o construtor da classe passada será executado
    //a quantidade de vezes equivalente a quantidade de classes que o herdam *SIMULTANEAMENTE*. Serão enviadas qtdClass Threads para seu construtor.
    //Warning2! Se usarmos a classe de teste para herdar de IClassFixture passando a propria classe ( MyTestClass : IClassFixture<MyTestClass>), 
    //seu construtor será executado duas vezes antes do primerio teste ser executado e, por default, uma vez antes de cada teste.
    public class ExecucaoSequencial : IDisposable
    {
        public string marcador;

        //Constutor que será usado para criar um contexto compartilhado entre todos os testes da classe que o usa como ClassFixture
        //Como duas classes usam a mesma ClasseFixture, este construtor receberá duas threads, uma de cada classe
        public ExecucaoSequencial()
        {
            this.marcador = "Construtor da ExecuçãoSequencial chamado. Devo ser chamado apenas uma vez por cada classe que me herda";
            Debug.WriteLine(marcador);
        }

        public void Dispose()
        {
            this.marcador = "Fim da execução da ExecuçãoSequencial";
        }
    }

    public class ExecutandoClassFixture1 : IClassFixture<ExecucaoSequencial>
    {
        public ExecucaoSequencial exeParalela;

        //Se for necessário usar alguma propriedade da classe de contexto é possível passa-la como parâmetro no construtor
        //da sub classe, uma instancia será fornecida automagicamente e, é claro, a mesma instância é passada para todas
        //as classes que a usam como parâmetro no construtor, ou seja, seu estado será compartilhada. 
        //Por isso é *um contexto para toda a execução* =D
        public ExecutandoClassFixture1(ExecucaoSequencial exeParalela)
        {
            this.exeParalela = exeParalela;
        }

        [Fact]
        public void Teste1()
        {
            exeParalela.marcador = "ExecutandoClassFixture1 teste 1";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste2()
        {
            exeParalela.marcador = "ExecutandoClassFixture1 teste 2";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste3()
        {
            exeParalela.marcador = "ExecutandoClassFixture1 teste 3";
            Debug.WriteLine(exeParalela.marcador);
        }
    }

    public class ExecutandoClassFixture2 : IClassFixture<ExecucaoSequencial>
    {
        ExecucaoSequencial exeParalela;
        public ExecutandoClassFixture2(ExecucaoSequencial exeParalela)
        {
            this.exeParalela = exeParalela;
        }

        [Fact]
        public void Teste4()
        {
            exeParalela.marcador = "ExecutandoClassFixture2 teste 4";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste5()
        {
            exeParalela.marcador = "ExecutandoClassFixture2 teste 5";
            Debug.WriteLine(exeParalela.marcador);
        }

        [Fact]
        public void Teste6()
        {
            exeParalela.marcador = "ExecutandoClassFixture2 teste 6";
            Debug.WriteLine(exeParalela.marcador);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CriandoContextoParaUmaClasse
    {
        public string variavelCompatilhadaPeloContexto;
        public CriandoContextoParaUmaClasse()
        {
            this.variavelCompatilhadaPeloContexto = "Criando o contexto";
        }
    }

    public class UsandoContextoExclusivamente : IClassFixture<CriandoContextoParaUmaClasse>
    {
        CriandoContextoParaUmaClasse contexto;
        public UsandoContextoExclusivamente(CriandoContextoParaUmaClasse contexto)
        {
            //Obtendo o contexto criado
            this.contexto = contexto;

        }

        [Fact]
        public void ContextoFoiCompartilhado()
        {
            string valorInicialDaVariavelDoContexto = "Criando o contexto";

            Assert.Equal(valorInicialDaVariavelDoContexto, contexto.variavelCompatilhadaPeloContexto);
        }

        [Fact]
        public void ContextoCompartilhadoFoiAlteradoEmAlgumTesteAnterior()
        {
            string valorInicialDaVariavelDoContexto = "Criando o contexto";

            Assert.NotEqual(valorInicialDaVariavelDoContexto, contexto.variavelCompatilhadaPeloContexto);
        }

        [Fact]
        public void AlterandoContexto()
        {
            string novoValorAhSerPassadoPelaVariavelDoContexto = "Alterando o valor da variavel de contexto";

            contexto.variavelCompatilhadaPeloContexto = novoValorAhSerPassadoPelaVariavelDoContexto;
            bool variavelDeContextoFoiAlterada = contexto.variavelCompatilhadaPeloContexto != "Criando o contexto" &&
                                                 !string.IsNullOrWhiteSpace(contexto.variavelCompatilhadaPeloContexto);

            Assert.True(variavelDeContextoFoiAlterada);
        }
    }
}