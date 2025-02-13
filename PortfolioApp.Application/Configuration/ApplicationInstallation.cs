using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PortfolioApp.Application.Configuration.CQRSConfiguration;
using PortfolioApp.Application.Items.Commands.AddItem;
using PortfolioApp.Application.Items.Queries.GetItemById;
using PortfolioApp.Application.Items.Queries.GetItems;
using PortfolioApp.Application.Users.Commands.AddUser;
using PortfolioApp.Application.Users.Queries.GenerateJwt;
using PortfolioApp.Application.Users.Queries.GetUserById;
using PortfolioApp.Application.Validators;
using PortfolioApp.Domain.Configurations;
using PortfolioApp.Domain.Entities;
using System.Text;

namespace PortfolioApp.Application.Configuration
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddQueries
            (this IServiceCollection services)
        {
            services.AddQueryHandler<GetItemByIdQuery, Item, GetItemByIdQueryHandler>();
            services.AddQueryHandler<GetItemsQuery, IEnumerable<Item>, GetItemsQueryHandler>();

            services.AddQueryHandler<GetUserByIdQuery, User, GetUserByIdQueryHandler>();
            services.AddQueryHandler<GenerateJwtQuery, string, GenerateJwtQueryHandler>();
            return services;
        }
        public static IServiceCollection AddCommands
            (this IServiceCollection services)
        {
            services.AddCommandHandler<AddItemCommand, AddItemCommandHandler>();
            services.AddCommandHandler<AddUserCommand, AddUserCommandHandler>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IValidator<Item>, ItemValidator>();
            serviceCollection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            serviceCollection.AddValidatorsFromAssemblyContaining<ItemValidator>();
            serviceCollection.AddValidatorsFromAssemblyContaining<UserValidator>();

            serviceCollection.Configure<AuthenticationSettings>(configuration.GetSection("Authentication"));

            return serviceCollection;
        }

        public static IServiceCollection AddAuthorizationService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var authenticationSettings = new AuthenticationSettings();

            configuration.GetSection("Authentication").Bind(authenticationSettings);

            serviceCollection.AddSingleton(authenticationSettings);

            serviceCollection.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });
            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("HasAdminRole", builder => builder.RequireClaim("Role", "Admin", "SuperAdmin"));
            });



            return serviceCollection;
        }
    }
}
