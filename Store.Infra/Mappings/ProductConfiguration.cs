using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Context.Entities;

namespace Store.Infra.Mappings
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id);
            builder.Property(c => c.Name);
            builder.Property(c => c.Description);
            builder.Property(c => c.Price);
            builder.Property(c => c.CreationDate);
        }
    }
}