using AutoMapper;
using RehberWeb.Models.Dtos;
using RehberWeb.Models.Entities;

namespace RehberWeb.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RehberDto, Rehber>();

        }
    }
}
