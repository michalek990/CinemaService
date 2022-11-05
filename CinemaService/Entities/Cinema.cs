namespace CinemaService.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

        public int AddressId { get; set; }

        public virtual List<Movie> Movies { get; set; }

        public virtual Address Address { get; set; }
    }
}
