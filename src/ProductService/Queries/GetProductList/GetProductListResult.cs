using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Queries
{
    public class GetProductListResult
    {
        public List<GetProductListResultItem> ProductListResultItems { get; set; }
    }

    public class GetProductListResultItem
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}
