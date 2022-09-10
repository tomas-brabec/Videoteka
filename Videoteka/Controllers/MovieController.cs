using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Videoteka.Data;

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
    }
}
