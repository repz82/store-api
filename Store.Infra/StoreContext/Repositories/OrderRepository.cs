using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Context.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Infra.StoreContext.DataContext;

namespace Store.Infra.StoreContext.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDataContext _context;

        public OrderRepository(StoreDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Get() => await _context.Orders.ToListAsync();

        public async Task Save(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
