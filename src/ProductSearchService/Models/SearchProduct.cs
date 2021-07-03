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

        public Guid Id { get; protected set; }
        public string Name { get;  set; }
        public string CategoryName { get;  set; }
        public string Manufacturer { get;  set; }
        public DateTime CreateDateTime { get; protected set; }
        public DateTime? UpdateDateTime { get; protected set; }
    }

}
