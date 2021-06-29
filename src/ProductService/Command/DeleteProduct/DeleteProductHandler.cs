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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {
        private readonly ILogger<DeleteProductHandler> _logger;
        private readonly ProductContext _context;
        private readonly IEventPublisher _eventPublisher;

        public DeleteProductHandler(ILogger<DeleteProductHandler> logger, ProductContext context, IEventPublisher eventPublisher)
        {
            _logger = logger;
            _context = context;
            _eventPublisher = eventPublisher;
        }
        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);

            if (entity != null)
            {
                _context.Products.Remove(entity);

                await _eventPublisher.PublishMessage(ProductDeleted(entity));

                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteProductResult { IsDeleted = true };
            }
            else
            {
                return new DeleteProductResult { IsDeleted = false };
            }

        }

        private ProductDeleted ProductDeleted(Product Product)
        {
            return new ProductDeleted
            {
                Id = Product.Id,
            };
        }
    }
}
