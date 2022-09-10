using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = null!;
    }
}
