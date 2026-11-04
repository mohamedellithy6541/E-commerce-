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
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository ,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IList<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProducts();
            var productDtos =  _mapper.Map<IList<ProductResponseDto>>(products.ToList());
            return productDtos;
        }
    }
}
