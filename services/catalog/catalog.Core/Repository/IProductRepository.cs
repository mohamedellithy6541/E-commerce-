using catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Core.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductsByName(string Name);
        Task<IEnumerable<Product>> GetProductsByBrandName(string Name);
        Task<bool> CreatProduct(Product product);
        Task<bool> UpdateProduct(string Id);
    }
}
