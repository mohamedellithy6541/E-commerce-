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

namespace catalog.Application.Handler.Queries
{
    public class GetBroductBrandByNameQueryHandler : IRequestHandler<GetBroductBrandByNameQuery, IList<BrandResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetBroductBrandByNameQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<BrandResponseDto>> Handle(GetBroductBrandByNameQuery request, CancellationToken cancellationToken)
        { 
            var brand = await _productRepository.GetProductsByBrandName(request.Name);
            var brandNameResponse = _mapper.Map<IList<BrandResponseDto>>(brand.ToList());
            return brandNameResponse;
        }
    }
}
