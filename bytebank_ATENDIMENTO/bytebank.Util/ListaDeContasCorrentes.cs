﻿using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;
        public ListaDeContasCorrentes(int tamanhoInicial = 5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao+1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void Remover(ContaCorrente conta)
        {
            Console.WriteLine("\n\tRemovendo item:\n");
            int indiceItem = -1;
            for(int i=0; i< _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if(contaAtual == conta)
                {
                    indiceItem = i;
                    break;
                }
            }

            for(int i = indiceItem; i<_proximaPosicao-1; i++)
            {
                _itens[i]=_itens[i+1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
            Console.WriteLine("\tItem Removido.\n");
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length>=tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando a capacidade da lista!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }

            _itens = novoArray;
        }

        public ContaCorrente RetornaContaMaiorSaldo()
        {
            ContaCorrente conta = null;

            double maiorValor = 0;
            for(int i=0; i<_itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    if (maiorValor < _itens[i].Saldo)
                    {
                        maiorValor = _itens[i].Saldo;
                        conta = _itens[i];
                    }
                }
            }
            return conta;
        }

        public void ExibirLista()
        {
            Console.WriteLine("\n\tLista de Conta Corrente:\n");
            for(int i =0; i<_itens.Length ; i++)
            {
                if(_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($" Indice[{i}] = Conta: {conta.Conta}");
                }
            }
        }
    }
}
