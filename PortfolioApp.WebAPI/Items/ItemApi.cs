using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Configuration.CQRSConfiguration;
using PortfolioApp.Application.Items.Commands.AddItem;
using PortfolioApp.Application.Items.Queries.GetItemById;
using PortfolioApp.Application.Items.Queries.GetItems;
using PortfolioApp.Domain.Entities;
using System.Net;
using static PortfolioApp.Application.Configuration.CQRSConfiguration.QueryHandlerConfiguration;

namespace PortfolioApp.WebAPI.Items
{
    internal static class ItemApi
    {
        public static RouteGroupBuilder MapItems(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/items");

            group.WithTags("Items");

            group.MapGet("/api/items/{itemId}", GetItemById)
                .Produces((int)HttpStatusCode.BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            async ValueTask<IResult> GetItemById(
                [FromServices] QueryHandler<GetItemByIdQuery, Item> GetItemByIdQueryHandler,
                int itemId,
                CancellationToken ct)
            {
                var item = await GetItemByIdQueryHandler(GetItemByIdQuery.With(itemId), ct);
                return item != null ? Results.Ok(item) : Results.NotFound();
            };

            group.MapGet("/api/items", GetItems)
                .Produces((int)HttpStatusCode.BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            ValueTask<IEnumerable<Item>> GetItems(
                [FromServices] QueryHandler<GetItemsQuery, IEnumerable<Item>> GetItemsQueryHandler,
                int? page,
                int? pageSize,
                CancellationToken ct)
            =>
                GetItemsQueryHandler(GetItemsQuery.With(page, pageSize), ct);

            group.MapPost("/api/items", HandlerAddItem)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest);

            async Task<IResult> HandlerAddItem([FromServices] CommandHandler<AddItemCommand> handler, AddItemCommand request, CancellationToken ct)
            {
                Console.WriteLine("================");
                await handler(request, ct);

                return Results.Ok();
            }


            return group;
        }
    }
}
