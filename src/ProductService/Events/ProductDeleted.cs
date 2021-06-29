using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Events
{
    public class ProductDeleted : INotification
    {
        public Guid Id { get; set; }
    }
}
