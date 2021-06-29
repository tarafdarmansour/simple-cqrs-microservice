using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Command
{
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string CategoryName { get;  set; }
        public string Manufacturer { get;  set; }
    }
}
