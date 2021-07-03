using ProductService.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSearchService.Models
{
    public class SearchProduct
    {
        public SearchProduct()
        {

        }
        public SearchProduct(ProductCreated Product)
        {
            Id = Product.Id;
            Name = Product.Name;
            CategoryName = Product.CategoryName;
            Manufacturer = Product.Manufacturer;
            CreateDateTime = DateTime.Now;
        }

        public void UpdateSearchProduct(ProductUpdated Product)
        {
            Name = Product.Name;
            CategoryName = Product.CategoryName;
            Manufacturer = Product.Manufacturer;
            UpdateDateTime = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string CategoryName { get;  set; }
        public string Manufacturer { get;  set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }

}
