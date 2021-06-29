using ProductService.ProductDBContext;
using System.Threading.Tasks;

namespace ProductService.Messaging.RabbitMQ.Outbox
{
    public class OutboxEventPublisher : IEventPublisher
    {
        private readonly ProductContext _context;

        public OutboxEventPublisher(ProductContext context)
        {
            _context = context;
        }

        public async Task PublishMessage<T>(T msg)
        {
            await _context.Messages.AddAsync(new Message(msg));
        }
    }
}