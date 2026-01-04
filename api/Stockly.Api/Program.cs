using Stockly.Api.Routes;
using Stockly.Application.DependencyInjection;
using Stockly.Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add modules
builder.Services
    .AddInfraModule(builder.Configuration)
    .AddApplicationModule();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapAuthEndpoints();


app.Run();