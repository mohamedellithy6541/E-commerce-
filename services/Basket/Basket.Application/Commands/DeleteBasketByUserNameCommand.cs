using MediatR;

namespace Basket.Application.Commands
{
    public class DeleteBasketByUserNameCommand : IRequest<Unit>
    {
        public DeleteBasketByUserNameCommand(string userName)
        {
            this.userName = userName;
        }
        public string userName { get; set; }
    }
}
