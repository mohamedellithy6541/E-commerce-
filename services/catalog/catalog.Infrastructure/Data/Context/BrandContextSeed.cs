using catalog.Core.Entities;
using MongoDB.Driver;

namespace catalog.InfratStructure.Data.Context
{
    public class BrandContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductBrand> brandCollection)
        {
            bool existBrand = await brandCollection.Find(b => true).AnyAsync();
            if (!existBrand)
            {
                var filePath = GetPreconfiguredBrands();

                var Brands = System.Text.Json.JsonSerializer.Deserialize<List<ProductBrand>>(filePath);
                await brandCollection.InsertManyAsync(Brands);
            }
        }

        private static string GetPreconfiguredBrands()
        {
            var filePath = Path.Combine("Data/SeedData/brands.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            return File.ReadAllText(filePath);
        }
    }
}
