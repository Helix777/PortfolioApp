using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Infrastructure.Persistence.Repositories;

namespace PortfolioApp.Infrastructure.Persistence.Configurations
{
    public static class InfrastructureInstalllation
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenericRepository<Item>, GenericRepository<Item>>();
            services.AddScoped<IItemRepository, ItemRepository>();
            return services;
        }
    }
}
