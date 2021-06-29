using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Queries
{
    public class GetProductListQuery : IRequest<GetProductListResult>
    {
    }
}
