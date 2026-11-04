using catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Core.Repository
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAllTypes();
    }
}
