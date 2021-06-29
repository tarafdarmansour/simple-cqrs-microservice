using Microsoft.Extensions.DependencyInjection;
using Nest;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSearchService.DataAccess.ElasticSearch
{
    public static class NestInstaller
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services, string cnString)
        {
            services.AddSingleton(typeof(ElasticClient), svc => CreateElasticClient(cnString));
            services.AddScoped(typeof(IProductSearchRepository), typeof(ProductRepository));
            return services;
        }

        private static ElasticClient CreateElasticClient(string cnString)
        {
            var settings = new ConnectionSettings(new Uri(cnString))
                .DefaultIndex("simple-cqrs-microservice");
            var client = new ElasticClient(settings);
            return client;
        }
    }
}
