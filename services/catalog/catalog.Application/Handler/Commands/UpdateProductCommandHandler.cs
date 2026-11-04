using AutoMapper;
using catalog.Application.Commands;
using catalog.Core.Entities;
using catalog.Core.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Application.Handler.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository,IMapper mapper  )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        { 
            var existingProduct = await _productRepository.GetProductById(request.Id);
            var product = _mapper.Map<Product>(request);
            var productUpdated = await _productRepository.UpdateProduct(new Product() 
            {
                Id   = request.Id,
                Name = request.Name,
                Description = request.Description,
                Summary = request.Summary,
                ImageFile = request.ImageFile,
                Brand = request.Brand,
                Type = request.Type
            });

            return productUpdated;
        }
    }
}
