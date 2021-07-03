using System.Threading;
using System.Threading.Tasks;
using ProductSearchService.Models;
using ProductService.Events;
using MediatR;
using ProductSearchService.Domain;

namespace DashboardService.Listeners
{
    public class ProductUpdatedHandler : INotificationHandler<ProductUpdated>
    {
        private readonly IProductSearchRepository _repository;

        public ProductUpdatedHandler(IProductSearchRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ProductUpdated notification, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(notification.Id);

            entity.UpdateSearchProduct(notification);

            await _repository.Update(entity);
            

        }
    }
}
