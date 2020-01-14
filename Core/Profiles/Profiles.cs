
using AutoMapper;
using Repository.Models;
using Repository.Models.Dtos;

namespace Core.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
