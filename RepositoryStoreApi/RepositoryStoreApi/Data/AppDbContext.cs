using Microsoft.EntityFrameworkCore;
using RepositoryStoreApi.Models;

namespace RepositoryStoreApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
}
