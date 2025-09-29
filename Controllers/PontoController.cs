using Clock_API.Data;
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
    }
}
