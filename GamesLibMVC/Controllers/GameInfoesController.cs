using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesLibMVC.Models;

namespace GamesLibMVC.Controllers
{
    public class GameInfoesController : Controller
    {
        private readonly GamesContext _context;

        public GameInfoesController(GamesContext context)
        {
            _context = context;
        }

        // GET: GameInfoes
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<GameInfo> gameInfoes = _context.GamesInfo.Include(g => g.Game).Include(g => g.Genre);
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString) && searchString != "Все")
            {
                gameInfoes = gameInfoes.Where(g => g.Genre.GenreName.Contains(searchString));
            }
            return View(await gameInfoes.AsNoTracking().ToListAsync());
        }

        // GET: GameInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameInfo = await _context.GamesInfo
                .Include(g => g.Game)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.GameInfoID == id);
            if (gameInfo == null)
            {
                return NotFound();
            }

            return View(gameInfo);
        }

        // GET: GameInfoes/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Games, "GameID", "GameName");
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreName");
            return View();
        }

        // POST: GameInfoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameInfoID,GameID,GenreID")] GameInfo gameInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Games, "GameID", "GameName", gameInfo.GameID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreName", gameInfo.GenreID);
            return View(gameInfo);
        }

        // GET: GameInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameInfo = await _context.GamesInfo.FindAsync(id);
            if (gameInfo == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Games, "GameID", "GameName", gameInfo.GameID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreName", gameInfo.GenreID);
            return View(gameInfo);
        }

        // POST: GameInfoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameInfoID,GameID,GenreID")] GameInfo gameInfo)
        {
            if (id != gameInfo.GameInfoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameInfoExists(gameInfo.GameInfoID))
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
            ViewData["GameID"] = new SelectList(_context.Games, "GameID", "GameName", gameInfo.GameID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreName", gameInfo.GenreID);
            return View(gameInfo);
        }

        // GET: GameInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameInfo = await _context.GamesInfo
                .Include(g => g.Game)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.GameInfoID == id);
            if (gameInfo == null)
            {
                return NotFound();
            }

            return View(gameInfo);
        }

        // POST: GameInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameInfo = await _context.GamesInfo.FindAsync(id);
            _context.GamesInfo.Remove(gameInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameInfoExists(int id)
        {
            return _context.GamesInfo.Any(e => e.GameInfoID == id);
        }
    }
}
