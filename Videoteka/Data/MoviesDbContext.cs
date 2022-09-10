using Microsoft.EntityFrameworkCore;
using Videoteka.Models;

namespace Videoteka.Data
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = null!;
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }
    }
}
