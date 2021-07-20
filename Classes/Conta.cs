using System;

namespace dio_dotnet_poo_NunuBanck {
    class Conta {
        private int Id { get; set; }
        private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(int id, TipoConta tipoConta, double saldo, double credito, string nome){
            this.Id = id;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool SacarDindin(double gaita){
            if((this.Saldo - gaita)<(this.Credito*-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -=gaita;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }
        public void DepositarDindin(double gaita){
            this.Saldo +=gaita;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double gaita, Conta contaDestino){
			if (this.SacarDindin(gaita)){
                contaDestino.DepositarDindin(gaita);
            }
        }
        public int getId() {
            return this.Id;
        }

        public override string ToString(){
            string retorno = "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: R$ " + this.Saldo + " | ";
            retorno += "Crédito: R$ " + this.Credito;
            return retorno;
        }
    }
}