using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{
    public class CreateMovieDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }
        public int CinemaId { get; set; }
    }
}
