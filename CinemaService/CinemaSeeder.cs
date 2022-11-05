using CinemaService.Entities;

namespace CinemaService
{
    public class CinemaSeeder
    {
        private readonly CinemaDbContext _dBContext;

        public CinemaSeeder(CinemaDbContext dbContext)
        {
            _dBContext = dbContext;
        }
        public void Seed()
        {
            //srapwdzamy polaczenie do bazy danych
            if (_dBContext.Database.CanConnect())
            {
                if (!_dBContext.Role.Any())
                {
                    var roles = GetRoles();
                    _dBContext.Role.AddRange(roles);
                    _dBContext.SaveChanges();
                }

                if (!_dBContext.Resteurants.Any())
                {
                    var resteurants = GetResteurants();
                    _dBContext.Resteurants.AddRange(resteurants);
                    _dBContext.SaveChanges();


                }
            }
        }
    }
}
