using catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Application.Quaries
{
    public class GetBroductBrandByNameQuery : IRequest<IList<BrandResponseDto>>
    {
        public string Name { get; set; }
        public GetBroductBrandByNameQuery(string name)
        {
            Name = name;    
        }
    }
}
