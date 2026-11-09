using Basket.Core.Entities;

namespace Basket.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppindCart> GetBasket(string userName);
        Task<ShoppindCart> UpdateBasket(ShoppindCart cart);
        Task DeleteBasket(string userName);

    }
}
