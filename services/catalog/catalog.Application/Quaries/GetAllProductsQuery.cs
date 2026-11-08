using catalog.Application.Responses;
using catalog.Core.Specs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Application.Quaries
{
    public class GetAllProductsQuery : IRequest<Pagination<ProductResponseDto>>
    {
        public CatalogSpecParms specParms { get; set; }
        public GetAllProductsQuery( CatalogSpecParms catalogSpecParms)
        {
            specParms = catalogSpecParms;
        }
    }
}
