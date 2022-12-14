using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Videoteka.Data;
using Videoteka.Models;

namespace Videoteka.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesDbContext _context;

        public MovieController(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.Include(m => m.Genre).ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewData["GenreList"] = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ReleaseYear,GenreId,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                TempData["Succes"] = $"Do vaší videotéky byl úspěšně přidán záznam o filmu: \"{movie.Title}\"";

                return RedirectToAction(nameof(Index));
            }

            ViewData["GenreList"] = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name", movie.GenreId);
            return View(movie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["GenreList"] = new SelectList(_context.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseYear,GenreId,Rating")] Movie movie)
        {
            if (id != movie.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
                TempData["Succes"] = $"Záznam o filmu: \"{movie.Title}\" byl aktualizován";

                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreList"] = new SelectList(_context.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                TempData["Delete"] = $"Film: \"{movie.Title}\" byl smazán";
            }

            await _context.SaveChangesAsync();
            //TODO
            return RedirectToAction(nameof(Index));
        }
    }
}
