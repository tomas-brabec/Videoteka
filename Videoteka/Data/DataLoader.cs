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
                new Genre() { Name = "Drama" },
                new Genre() { Name = "Komedie" },
                new Genre() { Name = "Dobrodružný" },
                new Genre() { Name = "Western" },
                new Genre() { Name = "Historický" },
                new Genre() { Name = "Životopisný" },
                new Genre() { Name = "Sci-Fi" },
                new Genre() { Name = "Horor" },
                new Genre() { Name = "Akční" }
            );

            context.SaveChanges();
        }

        private static void LoadMovies(MoviesDbContext context)
        {
            context.Movies.AddRange(
                new Movie() { Title = "Vetřelec", ReleaseYear = 1979, GenreId = 6, Rating = 5 },
                new Movie() { Title = "Blade Runner 2049 ", ReleaseYear = 2017, GenreId = 6, Rating = 4 },
                new Movie() { Title = "John Wick", ReleaseYear = 2014, GenreId = 9, Rating = 5 },
                new Movie() { Title = " Babovřesky", ReleaseYear = 2013, GenreId = 2, Rating = 0 }
                );

            context.SaveChanges();
        }
    }
}
