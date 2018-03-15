using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Context.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Infra.StoreContext.DataContext;

namespace Store.Infra.StoreContext.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDataContext _context;

        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Get() => await _context.Products.ToListAsync();

        public async Task Save(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}
