using catalog.Core.Entities;
using catalog.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Core.Repository
{
    public interface IProductRepository
    {
        Task<Pagination<Product>> GetAllProducts(CatalogSpecParms catalogSpecParms);
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductsByName(string Name);
        Task<IEnumerable<ProductBrand>> GetBrandByName(string Name);
        Task<Product> CreatProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
    }
}
