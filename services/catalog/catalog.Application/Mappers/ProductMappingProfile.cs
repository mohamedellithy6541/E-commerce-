using AutoMapper;
using catalog.Application.Responses;
using catalog.Core.Entities;

namespace catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductBrand, BrandResponseDto>().ReverseMap();
            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<ProductType, ProductTypeResponseDto>().ReverseMap();
           
        }
    }
}
