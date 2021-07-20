using System;
using System.Collections.Generic;

namespace dio_dotnet_poo_NunuBanck {
    class Program {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args) {

            //Conta conta = new Conta(TipoConta.PessoaFisica, 0, 0, "Erico Andre");
            //Console.WriteLine("{0}", conta);

            string opcao = MenuNunuBanck();
            while (opcao != "X"){
                switch (opcao) {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;      
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = MenuNunuBanck();
            }
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
        private static void ListarContas() {
            Console.WriteLine("Listar Clientes");
            if (listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            foreach (var conta in listContas) {
                Console.WriteLine("# {0} - {1} ", conta.getId(), conta);
            }
        }
        private static void InserirConta() {
            Console.WriteLine("Contas novas");

            int entradaTipoConta = tipoConta();

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(id: ProximoId(), tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);
            listContas.Add(novaConta);
        }
        private static void Transferir() {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
        private static void Sacar() {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
            
            listContas[indiceConta].SacarDindin(valorSaque);
        }
        private static void Depositar() {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            
            listContas[indiceConta].DepositarDindin(valorDeposito);
        }

        public static int tipoConta(){
            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int TipoConta = Int32.Parse(Console.ReadLine());
            if ((TipoConta!=1) && (TipoConta!=2)) {
                Console.WriteLine("Opcao {0} Invalida!", TipoConta);
                tipoConta();
            }
            return TipoConta;
        }
        public static int ProximoId() {
            return listContas.Count;
        }
		private static string MenuNunuBanck(){
            Console.WriteLine();
            Console.WriteLine("DIO NunuBanck !!!");
            Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar contas");
			Console.WriteLine("2- Inserir nova conta");
			Console.WriteLine("3- Transferir");
			Console.WriteLine("4- Sacar");
			Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcao = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcao;
		}
    }
}
