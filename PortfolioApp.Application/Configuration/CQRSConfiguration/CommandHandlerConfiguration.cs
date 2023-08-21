using Microsoft.Extensions.DependencyInjection;
using PortfolioApp.Application.Common.Interfaces.CQRS;

namespace PortfolioApp.Application.Configuration.CQRSConfiguration
{
    public static class CommandHandlerConfiguration
    {
        public static IServiceCollection AddCommandHandler
            <TCommand, TCommandHandler>(
            this IServiceCollection services
        ) where TCommandHandler : class, ICommandHandler<TCommand>
        {

            services.AddTransient<ICommandHandler<TCommand>, TCommandHandler>()
                    .AddTransient<CommandHandler<TCommand>>(
                        sp => sp.GetRequiredService
                        <ICommandHandler<TCommand>>().Handle
                );

            return services;
        }
    }

    public delegate ValueTask
        CommandHandler<in TCommand>(TCommand command, CancellationToken ct);
}
