using Basket.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries
{
    public class GetBasketQueryByUserName:IRequest<ShoppingCartResponse>
    {
        public GetBasketQueryByUserName(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }    
    }
}
