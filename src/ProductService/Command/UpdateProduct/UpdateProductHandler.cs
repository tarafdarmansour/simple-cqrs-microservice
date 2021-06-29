using ProductService.ProductDBContext;
using ProductService.Events;
using ProductService.Messaging;
using ProductService.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Command
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly ILogger<UpdateProductHandler> _logger;
        private readonly ProductContext _context;
        private readonly IEventPublisher _eventPublisher;

        public UpdateProductHandler(ILogger<UpdateProductHandler> logger, ProductContext context, IEventPublisher eventPublisher)
        {
            _logger = logger;
            _context = context;
            _eventPublisher = eventPublisher;
        }
        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.Products.FindAsync(request.Id);
            if (entity != null)
            {
                entity.UpdateProduct(new Product(request.Name, request.CategoryName, request.Manufacturer));

                _context.Products.Update(entity);

                await _eventPublisher.PublishMessage(ProductUpdated(entity));

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdateProductResult { IsUpdated = true };
            }
            else
            {
                return new UpdateProductResult { IsUpdated = false };
            }

        }

        private ProductUpdated ProductUpdated(Product product)
        {
            return new ProductUpdated
            {
                Id = product.Id,
                Manufacturer = product.Manufacturer,
                Name = product.Name,
                CategoryName = product.CategoryName
            };
        }
    }
}
