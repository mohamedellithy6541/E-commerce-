using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers.Command
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateBasketCommandHandler(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        } 
      
        public async  Task<ShoppingCartResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {   

           var shoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart() 
           {
               UserName=request.UserName,
               Items = request.Items 

           });
           var basketResponse = _mapper.Map<ShoppingCartResponse>(shoppingCart);

            return basketResponse;   
        }
    }
}
