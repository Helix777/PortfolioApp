namespace PortfolioApp.Application.Common.Interfaces.CQRS
{
    public interface IQueryHandler<in TQuery, TResult>
    {
        ValueTask<TResult> Handle(TQuery query, CancellationToken cancellation);
    }

    public interface ICommandHandler<in TCommand>
    {
        ValueTask Handle(TCommand command, CancellationToken cancellation);
    }
}
