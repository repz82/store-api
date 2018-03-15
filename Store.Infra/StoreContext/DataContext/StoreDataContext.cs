using FluentValidator;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Context.Entities;
using Store.Domain.StoreContext.VO;
using Store.Infra.Mappings;
using System.Data.SqlClient;

namespace Store.Infra.StoreContext.DataContext
{
    public class StoreDataContext : DbContext
    {
        public SqlConnection Connection { get; set; }

        public StoreDataContext(DbContextOptions<StoreDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<Notification>();
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}