using E_Commerce.Application.DTOs.Product;
using AutoMapper;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
