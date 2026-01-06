using Scalar.AspNetCore;
using Stockly.Api.Middlewares;
using Stockly.Api.Routes;
using Stockly.Application.DependencyInjection;
using Stockly.Infra.DependencyInjection;
using Wolverine;
using Wolverine.FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddExceptionHandler<ValidationExceptionHandler>()
    .AddExceptionHandler<CommonExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Host.UseWolverine(opts =>
{
    opts.Discovery.IncludeAssembly(
        typeof(ApplicationModule).Assembly
    );
    opts.UseFluentValidation();
});

// Add modules
builder.Services
    .AddInfraModule(builder.Configuration)
    .AddApplicationModule();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/api-docs");
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapAuthEndpoints();

app.Run();