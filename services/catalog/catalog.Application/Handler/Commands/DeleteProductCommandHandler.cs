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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;   
        }   
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var existproduct = await _productRepository.GetProductById(request.Id);
            var deletedProduct = _productRepository.DeleteProduct(existproduct);
            return await deletedProduct;
        }
    }
}
