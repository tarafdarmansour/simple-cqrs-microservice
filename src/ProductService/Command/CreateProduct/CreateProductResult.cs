using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Command
{
    public class CreateProductResult
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
