using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _reduisCach;

        public BasketRepository(IDistributedCache reduisCach)
        {
            _reduisCach = reduisCach;
        }
        public async Task<ShoppindCart> GetBasket(string userName)
        {
            var basket = await _reduisCach.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                throw new Exception("Basket aready exists"); 
            var ShoppindCart = JsonConvert.DeserializeObject<ShoppindCart>(basket); 
            return ShoppindCart!;
        }
        public async Task<ShoppindCart> UpdateBasket(ShoppindCart cart)
        {
            var basket = await GetBasket(cart.UserName);  // update the basket in redis cache 
            if (basket != null)
             return await GetBasket(cart.UserName); // muist addanlogic
           
            await _reduisCach.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
            return await GetBasket(cart.UserName);
            
        }
        public async Task DeleteBasket(string userName)
        {
            var basket = await _reduisCach.GetStringAsync(userName);
            if (basket != null)
               await  _reduisCach.RemoveAsync(userName); // if the basket is null or empty return null
            else
                throw new Exception("Basket not found"); // if the basket is not null or empty return the basket with the userName
        }


    }
}
