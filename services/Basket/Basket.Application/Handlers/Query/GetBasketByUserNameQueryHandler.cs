using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers.Query
{
    public class GetBasketByUserNameQueryHandler : IRequestHandler<GetBasketQueryByUserName, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketByUserNameQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;   
        }
        public async Task<ShoppingCartResponse> Handle(GetBasketQueryByUserName request, CancellationToken cancellationToken)
        { 
            var basket = await _basketRepository.GetBasket(request.UserName);
            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(basket);
            return shoppingCartResponse;
        }
    }
}
