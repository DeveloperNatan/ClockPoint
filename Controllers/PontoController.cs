using Clock_API.Data;
using Clock_API.Models;
using Microsoft.AspNetCore.Mvc;

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
            _appDbcontext.Pontos.Add(ponto);
            await _appDbcontext.SaveChangesAsync();

            return Ok(ponto);
        }

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

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOnePoint(int id)
        {
            var ponto = await _appDbcontext.Pontos.FindAsync(id);

            await _appDbcontext.SaveChangesAsync();
            return Ok(ponto);
        }

        //nao funciona
        [HttpGet]
        public async Task<IActionResult> FindAllPoint()
        {
            var ponto = await _appDbcontext.Pontos.FindAsync();

            await _appDbcontext.SaveChangesAsync();
            return Ok(ponto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoint(int id)
        {
            var ponto = await _appDbcontext.Pontos.FindAsync(id);

            _appDbcontext.Pontos.Remove(ponto);
            await _appDbcontext.SaveChangesAsync();

            return Ok(ponto);
        }
    }
}
