using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} je povinný údaj")]
        [MaxLength(255)]
        [Display(Name = "Název")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "{0} je povinný údaj")]
        [Range(1, 9999, ErrorMessage = "Zadejte pouze rok v rozmezí 1 až 9999")]
        [Display(Name = "Rok vydání")]
        public int ReleaseYear { get; set; }
        public int GenreId { get; set; }
        [Display(Name = "Žánr")]
        public Genre? Genre { get; set; } = null!;
        [Range(0, 5, ErrorMessage = "Zadejte hodnotu v rozmezí 0 až 5")]
        [Display(Name = "Hodnocení")]
        public int Rating { get; set; }
    }
}
