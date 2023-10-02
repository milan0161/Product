using MinimalAPI.Middleware;
using Persistence;
using Infrastructure;
using Application;
using MinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices().AddInfrastructureServices();



var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapGet("/", () => "Hello World!");
app.MapPost("/", PerfumeEndpoints.CreateProduct);

app.Run();
