using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_MVC___C__Portfolio.Models;
using ASP.NET_MVC___C__Portfolio.Persistence;

namespace ASP.NET_MVC___C__Portfolio.Controllers
{
    public class Games1Controller : Controller
    {
        private readonly OracleDbContext _context;

        public Games1Controller(OracleDbContext context)
        {
            _context = context;
        }

        private void PopularPlataformas()
        {
            ViewBag.Plataformas = new List<SelectListItem>
            {
                new SelectListItem { Value = "PlayStation", Text = "PlayStation" },
                new SelectListItem { Value = "Xbox", Text = "Xbox" },
                new SelectListItem { Value = "NintendoSwitch", Text = "Nintendo Switch" },
                new SelectListItem { Value = "Mobile", Text = "Mobile" },
                new SelectListItem { Value = "PC", Text = "PC" }
            };
        }

        // GET: Games1
        public async Task<IActionResult> Index()
        {
            var jogos = await _context.Games.OrderBy(j => j.Nome).ToListAsync();
            return View(jogos);
        }

        // GET: Games1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .FirstOrDefaultAsync(m => m.ID == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games1/Create
        public IActionResult Create()
        {
            PopularPlataformas();
            return View();
        }

        // POST: Games1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Valor,Plataformas,EmpresaDesenvolvedora,DataLancamento")] Games games)
        {
            if (ModelState.IsValid)
            {
                _context.Add(games);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopularPlataformas();
            return View(games);
        }

        // GET: Games1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }

            PopularPlataformas();
            return View(games);
        }

        // POST: Games1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Valor,Plataformas,EmpresaDesenvolvedora,DataLancamento")] Games games)
        {
            if (id != games.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            PopularPlataformas();
            return View(games);
        }

        // GET: Games1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .FirstOrDefaultAsync(m => m.ID == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Games1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var games = await _context.Games.FindAsync(id);
            if (games != null)
            {
                _context.Games.Remove(games);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.ID == id);
        }
    }
}
