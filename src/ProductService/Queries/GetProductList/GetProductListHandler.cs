using ProductService.ProductDBContext;
using ProductService.Events;
using ProductService.Messaging;
using ProductService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Queries
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, GetProductListResult>
    {
        private readonly ILogger<GetProductListHandler> _logger;
        private readonly ProductContext _context;

        public GetProductListHandler(ILogger<GetProductListHandler> logger, ProductContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<GetProductListResult> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {

            var Products = await _context.Products.ToListAsync();

            GetProductListResult getProductListResult = new GetProductListResult
            {
                ProductListResultItems = Products.Select(c => new GetProductListResultItem
                {
                    Id = c.Id,
                    Manufacturer = c.Manufacturer.ToString(),
                    Name = c.Name,
                    CategoryName = c.CategoryName
                })
                .ToList()
            };

            return getProductListResult;

        }

    }
}
