using catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Application.Quaries
{
    public class GetAllProductsQuery : IRequest<IList<ProductResponseDto>>
    {
    }
}
