using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using catalog.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public BasketController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        public async Task<ShoppingCartResponse> GetBasket(string userName)
        {
            var query = new GetBasketQueryByUserName(userName);
            var basket = await _mediator.Send(query);
            return basket;
        }
        [HttpPost]
        [Route("[action]", Name = "UpdateBasket")]
        public async Task<ShoppingCartResponse> UpdateBasket([FromBody] CreateBasketCommand createShopingCardCommand)
        {
            var basket = await _mediator.Send(createShopingCardCommand);
            return basket;
        }

        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
        public async Task<ActionResult<ShoppingCartResponse>> DeleteBasket(string userName)
        {
            var deleteBasketByUserNameCommand = new DeleteBasketByUserNameCommand(userName);
            return Ok(await _mediator.Send(deleteBasketByUserNameCommand));
        }

    }
}
