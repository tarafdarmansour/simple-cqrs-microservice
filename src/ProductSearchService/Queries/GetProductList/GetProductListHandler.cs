using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSearchService.Queries
{
    public class GetSearchProductListHandler : IRequestHandler<GetSearchProductListQuery, GetSearchProductListResult>
    {
        private readonly ILogger<GetSearchProductListHandler> _logger;
        private readonly IProductSearchRepository _repository;

        public GetSearchProductListHandler(ILogger<GetSearchProductListHandler> logger, IProductSearchRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task<GetSearchProductListResult> Handle(GetSearchProductListQuery request, CancellationToken cancellationToken)
        {

            var Products = await _repository.Find(request.query);

            GetSearchProductListResult getProductListResult = new GetSearchProductListResult
            {
                SearchProductListResultItems = Products.Select(c => new GetSearchProductListResultItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    CategoryName = c.CategoryName,
                    Manufacturer = c.Manufacturer
                })
                .ToList()
            };

            return getProductListResult;

        }

    }
}
