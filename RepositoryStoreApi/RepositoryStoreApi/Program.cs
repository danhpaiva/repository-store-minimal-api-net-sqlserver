using Microsoft.EntityFrameworkCore;
using RepositoryStoreApi.Data;
using RepositoryStoreApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<ProductRepository>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/v1/products", async (ProductRepository repository) => {
    var products = await repository.GetAllAsync(0, 10);
});

app.MapPost("/v1/products", async (AppDbContext context) => "Hello World");
app.MapPut("/v1/products", async (AppDbContext context) => "Hello World");
app.MapDelete("/v1/products", async (AppDbContext context) => "Hello World");

app.Run();