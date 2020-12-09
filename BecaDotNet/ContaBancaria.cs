using System;
using System.Globalization;

namespace BecaDotNet
{
    public class ContaBancaria
    {
        private string NumeroConta { get; set; }
        private string NomeTitular { get; set; }
        private double Saldo { get; set; }
        public string Operação { get; set; }

        public ContaBancaria(string numeroConta, string nomeTitular, double saldo)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = saldo;

            ImprimeDadosBancarios(this);
        }


        public static ContaBancaria AberturaContaBancaria()
        {
            Console.WriteLine("Digite o número da conta: ");
            string numeroConta = Console.ReadLine();

            Console.WriteLine("Digite o nome do titular: ");
            string nomeTitular = Console.ReadLine();

            Console.WriteLine("Haverá depósito inicial (S/N)? ");
            string escolhaDepositoInicial = Console.ReadLine();
            

            double deposito = 0.0;

            if (escolhaDepositoInicial.ToLower() == "s")
            {
                Console.WriteLine("Digite o valor do depósito inicial: ");
                deposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            return new ContaBancaria(numeroConta, nomeTitular, deposito);
        }
             


        public void Deposito(ContaBancaria contaBancaria)
        {
            Console.WriteLine("Entre um valor para o depósito: ");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);            
            Saldo += valor;
            ImprimeDadosBancarios(contaBancaria);
        }



        public void Saque(ContaBancaria contaBancaria)
        {
            Console.WriteLine("Entre um valor para saque:");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Saldo -= valor + 5;
            ImprimeDadosBancarios(contaBancaria);
        }



        public void ImprimeDadosBancarios(ContaBancaria contaBancaria)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Dados da conta atualizados: ");
            Console.WriteLine(contaBancaria.ToString());
            Console.WriteLine(" ");
        }


        public override string ToString()
        {
            return "Conta: " + NumeroConta + ", Titular: " + NomeTitular + ", Saldo: $ " + Saldo.ToString("F2");
        }






    }
}
