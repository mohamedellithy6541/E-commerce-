using catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Application.Quaries
{
    public class GetProductByIdQuery:IRequest<ProductResponseDto>
    {
        public GetProductByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
