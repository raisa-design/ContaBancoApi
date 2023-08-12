namespace ContaBancoApi.Entidades
{
    public class Agencia
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        public double Saldo { get; set; }

        public List<ContaBancaria> ContasBancarias { get; set; }

        public Agencia(int numero)
        {
            Numero = numero;
            Saldo = 0;
        }

    }
}
