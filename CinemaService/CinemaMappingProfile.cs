using AutoMapper;
using CinemaService.Entities;
using CinemaService.Models;
using System.IO;

namespace CinemaService
{
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {
            CreateMap<Cinema, CinemaDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Movie, MovieDto>();

            CreateMap<CreateCinemaDto, Cinema>()
                .ForMember(m => m.Address, c => c.MapFrom(dto => new Address()
                    { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));

            CreateMap<CreateMovieDto, Movie>();
        }
    }
}
