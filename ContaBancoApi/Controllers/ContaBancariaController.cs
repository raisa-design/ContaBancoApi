
using ContaBancoApi.Data;
using ContaBancoApi.Dto.ContaBancariaDtos;
using ContaBancoApi.Entidades;
using ContaBancoApi.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContaBancoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        private readonly DataContext _context;

          public ContaBancariaController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<ContaBancariaController>
        [HttpGet]
        public List<ContaBancariaDto> Get()
        {

            var listaContas = _context.contasBancarias.Include(cb => cb.Agencia).ToList();

            var listaDto = new List<ContaBancariaDto>();
            foreach (var conta in listaContas)
            {
                var contaDto = new ContaBancariaDto()
                {
                    NumConta = conta.NumConta,
                    Dono = conta.Dono,
                    Saldo = conta.Saldo,
                    Status = conta.Status,
                    Tipo = conta.Tipo,
                    NumeroAgencia = conta.Agencia.Numero
                };

                listaDto.Add(contaDto);
            }
           
            return listaDto;

        }

        // GET api/<ContaBancariaController>/5
        [HttpGet("{id}")]
        public ContaBancariaDto  Get (int id)
        {
            var cb = _context.contasBancarias.FirstOrDefault(x => x.Id==id);
            var agencia = _context.agencias.FirstOrDefault(x => x.Id == cb.AgenciaId);

            var contabancaria = new ContaBancariaDto()
            {
                NumConta = cb.NumConta,
                Dono = cb.Dono,
                Saldo = cb.Saldo,
                Status = cb.Status,
                Tipo = cb.Tipo,
                NumeroAgencia = agencia.Numero
            };


            return contabancaria;
        }

        // POST api/<ContaBancariaController>
        [HttpPost]
        public void AbrirConta (TipoConta tipo, string dono, int numeroAgencia)
        {
            var contaBancaria = new ContaBancaria();

            var agencia = _context.agencias.FirstOrDefault(x => x.Numero == numeroAgencia);

            contaBancaria.AbrirConta(tipo, dono, agencia);
            _context.contasBancarias.Add(contaBancaria);
            _context.SaveChanges();
        }


        //[HttpPut("{id}")]
        //public ActionResult<Atividade> Put(Atividade model)
        //{
        //    var atividade = _context.Atividades.FirstOrDefault(ati => ati.Id == model.Id);

        //    atividade.Titulo = model.Titulo;
        //    atividade.Descricao = model.Descricao;
        //    atividade.Prioridade = model.Prioridade;
        //    _context.Atividades.Update(atividade);
        //    _context.SaveChangesAsync();
        //    return Ok(atividade);
        //}
        // O model pega todas as propriedades do ContaBancaria, mas como só quero algumas irei fazer assim
        //[HttpPut("{id}")]
        //public ActionResult<ContaBancaria> Put( int numConta, string name, int id)
        //{
        //    var cb = _context.contasBancarias.FirstOrDefault(ati => ati.Id == id);


        //    cb.NumConta = numConta;
        //    cb.Dono =name;
        //    _context.contasBancarias.Update(cb);
        //    _context.SaveChangesAsync();
        //    return Ok(cb);
        //}

        [HttpPut("Sacar")]
        public ActionResult<ContaBancaria> Sacar(int numConta, double valorSaldo)
        {
            var cb = _context.contasBancarias.Include(x => x.Agencia).FirstOrDefault(cb => cb.NumConta == numConta);


            cb.Sacar(valorSaldo);
            _context.contasBancarias.Update(cb);
            _context.SaveChangesAsync();
            return Ok(cb);
        }

        [HttpPut("Depositar")]
        public ActionResult<ContaBancaria> depositar(int numconta, double valordeposito)
        {
            var cb = _context.contasBancarias.FirstOrDefault(cb => cb.NumConta == numconta);


            cb.Depositar(valordeposito);
            _context.contasBancarias.Update(cb);
            _context.SaveChangesAsync();
            return Ok(cb); 
        }



        [HttpDelete("remove/{id}")]
        public IActionResult RemoveItem(int id)
        {
            var cb = _context.contasBancarias.Find(id);
            _context.Remove(cb);
            _context.SaveChangesAsync();
            return Ok(cb);
        }

        //[HttpDelete("desativar")]
        //public IActionResult Desativar(int numConta)
        //{
        //    var cb = _context.contasBancarias.FirstOrDefault(cb => cb.NumConta == numConta);
        //    cb.fecharConta();
        //    _context.Update(cb);
        //    _context.SaveChangesAsync();
        //    return Ok(cb);
        //}


        //   ou  [HttpDelete("{id}")]
        //    public bool Delete(int id)
        //    {
        //        var cb = _context.ContasBancarias.FirstOrDefault(ati => ati.Id == id);
        //        if (cb == null)
        //            throw new Exception("Você está tentando deletar uma atividade que não existe");

        //        _context.Remove(cb);
    }
}
