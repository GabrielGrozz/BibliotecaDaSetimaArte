using AutoMapper;
using BibliotecaDaSetimaArte.Models;

namespace BibliotecaDaSetimaArte.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
