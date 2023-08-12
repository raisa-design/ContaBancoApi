using ContaBancoApi.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaBancoApi.Dto.ContaBancariaDtos
{
    public class ContaBancariaDto
    {
        public int NumConta { get; set; }

        public TipoConta Tipo { get; set; }

        public string Dono { get; set; }

        public double Saldo { get; set; }

        public StatusConta Status { get; set; }

        public int NumeroAgencia { get; set; }


    }
}
