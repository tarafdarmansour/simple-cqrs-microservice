using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductSearchService.Models;
using ProductSearchService.Queries;
using MediatR;

namespace ProductSearchService.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IMediator _bus;

        public SearchController(ILogger<SearchController> logger, IMediator bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchProduct(string query)
        {
            var cmd = new GetSearchProductListQuery() { query = query};
            var result = await _bus.Send(cmd);

           return PartialView("_SearchResult",result);
        }
    }
}
