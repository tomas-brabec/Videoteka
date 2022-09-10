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
                return RedirectToAction(nameof(Index));
            }

            ViewData["GenreList"] = new SelectList(await _context.Genres.ToListAsync(), "Id", "Name", movie.GenreId);
            return View(movie);
        }
    }
}
