using Microsoft.EntityFrameworkCore;
using PortfolioApp.Application.Configuration;
using PortfolioApp.Infrastructure.Persistence;
using PortfolioApp.Infrastructure.Persistence.Configurations;
using PortfolioApp.WebAPI.Items;
using PortfolioApp.WebAPI.Middlewares.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer()
.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioConnectionString")));


builder.Services.AddApplicationServices(builder.Configuration)
.AddInfrastructureServices(builder.Configuration)
.AddQueries()
.AddCommands();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.MapGet("/", () => "Hello World!");

app.MapItems();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
