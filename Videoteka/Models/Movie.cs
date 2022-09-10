using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = null!;
        [Range(1, 9999)]
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
