using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Appliclication.Commands
{
    public class DeleteDiscountCommand : IRequest<bool>
    {
        public DeleteDiscountCommand(string productName)
        {
            ProductName = productName;  
        }
        public string ProductName { get; set; }
    
    }
}
