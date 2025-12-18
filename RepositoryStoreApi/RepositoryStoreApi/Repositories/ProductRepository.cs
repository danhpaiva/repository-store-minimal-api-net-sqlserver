using Microsoft.EntityFrameworkCore;
using RepositoryStoreApi.Data;
using RepositoryStoreApi.Models;
using RepositoryStoreApi.Repositories.Abstractions;

namespace RepositoryStoreApi.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task DeleteAsync(Product product, CancellationToken cancellationToken = default)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<Product>> GetAllAsync(int skip = 0, int take = 25, CancellationToken cancellationToken = default)
    {
        return await context
            .Products
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync(cancellationToken);
    }
}
