using RepositoryStoreApi.Data;
using RepositoryStoreApi.Models;

namespace RepositoryStoreApi.Repositories;

public class ProductRepository(AppDbContext context)
{
    public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return product;
    }
}
