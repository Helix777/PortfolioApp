using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Common.Interfaces;
using PortfolioApp.Domain.Entities;
using PortfolioApp.Infrastructure.Persistence.DummyData;
using PortfolioApp.Infrastructure.Persistence.Repositories;

namespace PortfolioApp.Infrastructure.Persistence.Configurations
{
    public static class InfrastructureInstallation
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenericRepository<Item>, GenericRepository<Item>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            //services.AddScoped<IDummyUsers, DummyUsers>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
