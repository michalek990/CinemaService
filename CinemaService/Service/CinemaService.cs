using AutoMapper;
using CinemaService.Entities;
using CinemaService.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaService.Service
{
    public interface ICinemaService
    {
        public int Create(CreateCinemaDto dto);
        public void Delete(int id);
    }

    public class CinemaService : ICinemaService
    {
        private readonly CinemaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CinemaService(CinemaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateCinemaDto dto)
        {
            var cinema = _mapper.Map<Cinema>(dto);
            _dbContext.Cinema.Add(cinema);
            _dbContext.SaveChanges();
            return cinema.Id;
        }

        public void Delete(int id)
        {
            var cinema = _dbContext
                .Cinema.FirstOrDefault(c => c.Id == id);

            _dbContext.Cinema.Remove(cinema);
            _dbContext.SaveChanges();
        }
    }
}
