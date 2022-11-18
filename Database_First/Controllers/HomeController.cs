using Database_First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Database_First.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("GetData")]
        public async Task<IActionResult> GetData()
        {
            AppDbContext context = new AppDbContext();
            var pessoa = context.Pessoas.FirstOrDefault();
            pessoa.Nome = "Lucas Juan";
            
            return Ok(pessoa);

        }
    }
}
