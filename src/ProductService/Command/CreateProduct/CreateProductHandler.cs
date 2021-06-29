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
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly ILogger<CreateProductHandler> _logger;
        private readonly ProductContext _context;
        private readonly IEventPublisher _eventPublisher;

        public CreateProductHandler(ILogger<CreateProductHandler> logger,ProductContext context, IEventPublisher eventPublisher)
        {
            _logger = logger;
            _context = context;
            _eventPublisher = eventPublisher;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var Product = new Product(request.Name, request.CategoryName, request.Manufacturer);

            await _context.Products.AddAsync(Product,cancellationToken);

            await _eventPublisher.PublishMessage(ProductCreated(Product));

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductResult { CreateDateTime = Product.CreateDateTime, Id = Product.Id };
        }

        private ProductCreated ProductCreated(Product Product)
        {
            return new ProductCreated
            {
                Id = Product.Id,
                Manufacturer = Product.Manufacturer,
                Name = Product.Name,
                CategoryName = Product.CategoryName
            };
        }
    }
}
