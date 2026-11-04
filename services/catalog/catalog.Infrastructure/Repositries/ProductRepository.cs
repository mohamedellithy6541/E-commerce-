using catalog.Core.Entities;
using catalog.Core.Repository;
using catalog.InfratStructure.Data.Context;
using MongoDB.Driver;

namespace catalog.InfraStructure.Repositries
{
    public class ProductRepository : IProductRepository, IProductBrandRepository, IProductTypeRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _context = catalogContext;
        }
        public async Task<Product> CreatProduct(Product product)
        {
            await _context.products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            var Deleted =await _context.products.DeleteOneAsync(p => p.Id == product.Id);
            return Deleted.IsAcknowledged && Deleted.DeletedCount > 0;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
         => await _context.productBrands.Find(p => true).ToListAsync();
        public async Task<IEnumerable<Product>> GetAllProducts()
            => await _context.products.Find(p => true).ToListAsync();
        public async Task<IEnumerable<ProductType>> GetAllTypes()
       => await _context.productTypes.Find(p => true).ToListAsync();
        public async Task<Product> GetProductById(string id)
         => await _context.products.Find(p => p.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Product>> GetProductsByBrandName(string Name)
        => await _context.products.Find(p => p.Brand.Name == Name).ToListAsync();
        public async Task<IEnumerable<Product>> GetProductsByName(string Name)
        => await _context.products.Find(p => p.Name == Name).ToListAsync();
        public async Task<bool> UpdateProduct(Product product)
        {
            var existingProduct = await _context.products.Find(p => p.Id == product.Id).FirstOrDefaultAsync();
            if (existingProduct == null)
                return false;
            var updated = await _context.products.ReplaceOneAsync(p => p.Id == product.Id, product);

            return updated.IsAcknowledged && updated.ModifiedCount > 0;
        }
    }
}
