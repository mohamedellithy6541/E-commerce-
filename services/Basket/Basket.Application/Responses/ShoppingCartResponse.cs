using Basket.Core.Entities;

namespace Basket.Application.Responses
{
    public class ShoppingCartResponse
    {
        public ShoppingCartResponse()
        {

        }

        public string UserName { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }

        }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
