using catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.InfratStructure.Data.Context
{
    public class ProductContextsSeed
    {

        public static async Task SeedDataAsync(IMongoCollection<Product> ProductCollection)
        {
            bool existProduct = await ProductCollection.Find(b => true).AnyAsync();
            if (!existProduct)
            {
                var filePath = GetPreconfiguredBrands();
                var Products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(filePath);
                await ProductCollection.InsertManyAsync(Products);
            }
        }

        private static string GetPreconfiguredBrands()
        {
            var filePath = Path.Combine("Data/SeedData/products.json");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            return File.ReadAllText(filePath);
        }
    }
}
