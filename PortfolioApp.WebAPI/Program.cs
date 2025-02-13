using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PortfolioApp.Application.Configuration;
using PortfolioApp.Infrastructure.Persistence;
using PortfolioApp.Infrastructure.Persistence.Configurations;
using PortfolioApp.WebAPI.Api;
using PortfolioApp.WebAPI.Middlewares.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer()
.AddSwaggerGen( option => {
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
}



    );

builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioConnectionString")));

builder.Services.AddApplicationServices(builder.Configuration)
.AddAuthorizationService(builder.Configuration)
.AddInfrastructureServices(builder.Configuration)
.AddQueries()
.AddCommands();


var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.MapItems();
app.MapUsers();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.Run();
