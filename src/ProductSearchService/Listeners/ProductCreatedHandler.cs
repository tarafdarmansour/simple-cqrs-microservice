using System.Threading;
using System.Threading.Tasks;
using ProductSearchService.Models;
using ProductService.Events;
using MediatR;
using ProductSearchService.Domain;

namespace DashboardService.Listeners
{
    public class ProductCreatedHandler : INotificationHandler<ProductCreated>
    {
        private readonly IProductSearchRepository _repository;

        public ProductCreatedHandler(IProductSearchRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {

            await _repository.Add(new SearchProduct(notification));
            

        }
    }
}
