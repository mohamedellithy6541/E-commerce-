using catalog.Core.Entities;
using catalog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.InfraStructure.Repositries
{
    public class ProductRepository : IProductRepository , IProductBrandRepository, ITypeRepository
    {
        public Task<bool> CreatProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductType>> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByBrandName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
