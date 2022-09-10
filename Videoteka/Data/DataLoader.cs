using Microsoft.EntityFrameworkCore;
using Videoteka.Models;

namespace Videoteka.Data
{
    public static class DataLoader
    {
        //Initialize database https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-6.0&tabs=visual-studio#seed-the-database
        public static void Load(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesDbContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesDbContext>>()))
            {
                if (!context.Genres.Any())
                    LoadGenres(context);

                if (!context.Movies.Any())
                    LoadMovies(context);
            }
        }

        private static void LoadGenres(MoviesDbContext context) 
        {
            context.Genres.AddRange(
                new Genre() { Name = "SciFi" },
                new Genre() { Name = "Krimi" }
                );

            context.SaveChanges();
        }

        private static void LoadMovies(MoviesDbContext context)
        {
            context.Movies.AddRange(
                new Movie() { Title = "Alien", ReleaseYear = 1979, GenreId = 1, Rating = 5 }
                );

            context.SaveChanges();
        }
    }
}
