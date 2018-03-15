using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Context.Entities;

namespace Store.Infra.Mappings
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Number);
            builder.Property(c => c.CreationDate);
            builder.HasOne(c => c.User);
            builder.HasMany(c => c.Items);
        }
    }
}