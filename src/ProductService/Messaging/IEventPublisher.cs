using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Messaging
{
    public interface IEventPublisher
    {
        Task PublishMessage<T>(T msg);
    }
}
