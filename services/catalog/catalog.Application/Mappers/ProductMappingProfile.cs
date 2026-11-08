using AutoMapper;
using catalog.Application.Commands;
using catalog.Application.Responses;
using catalog.Core.Entities;
using catalog.Core.Specs;

namespace catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductBrand, BrandResponseDto>().ReverseMap();
            CreateMap<Product, ProductResponseDto>().ReverseMap();
            CreateMap<ProductType, ProductTypeResponseDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Pagination<Product>, Pagination<ProductResponseDto>>().ReverseMap();


        }
    }
}
