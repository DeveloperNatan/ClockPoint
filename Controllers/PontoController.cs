using Clock_API.Data;
using Clock_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clock_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoController : ControllerBase
    {
        //acessa banco
        private readonly AppDbContext _appDbcontext;

        //contrutor que recebe instancia do banco
        //injecao de dependencia
        public PontoController(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPoint(Ponto ponto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appDbcontext.Pontos.Add(ponto);
            await _appDbcontext.SaveChangesAsync();

            return Created("criado", ponto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ponto>>> FindAllPoints()
        {
            var Horarios = await _appDbcontext.Pontos.ToListAsync();

            return Ok(Horarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ponto>> FindOnePoint(int id)
        {
            var horario = await _appDbcontext.Pontos.FindAsync(id);

            if (horario == null)
            {
                return NotFound("Nenhum registro");
            }
            return Ok(horario);
        }

        //nao funciona

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoint(int id)
        {
            var ponto = await _appDbcontext.Pontos.FindAsync(id);

            _appDbcontext.Pontos.Remove(ponto);
            await _appDbcontext.SaveChangesAsync();

            return Ok("Deletado!");
        }

        //gustavo cateno
        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdatePoint(int id, [FromBody] Ponto pontoCurrent)
        // {
        //     var pontoAtual = await _appDbcontext.Pontos.FindAsync(id);

        //     _appDbcontext.Entry(pontoAtual).CurrentValues.SetValues(pontoCurrent);

        //     await _appDbcontext.SaveChangesAsync();
        //     return StatusCode(201, pontoAtual);
        // }

        //eu fiz
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePoint(Ponto ponto, int id)
        {
            var req = await _appDbcontext.Pontos.FindAsync(id);
            req.Nome = ponto.Nome;
            req.Tipo = ponto.Tipo;

            _appDbcontext.Pontos.Update(req);
            await _appDbcontext.SaveChangesAsync();

            return Ok(req);
        }
    }
}
