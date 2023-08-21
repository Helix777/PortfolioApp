
using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Common.Interfaces.CQRS;

namespace PortfolioApp.Application.Configuration.CQRSConfiguration
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection AddQueryHandler<TQuery, TResult, TQueryHandler>
            (this IServiceCollection services)
            where TQueryHandler : class, IQueryHandler<TQuery, TResult>
        {
            services.AddTransient<IQueryHandler<TQuery, TResult>, TQueryHandler>()
                .AddTransient<QueryHandler<TQuery, TResult>>(
                sp => sp.GetRequiredService<IQueryHandler<TQuery, TResult>>().Handle);

            return services;
        }

        public delegate ValueTask<TResult>
            QueryHandler<in TQuery, TResult>(TQuery query, CancellationToken cancellation);
    }
}
