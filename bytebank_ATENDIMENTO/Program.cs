using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank_ATENDIMENTO.byteBank.Exceptions;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C#
Array amostra = Array.CreateInstance(typeof(double), 5);

amostra.SetValue(6.9, 0);
amostra.SetValue(15.3, 1);
amostra.SetValue(3.4, 2);
amostra.SetValue(7.1, 3);
amostra.SetValue(8.0, 4);

TestaMediana(amostra);
MediaDaAmostra((double[])amostra);

void TestaMediana(Array array)
{
    if((array == null) || (array.Length == 0))
    {
        Console.WriteLine("O array para calculo da mediana é nulo");

    }
    double[] numerosOrdenados = (double[])array.Clone();

    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"A amostra tem mediana igual a {mediana}");
}

double MediaDaAmostra(double[] amostra)
{
    double media = 0;
    double acumulador = 0;

    if ((amostra == null) || (amostra.Length == 0))
    {
        Console.WriteLine("Amostra de dados nula ou vazia.");
        return 0;
    }
    else
    {
        for (int i = 0; i < amostra.Length; i++)
        {
            acumulador = acumulador + amostra[i];
        }
        media = acumulador / amostra.Length;
    }

    return media;
}

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();

    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "3214532-D"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7614532-E"));
    var clienteConta = new ContaCorrente(725, "8752345-F");
    listaDeContas.Adicionar(clienteConta);
    listaDeContas.ExibirLista();
    listaDeContas.Remover(clienteConta);
    listaDeContas.ExibirLista();

    ContaCorrente maiorConta = listaDeContas.RetornaContaMaiorSaldo();

    for(int i = 0; i<listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}

TestaArrayDeContasCorrentes();

#endregion


//Generica<int> teste1 = new Generica<int>();
//teste1.MostrarMensagem(10);

//Generica<string> teste2 = new Generica<string>();
//teste2.MostrarMensagem("Olá");
//
//public class Generica<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo {t}");
//   }
//}


#region Exemplos uso List
//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(95, "926875-X"){Saldo = 15490},
//    new ContaCorrente(94, "926875-X"){Saldo = 2100},
//    new ContaCorrente(86, "926875-X"){Saldo = 734},
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(95, "926875-X"){Saldo = 15490},
//    new ContaCorrente(94, "926875-X"){Saldo = 2100},
//    new ContaCorrente(86, "926875-X"){Saldo = 734},
//};

//Console.WriteLine(" --------------------------------------------- ");

//_listaDeContas2.AddRange(_listaDeContas3);

//for(int i = 0; i< _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($" Indice[{i}] = Conta: {_listaDeContas2[i].Conta} e Agencia: {_listaDeContas2[i].Numero_agencia}");
//}

//Console.WriteLine(" --------------------------------------------- ");

//var range = _listaDeContas3.GetRange(0, 1);
//for(int i = 0; i<range.Count; i++)
//{
//    Console.WriteLine($" Indice[{i}] = Conta: {_listaDeContas2[i].Conta} e Agencia: {_listaDeContas2[i].Numero_agencia}");
//}

//Console.WriteLine(" --------------------------------------------- ");

//_listaDeContas2.Reverse();

//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($" Indice[{i}] = Conta: {_listaDeContas2[i].Conta} e Agencia: {_listaDeContas2[i].Numero_agencia}");
//}
#endregion



