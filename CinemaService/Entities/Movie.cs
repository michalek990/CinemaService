namespace CinemaService.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rank { get; set; }

        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }
    }
}
