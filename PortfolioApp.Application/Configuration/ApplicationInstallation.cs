using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Configuration.CQRSConfiguration;
using PortfolioApp.Application.Items.Commands.AddItem;
using PortfolioApp.Application.Items.Queries.GetItemById;
using PortfolioApp.Application.Items.Queries.GetItems;
using PortfolioApp.Application.Items.Validators;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Configuration
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddQueries
            (this IServiceCollection services)
        {
            services.AddQueryHandler<GetItemByIdQuery, Item, GetItemByIdQueryHandler>();
            services.AddQueryHandler<GetItemsQuery, IEnumerable<Item>, GetItemsQueryHandler>();
            return services;
        }
        public static IServiceCollection AddCommands
            (this IServiceCollection services)
        {
            services.AddCommandHandler<AddItemCommand, AddItemCommandHandler>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IValidator<Item>, ItemValidator>();
            return serviceCollection;
        }
    }
}
