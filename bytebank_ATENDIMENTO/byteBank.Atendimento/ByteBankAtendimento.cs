using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.byteBank.Exceptions;

namespace bytebank_ATENDIMENTO.byteBank.Atendimento
{
    internal class ByteBankAtendimento
    {

        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(95, "926875-X"){Saldo = 15490, Titular = new Cliente{Cpf="00214584535", Nome = "Felipe", Profissao = "Gerente"}},
            new ContaCorrente(94, "347525-X"){Saldo = 18800, Titular = new Cliente{Cpf="02425436839", Nome = "Henrique", Profissao = "Desenvolvedor"} },
            new ContaCorrente(86, "127632-X"){Saldo = 734 , Titular = new Cliente { Cpf = "07568245980", Nome = "Gustavo", Profissao = "Estagiario" } }
        };

        //AtendimentoCliente();

        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("\t==================================================");
                    Console.WriteLine("\t===                                            ===");
                    Console.WriteLine("\t===          Atendimento ByteBank              ===");
                    Console.WriteLine("\t===                                            ===");
                    Console.WriteLine("\t===          1 - Cadastrar Conta               ===");
                    Console.WriteLine("\t===          2 - Listar Contas                 ===");
                    Console.WriteLine("\t===          3 - Remover Conta                 ===");
                    Console.WriteLine("\t===          4 - Ordenar Contas                ===");
                    Console.WriteLine("\t===          5 - Pesquisar Conta               ===");
                    Console.WriteLine("\t===          6 - Sair do Sistema               ===");
                    Console.WriteLine("\t===                                            ===");
                    Console.WriteLine("\t==================================================");
                    Console.WriteLine("\n\n");
                    Console.Write("\nDigite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new ByteBankException(excecao.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarConta();
                            break;
                        case '3':
                            RemoverConta();
                            break;
                        case '4':
                            OrdenarConta();
                            break;
                        case '5':
                            PesquisarConta();
                            break;
                        default:
                            Console.WriteLine("\n\tOpção não encontrada...");
                            break;
                    }
                }
            }
            catch (ByteBankException excecao)
            {
                Console.WriteLine($"Erro: {excecao.Message}");
                Console.ReadKey();
            }


        }

        private void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t===              Pesquisar Contas              ===");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\n");
            Console.WriteLine("Deseja pesquisar por (1) NÚMERO DA CONTA, (2) CPF TITULAR ou (3) AGÊNCIA DO TITULAR ? ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.WriteLine("Informe o número da conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Informe o CPF da conta: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Informe o Número da Agência: ");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                        ExibirListaDeContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não disponivel");
                    Console.ReadKey();
                    break;
            }
        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("... A consulta não retornou dados ... ");
            }
            else
            {
                foreach (var item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            var consulta = (
                    from conta in _listaDeContas
                    where conta.Numero_agencia == numeroAgencia
                    select conta
                ).ToList();

            return consulta;
        }

        private ContaCorrente ConsultaPorCPFTitular(string? cpf)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}
            //return conta;

            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();

        }

        private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;

            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }

        private void OrdenarConta()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de contas ordenada ...");
            Console.ReadKey();
        }

        private void RemoverConta()
        {
            Console.Clear();
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t===              Remover Contas                ===");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\n");
            Console.WriteLine("Informe o número da conta");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;
            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoção não encotrada ...");
            }
            Console.ReadKey();
        }

        private void ListarConta()
        {
            Console.Clear();
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t===             Lista de Contas                ===");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas!");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
            {
                //        Console.WriteLine("\n\t -- Dados da conta -- \n");
                //       Console.WriteLine($"Número da conta: {item.Conta}");
                //        Console.WriteLine($"Saldo da conta: {item.Saldo}");
                //        Console.WriteLine($"Titular da conta: {item.Titular.Nome}");
                //        Console.WriteLine($"CPF do Titular: {item.Titular.Cpf}");
                //        Console.WriteLine($"Profissao do Titular : {item.Titular.Profissao}");
                Console.WriteLine(item.ToString());
                Console.WriteLine("\n==================================================");
                Console.ReadKey();
            }
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t===           Cadastro de Contas               ===");
            Console.WriteLine("\t===                                            ===");
            Console.WriteLine("\t==================================================");
            Console.WriteLine("\n");
            Console.WriteLine("\t Informe Dados da Conta:");
            Console.WriteLine("\n");
            Console.Write("Número da conta: ");
            string numeroConta = Console.ReadLine();

            Console.Write("Número da agência: ");
            int numeroDaAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroDaAgencia, numeroConta);

            Console.Write("Informe o Saldo Inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Informe o nome do titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Informe CPF do titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Informe a profissão do titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso!");
            Console.ReadKey();

            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

    }
}
