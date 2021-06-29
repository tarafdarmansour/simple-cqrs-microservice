using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductService.Models;
using MediatR;
using ProductService.Command;
using ProductService.Queries;
using ProductService.Messaging.RabbitMQ.Outbox;

namespace ProductService.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _bus;
        private readonly List<string> ManufacturerList;

        public ProductController(ILogger<ProductController> logger, IMediator bus)
        {
            _logger = logger;
            _bus = bus;
            ManufacturerList = new List<string>
            {
                "Apple","Microsoft","Ubber","Samsung","Busch","OGeneral"
            };
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var cmd = new GetProductListQuery();
            var result = await _bus.Send(cmd);

            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] DeleteProductCommand cmd)
        {
            var result = await _bus.Send(cmd);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> Update([FromBody] UpdateProductCommand cmd)
        {
            var result = await _bus.Send(cmd);
            return new JsonResult(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromForm] CreateProductCommand cmd)
        {
            var result = await _bus.Send(cmd);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<JsonResult> AddRandomProduct()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            string postfix = r.Next(50, 100).ToString();
            var cmd = new CreateProductCommand()
            {
                Manufacturer = ManufacturerList[r.Next(0, 7)],
                Name = "Product" + postfix,
                CategoryName = "Category" + postfix
            };

            var result = await _bus.Send(cmd);

            if (result.Id != Guid.Empty)
                return new JsonResult("ok");

            return new JsonResult("notok");

        }
    }
}
