using System.Threading;
using System.Threading.Tasks;
using ProductSearchService.Models;
using ProductService.Events;
using MediatR;
using ProductSearchService.Domain;
using System;

namespace DashboardService.Listeners
{
    public class ProductDeletedHandler : INotificationHandler<ProductDeleted>
    {
        private readonly IProductSearchRepository _repository;

        public ProductDeletedHandler(IProductSearchRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ProductDeleted notification, CancellationToken cancellationToken)
        {

            var entity = await _repository.GetById(notification.Id);

            await _repository.Delete(entity);


        }
    }
}
