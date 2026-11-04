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
    public class GetAllProductTypeQueryHandler : IRequestHandler<GetAllProductTypesQuery, IList<ProductTypeResponseDto>>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public GetAllProductTypeQueryHandler(IProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }
        public async Task<IList<ProductTypeResponseDto>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            var productTypes = await _productTypeRepository.GetAllTypes();
            var productTypesList = _mapper.Map<IList<ProductTypeResponseDto>>(productTypes.ToList());
            return productTypesList;
        }
    }
}
