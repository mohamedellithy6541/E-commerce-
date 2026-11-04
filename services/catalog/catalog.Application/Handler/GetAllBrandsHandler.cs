using AutoMapper;
using catalog.Application.Quaries;
using catalog.Application.Responses;
using catalog.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Application.Handler
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponseDto>>
    {
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;

        public GetAllBrandsHandler(IProductBrandRepository productBrandRepository, IMapper mapper)
        {
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }
        public async Task<IList<BrandResponseDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _productBrandRepository.GetAllBrands();
            var productBrandDtos = _mapper.Map<IList<BrandResponseDto>>(brands.ToList());
            return productBrandDtos;
        }
    }
}
