using ContaBancoApi.Data;
using ContaBancoApi.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContaBancoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AgenciaController : ControllerBase

    { 
            private readonly DataContext _context;

            public AgenciaController(DataContext context)
            {
                _context = context;
            }


       
        [HttpGet]
        public List<Agencia> Get()
        {

            var agencia = _context.agencias.Include(x => x.ContasBancarias) .ToList();
            return agencia;

        }
        [HttpPost]
        public void Post( int numero )
        {
            var agencia = new Agencia(numero);

            _context.agencias.Add(agencia);
            _context.SaveChanges();
        }

    }
}
