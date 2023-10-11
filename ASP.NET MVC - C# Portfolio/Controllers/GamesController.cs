using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NET_MVC___C__Portfolio.Models;
using System.Threading.Tasks;
using ASP.NET_MVC___C__Portfolio.Persistence;

namespace ASP.NET_MVC___C__Portfolio.Controllers
{
    public class GamesController : Controller
    {
        private readonly OracleDbContext _context;

        public GamesController(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Counter = 1; // Inicialize o contador com 1
            var jogos = await _context.Games.ToListAsync();
            return View(jogos);

            /*{
                var jogos = await _context.Games.OrderBy(j => j.Nome).ToListAsync();
                return View(jogos); 
            } -- ordena por ordem alfabetica  
            */
        }
    }
}
/* garante que o contador de jogos inicia em 1 */
