using ProductService.Messaging.RabbitMQ.Outbox;
using ProductService.ModelConfiguration;
using ProductService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ProductService.ProductDBContext
{
    public class ProductContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public ProductContext(IConfiguration configuration, ILogger<ProductContext> logger)
        {
            _configuration = configuration;
            _logger = logger;

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new MessageConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
