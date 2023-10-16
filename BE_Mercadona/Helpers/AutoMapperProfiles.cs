using AutoMapper;
using BE_Mercadona.DTOs;
using BE_Mercadona.Models;

namespace BE_Mercadona.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductDTO,Product>().ReverseMap();
            CreateMap<ProductCreationDTO,Product>();
        }
    }
}
