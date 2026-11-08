using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalog.Core.Specs
{
    // this is an request parameter class for catalog spec, it will be used to filter the products based on brand, type, sort and search
    public class CatalogSpecParms
    {
        private const int MaxPageSize = 80; // Maximum page size allowed
        private int _pageSize = 10; // Default number item in each page = 10
        public int PageIndex { get; set; } = 1;// Current page index
        public int PageSize // Number of items per page
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string? BrandId { get; set; }
        public string? TypeId { get; set; }
        public string? Sort { get; set; }
        private string? _search;
        public string? Search
        {
            get;
            set;
        }
    }
}
