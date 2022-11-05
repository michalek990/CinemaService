using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{
    public class UpdateCinemaDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }
    }
}
