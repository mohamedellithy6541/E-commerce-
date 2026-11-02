using catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.InfratStructure.Data.Context
{
    public class TypeContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductType> typecollection)
        {
            bool existType = await typecollection.Find(b => true).AnyAsync();
            if (!existType)
            {
                var filePath = GetPreconfiguredBrands();
                var Types = System.Text.Json.JsonSerializer.Deserialize<List<ProductType>>(filePath);
                await typecollection.InsertManyAsync(Types);
            }
        }

        private static string GetPreconfiguredBrands()
        {
            var filePath = Path.Combine("Data/SeedData/types.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            return File.ReadAllText(filePath);
        }
    }
}
