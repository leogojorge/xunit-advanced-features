using System;
using Xunit;

namespace ParallelFixtureTests
{
    //Por default, cada classe de teste é uma collection para o xUnit v2. 
    //Sendo assim, metodos de teste dentro de uma classe não são executados em paralelo entre si.

    //Podemos criar collections customizadas para definir quais classes devem ou não rodar em paralelo entre elas.

    //Todas as classes que referenciarem esta coleção, "Sem paralelismo aqui", serão executadas uma por vez, metodo por metodo.
    //Poderia estar decorado em uma classe de teste com metodos, porém, se for necessário criar um contexto pra ser compartilhado entre mais classes,
    //será necessário crirar uma classe separada apenas pra isso, pois a ideia é que exista um construtor para ser chamado uma única vez, 
    //instanciando as dependencias necessárias para suas classes de teste
    [CollectionDefinition("Sem paralelismo aqui")]
    public class CollectionsFixture
    {
        //Não necessáriamente precisa de codigo para existir.
        //Neste caso, serve apenas para determinar uma coleção
        
        //Se eu precisasse criar um contexto compartilhado, mesmas instancias usadas por varias classes diferentes por exemplo,
        //basta inicializa-las dentro do construtor desta classe
    }
}
