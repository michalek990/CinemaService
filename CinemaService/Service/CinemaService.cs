using System.Globalization;
using AutoMapper;
using CinemaService.Entities;
using CinemaService.Exceptions;
using CinemaService.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaService.Service
{
    public interface ICinemaService
    {
        public int Create(CreateCinemaDto dto);
        public void Delete(int id);
        public void Update(int id,UpdateCinemaDto dto);
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

            if (cinema == null)
            {
                throw new NotFoundException("Cinema not found");
            }

            _dbContext.Cinema.Remove(cinema);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateCinemaDto dto)
        {
            var cinema = _dbContext
                .Cinema.FirstOrDefault(c => c.Id == id);

            if (cinema == null)
            {
                throw new NotFoundException("Cinema not found");
            }

            cinema.Name = dto.Name;
            cinema.Description = dto.Description;
            cinema.Rank = dto.Rank;

            _dbContext.SaveChanges();
        }
    }
}
