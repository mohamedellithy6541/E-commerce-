using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Core.Entities
{
    public class ProductType 
        :BaseEntity
    {
        // [BsonElement("name")] when needed to change the name of the property in the database
        public string Name { get; set; }
    }
}
