public partial class Program
{
    public static void Main()
    {
        List<ContaBancaria> contas = new List<ContaBancaria>();
        Random random = new Random();
        HashSet<int> hashSetNumeroConta = new HashSet<int>();
        DateTime dateTime = new DateTime();
        do
        {
            Console.WriteLine($"\t[{DateTime.Now}] Sistema de Contas Bancárias.");
            Console.WriteLine("\nEscolha uma opção das escolhas abaixo: ");
            Console.WriteLine("1 - Criar conta. ");
            Console.WriteLine("2 - Depositar dinheiro na conta ");
            Console.WriteLine("3 - Sacar dinheiro da conta ");
            Console.WriteLine("4 - Verificar saldo da conta ");
            Console.WriteLine("5 - Listar todas as contas ");
            Console.WriteLine("6 - Sair");
            int escolha = Convert.ToInt16(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("\nDigite o nome do titular: ");
                    string nomeTitular = Console.ReadLine();
                    int numeroConta;
                    double saldo = 0;
                    do
                    {
                        numeroConta = random.Next(1000, 1999);
                    }
                    while (!hashSetNumeroConta.Add(numeroConta));
                    ContaBancaria novaConta = new ContaBancaria(nomeTitular, numeroConta);
                    contas.Add(novaConta);
                    Console.WriteLine("Conta criada com sucesso para o titular {0} com número: {1}", nomeTitular, numeroConta);
                    break;
                case 2:
                    Console.WriteLine("\nDigite a conta para deposito: ");
                    int contaDeposito = Convert.ToInt32(Console.ReadLine());
                    ContaBancaria contaParaDeposito = contas.Find(c => c.Numero == contaDeposito);
                    if (hashSetNumeroConta.Contains(contaDeposito))
                    {
                        Console.WriteLine("Digite o valor para deposito: ");
                        double deposito = Convert.ToDouble(Console.ReadLine());
                        contaParaDeposito.Saldo += deposito;
                        Console.WriteLine("Depósito de {0:C} realizado com sucesso na conta {1}.", deposito, contaDeposito);
                        Console.WriteLine("Saldo na conta: {0:C} ", contaParaDeposito.Saldo);
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada. Verifique o número da conta e tente novamente.");
                    }
                    break;
                case 3:
                    Console.WriteLine("\nDigite a conta para sacar: ");
                    int contaSaque = Convert.ToInt32(Console.ReadLine());
                    ContaBancaria contaParaSaque = contas.Find(c => c.Numero == contaSaque);
                    if (hashSetNumeroConta.Contains(contaSaque) && contaParaSaque.Saldo > 0)
                    {
                        Console.WriteLine("Digite o valor para sacar: ");
                        double saque = Convert.ToDouble(Console.ReadLine());
                        if (saque < contaParaSaque.Saldo)
                        {
                            contaParaSaque.Saldo -= saque;
                            Console.WriteLine("Saque de {0:C} realizado com sucesso na conta {1}.", saque, contaSaque);
                            Console.WriteLine("Saldo na conta: {0:C}", contaParaSaque.Saldo);
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta não encontrada ou saldo insuficiente.");
                    }
                    break;
                case 4:
                    Console.WriteLine("\nDigite a conta para ver o saldo: ");
                    int contaSaldo = Convert.ToInt32(Console.ReadLine());
                    ContaBancaria contaVerificarSaldo = contas.Find(c => c.Numero == contaSaldo);
                    if (hashSetNumeroConta.Contains(contaSaldo))
                    {
                        Console.WriteLine("Saldo na conta {0}: {1:C}", contaVerificarSaldo, contaVerificarSaldo.Saldo);
                    }
                    break;
                case 5:
                    Console.WriteLine("Contas disponíveis:");
                    foreach (int conta in hashSetNumeroConta)
                    {
                        Console.WriteLine(conta);
                    }
                    break;
                default:
                    Console.WriteLine("Número digitado inválido!! ");
                    return;
            }
        } while (true);
    }
}
