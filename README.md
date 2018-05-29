## O que?
Precisamos registar os mapeamentos do AutoMapper e as injeções de dependência ao inicializar os testes. 

## Problema
Inicializa-los no construtor da classe causa exception, pois o construtor é chamado antes de cada teste e não é possível fazer multiplos registros.

## Solução
Usar as funcionalidades de criação de contexto e processamento sequencial vs paralelo do xUnit
