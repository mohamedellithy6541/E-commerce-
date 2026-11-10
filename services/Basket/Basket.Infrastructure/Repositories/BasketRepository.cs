using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCach)
        {
            _redisCache = redisCach;
        }
        public async Task<ShoppingCart?> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }
        public async Task<ShoppingCart?> UpdateBasket(ShoppingCart cart)
        {
            await _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
            return await GetBasket(cart.UserName);
        }
        public async Task DeleteBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (basket != null)
               await _redisCache.RemoveAsync(userName); // if the basket is null or empty return null
            else
                throw new Exception("Basket not found"); // if the basket is not null or empty return the basket with the userName
        }


    }
}
