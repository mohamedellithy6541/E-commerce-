using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands
{
    public class CreateBasketCommand : IRequest<ShoppingCartResponse>
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public CreateBasketCommand(string userName)
        {
            this.UserName = userName;
        }
    }
}
