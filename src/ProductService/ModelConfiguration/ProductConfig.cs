using ProductService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductService.ModelConfiguration
{

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.Name).HasMaxLength(200);
            builder.Property(c => c.CategoryName).HasMaxLength(200);
            builder.Property(c => c.Manufacturer).HasMaxLength(200);
            builder.Property(c => c.CreateDateTime).HasDefaultValueSql("GETDATE()");

        }
    }
}