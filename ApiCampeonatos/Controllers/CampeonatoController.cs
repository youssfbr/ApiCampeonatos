using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiCampeonatos.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ApiCampeonatos.Controllers
{
    [Authorize]
    [Route("[controller]/classificacao_geral")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CampeonatoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Campeonato>> GetCampeonato(int id)
        {
            var campeonato = await _context.Campeonatos.FindAsync(id);

            if (campeonato == null)
            {
                return NotFound();
            }

            return campeonato;
        }

        [HttpPost]
        public async Task<ActionResult<Campeonato>> PostCampeonato(Campeonato campeonato)
        {      
            _context.Campeonatos.Add(campeonato);
            await _context.SaveChangesAsync();
          
            return CreatedAtAction("GetCampeonato", new { id = campeonato.Id }, campeonato);
        }
    }
}
