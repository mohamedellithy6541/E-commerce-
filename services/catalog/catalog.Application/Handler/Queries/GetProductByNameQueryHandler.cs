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
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, ProductResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByNameQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductResponseDto> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductsByName(request.Name);
            var productDto = _mapper.Map<ProductResponseDto>(product);
            return productDto;
        }
    }
}
