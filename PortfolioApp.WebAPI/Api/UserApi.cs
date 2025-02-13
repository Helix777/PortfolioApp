using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Configuration.CQRSConfiguration;
using PortfolioApp.Application.Users.Commands.AddUser;
using PortfolioApp.Application.Users.Queries.GenerateJwt;
using PortfolioApp.Application.Users.Queries.GetUserById;
using PortfolioApp.Domain.DTOs;
using PortfolioApp.Domain.Entities;
using System.Net;
using static PortfolioApp.Application.Configuration.CQRSConfiguration.QueryHandlerConfiguration;

namespace PortfolioApp.WebAPI.Api
{
    internal static class UserApi
    {
        public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api");

            group.WithTags("Users");

            group.MapGet("/users/{userId}", GetUserById)
                .Produces((int)HttpStatusCode.BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            async ValueTask<IResult> GetUserById(
                [FromServices] QueryHandler<GetUserByIdQuery, User> GetUserByIdQueryHandler,
                int userId,
                CancellationToken ct)
            {
                var user = await GetUserByIdQueryHandler(GetUserByIdQuery.With(userId), ct);
                return user != null ? Results.Ok(user) : Results.NotFound();
            };

            group.MapPost("/users", HandlerAddUser)
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest);

            async Task<IResult> HandlerAddUser([FromServices] CommandHandler<AddUserCommand> handler, AddUserCommand request, CancellationToken ct)
            {
                Console.WriteLine("================");
                await handler(request, ct);

                return Results.Ok();
            }

            group.MapPost("/login", GenerateJwt)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

            async Task<IResult> GenerateJwt([FromServices] QueryHandler<GenerateJwtQuery, string> GenerateJwtQueryHandler,
                LoginDto loginDto,
                CancellationToken ct)
            {
                Console.WriteLine("================");
                var token = await GenerateJwtQueryHandler(GenerateJwtQuery.With(loginDto), ct);

                return Results.Ok(token);
            }


            return group;
        }
    }
}
