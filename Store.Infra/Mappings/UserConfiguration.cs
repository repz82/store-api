using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Context.Entities;

namespace Store.Infra.Mappings
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id);
            builder.OwnsOne(c => c.FullName);
            builder.OwnsOne(c => c.UserName);
            builder.OwnsOne(c => c.Password);
            builder.OwnsOne(c => c.Email);
        }
    }
}