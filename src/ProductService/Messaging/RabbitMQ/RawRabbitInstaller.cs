using System;
using System.Collections.Generic;
using ProductService.Messaging.RabbitMQ.Outbox;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Extensions.Client;

namespace ProductService.Messaging.RabbitMQ
{
    public static class RawRabbitInstaller
    {
        public static IServiceCollection AddRabbit(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddRawRabbit(
                cfg => cfg.AddJsonFile(
                    env.EnvironmentName == "Production" ? "rabbit.Production.json" : "rabbit.Development.json")
            );

            services.AddScoped<IEventPublisher, OutboxEventPublisher>();
            services.AddSingleton<Outbox.Outbox>();
            services.AddHostedService<OutboxSendingService>();
            return services;
        }
    }
}
