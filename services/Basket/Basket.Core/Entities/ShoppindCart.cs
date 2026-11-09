using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entities
{
    public class ShoppindCart
    {
        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public ShoppindCart()
        {

        }
        public ShoppindCart(string userName)
        {
            UserName = userName;
        }
    }
}
