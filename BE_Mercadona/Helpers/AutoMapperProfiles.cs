using AutoMapper;
using BE_Mercadona.DTOs;
using BE_Mercadona.Models;

namespace BE_Mercadona.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CategoryDTO,Category>().ReverseMap();
            CreateMap<CategoryCreationDTO,Category>();
            CreateMap<ProductDTO,Product>().ReverseMap();
            CreateMap<ProductCreationDTO,Product>();
            CreateMap<PromotionDTO, Promotion>().ReverseMap();
            CreateMap<PromotionCreationDTO, Promotion>();
        }
    }
}
