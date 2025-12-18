using Microsoft.EntityFrameworkCore;
using RepositoryStoreApi.Data;
using RepositoryStoreApi.Models;
using RepositoryStoreApi.Repositories;
using RepositoryStoreApi.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/v1/products", async (IProductRepository repository, CancellationToken token) => {
    var products = await repository.GetAllAsync(0, 10, token);
});

app.MapGet("/v1/products/{id}", async (int id, IProductRepository repository) => {
    var product = await repository.GetByIdAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});

app.MapPost("/v1/products", async (Product product, IProductRepository repository, CancellationToken token) => {
    var createdProduct = await repository.CreateAsync(product, token);
    return Results.Created($"/v1/products/{createdProduct.Id}", createdProduct);
});

app.MapPut("/v1/products/{id}", async (int id, Product updatedProduct, IProductRepository repository, CancellationToken token) => {
    var existingProduct = await repository.GetByIdAsync(id);
    if (existingProduct is null)
    {
        return Results.NotFound();
    }
    existingProduct.Title = updatedProduct.Title;
    var product = await repository.UpdateAsync(existingProduct, token);
    return Results.Ok(product);
});

app.MapDelete("/v1/products/{id}", async (int id, IProductRepository repository, CancellationToken token) => {
    var existingProduct = await repository.GetByIdAsync(id);
    if (existingProduct is null)
    {
        return Results.NotFound();
    }
    await repository.DeleteAsync(existingProduct, token);
    return Results.NoContent();
});

app.Run();