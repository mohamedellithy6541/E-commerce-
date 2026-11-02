using catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.InfratStructure.Data.Context
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> products { get; } 
        IMongoCollection<ProductBrand> productBrands { get; } 
        IMongoCollection<ProductType> productTypes { get; } 
         
    }
}
