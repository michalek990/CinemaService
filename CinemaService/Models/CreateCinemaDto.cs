using System.ComponentModel.DataAnnotations;

namespace CinemaService.Models
{
    public class CreateCinemaDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(40)]
        public string Street { get; set; }

        public string PostalCode { get; set; }
    }
}
