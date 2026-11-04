using catalog.Core.Entities;
using catalog.InfratStructure.Data.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace catalog.Infrastructure.Data.Context
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> products { get; }
        public IMongoCollection<ProductBrand> productBrands { get; }
        public IMongoCollection<ProductType> productTypes { get; }



        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            products = database.GetCollection<Product>(configuration["DatabaseSettings:ProductsCollectionName"]);
            productBrands = database.GetCollection<ProductBrand>(configuration["DatabaseSettings:ProductBrandsCollectionName"]);
            productTypes = database.GetCollection<ProductType>(configuration["DatabaseSettings:ProductTypesCollectionName"]);

            _ = ProductContextsSeed.SeedDataAsync(products);
            _ = BrandContextSeed.SeedDataAsync(productBrands);
            _ = TypeContextSeed.SeedDataAsync(productTypes);
        }
    }
}