using catalog.Core.Entities;
using catalog.Core.Repository;
using catalog.Core.Specs;
using catalog.Infrastructure.Data.Context;
using catalog.InfratStructure.Data.Context;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace catalog.Infrastructure.Repositries
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
            var Deleted = await _context.products.DeleteOneAsync(p => p.Id == product.Id);
            return Deleted.IsAcknowledged && Deleted.DeletedCount > 0;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
            => await _context.productBrands.Find(p => true).ToListAsync();

        public async Task<Pagination<Product>> GetAllProducts(CatalogSpecParms catalogSpecParms)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(catalogSpecParms.Search))
            {
                filter = filter & builder.Where(p => p.Name.ToLower().Contains(catalogSpecParms.Search.ToLower()));
            }
            if (!string.IsNullOrEmpty(catalogSpecParms.BrandId))
            {
                filter = filter & builder.Eq(p => p.Brand.Id, catalogSpecParms.BrandId);
            }
            if (!string.IsNullOrEmpty(catalogSpecParms.TypeId))
            {
                filter = filter & builder.Eq(p => p.Type.Id, catalogSpecParms.TypeId);
            }

            var totalcountItems = await _context.products.CountDocumentsAsync(filter);
            var date = await DataFilter(catalogSpecParms, filter);

            return new Pagination<Product>(catalogSpecParms.PageIndex,
                catalogSpecParms.PageSize,
                (int)totalcountItems, date);
        }
        public async Task<IEnumerable<ProductType>> GetAllTypes()
            => await _context.productTypes.Find(p => true).ToListAsync();

        public async Task<Product> GetProductById(string id)
            => await _context.products.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<ProductBrand>> GetBrandByName(string Name)
            => await _context.productBrands.Find(p => p.Name == Name).ToListAsync();

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



      private async Task<IReadOnlyList<Product>> DataFilter(CatalogSpecParms catalogSpecParms, FilterDefinition<Product> filter)
        {
            var sortDef = Builders<Product>.Sort.Ascending("name");
            if (!string.IsNullOrEmpty(catalogSpecParms.Sort))
            {
                switch (catalogSpecParms.Sort)
                {
                    case "PriceAsc":
                        sortDef = Builders<Product>.Sort.Ascending(p => p.Price);
                        break;
                    case "PriceDesc":
                        sortDef = Builders<Product>.Sort.Descending(p => p.Price);
                        break;
                    default:
                        sortDef = Builders<Product>.Sort.Ascending("name");
                        break;
                }
            }
            return await _context.products.Find(filter)
                .Sort(sortDef)
                .Skip(catalogSpecParms.PageSize * (catalogSpecParms.PageIndex - 1))
                .Limit(catalogSpecParms.PageSize)
                .ToListAsync();
        }
        
    }
}