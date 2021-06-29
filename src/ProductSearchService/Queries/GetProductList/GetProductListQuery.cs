using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSearchService.Queries
{
    public class GetSearchProductListQuery : IRequest<GetSearchProductListResult>
    {
        public string query { get; set; }
    }
}
