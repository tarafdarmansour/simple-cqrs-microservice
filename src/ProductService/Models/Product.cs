using System;

namespace ProductService.Models
{

    public class Product
    {
        public Product(string name,string categoryname,string manufacturer)
        {
            Id = Guid.NewGuid();
            Name = name;
            CategoryName = categoryname;
            Manufacturer = manufacturer;
        }

        public Product UpdateProduct(Product product)
        {
            this.Name = product.Name;
            this.CategoryName = product.CategoryName;
            this.Manufacturer = product.Manufacturer;
            this.UpdateDateTime = DateTime.Now;
            return this;
        }

        private Product()
        {

        }

        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string CategoryName { get; protected set; }
        public string Manufacturer { get; protected set; }
        public DateTime CreateDateTime { get; protected set; }
        public DateTime? UpdateDateTime { get; protected set; }
    }

}