using System.ComponentModel.DataAnnotations.Schema;

namespace ContaBancoApi.Entidades
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public int NumConta { get; set; }

        public TipoConta Tipo { get; set; }

        public string Dono { get; set; }

        public double Saldo { get; set; }

        public StatusConta Status { get; set; }

        public  int AgenciaId { get; set; }

        [NotMapped]  
        public  Agencia Agencia { get; set; }


        public ContaBancaria()
        {
            
        }

        public void AbrirConta(TipoConta tipo, string dono, Agencia  agencia)
        {
            Saldo = 0;
            Status = StatusConta.Ativado;
            Tipo = tipo;
            Dono = dono;

            Random randNum = new Random();
            NumConta = randNum.Next(10000000, 999999999);
            Agencia = agencia;
            AgenciaId = agencia.Id;


        }

        //public void mostrarDetalhes()
        //{
        //    Console.WriteLine("//////////////////////////////////////////////");
        //    Console.WriteLine("Tipo: " + Tipo);
        //    Console.WriteLine("Nome: " + Dono);
        //    Console.WriteLine("Numero da Conta: " + NumConta);
        //    Console.WriteLine("Saldo: " + Saldo);
        //    Console.WriteLine("Status: " + Status);


        //    Console.WriteLine("//////////////////////////////////////////////");

        //}
        //public void setStatus(bool status)
        //{
        //    Status = status;
        //}

        //public void setNumConta(int numConta)
        //{
        //    NumConta = numConta;
        //}

        //public void setTipo(string tipo)
        //{
        //    Tipo = tipo;
        //}
        //public void setDono(string dono)
        //{
        //    Dono = dono;
        //}

        //public int getNumConta()
        //{
        //    return NumConta;
        //}
        //public void abrirConta(string type)
        //{
        //    Tipo = type;
        //    setStatus(true);

        //    if (type == "CC")
        //    {
        //        Saldo = 50;
        //    }
        //    else if (type == "CP")
        //    {
        //        Saldo = 150;
        //    }
        //}

        //public void fecharConta()
        //{
        //    if (Saldo > 0)
        //    {
        //        Console.WriteLine("Conta com dinheiro");
        //    }
        //    else if (Saldo < 0)
        //    {
        //        Console.WriteLine("Conta em débito");
        //    }
        //    else
        //    {
        //        setStatus(false);
        //    }

        //}

        public void Depositar(double dep)
        {
            Console.WriteLine(Status);
            if (Status == StatusConta.Ativado)
            {
                Saldo = Saldo + dep;
            }
            else
            {
                Console.WriteLine("Impossível Depositar");

            }
        }

        public void Sacar(double sac)
        {
            if (Status == StatusConta.Ativado )
            {
                if (Saldo >= sac)
                {
                    Saldo = Saldo - sac;
                    CustoSaque();

                }
                else
                {
                    Console.WriteLine("saldo insuficiente");
                }
            }
            else
            {
                Console.WriteLine("impossível Sacar");
            }

        }

        // essa finção recebe uma valor divide por 100 e retorna o valor dividido 
        public double Porcentagem(int valor)
        {

            var resultado = valor / 100; 

            return resultado;
        }

        public void CustoSaque()
        {
           
          double porcentagem = 0.01; // 1% é representado como 0.01

          double valorReducao = Saldo * porcentagem;

          double novoSaldo = Saldo - valorReducao;

          Saldo = novoSaldo;

          Agencia.Saldo = Agencia.Saldo + valorReducao;

        }


        //public void pagarMensal()
        //{
        //    double pagMen = 0;

        //    if (Tipo == "CC")
        //    {
        //        pagMen = 12;
        //    }
        //    else if (Tipo == "CP")
        //    {
        //        pagMen = 20;
        //    }

        //    if (Status == true)
        //    {
        //        if (Saldo >= pagMen)
        //        {
        //            Saldo = Saldo - pagMen;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Saldo Insuficiente");

        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine("Impossível pagar");
        //    }
        //}



        //internal bool abrirConta()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
