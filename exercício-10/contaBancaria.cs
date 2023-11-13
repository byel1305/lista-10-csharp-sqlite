public class ContaBancaria
{
    public int Numero { get; set; }
    public string Titular { get; set; }
    public double Saldo { get; set; }

    public ContaBancaria(string t, int n)
    {
        Numero = n;
        Titular = t;
        Saldo = 0;
    }
}