using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSearchService.Queries
{
    public class GetSearchProductListResult
    {
        public List<GetSearchProductListResultItem> SearchProductListResultItems { get; set; }
    }

    public class GetSearchProductListResultItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Manufacturer { get; set; }
    }
}
