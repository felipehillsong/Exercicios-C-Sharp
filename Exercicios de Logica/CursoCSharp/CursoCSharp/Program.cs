using System;
using System.Collections.Generic;


using CursoCSharp.Fundamentos;
using CursoCSharp.EstruturasDeControle;
using CursoCSharp.ClassesEMetodos;
using CursoCSharp.Colecoes;
using CursoCSharp.OO;
using CursoCSharp.MetodosEFuncoes;
using CursoCSharp.Excecoes;
using CursoCSharp.API;
using CursoCSharp.TopicosAvancados;

namespace CursoCSharp {
    class Program {
        static void Main(string[] args) {
            var central = new CentralDeExercicios(new Dictionary<string, Action>() {
                {"Primeiro Programa - Fundamentos", PrimeiroPrograma.Executar},
                {"Comentarios - Fundamentos", Comentarios.Executar},
                {"Váriaveis e Constantes - Fundamentos", VariaveisEConstantes.Executar},
                {"Inferencia - Fundamentos", Inferencia.Executar},
                {"Interpolacao - Fundamentos", Interpolacao.Executar},
                {"Notação Ponto - Fundamentos", NotacaoPonto.Executar},
                {"Lendo Dados - Fundamentos", LendoDados.Executar},
                {"Formatando Numero - Fundamentos", FormatandoNumero.Executar},
                {"Coversões - Fundamentos", Conversoes.Executar},
                {"Operadores Aritimeticos - Fundamentos", OperadoresAritimeticos.Executar},
                {"Operadores Relacionais - Fundamentos", OperadoresRelacionais.Executar},
                {"Operadores Logicos - Fundamentos", OperadoresLogicos.Executar},
                {"Operadores de Atribuição - Fundamentos", OperadoresAtribuicao.Executar},
                {"Operadores Unários - Fundamentos", OperadoresUnarios.Executar},
                {"Operadores Ternário - Fundamentos", OperadorTernario.Executar},
                {"Estrutura IF - Estruturas de Controle", EstruturaIf.Executar},
                {"Estrutura IF/Else - Estruturas de Controle", EstruturaIfElse.Executar},
                {"Estrutura IF/Else/If - Estruturas de Controle", EstruturaIfElseIf.Executar},
                {"Estrutura Switch - Estruturas de Controle", EstruturaSwitch.Executar},
                {"Estrutura While - Estruturas de Controle", EstruturaWhile.Executar},
                {"Estrutura Do While - Estruturas de Controle", EstruturaDoWhile.Executar},
                {"Estrutura For - Estruturas de Controle", EstruturaFor.Executar},
                {"Estrutura Foreach - Estruturas de Controle", EstruturaForeach.Executar},
                {"Estrutura Break - Estruturas de Controle", EstruturaBreak.Executar},
                {"Estrutura Continue - Estruturas de Controle", EstruturaContinue.Executar},
                {"Membros - Classes e Membros", Membros.Executar},
                {"Construtores - Classses e Metodos", Construtores.Executar},
                {"Metodos com Retorno - Classses e Metodos", MetodosComRetorno.Executar},
                {"Metodos Estaticos - Classses e Metodos", MetodosEstaticos.Executar},
                {"Atributos Estaticos - Classses e Metodos", AtributosEstaticos.Executar},
                {"Desafio Atributo - Classses e Metodos", DesafioAtributo.Executar},
                {"Parametros Nomeados - Classses e Metodos", ParametrosNomeados.Executar},
                {"Get e Set - Classses e Metodos", GetSet.Executar},
                {"Props - Classses e Metodos", Props.Executar},
                {"Readonly - Classses e Metodos", Readonly.Executar},
                {"Enum - Classses e Metodos", ExemploEnum.Executar},
                {"Struct - Classses e Metodos", ExemploStruct.Executar},
                {"Struct Vs Classe - Classses e Metodos", StructVsClasse.Executar},
                {"Valor Vs Referencia - Classses e Metodos", ValorVsReferencia.Executar},
                {"Parametros por Referencia - Classses e Metodos", ParametrosPorReferencia.Executar},
                {"Parametro Padrão - Classses e Metodos", ParametroPadrao.Executar},
                {"Usando Array - Coleções", UsandoArray.Executar},
                {"List - Coleções", ColecoesList.Executar},
                {"ArrayList - Coleções", ColecoesArrayList.Executar},
                {"coelções Queue - Coleções", ColecoesQueue.Executar},
                {"Igualdade - Coleções", Igualdade.Executar},
                {"Stack - Coleções", CoelcoesStack.Executar},
                {"Dictionary - Coleções", ColecoesDictionary.Executar},
                {"Herança - Orientado Objeto", Heranca.Executar},
                {"Construtor This - Orientado Objeto", ConstrutorThis.Executar},
                {"Encapsulamento - Orientado Objeto", OO.Encapsulamento.Executar},
                {"Polimorfismo - Orientado Objeto", Polimorfismo.Executar},
                {"Classe Abstrata - Orientado Objeto", Abstract.Executar},
                {"Interface - Orientado Objeto", Interface.Executar},
                {"Sealed - Orientado Objeto", Sealed.Executar},
                {"Exemplo Lambda - Metodo E Funções", ExemploLambda.Executar},
                {"Lambdas Delegate - Metodo E Funções", LambdasDelegate.Executar},
                {"Usando Delegate - Metodo E Funções", UsandoDelegate.Executar},
                {"Delegates Com Função Anonima - Metodo E Funções", DelegateFuncAnonima.Executar},
                {"Delegates Como Parametros - Metodo E Funções", DelegatesComParametros.Executar},
                {"Metodos e Extensão - Metodo E Funções", MetodosdeEsxtensao.Executar},
                {"Primeira Exceção - Exceções", PrimeiraExcecao.Executar},
                {"Exceções Personalizadas - Exceções", ExcecoesPersonalizadas.Executar},
                {"Primeiro Arquivo - API", PrimeiroArquivo.Executar},
                {"Lendo Arquivos - API", LendoArquivos.Executar},
                {"Exemplo FileInfo - API", ExemploFileInfo.Executar},
                {"Exemplo DirectoryInfo - API", ExemploDirectoryInfo.Executar},
                {"Exemplo Path - API", ExemploPath.Executar},
                {"Exemplo DateTime - API", Exemplo_DateTime.Executar},
                {"Exemplo Timespan - API", ExemplotimeSpan.Executar},
                {"LINQ! - Topicos Avançados", LINQ1.Executar},
                {"LINQ2 - Topicos Avançados", LINQ1.Executar},
                {"Nullables - Topicos Avançados", Nullables.Executar},
                {"Dynamics - Topicos Avançados", Dynamics.Executar},
                {"Generics - Topicos Avançados", Generics.Executar},

            });

            central.SelecionarEExecutar();
        }
    }
}