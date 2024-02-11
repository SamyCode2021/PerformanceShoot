using AutoMapper;
using AutoMapperResearch.Models;
using Riok.Mapperly.Abstractions;

namespace AutoMapperResearch.Mappers
{
    public class PersonAutoMapper
    {
        public static MapperConfiguration CreateAutoMapper()
        {
            return new MapperConfiguration(cfg =>
                cfg.CreateMap<Person, PersonDto>()
                    .ForMember(dest => dest.PersonId, act => act.MapFrom(src => src.Id))
                    .ForMember(dest => dest.PersonFullName, act => act.MapFrom(src => src.Name))
                    .ForMember(dest => dest.PersonDateOfBirth, act => act.MapFrom(src => src.DateOfBirth)));
        }

    }
}