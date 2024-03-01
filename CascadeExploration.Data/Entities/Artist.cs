using System.ComponentModel.DataAnnotations;

namespace CascadeExploration.Data.Entities
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(100)]
        public string Name { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();
        public List<Track> Tracks { get; set; } = new List<Track>();
    }
}