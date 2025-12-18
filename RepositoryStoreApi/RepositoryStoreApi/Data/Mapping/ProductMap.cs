using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryStoreApi.Models;

namespace RepositoryStoreApi.Data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
            .IsRequired(true)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");
    }
}
